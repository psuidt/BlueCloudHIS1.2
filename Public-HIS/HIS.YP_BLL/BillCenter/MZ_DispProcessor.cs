using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Model;
using HIS.BLL;
using HIS.DAL;
using HIS.SYSTEM;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.Core;

namespace HIS.YP_BLL
{
    class MZ_DispProcessor : DispenseProcessor
    {

        public override void AuditBill(BillMaster billMaster, long auditerID, long auditDeptID)
        {
            throw new NotImplementedException();
        }

        public override BillMaster BuildNewMaster(long deptId, long userId)
        {
            throw new NotImplementedException();
        }

        public override BillOrder BuildNewoder(long deptId, BillMaster master)
        {
            throw new NotImplementedException();
        }

        public override void DelBill(BillMaster billMaster)
        {
            throw new NotImplementedException();
        }

        public override BillMaster SaveBills(List<BillMaster> masterList, long deptId, System.Collections.Hashtable dispDt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存门诊发药单（门诊发药）
        /// </summary>
        /// <param name="billMaster">门诊发药单表头</param>
        /// <param name="listOrder">门诊发药单明细</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_DRMaster dispMaster = (YP_DRMaster)billMaster;
                dispMaster.RetailFee = 0;
                YP_Storage store = new YP_Storage();
                //将发药单据表头写入数据库
                if (listOrder.Count > 0)
                {
                    //开启发药事务
                    oleDb.BeginTransaction();                   
                    string strWhere = BLL.Tables.yf_drmaster.RECIPEID + oleDb.EuqalTo() + dispMaster.RecipeID.ToString();
                    if (BindEntity<YP_DRMaster>.CreateInstanceDAL(oleDb, Tables.YF_DRMASTER).Exists(strWhere))
                    {
                        throw new Exception("该张发票已经发过药品，请刷新病人列表");
                    }
                    BindEntity<HIS.Model.YP_DRMaster>.CreateInstanceDAL(oleDb, Tables.YF_DRMASTER).Add(dispMaster);
                    //更新处方头
                    MZ_BLL.YP_Interface.UpdateSendDrugFlag(dispMaster.RecipeID);
                    //将生成的发药单据表头标识ID赋给所有发药明细
                    foreach (BillOrder baseOrder in listOrder)
                    {
                        YP_DROrder order = (YP_DROrder)baseOrder;
                        order.MasterDrugOCID = dispMaster.MasterDrugOCID;
                        YP_DROrder drOrder = (YP_DROrder)order;
                        BindEntity<HIS.Model.YP_DROrder>.CreateInstanceDAL(oleDb, Tables.YF_DRORDER).Add(order);
                        dispMaster.RetailFee += order.RetailFee;
                    }
                    dispMaster.RetailFee = dispMaster.RetailFee * dispMaster.RecipeNum;
                    BindEntity<HIS.Model.YP_DRMaster>.CreateInstanceDAL(oleDb, Tables.YF_DRMASTER).Update(dispMaster);
                    Hashtable storeTable = StoreFactory.GetProcessor(dispMaster.OpType).ChangeStoreNum(billMaster, listOrder);
                    //foreach (YP_StoreNum storeInfo in storeTable.Values)
                    //{
                    //    if (storeInfo.storeNum == -1)
                    //    {
                    //        noStoreList.Add(storeInfo);
                    //    }

                    //}
                    AccountFactory.GetWriter(dispMaster.OpType).WriteAccount(billMaster, listOrder, storeTable);
                    oleDb.CommitTransaction();
                }
            }
            catch (Exception error)
            {
                if (oleDb.IsInTransaction)
                {
                    oleDb.RollbackTransaction();
                }
                throw error;
            }
        }

