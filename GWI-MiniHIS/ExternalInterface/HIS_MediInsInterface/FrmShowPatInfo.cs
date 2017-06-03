using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS_MediInsInterface.Action;

namespace HIS_MediInsInterface
{
    public partial class FrmShowPatInfo : Form,IpatInfo
    {
        public bool isOk = false;

        CostUpdateController Controller;


        public FrmShowPatInfo(CostUpdateController _controller)
        {
            InitializeComponent();
            Controller = _controller;
            Controller.Ipatinfo = this;
        }

        #region IpatInfo 成员

        public DataTable dgvpatInfo
        {
            set
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = value;
            }
        }

        public DataTable cbywlb
        {
            set
            {
                this.comboBox1.DisplayMember = "YWMC";
                this.comboBox1.ValueMember = "YWLB";
                this.comboBox1.DataSource = value;
            }
        }

        public string ywlb
        {
            get
            {
                return this.comboBox1.SelectedValue.ToString();
            }
        }

        public string ywid
        {
            set { this.textBox1.Text = value; }
        }

        public int currentRow
        {
            get
            {
                if (this.dataGridView1.CurrentCell != null)
                    return this.dataGridView1.CurrentCell.RowIndex;
                return -1;
            }
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("先选择一个病人！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (this.comboBox1.SelectedValue == null)
            {
                MessageBox.Show("先选择病人的业务类别！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isOk = true;
            this.Close();
        }

        private void FrmShowPatInfo_Load(object sender, EventArgs e)
        {
            Controller.getpatinfodata();
        }

        #region IpatInfo 成员


        public string ylzh
        {
            get
            {
                return tbylzh.Text.Trim();
            }
            set
            {
                tbylzh.Text = value;
            }
        }

        public string DiseaseCode
        {
            get
            {
                return this.qtbDisease.MemberValue == null ? "" : qtbDisease.MemberValue.ToString();
            }
            set
            {
                qtbDisease.MemberValue = value;
            }
        }

        public string DiseaseName
        {
            get
            {
                return this.qtbDisease.Text;
            }
            set
            {
                this.qtbDisease.Text = value;
            }
        }

        public void Initialize(DataSet _dataSet)
        {
            this.qtbDisease.SetSelectionCardDataSource(_dataSet.Tables["Disease"]);
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            Controller.newgetpatinfodata();
        }

        private void tbylzh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button3_Click(null, null);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.button1_Click(null, null);
        }


 

       
    }
}
