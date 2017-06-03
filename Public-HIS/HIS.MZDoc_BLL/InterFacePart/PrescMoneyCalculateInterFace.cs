using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HIS.MZDoc_BLL.InterFace
{
    /// <summary>
    /// 处方金额计算接口
    /// </summary>
    public class PrescMoneyCalculateInterFace : IBaseInterFace
    {
        HIS.Interface.IPrescMoneyCalculate instance;
        /// <summary>
        /// 处方金额计算接口
        /// </summary>
        public PrescMoneyCalculateInterFace()
        {
            instance = HIS.Interface.InstanceFactory.CreatPrescMoneyCalculate();
        }
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="htBigitemFee">大项目明细，返回值</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney(Prescription[] PrescDetails, out Hashtable htBigitemFee, out decimal roundingMoney)
        {
            return instance.GetPrescriptionTotalMoney(PrescDetails, out htBigitemFee, out roundingMoney);
        }

        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney(Prescription[] PrescDetails, out decimal roundingMoney)
        {
            return instance.GetPrescriptionTotalMoney(PrescDetails, out roundingMoney);
        }

        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney(HIS.Interface.IPresDetail[] PrescDetails)
        {
            return instance.GetPrescriptionTotalMoney(PrescDetails);
        }

        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="htBigitemFee">大项目明细，返回值</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney(List<Prescription> PrescDetails, out Hashtable htBigitemFee, out decimal roundingMoney)
        {
            return instance.GetPrescriptionTotalMoney(PrescDetails.Cast<Prescription>().ToArray(), out htBigitemFee, out roundingMoney);
        }

        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney(List<Prescription> PrescDetails, out decimal roundingMoney)
        {
            return instance.GetPrescriptionTotalMoney(PrescDetails.Cast<Prescription>().ToArray(), out roundingMoney);
        }

        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney(List<Prescription> PrescDetails)
        {
            return instance.GetPrescriptionTotalMoney(PrescDetails.Cast<Prescription>().ToArray());
        }
    }
}
