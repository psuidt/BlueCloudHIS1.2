using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.MZ_BLL;
using HIS.MZ_BLL.Query;
using HIS.Interface.Structs;

namespace HIS_MZManager.Query
{
    /// <summary>
    /// 病人费用查询
    /// </summary>
    public partial class FrmPatientFeeQuery : BaseMainForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FormText"></param>
        public FrmPatientFeeQuery( string FormText)
        {
            InitializeComponent( );

            this.Text = FormText;
            this.FormTitle = FormText;
        }

        private void btnFind_Click( object sender , EventArgs e )
        {
            if ( !chkPatName.Checked && !chkInvoiceType.Checked && !chkVisitNo.Checked && !dtpFrom.Checked && !dtpTo.Checked )
            {
                MessageBox.Show( "至少需要指定一个查询条件！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                return;
            }
            string patientName = "";
            OPDBillKind invoiceType = OPDBillKind.所有发票;
            string invoiceNo = "";
            string visitNo = "";
            DateTime? beginDate = null;
            DateTime? endDate = null;

            #region 查询参数
            if ( chkPatName.Checked )
            {
                if ( txtPatName.Text.Trim( ) != "" )
                    patientName = txtPatName.Text.Trim();
                else
                {
                    MessageBox.Show( "指定的查询条件：病人姓名没有填写！" ,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtPatName.Focus( );
                    return;
                }
            }
            if ( chkInvoiceType.Checked )
            {
                foreach ( object obj in Enum.GetValues( typeof( OPDBillKind ) ) )
                {
                    if ( ( (OPDBillKind)obj ).ToString( ) == cboInvoiceType.Text )
                    {
                        invoiceType = (OPDBillKind)obj;
                        break;
                    }
                }
                if ( txtInvoiceNo.Text.Trim( ) != "" )
                    invoiceNo = txtInvoiceNo.Text.Trim( );
                else
                {
                    MessageBox.Show( "指定的查询条件：发票号没有填写！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    txtInvoiceNo.Focus( );
                    return;
                }
            }
            if ( chkVisitNo.Checked )
            {
                if ( txtVisitNo.Text.Trim( ) != "" )
                    visitNo = txtVisitNo.Text.Trim( );
                else
                {
                    MessageBox.Show( "指定的查询条件：门诊号没有填写！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    txtVisitNo.Focus( );
                    return;
                }
            }
            if ( dtpFrom.Checked )
                beginDate = Convert.ToDateTime(dtpFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00");
            if ( dtpTo.Checked )
                endDate = Convert.ToDateTime(dtpTo.Value.ToString("yyyy-MM-dd")+ " 23:59:59" );
            #endregion

            
            PatientQuery patientQuery = new PatientQuery( );
            List<BasePatient> lstPatient = patientQuery.GetPatient( invoiceNo , invoiceType , visitNo , patientName , beginDate , endDate );
            ShowPatientList( lstPatient );
        }

        private void ShowPatientList( List<BasePatient> lstPatient )
        {
            dgvPatList.Rows.Clear( );
            foreach ( BasePatient p in lstPatient )
            {
                OutPatient patient = (OutPatient)p;
                int row = dgvPatList.Rows.Add( );
                dgvPatList[COL_PATLISTID.Name , row].Value = patient.PatListID;
                dgvPatList[COL_VISITNO.Name , row].Value = patient.VisitNo;
                dgvPatList[COL_PATNAME.Name , row].Value = patient.PatientName;
                dgvPatList[COL_SEX.Name , row].Value = patient.Sex;
                dgvPatList[COL_AGE.Name , row].Value = patient.Age;
                dgvPatList[COL_PATTYPE.Name, row].Value = BaseDataController.GetName( BaseDataCatalog.病人类型列表, patient.MediType.Trim() );//PublicDataReader.GetPatientTypeNameByCode( patient.MediType.Trim());
                dgvPatList[COL_DOCTOR.Name, row].Value = BaseDataController.GetName( BaseDataCatalog.人员列表, Convert.ToInt32( patient.CureEmpCode == "" ? "0" : patient.CureEmpCode ) ); //PublicDataReader.GetEmployeeNameById( Convert.ToInt32( patient.CureEmpCode == "" ? "0" : patient.CureEmpCode ) );
                dgvPatList[COL_DEPT.Name, row].Value = BaseDataController.GetName(BaseDataCatalog.科室列表, Convert.ToInt32( patient.CureDeptCode == "" ? "0" : patient.CureDeptCode ) ); //PublicDataReader.GetDeptNameById( Convert.ToInt32( patient.CureDeptCode == "" ? "0" : patient.CureDeptCode ) );
                dgvPatList[COL_CURDATE.Name , row].Value = patient.CureDate;
                dgvPatList.Rows[row].Tag = patient;
            }
            dgvPatList.CurrentCell = null;
        }



        private void chkPatName_CheckedChanged( object sender , EventArgs e )
        {
            txtPatName.Enabled = chkPatName.Checked;
        }

        private void chkInvoiceType_CheckedChanged( object sender , EventArgs e )
        {
            cboInvoiceType.Enabled = chkInvoiceType.Checked;
            txtInvoiceNo.Enabled = chkInvoiceType.Checked;
        }

        private void chkVisitNo_CheckedChanged( object sender , EventArgs e )
        {
            txtVisitNo.Enabled = chkVisitNo.Checked;
        }

        private void FrmPatientFeeQuery_Load( object sender , EventArgs e )
        {
            foreach ( object obj in Enum.GetValues( typeof( OPDBillKind ) ) )
                cboInvoiceType.Items.Add( obj.ToString( ) );
            cboInvoiceType.SelectedIndex = 0;
        }

        private void dgvPatList_CurrentCellChanged( object sender , EventArgs e )
        {
            if ( dgvPatList.CurrentCell == null )
                return;

            int patlistId = Convert.ToInt32( dgvPatList[COL_PATLISTID.Name , dgvPatList.CurrentCell.RowIndex].Value );
            InvoiceQuery invoiceQuery = new InvoiceQuery( );
            List<Invoice> lstInvoice = invoiceQuery.GetInvoiceListByPatListId( patlistId );
            ShowInvoiceList( lstInvoice );
            dgvInvoiceItem.Rows.Clear( );
            dgvPresc.Rows.Clear( );
            dgvInvoiceList_CurrentCellChanged( null , null );
        }

        private void ShowInvoiceList( List<Invoice> lstInvoice )
        {
            dgvInvoiceList.Rows.Clear( );
            foreach ( Invoice invoice in lstInvoice )
            {
                int row = dgvInvoiceList.Rows.Add( );
                dgvInvoiceList[COL_INVOICENO.Name , row].Value = invoice.InvoiceNo;
                dgvInvoiceList[COL_TOTAL_FEE.Name , row].Value = invoice.TotalPay;
                dgvInvoiceList[COL_MONEY_FEE.Name , row].Value = invoice.CashPay;
                dgvInvoiceList[COL_POS_FEE.Name , row].Value = invoice.PosPay;
                dgvInvoiceList[COL_INSUR_FEE.Name , row].Value = invoice.VillagePay;
                dgvInvoiceList[COL_SELF_TALLY.Name , row].Value = invoice.SelfTally;
                dgvInvoiceList[COL_FAVOR_FEE.Name , row].Value = invoice.FavorPay;
                dgvInvoiceList[COL_CHARGEDATE.Name , row].Value = invoice.ChargeDate;
                dgvInvoiceList.Rows[row].Tag = invoice;
            }
        }

        private void dgvInvoiceList_CurrentCellChanged( object sender , EventArgs e )
        {
            if ( dgvInvoiceList.CurrentCell == null )
                return;
            Invoice invoice = (Invoice)dgvInvoiceList.Rows[dgvInvoiceList.CurrentCell.RowIndex].Tag;
            if ( invoice != null )
            {
                ShowInvoiceItems( invoice );

                ShowInvoicePrescriptions( invoice );
            }
        }

        private void ShowInvoicePrescriptions( Invoice invoice )
        {
            dgvPresc.Rows.Clear( );
            Prescription[] Prescriptions = invoice.Prescription;
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
                        dgvPresc["InvoiceNo" , row].Value = Prescriptions[i].TicketNum;
                        dgvPresc["PatName" , row].Value = Prescriptions[i].PatientName;
                        dgvPresc["VisitNo" , row].Value = Prescriptions[i].VisitNo;
                        dgvPresc[DoctorName.Name, row].Value = Prescriptions[i].PresDocCode.Trim() == "" ? "" : BaseDataController.GetName( BaseDataCatalog.人员列表, Convert.ToInt32( Prescriptions[i].PresDocCode ) );  //PublicDataReader.GetEmployeeNameById( Convert.ToInt32( Prescriptions[i].PresDocCode ) );
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
                        dgvPresc["RECORD_FLAG" , row].Value = "√";
                    else
                        dgvPresc["RECORD_FLAG" , row].Value = "";
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
                            dgvPresc["Drug_Flag" , row].Value = "√";
                        }
                        else
                        {
                            dgvPresc["Drug_Flag" , row].Value = "";
                        }
                    }
                    //颜色
                    for ( int r = 0 ; r < dgvPresc.Columns.Count ; r++ )
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
                    dgvPresc[m , dgvPresc.Rows.Count - 1].Style.ForeColor = Color.Red;
                    dgvPresc[m , dgvPresc.Rows.Count - 1].Style.BackColor = bkColor;
                    dgvPresc[m , dgvPresc.Rows.Count - 1].ReadOnly = true;
                }
            }
        }

        private void ShowInvoiceItems( Invoice invoice )
        {
            dgvInvoiceItem.Rows.Clear( );
            for ( int i = 0 ; i < invoice.Items.Length ; i++ )
            {
                int row = dgvInvoiceItem.Rows.Add( );
                dgvInvoiceItem[COL_MZFP_NAME.Name , row].Value = invoice.Items[i].ItemName;
                dgvInvoiceItem[COL_MZFP_FEE.Name , row].Value = invoice.Items[i].Cost;
            }
        }

        private void btnReset_Click( object sender , EventArgs e )
        {
            txtPatName.Text = "";
            txtInvoiceNo.Text = "";
            txtVisitNo.Text = "";
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvPatList.CurrentCell == null)
            {
                MessageBox.Show("请在病人查询结果中选折要打印的病人", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            bool printSubTotal = chkPrintSub.Checked;
            try
            {
                OutPatient patient = (OutPatient)dgvPatList.CurrentRow.Tag;

                if (chkPrintSingle.Checked)
                {
                    for (int i = 0; i < dgvInvoiceList.Rows.Count; i++)
                    {
                        Invoice invoice = (Invoice)dgvInvoiceList.Rows[i].Tag;
                        invoice.InvoiceNo = invoice.PerfChar + invoice.InvoiceNo;
                        PrintController.PrintOutPatientFeeList(patient, invoice, invoice.Prescription, printSubTotal);
                    }
                }
                else
                {
                    //合并发票
                    Invoice invoice = null;
                    List<Prescription> lstPrescription = null;
                    for (int i = 0; i < dgvInvoiceList.Rows.Count; i++)
                    {
                        Invoice invoice1 = (Invoice)dgvInvoiceList.Rows[i].Tag;
                        if (invoice1.Prescription[0].Record_Flag != 0)
                            continue;
                        if (invoice == null)
                        {
                            invoice = new Invoice();                            
                            invoice.InvoiceNo = invoice1.PerfChar + invoice1.InvoiceNo;
                            invoice.CashPay = invoice1.CashPay;
                            invoice.FavorPay = invoice1.FavorPay;
                            invoice.PosPay = invoice1.PosPay;
                            invoice.SelfTally = invoice1.SelfTally;
                            invoice.TotalPay = invoice1.TotalPay;
                            invoice.VillagePay = invoice1.VillagePay;
                            lstPrescription = invoice1.Prescription.ToList();

                            continue;
                        }
                        else
                        {
                            invoice.CashPay += invoice1.CashPay;
                            invoice.FavorPay += invoice1.FavorPay;
                            invoice.PosPay += invoice1.PosPay;
                            invoice.SelfTally += invoice1.SelfTally;
                            invoice.TotalPay += invoice1.TotalPay;
                            invoice.VillagePay += invoice1.VillagePay;
                            invoice.InvoiceNo = invoice.InvoiceNo + "  " + (invoice1.PerfChar + invoice1.InvoiceNo);
                            
                            for (int j = 0; j < invoice1.Prescription.Length; j++)
                                lstPrescription.Add(invoice1.Prescription[j]);
                        }
                    }
                    if (invoice == null)
                    {
                        MessageBox.Show("没有有效的费用可打印！", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    PrintController.PrintOutPatientFeeList(patient, invoice, lstPrescription.ToArray(), printSubTotal);
                    
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
