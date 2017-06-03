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
    public partial class FrmAllotInvoice : GWI.HIS.Windows.Controls.BaseForm
    {
        private int currentEmployeeId;

        public FrmAllotInvoice( int CurrentEmployeeId )
        {
            InitializeComponent();

            currentEmployeeId = CurrentEmployeeId;

        }

        private void FrmAllotInvoice_Load( object sender , EventArgs e )
        {
            
            cboChargetor.SetSelectionCardDataSource( DataReader.Employeies );
            cboInvoiceType.Items.Clear();
            foreach ( object obj in Enum.GetValues( typeof( OPDBillKind ) ) )
            {
                if ( obj.ToString() == OPDBillKind.所有发票.ToString() )
                    continue;
                cboInvoiceType.Items.Add( obj.ToString() );
            }

            txtKs.KeyPress += new KeyPressEventHandler( TextBox_KeyPress );
            txtJs.KeyPress += new KeyPressEventHandler( TextBox_KeyPress );
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( cboChargetor.Text.Trim() == "" || cboChargetor.MemberValue == null )
            {
                MessageBox.Show( "请指定发票领用人！","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                return;
            }

            OPDBillKind invoiceType = OPDBillKind.门诊收费发票;
            foreach ( object obj in Enum.GetValues( typeof( OPDBillKind ) ) )
            {
                if ( obj.ToString() == cboInvoiceType.Text )
                {
                    invoiceType = (OPDBillKind)obj;
                    break;
                }
            }

            int chargeUserId = Convert.ToInt32( cboChargetor.MemberValue );
            if ( chkCommonUser.Checked )
                chargeUserId = 0;

            try
            {
                int start = Convert.ToInt32( txtKs.Text );
                int end = Convert.ToInt32( txtJs.Text );
                string perfChar = txtPerfChar.Text.Trim( );
                if ( end < start )
                {
                    MessageBox.Show( "结束号不能大于开始号" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }

                if ( InvoiceManager.CheckInvoiceExists( invoiceType , start , end , perfChar ) )
                {
                    InvoiceManager.SetInvoiceRecord( invoiceType , chargeUserId , txtPerfChar.Text.Trim(), start , end , Convert.ToInt32( currentEmployeeId ) );
                    this.Close();
                }
            }
            catch ( Exception err )
            {

                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.Close();
        }

        private void chkCommonUser_CheckedChanged( object sender , EventArgs e )
        {
            cboChargetor.Enabled = chkCommonUser.Checked ? false : true;
        }

        private void TextBox_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( ( (int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 )  || (int)e.KeyChar == 190 || (int)e.KeyChar == 8 || (int)e.KeyChar == 27 )
            {
                e.Handled = false ;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
