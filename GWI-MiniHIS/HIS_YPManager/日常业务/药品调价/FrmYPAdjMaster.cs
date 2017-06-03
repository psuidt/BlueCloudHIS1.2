using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;
using HIS.Model;
using GWMHIS.BussinessLogicLayer.Classes;


namespace HIS_YPManager
{
    public partial class FrmYPAdjMaster : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private long _currentUserId;
        private long _currentDeptId;
        private string _chineseName;
        private DataTable _masterDt;
        private DataTable _orderDt;
        private YP_AdjMaster _currentMaster = new YP_AdjMaster();
        private string _belongSystem;
        private BillProcessor _billProcessor;
        private BillQuery _billQuery;
        public FrmYPAdjMaster()
        {
            InitializeComponent();
        }

        public FrmYPAdjMaster(long currentUserId, long currentDeptId, string chineseName, string belongSystem)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            _belongSystem = belongSystem;
            if (_belongSystem == ConfigManager.YF_SYSTEM)
            {
                _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_ADJPRICE);
                _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_ADJPRICE);
            }
            else
            {
                _billQuery = BillFactory.GetQuery(ConfigManager.OP_YK_ADJPRICE);
                _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YK_ADJPRICE);
            }
            InitializeComponent();
        }

        /// <summary>
        /// 构建查询条件列表
        /// </summary>
        private Hashtable BuildConditionParams()
        {
            Hashtable parameters = new Hashtable();
            ConditionParam param = new ConditionParam(QueryConditionType.是否审核, 1, true);
            parameters.Add(QueryConditionType.是否审核, param);
            param = new ConditionParam(QueryConditionType.开始时间, cobBeginDate.Value, chkRegTime.Checked);
            parameters.Add(QueryConditionType.开始时间, param);
            param = new ConditionParam(QueryConditionType.结束时间, cobEndDate.Value, chkRegTime.Checked);
            parameters.Add(QueryConditionType.结束时间, param);
            param = new ConditionParam(QueryConditionType.部门ID, (int)_currentDeptId, true);
            parameters.Add(QueryConditionType.部门ID, param);
            param = new ConditionParam(QueryConditionType.单据号, txtBillNum.Text == "" ? 0 : Convert.ToInt32(txtBillNum.Text), chkBillNum.Checked);
            parameters.Add(QueryConditionType.单据号, param);
            param = new ConditionParam(QueryConditionType.调价单号, txtAdjCode.Text, chkAdjCode.Checked);
            parameters.Add(QueryConditionType.调价单号, param);
            return parameters;
        }

        private void LoadData()
        {
            try
            {
                dgrdAdjMaster.AutoGenerateColumns = false;
                dgrdAdjOrder.AutoGenerateColumns = false;
                _masterDt = _billQuery.LoadMaster(BuildConditionParams());
                dgrdAdjMaster.DataSource = _masterDt;
                dgrdAdjMaster_CurrentCellChanged(null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void chkAdjCode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdjCode.Checked == true)
            {
                this.txtAdjCode.Enabled = true;
            }
            else
            {
                this.txtAdjCode.Enabled = false;
            }
        }

        private void chkBillNum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBillNum.Checked == true)
            {
                this.txtBillNum.Enabled = true;
            }
            else
            {
                this.txtBillNum.Enabled = false;
            }
        }

        private void chkRegTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegTime.Checked == true)
            {
                this.cobBeginDate.Enabled = true;
                this.cobEndDate.Enabled = true;
            }
            else
            {
                this.cobBeginDate.Enabled = false;
                this.cobEndDate.Enabled = false;
            }
        }

        private void FrmAdjMaster_Load(object sender, EventArgs e)
        {
            try
            {
                chkRegTime.Checked = true;
                LoadData();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }


        private void tsrbtnNew_Click(object sender, EventArgs e)
        {
            FrmYPAdjOrder frmOrder = new FrmYPAdjOrder(0, _belongSystem);
            frmOrder.MdiParent = this.MdiParent;
            frmOrder.WindowState = FormWindowState.Maximized;
            frmOrder._adjMaster = (YP_AdjMaster)(_billProcessor.BuildNewMaster(_currentDeptId, _currentUserId));
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmOrder);
            frmOrder.Show();
        }

        private void tsrbtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void FrmAdjMaster_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F2:
                    tsrbtnNew_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void tsrbtnPrint_Click(object sender, EventArgs e)
        {
            string startPath = Application.StartupPath + "\\report\\药品调价单据.grf";
            PrintFactory.GetPrinter(ConfigManager.OP_YK_ADJPRICE).PrintBill(_currentMaster, _orderDt,
                startPath, (int)_currentUserId);
        }

        private void dgrdAdjMaster_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (dgrdAdjMaster.CurrentCell != null)
                {
                    int currentIndex = dgrdAdjMaster.CurrentCell.RowIndex;
                    _currentMaster = GetAdjMasterFromDt(_masterDt.DefaultView.ToTable(), currentIndex, _currentMaster);
                    _orderDt = _billQuery.LoadOrder(_currentMaster);
                    dgrdAdjOrder.DataSource = _orderDt;
                }
                else
                {
                    dgrdAdjOrder.DataSource = null;
                    _currentMaster = null;
                }
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

        /// <summary>
        /// 从调价表头信息表中获取指定行记录对应的调价表头对象
        /// </summary>
        /// <param name="dtTable">调价表头信息表</param>
        /// <param name="index">指定行记录索引</param>
        /// <param name="_AdjMaster">调价表头对象</param>
        /// <returns>调价表头信息表</returns>
        private YP_AdjMaster GetAdjMasterFromDt(DataTable dtTable, int index, YP_AdjMaster _AdjMaster)
        {

            try
            {
                if (dtTable.Rows.Count < index || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                if (_AdjMaster == null)
                {
                    _AdjMaster = new YP_AdjMaster();
                }
                HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dtTable, index, _AdjMaster);
                return _AdjMaster;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
