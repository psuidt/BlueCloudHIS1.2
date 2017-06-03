using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using System.Windows.Forms;

namespace HIS_YPManager
{
    public partial class FrmStoreLimitQuery : GWI.HIS.Windows.Controls.BaseMainForm
    {

        public FrmStoreLimitQuery()
        {
            InitializeComponent();
        }

        public FrmStoreLimitQuery(string FormText, long currentUserId, long currentDeptId, string belongSystem)
        {
            InitializeComponent( );

            this.Text = FormText;
            this.FormTitle = this.Text;
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _belongSystem = belongSystem;
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        private long _currentUserId;
        /// <summary>
        /// 当前部门
        /// </summary>
        private long _currentDeptId;
        private DataTable _drugStoreInfoDt = new DataTable();
        private StoreQuery _storeQuery;
        private string _belongSystem;

        private void FrmStoreLimitQuery_Load(object sender, EventArgs e)
        {
            
            _drugStoreInfoDt.PrimaryKey = new DataColumn[] { _drugStoreInfoDt.Columns["MAKERDICID"] };
            _storeQuery = StoreFactory.GetQuery(_belongSystem);
            if (_belongSystem == ConfigManager.YF_SYSTEM)
            {
                dgrdDrugInfo.Columns["USEUNIT"].DataPropertyName = "UNITNAME";
                if (!ConfigManager.ManageTradepriceByYF())
                {
                    this.dgrdDrugInfo.Columns["TRADEPRICE"].Visible = false;
                }
            }
            cobQueryType.SelectedIndex = 1;
            cobDrugType.SelectedIndex = 0;
            cobQueryType.Focus();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            try
            {
                if (cobQueryType.SelectedIndex == 0)
                {
                    _drugStoreInfoDt = _storeQuery.GetDrugForStoreLimit(txtQueryCode.Text, true, (int)_currentDeptId,
                        (int)cobDrugType.SelectedIndex);
                }
                else
                {
                    _drugStoreInfoDt = _storeQuery.GetDrugForStoreLimit(txtQueryCode.Text, false, (int)_currentDeptId,
                        (int)cobDrugType.SelectedIndex);
                }
                _drugStoreInfoDt.PrimaryKey = new DataColumn[] { _drugStoreInfoDt.Columns["MAKERDICID"] };
                dgrdDrugInfo.AutoGenerateColumns = false;
                dgrdDrugInfo.DataSource = _drugStoreInfoDt;
                
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string startPath = Application.StartupPath + "\\report\\药品库存清单.grf";
                YP_Printer.PrintStoreBill(startPath, (int)_currentUserId, (int)_currentDeptId, _drugStoreInfoDt, _belongSystem);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cobQueryType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQueryCode.Focus();
                txtQueryCode.SelectAll();
            }
        }

        private void btnBuildPlan_Click(object sender, EventArgs e)
        {
            if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                FrmStockPlan frmstockplan = new FrmStockPlan(_currentUserId, _currentDeptId, true);
                frmstockplan.WindowState = FormWindowState.Maximized;
                ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmstockplan);
            }
            else
            {
                FrmSelectOutDept frmSelctDept = new FrmSelectOutDept();
                if (frmSelctDept.ShowDialog() == DialogResult.OK)
                {
                    FrmYFApplyorder frmOrder = new FrmYFApplyorder(_currentUserId, _currentDeptId, 0, true);
                    frmOrder._outDept.DeptID = frmSelctDept._storeDeptId;
                    frmOrder._outDept.DeptName = frmSelctDept._deptName;
                    frmOrder._outDept.DeptType1 = "药库";
                    frmOrder.LimitDt = GetUseLimitRow();
                    frmOrder.WindowState = FormWindowState.Maximized;
                    ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmOrder);
                }
            }
        }

        private DataTable GetUseLimitRow()
        {
            DataTable uselimitDt = _drugStoreInfoDt.Clone();
            for (int index = 0; index < dgrdDrugInfo.Rows.Count; index++)
            {
                int makerDicId = Convert.ToInt32(dgrdDrugInfo["MAKERDICID", index].Value);
                if (Convert.ToInt16(dgrdDrugInfo["ISSELECT", index].Value) == 1)
                {
                    DataRow selectRow = _drugStoreInfoDt.Rows.Find(makerDicId);
                    if (selectRow != null)
                    {
                        uselimitDt.Rows.Add(selectRow.ItemArray);
                    }
                }
            }
            return uselimitDt;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                txtQueryCode.Focus();
                txtQueryCode.SelectAll();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdDrugInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)//如果单击列表头，全选．
            {
                int index;
                for (index = 0; index < this.dgrdDrugInfo.RowCount; index++)
                {
                    this.dgrdDrugInfo.EndEdit();//结束编辑状态．
                    string re_value = this.dgrdDrugInfo.Rows[index].Cells["ISSELECT"].EditedFormattedValue.ToString();
                    this.dgrdDrugInfo.Rows[index].Cells["ISSELECT"].Value = 1;//如果为true则为选中,false未选中
                    this.dgrdDrugInfo.Rows[index].Selected = true;//选中整行。
                }
            }
        }
    }
}
