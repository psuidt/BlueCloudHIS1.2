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
    public partial class FrmStoreQuery : GWI.HIS.Windows.Controls.BaseMainForm, HIS_YZCXManager.IFrmStoreQuery
    {
        public FrmStoreQuery()
        {
            InitializeComponent();
        }

        private FrmStorequeryControl _control; 

        private void FrmStoreQuery_Load(object sender, EventArgs e)
        {
            cobDrugType.SelectedIndex = 0;
            lblRetailfee.Text = "0.00";
            lblTradeFee.Text = "0.00";
            lblDiffFee.Text = "0.00";
            _control = new FrmStorequeryControl(this);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                _control.LoadData(cobDrugType.Text, txtQueryCode.Text.Trim());
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

        private void dgrdDrugStore_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgrdDrugStore.CurrentCell != null)
            {
                int selectIndex = dgrdDrugStore.CurrentCell.RowIndex;
                if (selectIndex >= 0)
                {
                    int queryId = Convert.ToInt32(dgrdDrugStore["MAKERDICID", selectIndex].Value);
                    _control.GetDeptSplit(queryId);
                }
            }
        }

        public void RefreshStoreInfo(DataTable totalStoreDt)
        {
            try
            {
                dgrdDrugStore.AutoGenerateColumns = false;
                dgrdDrugStore.DataSource = totalStoreDt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        public void RefreshDeptSplit(DataTable deptSplit)
        {
            try
            {
                dgrdDeptStore.AutoGenerateColumns = false;
                dgrdDeptStore.DataSource = deptSplit;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        public void RefreshFee(decimal retailFee, decimal tradeFee)
        {
            lblRetailfee.Text = retailFee.ToString("0.00");
            lblTradeFee.Text = tradeFee.ToString("0.00");
            lblDiffFee.Text = (retailFee - tradeFee).ToString("0.00");
        }
    }
}
