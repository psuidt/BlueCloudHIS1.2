using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Model;
using HIS.BLL;
using HIS.MSAccess;


namespace HIS_DJSFManager.类
{
    /// <summary>
    /// 收费业务控制类
    /// </summary>
    public class ChargeControl 
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
        private BaseCharge chargeObject;
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

            ChargeType chargeType = ChargeType.多张处方一次结算;//考虑使用参数

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
            //oleDb.BeginTransaction();
            MSAccessDb.BeginTrans( );
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
                    #endregion
                    if ( MSAccessDb.Exists("MZ_PRESMASTER",Tables.mz_presmaster.PRESMASTERID + "=" + Prescriptions[i].PrescriptionID))
                    {
                        MZ_PresMaster mz_presmaster = (MZ_PresMaster)MSAccessDb.GetModel( "MZ_PRESMASTER" , Tables.mz_presmaster.PRESMASTERID + "=" + Prescriptions[i].PrescriptionID , typeof( MZ_PresMaster ) );
                        if ( mz_presmaster.Charge_Flag == 1 )
                        {
                            throw new Exception( "处方已收费，不能修改！" );
                        }
                        //更新处方头
                        //BindEntity<MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( t_mz_prescMaster );
                        MSAccessDb.UpdateRecord( t_mz_prescMaster );
                    }
                    else
                    {
                        //插入新处方
                        t_mz_prescMaster.PresMasterID = MSAccessDb.GetMaxID( "MZ_PRESMASTER" , Tables.mz_presmaster.PRESMASTERID );
                        MSAccessDb.InsertRecord( t_mz_prescMaster , Tables.mz_presmaster.PRESMASTERID );
                        Prescriptions[i].PrescriptionID = t_mz_prescMaster.PresMasterID;
                    }
                    //更新或增加明细
                    PrescriptionDetail[] details = Prescriptions[i].PresDetails;
                    int temp_detail_id = MSAccessDb.GetMaxID("MZ_PRESORDER" , Tables.mz_presorder.PRESORDERID );
                    for ( int j = 0 ; j < details.Length ; j++ )
                    {
                        HIS.Model.MZ_PresOrder t_mz_presOrder = new HIS.Model.MZ_PresOrder( );
                        #region 赋值
                        t_mz_presOrder.Amount = details[j].Amount;
                        t_mz_presOrder.BigItemCode = details[j].BigitemCode;
                        t_mz_presOrder.Buy_Price = details[j].Buy_price;
                        t_mz_presOrder.CaseID = details[j].ComplexId;
                        t_mz_presOrder.ItemID = details[j].ItemId;
                        t_mz_presOrder.ItemName = details[j].Itemname;
                        t_mz_presOrder.ItemType = details[j].ItemType;
                        t_mz_presOrder.Order_Flag = details[j].Order_Flag;
                        t_mz_presOrder.PassID = details[j].PassId;
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

                        if ( MSAccessDb.Exists("MZ_PRESORDER",Tables.mz_presorder.PRESORDERID + "=" + details[j].DetailId ))
                        {
                            //更新处方明细
                            MSAccessDb.UpdateRecord( t_mz_presOrder );
                        }
                        else
                        {
                            //插入新处方明细
                            t_mz_presOrder.PresOrderID = temp_detail_id;
                            int ret2 = MSAccessDb.InsertRecord( t_mz_presOrder , Tables.mz_presorder.PRESORDERID );
                            details[j].DetailId = temp_detail_id;
                            temp_detail_id++;
                        }
                    }
                }

                MSAccessDb.CommitTrans( );
                return true;
            }
            catch ( Exception err )
            {
                MSAccessDb.RollbackTrans( );
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
                Invoicies = (Invoice[])baseInvoicies;
            else
                Invoicies = null;
            return ret;
        }
        /// <summary>
        /// 取消结算，即退费
        /// </summary>
        /// <param name="invoice">要退费的发票对象</param>
        /// <returns>TRUE：退费成功</returns>
        public bool Refundment( Invoice invoice , Prescription[] ReblancePrescriptions )
        {
            return chargeObject.Refundment( invoice ,ReblancePrescriptions);
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
            //MZ_PresMaster mz_presmaster = BindEntity<MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( PrescriptionId );
            MZ_PresMaster mz_presmaster = (MZ_PresMaster)MSAccessDb.GetModel( "MZ_PRESMASTER" , Tables.mz_presmaster.PRESMASTERID + "=" + PrescriptionId , typeof( MZ_PresMaster ) );
            if ( mz_presmaster.Charge_Flag == 1 )
            {
                throw new Exception( "该处方已经收费，不能删除！" );
            }

            MSAccessDb.BeginTrans( );
            try
            {
                int effectRow = 0;
                List<HIS.Model.MZ_PresOrder> detail = MSAccessDb.GetListArray<MZ_PresOrder>("MZ_PRESORDER", "PRESMASTERID=" + PrescriptionId );
                for ( int i = 0; i < detail.Count; i++ )
                {
                    MSAccessDb.Execute( "delete * from mz_presorder where presorderid=" + ( (HIS.Model.MZ_PresOrder)detail[i] ).PresOrderID );
                    effectRow++;
                }
                MSAccessDb.Execute( "delete * from mz_presmaster where presmasterid = " + PrescriptionId );
                effectRow++;
                MSAccessDb.CommitTrans( );
                return effectRow;
            }
            catch  
            {
                MSAccessDb.RollbackTrans( );
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
            MZ_PresOrder mz_presorder = (MZ_PresOrder)MSAccessDb.GetModel( "MZ_PRESORDER" , Tables.mz_presorder.PRESORDERID + "=" + PrescriptionDetailId , typeof( MZ_PresOrder ) );
            MZ_PresMaster mz_presmaster = (MZ_PresMaster)MSAccessDb.GetModel( "MZ_PRESMASTER" , Tables.mz_presmaster.PRESMASTERID + "=" + mz_presorder.PresMasterID , typeof( MZ_PresMaster ) );
            if ( mz_presmaster.Charge_Flag == 1 )
            {
                throw new Exception( "该处方已经收费，不能删除！" );
            }

            MSAccessDb.BeginTrans( );
            try
            {
                int effectRow = 0;
                MZ_PresOrder detail = (MZ_PresOrder)MSAccessDb.GetModel( "MZ_PRESORDER" , Tables.mz_presorder.PRESORDERID + "=" + PrescriptionDetailId , typeof( MZ_PresOrder ) );
                MSAccessDb.Execute( "delete * from mz_presorder where presorderid=" + detail.PresOrderID );
                effectRow++;
                MSAccessDb.CommitTrans( );
                return effectRow;
            }
            catch(Exception err)
            {
                MSAccessDb.RollbackTrans( );
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
        public void SetChargeInfoPay( ref ChargeInfo[] ChargeInfos , decimal InsurPay , decimal PosPay , decimal CashPay , decimal SelfTally )
        {
            if ( ChargeInfos.Length > 1 && ( InsurPay > 0 && PosPay > 0 && CashPay > 0 && SelfTally > 0 ) )
            {
                throw new Exception( "多张处方一起结算的情况下只能有一种支付方式！" );
            }

            ChargeInfos[0].VillageFee = InsurPay;
            ChargeInfos[0].SelfFee = ChargeInfos[0].TotalFee - ChargeInfos[0].VillageFee;
            ChargeInfos[0].PosFee = PosPay;
            ChargeInfos[0].SelfTally = SelfTally;
            ChargeInfos[0].CashFee = ChargeInfos[0].SelfFee - ChargeInfos[0].PosFee - ChargeInfos[0].SelfTally;

        }
        
    }
}
