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
    /// 出库单处理器
    /// </summary>
    abstract class OutStoreProcessor:BillProcessor
    {
        /// <summary>
        /// 创建出库单表头
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="userId">用户ＩＤ</param>
        /// <returns>出库单表头</returns>
        public override HIS.Model.BillMaster BuildNewMaster(long deptId, long userId)
        {
            YP_OutMaster outStore = new YP_OutMaster();
            try
            {
                outStore.Audit_Flag = 0;
                DateTime currentTime = XcDate.ServerDateTime;
                outStore.BillDate = currentTime;
                outStore.Del_Flag = 0;
                outStore.DeptID = Convert.ToInt32(deptId);
                outStore.OutFee = 0;
                outStore.RegPeopleID = Convert.ToInt32(userId);
                outStore.RegTime = currentTime;
                outStore.RetailFee = 0;
                outStore.TradeFee = 0;
                return outStore;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 创建出库单明细
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="master">出库单表头</param>
        /// <returns>出库单明细</returns>
        public override HIS.Model.BillOrder BuildNewoder(long deptId, HIS.Model.BillMaster master)
        {
            YP_OutOrder outStore = new YP_OutOrder();
            try
            {
                outStore.DeptID = Convert.ToInt32(deptId);
                outStore.MasterOutStorage = (YP_OutMaster)master;
                outStore.MakerDic = new YP_MakerDic();
                outStore.LeastUnitEntity = new YP_UnitDic();
                return outStore;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 按最新价格重新核算出库单明细价格和头表金额
        /// </summary>
        /// <param name="outMaster">出库单表头</param>
        /// <param name="billOrder">出库单明细列表</param>
        /// <param name="belongSystem">所属系统（药房系统，药库系统）</param>
        protected void AuditPrice(YP_OutMaster outMaster, List<YP_OutOrder> billOrder, string belongSystem)
        {
            outMaster.RetailFee = 0;
            outMaster.TradeFee = 0;
            outMaster.OutFee = 0;
            foreach (YP_OutOrder order in billOrder)
            {
                YP_MakerDic makerDic = BindEntity<YP_MakerDic>.CreateInstanceDAL(oleDb).GetModel(order.MakerDicID);
                if (makerDic.RetailPrice != order.RetailPrice || makerDic.TradePrice != order.TradePrice)
                {
                    order.RetailPrice = makerDic.RetailPrice;
                    order.TradePrice = makerDic.TradePrice;
                    if (belongSystem == ConfigManager.YF_SYSTEM)
                    {
                        order.RetailFee = AccountWriter.YF_ComputeTotalFee(order.RetailPrice, order.OutNum, order.UnitNum);
                        order.TradeFee = AccountWriter.YF_ComputeTotalFee(order.TradePrice, order.OutNum, order.UnitNum);
                    }
                    else
                    {
                        order.RetailFee = AccountWriter.YK_ComputeTotalFee(order.RetailPrice, order.OutNum);
                        order.TradeFee = AccountWriter.YK_ComputeTotalFee(order.TradePrice, order.OutNum);
                    }
                }
                outMaster.RetailFee += order.RetailFee;
                outMaster.TradeFee += order.TradeFee;
                outMaster.OutFee += order.RetailFee;
            }
        }
    }    
}
