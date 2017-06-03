using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ReportManager
{
    public partial class FrmAddReport : GWI.HIS.Windows.Controls.BaseForm
    {
        #region 属性
        
        public string ReportName
        {
            get 
            {
                return txtRepotName.Text.Trim();
            }
            set 
            {
                this.txtRepotName.Text = value; 
            }
        }
        public string ProcessName
        {
            get 
            { 
                return this.txtProcessName.Text.Trim();
            }
            set
            {
                this.txtProcessName.Text = value;
            }
        }
        public string Remark
        {
            get 
            {
                //return this.txtRmark1.Text.Trim();
                return this.txtRmark.SelectedIndex.ToString(); //update by heyan
            }
            set
            {
                this.txtRmark.SelectedIndex =Convert.ToInt32(value);
            }
        }
        int masterreportid;

        #endregion
        public FrmAddReport(int _masterreportid)
        {
            InitializeComponent();
            this.txtRmark.SelectedIndex = 0;
            masterreportid = _masterreportid;
            HIS.Report_BLL.Proceduers procedures = new HIS.Report_BLL.Proceduers();
            txtProcessName.DataSource = procedures.GetProcedureNames();
            txtProcessName.DisplayMember = "routinename";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ReportName == "" || ProcessName == "")
            {
                MessageBox.Show("报表名称和存储过程名不能为空");
                return;
            }
            HIS.Report_BLL.Reportdat _report = new HIS.Report_BLL.Reportdat();
            _report.NAME = ReportName;
            _report.PROCEDURES = ProcessName;
            _report.REPORTMASTER_ID = masterreportid;
            if (this.Text.Trim()!="修改报表" && _report.IsExsistReport())
            {
                MessageBox.Show("该报表已存在，请重新输入");
                return;
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportName = "";
            ProcessName = "";
            this.Close();
        }

    }
}
