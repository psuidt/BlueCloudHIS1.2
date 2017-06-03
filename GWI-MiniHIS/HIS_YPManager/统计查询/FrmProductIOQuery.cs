using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;
using GWMHIS.BussinessLogicLayer;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_YPManager
{
    public partial class FrmProductIOQuery : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User user;
        public FrmProductIOQuery(long currentUserId, long currentDeptId)
        {
            InitializeComponent();
            user = new User(currentUserId);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            StoreQuery _query = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM);
            dgvDetail.DataSource = _query.GetSupportInfo(cobBeginDate.Value, cobEndDate.Value);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string startPath = Application.StartupPath + "\\report\\药品供应商统计单据.grf";
                YP_PrintCondition condition = new YP_PrintCondition();
                condition.actYear = cobBeginDate.Value.ToString();
                condition.actMonth = cobEndDate.Value.ToString();
                condition.userId = Convert.ToInt32(user.EmployeeID);
                PrintFactory.GetPrinter("Support_Report").PrintReport(condition, (DataTable)dgvDetail.DataSource, startPath);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
