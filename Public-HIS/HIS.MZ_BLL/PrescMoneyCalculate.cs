using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using HIS.Interface;
using HIS.SYSTEM.Core;

namespace HIS.MZ_BLL
{
    
    /// <summary>
    /// 处方金额处理器
    /// </summary>
    public class PrescMoneyCalculate : BaseBLL, IPrescMoneyCalculate
    {
        /// <summary>
        /// 舍入类型
        /// </summary>
        private int roundType = -999;
        /// <summary>
        /// 保留小数位
        /// </summary>
        private int digits = 1;
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="htBigitemFee">大项目明细，返回值</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney(IPresDetail[] PrescDetails, 
            out Hashtable htBigitemFee , out decimal roundingMoney)
        {
            htBigitemFee = new Hashtable();
            for ( int i = 0 ; i < PrescDetails.Length ; i++ )
            {
                //将明细按大项目分组
                string bigitemcode = PrescDetails[i].BigItemCode.Trim();
                if ( htBigitemFee.ContainsKey( bigitemcode ) )
                {
                    object obj = htBigitemFee[bigitemcode];
                    decimal total = PrescDetails[i].Money + Convert.ToDecimal( obj );
                    htBigitemFee.Remove( bigitemcode );
                    htBigitemFee.Add( bigitemcode , total );
                }
                else
                {
                    htBigitemFee.Add( bigitemcode , PrescDetails[i].Money );
                }
            }
            //进行四舍五入
            
            roundingMoney = 0;
            decimal presTotalFee = 0;
            Hashtable new_htBigitem = new Hashtable();
            foreach ( object obj in htBigitemFee )
            {
                string bigitemcode = ( (DictionaryEntry)obj ).Key.ToString().Trim();
                decimal fee1 = Convert.ToDecimal( ( (DictionaryEntry)obj ).Value );
                decimal tempFee = ConvertToDoubleDigit( fee1 );

                decimal fee2 = Decimal.Round( ( tempFee + (decimal)0.00000000000000000001 ) , digits );
                //Begin 2010-01-20 王志
                roundType = GetRoundType();
                if (roundType == (int)RoundType.逢分进位)
                {
                    if ((fee2 - fee1) < 0)
                    {
                        //舍入后的金额减去实际金额小于0，则表示有舍去金额，需要进位
                        if (digits == 0)
                        {
                            fee2 = fee2 + 1M;
                        }
                        else if (digits == 1)
                        {
                            fee2 = fee2 + 0.1M;
                        }
                        else if (digits == 2)
                        {
                            fee2 = fee2 + 0.01M;
                        }
                    }
                }
                //End   2010-01-20 王志

                if ( fee2 == 0 )
                    fee2 = 0.1M;
                decimal roundFee = fee2 - fee1;

                roundingMoney = roundingMoney + roundFee;
                presTotalFee = presTotalFee + fee2;

                new_htBigitem.Add( bigitemcode , fee2 );
            }
            htBigitemFee = new_htBigitem;
            return presTotalFee;
        }
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney(IPresDetail[] PrescDetails,  out decimal roundingMoney)
        {
            Hashtable htBigitemFee;
            return GetPrescriptionTotalMoney( PrescDetails , out htBigitemFee ,  out roundingMoney );
        }
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney( IPresDetail[] PrescDetails )
        {
            Hashtable htBigitemFee;
            decimal roundingMoney;
            return GetPrescriptionTotalMoney(PrescDetails,  out htBigitemFee, out roundingMoney);
        }
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="htBigitemFee">大项目明细，返回值</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney(List<IPresDetail> PrescDetails, 
            out Hashtable htBigitemFee , out decimal roundingMoney )
        {
            return GetPrescriptionTotalMoney(PrescDetails.ToArray(),  out htBigitemFee, out roundingMoney);
        }
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <param name="roundingMoney">舍入金额，返回值</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney(List<IPresDetail> PrescDetails,  out decimal roundingMoney)
        {
            Hashtable htBigitemFee;
            return GetPrescriptionTotalMoney(PrescDetails.ToArray(),  out htBigitemFee, out roundingMoney);
        }
        /// <summary>
        /// 按处方明细计算处方金额
        /// </summary>
        /// <param name="PrescDetails">处方明细</param>
        /// <returns>四舍五入后的处方总金额</returns>
        public decimal GetPrescriptionTotalMoney( List<IPresDetail> PrescDetails )
        {
            Hashtable htBigitemFee;
            decimal roundingMoney;
            return GetPrescriptionTotalMoney(PrescDetails.ToArray(),  out htBigitemFee, out roundingMoney);
        }
        /// <summary>
        /// 将多位的小数转换为2位的小数
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        private decimal ConvertToDoubleDigit( decimal Value )
        {
            string temp = ( (double)Value ).ToString( "" );
            decimal digitValue = Convert.ToDecimal( temp );
            int digit = temp.Length - temp.IndexOf( "." ) - 1;
            while ( digit > 2 )
            {
                digitValue = Decimal.Round( digitValue + (decimal)0.000000001 , digit - 1 );
                digit--;
            }

            return digitValue;
        }
        /// <summary>
        /// 从参数表获取设置的取舍方式
        /// </summary>
        /// <returns></returns>
        private int GetRoundType()
        {
            if ( roundType == -999 )
            {
                string sql = oleDb.Table(HIS.BLL.Tables.MZ_CONFIG, "",
                                            HIS.BLL.Tables.mz_config.CODE + oleDb.EuqalTo() + "'020'",
                                            HIS.BLL.Tables.mz_config.VALUE);

                object obj = oleDb.GetDataResult(sql);

                if (obj == null || Convert.IsDBNull(obj))
                {
                    throw new Exception("获取门诊参数020发生错误");
                }
                else
                {
                    roundType = Convert.ToInt32(obj);
                }
            }
            
            return roundType;
            
        }
    }
}
