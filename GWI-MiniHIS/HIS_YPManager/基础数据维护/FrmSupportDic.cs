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
    public partial class FrmSupportDic : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private DataTable _supportInfo;
        private YP_SupportDic _currentSupport;
        private int _currentState;
        const int ADD = 0;
        const int UPDATE = 1;
        const int NORMAL = 2;
        private long _currentUserId;
        private long _currentDeptId;
        private string _chineseName;

        public FrmSupportDic()
        {
            InitializeComponent();
        }

        public FrmSupportDic(long currentUserId, long currentDeptId, string chineseName)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            this.Text = _chineseName;
            InitializeComponent();
        }

        private void FrmSupportDic_Load(object sender, EventArgs e)
        {
            LoadData();
            EnableTextBox(false);
            _currentState = NORMAL;
            EnableButton();
        }

        private void LoadData()
        {
            try
            {
                _supportInfo = DrugBaseDataBll.LoadSupportInfo();
                dgrdSupport.DataSource = _supportInfo;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void ClearTextBox()
        {
            this.txtSupportName.Clear();
            this.txtSupportAddress.Clear();
            this.txtLinkName.Clear();
            this.txtLinkPhone.Clear();
        }

        private void EnableTextBox(bool isEnable)
        {
            this.txtSupportName.Enabled = isEnable;
            this.txtSupportAddress.Enabled = isEnable;
            this.txtLinkName.Enabled = isEnable;
            this.txtLinkPhone.Enabled = isEnable;
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

        private void ShowCurrentSupport()
        {
            if (_currentSupport != null)
            {
                this.txtSupportName.Text = _currentSupport.Name;
                this.txtSupportAddress.Text = _currentSupport.Address;
                this.txtLinkName.Text = _currentSupport.LinkMan;
                this.txtLinkPhone.Text = _currentSupport.Phone;
            }
        }

        private bool CheckInput()
        {
            if (txtSupportName.Text.Trim() == "")
            {
                MessageBox.Show("请输入供应商名称");
                txtSupportName.Focus();
                return false;
            }
            return true;
        }

        private void txtQuery_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    this._supportInfo = DrugBaseDataBll.LoadSupportInfo(txtQuery.Text);
                    this.dgrdSupport.DataSource = _supportInfo;
                    dgrdSupport_CurrentCellChanged(null, null);
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
                    _currentSupport = new YP_SupportDic();
                    this.txtSupportName.Focus();
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
                if (_currentSupport == null)
                {
                    MessageBox.Show("没有数据被选择");
                    return;
                }
                if (_currentState == NORMAL && _supportInfo.Rows.Count != 0)
                {
                    EnableTextBox(true);
                    _currentState = UPDATE;
                    EnableButton();
                    this.txtSupportName.Focus();
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
                if (_currentSupport == null)
                {
                    MessageBox.Show("没有数据被选择");
                    return;
                }
                if (_currentState == NORMAL)
                {
                    DrugBaseDataBll.DelSupport(_currentSupport);
                    _supportInfo.Rows.RemoveAt(dgrdSupport.CurrentCell.RowIndex);
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
                    _currentSupport.PYM = PublicStaticFun.GetPyWbCode(_currentSupport.Name)[0].ToString();
                    _currentSupport.WBM = PublicStaticFun.GetPyWbCode(_currentSupport.Name)[1].ToString();
                    if (_currentState == ADD)
                    {
                        DrugBaseDataBll.AddSupport(_currentSupport);
                        DrugBaseDataBll.AddSupport(_supportInfo, _currentSupport);
                        EnableTextBox(false);
                        MessageBox.Show("添加成功");
                    }
                    else if (_currentState == UPDATE)
                    {
                        DrugBaseDataBll.UpdateSupport(_currentSupport);
                        DrugBaseDataBll.UpdateSupport(_currentSupport, _supportInfo, dgrdSupport.CurrentCell.RowIndex);
                        EnableTextBox(false);
                        MessageBox.Show("更新成功");
                    }
                    tsrSupport.Focus();
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

        private void tsrbtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSupportDic_KeyDown(object sender, KeyEventArgs e)
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


        private void dgrdSupport_CurrentCellChanged(object sender, EventArgs e)
        {
            int index;
            if (dgrdSupport.CurrentCell != null)
            {
                index = dgrdSupport.CurrentCell.RowIndex;
            }
            else
            {
                index = 0;
            }
            _currentSupport = DrugBaseDataBll.GetSupportFormDt(_supportInfo.DefaultView.ToTable(), index);
            ShowCurrentSupport();
        }

        private void txtSupportName_TextChanged(object sender, EventArgs e)
        {
            if (_currentSupport != null)
            {
                _currentSupport.Name = this.txtSupportName.Text;
            }
        }

        private void txtSupportAddress_TextChanged(object sender, EventArgs e)
        {
            if (_currentSupport != null)
            {
                _currentSupport.Address = txtSupportAddress.Text;
            }
        }

        private void txtLinkName_TextChanged(object sender, EventArgs e)
        {
            if (_currentSupport != null)
            {
                _currentSupport.LinkMan = txtLinkName.Text;
            }
        }

        private void txtLinkPhone_TextChanged(object sender, EventArgs e)
        {
            if (_currentSupport != null)
            {
                _currentSupport.Phone = txtLinkPhone.Text;
            }
        }

        private void txtLinkPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                tsrSupport.Focus();
                tsrbtnSave.Select();
            }
        }

        private void tsrbtnCancel_Click(object sender, EventArgs e)
        {
            EnableTextBox(false);
            _currentState = NORMAL;
            EnableButton();
            dgrdSupport_CurrentCellChanged(null, null);
        }




    }
}
