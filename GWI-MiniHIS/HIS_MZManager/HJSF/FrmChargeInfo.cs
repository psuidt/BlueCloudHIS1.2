using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZManager.HJSF
{
    public partial class FrmChargeInfo : GWI.HIS.Windows.Controls.BaseForm
    {
        private decimal _ActPay;
        private decimal _ReturnMoney;

        public decimal ActPay
        {
            get
            {
                return _ActPay;
            }
        }
        public decimal ReturnMoney
        {
            get
            {
                return _ReturnMoney;
            }
        }

        private HIS.MZ_BLL.ChargeInfo returnChargeInfo;

        private bool cannotCancel;

        public HIS.MZ_BLL.ChargeInfo ReturnChargeInfo
        {
            get
            {
                return returnChargeInfo;
            }
        }

        private string format = "0.#0";

        public FrmChargeInfo(HIS.MZ_BLL.ChargeInfo chargeInfo)
        {
            InitializeComponent( );

            returnChargeInfo = chargeInfo;
        }

        public FrmChargeInfo( HIS.MZ_BLL.ChargeInfo chargeInfo ,bool CannotCancel)
        {
            InitializeComponent( );

            returnChargeInfo = chargeInfo;

            if ( CannotCancel )
            {
                btnCancel.Enabled = false;
                cannotCancel = true;
            }
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( Convert.ToDecimal( txtReturn.Text ) < 0 )
            {
                MessageBox.Show( "实收金额不足!","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                return;
            }
            if ( Convert.ToDecimal( txtActPosPay.Text ) > Convert.ToDecimal( lblNeedCharge.Text ) )
            {
                MessageBox.Show( "POS金额不能大于应收金额!" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            if ( Convert.ToDecimal( txtChargeUp.Text ) > Convert.ToDecimal( lblTotal.Text ) )
            {
                MessageBox.Show( "医保、农合记账金额不能大于总金额" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            if ( Convert.ToDecimal( txtSelfTally.Text ) > Convert.ToDecimal( lblTotal.Text ) )
            {
                MessageBox.Show( "单位个人记账金额不能大于总金额" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            returnChargeInfo.CashFee = Convert.ToDecimal( lblNeedCharge.Text ) - Convert.ToDecimal( txtActPosPay.Text );
            returnChargeInfo.PosFee = Convert.ToDecimal( txtActPosPay.Text );
            returnChargeInfo.VillageFee = Convert.ToDecimal( txtChargeUp.Text );
            returnChargeInfo.SelfFee = Convert.ToDecimal( lblNeedCharge.Text );
            returnChargeInfo.FavorFee = Convert.ToDecimal( lblPref.Text );
            returnChargeInfo.SelfTally = Convert.ToDecimal( txtSelfTally.Text );
            _ActPay = Convert.ToDecimal( txtActPay.Text );       //实收现金
            _ReturnMoney = Convert.ToDecimal( txtReturn.Text );  //需找零
            this.DialogResult = DialogResult.OK;
            this.Close( );
            
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close( );
        }

        private void FrmChargeInfo_Load( object sender , EventArgs e )
        {
            lblTotal.Text = ReturnChargeInfo.TotalFee.ToString( format );
            lblPref.Text = ReturnChargeInfo.FavorFee.ToString( format );
            //lblSelfPay.Text = ReturnChargeInfo.SelfFee.ToString( format );
            txtChargeUp.Text = ReturnChargeInfo.VillageFee.ToString( format );
            //应收
            decimal needCharge = ReturnChargeInfo.TotalFee - ReturnChargeInfo.VillageFee - ReturnChargeInfo.FavorFee;
            lblNeedCharge.Text = needCharge.ToString( format );

            //找零
            decimal actCashPay = Convert.ToDecimal(txtActPay.Text);
            decimal actPosPay = Convert.ToDecimal(txtActPosPay.Text);
            decimal returnMoney = actCashPay + actPosPay - needCharge;
            txtReturn.Text = returnMoney.ToString( format );

            txtActPay.TextChanged += new EventHandler( PayInput_TextChanged );
            txtActPosPay.TextChanged += new EventHandler( PayInput_TextChanged );
            txtChargeUp.TextChanged += new EventHandler( PayInput_TextChanged );
            txtSelfTally.TextChanged += new EventHandler( PayInput_TextChanged );
            if (HIS.MZ_BLL.OPDParamter.Parameters["001"].ToString() == "1")
            {
                txtActPosPay.Enabled = false;
            }
            else
            {
                txtActPosPay.Enabled = true;
            }
            if ( HIS.MZ_BLL.OPDParamter.Parameters["002"].ToString() == "1" )
            {
                txtChargeUp.Enabled = false;
            }
            else
            {
                txtChargeUp.Enabled = true;
            }
        }

        private void PayInput_TextChanged( object sender , EventArgs e )
        {
            try
            {
                if ( ( (Control)sender ).Name == txtActPosPay.Name
                    || ( (Control)sender ).Name == txtActPay.Name || ( (Control)sender ).Name == txtChargeUp.Name )
                {
                    if ( ( (TextBox)sender ).Text == "" )
                    {
                        ((TextBox)sender ).Text="0.00";
                        ( (TextBox)sender ).SelectAll( );
                    }
                }
                decimal totalCost = Convert.ToDecimal( lblTotal.Text );
                decimal prefCost = Convert.ToDecimal( lblPref.Text );
                decimal chargeUp = Convert.ToDecimal( txtChargeUp.Text );
                decimal needCharge = totalCost - prefCost - chargeUp; //个人自付 = 总金额 - 优惠 - 记账
                lblNeedCharge.Text = needCharge.ToString();
                decimal actCashPay = Convert.ToDecimal( txtActPay.Text );
                decimal actPosPay = Convert.ToDecimal( txtActPosPay.Text );
                decimal actSelfTally = Convert.ToDecimal( txtSelfTally.Text );
                decimal returnMoney = actCashPay + actPosPay + actSelfTally - needCharge;
                txtReturn.Text = returnMoney.ToString( format );
            }
            catch
            {
            }
        }

        private void FrmChargeInfo_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                btnOk_Click( null , null );
            }
            if ( (int)e.KeyChar == 27 && cannotCancel==false)
            {
                btnCancel_Click( null , null );
            }
        }

       

        private void txtMoenyInput_KeyPress( object sender , KeyPressEventArgs e )
        {
            TextBox txtInputBox = (TextBox)sender;

            if ( ( (int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 ) || (int)e.KeyChar == 8 || (int)e.KeyChar == 46 )
            {
                if ( (int)e.KeyChar == 46 )
                {
                    if ( txtInputBox.Text.IndexOf( "." ) > 0 )
                    {
                        e.Handled = true;
                    }
                }
                int dotIndex = txtInputBox.Text.IndexOf( "." );
                if ( dotIndex != -1 )
                {
                    string str = txtInputBox.Text.Substring( dotIndex + 1 );
                    if ( str.Length == 2 && (int)e.KeyChar != 8 && str != "00" )
                        e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
