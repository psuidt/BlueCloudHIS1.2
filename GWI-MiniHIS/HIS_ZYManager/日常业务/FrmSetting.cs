using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.ZY_BLL;


namespace HIS_ZYManager
{
    public partial class FrmSetting : GWI.HIS.Windows.Controls.BaseForm
    {
        DataTable Alldt = null;
        DataTable _Alldt = null;
        public FrmSetting()
        {
            InitializeComponent();
            
        }
        //绑定数据
        private void BindData()
        {
            Alldt=OP_ZYConfigSetting.GetConfigData();
            _Alldt = Alldt.Copy();
            this.dataGridViewEx1.AutoGenerateColumns = false;
            this.dataGridViewEx1.DataSource = Alldt;
            button1_Click(null, null);
            
        }
        //说明
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("value", typeof(int));
            DataColumn dc2 = new DataColumn("Text", typeof(string));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            for (int i = 0; i <= this.comboBox1.SelectedIndex; i++)
            {
                DataRow dr = dt.NewRow();
                dr["value"] = i;
                dr["Text"] = "";
                dt.Rows.Add(dr);
            }
            this.dataGridViewEx2.DataSource = dt;
        }
        //保存
        private void btSave_Click(object sender, EventArgs e)
        {
            if (this.tbcoding.Text.Trim() == "")
            {
                MessageBox.Show("填写参数代码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.tbcoding.Focus();
                return;
            }
            DataTable dt = (DataTable)this.dataGridViewEx2.DataSource;           
            OP_ZYConfigSetting.SaveData(this.tbcoding.Text.Trim(), this.tbname.Text.Trim(), OP_ZYConfigSetting.JoinString(dt));
            BindData();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        //删除
        private void btDel_Click(object sender, EventArgs e)
        {
            if (this.tbcoding.Text.Trim() == "")
            {
                MessageBox.Show("填写参数代码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.tbcoding.Focus();
                return;
            }
            OP_ZYConfigSetting.DelData(this.tbcoding.Text.Trim());
            BindData();
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        //值改变
        private void dataGridViewEx1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (this.dataGridViewEx1.CurrentCell != null)
            {
                if (e.ColumnIndex == 2)
                {
                    this.dataGridViewEx1[3, e.RowIndex].Value = ((DataTable)this.dataGridViewEx2.DataSource).Select("value=" + this.dataGridViewEx1[2, e.RowIndex].Value.ToString())[0]["Text"].ToString();
                    //Alldt.Rows[e.RowIndex]["value"] = Convert.ToInt32(this.dataGridViewEx1[2, e.RowIndex].Value);
                }
            }
        }
        //单元格改变
        private void dataGridViewEx1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewEx1.CurrentCell != null)
            {
                int rowindex = this.dataGridViewEx1.CurrentCell.RowIndex;
                this.tbcoding.Text = this.dataGridViewEx1[0, rowindex].Value.ToString();
                this.tbname.Text = this.dataGridViewEx1[1, rowindex].Value.ToString();
                DataTable dt = OP_ZYConfigSetting.GetConfigText(Alldt, this.tbcoding.Text.Trim());
                int[] cols = new int[dt.Rows.Count];
                for (int i = 0; i < cols.Length; i++)
                {
                    cols[i] = i;
                }
                this.Column2.DataSource = cols;
                this.comboBox1.SelectedIndex = dt.Rows.Count - 1;
                this.dataGridViewEx2.DataSource = dt;
            }
        }
        //使用默认设置
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _Alldt.Rows.Count; i++)
            {
                this.dataGridViewEx1[2, i].Value = _Alldt.Rows[i]["value"];
                DataTable dt = OP_ZYConfigSetting.GetConfigText(Alldt, this.dataGridViewEx1[0, i].Value.ToString());
                this.dataGridViewEx1[3, i].Value = (dt).Select("value=" + this.dataGridViewEx1[2, i].Value.ToString())[0]["Text"].ToString();
            }
        }
        //保存当前设置
        private void button2_Click(object sender, EventArgs e)
        {
            OP_ZYConfigSetting.SaveConfig(Alldt);
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        //窗体加载事件
        private void FrmSetting_Load(object sender, EventArgs e)
        {
            BindData();
            
        }
        //防错
        private void dataGridViewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.Cancel = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintController.CreateChargeInvoiceTemplate_GD();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PrintController.CreateChargeInvoiceTemplate_HN();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrintController.CreateChargeAccountBookTemplate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PrintController.CreateCostAccountBookTemplate();
        }
    }
}
