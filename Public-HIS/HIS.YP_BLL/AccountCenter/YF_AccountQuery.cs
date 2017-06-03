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
    /// 药房台帐查询器
    /// </summary>
    class YF_AccountQuery : AccountQuery
    {
        public override DataTable GetOrderAccount(int drugType, int actYear, int actMonth, int deptId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.LENDERFEE,A.DEBITFEE,A.BALANCEFEE,A.ACCOUNTTYPE,C.TYPEDICID");
            strSql.Append(" from YF_Account A");
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
                string op_audit = "";
                string op_adjust = "";
                string op_adjAccount = "'"+ConfigManager.OP_YF_MONTHACCOUNT+"'";
                accountTable = "YF_Account";
                op_audit = "'009'";
                op_adjust = "'007'";
                DataTable inFeeDt = new DataTable();
                inFeeDt.Columns.Add("项目");
                inFeeDt.Columns.Add("金额");
                DataRow addRow;
                //查询所有入库项目和金额
                object obj = QueryInStoreFee(drugTypeId, accountYear, accountMonth, deptId, accountTable);
                if (obj != null && obj != DBNull.Value)
                {
                    decimal inStoreFee = decimal.Parse(obj.ToString());
                    addRow = inFeeDt.NewRow();
                    addRow["项目"] = "期初入库金额";
                    addRow["金额"] = inStoreFee.ToString("0.00");
                    inFeeDt.Rows.Add(addRow);
                }
                //查询所有调赢项目和金额
                obj = QueryAdjupFee(drugTypeId, accountYear, accountMonth, deptId, accountTable, op_adjust);
                if (obj != null && obj != DBNull.Value)
                {
                    decimal adjustInFee = decimal.Parse(obj.ToString());
                    if (adjustInFee != 0)
                    {
                        addRow = inFeeDt.NewRow();
                        addRow["项目"] = "调价盈余";
                        addRow["金额"] = adjustInFee.ToString("0.00");
                        inFeeDt.Rows.Add(addRow);
                    }
                }
                //查询所有盘盈项目和金额
                obj = QueryCheckupFee(drugTypeId, accountYear, accountMonth, deptId, accountTable, op_audit);
                if (obj != null && obj != DBNull.Value)
                {
                    decimal checkInFee = decimal.Parse(obj.ToString());
                    addRow = inFeeDt.NewRow();
                    addRow["项目"] = "盘点盈余";
                    addRow["金额"] = checkInFee.ToString("0.00");
                    inFeeDt.Rows.Add(addRow);
                }

                //查询所有退药项目和金额
                DataRow refundRow = QueryRefundFee(drugTypeId, accountYear, accountMonth, deptId);
                decimal refundFee;
                if (refundRow != null && refundRow["LENDERFEE"] != DBNull.Value &&
                    refundRow["DEBITFEE"] != DBNull.Value)
                {
                    refundFee = decimal.Parse(refundRow["LENDERFEE"].ToString()) - decimal.Parse(refundRow["DEBITFEE"].ToString());
                    addRow = inFeeDt.NewRow();
                    addRow["项目"] = "退药金额";
                    addRow["金额"] = refundFee.ToString("0.00");
                    inFeeDt.Rows.Add(addRow);
                }

                //查询所有月结调整账目
                obj = QueryAdjAccountFee(drugTypeId, accountYear, accountMonth, deptId, accountTable, op_adjAccount);
                if (obj != null && obj != DBNull.Value)
                {
                    decimal adjAccountFee = decimal.Parse(obj.ToString());
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

        private DataRow QueryRefundFee(int drugTypeId, int accountYear, int accountMonth, int deptId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(A.LENDERFEE) AS LENDERFEE,SUM(A.DEBITFEE) AS DEBITFEE");
            strSql.Append(" from YF_Account A");
            strSql.Append(" left outer join YP_MakerDic B");
            strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
            strSql.Append(" left outer join YP_SpecDic C");
            strSql.Append(" on B.SPECDICID=C.SPECDICID");
            strSql.Append(" where A.OPTYPE='004' AND A.DeptID=" + deptId);
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
            DataRow refundRow = oleDb.GetDataRow(strSql.ToString());
            return refundRow;
        }

        private object QueryCheckupFee(int drugTypeId, int accountYear, int accountMonth, int deptId, string accountTable, string op_audit)
        {
            StringBuilder strSql = new StringBuilder();
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
            Object obj = oleDb.GetDataResult(strSql.ToString());
            return obj;
        }

        private object QueryAdjupFee(int drugTypeId, int accountYear, int accountMonth, int deptId, string accountTable, string op_adjust)
        {
            StringBuilder strSql = new StringBuilder();
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
            Object obj = oleDb.GetDataResult(strSql.ToString());
            return obj;
        }

        private object QueryInStoreFee(int drugTypeId, int accountYear, int accountMonth, int deptId, string accountTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(A.LENDERFEE) AS INFEE");
            strSql.Append(" from " + accountTable + " A");
            strSql.Append(" left outer join YP_MakerDic B");
            strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
            strSql.Append(" left outer join YP_SpecDic C");
            strSql.Append(" on B.SPECDICID=C.SPECDICID");
            strSql.Append(" where A.OPTYPE in('014','001') AND A.ACCOUNTTYPE=2 AND A.DeptID=" + deptId);
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
            Object obj = oleDb.GetDataResult(strSql.ToString());
            return obj;
        }

        public override DataTable QueryAllOutFee(int drugTypeId, int accountYear, int accountMonth, int deptId)
        {
            try
            {
                string accountTable = "YF_Account";
                string op_reportloss = "'" + ConfigManager.OP_YF_REPORTLOSS + "'";
                string op_deptdraw = "('" + ConfigManager.OP_YF_DEPTDRAW + "')";
                string op_adjust = "'" + ConfigManager.OP_YF_ADJPRICE + "'";
                string op_audit = "'" + ConfigManager.OP_YF_AUDITCHECK + "'";
                DataTable outFeeDt = new DataTable();
                outFeeDt.Columns.Add("项目");
                outFeeDt.Columns.Add("金额");
                DataRow addRow;
                //查询所有报损出库金额
                object obj = QueryRptLossFee(drugTypeId, accountYear, accountMonth, deptId, accountTable, op_reportloss);
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
                DataTable outStoreDt = QueryDeptDrawFee(drugTypeId, accountYear, accountMonth, deptId, accountTable, op_deptdraw);
                if (outStoreDt != null)
                {
                    for (int index = 0; index < outStoreDt.Rows.Count; index++)
                    {
                        DataRow outStoreRow = outStoreDt.Rows[index];
                        addRow = outFeeDt.NewRow();
                        addRow["金额"] = decimal.Parse(outStoreRow["DEBITFEE"].ToString()).ToString("0.00");
                        addRow["项目"] = outStoreRow["NAME"].ToString() + "领取";
                        outFeeDt.Rows.Add(addRow);
                    }
                }
                //查询所有调亏金额
                obj = QueryAdjDownFee(drugTypeId, accountYear, accountMonth, deptId, accountTable, op_adjust);
                if (obj != null && obj != DBNull.Value)
                {
                    decimal adjustOutFee = decimal.Parse(obj.ToString());
                    addRow = outFeeDt.NewRow();
                    addRow["项目"] = "调价亏损金额";
                    addRow["金额"] = adjustOutFee.ToString("0.00");
                    outFeeDt.Rows.Add(addRow);
                }
                //查询所有发药金额
                DataTable dispenseDt = QueryDispenseFee(drugTypeId, accountYear, accountMonth, deptId);
                if (dispenseDt != null)
                {
                    for (int index = 0; index < dispenseDt.Rows.Count; index++)
                    {
                        DataRow dispenseRow = dispenseDt.Rows[index];
                        addRow = outFeeDt.NewRow();
                        addRow["金额"] = (decimal.Parse(dispenseRow["DEBITFEE"].ToString())
                            - decimal.Parse((dispenseRow["LENDERFEE"]).ToString())).ToString("0.00");
                        addRow["项目"] = "(" + dispenseRow["NAME"].ToString() + ")发药";
                        outFeeDt.Rows.Add(addRow);
                    }
                }
                //查询所有盘亏金额
                obj = QueryCheckdownFee(drugTypeId, accountYear, accountMonth, deptId, accountTable, op_audit);
                if (obj != null && obj != DBNull.Value)
                {
                    decimal checkOutFee = decimal.Parse(obj.ToString());
                    if (checkOutFee != 0)
                    {
                        addRow = outFeeDt.NewRow();
                        addRow["项目"] = "盘亏金额";
                        addRow["金额"] = checkOutFee.ToString("0.00");
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

        private object QueryCheckdownFee(int drugTypeId, int accountYear, int accountMonth, int deptId, string accountTable, string op_audit)
        {
            StringBuilder strSql = new StringBuilder();
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
            object obj = oleDb.GetDataResult(strSql.ToString());
            return obj;
        }

        private DataTable QueryDispenseFee(int drugTypeId, int accountYear, int accountMonth, int deptId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(A.DEBITFEE) AS DEBITFEE,SUM(A.LENDERFEE) AS LENDERFEE,E.NAME");
            strSql.Append(" from YF_Account A");
            strSql.Append(" left outer join YP_MakerDic B");
            strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
            strSql.Append(" left outer join YP_SpecDic C");
            strSql.Append(" on B.SPECDICID=C.SPECDICID");
            strSql.Append(" left outer join YF_DrOrder D");
            strSql.Append(" on A.ORDERID=D.ORDERDRUGOCID");
            strSql.Append(" left outer join BASE_DEPT_PROPERTY E");
            strSql.Append(" on D.CUREDEPTID=E.DEPT_ID");
            strSql.Append(" where A.OPTYPE='003' AND A.DeptId=" + deptId);
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
            DataTable dispenseDt = oleDb.GetDataTable(strSql.ToString());
            return dispenseDt;
        }

        private object QueryAdjDownFee(int drugTypeId, int accountYear, int accountMonth, int deptId, string accountTable, string op_adjust)
        {
            StringBuilder strSql = new StringBuilder();
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
            object obj = oleDb.GetDataResult(strSql.ToString());
            return obj;
        }

        private object QueryAdjAccountFee(int drugTypeId, int accountYear, int accountMonth, int deptId, string accountTable, string op_AdjAccount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(A.LENDERFEE)");
            strSql.Append(" from " + accountTable + " A");
            strSql.Append(" left outer join YP_MakerDic B");
            strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
            strSql.Append(" left outer join YP_SpecDic C");
            strSql.Append(" on B.SPECDICID=C.SPECDICID");
            strSql.Append(" where A.OPTYPE=" + op_AdjAccount + " AND A.ACCOUNTTYPE=3 AND A.DeptId=" + deptId);
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
            return obj;
        }

        private DataTable QueryDeptDrawFee(int drugTypeId, int accountYear, int accountMonth, int deptId, string accountTable, string op_deptdraw)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(A.DEBITFEE) AS DEBITFEE,E.NAME");
            strSql.Append(" from " + accountTable + " A");
            strSql.Append(" left outer join YP_MakerDic B");
            strSql.Append(" on A.MAKERDICID=B.MAKERDICID");
            strSql.Append(" left outer join YP_SpecDic C");
            strSql.Append(" on B.SPECDICID=C.SPECDICID");
            strSql.Append(" left outer join YF_OutOrder D");
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
            return outStoreDt;
        }

        private static object QueryRptLossFee(int drugTypeId, int accountYear, int accountMonth, int deptId, string accountTable, string op_reportloss)
        {
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
            return obj;
        }


        public override DataTable QueryOrderAccount(int AccountYear, int AccountMonth, int MakerDicID, int deptId)
        {
            try
            {
                DataTable orderDt;
                HIS.DAL.YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                string str = Tables.yf_account.ACCOUNTYEAR + oleDb.EuqalTo() + AccountYear + oleDb.And() +
                       Tables.yf_account.ACCOUNTMONTH + oleDb.EuqalTo() + AccountMonth + oleDb.And() +
                       Tables.yf_account.MAKERDICID + oleDb.EuqalTo() + MakerDicID + oleDb.And() +
                       Tables.yf_account.DEPTID + oleDb.EuqalTo() + deptId;
                DateTime currentTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                orderDt = dal.YF_Account_GetList(str);
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
                tableName = "YF_Account";
                opType = "'008'";
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
            accountTable = "YF_Account";
            op_monthaccount = "'008'";
            accountHis = GetLastAccountHis(deptId);
            //如果查询的会计年，月份未做过月结
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
                IBaseDAL<YP_AccountHis> accountHisDao = BindEntity<YP_AccountHis>.CreateInstanceDAL(oleDb, BLL.Tables.YF_ACCOUNTHIS);
                int maxId = accountHisDao.GetMaxId(Tables.yf_accounthis.ACCOUNTHISTORYID,
                    Tables.yf_accounthis.DEPTID + oleDb.EuqalTo() + deptId);
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
            
            throw new NotImplementedException();
        }

        public override DataTable GetActHisList(int deptId)
        {
            try
            {
                string strWhere = BLL.Tables.yf_account.DEPTID + oleDb.EuqalTo() + deptId;
                return BindEntity<YP_AccountHis>.CreateInstanceDAL(oleDb, BLL.Tables.YF_ACCOUNTHIS).GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

}
