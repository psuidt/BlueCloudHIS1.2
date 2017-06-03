using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Public_BLL;

namespace HIS_PublicManager
{
    public partial class FrmPatientType  : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public FrmPatientType()
        {
            InitializeComponent();
            toolStripButton1_Click(null, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.dgPatientType.DataSource = OP_PatientType.GetPatientTypeData();
        }

        private void dgPatientType_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgPatientType.CurrentCell != null)
            {
                this.textBox1.Text = this.dgPatientType[0,this.dgPatientType.CurrentCell.RowIndex].Value.ToString();
                this.textBox2.Text = this.dgPatientType[1, this.dgPatientType.CurrentCell.RowIndex].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox2.Text == "")
            {
                MessageBox.Show("请填写完整数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OP_PatientType.SavePatientType(this.textBox1.Text.Trim(), this.textBox2.Text.Trim());
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("您填写数据有误！+\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dgPatientType.CurrentCell != null)
            {
                OP_PatientType.DelPatientType(this.textBox1.Text.Trim());
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
