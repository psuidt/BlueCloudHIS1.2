using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS;
using HIS.SYSTEM.Core;
using HIS.MZ_BLL.Exceptions;
using HIS.Interface.Structs;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 收费业务控制类
    /// </summary>
    public class ChargeControl : BaseBLL
    {

        /// <summary>
        /// 需要结算的病人
        /// </summary>
        private OutPatient patient;
        /// <summary>
        /// 操作员
        /// </summary>
        private int userId;
        /// <summary>
        /// 结算对象
        /// </summary>
        private HIS.MZ_BLL.BaseCharge chargeObject;
        /// <summary>
        /// 构造一个结算业务类,每个对象的实例对应一次业务操作
        /// 处理过程：保存处方->预算->正式结算->打印发票(可选)
        /// </summary>
        /// <param name="Patient">需要结算的病人对象</param>
        /// <param name="OperatorId">操作员</param>
        public ChargeControl( OutPatient Patient, int OperatorId )
        {
            patient = Patient;
            userId = OperatorId;

            ChargeType chargeType = (ChargeType)Convert.ToInt32( OPDParamter.Parameters["014"] );
             

            //ChargeType chargeType = ChargeType.多张处方一次结算;//考虑使用参数

            //根据病人类型实例化结算对象
            chargeObject = ChargeFactory.CreateChargeObject( Patient , OperatorId , chargeType );

        }
        /// <summary>
        /// 保存处方
        /// </summary>
        /// <param name="Prescriptions">要保存的处方</param>
        /// <returns>成功标志</returns> 
        /// <remarks></remarks>
        public bool SavePrescription( Prescription[] Prescriptions )
        {
            oleDb.BeginTransaction();
            try
            {
                for ( int i = 0 ; i < Prescriptions.Length ; i++ )
                {
                    if ( !Prescriptions[i].Modified )
                        continue;

                    if ( Prescriptions[i].PresDetails == null )
                        continue;

                    if ( Prescriptions[i].PresDetails.Length == 0 )
                        continue;

                    HIS.Model.MZ_PresMaster t_mz_prescMaster = new HIS.Model.MZ_PresMaster( );
                    #region 赋值
                    t_mz_prescMaster.PatID = Prescriptions[i].PatientID;
                    t_mz_prescMaster.PatListID = Prescriptions[i].RegisterID;
                    t_mz_prescMaster.Charge_Flag = Prescriptions[i].Charge_Flag;
                    t_mz_prescMaster.ChargeCode = Prescriptions[i].ChargeCode;
                    t_mz_prescMaster.CostMasterID = Prescriptions[i].ChargeID;
                    t_mz_prescMaster.Drug_Flag = Prescriptions[i].Drug_Flag;
                    t_mz_prescMaster.ExecDeptCode = Prescriptions[i].ExecDeptCode;
                    t_mz_prescMaster.ExecDocCode = Prescriptions[i].ExecDocCode;
                    t_mz_prescMaster.OldID = Prescriptions[i].OldPresID;
                    t_mz_prescMaster.PresCostCode = Prescriptions[i].PresCostCode;
                    t_mz_prescMaster.PresMasterID = Prescriptions[i].PrescriptionID;
                    t_mz_prescMaster.PresType = Prescriptions[i].PrescType;
                    t_mz_prescMaster.PresDeptCode = Prescriptions[i].PresDeptCode;
                    t_mz_prescMaster.PresDocCode = Prescriptions[i].PresDocCode;
                    t_mz_prescMaster.Record_Flag = Prescriptions[i].Record_Flag;
                    t_mz_prescMaster.TicketCode = Prescriptions[i].TicketCode;
                    t_mz_prescMaster.TicketNum = Prescriptions[i].TicketNum;
                    t_mz_prescMaster.Total_Fee = Prescriptions[i].Total_Fee;
                    t_mz_prescMaster.PresDate = Prescriptions[i].PresDate;
                    t_mz_prescMaster.PresAmount = Prescriptions[i].PresDetails[0].PresAmount;
                    t_mz_prescMaster.Hand_Flag = (int)OPDOperationType.门诊收费;
                    t_mz_prescMaster.DocPresId = Prescriptions[i].DocPresId;
                    #endregion
                    if ( BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Exists( Prescriptions[i].PrescriptionID ) )
                    {
                        Model.MZ_PresMaster mz_presmaster = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( Prescriptions[i].PrescriptionID );
                        if ( mz_presmaster.Charge_Flag == 1 )
                        {
                            throw new OperatorException( "处方已收费，不能修改！" );
                        }
                        //更新处方头
                        BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( t_mz_prescMaster );
                    }
                    else
                    {
                        //插入新处方
                        int ret1 = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Add( t_mz_prescMaster );
                        Prescriptions[i].PrescriptionID = ret1;
                    }
                    //更新或增加明细
                    PrescriptionDetail[] details = Prescriptions[i].PresDetails;
                    for ( int j = 0 ; j < details.Length ; j++ )
                    {
                        if ( details[j].Amount == 0 )
                            throw new OperatorException( "【" + details[j].Itemname + "】数量为零，请输入一个大于零的数" );
                        if ( details[j].BigitemCode == "01" || details[j].BigitemCode == "02" || details[j].BigitemCode == "03" )
                        {
                            decimal sellprice , buyprice , storevalue;
                            decimal inputValue = details[j].Amount * details[j].PresAmount;
                            PublicDataReader.StoreExists( details[j].ItemId , Prescriptions[i].ExecDeptCode , inputValue ,
                                out sellprice , out buyprice , out storevalue );
                           
                            
                        }

                        HIS.Model.MZ_PresOrder t_mz_presOrder = new HIS.Model.MZ_PresOrder( );
                        #region 赋值
                        t_mz_presOrder.Amount = details[j].Amount;
                        t_mz_presOrder.BigItemCode = details[j].BigitemCode;
                        t_mz_presOrder.Buy_Price = details[j].Buy_price;
                        t_mz_presOrder.CaseID = details[j].ComplexId;  //预留的CASEID用来保存组合项目的ID
                        t_mz_presOrder.ItemID = details[j].ItemId;
                        t_mz_presOrder.ItemName = details[j].Itemname;
                        t_mz_presOrder.ItemType = details[j].ItemType;
                        t_mz_presOrder.Order_Flag = details[j].Order_Flag;
                        t_mz_presOrder.PassID = details[j].DocPrescDetailId;  //预留的PassID用来保存门诊医生处方明细ID
                        t_mz_presOrder.PatID = this.patient.PatID;
                        t_mz_presOrder.PatListID = this.patient.PatListID;
                        t_mz_presOrder.PresAmount = details[j].PresAmount;
                        t_mz_presOrder.PresMasterID = Prescriptions[i].PrescriptionID;
                        t_mz_presOrder.PresOrderID = details[j].DetailId;
                        t_mz_presOrder.RelationNum = details[j].RelationNum;
                        t_mz_presOrder.Sell_Price = details[j].Sell_price;
                        t_mz_presOrder.Standard = details[j].Standard;
                        t_mz_presOrder.Tolal_Fee = details[j].Tolal_Fee;
                        t_mz_presOrder.Unit = details[j].Unit;
                        #endregion

                        if ( BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).Exists( details[j].DetailId ) )
                        {
                            //更新处方明细
                            BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).Update( t_mz_presOrder );
                        }
                        else
                        {
                            //插入新处方明细
                            int ret2 = BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).Add( t_mz_presOrder );
                            details[j].DetailId = ret2;
                        }
                    }
                }
                                
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
                ErrorWriter.WriteLog( err.Message );
                throw new Exception("保存处方发生错误！");
            }
        }
        /// <summary>
        /// 预算（一张处方一次结算，返回结算信息的数组，因为现在模式是一张处方一次结算，对于多张处方，返回结算数组对象，前台处理
        /// 反馈给用户的总信息
        /// </summary>
        /// <param name="prescriptions">处方信息</param>
        /// <returns>返回预算信息</returns>
        public ChargeInfo[] Budget( Prescription[] prescriptions )
        {
            return chargeObject.Budget( prescriptions );
        }
        /// <summary>
        /// 正式结算
        /// </summary>
        /// <param name="ChargeInfos">预结算信息（注意，传入的预算信息必须包含了各种支付信息）</param>
        /// <param name="prescriptions">要结算的处方信息</param>
        public bool Charge( ChargeInfo[] ChargeInfos ,Prescription[] prescriptions,out Invoice[] Invoicies)
        {
            BaseInvoice[] baseInvoicies;
            bool ret = chargeObject.Charge( ChargeInfos , prescriptions , out baseInvoicies );
            if ( ret )
            {
                Invoicies = new Invoice[baseInvoicies.Length];
                for ( int i = 0 ; i < baseInvoicies.Length ; i++ )
                    Invoicies[i] = (Invoice)baseInvoicies[i];
            }
            else
                Invoicies = null;
            return ret;
        }
        /// <summary>
        /// 取消结算，即退费
        /// </summary>
        /// <param name="invoice">要退费的发票对象</param>
        /// <returns>TRUE：退费成功</returns>
        public bool Refundment( Invoice invoice, Prescription[] ReblancePrescriptions, List<int> ReturnedDocPresIdList )
        {
            return chargeObject.Refundment( invoice, ReblancePrescriptions, ReturnedDocPresIdList );
        }
        /// <summary>
        /// 取消收费
        /// </summary>
        /// <returns></returns>
        public bool CancelCharge()
        {
            return chargeObject.AbortBudget();
        }
        /// <summary>
        /// 删除处方
        /// </summary>
        /// <param name="PrescriptionId">要删除的处方ID</param>
        /// <returns>被删除的处方数</returns>
        public int DeletePrescription( int PrescriptionId )
        {
            Model.MZ_PresMaster mz_presmaster = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( PrescriptionId );
            if ( mz_presmaster.Charge_Flag == 1 )
            {
                throw new OperatorException( "该处方已经收费，不能删除！" );
            }

            oleDb.BeginTransaction();
            try
            {
                int effectRow = 0;
                List<HIS.Model.MZ_PresOrder> detail = BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetListArray( "PRESMASTERID=" + PrescriptionId );
                
                for ( int i = 0; i < detail.Count; i++ )
                {
                    BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).Delete( ( (HIS.Model.MZ_PresOrder)detail[i] ).PresOrderID );
                    effectRow++;
                }
                BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Delete( PrescriptionId );
                effectRow++;
                oleDb.CommitTransaction();
                return effectRow;
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction();
                ErrorWriter.WriteLog( err.Message );
                return 0;
            }
        }
        /// <summary>
        /// 删除处方明细
        /// </summary>
        /// <param name="PrescriptionDetailId">要删除的明细ID</param>
        /// <returns>被删除的处方明细数</returns>
        public int DeletePrescriptionDetail( int PrescriptionDetailId )
        {

            //HIS.DAL.MZ_PresOrder d_mz_presorder = new HIS.DAL.MZ_PresOrder( );
            //d_mz_presorder._oleDB = this.oleDb;
            HIS.Model.MZ_PresOrder mz_presorder = BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetModel( PrescriptionDetailId );
            HIS.Model.MZ_PresMaster mz_presmaster = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( mz_presorder.PresMasterID );
            if ( mz_presmaster.Charge_Flag == 1 )
            {
                throw new OperatorException( "该处方已经收费，不能删除！" );
            }

            oleDb.BeginTransaction();
            try
            {
                int effectRow = 0;
                HIS.Model.MZ_PresOrder detail = BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetModel( PrescriptionDetailId );

                BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).Delete( detail.PresOrderID );
                effectRow++;
                oleDb.CommitTransaction();
                return effectRow;
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction();
                ErrorWriter.WriteLog( err.Message );
                return 0;
            }
        }
        /// <summary>
        /// 按照用户输入的金额分配每个结算的金额分配
        /// </summary>
        /// <param name="ChargeInfos">结算结果</param>
        /// <param name="InsurPay">医保农合支付</param>
        /// <param name="PosPay">POS支付</param>
        /// <param name="CashPay">现金支付</param>
        /// <param name="SelfTally">个人记账（属于个人自付中的一部分）</param>
        public void SetChargeInfoPay(ref ChargeInfo[] ChargeInfos,decimal InsurPay,decimal PosPay,decimal CashPay,decimal SelfTally )
        {
            if ( ChargeInfos.Length > 1 )
            {
                for ( int i = 0 ; i < ChargeInfos.Length ; i++ )
                {
                    if ( InsurPay > 0 )
                        ChargeInfos[i].VillageFee = ChargeInfos[i].TotalFee - ChargeInfos[i].FavorFee;
                    else if ( PosPay > 0 )
                        ChargeInfos[i].PosFee = ChargeInfos[i].TotalFee - ChargeInfos[i].FavorFee;
                    else if ( SelfTally > 0 )
                        ChargeInfos[i].SelfTally = ChargeInfos[i].TotalFee - ChargeInfos[i].FavorFee;
                    else
                        ChargeInfos[i].CashFee = ChargeInfos[i].TotalFee;
                }
            }
            else
            {
                ChargeInfos[0].VillageFee = InsurPay;
                ChargeInfos[0].SelfFee = ChargeInfos[0].TotalFee - ChargeInfos[0].VillageFee;
                ChargeInfos[0].PosFee = PosPay;
                ChargeInfos[0].SelfTally = SelfTally;
                ChargeInfos[0].CashFee = ChargeInfos[0].SelfFee - ChargeInfos[0].PosFee - ChargeInfos[0].SelfTally;
            }
            //if ( ChargeInfos.Length == 1 && InsurPay > 0 )
            //{
            //    ChargeInfos[0].VillageFee = InsurPay;
            //    ChargeInfos[0].SelfFee = ChargeInfos[0].TotalFee - ChargeInfos[0].VillageFee;
            //    ChargeInfos[0].PosFee = PosPay;
            //    ChargeInfos[0].SelfTally = SelfTally;
            //    ChargeInfos[0].CashFee = ChargeInfos[0].SelfFee - ChargeInfos[0].PosFee - ChargeInfos[0].SelfTally ; 
            //}
            //else
            //{
            //    #region 分配每张处方的支付信息（先现金再POS）
            //    decimal totalCash = CashPay;
            //    decimal totalPos = PosPay;

            //    for ( int i = 0 ; i < ChargeInfos.Length ; i++ )
            //    {
            //        //自付=总金额 - 优惠 - 记账
            //        ChargeInfos[i].SelfFee = ChargeInfos[i].TotalFee - ChargeInfos[i].FavorFee - ChargeInfos[i].VillageFee;

            //        if ( totalCash >= ChargeInfos[i].SelfFee )
            //        {
            //            //支付的现金大于自付,支付方式为全现金
            //            ChargeInfos[i].PosFee = 0;
            //            ChargeInfos[i].SelfTally = 0;
            //            ChargeInfos[i].CashFee = ChargeInfos[i].SelfFee;
            //            totalCash = totalCash - ChargeInfos[i].CashFee;
            //        }
            //        else
            //        {
            //            //支付的现金<自付并且大于0，支付方式为剩余的现金+部分POS+部分个人记账
            //            if ( totalCash != 0 )
            //            {
            //                ChargeInfos[i].CashFee = totalCash; //剩余的现金
            //                ChargeInfos[i].PosFee = ChargeInfos[i].SelfFee - ChargeInfos[i].CashFee; //部分支付POS
            //                totalCash = 0;
            //                totalPos = totalPos - ChargeInfos[i].PosFee;
            //            }
            //            else
            //            {
            //                ChargeInfos[i].CashFee = 0;
            //                ChargeInfos[i].PosFee = ChargeInfos[i].SelfFee;
            //                totalPos = totalPos - ChargeInfos[i].PosFee;

            //            }
            //        }
            //    }
            //    #endregion
            //}
        }
        
    }
}
