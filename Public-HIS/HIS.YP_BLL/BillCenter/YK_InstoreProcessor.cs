using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
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
    /// 药库采购入库单处理器
    /// </summary>
    class YK_InstoreProcessor : InStoreProcessor
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public YK_InstoreProcessor()
        {
        }

        public override BillMaster SaveBills(List<BillMaster> masterList, long deptId, System.Collections.Hashtable dispDt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 构造采购入库单表头
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>采购入库单表头</returns>
        public override BillMaster BuildNewMaster(long deptId, long userId)
        {
            BillMaster rtnMaster = base.BuildNewMaster(deptId, userId);
            ((YP_InMaster)rtnMaster).OpType = ConfigManager.OP_YK_INOPTYPE;
            return rtnMaster;
        }

        public override YP_DRMaster BuildNewDispenseMaster(object obj, int deptId, int dispenserId)
        {
            throw new NotImplementedException();
        }


        public override List<BillOrder> BuildNewDispOrder(System.Data.DataTable recipeOrder,
            YP_DRMaster dispMaster, int dispenseModel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除采购入库单
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        public override void DelBill(BillMaster billMaster)
        {
            try
            {
                YP_InMaster inStore = (YP_InMaster)billMaster;
                oleDb.BeginTransaction();
                IBaseDAL<YP_InMaster> ykInMaster = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_INMASTER);
                ykInMaster.Update(BLL.Tables.yk_inmaster.MASTERINSTORAGEID + oleDb.EuqalTo() + inStore.MasterInStorageID,
                    BLL.Tables.yk_inmaster.DEL_FLAG + oleDb.EuqalTo() + "1");
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 保存采购入库单
        /// </summary>
        /// <param name="billMaster">采购入库单表头</param>
        /// <param name="listOrder">采购入库单明细</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                
                YP_InMaster masterInstore = (YP_InMaster)billMaster;
                YP_InOrder inStore = new YP_InOrder();
                oleDb.BeginTransaction();
                //声明操作对象
                IBaseDAL<YP_InMaster> inMasterDao = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_INMASTER);
                IBaseDAL<YP_InOrder> inOrderDao = BindEntity<YP_InOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YK_INORDER);
                IBaseDAL<YP_Storage> storeDao = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, BLL.Tables.YK_STORAGE);
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                //获取入库单据号
                if (masterInstore.OpType == ConfigManager.OP_YK_INOPTYPE)
                {
                    masterInstore.BillNum = ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YK_INOPTYPE, deptId).BillNum;
                }
                else if (masterInstore.OpType == ConfigManager.OP_YK_BACKSTORE)
                {
                    masterInstore.BillNum = ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YK_BACKSTORE, deptId).BillNum;
                }
                else
                {
                    masterInstore.BillNum = ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YK_FIRSTIN, deptId).BillNum;
                }
                inMasterDao.Add(masterInstore);
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
                    //依次添加明细记录
                    inOrderDao.Add(inStore);
                }
                inMasterDao.Update(masterInstore);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 药库入库单审核
        /// </summary>
        /// <param name="billMaster">药库入库单头表</param>
        /// <param name="auditerID">审核人员ID</param>
        /// <param name="auditDeptID">审核部门ID</param>
        public override void AuditBill(BillMaster billMaster, long auditerID, long auditDeptID)
        {
            try
            {
                YP_InMaster inStore = (YP_InMaster)billMaster;
                string strWhere = BLL.Tables.yk_inmaster.MASTERINSTORAGEID + oleDb.EuqalTo() + inStore.MasterInStorageID
                + oleDb.And() + BLL.Tables.yk_inmaster.AUDIT_FLAG + oleDb.EuqalTo() + "1";
                if (BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_INMASTER).Exists(strWhere))
                {
                    throw new Exception("该张单据已经审核过。。。");
                }
                oleDb.BeginTransaction();
                DateTime _currentTime = XcDate.ServerDateTime;
                inStore.AuditTime = _currentTime;
                inStore.Audit_Flag = 1;
                inStore.AuditPeopleID = Convert.ToInt32(auditerID);
                IBaseDAL<YP_InOrder> ykInOrder = BindEntity<YP_InOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YK_INORDER);
                IBaseDAL<YP_InMaster> ykInMaster = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_INMASTER);
                List<YP_InOrder> listStore = ykInOrder.GetListArray("MasterInStorageID=" + inStore.MasterInStorageID + "");
                base.AuditPrice(inStore, listStore, ConfigManager.YK_SYSTEM);
                ykInMaster.Update(inStore);
                List<BillOrder> listOrder = new List<BillOrder>();
                AccountWriter actWriter = AccountFactory.GetWriter(inStore.OpType);
                foreach (YP_InOrder orderInstore in listStore)
                {
                    orderInstore.Audit_Flag = 1;
                    ykInOrder.Update(orderInstore);
                    listOrder.Add(orderInstore);
                }
                Hashtable storeTable = StoreFactory.GetProcessor(inStore.OpType).ChangeStoreNum(billMaster, listOrder);
                AccountFactory.GetWriter(inStore.OpType).WriteAccount(billMaster, listOrder, storeTable);
                oleDb.CommitTransaction();
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
        /// 修改采购入库单
        /// </summary>
        /// <param name="billMaster">采购入库单表头</param>
        /// <param name="listOrder">采购入库单明细列表</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_InMaster masterInstore = (YP_InMaster)billMaster;
                YP_InOrder orderInstore = new YP_InOrder();
                oleDb.BeginTransaction();
                //声明操作对象
                IBaseDAL<YP_InMaster> inMasterDao = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_INMASTER);
                IBaseDAL<YP_InOrder> inOrderDao = BindEntity<YP_InOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YK_INORDER);
                //如果明细不为空重新更新整个入库单表头及明细
                if (listOrder != null)
                {
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
                }
                //明细为空仅更新表头
                inMasterDao.Update(masterInstore);
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
