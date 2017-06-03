using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;
using GWMHIS.BussinessLogicLayer;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_YPManager
{
    public partial class FrmStoreQuery : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private long _currentUser;
        private long _currentDept;
        private string _chineseName;
        //过滤类型
        private FilterType _filterType;
        private SearchType _searchType;
        private DataTable _storeDt;
        private string _belongSystem;
        private StoreQuery _storeQuery;
        private AccountQuery accountQuery;
        private HIS.Model.YP_Batch _currentBatch;
        private DataTable _doseDt;
        private DataTable _typeDt;

        public FrmStoreQuery()
        {
            InitializeComponent();
        }

        public FrmStoreQuery(long currentUser, long currentDept, string chineseName, string belongSystem)
        {
            _currentUser = currentUser;
            _currentDept = currentDept;
            _chineseName = chineseName;
            _belongSystem = belongSystem;
            _filterType = Constant.CustomFilterType;
            _searchType = Constant.CustomSearchType;
            _storeQuery = StoreFactory.GetQuery(belongSystem);
            accountQuery = AccountFactory.GetQuery(belongSystem);
            InitializeComponent();
        }

        private void cobDrugType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtQueryCode.Focus();
            }
        }

        private void txtQueryCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    LoadData();
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void FrmStoreQuery_Load(object sender, EventArgs e)
        {
            if (_belongSystem == ConfigManager.YF_SYSTEM && !ConfigManager.ManageTradepriceByYF())
            {
                dgrdStoreQuery.Columns["TRADEPRICE"].Visible = false;
                dgrdStoreQuery.Columns["TRADEFEE"].Visible = false;
                dgrdStoreQuery.Columns["FEEDIFFERENCE"].Visible = false;
            }
            dgrdStoreQuery.AutoGenerateColumns = false;            
            _doseDt = DrugBaseDataBll.LoadDoseWithSelect();
            _typeDt = DrugBaseDataBll.LoadTypeWithSelect();
            cobDrugType.DataSource = _typeDt;
            cobDrugType.SelectedIndex = 0;
            LoadData();
            
        }

        private void LoadData()
        {
            try
            {
                decimal totalRetailFee = 0;
                _storeDt = _storeQuery.QueryStoreInfo(Convert.ToInt32(cobDrugType.SelectedValue),
                    Convert.ToInt32(cobDrugDose.SelectedValue),
                    (int)_currentDept,
                    this.txtQueryCode.Text.Trim());
                FilterNoStore();
                totalRetailFee = _storeQuery.QueryStoreFee((int)_currentDept,
                    Convert.ToInt32(cobDrugType.SelectedValue));
                if (totalRetailFee != -1)
                {
                    lblTotalFee.Text = totalRetailFee.ToString("0.00");
                }
                else
                {
                    lblTotalFee.Text = "0.00";
                }
                txtQueryCode.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string startPath = Application.StartupPath + "\\report\\药品库存清单.grf";
                if (chkIsShowNoStore.Checked == true)
                {
                    string filterWhere = "PACKNUM<>0 OR BASENUM<>0";
                    DataRow[] filterRows = _storeDt.Select(filterWhere);
                    DataTable filterDt = _storeDt.Clone();
                    foreach (DataRow dRow in filterRows)
                    {
                        filterDt.Rows.Add(dRow.ItemArray);
                    }
                    YP_Printer.PrintStoreBill(startPath, (int)_currentUser, (int)_currentDept, filterDt, _belongSystem);
                }
                else
                    YP_Printer.PrintStoreBill(startPath, (int)_currentUser, (int)_currentDept, _storeDt, _belongSystem);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdStoreQuery_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgrdStoreQuery.CurrentCell != null && _belongSystem == ConfigManager.YK_SYSTEM)
                {
                    if (pnlBatchQuery.Visible == false)
                    {
                        pnlBatchQuery.Visible = true;
                    }
                    int index = dgrdStoreQuery.CurrentCell.RowIndex;
                    if (index > -1)
                    {
                        int makerDicId = Convert.ToInt32(_storeDt.Rows[index]["MAKERDICID"]);
                        dgrdBatch.AutoGenerateColumns = false;
                        dgrdBatch.DataSource = _storeQuery.LoadBatch(makerDicId, (int)_currentDept);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnClosePanel_Click(object sender, EventArgs e)
        {
            pnlBatchQuery.Visible = false;
        }

        private void btnUpdateValidiyDate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentBatch != null && pnlBatchQuery.Visible == true)
                {
                    StoreFactory.GetProcessor(ConfigManager.YK_SYSTEM).UpdateBatch(_currentBatch, cobValidityTime.Value);
                    int index = dgrdStoreQuery.CurrentCell.RowIndex;
                    if (index > 0)
                    {
                        int makerDicId = Convert.ToInt32(_storeDt.Rows[index]["MAKERDICID"]);
                        dgrdBatch.AutoGenerateColumns = false;
                        dgrdBatch.DataSource = _storeQuery.LoadBatch(makerDicId, (int)_currentDept);
                    }
                    MessageBox.Show("到效日期修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdBatch_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgrdBatch.CurrentCell != null)
            {
                int index = dgrdBatch.CurrentCell.RowIndex;
                if (index > -1 && dgrdBatch.DataSource != null)
                {
                    if (_currentBatch == null)
                    {
                        _currentBatch = new HIS.Model.YP_Batch();
                    }
                    HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject((DataTable)dgrdBatch.DataSource,
                        index, _currentBatch);
                    cobValidityTime.Value = _currentBatch.ValidityDate;
                }
            }
        }

        private void FilterNoStore()
        {
            if (_storeDt == null)
                return;
            string filterWhere = "";
            if (chkIsShowNoStore.Checked == true)
            {
                filterWhere = "PACKNUM<>0 OR BASENUM<>0";
                DataRow[] filterRows = _storeDt.Select(filterWhere);
                DataTable filterDt = _storeDt.Clone();
                foreach (DataRow dRow in filterRows)
                {
                    filterDt.Rows.Add(dRow.ItemArray);
                }
                dgrdStoreQuery.AutoGenerateColumns = false;
                dgrdStoreQuery.DataSource = filterDt;
            }
            else
            {
                dgrdStoreQuery.AutoGenerateColumns = false;
                dgrdStoreQuery.DataSource = _storeDt;
            }
            
        }

        private void chkIsShowNoStore_CheckedChanged(object sender, EventArgs e)
        {
            FilterNoStore();
        }

        private void cobDrugType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int drugType = Convert.ToInt32(cobDrugType.SelectedValue);
            DataRow[] doseRows = _doseDt.Select("TYPEDICID=" + drugType + " OR DOSEDICID=0");
            DataTable selectDoseDt = _doseDt.Clone();
            foreach (DataRow dRow in doseRows)
            {
                selectDoseDt.Rows.Add(dRow.ItemArray);
            }
            cobDrugDose.DataSource = selectDoseDt;
        }

    }
}
