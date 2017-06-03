using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Model;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS_YPManager
{
    public partial class FrmOutMaster : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private long _currentUserId;
        private long _currentDeptId;
        private string _chineseName;
        private bool _isAudit = false;
        private DataTable _outMasterDt;
        private DataTable _orderDt;
        private YP_OutMaster _currentMaster;
        private string _belongSystem;
        private BillProcessor _billProcessor;
        private BillQuery _billQuery;
        public FrmOutMaster()
        {
            InitializeComponent();
        }

        public FrmOutMaster(long currentUserId, long currentDeptId, string chineseName, string belongSystem)
        {

            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            this.Text = _chineseName;
            _belongSystem = belongSystem;
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                _billQuery = BillFactory.GetQuery(ConfigManager.DEF_YK_OUT);
            }
            else
            {
                _billQuery = BillFactory.GetQuery(ConfigManager.DEF_YF_OUT);
            }
            InitializeComponent();
        }

        private void chkRegTime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkRegTime.Checked == true)
            {
                this.cobBeginDate.Enabled = true;
                this.cobEndDate.Enabled = true;
            }
            else 
            {
                this.cobBeginDate.Enabled = false;
                this.cobEndDate.Enabled = false;
            }
        }

        private void chkOpType_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkOpType.Checked == true)
            {
                this.cobOpType.Enabled = true;
            }
            else 
            {
                this.cobOpType.Enabled = false;
            }
        }

        private void chkBillNum_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBillNum.Checked == true)
            {
                this.txtBillNum.Enabled = true;
            }
            else 
            {
                this.txtBillNum.Enabled = false;
            }
        }

        private void FrmOutMaster_Load(object sender, EventArgs e)
        {
            try
            {
                
                this.cobOpType.Text = "药品报损";
                this.txtBillNum.Enabled = false;
                chkRegTime.Checked = true;
                LoadData();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        /// <summary>
        /// 构建查询条件列表
        /// </summary>
        private Hashtable BuildConditionParams()
        {
            Hashtable parameters = new Hashtable();
            ConditionParam param = new ConditionParam(QueryConditionType.是否审核, _isAudit == false ? 0 : 1, true);
            parameters.Add(QueryConditionType.是否审核, param);
            param = new ConditionParam(QueryConditionType.开始时间, cobBeginDate.Value, chkRegTime.Checked);
            parameters.Add(QueryConditionType.开始时间, param);
            param = new ConditionParam(QueryConditionType.结束时间, cobEndDate.Value, chkRegTime.Checked);
            parameters.Add(QueryConditionType.结束时间, param);
            param = new ConditionParam(QueryConditionType.部门ID, (int)_currentDeptId, true);
            parameters.Add(QueryConditionType.部门ID, param);
            param = new ConditionParam(QueryConditionType.单据号, txtBillNum.Text == "" ? 0 : Convert.ToInt32(txtBillNum.Text), chkBillNum.Checked);
            parameters.Add(QueryConditionType.单据号, param);
            string opType = "";
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                if (cobOpType.Text == "报损出库")
                {
                    opType = ConfigManager.OP_YK_REPORTLOSS;
                }
                else if (cobOpType.Text == "科室领药")
                {
                    opType = ConfigManager.OP_YK_DEPTDRAW;
                }
                else
                {
                    opType = ConfigManager.OP_YK_OUTTOYF;
                }
            }
            else
            {
                if (cobOpType.Text == "报损出库")
                {
                    opType = ConfigManager.OP_YF_REPORTLOSS;
                }
                else if (cobOpType.Text == "科室领药")
                {
                    opType = ConfigManager.OP_YF_DEPTDRAW;
                }
            }
            param = new ConditionParam(QueryConditionType.业务类型, opType, chkOpType.Checked);
            parameters.Add(QueryConditionType.业务类型, param);
            return parameters;
        }

        private void LoadData()
        {
            try
            {
                dgrdOutMaster.AutoGenerateColumns = false;
                dgrdOutOrder.AutoGenerateColumns = false;
                _outMasterDt = _billQuery.LoadMaster(BuildConditionParams());
                this.dgrdOutMaster.DataSource = _outMasterDt;

                dgrdOutMaster_CurrentCellChanged(null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void radAudit_CheckedChanged(object sender, EventArgs e)
        {
            this._isAudit = true;
            this.tsrbtnDelBill.Visible = false;
            this.tsrbtnAuditBill.Visible = false;
            this.tsrbtnUpdate.Visible = false;
            chkRegTime.Text = "审核时间";
        }

        private void radNotAudit_CheckedChanged(object sender, EventArgs e)
        {
            this._isAudit = false;
            this.tsrbtnDelBill.Visible = true;
            this.tsrbtnAuditBill.Visible = true;
            this.tsrbtnUpdate.Visible = true;
            chkRegTime.Text = "登记时间";
        }

        private void tsrbtnReportLoss_Click(object sender, EventArgs e)
        {
            FrmOutOrder frmOrder;
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                frmOrder = new FrmOutOrder(_currentUserId, _currentDeptId, 0, ConfigManager.OP_YK_REPORTLOSS, _belongSystem);
            }
            else 
            {
                frmOrder = new FrmOutOrder(_currentUserId, _currentDeptId, 0, ConfigManager.OP_YF_REPORTLOSS, _belongSystem);
            }
            frmOrder.MdiParent = this.MdiParent;
            frmOrder.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmOrder);
            frmOrder.Show();
        }

        private void tsrbtnDeptDraw_Click(object sender, EventArgs e)
        {
            FrmOutOrder frmOrder;
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                frmOrder = new FrmOutOrder(_currentUserId, _currentDeptId, 0, ConfigManager.OP_YK_DEPTDRAW, _belongSystem);
            }
            else
            {
                frmOrder = new FrmOutOrder(_currentUserId, _currentDeptId, 0, ConfigManager.OP_YF_DEPTDRAW, _belongSystem);
            }
            frmOrder.MdiParent = this.MdiParent;
            frmOrder.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmOrder);
            frmOrder.Show();

        }

        private void tsrbtnDelBill_Click(object sender, EventArgs e)
        {
            if (_currentMaster == null)
            {
                MessageBox.Show("请选中一行");
                return;
            }
            if (_currentMaster.Audit_Flag == 1)
            {
                MessageBox.Show("不能对已审核单据进行操作");
                return;
            }
            else
            {
                try
                {
                    if (MessageBox.Show("您确认要删除所选单据么？", "提示",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        _billProcessor = BillFactory.GetProcessor(_currentMaster.OpType);
                        _billProcessor.DelBill(_currentMaster);
                        LoadData();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    return;
                }
            }
        }

        private void tsrbtnAuditBill_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (ConfigManager.IsChecking(_currentDeptId))
                {
                    MessageBox.Show("药品正在盘点中......");
                    return;
                }
                if (_currentMaster == null)
                {
                    MessageBox.Show("请选中一行");
                    return;
                }
                if (_currentMaster.Audit_Flag == 1)
                {
                    MessageBox.Show("不能对已审核单据进行操作");
                    return;
                }
                else
                {
                    _billProcessor = BillFactory.GetProcessor(_currentMaster.OpType);
                    _billProcessor.AuditBill(_currentMaster, _currentUserId, _currentDeptId);
                    MessageBox.Show("审核成功，请及时核查库存...");
                    LoadData();
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

        private void tsrbtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsrbtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void FrmOutMaster_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F4:
                    tsrbtnDelBill_Click(null, null);
                    break;
                case Keys.F5:
                    tsrbtnAuditBill_Click(null, null);
                    break;
                case Keys.F6:
                    tsrbtnReportLoss_Click(null, null);
                    break;
                case Keys.F7:
                    tsrbtnDeptDraw_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void tsrbtnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentMaster == null)
            {
                MessageBox.Show("请选中一行");
                return;
            }
            if (_currentMaster.Audit_Flag == 1 || _currentMaster.OpType == ConfigManager.OP_YK_OUTTOYF)
            {
                MessageBox.Show("无法对单据进行该操作");
                return;
            }

            FrmOutOrder frmOrder = new FrmOutOrder(_currentUserId, _currentDeptId, 1, _currentMaster.OpType, _belongSystem);
            frmOrder.MdiParent = this.MdiParent;
            frmOrder.WindowState = FormWindowState.Maximized;
            frmOrder._currentMaster = _currentMaster;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmOrder);
            frmOrder.Show();
        }

        private void tsrbtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string startPath = Application.StartupPath;
                PrintFactory.GetPrinter(ConfigManager.OP_YK_DEPTDRAW).PrintBill(_currentMaster, _orderDt, startPath
                    ,(int)_currentUserId);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdOutMaster_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgrdOutMaster.CurrentCell != null)
                {
                    int currentIndex = dgrdOutMaster.CurrentCell.RowIndex;
                    _currentMaster = GetOutMasterFromDt(_outMasterDt.DefaultView.ToTable(), currentIndex);                    
                    _orderDt = _billQuery.LoadOrder(_currentMaster);
                    dgrdOutOrder.DataSource = _orderDt;
                }
                else
                {
                    dgrdOutOrder.DataSource = null;
                    _currentMaster = null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        /// <summary>
        /// 从出库信息表中读取出库表头对象
        /// </summary>
        /// <param name="dtTable">出库表头信息表</param>
        /// <param name="index">指定行记录索引</param>
        /// <returns>出库表头对象</returns>
        private YP_OutMaster GetOutMasterFromDt(DataTable dtTable, int index)
        {

            try
            {
                if (dtTable.Rows.Count < index || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                YP_OutMaster currentOutmaster = new YP_OutMaster();
                HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dtTable, index, currentOutmaster);
                return currentOutmaster;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
