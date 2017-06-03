using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL
{
    /// <summary>
    /// 病人费用
    /// </summary>
    public struct PatFee
    {
        /// <summary>
        /// 预交金
        /// </summary>
        public decimal chargeFee;
        /// <summary>
        /// 记账费用
        /// </summary>
        public decimal costFee;
        
        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal faoverFee;
        /// <summary>
        /// 记账金额（农合、医保等）
        /// </summary>
        public decimal villageFee;
        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal selfFee;

        /// <summary>
        /// 余额
        /// </summary>
        public decimal surplusFee;
        /// <summary>
        /// 退费
        /// </summary>
        public decimal retreatFee;
        /// <summary>
        /// 补收
        /// </summary>
        public decimal receiveFee;
    }
    /// <summary>
    /// 病人费用操作
    /// </summary>
    public class Op_PatFee
    {
        /// <summary>
        /// 设置农合费用
        /// </summary>
        /// <param name="patFee"></param>
        /// <param name="villageFee"></param>
        public static void SetvillageFee(ref PatFee patFee, decimal villageFee)
        {
            patFee.selfFee += patFee.villageFee;
            patFee.villageFee = villageFee;
            patFee.selfFee -= patFee.villageFee;

            patFee.surplusFee = patFee.chargeFee - patFee.selfFee;
            patFee.receiveFee = patFee.surplusFee < 0 ? (0 - patFee.surplusFee) : 0;
            patFee.retreatFee = patFee.surplusFee >= 0 ? patFee.surplusFee : 0;
        }

        /// <summary>
        /// 设置优惠费用
        /// </summary>
        /// <param name="patFee"></param>
        /// <param name="villageFee"></param>
        public static void SetfaoverFee(ref PatFee patFee, decimal faoverFee)
        {
            patFee.selfFee += patFee.faoverFee;
            patFee.faoverFee = faoverFee;
            patFee.selfFee -= patFee.faoverFee;

            patFee.surplusFee = patFee.chargeFee - patFee.selfFee;
            patFee.receiveFee = patFee.surplusFee < 0 ? (0 - patFee.surplusFee) : 0;
            patFee.retreatFee = patFee.surplusFee >= 0 ? patFee.surplusFee : 0;
        }

    }
    /// <summary>
    /// 交款费用
    /// </summary>
    public struct AccountFee
    {
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal Tol_Fee;
        /// <summary>
        /// 上缴金额（现金+POS）
        /// </summary>
        public decimal Account_Fee;
        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal Faover_Fee;
        /// <summary>
        /// 记账金额
        /// </summary>
        public decimal Village_Fee;
        /// <summary>
        /// 结欠金额(总金额-预交金-（现金+POS）)
        /// </summary>
        public decimal Arrears_Fee;
    }
    /// <summary>
    /// 上缴金额
    /// </summary>
    public struct AccountMenoyFee
    {
        /// <summary>
        /// 现金
        /// </summary>
        public decimal Cash_Fee;
        /// <summary>
        /// POS
        /// </summary>
        public decimal POS_Fee;
    }


    
}
