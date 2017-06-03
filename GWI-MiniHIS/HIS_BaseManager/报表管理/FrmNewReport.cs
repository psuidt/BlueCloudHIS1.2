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
using System.IO;

namespace HIS_BaseManager
{
    public partial class FrmNewReport : GWI.HIS.Windows.Controls.BaseForm
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
            FrmReportManager fm = new FrmReportManager(this.tb_RptName.Text.Trim(), this.tb_rptPath.Text.Trim(), this.tb_ConnStr.Text.Trim(), this.tb_Sql.Text.Trim());
            fm.ShowDialog();
        }
        private void AddReport()
        {
            try
            {
                HIS.Base_BLL.HIS_ReportManger.AddReport( this.tb_RptName.Text.Trim( ) , this.tb_rptPath.Text.Trim( ) , UserID , UserName );
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
        private void UpdateReport()
        {
            
            try
            {
                HIS.Base_BLL.HIS_ReportManger.UpdateReport( RptID ,this.tb_RptName.Text.Trim(),this.tb_rptPath.Text.Trim(),UserID,UserName);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        private void button5_Click( object sender , EventArgs e )
        {

        }
    }
}
