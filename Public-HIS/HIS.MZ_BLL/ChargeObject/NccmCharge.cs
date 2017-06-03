using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MZ_BLL.Exceptions;
using HIS.Interface.Structs;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem.Core;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 农合结算对象
    /// </summary>
    public class NccmCharge : GeneralCharge
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Patient">结算的病人对象</param>
        /// <param name="OperatorId">操作员ID</param>
        public NccmCharge( OutPatient Patient , int OperatorId , ChargeType _ChargeType )
            : base( Patient, OperatorId ,_ChargeType)
        {
        }
        /// <summary>
        /// 预算
        /// </summary>
        /// <param name="prescriptions">处方对象</param>
        /// <returns>预结算信息</returns>
        public override ChargeInfo[] Budget( Prescription[] prescriptions )
        {
            ////////////////////////////////////////////////////////////////////////////////
            //处理过程
            //先由医院做预算，完成后用 病人就诊序号+处方头ID+结算头ID组合作为农合的mzId，
            //因为农合要求mzId不能重复，所以医院结算必须放在前以此产生结算头ID
            /////////////////////////////////////////////////////////////////////////////////

            //提交医院结算
            ChargeInfo[] hisChargeInfos = base.Budget( prescriptions );

            InsurChargeInfo insurChargeInfo = new InsurChargeInfo(); 
            //构造农合接口对象
            HIS.MZ_BLL.InsurInterface.IInsureCharge insureCharge = HIS.MZ_BLL.InsurInterface.InsurInterfaceFactory.CreateInsurInstance( InsurType.新农合 );
            //将包含农合信息的病人对象传给接口
            insureCharge.HisPatientInfo = Patient;            
            //预算。
            insurChargeInfo = insureCharge.PreviewCharge( prescriptions );
            //合计补偿金额
            for ( int i = 0; i < hisChargeInfos.Length; i++ )
            {
                if ( hisChargeInfos[i].ChargeID == prescriptions[i].ChargeID )
                {
                    hisChargeInfos[i].VillageFee += prescriptions[i].RedeemCost;
                }
            }
            oleDb.BeginTransaction();
            try
            {
                //回写数据库字段
                for ( int i = 0 ; i < prescriptions.Length ; i++ )
                {
                    Model.MZ_PresMaster presMaster = HIS.SYSTEM.Core.BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( prescriptions[i].PrescriptionID );
                    presMaster.RedeemCost = prescriptions[i].RedeemCost;
                    HIS.SYSTEM.Core.BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( presMaster ); //更新处方头的补偿金额
                }
                oleDb.CommitTransaction( );
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
                throw new Exception("农合收费预算发生错误！");
            }
            return hisChargeInfos;
        }
        /// <summary>
        /// 正式结算
        /// </summary>
        /// <param name="BudgetaryChargeInfos">预结算信息，一般调用预算方法后返回该信息</param>
        /// <param name="prescriptions">处方信息</param>
        /// <returns></returns>
        public override bool Charge( ChargeInfo[] BudgetaryChargeInfos , Prescription[] prescriptions , out BaseInvoice[] ChargeInvoicies )
        {
            string errMsg = "新农合接口发生错误！";
            //构造农合接口对象
            HIS.MZ_BLL.InsurInterface.IInsureCharge insureCharge = HIS.MZ_BLL.InsurInterface.InsurInterfaceFactory.CreateInsurInstance( InsurType.新农合 );
            //将包含农合信息的病人对象传给接口
            insureCharge.HisPatientInfo = Patient;

            try
            {
                object result;
                bool success = insureCharge.Charge( prescriptions , out result );
                CompData[] compData = (CompData[])result;//获得补偿结果
                errMsg = "";
                //调用接口正式结算新农合
                if ( success )
                {
                    try
                    {
                        success = base.Charge( BudgetaryChargeInfos , prescriptions ,out  ChargeInvoicies );
                        //在结算信息中加入补偿结果以返回
                        for ( int i = 0 ; i < compData.Length ; i++ )
                        {
                            if ( compData[i].bill_no == BudgetaryChargeInfos[i].ChargeID.ToString( ) )
                            {
                                BudgetaryChargeInfos[i].compData = new System.Data.DataTable( );
                                #region ...
                                BudgetaryChargeInfos[i].compData.Columns.Add( "医疗证号" );
                                BudgetaryChargeInfos[i].compData.Columns.Add( "户主姓名" );
                                BudgetaryChargeInfos[i].compData.Columns.Add( "就医机构名称" );
                                BudgetaryChargeInfos[i].compData.Columns.Add( "就医机构级别" );
                                BudgetaryChargeInfos[i].compData.Columns.Add( "就诊日期" );
                                BudgetaryChargeInfos[i].compData.Columns.Add( "补偿类别" );
                                BudgetaryChargeInfos[i].compData.Columns.Add( "补偿方案" );
                                BudgetaryChargeInfos[i].compData.Columns.Add( "门诊费用小计" , Type.GetType( "System.Decimal" ) );
                                BudgetaryChargeInfos[i].compData.Columns.Add( "药费" , Type.GetType( "System.Decimal" ) );
                                BudgetaryChargeInfos[i].compData.Columns.Add( "核算补偿额" , Type.GetType( "System.Decimal" ) );
                                BudgetaryChargeInfos[i].compData.Columns.Add( "实际补偿" , Type.GetType( "System.Decimal" ) );
                                BudgetaryChargeInfos[i].compData.Columns.Add( "领款人签名" );
                                #endregion
                                System.Data.DataRow dr = BudgetaryChargeInfos[i].compData.NewRow( );
                                dr["医疗证号"] = insureCharge.HisPatientInfo.InsurInfo.Medcard_Id;
                                dr["户主姓名"] = insureCharge.HisPatientInfo.InsurInfo.Name;
                                dr["就医机构名称"] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                                dr["就医机构级别"] = insureCharge.HisPatientInfo.InsurInfo.Medorg_Level;
                                dr["就诊日期"] = insureCharge.HisPatientInfo.CureDate;
                                dr["补偿类别"] = "门诊";
                                dr["补偿方案"] = "";
                                dr["门诊费用小计"] = BudgetaryChargeInfos[i].TotalFee;
                                dr["药费"] = Convert.ToDecimal( compData[i].comp_drugfee );
                                dr["核算补偿额"] = Convert.ToDecimal( compData[i].comp_treatfee );
                                dr["实际补偿"] = Convert.ToDecimal( compData[i].comp_money );
                                dr["领款人签名"] = "";
                                BudgetaryChargeInfos[i].compData.Rows.Add( dr );
                            }
                        }
                    }
                    catch ( OperatorException operr )
                    {
                        throw new OperatorException( "新农合正式补偿成功，医院结算失败！\r\n原因" + operr.Message );
                    }
                    catch ( Exception interfaceErr )
                    {
                        throw interfaceErr;
                    }
                }
                else
                {
                    throw new OperatorException( "新农合补偿不成功！" );
                }
                return false;
            }
            catch ( OperatorException Operr )
            {
                throw Operr;
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Message );
                throw new Exception( "新农合结算发生错误！" );
            }
        }
        /// <summary>
        /// 取消预算，终止收费
        /// </summary>
        /// <returns></returns>
        public override bool AbortBudget()
        {
            return base.AbortBudget();
        }
        /// <summary>
        /// 退费
        /// </summary>
        /// <param name="invoice">要退费的发票对象</param>
        /// <returns></returns>
        public override bool Refundment( Invoice invoice, Prescription[] ReblancePrescriptions, List<int> ReturnedDocPresIdList )
        {

            //根据发票获得原始收费处方
            Prescription[] prescription = Patient.GetPrescriptionByInvoiceSerialNo( invoice.InvoiceNo );

            MZ_BLL.InsurInterface.IInsureCharge insurCharge = InsurInterface.InsurInterfaceFactory.CreateInsurInstance( InsurType.新农合 );
            //设置农合结算对象的病人信息
            insurCharge.HisPatientInfo = Patient;
            //原始处方
            Prescription orgPrescription = invoice.Prescription[0];
            //先处理医院退费操作，因为农合需要医院端的退费冲正信息
            bool bOk = false;
            try
            {
                bOk = base.Refundment( invoice ,null,null);
            }
            catch ( OperatorException operr )
            {
                throw operr;
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Message );
                throw new Exception( "医院退费发生错误！" );
            }

            if ( !bOk )
                return false;

            
            
            //冲正处方
            Prescription disChargePrescription = GetDisChargePrescription( invoice.Prescription[0].PrescriptionID );

            insurCharge.CancelCharge( orgPrescription, disChargePrescription );

            return false;
        }
        /// <summary>
        /// 得到冲正的处方
        /// </summary>
        /// <param name="orgPrescriptionId">被冲处方的ID</param>
        /// <returns></returns>
        private Prescription GetDisChargePrescription(int orgPrescriptionId)
        {
            Prescription _prescription = new Prescription();
            #region ...
            HIS.Model.MZ_PresMaster model_mz_presmaster = new HIS.Model.MZ_PresMaster();
            //红冲的处方头
            model_mz_presmaster = HIS.SYSTEM.Core.BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( "OLDID=" + orgPrescriptionId );
            if ( model_mz_presmaster == null )
                throw new OperatorException( "没有找到冲正的处方记录!" );
            _prescription.Charge_Flag = model_mz_presmaster.Charge_Flag;
            _prescription.ChargeCode = model_mz_presmaster.ChargeCode;
            _prescription.ChargeID = model_mz_presmaster.CostMasterID;
            _prescription.Drug_Flag = model_mz_presmaster.Drug_Flag;
            _prescription.ExecDeptCode = model_mz_presmaster.ExecDeptCode;
            _prescription.ExecDocCode = model_mz_presmaster.ExecDocCode;
            _prescription.OldPresID = model_mz_presmaster.OldID;
            _prescription.PresCostCode = model_mz_presmaster.PresCostCode;
            _prescription.PrescriptionID = model_mz_presmaster.PresMasterID;
            _prescription.PrescType = model_mz_presmaster.PresType;
            _prescription.PresDeptCode = model_mz_presmaster.PresDocCode;
            _prescription.PresDocCode = model_mz_presmaster.PresDocCode;
            _prescription.Record_Flag = model_mz_presmaster.Record_Flag;
            _prescription.TicketCode = model_mz_presmaster.TicketCode;
            _prescription.TicketNum = model_mz_presmaster.TicketNum;
            _prescription.Total_Fee = model_mz_presmaster.Total_Fee;

            List<HIS.Model.MZ_PresOrder> orders = HIS.SYSTEM.Core.BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetListArray( "PresmasterID=" + model_mz_presmaster.PresMasterID );
            PrescriptionDetail[] details = new PrescriptionDetail[orders.Count];
            for ( int j = 0; j < orders.Count; j++ )
            {
                #region 明细
                details[j].Amount = orders[j].Amount;
                details[j].BigitemCode = orders[j].BigItemCode;
                details[j].Buy_price = orders[j].Buy_Price;
                details[j].ComplexId = orders[j].CaseID;
                details[j].DetailId = orders[j].PresOrderID;
                details[j].ItemId = orders[j].ItemID;
                details[j].Itemname = orders[j].ItemName;
                details[j].ItemType = orders[j].ItemType;
                details[j].Order_Flag = orders[j].Order_Flag;
                details[j].PassId = orders[j].PassID;
                details[j].PresAmount = orders[j].PresAmount;
                details[j].PresctionId = orders[j].PresMasterID;
                details[j].RelationNum = orders[j].RelationNum;
                details[j].Sell_price = orders[j].Sell_Price;
                details[j].Standard = orders[j].Standard;
                details[j].Tolal_Fee = orders[j].Tolal_Fee;
                details[j].Unit = orders[j].Unit;
                #endregion
            }
            _prescription.PresDetails = details;
            #endregion
            return _prescription;
        }
    }
}
