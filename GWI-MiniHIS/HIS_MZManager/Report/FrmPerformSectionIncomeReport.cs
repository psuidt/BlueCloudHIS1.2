using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.MZ_BLL.Report;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.MZ_BLL;
using System.Collections;

namespace HIS_MZManager.Report
{
    public partial class FrmPerformSectionIncomeReport : BaseMainForm
    {
        public FrmPerformSectionIncomeReport(string FormText)
        {
            InitializeComponent( );

            this.Text = FormText;
            this.FormTitle = FormText;
            this.Font = font1;
            this.Load += new EventHandler( FrmPerformSectionIncomeReport_Load );
        }
        private Font font1 = new Font( "宋体" , 9F );
        private Font font2 = new Font( "宋体" , 11F, FontStyle.Bold );
        void FrmPerformSectionIncomeReport_Load( object sender , EventArgs e )
        {
            dtpFrom.Value = Convert.ToDateTime( DateTime.Now.Year.ToString( ) + "-" + DateTime.Now.Month.ToString( ) + "-01 00:00:00" );
            dtpEnd.Value = dtpFrom.Value.AddMonths( 1 ).AddSeconds( -1 );
            AddComboxEvent( );
            
        }

        void SetGridStyle(  )
        {
            for ( int i = 0 ; i < dgvResult.Rows.Count ; i++ )
            {
                if ( Convert.ToInt32( dgvResult[COL_SUB_FLAG.Name , i].Value ) == 1 )
                {
                    dgvResult[COL_COUNT.Name , i].Value = DBNull.Value;
                    dgvResult.SetRowColor( i , Color.Blue , Color.LightGray );
                    for ( int j = 0 ; j < dgvResult.Columns.Count ; j++ )
                    {
                        if ( dgvResult.Columns[j].Visible )
                        {
                            dgvResult[j , i].Style.Font = font2;
                        }
                    }
                }
            }
        }

        void FillComboBox()
        {
            DeleteComboxEvent( );
            Hashtable htOffice = new Hashtable( );
            Hashtable htItemName = new Hashtable( );
            Hashtable htStatItem = new Hashtable( );
            Hashtable htInvoice = new Hashtable( );
            cboOffice.DataSource = null;
            cboStatItem.Items.Clear( );
            chkOffice.Checked = false;
            chkStatItem.Checked = false;
            for ( int i = 0 ; i < dgvResult.Rows.Count ; i++ )
            {
                string officeName = dgvResult[COL_DEPT_NAME.Name , i].Value != null ? dgvResult[COL_DEPT_NAME.Name , i].Value.ToString( ).Trim() : "";
                string execdeptcode = dgvResult[COL_DEPT_ID.Name , i].Value.ToString( ).Trim( );
                string itemName = dgvResult[COL_ITEM_NAME.Name , i].Value != null ? dgvResult[COL_ITEM_NAME.Name , i].Value.ToString( ).Trim() : "";
                string statItem = dgvResult[COL_STATNAME.Name , i].Value != null ? dgvResult[COL_STATNAME.Name , i].Value.ToString( ).Trim() : "";
                string invoiceName = dgvResult[COL_FPNAME.Name , i].Value != null ? dgvResult[COL_FPNAME.Name , i].Value.ToString( ).Trim() : "";
                if ( officeName != "" )
                {
                    if ( !htOffice.ContainsKey( officeName ) )
                    {
                        htOffice.Add( execdeptcode , officeName );
                    }
                }
                
                if ( statItem != "" )
                {
                    if ( !htStatItem.ContainsKey( statItem ) )
                    {
                        cboStatItem.Items.Add( statItem );
                        htStatItem.Add( statItem , statItem );
                    }
                }
                if ( invoiceName != "" )
                {
                    if ( !htInvoice.ContainsKey( invoiceName ) )
                    {
                        htInvoice.Add( invoiceName , invoiceName );
                    }
                }
            }
            DataTable tbOffice = new DataTable( );
            tbOffice.Columns.Add( "DEPT_ID" );
            tbOffice.Columns.Add( "DEPT_NAME" );
            foreach ( object obj in htOffice )
            {
                DataRow dr = tbOffice.NewRow( );
                dr["DEPT_ID"] = ( (DictionaryEntry)obj ).Key.ToString( );
                dr["DEPT_NAME"] = ( (DictionaryEntry)obj ).Value.ToString( );
                tbOffice.Rows.Add( dr );
            }
            cboOffice.DisplayMember = "DEPT_NAME";
            cboOffice.ValueMember = "DEPT_ID";
            cboOffice.DataSource = tbOffice;
            AddComboxEvent( );
        }

        void AddComboxEvent()
        {
            cboOffice.SelectedIndexChanged += new EventHandler( ComboBox_SelectedIndexChanged );
            
            cboStatItem.SelectedIndexChanged += new EventHandler( ComboBox_SelectedIndexChanged );
        }

        void DeleteComboxEvent()
        {
            cboOffice.SelectedIndexChanged -= ComboBox_SelectedIndexChanged ;
            cboStatItem.SelectedIndexChanged -=  ComboBox_SelectedIndexChanged ;
        }

        private void btnStat_Click( object sender , EventArgs e )
        {
            btnStat.Enabled = false;
            btnPrint.Enabled = false;
            btnClose.Enabled = false;
            try
            {
                PerformOfficeIncomeReport report = new PerformOfficeIncomeReport( dtpFrom.Value , dtpEnd.Value );
                report.Fill( );
                this.dgvResult.DataSource = report.Result.DefaultView;
                FillComboBox( );
                SetGridStyle( );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            finally
            {
                btnStat.Enabled = true;
                btnPrint.Enabled = true;
                btnClose.Enabled = true;
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnExcel_Click( object sender , EventArgs e )
        {
            
        }

        private void btnPrint_Click( object sender , EventArgs e )
        {
            if ( dgvResult.DataSource != null )
            {
                string beginAndEnd = dtpFrom.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) + "--" + dtpEnd.Value.ToString( "yyyy-MM-dd HH:mm:ss" );
                PrintController.PrintPerformSectionIncomeReport( ( (DataView)dgvResult.DataSource ).Table , beginAndEnd );
            }
        }

        
        private void CheckBox_CheckedChanged( object sender , EventArgs e )
        {
            cboOffice.Enabled = chkOffice.Checked;
            cboStatItem.Enabled = chkStatItem.Checked;
            ShowDataList( );
        }

        private void ComboBox_SelectedIndexChanged( object sender , EventArgs e )
        {
            ShowDataList( );
        }

        void ShowDataList()
        {
            string filter = "";
            if ( chkOffice.Checked && cboOffice.Text != "" )
            {
                filter = "EXECDEPTCODE = '" + cboOffice.SelectedValue.ToString( ) + "'";
            }
            else
            {
                filter = "EXECDEPTCODE<>''";
            }

            if ( chkStatItem.Checked && cboStatItem.Text != "" )
            {
                filter += " AND ( STATNAME = '"+cboStatItem.Text+"' AND SUB_FLAG =0 ) OR (SUB_FLAG = 1)";
            }

            if ( dgvResult.DataSource != null )
            {
                ( (DataView)dgvResult.DataSource ).RowFilter = filter;
                SetGridStyle( );
            }
        }
    }
}
