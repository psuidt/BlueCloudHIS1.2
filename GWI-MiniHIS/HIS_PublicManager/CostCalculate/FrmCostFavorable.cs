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
    public partial class FrmCostFavorable :  GWI.HIS.Windows.Controls.BaseForm
    {
        public decimal outFee;

        public FrmCostFavorable()
        {
            InitializeComponent();
            this.panel3.Visible = false;
            this.Height = 220;
            this.btCal.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.panel3.Visible = true;
                this.Height = 400;
                this.btCal.Enabled = true;
            }
            else
            {
                this.panel3.Visible = false;
                this.Height = 220;
                this.btCal.Enabled = false;
            }
        }

        private void btclose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            outFee = Convert.ToDecimal(this.tbResultFee.Text.Trim());
            this.Close();
        }
    }
}
