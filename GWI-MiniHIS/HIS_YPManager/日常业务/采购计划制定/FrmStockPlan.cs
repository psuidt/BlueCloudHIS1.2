using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Model;

namespace HIS_YPManager
{
    public partial class FrmStockPlan : GWI.HIS.Windows.Controls.BaseMainForm, IFrmStockPlan
    {
        public FrmStockControl _control;
        private long _currentUserId;
        private long _currentDeptId;
        private bool _isBuildByLimit;

        public FrmStockPlan(long currentUserId, long currentDeptId, bool isBuildByLimit)
        {
            
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _isBuildByLimit = isBuildByLimit;
            InitializeComponent();
        }

        public FrmStockPlan()
        {
            InitializeComponent();
        }

        private void FrmStockPlan_Load(object sender, EventArgs e)
        {
            try
            {
                if (!_isBuildByLimit)
                {
                    _control = new FrmStockControl(this);
                    _control.CurrentState = 0;
                }
                else
                {
                    _control = new FrmStockControl(this);
                    btnNew_Click(null, null);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                _control.LoadPlanMaster(cobBeginDate.Value, cobEndDate.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                _control.PrintBill((int)_currentUserId);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                _control.BuildNewBill(_currentDeptId, _currentUserId, _isBuildByLimit);
                _isBuildByLimit = false;
                _control.CurrentState = 1;
                txtDgCode.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _control.CurrentState = 1;
                txtDgCode.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                _control.DelteBill(cobBeginDate.Value, cobEndDate.Value);
                MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                _control.LoadPlanMaster(cobBeginDate.Value, cobEndDate.Value);
                dgrdPlanMaster_CellMouseDoubleClick(null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                _control.AddOrder();
                MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtDgCode.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrdPlanOrder.CurrentCell != null)
                {
                    _control.UpdateOrder(dgrdPlanOrder.CurrentCell.RowIndex);
                    MessageBox.Show("更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnDelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrdPlanOrder.CurrentCell != null)
                {
                    int rowIndex = dgrdPlanOrder.CurrentCell.RowIndex;
                    if(rowIndex >= 0)
                    {
                        dgrdPlanOrder.CurrentCellChanged -=new EventHandler(dgrdPlanOrder_CurrentCellChanged);
                        _control.DeleteOrder(dgrdPlanOrder.CurrentCell.RowIndex);
                        dgrdPlanOrder.CurrentCellChanged += new EventHandler(dgrdPlanOrder_CurrentCellChanged);
                        
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdPlanOrder_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgrdPlanOrder.CurrentCell != null)
                {
                    _control.GetCurrentOrder(dgrdPlanOrder.CurrentCell.RowIndex);
                    
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdPlanMaster_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgrdPlanMaster.CurrentCell != null)
                {
                    int index = dgrdPlanMaster.CurrentCell.RowIndex;
                    if (index > -1)
                    {
                        int masterId = Convert.ToInt32(dgrdPlanMaster["PLANMASTERID", index].Value);
                        _control.GetCurrentMaster(masterId);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtDgCode_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (SelectedValue != null)
            {
                DataRow selectRow = (DataRow)SelectedValue;
                _control._currentOrder.MakerDicId = Convert.ToInt32(selectRow["MAKERDICID"]);
                _control._currentOrder.RetailPrice = Convert.ToDecimal(selectRow["RETAILPRICE"]);
                _control._currentOrder.TradePrice = Convert.ToDecimal(selectRow["TRADEPRICE"]);
                _control._currentOrder.Unit = Convert.ToInt32(selectRow["PACKUNIT"]);
                _control._currentOrder.UnitName = selectRow["UNITNAME"].ToString();
                _control._currentOrder._orderRemark._chemName = selectRow["CHEMNAME"].ToString();
                _control._currentOrder._orderRemark._drugSpe = selectRow["SPEC"].ToString();
                _control._currentOrder._orderRemark._productName = selectRow["PRODUCTNAME"].ToString();
                ShowCurrentOrder(_control._currentOrder);
            }
        }

        #region 界面接口实现
        public void RefreshMaster(DataTable masterDt)
        {
            if (masterDt != null)
            {
                dgrdPlanMaster.AutoGenerateColumns = false;
                dgrdPlanMaster.DataSource = masterDt;
            }
        }
        public void RefreshOrder(DataTable orderDt)
        {
            if (orderDt != null)
            {
                dgrdPlanOrder.AutoGenerateColumns = false;
                dgrdPlanOrder.DataSource = orderDt;
            }
        }
        public void ChangeCurrentState(int currentState)
        {
            if (currentState == 0)
            {
                btnQuery.Enabled = true;
                btnPrint.Enabled = true;
                btnNew.Enabled = true;
                btnDel.Enabled = true;
                btnUpdate.Enabled = true;
                btnAddOrder.Visible = false;
                btnDelOrder.Visible = false;
                btnUpdateOrder.Visible = false;
                btnSaveBill.Visible = false;
                btnCancelSave.Visible = false;
                txtDgCode.ReadOnly = true;
                txtNum.ReadOnly = true;
            }
            else
            {
                btnQuery.Enabled = false;
                btnPrint.Enabled = false;
                btnNew.Enabled = false;
                btnDel.Enabled = false;
                btnUpdate.Enabled = false;
                btnAddOrder.Visible = true;
                btnDelOrder.Visible = true;
                btnUpdateOrder.Visible = true;
                btnSaveBill.Visible = true;
                btnCancelSave.Visible = true;
                txtDgCode.ReadOnly = false;
                txtNum.ReadOnly = false;
            }
        }
        public void ClearAll()
        {
            txtDgCode.Clear();
            txtChemName.Clear();
            txtNum.Clear();
            txtProductName.Clear();
            txtSpec.Clear();
            txtTradePrice.Clear();
            txtRetailPrice.Clear();
            txtUnit.Text = "";
        }
        public void ShowCurrentOrder(YP_PlanOrder order)
        {
            if (order != null)
            {
                txtChemName.Text = order._orderRemark._chemName;
                txtNum.Text = order.StockNum.ToString("0.00");
                txtProductName.Text = order._orderRemark._productName;
                txtSpec.Text = order._orderRemark._drugSpe;
                txtTradePrice.Text = order.TradePrice.ToString("0.00");
                txtRetailPrice.Text = order.RetailPrice.ToString("0.00");
                txtUnit.Text = order.UnitName;
            }
        }
        public void RefreshDurgInfo(DataTable drugInfo)
        {
            try
            {
                txtDgCode.SetSelectionCardDataSource(drugInfo);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        public void RefreshFee(decimal totalRetailFee, decimal totalTradeFee)
        {
            this.lblRtialFee.Text = totalRetailFee.ToString("0.00");
            this.lblTradeFee.Text = totalTradeFee.ToString("0.00");
        }
        #endregion

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            if (txtNum.Text != "")
            {
                _control._currentOrder.StockNum = Convert.ToDecimal(txtNum.Text);
            }
        }

        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            try
            {
                _control.SaveBill();
                MessageBox.Show("采购单已成功保存", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                _control.LoadPlanMaster(cobBeginDate.Value, cobEndDate.Value);
                dgrdPlanMaster_CellMouseDoubleClick(null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnCancelSave_Click(object sender, EventArgs e)
        {
            try
            {
                _control.CancelSaveBill();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }        
    }
}
