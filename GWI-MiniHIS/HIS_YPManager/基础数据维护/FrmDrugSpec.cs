
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
using GWMHIS.BussinessLogicLayer;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.YP_BLL.PrintCenter;


namespace HIS_YPManager
{
    public partial class FrmDrugSpec : GWI.HIS.Windows.Controls.BaseMainForm
    {
        #region 属性
        /// <summary>
        /// 状态标识
        /// </summary>
        const int ADD = 1;
        const int UPDATE = 2;
        const int DELETE = 3;
        const int NORMAL = 4;
        /// <summary>
        /// 当前规格类型
        /// </summary>
        private YP_SpecDic _currentSpec = new YP_SpecDic();
        /// <summary>
        /// 用于ShowCard的数据源
        /// </summary>
        private DataTable _SpecDt = new DataTable();
        private DataTable _unitDt = new DataTable();       
        private DataTable _doseDt = new DataTable();
        private DataTable _typeDt = new DataTable();
        private DataTable _pharmacologyDt = new DataTable();
        //过滤类型
        private int _currentState;
        private int _queryType;
        
        #endregion
        #region 操作
        #region 窗口构造
        public FrmDrugSpec()
        {
            InitializeComponent();            
        }
        public FrmDrugSpec(long currentUserId, long currentDeptId, string chineseName)
        {
            _chineseName = chineseName;
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            this.Text = _chineseName;
            InitializeComponent();
        }
        private void FrmDrugSpec_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.F6:
                    tsrbtnMakerDic_Click(null, null);
                    break;
                case Keys.F7:
                    tsrbtnByName_Click(null, null);
                    break;
                default:
                    break;
            }
        }
        private void FrmDrugSpec_Load(object sender, EventArgs e)
        {
            try
            {

                _currentState = NORMAL;
                //加载数据
                LoadData(true);
                //初始化textbox控件
                _currentSpec = GetSpecFromDt(_SpecDt, 0);
                ShowCurrentSpec();
                TextBoxEnable(false, false);
                radShowAll.Checked = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void FrmDrugSpec_LocationChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region 自定义方法
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
        private bool CheckInput()
        {
            if (_currentSpec == null)
            {
                MessageBox.Show("请选择药品规格");
                return false;
            }
            if (_currentSpec.Name == "")
            {
                MessageBox.Show("请输入药品名称");
                txtDrugName.Focus();
                txtDrugName.SelectAll();
                return false;
            }
            if (_currentSpec.TypeDicID == 0)
            {
                MessageBox.Show("请输入药品类型");
                txtDgType.Focus();
                txtDgType.SelectAll();
                return false;
            }
            if (_currentSpec.PackUnit == 0)
            {
                MessageBox.Show("请输入包装单位");
                txtPackUnit.Focus();
                txtPackUnit.SelectAll();
                return false;
            }
            if (_currentSpec.PackNum == 0)
            {
                MessageBox.Show("请输入包装数量,包装数量必须大于0");
                txtPackNum.Focus();
                txtPackNum.SelectAll();
                return false;
            }
            if (_currentSpec.DoseUnit == 0)
            {
                MessageBox.Show("请输入药品含量单位");
                txtDoseUnit.Focus();
                txtDoseUnit.SelectAll(); 
                return false;
            }
            if (_currentSpec.Unit == 0)
            {
                MessageBox.Show("请输入基本单位");
                txtLeastUnit.Focus();
                txtLeastUnit.SelectAll(); 
                return false;
            }
            if (_currentSpec.DoseNum <= 0)
            {
                MessageBox.Show("请输入药品含量系数,含量系数必须大于0");
                txtDoseNum.Focus();
                txtDoseNum.SelectAll(); 
                return false;
            }
            return true;
        }
        /// <summary>
        /// 从数据库中加载数据
        /// </summary>
        private void LoadData(bool isInit)
        {
            try
            {
                if (isInit)
                {
                    dgrdDrugSpec.AutoGenerateColumns = false;
                    _SpecDt = DrugBaseDataBll.LoadSpecDic();
                    _unitDt = DrugBaseDataBll.LoadDrugUnit();
                    _doseDt = DrugBaseDataBll.LoadDrugDose();
                    _typeDt = DrugBaseDataBll.LoadDrugType();
                    LoadTree();
                    dgrdDrugSpec.DataSource = _SpecDt;
                    txtDgType.SetSelectionCardDataSource(_typeDt);
                    txtPackUnit.SetSelectionCardDataSource(_unitDt);
                    txtDoseUnit.SetSelectionCardDataSource(_unitDt);
                    txtLeastUnit.SetSelectionCardDataSource(_unitDt);
                    txtDrugDose.SetSelectionCardDataSource(_doseDt);
                    txtPharmacology.SetSelectionCardDataSource(_pharmacologyDt);
                    
                }
                else
                {
                    _SpecDt = DrugBaseDataBll.LoadSpecDic();
                    dgrdDrugSpec.DataSource = _SpecDt;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        /// <summary>
        /// 加载树形控件
        /// </summary>
        private void LoadTree()
        {
            try
            {
                _pharmacologyDt = DrugBaseDataBll.LoadPharmacology();
                DataRow[] drRoot = _pharmacologyDt.Select("FID=0");
                for (int index = 0; index < drRoot.Length; index++)
                {
                    TreeNode root = new TreeNode();
                    root.Text = drRoot[index]["NAME"].ToString();
                    root.Tag = drRoot[index]["ID"];
                    AddTreeNode(root);
                    treePharmacology.Nodes.Add(root);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        private void AddTreeNode(TreeNode parentNode)
        {

            DataRow[] drSub = _pharmacologyDt.Select("FID=" + Convert.ToInt32(parentNode.Tag));
            if (drSub.Length > 0)
            {
                for (int index = 0; index < drSub.Length; index++)
                {
                    TreeNode subNode = new TreeNode();
                    subNode.Text = drSub[index]["NAME"].ToString();
                    subNode.Tag = drSub[index]["ID"];
                    AddTreeNode(subNode);
                    parentNode.Nodes.Add(subNode);
                }
            }
            else
            {
                return;
            }
        }
        private void TextBoxEnable(bool isEnable, bool isHaveStore)
        {
            if (isEnable == true)
            {
                if (isHaveStore)
                {
                    this.txtGBCode.ReadOnly = false;
                    this.txtPharmacology.ReadOnly = false;
                    this.txtDrugDose.ReadOnly = false;
                    this.txtDrugSpec.ReadOnly = false;
                    this.txtLatinName.ReadOnly = false;
                    this.txtChemName.ReadOnly = false;
                    this.txtDrugName.ReadOnly = false;
                    this.txtDoseUnit.ReadOnly = false;
                    this.txtDoseNum.ReadOnly = false;
                    return;
                }
                else
                {
                    this.txtDoseNum.ReadOnly = false;
                    this.txtDoseUnit.ReadOnly = false;
                    this.txtDrugDose.ReadOnly = false;
                    this.txtDrugName.ReadOnly = false;
                    this.txtGBCode.ReadOnly = false;
                    this.txtChemName.ReadOnly = false;
                    this.txtLatinName.ReadOnly = false;
                    this.txtLeastUnit.ReadOnly = false;
                    this.txtPackNum.ReadOnly = false;
                    this.txtPackUnit.ReadOnly = false;
                    this.txtDgType.ReadOnly = false;
                    this.txtPharmacology.ReadOnly = false;
                    this.txtDrugSpec.ReadOnly = false;
                }
            }
            else
            {
                this.txtDoseNum.ReadOnly = true;
                this.txtDoseUnit.ReadOnly = true;
                this.txtDrugDose.ReadOnly = true;
                this.txtDrugName.ReadOnly = true;
                this.txtLatinName.ReadOnly = true;
                this.txtGBCode.ReadOnly = true;
                this.txtChemName.ReadOnly = true;
                this.txtLeastUnit.ReadOnly = true;
                this.txtPackNum.ReadOnly = true;
                this.txtPackUnit.ReadOnly = true;
                this.txtDgType.ReadOnly = true;
                this.txtPharmacology.ReadOnly = true;
                this.txtDrugSpec.ReadOnly = true;
                
            }
        }
        private void ClearTextBox()
        {
            this.txtDoseNum.Clear();
            this.txtDoseUnit.Clear();
            this.txtDrugDose.Clear();
            this.txtDrugName.Clear();
            this.txtGBCode.Clear();
            this.txtChemName.Clear();
            this.txtLatinName.Clear();
            this.txtLeastUnit.Clear();
            this.txtPackNum.Clear();
            this.txtPackUnit.Clear();
            this.txtDgType.Clear();
            this.txtPharmacology.Clear();
            this.txtDrugSpec.Clear();
        }
        private void ShowCurrentSpec()
        {
            if (_currentSpec == null)
            {
                ClearTextBox();
                return;
            }
            else 
            {
                this.txtDoseNum.Text = Convert.ToDouble(_currentSpec.DoseNum).ToString();
                this.txtDoseUnit.Text = DrugBaseDataBll.GetName(_currentSpec.DoseUnit, _unitDt, "UnitDicID", "UnitName");                
                this.txtDrugName.Text = _currentSpec.Name;
                this.txtGBCode.Text = _currentSpec.GBCode;
                this.txtChemName.Text = _currentSpec.ChemName;
                this.txtLatinName.Text = _currentSpec.LatinName;
                this.txtLeastUnit.Text = DrugBaseDataBll.GetName(_currentSpec.Unit, _unitDt, "UnitDicID", "UnitName");                
                this.txtPackNum.Text = _currentSpec.PackNum.ToString();
                this.txtPackUnit.Text = DrugBaseDataBll.GetName(_currentSpec.PackUnit, _unitDt, "UnitDicID", "UnitName");                
                this.txtDrugDose.Text = DrugBaseDataBll.GetName(_currentSpec.DoseDicID, _doseDt, "DoseDicID", "DoseName");               
                this.txtDgType.Text = DrugBaseDataBll.GetName(_currentSpec.TypeDicID, _typeDt, "TypeDicID", "TypeName");
                this.txtPharmacology.Text = DrugBaseDataBll.GetName(_currentSpec.Pharmacology, _pharmacologyDt, "ID", "NAME");
                this.txtDrugSpec.Text = _currentSpec.Spec;
            }
        }
        private void ButtonEnable()
        {
            switch (_currentState)
            {
                case ADD:
                    tsrbtnUpdate.Visible = false;
                    tsrbtnAdd.Visible = false;
                    tsrbtnByName.Visible = false;
                    tsrbtnDel.Visible = false;
                    tsrbtnCancelDel.Visible = false;
                    tsrbtnMakerDic.Visible = false;
                    tsrbtnCancel.Visible = true;
                    
                    radXY.Enabled = false;
                    radZCY.Enabled = false;
                    radZY.Enabled = false;
                    break;
                case UPDATE:
                    tsrbtnUpdate.Visible = false;
                    tsrbtnAdd.Visible = false;
                    tsrbtnByName.Visible = false;
                    tsrbtnDel.Visible = false;
                    tsrbtnCancelDel.Visible = false;
                    tsrbtnMakerDic.Visible = false;
                    tsrbtnCancel.Visible = true;
                    radXY.Enabled = false;
                    radZCY.Enabled = false;
                    radZY.Enabled = false;
                    break;
                default:
                    tsrbtnUpdate.Visible = true;
                    tsrbtnAdd.Visible = true;
                    tsrbtnByName.Visible = true;
                    tsrbtnDel.Visible = true;
                    tsrbtnCancelDel.Visible = true;
                    tsrbtnMakerDic.Visible = true;
                    tsrbtnCancel.Visible = false;
                    radXY.Enabled = true;
                    radZCY.Enabled = true;
                    radZY.Enabled = true;
                    break;
            }
        }
        private DataTable FilterDoseDt(int typeDicId)
        {
            if (_doseDt != null)
            {
                DataTable selectDose = _doseDt.Clone();
                DataRow[] drs = _doseDt.Select("TYPEDICID=" + typeDicId.ToString());
                foreach (DataRow doseDr in drs)
                {
                    selectDose.Rows.Add(doseDr.ItemArray);
                }
                return selectDose;
            }
            else
            {
                return _doseDt;
            }
        }
        #endregion

        #region TextBox控件

        private void txtPackNum_TextChanged(object sender, EventArgs e)
        {
            if (_currentState == UPDATE || _currentState == ADD)
            {
                if (XcConvert.IsInteger(this.txtPackNum.Text))
                {
                    _currentSpec.PackNum = Convert.ToInt32(this.txtPackNum.Text);                   
                }
                else
                {
                    this.txtPackNum.Text = "";
                    _currentSpec.PackNum = 0;
                }
                DrugBaseDataBll.CombineSpec(_currentSpec, _unitDt);
                txtDrugSpec.Text = _currentSpec.Spec;
            }
        }

        private void txtDoseNum_TextChanged(object sender, EventArgs e)
        {
            if (_currentState == UPDATE || _currentState == ADD)
            {
                if (XcConvert.IsNumeric(this.txtDoseNum.Text))
                {
                    _currentSpec.DoseNum = Convert.ToDecimal(this.txtDoseNum.Text);
                }
                else
                {
                    this.txtDoseNum.Text = "";
                    _currentSpec.DoseNum = 0;
                }
                DrugBaseDataBll.CombineSpec(_currentSpec, _unitDt);
                txtDrugSpec.Text = _currentSpec.Spec;
            }
        }

        private void txtPackUnit_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtPackUnit.ReadOnly == true)
            {
                return;
            }
            if (SelectedValue != null)
            {
                _currentSpec.PackUnit = Convert.ToInt32(txtPackUnit.MemberValue);
                DrugBaseDataBll.CombineSpec(_currentSpec, _unitDt);
                txtDrugSpec.Text = _currentSpec.Spec;
            }
        }

        private void txtLeastUnit_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtLeastUnit.ReadOnly == true)
            {
                return;
            }
            if (SelectedValue != null)
            {
                _currentSpec.Unit = Convert.ToInt32(txtLeastUnit.MemberValue);
                DrugBaseDataBll.CombineSpec(_currentSpec, _unitDt);
                txtDrugSpec.Text = _currentSpec.Spec;
            }
        }

        private void txtDoseUnit_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtDoseUnit.ReadOnly == true)
            {
                return;
            }
            if (SelectedValue != null)
            {
                _currentSpec.DoseUnit = Convert.ToInt32(txtDoseUnit.MemberValue);
                DrugBaseDataBll.CombineSpec(_currentSpec, _unitDt);
                txtDrugSpec.Text = _currentSpec.Spec;
            }
        }

        private void txtPharmacology_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtPharmacology.ReadOnly == true)
            {
                return;
            }
            if (SelectedValue != null)
            {
                _currentSpec.Pharmacology = Convert.ToInt32(txtPharmacology.MemberValue);
            }
        }

        private void txtDrugDose_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtDrugDose.ReadOnly == true)
            {
                return;
            }
            if (SelectedValue != null)
            {
                _currentSpec.DoseDicID = Convert.ToInt32(((DataRow)SelectedValue)["DoseDicID"]);
                txtDrugDose.Text = ((DataRow)SelectedValue)["DoseName"].ToString();

            }
        }

        private void txtChemName_TextChanged(object sender, EventArgs e)
        {
            if (_currentSpec != null)
            {
                _currentSpec.ChemName = this.txtChemName.Text.Trim();
            }
        }

        private void txtLatinName_TextChanged(object sender, EventArgs e)
        {
            if (_currentSpec != null)
            {
                _currentSpec.LatinName = this.txtLatinName.Text.Trim();
            }
        }

        private void txtDrugName_TextChanged(object sender, EventArgs e)
        {
            if (_currentSpec != null)
            {
                _currentSpec.Name = this.txtDrugName.Text.Trim();
            }
        }

        private void txtDrugSpec_TextChanged(object sender, EventArgs e)
        {
            if (_currentSpec != null)
            {
                _currentSpec.Spec = txtDrugSpec.Text;
            }
        }

        private void txtDrugDose_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)(e.KeyChar) == 13)
            {
                tsrDrugSpec.Focus();
                tsrbtnSave.Select();
            }
        }

        private void txtPackNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtLeastUnit.Focus();
            }
        }

        private void txtDoseNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txtDoseUnit.Focus();
            }
        }

        private void txtGBCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                _currentSpec.GBCode = this.txtGBCode.Text;
                txtDrugDose.Focus();
            }
            _currentSpec.GBCode = this.txtGBCode.Text;
        }

        private void txtPharmacology_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtQueryCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string queryname = txtQueryCode.Text.Trim();
                string strWhere = "";
                switch (_queryType)
                {
                    case 0:
                        strWhere += ("G.PYM like '%" + queryname + "%'"
                            + " or G.WBM like '%" + queryname + "%'"
                            + " or A.CHEMNAME like '%" + queryname.ToUpper() + "%'");
                        break;
                    default:
                        strWhere += ("A.TypeDicID=" + _queryType.ToString());
                        strWhere += (" AND (G.PYM like '%" + queryname + "%'"
                            + " or G.WBM like '%" + queryname + "%'"
                            + " or A.CHEMNAME like '%" + queryname.ToUpper() + "%')");
                        break;
                }
                if (chkIsUse.Checked == false)
                {
                    _SpecDt = DrugBaseDataBll.LoadSpecDic(strWhere);
                }
                else
                {
                    _SpecDt = DrugBaseDataBll.LoadUseSpec(strWhere);
                }
                dgrdDrugSpec.DataSource = _SpecDt;
                _currentSpec = GetSpecFromDt(_SpecDt, 0);
                ShowCurrentSpec();
            }
        }

        private void txtDgType_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtDgType.ReadOnly == true)
            {
                return;
            }
            if (SelectedValue != null)
            {
                _currentSpec.TypeDicID = Convert.ToInt32(txtDgType.MemberValue);
                txtDrugDose.SetSelectionCardDataSource(FilterDoseDt(_currentSpec.TypeDicID));
            }
        }


        #endregion

        #region DataGrid控件
        private void dgrdDrugSpec_CurrentCellChanged(object sender, EventArgs e)
        {
            int index;
            if (dgrdDrugSpec.CurrentCell != null)
            {
                index = dgrdDrugSpec.CurrentCell.RowIndex;
            }
            else
            {
                index = 0;
            }
            if (index >= 0)
            {
                _currentSpec = GetSpecFromDt(_SpecDt.DefaultView.ToTable(), index);
                ShowCurrentSpec();
            }
        }        
        #endregion        
        
        #region Radio控件
        private void radXY_CheckedChanged(object sender, EventArgs e)
        {
            _queryType = 1;
        }

        private void radShowAll_CheckedChanged(object sender, EventArgs e)
        {
            _queryType = 0;
        }

        private void radZCY_CheckedChanged(object sender, EventArgs e)
        {
            _queryType = 2;
        }

        private void radZY_CheckedChanged(object sender, EventArgs e)
        {
            _queryType = 3;
        }

        private void radWZ_CheckedChanged(object sender, EventArgs e)
        {
            _queryType = 4;
        }

        #endregion      

        #region Button控件
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsrbtnAdd_Click(object sender, EventArgs e)
        {
            if (_currentState == NORMAL)
            {
                TextBoxEnable(true, false);
                ClearTextBox();
                _currentState = ADD;
                ButtonEnable();
                _currentSpec = new YP_SpecDic();
                this.txtDrugName.Focus();
            }
        }

        private void tsrbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput() == true)
                {
                    if (_currentState == ADD)
                    {
                        string[] pywbcodeName = new string[2];
                        string[] pywbcodeChemName = new string[2];
                        pywbcodeName = PublicStaticFun.GetPyWbCode(_currentSpec.Name);
                        pywbcodeChemName = PublicStaticFun.GetPyWbCode(_currentSpec.ChemName);
                        DrugBaseDataBll.AddDgSpec(_currentSpec, pywbcodeName, pywbcodeChemName);
                        TextBoxEnable(false, false);
                        MessageBox.Show("保存成功");
                    }
                    else if (_currentState == UPDATE)
                    {
                        DrugBaseDataBll.UpdateDgSpec(_currentSpec);
                        TextBoxEnable(false, true);
                        MessageBox.Show("更新成功");
                    }
                    _currentState = NORMAL;
                    ButtonEnable();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentSpec == null)
            {
                MessageBox.Show("没有数据被选择");
                return;
            }
            if (_currentState == NORMAL)
            {
                TextBoxEnable(true, DrugBaseDataBll.IsHaveStoreRecord(_currentSpec));
                FilterDoseDt(_currentSpec.TypeDicID);
                _currentState = UPDATE;
                ButtonEnable();
                this.txtDrugName.Focus();
            }
        }

        private void tsrbtnDel_Click(object sender, EventArgs e)
        {
            if (_currentSpec == null)
            {
                MessageBox.Show("没有数据被选择");
                return;
            }
            try
            {
                if (MessageBox.Show("您确认要删除该规格药品么?" +
                    "[" + _currentSpec.ChemName + "]",
                    "提示",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    if (DrugBaseDataBll.IsHaveStoreNum(_currentSpec))
                    {
                        MessageBox.Show("该规格的药品已经有库存数量，无法删除，请先确保数量为0");
                        return;
                    }
                    if (_currentState == NORMAL)
                    {
                        DrugBaseDataBll.DeleteDgSpec(_currentSpec.SpecDicID);
                        MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnCancelDel_Click(object sender, EventArgs e)
        {
            if (_currentSpec == null)
            {
                MessageBox.Show("没有数据被选择");
                return;
            }
            try
            {
                if (MessageBox.Show("您确认要重新启用该规格药品么?" +
                    "[" + _currentSpec.ChemName + "]",
                    "提示",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    if (_currentState == NORMAL)
                    {
                        DrugBaseDataBll.CancelDelteDgSpec(_currentSpec.SpecDicID);
                        MessageBox.Show("该规格药品已重新启用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnMakerDic_Click(object sender, EventArgs e)
        {
            if (_currentSpec == null)
            {
                MessageBox.Show("请选中一行");
                return;
            }
            FrmDrugMaker frmDgMaker = new FrmDrugMaker();
            frmDgMaker.MdiParent = this.MdiParent;
            frmDgMaker.WindowState = FormWindowState.Maximized;
            frmDgMaker._currentSpec = _currentSpec;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmDgMaker);
            frmDgMaker.Show();
        }

        private void tsrbtnByName_Click(object sender, EventArgs e)
        {
            if (_currentSpec == null)
            {
                MessageBox.Show("请选中一行");
                return;
            }
            FrmDrugByname frmDgByname = new FrmDrugByname();
            frmDgByname.MdiParent = this.MdiParent;
            frmDgByname._currentSpec = _currentSpec;
            frmDgByname.InitForm();
            frmDgByname.ShowDialog();
        }

        private void tsrbtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treePharmacology_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                int pharmacologyId = Convert.ToInt32(e.Node.Tag);
                _SpecDt = DrugBaseDataBll.LoadSpecDic("PHARMACOLOGY=" + pharmacologyId.ToString());
                dgrdDrugSpec.DataSource = _SpecDt;
                _currentSpec = GetSpecFromDt(_SpecDt, 0);
                ShowCurrentSpec();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable printTable = DrugBaseDataBll.LoadFirstCheckDrug("");
                string startPath = Application.StartupPath + "\\report\\药品期初盘点单.grf";
                YP_Printer.PrintUseDrug(startPath, (int)_currentUserId, (int)_currentDeptId, printTable);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnCancel_Click(object sender, EventArgs e)
        {
            TextBoxEnable(false, false);
            _currentState = NORMAL;
            ButtonEnable();
            dgrdDrugSpec_CurrentCellChanged(null, null);
        }
        #endregion

        #region 从datatable中获得指定记录的名称
        /// <summary>
        /// 从规格信息表中获取规格对象
        /// </summary>
        /// <param name="dtTable">
        /// 规格信息表
        /// </param>
        /// <param name="index">
        /// 指定行记录索引
        /// </param>
        /// <returns>
        /// 规格对象
        /// </returns>
        private HIS.Model.YP_SpecDic GetSpecFromDt(DataTable dtTable, int index)
        {
            try
            {
                if (dtTable.Rows.Count < index || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                YP_SpecDic currentSpecDic = new YP_SpecDic();
                ApiFunction.DataTableToObject(dtTable, index, currentSpecDic);
                return currentSpecDic;
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        #endregion

        #region 输入法设置
        private void txtDrugName_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = GetInputLanguage(Constant.CustomImeMode); 
        }

        private void txtChemName_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = GetInputLanguage(Constant.CustomImeMode); 
        }

        private void txtDrugName_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        private void txtChemName_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        private void txtLatinName_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        private void txtLatinName_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = GetInputLanguage(Constant.CustomImeMode);
        }
        #endregion       

        private void tsrbtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                DataTable exportSpecDt = DrugBaseDataBll.LoadExpotSpec();
                YP_Printer.ExportData(exportSpecDt);
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
        #endregion        

        

       
    }
}
