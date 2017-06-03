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

namespace HIS_ZYDocManager.日常业务  //20100512.1.02  手术查询
{
    public partial class FrmSsQuery : GWI.HIS.Windows.Controls.BaseForm
    {
        DataTable ss = new DataTable();
        public FrmSsQuery()
        {
            InitializeComponent();
           ss= HIS.ZYDoc_BLL.QueryWork.OP_SsRpt.GetSsTable(0, dtBegin.Value, dtend.Value);
           Bind();
        }
        private void Bind()
        {
            dgvSsContent.AutoGenerateColumns = false;
            dgvSsContent.DataSource = ss;
        }
        private void GetTable()        
        {           
            if (radNotArrange.Checked)
            {
                ss = HIS.ZYDoc_BLL.QueryWork.OP_SsRpt.GetSsTable(0, dtBegin.Value, dtend.Value);
            }
            else if (radArrange.Checked)
            {
                ss = HIS.ZYDoc_BLL.QueryWork.OP_SsRpt.GetSsTable(1, dtBegin.Value, dtend.Value);
            }
            else if (radFinish.Checked)
            {
                ss = HIS.ZYDoc_BLL.QueryWork.OP_SsRpt.GetSsTable(2, dtBegin.Value, dtend.Value);
            }
            else
            {
                ss = HIS.ZYDoc_BLL.QueryWork.OP_SsRpt.GetSsTable(3, dtBegin.Value, dtend.Value);
            }
            Bind();
        }

        private void radNotArrange_CheckedChanged(object sender, EventArgs e)
        {
            GetTable();
        }

        private void radArrange_CheckedChanged(object sender, EventArgs e)
        {
            GetTable();
        }

        private void radFinish_CheckedChanged(object sender, EventArgs e)
        {
            GetTable();
        }

        private void radCancel_CheckedChanged(object sender, EventArgs e)
        {
            GetTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelApply_Click(object sender, EventArgs e)
        {
            if (!radNotArrange.Checked)
            {
                MessageBox.Show("只有未安排的才能取消");
                return;
            }           
            if (dgvSsContent == null || dgvSsContent.CurrentCell == null || dgvSsContent.Rows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("确定要取消申请吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            int rowindex = dgvSsContent.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgvSsContent.DataSource;
            string  applyid = dt.Rows[rowindex]["apply_id"].ToString();
            HIS.ZYDoc_BLL.OperaApply.SsApply apply = new HIS.ZYDoc_BLL.OperaApply.SsApply();
            if (apply.CancelApply(applyid))
            {
                MessageBox.Show("取消申请成功");
                GetTable();
            }
        }
     
    }
}
