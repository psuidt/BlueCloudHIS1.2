using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ZYDocManager.基础数据
{
    public partial class FrmNew : GWI.HIS.Windows.Controls.BaseForm
    {
        public string typename;
        public bool IsOk = true;
        public FrmNew()
        {
            InitializeComponent();
        }
        public FrmNew(string str)
        {
            InitializeComponent();
            this.label1.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.typename = textBox1.Text.Trim();

            IsOk = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsOk = false;
            this.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.typename = textBox1.Text.Trim();
                IsOk = true;
                this.Close();
            }

        }
    }
}
