using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZManager.GH
{
    public partial class FrmInputRegInvoiceNo : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmInputRegInvoiceNo()
        {
            InitializeComponent();
        }

        public string InputInvoiceNo
        {
            get
            {
                return txtInvoiceNo.Text;
            }
        }

        public string InputPerfChar
        {
            get
            {
                return txtPerfChar.Text.Trim();
            }
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click( object sender, EventArgs e )
        {
            if ( MessageBox.Show( "确定要退号？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
