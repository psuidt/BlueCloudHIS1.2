using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;

namespace HIS_PublicManager.SystemTool.GenerateWorkers
{
    public partial class FrmWorkInfo : Form
    {
        private int WorkID;
        private RelationalDatabase Oledb;
        public FrmWorkInfo()
        {
            InitializeComponent();
        }

        public FrmWorkInfo(int workid, RelationalDatabase _Oledb)
        {
            InitializeComponent();
            WorkID = workid;
            Oledb = _Oledb;

            DataRow dr = Oledb.GetDataRow("select * from HIS_WORKERSINFO where workid=" + WorkID);
            if (dr != null)
            {
                this.tbHISADDRESS.Text = dr["HISADDRESS"].ToString();
                this.tbHISPOS.Text = dr["HISPOS"].ToString();
                this.tbHISBEDCOUNT.Text = dr["HISBEDCOUNT"].ToString();
                this.tbHISBEDNUM.Text = dr["HISBEDNUM"].ToString();
                this.tbHISPATNUM.Text = dr["HISPATNUM"].ToString();
                this.tbHISPRESON.Text = dr["HISPRESON"].ToString();
                this.tbHISTEL.Text = dr["HISTEL"].ToString();
                this.tbHISWORKNUM.Text = dr["HISWORKNUM"].ToString();
                this.tbHISYZBM.Text = dr["HISYZBM"].ToString();
            }
            else
            {
                Oledb.DoCommand("insert into HIS_WORKERSINFO(Workid) values("+WorkID+")");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "update HIS_WORKERSINFO set HISADDRESS='" + this.tbHISADDRESS.Text .Trim()+ "'";
            sql += ",HISPOS='" + this.tbHISPOS.Text.Trim() + "'";
            sql += ",HISBEDCOUNT=" + this.tbHISBEDCOUNT.Text.Trim() + "";
            sql += ",HISBEDNUM=" + this.tbHISBEDNUM.Text.Trim() + "";
            sql += ",HISPATNUM="+this.tbHISPATNUM.Text.Trim()+"";
            sql += ",HISPRESON='" + this.tbHISPRESON.Text.Trim() + "'";
            sql += ",HISTEL='" + this.tbHISTEL.Text.Trim() + "'";
            sql += ",HISWORKNUM="+this.tbHISWORKNUM.Text.Trim()+"";
            sql += ",HISYZBM='" + this.tbHISYZBM.Text.Trim() + "'";
            sql += " where workid=" + WorkID;
            Oledb.DoCommand(sql);
            MessageBox.Show("保存成功！");
        }

       
    }
}
