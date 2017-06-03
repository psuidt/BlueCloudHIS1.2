using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Model;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;


namespace HIS_YPManager
{
    public partial class ZYFrmDrugRefund : GWI.HIS.Windows.Controls.BaseMainForm
    {
        long _currentUserId;
        long _currentDeptId;
        string _chineseName;
        private ZY_PatList _currentZYPat;
        private DataTable _dispOrder = null;
        private BillProcessor _billProcessor;

        public ZYFrmDrugRefund()
        {
            InitializeComponent();
        }

        public ZYFrmDrugRefund(long currentUserId, long currentDeptId, string chineseName)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_REFUND+"ZY");
            this.Text = _chineseName;
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void ShowCurrentPat()
        {
            DateTime currentTime = XcDate.ServerDateTime;
            this.txtPatName.Text = XcConvert.IsNull(_currentZYPat.PatientInfo.PatName, "拒绝");
            this.txtPatAge.Text = Age.GetAgeString(_currentZYPat.PatientInfo.PatBriDate, currentTime, 1);
            this.txtPatSex.Text = XcConvert.IsNull(_currentZYPat.PatientInfo.PatSex, "拒绝");
            this.txtBedNo.Text = XcConvert.IsNull(_currentZYPat.BedCode, "暂无");
            long patDeptId = Convert.ToInt64(_currentZYPat.CurrDeptCode);
            string patDeptName = new GWMHIS.BussinessLogicLayer.Classes.Deptment(patDeptId).Name;
            this.txtPatDept.Text = XcConvert.IsNull(patDeptName, "暂无");
            
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
                if (MessageBox.Show("您确定要退以下药品么？", "退药确认", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
                if (_dispOrder == null || _dispOrder.Rows.Count < 1)
                {
                    MessageBox.Show("没有药品可退", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                ZY_DispPresInfo presInfo = new ZY_DispPresInfo();
                presInfo.CureDocCode = _currentZYPat.CureDocCode;
                presInfo.CureNo = _currentZYPat.CureNo;
                presInfo.drFlag = 0;
                presInfo.opType = ConfigManager.OP_YF_REFUND;
                presInfo.PatListId = _currentZYPat.PatListID;
                presInfo.PatName = _currentZYPat.PatientInfo.PatName;
                presInfo.presDeptId = Convert.ToInt32(_currentZYPat.CurrDeptCode);
                presInfo.recipeNum = 1;
                YP_DRMaster refMaster = _billProcessor.BuildNewDispenseMaster(presInfo,(int)_currentDeptId, (int)_currentUserId);
                List<BillOrder> refList = _billProcessor.BuildNewDispOrder(_dispOrder, refMaster, 1);
                _billProcessor.SaveBill(refMaster, refList, _currentDeptId);                
                MessageBox.Show("退药成功,请及时告知记账护士进行冲账");
                this.txtQueryNum.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                _dispOrder = IN_InterFace.QueryRefRecipeOrder(_currentZYPat, (int)_currentDeptId,
                    cobBeginDate.Value, cobEndDate.Value);
                dgrdDispOrder.DataSource = _dispOrder;
                this.Cursor = DefaultCursor;
            }
        }

        private void dgrdDispOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgrdDispOrder.Columns["REFUNDNUM"].Index)
            {
                decimal refundNum = Convert.ToDecimal(_dispOrder.Rows[e.RowIndex]["REFUNDNUM"]);
                decimal totalRefNum = Convert.ToDecimal(_dispOrder.Rows[e.RowIndex]["TOTALREFUNDNUM"]);
                decimal totalDispNum = Convert.ToDecimal(_dispOrder.Rows[e.RowIndex]["TOTALDISPENSENUM"]);
                if (refundNum + totalRefNum > totalDispNum)
                {
                    MessageBox.Show("退药数量过多");
                    _dispOrder.Rows[e.RowIndex]["RefundNum"] = 0;
                }
                else if (refundNum < 0)
                {
                    MessageBox.Show("退药数量不能小于0");
                    _dispOrder.Rows[e.RowIndex]["RefundNum"] = 0;
                }
            }
        }


        private void ZYFrmDrugRefund_KeyDown(object sender, KeyEventArgs e)
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


        private void ZYFrmDrugRefund_Load(object sender, EventArgs e)
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

        private void chkIsRefundAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_dispOrder != null)
            {
                if (chkIsRefundAll.Checked)
                {
                    for (int index = 0; index < _dispOrder.Rows.Count; index++)
                    {
                        DataRow dRow = _dispOrder.Rows[index];
                        dRow["REFUNDNUM"] = Convert.ToDecimal(dRow["TOTALDISPENSENUM"]) -
                            Convert.ToDecimal(dRow["TOTALREFUNDNUM"]);
                    }
                }
                else
                {
                    for (int index = 0; index < _dispOrder.Rows.Count; index++)
                    {
                        DataRow dRow = _dispOrder.Rows[index];
                        dRow["REFUNDNUM"] = 0;
                    }
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                _currentZYPat = IN_InterFace.QueryPatByInpatNum(this.txtQueryNum.Text.Trim());
                if (_currentZYPat == null)
                {
                    MessageBox.Show(this.txtQueryNum, "该病人不存在");
                    this.txtQueryNum.Text = "";
                    return;
                }
                if (_currentZYPat.PatType != "2")
                {
                    MessageBox.Show(this.txtQueryNum, "该病人已出院，无法退药");
                    this.txtQueryNum.Text = "";
                    return;
                }
                ShowCurrentPat();
                _dispOrder = IN_InterFace.QueryRefRecipeOrder(_currentZYPat, (int)_currentDeptId,
                                cobBeginDate.Value, cobEndDate.Value);
                dgrdDispOrder.DataSource = _dispOrder;
                this.btnRefund.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                this.Cursor = this.DefaultCursor;
            }
        }
    }
}
