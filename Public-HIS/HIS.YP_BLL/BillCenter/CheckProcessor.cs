using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using HIS.Model;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CheckProcessor:BillProcessor
    {
        /// <summary>
        /// 盘点单据处理器
        /// </summary>
        public CheckProcessor()
        { 
        }

        /// <summary>
        /// 构造盘点单明细（未实现）
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="master">盘点单头表</param>
        /// <returns>盘点单明细</returns>
        public override BillOrder BuildNewoder(long deptId, BillMaster master)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 清除库房盘点状态
        /// </summary>
        /// <param name="deptId">药剂科室ＩＤ</param>
        abstract public void ClearCheckStatus(long deptId);

        /// <summary>
        /// 计算盘点单盈亏金额合计
        /// </summary>
        /// <param name="checkMaster">盘点头</param>
        /// <param name="listOrder">盘点明细</param>
        protected void ComputeMasterFee(YP_CheckMaster checkMaster, List<BillOrder> listOrder)
        {
            checkMaster.MoreRetailFee = 0;
            checkMaster.MoreTradeFee = 0;
            checkMaster.LessRetailFee = 0;
            checkMaster.LessTradeFee = 0;
            foreach (YP_CheckOrder order in listOrder)
            {
                //盘盈
                if (order.FactNum < order.CheckNum)
                {
                    checkMaster.MoreRetailFee += (order.CKRetailFee - order.FTRetailFee);
                    checkMaster.MoreTradeFee += (order.CKTradeFee - order.FTTradeFee);
                }
                //盘亏
                else
                {
                    checkMaster.LessRetailFee += (order.FTRetailFee - order.CKRetailFee);
                    checkMaster.LessTradeFee += (order.FTTradeFee - order.CKTradeFee);
                }
            }
        }

    }



    
}
