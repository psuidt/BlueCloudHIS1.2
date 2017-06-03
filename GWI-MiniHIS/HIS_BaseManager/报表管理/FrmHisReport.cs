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
using grproLib;

namespace HIS_BaseManager
{
    public partial class FrmHisReport : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;
        private Deptment _currentDept;

        public FrmHisReport(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            
            this.Text = chineseName;
            LoadReports();
        }

        private void LoadReports()
        {
            this.dataGridView1.DataSource = HIS.Base_BLL.BaseDataReader.HIS_Report;
            
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmNewReport frmnr = new FrmNewReport(_currentUser.EmployeeID.ToString(),_currentUser.Name);
            frmnr.ShowDialog();
            LoadReports();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                int Rptid = Convert.ToInt32(((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportID"]);
                string RptName = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportName"].ToString();
                string RptPath = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportPath"].ToString();
                FrmNewReport frmnr = new FrmNewReport(_currentUser.EmployeeID.ToString(), _currentUser.Name, Rptid, RptName, RptPath);
                frmnr.ShowDialog();
                LoadReports();
            }
            catch { }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string RptName = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportName"].ToString();
                string RptPath = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportPath"].ToString();

                FrmReportManager fm = new FrmReportManager(RptName, RptPath);
                fm.ShowDialog();
                //LoadReports();
            }
            catch { }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            DeleteReport();
            LoadReports();
        }

        private void DeleteReport()
        {
            
            try
            {
                int Rptid = Convert.ToInt32(((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportID"]);
                HIS.Base_BLL.HIS_ReportManger.DeleteReport( Rptid );
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string RptName = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportName"].ToString();
                string RptPath = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportPath"].ToString();
                //定义Grid++Report报表主对象
                GridppReport Report = new GridppReport();
                //载入报表模板数据
                Report.LoadFromFile(RptPath + RptName + ".grf");
                Report.PrintPreview(true);
            }
            catch { }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            toolStripButton2_Click(null, null);
        }
    }
}
