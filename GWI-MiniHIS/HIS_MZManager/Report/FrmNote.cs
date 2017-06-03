using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZManager.Report
{
    public partial class FrmNote : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmNote()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            this.Close();
        }
    }
}
