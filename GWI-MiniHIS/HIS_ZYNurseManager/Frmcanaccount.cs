using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;


namespace HIS_ZYNurseManager
{
    public partial class Frmcanaccount : Form
    {
        public Frmcanaccount()
        {
            InitializeComponent();
        }
        private decimal  amount;
        public  decimal  Amount
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
        /// <summary>
        /// 确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnassure_Click(object sender, EventArgs e)
        {
            if (CommonFun.IsNumeric(queryTextBox1.Text.ToString().Trim(), false))
            {
                if (Convert.ToDecimal(queryTextBox1.Text.ToString().Trim()) > 0)
                {
                    this.amount = Convert.ToDecimal(queryTextBox1.Text.ToString().Trim());
                }
                else
                {
                    queryTextBox1.Focus();
                    MessageBox.Show("您输入的数量为非正数，请重新输入正数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                queryTextBox1.Focus();
                MessageBox.Show("您输入的数量不是数值，请输入正整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Close();
        }
    }
}
