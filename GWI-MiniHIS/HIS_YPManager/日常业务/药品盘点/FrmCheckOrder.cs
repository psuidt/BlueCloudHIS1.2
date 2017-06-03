using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;
using HIS.Model;

namespace HIS_YPManager
{
    public partial class FrmCheckOrder : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public YP_CheckMaster _currentMaster;
        public int _currentState;
        const int ADD = 0;
        const int QUERY = 1;
        const int UPDATE = 2;
        private string _belongSystem;
        private long _currentUserId;
        private long _currentDeptId;
        private string _chineseName;
        private DataTable _checkOrderDt;
        private DataTable _drugInfoDt;
        private BillQuery _billQuery;
        private BillProcessor _billProcessor;
        private StoreQuery _storeQuery;
        private DataRow _selectRow;
        public FrmCheckOrder()
        {
            InitializeComponent();
        }

        public FrmCheckOrder(long currentUserId, long currentDeptId, string chineseName, string belongSystem)
        {

            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            _belongSystem = belongSystem;
            this.Text = _chineseName;
            _storeQuery = StoreFactory.GetQuery(belongSystem);
            InitializeComponent();
            this.dgrdCheckOrder.AutoGenerateColumns = false;
        }

        private void ShowInQuery()
        {
            this.txtQueryCode.Visible = false;
            this.lblQueryCode.Visible = false;
            this.txtRemark.ReadOnly = true;
            this.dgrdCheckOrder.Columns["CheckPackNum"].ReadOnly = true;
            this.tsrbtnSave.Visible = false;
            this.tsrbtnLoadData.Visible = false;
            this.btnDefCheckNum.Visible = false;
            this.btnAddOrder.Enabled = false;
            this.btnDelOrder.Enabled = false;
            this.txtDgCode.ReadOnly = true;
            this.txtFtBaseNum.ReadOnly = true;
            this.txtFtPackNum.ReadOnly = true;
            this.cobValidityDate.Enabled = false;
            if (_belongSystem != ConfigManager.YK_SYSTEM)
            {
                this.dgrdCheckOrder.Columns["CheckNum"].ReadOnly = true;
            }
        }

