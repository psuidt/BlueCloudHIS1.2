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
    public partial class FrmReportShow : GWI.HIS.Windows.Controls.BaseMainForm
    {
        #region 属性
        Paramater _currentParam;
        DataTable reportDat;
        ReportProcess _reportProcess;
        Reportdat _currentReport;
        ParamProcess _Paramprocess;
        List<Paramater> Paramlist;
        List<Paramater> paramlistCopy = new List<Paramater>();
        FrmGetInParaterController controller;
        GridppReport Report;
        DataTable tPrintTable;
        string _currentUser;
        string _currentDeptidname;
        DataTable _currentGroupId;
        private static DataTable Reportparamter;
        private User _user;
        private Deptment _dept;
        #endregion

        public FrmReportShow(User user, Deptment dept,DataTable Groupid )
        {
            _currentUser = user.Name;
            _currentDeptidname = dept.Name;
            _currentGroupId = Groupid;
            _user = user;
            _dept = dept;
            InitializeComponent();
            _reportProcess = new ReportProcess();
           
        }

        private void FrmReportShow_Load(object sender, EventArgs e)
        {
            _currentReport = new Reportdat();
            _currentParam = new Paramater();
            _reportProcess = new ReportProcess();
            _Paramprocess = new ParamProcess();
            loadReportdata();
            Reportparamter = _Paramprocess.Getparalist_all(_currentGroupId);

        }
        /// <summary>
        /// 加载报表信息
        /// </summary>
        private void loadReportdata()
        {
            TvReport.Nodes.Clear();
            ReportShow.loadShowReportdata(TvReport, _currentGroupId);
        }



        private void TvReport_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (TvReport.SelectedNode.Tag.GetType() == typeof(OpReportMaster))
            {
                return;
            }
            _currentReport = (Reportdat)TvReport.SelectedNode.Tag;
            if (_currentReport.REPORT_ID < 0)
                return;
            panel6.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region
            //if (controller == null)
            //{
            //    return;
            //}
            //Report = new GridppReport();

            //Paramlist = controller.GetParaValue();
            //if (Paramlist.Count == 0)
            //    return;
            //string Reportname = _currentReport.NAME.Trim() + ".grf";
            //string filePath = System.Windows.Forms.Application.StartupPath + "\\report\\" + Reportname;


            //    Report.LoadFromFile(filePath);
      

            //foreach (Paramater pp in Paramlist)
            //{
            //    if (pp.PARAMETER_TYPE == "OUT")
            //        continue;
            //    if (pp.PARAMETER_TYPE != "明细")
            //    {
            //        if (pp.objvalueCN != null)
            //            Report.ParameterByName(pp.PARAMETER_CN).AsString = pp.objvalueCN.ToString();
            //        else
            //            Report.ParameterByName(pp.PARAMETER_CN).AsString = pp.objvalue.ToString();
            //    }

            //}

            //Report.ParameterByName("报表名称").AsString = _currentReport.NAME;
            //Report.ParameterByName("打印时间").AsString = System.DateTime.Now.ToString();
            //Report.ParameterByName("当前科室").AsString = _currentDeptidname;
            //Report.ParameterByName("当前人员").AsString = _currentUser;
            //DataTable dataoutPara = _reportProcess.getOutParamter(_currentReport, Paramlist); //获取报表数据

            //if (_currentReport.REMARK != null && _currentReport.REMARK.ToString() == "1") //add by heyan 按统计大类统计报表
            //{
            //    for (int i = 0; i < dataoutPara.Rows.Count; i++)
            //    {
            //        int columndex = 0;
            //        try
            //        {
            //            Report.ParameterByName(dataoutPara.Rows[i][0].ToString()).AsString = dataoutPara.Rows[i][0].ToString();
            //            for (columndex = 1; columndex < dataoutPara.Columns.Count; columndex++)
            //            {
            //                Report.ParameterByName(dataoutPara.Rows[i][0].ToString().Trim() + "_" + columndex).AsString = dataoutPara.Rows[i][columndex].ToString();
            //            }
            //        }
            //        catch
            //        {
            //            Report.AddParameter(dataoutPara.Rows[i][0].ToString(), GRParameterDataType.grptString);
            //            for (columndex = 1; columndex < dataoutPara.Columns.Count; columndex++)
            //            {
            //                Report.AddParameter(dataoutPara.Rows[i][0].ToString().Trim() + "_" + columndex, GRParameterDataType.grptString);
            //            }
            //            Report.SaveToFile(System.Windows.Forms.Application.StartupPath + "\\report\\" + Reportname);
            //        }
            //        Report.ParameterByName(dataoutPara.Rows[i][0].ToString()).AsString = dataoutPara.Rows[i][0].ToString();
            //        for (columndex = 1; columndex < dataoutPara.Columns.Count; columndex++)
            //        {
            //            Report.ParameterByName(dataoutPara.Rows[i][0].ToString().Trim() + "_" + columndex).AsString = dataoutPara.Rows[i][columndex].ToString();
            //        }
            //    }

            //    decimal sum = 0;
            //    for (int i = 0; i < dataoutPara.Rows.Count; i++)
            //    {
            //        sum += Convert.ToDecimal(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dataoutPara.Rows[i][1], "0"));
            //    }
            //    try
            //    {
            //        Report.ParameterByName("合计金额").AsString = sum.ToString();
            //    }
            //    catch
            //    {
            //        Report.AddParameter("合计金额", GRParameterDataType.grptString);
            //        Report.SaveToFile(System.Windows.Forms.Application.StartupPath + "\\report\\" + Reportname);
            //        Report.ParameterByName("合计金额").AsString = sum.ToString();
            //    }

            //}
            //tPrintTable = dataoutPara;
            //Report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(reportPrinter_FetchRecord);



            //Frmtest foo = new Frmtest();
            //foo.AttachReport(Report);
            //foo.TopLevel = false;
            //foo.WindowState = FormWindowState.Maximized;
            //foo.FormBorderStyle = FormBorderStyle.None;
            //panel6.Controls.Add(foo);
            //foo.Dock = DockStyle.Fill;
            //foo.Show();
            #endregion
            if (_currentReport.REPORT_ID <= 0)
            {
                MessageBox.Show("请选择报表", "提示");
                return;
            }
            string Reportname = _currentReport.NAME.Trim() + ".grf";      

            FrmQueryControl query = new FrmQueryControl(_Paramprocess.getPara(_currentReport.REPORT_ID), _user.EmployeeID, _dept.DeptID);
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
            string filePath = System.Windows.Forms.Application.StartupPath + "\\report\\" + Reportname;
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
                            Report.SaveToFile(System.Windows.Forms.Application.StartupPath + "\\report\\" + Reportname);
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
                            Report.SaveToFile(System.Windows.Forms.Application.StartupPath + "\\report\\" + Reportname);
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
                        Report.SaveToFile(System.Windows.Forms.Application.StartupPath + "\\report\\" + Reportname);
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
            panel6.Controls.Add(foo);
            foo.Dock = DockStyle.Fill;
            foo.Show();         
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

        private List<Paramater> getlist(DataTable dbparamter, int reportid)
        {
            List<Paramater> newparalist = new List<Paramater>();
            Paramater onepara = null;
            DataTable para = dbparamter.Clone();
            DataRow[] drs = dbparamter.Select("REPORT_ID="+reportid);
            foreach (DataRow dr in drs)
            {
                
                onepara = new Paramater();
                onepara.PARAMETER = dr["PARAMETER"].ToString(); //d.PARAMETER;
                onepara.PARAMETER_CN = dr["PARAMETER_CN"].ToString();// mode.PARAMETER_CN;
                onepara.PARAMETER_TYPE = dr["PARAMETER_TYPE"].ToString();// mode.PARAMETER_TYPE;
                onepara.PARAMDATATYPE = int.Parse(dr["PARAMDATATYPE"].ToString());//mode.PARAMDATATYPE;
                onepara.REPORT_ID = int.Parse(dr["REPORT_ID"].ToString());// mode.REPORT_ID;
                onepara.ENUMEID = int.Parse(dr["ENUMEID"].ToString());// mode.ENUMEID;
                onepara.PARAMETERID = int.Parse(dr["PARAMETERID"].ToString()); //mode.PARAMETERID;
                onepara.FOREIGNER_FIELD_CN_NAME = dr["FOREIGNER_FIELD_CN_NAME"].ToString();//mode.FOREIGNER_FIELD_CN_NAME;
                onepara.FOREIGNER_FIELD_DB_NAME = dr["FOREIGNER_FIELD_DB_NAME"].ToString();// mode.FOREIGNER_FIELD_DB_NAME;
                onepara.FOREIGNER_TABLE =dr["FOREIGNER_TABLE"].ToString();// mode.FOREIGNER_TABLE;
                onepara.DATALENGTH = int.Parse(dr["DATALENGTH"].ToString()); //mode.DATALENGTH;
                onepara.HEIGHT = int.Parse(dr["HEIGHT"].ToString()); //mode.HEIGHT;
                onepara.UIC_TYPE = int.Parse(dr["UIC_TYPE"].ToString()); //mode.UIC_TYPE;
                onepara.UIC_X_LOCA = int.Parse(dr["UIC_X_LOCA"].ToString()); //mode.UIC_X_LOCA;
                onepara.UIC_Y_LOCA = int.Parse(dr["UIC_Y_LOCA"].ToString()); //mode.UIC_Y_LOCA;
                onepara.WIDTH = int.Parse(dr["WIDTH"].ToString()); //mode.WIDTH;
                onepara.FOREIGNER_FILTER_SQL =dr["FOREIGNER_FILTER_SQL"].ToString();// mode.FOREIGNER_FILTER_SQL;
                newparalist.Add(onepara);
            }
            return newparalist;
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
