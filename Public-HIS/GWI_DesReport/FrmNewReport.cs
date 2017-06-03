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
using Entity = HIS.Model;
using grproLib;
using System.IO;

namespace GWI_DesReport
{
    public partial class FrmNewReport : Form
    {
       
        string UserID, UserName;
        bool IsNew = false;
        int RptID;
        public FrmNewReport(string userid,string username)
        {
            InitializeComponent();
      
            UserID = userid;
            UserName = username;
            this.tb_rptPath.Text = System.IO.Directory.GetCurrentDirectory() + "\\report\\";
        }
        public FrmNewReport(string userid, string username,int rptid, string rptName, string rptPath)
        {
            InitializeComponent();
            IsNew = true;
            UserID = userid;
            UserName = username;
            RptID = rptid;
            this.tb_RptName.Text = rptName;
            this.tb_rptPath.Text = rptPath;

            this.Text = "修改报表数据源";
            //定义Grid++Report报表主对象
            GridppReport Report = new GridppReport();

            if (Report.LoadFromFile(rptPath + rptName + ".grf"))
            {
                this.tb_ConnStr.Text = Report.DetailGrid.Recordset.ConnectionString;
                this.tb_Sql.Text = Report.DetailGrid.Recordset.QuerySQL;
            }
            else
            {
                MessageBox.Show("报表文件不存在！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Next_Click(object sender, EventArgs e)
        {
            if (this.tb_RptName.Text.Trim() == "" || this.tb_ConnStr.Text.Trim() == "" || this.tb_rptPath.Text.Trim() == "" || this.tb_Sql.Text.Trim() == "")
            {
                MessageBox.Show("请输入完整数据！");
                return;
            }
            if (!Directory.Exists(this.tb_rptPath.Text.Trim()))
            {
                MessageBox.Show("报表文件存放路径不正确！");
                return;
            }
            if (!IsNew)
            {
                AddReport();
            }
            else
            {
                UpdateReport();
            }
            this.Hide();
            FrmMain fm = new FrmMain(this.tb_RptName.Text.Trim(),this.tb_rptPath.Text.Trim(),this.tb_ConnStr.Text.Trim(),this.tb_Sql.Text.Trim());
            fm.ShowDialog();
        }
        private void AddReport()
        {

            HIS.Model.HIS_Report Erpt = new HIS.Model.HIS_Report();
            Erpt.ReportName = this.tb_RptName.Text.Trim();
            Erpt.ReportPath = this.tb_rptPath.Text.Trim();
            Erpt.BuildEmpCode = UserID;
            Erpt.BuildEmpName = UserName;
            Erpt.BuildDateTime = DateTime.Now;
            HisReport.AddReport(Erpt);
        }
        private void UpdateReport()
        {
           
            try
            {
                HIS.Model.HIS_Report Erpt = new HIS.Model.HIS_Report();
                Erpt.ReportID = RptID;
                Erpt.ReportName = this.tb_RptName.Text.Trim();
                Erpt.ReportPath = this.tb_rptPath.Text.Trim();
                Erpt.BuildEmpCode = UserID;
                Erpt.BuildEmpName = UserName;
                Erpt.BuildDateTime = DateTime.Now;

                HisReport.UpdateReport(Erpt);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
