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
    public partial class FrmFavorable : GWI.HIS.Windows.Controls.BaseMainForm
    {

        string patcode;

        DataTable dtBaseItem,dtGroupItem,dtDrug;

        public FrmFavorable()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFavorable_Load(object sender, EventArgs e)
        {
            dtBaseItem = OP_Favorable.GetItemMXData(0);
            dtGroupItem = OP_Favorable.GetItemMXData(1);
            dtDrug = OP_Favorable.GetItemMXData(2);

            this.dgvPatType.DataSource = OP_Favorable.GetPatientTypeData();
            this.cbBasePatType.DataSource = OP_Favorable.GetBasePatTypeData();
            this.cbBasePatType.DisplayMember = "NAME";
            this.cbBasePatType.ValueMember = "CODE";
          
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox3.DataSource = OP_Favorable.GetItemFPData(this.comboBox4.SelectedIndex);
            this.comboBox3.DisplayMember = "item_name";
            this.comboBox3.ValueMember = "code";
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox6.SelectedIndex == 0)
                this.queryTextBox1.SetSelectionCardDataSource(dtBaseItem);
            else if (this.comboBox6.SelectedIndex == 1)
                this.queryTextBox1.SetSelectionCardDataSource(dtGroupItem);
            else if (this.comboBox6.SelectedIndex == 2)
                this.queryTextBox1.SetSelectionCardDataSource(dtDrug);
        }

        private void dgvPatType_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgvPatType.CurrentCell != null)
            {
                this.cbBasePatType.SelectedValue = this.dgvPatType[code.Name, this.dgvPatType.CurrentCell.RowIndex].Value;
                this.comboBox2.Text = this.dgvPatType[favor_type.Name, this.dgvPatType.CurrentCell.RowIndex].Value.ToString();
                this.textBox1.Text = this.dgvPatType[favor_sacle.Name, this.dgvPatType.CurrentCell.RowIndex].Value.ToString();
                this.textBox2.Text = this.dgvPatType[medcode.Name, this.dgvPatType.CurrentCell.RowIndex].Value.ToString();
                this.checkBox1.Checked = this.dgvPatType[mz_flag.Name, this.dgvPatType.CurrentCell.RowIndex].Value.ToString() == "1" ? true : false;
                this.checkBox2.Checked = this.dgvPatType[zy_flag.Name, this.dgvPatType.CurrentCell.RowIndex].Value.ToString() == "1" ? true : false;
                this.checkBox3.Checked = this.dgvPatType[del_flag.Name, this.dgvPatType.CurrentCell.RowIndex].Value.ToString() == "1" ? true : false;

                patcode = this.dgvPatType[code.Name, this.dgvPatType.CurrentCell.RowIndex].Value.ToString();
                this.dgvBigItem.AutoGenerateColumns = false;
                this.dgvItemMx.AutoGenerateColumns = false;
                this.dgvBigItem.DataSource = OP_Favorable.GetItemFavorData(patcode);
                DataTable dt = OP_Favorable.GetItemMXFavorData(patcode);
                this.dgvItemMx.DataSource = OP_Favorable.GetItemMXFavorItemName(dt, dtBaseItem, dtGroupItem, dtDrug);
            }
        }

        private void dgvBigItem_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgvBigItem.CurrentCell != null)
            {
                int rowid = this.dgvBigItem.CurrentCell.RowIndex;
                DataTable dt = (DataTable)this.dgvBigItem.DataSource;
                this.comboBox4.SelectedIndex = Convert.ToInt32(dt.Rows[rowid]["ITEMTYPE_FLAG"])-1;
                this.comboBox3.SelectedValue = dt.Rows[rowid]["ITEMCODE"];
                this.textBox3.Text = dt.Rows[rowid]["FAVORABLE_SCALE"].ToString();

            }
        }

        private void dgvItemMx_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgvItemMx.CurrentCell != null)
            {
                int rowid = this.dgvItemMx.CurrentCell.RowIndex;
                DataTable dt = (DataTable)this.dgvItemMx.DataSource;
                this.comboBox6.SelectedIndex = Convert.ToInt32(dt.Rows[rowid]["ITEMTYPE"]);
                this.queryTextBox1.MemberValue = dt.Rows[rowid]["ITEMID"];
                this.textBox4.Text = dt.Rows[rowid]["FAVORABLE_SCALE"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.cbBasePatType.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.checkBox1.Checked = true;
            this.checkBox2.Checked = true;
            this.checkBox3.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.comboBox4.SelectedIndex = 0;
            this.textBox3.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.comboBox6.SelectedIndex = 0;
            this.queryTextBox1.Text = "";
            this.textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox2.Text == "")
            {
                MessageBox.Show("请填写完整数据！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OP_Favorable.SavePatientType(this.cbBasePatType.SelectedValue.ToString()
                    , this.cbBasePatType.Text
                    , Convert.ToDecimal(this.textBox1.Text.Trim())
                    , this.comboBox2.SelectedIndex
                    , this.checkBox1.Checked == true ? 1 : 0
                    , this.checkBox2.Checked == true ? 1 : 0
                    , this.textBox2.Text
                    , this.checkBox3.Checked == true ? 1 : 0);
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception err)
            {
                MessageBox.Show("您填写数据有误！+\n"+err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.textBox4.Text == "" || this.queryTextBox1.Text == "")
            {
                MessageBox.Show("请填写完整数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OP_Favorable.SaveItemMXFavor(patcode
                    ,this.queryTextBox1.MemberValue.ToString()
                    ,this.comboBox6.SelectedIndex
                    ,Convert.ToDecimal(this.textBox4.Text.Trim()));
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                patcode = this.dgvPatType[code.Name, this.dgvPatType.CurrentCell.RowIndex].Value.ToString();
                this.dgvBigItem.AutoGenerateColumns = false;
                this.dgvItemMx.AutoGenerateColumns = false;
                this.dgvBigItem.DataSource = OP_Favorable.GetItemFavorData(patcode);
                DataTable dt = OP_Favorable.GetItemMXFavorData(patcode);
                this.dgvItemMx.DataSource = OP_Favorable.GetItemMXFavorItemName(dt, dtBaseItem, dtGroupItem, dtDrug);
            }
            catch (Exception err)
            {
                MessageBox.Show("您填写数据有误！+\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox3.Text == "")
            {
                MessageBox.Show("请填写完整数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OP_Favorable.SaveItemFavor(patcode
                    ,this.comboBox3.SelectedValue.ToString()
                    ,this.comboBox4.SelectedIndex+1
                    ,Convert.ToDecimal(this.textBox3.Text.Trim()));
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("您填写数据有误！+\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmFavorable_Load(null, null);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (patcode != null)
            {
                OP_Favorable.DelPatinetType(patcode);
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.queryTextBox1.MemberValue != null)
            {
                OP_Favorable.DelItemMXFavor(this.queryTextBox1.MemberValue.ToString(), this.comboBox6.SelectedIndex);
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.comboBox3.SelectedValue != null)
            {
                OP_Favorable.DelItemFavor(this.comboBox3.SelectedValue.ToString(), this.comboBox4.SelectedIndex + 1);
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
 

    }
}
