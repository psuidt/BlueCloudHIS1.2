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
using HIS.Model;

namespace HIS_YPManager
{
    public partial class FrmSetStoreLimit : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private string _chineseName;
        private long _currentUserId;
        private long _currentDeptId;
        private DataTable _drugInfoDt;
        private DataTable _drugStoreInfoDt;
        private int _currentState = NORMAL;
        private string _belongSystem;
        private const int NORMAL = 0;
        private const int ALTER = 1;
        private YP_Storage _currentStore = new YP_Storage();
        private StoreProcessor _storeProcessor;
        private StoreQuery _storeQuery;

        public FrmSetStoreLimit()
        {
            InitializeComponent();
        }

        public FrmSetStoreLimit(long currentUserId, long currentDeptId, string chineseName, string belongSystem)
        {
            _currentUserId = (int)currentUserId;
            _currentDeptId = (int)currentDeptId;
            _chineseName = chineseName;
            _belongSystem = belongSystem;
            _storeProcessor = StoreFactory.GetProcessor(belongSystem);
            _storeQuery = StoreFactory.GetQuery(belongSystem);
            InitializeComponent();
        }

        private void FrmSetStoreLimit_Load(object sender, EventArgs e)
        {
            try
            {
                SetControlVisible();
                ShowState();
                LoadData();
                dgrdStoreInfo_CurrentCellChanged(null, null);
                txtQueryCode.Focus();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void SetControlVisible()
        {
            if (!ConfigManager.ManageTradepriceByYF() 
                && _belongSystem == ConfigManager.YF_SYSTEM)
            {
                dgrdStoreInfo.Columns["TRADEPRICE"].Visible = false;
                txtTradePrice.Visible = false;
                lblTradePrice.Visible = false;
            }
        }

        private void LoadData()
        {
            try
            {
                dgrdStoreInfo.AutoGenerateColumns = false;
                _drugInfoDt = _storeQuery.LoadDrugInfo((int)_currentDeptId);
                _drugStoreInfoDt = _storeQuery.LoadStoreInfo((int)_currentDeptId);
                txtQueryCode.SetSelectionCardDataSource(_drugInfoDt);
                dgrdStoreInfo.DataSource = _drugStoreInfoDt;
                _drugStoreInfoDt.PrimaryKey = new DataColumn[] { _drugStoreInfoDt.Columns["MAKERDICID"] };

            }
            catch (Exception error)
            {
                throw error;
            }
        }


        private void tsrbtnSetLimit_Click(object sender, EventArgs e)
        {
            _currentState = ALTER;
            ShowState();
            txtUpperLimit.Focus();
        }

        private void tstbtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                _storeProcessor.UpdateStoreLimit(_currentStore);
                _drugStoreInfoDt.Rows[dgrdStoreInfo.CurrentCell.RowIndex]["UPPERLIMIT"] = _currentStore.UpperLimit;
                _drugStoreInfoDt.Rows[dgrdStoreInfo.CurrentCell.RowIndex]["LOWERLIMIT"] = _currentStore.LowerLimit;
                _currentState = NORMAL;
                ShowState();
                txtQueryCode.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void ShowState()
        {
            if (_currentState == NORMAL)
            {
                this.txtUpperLimit.ReadOnly = true;
                this.txtLowerLimit.ReadOnly = true;
                this.tsrbtnQuit.Visible = true;
                this.tsrbtnSetLimit.Visible = true;
                this.tstbtnSave.Visible = false;
            }
            else if (_currentState == ALTER)
            {
                this.txtUpperLimit.ReadOnly = false;
                this.txtLowerLimit.ReadOnly = false;
                this.tsrbtnQuit.Visible = true;
                this.tsrbtnSetLimit.Visible = false;
                this.tstbtnSave.Visible = true;
            }
        }

        private void tsrbtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowCurrentStore()
        {
            this.txtCurrentNum.Text = _currentStore.CurrentNum.ToString();
            this.txtLowerLimit.Text = Convert.ToString(_currentStore.LowerLimit);
            this.txtName.Text = _currentStore.MakerDic.DrugInfo.chemname;
            this.txtProduct.Text = _currentStore.MakerDic.DrugInfo.productname.ToString();
            this.txtRetailPrice.Text = _currentStore.MakerDic.RetailPrice.ToString();
            this.txtSpec.Text = _currentStore.MakerDic.DrugInfo.spec.ToString();
            this.txtTradePrice.Text = _currentStore.MakerDic.TradePrice.ToString();
            this.txtUnit.Text = _currentStore.LeastUnitEntity.UnitName.ToString();
            this.txtUpperLimit.Text = _currentStore.UpperLimit.ToString();
        }

        private void txtUpperLimit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                txtLowerLimit.Focus();
            }
        }

