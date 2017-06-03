using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.MZ_BLL;

namespace HIS_MZManager.Query
{
    public partial class FrmInvoiceQuery : GWI.HIS.Windows.Controls.BaseMainForm // GWMHIS.BussinessLogicLayer.Forms.BaseForm
    {
        private GWMHIS.BussinessLogicLayer.Classes.User currentUser;

       
        

        public FrmInvoiceQuery( string FormText, GWMHIS.BussinessLogicLayer.Classes.User CurrentUser )
        {
            InitializeComponent( );

            this.Text = FormText;

            currentUser = CurrentUser;
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
                    tbList = HIS.MZ_BLL.PublicDataReader.GetChargeInvoiceList( this.dtpFrom.Value , dtpTo.Value  );
                else
                    tbList = HIS.MZ_BLL.PublicDataReader.GetChargeInvoiceList( this.dtpFrom.Value , dtpTo.Value , Convert.ToInt32( currentUser.EmployeeID ));

                HIS.MZ_BLL.OPDBillKind invoiceType = HIS.MZ_BLL.OPDBillKind.所有发票;

                foreach ( object obj in Enum.GetValues( typeof( HIS.MZ_BLL.OPDBillKind ) ) )
                {
                    if ( obj.ToString( ) == cboInvoiceType.Text )
                    {
                        invoiceType = (HIS.MZ_BLL.OPDBillKind)obj;
                    }
                }
                string patTypeCode = "";

                if ( chkPayType.Checked )
                {
                    patTypeCode = cboPatType.SelectedValue.ToString() ;
                }
                DataRow[] drs;
                DataTable tbList1 = tbList.Clone( );
                if ( invoiceType == HIS.MZ_BLL.OPDBillKind.门诊挂号发票 )
                {
                    string filter = "Hang_Flag=0";
                    if ( patTypeCode != "" )
                        filter = filter + " and MediType='"+patTypeCode +"'";
                    drs = tbList.Select( filter );
                    for ( int i = 0 ; i < drs.Length ; i++ )
                        tbList1.Rows.Add( drs[i].ItemArray );
                }
                else if ( invoiceType == HIS.MZ_BLL.OPDBillKind.门诊收费发票 )
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
                if ( txtStartNo.Text.Trim( ) != "" )
                {
                    tbList.Rows.Clear( );
                    string filter = "";
                    if ( chkEndNo.Checked && txtEndNo.Text.Trim() != "" )
                    {
                        long invoiceNum = Convert.ToInt64( txtStartNo.Text );
                        long endNum = Convert.ToInt64( txtEndNo.Text );
                        if ( ( endNum - invoiceNum ) > 1000 )
                        {
                            if ( MessageBox.Show( "发票起止段查询范围过大，会消耗比较长的时间或导致程序无响应，是否继续？\r\n(建议值1000张以内)" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                            {
                                return;
                            }
                        }
                        while ( true )
                        {
                            if ( invoiceNum > endNum )
                            {
                                break;
                            }
                            else
                            {
                                filter = "InvoiceNo = '" + invoiceNum.ToString( ) + "'";
                                drs = tbList1.Select( filter );
                                if ( drs.Length > 0 )
                                {
                                    tbList.Rows.Add( drs[0].ItemArray );
                                }
                                invoiceNum++;
                            }
                        }
                    }
                    else
                    {
                        filter = "InvoiceNo = '" + txtStartNo.Text.Trim( ) + "'";
                        drs = tbList1.Select( filter );
                        for ( int i = 0 ; i < drs.Length ; i++ )
                        {
                            tbList.Rows.Add( drs[i].ItemArray );
                        }
                        //if ( drs.Length > 0 )
                        //{
                        //    tbList.Rows.Add( drs[0].ItemArray );
                        //}
                    }
                    tbList1 = tbList;
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
            txtEndNo.Enabled = false;

            foreach ( object obj in Enum.GetValues( typeof( HIS.MZ_BLL.OPDBillKind ) ) )
            {
                cboInvoiceType.Items.Add( obj.ToString( ) );
            }
            cboInvoiceType.SelectedIndex = 0;

            dtpFrom.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 00:00:00" );
            dtpTo.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 23:59:59" );

            //if ( currentUser.IsAdministrator )
            //{
            //    lblPrint.Visible = true;
            //}
            //else
            //{
            //    lblPrint.Visible = false;
            //}

            lblPrint.Visible = true;

            cboPatType.DisplayMember = "NAME";
            cboPatType.ValueMember = "PATTYPECODE";
            //cboPatType.DataSource = PublicDataReader.PatientTypeList;
            cboPatType.DataSource = BaseDataController.BaseDataSet[BaseDataCatalog.病人类型列表];
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
            //HIS.MZ_BLL.Invoice invoice = new HIS.MZ_BLL.Invoice( invoiceNo , HIS.MZ_BLL.OPDBillKind.所有发票);
             
        }

        

        private void lblClose_LinkClicked( object sender , LinkLabelLinkClickedEventArgs e )
        {
            plInvoice.Tag = null;
            plInvoice.Visible = false;
        }

        

        private void dgvList_CellDoubleClick( object sender , DataGridViewCellEventArgs e )
        {
            string invoiceNo = dgvList["InvoiceNo" , dgvList.CurrentCell.RowIndex].Value.ToString( );
            string perfChar = dgvList[PERFCHAR.Name , dgvList.CurrentCell.RowIndex].Value.ToString( );
            int invoiceType = Convert.ToInt32( dgvList["HANG_FLAG" , dgvList.CurrentCell.RowIndex].Value );
            if ( invoiceType == 0 )
                return;

            HIS.MZ_BLL.Invoice invoice = new HIS.MZ_BLL.Invoice( perfChar , invoiceNo , HIS.MZ_BLL.OPDBillKind.门诊收费发票 );

            lblTotal.Text = invoice.TotalPay.ToString( );
            lblPayType.Text = invoice.PayType;
            lblCash.Text = invoice.CashPay.ToString( );
            lblTally.Text = invoice.VillagePay.ToString( );
            lblPos.Text = invoice.PosPay.ToString( );
            lblFavor.Text = invoice.FavorPay.ToString( );
            lblSelfTally.Text = invoice.SelfTally.ToString( );
            dgvInoviceItems.Rows.Clear( );
             //2010-5-28 20100528.1.01 门诊票据查询
            if (invoice.Items.Length == 0)
            {
                return;
            }

            dgvInoviceItems.Rows.Add();
            dgvInoviceItems["ItemName", dgvInoviceItems.Rows.Count - 1].Value = invoice.Items[0].ItemName.Trim();
            dgvInoviceItems["ItemCost", dgvInoviceItems.Rows.Count - 1].Value = invoice.Items[0].Cost;
            for ( int i = 1 ; i < invoice.Items.Length ; i++ )
            {
                if (invoice.Items[i].ItemName.Trim() != invoice.Items[i - 1].ItemName.Trim())
                {
                    dgvInoviceItems.Rows.Add();
                    dgvInoviceItems["ItemName", dgvInoviceItems.Rows.Count - 1].Value = invoice.Items[i].ItemName.Trim();
                    dgvInoviceItems["ItemCost", dgvInoviceItems.Rows.Count - 1].Value = invoice.Items[i].Cost;
                }
               
            }
            plInvoice.Tag = invoice;
            plInvoice.Visible = true;
        }

        private void lblPrint_LinkClicked( object sender , LinkLabelLinkClickedEventArgs e )
        {
            if ( plInvoice.Tag != null )
            {
                HIS.MZ_BLL.Invoice invoice = (HIS.MZ_BLL.Invoice)plInvoice.Tag;
                if ( MessageBox.Show( "确认要重打的发票的发票号与电脑号一致？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes )
                {
                    PrintController.PrintChargeInvoice( new Invoice[] { invoice } );
                }
            }
        }

        private void chkEndNo_CheckedChanged( object sender , EventArgs e )
        {
            txtEndNo.Enabled = chkEndNo.Checked;
        }

        private void txtStartNo_TextChanged( object sender , EventArgs e )
        {
            if ( txtStartNo.Text.Trim( ) == "" )
                chkEndNo.Checked = false;
        }
    }
}
