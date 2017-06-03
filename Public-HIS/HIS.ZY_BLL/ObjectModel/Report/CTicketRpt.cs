using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.ZY_BLL.DataModel;

namespace HIS.ZY_BLL.Report
{
    //zenghao [20100507.2.01]
    /// <summary>
    /// 发票项目
    /// </summary>
    public class CTicketRpt : ChargeDateReport,IDataReport
    {
        private Total_Type _totalType = Total_Type.开方医生;
        private Item_Type _itemType = Item_Type.发票项目;
        private Date_Type _dateType = Date_Type.记账时间;

        private DataTable dt = null;
        private string ItemName = null;

        public Date_Type dateType
        {
            get
            {
                return _dateType;
            }
            set
            {
                _dateType = value;
            }
        }
        public Total_Type totalType
        {
            get
            {
                return _totalType;
            }
            set
            {
                _totalType = value;
            }
        }
        public Item_Type itemType
        {
            get
            {
                return _itemType;
            }
            set
            {
                _itemType = value;
            }
        }

        public void LoadOperationData(DateTime Bdate, DateTime Edate)
        {
            if (dateType == Date_Type.记账时间)
            {
                base.CLoadOperationData(Bdate, Edate);
            }
            else if (dateType == Date_Type.交款时间)
            {
                base.GLoadOperationData(Bdate, Edate);
            }
            else if (dateType == Date_Type.结算时间)
            {
                base.TLoadOperationData(Bdate, Edate);
            }
        }

        public DataTable GetData()
        {
            dt = new DataTable();

            if (itemType == Item_Type.发票项目)
            {
                ItemName = "BASE_STAT_ZYFP";
            }
            else if (itemType == Item_Type.核算项目)
            {
                ItemName = "BASE_STAT_HS";
            }
            else if (itemType == Item_Type.会计项目)
            {
                ItemName = "BASE_STAT_ZYKJ";
            }
            else if (itemType == Item_Type.大项目)
            {
                ItemName = "BASE_STAT_ITEM";
            }

            CreateDataTableColumn();

            if (totalType == Total_Type.开方医生)
            {
                presDoc();             
            }
            else if (totalType == Total_Type.主管医生)
            {
                chargeDoc();
            }
            else if (totalType == Total_Type.病人科室)
            {
                patDept();
            }
            else if (totalType == Total_Type.执行科室)
            {
                execDept();
            }

            CreateDataTableRowAll();
            return dt;
        }

        private DataTable presDoc()
        {
            DataRow row = null;

            for (int i = 0; i < operationList.PresDT.Rows.Count; i++)
            {
                string Row_name = base.GetName("BASE_EMPLOYEE_PROPERTY", operationList.PresDT.Rows[i]["PresDocCode"].ToString().Trim());
                string Col_name = base.GetItemName(ItemName, operationList.PresDT.Rows[i]["ItemType"].ToString().Trim());
                if (Col_name == "")
                {
                    Col_name = "未知项目";
                }
                DataRow[] drs = dt.Select("名称='" + Row_name + "'");

                if (drs.Length == 0)
                {
                    row = dt.NewRow();
                    row["名称"] = Row_name;
                    row["合计"] = Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    row[Col_name] = Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    dt.Rows.Add(row);
                }
                else
                {
                    drs[0]["合计"] = Dbnull(drs[0]["合计"]) + Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    drs[0][Col_name] = Dbnull(drs[0][Col_name]) + Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                }
            }
            return dt;
        }

        private DataTable chargeDoc()
        {
            DataRow row = null;

            for (int i = 0; i < operationList.PresDT.Rows.Count; i++)
            {

                string Row_name = base.GetName("BASE_EMPLOYEE_PROPERTY", operationList.PresDT.Rows[i]["CureDocCode"].ToString().Trim());
                string Col_name = base.GetItemName(ItemName, operationList.PresDT.Rows[i]["ItemType"].ToString().Trim());
                if (Col_name == "")
                {
                    Col_name = "未知项目";
                }
                DataRow[] drs = dt.Select("名称='" + Row_name + "'");

                if (drs.Length == 0)
                {
                    row = dt.NewRow();
                    row["名称"] = Row_name;
                    row["合计"] = Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    row[Col_name] = Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    dt.Rows.Add(row);
                }
                else
                {
                    drs[0]["合计"] = Dbnull(drs[0]["合计"]) + Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    drs[0][Col_name] = Dbnull(drs[0][Col_name]) + Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                }
            }
            return dt;
        }

