/// Company: 长城医疗有限公司
/// Designer: 曾浩
/// Coder: 曾浩
/// Version: 1.0
/// History:
///	2009-01-01  曾浩 [创建]
/// 2009-02-15  曾浩 [编码]
/// 2010-03-09  曾浩 [修改] 【072】
/// 要新增报表，能查询一段时期出院病人的情况，包括病人总费用、详细费用、
/// 入出院的具体时间、经治医生等。（格式已提供：西牛001）


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.ZY_BLL.DataModel;


namespace HIS.ZY_BLL.Report
{
    public class TicketRpt : TicketReport, ITicketDataReport
    {
        //private TicketDataShowType _IsShow=TicketDataShowType.收费员;
        private bool _IsTicketItem;
        private bool _IsVillageItem;
        private bool _IsSelfItem;

        private Date_Type _dateType = Date_Type.记账时间;
        private DataTable dt = null;

        #region ITicketDataReport 成员

        public bool IsTicketItem
        {
            get
            {
                return _IsTicketItem;
            }
            set
            {
                _IsTicketItem = value;
            }
        }

        public bool IsVillageItem
        {
            get
            {
                return _IsVillageItem;
            }
            set
            {
                _IsVillageItem = value;
            }
        }

        public bool IsSelfItem
        {
            get
            {
                return _IsSelfItem;
            }
            set
            {
                _IsSelfItem = value;
            }
        }

        private bool _isChargerShow=false;
        public bool IsChargerShow
        {
            get
            {
                return _isChargerShow;
            }
            set
            {
                _isChargerShow = value;
            }
        }

        private bool _isDeptShow = false;
        public bool IsDeptShow
        {
            get
            {
                return _isDeptShow;
            }
            set
            {
                _isDeptShow = value;
            }
        }

        private bool _isDocShow = false;
        public bool IsDocShow
        {
            get
            {
                return _isDocShow;
            }
            set
            {
                _isDocShow = value;
            }
        }

        private bool _isPatTypeShow = false;
        public bool IsPatTypeShow
        {
            get
            {
                return _isPatTypeShow;
            }
            set
            {
                _isPatTypeShow = value;
            }
        }

        #endregion

        #region IDataReport 成员

