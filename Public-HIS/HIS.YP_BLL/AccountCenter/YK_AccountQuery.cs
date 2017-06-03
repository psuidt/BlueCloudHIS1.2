using System;
using System.Collections.Generic;
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
    /// 药库台帐查询器
    /// </summary>
    class YK_AccountQuery : AccountQuery
    {

        public override DataTable GetOrderAccount(int drugType, int actYear, int actMonth, int deptId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.LENDERFEE,A.DEBITFEE,A.BALANCEFEE,C.TYPEDICID");
            strSql.Append(" from YK_Account A");
            strSql.Append(" left outer join YP_MakerDic B");
            strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
            strSql.Append(" left outer join YP_SpecDic C");
            strSql.Append(" on B.SPECDICID=C.SPECDICID");
            strSql.Append(" where A.DeptID=" + deptId);
            if (drugType != 0)
            {
                strSql.Append(" AND C.TYPEDICID=" + drugType.ToString());
                strSql.Append(" AND A.ACCOUNTYEAR=" + actYear.ToString());
                strSql.Append(" AND A.ACCOUNTMONTH=" + actMonth.ToString());
            }
            else
            {
                strSql.Append(" AND A.ACCOUNTYEAR=" + actYear.ToString());
                strSql.Append(" AND A.ACCOUNTMONTH=" + actMonth.ToString());
            }
            return oleDb.GetDataTable(strSql.ToString());
        }

        public override DataTable QueryAllInFee(int drugTypeId, int accountYear, int accountMonth, int deptId)
        {
            try
            {
                string accountTable = "";
                string op_instore = "";
                string op_audit = "";
                string op_adjust = "";
                accountTable = "YK_Account";
                op_instore = "('010')";
                op_audit = "'012'";
                op_adjust = "'016'";
                string op_adjAccount = "'"+ConfigManager.OP_YK_MONTHACCOUNT+"'";
                DataTable inFeeDt = new DataTable();
                inFeeDt.Columns.Add("项目");
                inFeeDt.Columns.Add("金额");
                DataRow addRow;
                // 查询所有期初入库项目和金额
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select SUM(A.LENDERFEE) AS INFEE");
                strSql.Append(" from " + accountTable + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" where A.OPTYPE='" + ConfigManager.OP_YK_FIRSTIN + "' AND A.ACCOUNTTYPE=2 AND A.DeptID=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                object obj = oleDb.GetDataResult(strSql.ToString());
                decimal firstInFee;
                if (obj != null && obj != DBNull.Value)
                {
                    firstInFee = decimal.Parse(obj.ToString());
                    addRow = inFeeDt.NewRow();
                    addRow["项目"] = "期初入库金额";
                    addRow["金额"] = firstInFee.ToString("0.00");
                    inFeeDt.Rows.Add(addRow);
                }
                //查询所有入库项目和金额
                strSql = new StringBuilder();
                strSql.Append("select SUM(A.LENDERFEE) AS INFEE");
                strSql.Append(" from " + accountTable + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" where A.OPTYPE in" + op_instore + " AND A.ACCOUNTTYPE=2 AND A.DeptID=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                obj = oleDb.GetDataResult(strSql.ToString());
                decimal inStoreFee;
                if (obj != null && obj != DBNull.Value)
                {
                    inStoreFee = decimal.Parse(obj.ToString());
                    addRow = inFeeDt.NewRow();
                    addRow["项目"] = "入库金额";
                    addRow["金额"] = inStoreFee.ToString("0.00");
                    inFeeDt.Rows.Add(addRow);
                }
                //查询所有调赢项目和金额
                strSql = new StringBuilder();
                strSql.Append("select SUM(A.LENDERFEE)");
                strSql.Append(" from " + accountTable + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" where A.OPTYPE=" + op_adjust + " AND A.ACCOUNTTYPE=2 AND A.DeptId=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                obj = oleDb.GetDataResult(strSql.ToString());
                decimal adjustInFee;
                if (obj != null && obj != DBNull.Value)
                {
                    adjustInFee = decimal.Parse(obj.ToString());
                    if (adjustInFee != 0)
                    {
                        addRow = inFeeDt.NewRow();
                        addRow["项目"] = "调价盈余";
                        addRow["金额"] = adjustInFee.ToString("0.00");
                        inFeeDt.Rows.Add(addRow);
                    }
                }
                //查询所有盘盈项目和金额
                strSql = new StringBuilder();
                strSql.Append("select SUM(A.LENDERFEE)");
                strSql.Append(" from " + accountTable + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" where A.OPTYPE=" + op_audit + " AND A.ACCOUNTTYPE=2 AND A.DeptId=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                obj = oleDb.GetDataResult(strSql.ToString());
                decimal checkInFee;
                if (obj != null && obj != DBNull.Value)
                {
                    checkInFee = decimal.Parse(obj.ToString());
                    addRow = inFeeDt.NewRow();
                    addRow["项目"] = "盘点盈余";
                    addRow["金额"] = checkInFee.ToString("0.00");
                    inFeeDt.Rows.Add(addRow);
                }
                strSql = new StringBuilder();
                strSql.Append("select SUM(A.LENDERFEE)");
                strSql.Append(" from " + accountTable + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" where A.OPTYPE=" + op_adjAccount + " AND A.ACCOUNTTYPE=3 AND A.DeptId=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                obj = oleDb.GetDataResult(strSql.ToString());
                decimal adjAccountFee;
                if (obj != null && obj != DBNull.Value)
                {
                    adjAccountFee = decimal.Parse(obj.ToString());
                    addRow = inFeeDt.NewRow();
                    addRow["项目"] = "月结调整";
                    addRow["金额"] = adjAccountFee.ToString("0.00");
                    inFeeDt.Rows.Add(addRow);
                }
                return inFeeDt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override DataTable QueryAllOutFee(int drugTypeId, int accountYear, int accountMonth, int deptId)
        {
            try
            {
                string accountTable = "";
                string op_reportloss = "";
                string op_deptdraw = "";
                string op_adjust = "";
                string op_audit = "";
                string op_backstore = "'024'";
                accountTable = "YK_Account";
                op_reportloss = "'018'";
                op_deptdraw = "('017','011')";
                op_adjust = "'016'";
                op_audit = "'012'";
                DataTable outFeeDt = new DataTable();
                outFeeDt.Columns.Add("项目");
                outFeeDt.Columns.Add("金额");
                DataRow addRow;
                //查询所有报损出库金额
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select SUM(A.DEBITFEE)");
                strSql.Append(" from " + accountTable + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" where A.OPTYPE=" + op_reportloss + " AND A.ACCOUNTTYPE=2 AND A.DeptId=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                object obj = oleDb.GetDataResult(strSql.ToString());
                decimal outStoreFee;
                if (obj != null && obj != DBNull.Value)
                {
                    addRow = outFeeDt.NewRow();
                    outStoreFee = decimal.Parse(obj.ToString());
                    addRow["项目"] = "报损出库金额";
                    addRow["金额"] = outStoreFee.ToString("0.00");
                    outFeeDt.Rows.Add(addRow);
                }
                //查询所有科室领药金额
                strSql = new StringBuilder();
                strSql.Append("select SUM(A.DEBITFEE) AS DEBITFEE,E.NAME");
                strSql.Append(" from " + accountTable + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" left outer join YK_OutOrder D");
                strSql.Append(" on A.ORDERID=D.OUTSTORAGEID");
                strSql.Append(" left outer join BASE_DEPT_PROPERTY E");
                strSql.Append(" on D.OUTDEPTID=E.DEPT_ID");
                strSql.Append(" where A.OPTYPE in" + op_deptdraw + " AND A.ACCOUNTTYPE=2 AND A.DeptId=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                strSql.Append(" group by E.NAME");
                DataTable outStoreDt = oleDb.GetDataTable(strSql.ToString());
                if (outStoreDt != null)
                {
                    for (int index = 0; index < outStoreDt.Rows.Count; index++)
                    {
                        DataRow outStoreRow = outStoreDt.Rows[index];
                        addRow = outFeeDt.NewRow();
                        addRow["金额"] = decimal.Parse(outStoreRow["DEBITFEE"].ToString()).ToString("0.00");
                        addRow["项目"] = "("+ outStoreRow["NAME"].ToString() + ")领药";
                        outFeeDt.Rows.Add(addRow);
                    }
                }
                //查询所有调亏金额
                strSql = new StringBuilder();
                strSql.Append("select SUM(A.DEBITFEE)");
                strSql.Append(" from " + accountTable + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" where A.OPTYPE=" + op_adjust + " AND A.ACCOUNTTYPE=2 AND A.DeptId=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                obj = oleDb.GetDataResult(strSql.ToString());
                decimal adjustOutFee = 0;
                if (obj != null && obj != DBNull.Value)
                {
                    adjustOutFee = decimal.Parse(obj.ToString());
                    addRow = outFeeDt.NewRow();
                    addRow["项目"] = "调价亏损金额";
                    addRow["金额"] = adjustOutFee.ToString("0.00");
                    outFeeDt.Rows.Add(addRow);
                }
                //查询所有盘亏金额
                strSql = new StringBuilder();
                strSql.Append("select SUM(A.DEBITFEE)");
                strSql.Append(" from " + accountTable + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" where A.OPTYPE=" + op_audit + " AND A.DeptId=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                obj = oleDb.GetDataResult(strSql.ToString());
                decimal checkOutFee = 0;
                if (obj != null && obj != DBNull.Value)
                {
                    checkOutFee = decimal.Parse(obj.ToString());
                    if (checkOutFee != 0)
                    {
                        addRow = outFeeDt.NewRow();
                        addRow["项目"] = "盘亏金额";
                        addRow["金额"] = checkOutFee.ToString("0.00");
                        outFeeDt.Rows.Add(addRow);
                    }
                }
                //查询所有退库金额
                strSql = new StringBuilder();
                strSql.Append("select SUM(A.DEBITFEE)");
                strSql.Append(" from " + accountTable + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" where A.OPTYPE=" + op_backstore + " AND A.DeptId=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                obj = oleDb.GetDataResult(strSql.ToString());
                decimal backStoreFee = 0;
                if (obj != null && obj != DBNull.Value)
                {
                    backStoreFee = decimal.Parse(obj.ToString());
                    if (backStoreFee != 0)
                    {
                        addRow = outFeeDt.NewRow();
                        addRow["项目"] = "退库金额";
                        addRow["金额"] = backStoreFee.ToString("0.00");
                        outFeeDt.Rows.Add(addRow);
                    }
                }
                QueryTotalEndFee(drugTypeId, accountYear, accountMonth, deptId, outFeeDt);
                return outFeeDt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override DataTable QueryOrderAccount(int AccountYear, int AccountMonth, int MakerDicID, int deptId)
        {
            try
            {
                DataTable orderDt;
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                string str = "A."+Tables.yf_account.ACCOUNTYEAR + oleDb.EuqalTo() + AccountYear + oleDb.And() +
                       "A." + Tables.yf_account.ACCOUNTMONTH + oleDb.EuqalTo() + AccountMonth + oleDb.And() +
                       "A." + Tables.yf_account.MAKERDICID + oleDb.EuqalTo() + MakerDicID + oleDb.And() +
                       "A." + Tables.yf_account.DEPTID + oleDb.EuqalTo() + deptId;
                DateTime currentTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                orderDt = dal.YK_Account_GetList(str);
                return orderDt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        protected override decimal QueryTotalBeginFee(int drugTypeId, int accountYear, int accountMonth, int deptId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select SUM(BALANCEFEE)");
                string tableName = "";
                string opType = "";
                tableName = "YK_Account";
                opType = "'015'";
                strSql.Append(" from " + tableName + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" where A.OPTYPE=" + opType + " AND A.ACCOUNTTYPE=0 AND A.DeptID=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                object obj = oleDb.GetDataResult(strSql.ToString());
                if (obj != null && obj != DBNull.Value)
                {
                    decimal totalBeginFee = decimal.Parse(obj.ToString());
                    return totalBeginFee;
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

        protected override void QueryTotalEndFee(int drugTypeId, int accountYear, int accountMonth, int deptId, DataTable outFeeDt)
        {
            string accountTable = "";
            string op_monthaccount = "";
            YP_AccountHis accountHis;
            DataRow addRow;
            accountTable = "YK_Account";
            op_monthaccount = "'015'";
            accountHis = GetLastAccountHis(deptId);
            if (accountHis == null)
            {
                throw new Exception("未进行初始化月结，请先进行初始化月结！");
            }
            //如果查询的会计年，月份已经做过月结
            if (accountYear > accountHis.AccountYear || (accountMonth > accountHis.AccountMonth &&
                accountYear == accountHis.AccountYear))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select SUM(B.BALANCEFEE)");
                strSql.Append(" from (select MAX(MACCOUNTID) AS MACCOUNTID");
                strSql.Append(" from " + accountTable + " AA");
                strSql.Append(" left outer join YP_MakerDic BB");
                strSql.Append(" on AA.MAKERDICID=BB.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic CC");
                strSql.Append(" on BB.SPECDICID=CC.SPECDICID");
                strSql.Append(" where AA.ACCOUNTMONTH=" + accountMonth.ToString() + "");
                strSql.Append(" and AA.ACCOUNTYEAR=" + accountYear.ToString() + "");
                strSql.Append(" and AA.DeptID=" + deptId + "");
                if (drugTypeId != 0)
                {
                    strSql.Append(" and CC.TypeDicID=" + drugTypeId + "");
                }
                strSql.Append(" group by AA.MAKERDICID)A");
                strSql.Append(" left outer join " + accountTable + " B");
                strSql.Append(" on A.MACCOUNTID=B.MACCOUNTID");
                strSql.Append(" left outer join YP_MakerDic C");
                strSql.Append(" on C.MakerDicID=B.MakerDicID");
                Object obj = oleDb.GetDataResult(strSql.ToString());
                decimal storeFee = 0;
                if (obj != null && obj != DBNull.Value)
                {
                    storeFee = decimal.Parse(obj.ToString());
                    addRow = outFeeDt.NewRow();
                    addRow["项目"] = "月末结余";
                    addRow["金额"] = storeFee.ToString("0.00");
                    outFeeDt.Rows.Add(addRow);
                }
            }
            //未做过月结
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select SUM(A.BALANCEFEE)");
                strSql.Append(" from " + accountTable + " A");
                strSql.Append(" left outer join YP_MakerDic B");
                strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
                strSql.Append(" left outer join YP_SpecDic C");
                strSql.Append(" on B.SPECDICID=C.SPECDICID");
                strSql.Append(" where A.OPTYPE=" + op_monthaccount + " AND A.ACCOUNTTYPE=1 AND A.DeptId=" + deptId);
                if (drugTypeId != 0)
                {
                    strSql.Append(" AND C.TYPEDICID=" + drugTypeId.ToString());
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                else
                {
                    strSql.Append(" AND A.ACCOUNTYEAR=" + accountYear.ToString());
                    strSql.Append(" AND A.ACCOUNTMONTH=" + accountMonth.ToString());
                }
                object obj = oleDb.GetDataResult(strSql.ToString());
                decimal storeFee = 0;
                if (obj != null && obj != DBNull.Value)
                {
                    storeFee = decimal.Parse(obj.ToString());
                    addRow = outFeeDt.NewRow();
                    addRow["项目"] = "月末结余";
                    addRow["金额"] = storeFee.ToString("0.00");
                    outFeeDt.Rows.Add(addRow);
                }
            }
            return;
        }

        public override YP_AccountHis GetLastAccountHis(int deptId)
        {
            try
            {
                IBaseDAL<YP_AccountHis> accountHisDao = BindEntity<YP_AccountHis>.CreateInstanceDAL(oleDb, BLL.Tables.YK_ACCOUNTHIS);
                int maxId = accountHisDao.GetMaxId(Tables.yk_accounthis.ACCOUNTHISTORYID,
                    Tables.yk_accounthis.DEPTID + oleDb.EuqalTo() + deptId);
                YP_AccountHis accountHistory = accountHisDao.GetModel(maxId);
                return accountHistory;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override void GetAccountTime(DateTime regTime, ref int accountYear, ref int accountMonth, int deptId)
        {
            try
            {
                YP_AccountHis lastAccount = GetLastAccountHis(deptId);
                if (lastAccount == null)
                {
                    string deptName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(deptId.ToString());
                    throw new Exception("["+deptName+"]"+"当前库房还未进行初始化月结，请先月结");
                }
                if (regTime >= lastAccount.EndTime)
                {
                    if (lastAccount.AccountMonth != 12)
                    {
                        accountMonth = lastAccount.AccountMonth + 1;
                        accountYear = lastAccount.AccountYear;
                    }
                    else
                    {
                        accountMonth = 1;
                        accountYear = lastAccount.AccountYear + 1;
                    }

                }
                else
                {
                    accountMonth = lastAccount.AccountMonth;
                    accountYear = lastAccount.AccountYear;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override int GetActTimes(int deptId)
        {
            try
            {
                string count_1 = oleDb.Count("*", "totalNum");
                string strWhere_2 = Tables.yk_accounthis.DEPTID + oleDb.EuqalTo() + deptId.ToString();
                string strsql = oleDb.Table(Tables.YK_ACCOUNTHIS, "", strWhere_2, count_1);
                object rtnObject = oleDb.GetDataResult(strsql);
                if (rtnObject == null || rtnObject == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (int)rtnObject;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override DataTable GetActHisList(int deptId)
        {
            try
            {
                string strWhere = BLL.Tables.yk_account.DEPTID + oleDb.EuqalTo() + deptId;
                return BindEntity<YP_AccountHis>.CreateInstanceDAL(oleDb, BLL.Tables.YK_ACCOUNTHIS).GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
