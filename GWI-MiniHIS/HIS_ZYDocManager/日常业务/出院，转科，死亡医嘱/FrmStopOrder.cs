using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;


namespace HIS_ZYDocManager.日常业务
{
    public partial class FrmStopOrder : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmStopOrder()
        {
            InitializeComponent();
         
        } 
        public bool IsStop = false;
        public  int num = 0;
        public DateTime endtime;
        public string frnquecy;
        public DateTime beginDateTime;
        private HIS.ZYDoc_BLL.BaseInfo.DrugBase drugbase = new HIS.ZYDoc_BLL.BaseInfo.DrugBase();
        private void FrmStopOrder_Load(object sender, EventArgs e)
        {
            DateTime dtime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            this.dtime_end.Value = dtime;          
            this.dtime_end.MinDate = beginDateTime;
            if (dtime.Date == beginDateTime.Date)//当天开当天停的
            {
                if (frnquecy == "持续" || frnquecy == "Q1h")
                {
                    int hour1 = dtime.Hour;
                    int bhour = beginDateTime.Hour;
                    this.lbNum.Text = (hour1 - bhour + 1).ToString();
                }
                else
                {
                    this.lbNum.Text = GetEndNum(frnquecy, this.dtime_end.Value).ToString();
                }

            }
            else
            {
                if (frnquecy == "持续" || frnquecy == "Q1h")
                {
                    this.lbNum.Text = (XcDate.ServerDateTime.Hour + 1).ToString();
                }
                else
                {
                    this.lbNum.Text = GetEndNum(frnquecy, this.dtime_end.Value).ToString();
                }
            }
            //this.dtime_end.MaxDate = dtime.Date.AddDays(Convert.ToDouble("1")).AddSeconds(-1);
          // this.NumUpDown.Maximum = GetEndNum(frnquecy, this.dtime_end.Value.AddDays(1).Date.AddSeconds(-1));//曾军龙认为不要限制未日执行次数
        }
        //根据频率、医嘱时间获取末日次数
        private int GetEndNum(string frequency, DateTime dtime)
        {
            return drugbase.getExecTimes(frnquecy, dtime, 1);
        }

        private void radDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (radDefault.Checked)
            {
                this.NumUpDown.Enabled = false;
            }
            else
            {
                this.NumUpDown.Enabled = true;
            }
        }

        private void dtime_end_ValueChanged(object sender, EventArgs e)
        {
            this.lbNum.Text = GetEndNum(frnquecy, this.dtime_end.Value).ToString();       
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "您确认停止医嘱吗?", "停医嘱", MessageBoxButtons.YesNo) == DialogResult.No)
            {      
                return;
            }    
            if (radDefault.Checked)
            {
                num =Convert.ToInt32(this.lbNum.Text);
            }
            else
            {
                num = Convert.ToInt16(this.NumUpDown.Value);
            }
            IsStop = true;
            endtime = this.dtime_end.Value;
            this.Close();          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
