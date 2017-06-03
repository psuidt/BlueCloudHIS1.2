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
    public partial class FrmPrescriptionQuery : GWI.HIS.Windows.Controls.BaseMainForm// GWMHIS.BussinessLogicLayer.Forms.BaseForm
    {
        //private GWMHIS.BussinessLogicLayer.Classes.User currentUser;
        public FrmPrescriptionQuery( string FormText/*, GWMHIS.BussinessLogicLayer.Classes.User CurrentUser*/ )
        {
            InitializeComponent( );
            this.Text = FormText;
            this.FormTitle = FormText;
            //currentUser = CurrentUser;
        }

        /// <summary>
        /// 显示处方
        /// </summary>
        /// <param name="Prescriptions"></param>
        private void ShowPrescriptions( Prescription[] Prescriptions )
        {
            dgvPresc.Rows.Clear( );
            for ( int i = 0 ; i < Prescriptions.Length ; i++ )
            {
                Color bkColor = Color.White;
                if ( i % 2 == 0 )
                    bkColor = Color.WhiteSmoke;
                decimal presSubTotal = 0;
                Color forceColor = Color.Blue;
                if ( Prescriptions[i].Record_Flag != 0 )
                    forceColor = Color.Red;

                for ( int j = 0 ; j < Prescriptions[i].PresDetails.Length ; j++ )
                {
                    dgvPresc.Rows.Add( );
                    int row = dgvPresc.Rows.Count - 1;

                    if ( j == 0 )
                    {
                        dgvPresc["NO" , row].Value = Convert.ToString( i + 1 );
                        dgvPresc["PresID" , row].Value = Prescriptions[i].PrescriptionID;
                        dgvPresc["InvoiceNo", row].Value = Prescriptions[i].TicketNum;
                        dgvPresc["PatName", row].Value = Prescriptions[i].PatientName;
                        dgvPresc["VisitNo" , row].Value = Prescriptions[i].VisitNo;
                    }
                    dgvPresc["Item_Name" , row].Value = Prescriptions[i].PresDetails[j].Itemname;
                    dgvPresc["Standard" , row].Value = Prescriptions[i].PresDetails[j].Standard;
                    dgvPresc["Price" , row].Value = Prescriptions[i].PresDetails[j].Sell_price;
                    dgvPresc["PACK_Unit" , row].Value = Prescriptions[i].PresDetails[j].Unit;
                    if ( Prescriptions[i].PresDetails[j].BigitemCode == "01" ||
                        Prescriptions[i].PresDetails[j].BigitemCode == "02" ||
                        Prescriptions[i].PresDetails[j].BigitemCode == "03" )
                    {
                        decimal baseNum = Prescriptions[i].PresDetails[j].Amount % Prescriptions[i].PresDetails[j].RelationNum;
                        decimal packNum = ( Prescriptions[i].PresDetails[j].Amount - baseNum ) / Prescriptions[i].PresDetails[j].RelationNum;

                        dgvPresc["PACK_NUM" , row].Value = packNum;
                        dgvPresc["BASE_NUM" , row].Value = baseNum;
                    }
                    else
                    {
                        dgvPresc["PACK_NUM" , row].Value = 0;
                        dgvPresc["BASE_NUM" , row].Value = Prescriptions[i].PresDetails[j].Amount;
                    }

                    dgvPresc["PresAmount" , row].Value = Prescriptions[i].PresDetails[j].PresAmount;
                    dgvPresc["TotalCost" , row].Value = Prescriptions[i].PresDetails[j].Tolal_Fee;
                    presSubTotal += Prescriptions[i].PresDetails[j].Tolal_Fee;
                    
                    //if ( Prescriptions[i].Record_Flag == 0 )
                    //{
                    if ( Prescriptions[i].Charge_Flag != 0 )
                        dgvPresc["RECORD_FLAG", row].Value = "√";
                    else
                        dgvPresc["RECORD_FLAG", row].Value = "";
                    //}
                    //else
                    //{
                    //    dgvPresc["RECORD_FLAG", row].Value = ""; //退费的用红字显示
                    //}
                    if ( Prescriptions[i].PresDetails[j].BigitemCode == "01" ||
                        Prescriptions[i].PresDetails[j].BigitemCode == "02" ||
                        Prescriptions[i].PresDetails[j].BigitemCode == "03" )
                    {
                        if ( Prescriptions[i].Drug_Flag == 1 )
                        {
                            dgvPresc["Drug_Flag", row].Value = "√";
                        }
                        else
                        {
                            dgvPresc["Drug_Flag" , row].Value = "";
                        }
                    }
                    //颜色
                    for ( int r = 0; r < dgvPresc.Columns.Count; r++ )
                    {
                        dgvPresc.Rows[row].Cells[r].Style.ForeColor = forceColor;
                        dgvPresc.Rows[row].Cells[r].Style.BackColor = bkColor;
                    }
                }
                //小计
                dgvPresc.Rows.Add( );
                dgvPresc["Standard" , dgvPresc.Rows.Count - 1].Value = "小    计:";
                dgvPresc["TotalCost" , dgvPresc.Rows.Count - 1].Value = Decimal.Round( presSubTotal , 1 );
                for ( int m = 0 ; m < dgvPresc.Columns.Count ; m++ )
                {
                    dgvPresc[m, dgvPresc.Rows.Count - 1].Style.ForeColor = forceColor;
                    dgvPresc[m, dgvPresc.Rows.Count - 1].Style.BackColor = bkColor;
                    dgvPresc[m , dgvPresc.Rows.Count - 1].ReadOnly = true;
                }
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnQuery_Click( object sender , EventArgs e )
        {
            TimeSpan span = dtpTo.Value - dtpFrom.Value;
            if ( ( span.Days + 1 ) > 7 )
            {
                MessageBox.Show( "时间最大范围不能超过7天", "", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                return;
            }
            try
            {
                OutPatient[] patients = null;
                string beginDate = dtpFrom.Value.ToString( "yyyy-MM-dd" ) + " 00:00:00";
                string endDate = dtpTo.Value.ToString( "yyyy-MM-dd" ) + " 23:59:59";
                string invoiceNo = txtInvoiceNo.Text.Trim();

                if ( txtPatient.Text.Trim( ) != "" )
                {
                    patients = OutPatient.GetPatient( "PatName<>'' AND PatName like '%" + txtPatient.Text.Trim( ) + "%'" );
                }
                else
                {
                    patients = OutPatient.GetPatientByPresDate(beginDate,endDate  );
                }
                if ( txtInvoiceNo.Text.Trim( ) != "" )
                {
                    OutPatient patient = new OutPatient( txtInvoiceNo.Text , OPDBillKind.门诊收费发票 );
                    patients = new OutPatient[] { patient };
                }

                List<Prescription> listPrescription = new List<Prescription>();
                for ( int i = 0; i < patients.Length; i++ )
                {
                    Prescription[] prescriptions = patients[i].GetPrescriptions( PresStatus.全部, true, beginDate, endDate, invoiceNo, 0 );
                    for ( int j = 0; j < prescriptions.Length; j++ )
                        prescriptions[j].PatientName = patients[i].PatientName;

                    listPrescription.AddRange( prescriptions );
                }
                ShowPrescriptions( listPrescription.ToArray() );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnPatient_Click( object sender , EventArgs e )
        {
            
        }

        private void txtPatient_TextChanged( object sender , EventArgs e )
        {
            
        }

        private void dgvPresc_DataError( object sender , DataGridViewDataErrorEventArgs e )
        {
            e.Cancel = true;
        }

        private void txtInvoiceNo_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
                btnQuery_Click( null , null );
        }

        private void txtPatient_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
                btnQuery_Click( null , null );
        }
        
    }
}
