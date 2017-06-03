using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;

namespace HIS_MZManager.HJSF
{
    public partial class FrmPreviousInfo : BaseForm
    {

        public string PatientName
        {
            get
            {
                return lblPatName.Text;
            }
            set
            {
                lblPatName.Text = value;
            }
        }
        public string InvoicePics
        {
            get
            {
                return lblInvoiceCount.Text;
            }
            set
            {
                lblInvoiceCount.Text = value;
            }
        }
        public string TotalMoney
        {
            get
            {
                return lblPresTotalCost.Text;
            }
            set
            {
                lblPresTotalCost.Text = value;
            }
        }
        public string FavorMoney
        {
            get
            {
                return lblPerMoney.Text;
            }
            set
            {
                lblPerMoney.Text = value;
            }
        }
        public string InsurMoney
        {
            get
            {
                return lblTally.Text;
            }
            set
            {
                lblTally.Text = value;
            }
        }
        public string SelfPayMoney
        {
            get
            {
                return lblSelfPay.Text;
            }
            set
            {
                lblSelfPay.Text = value;
            }
        }
        public string SelfTollyMoney
        {
            get
            {
                return lblSelfTally.Text;
            }
            set
            {
                lblSelfTally.Text = value;
            }
        }
        public string PosMoney
        {
            get
            {
                return lblPOS.Text;
            }
            set
            {
                lblPOS.Text = value;
            }
        }
        public string ActiveGetMoney
        {
            get
            {
                return lblActPay.Text;
            }
            set
            {
                lblActPay.Text = value;
            }
        }
        public string ReturnMoney
        {
            get
            {
                return lblReturnMoney.Text;
            }
            set
            {
                lblReturnMoney.Text = value;
            }
        }

        public FrmPreviousInfo()
        {
            InitializeComponent( );
        }

        protected override void OnShown( EventArgs e )
        {
            SetLocation( );

            base.OnShown( e );
        }

        protected override void OnClosing( CancelEventArgs e )
        {
            e.Cancel = true;
            this.Hide( );
        }

        private void SetLocation()
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
        }

        private void ClearInfo()
        {
            lblPatName.Text = "";
            lblInvoiceCount.Text = "";
            lblPresTotalCost.Text = "";
            lblPerMoney.Text = "";
            lblTally.Text = "";
            lblSelfPay.Text = "";
            lblSelfTally.Text = "";
            lblPOS.Text = "";
            lblActPay.Text = "";
            lblReturnMoney.Text = "";
        }
    }
}
