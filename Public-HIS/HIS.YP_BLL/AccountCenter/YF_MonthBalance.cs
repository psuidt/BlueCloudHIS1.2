using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.Model;
using HIS.DAL;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 药房系统月结处理器
    /// </summary>
    public class YF_MonthBalance : MonthBalanceProcessor
    {

        /// <summary>
        /// 定义月结处理事件
        /// </summary>
        public event MonthAccountHandler AccountHandler;
        /// <summary>
        /// 月结对账算法
        /// </summary>
        /// <param name="accountList">月末未结算的各药品最后一笔台帐记录</param>
        protected DataTable CheckAccount(List<YP_Account> accountList)
        {
            DataTable wrongDt = base.BuildWrongDataTable();
            Hashtable makerdicDt = new Hashtable();
            foreach (YP_Account act in accountList)
            {
                if (!makerdicDt.ContainsKey(act.MakerDicID))
                {
                    makerdicDt.Add(act.MakerDicID, act);
                }
                else if (act.MAccountID > ((YP_Account)(makerdicDt[act.MakerDicID])).MAccountID)
                {
                    makerdicDt[act.MakerDicID] = act;
                }
            }
            foreach (object makerDicId in makerdicDt)
            {
                YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                YP_Account hashValue = (YP_Account)((DictionaryEntry)makerDicId).Value;
                _makerDicId = hashValue.MakerDicID;
                List<YP_Account> actList = accountList.FindAll(match);
                decimal balanceFee = 0;
                decimal storeFee = dal.YF_GetDrugFee(hashValue.DeptID, hashValue.MakerDicID);
                decimal storeNum = StoreFactory.GetQuery(ConfigManager.YF_SYSTEM).QueryNum(hashValue.MakerDicID,
                    hashValue.DeptID);
                foreach (YP_Account act in actList)
                {
                    if (act.AccountType == 0)
                    {
                        balanceFee = act.BalanceFee;
                    }
                }
                foreach (YP_Account act in actList)
                {
                    balanceFee += act.LenderFee;
                    balanceFee -= act.DebitFee;
                }

                if (Convert.ToDecimal(Math.Abs(hashValue.BalanceFee - balanceFee)) > 2
                    || Convert.ToDecimal(Math.Abs(hashValue.BalanceFee - storeFee)) > 2
                    || Math.Abs(hashValue.OverNum - storeNum) > 0)
                {
                    string drugName = DrugBaseDataBll.GetDurgName(hashValue.MakerDicID);
                    DataRow errorRow = wrongDt.NewRow();
                    errorRow["CHEMNAME"] = drugName;
                    errorRow["MAKERDICID"] = hashValue.MakerDicID;
                    errorRow["WRONGFEE"] = hashValue.BalanceFee - balanceFee;
                    errorRow["STOREWRONGFEE"] = storeFee - hashValue.BalanceFee;
                    errorRow["WRONGNUM"] = storeNum - hashValue.OverNum;
                    errorRow["BALANCEFEE"] = hashValue.BalanceFee;
                    errorRow["BALANCENUM"] = hashValue.OverNum;
                    errorRow["UNIT"] = hashValue.LeastUnit;
                    errorRow["UNITNUM"] = hashValue.UnitNum;
                    wrongDt.Rows.Add(errorRow);
                }
            }
            return wrongDt;
        }

        /// <summary>
        /// 药房系统对账
        /// </summary>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <returns>错误药品账目信息</returns>
        public override DataTable SystemCheckAccount(int deptId)
        {
            try
            {
                //触发事件
                _monthEvent.CurrentState = MonthAccountState.SystemChecking;
                AccountHandler(_monthEvent);
                IBaseDAL<YP_AccountHis> accountHisDao = BindEntity<YP_AccountHis>.CreateInstanceDAL(oleDb,
                    HIS.BLL.Tables.YF_ACCOUNTHIS);
                int maxId = accountHisDao.GetMaxId(BLL.Tables.yf_accounthis.ACCOUNTHISTORYID,
                    BLL.Tables.yf_accounthis.DEPTID + oleDb.EuqalTo() + deptId);
                YP_AccountHis prevHis = accountHisDao.GetModel(maxId);
                int checkYear, checkMonth;
                if (prevHis.AccountMonth != 12)
                {
                    checkYear = prevHis.AccountYear;
                    checkMonth = prevHis.AccountMonth + 1;
                }
                else
                {
                    checkYear = prevHis.AccountYear + 1;
                    checkMonth = 1;
                }
                IBaseDAL<YP_Account> accountDao = BindEntity<YP_Account>.CreateInstanceDAL(oleDb, HIS.BLL.Tables.YF_ACCOUNT);
                List<YP_Account> listAccount =
                       accountDao.GetListArray("AccountYear=" + checkYear.ToString() +
                       " AND AccountMonth=" + checkMonth.ToString() + " AND BALANCE_FLAG=0"
                       + " AND DeptId=" + deptId);
                DateTime currentTime = XcDate.ServerDateTime;
                DataTable rtnDt = CheckAccount(listAccount);
                //触发事件
                _monthEvent.CurrentState = MonthAccountState.Over;
                AccountHandler(_monthEvent);
                return rtnDt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 药房系统平帐
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        public override void BalanceAccount(int deptId)
        {
            try
            {
                //触发事件
                _monthEvent.CurrentState = MonthAccountState.SystemChecking;
                AccountHandler(_monthEvent);
                DataTable wrongAccountDt = SystemCheckAccount(deptId);
                AccountQuery query = AccountFactory.GetQuery(ConfigManager.YF_SYSTEM);
                IBaseDAL<YP_Account> accountDao = BindEntity<YP_Account>.CreateInstanceDAL(oleDb, BLL.Tables.YF_ACCOUNT);
                if (wrongAccountDt.Rows.Count > 0)
                {
                    //触发事件
                    _monthEvent.CurrentState = MonthAccountState.WriteAdjAccount;
                    AccountHandler(_monthEvent);
                    AdjAccount(deptId, wrongAccountDt, query, accountDao);
                }
                _monthEvent.CurrentState = MonthAccountState.Over;
                AccountHandler(_monthEvent);
            }
            catch (Exception error)
            {
                if (oleDb.IsInTransaction)
                {
                    oleDb.RollbackTransaction();
                }
                throw error;
            }
        }

        /// <summary>
        /// 药房月结
        /// </summary>
        /// <param name="regPeople">月结操作人员编码</param>
        /// <param name="regDept">月结科室编码</param>
        public override void MonthAccount(int regPeople, int regDept)
        {
            try
            {
                //锁住当前月结库房，确保月结时不进行任何操作 
                DateTime currentTime = XcDate.ServerDateTime;
                int accountDay = ConfigManager.GetAccountDay(regDept);
                YP_AccountHis lastAccount = new YF_AccountQuery().GetLastAccountHis(regDept);
                ConfigManager.BeginCheck(regDept);
                if (lastAccount != null)
                {
                    if (currentTime.Day == accountDay && currentTime.Month != lastAccount.AccountMonth)
                    {
                        currentTime = MonthAccountAction(regPeople, regDept, currentTime, false);
                    }
                    else
                    {
                        throw new Exception("当前日期不是月结日期或当月已做过月结，无法进行月结");
                    }
                }
                else
                {
                    if (currentTime.Day == accountDay)
                    {
                        currentTime = MonthAccountAction(regPeople, regDept, currentTime, false);
                    }
                    else
                    {
                        throw new Exception("当前日期不是月结日期，无法进行月结");
                    }
                }
                //库房解锁
                ConfigManager.EndCheck(regDept);
            }
            catch (Exception error)
            {
                //库房解锁
                ConfigManager.EndCheck(regDept);
                throw error;
            }
        }

        /// <summary>
        /// 药房系统月结具体操作
        /// </summary>
        /// <param name="regPeople">月结人员编码</param>
        /// <param name="regDept">月结药房编码</param>
        /// <param name="currentTime">当前事件</param>
        /// <param name="isInit">是否初始化月结</param>
        /// <returns>月结时间</returns>
        protected override DateTime MonthAccountAction(int regPeople, int regDept, DateTime currentTime, bool isInit)
        {
            try
            {
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                int billNum = 0;
                //申明月结历史记录操作对象
                IBaseDAL<YP_AccountHis> accountHisDao = BindEntity<YP_AccountHis>.CreateInstanceDAL(oleDb, HIS.BLL.Tables.YF_ACCOUNTHIS);
                IBaseDAL<YP_BillNumDic> billDao = BindEntity<YP_BillNumDic>.CreateInstanceDAL(oleDb, HIS.BLL.Tables.YP_BILLNUMDIC);
                IBaseDAL<YP_Account> accountDao = BindEntity<YP_Account>.CreateInstanceDAL(oleDb, HIS.BLL.Tables.YF_ACCOUNT);
                IBaseDAL<YP_Storage> yfStore = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, HIS.BLL.Tables.YF_STORAGE);
                //初始化月结
                if (!accountHisDao.Exists("DEPTID=" + regDept))
                {
                    YP_AccountHis accoutHis = new YP_AccountHis();
                    accoutHis.AccountMonth = currentTime.Month;
                    accoutHis.AccountYear = currentTime.Year;
                    accoutHis.BeginTime = accoutHis.EndTime = currentTime;
                    accoutHis.DeptID = regDept;
                    accoutHis.RegMan = regPeople;
                    accoutHis.RegTime = currentTime;
                    oleDb.BeginTransaction();
                    accountHisDao.Add(accoutHis);
                    //写月结期初台帐
                    billNum = ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YF_MONTHACCOUNT, regDept).BillNum;
                    //触发月结运行状态改变的事件
                    _monthEvent.CurrentState = MonthAccountState.WriteBeginAccount;
                    AccountHandler(_monthEvent);
                    WriteBeginDateAccount(accoutHis, billNum, accountDao, regDept);
                    oleDb.CommitTransaction();
                }
                else
                {
                    int maxId = accountHisDao.GetMaxId(BLL.Tables.yf_accounthis.ACCOUNTHISTORYID,
                        BLL.Tables.yf_accounthis.DEPTID + oleDb.EuqalTo() + regDept.ToString());
                    YP_AccountHis prevHis = accountHisDao.GetModel(maxId);
                    YP_AccountHis currentHis = new YP_AccountHis();
                    if (prevHis.AccountMonth != 12)
                    {
                        currentHis.AccountMonth = prevHis.AccountMonth + 1;
                        currentHis.AccountYear = prevHis.AccountYear;
                    }
                    else
                    {
                        currentHis.AccountMonth = 1;
                        currentHis.AccountYear = prevHis.AccountYear + 1;
                    }
                    currentHis.BeginTime = prevHis.EndTime;
                    currentHis.DeptID = regDept;
                    currentHis.EndTime = currentTime;
                    currentHis.RegMan = regPeople;
                    currentHis.RegTime = currentTime;
                    string strWhere = "AccountYear=" + currentHis.AccountYear +
                        " AND AccountMonth=" + currentHis.AccountMonth + " AND BALANCE_FLAG=0"
                        + " AND DeptId=" + regDept;
                    List<YP_Account> listAccount = accountDao.GetListArray(strWhere);
                    //触发月结运行状态改变的事件
                    _monthEvent.CurrentState = MonthAccountState.SystemChecking;
                    AccountHandler(_monthEvent);
                    if (CheckAccount(listAccount).Rows.Count != 0)
                    {
                        throw new Exception("账目错误，无法月结，请进行系统对账，查看明细");
                    }
                    oleDb.BeginTransaction();
                    accountHisDao.Add(currentHis);
                    billNum = ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YF_MONTHACCOUNT, regDept).BillNum;
                    BindEntity<YP_Account>.CreateInstanceDAL(oleDb, BLL.Tables.YF_ACCOUNT).Update(strWhere,
                        "BALANCE_FLAG=1", BLL.Tables.yf_account.ACCOUNTHISTORYID + oleDb.EuqalTo() + currentHis.AccountHistoryID);
                    List<YP_Account> endList = base.GetMonthEndData(listAccount, billNum, currentTime, currentHis.AccountHistoryID);
                    //写期末记录
                    //触发月结运行状态改变的事件
                    _monthEvent.CurrentState = MonthAccountState.WriteEndAccount;
                    AccountHandler(_monthEvent);
                    WriteEndDateAccount(endList, accountDao, yfStore);
                    //写期初记录
                    //触发月结运行状态改变的事件
                    _monthEvent.CurrentState = MonthAccountState.WriteBeginAccount;
                    AccountHandler(_monthEvent);
                    WriteBeginDateAccount(endList, accountDao);
                    oleDb.CommitTransaction();
                }
                //触发月结运行状态改变的事件
                _monthEvent.CurrentState = MonthAccountState.Over;
                AccountHandler(_monthEvent);
                return currentTime;
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 取消药房月结
        /// </summary>
        /// <param name="regPeople">取消人员编码</param>
        /// <param name="regDept">取消月结的药房编码</param>
        public override void CancelMonthAccount(int regPeople, int regDept)
        {
            try
            {
                oleDb.BeginTransaction();
                string strWhere = "";
                //获取当前时间
                DateTime currentTime = XcDate.ServerDateTime;
                //获取月结日
                int accountDay = ConfigManager.GetAccountDay(regDept);
                //获取上次月结记录
                YP_AccountHis lastAccount = new YF_AccountQuery().GetLastAccountHis(regDept);
                if (lastAccount == null)
                {
                    throw new Exception("没有月结历史记录，请先进行初始化月结");
                }
                if (BindEntity<YP_AccountHis>.CreateInstanceDAL(oleDb, BLL.Tables.YF_ACCOUNTHIS).GetListArray(BLL.Tables.yf_accounthis.DEPTID
                    + oleDb.EuqalTo() + lastAccount.DeptID).Count <= 1)
                {
                    throw new Exception("初始化月结不允许取消");
                }
                //判断是否可以取消月结
                if (currentTime.Month == lastAccount.AccountMonth && currentTime > lastAccount.RegTime)
                {
                    IBaseDAL<YP_AccountHis> accountHisDao = BindEntity<YP_AccountHis>.CreateInstanceDAL(oleDb,
                        HIS.BLL.Tables.YF_ACCOUNTHIS);
                    IBaseDAL<YP_Account> accountDao = BindEntity<YP_Account>.CreateInstanceDAL(oleDb, HIS.BLL.Tables.YF_ACCOUNT);
                    //删除前次月结历史记录
                    accountHisDao.Delete(lastAccount.AccountHistoryID);
                    //删除本月期末台帐
                    strWhere = "AccountMonth=" + currentTime.Month.ToString() + " AND " + "AccountType=1" +
                        " AND DeptID=" + regDept.ToString();
                    accountDao.Delete(strWhere);
                    int nextMonth;
                    if (currentTime.Month == 12)
                    {
                        nextMonth = 1;
                    }
                    else
                    {
                        nextMonth = currentTime.Month + 1;
                    }
                    //删除下月月期初台帐
                    strWhere = "AccountMonth=" + nextMonth.ToString() + " AND " + "AccountType=0" +
                        " AND DeptID=" + regDept.ToString();
                    accountDao.Delete(strWhere);
                    //将已经月结过的台帐记录设置成未月结
                    strWhere = "AccountMonth=" + currentTime.Month.ToString() +
                        " AND DeptID=" + regDept.ToString();
                    accountDao.Update(strWhere, "Balance_Flag=0");
                    //将下月的台帐记录中的会计月记录设置成当前月
                    strWhere = "AccountMonth=" + nextMonth.ToString() +
                        " AND DeptID=" + regDept.ToString();
                    accountDao.Update(strWhere, "AccountMonth=" + currentTime.Month.ToString());
                    oleDb.CommitTransaction();
                }
                else
                {
                    throw new Exception("本月还没有进行月结，因此无法取消月结");
                }
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 写药房期初台帐
        /// </summary>
        /// <param name="accountList">上月未结药品最后一笔台帐</param>
        /// <param name="accountDao">台帐表操作对象</param>
        protected override void WriteBeginDateAccount(List<YP_Account> accountList, IBaseDAL<YP_Account> accountDao)
        {
            try
            {
                foreach (YP_Account account in accountList)
                {
                    if (account.AccountMonth == 12)
                    {
                        account.AccountYear++;
                        account.AccountMonth = 1;
                    }
                    else
                    {
                        account.AccountMonth++;
                    }
                    account.Balance_Flag = 0;
                    account.AccountType = 0;
                    account.OpType = ConfigManager.OP_YF_MONTHACCOUNT;
                    accountDao.Add(account);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 写药房期末台帐
        /// </summary>
        /// <param name="accountHis"></param>
        /// <param name="billNum"></param>
        /// <param name="accountDao"></param>
        /// <param name="deptId"></param>
        protected override void WriteBeginDateAccount(YP_AccountHis accountHis, int billNum,
            IBaseDAL<YP_Account> accountDao, int deptId)
        {
            YP_Dal ypDal = new YP_Dal();
            ypDal._oleDb = oleDb;
            YP_Account account = new YP_Account();
            DataTable beginDataDt = ypDal.YF_Storage_GetListForAccount(deptId);
            for (int index = 0; index < beginDataDt.Rows.Count; index++)
            {
                DataRow dRow = beginDataDt.Rows[index];
                if (accountHis.RegTime.Month != 12)
                {
                    account.AccountMonth = accountHis.RegTime.Month + 1;
                    account.AccountYear = accountHis.RegTime.Year;
                }
                else
                {
                    account.AccountMonth = 1;
                    account.AccountYear++;
                }
                account.Balance_Flag = 0;
                account.BillNum = billNum;
                account.DeptID = deptId;
                account.AccountHistoryID = accountHis.AccountHistoryID;
                account.LeastUnit = Convert.ToInt32(dRow["UNIT"]);
                account.MakerDicID = Convert.ToInt32(dRow["MAKERDICID"]);
                account.OpType = ConfigManager.OP_YF_MONTHACCOUNT;
                account.OrderID = 0;
                account.RegTime = accountHis.RegTime;
                account.RetailPrice = Convert.ToDecimal(dRow["RETAILPRICE"]);
                account.StockPrice = Convert.ToDecimal(dRow["TRADEPRICE"]);
                account.UnitNum = Convert.ToInt32(dRow["PUNITNUM"]);
                account.OverNum = Convert.ToInt32(dRow["CURRENTNUM"]);
                account.BalanceFee = 0;
                int modNum = (Convert.ToInt32(account.OverNum) % Convert.ToInt32(account.UnitNum));
                if (modNum == 0)
                {
                    account.BalanceFee += (account.OverNum / account.UnitNum) * account.RetailPrice;
                }
                else
                {
                    account.BalanceFee += ((account.OverNum - modNum) / account.UnitNum) * account.RetailPrice;
                    account.BalanceFee += (Convert.ToDecimal(modNum) / Convert.ToDecimal(account.UnitNum)) * account.RetailPrice;
                }
                accountDao.Add(account);
            }
        }

        /// <summary>
        /// 写期末月结台帐
        /// </summary>
        /// <param name="accountList">上月未结药品最后一笔台帐</param>
        /// <param name="accountDao">台帐表操作对象</param>
        /// <param name="ypStore">库存表操作对象</param>
        protected override void WriteEndDateAccount(List<YP_Account> accountList, IBaseDAL<YP_Account> accountDao,
            IBaseDAL<YP_Storage> ypStore)
        {
            try
            {
                foreach (YP_Account account in accountList)
                {
                    account.Balance_Flag = 1;
                    account.AccountType = 1;
                    account.OpType = ConfigManager.OP_YF_MONTHACCOUNT;
                    accountDao.Add(account);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