        private void FrmCheckOrder_Load(object sender, EventArgs e)
        {
            try
            {
                dgrdCheckOrder.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)9);
                if (_belongSystem == ConfigManager.YK_SYSTEM)
                {
                    dgrdCheckOrder.Columns.Remove("AccountNum");
                    dgrdCheckOrder.Columns.Remove("UnitName");
                    dgrdCheckOrder.Columns.Remove("CheckNum");
                    _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YK_CHECK);
                    _billQuery = BillFactory.GetQuery(ConfigManager.OP_YK_CHECK);
                    txtFtPackNum.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
                    txtFtBaseNum.ReadOnly = true;
                }
                else if (_belongSystem == ConfigManager.YF_SYSTEM)
                {
                    _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_CHECK);
                    _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_CHECK);
                    dgrdCheckOrder.Columns.Remove("BatchNum");
                    cobValidityDate.Enabled = false;
                }
                if (_currentState == UPDATE)
                {
                    this.tsrbtnLoadData.Visible = false;
                    this.txtDgCode.ReadOnly = true;
                    this.btnAddOrder.Enabled = false;
                    this.btnDelOrder.Enabled = false;
                }
                _checkOrderDt = _billQuery.LoadOrder(_currentMaster);
                dgrdCheckOrder.DataSource = _checkOrderDt;
                _drugInfoDt = _storeQuery.GetCheckDrug((int)_currentDeptId);
                txtDgCode.SetSelectionCardDataSource(_drugInfoDt);
                txtQueryCode.SetSelectionCardDataSource(_drugInfoDt);
                ShowCurrentMaster();
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnDefCheckNum_Click(object sender, EventArgs e)
        {

            try
            {
                if (_belongSystem == "药房系统")
                {
                    for (int index = 0; index < this.dgrdCheckOrder.Rows.Count; index++)
                    {
                        _checkOrderDt.Rows[index]["CPACKNUM"] = _checkOrderDt.Rows[index]["PACKNUM"];
                        _checkOrderDt.Rows[index]["CBASENUM"] = _checkOrderDt.Rows[index]["BASENUM"];
                    }
                }
                else
                {
                    for (int index = 0; index < this.dgrdCheckOrder.Rows.Count; index++)
                    {
                        _checkOrderDt.Rows[index]["CPACKNUM"] = _checkOrderDt.Rows[index]["PACKNUM"];
                    }
                }
                MessageBox.Show("设置完成");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void ShowCurrentMaster()
        {
            if (_currentMaster != null)
            {
                this.txtBillNum.Text = _currentMaster.BillNum.ToString();
                this.txtRemark.Text = _currentMaster.ReMark;
                this.cobBillDate.Value = _currentMaster.RegTime;
            }
        }

        private bool CheckInput()
        {
            if (this.dgrdCheckOrder.Rows.Count < 1)
            {
                MessageBox.Show("请先提取数据");
                return false;
            }
            else
            {
                if (_checkOrderDt != null)
                {
                    if (_checkOrderDt.Rows.Count <= 0)
                    {
                        return false;
                    }
                    for (int index = 0; index < _checkOrderDt.Rows.Count; index++)
                    {
                        DataRow currentRow = _checkOrderDt.Rows[index];
                        if (_belongSystem == ConfigManager.YF_SYSTEM)
                        {
                            if (currentRow["CBASENUM"] == DBNull.Value || currentRow["CPACKNUM"] == DBNull.Value
                                || Convert.ToDecimal(currentRow["CBASENUM"]) < 0 || Convert.ToDecimal(currentRow["CPACKNUM"]) < 0)
                            {
                                MessageBox.Show("第" + (index + 1).ToString() + "行数据有误:" + currentRow["ChemName"].ToString(),
                                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            if (currentRow["CPACKNUM"] == DBNull.Value || Convert.ToDecimal(currentRow["CPACKNUM"]) < 0)
                            {
                                MessageBox.Show("第" + (index + 1).ToString() + "行数据有误:" + currentRow["ChemName"].ToString(),
                                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void txtRemark_TextChanged(object sender, EventArgs e)
        {
            _currentMaster.ReMark = txtRemark.Text;
        }

        private void dgrdCheckOrder_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == dgrdCheckOrder.Columns["CheckPackNum"].Index || e.ColumnIndex == dgrdCheckOrder.Columns["CheckNum"].Index)
            {
                MessageBox.Show("格式错误,请输入数字！");
                dgrdCheckOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
        }

        private void FrmCheckOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_currentState == ADD)
                {                   
                    ConfigManager.StopCheckStatus(_currentMaster, _billQuery, _billProcessor, _belongSystem);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("关闭盘点状态出现异常，请及时进入盘点单据管理界面清除盘点状态");
            }
        }

        private void tsrbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsrPrintEmpty_Click(object sender, EventArgs e)
        {
            try
            {
                if (_checkOrderDt.Rows.Count > 0)
                {
                    string startPath = Application.StartupPath + "\\report\\药品空盘点表单.grf";
                    PrintFactory.GetPrinter(ConfigManager.OP_YK_CHECK + "EMPTY").PrintBill(_currentMaster, _checkOrderDt,
                        startPath, (int)_currentUserId);
                }
                else
                {
                    MessageBox.Show("请先提取数据");
                }
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
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (CheckInput() == true)
                {
                    if (_currentState == ADD)
                    {
                        _billProcessor.SaveBill(_currentMaster, GetOrderList(), _currentDeptId);
                        MessageBox.Show("保存成功，当前库房已是盘点状态，请及时审核单据....");
                    }
                    else
                    {
                        _billProcessor.UpdateBill(_currentMaster, GetOrderList(), _currentDeptId);
                        MessageBox.Show("修改成功,请及时审核盘点单据......");
                    }
                    _currentState = QUERY;
                    ShowInQuery();
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                this.Cursor = this.DefaultCursor;
            }
        }

        private void tsrbtnLoadData_Click(object sender, EventArgs e)
        {
            
            FrmCheckType frmCheckType = new FrmCheckType();
            if (frmCheckType.ShowDialog() != DialogResult.Cancel)
            {
                FilterData(frmCheckType.drugTypeId, frmCheckType.drugDoseId, frmCheckType.isOnlyNoStore);
                btnDefCheckNum_Click(null, null);
            }
        }

        private void FilterData(int drugTypeId, int drugDoseId, bool isOnlyNoStore)
        {
            if (_drugInfoDt.Rows.Count > 0)
            {
                _checkOrderDt.Rows.Clear();
                string filterWhere = "";
                if (drugTypeId != 0)
                {
                    filterWhere += ("TypeDicID=" + drugTypeId.ToString());
                }
                if (drugDoseId != -1)
                {
                    if (drugTypeId == 0)
                    {
                        filterWhere += ("DoseDicID=" + drugDoseId.ToString());
                    }
                    else
                    {
                        filterWhere += (" AND DoseDicID=" + drugDoseId.ToString());
                    }
                }
                if (isOnlyNoStore)
                {
                    filterWhere += (filterWhere==""?"CURRENTNUM<>0":" AND CURRENTNUM<>0");
                }
                DataTable newDataTable = _drugInfoDt.Clone();
                DataRow[] dRows = _drugInfoDt.Select(filterWhere, "DoseName, ChemName asc");               
                foreach (DataRow drugInfoRow in dRows)
                {
                    DataRow addRow = DrugInfoToCheckOrder(drugInfoRow);
                    filterWhere = "MAKERDICID=" + addRow["MAKERDICID"].ToString(); 
                    if (_belongSystem == ConfigManager.YK_SYSTEM)
                    {
                        filterWhere += " AND BATCHNUM='" + addRow["BATCHNUM"].ToString() + "'";                        
                    }
                    if (_checkOrderDt.Select(filterWhere).Length <= 0)
                    {
                        _checkOrderDt.Rows.Add(addRow);
                    }
                }
            }
        }

        private void FrmCheckOrder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F2:
                    tsrbtnLoadData_Click(null, null);
                    break;
                case Keys.F3:
                    tsrbtnSave_Click(null, null);
                    break;
                case Keys.F4:
                    tsrPrintEmpty_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void dgrdCheckOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int currentColoumn = dgrdCheckOrder.CurrentCell.ColumnIndex;
            if (currentColoumn == dgrdCheckOrder.Columns["CheckPackNum"].Index || currentColoumn == dgrdCheckOrder.Columns["CheckNum"].Index)
            {
                if (Convert.ToDecimal(dgrdCheckOrder.CurrentCell.Value) < 0)
                {
                    MessageBox.Show("盘存数不能小于0");
                    dgrdCheckOrder.CurrentCell.Value = 0;
                }
            }
        }


        private void txtQueryCode_AfterSelectedRow(object sender, object SelectedValue)
        {
            DataRow dr = (DataRow)SelectedValue;
            if (dr != null)
            {
                this.txtQueryCode.Text = "";
                int makerDicId = Convert.ToInt32(dr["MAKERDICID"]);
                for (int rowIndex = 0; rowIndex < dgrdCheckOrder.RowCount; rowIndex++)
                {
                    if (Convert.ToInt32(dgrdCheckOrder["MAKERDICID", rowIndex].Value) == makerDicId)
                    {
                        dgrdCheckOrder.Focus();
                        dgrdCheckOrder.CurrentCell = dgrdCheckOrder.Rows[rowIndex].Cells["CheckPackNum"];
                    }
                }
            }
        }

        /// <summary>
        /// 将指定审核明细信息表的行记录转成盘点明细对象
        /// </summary>
        /// <param name="orderTable">盘点明细信息表</param>
        /// <param name="index">行记录索引</param>
        /// <param name="opType">业务类型</param>
        /// <returns>
        /// 盘点明细对象
        /// </returns>
        private List<BillOrder> GetOrderList()
        {
            try
            {
                DataTable orderTable = _checkOrderDt;
                List<BillOrder> orderList = new List<BillOrder>();
                for (int index = 0; index < orderTable.Rows.Count; index++)
                {
                    DataRow dRow = orderTable.Rows[index];
                    YP_CheckOrder checkOrder = new YP_CheckOrder();
                    HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(orderTable, index, checkOrder);
                    //包装单位比例
                    checkOrder.UnitNum = Convert.ToInt32(dRow["PUNITNUM"]);
                    //如果是药房盘点业务
                    if (_belongSystem == ConfigManager.YF_SYSTEM)
                    {
                        if (_currentState == ADD)
                        {
                            //单位标识ID
                            checkOrder.LeastUnit = Convert.ToInt32(dRow["LEASTUNIT"]);
                        }
                        YF_ComputeCheckFee(dRow, checkOrder);
                    }
                    //如果是药库盘点业务
                    else
                    {
                        //单位标识ID
                        if (_currentState == ADD)
                        {
                            checkOrder.LeastUnit = Convert.ToInt32(dRow["LEASTUNIT"]);
                        }
                        YK_ComputeCheckFee(dRow, checkOrder);
                    }
                    orderList.Add(checkOrder);
                }

                return orderList;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void YK_ComputeCheckFee(DataRow dRow, YP_CheckOrder checkOrder)
        {
            //盘点包装量
            decimal cPackNum = Convert.ToDecimal(dRow["CPACKNUM"]);
            //零售价
            decimal retailPrice = Convert.ToDecimal(dRow["RETAILPRICE"]);
            //批发价
            decimal tradePrice = Convert.ToDecimal(dRow["TRADEPRICE"]);
            //实际包装量
            decimal packNum = Convert.ToDecimal(dRow["PACKNUM"]);
            checkOrder.CheckNum = cPackNum;
            checkOrder.FactNum = packNum;
            //计算盘盈，盘亏金额
            checkOrder.CKRetailFee = cPackNum * retailPrice;
            checkOrder.CKTradeFee = cPackNum * tradePrice;
            checkOrder.FTRetailFee = packNum * retailPrice;
            checkOrder.FTTradeFee = packNum * tradePrice;
        }

        private void YF_ComputeCheckFee(DataRow dRow, YP_CheckOrder checkOrder)
        {
            //盘点包装量
            decimal cPackNum = Convert.ToDecimal(dRow["CPACKNUM"]);
            //盘点基本量
            decimal cBaseNum = Convert.ToDecimal(dRow["CBASENUM"]);
            //包装单位比例
            decimal pUnitNum = Convert.ToDecimal(checkOrder.UnitNum);
            //零售价
            decimal retailPrice = checkOrder.RetailPrice;
            //批发价
            decimal tradePrice = checkOrder.TradePrice;
            //实际包装量
            decimal packNum = Convert.ToDecimal(dRow["PACKNUM"]);
            //实际基本量
            decimal baseNum = Convert.ToDecimal(dRow["BASENUM"]);
            checkOrder.CheckNum = cPackNum * pUnitNum + cBaseNum;
            checkOrder.FactNum = packNum * pUnitNum + baseNum;
            //计算盘盈，盘亏金额
            checkOrder.CKRetailFee = cPackNum * retailPrice + (cBaseNum / pUnitNum) * retailPrice;
            checkOrder.CKTradeFee = cPackNum * tradePrice + (cBaseNum / pUnitNum) * tradePrice;
            checkOrder.FTRetailFee = packNum * retailPrice + (baseNum / pUnitNum) * retailPrice;
            checkOrder.FTTradeFee = packNum * tradePrice + (baseNum / pUnitNum) * tradePrice;
        }

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (_currentMaster != null)
            {
                _currentMaster.ReMark = txtRemark.Text;
            }
            if (e.KeyValue == 13)
            {
                txtDgCode.Focus();
            }
        }

        private void txtDgCode_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtDgCode.ReadOnly == true)
            {
                return;
            }
            DataRow dr = (DataRow)SelectedValue;
            _selectRow = DrugInfoToCheckOrder(dr);
            ShowCurrentOrder();
        }

        /// <summary>
        /// 将库存药品信息转成盘点明细记录
        /// </summary>
        /// <param name="dr">库存药品信息</param>
        private DataRow DrugInfoToCheckOrder(DataRow dr)
        {
            DataRow changeRow = _checkOrderDt.NewRow();
            changeRow["CHEMNAME"] = dr["CHEMNAME"];
            changeRow["PRODUCTNAME"] = dr["PRODUCTNAME"];
            changeRow["MAKERDICID"] = dr["MAKERDICID"];
            changeRow["SPEC"] = dr["SPEC"];
            changeRow["RETAILPRICE"] = dr["RETAILPRICE"];
            changeRow["TRADEPRICE"] = dr["TRADEPRICE"];
            changeRow["PACKUNITNAME"] = dr["UNITNAME"];
            changeRow["PACKNUM"] = dr["PACKNUM"];
            changeRow["PUNITNUM"] = dr["PACKNUM"];
            changeRow["UNITNUM"] = dr["PACKNUM"];
            changeRow["WORKID"] = dr["WORKID"];
            changeRow["TYPEDICID"] = dr["TYPEDICID"];
            changeRow["TYPENAME"] = dr["TYPENAME"];
            changeRow["DOSEDICID"] = dr["DOSEDICID"];
            changeRow["DOSENAME"] = dr["DOSENAME"];
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                changeRow["PACKNUM"] = dr["CURRENTNUM"];
                changeRow["BATCHNUM"] = dr["BATCHNUM"];
                changeRow["CPACKNUM"] = 0;
                changeRow["LEASTUNIT"] = dr["PACKUNIT"];
                changeRow["STORAGEID"] = dr["ID"];
                changeRow["VALIDITYDATE"] = dr["VALIDITYDATE"];
            }
            else
            {
                changeRow["UNITNAME"] = dr["LUNITNAME"];
                changeRow["PACKNUM"] = (Convert.ToInt32(dr["CURRENTNUM"]) / Convert.ToInt32(dr["PACKNUM"])).ToString();
                changeRow["BASENUM"] = (Convert.ToInt32(dr["CURRENTNUM"]) % Convert.ToInt32(dr["PACKNUM"])).ToString();
                changeRow["CPACKNUM"] = 0;
                changeRow["CBASENUM"] = 0;
                changeRow["LEASTUNIT"] = dr["UNIT"];
                changeRow["STORAGEID"] = dr["STORAGEID"];
            }
            return changeRow;
        }

        private void ShowCurrentOrder()
        {
            txtChemName.Text = _selectRow["CHEMNAME"].ToString();
            txtProductName.Text = _selectRow["PRODUCTNAME"].ToString();
            txtSpec.Text = _selectRow["SPEC"].ToString();
            txtRetailPrice.Text = Convert.ToDecimal(_selectRow["RETAILPRICE"]).ToString("0.00");
            txtTradePrice.Text = Convert.ToDecimal(_selectRow["TRADEPRICE"]).ToString("0.00");
            txtPackUnit.Text = _selectRow["PACKUNITNAME"].ToString();

            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                txtActPackNum.Text = Convert.ToDecimal(_selectRow["PACKNUM"]).ToString();
                txtFtPackNum.Text = Convert.ToDecimal(_selectRow["CPACKNUM"]).ToString();
                txtBatchNum.Text = _selectRow["BATCHNUM"].ToString();
                DateTime validityTime = Convert.ToDateTime(_selectRow["VALIDITYDATE"]);
                cobValidityDate.Value = validityTime;
            }
            else
            {
                txtSmallUnit.Text = _selectRow["UNITNAME"].ToString();
                txtActPackNum.Text = (Convert.ToInt32(_selectRow["PACKNUM"])).ToString();
                txtActBaseNum.Text = (Convert.ToInt32(_selectRow["BASENUM"])).ToString();
                txtFtPackNum.Text = Convert.ToInt32(_selectRow["CPACKNUM"]).ToString();
                txtFtBaseNum.Text = Convert.ToInt32(_selectRow["CBASENUM"]).ToString();
            }
        }

        private bool checkInputOrder()
        {
            string findWhere = "";
            if (_selectRow == null)
            {
                MessageBox.Show("请选择药品");
                return false;
            }
            if (_belongSystem == ConfigManager.YF_SYSTEM)
            {
                if (txtFtBaseNum.Text == "" && txtFtPackNum.Text == "")
                {
                    MessageBox.Show("请输入药品实盘数量");
                    txtFtPackNum.Focus();
                    return false;
                }
                findWhere = "MAKERDICID=" + _selectRow["MAKERDICID"].ToString();
            }
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                if (txtFtPackNum.Text == "")
                {
                    MessageBox.Show("请输入药品实盘数量");
                    txtFtPackNum.Focus();
                    return false;
                }
                findWhere = "MAKERDICID=" + _selectRow["MAKERDICID"].ToString() + " AND BATCHNUM="
                + "'" + _selectRow["BATCHNUM"].ToString() + "'";
            }
            
            if (_checkOrderDt.Select(findWhere).Length > 0)
            {
                MessageBox.Show("该药品已经存在，请重新选择");
                txtDgCode.Focus();
                return false;
            }
            return true;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkInputOrder())
                {
                    if (_selectRow != null)
                    {
                        _checkOrderDt.Rows.Add(_selectRow);
                        ClearTextBox();
                        txtDgCode.Focus();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdCheckOrder_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgrdCheckOrder.CurrentCell != null)
                {
                    _selectRow = _checkOrderDt.Rows[dgrdCheckOrder.CurrentCell.RowIndex];
                    ShowCurrentOrder();
                }
                else
                {
                    ClearTextBox();
                    _selectRow = null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void ClearTextBox()
        {
            txtDgCode.Clear();
            txtActBaseNum.Clear();
            txtActPackNum.Clear();
            txtBatchNum.Clear();
            txtBillNum.Clear();
            txtChemName.Clear();
            txtFtBaseNum.Clear();
            txtFtPackNum.Clear();
            txtPackUnit.Text = "??";
            txtProductName.Clear();
            txtQueryCode.Clear();
            txtRetailPrice.Clear();
            txtSmallUnit.Text = "??";
            txtSpec.Clear();
            txtTradePrice.Clear();
            cobValidityDate.ValueChanged -= new EventHandler(cobValidityDate_ValueChanged);
            cobValidityDate.Value = DateTime.Now;
            cobValidityDate.ValueChanged += new EventHandler(cobValidityDate_ValueChanged);
        }

        private void txtFtPackNum_TextChanged(object sender, EventArgs e)
        {
            if (txtFtPackNum.Text != "" && txtFtPackNum.Text != "-")
            {
                if (_selectRow != null)
                {
                    if (_belongSystem == ConfigManager.YF_SYSTEM)
                    {
                        _selectRow["CPACKNUM"] = Convert.ToInt32(txtFtPackNum.Text);
                    }
                    else
                    {
                        _selectRow["CPACKNUM"] = Convert.ToDecimal(txtFtPackNum.Text);
                    }
                }
            }
        }

        private void btnDelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectRow == null || _checkOrderDt.Rows.Count == 0 || dgrdCheckOrder.CurrentCell == null)
                {
                    MessageBox.Show("没有选中数据");
                    return;
                }
                else
                {
                    _checkOrderDt.Rows.RemoveAt(dgrdCheckOrder.CurrentCell.RowIndex);
                }
                MessageBox.Show("删除成功");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtFtPackNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)(e.KeyChar) == 13)
            {
                if (_belongSystem == ConfigManager.YK_SYSTEM)
                {
                    btnAddOrder.Focus();
                }
                else
                {
                    txtFtBaseNum.Focus();
                    txtFtBaseNum.SelectAll();
                }
            }
        }

        private void txtFtBaseNum_TextChanged(object sender, EventArgs e)
        {
            if (txtFtBaseNum.Text != "" && txtFtBaseNum.Text != "-")
            {
                if (_selectRow != null)
                {
                    _selectRow["CBASENUM"] = Convert.ToInt32(this.txtFtBaseNum.Text);
                }
            }
        }

        private void cobValidityDate_ValueChanged(object sender, EventArgs e)
        {
            if (_selectRow != null)
            {
                if (_belongSystem == ConfigManager.YK_SYSTEM)
                {
                    _selectRow["VALIDITYDATE"] = cobValidityDate.Value;
                }
            }
        }

        private void cobValidityDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.btnAddOrder.Focus();
            }
        }

        private void chkFilterNoStore_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterNoStore.Checked)
            {
                _drugInfoDt = _drugInfoDt.Select("CURRENTNUM <> 0").CopyToDataTable();
                txtDgCode.SetSelectionCardDataSource(_drugInfoDt);
            }
            else
            {
                _drugInfoDt = _storeQuery.GetCheckDrug((int)_currentDeptId);
                txtDgCode.SetSelectionCardDataSource(_drugInfoDt);
            }
        }
    }
}
