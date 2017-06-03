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
    public partial class FrmSupportHis : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmSupportHis()
        {
            InitializeComponent();
        }

        public bool SetDgvDataSource(DataTable dataSource)
        {
            try
            {
                if (dataSource == null)
                {
                    return false;
                }
                else
                {
                    dgrdSupportHis.DataSource = dataSource;
                    return true;
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

    }
}
