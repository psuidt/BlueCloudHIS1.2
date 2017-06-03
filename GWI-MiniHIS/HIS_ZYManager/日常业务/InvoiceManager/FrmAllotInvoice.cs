using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS_ZYManager.InvoiceManager
{
    public partial class FrmAllotInvoice : GWI.HIS.Windows.Controls.BaseForm
    {
        private GWMHIS.BussinessLogicLayer.Classes.User user;

        public FrmAllotInvoice( GWMHIS.BussinessLogicLayer.Classes.User User )
        {
            InitializeComponent();

            user = User;

        }

        private void FrmAllotInvoice_Load( object sender , EventArgs e )
        {
            cboChargetor.DisplayField = "NAME";
            cboChargetor.ValueField = "EMPLOYEE_ID";
            cboChargetor.SearchKeyFiled = new string[] { "PY_CODE" , "WB_CODE" };
            cboChargetor.DataSource = HIS.ZY_BLL.InvoiceManager.InvoiceManager.GetEmployeeList();
            cboInvoiceType.Items.Clear();
            //foreach ( object obj in Enum.GetValues( typeof( HIS.MZ_BLL.OPDBillKind ) ) )
            //{
            //    if ( obj.ToString() == HIS.MZ_BLL.OPDBillKind.所有发票.ToString() )
            //        continue;
            //    cboInvoiceType.Items.Add( obj.ToString() );
            //}
            cboInvoiceType.Items.Add("住院发票");
            txtKs.KeyPress += new KeyPressEventHandler( TextBox_KeyPress );
            txtJs.KeyPress += new KeyPressEventHandler( TextBox_KeyPress );
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( cboChargetor.Text.Trim() == "" || cboChargetor.SelectedValue == null )
            {
                MessageBox.Show( "请指定发票领用人！","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                return;
            }

             
            int chargeUserId = Convert.ToInt32( cboChargetor.SelectedValue );
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

                if (HIS.ZY_BLL.InvoiceManager.InvoiceManager.CheckInvoiceExists( start , end , perfChar ) )
                {
                    HIS.ZY_BLL.InvoiceManager.InvoiceManager.SetInvoiceRecord( chargeUserId, txtPerfChar.Text.Trim(), start, end, Convert.ToInt32(user.EmployeeID));
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
