using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Report
{
    public class PatFeeRpt : PatFeeReport, IPatFeeDataReport
    {

        private bool _IsDeptShow;
        private bool _IsDocShow;
        private bool _IsPatTypeShow;
        private DataTable dt = null;


        #region IPatFeeDataReport 成员

        public bool IsDeptShow
        {
            get
            {
                return _IsDeptShow;
            }
            set
            {
                _IsDeptShow = value;
            }
        }

        public bool IsDocShow
        {
            get
            {
                return _IsDocShow;
            }
            set
            {
                _IsDocShow = value;
            }
        }

        public bool IsPatTypeShow
        {
            get
            {
                return _IsPatTypeShow;
            }
            set
            {
                _IsPatTypeShow = value;
            }
        }

        #endregion

        #region IDataReport 成员


        public void LoadOperationData(DateTime Bdate, DateTime Edate)
        {
            base.CLoadOperationData(Bdate, Edate);
        }

        public DataTable GetData()
        {
            dt = new DataTable();
            CreateDataTableColumn();
            DataView dv = dt.DefaultView;
            if (IsPatTypeShow)
            {
                Patient();
                dv.Sort = "科室名称,医生姓名,类型";
            }
            else if (IsPatTypeShow == false && IsDocShow == true)
            {
                Doctor();
                dv.Sort = "科室名称,医生姓名";
            }
            else if (IsPatTypeShow == false && IsDocShow == false && IsDeptShow == true)
            {
                Dept();
                dv.Sort = "科室名称";
            }
            
            
            dt = dv.ToTable();

            CreateDataTableRowAll();
            return dt;
        }

        public Total_Type totalType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Item_Type itemType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Date_Type dateType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        private void CreateDataTableColumn()
        {
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;

            if (IsPatTypeShow)
            {

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "科室名称";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "医生姓名";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "住院号";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "病人姓名";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "类型";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

            }
            else if (IsPatTypeShow == false && IsDocShow == true)
            {

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "科室名称";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "医生姓名";
                //column.ReadOnly = true;
                dt.Columns.Add(column);
            }
            else if (IsPatTypeShow == false && IsDocShow == false && IsDeptShow == true)
            {

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "科室名称";
                //column.ReadOnly = true;
                dt.Columns.Add(column);
            }

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "总金额";
            //column.ReadOnly = true;
            dt.Columns.Add(column);


            for (int i = 0; i < baseDataSet.Tables["BASE_STAT_ZYFP"].Rows.Count; i++)
            {
                column = new DataColumn();

                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = baseDataSet.Tables["BASE_STAT_ZYFP"].Rows[i]["NAME"].ToString();
                //column.ReadOnly = true;
                dt.Columns.Add(column);
            }

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "未知项目";
            //column.ReadOnly = true;
            dt.Columns.Add(column);

        }

        private void CreateDataTableRowAll()
        {
            DataRow row = dt.NewRow();

            row[0] = "合计";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //row["合计"] = Convert.ToDecimal(row["合计"]) + Convert.ToDecimal(dt.Rows[i]["合计"]);
                int startNum = 1;

                if (IsPatTypeShow)
                {
                    startNum = 5;
                }
                else if (IsPatTypeShow == false && IsDocShow == true)
                {
                    startNum = 2;
                }
                else if (IsPatTypeShow == false && IsDocShow == false && IsDeptShow == true)
                {
                    startNum = 1;
                }
                for (int j = startNum; j < dt.Columns.Count; j++)
                {
                    row[j] = Dbnull(row[j]) + Dbnull(dt.Rows[i][j]);
                }
            }
            dt.Rows.Add(row);
        }

        private void Patient()
        {
            DataRow row = null;
            # region 病人
            for (int i = 0; i < operationList.zyPresorderList.Count; i++)
            {
                //string Row_Chargename = base.GetName("BASE_EMPLOYEE_PROPERTY", operationList.zyCostmasterList[i].ChargeCode);

                string deptcode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).CurrDeptCode;
                string Row_deptname = base.GetName("BASE_DEPT_PROPERTY", deptcode);

                string doccode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).CureDocCode;
                string Row_docname = base.GetName("BASE_EMPLOYEE_PROPERTY", doccode);

                string Row_CureNo = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).CureNo;
                string Row_patname = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).patientInfo.PatName;
                string patcode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).PatientCode;
                string Row_patType = base.GetName("BASE_PATIENTTYPE",patcode);
                //string Row_ticketno = operationList.zyCostmasterList[i].TicketCode;

                DataRow[] drs = dt.Select("病人姓名='" + Row_patname + "' and 住院号='" + Row_CureNo + "'");
