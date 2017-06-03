using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ZYDocManager.日常业务
{
    public partial class FrmJZ : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmJZ()
        {
            InitializeComponent();
        }
        public string note = "";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtNote.Text.Trim() == "")
            {
                this.txtNote.Text = this.comboBox1.Text;
            }
            else
            {
                this.txtNote.Text+= "、" +this.comboBox1.Text;
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            note = this.txtNote.Text.Trim();
            this.Close();
        }

        private void FrmJZ_Load(object sender, EventArgs e)
        {
            this.txtNote.Text = "";
        }
    }
}
