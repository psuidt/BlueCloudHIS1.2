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
    public partial class FrmDispStatQuery : GWI.HIS.Windows.Controls.BaseMainForm, IFrmDispStatQuery
    {

        private FrmDispQueryControl _control;
        private int isMZZYQY=1;
        private int _makerDicId = 0;
        public FrmDispStatQuery()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan span = cobEndDate.Value - cobBeginDate.Value;
                if (span.Days > 366)
                {
                    MessageBox.Show("药品销量查询的时间间隔不能超过一年");
                    return;
                }
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                int drugTypeId = (cobDrugType.SelectedIndex + 1 == 5 ? 0 : cobDrugType.SelectedIndex + 1);
                _control.LoadDispMaster(cobBeginDate.Value, cobEndDate.Value, chkIsRefund.Checked,
                    drugTypeId, cobStatType.Text, _makerDicId, isMZZYQY);
                _makerDicId = 0;
                txtQueryCode.Clear();
                dgrdDispMaster_CellMouseDoubleClick(null, null);                
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


        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetTotalFee(decimal _totalRetailFee)
        {
            lblTotalFee.Text = _totalRetailFee.ToString("0.00");
        }
        public void RefreshDispMaster(DataTable dispMaster)
        {
            if (dispMaster != null)
            {
                dgrdDispMaster.AutoGenerateColumns = false;
                dgrdDispMaster.DataSource = dispMaster;
            }
        }
        public void RefreshDispOrder(DataTable dispOrder)
        {
           
            if (dispOrder != null)
            {
                dgrdDispOrder.AutoGenerateColumns = false;
                dgrdDispOrder.DataSource = dispOrder;
            }
        }

        public void RefreshDrugInfo(DataTable drugInfo)
        {
            if (drugInfo != null)
            {
                txtQueryCode.SetSelectionCardDataSource(drugInfo);
            }
        }

        private void FrmDispStatQuery_Load(object sender, EventArgs e)
        {
            _control = new FrmDispQueryControl(this);
            cobDrugType.SelectedIndex = 0;
            cobStatType.SelectedIndex = 0;
            radMZStat.Checked = true;
            cobBeginDate.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
            cobEndDate.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
        }

        private void radMZStat_CheckedChanged(object sender, EventArgs e)
        {
            isMZZYQY = 1;
        }

        private void radZYStat_CheckedChanged(object sender, EventArgs e)
        {
            isMZZYQY = 2;
        }

        private void radQYStat_CheckedChanged(object sender, EventArgs e)
        {
            isMZZYQY = 3;
        }

        private void dgrdDispMaster_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgrdDispMaster.CurrentCell != null)
                {
                    int currentIndex = dgrdDispMaster.CurrentCell.RowIndex;
                    if (currentIndex > -1)
                    {
                        int prjId = Convert.ToInt32(dgrdDispMaster["PRJID", currentIndex].Value);
                        _control.LoadDispOrder(prjId);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtQueryCode_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (SelectedValue != null)
            {
                DataRow selectRow = (DataRow)SelectedValue;
                _makerDicId = Convert.ToInt32(selectRow["MAKERDICID"]);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)//导出开方科室药品汇总 zhangyunhui 5.8
        {
            try
            {
                if (dgrdDispMaster.CurrentCell != null)
                {
                    //int currentIndex = dgrdDispMaster.CurrentCell.RowIndex;
                    //if (currentIndex > -1)
                    //{
                    //    int prjId = Convert.ToInt32(dgrdDispMaster["PRJID", currentIndex].Value);
                    //    _control.Exportdata(prjId, cobBeginDate.Value, cobEndDate.Value);
                    //}
                    _control.ExportData((DataTable)dgrdDispMaster.DataSource, cobBeginDate.Value, cobEndDate.Value);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

       
    }
}
