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
    class MZ_Refund : RefundProcessor
    {
        /// <summary>
        /// 根据门诊发药单表头创建门诊退药单表头
        /// </summary>
        /// <param name="obj">发药单表头</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <param name="dispenserId">退药人ID</param>
        /// <returns>门诊退药单表头</returns>
        public override YP_DRMaster BuildNewDispenseMaster(object obj, int deptId, int dispenserId)
        {
            YP_DRMaster dispMaster = (YP_DRMaster)obj;
            YP_DRMaster refMaster = new YP_DRMaster();
            refMaster.Charge_Flag = 1;//记账处方标识
            refMaster.DeptID = deptId;//发药部门ＩＤ
            refMaster.DocID = dispMaster.DocID;//主治医生ID
            refMaster.DosageMan = 0;//配药人ＩＤ，未启用
            refMaster.DrugOC_Flag = 0;//1表发药，0表退药
            refMaster.InpatientID = "";//住院号
            refMaster.InvoiceNum = dispMaster.InvoiceNum;//住院发票号默认为0
            refMaster.OPPeopleID = dispenserId;//发药人员ID
            refMaster.OPTime = XcDate.ServerDateTime;//发药时间
            refMaster.OpType = ConfigManager.OP_YF_REFUND;//业务类型
            refMaster.PatientID = dispMaster.PatientID;//病人ID
            refMaster.PatientName = dispMaster.PatientName;//病人姓名
            refMaster.PatientNo = "";//病历号，未启用
            refMaster.ReceiptCode = dispMaster.ReceiptCode;//结算收据号
            refMaster.RecipeID = dispMaster.RecipeID;//处方号，门诊已启用
            refMaster.RecipeNum = dispMaster.RecipeNum;//处方贴数
            refMaster.RetailFee = 0;//零售金额，初始化为0
            return refMaster;
        }

        /// <summary>
        /// 创建门诊退药明细列表
        /// </summary>
        /// <param name="recipeOrder">发药明细表</param>
        /// <param name="dispMaster">发药表头</param>
        /// <param name="dispenseModel">发药模式</param>
        /// <returns>门诊退药明细列表</returns>
        public override List<BillOrder> BuildNewDispOrder(DataTable recipeOrder, YP_DRMaster dispMaster, int dispenseModel)
        {
            List<BillOrder> rtnList = new List<BillOrder>();
            for (int index = 0; index < recipeOrder.Rows.Count; index++)
            {
                YP_DROrder refOrder = new YP_DROrder();
                DataRow dRow = recipeOrder.Rows[index];
                if (Convert.ToInt32(dRow["RefundNum"]) != 0 && Convert.ToInt32(dRow["DrugOC_Flag"]) == 1
                    && Convert.ToInt32(dRow["MasterDrugOCID"]) == dispMaster.MasterDrugOCID)
                {
                    refOrder = (YP_DROrder)ApiFunction.DataTableToObject(recipeOrder, index, refOrder);
                    refOrder.DrugOCNum = Convert.ToDecimal(dRow["RefundNum"]);
                    refOrder.DeptID = dispMaster.DeptID;//退药部门ＩＤ
                    refOrder.DrugOC_Flag = 0;//1表发药，0表退药
                    refOrder.MasterDrugOCID = 0;
                    refOrder.Refundment_Flag = 1;//1表已退费，0表未退费
                    //零售金额
                    refOrder.RetailFee = refOrder.RetailFee * Convert.ToDecimal(dRow["RefundNum"])
                        / Convert.ToDecimal(dRow["DrugOCNum"]);
                    //批发金额
                    refOrder.TradeFee = refOrder.TradeFee * Convert.ToDecimal(dRow["RefundNum"])
                        / Convert.ToDecimal(dRow["DrugOCNum"]);
                    refOrder.DrugOCNum = Convert.ToDecimal(dRow["RefundNum"]);
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

        public override BillMaster SaveBills(List<BillMaster> masterList, long deptId, System.Collections.Hashtable dispDt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存门诊退药单（门诊退药）
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="listOrder">单据明细列表</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_DRMaster refMaster = (YP_DRMaster)billMaster;
                refMaster.RetailFee = 0;
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
                        refMaster.RetailFee += order.RetailFee;
                    }
                    refMaster.RetailFee = refMaster.RetailFee * refMaster.RecipeNum;
                    BindEntity<HIS.Model.YP_DRMaster>.CreateInstanceDAL(oleDb, Tables.YF_DRMASTER).Update(refMaster);
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

        /// <summary>
        /// 更新门诊退药单（未实现）
        /// </summary>
        /// <param name="billMaster"></param>
        /// <param name="listOrder"></param>
        /// <param name="deptId"></param>
        public override void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            throw new NotImplementedException();
        }
    }

}
