using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using HIS.Model;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;



namespace HIS_YPManager
{
    public partial class MZFrmDrugRefund : GWI.HIS.Windows.Controls.BaseMainForm
    {
        long _currentUserId;
        long _currentDeptId;
        string _chineseName;
        private DataTable listMaster;
        private DataTable _dispOrder = null;
        private DataTable _dispMasterDt;
        private BillProcessor _billProcessor;
        private BillQuery _billQuery;
        private YP_DRMaster _currentMaster = new YP_DRMaster();

        public MZFrmDrugRefund()
        {
            InitializeComponent();
        }

        public MZFrmDrugRefund(long currentUserId, long currentDeptId, string chineseName)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_REFUND+"MZ");
            _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE);
            InitializeComponent();
            this.Text = _chineseName;
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void PrintRefundBill(YP_DRMaster refMaster)
        {
            try
            {
                string startPath = Application.StartupPath + "\\report\\门诊退药单据.grf";
                PrintFactory.GetPrinter(ConfigManager.OP_YF_REFUND + "MZ").PrintBill(refMaster, null, startPath, 
                    (int)_currentUserId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConfigManager.IsChecking(_currentDeptId))
                {
                    MessageBox.Show("药品正在盘点中......");
                    return;
                }
                if (MessageBox.Show("您确定要退以下药品么？", "退药确认",
                    MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
                if (_dispOrder == null || _dispOrder.Rows.Count < 1)
                {
                    MessageBox.Show("没有药品可退", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                if (CheckRefundNum() == false)
                {
                    MessageBox.Show("药品退药数量过多，请重新输入");
                    return;
                }
                List<YP_DRMaster> printList = new List<YP_DRMaster>();
                for(int index =0; index < listMaster.Rows.Count;index++)
                {
                    YP_DRMaster dispMaster = GetDRMasterFromDt(index);
                    YP_DRMaster refMaster = _billProcessor.BuildNewDispenseMaster(dispMaster,
                        (int)_currentDeptId, (int)_currentUserId);
                    List<BillOrder> refList = _billProcessor.BuildNewDispOrder(_dispOrder, dispMaster, 0);
                    if (refList.Count > 0)
                    {
                        _billProcessor.SaveBill(refMaster, refList, _currentDeptId);
                        printList.Add(refMaster);
                    }
                }
                MessageBox.Show("退药成功，请注意库存...", "退药成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);              
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                LoadData(Convert.ToInt32(txtQueryNum.Text).ToString());
                this.txtQueryNum.Focus();
            }
        }



        private YP_DRMaster GetDRMasterFromDt(int index)
        {
            if (index >= 0)
            {
                YP_DRMaster drMaster = new YP_DRMaster();
                drMaster = (YP_DRMaster)ApiFunction.DataTableToObject(listMaster, index, drMaster);
                return drMaster;
            }
            else
            {
                return null;
            }
        }


        private void MZFrmDrugRefund_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F2:
                    btnRefund_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private bool CheckRefundNum()
        {
            for (int index = 0; index < _dispOrder.Rows.Count; index++)
            {
                if (Convert.ToInt32(_dispOrder.Rows[index]["RefundNum"]) != 0)
                {
                    int totalNum = 0;
                    for (int count = 0; count < _dispOrder.Rows.Count; count++)
                    {
                        if (Convert.ToInt32(_dispOrder.Rows[count]["MAKERDICID"])
                            == Convert.ToInt32(_dispOrder.Rows[index]["MAKERDICID"]))
                        {
                            if (Convert.ToInt32(_dispOrder.Rows[count]["DRUGOC_FLAG"]) == 1)
                            {
                                totalNum += Convert.ToInt32(_dispOrder.Rows[count]["DrugOCNum"]);
                                totalNum -= Convert.ToInt32(_dispOrder.Rows[count]["RefundNum"]);
                            }
                            else
                            {
                                totalNum -= Convert.ToInt32(_dispOrder.Rows[count]["DrugOCNum"]);
                            }
                        }
                    }
                    if (totalNum < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void LoadData(string invoiceNum)
        {
            try
            {
                if (Convert.ToInt32(invoiceNum) != 0)
                {
                    listMaster = _billQuery.LoadDispMaster(invoiceNum, (int)_currentDeptId);
                    dgrdDispMaster.AutoGenerateColumns = false;
                    dgrdDispMaster.DataSource = listMaster;
                    _dispOrder = IN_InterFace.QueryRefRecipeOrder(invoiceNum);
                    dgrdDispOrder.AutoGenerateColumns = false;
                    dgrdDispOrder.DataSource = _dispOrder;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        private void MZFrmDrugRefund_Load(object sender, EventArgs e)
        {
            try
            {
                User currentUser = new User((long)this._currentUserId);
                this.txtRefunder.Text = currentUser.Name;
                this.txtQueryNum.Focus();
                this.txtQueryNum.SelectAll();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdDispOrder_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgrdDispOrder.CurrentCell != null)
            {
                int index = dgrdDispOrder.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    //如果是发药
                    if (Convert.ToInt32(_dispOrder.Rows[index]["DRUGOC_FLAG"]) == 1)
                    {
                        RefundNum.ReadOnly = false;
                    }
                    else
                    {
                        RefundNum.ReadOnly = true;
                    }
                }
            }
        }

        private void dgrdDispOrder_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (this.txtQueryNum.Text.Trim() == "")
                {
                    return;
                }
                LoadData(Convert.ToInt32(txtQueryNum.Text).ToString());
                this.btnRefund.Focus();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgrdDRMaster_CurrentCellChanged(object sender, EventArgs e)
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
                        DataTable _dispOrderDt = _billQuery.LoadOrder(_currentMaster);
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

        /// <summary>
        /// 构建查询条件列表
        /// </summary>
        private Hashtable BuildConditionParams()
        {
            Hashtable parameters = new Hashtable();
            ConditionParam param = new ConditionParam(QueryConditionType.是否审核, 1, true);
            parameters.Add(param, QueryConditionType.是否审核);
            param = new ConditionParam(QueryConditionType.开始时间, cobBeginTime.Value, true);
            parameters.Add(QueryConditionType.开始时间, param);
            param = new ConditionParam(QueryConditionType.结束时间, cobEndTime.Value, true);
            parameters.Add(QueryConditionType.结束时间, param);
            param = new ConditionParam(QueryConditionType.部门ID, (int)_currentDeptId, true);
            parameters.Add(QueryConditionType.部门ID, param);
            return parameters;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE);
                DataTable allMaster = _billQuery.LoadMaster(BuildConditionParams());
                _dispMasterDt = allMaster.Clone();
                DataRow[] filterRows;
                if (this.txtInvoiceNoQuery.Text.Trim() == "00000000")
                {
                    filterRows = allMaster.Select("INVOICENUM<>0 and DrugOC_Flag=0");
                }
                else
                {
                    filterRows = allMaster.Select("INVOICENUM=" + Convert.ToInt32(txtInvoiceNoQuery.Text)
                        + " and DrugOC_Flag=1");
                }
                foreach (DataRow dr in filterRows)
                {
                    _dispMasterDt.Rows.Add(dr.ItemArray);
                }
                dgrdDRMaster.AutoGenerateColumns = false;
                dgrdDRMaster.DataSource = _dispMasterDt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
