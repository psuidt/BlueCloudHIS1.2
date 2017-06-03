using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GWI.HIS.Windows.Controls;
using HIS_DJSFManager.类;


namespace HIS_DJSFManager.窗口
{
    public partial class FrmViewInvoice : BaseForm
    {
        private BaseAccountBook accountBook;
        
        private OPDBillKind kind;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccountBook"></param>
        /// <param name="Kind"></param>
        public FrmViewInvoice(BaseAccountBook AccountBook , OPDBillKind Kind)
        {
            InitializeComponent( );

            accountBook = AccountBook;

            kind = Kind;
            this.Text = this.Text + " --【" +kind.ToString( ) + "】";
        }

        private void FrmViewInvoice_Load( object sender , EventArgs e )
        {
            Invoice[] invoices = null;
            if ( accountBook is PrivyAccountBook )
            {
                if ( kind == OPDBillKind.门诊挂号发票 )
                    invoices = ( (PrivyAccountBook)accountBook ).RegisterInvoiceInfo.InvoiceList;
                else
                    invoices = ( (PrivyAccountBook)accountBook ).ChargeInvoiceInfo.InvoiceList;
            }
            //else
            //{
            //    List<Invoice> lstInvoice = new List<Invoice>( );
            //    CollectAccountBook collectBook = (CollectAccountBook)accountBook;
            //    if ( kind == OPDBillKind.门诊挂号发票 )
            //    {
            //        for ( int i = 0 ; i < collectBook.ChargeInvoiceInfo.Length ; i++ )
            //        {
            //            for ( int j = 0 ; j < collectBook.ChargeInvoiceInfo[i].InvoiceList.Length ; j++ )
            //            {
            //                lstInvoice.Add( collectBook.ChargeInvoiceInfo[i].InvoiceList[j] );
            //            }
            //        }
            //    }
            //    else
            //    {
            //        for ( int i = 0 ; i < collectBook.RegisterInvoiceInfo.Length ; i++ )
            //        {
            //            for ( int j = 0 ; j < collectBook.RegisterInvoiceInfo[i].InvoiceList.Length ; j++ )
            //            {
            //                lstInvoice.Add( collectBook.RegisterInvoiceInfo[i].InvoiceList[j] );
            //            }
            //        }
            //    }
            //    invoices = lstInvoice.ToArray( );
            //}

            if ( invoices != null )
            {
                decimal total_pay = 0;
                decimal cash_pay = 0;
                decimal pos_pay = 0;
                decimal village_pay = 0;
                decimal selfTally = 0;
                decimal favor_fee = 0;
                for ( int i = 0 ; i < invoices.Length ; i++ )
                {
                    int row = dgvList.Rows.Add( );
                    dgvList[InvoiceNo.Name , row].Value = invoices[i].InvoiceNo;
                    dgvList[MediType.Name , row].Value = invoices[i].PatientName;
                    dgvList[Total_Fee.Name , row].Value = invoices[i].TotalPay;
                    dgvList[Cash_Fee.Name , row].Value = invoices[i].CashPay;
                    dgvList[POS_Fee.Name , row].Value = invoices[i].PosPay;
                    dgvList[Insur_Fee.Name , row].Value = invoices[i].VillagePay;
                    dgvList[Self_Fee.Name , row].Value = invoices[i].SelfTally;
                    dgvList[Favor_Fee.Name , row].Value = invoices[i].FavorPay;
                    dgvList[Cost_Date.Name , row].Value = invoices[i].ChargeDate;
                    dgvList[Record_Flag.Name , row].Value = invoices[i].RecordFlag;

                    if ( invoices[i].RecordFlag == 1 )
                    {
                        dgvList.SetRowColor( row , Color.Red , Color.White );
                    }
                    if ( invoices[i].RecordFlag == 0 )
                    {
                        total_pay += invoices[i].TotalPay;
                        cash_pay += invoices[i].CashPay;
                        pos_pay += invoices[i].PosPay;
                        village_pay += invoices[i].VillagePay;
                        selfTally += invoices[i].SelfTally;
                        favor_fee += invoices[i].FavorPay;
                    }
                }
                dgvList.Rows.Add( );
                dgvList[InvoiceNo.Name , dgvList.Rows.Count - 1].Value = "合  计:";
                dgvList[Total_Fee.Name , dgvList.Rows.Count - 1].Value = total_pay;
                dgvList[Cash_Fee.Name , dgvList.Rows.Count - 1].Value = cash_pay;
                dgvList[POS_Fee.Name , dgvList.Rows.Count - 1].Value = pos_pay;
                dgvList[Insur_Fee.Name , dgvList.Rows.Count - 1].Value = village_pay;
                dgvList[Self_Fee.Name , dgvList.Rows.Count - 1].Value = selfTally;
                dgvList[Favor_Fee.Name , dgvList.Rows.Count - 1].Value = favor_fee;
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
    }
}
