using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using grproLib;

namespace HIS_ReportManager
{
    public partial class Frmtest : GWI.HIS.Windows.Controls.BaseForm
    {
        public Frmtest()
        {
            
            InitializeComponent();
        }


        public void AttachReport(GridppReport Report)
        {
            //设定查询显示器关联的报表
            axGDVshowReport.Report = Report;
            
        }
        private void Frmtest_Load(object sender, EventArgs e)
        {
            axGDVshowReport.Stop();
            axGDVshowReport.Start();            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            axGDVshowReport.Stop();
            this.Close();
        }

        private void btnPrintview_Click(object sender, EventArgs e)
        {
            axGDVshowReport.Report.PrintPreview(true);
        }
    }
}
