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
    public partial class FrmDrugByname : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public YP_SpecDic _currentSpec;
        private YP_BynameDic _currentByname = null;
        private DataTable _bynameDt = new DataTable();
        private int _currentState;
        const int ADD = 1;
        const int UPDATE = 2;
        const int NORMAL = 3;
        public FrmDrugByname()
        {
            InitializeComponent();
        }

        public void InitForm()
        {
            LoadData();
            if (_bynameDt.Rows.Count != 0)
            {
                _currentByname = GetBynameFromDt(_bynameDt, 0);
                if (_currentByname != null)
                {
                    ShowCurrentByname();
                }
            }
            _currentState = NORMAL;
            ButtonEnable();
            TextBoxEnable(false);
        }

        private void LoadData()
        {
            dgrdByName.AutoGenerateColumns = false;
            _bynameDt = DrugBaseDataBll.LoadDrugByName(_currentSpec);
            dgrdByName.DataSource = _bynameDt;
            dgrdByName_CurrentCellChanged(null, null);
        }

        private bool CheckInput()
        {
            if (txtByname.Text.Trim() == "")
            {
                MessageBox.Show("请输入别名");
                txtByname.Focus();
                return false;
            }
            return true;
        }

        private void TextBoxEnable(bool isEnable)
        {
            if (isEnable == true)
            {
                this.txtByname.ReadOnly = false;
                this.txtPYM.ReadOnly = false;
                this.txtWBM.ReadOnly = false;
            }
            else
            {
                this.txtByname.ReadOnly = true;
                this.txtPYM.ReadOnly = true;
                this.txtWBM.ReadOnly = true;
            }
        }

        private void TextBoxClear()
        {
            this.txtByname.Clear();
            this.txtPYM.Clear();
            this.txtWBM.Clear();
        }

        private void ButtonEnable()
        {
            switch(_currentState)
            {
                case ADD:
                    tsrbtnAdd.Visible = false;
                    tsrbtnDel.Visible = false;
                    tsrbtnSave.Visible = true;
                    tsrbtnUpdate.Visible = false;
                    break;
                case UPDATE:
                    tsrbtnAdd.Visible = false;
                    tsrbtnDel.Visible = false;
                    tsrbtnSave.Visible = true;
                    tsrbtnUpdate.Visible = false;
                    break;
                default:
                    tsrbtnAdd.Visible = true;
                    tsrbtnDel.Visible = true;
                    tsrbtnSave.Visible = false;
                    tsrbtnUpdate.Visible = true;
                    break;
            }
        }
        private void ShowCurrentByname()
        {
            if (_currentByname != null)
            {
                this.txtByname.Text = _currentByname.Byname;
                this.txtPYM.Text = _currentByname.PYM;
                this.txtWBM.Text = _currentByname.WBM;
            }
        }        


        private void tsrbtnAdd_Click(object sender, EventArgs e)
        {
            if (_currentState == NORMAL)
            {
                TextBoxEnable(true);
                TextBoxClear();
                _currentState = ADD;
                ButtonEnable();
                _currentByname = new YP_BynameDic();
                _currentByname.SpecDicID = _currentSpec.SpecDicID;
                this.txtByname.Focus();
            }
        }

        private void tsrbtnDel_Click(object sender, EventArgs e)
        {
            if (_currentByname == null)
            {
                MessageBox.Show("没有数据被选择");
                return;
            }
            try
            {
                if (_currentState == NORMAL)
                {
                    int lastRowIndex = dgrdByName.CurrentCell.RowIndex;
                    DrugBaseDataBll.DeleteByname(_currentByname);
                    LoadData();
                    if (_bynameDt.Rows.Count == 0)
                    {
                        this.TextBoxClear();
                        _currentByname = null;
                        return;
                    }
                    if (lastRowIndex != 0)
                    {
                        dgrdByName.CurrentCell = dgrdByName[0, lastRowIndex - 1];
                    }
                    else
                    {
                        dgrdByName.CurrentCell = dgrdByName[0, 0];
                    }
                    MessageBox.Show("删除成功");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void tsrbtnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentByname == null)
            {
                MessageBox.Show("没有选择数据，请先选择数据");
                return;
            }
            if (_currentState == NORMAL)
            {
                TextBoxEnable(true);
                _currentState = UPDATE;
                ButtonEnable();
                this.txtByname.Focus();
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
                        _currentByname.PYM = PublicStaticFun.GetPyWbCode(this.txtByname.Text)[0].ToString();
                        _currentByname.WBM = PublicStaticFun.GetPyWbCode(this.txtByname.Text)[1].ToString();
                        this.txtPYM.Text = _currentByname.PYM;
                        this.txtWBM.Text = _currentByname.WBM;
                        DrugBaseDataBll.AddDgByname(_currentByname);
                        LoadData();
                        if (_bynameDt.Rows.Count > 0)
                        {
                            dgrdByName.CurrentCell = dgrdByName[0,_bynameDt.Rows.Count - 1];
                        }
                        else
                        {
                            dgrdByName.CurrentCell = dgrdByName[0, 0];
                        }
                        TextBoxEnable(false);
                        MessageBox.Show("添加成功");
                    }
                    else if (_currentState == UPDATE)
                    {
                        //_currentByname.PYM = PublicStaticFun.GetPyWbCode(this.txtByname.Text)[0].ToString();
                        //_currentByname.WBM = PublicStaticFun.GetPyWbCode(this.txtByname.Text)[1].ToString();
                        //this.txtPYM.Text = _currentByname.PYM;
                        //this.txtWBM.Text = _currentByname.WBM;
                        _currentByname.PYM = this.txtPYM.Text.Trim();
                        _currentByname.WBM = this.txtWBM.Text.Trim();
                        DrugBaseDataBll.UpdateByname(_currentByname);
                        LoadData();
                        TextBoxEnable(false);
                        MessageBox.Show("更新成功");
                    }
                    _currentState = NORMAL;
                    ButtonEnable();
                    TextBoxEnable(false);
                    this.tsrDrugByName.Focus();
                    this.tsrbtnAdd.Select();
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

        private void FrmDrugByname_KeyDown(object sender, KeyEventArgs e)
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

        private void txtByname_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtByname.ReadOnly == true)
            {
                return;
            }
            
            if (e.KeyValue == 13)
            {
                this.tsrDrugByName.Focus();
                this.tsrbtnSave.Select();
            }
        }

        private void dgrdByName_CurrentCellChanged(object sender, EventArgs e)
        {
            int index;
            if (dgrdByName.CurrentCell != null)
            {
                index = dgrdByName.CurrentCell.RowIndex;
                _currentByname = GetBynameFromDt(_bynameDt.DefaultView.ToTable(), index);
                ShowCurrentByname();
            }        
        }

        /// <summary>
        /// 从别名信息表中读取别名对象
        /// </summary>
        /// <param name="dtTable">
        /// 别名信息表
        /// </param>
        /// <param name="index">
        /// 指定别名记录行索引
        /// </param>
        /// <returns>
        /// 别名对象
        /// </returns>
        private YP_BynameDic GetBynameFromDt(DataTable dtTable, int index)
        {

            try
            {
                if (dtTable.Rows.Count < index || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                YP_BynameDic currentByname = new YP_BynameDic();
                HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dtTable, index, currentByname);
                return currentByname;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void txtByname_TextChanged(object sender, EventArgs e)
        {
            _currentByname.Byname = txtByname.Text;
        }
    }
}
