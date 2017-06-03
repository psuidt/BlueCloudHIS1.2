using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS_DJSFManager.类;

namespace HIS_DJSFManager.窗口
{
    public partial class FrmPatientList : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmPatientList()
        {
            InitializeComponent( );
        }
        public int SelectedPatientListId;

        private void FrmPatientList_Load( object sender , EventArgs e )
        {
            dgvPatient.DataSource = DataReader.GetPatientList( );
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( dgvPatient.Rows.Count == 0 )
                return;
            if ( dgvPatient.CurrentCell == null )
                return;

             this.SelectedPatientListId  = Convert.ToInt32( dgvPatient["PatListId" , dgvPatient.CurrentCell.RowIndex].Value );
             this.DialogResult = DialogResult.OK;
             this.Close( );
        }

        private void dgvPatient_DoubleClick( object sender , EventArgs e )
        {
            btnOk_Click( null , null );
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
    }
}
