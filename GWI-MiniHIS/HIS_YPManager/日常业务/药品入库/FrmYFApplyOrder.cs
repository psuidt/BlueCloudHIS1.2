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
    public partial class FrmYFApplyorder : GWI.HIS.Windows.Controls.BaseMainForm
    {
        const int DEFMONTH = 12;
        public YP_InMaster _currentMaster;
        private YP_InOrder _currentOrder;
        private long _currentUserId;
        private long _currentDeptId;
        private DataTable _drugInfoDt;
        private DataTable _inOrderDt;
        private BillProcessor _billProcessor;
        private BillQuery _billQuery;
        private StoreQuery _storeQuery;
        public YP_DeptDic _outDept = new YP_DeptDic();
        private bool _isBuildByLimit;
        private DataTable _limitDt;       
        
        /// <summary>
        /// 新增单据状态
        /// </summary>
        const int ADD = 0;
        /// <summary>
        /// 查看单据状态
        /// </summary>
        const int UPDATE = 1;
        /// <summary>
        /// 当前状态
        /// </summary>
        public int _currentState;

        public DataTable LimitDt
        {
            get { return _limitDt; }
            set { _limitDt = value; }
        }

        public FrmYFApplyorder()
        {
            InitializeComponent();
        }

        public FrmYFApplyorder(long currentUserId, long currentDeptId, int beginState,
            bool isBuildByLimit)
        {
            
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _currentState = beginState;
            _isBuildByLimit = isBuildByLimit;
            _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_APPLYIN);
            _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_APPLYIN);
            _storeQuery = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM);
            InitializeComponent();
            //设置起始焦点           
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckSaveOrder() == true)
                {
                    txtInNum_TextChanged(null, null);
                    AddOrderToDT(_currentOrder, _inOrderDt);
                    ClearOrderTextbox();
                    _currentOrder = (YP_InOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
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
                if (CheckSaveOrder() == true)
                {
                    txtInNum_TextChanged(null, null);
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
                        _currentOrder = (YP_InOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
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

        private void ShowInQuery()
        {
            this.btnDelOrder.Visible = false;
            this.btnUpdateOrder.Visible = false;
            this.tsrbtnSave.Visible = false;
            this.tsrbtnNew.Visible = false;
            this.txtDgCode.ReadOnly = true;
            this.txtInNum.ReadOnly = true;
            this.txtBatchNum.ReadOnly = true;
            this.cobBillTime.Enabled = false;
        }


        private void txtInvoiceNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtDgCode.Focus();
            }
        }


        private void txtInNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnAddOrder.Focus();
            }
        }


        private void LoadData()
        {
            dgrdInOrder.AutoGenerateColumns = false;
            _drugInfoDt = _storeQuery.LoadDrugInfo(_outDept.DeptID, (int)_currentDeptId);
            txtDgCode.SetSelectionCardDataSource(_drugInfoDt);
            _inOrderDt = _billQuery.LoadOrder(_currentMaster);
            dgrdInOrder.DataSource = _inOrderDt;

        }

        private void ShowCurrentMaster()
        {
            if (_currentMaster != null)
            {
                this.cobBillTime.Value = _currentMaster.BillDate;
            }
        }

        private void ShowDrugInfo()
        {
            this.txtDgName.Text = _currentOrder.MakerDic.DrugInfo.chemname;
            this.txtDgSpec.Text = _currentOrder.MakerDic.DrugInfo.spec;
            this.txtProduct.Text = _currentOrder.MakerDic.DrugInfo.productname;
            this.txtRetailPrice.Text = _currentOrder.RetailPrice.ToString();
            this.txtTradePrice.Text = _currentOrder.TradePrice.ToString();
            this.txtPackUnit.Text = _currentOrder.LeastUnitEntity.UnitName;
            this.txtBatchNum.Text = _currentOrder.BatchNum;
        }

        private void ShowCurrentOrder()
        {
            ShowDrugInfo();
            this.txtInNum.Text = Convert.ToInt32(_currentOrder.InNum).ToString();
        }

        private bool CheckSaveBill()
        {
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
                MessageBox.Show("请输入药品信息");
                txtDgCode.Focus();
                txtDgCode.SelectAll();
                return false;
            }
            if (_currentOrder.InNum == 0 || _currentOrder.InNum > Convert.ToDecimal(txtCurrentNum.Text.Trim()))
            {
                MessageBox.Show("申请入库数量过多或数量为0，请重新输入");
                txtInNum.Focus();
                txtInNum.SelectAll();
                return false;
            }
            if (_currentOrder.BatchNum == "" || _currentOrder.BatchNum == null)
            {
                MessageBox.Show("请输入批次号");
                txtBatchNum.Focus();
                txtBatchNum.SelectAll();
                return false;
            }
            return true;
        }

        private void ClearOrderTextbox()
        {
            this.txtDgCode.Clear();
            this.txtDgName.Clear();
            this.txtDgSpec.Clear();
            this.txtProduct.Clear();
            this.txtPackUnit.Clear();
            this.txtInNum.Clear();
            this.txtTradePrice.Clear();
            this.txtRetailPrice.Clear();
            this.txtBatchNum.Clear();
            this.txtCurrentNum.Clear();
        }

        private void FrmYFInorder_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (!_isBuildByLimit)
                {
                    if (_currentState == ADD)
                    {
                        //生成一个新的单据表头
                        _currentMaster = (YP_InMaster)(_billProcessor.BuildNewMaster(_currentDeptId, _currentUserId));
                        _currentMaster.SupportDicID = _outDept.DeptID;
                    }
                    _currentOrder = (YP_InOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
                    LoadData();
                }
                else
                {
                    _billProcessor.BuildApplyInByStoreLimit(out _currentMaster,
                        out _inOrderDt, (int)_currentDeptId, (int)_currentUserId, _outDept.DeptID, _limitDt);
                    _currentOrder = (YP_InOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
                    dgrdInOrder.AutoGenerateColumns = false;
                    dgrdInOrder.DataSource = _inOrderDt;
                    _drugInfoDt = _storeQuery.LoadDrugInfo(_outDept.DeptID, (int)_currentDeptId);
                    txtDgCode.SetSelectionCardDataSource(_drugInfoDt);
                    _isBuildByLimit = false;
                }
                //显示当前表头信息
                this.txtApplyDept.Text = _outDept.DeptName;
                ShowCurrentMaster();
                this.cobBillTime.Focus();
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

        private void tsrbtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                //生成一个新的单据表头
                _currentMaster = (YP_InMaster)(_billProcessor.BuildNewMaster(_currentDeptId, _currentUserId));
                _currentMaster.SupportDicID = _outDept.DeptID;
                _currentOrder = (YP_InOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
                //加载数据
                LoadData();
                ClearOrderTextbox();
                ShowCurrentMaster();
                _currentState = ADD;
                this.cobBillTime.Focus();
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
                    if (_currentState == ADD)
                    {
                        _billProcessor.SaveBill(_currentMaster, GetListOrder(), _outDept.DeptID);
                    }
                    else
                    {
                        _billProcessor.UpdateBill(_currentMaster, GetListOrder(), _outDept.DeptID);
                    }
                    ShowInQuery();
                    tsrInOrder.Focus();
                    MessageBox.Show("保存成功,请告知药库审核入库申请单以确保药品及时入库...");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void FrmYFInorder_KeyDown(object sender, KeyEventArgs e)
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
                default:
                    break;
            }
        }

        

        private void cobBillTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txtDgCode.Focus();
            }
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
                    DataTable batchDt = _storeQuery.LoadBatchWithDelete(_currentOrder.MakerDicID,
                    (int)_outDept.DeptID);
                    DataRow[] dRows = batchDt.Select("BATCHNUM='" + _currentOrder.BatchNum.ToString() + "'");
                    if (dRows.Length > 0)
                    {
                        txtCurrentNum.Text = dRows[0]["CURRENTNUM"].ToString();
                    }
                    else
                    {
                        txtCurrentNum.Clear();
                    }
                    txtBatchNum.SetSelectionCardDataSource(batchDt);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtDgCode_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtDgCode.ReadOnly == true)
            {
                return;
            }
            DataRow dr = (DataRow)SelectedValue;
            txtDgCode.Text = "";
            _currentOrder.MakerDic.MakerDicID = Convert.ToInt32(dr["MAKERDICID"]);
            _currentOrder.MakerDicID = Convert.ToInt32(dr["MAKERDICID"]);
            _currentOrder.LeastUnit = Convert.ToInt32(dr["PACKUNIT"]);
            _currentOrder.UnitNum = Convert.ToInt32(dr["PACKNUM"]);
            _currentOrder.MakerDic.DrugInfo.chemname = dr["CHEMNAME"].ToString();
            _currentOrder.MakerDic.DrugInfo.spec = dr["SPEC"].ToString();
            _currentOrder.MakerDic.DrugInfo.productname = dr["PRODUCTNAME"].ToString();
            _currentOrder.RetailPrice = Convert.ToDecimal(dr["RETAILPRICE"]);
            _currentOrder.TradePrice = Convert.ToDecimal(dr["TRADEPRICE"].ToString());
            _currentOrder.ValidityDate = _currentMaster.RegTime.AddMonths(DEFMONTH);
            _currentOrder.LeastUnitEntity.UnitName = dr["UNITNAME"].ToString();
            DataTable batchDt = _storeQuery.LoadBatchWithDelete(_currentOrder.MakerDicID,
                _outDept.DeptID);           
            txtBatchNum.SetSelectionCardDataSource(batchDt);
            DataRow[] dRows = batchDt.Select("DEL_FLAG=0", "CURRENTNUM desc,VALIDITYDATE ASC"); // update by heyan 2010.12.15 默认批次选择为有库存的批次
            if (dRows.Length > 0)
            {
                txtCurrentNum.Text = dRows[0]["CURRENTNUM"].ToString();
                _currentOrder.BatchNum = dRows[0]["BATCHNUM"].ToString();
                _currentOrder.ValidityDate = Convert.ToDateTime(dRows[0]["VALIDITYDATE"]);
            }
            else
                txtCurrentNum.Text = "0";
            ShowDrugInfo();
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
                    inOrder.InNum = Convert.ToDecimal(dR["INNUM"]);
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
                    inOrder.BatchNum = dR["BATCHNUM"].ToString();
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
                    dR["BATCHNUM"] = inOrder.BatchNum;
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
                    if ((Convert.ToInt32(orderDt.Rows[index]["MAKERDICID"]) == Convert.ToInt32(newRow["MAKERDICID"]))
                        && (orderDt.Rows[index]["BATCHNUM"].ToString() == newRow["BATCHNUM"].ToString()))
                    {
                        throw new Exception("该药品已经存在于明细中,无法添加.....");
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
            if (txtBatchNum.ReadOnly == true)
            {
                return;
            }
            if (SelectedValue != null)
            {
                DataRow dr = (DataRow)SelectedValue;
                _currentOrder.BatchNum = Convert.ToString(txtBatchNum.MemberValue);
                _currentOrder.ValidityDate = Convert.ToDateTime(dr["VALIDITYDATE"]);
                txtCurrentNum.Text = dr["CURRENTNUM"].ToString();
            }
        }

        private void txtInNum_TextChanged(object sender, EventArgs e)
        {
            if (txtInNum.Text != "" && txtInNum.Text != "-")
            {
                _currentOrder.RetailFee = _currentOrder.RetailPrice * Convert.ToDecimal(txtInNum.Text.Trim());
                _currentOrder.TradeFee = _currentOrder.TradePrice * Convert.ToDecimal(txtInNum.Text.Trim());
                _currentOrder.InNum = Convert.ToDecimal(txtInNum.Text);
            }
        }

        private void cobBillTime_ValueChanged(object sender, EventArgs e)
        {
            if (_currentMaster != null)
            {
                _currentMaster.BillDate = cobBillTime.Value;
            }
        }
    }
}
