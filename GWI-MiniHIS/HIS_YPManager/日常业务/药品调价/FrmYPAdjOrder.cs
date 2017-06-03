using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.YP_BLL;
using HIS.Model;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_YPManager
{
    public partial class FrmYPAdjOrder : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public YP_AdjMaster _adjMaster;
        private YP_AdjOrder _currentOrder;
        private int _currentState;
        private DataTable _drugInfoDt;
        private DataTable _orederDt;
        const int ADD = 0;
        const int QUERY = 1;
        private string _belongSystem;
        private BillQuery _billQuery;
        private BillProcessor _billProcessor;
        public FrmYPAdjOrder()
        {
            InitializeComponent();
        }

        public FrmYPAdjOrder(int state, string belongSystem)
        {
            _currentState = state;
            _belongSystem = belongSystem;
            InitializeComponent();
        }

        private void ShowMaster()
        {
            this.cobExeDate.Value = _adjMaster.ExeTime;
            this.txtBillNum.Text = _adjMaster.BillNum.ToString();
            this.txtAdjCode.Text = _adjMaster.AdjCode.ToString();
            this.txtRemark.Text = _adjMaster.Remark.ToString();
        }

        private bool CheckSaveBill()
        {
            if (_orederDt.Rows.Count < 1)
            {
                MessageBox.Show("没有药品需要调价");
                return false;
            }
            if (txtAdjCode.Text.Trim() == "")
            {
                MessageBox.Show("请输入调价文号");
                txtAdjCode.Focus();
                return false;
            }
            return true;
        }

        private bool CheckSaveOrder()
        {
            if (_currentOrder == null)
            {
                MessageBox.Show("请选择明细");
                return false;
            }
            if (_currentOrder.MakerDicID == 0)
            {
                MessageBox.Show("请选择调价药品");
                txtDgCode.Focus();
                txtDgCode.SelectAll();
                return false;
            }
            if (_currentOrder.NewRetailPrice < 0)
            {
                MessageBox.Show("请输入药品新零售价");
                txtNewRetail.Focus();
                txtNewRetail.SelectAll();
                return false;
            }
            if (_currentOrder.NewTradePrice < 0)
            {
                MessageBox.Show("请输入药品新批发价");
                txtNewTrade.Focus();
                txtNewTrade.SelectAll();
                return false;
            }
            if (_currentOrder.NewRetailPrice - _currentOrder.OldRetailPrice == 0&&
                _currentOrder.NewTradePrice - _currentOrder.OldTradePrice == 0)
            {
                MessageBox.Show("未产生调价");
                return false;
            }
            return true;
        }

        private void FrmAdjOrder_Load(object sender, EventArgs e)
        {
            try
            {
                if (_belongSystem == ConfigManager.YF_SYSTEM)
                {
                    _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_ADJPRICE);
                    _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_ADJPRICE);
                }
                else
                {
                    _billQuery = BillFactory.GetQuery(ConfigManager.OP_YK_ADJPRICE);
                    _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YK_ADJPRICE);
                }
                if (_currentState == ADD)
                {
                    this._currentOrder = (YP_AdjOrder)(_billProcessor.BuildNewoder(0, _adjMaster));
                    LoadData();
                    this.txtNewRetail.Text = "0.00";
                    this.txtNewTrade.Text = "0.00";
                    ShowMaster();
                    this.txtAdjCode.Focus();
                    this.txtAdjCode.SelectAll();
                }
                else
                {
                    LoadData();
                    _currentOrder = (YP_AdjOrder)(_billProcessor.BuildNewoder(0, _adjMaster));
                    dgrdAdjOrder_CurrentCellChanged(null, null);
                    ShowInQuery();
                    ShowMaster();
                }
                
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                dgrdAdjOrder.AutoGenerateColumns = false;
                _drugInfoDt = StoreFactory.GetQuery(_belongSystem).LoadDrugInfo((int)_adjMaster.DeptID);
                txtDgCode.SetSelectionCardDataSource(_drugInfoDt);
                _orederDt = _billQuery.LoadOrder(_adjMaster);
                dgrdAdjOrder.DataSource = _orederDt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void ShowDrugInfo()
        {
            this.txtDgName.Text = _currentOrder.MakerDic.DrugInfo.chemname;
            this.txtDgSpec.Text = _currentOrder.MakerDic.DrugInfo.spec;
            this.txtProduct.Text = _currentOrder.MakerDic.DrugInfo.productname;
            this.txtRetailPrice.Text = _currentOrder.OldRetailPrice.ToString();
            this.txtTradePrice.Text = _currentOrder.OldTradePrice.ToString();
            this.txtPackUnit.Text = _currentOrder.LeastUnitEntity.UnitName;
        }

        private void ShowCurrentOrder()
        {
            ShowDrugInfo();
            txtNewRetail.Text = _currentOrder.NewRetailPrice.ToString();
            txtNewTrade.Text = _currentOrder.NewTradePrice.ToString();
            txtAdjDif.Text = (_currentOrder.NewRetailPrice - _currentOrder.OldRetailPrice).ToString();
        }

        private void ShowInQuery()
        {
            this.btnAddOrder.Visible = false;
            this.btnDelOrder.Visible = false;
            this.btnUpdateOrder.Visible = false;
            this.tsrbtnExecute.Visible = false;
            this.tsrbtnNew.Visible = false;
            this.txtAdjCode.ReadOnly = true;
            this.txtRemark.ReadOnly = true;
            this.txtNewRetail.ReadOnly = true;
            this.txtNewTrade.ReadOnly = true;
            this.txtDgCode.ReadOnly = true;
        }

        private void ClearOrderTextbox()
        {
            this.txtDgCode.Clear();
            this.txtDgName.Clear();
            this.txtDgSpec.Clear();
            this.txtProduct.Clear();
            this.txtPackUnit.Clear();
            this.txtTradePrice.Clear();
            this.txtRetailPrice.Clear();
            this.txtNewTrade.Clear();
            this.txtNewRetail.Clear();
            this.txtAdjDif.Clear();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckSaveOrder() == true)
                {
                    txtNewRetail_TextChanged(null, null);
                    txtNewTrade_TextChanged(null, null);
                    AddOrderToDT(_currentOrder, _orederDt);
                    ClearOrderTextbox();
                    _currentOrder = (YP_AdjOrder)(_billProcessor.BuildNewoder(0, _adjMaster));
                    //设置金额初始值
                    this.txtNewRetail.Text = "0.00";
                    this.txtNewTrade.Text = "0.00";
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
                    if (_currentOrder == null || _orederDt.Rows.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        txtNewRetail_TextChanged(null, null);
                        txtNewTrade_TextChanged(null, null);
                        DataRow currentRow = _orederDt.Rows[dgrdAdjOrder.CurrentCell.RowIndex];
                        AdjOrderToDataRow(currentRow, _currentOrder);
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
                if (MessageBox.Show("您确认要删除该明细么？", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
                if (_currentOrder == null || _orederDt.Rows.Count == 0 || dgrdAdjOrder.CurrentCell == null)
                {
                    MessageBox.Show("没有选中数据");
                    return;
                }
                else
                {
                    _orederDt.Rows.RemoveAt(dgrdAdjOrder.CurrentCell.RowIndex);
                    if (dgrdAdjOrder.CurrentCell == null)
                    {
                        _currentOrder = (YP_AdjOrder)(_billProcessor.BuildNewoder(0, _adjMaster));
                        ClearOrderTextbox();
                    }
                    else if (dgrdAdjOrder.CurrentCell.RowIndex > _orederDt.Rows.Count - 1)
                    {
                        dgrdAdjOrder.CurrentCell = dgrdAdjOrder[dgrdAdjOrder.CurrentCell.ColumnIndex, dgrdAdjOrder.CurrentCell.RowIndex - 1];
                    }
                    else
                    {
                        DataRowToAdjOrder(_orederDt.Rows[dgrdAdjOrder.CurrentCell.RowIndex], _currentOrder);
                        ShowCurrentOrder();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtNewTrade_TextChanged(object sender, EventArgs e)
        {
            if (!XcConvert.IsNumeric(this.txtNewTrade.Text))
            {
                this.txtNewTrade.Text = "0.00";
                this.txtNewTrade.SelectAll();
                _currentOrder.NewTradePrice = 0;
            }
            else
            {
                _currentOrder.NewTradePrice = Convert.ToDecimal(txtNewTrade.Text);
            }
        }

        private void txtNewRetail_TextChanged(object sender, EventArgs e)
        {
            if (!XcConvert.IsNumeric(this.txtNewRetail.Text))
            {
                this.txtNewRetail.Text = "0.00";
                this.txtNewRetail.SelectAll();
                _currentOrder.NewRetailPrice = 0;
            }
            else
            {
                _currentOrder.NewRetailPrice = Convert.ToDecimal(txtNewRetail.Text);
                txtAdjDif.Text = (_currentOrder.NewRetailPrice - _currentOrder.OldRetailPrice).ToString();
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
                _adjMaster = (YP_AdjMaster)(_billProcessor.BuildNewMaster(_adjMaster.DeptID, _adjMaster.RegPeople));
                
                _currentOrder = (YP_AdjOrder)(_billProcessor.BuildNewoder(0, _adjMaster));
                //加载数据
                LoadData();
                ClearOrderTextbox();
                ShowMaster();
                //设置金额初始值
                this.txtNewTrade.Text = "0.00";
                this.txtNewRetail.Text = "0.00";
                this.txtAdjCode.Focus();
                _currentState = ADD;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckSaveBill() == true)
                {
                    _billProcessor.SaveBill(_adjMaster, GetListOrder(), 0);
                    MessageBox.Show("调价执行成功，请及时通知各执行科室。。。");
                    tsrbtnNew_Click(null, null);
                    tsrAdjOrder.Focus();
                }
            }
            catch (Exception error)
            {                
                MessageBox.Show(error.Message);
                tsrAdjOrder.Focus();
                tsrbtnQuit.Select();
            }
        }

        private void FrmAdjOrder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F2:
                    tsrbtnNew_Click(null, null);
                    break;
                case Keys.F3:
                    tsrbtnExecute_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void txtAdjCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                _adjMaster.AdjCode = txtAdjCode.Text;
                txtRemark.Focus();                
            }
            else
            {
                _adjMaster.AdjCode = txtAdjCode.Text;
            }
        }

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtDgCode.Focus();
            }
            else
            {
                _adjMaster.Remark = txtRemark.Text;
            }
        }

        private void txtNewTrade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txtNewRetail.Focus();
            }
        }

        private void txtNewRetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.btnAddOrder.Focus();
            }
        }
        
        private void dgrdAdjOrder_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgrdAdjOrder.CurrentCell != null)
                {
                    int currentIndex = dgrdAdjOrder.CurrentCell.RowIndex;

                    DataRowToAdjOrder(_orederDt.DefaultView.ToTable().Rows[currentIndex], _currentOrder);
                    ShowCurrentOrder();
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
            _currentOrder.MakerDic.MakerDicID = Convert.ToInt32(dr["MAKERDICID"]);
            _currentOrder.MakerDicID = Convert.ToInt32(dr["MAKERDICID"]);
            _currentOrder.UnitNum = Convert.ToInt32(dr["PACKNUM"]);
            _currentOrder.MakerDic.DrugInfo.chemname = dr["CHEMNAME"].ToString();
            _currentOrder.MakerDic.DrugInfo.spec = dr["SPEC"].ToString();
            _currentOrder.MakerDic.DrugInfo.productname = dr["PRODUCTNAME"].ToString();
            _currentOrder.OldRetailPrice = Convert.ToDecimal(dr["RETAILPRICE"]);
            _currentOrder.OldTradePrice = Convert.ToDecimal(dr["TRADEPRICE"].ToString());
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                _currentOrder.LeastUnitEntity.UnitName = dr["UNITNAME"].ToString();
                _currentOrder.LeastUnit = Convert.ToInt32(dr["PACKUNIT"]);
            }
            else
            {
                _currentOrder.LeastUnitEntity.UnitName = dr["LUNITNAME"].ToString();
                _currentOrder.LeastUnit = Convert.ToInt32(dr["UNIT"]);
            }
            ShowDrugInfo();
        }

        /// <summary>
        /// 将调价明细信息表中的行记录转成调价明细
        /// </summary>
        /// <param name="dR">调价明细信息表</param>
        /// <param name="adjOrder">调价明细对象</param>
        public static void DataRowToAdjOrder(DataRow dR, YP_AdjOrder adjOrder)
        {
            try
            {
                if (dR == null || adjOrder == null)
                {
                    return;
                }
                else
                {
                    adjOrder.AdjNum = Convert.ToDecimal(dR["AdjNum"]);//调价数量
                    adjOrder.AdjRetailFee = Convert.ToDecimal(dR["AdjRetailFee"]);//调整零售金额
                    adjOrder.AdjTradeFee = Convert.ToDecimal(dR["AdjTradeFee"]);//调整批发金额
                    adjOrder.Audit_Flag = Convert.ToInt32(dR["Audit_Flag"]);//审核标识
                    adjOrder.BillNum = Convert.ToInt32(dR["BillNum"]);//单据号
                    adjOrder.DeptID = Convert.ToInt32(dR["DeptID"]);//科室ＩＤ
                    adjOrder.LeastUnit = Convert.ToInt32(dR["LeastUnit"]);//单位
                    adjOrder.MakerDicID = Convert.ToInt32(dR["MakerDicID"]);//厂家典标识ID
                    adjOrder.MasterIAdjPriceD = Convert.ToInt32(dR["MasterIAdjPriceD"]);//调价表头ID
                    adjOrder.NewRetailPrice = Convert.ToDecimal(dR["NewRetailPrice"]);//新零售价
                    adjOrder.NewTradePrice = Convert.ToDecimal(dR["NewTradePrice"]);//新批发价
                    adjOrder.OldRetailPrice = Convert.ToDecimal(dR["OldRetailPrice"]);//老零售价
                    adjOrder.OldTradePrice = Convert.ToDecimal(dR["OldTradePrice"]);//老批发价
                    adjOrder.OrderAdjPriceID = Convert.ToInt32(dR["OrderAdjPriceID"]);//调价明细ID
                    adjOrder.UnitNum = Convert.ToInt32(dR["UnitNum"]);//单位比例
                    adjOrder.MakerDic.DrugInfo.spec = dR["SPEC"].ToString();//药品规格
                    adjOrder.MakerDic.DrugInfo.chemname = dR["CHEMNAME"].ToString();//药品名称
                    adjOrder.LeastUnitEntity.UnitName = dR["UNITNAME"].ToString();//单位名称
                    adjOrder.MakerDic.DrugInfo.productname = dR["PRODUCTNAME"].ToString();//厂家名称
                }
                return;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 将调价明细对象转成调价明细表中行记录
        /// </summary>
        /// <param name="dR">明细表行记录对象</param>
        /// <param name="adjOrder">调价明细对象</param>
        public static void AdjOrderToDataRow(DataRow dR, YP_AdjOrder adjOrder)
        {
            try
            {
                if (dR == null || adjOrder == null)
                {
                    return;
                }
                else
                {
                    dR["AdjNum"] = adjOrder.AdjNum;
                    dR["AdjRetailFee"] = adjOrder.AdjRetailFee;
                    dR["AdjTradeFee"] = adjOrder.AdjTradeFee;
                    dR["Audit_Flag"] = adjOrder.Audit_Flag;
                    dR["BillNum"] = adjOrder.BillNum;
                    dR["DeptID"] = adjOrder.DeptID;
                    dR["LeastUnit"] = adjOrder.LeastUnit;
                    dR["MakerDicID"] = adjOrder.MakerDicID;
                    dR["MasterIAdjPriceD"] = adjOrder.MasterIAdjPriceD;
                    dR["NewRetailPrice"] = adjOrder.NewRetailPrice;
                    dR["NewTradePrice"] = adjOrder.NewTradePrice;
                    dR["OldRetailPrice"] = adjOrder.OldRetailPrice;
                    dR["OldTradePrice"] = adjOrder.OldTradePrice;
                    dR["OrderAdjPriceID"] = adjOrder.OrderAdjPriceID;
                    dR["UnitNum"] = adjOrder.UnitNum;
                    dR["SPEC"] = adjOrder.MakerDic.DrugInfo.spec;
                    dR["CHEMNAME"] = adjOrder.MakerDic.DrugInfo.chemname;
                    dR["UNITNAME"] = adjOrder.LeastUnitEntity.UnitName;
                    dR["PRODUCTNAME"] = adjOrder.MakerDic.DrugInfo.productname;
                    dR["AdjDif"] = adjOrder.NewRetailPrice - adjOrder.OldRetailPrice;
                }
                return;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 添加调价明细对象到调价明细信息表中
        /// </summary>
        /// <param name="order">调价明细对象</param>
        /// <param name="orderDt">调价明细信息表</param>
        public static void AddOrderToDT(YP_AdjOrder order, DataTable orderDt)
        {
            try
            {
                DataRow newRow = orderDt.NewRow();
                AdjOrderToDataRow(newRow, order);
                //判断新增明细药品是否已经存在于入库单明细表中
                for (int index = 0; index < orderDt.Rows.Count; index++)
                {
                    if (Convert.ToInt32(orderDt.Rows[index]["MAKERDICID"]) == Convert.ToInt32(newRow["MAKERDICID"]))
                    {
                        throw new Exception("该药品已经存在于明细中,无法添加....");
                    }
                }
                
                orderDt.Rows.Add(newRow);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private List<BillOrder> GetListOrder()
        {
            if (_orederDt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                List<BillOrder> listOrder = new List<BillOrder>();               
                for (int index = 0; index < _orederDt.Rows.Count; index++)
                {
                    YP_AdjOrder order = new YP_AdjOrder();
                    HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(_orederDt, index, order);
                    listOrder.Add(order);
                }
                return listOrder;
            }
        }

        private void lblDgName_Click(object sender, EventArgs e)
        {

        }

    }
}
