using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_YPManager
{
    public partial class FrmDeptSetType : GWI.HIS.Windows.Controls.BaseForm
    {
        public List<int> drugTypeList = new List<int>();
        public FrmDeptSetType()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int addType;
            if (chkXY.Checked)
            {
                addType = 1;
                drugTypeList.Add(addType);
            }
            if (chkZCY.Checked)
            {
                addType = 2;
                drugTypeList.Add(addType);
            }
            if (chkZY.Checked)
            {
                addType = 3;
                drugTypeList.Add(addType);
            }
            if (chkWZ.Checked)
            {
                addType = 4;
                drugTypeList.Add(addType);
            }
        }
    }
}
