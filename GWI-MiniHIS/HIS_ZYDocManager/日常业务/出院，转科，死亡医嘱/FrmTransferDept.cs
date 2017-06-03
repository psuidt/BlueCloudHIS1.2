using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;

namespace  HIS_ZYDocManager.日常业务    
{
    public partial class FrmTransferDept : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmTransferDept()
        {
            InitializeComponent();
        }

        private HIS.Model.ZY_PatList patlist;
        public bool isTransferDept = false;   
        int userid;
        int deptid;
        private HIS.ZYDoc_BLL.OrderInfo.IOrderOP orderop;

        public FrmTransferDept(HIS.Model.ZY_PatList _patlist, long _userid, long _deptid)
        {
            InitializeComponent();
            patlist = _patlist;            
            userid = Convert.ToInt32(_userid);
            deptid = Convert.ToInt32(_deptid);
            orderop = new HIS.ZYDoc_BLL.OrderInfo.OrderOperation();
            BindPat();
        }
        //绑定病人信息
        private void BindPat()
        {
            this.txtPatNo.Text = patlist.CureNo;
            this.txtPatName.Text = patlist.PatientInfo.PatName;
            this.label12.Text = patlist.BedCode;
            this.txtNowDept.Text = HIS.ZYDoc_BLL.GetName.GetDeptName(deptid.ToString()); 
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

        private void FrmTransferDept_Load(object sender, EventArgs e)
        {
            DateTime dt = XcDate.ServerDateTime;
            this.dateTimePicker2.Value = dt;
            this.dateTimePicker2.MaxDate = dt.Date.AddDays(7);
            this.dateTimePicker2.MinDate = dt.Date;
            DataTable dtt = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptData(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType.住院, HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType2.临床);
            this.cbDept.DataSource = dtt;
            this.cbDept.DisplayMember = "name";
            this.cbDept.ValueMember = "code";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.deptid == Convert.ToInt64(this.cbDept.SelectedValue))
            {
                MessageBox.Show("不允许本科室转本科室！请重新选择科室。");
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
            string content = "转" + this.cbDept.Text.Trim();
            if (HIS.ZYDoc_BLL.PatInfo.PatOperation.GetNewPatModel(patlist.PatListID).CurrDeptCode != this.deptid.ToString())
            {
                MessageBox.Show("该病人已经不在本科室，请确认！");
                return;
            }
            if (HIS.ZYDoc_BLL.PatInfo.PatOperation.IsTurnDept(patlist.PatListID))
            {
                MessageBox.Show("该病人已存在转科记录，请确认！");
                return;
            }
            HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();            
            record.PATID = patlist.PatListID;          
            record.PAT_DEPTID =Convert.ToInt32(patlist.CurrDeptCode);
            record.PRES_DEPTID = deptid;         
            record.ORDER_DOC = userid;
            record.ORDER_BDATE = Convert.ToDateTime(this.dateTimePicker2.Value.ToString());           
            record.ORDER_CONTENT = content;         
            record.OPRERATOR = userid;          
            record.EXEC_DEPT = deptid;          

            HIS.Model.ZY_DOC_TRANSDEPT transdept = new HIS.Model.ZY_DOC_TRANSDEPT();
            transdept.PATID = patlist.PatListID;
            transdept.ORIGE_DEPT = Convert.ToInt32(patlist.CurrDeptCode);
            transdept.GET_DEPT =Convert.ToInt32(this.cbDept.SelectedValue);
            transdept.TRANSFER_DATE =Convert.ToDateTime( this.dateTimePicker2.Value.ToString());
            transdept.OPERATOR=this.userid;
            transdept.DESCRIPTION = content;
            transdept.BABY_ID = 0;
            transdept.FINISH_FLAG = 0;
            List<HIS.Model.ZY_DOC_ORDERRECORD> records = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            for (int i = 0; i < groupTb.Rows.Count; i++)
            {
                HIS.Model.ZY_DOC_ORDERRECORD order = new HIS.Model.ZY_DOC_ORDERRECORD();
                order = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(groupTb, i, order);
                order.EORDER_DOC = userid;
                order.EORDER_DATE = Convert.ToDateTime(this.dateTimePicker2.Value.ToString());
                order.TEMINAL_TIMES = Convert.ToInt32(groupTb.Rows[i]["teminal_times"].ToString());
                order.STATUS_FALG = 3;
                records.Add(order);
            }
            orderop.records = records;
            if (orderop.TurnDept(record,transdept))
            {
                MessageBox.Show("转科申请成功");
                this.isTransferDept = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("转科申请失败");
                this.Close();
            }   
        }
    }
}
