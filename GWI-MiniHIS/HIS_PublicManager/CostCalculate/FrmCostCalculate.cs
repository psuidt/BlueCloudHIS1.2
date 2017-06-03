using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_PublicManager
{
    public partial class FrmCostCalculate : GWI.HIS.Windows.Controls.BaseForm
    {
        /// <summary>
        /// 记账类型
        /// </summary>
        public string CalType;
        /// <summary>
        /// 单位代码
        /// </summary>
        public string WorkUnit;
        /// <summary>
        /// 单位记账金额
        /// </summary>
        public decimal workUnit_Fee;
        /// <summary>
        /// 总记账金额
        /// </summary>
        public decimal CalResult;


        /// <summary>
        /// 病人费用总金额
        /// </summary>
        public decimal allFee;
        public decimal selfFee;
        public decimal examineFee;

        formulaManager.formulaManager fm = null;

        public FrmCostCalculate()
        {
            InitializeComponent();
        }

        public FrmCostCalculate(int patlistId, decimal Allfee, decimal Selffee,DataTable dtfee)
        {
            InitializeComponent();

            this.allFee = Allfee;
            this.selfFee = Selffee;
            //this.examineFee = ExamineFee;
          
            this.BindData(patlistId,dtfee);

            this.checkBox1.Checked = false;
            this.panel3.Visible = false;
            this.Height = 233;
            this.btCal.Enabled = false;
            this.checkBox2.Checked = false;
            this.txtUnit.Enabled = false;
            this.cbWorker.Enabled = false;

            this.tbResultFee.Text = "0";
            this.txtSelfFee.Text = "0";
            this.lbAllFee.Text = allFee.ToString("0.00");


            fm = new HIS_PublicManager.formulaManager.formulaManager();
            fm.LoadData();
        }

        private void BindData(int patlistId, DataTable dtfee)
        {

            for (int i = 0; i < dtfee.Rows.Count; i++)
            {
                if (dtfee.Rows[i][0].ToString().Trim() == "诊查费")
                {
                    this.examineFee = Convert.ToDecimal(dtfee.Rows[i][1]);
                }
            }

            this.cbCalType.DataSource = HIS.Public_BLL.Op_CostCalculate.GetPatientType();
            this.cbCalType.DisplayMember = "name";
            this.cbCalType.ValueMember = "code";

            this.cbWorker.DataSource = HIS.Public_BLL.Op_CostCalculate.GetWorkUnit();
            this.cbWorker.DisplayMember = "name";
            this.cbWorker.ValueMember = "code";

            this.cbCalType.SelectedValue = HIS.Public_BLL.Op_CostCalculate.GetPatlistType(patlistId);
            this.CalType = this.cbCalType.SelectedValue.ToString();

        }

        private void btclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //计算
        private void btCal_Click(object sender, EventArgs e)
        {
            DataTable dt=(DataTable)this.dataGridViewEx1.DataSource;
            fm.Calculate(dt,false);
            this.tbResultFee.Text = fm.GetResult(dt);
        }

        private void cbCalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tbResultFee.ForeColor = Color.Black;
            this.tbResultFee.Enabled = true;

            this.tabPage1.Text = this.cbCalType.Text;
            this.CalType = this.cbCalType.SelectedValue.ToString();

            if (fm != null)
            {
                fm.ChangedData(CalType);

                DataTable dt = fm.ArrangCalculate();
                for (int i = 0; i < fm.fsvlist.Count; i++)
                {
                    switch (fm.fsvlist[i].name)
                    {
                        case "总金额":
                            fm.fsvlist[i].value = allFee.ToString("0.00");
                            break;
                        case "诊金":
                            fm.fsvlist[i].value = examineFee.ToString("0.00");
                            break;
                        case "自费金额":
                            fm.fsvlist[i].value = selfFee.ToString("0.00");
                            break;
                    }
                }


                fm.Calculate(dt);

                this.dataGridViewEx1.DataSource = dt;
            }
        }

        private void btok_Click(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                try
                {
                    this.WorkUnit = this.cbWorker.SelectedValue.ToString();
                    workUnit_Fee = Convert.ToDecimal(this.txtUnit.Text);
                }
                catch
                {
                    MessageBox.Show("请先选择记账单位！");
                    return;
                }
            }
            CalResult = Convert.ToDecimal(this.tbResultFee.Text) + Convert.ToDecimal(this.txtUnit.Text);
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.Location = new Point(this.Location.X, this.Location.Y-200);
                this.panel3.Visible = true;
                this.Height = 635;
                this.btCal.Enabled = true;

                cbCalType_SelectedIndexChanged(null, null);
            }
            else
            {
                this.Location = new Point(this.Location.X, this.Location.Y + 200);
                this.panel3.Visible = false;
                this.Height = 233;
                this.btCal.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                this.txtUnit.Enabled = true;
                this.cbWorker.Enabled = true;
                this.txtUnit.Text = Convert.ToString(allFee - Convert.ToDecimal(this.tbResultFee.Text)-Convert.ToDecimal(this.txtSelfFee.Text));
            }
            else
            {
                this.txtUnit.Enabled = false;
                this.txtUnit.Text = "0";
                this.cbWorker.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tbResultFee.Text = Convert.ToString(allFee - Convert.ToDecimal(this.txtUnit.Text) - Convert.ToDecimal(this.txtSelfFee.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
                this.txtUnit.Text = Convert.ToString(allFee - Convert.ToDecimal(this.tbResultFee.Text) - Convert.ToDecimal(this.txtSelfFee.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.txtSelfFee.Text = Convert.ToString(allFee - Convert.ToDecimal(this.txtUnit.Text) - Convert.ToDecimal(this.tbResultFee.Text));
        }

    }
}
