using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using HIS.Model;
using HIS.BLL;
using HIS.MSAccess;

namespace HIS_DJSFManager.类
{
    /// <summary>
    /// 普通病人结算对象
    /// </summary>
    public class GeneralCharge : BaseCharge
    {
        /// <summary>
        /// 小数位数
        /// </summary>
        protected int digits = 1;

        /// <summary>
        /// 门诊结算对象，该对象实现一张处方一次结算的功能
        /// </summary>
        /// <param name="Patient">要结算的病人对象</param>
        /// <param name="OperatorId">操作员</param>
        public GeneralCharge( OutPatient Patient , int OperatorId , ChargeType _ChargeType )
            : base( Patient, OperatorId ,_ChargeType)
        {
        }
        /// <summary>
        /// 通过大项目代码获取门诊发票项目
        /// </summary>
        /// <param name="StatItemCode"></param>
        /// <returns></returns>
        protected InvoiceItem GetInvoiceByStatCode( string StatItemCode )
        {
            DataRow[] drs = DataReader.StatItemList.Select( "code='" + StatItemCode + "'" );
            InvoiceItem invoiceItem = new InvoiceItem( );
            if ( drs.Length == 0 )
            {
                throw new Exception( "大项目对应的发票项目不存在！" );
            }
            else
            {
                invoiceItem.ItemCode = drs[0]["MZFP_CODE"].ToString( ).Trim( );
                invoiceItem.ItemName = drs[0]["MZFP_NAME"].ToString( ).Trim( );
            }
            return invoiceItem;
        }
        /// <summary>
        /// 预算
        /// </summary>
        /// <param name="prescriptions">要预算的处方</param>
        /// <returns>预算信息,供正式结算用</returns>
        public override ChargeInfo[] Budget( Prescription[] prescriptions )
        {
                        
            ChargeInfo[] chargeInfos = new ChargeInfo[prescriptions.Length];
            try
            {
                MSAccessDb.BeginTrans( );
                chargeInfos = _budget( prescriptions );
                MSAccessDb.CommitTrans( );
            }
            catch ( Exception err )
            {
                MSAccessDb.RollbackTrans( );
                throw new Exception( "预结算发生错误！" );
            }
            return chargeInfos;
            
        }
        /// <summary>
        /// 正式结算
        /// </summary>
        /// <param name="BudgetaryChargeInfos">预算信息</param>
        /// <param name="prescriptions">要结算的处方，该处方对象经过预算方法处理</param>
        /// <returns>true:结算成功，false：结算失败</returns>
        public override bool Charge( ChargeInfo[] BudgetaryChargeInfos , Prescription[] prescriptions , out BaseInvoice[] ChargeInvoicies )
        {
            MSAccessDb.BeginTrans( );
            try
            {
                _charge( BudgetaryChargeInfos , prescriptions , out ChargeInvoicies );
                MSAccessDb.CommitTrans( );
                return true;
            }
            catch ( Exception err )
            {
                MSAccessDb.RollbackTrans( );
                throw new Exception( "正式结算发生错误！");
            }
        }
        /// <summary>
        /// 取消预结算
        /// </summary>
        /// <returns></returns>
        /// <remarks>取消预算后不会再做正式结算，并且删除掉预算信息</remarks>
        public override bool AbortBudget()
        {
            
            return true;
        }
        /// <summary>
        /// 退费
        /// </summary>
        /// <param name="invoice">要退费的发票对象</param>
        /// <returns></returns>
        public override bool Refundment( Invoice invoice , Prescription[] ReblancePrescriptions )
        {
            try
            {
                MSAccessDb.BeginTrans();

                _refundment( invoice , ReblancePrescriptions );

                MSAccessDb.CommitTrans( );
                return true;
            }
            catch(Exception err)
            {
                MSAccessDb.RollbackTrans( );
                //ErrorWriter.WriteLog( err.Message );
                throw err;
            }


        }

