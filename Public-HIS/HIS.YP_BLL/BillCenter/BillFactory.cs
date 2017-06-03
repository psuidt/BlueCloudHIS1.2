using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 单据处理器创建工厂
    /// </summary>
    public class BillFactory
    {
        private static BillProcessor newProcessor;
        private static BillQuery billQuery;
        BillFactory()
        {            
        }
        
        /// <summary>
        /// 创建业务单据处理器
        /// </summary>
        /// <param name="opType">业务类型</param>
        /// <returns>新创建的单据处理器</returns>
        static public BillProcessor GetProcessor(string opType)
        {
            switch (opType)
            {
                case ConfigManager.OP_YF_ADJPRICE:
                    newProcessor = new AdjpriceProcessor();
                    break;
                case ConfigManager.OP_YF_APPLYIN:
                    newProcessor = new ApplyInProcessor();
                    break;
                case ConfigManager.OP_YF_PJDB:
                    newProcessor = new ApplyInProcessor();
                    break;
                case ConfigManager.OP_YF_CHECK:
                    newProcessor = new YF_CheckPorcessor();
                    break;
                case ConfigManager.OP_YF_DEPTDRAW:
                    newProcessor = new YF_OutstoreProcessor();
                    break;
                case ConfigManager.OP_YF_DISPENSE+"MZ":
                    newProcessor = new MZ_DispProcessor();
                    break;
                case ConfigManager.OP_YF_DISPENSE+"ZY":
                    newProcessor = new ZY_DispProcessor();
                    break;
                case ConfigManager.OP_YF_DISPENSE+"ZY_ECONOMY":
                    newProcessor = new ZY_DispEconomy();
                    break;
                case ConfigManager.OP_YF_INSTORE:
                    newProcessor = new YF_InstoreProcessor();
                    break;
                case ConfigManager.OP_YF_REPORTLOSS:
                    newProcessor = new YF_OutstoreProcessor();
                    break;
                case ConfigManager.OP_YF_REFUND+"MZ":
                    newProcessor = new MZ_Refund();
                    break;
                case ConfigManager.OP_YF_REFUND+"ZY":
                    newProcessor = new ZY_Refund();
                    break;
                case ConfigManager.OP_YK_ADJPRICE:
                    newProcessor = new AdjpriceProcessor();
                    break;
                case ConfigManager.OP_YK_CHECK:
                    newProcessor = new YK_CheckPorcessor();
                    break;
                case ConfigManager.OP_YK_DEPTDRAW:
                    newProcessor = new YK_OutstoreProcessor();
                    break;
                case ConfigManager.OP_YK_INOPTYPE:
                    newProcessor = new YK_InstoreProcessor();
                    break;
                case ConfigManager.OP_YK_FIRSTIN:
                    newProcessor = new YK_InstoreProcessor();
                    break;
                case ConfigManager.OP_YK_BACKSTORE:
                    newProcessor = new YK_BackStoreProcessor();
                    break;
                case ConfigManager.OP_YK_OUTTOYF:
                    newProcessor = new YK_OutstoreProcessor();
                    break;
                case ConfigManager.OP_YK_REPORTLOSS:
                    newProcessor = new YK_OutstoreProcessor();
                    break;
                case ConfigManager.OP_YK_STOCKPLAN:
                    newProcessor = new StockPlanProcessor();
                    break;
                default:
                    return null;
            }
            return newProcessor;
        }

        /// <summary>
        /// 创建单据查询对象
        /// </summary>
        /// <param name="opType">业务类型</param>
        /// <returns>单据查询处理器</returns>
        public static BillQuery GetQuery(string opType)
        {
            switch (opType)
            {
                case ConfigManager.OP_YF_ADJPRICE:
                    billQuery = new AdjBillQuery();
                    break;
                case ConfigManager.OP_YF_APPLYIN:
                    billQuery = new YF_ApplyQuery();
                    break;
                case ConfigManager.OP_YF_CHECK:
                    billQuery = new YF_CheckBillQuery();
                    break;
                case ConfigManager.DEF_YF_OUT:
                    billQuery = new YF_OutstoreQuery();
                    break;
                case ConfigManager.OP_YF_DISPENSE:
                    billQuery = new DispRefQuery();
                    break;
                case ConfigManager.OP_YF_DISPENSE + "ZY_TL":
                    billQuery = new ZY_DeptDispQuery();
                    break;
                case ConfigManager.OP_YF_INSTORE:
                    billQuery = new YF_InstoreQuery();
                    break;
                case ConfigManager.OP_YF_REFUND:
                    billQuery = new DispRefQuery();
                    break;
                case ConfigManager.OP_YK_ADJPRICE:
                    billQuery = new AdjBillQuery();
                    break;
                case ConfigManager.OP_YK_CHECK:
                    billQuery = new YK_CheckBillQuery();
                    break;
                case ConfigManager.DEF_YK_OUT:
                    billQuery = new YK_OutstoreQuery();
                    break;
                case ConfigManager.OP_YK_INOPTYPE:
                    billQuery = new YK_IntstoreQuery();
                    break;
                case ConfigManager.OP_YK_STOCKPLAN:
                    billQuery = new StockPlanQuery();
                    break;
                default:
                    return null;
            }
            return billQuery;
        }
    }
}
