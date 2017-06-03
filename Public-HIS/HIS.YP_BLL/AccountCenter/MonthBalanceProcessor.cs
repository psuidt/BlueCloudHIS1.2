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
    /// 月结类型
    /// </summary>
    public enum MonthAccountState
    {
        /// <summary>
        /// 对账
        /// </summary>
        SystemChecking,
        /// <summary>
        /// 写期初台帐
        /// </summary>
        WriteBeginAccount,
        /// <summary>
        /// 写期末台帐
        /// </summary>
        WriteEndAccount,
        /// <summary>
        /// 写调整账目
        /// </summary>
        WriteAdjAccount,
        /// <summary>
        /// 结束
        /// </summary>
        Over
    }
    /// <summary>
    /// 月结事件
    /// </summary>
    public class MonthAccountEvent : EventArgs
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MonthAccountEvent()
        { }

        private MonthAccountState currentState;

        /// <summary>
        /// 当前月结状态
        /// </summary>
        public MonthAccountState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        private decimal percent;

        /// <summary>
        /// 当前状态完成百分比
        /// </summary>
        public decimal Percent
        {
            get { return percent; }
            set { percent = value; }
        }
    }
    /// <summary>
    /// 定义月结委托类型
    /// </summary>
    /// <param name="e">月结状态</param>
    public delegate void MonthAccountHandler(MonthAccountEvent e);
    /// <summary>
    /// 月结台帐处理器
    /// </summary>
    public abstract class MonthBalanceProcessor : HIS.SYSTEM.Core.BaseBLL
    {
        /// <summary>
        /// 月结处理过程中触发的事件（针对前台显示）
        /// </summary>
        protected MonthAccountEvent _monthEvent = new MonthAccountEvent();
        /// <summary>
        /// 药品厂家典ID
        /// </summary>
        protected int _makerDicId;

        /// <summary>
        /// 委托函数定义：比较台帐对应药品是否相等
        /// </summary>
        /// <param name="account">台帐信息</param>
        /// <returns></returns>
        protected bool match(YP_Account account)
        {
            if (account.MakerDicID == _makerDicId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取当前未结月药品期末台帐信息
        /// </summary>
        /// <param name="actList">台帐信息表</param>
        /// <param name="billNum">单据号</param>
        /// <param name="currentTime">当前时间</param>
        /// <param name="actHisID">月结历史记录ID</param>
        /// <returns></returns>
        protected List<YP_Account> GetMonthEndData(List<YP_Account> actList, int billNum, DateTime currentTime, int actHisID)
        {
            List<YP_Account> endActList = new List<YP_Account>();
            Hashtable makerdicDt = new Hashtable();
            foreach (YP_Account act in actList)
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
                YP_Account hashValue = (YP_Account)((DictionaryEntry)makerDicId).Value;
                YP_Account endData = (YP_Account)(hashValue.Clone());
                endData.AccountType = 1;
                endData.DebitFee = 0;
                endData.DebitNum = 0;
                endData.LenderNum = 0;
                endData.LenderFee = 0;
                endData.BillNum = billNum;
                endData.RegTime = currentTime;
                endData.AccountHistoryID = actHisID;
                endActList.Add(endData);
            }
            return endActList;
        }

        /// <summary>
        /// 获取月结日
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public static int GetAccountDay(int deptId)
        {
            try
            {
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                IBaseDAL<YP_CONFIG> appDal = BindEntity<YP_CONFIG>.CreateInstanceDAL(oleDb);
                YP_CONFIG config = appDal.GetModel("CODE='008' AND DeptID=" + deptId);
                if (config != null)
                {
                    return Convert.ToInt32(config.VALUE);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        /// <summary>
        /// 设置月结日
        /// </summary>
        /// <param name="accountDay">新设置的月结日</param>
        /// <param name="deptId">部门ID</param>
        public static void SetAccountDay(int accountDay, int deptId)
        {
            try
            {
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                oleDb.BeginTransaction();
                //获取月结类型的全局参数
                IBaseDAL<YP_CONFIG> appDal = BindEntity<YP_CONFIG>.CreateInstanceDAL(oleDb);
                YP_CONFIG accDay = appDal.GetModel("CODE='008' AND DeptID=" + deptId);
                if (accDay != null)
                {
                    accDay.VALUE = accountDay.ToString();
                    appDal.Update(accDay);
                }
                else
                {
                    throw new Exception("药品系统参数表未进行初始化设置");
                }
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }
        /// <summary>
        /// 药剂科室月结
        /// </summary>
        /// <param name="regPeople">月结操作人员</param>
        /// <param name="regDept">月结科室ID</param>
        public abstract void MonthAccount(int regPeople, int regDept);

        /// <summary>
        /// 取消月结
        /// </summary>
        /// <param name="regPeople">月结操作员</param>
        /// <param name="regDept">月结药剂科室ID</param>
        public abstract void CancelMonthAccount(int regPeople, int regDept);

        /// <summary>
        /// 月结处理操作（主要包括对账、写期末、写期初数据）
        /// </summary>
        /// <param name="regPeople">操作人员ID</param>
        /// <param name="regDept">月结药剂科室ID</param>
        /// <param name="currentTime">当前时间</param>
        /// <param name="isInit">是否初始化月结</param>
        /// <returns></returns>
        protected abstract DateTime MonthAccountAction(int regPeople, int regDept, DateTime currentTime, bool isInit);

        /// <summary>
        /// 写期初台帐
        /// </summary>
        /// <param name="accountHis">月结历史记录</param>
        /// <param name="billNum">月结单据号</param>
        /// <param name="accountDao">台帐操作对象</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        protected abstract void WriteBeginDateAccount(YP_AccountHis accountHis, int billNum,
            IBaseDAL<YP_Account> accountDao, int deptId);
        /// <summary>
        /// 写月结期初台帐
        /// </summary>
        /// <param name="accountList">月末所有药品未结算的最后一笔台帐</param>
        /// <param name="accountDao">台帐表操作对象</param>
        protected abstract void WriteBeginDateAccount(List<YP_Account> accountList, IBaseDAL<YP_Account> accountDao);

        /// <summary>
        /// 写月结期末台帐
        /// </summary>
        /// <param name="accountList">月末所有药品未结算的最后一笔台帐</param>
        /// <param name="accountDao">台帐表操作对象</param>
        /// <param name="ypStore">库存表操作对象</param>
        protected abstract void WriteEndDateAccount(List<YP_Account> accountList, IBaseDAL<YP_Account> accountDao,
            IBaseDAL<YP_Storage> ypStore);
        /// <summary>
        /// 构造对账错误信息表
        /// </summary>
        /// <returns>对账有错误的药品信息表</returns>
        protected DataTable BuildWrongDataTable()
        {
            DataTable wrongDt = new DataTable();
            wrongDt.Columns.Add("CHEMNAME");
            wrongDt.Columns.Add("MAKERDICID");
            wrongDt.Columns.Add("WRONGNUM", Type.GetType("System.Decimal"));
            wrongDt.Columns.Add("WRONGFEE", Type.GetType("System.Decimal"));
            wrongDt.Columns.Add("STOREWRONGFEE", Type.GetType("System.Decimal"));
            wrongDt.Columns.Add("BALANCEFEE", Type.GetType("System.Decimal"));
            wrongDt.Columns.Add("BALANCENUM", Type.GetType("System.Decimal"));
            wrongDt.Columns.Add("UNITNUM", Type.GetType("System.Int32"));
            wrongDt.Columns.Add("UNIT", Type.GetType("System.Int32"));
            return wrongDt;
        }

        /// <summary>
        /// 系统自动对账
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>错误账目信息表</returns>
        public abstract DataTable SystemCheckAccount(int deptId);

        /// <summary>
        /// 系统自动平账
        /// </summary>
        /// <param name="deptId">药剂科室ＩＤ</param>
        public abstract void BalanceAccount(int deptId);

        /// <summary>
        /// 账目调整算法
        /// </summary>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <param name="wrongAccountDt">错误账目信息表</param>
        /// <param name="query">账务查询器</param>
        /// <param name="accountDao">台帐表操作对象</param>
        protected static void AdjAccount(int deptId, DataTable wrongAccountDt, AccountQuery query, IBaseDAL<YP_Account> accountDao)
        {
            DateTime currentTime = XcDate.ServerDateTime;
            //获取当前会计年月
            int currentActYear = 0, currentActMonth = 0;
            query.GetAccountTime(currentTime, ref currentActYear, ref currentActMonth, deptId);
            string opType = "";
            if (query.GetType().ToString() == "HIS.YP_BLL.YK_AccountQuery")
                opType = ConfigManager.OP_YK_MONTHACCOUNT;
            else if (query.GetType().ToString() == "HIS.YP_BLL.YF_AccountQuery")
                opType = ConfigManager.OP_YF_MONTHACCOUNT;
            else
                throw new Exception("账目调节系统类型错误");
            oleDb.BeginTransaction();
            //按错误药品信息依次写入调整台帐，把账目调平
            for (int index = 0; index < wrongAccountDt.Rows.Count; index++)
            {
                DataRow currentRow = wrongAccountDt.Rows[index];
                YP_Account adjAccount = new YP_Account();
                adjAccount.AccountMonth = currentActMonth;
                adjAccount.AccountType = 3;
                adjAccount.AccountYear = currentActYear;
                adjAccount.MakerDicID = Convert.ToInt32(currentRow["MAKERDICID"]);
                adjAccount.LeastUnit = Convert.ToInt32(currentRow["UNIT"]);
                adjAccount.UnitNum = Convert.ToInt32(currentRow["UNITNUM"]);
                if (currentRow["WRONGFEE"] != DBNull.Value)
                {
                    adjAccount.LenderFee = Convert.ToDecimal(currentRow["WRONGFEE"])
                        + Convert.ToDecimal(currentRow["STOREWRONGFEE"]);
                }
                if (currentRow["WRONGNUM"] != DBNull.Value)
                {
                    adjAccount.LenderNum = Convert.ToDecimal(currentRow["WRONGNUM"]);
                }
                if (currentRow["BALANCEFEE"] != DBNull.Value)
                {
                    adjAccount.BalanceFee = Convert.ToDecimal(currentRow["BALANCEFEE"])
                        + Convert.ToDecimal(currentRow["STOREWRONGFEE"]);
                }
                if (currentRow["BALANCENUM"] != DBNull.Value)
                {
                    adjAccount.OverNum = Convert.ToDecimal(currentRow["BALANCENUM"]) + adjAccount.LenderNum;
                }
                adjAccount.DeptID = deptId;

                adjAccount.OpType = opType;
                adjAccount.RegTime = currentTime;
                accountDao.Add(adjAccount);
            }
            oleDb.CommitTransaction();
        }
    }






}

