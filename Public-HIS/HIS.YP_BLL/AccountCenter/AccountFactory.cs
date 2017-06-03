using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 台帐查询处理器创建工厂
    /// </summary>
    public class AccountFactory
    {
        private static AccountQuery accountQuery;
        private static AccountWriter accountWriter;
        private static MonthBalanceProcessor monthBalancer;

        /// <summary>
        /// 构造台帐写入器
        /// </summary>
        /// <param name="opType">台帐业务类型</param>
        /// <returns>台帐写入器</returns>
        public static AccountWriter GetWriter(string opType)
        {
            switch (opType)
            {
                case ConfigManager.OP_YF_ADJPRICE:
                    accountWriter = new AdjPriceAccount();
                    break;
                case ConfigManager.OP_YF_APPLYIN:
                    accountWriter = new YF_InstoreAccount();
                    break;
                case ConfigManager.OP_YF_CHECK:
                    accountWriter = new YF_CheckAccount();
                    break;
                case ConfigManager.OP_YF_DEPTDRAW:
                    accountWriter = new YF_OutStoreAccount();
                    break;
                case ConfigManager.OP_YF_DISPENSE:
                    accountWriter = new DispenseAccount();
                    break;
                case ConfigManager.OP_YF_INSTORE:
                    accountWriter = new YF_InstoreAccount();
                    break;
                case ConfigManager.OP_YF_REPORTLOSS:
                    accountWriter = new YF_OutStoreAccount();
                    break;
                case ConfigManager.OP_YF_REFUND:
                    accountWriter = new RefundAccount();
                    break;
                case ConfigManager.OP_YK_ADJPRICE:
                    accountWriter = new AdjPriceAccount();
                    break;
                case ConfigManager.OP_YK_CHECK:
                    accountWriter = new YK_CheckAccount();
                    break;
                case ConfigManager.OP_YK_DEPTDRAW:
                    accountWriter = new YK_OutStoreAccount();
                    break;
                case ConfigManager.OP_YK_INOPTYPE:
                    accountWriter = new YK_InstoreAccount();
                    break;
                case ConfigManager.OP_YK_BACKSTORE:
                    accountWriter = new YK_BackStoreAccount();
                    break;
                case ConfigManager.OP_YK_OUTTOYF:
                    accountWriter = new YK_OutStoreAccount();
                    break;
                case ConfigManager.OP_YK_REPORTLOSS:
                    accountWriter = new YK_OutStoreAccount();
                    break;
                case ConfigManager.OP_YK_FIRSTIN:
                    accountWriter = new YK_InstoreAccount();
                    break;
                default:
                    return null;
            }
            return accountWriter;
        }

        /// <summary>
        /// 构造账务查询器
        /// </summary>
        /// <param name="belongSystem">所属系统（药房，药库系统）</param>
        /// <returns>账务查询器</returns>
        public static AccountQuery GetQuery(string belongSystem)
        {
            switch (belongSystem)
            {
                case ConfigManager.YF_SYSTEM:
                    accountQuery = new YF_AccountQuery();
                    break;
                case ConfigManager.YK_SYSTEM:
                    accountQuery = new YK_AccountQuery();
                    break;
                default:
                    return null;
            }
            return accountQuery;
        }

        /// <summary>
        /// 构造月结处理器
        /// </summary>
        /// <param name="belongSystem">所属系统（药房，药库系统）</param>
        /// <returns>月结处理器</returns>
        public static MonthBalanceProcessor GetMonthBalancer(string belongSystem)
        {
            switch (belongSystem)
            {
                case ConfigManager.YF_SYSTEM:
                    monthBalancer = new YF_MonthBalance();
                    break;
                case ConfigManager.YK_SYSTEM:
                    monthBalancer = new YK_MonthBalance();
                    break;
                default:
                    return null;
            }
            return monthBalancer;
        }
    }
}
