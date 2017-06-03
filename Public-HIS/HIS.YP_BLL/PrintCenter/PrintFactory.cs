using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 单据打印工厂
    /// </summary>
    public class PrintFactory
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PrintFactory()
        { 
        }
        private static YP_Printer printer;

        /// <summary>
        /// 获取单据打印对象
        /// </summary>
        /// <param name="opType">单据类型</param>
        /// <returns>单据打印对象</returns>
        public static YP_Printer GetPrinter(string opType)
        {
            switch (opType)
            {
                //药房申请入库
                case ConfigManager.OP_YF_APPLYIN:
                    printer = new InStorePrint();
                    break;
                //药房盘点单
                case ConfigManager.OP_YF_CHECK:
                    printer = new CheckPrint();
                    break;
                //药房科室出库
                case ConfigManager.OP_YF_DEPTDRAW:
                    printer = new OutStorePrint();
                    break;
                //药房门诊发药单
                case ConfigManager.OP_YF_DISPENSE+"MZ":
                    printer = new MZDispPrint();
                    break;
                //药房住院统领
                case ConfigManager.OP_YF_DISPENSE+"ZY_TL":
                    printer = new ZYMultiPrint();
                    break;
                //药房住院摆药
                case ConfigManager.OP_YF_DISPENSE+"ZY_BY":
                    printer = new ZYSinglePrint();
                    break;
                //药房期初入库
                case ConfigManager.OP_YF_INSTORE:
                    printer = new InStorePrint();
                    break;
                //药房报损出库
                case ConfigManager.OP_YF_REPORTLOSS:
                    printer = new OutStorePrint();
                    break;
                //药房门诊退药
                case ConfigManager.OP_YF_REFUND+"MZ":
                    printer = new MZRefundPrint();
                    break;
                //药房住院退药
                case ConfigManager.OP_YF_REFUND+"ZY":
                    printer = new ZYRefundPint();
                    break;
                //药库调价单
                case ConfigManager.OP_YK_ADJPRICE:
                    printer = new AdjPricePrint();
                    break;
                //药库盘点单
                case ConfigManager.OP_YK_CHECK:
                    printer = new CheckPrint();
                    break;
                //药库空盘点单
                case ConfigManager.OP_YK_CHECK+"EMPTY":
                    printer = new CheckEmptyPrint();
                    break;
                //药库科室出库
                case ConfigManager.OP_YK_DEPTDRAW:
                    printer = new OutStorePrint();
                    break;
                //药库采购/期初入库
                case ConfigManager.OP_YK_INOPTYPE:
                    printer = new InStorePrint();
                    break;
                //药库出库（到药房）单
                case ConfigManager.OP_YK_OUTTOYF:
                    printer = new OutStorePrint();
                    break;
                //药库报损出库单
                case ConfigManager.OP_YK_REPORTLOSS:
                    printer = new OutStorePrint();
                    break;
                //药库采购计划
                case ConfigManager.OP_YK_STOCKPLAN:
                    printer = new StockPlanPrint();
                    break;
                //进销存
                case "IOS_Report":
                    printer = new IOSPrint();
                    break;
                //明细账
                case "Account_Report":
                    printer = new AccountOrderPrint();
                    break;
                case "Support_Report":
                    printer = new SupportPrinter();
                    break;
                default:
                    return null;
            }
            return printer;
        }
    }
}
