using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using grproLib;
using System.IO;
namespace HIS_BaseManager
{
    public partial class FrmReportManager : GWI.HIS.Windows.Controls.BaseMainForm
    {
        //定义Grid++Report报表主对象
        private GridppReport Report = new GridppReport();
        string rptName;
        string rptPath;
        string ConnStr;
        string SqlStr;
        public FrmReportManager()
        {
            InitializeComponent();
            this.FormTitle = this.Text;
        }
        public FrmReportManager(string _rptName ,string _rptPath,string _ConnStr,string _SqlStr)
        {
            InitializeComponent();
            this.FormTitle = this.Text;
            this.rptName = _rptName;
            this.rptPath = _rptPath;
            this.ConnStr = _ConnStr;
            this.SqlStr = _SqlStr;

            Report.InsertDetailGrid();
            Report.DetailGrid.Recordset.ConnectionString = ConnStr;//"Provider=IBMDADB2.1;Password=db2inst2;Persist Security Info=True;User ID=db2inst2;Data Source=HIS;Location=192.168.10.60:50000;Mode=ReadWrite";
            Report.DetailGrid.Recordset.QuerySQL = SqlStr;//"select * from base_user";
            Report.SaveToFile(rptPath + rptName + ".grf");
            this.axGRDesigner1.Report = Report; 
        }
        public FrmReportManager(string _rptName, string _rptPath)
        {
            InitializeComponent();

            this.rptName = _rptName;
            this.rptPath = _rptPath;

            if (Report.LoadFromFile(rptPath + rptName + ".grf"))
            {
                this.axGRDesigner1.Report = Report; 
            }
            else
            {
                MessageBox.Show("报表文件不存在！");
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ((GridppReport)this.axGRDesigner1.Report).PrintPreview(true);
        }

        private void axGRDesigner1_OpenReport(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Report = null;
            Report.InsertDetailGrid();
            Report.DetailGrid.Recordset.ConnectionString = ConnStr;
            Report.DetailGrid.Recordset.QuerySQL = SqlStr; 
            this.axGRDesigner1.Report = Report;
        }

        private void axGRDesigner1_SaveReport(object sender, EventArgs e)
        {
             
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new FrmReportManager());
        }
    }
}
