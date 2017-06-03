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
    public partial class FrmDrugDept : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private int _currentUserId;
        private string _chineseName;
        private int _currentDeptId;
        private DataTable _deptDt;
        private DataTable _drugDeptDt;
        private DataTable _deptOpDt;
        private YP_DeptDic _currentDept = new YP_DeptDic();

        public FrmDrugDept()
        {
            InitializeComponent();
        }

        public FrmDrugDept(long currentUserId, long currentDeptId, string chineseName)
        {
            _currentUserId = (int)currentUserId;
            _currentDeptId = (int)currentDeptId;
            _chineseName = chineseName;
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                dgrdDeptInfo.AutoGenerateColumns = false;
                _deptDt = DrugBaseDataBll.LoadDrugTypeDept();
                _drugDeptDt = DrugBaseDataBll.LoadAllDrugDept();
                txtQueryCode.SetSelectionCardDataSource(_deptDt);
                dgrdDeptInfo.DataSource = _drugDeptDt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void ShowCurrentDept()
        {
            if (_currentDept == null)
            {
                MessageBox.Show("请选中一行");
                return;
            }
            else
            {
                lblDeptName.Text = _currentDept.DeptName;
                if (_currentDept.Use_Flag == 1)
                {
                    lblUseState.Text = "已启用";
                }
                else
                {
                    lblUseState.Text = "未启用";
                }
                switch (_currentDept.DeptType1)
                {
                    case "药房":
                        radYF.Checked = true;
                        break;
                    case "药库":
                        radYK.Checked = true;
                        break;
                    case "物资库":
                        radWZ.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_currentDept != null)
            {
                try
                {
                    if (_currentDept.DeptID == 0)
                    {
                        MessageBox.Show("请选择科室");
                        txtQueryCode.Focus();
                        txtQueryCode.Select();
                    }
                    if (DrugBaseDataBll.ExistDrugDept(_currentDept.DeptID))
                    {
                        MessageBox.Show("该科室已经是药剂科室，无法添加");
                        return;
                    }
                    DrugBaseDataBll.AddDrugDept(_currentDept);
                    LoadData();
                    if (_drugDeptDt.Rows.Count > 0)
                    {
                        dgrdDeptInfo.CurrentCell = dgrdDeptInfo[0, _drugDeptDt.Rows.Count - 1];
                    }
                    else
                    {
                        dgrdDeptInfo.CurrentCell = dgrdDeptInfo[0, 0];
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("请选择科室");
                txtQueryCode.Focus();
                txtQueryCode.Select();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_currentDept != null)
            {
                try
                {
                    if (_currentDept.DeptID == 0)
                    {
                        MessageBox.Show("请选择科室");
                        txtQueryCode.Focus();
                        txtQueryCode.Select();
                    }
                    if (_currentDept.Use_Flag == 1)
                    {
                        MessageBox.Show("该科室已经启用，无法删除");
                        return;
                    }
                    if (MessageBox.Show("您确定要删除该药剂科室么？",
                        "删除确认",
                        MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    int lastRowIndex = this.dgrdDeptInfo.CurrentCell.RowIndex;
                    DrugBaseDataBll.DelDrugDept(_currentDept);
                    LoadData();
                    if (lastRowIndex != 0)
                    {
                        dgrdDeptInfo.CurrentCell = dgrdDeptInfo[dgrdDeptInfo.CurrentCell.ColumnIndex, lastRowIndex - 1];
                    }
                    else
                    {
                        dgrdDeptInfo.CurrentCell = dgrdDeptInfo[dgrdDeptInfo.CurrentCell.ColumnIndex, 0];
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("请选择科室");
                txtQueryCode.Focus();
                txtQueryCode.Select();
            }
        }

        private void radYF_CheckedChanged(object sender, EventArgs e)
        {
            if (_currentDept != null)
            {
                _currentDept.DeptType1 = "药房";
            }
        }

        private void radYK_CheckedChanged(object sender, EventArgs e)
        {
            if (_currentDept != null)
            {
                _currentDept.DeptType1 = "药库";
            }
        }

        private void radWZ_CheckedChanged(object sender, EventArgs e)
        {
            if (_currentDept != null)
            {
                _currentDept.DeptType1 = "物资";
            }
        }


        private void btnUse_Click(object sender, EventArgs e)
        {
            if (_currentDept != null)
            {
                try
                {
                    if (_currentDept.Use_Flag == 1)
                    {
                        MessageBox.Show("该科室已经被启用");
                        return;
                    }
                    FrmDeptSetType frmdeptsettype = new FrmDeptSetType();
                    //if (_currentDept.DeptType1 != "物资")
                    //{
                        if (frmdeptsettype.ShowDialog() == DialogResult.OK)
                        {
                            DrugBaseDataBll.AddManageType(_currentDept, frmdeptsettype.drugTypeList);
                            DrugBaseDataBll.UseDrugDept(_currentDept);                           
                        }
                    //}
                    //else
                    //{
                    //    List<int> wzTypeList = new List<int>();
                    //    wzTypeList.Add(4);
                    //    DrugBaseDataBll.AddManageType(_currentDept, wzTypeList);
                    //    DrugBaseDataBll.UseDrugDept(_currentDept);
                    //}
                    ShowCurrentDept();
                    LoadDeptBussiness();
                    LoadData();
                    MessageBox.Show("该药剂科室已经成功启用，请立刻进行初始化月结...");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void btnStopUse_Click(object sender, EventArgs e)
        {
            if (_currentDept != null)
            {
                try
                {
                    DrugBaseDataBll.StopUseDrugDept(_currentDept);
                    ShowCurrentDept();
                    LoadDeptBussiness();
                    LoadData();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void dgrdDeptInfo_CurrentCellChanged(object sender, EventArgs e)
        {            
            
        }

        private void LoadDeptBussiness()
        {
            try
            {
                if (_currentDept != null)
                {
                    _deptOpDt = DrugBaseDataBll.QueryDeptBussiness(_currentDept);
                    dgrdDeptOP.DataSource = _deptOpDt;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void FrmDrugDept_Load(object sender, EventArgs e)
        {
            try
            {               
                LoadData();
                chkShowTradePrice.Checked = ConfigManager.ManageTradepriceByYF();
                dgrdDeptInfo_CurrentCellChanged(null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgrdDeptInfo_CurrentCellChanged_1(object sender, EventArgs e)
        {
            if (dgrdDeptInfo.CurrentCell != null)
            {
                int currentIndex = dgrdDeptInfo.CurrentCell.RowIndex;
                if (_drugDeptDt.Rows.Count < currentIndex || _drugDeptDt.Rows.Count == 0)
                {
                    _currentDept = null;
                    return;
                }
                else
                {
                    DrugBaseDataBll.GetDrugDeptFromDt(_drugDeptDt.DefaultView.ToTable(), currentIndex, _currentDept);
                    ShowCurrentDept();
                    LoadDeptBussiness();
                    return;
                }
            }
        }

        private void txtQueryCode_AfterSelectedRow(object sender, object SelectedValue)
        {
            try
            {
                DataRow dr = (DataRow)SelectedValue;
                if (dr != null)
                {
                    txtQueryCode.Text = "";
                    int deptId = Convert.ToInt32(dr["DEPT_ID"]);
                    if (DrugBaseDataBll.ExistDrugDept(deptId))
                    {
                        _currentDept = DrugBaseDataBll.FindDrugDept(deptId);
                        ShowCurrentDept();
                        this.btnDel.Focus();
                    }
                    else
                    {
                        _currentDept = new YP_DeptDic();
                        _currentDept.DeptID = deptId;
                        _currentDept.DeptName = Convert.ToString(dr["NAME"]);
                        _currentDept.DeptType1 = "药库";
                        _currentDept.Use_Flag = 0;
                        ShowCurrentDept();
                        this.btnAdd.Focus();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void chkShowTradePrice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ConfigManager.SetManageTradePriceByYF(chkShowTradePrice.Checked);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }      
    }
}
