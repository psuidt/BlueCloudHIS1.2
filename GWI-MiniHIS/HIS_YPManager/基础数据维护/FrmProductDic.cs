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
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_YPManager
{
    public partial class FrmProductDic : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private DataTable _productInfo;
        private YP_ProductDic _currentProduct;
        private int _currentState;
        const int ADD = 0;
        const int UPDATE = 1;
        const int NORMAL = 2;
        private long _currentUserId;
        private long _currentDeptId;
        private string _chineseName;
        public FrmProductDic()
        {
            InitializeComponent();
        }

        public FrmProductDic(long currentUserId, long currentDeptId, string chineseName)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            this.Text = _chineseName;
            InitializeComponent();
        }

        private void FrmProductDic_Load(object sender, EventArgs e)
        {
            txtQuery.Focus();
            LoadData();
            EnableTextBox(false);
            _currentState = NORMAL;
            EnableButton();
            
        }


        private void LoadData()
        {
            try
            {
                _productInfo = DrugBaseDataBll.LoadProductInfo();
                dgrdProduct.DataSource =_productInfo;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void ClearTextBox()
        {
            this.txtProductName.Clear();
            this.txtProductAddress.Clear();
            this.txtLinkName.Clear();
            this.txtLinkPhone.Clear();
        }

        private void EnableTextBox(bool isEnable)
        {
            this.txtProductName.Enabled = isEnable;
            this.txtProductAddress.Enabled = isEnable;
            this.txtLinkName.Enabled = isEnable;
            this.txtLinkPhone.Enabled = isEnable;
        }

        private bool CheckInput()
        {
            if (txtProductName.Text.Trim() == "")
            {
                MessageBox.Show("请输入生产商名称");
                this.txtProductName.Focus();
                return false;
            }
            return true;
        }

        private void EnableButton()
        {
            switch (_currentState)
            {
                case ADD:
                    this.tsrbtnAdd.Visible = false;
                    this.tsrbtnDel.Visible = false;
                    this.tsrbtnUpdate.Visible = false;
                    this.tsrbtnSave.Visible = true;
                    this.tsrbtnCancel.Visible = true;
                    break;
                case UPDATE:
                    this.tsrbtnAdd.Visible = false;
                    this.tsrbtnDel.Visible = false;
                    this.tsrbtnUpdate.Visible = false;
                    this.tsrbtnSave.Visible = true;
                    this.tsrbtnCancel.Visible = true;
                    break;
                default:
                    this.tsrbtnAdd.Visible = true;
                    this.tsrbtnDel.Visible = true;
                    this.tsrbtnUpdate.Visible = true;
                    this.tsrbtnSave.Visible = false;
                    this.tsrbtnCancel.Visible = false;
                    break;
            }
        }



        private void ShowCurrentProduct()
        {
            if (_currentProduct != null)
            {
                this.txtProductName.Text = _currentProduct.ProductName;
                this.txtProductAddress.Text = _currentProduct.Address;
                this.txtLinkName.Text = _currentProduct.LinkName;
                this.txtLinkPhone.Text = _currentProduct.LinkPhone;
            }
        }

        private void txtQuery_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    _productInfo = DrugBaseDataBll.LoadProductInfo(txtQuery.Text.Trim().ToLower());
                    dgrdProduct.DataSource = _productInfo;
                    dgrdProduct_CurrentCellChanged(null, null);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentState == NORMAL)
                {
                    EnableTextBox(true);
                    ClearTextBox();
                    _currentState = ADD;
                    EnableButton();
                    _currentProduct = new YP_ProductDic();
                    this.txtProductName.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }         
        }

        private void tsrbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentProduct == null)
                {
                    MessageBox.Show("没有数据被选择");
                    return;
                }
                if (_currentState == NORMAL && _productInfo.Rows.Count != 0)
                {
                    EnableTextBox(true);
                    _currentState = UPDATE;
                    EnableButton();
                    this.txtProductName.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentProduct == null)
                {
                    MessageBox.Show("没有数据被选择");
                    return;
                }
                if (_currentState == NORMAL)
                {
                    DrugBaseDataBll.DelProduct(_currentProduct);
                    _productInfo.Rows.RemoveAt(dgrdProduct.CurrentRow.Index);
                    MessageBox.Show("删除成功");
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
                if (CheckInput() == true)
                {
                    _currentProduct.PYM = PublicStaticFun.GetPyWbCode(_currentProduct.ProductName)[0].ToString();
                    _currentProduct.WMB = PublicStaticFun.GetPyWbCode(_currentProduct.ProductName)[1].ToString();
                    if (_currentState == ADD)
                    {
                        DrugBaseDataBll.AddProduct(_currentProduct);
                        DrugBaseDataBll.AddProduct(_productInfo, _currentProduct);
                        EnableTextBox(false);
                        MessageBox.Show("添加成功");
                    }
                    else if (_currentState == UPDATE)
                    {
                        DrugBaseDataBll.UpdateProduct(_currentProduct);
                        DrugBaseDataBll.UpdateProduct(_currentProduct, _productInfo, dgrdProduct.CurrentRow.Index);
                        EnableTextBox(false);
                        MessageBox.Show("更新成功");
                    }
                    tsrProduct.Focus();
                    tsrbtnAdd.Select();
                    _currentState = NORMAL;
                    EnableButton();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnCancel_Click(object sender, EventArgs e)
        {
            EnableTextBox(false);
            _currentState = NORMAL;
            EnableButton();
            dgrdProduct_CurrentCellChanged(null, null);
        }

        private void tsrbtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProductDic_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F2:
                    tsrbtnAdd_Click(null, null);
                    break;
                case Keys.F3:
                    tsrbtnUpdate_Click(null, null);
                    break;
                case Keys.F4:
                    tsrbtnDel_Click(null, null);
                    break;
                case Keys.F5:
                    tsrbtnSave_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void dgrdProduct_CurrentCellChanged(object sender, EventArgs e)
        {
            int index;
            if (dgrdProduct.CurrentCell != null)
            {
                index = dgrdProduct.CurrentCell.RowIndex;
            }
            else
            {
                index = 0;
            }
            if (index >= 0)
            {
                _currentProduct = DrugBaseDataBll.GetProductFormDt(_productInfo.DefaultView.ToTable(), index);
                ShowCurrentProduct();
            }
        }

        private void txtProductAddress_TextChanged(object sender, EventArgs e)
        {
            if (_currentProduct != null)
            {
                _currentProduct.Address = txtProductAddress.Text;
            }
        }

        private void txtLinkName_TextChanged(object sender, EventArgs e)
        {
            if (_currentProduct != null)
            {
                _currentProduct.LinkName = txtLinkName.Text;
            }
        }

        private void txtLinkPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtLinkPhone.Text.Length > 20)
            {
                txtLinkPhone.Text = "";
            }
            else
            {
                if (_currentProduct != null)
                {
                    _currentProduct.LinkPhone = txtLinkPhone.Text;
                }
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (_currentProduct != null)
            {
                _currentProduct.ProductName = txtProductName.Text;
            }
        }

        private void txtLinkPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                tsrProduct.Focus();
                tsrbtnSave.Select();
            }
        }

        private void txtQuery_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        private void txtQuery_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = GetInputLanguage(HIS.SYSTEM.PubicBaseClasses.Constant.CustomImeMode);
        }

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

        

    }
}
