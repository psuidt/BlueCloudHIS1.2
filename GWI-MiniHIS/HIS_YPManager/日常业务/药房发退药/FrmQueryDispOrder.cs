using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_YPManager
{
    public partial class FrmQueryDispOrder : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public FrmQueryDispOrder()
        {
            InitializeComponent();
        }

        private DataTable _recipeDt = null;

        public void setDataSource(DataTable recipeDt)
        {
            _recipeDt = recipeDt;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (_recipeDt != null)
            {
                for (int index = 0; index < _recipeDt.Rows.Count; index++)
                {
                    _recipeDt.Rows[index]["isdispense"] = 1;
                }
            }
        }

        private void btnSelectNot_Click(object sender, EventArgs e)
        {
            if (_recipeDt != null)
            {
                for (int index = 0; index < _recipeDt.Rows.Count; index++)
                {
                    _recipeDt.Rows[index]["isdispense"] = 0;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmQueryDispOrder_Load(object sender, EventArgs e)
        {
            this.dgrdQueryRecipe.AutoGenerateColumns = false;
            if (_recipeDt != null)
            {
                this.dgrdQueryRecipe.DataSource = _recipeDt;
            }
        }
    }
}
