using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.SYSTEM.PubicBaseClasses;
using System.IO;

namespace HIS_PublicManager
{
    public partial class FrmReportPrinterSet : BaseForm
    {
        public FrmReportPrinterSet()
        {
            InitializeComponent( );

            Cursor = Cursors.WaitCursor;
            List<Item> printers = PublicPrintSet.LoadCurrentIntalledPrinter( );
            foreach(Item item in printers )
            {
                ( (DataGridViewComboBoxColumn)dgvReport.Columns["PrinterName"] ).Items.Add( item.Text );
            }
            Cursor = Cursors.Default;
        }

        private void FrmReportPrinterSet_Load( object sender , EventArgs e )
        {
            DataTable tbConfig = PublicPrintSet.LoadLocalConfig( );
            string path = Application.StartupPath + "\\report";

            for ( int i = 0 ; i < tbConfig.Rows.Count ; i++ )
            {
                string fileFullName = tbConfig.Rows[i]["FileFullName"].ToString( ).Trim();
                int index = fileFullName.IndexOf( path );
                if ( index != -1 )
                {
                    dgvReport.Rows.Add( );
                    int row = dgvReport.Rows.Count - 1;
                    dgvReport["ReportFullName" , row].Value = tbConfig.Rows[i]["FileFullName"].ToString( );
                    dgvReport["PrinterName" , row].Value = tbConfig.Rows[i]["PrinterName"].ToString( );
                }
            }
        }

        private void button1_Click( object sender , EventArgs e )
        {
            DataSet dsConfig = new DataSet( );
            DataTable tbConfig = new DataTable( );
            tbConfig.Columns.Add( "FileFullName" );
            tbConfig.Columns.Add( "PrinterName" );

           
            for ( int i = 0 ; i < dgvReport.Rows.Count; i ++)
            {
                DataRow dr = tbConfig.NewRow( );
                dr["FileFullName"] = dgvReport["ReportFullName" , i].Value.ToString( );
                dr["PrinterName"] = dgvReport["PrinterName" , i].Value.ToString( );
                tbConfig.Rows.Add( dr );
            }
            dsConfig.Tables.Add( tbConfig );

            PublicPrintSet.SaveConfig( dsConfig );
            MessageBox.Show( "配置已保存","",MessageBoxButtons.OK,MessageBoxIcon.Information );
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnSetAll_Click( object sender , EventArgs e )
        {
            if ( dgvReport.Rows.Count == 0 ) return;
            if ( dgvReport.CurrentCell == null ) return ;
            string prienterName = dgvReport["PrinterName" , dgvReport.CurrentCell.RowIndex].Value.ToString( );

            for ( int i = 0 ; i < dgvReport.Rows.Count ; i++ )
            {
                dgvReport["PrinterName" , i].Value = prienterName;
            }
        }

        private void dgvReport_DataError( object sender , DataGridViewDataErrorEventArgs e )
        {
            e.Cancel = true;
        }
    }
}
