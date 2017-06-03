using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using HIS.Model;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 台帐写入器
    /// </summary>
    public abstract class AccountWriter:HIS.SYSTEM.Core.BaseBLL
    {
        /// <summary>
        /// 写入台帐
        /// </summary>
        /// <param name="billMaster">单据头表信息</param>
        /// <param name="orderList">单据明细信息</param>
        /// <param name="storeTable">库存处理后的最新药品库存信息</param>
        public abstract void WriteAccount(BillMaster billMaster, List<BillOrder> orderList, Hashtable storeTable);

        /// <summary>
        /// 计算余额
        /// </summary>
        /// <param name="account">台帐信息</param>
        protected abstract void ComputeFee(YP_Account account);

        /// <summary>
        /// 根据单据信息构造台帐信息
        /// </summary>
        /// <param name="billMaster">单据头</param>
        /// <param name="billOrder">单据明细信息</param>
        /// <param name="storeNum">库存处理后药品库存信息</param>
        /// <param name="accountYear">会计年份</param>
        /// <param name="accountMonth">会计月份</param>
        /// <param name="smallUnit">基本单位</param>
        /// <returns>台帐信息</returns>
        protected abstract YP_Account BuildAccount(BillMaster billMaster, BillOrder billOrder, decimal storeNum,
    int accountYear, int accountMonth, int smallUnit);

        /// <summary>
        /// 计算药品金额（药房系统）
        /// </summary>
        /// <param name="price">药品零售价</param>
        /// <param name="number">药品数量</param>
        /// <param name="unitInverse">单位比例</param>
        /// <returns>合计金额</returns>
        public static decimal YF_ComputeTotalFee(decimal price, decimal number, int unitInverse)
        {
            decimal totalFee = 0;
            int modNum = (Convert.ToInt32(number) % unitInverse);
            if (modNum == 0)
            {
                totalFee += (number / unitInverse) * price;
            }
            else
            {
                totalFee += Convert.ToDecimal((number - modNum) / unitInverse) * price;
                totalFee += (Convert.ToDecimal(modNum) / Convert.ToDecimal(unitInverse)) * price;
            }
            return totalFee;
        }

        /// <summary>
        /// 计算药品金额（药库系统）
        /// </summary>
        /// <param name="price">药品零售价</param>
        /// <param name="number">药品数量</param>
        /// <returns>合计金额</returns>
        public static decimal YK_ComputeTotalFee(decimal price, decimal number)
        {
            return number * price;
        }

    }
}
