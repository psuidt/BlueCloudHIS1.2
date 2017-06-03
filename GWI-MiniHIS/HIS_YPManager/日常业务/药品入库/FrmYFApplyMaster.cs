using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;
using HIS.Model;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_YPManager
{
    public partial class FrmYFApplyMaster : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private long _currentUserId;
        private long _currentDeptId;
        private string _chineseName;
        private bool _isAudit = false;
        private YP_InMaster _currentMaster;
        private DataTable _masterDt;
        private DataTable _orderDt;
        private BillProcessor _billProcessor;
    
        public FrmYFApplyMaster()
        {
            InitializeComponent();
            
        }

        public FrmYFApplyMaster(long currentUserId, long currentDeptId, string chineseName)
        {

            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            this.Text = _chineseName;
            InitializeComponent();
        }

        private void chkRegTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegTime.Checked == true)
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



        private void radAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (radAudit.Checked == true)
            {
                _isAudit = true;
                this.tsrbtnDelBill.Visible = false;
                this.tsrbtnUpdate.Visible = false;
            }
            else 
            {
                _isAudit = false;
            }
        }

        private void radNotAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (radNotAudit.Checked == true)
            {
                _isAudit = false;
                this.tsrbtnDelBill.Visible = true;
            }
            else
            {
                _isAudit = true;
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
            return parameters;
        }

        private void LoadData()
        {
            try
            {
                dgrdInMaker.AutoGenerateColumns = false;
                dgrdInOrder.AutoGenerateColumns = false;
                _masterDt = BillFactory.GetQuery(ConfigManager.OP_YF_APPLYIN).LoadMaster(BuildConditionParams());
                this.dgrdInMaker.DataSource = _masterDt;
                dgrdInMaker_CurrentCellChanged(null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }



        private void dgrdSupport_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            for (int i = 0; i < ((DataTable)grid.DataSource).DefaultView.Count; i++)
            {
                grid.UnSelect(i);
            }
            grid.Select(grid.CurrentCell.RowNumber);
        }

        private void tsrbtnNew_Click(object sender, EventArgs e)
        {
            FrmSelectOutDept frmSelctDept = new FrmSelectOutDept();
            if (frmSelctDept.ShowDialog() == DialogResult.OK)
            {
                FrmYFApplyorder frmOrder = new FrmYFApplyorder(_currentUserId, _currentDeptId, 0, false);
                frmOrder._outDept.DeptID = frmSelctDept._storeDeptId;
                frmOrder._outDept.DeptName = frmSelctDept._deptName;
                frmOrder._outDept.DeptType1 = "药库";
                frmOrder.MdiParent = this.MdiParent;
                frmOrder.WindowState = FormWindowState.Maximized;
                ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmOrder);
                frmOrder.Show();
            }            
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
                        BillFactory.GetProcessor(_currentMaster.OpType).DelBill(_currentMaster);
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

        private void FrmInMaster_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F2:
                    tsrbtnNew_Click(null, null);
                    break;
                case Keys.F4:
                    tsrbtnDelBill_Click(null, null);
                    break;
                default:
                    break;
            }
        }


        private void FrmYFInMaster_Load(object sender, EventArgs e)
        {
            chkRegTime.Checked = true;
            radNotAudit.Checked = true;
            _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_APPLYIN);
            LoadData();
        }
        private void tsrbtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string startPath = Application.StartupPath + "\\report\\药品入库单据.grf";
                PrintFactory.GetPrinter(ConfigManager.OP_YF_INSTORE).PrintBill(_currentMaster, _orderDt, 
                    startPath, (int)_currentUserId);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdInMaker_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (dgrdInMaker.CurrentCell != null)
                {
                    int currentIndex = dgrdInMaker.CurrentCell.RowIndex;
                    _currentMaster = GetMasterFromDt(_masterDt.DefaultView.ToTable(), currentIndex);
//add  平级药房调拨 张运辉 [20100531]
                    if (_currentMaster.OpType == ConfigManager.OP_YF_PJDB)
                    {
                        _orderDt = BillFactory.GetQuery(ConfigManager.OP_YF_APPLYIN).LoadOrder(_currentMaster);
                        tribmange(false);

                    }
                    else
                    {
                        _orderDt = BillFactory.GetQuery(_currentMaster.OpType).LoadOrder(_currentMaster);
                        tribmange(true);
                    }
                    dgrdInOrder.DataSource = _orderDt;
                }
                else
                {
                    dgrdInOrder.DataSource = null;
                    _currentMaster = null;
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

        private YP_InMaster GetMasterFromDt(DataTable dtTable, int index)
        {

            try
            {
                if (dtTable.Rows.Count < index || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                YP_InMaster currentInmaster = new YP_InMaster();
                currentInmaster.SupportDic = new YP_SupportDic();
                HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dtTable, index, currentInmaster);
                currentInmaster.SupportDic.Name = dtTable.Rows[index]["SupportName"].ToString();
                return currentInmaster;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void tsrbtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentMaster.Audit_Flag == 1)
                {
                    MessageBox.Show("不能对已审核单据进行操作");
                    return;
                }
                FrmSelectOutDept frmSelctDept = new FrmSelectOutDept();
                FrmYFApplyorder frmOrder = new FrmYFApplyorder(_currentUserId, _currentDeptId, 1, false);
                frmOrder._currentMaster = _currentMaster;
                frmOrder._outDept.DeptID = _currentMaster.SupportDicID;
                frmOrder._outDept.DeptName = new Deptment((long)(_currentMaster.SupportDicID)).Name;
                frmOrder._outDept.DeptType1 = "药库";
                frmOrder.MdiParent = this.MdiParent;
                frmOrder.WindowState = FormWindowState.Maximized;
                ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmOrder);
                frmOrder.Show();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdInMaker_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_currentMaster.Audit_Flag == 0 && e.ColumnIndex == dgrdInMaker.Columns["ColBtnBackStore"].Index)
                {
                    MessageBox.Show("该张单据还未审核，不需要退库，可直接进行修改或删除。", "退库提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (e.ColumnIndex == dgrdInMaker.Columns["ColBtnBackStore"].Index)
                {
                    if (MessageBox.Show("您确定要退该张单据么，单据号：" + _currentMaster.BillNum,
                        "退库提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                        _currentMaster.RetailFee = 0;
                        _currentMaster.StockFee = 0;
                        _currentMaster.TradeFee = 0;
                        _currentMaster.Audit_Flag = 0;
                        _currentMaster.AuditPeopleID = 0;
                        _currentMaster.AuditTime = new DateTime();
                        _currentMaster.RegTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                        _currentMaster.RegPeopleID = (int)_currentUserId;
                        _billProcessor.SaveBill(_currentMaster, 
                            BillFactory.GetQuery(ConfigManager.OP_YF_APPLYIN).GetBackStoreOrderList(_currentMaster),_currentMaster.SupportDicID);
                        tsrbtnRefresh_Click(null, null);
                    }
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
//add  平级药房调拨 张运辉 [20100531]
        private void tribmange(bool blIsVisible)
        {


            this.tsrbtnDelBill.Visible = blIsVisible;
            this.tsrbtnUpdate.Visible = blIsVisible;
            
        }
        
    }
}
