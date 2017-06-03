using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace HIS_YZCXManager
{
    public partial class FrmDrugInOutQuery : GWI.HIS.Windows.Controls.BaseMainForm, IFrmInOutQuery
    {

        private FrmInOutQueryControl _control;

        private int _currentUserId;
        private int _currentDeptId;
        private string _chineseName;

        public FrmDrugInOutQuery()
        {
            InitializeComponent();
        }

        public FrmDrugInOutQuery(long currentUserId, long currentDeptId, string chineseName)
        {
            _currentUserId = (int)currentUserId;
            _currentDeptId = (int)currentDeptId;
            _chineseName = chineseName;
            InitializeComponent();
        }



        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                TimeSpan span = cobEndDate.Value - cobBeginDate.Value;
                if (span.Days > 90)
                {
                    MessageBox.Show("入出库信息查询时间间隔不能超过一个季度");
                    return;
                }
                int deptId = Convert.ToInt32(cobDrugDept.SelectedValue);
                if (tabInOutStore.SelectedTab == tabInStore)
                {
                    _control.LoadInMasterData(cobBeginDate.Value, cobEndDate.Value, deptId, cobRptType.Text, cobOpType.Text);
                }
                else
                {
                    _control.LoadOutMasterData(cobBeginDate.Value, cobEndDate.Value, deptId, cobOpType.Text);
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath + "\\report\\库房入出库统计.grf";
                _control.PrintCondition.beginTime = cobBeginDate.Value;
                _control.PrintCondition.endTime = cobEndDate.Value;
                _control.PrintCondition.billNo = tabInOutStore.SelectedIndex.ToString();
                _control.PrintCondition.exeDeptId = Convert.ToInt32(cobDrugDept.SelectedValue);
                _control.PrintCondition.printer = _currentUserId;
                _control.PrintReport(path);
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

        private void dgrdInMaster_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgrdInMaster.CurrentCell != null)
            {
                int currentIndex = dgrdInMaster.CurrentCell.RowIndex;
                if (currentIndex > -1)
                {
                    _control.LoadInOrderData(Convert.ToInt32(dgrdInMaster["PRJID", currentIndex].Value), chkIsCollect.Checked);
                }
            }
        }

        public void SetTotalFee(decimal _totalRetailFee, decimal _totalStockFee)
        {
            this.lblTotalRetailFee.Text = _totalRetailFee.ToString("0.00");
            this.lblStockFee.Text = _totalStockFee.ToString("0.00");
        }

        public void RefreshInMaster(DataTable totalInMaster)
        {
            this.dgrdInMaster.AutoGenerateColumns = false;
            this.dgrdInMaster.DataSource = totalInMaster;
            
        }

        public void RefreshOutMaster(DataTable totalOutMaster)
        {
            this.dgrdOutMaster.AutoGenerateColumns = false;
            this.dgrdOutMaster.DataSource = totalOutMaster;
        }

        public void RefreshInOrder(DataTable inOrder)
        {
            this.dgrdInOrder.AutoGenerateColumns = false;
            this.dgrdInOrder.DataSource = inOrder;
            
        }

        public void RefreshOutOrder(DataTable outOrder)
        {
            this.dgrdOutOrder.AutoGenerateColumns = false;
            this.dgrdOutOrder.DataSource = outOrder;
        }

        public void AddDrugDept(DataTable deptDt)
        {
            DataRow allDept = deptDt.NewRow();
            allDept["DEPTNAME"] = "全部库房";
            allDept["DEPTID"] = 0;
            deptDt.Rows.Add(allDept);
            cobDrugDept.DataSource = deptDt;
        }

        private void FrmDrugInOutQuery_Load(object sender, EventArgs e)
        {
            try
            {
                this._control = new FrmInOutQueryControl(this);
                cobDrugDept.SelectedIndex = 0;
                cobRptType.SelectedIndex = 0;
                cobOpType.SelectedIndex = 0;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tabInOutStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabInOutStore.SelectedTab == tabInStore)
            {
                cobRptType.Items.Clear();
                cobRptType.Items.Add("生产厂家");
                cobRptType.Items.Add("供应商");
                cobRptType.SelectedIndex = 0;
                cobOpType.Items.Clear();
                cobOpType.Items.Add("期初入库");
                cobOpType.Items.Add("采购入库");
                cobOpType.Items.Add("入库合计");
                cobOpType.SelectedIndex = 0;
            }
            else
            {
                cobRptType.Items.Clear();
                cobRptType.Items.Add("出库科室");
                cobRptType.SelectedIndex = 0;
                cobOpType.Items.Clear();
                cobOpType.Items.Add("科室出库");
                cobOpType.Items.Add("报损出库");
                cobOpType.SelectedIndex = 0;
            }
        }

        private void dgrdOutMaster_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (dgrdOutMaster.CurrentCell != null)
                {
                    int currentIndex = dgrdOutMaster.CurrentCell.RowIndex;
                    if (currentIndex > -1)
                    {
                        _control.LoadOutOrderData(Convert.ToInt32(dgrdOutMaster["PRJIDOUT", currentIndex].Value), chkIsCollect.Checked);
                    }
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

        private void btnPicOutStore_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrdOutMaster.DataSource != null)
                {
                    DataTable pictureDt = ((DataTable)(this.dgrdOutMaster.DataSource)).Copy();
                    pictureDt.Rows.RemoveAt(pictureDt.Rows.Count - 1);
                    TableColumn[] columns = new TableColumn[1];
                    columns[0].ColumnName = "出库金额";
                    columns[0].ColumnField = "RETAILFEE";
                    FrmShowGraphic showGraphic = new FrmShowGraphic(pictureDt, "PRJNAME", columns, DataTableStruct.Rows,
                        "药品出库图示");
                    showGraphic.ShowDialog();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnPicInstore_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrdInMaster.DataSource != null)
                {
                    DataTable pictureDt = ((DataTable)(this.dgrdInMaster.DataSource)).Copy();
                    pictureDt.Rows.RemoveAt(pictureDt.Rows.Count - 1);
                    TableColumn[] columns = new TableColumn[1];
                    columns[0].ColumnName = "入库金额";
                    columns[0].ColumnField = "RETAILFEE";
                    FrmShowGraphic showGraphic = new FrmShowGraphic(pictureDt, "PRJNAME", columns, DataTableStruct.Rows,
                        "药品入库图示");
                    showGraphic.ShowDialog();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void chkIsCollect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsCollect.Checked)
            {
                dgrdInOrder.Columns["ColRegTimeIn"].Visible = false;
                dgrdOutOrder.Columns["ColRegTimeOut"].Visible = false;
            }
            else
            {
                dgrdInOrder.Columns["ColRegTimeIn"].Visible = true;
                dgrdOutOrder.Columns["ColRegTimeOut"].Visible = true;
            }

        }
    }
}
