using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Model;
using HIS.DAL;
using HIS.SYSTEM;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 采购计划单处理对象
    /// </summary>
    public class StockPlanProcessor:BillProcessor
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public StockPlanProcessor()
        {
        }

        /// <summary>
        /// 审核采购计划单
        /// </summary>
        /// <param name="billMaster"></param>
        /// <param name="auditerID"></param>
        /// <param name="auditDeptID"></param>
        public override void AuditBill(BillMaster billMaster, long auditerID, long auditDeptID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据病人创建发药头表（不用）
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="deptId"></param>
        /// <param name="dispenserId"></param>
        /// <returns></returns>
        public override YP_DRMaster BuildNewDispenseMaster(object obj, int deptId, int dispenserId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 创建发药明细（不用）
        /// </summary>
        /// <param name="recipeOrder"></param>
        /// <param name="dispMaster"></param>
        /// <param name="dispenseModel"></param>
        /// <returns></returns>
        public override List<BillOrder> BuildNewDispOrder(System.Data.DataTable recipeOrder, YP_DRMaster dispMaster, int dispenseModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建新的采购计划表头
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>采购计划表头</returns>
        public override BillMaster BuildNewMaster(long deptId, long userId)
        {
            try
            {
                YP_PlanMaster planMaster = new YP_PlanMaster();
                planMaster.RegPeople = (int)userId;
                planMaster.RegPeopleName = BaseData.GetUserName((int)userId);
                planMaster.DeptId = (int)deptId;
                return planMaster;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 创建新的采购计划明细
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="master">采购计划表头</param>
        /// <returns>采购计划明细</returns>
        public override BillOrder BuildNewoder(long deptId, BillMaster master)
        {
            YP_PlanOrder planOrder = new YP_PlanOrder();
            return planOrder;
        }

        /// <summary>
        /// 删除指定采购计划单
        /// </summary>
        /// <param name="billMaster">采购计划表头</param>
        public override void DelBill(BillMaster billMaster)
        {
            try
            {
                YP_PlanMaster planMaster = (YP_PlanMaster)billMaster;
                oleDb.BeginTransaction();
                int deleteID = planMaster.PlanMasterId;
                IBaseDAL<YP_PlanMaster> masterDao = BindEntity<YP_PlanMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_PLANMASTER);
                //删除头表
                masterDao.Delete(deleteID);
                IBaseDAL<YP_PlanOrder> orderDao = BindEntity<YP_PlanOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YK_PLANORDER);
                //删除明细
                orderDao.Delete(Tables.yk_planorder.PLANMASTERID + oleDb.EuqalTo() + deleteID.ToString());
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 保存采购计划单
        /// </summary>
        /// <param name="billMaster">采购计划表头</param>
        /// <param name="listOrder">采购计划明细列表</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_PlanMaster planMaster = (YP_PlanMaster)billMaster;
                IBaseDAL<YP_PlanMaster> masterDao = BindEntity<YP_PlanMaster>.CreateInstanceDAL(oleDb, Tables.YK_PLANMASTER);
                IBaseDAL<YP_PlanOrder> orderDao = BindEntity<YP_PlanOrder>.CreateInstanceDAL(oleDb, Tables.YK_PLANORDER);
                planMaster.RegTime = XcDate.ServerDateTime;
                planMaster.LASTCHANGTIME = XcDate.ServerDateTime;
                planMaster.TradeFee = 0;
                planMaster.RetailFee = 0;
                oleDb.BeginTransaction();
                //写头表信息获取ID号
                masterDao.Add(planMaster);
                foreach (YP_PlanOrder planOrder in listOrder)
                {
                    //计算头表合计金额
                    planMaster.RetailFee += planOrder.RetailFee;
                    planMaster.TradeFee += planOrder.TradeFee;
                    planOrder.PlanMasterId = planMaster.PlanMasterId;
                    //依次添加明细记录
                    orderDao.Add(planOrder);
                }
                masterDao.Update(planMaster);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 同时保存多张采购计划单
        /// </summary>
        /// <param name="masterList"></param>
        /// <param name="deptId"></param>
        /// <param name="dispDt"></param>
        /// <returns></returns>
        public override BillMaster SaveBills(List<BillMaster> masterList, long deptId, System.Collections.Hashtable dispDt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改采购计划单
        /// </summary>
        /// <param name="billMaster">采购计划表头</param>
        /// <param name="listOrder">采购计划明细列表</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_PlanMaster planMaster = (YP_PlanMaster)billMaster;
                oleDb.BeginTransaction();
                //声明操作对象
                IBaseDAL<YP_PlanMaster> masterDao = BindEntity<YP_PlanMaster>.CreateInstanceDAL(oleDb, Tables.YK_PLANMASTER);
                IBaseDAL<YP_PlanOrder> orderDao = BindEntity<YP_PlanOrder>.CreateInstanceDAL(oleDb, Tables.YK_PLANORDER);
                planMaster.RetailFee = 0;
                planMaster.TradeFee = 0;
                orderDao.Delete(Tables.yk_planorder.PLANMASTERID + oleDb.EuqalTo() + planMaster.PlanMasterId);
                foreach (YP_PlanOrder planOrder in listOrder)
                {
                    //计算入库金额
                    planMaster.RetailFee += planOrder.RetailFee;
                    planMaster.TradeFee += planOrder.TradeFee;
                    planOrder.PlanMasterId = planMaster.PlanMasterId;
                    //依次添加明细记录
                    orderDao.Add(planOrder);
                }
                masterDao.Update(planMaster);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

    }
}
