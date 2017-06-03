using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using HIS.YP_BLL;
using HIS.Model;


namespace HIS_YPManager
{
    public partial class FrmMonthAccount : GWI.HIS.Windows.Controls.BaseForm
    {

        private YP_AccountHis _lastAccountHis;
        private string _belongSystem = "";
        private long _currentUser;
        private long _currentDept;
        private MonthBalanceProcessor _monthAccount;
        private AccountQuery _accountQuery;
        public FrmMonthAccount()
        {
            InitializeComponent();
        }

        public FrmMonthAccount(string belongSystem, long currentUser, long currentDept)
        {
            _belongSystem = belongSystem;
            _monthAccount = AccountFactory.GetMonthBalancer(belongSystem);
            _accountQuery = AccountFactory.GetQuery(belongSystem);
            _currentUser = currentUser;
            _currentDept = currentDept;
            InitializeComponent();
        }

        private void FrmMonthAccount_Load(object sender, EventArgs e)
        {
            try
            {
                for (int day = 1; day <= 31; day++)
                {
                    cobAccountDay.Items.Add(day.ToString() + "号");
                }
                cobAccountDay.Text = ConfigManager.GetAccountDay((int)_currentDept).ToString() + "号";
                if (_belongSystem == ConfigManager.YF_SYSTEM)
                {
                    btnYKMonthAccount.Enabled = false;
                    ((YF_MonthBalance)_monthAccount).AccountHandler += new MonthAccountHandler(FrmMonthAccount_AccountHandler);
                }
                else
                {
                    btnYFMonthAccount.Enabled = false;
                    ((YK_MonthBalance)_monthAccount).AccountHandler += new MonthAccountHandler(FrmMonthAccount_AccountHandler);
                }
                _lastAccountHis = _accountQuery.GetLastAccountHis((int)_currentDept);
                if (_lastAccountHis != null)
                {
                    cobBeginDate.Value = _lastAccountHis.BeginTime;
                    cobEndDate.Value = _lastAccountHis.EndTime;
                }
                dgrdAccountHis.AutoGenerateColumns = false;
                dgrdAccountHis.DataSource = _accountQuery.GetActHisList((int)_currentDept);
                int currentActMonth = _lastAccountHis.AccountMonth == 12 ? 1 : _lastAccountHis.AccountMonth + 1;
                int currentActYear = _lastAccountHis.AccountMonth == 12 ? _lastAccountHis.AccountYear + 1 : _lastAccountHis.AccountYear;
                lblCurrentActMonth.Text = currentActYear + "年" + currentActMonth + "月";
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        void FrmMonthAccount_AccountHandler(MonthAccountEvent e)
        {
            switch (e.CurrentState)
            {
                case MonthAccountState.SystemChecking:
                    lblState.Text = "系统对账中...";
                    break;
                case MonthAccountState.WriteBeginAccount:
                    lblState.Text = "正在写期初台帐...";
                    break;
                case MonthAccountState.WriteEndAccount:
                    lblState.Text = "正在写期末台帐...";
                    break;
                case MonthAccountState.Over:
                    lblState.Text = "准备...";
                    break;
                case MonthAccountState.WriteAdjAccount:
                    lblState.Text = "正在写调整台帐...";
                    break;
                default:
                    break;
            }
            this.Refresh();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int index = cobAccountDay.Items.IndexOf(cobAccountDay.Text);
                ConfigManager.SetAccountDay(index + 1, (int)_currentDept);
                MessageBox.Show("新的月结时间已经成功设置，如果新设置月结时间在原月结时间之后，可取消月结");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnCancelAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("您确认要取消本月月结么？请先联系系统管理人员。。。（点击“取消”）", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                    DialogResult.OK)
                {
                    lblState.Text = "取消月结中，请等待...";
                    this.Refresh();
                    _monthAccount.CancelMonthAccount((int)_currentUser, (int)_currentDept);
                    lblState.Text = "准备";
                    this.FrmMonthAccount_Load(null, null);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                lblState.Text = "准备";
            }

        }

        private void btnYKMonthAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("您确认要进行药库月结么？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                    DialogResult.OK)
                {
                    this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                    _monthAccount.MonthAccount((int)_currentUser, (int)_currentDept);
                    this.FrmMonthAccount_Load(null, null);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                lblState.Text = "准备";
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
        }

        private void btnYFMonthAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("您确认要进行药房月结么？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                    DialogResult.OK)
                {
                    this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                    _monthAccount.MonthAccount((int)_currentUser, (int)_currentDept);
                    this.FrmMonthAccount_Load(null, null);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                lblState.Text = "准备";
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
        }

        private void btnCheckAccount_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                this.dgrdWrongData.AutoGenerateColumns = false;
                this.dgrdWrongData.DataSource = _monthAccount.SystemCheckAccount((int)_currentDept);
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

        private void btnBalacneAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("您确认要让系统自动帮您平账么？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    == DialogResult.OK)
                {
                    this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                    _monthAccount.BalanceAccount((int)_currentDept);
                }
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

    }
}
