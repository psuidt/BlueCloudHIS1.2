using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.MZ_BLL;
using System.Collections;
using HIS.Interface;
using HIS.Interface.Structs;

namespace HIS_MZManager.Query
{
    public partial class FrmPrescriptionQuery : GWI.HIS.Windows.Controls.BaseMainForm// GWMHIS.BussinessLogicLayer.Forms.BaseForm
    {
        private GWMHIS.BussinessLogicLayer.Classes.User currentUser;
        public FrmPrescriptionQuery( string FormText, GWMHIS.BussinessLogicLayer.Classes.User CurrentUser )
        {
            InitializeComponent( );
            this.Text = FormText;
            this.FormTitle = FormText;
            currentUser = CurrentUser;
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
                    dgvPresc["PresID" , row].Value = Prescriptions[i].PrescriptionID;
                    if ( j == 0 )
                    {
                        dgvPresc["NO" , row].Value = Convert.ToString( i + 1 );
                        //dgvPresc["PresID" , row].Value = Prescriptions[i].PrescriptionID;
                        dgvPresc["InvoiceNo", row].Value = Prescriptions[i].TicketNum;
                        dgvPresc["PatName", row].Value = Prescriptions[i].PatientName;
                        dgvPresc["VisitNo" , row].Value = Prescriptions[i].VisitNo;
                        //dgvPresc[DoctorName.Name , row].Value = Prescriptions[i].PresDocCode.Trim( ) == "" ? "" : PublicDataReader.GetEmployeeNameById( Convert.ToInt32( Prescriptions[i].PresDocCode ) );
                        dgvPresc[DoctorName.Name, row].Value = Prescriptions[i].PresDocCode.Trim() == "" ? "" : BaseDataController.GetName(BaseDataCatalog.人员列表, Convert.ToInt32( Prescriptions[i].PresDocCode ) );
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
                Hashtable htBigItem;
                decimal roundMoney;
                //presSubTotal = BaseDataController.CalculatePrescriptionTotalFee( Prescriptions[i] , out htBigItem , out roundMoney );
                List<IPresDetail> lstDetail = new List<IPresDetail>();
                for ( int detailIndex = 0 ; detailIndex < Prescriptions[i].PresDetails.Length ; detailIndex++ )
                    lstDetail.Add( Prescriptions[i].PresDetails[detailIndex] );



                presSubTotal = ( new PrescMoneyCalculate() ).GetPrescriptionTotalMoney( lstDetail, out htBigItem, out roundMoney );

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
            if ( ( span.Days + 1 ) > 7 && txtInvoiceNo.Text.Trim() =="" && txtPatient.Text.Trim() =="" )
            {
                MessageBox.Show( "没有指定病人姓名或者发票号的情况下，时间最大范围不能超过7天", "", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                return;
            }
            try
            {
                string invoiceNo = txtInvoiceNo.Text.Trim();

                DataTable tbPres = PublicDataReader.Get_Prescriptions( txtPatient.Text , txtInvoiceNo.Text , dtpFrom.Value , dtpTo.Value );

                Hashtable htPrescription = new Hashtable( );

                for ( int masterCount = 0 ; masterCount < tbPres.Rows.Count ; masterCount++ )
                {
                    //===========修改日期：2010-03-03 王志=============================
                    //=========================Begin===================================
                    //读取的医生站处方，在预算取消后，会形成垃圾数据，增加过滤条件，使
                    //这部分数据不显示出来
                    int chargFlag = Convert.ToInt32( tbPres.Rows[masterCount]["Charge_Flag"] );
                    int docPresId = Convert.ToInt32( tbPres.Rows[masterCount]["DocPresId"] );
                    if ( chargFlag == 0 && docPresId != 0 )
                        continue;
                    //=========================End======================================

                    int presMasterId = Convert.ToInt32( tbPres.Rows[masterCount]["PresMasterID"] );
                    if ( htPrescription.ContainsKey( presMasterId ) )
                        continue;

                    Prescription prescription = new Prescription( );
                    #region 读取处方头
                    prescription.Charge_Flag = Convert.ToInt32( tbPres.Rows[masterCount]["Charge_Flag"] );
                    prescription.Drug_Flag = Convert.ToInt32( tbPres.Rows[masterCount]["Drug_Flag"] );
                    prescription.PrescriptionID = Convert.ToInt32( tbPres.Rows[masterCount]["PresMasterID"]);
                    prescription.PresDocCode = tbPres.Rows[masterCount]["PresDocCode"].ToString().Trim();
                    prescription.Record_Flag = Convert.ToInt32( tbPres.Rows[masterCount]["Record_Flag"]);
                    prescription.TicketNum = tbPres.Rows[masterCount]["TicketNum"].ToString();
                    prescription.Total_Fee = Convert.ToDecimal( tbPres.Rows[masterCount]["Pres_Total_Fee"] );
                    prescription.VisitNo = tbPres.Rows[masterCount]["visitno"].ToString( ).Trim( );
                    prescription.PatientName = tbPres.Rows[masterCount]["patname"].ToString( ).Trim( );
                    #endregion
                    DataRow[] drs = tbPres.Select( "presmasterid=" + prescription.PrescriptionID , "order_flag asc" );
                    PrescriptionDetail[] details = new PrescriptionDetail[drs.Length];
                    for ( int orderCount = 0 ; orderCount < drs.Length ; orderCount++ )
                    {
                        #region 明细
                        details[orderCount] = new PrescriptionDetail();
                        details[orderCount].Amount = Convert.ToDecimal( drs[orderCount]["Amount"] );
                        details[orderCount].Itemname = drs[orderCount]["ItemName"].ToString().Trim();
                        details[orderCount].Order_Flag = Convert.ToInt32(drs[orderCount]["Order_Flag"]);
                        details[orderCount].PresAmount = Convert.ToInt32( drs[orderCount]["PresAmount"] );
                        details[orderCount].RelationNum = Convert.ToDecimal( drs[orderCount]["RelationNum"] );
                        details[orderCount].Sell_price = Convert.ToDecimal( drs[orderCount]["Sell_Price"] );
                        details[orderCount].Standard = drs[orderCount]["Standard"].ToString( ).Trim( );
                        details[orderCount].Tolal_Fee = Convert.ToDecimal( drs[orderCount]["Order_Total_Fee"] );
                        details[orderCount].Unit = drs[orderCount]["Unit"].ToString( ).Trim( );
                        details[orderCount].Drug_Flag = Convert.ToInt32( drs[orderCount]["Drug_Flag"] );
                        details[orderCount].BigitemCode = drs[orderCount]["Bigitemcode"].ToString( ).Trim( );
                        #endregion
                    }
                    prescription.PresDetails = details;
                    htPrescription.Add( presMasterId , prescription );
                }

                Prescription[] prescriptions = new Prescription[htPrescription.Count];
                int index = 0;
                foreach ( object obj in htPrescription )
                {
                    prescriptions[index] = (Prescription)( (DictionaryEntry)obj ).Value;
                    index++;
                }


                ShowPrescriptions( prescriptions );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }


        private void btnPatient_Click( object sender , EventArgs e )
        {
            FrmPatientSelect fSelect = new FrmPatientSelect( "" );
            if ( fSelect.ShowDialog( ) == DialogResult.OK )
            {
                txtPatient.Text = fSelect.SelectedPatient.PatientName;
                txtPatient.Tag = fSelect.SelectedPatient;
            }
        }

        private void txtPatient_TextChanged( object sender , EventArgs e )
        {
            if ( txtPatient.Text == "" )
            {
                txtPatient.Tag = null;
            }
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

        private void btnCopy_Click( object sender , EventArgs e )
        {
            if ( dgvPresc.CurrentCell == null )
                return;
            if ( dgvPresc.Rows.Count == 0 )
                return;
            if ( MessageBox.Show( "确定要复制当前指定的处方吗？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                return;

            int presmasterId = Convert.ToInt32( dgvPresc[PresID.Name , dgvPresc.CurrentCell.RowIndex].Value );
            PrescriptionController presController = new PrescriptionController( );
            try
            {
                presController.CopyPrescription( presmasterId );
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }

        }
        
    }
}