#if DEBUG

#endif
                if (drs.Length == 0)
                {
                    row = dt.NewRow();
                    //row["结算人"] = Row_Chargename;
                    row["科室名称"] = Row_deptname;
                    row["医生姓名"] = Row_docname;
                    row["住院号"] = Row_CureNo;
                    row["病人姓名"] = Row_patname;
                    row["类型"] = Row_patType;
                    //row["发票号"] = Row_ticketno;
                    row["总金额"] = Convert.ToDecimal(operationList.zyPresorderList[i].Tolal_Fee.ToString("0.00"));

                    //row["记账金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    //row["自付金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    //row["优惠金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));

                    IsTicketItem_0(row, i);
                    //IsVillageItem_0(row, i);
                    //IsSelfItem_0(row, i);

                    dt.Rows.Add(row);
                }
                else
                {
                    drs[0]["总金额"] = Dbnull(drs[0]["总金额"]) + Convert.ToDecimal(operationList.zyPresorderList[i].Tolal_Fee.ToString("0.00"));
                    //drs[0]["记账金额"] = Dbnull(drs[0]["记账金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    //drs[0]["自付金额"] = Dbnull(drs[0]["自付金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    //drs[0]["优惠金额"] = Dbnull(drs[0]["优惠金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));

                    IsTicketItem_1(drs, i);
                    //IsVillageItem_1(drs, i);
                    //IsSelfItem_1(drs, i);
                }
            }
            #endregion
        }

        private void Doctor()
        {
            DataRow row = null;
            # region 医生
            for (int i = 0; i < operationList.zyPresorderList.Count; i++)
            {
                //string Row_Chargename = base.GetName("BASE_EMPLOYEE_PROPERTY", operationList.zyCostmasterList[i].ChargeCode);

                string deptcode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).CurrDeptCode;
                string Row_deptname = base.GetName("BASE_DEPT_PROPERTY", deptcode);

                string doccode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).CureDocCode;
                string Row_docname = base.GetName("BASE_EMPLOYEE_PROPERTY", doccode);

                //string Row_CureNo = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).CureNo;
                //string Row_patname = base.GetPatName(operationList.zyPresorderList[i].PatID);
                //string patcode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).PatientCode;
                //string Row_patType = base.GetName("BASE_PATIENTTYPE", patcode);
                //string Row_ticketno = operationList.zyCostmasterList[i].TicketCode;

                DataRow[] drs = dt.Select("医生姓名 = '" + Row_docname + "'");
#if DEBUG

