using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZDocManager
{
    public partial class FrmWardBedQuery : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public FrmWardBedQuery(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            this.Text = chineseName;
            this.FormTitle = chineseName;
          
            tSBtnQuery_Click(null, null);
        }

        private void tSBtnQuery_Click(object sender, EventArgs e)
        {
            dGVEResult.AutoGenerateColumns = false;
            dGVEResult.DataSource = HIS.MZDoc_BLL.OP_ReportQuery.QueryZyDeptBed();
        }

        private void tSBtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