        private DataTable patDept()
        {
            DataRow row = null;

            for (int i = 0; i < operationList.PresDT.Rows.Count; i++)
            {
                string Row_name = base.GetName("BASE_DEPT_PROPERTY", operationList.PresDT.Rows[i]["PresDeptCode"].ToString().Trim());
                string Col_name = base.GetItemName(ItemName,  operationList.PresDT.Rows[i]["ItemType"].ToString().Trim());
                if (Col_name == "")
                {
                    Col_name = "未知项目";
                }
                DataRow[] drs = dt.Select("名称='" + Row_name + "'");

                if (drs.Length == 0)
                {
                    row = dt.NewRow();
                    row["名称"] = Row_name;
                    row["合计"] = Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    row[Col_name] = Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    dt.Rows.Add(row);
                }
                else
                {
                    drs[0]["合计"] = Dbnull(drs[0]["合计"]) + Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    drs[0][Col_name] = Dbnull(drs[0][Col_name]) + Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                }
            }
            return dt;
        }

        private DataTable execDept()
        {
            DataRow row = null;

            for (int i = 0; i < operationList.PresDT.Rows.Count; i++)
            {

                string Row_name = base.GetName("BASE_DEPT_PROPERTY", operationList.PresDT.Rows[i]["ExecDeptCode"].ToString().Trim());
                string Col_name = base.GetItemName(ItemName, operationList.PresDT.Rows[i]["ItemType"].ToString().Trim());
                if (Col_name == "")
                {
                    Col_name = "未知项目";
                }
                DataRow[] drs = dt.Select("名称='" + Row_name + "'");

                if (drs.Length == 0)
                {
                    row = dt.NewRow();
                    row["名称"] = Row_name;
                    row["合计"] = Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    row[Col_name] = Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    dt.Rows.Add(row);
                }
                else
                {
                    drs[0]["合计"] = Dbnull(drs[0]["合计"]) + Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                    drs[0][Col_name] = Dbnull(drs[0][Col_name]) + Convert.ToDecimal(operationList.PresDT.Rows[i]["Tolal_Fee"]);
                }
            }
            return dt;
        }

        //private bool CheckPresOrder_BK(int i)
        //{
        //    bool b = false;
        //    if (dateType == Date_Type.记账时间)
        //    {
        //        //base.CLoadOperationData(Bdate, Edate);
        //        b = true;
        //    }
        //    else if (dateType == Date_Type.交款时间)
        //    {



        //        if (operationList.zyPresorderList[i].OldID == -1)
        //        {
        //            b = true;
        //            return b;
        //        }

        //        //base.GLoadOperationData(Bdate, Edate);
        //        //第一步：先判断明细是否存在在结算记录中
        //        ZY_CostMaster zyC = operationList.zyCostmasterList.Find(
        //            delegate(ZY_CostMaster x)
        //            {
        //                return x.CostMasterID == operationList.zyPresorderList[i].CostMasterID;
        //            }
        //        );



        //        //第二步：判断结算记录是否存在与交款记录中
        //        if (zyC != null)
        //        {
        //            b = operationList.zyAccountList.Exists(
        //          delegate(ZY_Account x)
        //          {
        //              return (x.AccountID == zyC.AccountID);
        //          }
        //        );


        //            //确保有两个交款员交款时有交叉问题
        //        }

        //    }
        //    else if (dateType == Date_Type.结算时间)
        //    {
        //        //base.TLoadOperationData(Bdate, Edate);
        //        b = operationList.zyCostmasterList.Exists(
        //            delegate(ZY_CostMaster x)
        //            { return x.CostMasterID == operationList.zyPresorderList[i].CostMasterID; }
        //        );
        //    }
        //    return b;
        //}

        //private bool CheckPresOrder(int i)
        //{
        //    return true;
        //}

        private void CreateDataTableColumn()
        {
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "名称";
            //column.ReadOnly = true;
            // Add the Column to the DataColumnCollection.
            dt.Columns.Add(column);

            

            for (int i = 0; i < baseDataSet.Tables[ItemName].Rows.Count; i++)
            {
                column = new DataColumn();

                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = baseDataSet.Tables[ItemName].Rows[i]["NAME"].ToString();
                //column.ReadOnly = true;
                dt.Columns.Add(column);
            }

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "未知项目";
            //column.ReadOnly = true;
            dt.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "合计";
            //column.ReadOnly = false;
            // Add the column to the table.
            dt.Columns.Add(column);
        }

        private void CreateDataTableRowAll()
        {
            DataRow row = dt.NewRow();
            row["名称"] = "合计";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //row["合计"] = Convert.ToDecimal(row["合计"]) + Convert.ToDecimal(dt.Rows[i]["合计"]);
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    row[j] = Dbnull( row[j]) + Dbnull(dt.Rows[i][j]);
                }
            }
            dt.Rows.Add(row);
        }      

    }
}
