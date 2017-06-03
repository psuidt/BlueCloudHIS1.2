using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.MZ_BLL;
using GWI.HIS.Windows.Controls;


namespace HIS_MZManager.Account
{
    public partial class FrmViewInvoice : BaseForm
    {
        private Invoice[] invoices;
        private bool isRefund;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccountBook"></param>
        /// <param name="Kind"></param>
        public FrmViewInvoice( Invoice[] Invoices ,bool IsRefund)
        {
            InitializeComponent( );

            invoices = Invoices;
            isRefund = IsRefund;

            if ( isRefund )
                label1.Visible = false;
        }

        private void FrmViewInvoice_Load( object sender , EventArgs e )
        {
            
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

                    if ( invoices[i].RecordFlag == 1 || invoices[i].RecordFlag == 2 )
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
                if ( !isRefund )
                {
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
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
    }
}
