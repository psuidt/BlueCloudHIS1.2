using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Interface.Structs;

namespace HIS.MZ_BLL.InsurInterface
{
    /// <summary>
    /// 医保、农合结算接口定义
    /// </summary>
    public interface  IInsureCharge
    {
        /// <summary>
        /// 
        /// </summary>
        HIS.MZ_BLL.OutPatient HisPatientInfo
        {
            get;
            set;
        }
        /// <summary>
        /// 得到医保、农合病人信息
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        InsurPatientInfo[] GetPatientInfo(string[] parameters);
        /// <summary>
        /// 上传处方(农合不用，上传数据在预算或结算的时候提交)
        /// </summary>
        /// <param name="prescriptions">要上传的处方</param>
        /// <param name="RedeemingMoney">返回的补偿金额</param>
        /// <returns></returns>
        bool UploadPrescription( Prescription[] prescriptions , out decimal RedeemingMoney );
        /// <summary>
        /// 预结算
        /// </summary>
        /// <param name="prescriptions">需要计算的处方</param>
        /// <returns></returns>
        InsurChargeInfo PreviewCharge( Prescription[] prescriptions );
        /// <summary>
        /// 正式结算
        /// </summary>
        /// <param name="prescriptions">需要结算的处方</param>
        /// <param name="Result">返回的信息</param>
        /// <returns></returns>
        bool Charge( Prescription[] prescriptions, out object Result );
        /// <summary>
        /// 取消结算
        /// </summary>
        /// <param name="newPrescription">用于冲正的处方</param>
        /// <param name="oldPrescription">原始处方信息</param>
        /// <returns></returns>
        bool CancelCharge(Prescription oldPrescription,Prescription newPrescription);
     
    }
}
