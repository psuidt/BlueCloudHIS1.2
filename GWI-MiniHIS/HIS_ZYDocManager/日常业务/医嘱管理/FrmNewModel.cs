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
    public partial class FrmNewModel : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmNewModel()
        {
            InitializeComponent();
        }
        public int level=2;
        public string typename;

        private void rbHospital_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHospital.Checked)
            {
                level = 0;
            }
        }

        private void rbDept_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDept.Checked)
            {
                level = 1;
            }
        }

        private void rbSelf_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelf.Checked)
            {
                level = 2;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            typename = this.txtModelName.Text.Trim();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtModelName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.typename = this.txtModelName.Text.Trim();
                this.Close();
            }

        }
    }
}
