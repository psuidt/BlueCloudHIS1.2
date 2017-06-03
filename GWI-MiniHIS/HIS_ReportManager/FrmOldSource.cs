using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ReportManager
{
    public partial class FrmOldSource : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmOldSource(DataTable dtdata)
        {
            InitializeComponent();                        
            dgvData.DataSource = dtdata;
        }
    }
}