        /// <summary>
        /// 得到打折金额
        /// </summary>
        /// <param name="patTypeCode"></param>
        /// <param name="allCost"></param>
        /// <param name="invoice"></param>
        /// <returns></returns>
        protected decimal GetFavorCost( string patTypeCode , ChargeInfo chargeInfo , Prescription[] Prescriptions )
        {
            //HIS.DAL.Public_DAL pub_dal = new HIS.DAL.Public_DAL( );
            //pub_dal._OleDB = oleDb;
            //List<HIS.DAL.Public_DAL.faoverAllData> invoiceItems = new List<HIS.DAL.Public_DAL.faoverAllData>( );
            //for ( int i = 0 ; i < chargeInfo.Items.Length ; i++ )
            //{
            //    HIS.DAL.Public_DAL.faoverAllData data = new HIS.DAL.Public_DAL.faoverAllData( );
            //    data.Code = chargeInfo.Items[i].ItemCode;
            //    data.Totalfee = chargeInfo.Items[i].Cost;
            //    invoiceItems.Add( data );
            //}
            //List<HIS.DAL.Public_DAL.faoverAllData> details = new List<HIS.DAL.Public_DAL.faoverAllData>( );
            //for ( int i = 0 ; i < Prescriptions.Length ; i++ )
            //{
            //    for ( int j = 0 ; j < Prescriptions[i].PresDetails.Length ; j++ )
            //    {
            //        HIS.DAL.Public_DAL.faoverAllData data = new HIS.DAL.Public_DAL.faoverAllData( );
            //        data.Code = Prescriptions[i].PresDetails[j].ItemId.ToString( );
            //        data.Totalfee = Prescriptions[i].PresDetails[j].Tolal_Fee;
            //        if ( Prescriptions[i].PresDetails[j].BigitemCode == "01" || Prescriptions[i].PresDetails[j].BigitemCode == "02" || Prescriptions[i].PresDetails[j].BigitemCode == "03" )
            //        {
            //            data.Type = 2;
            //        }
            //        else
            //        {
            //            if ( Prescriptions[i].PresDetails[j].ComplexId == 0 )
            //                data.Type = 0;
            //            else
            //                data.Type = 1;
            //        }
            //        details.Add( data );
            //    }
            //}
            //return pub_dal.GetfaoverAll_Fee( 1 , patTypeCode , chargeInfo.TotalFee , invoiceItems , details );

            return 0;
        }
        /// <summary>
        /// 得到打折金额
        /// </summary>
        /// <param name="patTypeCode"></param>
        /// <param name="allCost"></param>
        /// <param name="invoice"></param>
        /// <returns></returns>
        protected decimal GetFavorCost( string patTypeCode , ChargeInfo chargeInfo , Prescription prescription )
        {
            Prescription[] prescripions = new Prescription[1];
            prescripions[0] = prescription;

            return GetFavorCost( Patient.MediType , chargeInfo , prescripions );
        }

        /// <summary>
        /// 按统计大项目合并单张处方并回写参数对象中的处方总金额和舍入金额
        /// </summary>
        /// <param name="prescription">需要合并的处方，方法调用后总金额和舍入金额将被重写</param>
        /// <returns></returns>
        protected List<Item> MergePrescriptionByStatItemCode(ref Prescription prescription)
        {
            Hashtable htStatItemOfSinglePresc = new Hashtable( );//单张处方的大项目
            decimal singlePrescTotalCost = 0; //单张处方总金额
            #region 按大项目先合并处方明细
            for ( int j = 0 ; j < prescription.PresDetails.Length ; j++ )
            {
                string bigitemCode = prescription.PresDetails[j].BigitemCode.Trim( );
                if ( htStatItemOfSinglePresc.ContainsKey( bigitemCode ) )
                {
                    decimal cost = Convert.ToDecimal( htStatItemOfSinglePresc[bigitemCode] );
                    cost = cost + prescription.PresDetails[j].Tolal_Fee;
                    htStatItemOfSinglePresc[bigitemCode] = cost;
                }
                else
                {
                    htStatItemOfSinglePresc.Add( bigitemCode , prescription.PresDetails[j].Tolal_Fee );
                }
            }
            #endregion

            #region 对合并后的大项目单个舍入,得到舍入金额
            decimal singlePresRoundValue = 0; //单张处方舍入金额
            List<Item> lstTemp = new List<Item>( );
            foreach ( object obj in htStatItemOfSinglePresc )
            {
                decimal cost = Convert.ToDecimal( ( (DictionaryEntry)obj ).Value );
                decimal value = Decimal.Round( cost , digits );
                singlePresRoundValue = singlePresRoundValue + ( cost - value ); //累加舍入金额
                singlePrescTotalCost = singlePrescTotalCost + value;            //累加舍入后的金额

                Item item = new Item( );
                item.Text = ( (DictionaryEntry)obj ).Key.ToString( );
                item.Value = value;
                lstTemp.Add( item );//保存取舍后的大项目明细金额
            }
            #endregion
            prescription.RoundingMoney = singlePresRoundValue; //保存单张处方的舍入金额
            prescription.Total_Fee = singlePrescTotalCost;   //保存单张处方舍入后的总金额
            
            return lstTemp;
            
        }

