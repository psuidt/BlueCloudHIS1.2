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
    public partial class FrmAddReportType : GWI.HIS.Windows.Controls.BaseForm
    {
        public string reportTypeName
        {
            get
            {
                return txtTypeName.Text.Trim();
            }
            set
            {
                txtTypeName.Text = value;
            }
        }
        public FrmAddReportType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTypeName.Text.Trim() == "")
            {
                MessageBox.Show("报表类型名不能为空！");
                txtTypeName.Focus();
                return;
            }
            reportTypeName = txtTypeName.Text.Trim();
            HIS.Report_BLL.OpReportMaster _master = new HIS.Report_BLL.OpReportMaster();
            _master.NAME = reportTypeName;
            if (this.Text.Trim() != "修改类型名" && _master.IsExsistReportMaster())
            {
                MessageBox.Show("该类型名已存在，请重新输入");
                txtTypeName.Focus();
                return;
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reportTypeName = "";
            this.Close();
        }

        private void txtTypeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

    }
}
