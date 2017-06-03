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
    public partial class FrmInvoiceQuery : GWI.HIS.Windows.Controls.BaseMainForm // GWMHIS.BussinessLogicLayer.Forms.BaseForm
    {
        private int _currentEmployeeId;

        public FrmInvoiceQuery( string FormText , int CurrentEmployeeId )
        {
            InitializeComponent( );

            this.Text = FormText;

            _currentEmployeeId = CurrentEmployeeId;
        
        }

        private void button1_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnQuery_Click( object sender , EventArgs e )
        {
            lblActCost.Text = "";
            lblTotalCost.Text = "";
            lblTotalNum.Text = "";
            lblReturnCost.Text = "";
            lblReturnNum.Text = "";
            lblTotalCash.Text = "";
            lblTotalFavor.Text = "";
            lblTotalPOS.Text = "";
            lblTotalTally.Text = "";
            plInvoice.Visible = false;
            try
            {
                DataTable tbList = null;
                if ( chkall.Checked )
                    tbList = DataReader.GetChargeInvoiceList( this.dtpFrom.Value , dtpTo.Value  );
                else
                    tbList = DataReader.GetChargeInvoiceList( this.dtpFrom.Value , dtpTo.Value , Convert.ToInt32( _currentEmployeeId ) );

                OPDBillKind invoiceType = OPDBillKind.所有发票;

                foreach ( object obj in Enum.GetValues( typeof( OPDBillKind ) ) )
                {
                    if ( obj.ToString( ) == cboInvoiceType.Text )
                    {
                        invoiceType = (OPDBillKind)obj;
                    }
                }
                string patTypeCode = "";

                if ( chkPayType.Checked )
                {
                    patTypeCode = cboPatType.SelectedValue.ToString() ;
                }
                DataRow[] drs;
                DataTable tbList1 = tbList.Clone( );
                if ( invoiceType == OPDBillKind.门诊挂号发票 )
                {
                    string filter = "Hang_Flag=0";
                    if ( patTypeCode != "" )
                        filter = filter + " and MediType='"+patTypeCode +"'";
                    drs = tbList.Select( filter );
                    for ( int i = 0 ; i < drs.Length ; i++ )
                        tbList1.Rows.Add( drs[i].ItemArray );
                }
                else if ( invoiceType == OPDBillKind.门诊收费发票 )
                {
                    string filter = "Hang_Flag=1";
                    if ( patTypeCode != "" )
                        filter = filter + " and MediType='" + patTypeCode + "'";

                    drs = tbList.Select( filter );
                    for ( int i = 0 ; i < drs.Length ; i++ )
                        tbList1.Rows.Add( drs[i].ItemArray );
                }
                else
                {
                    string filter = "";
                    if ( patTypeCode != "" )
                        filter = filter + "MediType='" + patTypeCode + "'";

                    drs = tbList.Select( filter );
                    for ( int i = 0 ; i < drs.Length ; i++ )
                        tbList1.Rows.Add( drs[i].ItemArray );
                }
                tbList = tbList1;
                dgvList.DataSource = tbList1;

                object objValue;

                lblTotalNum.Text = tbList.Rows.Count.ToString( );
                objValue = tbList.Compute( "Sum(COST)" ,"");
                lblTotalCost.Text = Convert.ToDecimal( Convert.IsDBNull( objValue ) ? "0" : objValue ).ToString( );

                objValue = tbList.Compute( "count(InvoiceNo)" , "UnChargeDate is not null" );
                lblReturnNum.Text = Convert.ToInt32( Convert.IsDBNull(objValue)?"0":objValue ).ToString( );

                objValue = tbList.Compute( "Sum(UnChargeCost)" , "UnChargeDate is not null" );
                lblReturnCost.Text = Convert.ToDecimal( Convert.IsDBNull( objValue ) ? "0" : objValue ).ToString( );

                objValue = tbList.Compute( "Sum(Cost)" , "UnChargeDate is  null" );
                lblActCost.Text = Convert.ToDecimal( Convert.IsDBNull( objValue ) ? "0" : objValue ).ToString( );

                objValue = tbList.Compute( "Sum(Cash)" , "UnChargeDate is  null" );
                lblTotalCash.Text = Convert.ToDecimal( Convert.IsDBNull( objValue ) ? "0" : objValue ).ToString( );

                objValue = tbList.Compute( "Sum(POS)" , "UnChargeDate is  null" );
                lblTotalPOS.Text = Convert.ToDecimal( Convert.IsDBNull( objValue ) ? "0" : objValue ).ToString( );

                objValue = tbList.Compute( "Sum(Tally)" , "UnChargeDate is  null" );
                lblTotalTally.Text = Convert.ToDecimal( Convert.IsDBNull( objValue ) ? "0" : objValue ).ToString( );

                objValue = tbList.Compute( "Sum(Favor)" , "UnChargeDate is  null" );
                lblTotalFavor.Text = Convert.ToDecimal( Convert.IsDBNull( objValue ) ? "0" : objValue ).ToString( );

                objValue = tbList.Compute( "Sum(Self_Tally)" , "UnChargeDate is  null" );
                lblTotalSelfTally.Text = Convert.ToDecimal( Convert.IsDBNull( objValue ) ? "0" : objValue ).ToString( );
            }
            catch
            {
            }

        }

        private void dgvList_RowPostPaint( object sender , DataGridViewRowPostPaintEventArgs e )
        {
            

        }

        private void FrmInvoiceQuery_Load( object sender , EventArgs e )
        {
            lblActCost.Text = "";
            lblTotalCost.Text = "";
            lblTotalNum.Text = "";
            lblReturnCost.Text = "";
            lblReturnNum.Text = "";
            lblTotalCash.Text = "";
            lblTotalFavor.Text = "";
            lblTotalPOS.Text = "";
            lblTotalTally.Text = "";
            lblTotalSelfTally.Text = "";

            foreach ( object obj in Enum.GetValues( typeof( OPDBillKind ) ) )
            {
                cboInvoiceType.Items.Add( obj.ToString( ) );
            }
            cboInvoiceType.SelectedIndex = 0;

            dtpFrom.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 00:00:00" );
            dtpTo.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 23:59:59" );

            lblPrint.Visible = true;
            cboPatType.DisplayMember = "NAME";
            cboPatType.ValueMember = "CODE";
            cboPatType.DataSource = DataReader.PatientType;
            cboPatType.SelectedIndex = 0;
            cboPatType.Enabled = false;

            chkPayType.Checked = false;

            chkPayType.CheckedChanged += new EventHandler( chkPayType_CheckedChanged );
        }

        void chkPayType_CheckedChanged( object sender , EventArgs e )
        {
            if ( chkPayType.Checked )
                cboPatType.Enabled = true;
            else
                cboPatType.Enabled = false;
        }

        private void dgvList_CurrentCellChanged( object sender , EventArgs e )
        {
            if ( dgvList.Rows.Count == 0 )
                return;
            if ( dgvList.CurrentCell == null )
                return;

            //string invoiceNo = dgvList["InvoiceNo" , dgvList.CurrentCell.RowIndex].Value.ToString( );
            //Invoice invoice = new Invoice( invoiceNo , OPDBillKind.所有发票);
             
        }

        

        private void lblClose_LinkClicked( object sender , LinkLabelLinkClickedEventArgs e )
        {
            plInvoice.Tag = null;
            plInvoice.Visible = false;
        }

        

        private void dgvList_CellDoubleClick( object sender , DataGridViewCellEventArgs e )
        {
            string invoiceNo = dgvList["InvoiceNo" , dgvList.CurrentCell.RowIndex].Value.ToString( );
            int invoiceType = Convert.ToInt32( dgvList["HANG_FLAG" , dgvList.CurrentCell.RowIndex].Value );
            if ( invoiceType == 0 )
                return;

            Invoice invoice = new Invoice("", invoiceNo , OPDBillKind.门诊收费发票 );

            lblTotal.Text = invoice.TotalPay.ToString( );
            lblPayType.Text = invoice.PayType;
            lblCash.Text = invoice.CashPay.ToString( );
            lblTally.Text = invoice.VillagePay.ToString( );
            lblPos.Text = invoice.PosPay.ToString( );
            lblFavor.Text = invoice.FavorPay.ToString( );
            lblSelfTally.Text = invoice.SelfTally.ToString( );
            dgvInoviceItems.Rows.Clear( );
            for ( int i = 0 ; i < invoice.Items.Length ; i++ )
            {
                dgvInoviceItems.Rows.Add( );
                dgvInoviceItems["ItemName" , dgvInoviceItems.Rows.Count - 1].Value = invoice.Items[i].ItemName.Trim( );
                dgvInoviceItems["ItemCost" , dgvInoviceItems.Rows.Count - 1].Value = invoice.Items[i].Cost;
            }
            plInvoice.Tag = invoice;
            plInvoice.Visible = true;
        }

        private void lblPrint_LinkClicked( object sender , LinkLabelLinkClickedEventArgs e )
        {
            if ( plInvoice.Tag != null )
            {
                Invoice invoice = (Invoice)plInvoice.Tag;
                if ( MessageBox.Show( "确认要重打的发票的发票号与电脑号一致？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes )
                {
                    PrintController.PrintChargeInvoice( new Invoice[] { invoice } );
                }
            }
        }
    }
}