        private ChargeInfo[] _budget( Prescription[] prescriptions )
        {
            int temp_costmasterid = MSAccessDb.GetMaxID( "MZ_COSTMASTER" , Tables.mz_costmaster.COSTMASTERID );
            int temp_costorderid = MSAccessDb.GetMaxID( "MZ_COSTORDER" , Tables.mz_costorder.COSTORDERID );
            ChargeInfo[] chargeInfos = new ChargeInfo[prescriptions.Length];
            try
            {
                for ( int prescCount = 0 ; prescCount < prescriptions.Length ; prescCount++ )
                {
                    List<Item> lstStatItems = MergePrescriptionByStatItemCode( ref  prescriptions[prescCount] );

                    Prescription prescription = prescriptions[prescCount];
                    chargeInfos[prescCount] = new ChargeInfo( );
                    //保存结算头
                    HIS.Model.MZ_CostMaster chargeBill = new HIS.Model.MZ_CostMaster( );
                    #region ....
                    chargeBill.PatID = Patient.PatID;
                    chargeBill.PatListID = Patient.PatListID;
                    chargeBill.PresMasterID = prescription.PrescriptionID;
                    chargeBill.TicketNum = "";
                    chargeBill.TicketCode = "";
                    chargeBill.ChargeCode = OperatorId.ToString( );
                    chargeBill.ChargeName = DataReader.GetEmployeeNameById( OperatorId ); //BindEntity<HIS.Model.BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL(oleDb).GetModel(OperatorId).NAME ;
                    chargeBill.Total_Fee = prescription.Total_Fee;
                    chargeBill.Self_Fee = 0;
                    chargeBill.Village_Fee = 0;
                    chargeBill.Favor_Fee = 0;
                    chargeBill.Pos_Fee = 0;
                    chargeBill.Money_Fee = 0;
                    chargeBill.Ticket_Flag = 0;
                    //chargeBill.CostDate;//预结算不写结算时间
                    chargeBill.Record_Flag = 9;//预结算记录状态置为9
                    chargeBill.OldID = 0;
                    chargeBill.AccountID = 0;
                    chargeBill.Hang_Flag = (int)OPDOperationType.门诊收费;
                    chargeBill.Hurried_Flag = Patient.IsEmergency ? 1 : 0;
                    #endregion
                    //int ret1 = BindEntity<HIS.Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).Add( chargeBill );
                    chargeBill.CostMasterID = temp_costmasterid;
                    int ret1 = MSAccessDb.InsertRecord( chargeBill , Tables.mz_costmaster.COSTMASTERID );
                    temp_costmasterid++;

                    chargeBill.CostMasterID = temp_costmasterid;
                    prescriptions[prescCount].ChargeID = temp_costmasterid;
                    //累加每张处方结算信息
                    chargeInfos[prescCount].ChargeID = chargeBill.CostMasterID;
                    chargeInfos[prescCount].PrescriptionID = chargeBill.PresMasterID;
                    chargeInfos[prescCount].TotalFee = chargeBill.Total_Fee;
                    chargeInfos[prescCount].SelfFee = chargeBill.Self_Fee;
                    chargeInfos[prescCount].VillageFee = chargeBill.Village_Fee;
                    chargeInfos[prescCount].FavorFee = chargeBill.Favor_Fee;
                    if ( ret1 > 0 )
                    {
                        List<InvoiceItem> chargeItems = new List<InvoiceItem>( );
                        #region 按大项目保存结算明细
                        foreach ( object obj in lstStatItems )
                        {
                            Item item = (Item)obj;
                            HIS.Model.MZ_CostOrder chargeDetail = new HIS.Model.MZ_CostOrder( );
                            chargeDetail.CostID = chargeBill.CostMasterID;
                            chargeDetail.ItemType = item.Text;
                            chargeDetail.Total_Fee = Convert.ToDecimal( item.Value );
                            chargeDetail.CostOrderID = temp_costorderid;
                            int ret2 = MSAccessDb.InsertRecord( chargeDetail , Tables.mz_costorder.COSTORDERID );
                            temp_costorderid++;
                            if ( ret2 > 0 )
                            {
                                InvoiceItem invoice = GetInvoiceByStatCode( chargeDetail.ItemType );
                                invoice.Cost = chargeDetail.Total_Fee;
                                chargeItems.Add( invoice );
                            }
                        }
                        #endregion
                        chargeInfos[prescCount].Items = chargeItems.ToArray( );
                    }
                }
            }
            catch ( Exception err )
            {
                throw err;
            }
            //计算每张处方的打折金额
            for ( int i = 0 ; i < chargeInfos.Length ; i++ )
            {
                chargeInfos[i].FavorFee = GetFavorCost( Patient.MediType , chargeInfos[i] , prescriptions[i] );
            }
            return chargeInfos;

        }

