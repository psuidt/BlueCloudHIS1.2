using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Report_BLL;
using grproLib;
using HIS_ReportManager.Controller;
using GWMHIS.BussinessLogicLayer.Classes;



namespace HIS_ReportManager
{
    public partial class FrmReport : GWI.HIS.Windows.Controls.BaseMainForm
    {
        #region 属性
        Paramater _currentParam;      
        ReportProcess _reportProcess;
        Reportdat _currentReport;
        ParamProcess _Paramprocess;
        List<Paramater> Paramlist;
        List<Paramater> paramlistCopy = new List<Paramater>();
        GridppReport Report ; 
        DataTable tPrintTable;
        string _currentUser;
        string _currentDeptidname;
        DataTable _procedureParams;       
        
       private  User _user;
        private Deptment _dept;

        #endregion 

        //初始化
        public FrmReport(string  user,string deptname)
        {
            _currentUser = user;
            _currentDeptidname = deptname;
            InitializeComponent();
            _reportProcess = new ReportProcess();

        }
        //初始化
        public FrmReport( User user, Deptment dept)
        {
            _user = user;
            _dept = dept;
            _currentDeptidname = dept.Name;
            InitializeComponent();
            _reportProcess = new ReportProcess();

        }
        
        /// <summary>
        /// 加载报表树
        /// </summary>
        private void loadReportdata()
        {
            dgvInParam.DataSource = null;
            TvReport.Nodes.Clear();        
            ReportShow.loadReportdata(TvReport);
           // TvReport.ExpandAll();
        }      
      
        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmReport_Load(object sender, EventArgs e)
        {
            _currentReport = new Reportdat();
            _currentParam = new Paramater();
            _reportProcess = new ReportProcess();
            _Paramprocess = new ParamProcess();
            loadReportdata();    
           
        }    
        /// <summary>
        /// 选择报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TvReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TvReport.SelectedNode.Tag.GetType() == typeof(OpReportMaster))
            {                
                return;
            }
            //TvReport.ExpandAll();
            _currentReport = (Reportdat)TvReport.SelectedNode.Tag;
            if (_currentReport.REPORT_ID < 0)
                return;
            Proceduers opprodedure = new Proceduers();
            dgvInParam.DataSource = null;
            panel12.Controls.Clear();
            _procedureParams = opprodedure.GetProcedureParameters(_currentReport.PROCEDURES.Trim());
            LoadParam();

           
        }
        private void LoadParam()
        {
            if (_currentReport.REPORT_ID >= 0)
            {
                dgvInParam.DataSource = null;
                DataTable Param = _Paramprocess.getParamlist(_currentReport.REPORT_ID);
                dgvInParam.AutoGenerateColumns = false;
                dgvInParam.DataSource = Param;
                this.txtReportName.Text = _currentReport.NAME;
                this.txtProcess.Text = _currentReport.PROCEDURES;              
 
            }
 
        }

