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
    public partial class FrmStop : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmStop()
        {
            InitializeComponent();
        }
        private HIS.Model.ZY_PatList patlist;
        public bool isDefineStop = false;
        int userid;
        int deptid;
        public FrmStop(HIS.Model.ZY_PatList _patlist, long _userid, long _deptid)
        {
            InitializeComponent();
            patlist = _patlist;
            userid = Convert.ToInt32(_userid);
            deptid = Convert.ToInt32(_deptid);
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

        private void btnYes_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (this.radDefault.Checked)
            {
                num = -1;
            }
            else
            {
                num = Convert.ToInt16(this.NumUpDown.Value);
            }   
            FrmChgTemiTimes fce = new FrmChgTemiTimes(patlist, num);
            fce.ShowDialog();
            if (!fce.isOK)
            {
                return;
            }
            DataTable groupTb = fce.groupTb;
            //停医嘱         
            List<HIS.Model.ZY_DOC_ORDERRECORD> records = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            for (int i = 0; i < groupTb.Rows.Count; i++)
            {
                HIS.Model.ZY_DOC_ORDERRECORD order = new HIS.Model.ZY_DOC_ORDERRECORD();
                order = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(groupTb, i, order);
                order.EORDER_DOC = userid;
                order.EORDER_DATE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                order.TEMINAL_TIMES = Convert.ToInt32(groupTb.Rows[i]["teminal_times"].ToString());
                order.STATUS_FALG = 3;
                records.Add(order);
            }
            HIS.ZYDoc_BLL.OrderInfo.IOrderOP orderop = new HIS.ZYDoc_BLL.OrderInfo.OrderOperation();
            orderop.records = records;
            if (orderop.StopAll()) 
            {
                MessageBox.Show("停医嘱成功！");
                isDefineStop = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("停医嘱错误！");
                this.Close();
            }
        }
      
    }
}
