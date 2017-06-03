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
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;
using HIS.SYSTEM.Core;
using Entity = HIS.Model;
using grproLib;

namespace GWI_DesReport
{
    public partial class FrmHisReport : BaseForm
    {
        private User _currentUser;
        private Deptment _currentDept;

        public FrmHisReport(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            
            this.Text = chineseName;
            this.dataGridView1.DataSource = HisReport.LoadReports();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.toolStripButton2_Click(null, null);
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new FrmNewReport(this._currentUser.EmployeeID.ToString(), this._currentUser.Name).ShowDialog();
            this.dataGridView1.DataSource = HisReport.LoadReports();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string str = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportName"].ToString();
                string str2 = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportPath"].ToString();
                new FrmMain(str, str2).ShowDialog();
            }
            catch
            {
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string str = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportName"].ToString();
                string str2 = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportPath"].ToString();
                GridppReport report = new GridppReportClass();
                report.LoadFromFile(str2 + str + ".grf");
                report.PrintPreview(true);
            }
            catch
            {
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                int rptid = Convert.ToInt32(((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportID"]);
                string rptName = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportName"].ToString();
                string rptPath = ((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportPath"].ToString();
                new FrmNewReport(this._currentUser.EmployeeID.ToString(), this._currentUser.Name, rptid, rptName, rptPath).ShowDialog();
                this.dataGridView1.DataSource = HisReport.LoadReports();
            }
            catch
            {
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = HisReport.LoadReports();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if ((this.dataGridView1.DataSource != null) && (MessageBox.Show("确定要删除该报表码？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK))
            {
                HisReport.DeleteReport(((DataTable)this.dataGridView1.DataSource).DefaultView.ToTable().Rows[this.dataGridView1.CurrentCell.RowIndex]["ReportPath"].ToString());
                this.dataGridView1.DataSource = HisReport.LoadReports();
            }
        }

    }
}