        private bool _charge( ChargeInfo[] BudgetaryChargeInfos , Prescription[] prescriptions , out BaseInvoice[] ChargeInvoicies )
        {
            try
            {
                for ( int chargeCount = 0 ; chargeCount < BudgetaryChargeInfos.Length ; chargeCount++ )
                {
                    if ( MSAccessDb.Exists( "MZ_COSTMASTER", Tables.mz_costmaster.COSTMASTERID + "=" + BudgetaryChargeInfos[chargeCount].ChargeID ) )
                    {
                        HIS.Model.MZ_CostMaster chargeBill = new HIS.Model.MZ_CostMaster( );
                        chargeBill = (MZ_CostMaster)MSAccessDb.GetModel( "MZ_COSTMASTER" , Tables.mz_costmaster.COSTMASTERID + "=" + BudgetaryChargeInfos[chargeCount].ChargeID , typeof( MZ_CostMaster ) );
                        chargeBill.Self_Fee = BudgetaryChargeInfos[chargeCount].SelfFee;
                        chargeBill.Village_Fee = BudgetaryChargeInfos[chargeCount].VillageFee;
                        chargeBill.Favor_Fee = BudgetaryChargeInfos[chargeCount].FavorFee;
                        chargeBill.Pos_Fee = BudgetaryChargeInfos[chargeCount].PosFee;
                        chargeBill.Money_Fee = BudgetaryChargeInfos[chargeCount].CashFee;
                        chargeBill.Ticket_Flag = 0;
                        chargeBill.CostDate = DateTime.Now;
                        chargeBill.Record_Flag = 0;
                        string perfCode = "";
                        chargeBill.TicketNum = InvoiceManager.GetBillNumber( OPDBillKind.门诊收费发票 , OperatorId , false , out perfCode );
                        chargeBill.TicketCode = perfCode;

                        BudgetaryChargeInfos[chargeCount].InvoiceSerialNO = Convert.ToInt32( chargeBill.TicketNum );
                        BudgetaryChargeInfos[chargeCount].ChargeDate = chargeBill.CostDate;
                        MSAccessDb.UpdateRecord( chargeBill );//更新结算表
                        //更新处方表收费标识
                        HIS.Model.MZ_PresMaster presMaster = new HIS.Model.MZ_PresMaster( );

                        //presMaster = BindEntity<HIS.Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( BudgetaryChargeInfos[chargeCount].PrescriptionID );
                        presMaster = (MZ_PresMaster)MSAccessDb.GetModel( "MZ_PRESMASTER" , 
                            Tables.mz_presmaster.PRESMASTERID + "=" + BudgetaryChargeInfos[chargeCount].PrescriptionID , 
                            typeof( MZ_PresMaster ) );
                        if ( presMaster.Charge_Flag == 0 )
                        {
                            presMaster.Charge_Flag = 1;
                            presMaster.RoungingMoney = presMaster.Total_Fee - BudgetaryChargeInfos[chargeCount].TotalFee;
                            presMaster.Total_Fee = BudgetaryChargeInfos[chargeCount].TotalFee;
                            presMaster.TicketCode = BudgetaryChargeInfos[chargeCount].InvoiceNO;
                            presMaster.TicketNum = chargeBill.TicketNum;
                            presMaster.CostMasterID = BudgetaryChargeInfos[chargeCount].ChargeID;
                            presMaster.ChargeCode = OperatorId.ToString( );
                            //BindEntity<HIS.Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( presMaster );
                            MSAccessDb.UpdateRecord( presMaster );
                        }
                        else
                        {
                            throw new Exception( "该处方已被其他收费员收费！" );
                        }
                    }
                    else
                    {
                        throw new Exception( "没有找到结算号的记录！" );
                    }
                }
                
                //生成发票
                ChargeInvoicies = new BaseInvoice[BudgetaryChargeInfos.Length];
                for ( int i = 0 ; i < BudgetaryChargeInfos.Length ; i++ )
                {
                    ChargeInvoicies[i] = new Invoice(BudgetaryChargeInfos[i].PerfChar, BudgetaryChargeInfos[i].InvoiceNO , OPDBillKind.门诊收费发票 );
                }
                return true;
            }
            
            catch ( Exception err )
            {
                throw err;
            }
        }