        public void LoadOperationData(DateTime Bdate, DateTime Edate)
        {
            if (dateType == Date_Type.交款时间)
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
            DataView dv = dt.DefaultView;
            if (IsPatTypeShow)
            {
                Patient();
                dv.Sort = "结算人,科室名称,医生姓名,类型";
            }
            else if (IsPatTypeShow == false && IsDocShow == true)
            {
                Doctor();
                dv.Sort = "结算人,科室名称,医生姓名";
            }
            else if (IsPatTypeShow == false && IsDocShow == false && IsDeptShow == true)
            {
                Dept();
                dv.Sort = "结算人,科室名称";
            }
            else if (IsPatTypeShow == false && IsDocShow == false && IsDeptShow == false)
            {
                ChargeEmp();
                dv.Sort = "结算人";
            }
            
            
            dt = dv.ToTable();
            
            CreateDataTableRowAll();
            return dt;
        }
        #region
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
                return _dateType;
            }
            set
            {
                _dateType = value;
            }
        }
        #endregion
        #endregion

        private void ChargeEmp()
        {
            DataRow row = null;
            #region 收费员
            for (int i = 0; i < operationList.zyCostmasterList.Count; i++)
            {
                string Row_name = base.GetName("BASE_EMPLOYEE_PROPERTY", operationList.zyCostmasterList[i].ChargeCode);
                //string PatType = base.GetName(Tables.BASE_PATIENTTYPE, operationList.zyCostmasterList[i].PatType);
                DataRow[] drs = dt.Select("结算人='" + Row_name + "'");
                if (drs.Length == 0)
                {
                    row = dt.NewRow();
                    row["结算人"] = Row_name;
                    row["总金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Total_Fee.ToString("0.00"));
                    row["记账金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    row["自付金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    row["优惠金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));
                    IsTicketItem_0(row, i);
                    IsVillageItem_0(row, i);
                    IsSelfItem_0(row, i);

                    dt.Rows.Add(row);
                }
                else
                {
                    drs[0]["总金额"] = Dbnull(drs[0]["总金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Total_Fee.ToString("0.00"));
                    drs[0]["记账金额"] = Dbnull(drs[0]["记账金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    drs[0]["自付金额"] = Dbnull(drs[0]["自付金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    drs[0]["优惠金额"] = Dbnull(drs[0]["优惠金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));
                    IsTicketItem_1(drs, i);
                    IsVillageItem_1(drs, i);
                    IsSelfItem_1(drs, i);
                }
            }
            #endregion

        }

        private void Patient()
        {
            DataRow row = null;
            # region 病人
            for (int i = 0; i < operationList.zyCostmasterList.Count; i++)
            {
                string Row_Chargename = base.GetName("BASE_EMPLOYEE_PROPERTY", operationList.zyCostmasterList[i].ChargeCode);

                string deptcode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyCostmasterList[i].PatListID).CurrDeptCode;
                string Row_deptname = base.GetName("BASE_DEPT_PROPERTY", deptcode);

                string doccode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyCostmasterList[i].PatListID).CureDocCode;
                string Row_docname = base.GetName("BASE_EMPLOYEE_PROPERTY", doccode);

                string Row_CureNo = operationList.zyCostmasterList[i].CureNo;
                string Row_patname = operationList.zyPatList.Find(x => x.PatListID == operationList.zyCostmasterList[i].PatListID).patientInfo.PatName;//base.GetPatName(operationList.zyCostmasterList[i].PatID);
                string Row_patType = base.GetName("BASE_PATIENTTYPE", operationList.zyCostmasterList[i].PatType);
                string Row_ticketno = operationList.zyCostmasterList[i].TicketCode;

                DataRow[] drs = dt.Select("病人姓名='" + Row_patname + "' and 发票号='" + Row_ticketno + "'");
#if DEBUG
                if (Row_ticketno == "JE30982300")
                {
                    Console.Out.WriteLine(operationList.zyCostmasterList[i].CostMasterID);
                }
#endif
                if (drs.Length == 0)
                {
                    row = dt.NewRow();
                    row["结算人"] = Row_Chargename;
                    row["科室名称"] = Row_deptname;
                    row["医生姓名"] = Row_docname;
                    //row["住院号"] = Row_CureNo;
                    row["病人姓名"] = Row_patname;
                    row["类型"] = Row_patType;
                    row["发票号"] = Row_ticketno;
                    row["总金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Total_Fee.ToString("0.00"));

                    row["记账金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    row["自付金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    row["优惠金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));

                    IsTicketItem_0(row, i);
                    IsVillageItem_0(row, i);
                    IsSelfItem_0(row, i);

                    dt.Rows.Add(row);
                }
                else
                {
                    drs[0]["总金额"] = Dbnull(drs[0]["总金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Total_Fee.ToString("0.00"));
                    drs[0]["记账金额"] = Dbnull(drs[0]["记账金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    drs[0]["自付金额"] = Dbnull(drs[0]["自付金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    drs[0]["优惠金额"] = Dbnull(drs[0]["优惠金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));

                    IsTicketItem_1(drs, i);
                    IsVillageItem_1(drs, i);
                    IsSelfItem_1(drs, i);
                }
            }
            #endregion
        }

        private void Doctor()
        {
            DataRow row = null;
            # region 医生
            for (int i = 0; i < operationList.zyCostmasterList.Count; i++)
            {
                string Row_Chargename = base.GetName("BASE_EMPLOYEE_PROPERTY", operationList.zyCostmasterList[i].ChargeCode);

                string deptcode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyCostmasterList[i].PatListID).CurrDeptCode;
                string Row_deptname = base.GetName("BASE_DEPT_PROPERTY", deptcode);


                string doccode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyCostmasterList[i].PatListID).CureDocCode;
                string Row_docname = base.GetName("BASE_EMPLOYEE_PROPERTY", doccode);

                DataRow[] drs = dt.Select("医生姓名 = '" + Row_docname + "'");

                if (drs.Length == 0)
                {
                    row = dt.NewRow();
                    row["结算人"] = Row_Chargename;
                    row["科室名称"] = Row_deptname;
                    row["医生姓名"] = Row_docname;
                    //row["出院人数"] = operationList.zyCostmasterList[i].Record_Flag == 0 ? 1 : 0;
                    row["总金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Total_Fee.ToString("0.00"));
                    row["记账金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    row["自付金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    row["优惠金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));
                    IsTicketItem_0(row, i);
                    IsVillageItem_0(row, i);
                    IsSelfItem_0(row, i);

                    dt.Rows.Add(row);
                }
                else
                {
                    drs[0]["结算人"] = RetureName(drs[0]["结算人"], Row_Chargename);
                    drs[0]["科室名称"] = RetureName(drs[0]["科室名称"], Row_deptname);
                    //drs[0]["出院人数"] = Dbnull(drs[0]["出院人数"]) + (operationList.zyCostmasterList[i].Record_Flag == 0 ? 1 : 0);
                    drs[0]["总金额"] = Dbnull(drs[0]["总金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Total_Fee.ToString("0.00"));
                    drs[0]["记账金额"] = Dbnull(drs[0]["记账金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    drs[0]["自付金额"] = Dbnull(drs[0]["自付金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    drs[0]["优惠金额"] = Dbnull(drs[0]["优惠金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));

                    IsTicketItem_1(drs, i);
                    IsVillageItem_1(drs, i);
                    IsSelfItem_1(drs, i);
                }
            }
            #endregion
        }
        
        private void Dept()
        {
            DataRow row = null;
            # region 科室
            for (int i = 0; i < operationList.zyCostmasterList.Count; i++)
            {
                string Row_Chargename = base.GetName("BASE_EMPLOYEE_PROPERTY", operationList.zyCostmasterList[i].ChargeCode);

                string deptcode = operationList.zyPatList.Find(x => x.PatListID == operationList.zyCostmasterList[i].PatListID).CurrDeptCode;
                string Row_deptname = base.GetName("BASE_DEPT_PROPERTY", deptcode);

                DataRow[] drs = dt.Select("科室名称 = '" + Row_deptname + "'");

                if (drs.Length == 0)
                {
                    row = dt.NewRow();
                    row["结算人"] =Row_Chargename;
                    row["科室名称"] = Row_deptname;

                    //row["出院人数"] = operationList.zyCostmasterList[i].Record_Flag == 0 ? 1 : 0;
                    row["总金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Total_Fee.ToString("0.00"));
                    row["记账金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    row["自付金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    row["优惠金额"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));
                    IsTicketItem_0(row, i);
                    IsVillageItem_0(row, i);
                    IsSelfItem_0(row, i);

                    dt.Rows.Add(row);
                }
                else
                {
                    drs[0]["结算人"] = RetureName(drs[0]["结算人"], Row_Chargename);
                    //drs[0]["出院人数"] = Dbnull(drs[0]["出院人数"]) + (operationList.zyCostmasterList[i].Record_Flag == 0 ? 1 : 0);
                    drs[0]["总金额"] = Dbnull(drs[0]["总金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Total_Fee.ToString("0.00"));
                    drs[0]["记账金额"] = Dbnull(drs[0]["记账金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Village_Fee.ToString("0.00"));
                    drs[0]["自付金额"] = Dbnull(drs[0]["自付金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Self_Fee.ToString("0.00"));
                    drs[0]["优惠金额"] = Dbnull(drs[0]["优惠金额"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Favor_Fee.ToString("0.00"));

                    IsTicketItem_1(drs, i);
                    IsVillageItem_1(drs, i);
                    IsSelfItem_1(drs, i);
                }
            }
            #endregion
        }

        private void CreateDataTableColumn()
        {
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;

            if (IsPatTypeShow)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "结算人";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

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

                //column = new DataColumn();
                //column.DataType = System.Type.GetType("System.String");
                //column.ColumnName = "住院号";
                ////column.ReadOnly = true;
                //dt.Columns.Add(column);

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


                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "发票号";
                //column.ReadOnly = true;
                dt.Columns.Add(column);
            }
            else if (IsPatTypeShow == false && IsDocShow == true)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "结算人";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

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
                column.ColumnName = "结算人";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "科室名称";
                //column.ReadOnly = true;
                dt.Columns.Add(column);
            }
            else if (IsPatTypeShow == false && IsDocShow == false && IsDeptShow == false)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "结算人";
                //column.ReadOnly = true;
                dt.Columns.Add(column);
            }

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "总金额";
            //column.ReadOnly = true;
            dt.Columns.Add(column);

            if (IsTicketItem)
            {
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

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "记账金额";
            //column.ReadOnly = true;
            dt.Columns.Add(column);

            if (IsVillageItem)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = "农合";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = "居民医保";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = "职工医保";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = "自费";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = "单位";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = "其他";
                //column.ReadOnly = true;
                dt.Columns.Add(column);
            }

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "自付金额";
            //column.ReadOnly = true;
            dt.Columns.Add(column);

            if (IsSelfItem)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = "预交金";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = "补收";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = "应退";
                //column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = "欠费";
                //column.ReadOnly = true;
                dt.Columns.Add(column);
            }

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "优惠金额";
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
                    startNum = 6;
                }
                else if (IsPatTypeShow == false && IsDocShow == true)
                {
                    startNum = 3;
                }
                else if (IsPatTypeShow == false && IsDocShow == false && IsDeptShow == true)
                {
                    startNum = 2;
                }
                else if (IsPatTypeShow == false && IsDocShow == false && IsDeptShow == false)
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

        private bool CheckCostMaster(int i)
        {
            bool b = false;
            if (dateType == Date_Type.交款时间)
            {
                //base.GLoadOperationData(Bdate, Edate);
                b = operationList.zyCostmasterList.Exists(
             delegate(ZY_CostMaster x)
             { return x.AccountID == operationList.zyCostmasterList[i].AccountID; }
                );
            }
            else if (dateType == Date_Type.结算时间)
            {
                //base.TLoadOperationData(Bdate, Edate);
                b = true;
            }

            return b;
        }

        private void IsTicketItem_0(DataRow row, int i)
        {
            if (IsTicketItem)
            {
                List<ZY_CostOrder> zyCO = operationList.zyCostorderList.FindAll(
                    delegate(ZY_CostOrder x)
                    {
                        return x.CostID == operationList.zyCostmasterList[i].CostMasterID;
                    }
                    );
                for (int k = 0; k < zyCO.Count; k++)
                {
                    string Col_name = base.GetItemName("BASE_STAT_ZYFP", zyCO[k].BigItemCode.Trim());
                    if (Col_name == "")
                    {
                        Col_name = "未知项目";
                    }

                    row[Col_name] = Dbnull(row[Col_name]) + Convert.ToDecimal(zyCO[k].Total_Fee.ToString("0.00"));
                }
            }
        }

        private void IsVillageItem_0(DataRow row, int i)
        {
            if (IsVillageItem)
            {
                if (operationList.zyCostmasterList[i].PatType == "01")
                {
                    row["自费"] = Convert.ToDecimal(operationList.zyCostmasterList[i].NotWorkUnit_Fee.ToString("0.00"));
                }
                else if (operationList.zyCostmasterList[i].PatType == "02")
                {
                    row["农合"] = Convert.ToDecimal(operationList.zyCostmasterList[i].NotWorkUnit_Fee.ToString("0.00"));
                }
                else if (operationList.zyCostmasterList[i].PatType == "03")
                {
                    row["居民医保"] = Convert.ToDecimal(operationList.zyCostmasterList[i].NotWorkUnit_Fee.ToString("0.00"));
                }
                else if (operationList.zyCostmasterList[i].PatType == "04")
                {
                    row["职工医保"] = Convert.ToDecimal(operationList.zyCostmasterList[i].NotWorkUnit_Fee.ToString("0.00"));
                }
                else if (operationList.zyCostmasterList[i].PatType == "06")
                {
                    row["其他"] = Convert.ToDecimal(operationList.zyCostmasterList[i].NotWorkUnit_Fee.ToString("0.00"));
                }
                row["单位"] = Convert.ToDecimal(operationList.zyCostmasterList[i].WorkUnit_Fee.ToString("0.00"));
            }
        }

        private void IsSelfItem_0(DataRow row, int i)
        {
            if (IsSelfItem)
            {
                row["预交金"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Deptosit_Fee.ToString("0.00"));
                row["补收"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Reality_Fee >= 0 ? operationList.zyCostmasterList[i].Reality_Fee.ToString("0.00") : "0");
                row["应退"] = Convert.ToDecimal(operationList.zyCostmasterList[i].Reality_Fee < 0 ? operationList.zyCostmasterList[i].Reality_Fee.ToString("0.00") : "0");
                row["欠费"] = Convert.ToDecimal((operationList.zyCostmasterList[i].Self_Fee - operationList.zyCostmasterList[i].Deptosit_Fee - operationList.zyCostmasterList[i].Reality_Fee).ToString("0.00"));
            }
        }

        private void IsTicketItem_1(DataRow[] drs, int i)
        {
            if (IsTicketItem)
            {
                List<ZY_CostOrder> zyCO = operationList.zyCostorderList.FindAll(
                    delegate(ZY_CostOrder x)
                    {
                        return x.CostID == operationList.zyCostmasterList[i].CostMasterID;
                    }
                    );
                for (int k = 0; k < zyCO.Count; k++)
                {
                    string Col_name = base.GetItemName("BASE_STAT_ZYFP", zyCO[k].BigItemCode.Trim());
                    if (Col_name == "")
                    {
                        Col_name = "未知项目";
                    }
                    drs[0][Col_name] = Dbnull(drs[0][Col_name]) + Convert.ToDecimal(zyCO[k].Total_Fee.ToString("0.00"));
                }
            }
        }

        private void IsVillageItem_1(DataRow[] drs, int i)
        {
            if (IsVillageItem)
            {
                if (operationList.zyCostmasterList[i].PatType == "01")
                {
                    drs[0]["自费"] = Dbnull(drs[0]["自费"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].NotWorkUnit_Fee.ToString("0.00"));
                }
                else if (operationList.zyCostmasterList[i].PatType == "02")
                {
                    drs[0]["农合"] = Dbnull(drs[0]["农合"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].NotWorkUnit_Fee.ToString("0.00"));
                }
                else if (operationList.zyCostmasterList[i].PatType == "03")
                {
                    drs[0]["居民医保"] = Dbnull(drs[0]["居民医保"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].NotWorkUnit_Fee.ToString("0.00"));
                }
                else if (operationList.zyCostmasterList[i].PatType == "04")
                {
                    drs[0]["职工医保"] = Dbnull(drs[0]["职工医保"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].NotWorkUnit_Fee.ToString("0.00"));
                }
                else if (operationList.zyCostmasterList[i].PatType == "06")
                {
                    drs[0]["其他"] = Dbnull(drs[0]["其他"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].NotWorkUnit_Fee.ToString("0.00"));
                }
                drs[0]["单位"] = Dbnull(drs[0]["单位"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].WorkUnit_Fee.ToString("0.00"));
            }
        }

        private void IsSelfItem_1(DataRow[] drs, int i)
        {
            if (IsSelfItem)
            {
                drs[0]["预交金"] = Dbnull(drs[0]["预交金"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Deptosit_Fee.ToString("0.00"));
                drs[0]["补收"] = Dbnull(drs[0]["补收"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Reality_Fee >= 0 ? operationList.zyCostmasterList[i].Reality_Fee.ToString("0.00") : "0");
                drs[0]["应退"] = Dbnull(drs[0]["应退"]) + Convert.ToDecimal(operationList.zyCostmasterList[i].Reality_Fee < 0 ? operationList.zyCostmasterList[i].Reality_Fee.ToString("0.00") : "0");
                drs[0]["欠费"] = Dbnull(drs[0]["欠费"]) + Convert.ToDecimal((operationList.zyCostmasterList[i].Self_Fee - operationList.zyCostmasterList[i].Deptosit_Fee - operationList.zyCostmasterList[i].Reality_Fee).ToString("0.00"));
            }
        }
    }
}
