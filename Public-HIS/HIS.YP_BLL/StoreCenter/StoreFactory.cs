using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 库存处理器构造工厂
    /// </summary>
    public class StoreFactory
    {
        /// <summary>
        /// 库存处理器
        /// </summary>
        static private StoreProcessor _storeProcessor;
        /// <summary>
        /// 库存查询器
        /// </summary>
        static private StoreQuery _storeQuery;
        /// <summary>
        /// 构造函数
        /// </summary>
        public StoreFactory()
        {
        }
        /// <summary>
        /// 创建库存处理器
        /// </summary>
        /// <param name="opType">业务类型</param>
        /// <returns>库存处理器</returns>
        static public StoreProcessor GetProcessor(string opType)
        {
            switch (opType)
            {
                case ConfigManager.OP_YF_ADJPRICE:
                    throw new Exception("对象错误引用");
                case ConfigManager.OP_YF_APPLYIN:
                    _storeProcessor = new YF_In_StoreProcessor();
                    break;
                case ConfigManager.OP_YF_CHECK:
                    _storeProcessor = new YF_Check_StoreProcessor();
                    break;
                case ConfigManager.OP_YF_DEPTDRAW:
                    _storeProcessor = new YF_Out_StoreProcessor();
                    break;
                case ConfigManager.OP_YF_DISPENSE:
                    _storeProcessor = new Disp_StoreProcessor();
                    break;
                case ConfigManager.OP_YF_INSTORE:
                    _storeProcessor = new YF_In_StoreProcessor();
                    break;
                case ConfigManager.OP_YK_FIRSTIN:
                    _storeProcessor = new YK_In_StoreProcessor();
                    break;
                case ConfigManager.OP_YF_REPORTLOSS:
                    _storeProcessor = new YF_Out_StoreProcessor();
                    break;
                case ConfigManager.OP_YF_REFUND:
                    _storeProcessor = new Ref_StoreProcessor();
                    break;
                case ConfigManager.OP_YK_ADJPRICE:
                    throw new Exception("对象引用错误");
                case ConfigManager.OP_YK_CHECK:
                    _storeProcessor = new YK_Check_StoreProcessor();
                    break;
                case ConfigManager.OP_YK_DEPTDRAW:
                    _storeProcessor = new YK_Out_StoreProcessor();
                    break;
                case ConfigManager.OP_YK_INOPTYPE:
                    _storeProcessor = new YK_In_StoreProcessor();
                    break;
                case ConfigManager.OP_YK_OUTTOYF:
                    _storeProcessor = new YK_Out_StoreProcessor();
                    break;
                case ConfigManager.OP_YK_REPORTLOSS:
                    _storeProcessor = new YK_Out_StoreProcessor();
                    break;
                case ConfigManager.OP_YK_BACKSTORE:
                    _storeProcessor = new YK_Back_StoreProcessor();
                    break;
                case ConfigManager.YK_SYSTEM:
                    _storeProcessor = new YK_In_StoreProcessor();
                    break;
                case ConfigManager.YF_SYSTEM:
                    _storeProcessor = new YF_In_StoreProcessor();
                    break;
                default:
                    return null;
            }
            return _storeProcessor;
        }

        /// <summary>
        /// 创建库存查询器
        /// </summary>
        /// <param name="belongSystem">所属系统（药房还是药库）</param>
        /// <returns>库存查询器</returns>
        static public StoreQuery GetQuery(string belongSystem)
        {
            switch (belongSystem)
            {
                case ConfigManager.YF_SYSTEM:
                    _storeQuery = new YF_StoreQuery();
                    break;
                case ConfigManager.YK_SYSTEM:
                    _storeQuery = new YK_StoreQuery();
                    break;
                default:
                    return null;
            }
            return _storeQuery;
        }

    }
}
