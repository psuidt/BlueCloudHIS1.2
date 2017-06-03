using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
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
    /// 药房申请入库单处理器
    /// </summary>
    class ApplyInProcessor : YF_InstoreProcessor
    {
        /// <summary>
        /// 是否平级调拨
        /// </summary>
        private static bool boPjdb = false;
        public override BillMaster BuildNewMaster(long deptId, long userId)
        {
            BillMaster rtnMaster = base.BuildNewMaster(deptId, userId);
            ((YP_InMaster)rtnMaster).OpType = ConfigManager.OP_YF_APPLYIN;
            return rtnMaster;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ApplyInProcessor()
        {
        }

        /// <summary>
        /// 根据入库表头生成出库表头并添加到数据库中
        /// </summary>
        /// <param name="masterDao">出库表头数据访问对象</param>
        /// <param name="inMaster">入库表头</param>
        /// <param name="ypDal">数据访问层对象</param>
        /// <param name="storedeptId">入库部门ID</param>
        private YP_OutMaster AddYKOutMaster(IBaseDAL<YP_OutMaster> masterDao, YP_InMaster inMaster, YP_Dal ypDal, int storedeptId)
        {
            YP_OutMaster outMaster = new YP_OutMaster();

            if (HIS.SYSTEM.Core.BindEntity<object>.CreateInstanceDAL(oleDb, "YP_DEPTDIC").GetFieldValue("DEPTTYPE1", "DEPTID=" + storedeptId).ToString() == "药房")
                boPjdb = true;
            else
                boPjdb = false;
            if (boPjdb == true)
            {
                ChangeInmasterToOutmaster1(inMaster, storedeptId, outMaster);
                //update 20100624           
                outMaster.BillNum = ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YF_DEPTDRAW, storedeptId).BillNum;
            }
            else
            {
                ChangeInmasterToOutmaster(inMaster, storedeptId, outMaster);
                //update 20100624           
                outMaster.BillNum = ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YK_OUTTOYF, storedeptId).BillNum;
            }
            masterDao.Add(outMaster);
            return outMaster;
        }

        /// <summary>
        /// 将药房申请入库单表头转换为药库出库单表头
        /// </summary>
        /// <param name="inMaster">入库单头表</param>
        /// <param name="storedeptId">出库库房ＩＤ</param>
        /// <param name="outMaster">出库单表头</param>
        /// <returns>出库单表头</returns>
        private static YP_OutMaster ChangeInmasterToOutmaster(YP_InMaster inMaster, int storedeptId, YP_OutMaster outMaster)
        {
            outMaster.BillDate = inMaster.BillDate;
            outMaster.Del_Flag = 0;
            outMaster.OpType = ConfigManager.OP_YK_OUTTOYF;
            
            outMaster.OutFee = inMaster.RetailFee;
            outMaster.RegTime = inMaster.RegTime;
            outMaster.RelationNum = inMaster.BillNum;
            outMaster.ReMark = inMaster.ReMark;
            outMaster.RetailFee = inMaster.RetailFee;
            outMaster.TradeFee = inMaster.TradeFee;
            outMaster.DeptID = storedeptId;
            outMaster.OutDeptId = inMaster.DeptID;
            outMaster.RegPeopleID = inMaster.RegPeopleID;
            return outMaster;
        }

        /// <summary>
        /// 将药房申请入库单表头转换为药库出库单表头
        /// </summary>
        /// <param name="inMaster">入库单头表</param>
        /// <param name="storedeptId">出库库房ＩＤ</param>
        /// <param name="outMaster">出库单表头</param>
        /// <returns>出库单表头</returns>
        private static YP_OutMaster ChangeInmasterToOutmaster1(YP_InMaster inMaster, int storedeptId, YP_OutMaster outMaster)
        {
            outMaster.BillDate = inMaster.BillDate;
            outMaster.Del_Flag = 0;
            outMaster.OpType = ConfigManager.OP_YF_DEPTDRAW;
            outMaster.OutFee = inMaster.RetailFee;
            outMaster.RegTime = inMaster.RegTime;
            outMaster.RelationNum = inMaster.BillNum;
            outMaster.ReMark = inMaster.ReMark;
            outMaster.RetailFee = inMaster.RetailFee;
            outMaster.TradeFee = inMaster.TradeFee;
            outMaster.DeptID = storedeptId;
            outMaster.OutDeptId = inMaster.DeptID;
            outMaster.RegPeopleID = inMaster.RegPeopleID;
            return outMaster;
        }

        /// <summary>
        /// 根据出库表明细生成出库表明细并添加到数据库中
        /// </summary>
        /// <param name="orderDao">出库表明细数据访问对象</param>
        /// <param name="inOrder">入库表明细</param>
        /// <param name="deptId">入库部门ＩＤ</param>
        /// <param name="outMaster">出库表头</param>
        private void AddYKOutOrder(IBaseDAL<YP_OutOrder> orderDao, YP_InOrder inOrder, long deptId, YP_OutMaster outMaster)
        {
            YP_OutOrder outOrder = ChangeInorderToOutorder(inOrder, outMaster);
            orderDao.Add(outOrder);
        }

        /// <summary>
        /// 将药房申请入库单明细转换为药库出库单明细
        /// </summary>
        /// <param name="inOrder">入库单明细</param>
        /// <param name="outMaster">药库出库单表头</param>
        /// <returns>药库出库单明细</returns>
        private static YP_OutOrder ChangeInorderToOutorder(YP_InOrder inOrder, YP_OutMaster outMaster)
        {
            YP_OutOrder outOrder = new YP_OutOrder();
            outOrder.Audit_Flag = 0;
            outOrder.LeastUnit = inOrder.LeastUnit;
            outOrder.MakerDicID = inOrder.MakerDicID;
            outOrder.MasterOutStorageID = outMaster.MasterOutStorageID;
            outOrder.OutNum = inOrder.InNum;
            outOrder.ProductNum = inOrder.BatchNum;
            outOrder.RecScale = inOrder.RecScale;
            outOrder.Remark = inOrder.Remark;
            outOrder.RetailFee = inOrder.RetailFee;
            outOrder.RetailPrice = inOrder.RetailPrice;
            outOrder.TradeFee = inOrder.TradeFee;
            outOrder.TradePrice = inOrder.TradePrice;
            outOrder.UnitNum = inOrder.UnitNum;
            outOrder.ValidityDate = inOrder.ValidityDate;
            outOrder.DeptID = outMaster.DeptID;
            outOrder.OutDeptID = outMaster.OutDeptId;
            outOrder.BillNum = inOrder.BillNum;
            return outOrder;
        }

        /// <summary>
        /// 审核药房申请入库单
        /// </summary>
        /// <param name="billMaster">药房申请入库单表头</param>
        /// <param name="auditerID">审核人员ＩＤ</param>
        /// <param name="auditDeptID">审核科室ＩＤ</param>
        public override void AuditBill(BillMaster billMaster, long auditerID, long auditDeptID)
        {
            YP_InMaster inStore = (YP_InMaster)billMaster;
            try
            {
                ////update 20100624
                if (HIS.SYSTEM.Core.BindEntity<object>.CreateInstanceDAL(oleDb, "YP_DEPTDIC").GetFieldValue("DEPTTYPE1", "DEPTID=" + inStore.DeptID).ToString() == "药房")
                    boPjdb = true;
                else
                    boPjdb = false;
                if (billMaster == null)
                {
                    throw new Exception("对应领药单丢失");
                }
                IBaseDAL<YP_InMaster> yfInMaster = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INMASTER);
                IBaseDAL<YP_InOrder> yfInOrder = BindEntity<YP_InOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INORDER);
                List<YP_InOrder> listOrder = yfInOrder.GetListArray("MasterInStorageID=" + inStore.MasterInStorageID + "");
                List<BillOrder> billListOrder = new List<BillOrder>();
                base.AuditPrice(inStore, listOrder, ConfigManager.YF_SYSTEM);
                inStore.AuditTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                inStore.Audit_Flag = 1;
                inStore.AuditPeopleID = Convert.ToInt32(auditerID);
                yfInMaster.Update(inStore);
                foreach (YP_InOrder orderInstore in listOrder)
                {
                    orderInstore.Audit_Flag = 1;
                    yfInOrder.Update(orderInstore);
                    billListOrder.Add(orderInstore);
                }


                Hashtable storeTable;
                if (((YP_InMaster)billMaster).OpType==ConfigManager.OP_YF_PJDB)
                {
                    ((YP_InMaster)billMaster).OpType=ConfigManager.OP_YF_APPLYIN;
                    storeTable = StoreFactory.GetProcessor(ConfigManager.OP_YF_APPLYIN).ChangeStoreNum(billMaster, billListOrder);

                }
                else
                {
                    storeTable = StoreFactory.GetProcessor(inStore.OpType).ChangeStoreNum(billMaster, billListOrder);
 
                }
                AccountFactory.GetWriter(inStore.OpType).WriteAccount(billMaster, billListOrder, storeTable);
            }
            catch (Exception error)
            {
                inStore.Audit_Flag = 0;
                throw error;
            }
        }

        /// <summary>
        /// 保存药房入库申请单
        /// </summary>
        /// <param name="billMaster">申请单表头</param>
        /// <param name="listOrder">申请单明细</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {                
                IBaseDAL<YP_OutMaster> outMasterDao ;
                IBaseDAL<YP_OutOrder> outOrderDao ;
                IBaseDAL<YP_Storage> storeDao;
                YP_InMaster masterInstore = (YP_InMaster)billMaster;
                ////update 20100624
                if (HIS.SYSTEM.Core.BindEntity<object>.CreateInstanceDAL(oleDb, "YP_DEPTDIC").GetFieldValue("DEPTTYPE1", "DEPTID=" + deptId).ToString() == "药房")
                    boPjdb = true;
                else
                    boPjdb = false;
                YP_InOrder inStore = new YP_InOrder();
                oleDb.BeginTransaction();
                IBaseDAL<YP_InMaster> inMasterDao = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INMASTER);
                IBaseDAL<YP_InOrder> inOrderDao = BindEntity<YP_InOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INORDER);
                if (boPjdb)
                {
                    outMasterDao = BindEntity<YP_OutMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTMASTER);
                    outOrderDao = BindEntity<YP_OutOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTORDER);
                    storeDao = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, BLL.Tables.YF_STORAGE);
                    
                }
                else
                {
                    outMasterDao = BindEntity<YP_OutMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_OUTMASTER);
                    outOrderDao = BindEntity<YP_OutOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YK_OUTORDER);
                    storeDao = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, BLL.Tables.YK_STORAGE);

                    
                }
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                //获取入库单据号
                masterInstore.BillNum = (ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YF_APPLYIN, masterInstore.DeptID)).BillNum;
                if(!boPjdb)
                masterInstore.OpType = ConfigManager.OP_YF_APPLYIN;
                inMasterDao.Add(masterInstore);
                YP_OutMaster outMaster = AddYKOutMaster(outMasterDao, masterInstore, ypDal, Convert.ToInt32(deptId));
                foreach (BillOrder order in listOrder)
                {
                    //遍历DataTable取出明细记录并设置记录的值
                    inStore = (YP_InOrder)order;
                    //计算入库金额
                    masterInstore.RetailFee += inStore.RetailFee;
                    masterInstore.StockFee += inStore.StockFee;
                    masterInstore.TradeFee += inStore.TradeFee;
                    inStore.MasterInStorageID = masterInstore.MasterInStorageID;
                    inStore.BillNum = masterInstore.BillNum;
                    inStore.DeptID = masterInstore.DeptID;
                    //依次添加明细记录
                    inOrderDao.Add(inStore);
                    AddYKOutOrder(outOrderDao, inStore, deptId, outMaster);
                }
                inMasterDao.Update(masterInstore);
                outMaster.RetailFee = masterInstore.RetailFee;
                outMaster.TradeFee = masterInstore.TradeFee;
                outMaster.OutFee = masterInstore.RetailFee;
                outMasterDao.Update(outMaster);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 修改药房申请入库单
        /// </summary>
        /// <param name="billMaster">申请入库单表头</param>
        /// <param name="listOrder">申请入库单明细</param>
        /// <param name="deptId">出库科室ID</param>
        public override void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_InMaster masterInstore = (YP_InMaster)billMaster;
                YP_InOrder orderInstore = new YP_InOrder();
                oleDb.BeginTransaction();
                //声明操作对象
                IBaseDAL<YP_InMaster> inMasterDao = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INMASTER);
                IBaseDAL<YP_InOrder> inOrderDao = BindEntity<YP_InOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INORDER);
                masterInstore.RetailFee = 0;
                masterInstore.StockFee = 0;
                masterInstore.TradeFee = 0;
                inOrderDao.Delete("MasterInStorageID=" + masterInstore.MasterInStorageID.ToString());
                foreach (BillOrder order in listOrder)
                {
                    //遍历DataTable取出明细记录并设置记录的值
                    orderInstore = (YP_InOrder)order;
                    //计算入库金额
                    masterInstore.RetailFee += orderInstore.RetailFee;
                    masterInstore.TradeFee += orderInstore.TradeFee;
                    masterInstore.StockFee += orderInstore.StockFee;
                    orderInstore.MasterInStorageID = masterInstore.MasterInStorageID;
                    orderInstore.BillNum = masterInstore.BillNum;
                    //依次添加明细记录
                    inOrderDao.Add(orderInstore);
                }
                inMasterDao.Update(masterInstore);
                orderInstore = UpdateOutMaster(listOrder, deptId, masterInstore, orderInstore);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 根据药房申请入库单更新对应药库出库单明细
        /// </summary>
        /// <param name="listOrder">药库出库单明细列表</param>
        /// <param name="deptId">出库科室ＩＤ</param>
        /// <param name="masterInstore">药房申请入库单</param>
        /// <param name="orderInstore">申请入库单明细</param>
        /// <returns>申请入库单明细</returns>
        private YP_InOrder UpdateOutMaster(List<BillOrder> listOrder, long deptId, YP_InMaster masterInstore, YP_InOrder orderInstore)
        {
            IBaseDAL<YP_OutMaster> ypOutMaster;
            IBaseDAL<YP_OutOrder> outOrderDao;
            string strWhere;
            //update 20100624
            if (HIS.SYSTEM.Core.BindEntity<object>.CreateInstanceDAL(oleDb, "YP_DEPTDIC").GetFieldValue("DEPTTYPE1", "DEPTID=" + deptId).ToString() == "药房")
                boPjdb = true;
            else
                boPjdb = false;
            if (boPjdb)
            {
                ypOutMaster = BindEntity<YP_OutMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTMASTER);
                strWhere = BLL.Tables.yf_outmaster.BILLNUM + oleDb.EuqalTo() + masterInstore.BillNum
                    + oleDb.And() + BLL.Tables.yf_outmaster.OPTYPE + oleDb.EuqalTo() + "'" + ConfigManager.OP_YF_DEPTDRAW + "'"
                    + oleDb.And() + BLL.Tables.yf_outmaster.AUDIT_FLAG + oleDb.EuqalTo() + 0
                    + oleDb.And() + BLL.Tables.yf_outmaster.REGTIME + oleDb.EuqalTo() + "'" + masterInstore.RegTime + "'";
            }
            else
            {
                ypOutMaster = BindEntity<YP_OutMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_OUTMASTER);
                strWhere = BLL.Tables.yk_outmaster.RELATIONNUM + oleDb.EuqalTo() + masterInstore.BillNum
                    + oleDb.And() + BLL.Tables.yk_outmaster.OPTYPE + oleDb.EuqalTo() + "'" + ConfigManager.OP_YK_OUTTOYF + "'"
                    + oleDb.And() + BLL.Tables.yk_outmaster.AUDIT_FLAG + oleDb.EuqalTo() + 0
                    + oleDb.And() + BLL.Tables.yk_outmaster.REGTIME + oleDb.EuqalTo() + "'" + masterInstore.RegTime + "'";
            }
            YP_OutMaster outMaster = ypOutMaster.GetModel(strWhere);
            outMaster.RetailFee = 0;
            outMaster.TradeFee = 0;
            outMaster.OutFee = 0;
            if (outMaster != null)
            {
                int storeDeptId = outMaster.DeptID;
                ChangeInmasterToOutmaster(masterInstore, storeDeptId, outMaster);
                if (boPjdb)
                {
                    outOrderDao = BindEntity<YP_OutOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTORDER);
                    outOrderDao.Delete(BLL.Tables.yf_outorder.MASTEROUTSTORAGEID
                        + oleDb.EuqalTo() + outMaster.MasterOutStorageID);
                }
                else
                {
                    outOrderDao = BindEntity<YP_OutOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YK_OUTORDER);
                    outOrderDao.Delete(BLL.Tables.yk_outorder.MASTEROUTSTORAGEID
                        + oleDb.EuqalTo() + outMaster.MasterOutStorageID);
                }                
                foreach (BillOrder order in listOrder)
                {
                    orderInstore = (YP_InOrder)order;
                    AddYKOutOrder(outOrderDao, orderInstore, deptId, outMaster);
                }
            }
            ypOutMaster.Update(outMaster);
            return orderInstore;
        }

        
    }
}
