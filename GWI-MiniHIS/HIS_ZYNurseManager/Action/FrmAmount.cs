using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ZYNurseManager
{
    public partial class FrmCanAmount : Form
    {
        private decimal amount;
        public FrmCanAmount()
        {
           InitializeComponent();        
        }
        public decimal Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }      
        private void button1_Click(object sender, EventArgs e)
        {
            if (queryTextBox1.Text != "")
            {
                this.amount = Convert.ToDecimal(queryTextBox1.Text.ToString());
            }
            else
            {
                MessageBox.Show("您输入的数量不能为空，请重新输入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Close();
        }
    }
}
