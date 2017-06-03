using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
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
    /// 住院退药处理器
    /// </summary>
    class ZY_Refund : RefundProcessor
    {

        public override YP_DRMaster BuildNewDispenseMaster(object obj, int deptId, int dispenserId)
        {
            throw new NotImplementedException();
        }

        public override BillMaster SaveBills(List<BillMaster> masterList, long deptId, System.Collections.Hashtable dispDt)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// 创建住院退药单明细列表
        /// </summary>
        /// <param name="recipeOrder">发药明细表</param>
        /// <param name="dispMaster">退药单表头</param>
        /// <param name="dispenseModel"></param>
        /// <returns>住院退药单明细列表</returns>
        public override List<BillOrder> BuildNewDispOrder(DataTable recipeOrder, YP_DRMaster dispMaster, int dispenseModel)
        {
            List<BillOrder> rtnList = new List<BillOrder>();
            for (int index = 0; index < recipeOrder.Rows.Count; index++)
            {
                YP_DROrder refOrder = new YP_DROrder();
                DataRow dRow = recipeOrder.Rows[index];
                if (Convert.ToInt32(dRow["RefundNum"]) != 0)
                {
                    refOrder = (YP_DROrder)ApiFunction.DataTableToObject(recipeOrder, index, refOrder);
                    refOrder.DeptID = dispMaster.DeptID;//退药部门ＩＤ
                    refOrder.DrugOC_Flag = 0;//1表发药，0表退药
                    refOrder.MasterDrugOCID = dispMaster.MasterDrugOCID;//对应表头ＩＤ
                    refOrder.Refundment_Flag = 1;//1表已退费，0表未退费
                    //零售金额
                    refOrder.RetailFee = refOrder.RetailFee * Convert.ToDecimal(dRow["RefundNum"]) / refOrder.DrugOCNum;
                    //批发金额
                    refOrder.TradeFee = refOrder.TradeFee * Convert.ToDecimal(dRow["RefundNum"]) / refOrder.DrugOCNum;
                    refOrder.DrugOCNum = Convert.ToDecimal(dRow["RefundNum"]);
                    dispMaster.RetailFee += refOrder.RetailFee;//统计表头的零售金额
                    rtnList.Add(refOrder);
                }
            }
            return rtnList;
        }

        public override void AuditBill(BillMaster billMaster, long auditerID, long auditDeptID)
        {
            throw new NotImplementedException();
        }

        public override BillMaster BuildNewMaster(long deptId, long userId)
        {
            throw new NotImplementedException();
        }

        public override void DelBill(BillMaster billMaster)
        {
            throw new NotImplementedException();
        }

        public override BillOrder BuildNewoder(long deptId, BillMaster master)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 住院退药单保存（单人退药）
        /// </summary>
        /// <param name="billMaster">住院退药单表头</param>
        /// <param name="listOrder">住院退药单明细</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_DRMaster refMaster = (YP_DRMaster)billMaster;
                oleDb.BeginTransaction();
                //将发药单据表头写入数据库
                if (listOrder.Count > 0)
                {
                    //添加退药表头
                    BindEntity<HIS.Model.YP_DRMaster>.CreateInstanceDAL(oleDb, Tables.YF_DRMASTER).Add(refMaster);
                    foreach (YP_DROrder order in listOrder)
                    {
                        order.MasterDrugOCID = refMaster.MasterDrugOCID;
                        BindEntity<HIS.Model.YP_DROrder>.CreateInstanceDAL(oleDb, Tables.YF_DRORDER).Add(order);
                    }
                    Hashtable storeTable = StoreFactory.GetProcessor(refMaster.OpType).ChangeStoreNum(billMaster, listOrder);
                    AccountFactory.GetWriter(refMaster.OpType).WriteAccount(billMaster, listOrder, storeTable);
                }
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        public override void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            throw new NotImplementedException();
        }
    }
}
