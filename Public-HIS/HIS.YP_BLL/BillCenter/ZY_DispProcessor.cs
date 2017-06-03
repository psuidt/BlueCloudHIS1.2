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
    /// <summary>
    /// 住院待发药处方信息
    /// </summary>
    public struct ZY_DispPresInfo
    {
        /// <summary>
        /// 开方医生代码
        /// </summary>
        public string CureDocCode;
        /// <summary>
        /// 开方科室代码
        /// </summary>
        public int presDeptId;
        /// <summary>
        /// 住院号
        /// </summary>
        public string CureNo;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName;
        /// <summary>
        /// 病人ID
        /// </summary>
        public int PatListId;
        /// <summary>
        /// 处方付数
        /// </summary>
        public int recipeNum;
        /// <summary>
        /// 发退药标识
        /// </summary>
        public int drFlag;
        /// <summary>
        /// 业务类型
        /// </summary>
        public string opType;
    }

    /// <summary>
    /// 住院药品统领单处理器
    /// </summary>
    public class ZY_DispProcessor : DispenseProcessor
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

        public List<YP_StoreNum> noStoreList;

        /// <summary>
        /// 住院药品统领
        /// </summary>
        /// <param name="masterList">发药单表头汇总</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <param name="dispDt">记账明细信息</param>
        /// <returns>统领药品历史信息</returns>
        public override BillMaster SaveBills(List<BillMaster> masterList, long deptId, Hashtable dispDt)
        {
            try
            {
                if (masterList == null)
                {
                    throw new Exception("发药汇总失败");
                }
                if (masterList.Count < 1)
                {
                    throw new Exception("没有药品被选中发送");
                }
                noStoreList = new List<YP_StoreNum>();
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
                    string hashKey = dispMaster.InpatientID + dispMaster.DrugOC_Flag.ToString();
                    if (dispDt[hashKey] == null)
                    {
                        break;
                    }
                    DataTable dispRecipeOrder = (DataTable)dispDt[hashKey];
                    if (dispRecipeOrder.Rows.Count > 0)
                    {
                        List<BillOrder> dispList = this.BuildNewDispOrder(dispRecipeOrder, dispMaster, 2);
                        dispMaster.UniFormId = dispDeptHis.Id;
                        SingleDisp(dispList, dispMaster, dispDeptHis.Id);
                        dispDeptHis.TotalFee += dispMaster.RetailFee;
                        dispDeptHis.PatientNames += (dispMaster.PatientName + ",");
                    }
                }
                BindEntity<YP_DispDeptHis>.CreateInstanceDAL(oleDb).Update(dispDeptHis);
                if (noStoreList.Count > 0)
                {
                    oleDb.RollbackTransaction();
                    return null;
                }
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
        /// 保存单张住院发药单据
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
            dispMaster.RetailFee = Decimal.Round(dispMaster.RetailFee + (decimal)0.00000000001, 2);
            BindEntity<HIS.Model.YP_DRMaster>.CreateInstanceDAL(oleDb, Tables.YF_DRMASTER).Add(dispMaster);
            HIS.Interface.IZY_Data zyInterFace = new HIS.Interface.ZY_Data();
            //将生成的发药单据表头标识ID赋给所有发药明细
            for(int index =0; index < listOrder.Count; index++)
            {
                YP_DROrder order = (YP_DROrder)listOrder[index];
                order.MasterDrugOCID = dispMaster.MasterDrugOCID;               
                order.UniformID = uniformId;
                if (order.DrugOCNum != 0)
                {
                    BindEntity<HIS.Model.YP_DROrder>.CreateInstanceDAL(oleDb, Tables.YF_DRORDER).Add(order);
                }
                else
                {
                    listOrder.Remove(order);
                    index--;// add zenghao 20100823
                }
                if (order.DrugOC_Flag == 1)
                {
                    zyInterFace.UpdateSendFlag(order.OrderRecipeID, order.DrugOC_Flag, order.DrugOCNum, order.RetailFee);
                }
                else
                {
                    zyInterFace.UpdateSendFlag(order.OrderRecipeID, 2, -order.DrugOCNum, -order.RetailFee);
                }
            }
            Hashtable storeTable = StoreFactory.GetProcessor(dispMaster.OpType).ChangeStoreNum(dispMaster, listOrder);
            foreach (YP_StoreNum storeInfo in storeTable.Values)
            {
                if (storeInfo.storeNum == -1)
                {
                    noStoreList.Add(storeInfo);
                }
                    
            }
            AccountFactory.GetWriter(dispMaster.OpType).WriteAccount(dispMaster, listOrder, storeTable);
        }

        public override void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建住院发药单明细列表
        /// </summary>
        /// <param name="recipeOrder">护士站记账信息表</param>
        /// <param name="dispMaster">住院发药单表头</param>
        /// <param name="dispenseModel">发药模式</param>
        /// <returns>住院发药单明细列表</returns>
        public override List<BillOrder> BuildNewDispOrder(DataTable recipeOrder, YP_DRMaster dispMaster, int dispenseModel)
        {
            List<BillOrder> rtnList = new List<BillOrder>();
            bool dr_Flag = (dispMaster.OpType == ConfigManager.OP_YF_DISPENSE ? true : false);
            for (int index = 0; index < recipeOrder.Rows.Count; index++)
            {
                DataRow dRow = recipeOrder.Rows[index];
                YP_DROrder dispOrder = new YP_DROrder();
                dispOrder.ChemName = dRow["CHEMNAME"].ToString();//药品化学名称
                dispOrder.DeptID = dispMaster.DeptID;//发药部门ＩＤ                    
                if (dr_Flag)
                {
                    dispOrder.DrugOC_Flag = 1;
                    dispOrder.DrugOCNum = Convert.ToDecimal(dRow["DRUGNUM"]);
                }
                else
                {
                    dispOrder.DrugOC_Flag = 0;
                    dispOrder.DrugOCNum = -Convert.ToDecimal(dRow["DRUGNUM"]);
                }
                dispOrder.InpatientID = dispMaster.InpatientID;
                dispOrder.InvoiceNum = 0;//发票号默认为0
                dispOrder.LeastUnit = Convert.ToInt32(dRow["UNIT"]);//发药单位ＩＤ
                dispOrder.MakerDicID = Convert.ToInt32(dRow["MAKERDICID"]);//厂家典标识ＩＤ
                dispOrder.MasterDrugOCID = dispMaster.MasterDrugOCID;//对应表头ＩＤ
                dispOrder.OrderRecipeID = Convert.ToInt32(dRow["ORDERRECIPEID"]);//处方明细ID
                dispOrder.Refundment_Flag = 0;//1表已退费，0表未退费
                decimal hjRetailFee = Convert.ToDecimal(dRow["RETAILFEE"]);//零售金额
                dispOrder.RetailPrice = Convert.ToDecimal(dRow["RETAILPRICE"]);//零售价
                dispOrder.SpecDicID = Convert.ToInt32(dRow["SPECDICID"]);//药品规格标识ID
                dispOrder.TradePrice = Convert.ToDecimal(dRow["TRADEPRICE"]);//批发价
                //批发金额
                dispOrder.TradeFee = (dispOrder.TradePrice / Convert.ToDecimal(dRow["UNITNUM"])) * dispOrder.DrugOCNum;
                dispOrder.Uniform_Flag = dispenseModel;
                dispOrder.UnitNum = Convert.ToInt32(dRow["UNITNUM"]);
                dispOrder.Curedeptid = Convert.ToInt32(dRow["CUREDEPT"]);
                dispOrder.RetailFee = AccountWriter.YF_ComputeTotalFee(dispOrder.RetailPrice, dispOrder.DrugOCNum, dispOrder.UnitNum);
                dispMaster.RetailFee += dispOrder.RetailFee;//统计表头的零售金额
                rtnList.Add(dispOrder);
            }
            return rtnList;
        }

        public override YP_DRMaster BuildNewDispenseMaster(object obj, int deptId, int dispenserId)
        {
            throw new NotImplementedException();
        }

        
    }
}
