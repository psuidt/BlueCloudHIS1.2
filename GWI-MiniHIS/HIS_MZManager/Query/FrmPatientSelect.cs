using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZManager.Query
{
    public partial class FrmPatientSelect : GWI.HIS.Windows.Controls.BaseForm
    {
        private System.Data.DataTable tbPatientList;
        private HIS.MZ_BLL.OutPatient selectPatient;

        public FrmPatientSelect(string keywordOfName)
        {
            InitializeComponent( );
            this.Text = "请选择病人";
            tbPatientList = HIS.MZ_BLL.OutPatient.GetPatientList( "PatName<>'' AND PatName like '%" + keywordOfName + "%' fetch first 100 rows only" );
            DataTable tbTmp = tbPatientList.Clone( );
            foreach ( DataColumn col in tbTmp.Columns )
            {
                if ( col.ColumnName.ToUpper( ) == "PATLISTID" || col.ColumnName.ToUpper( ) == "PATID" || col.ColumnName.ToUpper() == "PATNAME"
                    || col.ColumnName.ToUpper() == "PATSEX" || col.ColumnName.ToUpper() == "CUREDATE" || col.ColumnName.ToUpper() == "PYM" || col.ColumnName.ToUpper() == "WBM" || col.ColumnName.ToUpper() == "VISITNO" )
                {
                    continue;
                }
                else
                {
                    tbPatientList.Columns.Remove( col.ColumnName );
                }
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="withNotChargePresc">只显示有未收费处方的病人</param>
        public FrmPatientSelect(bool withNotChargePresc)
        {
            InitializeComponent( );

            int existsPresDay = 1;
            if ( HIS.MZ_BLL.OPDParamter.Parameters["010"] != null )
                existsPresDay = Convert.ToInt32( HIS.MZ_BLL.OPDParamter.Parameters["010"] );
            int existsVisitDay = 7;
            if ( HIS.MZ_BLL.OPDParamter.Parameters["011"] != null )
                existsVisitDay = Convert.ToInt32( HIS.MZ_BLL.OPDParamter.Parameters["011"] );

            this.Text = "选择病人";


            tbPatientList = HIS.MZ_BLL.OutPatient.GetPatientListByExistsPrescrition( existsVisitDay,existsPresDay );
            DataTable tbTmp = tbPatientList.Clone( );
            foreach ( DataColumn col in tbTmp.Columns )
            {
                if ( col.ColumnName.ToUpper( ) == "PATLISTID" || col.ColumnName.ToUpper( ) == "PATID" || col.ColumnName.ToUpper( ) == "PATNAME"
                    || col.ColumnName.ToUpper() == "PATSEX" || col.ColumnName.ToUpper() == "CUREDATE" || col.ColumnName.ToUpper() == "PYM" || col.ColumnName.ToUpper() == "WBM" || col.ColumnName.ToUpper() == "VISITNO" )
                {
                    continue;
                }
                else
                {
                    tbPatientList.Columns.Remove( col.ColumnName );
                }
            }
        }

        public FrmPatientSelect( DataTable datatablePatientList )
        {
            InitializeComponent( );

            tbPatientList = datatablePatientList;
        }

        public HIS.MZ_BLL.OutPatient SelectedPatient
        {
            get
            {
                return selectPatient;
            }
        }

        private void FrmPatientSelect_Load( object sender , EventArgs e )
        {
            dgvPatient.DataSource = tbPatientList.DefaultView;
        }

        private void textBox1_TextChanged( object sender , EventArgs e )
        {
            string strVal = textBox1.Text;
            try
            {

                ( (DataView)dgvPatient.DataSource ).RowFilter = "PatName like '%" + strVal + "%' or pym like '%" + strVal + "%' or wbm like '%" + strVal + "%'";
            }
            catch
            {
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnSelect_Click( object sender , EventArgs e )
        {
            if ( dgvPatient.Rows.Count == 0 )
                return;

            this.selectPatient = new HIS.MZ_BLL.OutPatient( Convert.ToInt32(dgvPatient["PATLISTID" , dgvPatient.CurrentCell.RowIndex].Value) );
            this.DialogResult = DialogResult.OK;
            this.Close( );
        }

        private void dgvPatient_DoubleClick( object sender , EventArgs e )
        {
            btnSelect_Click( null , null );
        }

        private void dgvPatient_PreviewKeyDown( object sender , PreviewKeyDownEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                e.IsInputKey = false;
                btnSelect_Click( null , null );
            }
        }

        private void textBox1_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
                btnSelect_Click( null , null );
        }

        private void FrmPatientSelect_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 27 )
                this.Close();
        }
    }
}
