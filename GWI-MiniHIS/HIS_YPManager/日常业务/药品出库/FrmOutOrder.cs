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
    
    public partial class FrmOutOrder : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public YP_OutMaster _currentMaster;
        private YP_OutOrder _currentOrder;
        private long _currentUserId;
        private long _currentDeptId;
        private DataTable _deptInfoDt;
        private DataTable _drugInfoDt;
        private DataTable _outOrderDt;
        private DataTable _userInfoDt;
        private BillProcessor _billProcessor;
        private BillQuery _billQuery;
        private StoreQuery _storQuery;
        private string _opType;
        private string _belongSystem;
        const int DEFMONTH = 2;
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
        public FrmOutOrder()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currentUserId">用户ＩＤ</param>
        /// <param name="currentDeptId">用户部门ＩＤ</param>
        /// <param name="beginState">起始状态</param>
        /// <param name="opType">业务类型</param>
        public FrmOutOrder(long currentUserId, long currentDeptId, int beginState, string opType, string belongSystem)
        {
            
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _currentState = beginState;
            _opType = opType;
            _belongSystem = belongSystem;
            _storQuery = StoreFactory.GetQuery(belongSystem);            
            InitializeComponent();         
        }

        private void FrmOutOrder_Load(object sender, EventArgs e)
        {
            txtApplyPeople.Text = new User(_currentUserId).Name;
            if (_opType == ConfigManager.OP_YK_REPORTLOSS
                    || _opType == ConfigManager.OP_YF_REPORTLOSS)
            {
                txtOpType.Text = "药品报损";
                txtOutDept.Text = "无领药科室";
                txtOutDept.ReadOnly = true;
                txtApplyPeople.ReadOnly = true;
                txtByOptype.ReadOnly = false;
            }
            else
            {
                this.txtOpType.Text = "科室领药";
                txtByOptype.ReadOnly = true;
            }
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {                
                _billQuery = BillFactory.GetQuery(ConfigManager.DEF_YK_OUT);             
            }
            else if (_belongSystem == ConfigManager.YF_SYSTEM)
            {
                _billQuery = BillFactory.GetQuery(ConfigManager.DEF_YF_OUT);
                txtBatchNum.ReadOnly = true;
            }
            _billProcessor = BillFactory.GetProcessor(_opType);          
            //如果是添加单据状态
            if (_currentState == ADD)
            {
                //生成一个新的单据表头
                _currentMaster = (YP_OutMaster)(_billProcessor.BuildNewMaster(_currentDeptId, _currentUserId));
                _currentMaster.OpType = _opType;
                _currentOrder = (YP_OutOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
                LoadData();
            }
            else if (_currentState == UPDATE)
            {
                _currentOrder = (YP_OutOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
                LoadData();               
                dgrdOrderInfo_CurrentCellChanged(null, null);
            }
            //显示当前表头信息
            ShowCurrentMaster();
        
        }

        private void LoadData()
        {
            dgrdOrderInfo.AutoGenerateColumns = false;
            _deptInfoDt = IN_InterFace.LoadOutStoreDept((int)_currentDeptId);
//add  平级药房调拨 张运辉 [20100531]
            DataTable Deptidt = _deptInfoDt.Clone();
            DataRow[] dRows;
            dRows = _deptInfoDt.Select("NAME<>'药库' and DEPT_ID<>" + (int)_currentDeptId);
            foreach (DataRow dr in dRows)
            {
                Deptidt.Rows.Add(dr.ItemArray);
            }
            _deptInfoDt = Deptidt;

            _userInfoDt = IN_InterFace.LoadAllUser();
            _drugInfoDt = StoreFactory.GetQuery(_belongSystem).LoadDrugInfo((int)_currentDeptId);
            _outOrderDt = _billQuery.LoadOrder(_currentMaster);
            txtOutDept.SetSelectionCardDataSource(_deptInfoDt);
            txtApplyPeople.SetSelectionCardDataSource(_userInfoDt);
            txtDgCode.SetSelectionCardDataSource(_drugInfoDt);
            this.dgrdOrderInfo.DataSource = _outOrderDt;
        }

        private void ShowCurrentMaster()
        {
            if (_currentMaster != null)
            {

                this.cobOutDate.Value = _currentMaster.BillDate;
                this.txtRemark.Text = _currentMaster.ReMark;
                if (_currentMaster.OutDeptId != 0)
                {
                    this.txtOutDept.Text = new Deptment((long)(int)_currentMaster.OutDeptId).Name;
                }
            }
        }

        private bool CheckSaveBill()
        {
            if (_outOrderDt.Rows.Count < 1)
            {
                MessageBox.Show("没有药品需要出库");
                return false;
            }
            if (_currentMaster.OutDeptId == 0 && _currentMaster.OpType == ConfigManager.OP_YK_DEPTDRAW)
            {
                MessageBox.Show("请选择领药科室");
                txtOutDept.Focus();
                txtOutDept.SelectAll();
                return false;
            }
            return true;
        }

        private bool CheckSaveOrder()
        {
            if (_currentOrder == null)
            {
                MessageBox.Show("请选择出库单明细");
                return false;
            }
            if (_currentOrder.MakerDicID == 0)
            {
                MessageBox.Show("请选择药品信息");
                txtDgCode.Focus();
                txtDgCode.SelectAll();
                return false;
            }
            if (_currentOrder.OutNum == 0 )
            {
                MessageBox.Show("请输入出库数量");
                txtOutNum.Focus();
                txtOutNum.SelectAll();
                return false;
            }
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                if (_currentOrder.ProductNum == null || 
                    _currentOrder.ProductNum == "")
                {
                    MessageBox.Show("请输入批次号");
                    txtBatchNum.Focus();
                    txtBatchNum.SelectAll();
                    return false;
                }
            }
            return true;
        }

        private void ShowDrugInfo()
        {
            this.txtDgName.Text = _currentOrder.MakerDic.DrugInfo.chemname;
            this.txtDgSpec.Text = _currentOrder.MakerDic.DrugInfo.spec;
            this.txtProduct.Text = _currentOrder.MakerDic.DrugInfo.productname;
            this.txtRetailPrice.Text = _currentOrder.RetailPrice.ToString();
            this.txtTradePrice.Text = _currentOrder.TradePrice.ToString();
            this.txtPackUnit.Text = _currentOrder.LeastUnitEntity.UnitName;
            
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                this.txtCurrentStore.Text = _storQuery.QueryNum(_currentOrder.MakerDicID, (int)_currentDeptId).ToString("0.00");
            }
            else if (_belongSystem == ConfigManager.YF_SYSTEM)
            {
                decimal currentNum = _storQuery.QueryNum(_currentOrder.MakerDicID, _currentMaster.DeptID)
                    / _currentOrder.UnitNum;
                if (currentNum < 0)
                {
                    currentNum = 0;
                }
                this.txtCurrentStore.Text = currentNum.ToString("0.00");
            }
        }

        private void cobOutDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (_currentMaster.OpType == ConfigManager.OP_YK_DEPTDRAW
                    ||_currentMaster.OpType == ConfigManager.OP_YF_DEPTDRAW)
                {
                    this.txtOutDept.Focus();
                }
                else
                {
                    this.txtRemark.Focus();
                }
            }
        }

        private void txtOutNum_TextChanged(object sender, EventArgs e)
        {
            bool isNegtiveMark = (txtOutNum.Text.Trim() == "-"?true:false);
            if (isNegtiveMark)
            {
                return;
            }
            if (!XcConvert.IsNumeric(this.txtOutNum.Text))
            {
                this.txtOutNum.Text = "";
                _currentOrder.RetailFee = 0;
                _currentOrder.TradeFee = 0;
                _currentOrder.OutNum = 0;
            }
            else
            {
                if (Convert.ToDecimal(this.txtOutNum.Text) <= Convert.ToDecimal(this.txtCurrentStore.Text))
                {
                    _currentOrder.RetailFee = _currentOrder.RetailPrice * Convert.ToDecimal(txtOutNum.Text.Trim());
                    _currentOrder.TradeFee = _currentOrder.TradePrice * Convert.ToDecimal(txtOutNum.Text.Trim());
                    _currentOrder.OutNum = Convert.ToDecimal(txtOutNum.Text);
                }
                else
                {
                    if (_currentState == ADD)
                    {
                        MessageBox.Show("出库量太大，已经超过库存总量");
                        this.txtOutNum.Text = "";
                        _currentOrder.RetailFee = 0;
                        _currentOrder.TradeFee = 0;
                        _currentOrder.OutNum = 0;
                        this.txtOutNum.Focus();
                    }
                    return;
                }
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckSaveOrder() == true)
                {
                    txtOutNum_TextChanged(null, null);
                    AddOrderToDT(_currentOrder, _outOrderDt);
                    ClearOrderTextbox();
                    if(_opType==ConfigManager.OP_YF_PJDB)
                    _currentOrder = ChangeInorderToOutorder((YP_InOrder)(_billProcessor.BuildNewoder((int)_currentDeptId,ChangeOutmasterToIntmaster( _currentMaster))));
                    else
                    _currentOrder = (YP_OutOrder)(_billProcessor.BuildNewoder((int)_currentDeptId, _currentMaster));
                    this.txtDgCode.Focus();
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
            this.txtOutNum.Clear();
            this.txtTradePrice.Clear();
            this.txtRetailPrice.Clear();            
            this.txtCurrentStore.Clear();
            this.txtBatchNum.Clear();
            this.cobValidityDate.Value = _currentMaster.RegTime.AddMonths(2);
            this.txtByOptype.Clear();
        }

        private void btnDelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentOrder == null || _outOrderDt.Rows.Count == 0 || dgrdOrderInfo.CurrentCell == null)
                {
                    MessageBox.Show("没有选中数据");
                    return;
                }
                else
                {
                    _outOrderDt.Rows.RemoveAt(dgrdOrderInfo.CurrentCell.RowIndex);
                    if (dgrdOrderInfo.CurrentCell == null)
                    {
                        _currentOrder = (YP_OutOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
                        ClearOrderTextbox();
                    }

                    else if (dgrdOrderInfo.CurrentCell.RowIndex > _outOrderDt.Rows.Count - 1)
                    {
                        dgrdOrderInfo.CurrentCell = dgrdOrderInfo[dgrdOrderInfo.CurrentCell.ColumnIndex, dgrdOrderInfo.CurrentCell.RowIndex - 1];
                    }
                    else
                    {
                        DataRowToOutorder(_outOrderDt.Rows[dgrdOrderInfo.CurrentCell.RowIndex], _currentOrder);
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


        private void ShowCurrentOrder()
        {
            ShowDrugInfo();
            this.txtOutNum.Text = _currentOrder.OutNum.ToString();
            this.cobValidityDate.Value = _currentOrder.ValidityDate;
            this.txtByOptype.Text = _currentOrder.OutReason;
            this.txtBatchNum.Text = _currentOrder.ProductNum;
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckSaveOrder() == true)
                {
                    if (_currentOrder == null || _outOrderDt.Rows.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        txtOutNum_TextChanged(null, null);
                        DataRow currentRow = _outOrderDt.Rows[dgrdOrderInfo.CurrentCell.RowIndex];
                        OutorderToDataRow(currentRow, _currentOrder);
                    }
                    MessageBox.Show("更新成功");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
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
                if (_opType == ConfigManager.OP_YF_PJDB)//平级调拨 张运辉
                {
                    _currentMaster = ChangeInmasterToOutmaster(((YP_InMaster)(_billProcessor.BuildNewMaster(_currentDeptId, _currentUserId))));
                    _currentMaster.OpType = _opType;
                    _currentOrder = ChangeInorderToOutorder((YP_InOrder)(_billProcessor.BuildNewoder(_currentDeptId, ChangeOutmasterToIntmaster(_currentMaster))));

                }
                else
                {
                _currentMaster = (YP_OutMaster)(_billProcessor.BuildNewMaster(_currentDeptId, _currentUserId));
                _currentMaster.OpType = _opType;
                _currentOrder = (YP_OutOrder)(_billProcessor.BuildNewoder(_currentDeptId, _currentMaster));
                }

                //加载数据
                _outOrderDt = _billQuery.LoadOrder(_currentMaster);
                this.dgrdOrderInfo.DataSource = _outOrderDt;
                ClearOrderTextbox();
                ShowCurrentMaster();
                //设置金额初始值
                this.cobOutDate.Focus();
                _currentState = ADD;
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
                if (ConfigManager.IsChecking(_currentDeptId))
                {
                    MessageBox.Show("药品正在盘点中......");
                    return;
                }
                if (CheckSaveBill() == true)
                {
                    if (_currentState == ADD)
                    {
                        if(_opType==ConfigManager.OP_YF_PJDB)
                            _billProcessor.SaveBill(ChangeOutmasterToIntmaster(_currentMaster), GetListOrder(), _currentDeptId);
                        else                        
                        _billProcessor.SaveBill(_currentMaster, GetListOrder(), _currentDeptId);
                    }
                    else
                    {
                        if (_opType == ConfigManager.OP_YF_APPLYIN)
                            _billProcessor.UpdateBill(ChangeOutmasterToIntmaster(_currentMaster), GetListOrder(), _currentDeptId);
                        else 
                        _billProcessor.UpdateBill(_currentMaster, GetListOrder(), _currentDeptId);
                    }
                    MessageBox.Show("保存成功,请及时审核以确保药品出库。。。");
                    tsrbtnNew_Click(null, null);
                    tsrOutOrder.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

//add  平级药房调拨 张运辉 [20100531]
        /// <summary>
        /// 将药房出库单表头转换为药房申请入库单表头
        /// </summary>
        /// <param name="inMaster">入库单头表</param>
        /// <param name="storedeptId">出库库房ＩＤ</param>
        /// <param name="outMaster">出库单表头</param>
        /// <returns>出库单表头</returns>
        private  YP_InMaster ChangeOutmasterToIntmaster(YP_OutMaster outMaster)
        {
            YP_InMaster inMaster=new YP_InMaster();
            //outMaster.BillDate = inMaster.BillDate;
            //outMaster.Del_Flag = 0;
            //outMaster.OpType = ConfigManager.OP_YK_OUTTOYF;
            //outMaster.OutFee = inMaster.RetailFee;
            //outMaster.RegTime = inMaster.RegTime;
            //outMaster.RelationNum = inMaster.BillNum;
            //outMaster.ReMark = inMaster.ReMark;
            //outMaster.RetailFee = inMaster.RetailFee;
            //outMaster.TradeFee = inMaster.TradeFee;
            //outMaster.DeptID = storedeptId;
            //outMaster.OutDeptId = inMaster.DeptID;
            //outMaster.RegPeopleID = inMaster.RegPeopleID;
            //return outMaster;
            inMaster.BillDate=outMaster.BillDate;
            inMaster.OpType = _opType;
            inMaster.RetailFee = outMaster.OutFee;
            inMaster.RegTime = outMaster.RegTime;
            inMaster.BillNum = outMaster.BillNum;
            inMaster.ReMark = outMaster.ReMark;
            inMaster.RetailFee = outMaster.RetailFee;
            inMaster.TradeFee = outMaster.TradeFee;
            inMaster.DeptID = outMaster.OutDeptId;
            inMaster.RegPeopleID = outMaster.RegPeopleID;
            return inMaster;


        }

//add  平级药房调拨 张运辉 [20100531]
        /// <summary>
        /// 将药房申请入库单表头转换为药库出库单表头
        /// </summary>
        /// <param name="inMaster">入库单头表</param>
        /// <param name="storedeptId">出库库房ＩＤ</param>
        /// <param name="outMaster">出库单表头</param>
        /// <returns>出库单表头</returns>
        private  YP_OutMaster ChangeInmasterToOutmaster(YP_InMaster inMaster )
        {
            YP_OutMaster outMaster= new YP_OutMaster();
            outMaster.BillDate = inMaster.BillDate;
            outMaster.Del_Flag = 0;
            outMaster.OpType = inMaster.OpType;
            outMaster.OutFee = inMaster.RetailFee;
            outMaster.RegTime = inMaster.RegTime;
            outMaster.RelationNum = inMaster.BillNum;
            outMaster.ReMark = inMaster.ReMark;
            outMaster.RetailFee = inMaster.RetailFee;
            outMaster.TradeFee = inMaster.TradeFee;
            outMaster.DeptID = (int)_currentDeptId;
            outMaster.OutDeptId = inMaster.DeptID;
            outMaster.RegPeopleID = inMaster.RegPeopleID;
            return outMaster;
        }


        private void FrmOutOrder_KeyDown(object sender, KeyEventArgs e)
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

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            _currentMaster.ReMark = txtRemark.Text;
            if (e.KeyValue == 13)
            {
                this.txtDgCode.Focus();
            }
        }

        
        private void txtOutNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (_currentMaster.OpType == ConfigManager.OP_YK_REPORTLOSS
                    ||_currentMaster.OpType == ConfigManager.OP_YF_REPORTLOSS)
                {
                    this.txtByOptype.Focus();
                    this.txtByOptype.SelectAll();
                }
                else
                {
                    btnAddOrder.Focus();
                }
            }
        }

        private void txtCurrentStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.btnAddOrder.Focus();
            }
        }

        private void txtByOptype_KeyDown(object sender, KeyEventArgs e)
        {
            if (_opType == ConfigManager.OP_YK_REPORTLOSS||
                _opType == ConfigManager.OP_YF_REPORTLOSS)
            {
                if (e.KeyValue == 13)
                {
                    btnAddOrder.Focus();
                }
                _currentOrder.OutReason = this.txtByOptype.Text;
            }
        }


        private void dgrdOrderInfo_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgrdOrderInfo.CurrentCell != null)
                {
                    int currentIndex = dgrdOrderInfo.CurrentCell.RowIndex;
                    DataRowToOutorder(_outOrderDt.DefaultView.ToTable().Rows[currentIndex], _currentOrder);
                    ShowCurrentOrder();
                    if (!chkShowStoreBatch.Checked)
                        txtBatchNum.SetSelectionCardDataSource(_storQuery.LoadBatchWithDelete(_currentOrder.MakerDicID,
                            (int)_currentDeptId));
                    else
                        txtBatchNum.SetSelectionCardDataSource(_storQuery.LoadBatch(_currentOrder.MakerDicID,
                            (int)_currentDeptId));
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtOutDept_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtOutDept.ReadOnly == true)
            {
                return;
            }
            DataRow dr = (DataRow)SelectedValue;
            if (dr != null)
            {
//add  平级药房调拨 张运辉 [20100531]
                if (dr["TYPE_CODE"].ToString() == "002")
                {
                    _opType = ConfigManager.OP_YF_PJDB;
                    _billProcessor = BillFactory.GetProcessor(_opType);
                }
                _currentMaster.OutDeptId = Convert.ToInt32(txtOutDept.MemberValue);
            }
        }

        private void txtDgCode_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtDgCode.ReadOnly)
            {
                return;
            }
            DataRow dr = (DataRow)SelectedValue;
            if (dr != null)
            {
                txtDgCode.Text = "";
                _currentOrder.MakerDic.MakerDicID = Convert.ToInt32(txtDgCode.MemberValue);
                _currentOrder.MakerDicID = Convert.ToInt32(dr["MAKERDICID"]);
                _currentOrder.LeastUnit = Convert.ToInt32(dr["PACKUNIT"]);
                _currentOrder.UnitNum = Convert.ToInt32(dr["PACKNUM"]);
                _currentOrder.MakerDic.DrugInfo.chemname = dr["CHEMNAME"].ToString();
                _currentOrder.MakerDic.DrugInfo.spec = dr["SPEC"].ToString();
                _currentOrder.MakerDic.DrugInfo.productname = dr["PRODUCTNAME"].ToString();
                _currentOrder.RetailPrice = Convert.ToDecimal(dr["RETAILPRICE"]);
                _currentOrder.TradePrice = Convert.ToDecimal(dr["TRADEPRICE"].ToString());
                _currentOrder.ValidityDate = _currentMaster.BillDate.AddMonths(DEFMONTH);
                _currentOrder.LeastUnitEntity.UnitName = dr["UNITNAME"].ToString();
                if (!chkShowStoreBatch.Checked)
                    txtBatchNum.SetSelectionCardDataSource(_storQuery.LoadBatchWithDelete(_currentOrder.MakerDicID,
                        (int)_currentDeptId));
                else
                    txtBatchNum.SetSelectionCardDataSource(_storQuery.LoadBatch(_currentOrder.MakerDicID,
                        (int)_currentDeptId));
                ShowDrugInfo();
                if (_belongSystem == ConfigManager.YK_SYSTEM)
                {
                    txtBatchNum.Focus();
                }
                else
                {
                    txtOutNum.Focus();
                }
            }
        }

        /// <summary>
        /// 从出库明细信息表中读取出库明细对象
        /// </summary>
        /// <param name="dtTable">
        /// 出库明细信息表
        /// </param>
        /// <param name="index">
        /// 指定行记录索引
        /// </param>
        /// <returns>
        /// 出库明细对象
        /// </returns>
        private YP_OutOrder GetOutOrderFromDt(DataTable dtTable, int index)
        {

            try
            {
                if (dtTable.Rows.Count < index || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                YP_OutOrder currentOutorder = new YP_OutOrder();
                ApiFunction.DataTableToObject(dtTable, index, currentOutorder);
                return currentOutorder;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
//add  平级药房调拨 张运辉 [20100531]
        private YP_InOrder GetIntOrderFromDt(DataTable dtTable, int index)
        {

            try
            {
                if (dtTable.Rows.Count < index || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                YP_InOrder currentIntorder = new YP_InOrder();
                ApiFunction.DataTableToObject(dtTable, index, currentIntorder);
                currentIntorder.InNum = decimal.Parse(dtTable.Rows[index]["OUTNUM"].ToString());
                return currentIntorder;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 将出库明细信息表中的行记录转成出库明细对象
        /// </summary>
        /// <param name="dR">行对象</param>
        /// <param name="outOrder">出库明细对象</param>
        private void DataRowToOutorder(DataRow dR, YP_OutOrder outOrder)
        {
            try
            {
                if (dR == null || outOrder == null)
                {
                    return;
                }
                else
                {
                    outOrder.Audit_Flag = Convert.ToInt32(dR["Audit_Flag"]);//审核标识
                    outOrder.BillNum = Convert.ToInt32(dR["BillNum"]);//单据号
                    outOrder.DeptID = Convert.ToInt32(dR["DeptID"]);//科室ＩＤ
                    outOrder.OutNum = Convert.ToDecimal(dR["OutNum"]);//出库数量
                    outOrder.OutStorageID = Convert.ToInt32(dR["OutStorageID"]);//明细ＩＤ
                    outOrder.LeastUnit = Convert.ToInt32(dR["LeastUnit"]);//出库单位
                    outOrder.MakerDicID = Convert.ToInt32(dR["MakerDicID"]);//药品厂家典ID
                    outOrder.MasterOutStorageID = Convert.ToInt32(dR["MasterOutStorageID"]);//出库表头ID
                    outOrder.RecScale = Convert.ToDecimal(dR["RecScale"]);//扣率
                    outOrder.Remark = dR["Remark"].ToString();//备注
                    outOrder.RetailFee = Convert.ToDecimal(dR["RetailFee"]);//零售金额
                    outOrder.RetailPrice = Convert.ToDecimal(dR["RetailPrice"]);//零售价
                    outOrder.TradeFee = Convert.ToDecimal(dR["TradeFee"]);//批发金额
                    outOrder.TradePrice = Convert.ToDecimal(dR["TradePrice"]);//批发价
                    outOrder.UnitNum = Convert.ToInt32(dR["UnitNum"]);//单位比例
                    outOrder.ValidityDate = Convert.ToDateTime(dR["ValidityDate"]);//到效日期
                    outOrder.MakerDic.DrugInfo.spec = dR["SPEC"].ToString();//规格
                    outOrder.MakerDic.DrugInfo.chemname = dR["CHEMNAME"].ToString();//品名
                    outOrder.LeastUnitEntity.UnitName = dR["UNITNAME"].ToString();//单位名称
                    outOrder.MakerDic.DrugInfo.productname = dR["PRODUCTNAME"].ToString();//厂家名称
                    outOrder.OutReason = dR["OutReason"].ToString();//出库原因
                    outOrder.ProductNum = dR["ProductNum"].ToString();//批次号

                }
                return;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 将出库明细对象转成出库信息表中行记录
        /// </summary>
        /// <param name="dR">数据表记录行对象</param>
        /// <param name="outOrder">出库明细对象</param>
        private void OutorderToDataRow(DataRow dR, YP_OutOrder outOrder)
        {
            try
            {
                if (dR == null || outOrder == null)
                {
                    return;
                }
                else
                {
                    dR["Audit_Flag"] = outOrder.Audit_Flag;
                    dR["BillNum"] = outOrder.BillNum;
                    dR["DeptID"] = outOrder.DeptID;
                    dR["OutNum"] = outOrder.OutNum;
                    dR["OutStorageID"] = outOrder.OutStorageID;
                    dR["LeastUnit"] = outOrder.LeastUnit;
                    dR["MakerDicID"] = outOrder.MakerDicID;
                    dR["MasterOutStorageID"] = outOrder.MasterOutStorageID;
                    dR["RecScale"] = outOrder.RecScale;
                    dR["Remark"] = outOrder.Remark;
                    dR["RetailFee"] = outOrder.RetailFee;
                    dR["RetailPrice"] = outOrder.RetailPrice;
                    dR["TradeFee"] = outOrder.TradeFee;
                    dR["TradePrice"] = outOrder.TradePrice;
                    dR["UnitNum"] = outOrder.UnitNum;
                    dR["ValidityDate"] = outOrder.ValidityDate;
                    dR["SPEC"] = outOrder.MakerDic.DrugInfo.spec;
                    dR["CHEMNAME"] = outOrder.MakerDic.DrugInfo.chemname;
                    dR["UNITNAME"] = outOrder.LeastUnitEntity.UnitName;
                    dR["PRODUCTNAME"] = outOrder.MakerDic.DrugInfo.productname;
                    dR["OutReason"] = outOrder.OutReason;
                    dR["ProductNum"] = outOrder.ProductNum;//批次号
                }
                return;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 添加出库明细对象到出库明细信息表中
        /// </summary>
        /// <param name="order">
        /// 出库明细对象
        /// </param>
        /// <param name="orderDt">
        /// 出库明细信息表
        /// </param>
        private void AddOrderToDT(YP_OutOrder order, DataTable orderDt)
        {
            try
            {
                DataRow newRow = orderDt.NewRow();
                //出库明细对象转成明细信息表中行记录
                OutorderToDataRow(newRow, order);
                for (int index = 0; index < orderDt.Rows.Count; index++)
                {
                    if ((Convert.ToInt32(orderDt.Rows[index]["MAKERDICID"]) == Convert.ToInt32(newRow["MAKERDICID"]))
                        &&(orderDt.Rows[index]["PRODUCTNUM"].ToString() == newRow["PRODUCTNUM"].ToString()))
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
//add  平级药房调拨 张运辉 [20100531]
        /// <summary>
        /// 将药房申请入库单明细转换为药库出库单明细
        /// </summary>
        /// <param name="inOrder">入库单明细</param>
        /// <param name="outMaster">药库出库单表头</param>
        /// <returns>药库出库单明细</returns>
        private  YP_OutOrder ChangeInorderToOutorder(YP_InOrder inOrder)
        {
            YP_OutOrder outOrder = new YP_OutOrder();
            outOrder.MakerDic = new YP_MakerDic();
            outOrder.LeastUnitEntity = new YP_UnitDic();
           
            outOrder.Audit_Flag = 0;
            outOrder.LeastUnit = inOrder.LeastUnit;
            outOrder.MakerDicID = inOrder.MakerDicID;
            //outOrder.MasterOutStorageID = outMaster.MasterOutStorageID;
            outOrder.OutNum = inOrder.InNum;
            outOrder.ProductNum = inOrder.BatchNum;
            outOrder.RecScale = inOrder.RecScale;
            outOrder.Remark = inOrder.Remark;
            outOrder.RetailFee = inOrder.RetailFee;
            outOrder.RetailPrice = inOrder.RetailPrice;
            outOrder.TradeFee = inOrder.TradeFee;
            outOrder.TradePrice = inOrder.TradePrice;
            outOrder.UnitNum = inOrder.UnitNum;
            outOrder.ValidityDate = inOrder.ValidityDate;
            outOrder.DeptID =(int)_currentDeptId;
            outOrder.OutDeptID = inOrder.DeptID;
            return outOrder;
        }
        private List<BillOrder> GetListOrder()
        {
            if (_outOrderDt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                List<BillOrder> listOrder = new List<BillOrder>();
                for (int index = 0; index < _outOrderDt.Rows.Count; index++)
                {
                    if (_opType == ConfigManager.OP_YF_PJDB)
                        listOrder.Add(GetIntOrderFromDt(_outOrderDt, index));
                    else
                    listOrder.Add(GetOutOrderFromDt(_outOrderDt, index));
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
            DataRow batchRow = (DataRow)SelectedValue;
            _currentOrder.ProductNum = Convert.ToString(txtBatchNum.MemberValue);
            _currentOrder.ValidityDate = Convert.ToDateTime(batchRow["VALIDITYDATE"]);
            this.cobValidityDate.Value = _currentOrder.ValidityDate;
            
        }

        private void txtApplyPeople_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtApplyPeople.ReadOnly == true)
            {
                return;
            }
            DataRow dr = (DataRow)SelectedValue;
            if (dr != null)
            {
                _currentMaster.RegPeopleID = Convert.ToInt32(txtApplyPeople.MemberValue);
            }
        }

        private void cobOutDate_ValueChanged(object sender, EventArgs e)
        {
            if (cobOutDate.Value != null)
            {
                _currentMaster.BillDate = cobOutDate.Value;
            }
        }
    }
}
