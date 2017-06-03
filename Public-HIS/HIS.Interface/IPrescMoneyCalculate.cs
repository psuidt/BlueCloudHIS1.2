using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HIS.Interface
{
    /// <summary>
    /// 处方金额计算类
    /// </summary>
    public interface IPrescMoneyCalculate
    {
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="htBigitemFee">大项目明细，返回值</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        decimal GetPrescriptionTotalMoney( IPresDetail[] PrescDetails, out Hashtable htBigitemFee, out decimal roundingMoney );
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        decimal GetPrescriptionTotalMoney( IPresDetail[] PrescDetails, out decimal roundingMoney );
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <returns>四舍五入后的处方总金额</returns>
        decimal GetPrescriptionTotalMoney( IPresDetail[] PrescDetails );
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="htBigitemFee">大项目明细，返回值</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        decimal GetPrescriptionTotalMoney( List<IPresDetail> PrescDetails, out Hashtable htBigitemFee, out decimal roundingMoney );
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        decimal GetPrescriptionTotalMoney( List<IPresDetail> PrescDetails, out decimal roundingMoney );
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <returns>四舍五入后的处方总金额</returns>
        decimal GetPrescriptionTotalMoney( List<IPresDetail> PrescDetails );
    }
}
