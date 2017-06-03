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
using HIS.Model;
using System.Collections;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_YPManager
{
    public partial class FrmCheckMaster : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private long _currentUserId;
        private long _currentDeptId;
        private string _chineseName;
        private bool _isAduit = false;
        private DataTable _masterDt;
        private DataTable _orderDt;
        private YP_CheckMaster _currentMaster;
        private string _belongSystem;
        private BillProcessor _billProcessor;
        private BillQuery _billQuery;
        public FrmCheckMaster()
        {
            InitializeComponent();
        }

        public FrmCheckMaster(long currentUserId, long currentDeptId, string chineseName, string belongSystem)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            this.Text = _chineseName;
            _belongSystem = belongSystem;
            if (_belongSystem == ConfigManager.YF_SYSTEM)
            {
                _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_CHECK);
                _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_CHECK);
            }
            else if (_belongSystem == ConfigManager.YK_SYSTEM)
            {
                _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YK_CHECK);
                _billQuery = BillFactory.GetQuery(ConfigManager.OP_YK_CHECK);
            }
            InitializeComponent();
        }

        private void radAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radAudit.Checked == true)
            {
                _isAduit = true;
                this.tsrbtnDel.Visible = false;
                this.tsrbtnAuditBill.Visible = false;
                this.tsrbtnUpdate.Visible = false;
            }
        }

        private void radNotAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radNotAudit.Checked == true)
            {
                _isAduit = false;
                this.tsrbtnDel.Visible = true;
                this.tsrbtnAuditBill.Visible = true;
                this.tsrbtnUpdate.Visible = true;
            }
        }

        private void chkRegTime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkRegTime.Checked == true)
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

        /// <summary>
        /// 构建查询条件列表
        /// </summary>
        private Hashtable BuildConditionParams()
        {
            Hashtable parameters = new Hashtable();
            ConditionParam param = new ConditionParam(QueryConditionType.是否审核, _isAduit == false ? 0 : 1, true);
            parameters.Add(QueryConditionType.是否审核, param);
            param = new ConditionParam(QueryConditionType.盘审单号, 
                (txtAuditNo.Text == "" ? 0 : Convert.ToInt32(txtAuditNo.Text.Trim())), chkAuditNo.Checked);
            parameters.Add(QueryConditionType.盘审单号, param);
            param = new ConditionParam(QueryConditionType.开始时间, cobBeginDate.Value, chkRegTime.Checked);
            parameters.Add(QueryConditionType.开始时间, param);
            param = new ConditionParam(QueryConditionType.结束时间, cobEndDate.Value, chkRegTime.Checked);
            parameters.Add(QueryConditionType.结束时间, param);
            param = new ConditionParam(QueryConditionType.部门ID, (int)_currentDeptId, true);
            parameters.Add(QueryConditionType.部门ID, param);
            return parameters;
        }


        private void LoadData()
        {
            dgrdCheckMaster.AutoGenerateColumns = false;
            dgrdCheckOrder.AutoGenerateColumns = false;
            _masterDt = _billQuery.LoadMaster(BuildConditionParams());
            dgrdCheckMaster.DataSource = _masterDt;
            dgrdCheckMaster_CurrentCellChanged(null, null);
        }

        private void FrmCheckMaster_Load(object sender, EventArgs e)
        {
            try
            {
                chkRegTime.Checked = true;
                LoadData();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnNewBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("一旦新增盘点单据，当前库房所有业务都将暂停，您确认要进入盘点状态么？",
                "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (!ConfigManager.IsChecking(_currentDeptId))
                    {
                        ConfigManager.BeginCheck(_currentDeptId);
                    }
                    FrmCheckOrder frmcheckOrder = new FrmCheckOrder(_currentUserId, _currentDeptId, _chineseName, _belongSystem);
                    frmcheckOrder.WindowState = FormWindowState.Maximized;
                    frmcheckOrder.MdiParent = this.MdiParent;
                    frmcheckOrder._currentMaster = (YP_CheckMaster)(_billProcessor.BuildNewMaster(_currentDeptId, _currentUserId));
                    ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmcheckOrder);
                    frmcheckOrder.Show();
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

        private void tsrbtnDel_Click(object sender, EventArgs e)
        {
            if (_currentMaster == null)
            {
                MessageBox.Show("请选中一行");
                return;
            }
            if (_currentMaster.Audit_Flag == 1)
            {
                MessageBox.Show("该单据已被审核，无法进行删除");
                return;
            }
            else
            {
                if (MessageBox.Show("该单据如果号码为0可能正在盘点，您确认要删除所选单据么？", 
                    "提示", MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        _billProcessor.DelBill(_currentMaster);
                        LoadData();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                }
            }
        }

        private void tsrbtnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentMaster == null)
            {
                MessageBox.Show("请选中一行");
                return;
            }
            if (_currentMaster.Audit_Flag == 1 || _currentMaster.BillNum == 0)
            {
                MessageBox.Show("该单据正在进行盘点或未被审核，无法进行更新");
                return;
            }
            else
            {
                FrmCheckOrder frmcheckOrder = new FrmCheckOrder(_currentUserId, _currentDeptId, _chineseName, _belongSystem);
                frmcheckOrder.WindowState = FormWindowState.Maximized;
                frmcheckOrder.MdiParent = this.MdiParent;
                frmcheckOrder._currentMaster = _currentMaster;
                frmcheckOrder._currentState = 2;
                ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmcheckOrder);
                frmcheckOrder.Show();
            }
        }

        private void tsrbtnAuditBill_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("下面将对本库房的所有盘点单据进行累加审核，您确认所有盘点单据已保存完毕并开始审核么？",
                "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                    _billProcessor.AuditBill(_currentMaster, _currentUserId, _currentDeptId);
                    LoadData();
                    MessageBox.Show("审核成功,请核查审核药品库存");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
        }

        private void tsrbtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                if (_masterDt.Rows.Count >= 1)
                {
                    dgrdCheckMaster_CurrentCellChanged(null, null);
                }
                else
                {
                    _currentMaster = null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tsrbtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void FrmCheckMaster_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F2:
                    tsrbtnNewBill_Click(null, null);
                    break;
                case Keys.F4:
                    tsrbtnDel_Click(null, null);
                    break;
                case Keys.F5:
                    tsrbtnUpdate_Click(null, null);
                    break;
                case Keys.F6:
                    tsrbtnAuditBill_Click(null, null);
                    break;
                default:
                    break;
            }
        }



        private void tsrbtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                YP_CheckMaster master = new YP_CheckMaster();
                int auditNum = 0;
                string strAuditNum = GWMHIS.BussinessLogicLayer.Forms.DlgInputBoxStatic.InputBox("", "请输入要打印的审核单号","");
                if (strAuditNum != "" && Int32.TryParse(strAuditNum, out auditNum))
                {
                    if (_belongSystem == ConfigManager.YF_SYSTEM)
                    {
                        master.OpType = ConfigManager.OP_YF_CHECK;
                    }
                    else
                    {
                        master.OpType = ConfigManager.OP_YK_CHECK;
                    }
                    master.AuditNum = auditNum;
                    master.DeptID = (int)_currentDeptId;
                    string startPath = Application.StartupPath + "\\report\\药品盘点单据.grf";
                    PrintFactory.GetPrinter(ConfigManager.OP_YK_CHECK).PrintBill(master, null, startPath,
                        (int)_currentUserId);
                }
                else
                {
                    throw new Exception("盘点单号格式不正确，请重新输入");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdCheckMaster_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (dgrdCheckMaster.CurrentCell != null)
                {
                    int currentIndex = dgrdCheckMaster.CurrentCell.RowIndex;
                    _currentMaster = GetCheckMasterFromDt(_masterDt.DefaultView.ToTable(), currentIndex);
                    _orderDt = _billQuery.LoadOrder(_currentMaster);
                    dgrdCheckOrder.DataSource = _orderDt;
                }
                else
                {
                    dgrdCheckOrder.DataSource = null;
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
        /// 从盘点表头信息表中读取盘点表头对象
        /// </summary>
        /// <param name="dtTable">盘点表头信息表</param>
        /// <param name="index"> 对应行记录索引</param>
        /// <returns>读取的盘点表头对象</returns>
        private YP_CheckMaster GetCheckMasterFromDt(DataTable dtTable, int index)
        {

            try
            {
                if (dtTable.Rows.Count < index || dtTable.Rows.Count == 0)
                {
                    return null;
                }
                YP_CheckMaster currentMaster = new YP_CheckMaster();
                HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dtTable, index, currentMaster);
                return currentMaster;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void tsrbtnClearStatus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("该操作将强制删除所有未盘点的单据（删除后处于盘点状态的单据将无法保存），"+
                "\n并将当前库房的盘点状态设置成未盘点状态,您确认要清除盘点状态么？", 
                "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    ((CheckProcessor)_billProcessor).ClearCheckStatus(_currentDeptId);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void chkAuditNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAuditNo.Checked == true)
            {
                this.txtAuditNo.Enabled = true;
            }
            else
            {
                this.txtAuditNo.Enabled = false;
            }
        }
    }
}
