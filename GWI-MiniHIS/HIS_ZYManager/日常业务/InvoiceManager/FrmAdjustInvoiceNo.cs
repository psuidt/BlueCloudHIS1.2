using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;

namespace HIS_ZYManager.InvoiceManager
{
    public partial class FrmAdjustInvoiceNo : BaseForm
    {
        private int operatorId;
        //private OPDBillKind invoiceType;
        private string perfCode = "";

        public FrmAdjustInvoiceNo(int OperatorId)
        {
            InitializeComponent( );
            operatorId = OperatorId;
            //invoiceType = InvoiceType;
          
        }

        private void FrmAdjustInvoiceNo_Load( object sender , EventArgs e )
        {
            
            lblCurrent.Text = HIS.ZY_BLL.InvoiceManager.InvoiceManager.GetBillNumber(operatorId , true , out perfCode );
            txtNewInvoiceNo.Text = lblCurrent.Text;
            txtNewInvoiceNo.Focus( );
            txtNewInvoiceNo.SelectAll( );
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( txtNewInvoiceNo.Text.Trim( ) == "" )
            {
                MessageBox.Show( "请输入要调整的发票号！" ,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            try
            {
                bool ret = HIS.ZY_BLL.InvoiceManager.InvoiceManager.AdjustInvoiceNo(operatorId , perfCode, txtNewInvoiceNo.Text );
                this.DialogResult = DialogResult.OK;
                this.Close( );
            }
          
            catch ( Exception ex )
            {
                //ErrorWriter.WriteLog( ex.Message );
                MessageBox.Show( "调整发票号发生错误！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }

        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close( );
        }

        
    }
}
