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
    public partial class FrmAddModel : GWI.HIS.Windows.Controls.BaseForm
    {
        public int level;
        public int type;
        public string lbtext
        {
           set
            {
                label1.Text = value ;
            }
        }
        public string modelName
        {
            get
            {
                return txtName.Text.Trim();
            }
            set
            {
                txtName.Text = value;
            }
        }
        public FrmAddModel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HIS.ZYNurse_BLL.FeeModelProcess modelporcee = new HIS.ZYNurse_BLL.FeeModelProcess();
            if (modelName == "")
            {
                MessageBox.Show("名称不能为空");
                txtName.Focus();
                return;
            }
            if (modelporcee.IsExsistName(modelName, type, level))
            {
                MessageBox.Show("该名称已存在,请重新输入");
                txtName.Focus();
                return;
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            modelName = "";
            this.Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                button1_Click(null, null);
            }
        }
    }
}