        public override void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 按处方明细构造发药单明细
        /// </summary>
        /// <param name="recipeOrder">处方明细</param>
        /// <param name="dispMaster">发药单表头</param>
        /// <param name="dispenseModel">发药方式（发药还是退药）</param>
        /// <returns>发药单明细</returns>
        public override List<BillOrder> BuildNewDispOrder(DataTable recipeOrder, YP_DRMaster dispMaster, int dispenseModel)
        {
            if (recipeOrder == null)
            {
                return null;
            }
            if (recipeOrder.Rows.Count <= 0)
            {
                return null;
            }
            List<BillOrder> rtnList = new List<BillOrder>();
            for (int index = 0; index < recipeOrder.Rows.Count; index++)
            {
                YP_DROrder dispOrder = new YP_DROrder();
                DataRow dRow = recipeOrder.Rows[index];
                dispOrder.ChemName = dRow["CHEMNAME"].ToString();//药品化学名称
                dispOrder.DeptID = dispMaster.DeptID;//发药部门ＩＤ
                dispOrder.DoseNum = 0;//剂数默认为0
                dispOrder.DrugOC_Flag = 1;//1表发药，0表退药
                dispOrder.DrugOCNum = Convert.ToDecimal(dRow["AMOUNT"]);
                dispOrder.InpatientID = dispMaster.InpatientID;
                dispOrder.InvoiceNum = dispMaster.InvoiceNum;//发票号默认为0
                dispOrder.LeastUnit = Convert.ToInt32(dRow["UNIT"]);//发药单位ＩＤ
                dispOrder.MakerDicID = Convert.ToInt32(dRow["ITEMID"]);//厂家典标识ＩＤ
                dispOrder.MasterDrugOCID = dispMaster.MasterDrugOCID;//对应表头ＩＤ
                dispOrder.OrderRecipeID = Convert.ToInt32(dRow["PRESORDERID"]);//处方明细ID
                dispOrder.Refundment_Flag = 0;//1表已退费，0表未退费                
                decimal hjRetailFee = Convert.ToDecimal(dRow["TOLAL_FEE"]);//零售金额
                decimal recipeNum = Convert.ToDecimal(dRow["PRESAMOUNT"]);
                dispOrder.RetailPrice = Convert.ToDecimal(dRow["SELL_PRICE"]);//零售价
                dispOrder.SpecDicID = Convert.ToInt32(dRow["SPECDICID"]);//药品规格标识ID
                dispOrder.TradePrice = Convert.ToDecimal(dRow["BUY_PRICE"]);//批发价
                //批发金额
                dispOrder.TradeFee = dispOrder.TradePrice * Convert.ToDecimal(dRow["AMOUNT"])
                    / Convert.ToDecimal(dRow["RELATIONNUM"]);
                dispOrder.Uniform_Flag = 0;//1表示住院，0表示门诊,2表住院统领
                dispOrder.UnitNum = Convert.ToInt32(dRow["RELATIONNUM"]);
                dispOrder.Curedeptid = Convert.ToInt32(dRow["PRESDEPTCODE"]);
                dispOrder.RetailFee = AccountWriter.YF_ComputeTotalFee(dispOrder.RetailPrice,
                    dispOrder.DrugOCNum, dispOrder.UnitNum);
                rtnList.Add(dispOrder);
            }
            return rtnList;
        }

        /// <summary>
        /// 构造发药单表头
        /// </summary>
        /// <param name="obj">处方头</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <param name="dispenserId">发药人员ID</param>
        /// <returns>发药单表头</returns>
        public override YP_DRMaster BuildNewDispenseMaster(object obj, int deptId, int dispenserId)
        {
            HIS.Interface.Structs.Prescription pres = (HIS.Interface.Structs.Prescription)obj;
            YP_DRMaster dispMaster = new YP_DRMaster();
            dispMaster.Charge_Flag = 1;
            dispMaster.DeptID = deptId;
            dispMaster.ChargeMan = Convert.ToInt32(pres.ChargeCode);
            dispMaster.DeptID = deptId;
            if (pres.PresDocCode != "")
            {
                dispMaster.DocID = Convert.ToInt32(pres.PresDocCode);
            }
            else
            {
                dispMaster.DocID = 0;
            }
            dispMaster.DosageMan = 0;
            dispMaster.DrugOC_Flag = 1;
            dispMaster.InpatientID = "";
            dispMaster.InvoiceNum = Convert.ToInt32(pres.TicketNum);
            dispMaster.OPPeopleID = dispenserId;
            dispMaster.OPTime = XcDate.ServerDateTime;
            dispMaster.OpType = ConfigManager.OP_YF_DISPENSE;
            dispMaster.PatientID = pres.RegisterID;
            dispMaster.PatientName = pres.PatientName;
            dispMaster.PatientNo = "";
            dispMaster.ReceiptCode = pres.ChargeID;
            dispMaster.RecipeID = pres.PrescriptionID;
            dispMaster.RecipeNum = Convert.ToInt32(pres.presAmount);
            dispMaster.RetailFee = 0;
            return dispMaster;
        }
    }
}
