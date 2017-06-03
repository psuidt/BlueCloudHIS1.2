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
    public partial class FrmDeath : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmDeath()
        {
            InitializeComponent();
        }
        int userid;
        int deptid;
        HIS.Model.ZY_PatList patlist;
        public bool isDefineDeath = false;
        private HIS.ZYDoc_BLL.OrderInfo.IOrderOP orderop;
        private HIS.ZYDoc_BLL.BaseInfo.ShowCardBase showcardbase = new HIS.ZYDoc_BLL.BaseInfo.ShowCardBase();
        public FrmDeath(HIS.Model.ZY_PatList _patlist,long _userid,long _deptid)
        {
            InitializeComponent();
            patlist = _patlist;
            userid = Convert.ToInt32(_userid);
            deptid = Convert.ToInt32(_deptid);
            this.BindPat();
            DataTable dt = showcardbase.GetDisease();          
            this.txtdiag.SetSelectionCardDataSource(dt);
            orderop = new HIS.ZYDoc_BLL.OrderInfo.OrderOperation();
        }
        //绑定病人信息
        private void BindPat()
        {
            this.txtPatNo.Text = patlist.CureNo;
            this.txtPatName.Text = patlist.PatientInfo.PatName;
            this.txtBedNo.Text = patlist.BedCode;
            this.txtNowDept.Text = HIS.ZYDoc_BLL.GetName.GetDeptName(deptid.ToString());
            string[] strdiag = patlist.DiseaseName.Split(new char[] { '|' });
            if (strdiag[0] == "")
            {
                this.txtDiagnose.Text = strdiag[1].Replace("\r\n","");
            }
            else
            {
                this.txtDiagnose.Text = strdiag[0].Replace("\r\n","");
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            int num = 0;//末日次数
            if (this.radioButton1.Checked)
            {
                num = -1;
            }
            else
            {
                num = Convert.ToInt16(this.numericUpDown1.Value);
            }
            //修改末日次数还没做(babyid)
            FrmChgTemiTimes fce = new FrmChgTemiTimes(patlist,num);
            fce.ShowDialog();
            if (!fce.isOK)
            {
                return;
            }
            DataTable groupTb = fce.groupTb;     
            HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();                    
            record.ORDER_DOC = userid;           
            record.ORDER_CONTENT = "病人死亡";                 
            record.ORDER_BDATE = Convert.ToDateTime(this.dateTimePicker1.Value.ToString());           
            record.OPRERATOR = userid;           
            record.EXEC_DEPT = deptid;
            record.PRES_DEPTID = deptid;                   
            patlist.Out_Flag = 3;
            patlist.OutDate = Convert.ToDateTime(this.dateTimePicker1.Value.ToString());
            patlist.OutDiagnName = this.txtdiag.Text.Trim();
            List<HIS.Model.ZY_DOC_ORDERRECORD> records = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            //停所有长嘱
            for (int i = 0; i < groupTb.Rows.Count; i++)
            {
                HIS.Model.ZY_DOC_ORDERRECORD order = new HIS.Model.ZY_DOC_ORDERRECORD();
                order = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(groupTb, i, order);
                order.EORDER_DOC = userid;
                order.EORDER_DATE = Convert.ToDateTime(this.dateTimePicker1.Value);
                order.TEMINAL_TIMES = Convert.ToInt32(groupTb.Rows[i]["teminal_times"].ToString());
                order.STATUS_FALG = 3;
                records.Add(order);
            }
            orderop.records = records;
            if (orderop.Death(record,patlist))
            {
                MessageBox.Show("生成死亡医嘱正确");
                this.isDefineDeath = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("生成死亡医嘱错误！请重试");
                this.Close();
            }
        }

        private void FrmDeath_Load(object sender, EventArgs e)
        {
            DateTime dt = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime; 
            this.dateTimePicker1.Value = dt;
            this.dateTimePicker1.MaxDate = dt;
            this.dateTimePicker1.MinDate = patlist.CureDate;          
        }
    }
}
