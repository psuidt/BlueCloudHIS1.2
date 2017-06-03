using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.MZ_BLL.Exceptions;
using HIS.BLL;
using System.Collections;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.Interface;
using HIS.Interface.Structs;
namespace HIS.MZ_BLL
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
            //DataRow[] drs = PublicDataReader.StatItemList.Select( "stat_code='" + StatItemCode + "'" );
            DataRow[] drs = BaseDataController.BaseDataSet[BaseDataCatalog.基本分类与各分类对应表].Select( "stat_code='" + StatItemCode + "'" );
            InvoiceItem invoiceItem = new InvoiceItem( );
            if ( drs.Length == 0 )
            {
                throw new OperatorException( "大项目对应的发票项目不存在！" );
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
                oleDb.BeginTransaction( );
                chargeInfos = _budget( prescriptions );
                oleDb.CommitTransaction( );
            }
            catch ( Exception err )
            {
                oleDb.RollbackTransaction( );
                ErrorWriter.WriteLog( err );
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
            oleDb.BeginTransaction();
            try
            {
                _charge( BudgetaryChargeInfos , prescriptions , out ChargeInvoicies );
                oleDb.CommitTransaction( );
                return true;
            }
            catch ( OperatorException operr )
            {
                oleDb.RollbackTransaction( );
                throw operr;
            }
            catch ( Exception err )
            {
                oleDb.RollbackTransaction( );
                ErrorWriter.WriteLog( err );
                throw new Exception( "正式结算发生错误,请重新点收银按钮！");
            }
        }
        /// <summary>
        /// 取消预结算
        /// </summary>
        /// <returns></returns>
        /// <remarks>取消预算后不会再做正式结算，并且删除掉预算信息</remarks>
        public override bool AbortBudget()
        {
            //try
            //{
            //    //头
            //    List<HIS.Model.MZ_CostMaster> masters = BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).GetListArray( "CHARGECODE='" + OperatorId.ToString() + "' AND RECORD_FLAG=9" );
            //    foreach ( HIS.Model.MZ_CostMaster master in masters )
            //    {
            //        //明细
            //        List<HIS.Model.MZ_CostOrder> orders = BindEntity<Model.MZ_CostOrder>.CreateInstanceDAL( oleDb ).GetListArray( "COSTID=" + master.CostMasterID );
            //        foreach ( HIS.Model.MZ_CostOrder order in orders )
            //        {
            //            BindEntity<Model.MZ_CostOrder>.CreateInstanceDAL( oleDb ).Delete( order.CostOrderID );
            //        }
            //        BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).Delete( master.CostMasterID );
            //    }
                
            //    return true;
            //}
            //catch ( Exception err )
            //{
            //    throw err;
            //}
            return true;
        }
        /// <summary>
        /// 退费
        /// </summary>
        /// <param name="invoice">要退费的发票对象</param>
        /// <returns></returns>
        public override bool Refundment( Invoice invoice , Prescription[] ReblancePrescriptions , List<int> ReturnedDocPresIdList )
        {
            try
            {
                oleDb.BeginTransaction( );

                _refundment( invoice , ReblancePrescriptions );
                MZClinicInterface clinicInterface = new MZClinicInterface();
                for ( int i = 0; i < ReturnedDocPresIdList.Count; i++ )
                {
                    clinicInterface.ChangePresStatus( ReturnedDocPresIdList[i], 2 );
                    //HIS.MZDoc_BLL.OP_Prescription.ChangePresStatus( ReturnedDocPresIdList[i], 2 );
                }

                oleDb.CommitTransaction( );
                return true;
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction( );
                ErrorWriter.WriteLog( err.Message );
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
            HIS.DAL.Public_DAL pub_dal = new HIS.DAL.Public_DAL( );
            pub_dal._OleDB = oleDb;
            List<HIS.DAL.Public_DAL.faoverAllData> invoiceItems = new List<HIS.DAL.Public_DAL.faoverAllData>( );
            for ( int i = 0 ; i < chargeInfo.Items.Length ; i++ )
            {
                HIS.DAL.Public_DAL.faoverAllData data = new HIS.DAL.Public_DAL.faoverAllData( );
                data.Code = chargeInfo.Items[i].ItemCode;
                data.Totalfee = chargeInfo.Items[i].Cost;
                invoiceItems.Add( data );
            }
            List<HIS.DAL.Public_DAL.faoverAllData> details = new List<HIS.DAL.Public_DAL.faoverAllData>( );
            for ( int i = 0 ; i < Prescriptions.Length ; i++ )
            {
                for ( int j = 0 ; j < Prescriptions[i].PresDetails.Length ; j++ )
                {
                    HIS.DAL.Public_DAL.faoverAllData data = new HIS.DAL.Public_DAL.faoverAllData( );
                    data.Code = Prescriptions[i].PresDetails[j].ItemId.ToString( );
                    data.Totalfee = Prescriptions[i].PresDetails[j].Tolal_Fee;
                    if ( Prescriptions[i].PresDetails[j].BigitemCode == "01" || Prescriptions[i].PresDetails[j].BigitemCode == "02" || Prescriptions[i].PresDetails[j].BigitemCode == "03" )
                    {
                        data.Type = 2;
                    }
                    else
                    {
                        if ( Prescriptions[i].PresDetails[j].ComplexId == 0 )
                            data.Type = 0;
                        else
                            data.Type = 1;
                    }
                    details.Add( data );
                }
            }
            return pub_dal.GetfaoverAll_Fee( 1 , patTypeCode , chargeInfo.TotalFee , invoiceItems , details );
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
            
            Hashtable htStatItemOfSinglePresc = new Hashtable();//单张处方的大项目
            decimal singlePresRoundValue = 0; //单张处方舍入金额
            decimal singlePrescTotalCost = 0; //单张处方总金额
            List<Item> lstTemp = new List<Item>();

            List<IPresDetail> lstPrescDetail = new List<IPresDetail>();
            for ( int i = 0 ; i < prescription.PresDetails.Length ; i++ )
            {
                lstPrescDetail.Add( prescription.PresDetails[i] );
            }

         

            singlePrescTotalCost = (new PrescMoneyCalculate()).GetPrescriptionTotalMoney( lstPrescDetail ,  out htStatItemOfSinglePresc , out singlePresRoundValue );

            foreach ( object obj in htStatItemOfSinglePresc )
            {
                Item item = new Item();
                item.Text = ( (DictionaryEntry)obj ).Key.ToString();
                item.Value = Convert.ToDecimal( ( (DictionaryEntry)obj ).Value );
                lstTemp.Add( item );//保存取舍后的大项目明细金额
            }
            prescription.RoundingMoney = singlePresRoundValue; //保存单张处方的舍入金额
            prescription.Total_Fee = singlePrescTotalCost;   //保存单张处方舍入后的总金额
            return lstTemp;
        }
        /// <summary>
        /// 预算
        /// </summary>
        /// <param name="prescriptions">要进行计算的处方，数组对象</param>
        /// <returns></returns>
        private ChargeInfo[] _budget( Prescription[] prescriptions )
        {
            //MZClinicInterface clinicInterface = new MZClinicInterface();

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
                    //chargeBill.ChargeName = PublicDataReader.GetEmployeeNameById( OperatorId ); //BindEntity<HIS.Model.BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL(oleDb).GetModel(OperatorId).NAME ;
                    chargeBill.ChargeName = BaseDataController.GetName( BaseDataCatalog.人员列表, OperatorId );
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
                    int ret1 = BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).Add( chargeBill );
                    chargeBill.CostMasterID = ret1;
                    prescriptions[prescCount].ChargeID = ret1;
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

                            int ret2 = BindEntity<Model.MZ_CostOrder>.CreateInstanceDAL( oleDb ).Add( chargeDetail );
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

                //for (int i = 0; i < prescriptions.Length; i++)//预算就修改门诊处方状态
                //    clinicInterface.ChangePresStatus(prescriptions[i].DocPresId, 1);
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
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="BudgetaryChargeInfos">预算后产生的计算信息</param>
        /// <param name="prescriptions">要收费的处方</param>
        /// <param name="ChargeInvoicies">结算成功后返回的发票结果，数组对象</param>
        /// <returns></returns>
        private bool _charge( ChargeInfo[] BudgetaryChargeInfos , Prescription[] prescriptions , out BaseInvoice[] ChargeInvoicies )
        {
            try
            {
                MZClinicInterface clinicInterface = new MZClinicInterface();
                for (int presindex = 0; presindex < prescriptions.Length; presindex++)
                {
                    if (prescriptions[presindex].DocPresId > 0)
                    {
                        decimal mzdocfee = clinicInterface.GetDocPresMoney(prescriptions[presindex].DocPresId);
                        if (mzdocfee != prescriptions[presindex].Total_Fee)
                        {
                            throw new Exception("门诊医生站已对该收费处方进行修改，请重新刷新处方再点收银！");
                        }
                    }
                }
                for ( int chargeCount = 0 ; chargeCount < BudgetaryChargeInfos.Length ; chargeCount++ )
                {
                    if ( BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).Exists( BudgetaryChargeInfos[chargeCount].ChargeID ) )
                    {
                        HIS.Model.MZ_CostMaster chargeBill = new HIS.Model.MZ_CostMaster( );
                        chargeBill = BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).GetModel( BudgetaryChargeInfos[chargeCount].ChargeID );
                        chargeBill.Self_Fee = BudgetaryChargeInfos[chargeCount].SelfFee;
                        chargeBill.Village_Fee = BudgetaryChargeInfos[chargeCount].VillageFee;
                        chargeBill.Favor_Fee = BudgetaryChargeInfos[chargeCount].FavorFee;
                        chargeBill.Pos_Fee = BudgetaryChargeInfos[chargeCount].PosFee;
                        chargeBill.Money_Fee = BudgetaryChargeInfos[chargeCount].CashFee;
                        chargeBill.Self_Tally = BudgetaryChargeInfos[chargeCount].SelfTally;
                        chargeBill.Ticket_Flag = 0;
                        chargeBill.CostDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                        chargeBill.Record_Flag = 0;
                        string perfCode = "";
                        chargeBill.TicketNum = InvoiceManager.GetBillNumber( OPDBillKind.门诊收费发票 , OperatorId , false,out perfCode );
                        chargeBill.TicketCode = perfCode; //前缀

                        //BudgetaryChargeInfos[chargeCount].InvoiceSerialNO = Convert.ToInt32( chargeBill.TicketNum );
                        //BudgetaryChargeInfos[chargeCount].PerfChar = perfCode;
                        //BudgetaryChargeInfos[chargeCount].ChargeDate = chargeBill.CostDate;

                        BudgetaryChargeInfos[chargeCount].InvoiceSerialNO = Convert.ToInt32( chargeBill.TicketNum );
                        BudgetaryChargeInfos[chargeCount].InvoiceNO = chargeBill.TicketNum;
                        BudgetaryChargeInfos[chargeCount].PerfChar = perfCode;
                        BudgetaryChargeInfos[chargeCount].ChargeDate = chargeBill.CostDate;

                        BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).Update( chargeBill );//更新结算表
                        //更新处方表收费标识
                        HIS.Model.MZ_PresMaster presMaster = new HIS.Model.MZ_PresMaster( );

                        presMaster = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( BudgetaryChargeInfos[chargeCount].PrescriptionID );
                        if ( presMaster.Charge_Flag == 0 )
                        {
                            presMaster.Charge_Flag = 1;
                            presMaster.RoungingMoney = presMaster.Total_Fee - BudgetaryChargeInfos[chargeCount].TotalFee;
                            presMaster.Total_Fee = BudgetaryChargeInfos[chargeCount].TotalFee;
                            presMaster.TicketCode = perfCode;//前缀//BudgetaryChargeInfos[chargeCount].InvoiceNO;
                            presMaster.TicketNum = chargeBill.TicketNum;
                            presMaster.CostMasterID = BudgetaryChargeInfos[chargeCount].ChargeID;
                            presMaster.ChargeCode = OperatorId.ToString( );
                            BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( presMaster );
                        }
                        else
                        {
                            throw new OperatorException( "该处方已被其他收费员收费！" );
                        }
                    }
                    else
                    {
                        throw new OperatorException( "没有找到结算号的记录！" );
                    }
                }
                for ( int i = 0 ; i < prescriptions.Length ; i++ )
                    clinicInterface.ChangePresStatus( prescriptions[i].DocPresId, 1 );
                //生成发票
                ChargeInvoicies = new BaseInvoice[BudgetaryChargeInfos.Length];
                for ( int i = 0 ; i < BudgetaryChargeInfos.Length ; i++ )
                {
                    ChargeInvoicies[i] = new Invoice(BudgetaryChargeInfos[i].PerfChar, BudgetaryChargeInfos[i].InvoiceNO , OPDBillKind.门诊收费发票 );
                }
                return true;
            }
            catch ( OperatorException operr )
            {
                throw operr;
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 退费
        /// </summary>
        /// <param name="invoice">要退费的发票对象</param>
        /// <param name="ReblancePrescriptions">需要重新补收的处方对象，主要是部分退费时会产生需要补收的处方</param>
        /// <returns></returns>
        protected bool _refundment( Invoice invoice , Prescription[] ReblancePrescriptions )
        {
            try
            {

                List<Model.MZ_CostMaster> lstCostMaster = BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).GetListArray( Tables.mz_costmaster.COSTMASTERID + oleDb.EuqalTo( ) + invoice.ChargeID );
                foreach ( Model.MZ_CostMaster mz_costmaster in lstCostMaster )
                {
                    int oldCostMasterId = mz_costmaster.CostMasterID;
                    //置结算记录退费
                    BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).Update( Tables.mz_costmaster.COSTMASTERID + oleDb.EuqalTo( ) + oldCostMasterId ,
                                                                                    Tables.mz_costmaster.RECORD_FLAG + oleDb.EuqalTo( ) + "1" );
                    //冲正
                    mz_costmaster.ChargeCode = OperatorId.ToString( );
                    //mz_costmaster.ChargeName = PublicDataReader.GetEmployeeNameById( OperatorId );
                    mz_costmaster.ChargeName = BaseDataController.GetName( BaseDataCatalog.人员列表, OperatorId );
                    mz_costmaster.CostDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    mz_costmaster.Favor_Fee = mz_costmaster.Favor_Fee * -1;
                    mz_costmaster.Money_Fee = mz_costmaster.Money_Fee * -1;
                    mz_costmaster.OldID = mz_costmaster.CostMasterID;
                    mz_costmaster.PresMasterID = mz_costmaster.PresMasterID;
                    mz_costmaster.Pos_Fee = mz_costmaster.Pos_Fee * -1;
                    mz_costmaster.Record_Flag = 2; //红冲标识
                    mz_costmaster.Self_Fee = mz_costmaster.Self_Fee * -1;
                    mz_costmaster.Total_Fee = mz_costmaster.Total_Fee * -1;
                    mz_costmaster.Village_Fee = mz_costmaster.Village_Fee * -1;
                    mz_costmaster.Self_Tally = mz_costmaster.Self_Tally * -1;
                    mz_costmaster.AccountID = 0;
                    mz_costmaster.Hang_Flag = (int)OPDOperationType.门诊收费;
                    BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).Add( mz_costmaster );
                    //红冲明细
                    List<Model.MZ_CostOrder> lstCostOrder = BindEntity<Model.MZ_CostOrder>.CreateInstanceDAL( oleDb ).GetListArray( Tables.mz_costorder.COSTID + oleDb.EuqalTo( ) + oldCostMasterId );
                    foreach ( Model.MZ_CostOrder mz_costorder in lstCostOrder )
                    {
                        mz_costorder.CostID = mz_costmaster.CostMasterID;
                        mz_costorder.Total_Fee = mz_costorder.Total_Fee * -1;
                        BindEntity<Model.MZ_CostOrder>.CreateInstanceDAL( oleDb ).Add( mz_costorder );
                    }

                    //更新对应的处方部分
                    List<Model.MZ_PresMaster> lstPresMaster = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetListArray( Tables.mz_presmaster.COSTMASTERID + oleDb.EuqalTo( ) + oldCostMasterId );
                    foreach ( Model.MZ_PresMaster mz_presmaster in lstPresMaster )
                    {
                        int oldPresMasterId = mz_presmaster.PresMasterID;
                        //置退费标志
                        BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( Tables.mz_presmaster.PRESMASTERID + oleDb.EuqalTo( ) + oldPresMasterId ,
                                                                                           Tables.mz_presmaster.RECORD_FLAG + oleDb.EuqalTo( ) + "1" );
                        //红冲
                        mz_presmaster.ChargeCode = OperatorId.ToString( );
                        mz_presmaster.OldID = mz_presmaster.PresMasterID;
                        mz_presmaster.Record_Flag = 2;
                        mz_presmaster.Total_Fee = mz_presmaster.Total_Fee * -1;
                        mz_presmaster.PresMasterID = 0;
                        mz_presmaster.Hand_Flag = (int)OPDOperationType.门诊收费;
                        mz_presmaster.CostMasterID = mz_costmaster.CostMasterID; //记录冲正的结算ID
                        BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Add( mz_presmaster );
                        //明细
                        List<Model.MZ_PresOrder> lstPresOrder = BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetListArray( Tables.mz_presorder.PRESMASTERID + oleDb.EuqalTo( ) + oldPresMasterId );
                        foreach ( Model.MZ_PresOrder mz_presorder in lstPresOrder )
                        {
                            mz_presorder.PresMasterID = mz_presmaster.PresMasterID;
                            mz_presorder.Amount = mz_presorder.Amount * -1;
                            mz_presorder.Tolal_Fee = mz_presorder.Tolal_Fee * -1;
                            BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).Add( mz_presorder );
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
