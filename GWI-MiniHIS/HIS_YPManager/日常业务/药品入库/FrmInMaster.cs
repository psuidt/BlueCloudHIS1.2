using System;
using System.Collections;
using System.Collections.Generic;
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
    public partial class FrmInMaster : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private long _currentUserId;
        private long _currentDeptId;
        private string _chineseName;
        private bool _isAudit = false;
        private DataTable _supportDt = new DataTable();
        private DataTable _orderDt = new DataTable();
        private int _supportId = 0;
        private YP_InMaster _currentMaster;
        private DataTable _masterDt;
        private string _belongSystem;
        private BillQuery _billQurey;
        private BillProcessor _billProcessor;
        public FrmInMaster()
        {
            InitializeComponent();
            
        }

        public FrmInMaster(long currentUserId, long currentDeptId, string chineseName, string belongSystem)
        {

            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            _belongSystem = belongSystem;
            this.Text = _chineseName;
            InitializeComponent();
        }

        private void chkSupport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupport.Checked == true)
            {
                this.txtSupport.Enabled = true;
            }
            else 
            {
                this.txtSupport.Enabled = false;
            }
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

        private void chkInvoiceNum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInvoiceNum.Checked == true)
            {
                this.txtInvoiceNum.Enabled = true;
            }
            else
            {
                this.txtInvoiceNum.Enabled = false;
            }
        }

        private void chkBillNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBillNo.Checked)
            {
                this.txtBillNo.Enabled = true;
            }
            else
            {
                this.txtBillNo.Enabled = false;
            }
        }

        private void radAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (radAudit.Checked == true)
            {
                _isAudit = true;
                this.tsrbtnDelBill.Visible = false;
                this.tsrbtnAuditBill.Visible = false;
                this.tsrbtnUpdate.Visible = false;
                this.tsrbtnPay.Visible = true;
                chkRegTime.Text = "审核时间";
            }
            else 
            {
                _isAudit = false;
                chkRegTime.Text = "登记时间";
            }
        }

        private void radNotAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (radNotAudit.Checked == true)
            {
                _isAudit = false;
                this.tsrbtnDelBill.Visible = true;
                this.tsrbtnAuditBill.Visible = true;
                this.tsrbtnUpdate.Visible = true;
                this.tsrbtnPay.Visible = false;
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
            param = new ConditionParam(QueryConditionType.单据号, txtBillNo.Text == "" ? 0 : Convert.ToInt32(txtBillNo.Text), 
                chkBillNo.Checked);
            parameters.Add(QueryConditionType.单据号, param);
            param = new ConditionParam(QueryConditionType.发票号, txtInvoiceNum.Text, chkInvoiceNum.Checked);
            parameters.Add(QueryConditionType.发票号, param);
            param = new ConditionParam(QueryConditionType.供应商ID, _supportId, chkSupport.Checked);
            parameters.Add(QueryConditionType.供应商ID, param);
            return parameters;
        }

        private void LoadData()
        {
            try
            {
                dgrdInMaker.AutoGenerateColumns = false;
                dgrdInOrder.AutoGenerateColumns = false;
                _masterDt = _billQurey.LoadMaster(BuildConditionParams());
                this.dgrdInMaker.DataSource = _masterDt;
                if (chkIsPay.Checked)
                {
                    DataRow[] selectRows = _masterDt.Select("PAY_FLAG=" + cobPayState.SelectedIndex.ToString());
                    if (selectRows.Length > 0)
                    {
                        _masterDt = selectRows.CopyToDataTable();
                        this.dgrdInMaker.DataSource = _masterDt;
                    }
                    else
                    {
                        _masterDt.Rows.Clear();
                    }
                }
                _supportDt = DrugBaseDataBll.LoadSupportInfo();
                txtSupport.SetSelectionCardDataSource(_supportDt);
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
            FrmInorder frmOrder = new FrmInorder(_currentUserId, _currentDeptId, 0, _belongSystem);
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
                    if (MessageBox.Show("您确认要删除所选单据么？", "提示", MessageBoxButtons.OKCancel, 
                        MessageBoxIcon.Question) == DialogResult.OK)
                    {
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
                    _billProcessor.AuditBill(_currentMaster, _currentUserId, _currentDeptId);
                    MessageBox.Show("审核成功,药品已经成功入库,请核查库存......");
                    LoadData();
                }
            }
            catch (Exception error)
            {
                _currentMaster.Audit_Flag = 0;
                MessageBox.Show(error.Message);
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
                case Keys.F5:
                    tsrbtnAuditBill_Click(null, null);
                    break;
                case Keys.F6:
                    tsrbtnBack_Click(null, null);
                    break;
                default:
                    break;
            }
        }



        private void FrmYFInMaster_Load(object sender, EventArgs e)
        {
            try
            {
                chkRegTime.Checked = true;
                cobPayState.SelectedIndex = 0;
                if (_belongSystem == ConfigManager.YF_SYSTEM)
                {
                    _billQurey = BillFactory.GetQuery(ConfigManager.OP_YF_INSTORE);
                    _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_INSTORE);
                    tsrbtnPay.Visible = false;
                    tsrbtnPrintTotal.Visible = false;
                    dgrdInMaker.Columns["ColBtnBackStore"].Visible = false;
                }
                else
                {
                    _billQurey = BillFactory.GetQuery(ConfigManager.OP_YK_INOPTYPE);
                    _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YK_INOPTYPE);
                }
                LoadData();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentMaster == null)
            {
                MessageBox.Show("请选中一行");
                return;
            }
            if (_currentMaster.Audit_Flag == 1)
            {
                MessageBox.Show("已审核单据无法进行修改");
                return;
            }
            FrmInorder frmOrder = new FrmInorder(_currentUserId, _currentDeptId, 1, _belongSystem);
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
                string startPath = Application.StartupPath + "\\report\\药品入库单据.grf";
                PrintFactory.GetPrinter(ConfigManager.OP_YK_INOPTYPE).PrintBill(_currentMaster, _orderDt, startPath, (int)_currentUserId);
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
                    _orderDt = _billQurey.LoadOrder(_currentMaster);
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

        private void txtSupport_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (SelectedValue != null)
            {
                DataRow dr = (DataRow)SelectedValue;
                _supportId = Convert.ToInt32(dr["SupportDicID"]);
                txtSupport.Text = dr["NAME"].ToString();

            }
        }

        /// <summary>
        /// 将数据表中指定位置的记录转成入库表头记录对象
        /// </summary>
        /// <param name="dtTable">
        /// 数据表
        /// </param>
        /// <param name="index">
        /// 对应记录的索引
        /// </param>
        /// <returns>
        /// 转换之后生成的入库表头记录对象
        /// </returns>
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

        private void tsrbtnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentMaster != null)
                {
                    if (_currentMaster.OpType != ConfigManager.OP_YK_INOPTYPE)
                    {
                        MessageBox.Show("该张单据不是采购入库单,采购入库单才可付款");
                        return;
                    }
                    if (_currentMaster.Audit_Flag != 1)
                    {
                        MessageBox.Show("该张入库单未经审核,无法付款");
                        return;
                    }
                    _currentMaster.Pay_Flag = 1;
                    _currentMaster.InvoiceNum = GWMHIS.BussinessLogicLayer.Forms.DlgInputBoxStatic.InputBox("", "请输入发票号",
                        _currentMaster.InvoiceNum);
                    if (_currentMaster.InvoiceNum != "")
                    {
                        _billProcessor.UpdateBill(_currentMaster, null, _currentDeptId);
                        MessageBox.Show("该张入库单已经成功付款,请刷新单据");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnPrintTotal_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                string startPath = Application.StartupPath + "\\report\\入库单汇总.grf";
                YP_Printer.PringInStoreTotal(startPath, _masterDt, cobBeginDate.Value.ToString()
                    + "到" + cobEndDate.Value.ToString(), (int)_currentDeptId, (int)_currentUserId);
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
                    if (_currentMaster.OpType == ConfigManager.OP_YK_BACKSTORE)
                    {
                        MessageBox.Show("退库单无法进行退库。", "退库提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
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
                        _currentMaster.OpType = ConfigManager.OP_YK_BACKSTORE;
                        _billProcessor.SaveBill(_currentMaster, _billQurey.GetBackStoreOrderList(_currentMaster), _currentDeptId);
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

        private void chkIsPay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsPay.Checked)
            {
                cobPayState.Enabled = true;
            }
            else
            {
                cobPayState.Enabled = false;
            }
        }

        private void tsrbtnBack_Click(object sender, EventArgs e)
        {
            FrmInorder frmOrder = new FrmInorder(_currentUserId, _currentDeptId, 2, _belongSystem);
            frmOrder.MdiParent = this.MdiParent;
            frmOrder.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmOrder);
            frmOrder.Show();
        }  
    }
}
