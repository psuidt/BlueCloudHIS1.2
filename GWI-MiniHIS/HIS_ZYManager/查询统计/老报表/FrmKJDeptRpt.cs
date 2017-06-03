using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using _HIS = HIS.SYSTEM.PubicBaseClasses;
using grproLib;
using System.IO;

namespace HIS_ZYManager
{
    public partial class FrmKJDeptRpt : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;
        private Deptment _currentDept;
         
        grproLib.GridppReport Report = null;

        public FrmKJDeptRpt(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDeptRpt_Load(object sender, EventArgs e)
        {
             
        }

        private void BindData()
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 创建报表文件
        /// </summary>
        /// <param name="ReportName">报表名</param>
        /// <param name="Columns">列信息</param>
        /// <returns></returns>
        private bool CreateReportFile(string ReportName, DataTable Columns)
        {
            try
            {
                GridppReport gridReport = new GridppReport();
                DataTable dtColumns = Columns;
                string reportName = ReportName;
                string fileName = System.Windows.Forms.Application.StartupPath + "\\report\\" + reportName + ".grf";
                if (System.IO.File.Exists(fileName))
                {
                    if (MessageBox.Show("该报表已经存在是否重新设置？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        System.IO.File.Delete(fileName);
                    }
                    else
                    {
                        return false;
                    }
                }
                if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\report"))
                {
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\report");
                }
                if (!File.Exists(fileName))
                {
                    gridReport.SaveToFile(fileName);
                    gridReport.InsertReportHeader();
                    gridReport.InsertDetailGrid();
                    gridReport.InsertReportFooter();
                    foreach (DataColumn dc in dtColumns.Columns)
                    {
                        string title_name = dc.ColumnName;
                        gridReport.DetailGrid.AddColumn(title_name, title_name, title_name, 2);
                        gridReport.DetailGrid.Recordset.AddField(title_name, GRFieldType.grftString);
                    }
                    gridReport.AddParameter("医院名称", GRParameterDataType.grptString);
                    gridReport.AddParameter("报表标题", GRParameterDataType.grptString);
                    gridReport.AddParameter("统计时间", GRParameterDataType.grptString);
                    gridReport.AddParameter("制表人", GRParameterDataType.grptString);
                    gridReport.AddParameter("备注", GRParameterDataType.grptString);

                    gridReport.SaveToFile(fileName);

                }
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
        private void Report_FetchRecord(ref bool Eof)
        {
 
        }
        private void Print(bool IsPrint, string ReportName)
        {
            Report = new grproLib.GridppReport();
            Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\" + ReportName + ".grf");  
            Report.ParameterByName("制表人").AsString = _currentUser.Name;
            Report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
            Report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(Report_FetchRecord);
            if (IsPrint)
            {
                Report.Print(false);
            }
            else
            {
                Report.PrintPreview(false);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
             
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
        }
 
    }
}
