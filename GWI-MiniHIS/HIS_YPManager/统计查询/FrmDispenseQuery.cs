using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;
using HIS.Model;

namespace HIS_YPManager
{
    public partial class FrmDispenseQuery : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public FrmDispenseQuery()
        {
            InitializeComponent();
        }

        public FrmDispenseQuery(long currentUserId, long currentDeptId, string chineseName)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;

            this.Text = "药房发药查询";
            this.FormTitle = this.Text;
            InitializeComponent();
        }
        private long _currentUserId;
        private long _currentDeptId;
        private string _chineseName;
        private DataTable _dispMasterDt;
        private DataTable _dispOrderDt;
        private DataTable _deptDispDt;
        private YP_DRMaster _currentMaster = new YP_DRMaster();
        private YP_DispDeptHis _currentDeptDisp = new YP_DispDeptHis();
        private BillQuery _billQuery;

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void FrmDispenseQuery_Load(object sender, EventArgs e)
        {
            try
            {
                _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE);
                cobOPType.SelectedIndex = 0;
                LoadData();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        /// <summary>
        /// 构建查询条件列表
        /// </summary>
        private Hashtable BuildConditionParams()
        {
            Hashtable parameters = new Hashtable();
            ConditionParam param = new ConditionParam(QueryConditionType.是否审核, 1, true);
            parameters.Add(param, QueryConditionType.是否审核);
            param = new ConditionParam(QueryConditionType.开始时间, cobBeginDate.Value, true);
            parameters.Add(QueryConditionType.开始时间, param);
            param = new ConditionParam(QueryConditionType.结束时间, cobEndDate.Value, true);
            parameters.Add(QueryConditionType.结束时间, param);
            param = new ConditionParam(QueryConditionType.部门ID, (int)_currentDeptId, true);
            parameters.Add(QueryConditionType.部门ID, param);
            return parameters;
        }

        private void LoadData()
        {
            try
            {
                if (tabDispQuery.SelectedTab == tabPgSingle)
                {
                    _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE);
                    DataTable allMaster = _billQuery.LoadMaster(BuildConditionParams());
                    _dispMasterDt = allMaster.Clone();
                    if (cobOPType.Text == "门诊")
                    {
                        DataRow[] filterRows;
                        if (txtQueryCode.Text == "")
                        {
                            filterRows = allMaster.Select("INVOICENUM<>0");
                        }
                        else
                        {
                            filterRows = allMaster.Select("INVOICENUM=" + txtQueryCode.Text);
                        }
                        foreach (DataRow dr in filterRows)
                        {
                            _dispMasterDt.Rows.Add(dr.ItemArray);
                        }
                    }
                    else
                    {
                        DataRow[] filterRows;
                        if (txtQueryCode.Text == "")
                        {
                            filterRows = allMaster.Select("INVOICENUM=0");
                        }
                        else
                        {
                            filterRows = allMaster.Select("INPATIENTID='" + txtQueryCode.Text + "' AND INVOICENUM=0");
                        }
                        foreach (DataRow dr in filterRows)
                        {
                            _dispMasterDt.Rows.Add(dr.ItemArray);
                        }
                    }
                    dgrdDRMaster.DataSource = _dispMasterDt;
                    if (_dispOrderDt != null)
                    {
                        _dispOrderDt.Rows.Clear();
                    }
                }
                else
                {
                    _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE + "ZY_TL");
                    _deptDispDt = _billQuery.LoadMaster(BuildConditionParams());
                    dgrdDispDept.AutoGenerateColumns = false;
                    dgrdDispDept.DataSource = _deptDispDt;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string startPath = Application.StartupPath;
                YP_Printer printer;
                if (tabDispQuery.SelectedTab == tabPgSingle)
                {
                    //如果是门诊发药,发票号为0
                    if (_currentMaster.InvoiceNum != 0)
                    {
                        //如果是发药
                        if (_currentMaster.DrugOC_Flag == 1)
                        {
                            printer = PrintFactory.GetPrinter(ConfigManager.OP_YF_DISPENSE + "MZ");
                            startPath += "\\report\\门诊发药单据.grf";
                        }
                        //如果是退药
                        else
                        {
                            printer = PrintFactory.GetPrinter(ConfigManager.OP_YF_REFUND + "MZ");
                            startPath += "\\report\\门诊退药单据.grf";
                        }
                    }
                    //如果是住院发药
                    else
                    {
                        if (_currentMaster.DrugOC_Flag == 1)
                        {
                            printer = PrintFactory.GetPrinter(ConfigManager.OP_YF_DISPENSE + "ZY_BY");
                            startPath += "\\report\\住院摆药单(经管).grf";
                        }
                        else
                        {
                            printer = PrintFactory.GetPrinter(ConfigManager.OP_YF_REFUND + "ZY");
                            startPath += "\\report\\住院退药单据.grf";
                        }
                    }
                    printer.PrintBill(_currentMaster, null, startPath, (int)_currentUserId);
                }
                else
                {
                    printer = PrintFactory.GetPrinter(ConfigManager.OP_YF_DISPENSE + "ZY_TL");
                    startPath += "\\report\\统领发药单据(经管).grf";
                    printer.PrintBill(_currentDeptDisp, (DataTable)(dgrdDispOrder.DataSource), startPath, (int)_currentUserId);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tabDispQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabDispQuery.SelectedTab == tabPgSingle)
            {
                _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE);
            }
            else
            {
                _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE + "ZY_TL");
            }
        }

        private void dgrdDRMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgrdDRMaster.CurrentCell != null)
                {
                    int rowIndex = dgrdDRMaster.CurrentCell.RowIndex;
                    HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(_dispMasterDt.DefaultView.ToTable(),
                        rowIndex, _currentMaster);
                    if (_currentMaster != null)
                    {
                        _dispOrderDt = _billQuery.LoadOrder(_currentMaster);
                        dgrdDROrder.AutoGenerateColumns = false;
                        dgrdDROrder.DataSource = _dispOrderDt;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdDispDept_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgrdDispDept.CurrentCell != null)
            {
                try
                {
                    this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                    int rowIndex = dgrdDispDept.CurrentCell.RowIndex;
                    HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(_deptDispDt.DefaultView.ToTable(),
                        rowIndex, _currentDeptDisp);
                    if (_currentDeptDisp != null)
                    {
                        this.dgrdDispOrder.AutoGenerateColumns = false;
                        this.dgrdDispOrder.DataSource = _billQuery.LoadOrder(_currentDeptDisp);
                    }
                    this.Cursor = DefaultCursor;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                finally
                {
                    this.Cursor = DefaultCursor;
                }
            }
        }

        private void cobOPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobOPType.SelectedIndex == 0)
            {
                lblqueryCode.Text = "发票号:";               
            }
            else
            {
                lblqueryCode.Text = "住院号:";
            }
            this.txtQueryCode.Text = "";
        }
    }
}
