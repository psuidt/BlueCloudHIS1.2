using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Model;
using HIS.BLL;
//using HIS.DAL;
using HIS.SYSTEM;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.Core;

namespace HIS.YP_BLL
{

    /// <summary>
    /// 住院发药单处理器（经济管理部分）
    /// </summary>
    class ZY_DispEconomy : DispenseProcessor
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

        /// <summary>
        /// 保存多张住院发药单（住院发药统领）
        /// </summary>
        /// <param name="masterList">发药单头表</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <param name="dispDt"></param>
        /// <returns></returns>
        public override BillMaster SaveBills(List<BillMaster> masterList, long deptId, Hashtable dispDt)
        {
            try
            {         
                YP_DispDeptHis dispDeptHis = new YP_DispDeptHis();
                dispDeptHis.DispDept = (int)deptId;
                YP_DRMaster firstMaster = (YP_DRMaster)(masterList[0]);
                dispDeptHis.OpMan = firstMaster.OPPeopleID;
                dispDeptHis.OpTime = firstMaster.OPTime;
                dispDeptHis.TotalFee = 0;
                dispDeptHis.DeptId = firstMaster.DeptID;              
                oleDb.BeginTransaction();
                BindEntity<YP_DispDeptHis>.CreateInstanceDAL(oleDb).Add(dispDeptHis);
                foreach (YP_DRMaster dispMaster in masterList)
                {
                    if (dispDt[dispMaster.InpatientID] == null)
                    {
                        break;
                    }
                    DataTable dispRecipeOrder = (DataTable)dispDt[dispMaster.InpatientID];
                    if (dispRecipeOrder.Rows.Count > 0)
                    {
                        DataTable dt = dispRecipeOrder.Clone();
                        dt.Clear();
                        DataRow[] rows = dispRecipeOrder.Select("group_id=" + dispMaster.RecipeID + "");
                        if (rows.Length > 0)
                        {
                            for (int index = 0; index < rows.Length; index++)
                            {
                                dt.Rows.Add(rows[index].ItemArray);
                            }
                            List<BillOrder> dispList = this.BuildNewDispOrder(dt, dispMaster, 2);
                            dispMaster.UniFormId = dispDeptHis.Id;
                            SingleDisp(dispList, dispMaster, dispDeptHis.Id);
                            dispDeptHis.TotalFee += dispMaster.RetailFee;
                            dispDeptHis.PatientNames += (dispMaster.PatientName + ",");
                        }
                        //List<BillOrder> dispList = this.BuildNewDispOrder(dispRecipeOrder, dispMaster, 2);
                        //dispMaster.UniFormId = dispDeptHis.Id;
                        //SingleDisp(dispList, dispMaster, dispDeptHis.Id);
                        //dispDeptHis.TotalFee += dispMaster.RetailFee;
                        //dispDeptHis.PatientNames += (dispMaster.PatientName + ",");
                    }
                }
                BindEntity<YP_DispDeptHis>.CreateInstanceDAL(oleDb).Update(dispDeptHis);
                oleDb.CommitTransaction();
                return dispDeptHis;
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

        /// <summary>
        /// 保存住院发药单（单人发药）
        /// </summary>
        /// <param name="billMaster">住院发药单表头</param>
        /// <param name="listOrder">住院发药单明细列表</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_DRMaster dispMaster = (YP_DRMaster)billMaster;
                //将发药单据表头写入数据库
                if (listOrder.Count > 0)
                {
                    //开启发药事务
                    oleDb.BeginTransaction();
                    SingleDisp(listOrder, dispMaster, 0);
                    oleDb.CommitTransaction();
                }
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 住院单人发药
        /// </summary>
        /// <param name="listOrder">发药单明细列表</param>
        /// <param name="dispMaster">发药单表头</param>
        /// <param name="uniformId">统领ID</param>
        private void SingleDisp(List<BillOrder> listOrder, YP_DRMaster dispMaster, int uniformId)
        {
            
            BindEntity<HIS.Model.YP_DRMaster>.CreateInstanceDAL(oleDb, Tables.YF_DRMASTER).Add(dispMaster);
            //将生成的发药单据表头标识ID赋给所有发药明细
            foreach (BillOrder baseOrder in listOrder)
            {
                YP_DROrder order = (YP_DROrder)baseOrder;
                order.MasterDrugOCID = dispMaster.MasterDrugOCID;
                ZY_BLL.YP_Interface.UpdateSendDrugFlag(order.OrderRecipeID);
                order.UniformID = uniformId;
                BindEntity<HIS.Model.YP_DROrder>.CreateInstanceDAL(oleDb, Tables.YF_DRORDER).Add(order);
            }
            Hashtable storeTable = StoreFactory.GetProcessor(dispMaster.OpType).ChangeStoreNum(dispMaster, listOrder);
            AccountFactory.GetWriter(dispMaster.OpType).WriteAccount(dispMaster, listOrder, storeTable);
        }

        public override void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建住院发药单明细列表
        /// </summary>
        /// <param name="recipeOrder">记账明细表</param>
        /// <param name="dispMaster">发药单表头</param>
        /// <param name="dispenseModel">发药模式</param>
        /// <returns>住院发药单明细列表</returns>
        public override List<BillOrder> BuildNewDispOrder(DataTable recipeOrder, YP_DRMaster dispMaster, int dispenseModel)
        {
            List<BillOrder> rtnList = new List<BillOrder>();
            for (int index = 0; index < recipeOrder.Rows.Count; index++)
            {
                YP_DROrder dispOrder = new YP_DROrder();
                DataRow dRow = recipeOrder.Rows[index];
                //if (dRow["ISDISPENSE"] != DBNull.Value)
                //{
                    dispOrder.ChemName = dRow["itemname"].ToString();//药品化学名称
                    dispOrder.DeptID = dispMaster.DeptID;//发药部门ＩＤ
                    dispOrder.DoseNum = 0;//剂数默认为0
                    dispOrder.DrugOC_Flag = dispMaster.DrugOC_Flag;// 1;//1表发药，0表退药
                    dispOrder.DrugOCNum = Convert.ToDecimal(dRow["AMOUNT"]) > 0 ? Convert.ToDecimal(dRow["AMOUNT"]) : Convert.ToDecimal(dRow["AMOUNT"])*-1;
                    dispOrder.InpatientID = dispMaster.InpatientID;
                    dispOrder.InvoiceNum = 0;//发票号默认为0
                    dispOrder.LeastUnit = Convert.ToInt32(dRow["UNITID"]);//发药单位ＩＤ
                    dispOrder.MakerDicID = Convert.ToInt32(dRow["ITEMID"]);//厂家典标识ＩＤ
                    dispOrder.MasterDrugOCID = dispMaster.MasterDrugOCID;//对应表头ＩＤ
                    dispOrder.OrderRecipeID = Convert.ToInt32(dRow["PRESORDERID"]);//处方明细ID
                    dispOrder.Refundment_Flag = 0;//1表已退费，0表未退费
                    decimal hjRetailFee = Convert.ToDecimal(dRow["TOLAL_FEE"]);//零售金额
                    dispOrder.RetailPrice = Convert.ToDecimal(dRow["SELL_PRICE"]);//零售价
                    dispOrder.SpecDicID = Convert.ToInt32(dRow["SPECDICID"]);//药品规格标识ID
                    dispOrder.TradePrice = Convert.ToDecimal(dRow["BUY_PRICE"]);//批发价
                    //批发金额
                    dispOrder.TradeFee = (dispOrder.TradePrice / Convert.ToDecimal(dRow["RELATIONNUM"])) * dispOrder.DrugOCNum;
                    dispOrder.Uniform_Flag = (dispenseModel == 1?0:1);//1表示住院单人,2表住院统领
                    dispOrder.UnitNum = Convert.ToInt32(dRow["RELATIONNUM"]);
                    dispOrder.Curedeptid = Convert.ToInt32(dRow["PRESDEPTCODE"]);
                    dispOrder.RetailFee = AccountWriter.YF_ComputeTotalFee(dispOrder.RetailPrice, dispOrder.DrugOCNum, dispOrder.UnitNum);
                    dispMaster.RetailFee += dispOrder.RetailFee;//统计表头的零售金额
                    rtnList.Add(dispOrder);
               // }
            }
            return rtnList;
        }

        public override YP_DRMaster BuildNewDispenseMaster(object obj, int deptId, int dispenserId)
        {
            throw new NotImplementedException();
        }

       

        
    }
}
