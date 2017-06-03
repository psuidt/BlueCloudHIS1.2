using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.ZY_BLL.Dao;
using HIS.ZY_BLL.Dao.ChargeListManager;
using HIS.ZY_BLL.Dao.CostManager;
using System.Collections;
using HIS.ZY_BLL.Dao.Account;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS.ZY_BLL.DataModel
{
    /// <summary>
    /// 住院交款类
    /// </summary>
    partial class ZY_Account : IbaseDao,ICloneable
    {

        #region IbaseDao 成员
        private HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _oleDb;
        public HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb
        {
            get
            {
                return _oleDb;
            }
            set
            {
                _oleDb = value;
            }
        }

        #endregion

        private string _accountName;
        /// <summary>
        /// 交款员
        /// </summary>
        public string AccountName
        {
            get
            {
                return _accountName;
            }
            set
            {
                _accountName = value;
            }
        }

        public ZY_Account()
        {
            oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 得到最后一次交款日期
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastTime()
        {
            try
            {
                string strWhere = "ACCOUNTCODE ='" + this.AccountCode + "' order by accountid desc " + oleDb.FETCH();
                object obj = BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).GetFieldValue("ACCOUNTDATE", strWhere);
                return Convert.ToDateTime(obj);
            }
            catch (HIS.SYSTEM.DatabaseAccessLayer.DALException e)
            {
                return new DateTime();
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 得到未交款的所有预交金
        /// 
        /// </summary>
        /// <param name="ChargeCode">操作员代码</param>
        /// <returns></returns>
        public DataTable GetAllCharge(string ChargeCode)
        {

            try
            {

                IaccountDao itD = DaoFactory.GetObject<IaccountDao>(typeof(AccountDao));
                itD.oleDb = oleDb;
                DataTable dt = itD.GetAllCharge(ChargeCode);

                return dt;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 得到所有未交款的结算
        /// </summary>
        /// <param name="ChargeCode">操作员代码</param>
        /// <returns></returns>
        public DataTable GetAllCost(string ChargeCode)
        {

            try
            {
                IaccountDao itD = DaoFactory.GetObject<IaccountDao>(typeof(AccountDao));
                itD.oleDb = oleDb;
                DataTable dt = itD.GetAllCost(ChargeCode);
                return dt;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// 得到所有未交款的预交金和结算费用合计
        /// </summary>
        /// <param name="ChargeCode">操作员代码</param>
        /// <returns></returns>
        public DataTable GetAllChargeAndCost(string ChargeCode)
        {
            DataTable dt1 = GetAllCharge(ChargeCode);
            DataTable dt2 = GetAllCost(ChargeCode);
            DataRow[] drs = dt1.Select();
            for (int i = 0; i < drs.Length; i++)
            {
                dt2.Rows.Add(drs[i].ItemArray);
            }
            return dt2;
        }

        /// <summary>
        /// 得到现金和pos金额分别多少
        /// </summary>
        /// <param name="ChargeCode">操作员代码</param>
        /// <param name="type">类别(0,全部.1，预交金.2,结算.)</param>
        /// <returns></returns>
        public decimal[] GetMenoyAndPosFee(string ChargeCode, int type)
        {
            IchargeListDao icLD = DaoFactory.GetObject<IchargeListDao>(typeof(ChargeListDao));
            IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
            icLD.oleDb = oleDb;
            icD.oleDb = oleDb;

            try
            {
                if (type == 0)
                {
                    decimal[] dec = new decimal[5];
                    decimal[] dec1 = new decimal[5];
                    dec = icLD.GetMenoyAndPosFee(ChargeCode);
                    dec1 = icD.GetMenoyAndPosFee(ChargeCode);
                    dec[0] += dec1[0];
                    dec[1] += dec1[1];
                    dec[2] += dec1[2];
                    dec[3] += dec1[3];
                    dec[4] += dec1[4];
                    return dec;
                }
                else if (type == 1)
                {
                    return icLD.GetMenoyAndPosFee(ChargeCode);
                }
                else if (type == 2)
                {
                    return icD.GetMenoyAndPosFee(ChargeCode);
                }
                return null;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 得到结算交款的费用
        /// </summary>
        /// <param name="ChargeCode">操作员代码</param>
        /// <returns>总金额、优惠、记账、结欠</returns>
        public AccountFee GetCostAllTolFee(string ChargeCode)
        {
            AccountFee accountFee = new AccountFee();
            string strWhere = "ACCOUNTID = 0 and CHARGECODE ='" + ChargeCode + "' ";

            return accountFee;
        }
        /// <summary>
        /// 得到结算交款的费用
        /// </summary>
        /// <param name="AccountID">交款ID</param>
        /// <returns>总金额、优惠、记账、结欠</returns>
        public AccountFee GetCostAllTolFee(int AccountID)
        {
            AccountFee accountFee = new AccountFee();

            return accountFee;
        }
        /// <summary>
        /// 得到明细
        /// </summary>
        /// <param name="ChargeCode">操作员代码</param>
        /// <param name="feeType"></param>
        /// <returns></returns>
        public DataTable GetDetailCharge(string ChargeCode, string feeType)
        {
            try
            {
                IchargeListDao icLD = DaoFactory.GetObject<IchargeListDao>(typeof(ChargeListDao));
                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                icLD.oleDb = oleDb;
                icD.oleDb = oleDb;

                if (feeType.Trim() == "正常")
                {
                    return icLD.GetDetailCharge(ChargeCode, 0);

                }
                else if (feeType.Trim() == "退费")
                {
                    return icLD.GetDetailCharge(ChargeCode, 1);
                }
                else if (feeType.Trim() == "结补")
                {
                    return icD.GetDetailCharge(ChargeCode, 0);
                }
                else if (feeType.Trim() == "结退")
                {
                    return icD.GetDetailCharge(ChargeCode, 1);
                }
                return null;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 交款
        /// </summary>
        /// <param name="type">交款类型（1预交金，2结算费用，3全部）</param>
        /// <param name="empID">交款人ID</param>
        /// <returns></returns>
        public int[] SaveAccount(int type, string empID)
        {
            try
            {
                int[] AccountsID = new int[2];
                AccountsID[0] = -1;
                AccountsID[1] = -1;

                oleDb.BeginTransaction();


                IchargeListDao icLD = DaoFactory.GetObject<IchargeListDao>(typeof(ChargeListDao));
                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                icLD.oleDb = oleDb;
                icD.oleDb = oleDb;

                if (type == 1)
                {
                    ZY_Account zyAccount = new ZY_Account();
                    zyAccount.AccountType = 0;//预交金
                    zyAccount.AccountCode = empID;
                    zyAccount.LastDate = GetLastTime();
                    DataTable dt = GetAllCharge(empID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["typename"].ToString() == "正常")
                        {
                            zyAccount.WTicketFee = Convert.ToDecimal(dt.Rows[i]["tol_fee"]);
                            zyAccount.WTicketNum = Convert.ToInt32(dt.Rows[i]["count"]);
                        }
                        else if (dt.Rows[i]["typename"].ToString() == "退费")
                        {
                            zyAccount.BTicketFee = Convert.ToDecimal(dt.Rows[i]["tol_fee"]);
                            zyAccount.BTicketNum = Convert.ToInt32(dt.Rows[i]["count"]);
                        }
                    }
                    decimal[] dec = GetMenoyAndPosFee(empID, type);
                    zyAccount.Total_Fee = dec[0] + dec[1];
                    zyAccount.Cash_Fee = dec[0];
                    zyAccount.POS_Fee = dec[1];
                    zyAccount.AccountCode = empID;
                    zyAccount.AccountDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).Add(zyAccount);
                    AccountsID[0] = zyAccount.AccountID;
                    icLD.UpdateAccount(zyAccount.AccountCode, zyAccount.AccountID);
                }
                else if (type == 2)
                {
                    ZY_Account zyAccount = new ZY_Account();
                    zyAccount.AccountType = 1;//结算
                    zyAccount.AccountCode = empID;
                    zyAccount.LastDate = GetLastTime();
                    DataTable dt = GetAllCost(empID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["typename"].ToString() == "结补")
                        {
                            zyAccount.WTicketFee = Convert.ToDecimal(dt.Rows[i]["tol_fee"]);
                            zyAccount.WTicketNum = Convert.ToInt32(dt.Rows[i]["count"]);
                        }
                        else if (dt.Rows[i]["typename"].ToString() == "结退")
                        {
                            zyAccount.BTicketFee = Convert.ToDecimal(dt.Rows[i]["tol_fee"]);
                            zyAccount.BTicketNum = Convert.ToInt32(dt.Rows[i]["count"]);
                        }
                    }
                    decimal[] dec = GetMenoyAndPosFee(empID, type);
                    zyAccount.Total_Fee = dec[0] + dec[1];
                    zyAccount.Cash_Fee = dec[0];
                    zyAccount.POS_Fee = dec[1];
                    zyAccount.AccountCode = empID;
                    zyAccount.AccountDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    zyAccount.CostFee = dec[2];
                    zyAccount.FaoverFee = dec[3];
                    BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).Add(zyAccount);
                    AccountsID[1] = zyAccount.AccountID;
                    icD.UpdateAccount(zyAccount.AccountCode, zyAccount.AccountID);
                }
                else
                {
                    ZY_Account zyAccount = new ZY_Account();
                    zyAccount.AccountType = 0;//预交金
                    zyAccount.AccountCode = empID;
                    zyAccount.LastDate = GetLastTime();
                    DataTable dt = GetAllCharge(empID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["typename"].ToString() == "正常")
                        {
                            zyAccount.WTicketFee = Convert.ToDecimal(dt.Rows[i]["tol_fee"]);
                            zyAccount.WTicketNum = Convert.ToInt32(dt.Rows[i]["count"]);
                        }
                        else if (dt.Rows[i]["typename"].ToString() == "退费")
                        {
                            zyAccount.BTicketFee = Convert.ToDecimal(dt.Rows[i]["tol_fee"]);
                            zyAccount.BTicketNum = Convert.ToInt32(dt.Rows[i]["count"]);
                        }
                    }
                    decimal[] dec = GetMenoyAndPosFee(empID, 1);
                    zyAccount.Total_Fee = dec[0] + dec[1];
                    zyAccount.Cash_Fee = dec[0];
                    zyAccount.POS_Fee = dec[1];
                    zyAccount.AccountCode = empID;
                    zyAccount.AccountDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).Add(zyAccount);
                    AccountsID[0] = zyAccount.AccountID;
                    icLD.UpdateAccount(zyAccount.AccountCode, zyAccount.AccountID);

                    zyAccount = new ZY_Account();
                    zyAccount.AccountType = 1;//结算
                    zyAccount.AccountCode = empID;
                    zyAccount.LastDate = GetLastTime();
                    dt = GetAllCost(empID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["typename"].ToString() == "结补")
                        {
                            zyAccount.WTicketFee = Convert.ToDecimal(dt.Rows[i]["tol_fee"]);
                            zyAccount.WTicketNum = Convert.ToInt32(dt.Rows[i]["count"]);
                        }
                        else if (dt.Rows[i]["typename"].ToString() == "结退")
                        {
                            zyAccount.BTicketFee = Convert.ToDecimal(dt.Rows[i]["tol_fee"]);
                            zyAccount.BTicketNum = Convert.ToInt32(dt.Rows[i]["count"]);
                        }
                    }
                    dec = GetMenoyAndPosFee(empID, 2);
                    zyAccount.Total_Fee = dec[0] + dec[1];
                    zyAccount.Cash_Fee = dec[0];
                    zyAccount.POS_Fee = dec[1];
                    zyAccount.AccountCode = empID;
                    zyAccount.AccountDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    zyAccount.CostFee = dec[2];
                    zyAccount.FaoverFee = dec[3];
                    BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).Add(zyAccount);
                    AccountsID[1] = zyAccount.AccountID;
                    icD.UpdateAccount(zyAccount.AccountCode, zyAccount.AccountID);
                }
                //oleDb.StoreProcedureName = "";
                //oleDb.Coding = "";
                oleDb.CommitTransaction();
                return AccountsID;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到所有票据汇总
        /// </summary>
        /// <param name="AccountID">交款ID</param>
        /// <returns></returns>
        public DataTable GetTicketTotle(int AccountID)
        {
            try
            {
                //IchargeListDao icLD = DaoFactory.GetObject<IchargeListDao>(typeof(ChargeListDao));
                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                //icLD.oleDb = oleDb;
                icD.oleDb = oleDb;
                return icD.GetTicketTotle(AccountID);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 得到应收金额（医疗收入、药品收入、其他收入）
        /// </summary>
        /// <param name="AccountID">交款ID</param>
        /// <returns></returns>
        public decimal[] GetTotleType(int AccountID)
        {
            try
            {
                //IchargeListDao icLD = DaoFactory.GetObject<IchargeListDao>(typeof(ChargeListDao));
                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                //icLD.oleDb = oleDb;
                icD.oleDb = oleDb;
                return icD.GetTotleType(AccountID);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        ///得到结账记录 
        /// </summary>
        /// <param name="AccountID">结账号</param>
        /// <returns></returns>
        public ZY_Account GetAccount(int AccountID)
        {
            ZY_Account zyAccount = BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).GetModel(AccountID);

            zyAccount.AccountName = BaseNameFactory.GetName(baseNameType.用户名称, zyAccount.AccountCode);//HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(zyAccount.AccountCode);
            return zyAccount;
        }

        /// <summary>
        /// 得到结账历史记录
        /// </summary>
        /// <param name="ChargeCode">操作员代码</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public DataTable GetAccountList(string ChargeCode, DateTime Bdate, DateTime Edate)
        {
            try
            {
                string strWhere = "ACCOUNTCODE ='" + ChargeCode + "' and date(ACCOUNTDATE) >= '" + Bdate.Date + "' and date(ACCOUNTDATE) <= '" + Edate.Date + "'";

                return BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).GetList(
                    strWhere,
                    "ACCOUNTID",
                    "LASTDATE",
                    "TOTAL_FEE",
                    "CASH_FEE",
                    "POS_FEE",
                    "ACCOUNTDATE",
                    "PRINTNUM",
                    "( case ACCOUNTTYPE when 0 then '预交金' when 1 then '结算' end) ACCOUNTTYPE");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到结账记录的对应金额
        /// </summary>
        /// <param name="AccountID">交款ID</param>
        /// <returns></returns>
        public decimal[] GetAccountFee(int AccountID)
        {
            decimal[] dec = new decimal[4];
            string strWhere1 = "FEETYPE = 0 and ACCOUNTID =" + AccountID;
            //预交现金
            dec[0] = Convert.ToDecimal(BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetSum("TOTAL_FEE", strWhere1));
            string strWhere2 = "FEETYPE = 1 and ACCOUNTID =" + AccountID;
            //预交POS
            dec[1] = Convert.ToDecimal(BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetSum("TOTAL_FEE", strWhere1));
            string strWhere3 =
                "ACCOUNTID =" + AccountID;
            //结算现金
            dec[2] = Convert.ToDecimal(BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetSum("MONEY_FEE", strWhere3));
            dec[3] = Convert.ToDecimal(BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetSum("POS_FEE", strWhere3));
            return dec;
        }
        /// <summary>
        /// 更新打印次数
        /// </summary>
        /// <param name="AccountID">交款ID</param>
        public void UpdatePrintNum(int AccountID)
        {
            BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).Update(" ACCOUNTID=" + AccountID, " PRINTNUM=PRINTNUM+1 ");
        }
        /// <summary>
        /// 交款表汇总数据
        /// </summary>
        /// <param name="BDate">开始时间</param>
        /// <param name="EDate">结束时间</param>
        /// <returns></returns>
        public List<ZY_Account> GetAllData(DateTime BDate, DateTime EDate)
        {
            string strWhere = "ACCOUNTDATE >='" + BDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and ACCOUNTDATE <='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            return BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
        }
        /// <summary>
        /// 得到预交金收据清单
        /// </summary>
        /// <param name="AccountID">结算ID</param>
        /// <param name="type">-1,全部预交金收据0，正常收据，1为退费收据,2(结算)预交金收据</param>
        /// <returns></returns>
        public  List<ZY_ChargeList> GetChargeData(string[] AccountID, int type)
        {
            string strWhere = "ACCOUNTID "+ oleDb.In(AccountID);
            if (type == 0)
            {
                strWhere += oleDb.And() + "(RECORD_FLAG <> 2 or TOTAL_FEE >= 0 )";
            }
            else if (type == 1)
            {
                strWhere += oleDb.And() + "RECORD_FLAG = 2 and TOTAL_FEE < 0 ";
            }
            else if (type == 2)
            {
                strWhere = "ACCOUNTID "+ oleDb.In(AccountID);
                string tablesql = oleDb.ChildTable("ZY_COSTMASTER", "", strWhere,"COSTMASTERID");
                string strsql = "RECORD_FLAG = 0 and DELETE_FLAG "+ oleDb.In() + tablesql;
                strWhere = strsql;
            }
            else
            {

            }
            return BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
        }
        /// <summary>
        /// 得到结算收据清单
        /// </summary>
        /// <param name="AccountID">结算ID</param>
        /// <param name="type">0，正常收据，1为退费收据,2预交金收据</param>
        /// <returns></returns>
        public List<ZY_CostMaster> GetCostData(string[] AccountID, int type)
        {
            string strWhere = "ACCOUNTID "+ oleDb.In(AccountID);
            if (type == 0)
            {
                strWhere += oleDb.And() + "REALITY_FEE >= 0";
            }
            else if (type == 1)
            {
                strWhere += oleDb.And() + "REALITY_FEE < 0";
            }

            return BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
        }
        /// <summary>
        /// 得到项目数据
        /// </summary>
        /// <param name="AccountID">结算ID</param>
        /// <returns></returns>
        public  DataTable GetBIGItemData(string[] AccountID)
        {
            IaccountDao itD = DaoFactory.GetObject<IaccountDao>(typeof(AccountDao));
            itD.oleDb = oleDb;
            return itD.GetBIGItemData(AccountID);

        }
        /// <summary>
        /// 得到记账费用
        /// </summary>
        /// <param name="AccountID">记账ID</param>
        /// <returns></returns>
        public DataTable GetVillage_Fee(int AccountID)
        {
            IaccountDao itD = DaoFactory.GetObject<IaccountDao>(typeof(AccountDao));
            itD.oleDb = oleDb;
            return itD.GetVillage_Fee(AccountID);
        }
        /// <summary>
        /// 根据结算ID获取结算记录（财务结帐-打印结算交款表）
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public List<ZY_CostMaster> GetCostData(int AccountID)
        {
            string strWhere = "ACCOUNTID =" + AccountID + oleDb.OrderBy("ACCOUNTID");
            return BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
        }
        /// <summary>
        /// 根据结算ID获取结算预交金记录（财务结帐-打印结算交款表）
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public List<ZY_ChargeList> GetChargeListData(int AccountID)
        {
            string strWhere = " DELETE_FLAG in (select costmasterid from zy_costmaster where accountid=" + AccountID + ") ";
            return BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
        }

        /// <summary>
        /// 得到废票张数
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public int GetBadTicketCount(int AccountID)
        {
            string strWhere = "ACCOUNTID =" + AccountID;
            return Convert.ToInt32(BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_BADTICKET").GetFieldValue("count(*)", strWhere));
        }
        /// <summary>
        /// 得到所有记账费用
        /// </summary>
        /// <returns></returns>
        public decimal GetAllChargeFee(DateTime Bdate, DateTime Edate)
        {
            IaccountDao itD = DaoFactory.GetObject<IaccountDao>(typeof(AccountDao));
            itD.oleDb = oleDb;
            return itD.GetAllChargeFee(Bdate, Edate);
        }

        /// <summary>
        /// 得到所有记账费用
        /// </summary>
        /// <returns></returns>
        public decimal GetAllChargeFee(DateTime Bdate, DateTime Edate,List<ZY_Account> zylist)
        {

            IaccountDao itD = DaoFactory.GetObject<IaccountDao>(typeof(AccountDao));
            itD.oleDb = oleDb;
            return itD.GetAllChargeFee(Bdate, Edate,zylist);
        }

        /// <summary>
        /// 获取科室分类数据
        /// </summary>
        /// <param name="AccountID">交款ID</param>
        /// <returns></returns>
        public DataTable GetAccountDeptOrderData(int AccountID)
        {
            DataTable dt = new DataTable();

            string strWhere = "Accountid=" + AccountID;
            DataTable DeptDT = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetList(strWhere, "CostMasterID", "PatlistID");


            //建列
            DataColumn column;
            ArrayList al = new ArrayList();
            for (int i = 0; i < DeptDT.Rows.Count; i++)
            {
                string deptcode = BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue("curedeptcode", "patlistid=" + DeptDT.Rows[i]["patlistid"] + "").ToString();
                if (!al.Contains(deptcode))
                    al.Add(deptcode);
            }
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "费用项目";
            //column.ReadOnly = true;
            dt.Columns.Add(column);
            for (int i = 0; i < al.Count; i++)
            {
                string deptName = BaseNameFactory.GetName(baseNameType.科室名称, al[i].ToString());//HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(al[i].ToString());
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = deptName;
                //column.ReadOnly = true;
                dt.Columns.Add(column);
            }

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "合计";
            //column.ReadOnly = true;
            dt.Columns.Add(column);



            //添加行

            IaccountDao itD = DaoFactory.GetObject<IaccountDao>(typeof(AccountDao));
            itD.oleDb = oleDb;
            DataTable ItemDT = itD.GetAccountDeptOrderData(AccountID);

            ArrayList alrow = new ArrayList();
            DataRow row = null;
            for (int i = 0; i < ItemDT.Rows.Count; i++)
            {
                if (!alrow.Contains(ItemDT.Rows[i]["itemname"]))
                {
                    alrow.Add(ItemDT.Rows[i]["itemname"]);
                    row = dt.NewRow();
                    int rowid = alrow.Count - 1;
                    row["费用项目"] = ItemDT.Rows[i]["itemname"].ToString();
                    row[ItemDT.Rows[i]["deptname"].ToString()] = Convert.ToDecimal(ItemDT.Rows[i]["total_fee"]);
                    row["合计"] = Convert.ToDecimal(ItemDT.Rows[i]["total_fee"]);
                    dt.Rows.Add(row);
                }
                else
                {
#if DEBUG
                    if (i == 28)
                    {
                        break;
                    }
#endif
                    int rowid = alrow.IndexOf(ItemDT.Rows[i]["itemname"]);
                    dt.Rows[rowid][ItemDT.Rows[i]["deptname"].ToString()] = Convert.ToDecimal(dt.Rows[rowid][ItemDT.Rows[i]["deptname"].ToString()].ToString() == "" ? "0" : dt.Rows[rowid][ItemDT.Rows[i]["deptname"].ToString()].ToString()) + Convert.ToDecimal(ItemDT.Rows[i]["total_fee"]);
                    dt.Rows[rowid]["合计"] = Convert.ToDecimal(dt.Rows[rowid]["合计"]) + Convert.ToDecimal(ItemDT.Rows[i]["total_fee"]);
                }

            }

            CreateDataTableRowAll(dt);

            return dt;

        }

        private decimal Dbnull(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(obj);
        }

        private void CreateDataTableRowAll(DataTable dt)
        {
            DataRow row = dt.NewRow();
            row["费用项目"] = "合计";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //row["合计"] = Convert.ToDecimal(row["合计"]) + Convert.ToDecimal(dt.Rows[i]["合计"]);
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    row[j] = Dbnull(row[j]) + Dbnull(dt.Rows[i][j]);
                }
            }
            dt.Rows.Add(row);
        } 

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}