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
using GWMHIS.BussinessLogicLayer;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_YPManager
{
    public partial class FrmDrugMaker : GWI.HIS.Windows.Controls.BaseMainForm
    {
        #region 属性
        public YP_SpecDic _currentSpec;
        private YP_MakerDic _currentMaker = new YP_MakerDic();
        private DataTable _makerDt;
        private DataTable _medicareDt;
        private DataTable _productDt;
        private int _currentState = NORMAL;
        const int ADD = 1;
        const int UPDATE = 2;
        const int NORMAL = 3;
        #endregion
        public FrmDrugMaker()
        {
            InitializeComponent();
        }

        #region 按钮控件

        private void chkUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUse.Checked == true)
            {
                _currentMaker.GetWay = 1;
            }
            else
            {
                _currentMaker.GetWay = 0;
            }
        }

        private void chkOwnPay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOwnPay.Checked == true)
            {
                _currentMaker.OwnPay_Flag = 1;
            }
            else 
            {
                _currentMaker.OwnPay_Flag = 0;
            }
        }

        private void chkRecipe_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRecipe.Checked == true)
            {
                _currentMaker.Recipe_Flag = 1;
            }
            else
            {
                _currentMaker.Recipe_Flag = 0;
            }
        }

        private void chkVirulent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVirulent.Checked == true)
            {
                _currentMaker.Virulent_Flag = 1;
            }
            else
            {
                _currentMaker.Virulent_Flag = 0;
            }
        }

        private void chkNarcotic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNarcotic.Checked == true)
            {
                _currentMaker.Narcotic_Flag = 1;
            }
            else
            {
                _currentMaker.Narcotic_Flag = 0;
            }
        }

        private void chkLunacy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLunacy.Checked == true)
            {
                _currentMaker.Lunacy_Flag = 1;
            }
            else
            {
                _currentMaker.Lunacy_Flag = 0;
            }
        }

        private void chkSkintest_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSkintest.Checked == true)
            {
                _currentMaker.Skintest_Flag = 1;
            }
            else
            {
                _currentMaker.Skintest_Flag = 0;
            }
        }

        #endregion
        #region 文本框控件

        #region 限制数字
        private void txtRetailPrice_TextChanged(object sender, EventArgs e)
        {
            if (_currentState == UPDATE || _currentState == ADD)
            {
                if (XcConvert.IsNumeric(this.txtRetailPrice.Text))
                {
                    _currentMaker.RetailPrice = Convert.ToDecimal(this.txtRetailPrice.Text);
                }
                else
                {
                    this.txtRetailPrice.Text = "";
                    _currentMaker.RetailPrice = 0;
                }
            }
        }

        private void txtTradePrice_TextChanged(object sender, EventArgs e)
        {
            if (_currentState == UPDATE || _currentState == ADD)
            {
                if (XcConvert.IsNumeric(this.txtTradePrice.Text))
                {
                    _currentMaker.TradePrice = Convert.ToDecimal(this.txtTradePrice.Text);
                    //如果是中药
                    if (_currentSpec.TypeDicID == 3)
                    {
                        _currentMaker.RetailPrice = Convert.ToDecimal((_currentMaker.TradePrice*((decimal)1.25)).ToString("0.00"));                        
                    }
                    else if (_currentSpec.TypeDicID == 1 || _currentSpec.TypeDicID == 2)
                    {
                        _currentMaker.RetailPrice = Convert.ToDecimal((_currentMaker.TradePrice * ((decimal)1.15)).ToString("0.00"));
                    }
                    else
                    {
                        _currentMaker.RetailPrice = Convert.ToDecimal((_currentMaker.TradePrice * ((decimal)1.0)).ToString("0.00"));
                    }
                    txtRetailPrice.Text = _currentMaker.RetailPrice.ToString();
                }
                else
                {
                    this.txtTradePrice.Text = "";
                    _currentMaker.RetailPrice = 0;
                    txtRetailPrice.Text = "0.00";
                    _currentMaker.TradePrice = 0;
                }
            }
        }

        private void txtValidity_TextChanged(object sender, EventArgs e)
        {
            if (_currentState == UPDATE || _currentState == ADD)
            {
                if (XcConvert.IsInteger(this.txtValidity.Text))
                {
                    _currentMaker.ValidityDate = Convert.ToInt32(this.txtValidity.Text);
                }
                else
                {
                    this.txtValidity.Text = "";
                    _currentMaker.ValidityDate = 0;
                }
            }
        }

        private void txtDefStockPrice_TextChanged(object sender, EventArgs e)
        {
            if (_currentState == UPDATE || _currentState == ADD)
            {
                if (XcConvert.IsNumeric(this.txtDefStockPrice.Text))
                {
                    _currentMaker.DefStockPrice = Convert.ToDecimal(this.txtDefStockPrice.Text);
                }
                else
                {
                    this.txtDefStockPrice.Text = "";
                    _currentMaker.DefStockPrice = 0;
                }
            }
        }      
        #endregion
        #endregion
        #region 自定义方法

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            try
            {
                dgrdMaker.AutoGenerateColumns = false;
                if (_currentSpec != null)
                {
                    _makerDt = DrugBaseDataBll.LoadMakerDic(_currentSpec);
                }
                _productDt = DrugBaseDataBll.LoadProductDic();
                _medicareDt = DrugBaseDataBll.LoadMedicareDic();
                txtMakerName.SetSelectionCardDataSource(_productDt);
                txtMedicare.SetSelectionCardDataSource(_medicareDt);
                dgrdMaker.DataSource = _makerDt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void TextBoxEnable(bool isEnable)
        {
            if (isEnable == true)
            {
                this.txtMakerName.ReadOnly = false;
                this.txtMedicare.ReadOnly = false;
                this.cobUniType.Enabled = true;
                this.txtRetailPrice.ReadOnly = false;
                this.txtTradePrice.ReadOnly = false;
                this.txtValidity.ReadOnly = false;
                this.txtBaleNum.ReadOnly = false;
                this.txtRemark.ReadOnly = false;
                this.txtDefStockPrice.ReadOnly = false;
                this.txtHRetailPrice.ReadOnly = false;
                
                this.chkOwnPay.Enabled = true;
                this.chkRecipe.Enabled = true;
                this.chkLunacy.Enabled = true;
                this.chkNarcotic.Enabled = true;
                this.chkSkintest.Enabled = true;
                this.chkIsBigTransfu.Enabled = true;
                this.chkVirulent.Enabled = true;
                this.chkUse.Enabled = true;
            }
            else
            {
                this.txtMakerName.ReadOnly = true;
                this.txtMedicare.ReadOnly = true;
                this.txtRetailPrice.ReadOnly = true;
                this.txtTradePrice.ReadOnly = true;
                this.txtValidity.ReadOnly = true;
                this.txtBaleNum.ReadOnly = true;
                this.txtRemark.ReadOnly = true;
                this.txtDefStockPrice.ReadOnly = true;
                this.txtHRetailPrice.ReadOnly = false;
                this.cobUniType.Enabled = false;
                this.chkOwnPay.Enabled = false;
                this.chkRecipe.Enabled = false;
                this.chkLunacy.Enabled = false;
                this.chkNarcotic.Enabled = false;
                this.chkSkintest.Enabled = false;
                this.chkIsBigTransfu.Enabled = false;
                this.chkVirulent.Enabled = false;
                this.chkUse.Enabled = false;
            }
        }
        /// <summary>
        /// 清空文本框
        /// </summary>
        private void TextBoxClear()
        {
            this.txtMakerName.Clear();
            this.txtMedicare.Clear();
            this.txtRetailPrice.Text = "0.00";
            this.txtTradePrice.Text = "0.00";
            this.txtValidity.Clear();
            this.txtBaleNum.Clear();
            this.txtDefStockPrice.Text = "0.00";
            this.txtRemark.Clear();
            this.txtHRetailPrice.Text = "0.00";
        }

        /// <summary>
        /// 根据当前状态设置按键使能
        /// </summary>
        private void ButtonEnable()
        {
            switch (_currentState)
            {
                case ADD:
                    this.tsrbtnAdd.Visible = false;
                    this.tsrbtnUpdate.Visible = false;
                    this.tsrbtnCancel.Visible = true;
                    break;
                case UPDATE:
                    this.tsrbtnAdd.Visible = false;
                    this.tsrbtnUpdate.Visible = false;
                    this.tsrbtnCancel.Visible = true;
                    break;
                default:
                    this.tsrbtnAdd.Visible = true;
                    this.tsrbtnUpdate.Visible = true;
                    this.tsrbtnCancel.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// 展示当前DrugMaker对象内容
        /// </summary>
        private void ShowCurrentMaker()
        {
            if (_currentMaker != null)
            {
                this.txtMakerName.Text = DrugBaseDataBll.GetName(_currentMaker.ProductID, _productDt, "ProductID", "ProductName");
                this.txtMedicare.Tag = 1;
                this.txtMedicare.Text = DrugBaseDataBll.GetName(_currentMaker.MedicareDicID, _medicareDt, "MedicareDicID", "MedicareName");
                this.txtMedicare.Tag = 1;
                this.txtRetailPrice.Text = _currentMaker.RetailPrice.ToString();
                this.txtTradePrice.Text = _currentMaker.TradePrice.ToString();
                this.txtValidity.Text = _currentMaker.ValidityDate.ToString();
                this.txtDefStockPrice.Text = _currentMaker.DefStockPrice.ToString();
                this.txtRemark.Text = _currentMaker.Remark;
                this.txtBaleNum.Text = _currentMaker.BaleNum;
                this.txtMediInverse.Text = _currentMaker.Medi_inverse.ToString();
                this.txtHRetailPrice.Text = _currentMaker.HRetailPrice.ToString();
                this.cobUniType.SelectedIndex = _currentMaker.UnifGettype == "02" ? 1 : 0;
                if (_currentMaker.OwnPay_Flag == 1)
                {
                    this.chkOwnPay.Checked = true;
                }
                else
                {
                    this.chkOwnPay.Checked = false;
                }
                if (_currentMaker.Recipe_Flag == 1)
                {
                    this.chkRecipe.Checked = true;
                }
                else
                {
                    this.chkRecipe.Checked = false;
                }
                if (_currentMaker.Lunacy_Flag == 1)
                {
                    this.chkLunacy.Checked = true;
                }
                else
                {
                    this.chkLunacy.Checked = false;
                }
                if (_currentMaker.Narcotic_Flag == 1)
                {
                    this.chkNarcotic.Checked = true;
                }
                else
                {
                    this.chkNarcotic.Checked = false;
                }
                if (_currentMaker.Skintest_Flag == 1)
                {
                    this.chkSkintest.Checked = true;
                }
                else
                {
                    this.chkSkintest.Checked = false;
                }
                if (_currentMaker.Bigtransfu_Flag == 1)
                {
                    this.chkIsBigTransfu.Checked = true;
                }
                else
                {
                    this.chkIsBigTransfu.Checked = false;
                }
                if (_currentMaker.Virulent_Flag == 1)
                {
                    this.chkVirulent.Checked = true;
                }
                else
                {
                    this.chkVirulent.Checked = false;
                }
                if (_currentMaker.GetWay == 1)
                {
                    this.chkUse.Checked = true;
                }
                else
                {
                    this.chkUse.Checked = false;
                }
            }
            else 
            {
                TextBoxClear();
                return;
            }
        }
        #endregion


        private bool CheckInput()
        {
            if (_currentMaker == null)
            {
                MessageBox.Show("请选择厂家");
                return false;
            }
            if (_currentMaker.ProductID == 0)
            {
                MessageBox.Show("请输入厂家名称");
                txtMakerName.Focus();
                txtMakerName.SelectAll();
                return false;
            }
            if (_currentMaker.ValidityDate == 0)
            {
                MessageBox.Show("请输入默认有效期限");
                txtValidity.Focus();
                txtValidity.SelectAll();
                return false;
            }
            return true;
        }

        private void tsrbtnAdd_Click(object sender, EventArgs e)
        {
            if (_currentState == NORMAL)
            {
                TextBoxClear();
                TextBoxEnable(true);
                _currentState = ADD;
                ButtonEnable();
                _currentMaker = new YP_MakerDic();
                _currentMaker.UnifGettype = "01";
                cobUniType.SelectedIndex = 0;
                _currentMaker.SpecDicID = _currentSpec.SpecDicID;
                //清空checkbox和currentMaker的值
                this.chkOwnPay.Checked = false;
                this.chkRecipe.Checked = false;
                this.txtMakerName.Focus();
            }
        }

        private void tsrbtnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentMaker == null || dgrdMaker.CurrentCell == null)
            {
                MessageBox.Show("没有数据被选择");
                return;
            }
            if (_currentState == NORMAL && this._makerDt.Rows.Count != 0)
            {
                TextBoxEnable(true);
                if (DrugBaseDataBll.IsHaveStoreRecord(_currentMaker))
                {
                    this.txtRetailPrice.Enabled = false;
                    this.txtTradePrice.Enabled = false;
                }
                _currentState = UPDATE;
                ButtonEnable();
                this.txtMakerName.Focus();
            }
        }

        private void tsrbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentState == NORMAL)
                {
                    return;
                }
                if (CheckInput() == true)
                {
                    if (_currentState == ADD)
                    {
                        DrugBaseDataBll.AddDgMaker(_currentMaker, _currentSpec);
                        LoadData();
                        if (_makerDt.Rows.Count > 0)
                        {
                            dgrdMaker.CurrentCell = dgrdMaker[0, _makerDt.Rows.Count - 1];
                        }
                        else
                        {
                            dgrdMaker.CurrentCell = dgrdMaker[0, 0];
                        }
                        TextBoxEnable(false);
                        MessageBox.Show("添加成功");
                    }
                    else if (_currentState == UPDATE)
                    {
                        string storeInfo = CheckDrugStore();
                        if (storeInfo != "")
                        {
                            if (MessageBox.Show(CheckDrugStore(), "提示",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                UpdateMaker();
                            }
                        }
                        else
                        {
                            UpdateMaker();
                        }
                    }
                    _currentState = NORMAL;
                    this.tsrMakerDic.Focus();
                    this.tsrbtnAdd.Select();
                    ButtonEnable();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void UpdateMaker()
        {
            DrugBaseDataBll.UpdateDgMaker(_currentMaker);
            LoadData();
            txtRetailPrice.Enabled = true;
            txtTradePrice.Enabled = true;
            TextBoxEnable(false);
            MessageBox.Show("更新成功");
            
        }

        private string CheckDrugStore()
        {
            StoreQuery storeQuery = null;
            string rtn = "";
            if (_currentMaker != null)
            {
                if (_currentMaker.GetWay == 1)
                {
                    DataTable allDrugDept = DrugBaseDataBll.LoadAllDrugDept();
                    for (int index = 0; index < allDrugDept.Rows.Count; index++)
                    {
                        int deptId = Convert.ToInt32(allDrugDept.Rows[index]["DEPTID"]);
                        string deptName = allDrugDept.Rows[index]["DEPTNAME"].ToString();
                        if (allDrugDept.Rows[index]["DEPTTYPE1"].ToString() == "药房")
                        {
                            storeQuery = StoreFactory.GetQuery(ConfigManager.YF_SYSTEM); 
                        }
                        else
                        {
                            storeQuery = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM);
                        }
                        decimal currentNum = storeQuery.QueryNum(_currentMaker.MakerDicID, deptId);
                        if (currentNum > 0)
                        {
                            rtn += ("[" + deptName.Trim() + "数量:" + currentNum.ToString("0.00") + "]" + "\n");
                        }
                    }
                    if (rtn != "")
                    {
                        rtn += "该药品(物资)在上述科室数量不为0，您确定要停用么？";
                    }
                }
            }
            return rtn;
        }

        private void tsrbtnDel_Click(object sender, EventArgs e)
        {

            if (_currentMaker == null || dgrdMaker.CurrentCell == null)
            {
                MessageBox.Show("没有数据被选择");
                return;
            }
            if (_currentMaker.Del_Flag == 1)
            {
                MessageBox.Show("该药品已被删除");
                return;
            }
            try
            {
                if (_currentState == NORMAL)
                {
                    int lastRowIndex = dgrdMaker.CurrentCell.RowIndex;
                    DrugBaseDataBll.DeleteDgMaker(_currentMaker);
                    LoadData();
                    if (_makerDt.Rows.Count > 0)
                    {
                        if (lastRowIndex != 0)
                        {
                            dgrdMaker.CurrentCell = dgrdMaker[dgrdMaker.CurrentCell.ColumnIndex, lastRowIndex - 1];
                        }
                        else
                        {
                            dgrdMaker.CurrentCell = dgrdMaker[dgrdMaker.CurrentCell.ColumnIndex, 0];
                        }
                    }
                    else
                    {
                        TextBoxClear();
                        _currentMaker = null;
                    }
                    MessageBox.Show("删除成功");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnCancel_Click(object sender, EventArgs e)
        {
            this._currentState = NORMAL;
            TextBoxEnable(false);
            ButtonEnable();
            dgrdMaker_CurrentCellChanged(null, null);
        }


        private void tsrbtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDrugMaker_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F2:
                    tsrbtnAdd_Click(null, null);
                    break;
                case Keys.F3:
                    tsrbtnDel_Click(null, null);
                    break;
                case Keys.F4:
                    tsrbtnUpdate_Click(null, null);
                    break;
                case Keys.F5:
                    tsrbtnSave_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        #region 按键事件响应



        /// <summary>
        /// 依据输入法描述获取输入法
        /// </summary>
        /// <param name="languageName">输入法描述（比如五笔）</param>
        /// <returns></returns>
        public static InputLanguage GetInputLanguage(string languageName)
        {
            foreach (InputLanguage l in InputLanguage.InstalledInputLanguages)
            {
                if (l.LayoutName.IndexOf(languageName) >= 0)
                {
                    return l;
                }
            }
            //如果当前输入法中无要查找的输入法则返回默认输入法
            return InputLanguage.DefaultInputLanguage;
        }

        private void txtRetailPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txtDefStockPrice.Focus();
                txtDefStockPrice.SelectAll();
            }
        }

        private void txtTradePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txtRetailPrice.Focus();
                this.txtRetailPrice.SelectAll();
            }
        }

        private void txtValidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txtHRetailPrice.Focus();
                this.txtHRetailPrice.Select();
            }
        }

        private void txtDefStockPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtBaleNum.Focus();
            }
        }

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            _currentMaker.Remark = this.txtRemark.Text;
            if (e.KeyCode == Keys.Enter)
            {
                _currentMaker.Remark = this.txtRemark.Text;
                this.tsrMakerDic.Focus();
                this.tsrbtnSave.Select();
            }
        }

        private void txtBaleNum_KeyDown(object sender, KeyEventArgs e)
        {
            _currentMaker.BaleNum = this.txtBaleNum.Text;
            if (e.KeyCode == Keys.Enter)
            {
                _currentMaker.BaleNum = this.txtBaleNum.Text;
                this.txtMedicare.Focus();
            }
        }

        private void txtMedicare_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtMedicare.ReadOnly)
            {
                return;
            }
            DataRow dr = (DataRow)SelectedValue;
            if (dr != null)
            {
                _currentMaker.MedicareDicID = Convert.ToInt32(dr["MedicareDicID"]);
                txtMediInverse.Focus();
            }
        }

        private void txtMakerName_AfterSelectedRow(object sender, object SelectedValue)
        {

            if (txtMakerName.ReadOnly)
            {
                return;
            }
            DataRow dr = (DataRow)SelectedValue;
            if (dr != null)
            {
                _currentMaker.ProductID = Convert.ToInt32(dr["ProductId"]);
            }
            if (_currentState == ADD)
            {
                txtTradePrice.Focus();
                txtTradePrice.SelectAll();
            }
            else
            {
                txtDefStockPrice.Focus();
                txtDefStockPrice.SelectAll();
            }
        }

        private void txtMediInverse_TextChanged(object sender, EventArgs e)
        {
            if (txtMediInverse.Text != "" && txtMediInverse.Text != "-")
            {
                int mediInverse = Convert.ToInt32(txtMediInverse.Text);
                if (mediInverse >= 0)
                {
                    _currentMaker.Medi_inverse = mediInverse;
                }
            }
        }

        private void txtHRetailPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtHRetailPrice.Text != "" && txtMediInverse.Text != "-")
            {
                decimal hRetailPice = Convert.ToDecimal(txtHRetailPrice.Text);
                _currentMaker.HRetailPrice = hRetailPice;

            }
        }

        #endregion

        private void FrmDrugMaker_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                if (_makerDt.Rows.Count != 0)
                {
                    _currentMaker = GetMakerFromDt(_makerDt, 0);
                    ShowCurrentMaker();
                }
                TextBoxEnable(false);
                _currentState = NORMAL;
                ButtonEnable();
                this.lblDgName.Text = _currentSpec.Name;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdMaker_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int index;
                if (dgrdMaker.CurrentCell != null)
                {
                    index = dgrdMaker.CurrentCell.RowIndex;
                    _currentMaker = GetMakerFromDt(_makerDt.DefaultView.ToTable(), index);
                    ShowCurrentMaker();
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }


        /// <summary>
        /// 从厂家信息表中获取厂家典记录对象
        /// </summary>
        /// <param name="dtTable">
        /// 厂家信息表
        /// </param>
        /// <param name="index">
        /// 指定记录行索引
        /// </param>
        /// <returns>
        /// 厂家典记录对象
        /// </returns>
        private YP_MakerDic GetMakerFromDt(DataTable dtTable, int index)
        {

            try
            {
                if (dtTable.Rows.Count < index || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                YP_MakerDic currentMaker = new YP_MakerDic();
                ApiFunction.DataTableToObject(dtTable, index, currentMaker);
                return currentMaker;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        #region 输入法控制
        private void txtRemark_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = GetInputLanguage(Constant.CustomImeMode);
        }

        private void txtRemark_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }
        #endregion

        private void tsrbtnCancelDel_Click(object sender, EventArgs e)
        {
            if (_currentMaker == null)
            {
                MessageBox.Show("没有数据被选择");
                return;
            }
            try
            {
                if (MessageBox.Show("您确认要重新启用该厂家药品么?" +
                    "[" + _currentSpec.ChemName + "]",
                    "提示",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    if (_currentState == NORMAL)
                    {
                        DrugBaseDataBll.CancelDelteDgMaker(_currentMaker.MakerDicID);
                        MessageBox.Show("该厂家药品已重新启用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadData();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
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

        private void cobUniType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobUniType.SelectedIndex == 0)
            {
                _currentMaker.UnifGettype = "01";
            }
            else
            {
                _currentMaker.UnifGettype = "02";
            }
        }

        private void cobUniType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtRemark.Focus();
            }
        }

        private void chkIsBigTransfu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsBigTransfu.Checked == true)
            {
                _currentMaker.Bigtransfu_Flag = 1;
            }
            else
            {
                _currentMaker.Bigtransfu_Flag = 0;
            }
        }

        
       
    }
}