#endif
                if (drs.Length == 0)
                {
                    row = dt.NewRow();
                    //row["结算人"] = Row_Chargename;
                    row["科室名称"] = Row_deptname;
                    row["医生姓名"] = Row_docname;
                    //row["住院号"] = Row_CureNo;
                    //row["病人姓名"] = Row_patname;
                    //row["类型"] = Row_patType;
                    //row["发票号"] = Row_ticketno;
                    row["总金额"] = Convert.ToDecimal(operationList.zyPresorderList[i].Tolal_Fee.ToString("0.00"));

                    //row["记账金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    //row["自付金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    //row["优惠金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));

                    IsTicketItem_0(row, i);
                    //IsVillageItem_0(row, i);
                    //IsSelfItem_0(row, i);

                    dt.Rows.Add(row);
                }
                else
                {
                    drs[0]["科室名称"] = RetureName(drs[0]["科室名称"], Row_deptname);
                    drs[0]["总金额"] = Dbnull(drs[0]["总金额"]) + Convert.ToDecimal(operationList.zyPresorderList[i].Tolal_Fee.ToString("0.00"));
                    //drs[0]["记账金额"] = Dbnull(drs[0]["记账金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    //drs[0]["自付金额"] = Dbnull(drs[0]["自付金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    //drs[0]["优惠金额"] = Dbnull(drs[0]["优惠金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));

                    IsTicketItem_1(drs, i);
                    //IsVillageItem_1(drs, i);
                    //IsSelfItem_1(drs, i);
                }
            }
            #endregion
        }

        private void Dept()
        {
            DataRow row = null;
            # region 科室
            for (int i = 0; i < operationList.zyPresorderList.Count; i++)
            {
                //string Row_Chargename = base.GetName("BASE_EMPLOYEE_PROPERTY", operationList.zyCostmasterList[i].ChargeCode);

                string deptcode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).CurrDeptCode;
                string Row_deptname = base.GetName("BASE_DEPT_PROPERTY", deptcode);

                //string doccode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).CureDocCode;
                //string Row_docname = base.GetName("BASE_EMPLOYEE_PROPERTY", doccode);

                //string Row_CureNo = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).CureNo;
                //string Row_patname = base.GetPatName(operationList.zyPresorderList[i].PatID);
                //string patcode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyPresorderList[i].PatListID).PatientCode;
                //string Row_patType = base.GetName("BASE_PATIENTTYPE", patcode);
                //string Row_ticketno = operationList.zyCostmasterList[i].TicketCode;

                DataRow[] drs = dt.Select("科室名称 = '" + Row_deptname + "'");
#if DEBUG

#endif
                if (drs.Length == 0)
                {
                    row = dt.NewRow();
                    //row["结算人"] = Row_Chargename;
                    row["科室名称"] = Row_deptname;
                    //row["医生姓名"] = Row_docname;
                    //row["住院号"] = Row_CureNo;
                    //row["病人姓名"] = Row_patname;
                    //row["类型"] = Row_patType;
                    //row["发票号"] = Row_ticketno;
                    row["总金额"] = Convert.ToDecimal(operationList.zyPresorderList[i].Tolal_Fee.ToString("0.00"));

                    //row["记账金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    //row["自付金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    //row["优惠金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));

                    IsTicketItem_0(row, i);
                    //IsVillageItem_0(row, i);
                    //IsSelfItem_0(row, i);

                    dt.Rows.Add(row);
                }
                else
                {
                    drs[0]["总金额"] = Dbnull(drs[0]["总金额"]) + Convert.ToDecimal(operationList.zyPresorderList[i].Tolal_Fee.ToString("0.00"));
                    //drs[0]["记账金额"] = Dbnull(drs[0]["记账金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    //drs[0]["自付金额"] = Dbnull(drs[0]["自付金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    //drs[0]["优惠金额"] = Dbnull(drs[0]["优惠金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));

                    IsTicketItem_1(drs, i);
                    //IsVillageItem_1(drs, i);
                    //IsSelfItem_1(drs, i);
                }
            }
            #endregion
        }

        private void IsTicketItem_0(DataRow row, int i)
        {
            string Col_name = base.GetItemName("BASE_STAT_ZYFP", operationList.zyPresorderList[i].ItemType.Trim());
            if (Col_name == "")
            {
                Col_name = "未知项目";
            }

            row[Col_name] = Dbnull(row[Col_name]) + Convert.ToDecimal(operationList.zyPresorderList[i].Tolal_Fee.ToString("0.00"));
        }

        private void IsTicketItem_1(DataRow[] drs, int i)
        {
            string Col_name = base.GetItemName("BASE_STAT_ZYFP", operationList.zyPresorderList[i].ItemType.Trim());
            if (Col_name == "")
            {
                Col_name = "未知项目";
            }
            drs[0][Col_name] = Dbnull(drs[0][Col_name]) + Convert.ToDecimal(operationList.zyPresorderList[i].Tolal_Fee.ToString("0.00"));
        }
    }
}
