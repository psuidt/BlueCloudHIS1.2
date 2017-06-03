using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.ZY_BLL.DataModel;

namespace HIS_ZYManager
{
    public partial class FrmBadTicketManager : GWI.HIS.Windows.Controls.BaseForm
    {
        string EmpCode;
        private ZY_CostMaster zyCostMaster = null;

        public FrmBadTicketManager()
        {
            InitializeComponent();

            zyCostMaster = new ZY_CostMaster();
        }
        public FrmBadTicketManager(string empcode)
        {
            InitializeComponent();
            EmpCode = empcode;
            zyCostMaster = new ZY_CostMaster();

            this.dgvNow.AutoGenerateColumns = false;
            this.dgvHistroy.AutoGenerateColumns = false;

            this.dgvNow.DataSource = zyCostMaster.GetBadTicket(false, EmpCode, null, null);
            this.dgvHistroy.DataSource = zyCostMaster.GetBadTicket(true, EmpCode, this.dtBdate.Value, this.dteDate.Value);

            this.tabControl1.SelectedIndex = 0;
        }
        
        //显示历史发票
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.btDel.Enabled = true;
            }
            else
            {
                this.btDel.Enabled = false;
            }
        }
        //添加
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (this.txtTicketNo.Text.Trim() == "")
            {
                MessageBox.Show("发票号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            zyCostMaster.AddBadTicket(this.txtTicketNo.Text.Trim(), EmpCode);
            this.tabControl1.SelectedIndex = 0;
            this.dgvNow.AutoGenerateColumns = false;
            this.dgvNow.DataSource = zyCostMaster.GetBadTicket(false, EmpCode, null, null);
            this.txtTicketNo.Text = "";
            MessageBox.Show("添加成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        //删除
        private void btDel_Click(object sender, EventArgs e)
        {
            if (this.dgvNow.CurrentCell != null)
            {
                string ticketno = this.dgvNow[0, this.dgvNow.CurrentCell.RowIndex].Value.ToString();
                zyCostMaster.DelBadTicket(ticketno);
                this.dgvNow.AutoGenerateColumns = false;
                this.dgvNow.DataSource = zyCostMaster.GetBadTicket(false, EmpCode, null, null);
                MessageBox.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        //关闭
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}