        protected bool _refundment( Invoice invoice , Prescription[] ReblancePrescriptions )
        {
            try
            {
                int temp_costmasterid = MSAccessDb.GetMaxID( "MZ_COSTMASTER" , Tables.mz_costmaster.COSTMASTERID );
                int temp_costorderid = MSAccessDb.GetMaxID( "MZ_COSTORDER" , Tables.mz_costorder.COSTORDERID );
                int temp_presmasterid = MSAccessDb.GetMaxID( "MZ_PRESMASTER" , Tables.mz_presmaster.PRESMASTERID );
                int temp_presorderid = MSAccessDb.GetMaxID( "MZ_PRESORDER" , Tables.mz_presorder.PRESORDERID );

                //List<HIS.Model.MZ_CostMaster> lstCostMaster = BindEntity<HIS.Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).GetListArray( Tables.mz_costmaster.COSTMASTERID + oleDb.EuqalTo( ) + invoice.ChargeID );
                List<HIS.Model.MZ_CostMaster> lstCostMaster = MSAccessDb.GetListArray<MZ_CostMaster>("MZ_COSTMASTER", Tables.mz_costmaster.COSTMASTERID + "=" + invoice.ChargeID );
                foreach ( HIS.Model.MZ_CostMaster mz_costmaster in lstCostMaster )
                {
                    int oldCostMasterId = mz_costmaster.CostMasterID;
                    //置结算记录退费
                    MSAccessDb.Execute( "update mz_costmaster set RECORD_FLAG = 1 where COSTMASTERID = " + oldCostMasterId );
                    //冲正
                    mz_costmaster.ChargeCode = OperatorId.ToString( );
                    mz_costmaster.ChargeName = DataReader.GetEmployeeNameById( OperatorId );
                    mz_costmaster.CostDate = DateTime.Now;
                    mz_costmaster.Favor_Fee = mz_costmaster.Favor_Fee * -1;
                    mz_costmaster.Money_Fee = mz_costmaster.Money_Fee * -1;
                    mz_costmaster.OldID = mz_costmaster.CostMasterID;
                    mz_costmaster.PresMasterID = mz_costmaster.PresMasterID;
                    mz_costmaster.Pos_Fee = mz_costmaster.Pos_Fee * -1;
                    mz_costmaster.Record_Flag = 2; //红冲标识
                    mz_costmaster.Self_Fee = mz_costmaster.Self_Fee * -1;
                    mz_costmaster.Total_Fee = mz_costmaster.Total_Fee * -1;
                    mz_costmaster.Village_Fee = mz_costmaster.Village_Fee * -1;
                    mz_costmaster.AccountID = 0;
                    mz_costmaster.Hang_Flag = (int)OPDOperationType.门诊收费;
                    mz_costmaster.CostMasterID = temp_costorderid;

                    MSAccessDb.InsertRecord( mz_costmaster , Tables.mz_costmaster.COSTMASTERID );
                    temp_costmasterid++;
                    //红冲明细
                    List<HIS.Model.MZ_CostOrder> lstCostOrder = MSAccessDb.GetListArray<HIS.Model.MZ_CostOrder>( "MZ_COSTORDER",Tables.mz_costorder.COSTID + "=" + oldCostMasterId );
                    foreach ( HIS.Model.MZ_CostOrder mz_costorder in lstCostOrder )
                    {
                        mz_costorder.CostID = mz_costmaster.CostMasterID;
                        mz_costorder.Total_Fee = mz_costorder.Total_Fee * -1;
                        mz_costorder.CostOrderID = temp_costorderid;
                        MSAccessDb.InsertRecord( mz_costorder , Tables.mz_costorder.COSTORDERID );
                        temp_costorderid++;
                    }

                    //更新对应的处方部分
                    List<HIS.Model.MZ_PresMaster> lstPresMaster = MSAccessDb.GetListArray<MZ_PresMaster>( "MZ_PRESMASTER",Tables.mz_presmaster.COSTMASTERID + "=" + oldCostMasterId );
                    foreach ( HIS.Model.MZ_PresMaster mz_presmaster in lstPresMaster )
                    {
                        int oldPresMasterId = mz_presmaster.PresMasterID;
                        //置退费标志
                        MSAccessDb.UpdateRecord( new string[]{ Tables.mz_presmaster.RECORD_FLAG + " = 1" },
                                                Tables.mz_presmaster.PRESMASTERID + " = " + oldPresMasterId ,
                                                typeof( MZ_PresMaster ) );
                        //红冲
                        mz_presmaster.ChargeCode = OperatorId.ToString( );
                        mz_presmaster.OldID = mz_presmaster.PresMasterID;
                        mz_presmaster.Record_Flag = 2;
                        mz_presmaster.Total_Fee = mz_presmaster.Total_Fee * -1;
                        mz_presmaster.PresMasterID = 0;
                        mz_presmaster.Hand_Flag = (int)OPDOperationType.门诊收费;
                        mz_presmaster.CostMasterID = mz_costmaster.CostMasterID; //记录冲正的结算ID
                        mz_presmaster.PresMasterID = temp_presmasterid;
                        MSAccessDb.InsertRecord( mz_presmaster , Tables.mz_presmaster.PRESMASTERID );
                        temp_presmasterid++;
                        //明细
                        List<MZ_PresOrder> lstPresOrder = MSAccessDb.GetListArray<MZ_PresOrder>( "MZ_PRESORDER", Tables.mz_presorder.PRESMASTERID + " = " + oldPresMasterId );
                        foreach ( MZ_PresOrder mz_presorder in lstPresOrder )
                        {
                            mz_presorder.PresMasterID = mz_presmaster.PresMasterID;
                            mz_presorder.Amount = mz_presorder.Amount * -1;
                            mz_presorder.Tolal_Fee = mz_presorder.Tolal_Fee * -1;
                            mz_presorder.PresOrderID = temp_presorderid;
                            MSAccessDb.InsertRecord( mz_presorder , Tables.mz_presorder.PRESORDERID );
                            temp_presorderid++;
                        }
                    }
                }
                
                return true;
            }
            catch ( Exception err )
            {
                
                throw err;
            }


        }
    }
}
