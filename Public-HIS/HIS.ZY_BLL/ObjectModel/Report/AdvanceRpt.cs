using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Report
{
    public class AdvanceRpt : AdvanceFeeReport, IAdvanceDataReport
    {
        #region IDataReport 成员
        private Total_Type _totalType = Total_Type.开方医生;
        private Item_Type _itemType = Item_Type.发票项目;
        private Date_Type _dateType = Date_Type.记账时间;
        private DataTable dt = null;


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
            CreateDataTableColumn();

            switch (advShow)
            {
                case AdvanceDataShowType.汇总:
                    ChargeAll();
                    break;
                case AdvanceDataShowType.明细:
                    ChargeMX();
                    break;
            }
            dt.DefaultView.Sort = "收费员";
            dt = dt.DefaultView.ToTable();
            CreateDataTableRowAll();           
            return dt;
        }

        private void ChargeAll()
        {
            DataRow row = null;
            for (int i = 0; i < operationList.zyChargeList.Count; i++)
            {
                //if (CheckChargeList(i))
                //{
                    string Row_name = base.GetName("BASE_EMPLOYEE_PROPERTY", operationList.zyChargeList[i].ChargeCode);

                    DataRow[] drs = dt.Select("收费员='" + Row_name + "'");
                    if (drs.Length == 0)
                    {
                        row = dt.NewRow();
                        row["收费员"] = Row_name;
                        row["预交笔数"] = 1;
                        row["总金额"] = operationList.zyChargeList[i].Total_Fee;
                        dt.Rows.Add(row);
                    }
                    else
                    {
                        drs[0]["预交笔数"] = Dbnull(drs[0]["预交笔数"]) + 1;
                        drs[0]["总金额"] = Dbnull(drs[0]["总金额"]) + Convert.ToDecimal(operationList.zyChargeList[i].Total_Fee.ToString("0.00"));
                    }
                //}
            }
        }

        
        private void ChargeMX()
        {
            DataRow row = null;
            for (int i = 0; i < operationList.zyChargeList.Count; i++)
            {
                //if (CheckChargeList(i))
                //{
                    string Row_name = base.GetName("BASE_EMPLOYEE_PROPERTY", operationList.zyChargeList[i].ChargeCode);
                    string Row_PatName = base.GetPatName(operationList.zyChargeList[i].PatID);
                    string Row_Cureno = operationList.zyChargeList[i].CureNo;
                    string Row_Billno = operationList.zyChargeList[i].BillNo;
                    string Row_date = operationList.zyChargeList[i].CostDate.ToString();
                    decimal Row_fee = operationList.zyChargeList[i].Total_Fee;
                    //DataRow[] drs = dt.Select("收费员='" + Row_name + "' and ");
                    row = dt.NewRow();
                    row["收费员"] = Row_name;
                    row["病人姓名"] = Row_PatName;
                    row["住院号"] = Row_Cureno;
                    row["单据号"] = Row_Billno;
                    row["时间"] = Row_date;
                    row["单据金额"] = Row_fee;
                    dt.Rows.Add(row);

                //}
            }
        }

        private bool CheckChargeList(int i)
        {
            bool b = false;
            if (dateType == Date_Type.交款时间)
            {
                //base.GLoadOperationData(Bdate, Edate);
                b = operationList.zyAccountList.Exists(x => x.AccountID == operationList.zyChargeList[i].AccountID);
            }
            else if (dateType == Date_Type.结算时间)
            {
                //base.TLoadOperationData(Bdate, Edate);
                b = operationList.zyCostmasterList.Exists(x => x.CostMasterID == operationList.zyChargeList[i].Delete_Flag);
            }
            else if (dateType == Date_Type.记账时间)
            {
                b = true;
            }

            return b;
        }

        private void CreateDataTableColumn()
        {
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "收费员";
            //column.ReadOnly = true;
            dt.Columns.Add(column);


            switch (advShow)
            {
                case AdvanceDataShowType.汇总:
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.Decimal");
                    column.ColumnName = "预交笔数";
                    //column.ReadOnly = true;
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.Decimal");
                    column.ColumnName = "总金额";
                    //column.ReadOnly = true;
                    dt.Columns.Add(column);
                    break;
                case AdvanceDataShowType.明细:

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "病人姓名";
                    //column.ReadOnly = true;
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "住院号";
                    //column.ReadOnly = true;
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "单据号";
                    //column.ReadOnly = true;
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "时间";
                    //column.ReadOnly = true;
                    dt.Columns.Add(column);


                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.Decimal");
                    column.ColumnName = "单据金额";
                    //column.ReadOnly = true;
                    dt.Columns.Add(column);
                    break;
         
            }

        }

        private void CreateDataTableRowAll()
        {
            DataRow row = dt.NewRow();

            row["收费员"] = "合计";
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //row["合计"] = Convert.ToDecimal(row["合计"]) + Convert.ToDecimal(dt.Rows[i]["合计"]);
                int startNum = 1;

                switch (advShow)
                {
                    case AdvanceDataShowType.汇总:
                        startNum = 1;
                        break;
                    case AdvanceDataShowType.明细:
                        startNum = 5;
                        break;
                }

                for (int j = startNum; j < dt.Columns.Count; j++)
                {
                    row[j] = Dbnull(row[j]) + Dbnull(dt.Rows[i][j]);
                }
            }
            dt.Rows.Add(row);
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

        #endregion

        private AdvanceDataShowType _advShow = AdvanceDataShowType.汇总;

        public AdvanceDataShowType advShow
        {
            get
            {
                return _advShow;
            }
            set
            {
                _advShow = value;
            }
        }
    }
}