        private void dgvInParam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _currentParam = new Paramater();
            _currentParam = (Paramater)dgvInParam.CurrentRow.Tag;
        }

        private void dgvInParam_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnDelParam.Enabled = true;
            this.btnDelParam.Enabled = true;
            //this.btnUpdate.Enabled = true;
            //this.btnNewParam.Enabled = true;
            _currentParam = new Paramater(); int row= dgvInParam.CurrentRow.Index;
            _currentParam.PARAMETERID = int.Parse(dgvInParam["参数ID", row].Value.ToString());
            _currentParam.PARAMETER = dgvInParam["参数名", row].Value.ToString();
            _currentParam.DATALENGTH = int.Parse(dgvInParam["大小", row].Value.ToString());
            _currentParam.PARAMETER_TYPE =dgvInParam["Direction", row].Value.ToString();
            _currentParam.PARAMDATATYPE = int.Parse(dgvInParam["数据类型", row].Value.ToString());
            _currentParam.PARAMETER_CN = dgvInParam["参数别名", row].Value.ToString();
            _currentParam.REPORT_ID = int.Parse(dgvInParam["REPORT_ID", row].Value.ToString());
            _currentParam.UIC_TYPE = int.Parse(dgvInParam["控件类型", row].Value.ToString());
            _currentParam.FOREIGNER_FIELD_CN_NAME = dgvInParam["FOREIGNER_FIELD_CN_NAME", row].Value.ToString();
            _currentParam.FOREIGNER_FIELD_DB_NAME = dgvInParam["FOREIGNER_FIELD_DB_NAME", row].Value.ToString();
            _currentParam.FOREIGNER_FILTER_SQL = dgvInParam["FOREIGNER_FILTER_SQL", row].Value.ToString();
            _currentParam.ENUMEID =int.Parse( dgvInParam["ENUMEID", row].Value.ToString());
            //this.txtParaName.Text = _currentParam.PARAMETER;
            //this.txtParamLength.Text = _currentParam.DATALENGTH.ToString();
            //this.txtParamter_cn.Text = _currentParam.PARAMETER_CN;
            //this.cmbParamterType.SelectedIndex = _currentParam.PARAMDATATYPE;
            //this.cmbInOut.SelectedIndex = 0;
        }

        private void btnInParamManage_Click(object sender, EventArgs e)
        {
            FrmVindicatorConfig frm = new FrmVindicatorConfig(_currentReport.REPORT_ID);
            frm.ShowDialog();
        }

        private void btnGetReportParam_Click(object sender, EventArgs e)
        {
            DataTable dataoutPara;
            Paramater outpara;
            if(_currentReport!=null&&_currentReport.PROCEDURES!="")
            {              

                FrmGetInParater frmGetpara = new FrmGetInParater(_Paramprocess.getPara(_currentReport.REPORT_ID),_user,_dept);

                if (frmGetpara.ShowDialog() == DialogResult.OK)
                {
                    Paramlist = frmGetpara.paralist;
                }
                else
                    return;

               dataoutPara= _reportProcess.getOutParamter(_currentReport, Paramlist);
               if (dataoutPara != null)
               {
                   for (int index = 0; index < dataoutPara.Columns.Count; index++)
                   {
                       outpara = new Paramater();
                       outpara.PARAMETER = dataoutPara.Columns[index].ColumnName;
                       outpara.PARAMETER_TYPE = "";
                       if (dataoutPara.Columns[index].DataType.Name == "String")
                           outpara.PARAMDATATYPE = 0;
                       else
                           outpara.PARAMDATATYPE = 1;
                       outpara.REPORT_ID = _currentReport.REPORT_ID;
                       outpara.addParamter();
                   }
               }

            }
        }     

       
         /// <summary>
         /// 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (_currentReport.REPORT_ID <= 0)
            {
                MessageBox.Show("请选择报表", "提示");
                return;
            }
            string Reportname = _currentReport.NAME.Trim() + ".grf";
            if (!System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\report\\newreport\\" + Reportname))
            {
                Report = new GridppReport();
                Paramlist = _Paramprocess.getParaX(_currentReport.REPORT_ID);
                if (Paramlist == null)
                    return;
                Report.InsertReportHeader();
                Report.InsertDetailGrid();
                Report.InsertReportFooter();
                Report.DetailGrid.IsCrossTab = true;

                IGRRecordset RecordSet = Report.DetailGrid.Recordset;
                foreach (Paramater pp in Paramlist)
                {
                    if (pp.PARAMETER_TYPE == "表头表尾" || pp.PARAMETER_TYPE == "IN")
                        Report.AddParameter(pp.PARAMETER_CN, GRParameterDataType.grptString);
                    else if (pp.PARAMETER_TYPE == "明细")
                    {
                        if (pp.PARAMDATATYPE == 1)
                            RecordSet.AddField(pp.PARAMETER, GRFieldType.grftFloat);
                        else
                            RecordSet.AddField(pp.PARAMETER, GRFieldType.grftString);

                    }
                    else
                        continue;
                }
                Report.AddParameter("报表名称", GRParameterDataType.grptString);
                Report.AddParameter("打印时间", GRParameterDataType.grptString);
                Report.AddParameter("当前科室", GRParameterDataType.grptString);
                Report.AddParameter("当前人员", GRParameterDataType.grptString);               
                Report.DetailGrid.IsCrossTab = false;
                Report.SaveToFile(System.Windows.Forms.Application.StartupPath + "\\report\\newreport\\" + Reportname);
            }          

            FrmQueryControl query = new FrmQueryControl(_Paramprocess.getPara(_currentReport.REPORT_ID),_user.EmployeeID,_dept.DeptID);
            if (paramlistCopy != null && paramlistCopy.Count > 0)
            {
                query.setParamValue(paramlistCopy);
            }      
            query.ShowDialog();                
            if (!query.isok)
            {
                return;
            }
            Report = new GridppReport();
            Paramlist = query.GetParaValue();
            paramlistCopy = Paramlist;
            string filePath = System.Windows.Forms.Application.StartupPath + "\\report\\newreport\\" + Reportname;
            Report.LoadFromFile(filePath);
            foreach (Paramater pp in Paramlist)
            {
                if (pp.PARAMETER_TYPE == "OUT")
                    continue;
                if (pp.PARAMETER_TYPE != "明细")
                {
                    if (pp.objvalueCN != null)
                    {
                        try
                        {
                            Report.ParameterByName(pp.PARAMETER_CN).AsString = pp.objvalueCN.ToString();
                        }
                        catch
                        {
                            Report.AddParameter(pp.PARAMETER_CN, GRParameterDataType.grptString);
                            Report.SaveToFile(System.Windows.Forms.Application.StartupPath + "\\report\\newreport\\" + Reportname);
                        }
                        finally
                        {
                            Report.ParameterByName(pp.PARAMETER_CN).AsString = pp.objvalueCN.ToString();
                        }
                    }
                    else
                    {
                        try
                        {
                            Report.ParameterByName(pp.PARAMETER_CN).AsString = pp.objvalue.ToString();
                        }
                        catch
                        {
                            Report.AddParameter(pp.PARAMETER_CN, GRParameterDataType.grptString);
                            Report.SaveToFile(System.Windows.Forms.Application.StartupPath + "\\report\\newreport\\" + Reportname);
                        }
                        finally
                        {
                            Report.ParameterByName(pp.PARAMETER_CN).AsString = pp.objvalue.ToString();
                        }
                    }
                }

            }

            Report.ParameterByName("报表名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + _currentReport.NAME;
            Report.ParameterByName("打印时间").AsString = System.DateTime.Now.ToString();
            Report.ParameterByName("当前科室").AsString = _currentDeptidname;
            Report.ParameterByName("当前人员").AsString = _user.Name;
            DataTable dataoutPara = _reportProcess.getOutParamter(_currentReport, Paramlist); //获取报表数据          
            if (_currentReport.REMARK != null && _currentReport.REMARK.ToString() == "1") //add by heyan 按统计大类统计报表
            {
                for (int i = 0; i < dataoutPara.Rows.Count; i++)
                {
                    int columndex = 0;
                    try
                    {
                        Report.ParameterByName(dataoutPara.Rows[i][0].ToString()).AsString = dataoutPara.Rows[i][0].ToString();
                        for (columndex = 1; columndex < dataoutPara.Columns.Count; columndex++)
                        {
                            Report.ParameterByName(dataoutPara.Rows[i][0].ToString().Trim() + "_" + columndex).AsString = dataoutPara.Rows[i][columndex].ToString();
                        }
                    }
                    catch
                    {
                        Report.AddParameter(dataoutPara.Rows[i][0].ToString(), GRParameterDataType.grptString);
                        for (columndex = 1; columndex < dataoutPara.Columns.Count; columndex++)
                        {
                            Report.AddParameter(dataoutPara.Rows[i][0].ToString().Trim() + "_" + columndex, GRParameterDataType.grptString);
                        }
                        Report.SaveToFile(System.Windows.Forms.Application.StartupPath + "\\report\\newreport\\" + Reportname);
                    }
                    Report.ParameterByName(dataoutPara.Rows[i][0].ToString()).AsString = dataoutPara.Rows[i][0].ToString();
                    for (columndex = 1; columndex < dataoutPara.Columns.Count; columndex++)
                    {
                        Report.ParameterByName(dataoutPara.Rows[i][0].ToString().Trim() + "_" + columndex).AsString = dataoutPara.Rows[i][columndex].ToString();
                    }

                }

                decimal sum = 0;
                for (int i = 0; i < dataoutPara.Rows.Count; i++)
                {
                    sum += Convert.ToDecimal(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dataoutPara.Rows[i][1], "0"));
                }
                try
                {
                    Report.ParameterByName("合计金额").AsString = sum.ToString();
                }
                catch
                {
                    Report.AddParameter("合计金额", GRParameterDataType.grptString);
                    Report.SaveToFile(System.Windows.Forms.Application.StartupPath + "\\report\\newreport\\" + Reportname);
                    Report.ParameterByName("合计金额").AsString = sum.ToString();
                }

            }

            else
            {

                try
                {
                    if (Report.DetailGrid.Recordset.Fields.Count == 0)
                    {
                        for (int i = 0; i < dataoutPara.Columns.Count; i++)
                        {
                            Report.DetailGrid.AddColumn(dataoutPara.Columns[i].ColumnName, dataoutPara.Columns[i].ColumnName, dataoutPara.Columns[i].ColumnName, 2);
                            Report.DetailGrid.Recordset.AddField(dataoutPara.Columns[i].ColumnName, GRFieldType.grftString);
                        }
                        Report.SaveToFile(System.Windows.Forms.Application.StartupPath + "\\report\\newreport\\" + Reportname);
                    }
                }
                catch
                { }

            }
            tPrintTable = dataoutPara;
            Report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(reportPrinter_FetchRecord);


            Frmtest foo = new Frmtest();
            foo.AttachReport(Report);
            foo.TopLevel = false;
            foo.WindowState = FormWindowState.Maximized;
            foo.FormBorderStyle = FormBorderStyle.None;
            panel12.Controls.Add(foo);
            foo.Dock = DockStyle.Fill;
            foo.Show();         
        }

        // 将 DataTable 的数据转储到 Grid++Report 的数据集中
        private static void FillRecordToReport(IGridppReport Report, DataTable dt)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dt.Columns.Count; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }


            // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
            foreach (DataRow dr in dt.Rows)
            {
                Report.DetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
                }

                Report.DetailGrid.Recordset.Post();
            }
        }

        private void reportPrinter_FetchRecord(ref bool pEof)
        {
            GWI_DesReport.HisReport.FillRecordToReport(Report, tPrintTable);          
        }

        private void btnPringtview_Click(object sender, EventArgs e)
        {
            if (Report == null)
                return;
            Report.PrintPreview(true);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (Report==null)
            {
                return;
            }
            ReportToExcel(tPrintTable);
        }
        /// <summary>
        /// 输出Excel
        /// </summary>
        /// <param name="Report"></param>
        public void ReportToExcel(DataTable tPrintTable)
        {

            try
            {
                int totalColumn = tPrintTable.Columns.Count;

                Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();

                excel.Application.Workbooks.Add(true);

                #region 填充数据
                excel.Cells[1, 1] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + _currentReport.NAME;
                Microsoft.Office.Interop.Excel.Range titleStartcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1];
                Microsoft.Office.Interop.Excel.Range titleEndcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, totalColumn];
                excel.get_Range(titleStartcell, titleEndcell).Merge(0);
                excel.get_Range(titleStartcell, titleEndcell).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                excel.get_Range(titleStartcell, titleEndcell).Font.Name = "宋体";
                excel.get_Range(titleStartcell, titleEndcell).Font.Size = 15;
                excel.get_Range(titleStartcell, titleEndcell).Font.Bold = true;

                //excel.Cells[2, 1] = "统计时间：";
                //excel.Cells[2, 2] = bdate.ToString("yyyy-MM-dd HH:mm:ss") + " -- " + edate.ToString("yyyy-MM-dd HH:mm:ss");
                //excel.get_Range((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 2], (Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 6]).Merge(0);

                //excel.Cells[2, totalColumn - 2] = "制表人：";
                //excel.Cells[2, totalColumn - 1] = _user.Name;

                int row = 3;
                Microsoft.Office.Interop.Excel.Range startCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row, 1];
                Microsoft.Office.Interop.Excel.Range endCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row + tPrintTable.Rows.Count, totalColumn];

                for (int i = 0; i < tPrintTable.Columns.Count; i++)
                    excel.Cells[row, i + 1] = tPrintTable.Columns[i].ColumnName.ToString();
                row = row + 1;
                for (int i = 0; i < tPrintTable.Rows.Count; i++)
                {

                    for (int j = 0; j < tPrintTable.Columns.Count; j++)
                    {
                        object objValue = tPrintTable.Rows[i][tPrintTable.Columns[j].ColumnName];
                        if (Convert.IsDBNull(objValue))
                            continue;
                        excel.Cells[row + i, j + 1] = objValue.ToString();
                    }
                }
                #endregion

                #region 画网格线
                object obj = excel.get_Range(startCell, endCell).Select();

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                row = row + tPrintTable.Rows.Count + 1;
                excel.Cells[row, 1] = "审核人";
                excel.Cells[row, totalColumn - 2] = "打印日期：";
                excel.Cells[row, totalColumn] = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString("yyyy-MM-dd");

                #endregion

                excel.ActiveWindow.DisplayGridlines = false;
                excel.Visible = true;

            }
            catch
            {
                MessageBox.Show("输出到Excel发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GC.Collect();
            }
        } 

        private void TvReport_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = TvReport.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点...
                {
                    this.TvReport.SelectedNode = CurrentNode;
                }
            }
          
        }

        /// <summary>
        /// 新增报表类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAddType_Click(object sender, EventArgs e)
        {
            if (TvReport.SelectedNode.Tag!= null)
            {
                if (TvReport.SelectedNode.Tag.GetType()==typeof(Reportdat))
                {
                    MessageBox.Show("报表下边不能添加类型");
                    return;
                }               
                FrmAddReportType frmtype = new FrmAddReportType();
                frmtype.ShowDialog();
                if (frmtype.reportTypeName != "")
                {
                    HIS.Report_BLL.OpReportMaster _master = (OpReportMaster)TvReport.SelectedNode.Tag;
                    _master.NAME = frmtype.reportTypeName;
                    _master.P_ID = _master.REPORTMASTER_ID;
                    _master.REPORT_TYPE = 0;
                    _master.Add();
                    loadReportdata();
                }
            }
           
        }

        /// <summary>
        /// 新增报表 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAddReport_Click(object sender, EventArgs e)
        {
            if (TvReport.SelectedNode.Tag != null)
            {           
                if (TvReport.SelectedNode.Tag.GetType() == typeof(Reportdat))
                {
                    MessageBox.Show("报表下边不能添加报表");
                    return;
                }
                HIS.Report_BLL.OpReportMaster _master = (OpReportMaster)TvReport.SelectedNode.Tag;
                if (_master.REPORTMASTER_ID == -1)
                {
                    MessageBox.Show("不能直接在根结点下增加报表,请先增加类型");
                    return;
                }
                FrmAddReport report = new FrmAddReport(_master.REPORTMASTER_ID);
                report.ShowDialog();
                if (report.ReportName!="" && report.ProcessName!="")
                { 
                    _currentReport = new Reportdat();
                    _currentReport.NAME = report.ReportName;
                    _currentReport.PROCEDURES = report.ProcessName;
                    _currentReport.REMARK = report.Remark;
                    _currentReport.REPORTMASTER_ID = _master.REPORTMASTER_ID;
                    _currentReport.addReport();
                    loadReportdata();
                }
            }

        }

        /// <summary>
        /// 修改报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuUpdate_Click(object sender, EventArgs e)
        {
            if (TvReport.SelectedNode.Tag != null)
            {
                if (TvReport.SelectedNode.Tag.GetType() == typeof(OpReportMaster))
                {
                    OpReportMaster _master = (OpReportMaster)TvReport.SelectedNode.Tag;
                    if (_master.REPORTMASTER_ID == -1)
                    {
                        return;
                    }
                    FrmAddReportType frmtype = new FrmAddReportType();
                    frmtype.Text = "修改类型名";
                    frmtype.reportTypeName = _master.NAME;
                    frmtype.ShowDialog();
                    if (frmtype.reportTypeName != "")
                    {

                        _master.NAME = frmtype.reportTypeName;
                        _master.Update();
                        loadReportdata();
                    }
                }
                else
                {
                    Reportdat _report = (Reportdat)TvReport.SelectedNode.Tag;
                    FrmAddReport frmreport = new FrmAddReport(_report.REPORTMASTER_ID);
                    frmreport.Text = "修改报表";
                    frmreport.ReportName = _report.NAME;
                    frmreport.ProcessName = _report.PROCEDURES;
                    frmreport.Remark = _report.REMARK;
                    frmreport.ShowDialog();
                    if (frmreport.ReportName != "" && frmreport.ProcessName != "")
                    {
                        if (_report.NAME.Trim() != frmreport.ReportName.Trim())
                        {
                            string filepath = System.Windows.Forms.Application.StartupPath + "\\report\\newreport\\";
                            if (System.IO.File.Exists(filepath + _report.NAME.Trim() + ".grf"))
                            {
                                try
                                {
                                    System.IO.File.Copy(filepath + _report.NAME.Trim() + ".grf", filepath + frmreport.ReportName.Trim() + ".grf", true);
                                    System.IO.File.Delete(filepath + _report.NAME.Trim() + ".grf");
                                }
                                catch
                                {
                                    MessageBox.Show("请先关闭文件再修改文件名!");
                                    return;
                                }
                            }
                        }
                        _report.NAME = frmreport.ReportName;
                        _report.PROCEDURES = frmreport.ProcessName;
                        _report.REMARK = frmreport.Remark;
                        _report.update();
                        loadReportdata();
                    }
                }
            }
        }
        /// <summary>
        /// 删除报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuDelete_Click(object sender, EventArgs e)
        {
            if (TvReport.SelectedNode.Tag != null)
            {
                if (TvReport.SelectedNode.Tag.GetType() == typeof(OpReportMaster))
                {
                    OpReportMaster _master = (OpReportMaster)TvReport.SelectedNode.Tag;
                    if (_master.REPORTMASTER_ID == -1)
                    {
                        return;
                    }
                    if (_master.IsHasChildReport())
                    {
                        MessageBox.Show("要先删除类型下的报表");
                        return;
                    }
                    else
                        _master.Delete();
                }
                else
                {
                    Reportdat _report = (Reportdat)TvReport.SelectedNode.Tag;
                    _report.Delete();
                }               
                MessageBox.Show("删除成功");
                loadReportdata();
            }
        }

        //参数操作
        private void btnDelParam_Click(object sender, EventArgs e)
        {
            if (_currentParam != null)
            {
                if (MessageBox.Show("确定要删除当前参数吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    _Paramprocess.delParamter(_currentParam.PARAMETERID);
                LoadParam();
            }
        }
        
        //新增参数
        private void btnAddParam_Click(object sender, EventArgs e)
        {
            if (_procedureParams != null && _procedureParams.Rows.Count > 0)
            {
                FrmAddParameter frmadd = new FrmAddParameter(_procedureParams);
                frmadd.isAdd = true;
                frmadd.ShowDialog();
                LoadParam();
            }

        }
        //初始化参数
        private void btnInitialize_Click(object sender, EventArgs e)
        {
            if (_currentReport != null)
            {
                if (MessageBox.Show("参数初始化会把之前的参数清除，重新加载此存储过程的参数，确定要初始化吗？", "询问", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Paramater paramter = new Paramater();
                    paramter.REPORT_ID = _currentReport.REPORT_ID;
                    paramter.InitializeParamToReport(_currentReport.PROCEDURES);
                    LoadParam();
                }
            }
        }
        //删除参数
        private void button4_Click(object sender, EventArgs e)
        {
            if (_currentParam != null)
            {
                _currentParam.REPORT_ID = _currentReport.REPORT_ID;
                FrmAddParameter frmadd = new FrmAddParameter(_currentParam);
                frmadd.isAdd = false;
                frmadd.ShowDialog();
                LoadParam();
            }
        }

        private void btnQueryOldSource_Click(object sender, EventArgs e)
        {
            if (Paramlist == null)
            {
                return;
            }
            DataTable dataoutPara = _reportProcess.getOutParamter(_currentReport, Paramlist); //获取报表数据    
            FrmOldSource olddata = new FrmOldSource(dataoutPara);
            olddata.ShowDialog();

        }

        private void btnReportDesign_Click(object sender, EventArgs e)
        {
            try
            {
                string RptName = _currentReport.NAME.Trim();
                string RptPath = System.Windows.Forms.Application.StartupPath + "\\report\\newreport\\" ;
                HIS_BaseManager.FrmReportManager fm = new HIS_BaseManager.FrmReportManager(RptName, RptPath);
                fm.Show();             
            }
            catch { }
        }

        private void TvReport_DragDrop(object sender, DragEventArgs e)
        {
            //取源节点信息 获得进行"Drag"操作中拖动的字符串
            TreeNode sourceNode = this.TvReport.SelectedNode;
            Reportdat _report = (Reportdat) sourceNode.Tag;

            Point m_Position = new Point();
            m_Position.X = e.X;
            m_Position.Y = e.Y;
            m_Position = TvReport.PointToClient(m_Position);
            TreeNode CurrentNode = this.TvReport.GetNodeAt(m_Position);              
            if (CurrentNode != null)//判断你点的是不是一个节点...
            {

                if (CurrentNode.Tag.GetType() == typeof(OpReportMaster) && ((OpReportMaster)CurrentNode.Tag).REPORTMASTER_ID != -1)
                {
                    _report.REPORTMASTER_ID = ((OpReportMaster)CurrentNode.Tag).REPORTMASTER_ID;
                }
                else
                {
                    _report.REPORTMASTER_ID = ((Reportdat)CurrentNode.Tag).REPORTMASTER_ID;
                }
                _report.update();
                loadReportdata();
            }        
            
        }

        private void TvReport_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (TvReport.SelectedNode!=null && TvReport.SelectedNode.Tag != null)
            {
                if (TvReport.SelectedNode.Tag.GetType() == typeof(OpReportMaster))
                {
                    return;
                }
                Reportdat _report = (Reportdat)TvReport.SelectedNode.Tag;           
                DoDragDrop(_report, DragDropEffects.Move);                
            }
           
        }

        private void TvReport_DragEnter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Move;

        }

        private void TvReport_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
           // for (int i = 0; i < TvReport.Nodes.Count; i++)
           // {
           //     TvReport.Nodes[i].ImageIndex = 15;
           //     if (TvReport.Nodes[i].GetType() == typeof(OpReportMaster) )
           //     {
           //         SearchSubNode(TvReport.Nodes[i]);
           //     }
           // }
          
           //TvReport.SelectedNode = e.Node;
        }

        private void SearchSubNode(TreeNode node)
        {
            foreach (TreeNode nd in node.Nodes)
            {
                if (nd.Tag.GetType() == typeof(OpReportMaster))
                {
                    nd.ImageIndex = 15;
                    SearchSubNode(nd);
                }
                else
                {
                    nd.ImageIndex = 14;
                }
            }
        }

        bool isExpand = false;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!isExpand)
            {
                TvReport.ExpandAll();
                isExpand = true;
                linkLabel1.Text = "折叠所有报表";
            }
            else
            {
                TvReport.CollapseAll();
                isExpand = false;
                linkLabel1.Text = "展开所有报表";
            }
        }

  
    }
}
