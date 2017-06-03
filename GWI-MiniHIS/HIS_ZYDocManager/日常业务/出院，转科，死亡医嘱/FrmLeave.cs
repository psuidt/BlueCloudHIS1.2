using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ZYDocManager.日常业务
{
    public partial class FrmLeave : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmLeave()
        {
            InitializeComponent();
        }
        private HIS.Model.ZY_PatList patlist;
        public bool isDefineOut = false;
        DataTable dtzy;
        DataTable dtzx;
        DataTable dtxy;
        int userid;
        int deptid;
        private HIS.ZYDoc_BLL.OrderInfo.IOrderOP orderop;
        private HIS.ZYDoc_BLL.BaseInfo.ShowCardBase showcardbase = new HIS.ZYDoc_BLL.BaseInfo.ShowCardBase();
        public FrmLeave(HIS.Model.ZY_PatList _patlist,long _userid,long _deptid)
        {
            InitializeComponent();
            patlist = _patlist;
            BindPat();
            userid = Convert.ToInt32(_userid);
            deptid = Convert.ToInt32(_deptid);
            orderop = new HIS.ZYDoc_BLL.OrderInfo.OrderOperation();
            Initialize();
        }

        private void Initialize()
        {
            DataTable dt = showcardbase.GetDisease();
            //中医诊断
            DataRow[] diseaseDR = dt.Select("sort='B'");
            dtzy = dt.Clone();
            dtzy.Rows.Clear();
            foreach (DataRow dr in diseaseDR)
            {
                dtzy.Rows.Add(dr.ItemArray);
            }
            //证型
            DataRow[] rows = dt.Select("sort='Z'");
            dtzx = dt.Clone();
            dtzx.Rows.Clear();
            foreach (DataRow dr in rows)
            {
                dtzx.Rows.Add(dr.ItemArray);
            }

            //西医诊断
            DataRow[] rowss = dt.Select("sort='D'");
            dtxy = dt.Clone();
            dtxy.Rows.Clear();
            foreach (DataRow dr in rowss)
            {
                dtxy.Rows.Add(dr.ItemArray);
            }
            this.txtzy.SetSelectionCardDataSource(dtzy);
            this.txtzx.SetSelectionCardDataSource(dtzx);
            this.txtxy.SetSelectionCardDataSource(dtxy);            
        }
        //绑定病人信息
        private void BindPat()
        {
            this.txtPatNo.Text = patlist.CureNo;
            this.txtPatName.Text = patlist.PatientInfo.PatName;
            this.label12.Text = patlist.BedCode;
            this.txtNowDept.Text = HIS.ZYDoc_BLL.GetName.GetDeptName(patlist.CurrDeptCode);// HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(patlist.CurrDeptCode);        
            string[] strdiag = patlist.DiseaseName.Split(new char[] { '|' });
            if (strdiag[0] == "")
            {
                this.txtDiagnose.Text = strdiag[1].Replace("\r\n", "");
            }
            else
            {
                this.txtDiagnose.Text = strdiag[0].Replace("\r\n", "");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.numericUpDown1.Enabled = false;
            }
            else
            {
                this.numericUpDown1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //babyid没判断
            DateTime serverDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            if (this.cbOut.SelectedItem == null)
            {
                MessageBox.Show("请选择‘出院情况’！");
                return;
            }
            int num = 0;//末日次数
            if (this.radioButton1.Checked)
            {
                num = -1;
            }
            else
            {
                num = Convert.ToInt16(this.numericUpDown1.Value);
            }

            FrmChgTemiTimes fce = new FrmChgTemiTimes(patlist, num);
            fce.ShowDialog();
            if (!fce.isOK)
            {
                return;
            }
            DataTable groupTb = fce.groupTb;
            string str = "";
            if (this.dTimePicker1.Value.Date <= serverDateTime.Date)
            {
                str = "今日";
            }
            else if (this.dTimePicker1.Value.Date == serverDateTime.Date.AddDays(1))
            {
                str = "明日";
            }
            else if (this.dTimePicker1.Value.DayOfWeek == DayOfWeek.Monday)
            {
                str = "星期一";
            }
            else
            {
                str = this.dTimePicker1.Value.Month.ToString() + "月" + this.dTimePicker1.Value.Day.ToString() + "日";
            }  
            patlist.Out_Flag = this.cbOut.SelectedIndex;
            patlist.OutDate = Convert.ToDateTime(this.dTimePicker1.Value.Date.ToString());
            patlist.OutDiagnName = this.txtxy.Text.Trim();
            if (txtxy.MemberValue != null) //20100507.0.01
            {
                patlist.OutDiagnCode = txtxy.MemberValue.ToString();
            }
            HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD(); 
            record.PRES_DEPTID = deptid;            
            record.ORDER_DOC = userid;
            record.ORDER_BDATE = dTimePicker1.Value.Date <= serverDateTime.Date ? dTimePicker1.Value : serverDateTime;           
            record.ORDER_CONTENT = str + "病人出院";            
            record.OPRERATOR = userid;           
            record.EXEC_DEPT = deptid;            
            List<HIS.Model.ZY_DOC_ORDERRECORD> records = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            for (int i = 0; i < groupTb.Rows.Count; i++)
            {
                HIS.Model.ZY_DOC_ORDERRECORD order = new HIS.Model.ZY_DOC_ORDERRECORD();
                order = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(groupTb, i, order);
                order.EORDER_DOC = userid;
                order.EORDER_DATE = Convert.ToDateTime(this.dTimePicker1.Value);
                order.TEMINAL_TIMES = Convert.ToInt32(groupTb.Rows[i]["teminal_times"].ToString());
                order.STATUS_FALG = 3;
                records.Add(order);
            }
            orderop.records = records;
            if (orderop.Leave(record, patlist))
            {
                isDefineOut = true;
                MessageBox.Show("出院申请成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("出院申请失败！请重试！");
                this.Close();
            }
        }

        private void FrmLeave_Load(object sender, EventArgs e)
        {
            DateTime dt = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;   
            this.dTimePicker1.Value = dt;         
            this.dTimePicker1.MinDate = patlist.CureDate;
        }
    }
}
