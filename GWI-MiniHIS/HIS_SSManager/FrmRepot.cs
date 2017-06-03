using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_SSManager
{
    public partial class FrmRepot : GWI.HIS.Windows.Controls.BaseMainForm
    {
        int deptid;
        public FrmRepot(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            deptid = Convert.ToInt32(currentDeptId);
            this.cbType.Text = "发票项目";
        } 
        private void btnfind_Click(object sender, EventArgs e)
        {
            DateTime bdate = dtpBdate.Value;
            DateTime edate = dtPEnd.Value;
            string itemtype = this.cbType.Text;
            DataTable dt = new DataTable();
            dt = HIS.SS_BLL.SsReport.GetReport(deptid, bdate, edate, cbType.Text);
            this.dataGridViewEx1.DataSource = dt;
            for (int i = 0; i < 4; i++)
            {
                this.dataGridViewEx1.Columns[i].Frozen = true;
            }
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
    }
}
