using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using HIS.Model;
using HIS.DAL;
using HIS.SYSTEM;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.Core;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 药品入库单处理器
    /// </summary>
    abstract class InStoreProcessor : BillProcessor
    {
        /// <summary>
        /// 创建采购入库单
        /// </summary>
        /// <param name="deptId">部门ＩＤ</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        override public BillMaster BuildNewMaster(long deptId, long userId)
        {
            YP_InMaster inStore = new YP_InMaster();
            try
            {
                inStore.RegPeopleID = Convert.ToInt32(userId);
                inStore.DeptID = Convert.ToInt32(deptId);
                inStore.Audit_Flag = 0;
                inStore.Del_Flag = 0;
                inStore.Pay_Flag = 0;
                inStore.OpManID = Convert.ToInt32(userId);
                inStore.RegTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                inStore.BillDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                inStore.InvoiceDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                inStore.SupportDic = new YP_SupportDic();
                return inStore;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 根据指定信息创建明细记录对象
        /// </summary>
        /// <param name="deptId">部门标识ID</param>
        /// <param name="master">对应的入库表头记录对象</param>
        /// <returns> 新建的明细记录对象</returns>
        override public BillOrder BuildNewoder(long deptId, BillMaster master)
        {
            YP_InOrder inStore = new YP_InOrder();
            try
            {
                //如果是添加状态创建明细对象
                {
                    inStore.DeptID = Convert.ToInt32(deptId);

                }
                inStore.MasterInStorage = (YP_InMaster)master;
                inStore.MakerDic = new YP_MakerDic();
                inStore.LeastUnitEntity = new YP_UnitDic();
                return inStore;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 重新计算入库单价格和金额，防止审核之前入库单调价
        /// </summary>
        /// <param name="inMaster">入库单表头</param>
        /// <param name="billOrder">入库单明细</param>
        /// <param name="belongSystem">药房或药库系统</param>
        protected void AuditPrice(YP_InMaster inMaster, List<YP_InOrder> billOrder, string belongSystem)
        {
            inMaster.RetailFee = 0;
            inMaster.TradeFee = 0;
            foreach (YP_InOrder order in billOrder)
            {
                YP_MakerDic makerDic = BindEntity<YP_MakerDic>.CreateInstanceDAL(oleDb).GetModel(order.MakerDicID);
                if (makerDic.RetailPrice != order.RetailPrice || makerDic.TradePrice != order.TradePrice)
                {
                    order.RetailPrice = makerDic.RetailPrice;
                    order.TradePrice = makerDic.TradePrice;
                    if (belongSystem == ConfigManager.YF_SYSTEM)
                    {
                        if (inMaster.OpType != ConfigManager.OP_YF_APPLYIN)
                        {
                            order.RetailFee = AccountWriter.YF_ComputeTotalFee(order.RetailPrice, order.InNum, order.UnitNum);
                            order.TradeFee = AccountWriter.YF_ComputeTotalFee(order.TradePrice, order.InNum, order.UnitNum);
                        }
                        else
                        {
                            order.RetailFee = AccountWriter.YF_ComputeTotalFee(order.RetailPrice, order.InNum * order.UnitNum, order.UnitNum);
                            order.TradeFee = AccountWriter.YF_ComputeTotalFee(order.TradePrice, order.InNum * order.UnitNum, order.UnitNum);
                        }
                    }
                    else
                    {
                        order.RetailFee = AccountWriter.YK_ComputeTotalFee(order.RetailPrice, order.InNum);
                        order.TradeFee = AccountWriter.YK_ComputeTotalFee(order.TradePrice, order.InNum);
                    }
                }
                inMaster.RetailFee += order.RetailFee;
                inMaster.TradeFee += order.TradeFee;
            }
        }
    }
}
