using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Model;
using HIS.YP_BLL;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_YPManager
{
    public partial class FrmInorder : GWI.HIS.Windows.Controls.BaseMainForm
    {
        const int DEFMONTH = 2;
        public YP_InMaster _currentMaster;
        private YP_InOrder _currentOrder;
        private long _currentUserId;
        private long _currentDeptId;
        private DataTable _supportDt;
        private DataTable _drugInfoDt;
        private DataTable _inOrderDt;
        private string _belongSystem;
        private BillProcessor _billProcessor;
        private BillQuery _billQuery;
        private StoreQuery _storeQuery;
        private DataTable _batchDt;
        /// <summary>
        /// 新增入库单据状态
        /// </summary>
        const int ADD = 0;
        /// <summary>
        /// 修改单据状态
        /// </summary>
        const int UPDATE = 1;
        /// <summary>
        /// 新增退库单状态
        /// </summary>
        const int BACK = 2;
        /// <summary>
        /// 当前状态
        /// </summary>
        public int _currentState;
        public FrmInorder()
        {
            InitializeComponent();
        }

        public FrmInorder(long currentUserId, long currentDeptId, int beginState, string belongSystem)
        {
            
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _currentState = beginState;
            _belongSystem = belongSystem;
            _storeQuery = StoreFactory.GetQuery(belongSystem);
            //生成一个新的单据表头
            InitializeComponent();
            //设置起始焦点
            
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                ComputeFeeAndNum();
                if (CheckSaveOrder() == true)
                {
                    
                    AddOrderToDT(_currentOrder, _inOrderDt);
                    ClearOrderTextbox();
                    _currentOrder = (YP_InOrder)(_billProcessor.BuildNewoder(_currentMaster.DeptID, _currentMaster));
                    //设置金额初始值
                    this.txtStockFee.Text = "0.00";
                    this.txtDefStockPrice.Text = "0.000";
                    this.txtDgCode.Focus();
                }
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
                ComputeFeeAndNum();
                if (CheckSaveOrder() == true)
                {
                    if (_currentOrder == null || _inOrderDt.Rows.Count == 0 || dgrdInOrder.CurrentCell == null)
                    {
                        MessageBox.Show("请选中数据");
                        return;
                    }
                    else
                    {
                        DataRow currentRow = _inOrderDt.Rows[dgrdInOrder.CurrentCell.RowIndex];
                        orderToDataRow(currentRow, _currentOrder);
                    }
                    MessageBox.Show("更新成功");
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
                if (_currentOrder == null || _inOrderDt.Rows.Count == 0 || dgrdInOrder.CurrentCell == null)
                {
                    MessageBox.Show("没有选中数据");
                    return;
                }
                else
                {
                    _inOrderDt.Rows.RemoveAt(dgrdInOrder.CurrentCell.RowIndex);
                   
                    if (dgrdInOrder.CurrentCell == null)
                    {
                        _currentOrder = (YP_InOrder)(_billProcessor.BuildNewoder(_currentMaster.DeptID, _currentMaster));
                        ClearOrderTextbox();
                    }

                    else if (dgrdInOrder.CurrentCell.RowIndex > _inOrderDt.Rows.Count - 1)
                    {
                        dgrdInOrder.CurrentCell = dgrdInOrder[dgrdInOrder.CurrentCell.ColumnIndex, dgrdInOrder.CurrentCell.RowIndex - 1]; 
                    }
                    else
                    {
                        DataRowToorder(_inOrderDt.Rows[dgrdInOrder.CurrentCell.RowIndex], _currentOrder);
                        ShowCurrentOrder();
                    }
                }
                MessageBox.Show("删除成功");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtInvoiceNum_TextChanged(object sender, EventArgs e)
        {
            if (XcConvert.IsInteger(this.txtInvoiceNum.Text.Trim()))
            {
                _currentMaster.InvoiceNum = this.txtInvoiceNum.Text;
            }
            else
            {
                this.txtInvoiceNum.Text = "";
                _currentMaster.InvoiceNum = "";
            }
        }

        private void txtInvoiceNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (_belongSystem == ConfigManager.YK_SYSTEM)
                {
                    this.txtDeliverNum.Focus();
                }
                else
                {
                    this.txtDgCode.Focus();
                }
            }
        }

        private void txtDeliverNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txtDgCode.Focus();
            }

        }

        private void txtDeliverNum_TextChanged(object sender, EventArgs e)
        {
            _currentMaster.DeliverNum = Convert.ToInt16( this.txtDeliverNum.Text.Trim().ToString());
        }


        private void LoadData()
        {
            dgrdInOrder.AutoGenerateColumns = false;
            _supportDt = DrugBaseDataBll.LoadSupportInfo();
            _drugInfoDt = DrugBaseDataBll.YD_LoadDrugInfo((int)_currentDeptId);
            txtSupport.SetSelectionCardDataSource(_supportDt);
            txtDgCode.SetSelectionCardDataSource(_drugInfoDt);
            _inOrderDt = _billQuery.LoadOrder(_currentMaster);
            dgrdInOrder.DataSource = _inOrderDt;
            _batchDt = _storeQuery.LoadBatch((int)_currentDeptId);

        }

        private void ShowCurrentMaster()
        {
            if (_currentMaster != null)
            {
                this.txtSupport.Text = XcConvert.IsNull(_currentMaster.SupportDic.Name, "");
                this.txtInvoiceNum.Text = XcConvert.IsNull(_currentMaster.InvoiceNum, "");
                this.cobBillTime.Value = _currentMaster.BillDate;
                this.cobInvoiceTime.Value = _currentMaster.InvoiceDate;
                this.txtDeliverNum.Text = XcConvert.IsNull(_currentMaster.DeliverNum, "");
                this.txtRemark.Text = _currentMaster.ReMark;
            }
        }

        private void ShowDrugInfo()
        {
            try
            {
                this.txtDgName.Text = _currentOrder.MakerDic.DrugInfo.chemname;
                this.txtDgSpec.Text = _currentOrder.MakerDic.DrugInfo.spec;
                this.txtProduct.Text = _currentOrder.MakerDic.DrugInfo.productname;
                this.txtRetailPrice.Text = _currentOrder.RetailPrice.ToString();
                this.txtTradePrice.Text = _currentOrder.TradePrice.ToString();               
                this.txtDefStockPrice.Text = _currentOrder.MakerDic.DefStockPrice.ToString();
                this.txtStockPrice.Text = _currentOrder.StockPrice.ToString();
                decimal currentNum = 0;
                if (_belongSystem == ConfigManager.YF_SYSTEM)
                {
                    currentNum = _storeQuery.QueryNum(_currentOrder.MakerDicID, _currentOrder.DeptID);
                    if (currentNum < 0)
                    {
                        currentNum = 0;
                    }
                    this.txtSmallUnit.Text = _currentOrder.LeastUnitEntity.UnitName;
                }
                else
                {                   
                    currentNum = _storeQuery.QueryNum(_currentOrder.MakerDicID, _currentOrder.DeptID);
                    this.txtPackUnit.Text = _currentOrder.LeastUnitEntity.UnitName;
                }
                this.txtCurrentNum.Text = currentNum.ToString("0.00");
                this.cobValidityDate.Value = _currentOrder.ValidityDate;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void ShowCurrentOrder()
        {
            ShowDrugInfo();
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                this.txtInNum.Text = Convert.ToInt32(_currentOrder.InNum).ToString();
            }
            else
            {
                this.txtBaseNum.Text = (Convert.ToInt32(_currentOrder.InNum) % Convert.ToInt32(_currentOrder.UnitNum)).ToString();
                this.txtInNum.Text = (Convert.ToInt32(_currentOrder.InNum)/ Convert.ToInt32(_currentOrder.UnitNum)).ToString();
            }
            this.txtStockPrice.Text = _currentOrder.StockPrice.ToString();
            this.txtStockFee.Text = _currentOrder.StockFee.ToString();
            this.txtBatchNum.Text = _currentOrder.BatchNum;
        }

        private bool CheckSaveBill()
        {
            if (_currentMaster.SupportDicID == 0)
            {
                MessageBox.Show("请输入供应商名称");
                txtSupport.Focus();
                txtSupport.SelectAll();
                return false;
            }
            if (_inOrderDt.Rows.Count < 1)
            {
                MessageBox.Show("没有要入库的药品");
                return false;
            }
            return true;
        }

        private bool CheckSaveOrder()
        {
            if (_currentOrder == null)
            {
                MessageBox.Show("请选择明细信息");
                return false;
            }
            if (_currentOrder.MakerDicID == 0)
            {
                MessageBox.Show("请选择药品信息");
                txtDgCode.Focus();
                txtDgCode.SelectAll();
                return false;
            }
            if (_currentOrder.InNum == 0)
            {
                MessageBox.Show("请输入入库数量");
                txtInNum.Focus();
                txtInNum.SelectAll();
                return false;
            }
            if (_currentOrder.StockPrice == 0)
            {
                MessageBox.Show("请输入进价");
                txtStockPrice.Focus();
                txtStockPrice.SelectAll();
                return false;
            }
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                if (_currentOrder.BatchNum == "" || _currentOrder.BatchNum == null)
                {
                    MessageBox.Show("请输入批次号");
                    txtBatchNum.Focus();
                    return false;
                }
            }
            return true;
        }

        private void cobValidityDate_ValueChanged(object sender, EventArgs e)
        {
            _currentOrder.ValidityDate = cobValidityDate.Value;
        }

        private void dgrdInOrder_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgrdInOrder.CurrentCell != null)
                {
                    int currentIndex = dgrdInOrder.CurrentCell.RowIndex;
                    DataRowToorder(_inOrderDt.DefaultView.ToTable().Rows[currentIndex], _currentOrder);
                    ShowCurrentOrder();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void ClearOrderTextbox()
        {
            this.txtDgCode.Clear();
            this.txtDgName.Clear();
            this.txtDgSpec.Clear();
            this.txtProduct.Clear();
            this.txtPackUnit.Clear();
            this.txtInNum.Clear();
            this.txtBaseNum.Clear();
            this.txtTradePrice.Clear();
            this.txtRetailPrice.Clear();
            this.txtStockPrice.Clear();
            this.txtStockFee.Clear();
            this.txtDefStockPrice.Clear();
            this.txtCurrentNum.Clear();
            this.txtBatchNum.Clear();
            this.txtSmallUnit.Clear();
            this.cobValidityDate.Value = _currentMaster.RegTime.AddMonths(2);
        }

        private void CreateProcessorBySystem()
        {
            if (_belongSystem == ConfigManager.YF_SYSTEM)
            {
                _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_INSTORE);
                _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_INSTORE);
                this.txtBatchNum.ReadOnly = true;
                this.chkIsFirstIn.Visible = false;
                this.txtBaseNum.ReadOnly = false;
                this.txtDeliverNum.Visible = false;
                this.lblDeliverNum.Visible = false;
                this.txtInNum.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
                this.btnQuerySupportHis.Visible = false;
            }
            else
            {
                if (_currentState == ADD)
                {
                    _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YK_INOPTYPE);
                    this.chkIsFirstIn.Visible = true;
                }
                else if (_currentState == BACK)
                {
                    _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YK_BACKSTORE);
                    this.chkIsFirstIn.Visible = false;
                }
                else if(_currentState == UPDATE)
                {
                    if (_currentMaster != null)
                    {
                        _billProcessor = BillFactory.GetProcessor(_currentMaster.OpType);
                    }
                    this.chkIsFirstIn.Visible = (_currentMaster.OpType == ConfigManager.OP_YK_BACKSTORE ? false : true);
                }
                _billQuery = BillFactory.GetQuery(ConfigManager.OP_YK_INOPTYPE);
                this.txtBaseNum.ReadOnly = true;
                this.txtDeliverNum.Visible = true;
                this.btnQuerySupportHis.Visible = true;
            }
        }
        private void FrmInorder_Load(object sender, EventArgs e)
        {
            CreateProcessorBySystem();
            //如果是添加单据状态
            if (_currentState == ADD || _currentState == BACK)
            {
                _currentMaster = (YP_InMaster)(_billProcessor.BuildNewMaster(_currentDeptId, _currentUserId));
                _currentOrder = (YP_InOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
                LoadData();
                //设置金额初始值
                this.txtStockFee.Text = "0.00";
                this.txtStockPrice.Text = "0.000";
                this.txtDefStockPrice.Text = "0.000";
            }
            else if (_currentState == UPDATE)
            {
                _currentOrder = (YP_InOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
                LoadData();
                dgrdInOrder_CurrentCellChanged(null, null);
            }
            if (_currentMaster.OpType == ConfigManager.OP_YK_BACKSTORE)
            {
                this.FormTitle = "退库单据";
            }
            //显示当前表头信息
            ShowCurrentMaster();
            this.txtSupport.Focus();
        }

        private void tsrbtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsrbtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                //生成一个新的单据表头
                if (_belongSystem == ConfigManager.YF_SYSTEM)
                {
                    _currentMaster = (YP_InMaster)(_billProcessor.BuildNewMaster(_currentDeptId, _currentUserId));
                    _currentOrder = (YP_InOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
                    _inOrderDt = BillFactory.GetQuery(ConfigManager.OP_YF_INSTORE).LoadOrder(_currentMaster);
                }
                else
                {
                    _currentMaster = (YP_InMaster)(_billProcessor.BuildNewMaster(_currentDeptId, _currentUserId));
                    _currentOrder = (YP_InOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
                    _inOrderDt = BillFactory.GetQuery(ConfigManager.OP_YK_INOPTYPE).LoadOrder(_currentMaster);
                }
                //加载数据              
                dgrdInOrder.DataSource = _inOrderDt;
                ClearOrderTextbox();
                ShowCurrentMaster();
                //设置金额初始值
                txtStockFee.Text = "0.00";
                txtStockPrice.Text = "0.000";
                txtDefStockPrice.Text = "0.000";
                if (_currentMaster.OpType == ConfigManager.OP_YK_BACKSTORE)
                    _currentState = BACK;
                else
                    _currentState = ADD;
                this.txtSupport.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckSaveBill() == true)
                {
                    List<BillOrder> listOrder = GetListOrder();
                    if (_currentState == ADD || _currentState == BACK)
                    {
                        _billProcessor.SaveBill(_currentMaster, listOrder, _currentDeptId);
                    }
                    else
                    {
                        _billProcessor.UpdateBill(_currentMaster, listOrder, _currentDeptId);
                    }
                    tsrbtnNew_Click(null, null);
                    MessageBox.Show("单据成功保存，请及时对单据进行审核以确保药品成功入库");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void FrmInorder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F2:
                    tsrbtnNew_Click(null, null);
                    break;
                case Keys.F3:
                    tsrbtnSave_Click(null, null);
                    break;
                case Keys.F5:
                    btnQuerySupportHis_Click(null, null);
                    break;
                default:
                    break;
            }
        }
        



        private void dgrdInOrder_CurrentCellChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (dgrdInOrder.CurrentCell != null)
                {
                    int currentIndex = dgrdInOrder.CurrentCell.RowIndex;
                    DataRowToorder(_inOrderDt.DefaultView.ToTable().Rows[currentIndex], _currentOrder);
                    ShowCurrentOrder();
                    if (_batchDt != null)
                    {
                        txtBatchNum.SetSelectionCardDataSource(FilterBatchDt(_currentOrder.MakerDicID));
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtSupport_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtSupport.ReadOnly == true)
            {
                return;
            }
            _currentMaster.SupportDicID = Convert.ToInt32(txtSupport.MemberValue);
        }

        private void txtDgCode_AfterSelectedRow(object sender, object SelectedValue)
        {
            try
            {
                if (txtDgCode.ReadOnly == true)
                {
                    return;
                }
                DataRow dr = (DataRow)SelectedValue;
                _currentOrder.MakerDic.MakerDicID = Convert.ToInt32(dr["MAKERDICID"]);
                _currentOrder.MakerDicID = Convert.ToInt32(dr["MAKERDICID"]);
                if (_belongSystem == ConfigManager.YK_SYSTEM)
                {
                    _currentOrder.LeastUnit = Convert.ToInt32(dr["PACKUNIT"]);
                    _currentOrder.LeastUnitEntity.UnitName = dr["UNITNAME"].ToString();
                    txtSmallUnit.Text = dr["SUNITNAME"].ToString();                   
                }
                else
                {
                    _currentOrder.LeastUnit = Convert.ToInt32(dr["UNIT"]);
                    _currentOrder.LeastUnitEntity.UnitName = dr["SUNITNAME"].ToString(); 
                    txtPackUnit.Text = dr["UNITNAME"].ToString();
                }
                _currentOrder.UnitNum = Convert.ToInt32(dr["PACKNUM"]);
                _currentOrder.MakerDic.DrugInfo.chemname = dr["CHEMNAME"].ToString();
                _currentOrder.MakerDic.DrugInfo.spec = dr["SPEC"].ToString();
                _currentOrder.MakerDic.DrugInfo.productname = dr["PRODUCTNAME"].ToString();
                _currentOrder.RetailPrice = Convert.ToDecimal(dr["RETAILPRICE"]);
                _currentOrder.TradePrice = Convert.ToDecimal(dr["TRADEPRICE"].ToString());
                _currentOrder.ValidityDate = _currentMaster.RegTime.AddMonths(DEFMONTH);               
                _currentOrder.MakerDic.DefStockPrice = Convert.ToDecimal(dr["DEFSTOCKPRICE"]);
                _currentOrder.StockPrice = Convert.ToDecimal(dr["DEFSTOCKPRICE"]);
                _currentOrder.ValidityDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.AddMonths(
                    2);
                //过滤药品批次表
                txtBatchNum.SetSelectionCardDataSource(FilterBatchDt(_currentOrder.MakerDicID));
                ShowDrugInfo();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private DataTable FilterBatchDt(int makerDicId)
        {
            if (_batchDt != null)
            {
                DataTable selectBatch = _batchDt.Clone();
                DataRow[] drs = _batchDt.Select("MAKERDICID=" + makerDicId.ToString());
                foreach (DataRow batchDr in drs)
                {
                    selectBatch.Rows.Add(batchDr.ItemArray);
                }
                return selectBatch;
            }
            else
            {
                return _batchDt;
            }
        }

        /// <summary>
        /// 将指定数据表中的行记录值赋给入库明细记录对象
        /// </summary>
        /// <param name="dR">指定行记录</param>
        /// <param name="inOrder">入库明细记录对象</param>
        private void DataRowToorder(DataRow dR, YP_InOrder inOrder)
        {
            try
            {
                if (dR == null || inOrder == null)
                {
                    return;
                }
                else
                {
                    inOrder.Audit_Flag = Convert.ToInt32(dR["Audit_Flag"]);
                    inOrder.BillNum = Convert.ToInt32(dR["BillNum"]);
                    inOrder.DeliverNum = dR["DeliverNum"].ToString();
                    inOrder.DeptID = Convert.ToInt32(dR["DeptID"]);
                    inOrder.InNum = Convert.ToDecimal(dR["InNum"]);
                    inOrder.InStorageID = Convert.ToInt32(dR["InStorageID"]);
                    inOrder.LeastUnit = Convert.ToInt32(dR["LeastUnit"]);
                    inOrder.MakerDicID = Convert.ToInt32(dR["MakerDicID"]);
                    inOrder.MasterInStorageID = Convert.ToInt32(dR["MasterInStorageID"]);
                    inOrder.BatchNum = dR["BatchNum"].ToString();
                    inOrder.RecScale = Convert.ToDecimal(dR["RecScale"]);
                    inOrder.Remark = dR["Remark"].ToString();
                    inOrder.RetailFee = Convert.ToDecimal(dR["RetailFee"]);
                    inOrder.RetailPrice = Convert.ToDecimal(dR["RetailPrice"]);
                    inOrder.StockFee = Convert.ToDecimal(dR["StockFee"]);
                    inOrder.StockPrice = Convert.ToDecimal(dR["StockPrice"]);
                    inOrder.TradeFee = Convert.ToDecimal(dR["TradeFee"]);
                    inOrder.TradePrice = Convert.ToDecimal(dR["TradePrice"]);
                    inOrder.UnitNum = Convert.ToInt32(dR["UnitNum"]);
                    inOrder.ValidityDate = Convert.ToDateTime(dR["ValidityDate"]);
                    inOrder.MakerDic.DrugInfo.spec = dR["SPEC"].ToString();
                    inOrder.MakerDic.DrugInfo.chemname = dR["CHEMNAME"].ToString();
                    inOrder.LeastUnitEntity.UnitName = dR["UNITNAME"].ToString();
                    inOrder.MakerDic.DrugInfo.productname = dR["PRODUCTNAME"].ToString();
                    inOrder.MakerDic.DefStockPrice = Convert.ToDecimal(dR["DefStockPrice"]);
                    if (dR["CurrentNum"] != DBNull.Value)
                    {
                        inOrder.CurrentNum = Convert.ToDecimal(dR["CurrentNum"]);
                    }
                    else
                    {
                        inOrder.CurrentNum = 0;
                    }
                }
                return;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 将入库明细记录对象的值赋给数据表行记录
        /// </summary>
        /// <param name="dR">指定数据行记录</param>
        /// <param name="inOrder">入库明细记录对象</param>
        private void orderToDataRow(DataRow dR, YP_InOrder inOrder)
        {
            try
            {
                if (dR == null || inOrder == null)
                {
                    return;
                }
                else
                {
                    dR["Audit_Flag"] = inOrder.Audit_Flag;
                    dR["BillNum"] = inOrder.BillNum;
                    dR["DeliverNum"] = inOrder.DeliverNum;
                    dR["DeptID"] = inOrder.DeptID;
                    dR["InNum"] = inOrder.InNum;
                    dR["InStorageID"] = inOrder.InStorageID;
                    dR["LeastUnit"] = inOrder.LeastUnit;
                    dR["MakerDicID"] = inOrder.MakerDicID;
                    dR["MasterInStorageID"] = inOrder.MasterInStorageID;
                    dR["BatchNum"] = inOrder.BatchNum;
                    dR["RecScale"] = inOrder.RecScale;
                    dR["Remark"] = inOrder.Remark;
                    dR["RetailFee"] = inOrder.RetailFee;
                    dR["RetailPrice"] = inOrder.RetailPrice;
                    dR["StockFee"] = inOrder.StockFee;
                    dR["StockPrice"] = inOrder.StockPrice;
                    dR["TradeFee"] = inOrder.TradeFee;
                    dR["TradePrice"] = inOrder.TradePrice;
                    dR["UnitNum"] = inOrder.UnitNum;
                    dR["ValidityDate"] = inOrder.ValidityDate;
                    dR["SPEC"] = inOrder.MakerDic.DrugInfo.spec;
                    dR["CHEMNAME"] = inOrder.MakerDic.DrugInfo.chemname;
                    dR["UNITNAME"] = inOrder.LeastUnitEntity.UnitName;
                    dR["PRODUCTNAME"] = inOrder.MakerDic.DrugInfo.productname;
                    dR["DefStockPrice"] = inOrder.MakerDic.DefStockPrice;
                    dR["CurrentNum"] = inOrder.CurrentNum;
                    dR["BatchNum"] = inOrder.BatchNum;
                }
                return;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 添加一个入库明细记录对象数据到指定数据表中
        /// </summary>
        /// <param name="order">入库明细记录对象</param>
        /// <param name="orderDt">指定数据表</param>
        private void AddOrderToDT(YP_InOrder order, DataTable orderDt)
        {
            try
            {
                DataRow newRow = orderDt.NewRow();
                orderToDataRow(newRow, order);
                //判断新增明细药品是否已经存在于入库单明细表中
                for (int index = 0; index < orderDt.Rows.Count; index++)
                {
                    if (Convert.ToInt32(orderDt.Rows[index]["MAKERDICID"]) == Convert.ToInt32(newRow["MAKERDICID"])&&
                        (orderDt.Rows[index]["BATCHNUM"].ToString() == newRow["BATCHNUM"].ToString()))
                    {
                        throw new Exception("该药品已经存在于明细中,无法添加，请直接修改入库数量");
                    }
                }
                orderDt.Rows.Add(newRow);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 将数据表中指定位置的记录转成入库明细记录对象
        /// </summary>
        /// <param name="dtTable">
        /// 数据表
        /// </param>
        /// <param name="index">
        /// 对应记录的索引
        /// </param>
        /// <returns>
        /// 转换之后生成的入库明细记录对象
        /// </returns>
        private YP_InOrder GetOrderFromDt(DataTable dtTable, int index)
        {

            try
            {
                if (dtTable.Rows.Count < index || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                YP_InOrder currentInorder = new YP_InOrder();
                HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dtTable, index, currentInorder);
                return currentInorder;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private List<BillOrder> GetListOrder()
        {
            if (_inOrderDt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                List<BillOrder> listOrder = new List<BillOrder>();
                for (int index = 0; index < _inOrderDt.Rows.Count; index++)
                {
                    listOrder.Add(GetOrderFromDt(_inOrderDt, index));
                }
                return listOrder;
            }
        }

        private void txtBatchNum_AfterSelectedRow(object sender, object SelectedValue)
        {
            if(txtBatchNum.ReadOnly == true)
            {
                return;
            }
            if (SelectedValue != null)
            {
                _currentOrder.BatchNum = Convert.ToString(txtBatchNum.MemberValue);
                _currentOrder.ValidityDate = Convert.ToDateTime(((DataRow)SelectedValue)["VALIDITYDATE"]);
                cobValidityDate.Value = _currentOrder.ValidityDate;
            }
        }

        private void txtBatchNum_TextChanged(object sender, EventArgs e)
        {
            _currentOrder.BatchNum = txtBatchNum.Text;
        }

        private void ComputeFeeAndNum()
        {
            if (_currentOrder.MakerDicID == 0)
            {
                return;
            }
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                decimal inNum = (txtInNum.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtInNum.Text.Trim()));
                _currentOrder.StockPrice = (txtStockPrice.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtStockPrice.Text.Trim()));
                _currentOrder.RetailFee = _currentOrder.RetailPrice * inNum;
                _currentOrder.TradeFee = _currentOrder.TradePrice * inNum;
                _currentOrder.InNum = inNum;
                if (_currentOrder.StockPrice != 0)
                {
                    _currentOrder.StockFee = _currentOrder.StockPrice * _currentOrder.InNum;
                }
            }
            else
            {
                decimal baseNum = (txtBaseNum.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtBaseNum.Text.Trim()));
                decimal inNum = (txtInNum.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtInNum.Text.Trim()));
                _currentOrder.StockPrice = (txtStockPrice.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtStockPrice.Text.Trim()));
                _currentOrder.RetailFee = _currentOrder.RetailPrice * inNum
                    + baseNum / Convert.ToDecimal(_currentOrder.UnitNum) * _currentOrder.RetailPrice;
                _currentOrder.TradeFee = _currentOrder.TradePrice * inNum
                    + baseNum / Convert.ToDecimal(_currentOrder.UnitNum) * _currentOrder.TradePrice;
                _currentOrder.InNum = inNum * _currentOrder.UnitNum + baseNum;
                if (_currentOrder.StockPrice != 0)
                {
                    _currentOrder.StockFee = _currentOrder.StockPrice * inNum
                        + baseNum / Convert.ToDecimal(_currentOrder.UnitNum) * _currentOrder.StockPrice;
                }
            }
        }

        private void txtInNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (_belongSystem == ConfigManager.YK_SYSTEM)
                    txtBatchNum.Focus();
                else
                    this.txtBaseNum.Focus();
            }
            
        }

        private void chkIsFirstIn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsFirstIn.Checked == true)
            {
                _currentMaster.OpType = ConfigManager.OP_YK_FIRSTIN;
            }
            else
            {
                _currentMaster.OpType = ConfigManager.OP_YK_INOPTYPE;
            }
        }

        private void cobValidityDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txtStockPrice.Focus();
                txtStockPrice.SelectAll();
            }
        }

        private void tsrbtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                _supportDt = DrugBaseDataBll.LoadSupportInfo();
                _drugInfoDt = DrugBaseDataBll.YD_LoadDrugInfo((int)_currentDeptId);
                txtSupport.SetSelectionCardDataSource(_supportDt);
                txtDgCode.SetSelectionCardDataSource(_drugInfoDt);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void cobBillTime_ValueChanged(object sender, EventArgs e)
        {
            if (cobBillTime.Value != null)
            {
                _currentMaster.BillDate = cobBillTime.Value;
            }
        }

        private void btnQuerySupportHis_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentOrder != null && _belongSystem == ConfigManager.YK_SYSTEM)
                {
                    if (_currentOrder.MakerDicID > 0)
                    {
                        FrmSupportHis frmSupportHis = new FrmSupportHis();
                        if (frmSupportHis.SetDgvDataSource(_billQuery.LoadSupportHis(_currentOrder.MakerDicID,
                            (int)_currentDeptId)))
                        {
                            frmSupportHis.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        //private void txtRemark_TextChanged(object sender, EventArgs e)
        //{
        //    _currentMaster.ReMark = this.txtRemark.Text.Trim();
        //}

        private void txtRemark_TextChanged_1(object sender, EventArgs e)//新增备注字段输入框 及保存 zhangyunhui 5.8
        {
            _currentMaster.ReMark = this.txtRemark.Text.Trim();
        }

        
    }
}