        private void txtLowerLimit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tsrSetStoreLimit.Focus();
                tstbtnSave.Select();
            }
        }

        private void txtUpperLimit_TextChanged(object sender, EventArgs e)
        {
            if (_currentState != NORMAL)
            {
                if (!XcConvert.IsNumeric(txtUpperLimit.Text))
                {
                    txtUpperLimit.Text = "0.000";
                    txtUpperLimit.Focus();
                    txtUpperLimit.SelectAll();
                    return;
                }
                else
                {
                    if (Convert.ToDecimal(txtUpperLimit.Text) < Convert.ToDecimal(txtLowerLimit.Text))
                    {
                        txtUpperLimit.Text = "0.000";
                        txtUpperLimit.Focus();
                        txtUpperLimit.SelectAll();
                        return;
                    }
                    else
                    {
                        _currentStore.UpperLimit = Convert.ToDecimal(txtUpperLimit.Text);
                    }
                }
            }
        }

        private void txtLowerLimit_TextChanged(object sender, EventArgs e)
        {
            if (_currentState != NORMAL)
            {
                if (!XcConvert.IsNumeric(txtLowerLimit.Text))
                {
                    txtLowerLimit.Text = "0.000";
                    txtLowerLimit.Focus();
                    txtLowerLimit.SelectAll();
                    return;
                }
                else
                {
                    if (Convert.ToDecimal(txtUpperLimit.Text) < Convert.ToDecimal(txtLowerLimit.Text))
                    {
                        txtLowerLimit.Text = "0.000";
                        txtLowerLimit.Focus();
                        txtLowerLimit.SelectAll();
                        return;
                    }
                    else
                    {
                        _currentStore.LowerLimit = Convert.ToDecimal(txtLowerLimit.Text);
                    }
                }
            }
        }

        private void dgrdStoreInfo_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgrdStoreInfo.CurrentCell != null)
                {
                    int currentIndex = dgrdStoreInfo.CurrentCell.RowIndex;

                    DrugBaseDataBll.DataRowToStoreOrder(_drugStoreInfoDt.DefaultView.ToTable().Rows[currentIndex], _currentStore);
                    ShowCurrentStore();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtQueryCode_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (txtQueryCode.ReadOnly)
            {
                return;
            }
            DataRow dr = (DataRow)SelectedValue;
            if (dr != null)
            {
                int makerdicId = Convert.ToInt32(txtQueryCode.MemberValue);
                for (int rowIndex = 0; rowIndex < dgrdStoreInfo.RowCount; rowIndex++)
                {
                    if (Convert.ToInt32(dgrdStoreInfo["MAKERDICID", rowIndex].Value) == makerdicId)
                    {
                        dgrdStoreInfo.CurrentCell = dgrdStoreInfo.Rows[rowIndex].Cells[0];
                    }
                }
            }
        }

        private void FrmSetStoreLimit_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    tsrbtnSetLimit_Click(null, null);
                    break;
                case Keys.F3:
                    tstbtnSave_Click(null, null);
                    break;
                default:
                    break;
            }
        }
    }
}
