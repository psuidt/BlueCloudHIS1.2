using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS_DJSFManager.窗口;

namespace HIS_DJSFManager.类
{
    public partial class FrmUnCharge : GWI.HIS.Windows.Controls.BaseForm
    {
        private const string subTotalString = "小   计：";

        private int _EmployeeID;

        private DataTable dtbChargeItems;

        private OutPatient currentPatient;

        private Invoice currentInvoice;

        private bool loadPresc = false;

        public OutPatient ReturnPatient;

        /// <summary>
        /// 是否有处方需要结算
        /// </summary>
        public bool HasPresNeedBalance;
        //add zenghao
        private List<PrescriptionDetail> lstRetYP;

        public FrmUnCharge(int EmployeeID )
        {
            InitializeComponent( );

            _EmployeeID = EmployeeID;
        }

        #region 处方显示处理
        /// <summary>
        /// 根据当前行获取处方的开始行和结束行,小计行
        /// </summary>
        /// <param name="CurrentRowInex">当前行</param>
        /// <param name="startRowInex">开始行的Index</param>
        /// <param name="endRowIndex">结束行的Index</param>
        /// <param name="subTotalRowIndex">小计行的Index，如果为-1,则表示当前处方没有小计行</param>
        private void GetPrescriptionStartRowAndEndRow( int CurrentRowInex , out int startRowInex , out int endRowIndex , out int subTotalRowIndex )
        {
            int currentRowIndex = CurrentRowInex;
            subTotalRowIndex = -1;
            if ( CurrentRowInex == -1 )
            {
                startRowInex = 0;
                endRowIndex = 0;
                return;
            }
            //如果是小计行
            if ( dgvPresc["NO2" , currentRowIndex].Tag != null
                && Convert.ToInt32( dgvPresc["NO2" , currentRowIndex].Tag ) == 1 )
            {
                subTotalRowIndex = currentRowIndex;
                CurrentRowInex = CurrentRowInex - 1;
            }

            currentRowIndex = CurrentRowInex;
            //查找开始行
            while ( true )
            {
                currentRowIndex--;
                if ( currentRowIndex <= 0 )
                {
                    startRowInex = 0;
                    break;
                }
                else
                {
                    if ( dgvPresc["NO2" , currentRowIndex].Tag != null
                        && Convert.ToInt32( dgvPresc["NO2" , currentRowIndex].Tag ) == 1 )
                    {
                        startRowInex = currentRowIndex + 1;
                        break;
                    }
                }
            }
            //查找结束
            currentRowIndex = CurrentRowInex;
            while ( true )
            {
                currentRowIndex++;
                if ( currentRowIndex == dgvPresc.Rows.Count )
                {
                    endRowIndex = currentRowIndex - 1;
                    break;
                }
                else
                {
                    if ( dgvPresc["NO2" , currentRowIndex].Tag != null
                        && Convert.ToInt32( dgvPresc["No2" , currentRowIndex].Tag ) == 1 )
                    {
                        endRowIndex = currentRowIndex - 1;
                        subTotalRowIndex = currentRowIndex;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 计算处方金额
        /// </summary>
        /// <returns></returns>
        private decimal CalcutePrescriptionCost( int currentRowIndex )
        {
            int start , end , subRow;
            GetPrescriptionStartRowAndEndRow( currentRowIndex , out start , out end , out subRow );
            if ( dgvPresc["NO1" , end].Tag != null && dgvPresc["NO1" , end].Tag.ToString( ) == "1" )
            {
                end = end - 1;
            }
            decimal subTotal = 0;
            for ( int i = start ; i <= end ; i++ )
            {
                if ( dgvPresc["TotalCost" , i].Value != null )
                {
                    subTotal = subTotal + Convert.ToDecimal( dgvPresc["TotalCost" , i].Value );
                }
            }
            return subTotal;
        }
        /// <summary>
        /// 写小计行内容
        /// </summary>
        /// <param name="subTotalRow"></param>
        private void WriteSubTotalRow( int subTotalRow )
        {
            decimal presTotal = CalcutePrescriptionCost( subTotalRow );

            for ( int i = 0 ; i < dgvPresc.Columns.Count ; i++ )
            {
                if ( dgvPresc.Columns[i].Visible )
                {
                    if ( ( dgvPresc.Columns[i].GetType( ) == typeof( DataGridViewTextBoxColumn ) )
                        || dgvPresc.Columns[i].GetType( ).IsSubclassOf( typeof( DataGridViewTextBoxColumn ) ) )
                    {
                        dgvPresc[i , subTotalRow].Value = "";
                    }
                }
            }
            dgvPresc["Exec_dept" , dgvPresc.Rows.Count - 1].Value = subTotalString;
            dgvPresc["TotalCost" , dgvPresc.Rows.Count - 1].Value = presTotal;
            dgvPresc["NO2" , dgvPresc.Rows.Count - 1].Tag = 1; /*注意在小计行的NO2列打标记为小计行*/
            dgvPresc.Rows[dgvPresc.Rows.Count - 1].Tag = 1;

            for ( int i = 0 ; i < dgvPresc.Columns.Count ; i++ )
            {
                dgvPresc[i , subTotalRow].Style.BackColor = Color.LightYellow;
                dgvPresc[i , subTotalRow].Style.Font = new Font( "宋体" , (float)11 , FontStyle.Bold );
                dgvPresc[i , subTotalRow].Style.ForeColor = Color.Red;
                if ( dgvPresc[i , subTotalRow].IsInEditMode )
                    dgvPresc.CancelEdit( );
                dgvPresc[i , subTotalRow].ReadOnly = true;
            }


        }
        /// <summary>
        /// 显示处方
        /// </summary>
        /// <param name="Prescriptions"></param>
        private void ShowPrescriptions( Prescription[] Prescriptions ,List<PrescriptionDetail> ReturnDrugDetailList)
        {
            dgvPresc.Rows.Clear( );
            loadPresc = true;
            for ( int i = 0 ; i < Prescriptions.Length ; i++ )
            {
                for ( int j = 0 ; j < Prescriptions[i].PresDetails.Length ; j++ )
                {
                    dgvPresc.Rows.Add( );
                    int row = dgvPresc.Rows.Count - 1;

                    dgvPresc["PrescID" , row].Value = Prescriptions[i].PrescriptionID;
                    dgvPresc["DetailID" , row].Value = Prescriptions[i].PresDetails[j].DetailId;
                    dgvPresc["NO1" , row].Value = Convert.ToString( i + 1 );
                    if ( j == 0 )
                        dgvPresc["NO2" , row].Value = Convert.ToString( i + 1 );
                    dgvPresc["Item_Name" , row].Value = Prescriptions[i].PresDetails[j].Itemname;
                    dgvPresc["Standard" , row].Value = Prescriptions[i].PresDetails[j].Standard;
                    dgvPresc["Price" , row].Value = Prescriptions[i].PresDetails[j].Sell_price;
                    dgvPresc["Item_Unit" , row].Value = Prescriptions[i].PresDetails[j].Unit;//大单位
                    dgvPresc["PACK_Unit" , row].Value = Prescriptions[i].PresDetails[j].Unit;//大单位
                    string base_unit = "";
                    DataRow[] drBaseItem = dtbChargeItems.Select( "isdrug = 1 and item_id=" + Prescriptions[i].PresDetails[j].ItemId.ToString( ) );
                    if ( drBaseItem.Length > 0 )
                        base_unit = drBaseItem[0]["base_unit"].ToString( ).Trim( );
                    else
                        base_unit = Prescriptions[i].PresDetails[j].Unit;

                    dgvPresc["Base_Unit" , row].Value = base_unit;//小单位
                    if ( Prescriptions[i].PresDetails[j].BigitemCode == "01" || Prescriptions[i].PresDetails[j].BigitemCode == "02" || Prescriptions[i].PresDetails[j].BigitemCode == "03" )
                    {
                        decimal baseNum = 0;
                        decimal packNum = 0;
                        GetPackNumAndBaseNum( Prescriptions[i].PresDetails[j].Amount , Prescriptions[i].PresDetails[j].RelationNum ,out packNum , out baseNum );
                        decimal retBaseNum = 0;
                        decimal retPackNum = 0;
                        //GetPackNumAndBaseNum( Prescriptions[i].PresDetails[j].DetailId , Prescriptions[i].PresDetails[j].ItemId , ReturnDrugDetailList ,out retPackNum , out retBaseNum );

                        dgvPresc["PACK_NUM" , row].Value = packNum;
                        dgvPresc["ReturnPackNum" , row].Value = retPackNum;

                        dgvPresc["BASE_NUM" , row].Value = baseNum;
                        dgvPresc["ReturnBaseNum" , row].Value = retBaseNum;
                        //add zenghao
                        if (retPackNum > 0 || retBaseNum > 0)
                        {
                            this.btnAll.Enabled = false;
                        }
                    }
                    else
                    {
                        dgvPresc["PACK_NUM" , row].Value = 0;
                        dgvPresc["ReturnPackNum" , row].Value = 0;
                        dgvPresc["BASE_NUM" , row].Value = Prescriptions[i].PresDetails[j].Amount;
                        dgvPresc["ReturnBaseNum" , row].Value = 0;
                    }

                    dgvPresc["PresAmount" , row].Value = Prescriptions[i].PresDetails[j].PresAmount;
                    dgvPresc["EXEC_DEPT" , row].Value = DataReader.GetDeptNameById( Convert.ToInt32(Prescriptions[i].ExecDeptCode) );
                    dgvPresc["EXEC_DEPT" , row].Tag = Prescriptions[i].ExecDeptCode;
                    dgvPresc["TotalCost" , row].Value = Prescriptions[i].PresDetails[j].Tolal_Fee;
                    dgvPresc["Item_ID" , row].Value = Prescriptions[i].PresDetails[j].ItemId;
                    dgvPresc["STATITEM_CODE" , row].Value = Prescriptions[i].PresDetails[j].BigitemCode;
                    dgvPresc["Complex_Id" , row].Value = Prescriptions[i].PresDetails[j].ComplexId;
                    dgvPresc["HJXS" , row].Value = Prescriptions[i].PresDetails[j].RelationNum;
                    dgvPresc["PrescDoctor" , row].Value = Prescriptions[i].PresDocCode;
                    dgvPresc["PrescDept" , row].Value = Prescriptions[i].PresDeptCode;
                    dgvPresc["Selected" , row].Value = (short)1;
                    dgvPresc["Modified" , row].Value = 0;
                    dgvPresc["DRUG_FLAG" , row].Value = Prescriptions[i].Drug_Flag;
                    
                    //颜色
                    for ( int r = 0 ; r < dgvPresc.Columns.Count ; r++ )
                    {
                        dgvPresc.Rows[row].Cells[r].Style.ForeColor = Color.Blue;
                    }
                    dgvPresc_CellEndEdit(this, new DataGridViewCellEventArgs(dgvPresc.Columns["ReturnBaseNum"].Index,row));
                }
                dgvPresc.Rows.Add( );
                WriteSubTotalRow( dgvPresc.Rows.Count - 1 );
            }
            if ( dgvPresc.Rows.Count > 0 )
                dgvPresc.CurrentCell = dgvPresc["BASE_NUM" , dgvPresc.Rows.Count - 1];

            loadPresc = false;
        }

        public void GetPackNumAndBaseNum(int detailId,int drug_id,List<PrescriptionDetail> lstReturn,
                                                    out decimal PackNum,out decimal BaseNum)
        {
            PackNum = 0;
            BaseNum = 0;
            foreach ( PrescriptionDetail detail in lstReturn )
            {
                if ( detail.DetailId == detailId && detail.ItemId == drug_id )
                {
                    //BaseNum = detail.Amount % detail.RelationNum;
                    //PackNum = ( detail.Amount - BaseNum ) / detail.RelationNum;
                    GetPackNumAndBaseNum( detail.Amount , detail.RelationNum , out PackNum , out BaseNum );
                    return;
                }
            }
        }
        public void GetPackNumAndBaseNum( decimal Amount , decimal RelationNum , out decimal PackNum , out decimal BaseNum )
        {
            BaseNum = Amount % RelationNum;
            PackNum = ( Amount - BaseNum ) / RelationNum;
        }

        /// <summary>
        /// 获取处方张数
        /// </summary>
        /// <returns></returns>
        private int GetPrescriptionNumber()
        {
            int number = 0;
            for ( int i = 0 ; i < dgvPresc.Rows.Count ; i++ )
            {
                if ( dgvPresc["NO2" , i].Tag != null && Convert.ToInt32( dgvPresc["NO2" , i].Tag ) == 1 )
                {
                    number = number + 1;
                }
            }
            return number;
        }
        /// <summary>
        /// 得到录入退费数量后的新处方
        /// </summary>
        /// <returns></returns>
        private Prescription[] GetPrescriptionRemanentFromGrid( bool allPrescription )
        {
            bool noreturnValue = true; //没有退数量

            int prescCount = 0;

            prescCount = GetPrescriptionNumber( );

            int currentRow = 0;

            Prescription[] prescriptions = new Prescription[prescCount];

            #region 得到处方，如果是没有选择的处方
            int start , end , subRow;//定义处方的开始行，结束行和小计行
            int presIndex = 0;
            for ( presIndex = 0 ; presIndex < prescCount ; presIndex++ )
            {
                prescriptions[presIndex] = new Prescription( );
                //处方头
                prescriptions[presIndex].PatientID = currentPatient.PatID;
                prescriptions[presIndex].RegisterID = currentPatient.PatListID;
                prescriptions[presIndex].PresCostCode = _EmployeeID.ToString( );
                prescriptions[presIndex].PresDeptCode = currentPatient.CureDeptCode;
                prescriptions[presIndex].PresDocCode = currentPatient.CureEmpCode;
                prescriptions[presIndex].Record_Flag = 0;
                prescriptions[presIndex].Charge_Flag = 0;
                prescriptions[presIndex].Drug_Flag = 0;
                prescriptions[presIndex].Total_Fee = 0;
                prescriptions[presIndex].PresDate = DateTime.Now;

                GetPrescriptionStartRowAndEndRow( currentRow , out start , out end , out subRow );
                if ( !allPrescription )
                {
                    if ( Convert.ToInt32( dgvPresc["Selected" , start].Value ) == 0 )
                    {
                        prescriptions[presIndex].PresDetails = null;
                        currentRow = subRow + 1;
                        continue;
                    }
                }
                prescriptions[presIndex].PresDetails = new PrescriptionDetail[end - start + 1];
                int detailIndex = 0;
                for ( int i = start ; i <= end ; i++ )
                {
                    if ( dgvPresc["Selected" , start].Value == null || Convert.ToBoolean( dgvPresc["Selected" , start].Value ) == false )
                    {
                        prescriptions[presIndex].PresDetails = null;
                        break;
                    }
                    int drug_flag = Convert.ToInt32( dgvPresc["DRUG_FLAG" , i].Value );
                    prescriptions[presIndex].Drug_Flag = drug_flag;//***发药标志

                    prescriptions[presIndex].PrescriptionID = Convert.ToInt32( dgvPresc["PrescID" , i].Value );
                    prescriptions[presIndex].ExecDeptCode = dgvPresc["EXEC_DEPT" , i].Tag.ToString( );//处方头记录执行科室
                    #region prescription.PrescType
                    switch ( dgvPresc["STATITEM_CODE" , i].Value.ToString( ).Trim( ) )
                    {
                        case "01":
                            prescriptions[presIndex].PrescType = "1";
                            break;
                        case "02":
                            prescriptions[presIndex].PrescType = "2";
                            break;
                        case "03":
                            prescriptions[presIndex].PrescType = "3";
                            break;
                        default:
                            prescriptions[presIndex].PrescType = "-1";
                            break;
                    }
                    #endregion
                    prescriptions[presIndex].PresDetails[detailIndex].PresctionId = prescriptions[presIndex].PrescriptionID;

                    int packNumOld = Convert.ToInt32( dgvPresc["PACK_NUM" , i].Value );
                    int baseNumOld = Convert.ToInt32( dgvPresc["BASE_NUM" , i].Value );
                    int packNumRet = Convert.ToInt32( dgvPresc["ReturnPackNum" , i].Value );
                    int baseNumRet = Convert.ToInt32( dgvPresc["ReturnBaseNum" , i].Value );
                    if ( packNumRet > 0 || baseNumRet > 0 )
                    {
                        noreturnValue = false;
                    }
                    int packNum = packNumOld - packNumRet; //现 = 原 - 退
                    int baseNum = baseNumOld - baseNumRet;
                    decimal relationNum = Convert.ToDecimal( dgvPresc["HJXS" , i].Value );
                    int amountNum = Convert.ToInt32( dgvPresc["PresAmount" , i].Value );
                    decimal sumNum = Convert.ToDecimal( packNum * relationNum + baseNum );
                    prescriptions[presIndex].PresDetails[detailIndex].Amount = sumNum;
                    prescriptions[presIndex].PresDetails[detailIndex].BigitemCode = dgvPresc["STATITEM_CODE" , i].Value.ToString( );
                    prescriptions[presIndex].PresDetails[detailIndex].Buy_price = Convert.ToDecimal( dgvPresc["Price" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].ComplexId = Convert.ToInt32( dgvPresc["Complex_Id" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].DetailId = Convert.ToInt32( dgvPresc["DetailID" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].ItemId = Convert.ToInt32( dgvPresc["Item_ID" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].Itemname = dgvPresc["Item_Name" , i].Value.ToString( );
                    #region prescription.PresDetails[detailIndex].ItemType
                    switch ( dgvPresc["STATITEM_CODE" , i].Value.ToString( ).Trim( ) )
                    {
                        case "01":
                            prescriptions[presIndex].PresDetails[detailIndex].ItemType = "01";
                            break;
                        case "02":
                            prescriptions[presIndex].PresDetails[detailIndex].ItemType = "02";
                            break;
                        case "03":
                            prescriptions[presIndex].PresDetails[detailIndex].ItemType = "03";
                            break;
                        default:
                            prescriptions[presIndex].PresDetails[detailIndex].ItemType = "00";
                            break;
                    }
                    #endregion
                    prescriptions[presIndex].PresDetails[detailIndex].Order_Flag = detailIndex + 1;
                    prescriptions[presIndex].PresDetails[detailIndex].PresAmount = Convert.ToInt32( dgvPresc["PresAmount" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].RelationNum = Convert.ToDecimal( dgvPresc["HJXS" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].Sell_price = Convert.ToDecimal( dgvPresc["Price" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].Standard = dgvPresc["Standard" , i].Value.ToString( );
                    prescriptions[presIndex].PresDetails[detailIndex].Tolal_Fee = Convert.ToDecimal( dgvPresc["TotalCost" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].Unit = dgvPresc["Pack_Unit" , i].Value.ToString( );
                    if ( Convert.ToInt16( dgvPresc["Modified" , i].Value ) == 1 )
                    {
                        prescriptions[presIndex].PresDetails[detailIndex].Modified = true;
                        prescriptions[presIndex].Modified = true;
                    }
                    else
                    {
                        prescriptions[presIndex].PresDetails[detailIndex].Modified = false;
                    }
                    prescriptions[presIndex].Total_Fee += prescriptions[presIndex].PresDetails[detailIndex].Tolal_Fee;
                    detailIndex++;
                }

                currentRow = subRow + 1;
            }
            #endregion
            if ( noreturnValue )
                return null;
            else
                return prescriptions;
        }
        #endregion
        /// <summary>
        /// 退费处理
        /// </summary>
        private void RefundmentProcess()
        {
            if ( _EmployeeID != Convert.ToInt32( currentInvoice.ChargeUserId ) )
            {
                throw new Exception( "该发票不是您收费，需收费员【"+currentInvoice.ChargeUser+"】才能退费！" );
            }
            //得到新的处方
            Prescription[] remanentPrescriptions = GetPrescriptionRemanentFromGrid( true );
            if ( remanentPrescriptions == null )
            {
                throw new Exception( "至少需要指定一条需要退费项目的数量！" );
            }
            //整理处方，除去0数量和没有明细的处方
            List<Prescription> lstPrescription = new List<Prescription>( );
            for ( int i = 0 ; i < remanentPrescriptions.Length ; i++ )
            {
                remanentPrescriptions[i].PrescriptionID = 0;
                List<PrescriptionDetail> lstDetail = new List<PrescriptionDetail>( );
                for ( int j = 0 ; j < remanentPrescriptions[i].PresDetails.Length ; j++ )
                {
                    remanentPrescriptions[i].PresDetails[j].DetailId = 0;
                    if ( remanentPrescriptions[i].PresDetails[j].Tolal_Fee != 0 )
                        lstDetail.Add( remanentPrescriptions[i].PresDetails[j] );
                }
                remanentPrescriptions[i].Modified = true;
                if ( lstDetail.Count > 0 )
                {
                    remanentPrescriptions[i].PresDetails = lstDetail.ToArray( );
                    lstPrescription.Add( remanentPrescriptions[i] );
                }
            }
            remanentPrescriptions = lstPrescription.ToArray( );
            if ( remanentPrescriptions.Length == 0 )
                remanentPrescriptions = null;

            if ( remanentPrescriptions != null )
            {
                
            }

            ChargeControl chargeController = new ChargeControl( currentPatient , _EmployeeID );
            try
            {
                decimal newcost = 0;
                decimal newmoneypay=0;
                decimal newpos=0;
                decimal newfoverpay=0;
                decimal newtally=0;
                decimal invoiceCount = 0;
                if ( chargeController.Refundment( currentInvoice , remanentPrescriptions ) )
                {
                    if ( remanentPrescriptions != null )
                    {
                        if ( chargeController.SavePrescription( remanentPrescriptions ) )
                        {
                            if ( MessageBox.Show( "还有需要重新收费的处方，是否由系统自动收费？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                            {
                                MessageBox.Show( "用户已取消操作,需要重新收费的处方还未收费，请转到收费窗口继续收费！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                                ReturnPatient = currentPatient;
                                HasPresNeedBalance = true;
                                return;
                            }
                            if ( MessageBox.Show( "需要重新打印发票收据，请确认发票是否已经准备就绪！" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                            {
                                MessageBox.Show( "用户已取消操作,需要重新收费的处方还未收费，请转到收费窗口继续收费！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                                ReturnPatient = currentPatient;
                                HasPresNeedBalance = true;
                                return;
                            }

                            ChargeInfo[] chargeInfos = chargeController.Budget( remanentPrescriptions );
                            #region 合计结算信息并显示给用户
                            //累计结算信息
                            ChargeInfo totalChargeInfo = new ChargeInfo( );
                            for ( int i = 0 ; i < chargeInfos.Length ; i++ )
                            {
                                totalChargeInfo.TotalFee += chargeInfos[i].TotalFee;
                                totalChargeInfo.FavorFee += chargeInfos[i].FavorFee;
                                totalChargeInfo.SelfFee += chargeInfos[i].SelfFee;
                                totalChargeInfo.VillageFee += chargeInfos[i].VillageFee;
                            }

                            //向用户展示结算信息
                            FrmChargeInfo frmChargeInfo = new FrmChargeInfo( totalChargeInfo , true );
                            frmChargeInfo.ShowDialog( );

                            chargeController.SetChargeInfoPay( ref chargeInfos , frmChargeInfo.ReturnChargeInfo.VillageFee ,
                                                                                frmChargeInfo.ReturnChargeInfo.PosFee ,
                                                                                frmChargeInfo.ReturnChargeInfo.CashFee,frmChargeInfo.ReturnChargeInfo.SelfTally );

                            #endregion
                            Invoice[] invoices;
                            chargeController.Charge( chargeInfos , remanentPrescriptions , out invoices );

                            PrintController.PrintChargeInvoice( invoices );
                            invoiceCount = invoices.Length;
                            for ( int i = 0 ; i < invoices.Length ; i++ )
                            {
                                newcost += invoices[i].TotalPay;
                                newmoneypay += invoices[i].CashPay;
                                newpos += invoices[i].PosPay;
                                newfoverpay += invoices[i].FavorPay;
                                newtally += invoices[i].VillagePay;
                            }
                        }
                    }

                    decimal returncost = currentInvoice.TotalPay - newcost;
                    decimal returnmoneypay = currentInvoice.CashPay - newmoneypay;
                    decimal returnpos = currentInvoice.PosPay - newpos;
                    decimal returnfoverpay = currentInvoice.FavorPay - newfoverpay;
                    decimal returntally = currentInvoice.VillagePay - newtally;
                    MessageBox.Show( "本次操作完成!\r\n需要退病人金额：" + returncost + "元,其中：" +
                                                                            "\r\n退 现 金：" + returnmoneypay + "元" +
                                                                            "\r\n退 POS  ：" + returnpos + "元" +
                                                                            "\r\n退 优 惠：" + returnfoverpay + "元" +
                                                                            "\r\n退 记 账：" + returntally + "元" +
                                                                            "\r\n\r\n新打发票：" + invoiceCount + "张" +
                                                                            "\r\n总 金 额：" + newcost + "元" ,
                                                                             "退费成功" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                }
            }
            catch ( Exception err )
            {
                MessageBox.Show( "退费失败！\r\n可能的原因;+\r\n" + err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
            }
        }

        private void btnOK_Click( object sender , EventArgs e )
        {
            if ( txtInvoiceNo.Text.Trim( ) == "" )
            {
                MessageBox.Show( "请输入要退费的发票号" , "" , MessageBoxButtons.OK , MessageBoxIcon.Exclamation );
                return;
            }

            for (int i = 0; i < dgvPresc.Rows.Count; i++)
            {
                if (dgvPresc.Rows[i].Tag != null && dgvPresc.Rows[i].Tag.ToString() == "1")
                    continue;
                if (dgvPresc["STATITEM_CODE", i].Value.ToString() == "01" ||
                    dgvPresc["STATITEM_CODE", i].Value.ToString() == "02" ||
                    dgvPresc["STATITEM_CODE", i].Value.ToString() == "03")
                {
                    if (dgvPresc["DRUG_FLAG", i].Value.ToString() == "1")
                    {
                        if ((dgvPresc["ReturnPackNum", i].Value != null && Convert.ToInt32(dgvPresc["ReturnPackNum", i].Value) > 0) ||
                            (dgvPresc["ReturnBaseNum", i].Value != null && Convert.ToInt32(dgvPresc["ReturnBaseNum", i].Value) > 0))
                        {
                            if (lstRetYP.Count == 0)
                            {
                                MessageBox.Show("【" + dgvPresc["Item_Name", i].Value + "】已发药，请先退药", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }

            try
            {
                RefundmentProcess( );

            }
            
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close( );
        }

        private void txtInvoiceNo_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                if ( txtInvoiceNo.Text.Trim( ) == "" )
                {
                    MessageBox.Show( "请输入要退费的发票号" , "" , MessageBoxButtons.OK , MessageBoxIcon.Exclamation );
                    return;
                }
                else
                {
                    //add zenghao
                    this.btnAll.Enabled = true;
                    dgvPresc.Focus( );
                    
                }

            }
            
        }

        private void FrmUnCharge_Load( object sender , EventArgs e )
        {
            
            txtInvoiceNo.MaxLength = 12;//Convert.ToInt32( OPDParamter.Parameters["005"] );
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Left = 0;

            dtbChargeItems = DataReader.GetShowCardItems(  );

            DataTable tbPerfChar = DataReader.Get_Invoice_PerfChar( );
            for ( int i = 0 ; i < tbPerfChar.Rows.Count ; i++ )
                txtPerfChar.Items.Add( tbPerfChar.Rows[i]["PerfChar"].ToString( ).Trim( ) );
        }

        private void FrmUnCharge_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 27 )
            {
                this.Close();
            }
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close( );
        }

        private void dgvPresc_CellEndEdit( object sender , DataGridViewCellEventArgs e )
        {
            int rowIndex = dgvPresc.CurrentCell.RowIndex;
            int start , end , subRow;
            GetPrescriptionStartRowAndEndRow( e.RowIndex , out  start , out end , out subRow );
            if ( e.ColumnIndex == dgvPresc.Columns["ReturnPackNum"].Index || e.ColumnIndex == dgvPresc.Columns["ReturnBaseNum"].Index
                    || e.ColumnIndex == dgvPresc.Columns["PresAmount"].Index )
            {
                if ( dgvPresc["ReturnPackNum" , rowIndex].Value == null || dgvPresc["ReturnPackNum" , rowIndex].Value.ToString( ) == "" )
                    dgvPresc["ReturnPackNum" , rowIndex].Value = 0;
                if ( dgvPresc["ReturnBaseNum" , rowIndex].Value == null || dgvPresc["ReturnBaseNum" , rowIndex].Value.ToString( ) == "" )
                    dgvPresc["ReturnBaseNum" , rowIndex].Value = 0;
            }
            #region ...
            //退包装数列
            if ( loadPresc == false )
            {
                if ( e.ColumnIndex == dgvPresc.Columns["ReturnPackNum"].Index )
                {
                    int oldPackNum = Convert.ToInt32( dgvPresc["PACK_NUM" , e.RowIndex].Value );
                    int newPackNum = Convert.ToInt32( dgvPresc["ReturnPackNum" , e.RowIndex].Value );

                    if ( newPackNum > oldPackNum )
                    {
                        MessageBox.Show( "输入的退包装数不能大于原包装数" );
                        dgvPresc["ReturnPackNum" , e.RowIndex].Value = 0;
                    }

                }
                //退基本数列
                if ( e.ColumnIndex == dgvPresc.Columns["ReturnBaseNum"].Index )
                {
                    int oldBaseNum = Convert.ToInt32( dgvPresc["BASE_NUM" , e.RowIndex].Value );
                    int newBaseNum = Convert.ToInt32( dgvPresc["ReturnBaseNum" , e.RowIndex].Value );
                    if ( newBaseNum > oldBaseNum )
                    {
                        MessageBox.Show( "输入的退基本数不能大于原包装数" );
                        dgvPresc["ReturnBaseNum" , e.RowIndex].Value = 0;
                    }
                }
            }
            #endregion
            
            try
            {
                //if ( dgvPresc.CurrentCell.ColumnIndex == dgvPresc.Columns["ReturnPackNum"].Index || dgvPresc.CurrentCell.ColumnIndex == dgvPresc.Columns["ReturnBaseNum"].Index
                //    || dgvPresc.CurrentCell.ColumnIndex == dgvPresc.Columns["PresAmount"].Index )
                if ( e.ColumnIndex == dgvPresc.Columns["ReturnPackNum"].Index || e.ColumnIndex == dgvPresc.Columns["ReturnBaseNum"].Index
                    || e.ColumnIndex == dgvPresc.Columns["PresAmount"].Index )
                {
                    if ( dgvPresc["ReturnPackNum" , rowIndex].Value == null || dgvPresc["ReturnPackNum" , rowIndex].Value.ToString( ) == "" )
                        dgvPresc["ReturnPackNum" , rowIndex].Value = 0;
                    if ( dgvPresc["ReturnBaseNum" , rowIndex].Value == null || dgvPresc["ReturnBaseNum" , rowIndex].Value.ToString( ) == "" )
                        dgvPresc["ReturnBaseNum" , rowIndex].Value = 0;
                    

                    decimal packnumOld = dgvPresc["PACK_NUM" , rowIndex].Value == null ? 0 : Convert.ToDecimal( dgvPresc["PACK_NUM" , rowIndex].Value );
                    decimal basenumOld = dgvPresc["BASE_NUM" , rowIndex].Value == null ? 0 : Convert.ToDecimal( dgvPresc["BASE_NUM" , rowIndex].Value );
                    decimal packnumRet = dgvPresc["ReturnPackNum" , rowIndex].Value == null ? 0 : Convert.ToDecimal( dgvPresc["ReturnPackNum" , rowIndex].Value );
                    decimal basenumRet = dgvPresc["ReturnBaseNum" , rowIndex].Value == null ? 0 : Convert.ToDecimal( dgvPresc["ReturnBaseNum" , rowIndex].Value );


                    decimal packnum = packnumOld - packnumRet;
                    decimal basenum = basenumOld - basenumRet;
                    decimal presAmount = dgvPresc["PresAmount" , rowIndex].Value == null ? 1 : Convert.ToDecimal( dgvPresc["PresAmount" , rowIndex].Value );
                    //计算本张处方金额
                    decimal presTotal = 0;
                    for ( int index = start ; index <= end ; index++ )
                    {
                        dgvPresc["PresAmount" , index].Value = presAmount;

                        packnumOld = dgvPresc["PACK_NUM" , index].Value == null ? 0 : Convert.ToDecimal( dgvPresc["PACK_NUM" , index].Value );
                        basenumOld = dgvPresc["BASE_NUM" , index].Value == null ? 0 : Convert.ToDecimal( dgvPresc["BASE_NUM" , index].Value );
                        packnumRet = dgvPresc["ReturnPackNum" , index].Value == null ? 0 : Convert.ToDecimal( dgvPresc["ReturnPackNum" , index].Value );
                        basenumRet = dgvPresc["ReturnBaseNum" , index].Value == null ? 0 : Convert.ToDecimal( dgvPresc["ReturnBaseNum" , index].Value );

                        packnum = packnumOld - packnumRet;
                        basenum = basenumOld - basenumRet;

                        decimal relationNum = dgvPresc["HJXS" , index].Value == null ? 0 : Convert.ToDecimal( dgvPresc["HJXS" , index].Value );
                        decimal price = dgvPresc["PRICE" , index].Value == null ? 0 : Convert.ToDecimal( dgvPresc["PRICE" , index].Value );
                        decimal total = 0;
                        if ( relationNum != 0 )
                            total = Math.Round( ( packnum * price + ( basenum * price / relationNum ) ) * presAmount , 4 );

                        dgvPresc["TotalCost" , index].Value = total;
                        presTotal += Convert.ToDecimal( dgvPresc["TotalCost" , index].Value );

                    }
                    //更新小计行数
                    if ( subRow > 0 )
                        dgvPresc["TotalCost" , subRow].Value = presTotal;
                    //将本行修改标识置为1
                    dgvPresc["Modified" , rowIndex].Value = 1;
                }
            }
            catch
            {
            }
        }

        private void dgvPresc_CurrentCellChanged( object sender , EventArgs e )
        {
            if ( dgvPresc.CurrentCell == null )
                return;
            if ( dgvPresc.Rows[dgvPresc.CurrentCell.RowIndex].Tag != null &&
                dgvPresc.Rows[dgvPresc.CurrentCell.RowIndex].Tag.ToString( ) == "1" )
            {
                return;
            }
            
            int row = dgvPresc.CurrentCell.RowIndex;

            if ( dgvPresc["ITEM_ID" , row].Value == null )
                return;

            string stat_item_code = dgvPresc["STATITEM_CODE" , row].Value.ToString( );
            int drug_flag = Convert.ToInt32( dgvPresc["DRUG_FLAG" , row].Value);

            if ( stat_item_code == "01" || stat_item_code == "02" || stat_item_code == "03" )
            {
                if ( drug_flag == 1 )
                {
                    //发了药不能修改退数量，必须通过药品接口获得数量
                    dgvPresc.Columns["ReturnPackNum"].ReadOnly = true;
                    dgvPresc.Columns["ReturnBaseNum"].ReadOnly = true;
                }
                else
                {
                    //没发药可以修改数量
                    dgvPresc.Columns["ReturnPackNum"].ReadOnly = false;
                    dgvPresc.Columns["ReturnBaseNum"].ReadOnly = false;
                }
            }
            else
            {
                dgvPresc.Columns["ReturnPackNum"].ReadOnly = false;
                dgvPresc.Columns["ReturnBaseNum"].ReadOnly = false;
            }

        }

        private void txtInvoiceNo_Leave( object sender , EventArgs e )
        {
            if ( txtInvoiceNo.Text.Trim( ) == "" )
            {
                return;
            }
            try
            {
                currentPatient = new OutPatient( txtInvoiceNo.Text , OPDBillKind.门诊收费发票 );

                txtPatientName.Text = currentPatient.PatientName;
                lblFeeType.Text = DataReader.GetPatientTypeNameByCode( currentPatient.MediType );

                currentInvoice = new Invoice( txtPerfChar.Text.Trim(), txtInvoiceNo.Text , OPDBillKind.门诊收费发票 );
                if ( currentInvoice.RecordFlag != 0 )
                {
                    MessageBox.Show( "该发票已经退费，请确认输入的发票号是否正确！" );
                    txtInvoiceNo.Focus( );
                    return;
                }
                lstRetYP = null;//DataReader.GetDrugReturnValueList( currentInvoice.InvoiceNo );

                ShowPrescriptions( currentInvoice.Prescription , lstRetYP );

                lblTotal.Text = currentInvoice.TotalPay.ToString( "0.00" );
                lblCash.Text = currentInvoice.CashPay.ToString( "0.00" );
                lblPOS.Text = currentInvoice.PosPay.ToString( "0.00" );
                lblChargeUp.Text = currentInvoice.VillagePay.ToString( "0.00" );
                lblFover.Text = currentInvoice.FavorPay.ToString( "0.00" );
                lblSelfTally.Text = currentInvoice.SelfTally.ToString( "0.00" );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtInvoiceNo.Focus( );
                txtInvoiceNo.Text = "";
                txtPatientName.Text = "";
                lblFeeType.Text = "";
                dgvPresc.Rows.Clear( );
                lblCash.Text = "0.00";
                lblChargeUp.Text = "0.00";
                lblFover.Text = "0.00";
                lblPOS.Text = "0.00";
                lblTotal.Text = "0.00";
            }
        }
    

        private void btnAll_Click( object sender , EventArgs e )
        {
            for ( int i = 0 ; i < dgvPresc.Rows.Count ; i++ )
            {
                dgvPresc["TotalCost" , i].Value = 0.000M;
                if ( dgvPresc.Rows[i].Tag != null && dgvPresc.Rows[i].Tag.ToString( ) == "1" )
                {
                    continue;
                }
                dgvPresc["ReturnPackNum" , i].Value = dgvPresc["PACK_NUM" , i].Value;
                dgvPresc["ReturnBaseNum" , i].Value = dgvPresc["BASE_NUM" , i].Value;

            }
        }

    }
}
