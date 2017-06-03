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
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_YPManager
{
    public partial class FrmIOSQuery : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private long _currentUser;
        private long _currentDept;
        private string _chineseName;
        private string _belongSystem;
        private AccountQuery _accountQuery;
        public FrmIOSQuery()
        {
            InitializeComponent();
        }

        public FrmIOSQuery(long currentUser, long currentDept, string chineseName, string belongSystem)
        {
            _currentUser = currentUser;
            _currentDept = currentDept;
            _chineseName = chineseName;
            _belongSystem = belongSystem;
            _accountQuery = AccountFactory.GetQuery(belongSystem);
            InitializeComponent();
        }

        private void cobQueryYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                cobQueryMonth.Focus();
            }
        }

        private void cobQueryMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                cobQueryType.Focus();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                string queryDrugType = cobQueryType.Text;
                int queryYear = Convert.ToInt32(cobQueryYear.Text);
                int queryMonth = Convert.ToInt32(cobQueryMonth.Text);
                dgrdDrugIOS.DataSource = _accountQuery.QueryDrugIOS(queryDrugType, queryYear, queryMonth, (int)_currentDept);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrdDrugIOS.DataSource != null)
                {
                    DataTable printDt = (DataTable)(dgrdDrugIOS.DataSource);
                    string startPath = Application.StartupPath + "\\report\\药品进销存报表.grf";
                    YP_PrintCondition condition = new YP_PrintCondition();
                    condition.actYear = cobQueryYear.Text;
                    condition.actMonth = cobQueryMonth.Text;
                    condition.drugType = cobQueryType.Text;
                    condition.userId = (int)_currentUser;
                    condition.deptId = (int)_currentDept;
                    PrintFactory.GetPrinter("IOS_Report").PrintReport(condition, printDt, startPath);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmIOSQuery_Load(object sender, EventArgs e)
        {
            DateTime currentTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            int currentActYear = 0;
            int currentActMonth = 0;
            _accountQuery.GetAccountTime(currentTime, ref currentActYear, ref currentActMonth, (int)_currentDept);
            cobQueryMonth.Text = currentActMonth.ToString();
            cobQueryYear.Text = currentActYear.ToString();
            cobQueryType.SelectedIndex = 1;
        }

        private void cobQueryType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnQuery.Focus();
            }
        }
    }
}
