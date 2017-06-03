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
    /// 药房期初入库单处理器
    /// </summary>
    class YF_InstoreProcessor : InStoreProcessor
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public YF_InstoreProcessor()
        {
        }

        public override BillMaster SaveBills(List<BillMaster> masterList, long deptId, System.Collections.Hashtable dispDt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建药房期初入库单表头
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>药房期初入库单表头</returns>
        public override BillMaster BuildNewMaster(long deptId, long userId)
        {
            BillMaster rtnMaster = base.BuildNewMaster(deptId, userId);
            ((YP_InMaster)rtnMaster).OpType = ConfigManager.OP_YF_INSTORE;
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
        /// 删除药房期初入库单
        /// </summary>
        /// <param name="billMaster">药房期初入库单表头</param>
        public override void DelBill(BillMaster billMaster)
        {
            try
            {
                YP_InMaster inStore = (YP_InMaster)billMaster;
                oleDb.BeginTransaction();
                IBaseDAL<YP_InMaster> yfInMaster = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INMASTER);
                yfInMaster.Update(BLL.Tables.yf_inmaster.MASTERINSTORAGEID + oleDb.EuqalTo() + inStore.MasterInStorageID,
                    BLL.Tables.yf_inmaster.DEL_FLAG + oleDb.EuqalTo() + "1");
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                int deleteID = ypDal.YK_Outmaster_GetIDByBillNum(inStore.BillNum, inStore.DeptID);
                //做关联删除
                if (deleteID != -1)
                {
                    IBaseDAL<YP_OutMaster> ykOutMaster = BindEntity<YP_OutMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_OUTMASTER);
                    ykOutMaster.Update(BLL.Tables.yk_outmaster.MASTEROUTSTORAGEID + oleDb.EuqalTo() + deleteID,
                        BLL.Tables.yk_outmaster.DEL_FLAG + oleDb.EuqalTo() + "1");
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
        /// 保存药房期初入库单
        /// </summary>
        /// <param name="billMaster">期初入库单表头</param>
        /// <param name="listOrder">期初入库单明细列表</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_InOrder orderInstore;
                YP_InMaster masterInstore = (YP_InMaster)billMaster;
                oleDb.BeginTransaction();
                //声明操作对象
                IBaseDAL<YP_InMaster> inMasterDao = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INMASTER);
                IBaseDAL<YP_InOrder> inOrderDao = BindEntity<YP_InOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INORDER);
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                //获取入库单据号
                masterInstore.BillNum = (ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YF_INSTORE, deptId)).BillNum;
                masterInstore.OpType = ConfigManager.OP_YF_INSTORE;
                inMasterDao.Add(masterInstore);
                foreach (BillOrder order in listOrder)
                {
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
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }


        /// <summary>
        /// 审核药房期初入库单
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="auditerID">审核人员ID</param>
        /// <param name="auditDeptID">审核科室ID</param>
        public override void AuditBill(BillMaster billMaster, long auditerID, long auditDeptID)
        {
            YP_InMaster inStore = (YP_InMaster)billMaster;
            string strWhere = BLL.Tables.yf_inmaster.MASTERINSTORAGEID + oleDb.EuqalTo() + inStore.MasterInStorageID
                + oleDb.And() + BLL.Tables.yf_inmaster.AUDIT_FLAG + oleDb.EuqalTo() + "1";
            if (BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INMASTER).Exists(strWhere))
            {
                throw new Exception("该张单据已经审核过。。。");
            }
            try
            {
                oleDb.BeginTransaction();
                IBaseDAL<YP_InMaster> masterDao = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INMASTER);
                IBaseDAL<YP_InOrder> orderDao = BindEntity<YP_InOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INORDER);
                AccountWriter actWriter = AccountFactory.GetWriter(inStore.OpType);
                inStore.AuditTime = XcDate.ServerDateTime;
                inStore.Audit_Flag = 1;
                inStore.AuditPeopleID = Convert.ToInt32(auditerID);               
                List<YP_InOrder> listStore = orderDao.GetListArray("MasterInStorageID=" + inStore.MasterInStorageID + "");
                //按最新价格更新单据
                base.AuditPrice(inStore, listStore, ConfigManager.YF_SYSTEM);
                masterDao.Update(inStore);
                List<BillOrder> listOrder = new List<BillOrder>();
                foreach (YP_InOrder orderInstore in listStore)
                {
                    orderInstore.Audit_Flag = 1;
                    orderDao.Update(orderInstore);
                    listOrder.Add(orderInstore);
                }
                Hashtable storeTable = StoreFactory.GetProcessor(inStore.OpType).ChangeStoreNum(billMaster, listOrder);
                AccountFactory.GetWriter(inStore.OpType).WriteAccount(billMaster, listOrder, storeTable);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                inStore.Audit_Flag = 0;
                throw error;
            }
        }

        /// <summary>
        /// 修改药房期初入库单
        /// </summary>
        /// <param name="billMaster">期初入库单表头</param>
        /// <param name="listOrder">期初入库单明细列表</param>
        /// <param name="deptId">药剂科室ID</param>
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
