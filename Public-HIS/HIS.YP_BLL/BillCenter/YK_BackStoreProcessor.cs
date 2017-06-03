using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Model;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 药品退库单处理器：派生于药品入库单处理器
    /// </summary>
    class YK_BackStoreProcessor : YK_InstoreProcessor
    {
        /// <summary>
        /// 构造退库单对性
        /// </summary>
        /// <param name="deptId">单据所属科室ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public override HIS.Model.BillMaster BuildNewMaster(long deptId, long userId)
        {
            BillMaster rtnMaster = base.BuildNewMaster(deptId, userId);
            //指定业务类型为退库业务类型
            ((YP_InMaster)rtnMaster).OpType = ConfigManager.OP_YK_BACKSTORE;
            return rtnMaster;
        }

    }
}
