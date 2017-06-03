using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.YP_BLL;

namespace HIS_YPManager
{
    public partial class FrmValidityDate : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private long _currentUserId;
        private long _currentDeptId;
        private string _chineseName;
        private StoreQuery _storeQuery;


        public FrmValidityDate()
        {
            InitializeComponent();
        }

        public FrmValidityDate(long currentUserId, long currentDeptId, string chineseName)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            _storeQuery = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM);
            InitializeComponent();
        }

        private void cobDrugType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValidyDays.Focus();
            }
        }

        private void FrmValidityDate_Load(object sender, EventArgs e)
        {
            try
            {
                cobDrugType.SelectedIndex = 0;
                txtValidyDays.Text = "7";
                LoadData();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LoadData()
        {
            try
            {
                
                DataTable dt = _storeQuery.GetDrugForValidity(cobDrugType.Text,
                    Convert.ToInt32(txtValidyDays.Text), (int)_currentDeptId);
                dgrdDrugInfo.AutoGenerateColumns = false;
                dgrdDrugInfo.DataSource = dt;
                
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
