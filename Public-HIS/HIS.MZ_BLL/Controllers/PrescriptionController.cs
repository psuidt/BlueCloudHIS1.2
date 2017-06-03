using System;
using System.Collections.Generic;
using HIS.BLL;
using HIS.Interface.Structs;
using HIS.Model;
using HIS.MZ_BLL.Exceptions;
using HIS.SYSTEM.Core;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 处方管理器,
    /// </summary>
    public class PrescriptionController : BaseBLL
    {
        public PrescriptionController()
        {
        }
        /// <summary>
        /// 保存处方
        /// </summary>
        /// <param name="patient">处方所属病人</param>
        /// <param name="Prescriptions">要保存的处方</param>
        /// <returns></returns>
        public bool SavePrescription(BasePatient patient, Prescription[] Prescriptions )
        {
            oleDb.BeginTransaction( );
            try
            {
                for ( int i = 0 ; i < Prescriptions.Length ; i++ )
                {
                    if ( !Prescriptions[i].Modified && Prescriptions[i].DocPresId==0 )
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

                            details[j].Buy_price = buyprice;
                            details[j].Sell_price = sellprice;

                        }

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
                        t_mz_presOrder.PatID = patient.PatID;
                        t_mz_presOrder.PatListID = patient.PatListID;
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
                throw new Exception( "保存处方发生错误！" );
            }
        }
        /// <summary>
        /// 复制处方到该处方所属的病人
        /// </summary>
        /// <returns></returns>
        public bool CopyPrescription( int PrescriptionId )
        {
            return CopyPrescription( PrescriptionId , null );
        }
        /// <summary>
        /// 复制处方到指定的病人
        /// </summary>
        /// <param name="PrescriptionId">目标处方ID</param>
        /// <param name="patient">目标病人</param>
        /// <returns></returns>
        public bool CopyPrescription( int PrescriptionId , BasePatient patient )
        {
            MZ_PresMaster mz_presmaster = BindEntity<MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( PrescriptionId );
            if ( mz_presmaster == null )
                throw new Exception( "没有找到处方，请确认处方是否存在！" );
            List<MZ_PresOrder> lstPresOrder = BindEntity<MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetListArray( Tables.mz_presorder.PRESMASTERID + oleDb.EuqalTo( ) + PrescriptionId );
            if ( lstPresOrder.Count == 0 )
                throw new Exception( "该处方没有明细，不能复制！" );

            try
            {
                mz_presmaster.Charge_Flag = 0;
                mz_presmaster.ChargeCode = "";
                mz_presmaster.CostMasterID = 0;
                mz_presmaster.Drug_Flag = 0;
                mz_presmaster.OldID = 0;
                mz_presmaster.PresDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                mz_presmaster.Record_Flag = 0;
                mz_presmaster.TicketCode = "";
                mz_presmaster.TicketNum = "";
                if ( patient != null )
                {
                    mz_presmaster.PatID = patient.PatID;
                    mz_presmaster.PatListID = patient.PatListID;
                }

                oleDb.BeginTransaction( );
                BindEntity<MZ_PresMaster>.CreateInstanceDAL( oleDb ).Add( mz_presmaster );
                foreach ( MZ_PresOrder order in lstPresOrder )
                {
                    order.PresMasterID = mz_presmaster.PresMasterID;
                    BindEntity<MZ_PresOrder>.CreateInstanceDAL( oleDb ).Add( order );
                }
                oleDb.CommitTransaction( );
                return true;
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction( );
                ErrorWriter.WriteLog( err.Message + "\r\n" + err.StackTrace );
                throw new Exception( "复制处方发生错误！详情请参考log日志！" );
            }
        }
        /// <summary>
        /// 删除处方
        /// </summary>
        /// <param name="PrescriptionId">要删除的处方ID</param>
        /// <returns>被删除的处方数</returns>
        public int DeletePrescription( int PrescriptionId )
        {
            MZ_PresMaster mz_presmaster = BindEntity<MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( PrescriptionId );
            if ( mz_presmaster.Charge_Flag == 1 )
            {
                throw new OperatorException( "该处方已经收费，不能删除！" );
            }

            oleDb.BeginTransaction( );
            try
            {
                int effectRow = 0;
                List<MZ_PresOrder> detail = BindEntity<MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetListArray( "PRESMASTERID=" + PrescriptionId );

                for ( int i = 0 ; i < detail.Count ; i++ )
                {
                    BindEntity<MZ_PresOrder>.CreateInstanceDAL( oleDb ).Delete( ( (MZ_PresOrder)detail[i] ).PresOrderID );
                    effectRow++;
                }
                BindEntity<MZ_PresMaster>.CreateInstanceDAL( oleDb ).Delete( PrescriptionId );
                effectRow++;
                oleDb.CommitTransaction( );
                return effectRow;
            }
            catch ( Exception err )
            {
                oleDb.RollbackTransaction( );
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

            MZ_PresOrder mz_presorder = BindEntity<MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetModel( PrescriptionDetailId );
            MZ_PresMaster mz_presmaster = BindEntity<MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( mz_presorder.PresMasterID );
            if ( mz_presmaster.Charge_Flag == 1 )
            {
                throw new OperatorException( "该处方已经收费，不能删除！" );
            }

            oleDb.BeginTransaction( );
            try
            {
                int effectRow = 0;
                MZ_PresOrder detail = BindEntity<MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetModel( PrescriptionDetailId );

                BindEntity<MZ_PresOrder>.CreateInstanceDAL( oleDb ).Delete( detail.PresOrderID );
                effectRow++;
                oleDb.CommitTransaction( );
                return effectRow;
            }
            catch ( Exception err )
            {
                oleDb.RollbackTransaction( );
                ErrorWriter.WriteLog( err.Message );
                return 0;
            }
        }
        /// <summary>
        /// 获取病人处方
        /// </summary>
        /// <param name="patient">处方所属的病人</param>
        /// <param name="status">状态</param>
        /// <param name="IsCharge">是否收费处检索</param>
        /// <returns>处方信息</returns>
        public Prescription[] GetPrescriptions( BasePatient patient , PresStatus status , bool IsCharge )
        {
            return GetPrescriptions( patient , status , IsCharge , "" , "" , "" , 0 );
        }
        /// <summary>
        /// 获取病人处方
        /// </summary>
        /// <param name="patient">处方所属的病人</param>
        /// <param name="status">状态</param>
        /// <param name="IsCharge">是否收费处检索</param>
        /// <param name="ExceDeptID">执行科室ID</param>
        /// <returns>处方信息</returns>
        public Prescription[] GetPrescriptions( BasePatient patient , PresStatus status , bool IsCharge , int ExceDeptID )
        {
            return GetPrescriptions( patient , status , IsCharge , "" , "" , "" , ExceDeptID );
        }
        /// <summary>
        /// 获取病人处方
        /// </summary>
        /// <param name="patient">处方所属的病人</param>
        /// <param name="status"></param>
        /// <param name="IsCharge">是否收费处检索</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="InvoiceNo">发票号</param>
        /// <param name="ExecDeptCode">执行科室ID</param>
        /// <returns>处方信息</returns>
        public Prescription[] GetPrescriptions( BasePatient patient , PresStatus status , bool IsCharge , string beginDate , string endDate , string InvoiceNo , int ExecDeptCode )
        {
            string condiction = "";
            switch ( status )
            {
                case PresStatus.全部:
                    condiction = " PatListID = " + patient.PatListID + " AND Record_Flag in (0,1)";
                    break;
                case PresStatus.未收费:
                    condiction = " PatListID = " + patient.PatListID + " AND Charge_Flag = 0 AND Record_Flag = 0 AND Drug_Flag = 0";
                    break;
                case PresStatus.已收费未发药:
                case PresStatus.已收费已退药:
                    condiction = " PatListID = " + patient.PatListID + " AND Charge_Flag = 1 AND Record_Flag = 0 And Drug_Flag = 0";
                    break;
                case PresStatus.已收费已发药:
                    condiction = " PatListID = " + patient.PatListID + " AND Charge_Flag = 1 AND Record_Flag = 0 And Drug_Flag = 1";
                    break;
            }
            if ( !IsCharge )
                condiction = condiction + " and PRESTYPE in ('0','1','2','3') ";

            if ( ExecDeptCode != 0 )
                condiction = condiction + " and ExecDeptCode = '" + ExecDeptCode.ToString( ) + "'";

            if ( InvoiceNo.Trim( ) == "" )
            {
                if ( beginDate.Trim( ) != "" )
                {
                    condiction = condiction + " and PresDate>='" + beginDate + "'";
                }
                if ( endDate.Trim( ) != "" )
                {
                    condiction = condiction + " and PresDate<='" + endDate + "'";
                }
            }

            if ( InvoiceNo.Trim( ) != "" )
            {
                condiction = condiction + " and COSTMASTERID in (select COSTMASTERID from MZ_COSTMASTER where TICKETNUM='" + InvoiceNo + "' and RECORD_FLAG IN (0,1))";
            }

            condiction = condiction + " and hand_flag = " + (int)OPDOperationType.门诊收费 + " order by presmasterid";

            //得到实体列表
            List<HIS.Model.MZ_PresMaster> presMastList = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetListArray( condiction );
            //定义返回的处方
            Prescription[] prescriptions = new Prescription[presMastList.Count];
            for ( int i = 0 ; i < presMastList.Count ; i++ )
            {
                #region 读取处方头
                prescriptions[i].Charge_Flag = presMastList[i].Charge_Flag;
                prescriptions[i].ChargeCode = presMastList[i].ChargeCode;
                prescriptions[i].ChargeID = presMastList[i].CostMasterID;
                prescriptions[i].Drug_Flag = presMastList[i].Drug_Flag;
                prescriptions[i].ExecDeptCode = presMastList[i].ExecDeptCode;
                prescriptions[i].ExecDocCode = presMastList[i].ExecDocCode;
                prescriptions[i].OldPresID = presMastList[i].OldID;
                prescriptions[i].PresCostCode = presMastList[i].PresCostCode;
                prescriptions[i].PrescriptionID = presMastList[i].PresMasterID;
                prescriptions[i].PrescType = presMastList[i].PresType;
                prescriptions[i].PresDeptCode = presMastList[i].PresDocCode;
                prescriptions[i].PresDocCode = presMastList[i].PresDocCode;
                prescriptions[i].Record_Flag = presMastList[i].Record_Flag;
                prescriptions[i].TicketCode = presMastList[i].TicketCode;
                prescriptions[i].TicketNum = presMastList[i].TicketNum;
                prescriptions[i].Total_Fee = presMastList[i].Total_Fee;
                prescriptions[i].VisitNo = patient.VisitNo;
                #endregion
                //HIS.DAL.MZ_PresOrder mz_presorder = new HIS.DAL.MZ_PresOrder( );
                //mz_presorder._oleDB = oleDb;
                List<HIS.Model.MZ_PresOrder> presDetailList = BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetListArray( " PresMasterID = " + presMastList[i].PresMasterID + " order by order_flag" );
                //写明细
                PrescriptionDetail[] details = new PrescriptionDetail[presDetailList.Count];
                for ( int j = 0 ; j < presDetailList.Count ; j++ )
                {
                    #region 明细
                    details[j].Amount = presDetailList[j].Amount;
                    details[j].BigitemCode = presDetailList[j].BigItemCode;
                    details[j].Buy_price = presDetailList[j].Buy_Price;
                    details[j].ComplexId = presDetailList[j].CaseID;
                    details[j].DetailId = presDetailList[j].PresOrderID;
                    details[j].ItemId = presDetailList[j].ItemID;
                    details[j].Itemname = presDetailList[j].ItemName;
                    details[j].ItemType = presDetailList[j].ItemType;
                    details[j].Order_Flag = presDetailList[j].Order_Flag;
                    details[j].PassId = presDetailList[j].PassID;
                    details[j].PresAmount = presDetailList[j].PresAmount;
                    details[j].PresctionId = presDetailList[j].PresMasterID;
                    details[j].RelationNum = presDetailList[j].RelationNum;
                    details[j].Sell_price = presDetailList[j].Sell_Price;
                    details[j].Standard = presDetailList[j].Standard;
                    details[j].Tolal_Fee = presDetailList[j].Tolal_Fee;
                    details[j].Unit = presDetailList[j].Unit;
                    details[j].Drug_Flag = prescriptions[i].Drug_Flag;
                    #endregion
                }
                prescriptions[i].PresDetails = details;
            }

            return prescriptions;
        }
        /// <summary>
        /// 根据发票号获取处方
        /// </summary>
        /// <param name="patient">处方所属的病人</param>
        /// <param name="InvoiceNo">收费发票号</param>
        /// <returns>处方信息</returns>
        public Prescription[] GetPrescriptions( BasePatient patient , string InvoiceNo )
        {
            string condiction = "";
            condiction = " PatListID = " + patient.PatListID + " AND Charge_Flag = 1 AND Record_Flag = 0 And TicketNum='" + InvoiceNo + "' and hand_flag=" + (int)OPDOperationType.门诊收费;
            condiction = condiction + " order by presmasterid";

            //得到实体列表
            List<HIS.Model.MZ_PresMaster> presMastList = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetListArray( condiction );
            if ( presMastList.Count == 0 )
            {
                throw new Exception( "找不到发票信息！\r\n1、请确认发票号是否正确。\r\n2、请确认该发票是否已退费。" );
            }
            if ( presMastList.Count > 1 )
            {
                //判断发票里是否有药品
                foreach ( Model.MZ_PresMaster mz_presmaster in presMastList )
                {
                    if ( mz_presmaster.Drug_Flag == 1 )
                    {
                        throw new Exception( "该发票内有药品并且还未退药，要退费请先进行退药操作！" );
                    }
                }
            }
            else
            {
                if ( presMastList[0].Drug_Flag == 1 )
                {
                    throw new Exception( "该发票已经发药，要退费请先进行退药操作！" );
                }
            }

            //定义返回的处方
            Prescription[] prescriptions = new Prescription[presMastList.Count];
            for ( int i = 0 ; i < presMastList.Count ; i++ )
            {
                #region 读取处方头
                prescriptions[i].Charge_Flag = presMastList[i].Charge_Flag;
                prescriptions[i].ChargeCode = presMastList[i].ChargeCode;
                prescriptions[i].ChargeID = presMastList[i].CostMasterID;
                prescriptions[i].Drug_Flag = presMastList[i].Drug_Flag;
                prescriptions[i].ExecDeptCode = presMastList[i].ExecDeptCode;
                prescriptions[i].ExecDocCode = presMastList[i].ExecDocCode;
                prescriptions[i].OldPresID = presMastList[i].OldID;
                prescriptions[i].PresCostCode = presMastList[i].PresCostCode;
                prescriptions[i].PrescriptionID = presMastList[i].PresMasterID;
                prescriptions[i].PrescType = presMastList[i].PresType;
                prescriptions[i].PresDeptCode = presMastList[i].PresDocCode;
                prescriptions[i].PresDocCode = presMastList[i].PresDocCode;
                prescriptions[i].Record_Flag = presMastList[i].Record_Flag;
                prescriptions[i].TicketCode = presMastList[i].TicketCode;
                prescriptions[i].TicketNum = presMastList[i].TicketNum;
                prescriptions[i].Total_Fee = presMastList[i].Total_Fee;
                #endregion
                //HIS.DAL.MZ_PresOrder mz_presorder = new HIS.DAL.MZ_PresOrder( );
                //mz_presorder._oleDB = oleDb;
                List<HIS.Model.MZ_PresOrder> presDetailList = BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetListArray( " PresMasterID = " + presMastList[i].PresMasterID + " order by order_flag" );
                //写明细
                PrescriptionDetail[] details = new PrescriptionDetail[presDetailList.Count];
                for ( int j = 0 ; j < presDetailList.Count ; j++ )
                {
                    #region 明细
                    details[j].Amount = presDetailList[j].Amount;
                    details[j].BigitemCode = presDetailList[j].BigItemCode;
                    details[j].Buy_price = presDetailList[j].Buy_Price;
                    details[j].ComplexId = presDetailList[j].CaseID;
                    details[j].DetailId = presDetailList[j].PresOrderID;
                    details[j].ItemId = presDetailList[j].ItemID;
                    details[j].Itemname = presDetailList[j].ItemName;
                    details[j].ItemType = presDetailList[j].ItemType;
                    details[j].Order_Flag = presDetailList[j].Order_Flag;
                    details[j].PassId = presDetailList[j].PassID;
                    details[j].PresAmount = presDetailList[j].PresAmount;
                    details[j].PresctionId = presDetailList[j].PresMasterID;
                    details[j].RelationNum = presDetailList[j].RelationNum;
                    details[j].Sell_price = presDetailList[j].Sell_Price;
                    details[j].Standard = presDetailList[j].Standard;
                    details[j].Tolal_Fee = presDetailList[j].Tolal_Fee;
                    details[j].Unit = presDetailList[j].Unit;
                    #endregion
                }
                prescriptions[i].PresDetails = details;
            }

            return prescriptions;
        }
    }
}
