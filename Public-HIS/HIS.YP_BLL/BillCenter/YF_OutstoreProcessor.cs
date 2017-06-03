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
    class YF_OutstoreProcessor : OutStoreProcessor
    {
        public YF_OutstoreProcessor()
        {
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

        public override BillMaster BuildNewMaster(long deptId, long userId)
        {
            return base.BuildNewMaster(deptId, userId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="billMaster"></param>
        /// <param name="auditerID"></param>
        /// <param name="auditDeptID"></param>
        public override void AuditBill(BillMaster billMaster, long auditerID, long auditDeptID)
        {
            YP_OutMaster outStore = (YP_OutMaster)billMaster;
            string strWhere = BLL.Tables.yf_outmaster.MASTEROUTSTORAGEID + oleDb.EuqalTo() + outStore.MasterOutStorageID
                + oleDb.And() + BLL.Tables.yf_outmaster.AUDIT_FLAG + oleDb.EuqalTo() + "1";
            if (BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTMASTER).Exists(strWhere))
            {
                throw new Exception("该张单据已经审核过。。。");
            }
            try
            {
                //更改标识位
                oleDb.BeginTransaction();
                DateTime _currentTime = XcDate.ServerDateTime;
                IBaseDAL<YP_OutMaster> masterDao = BindEntity<YP_OutMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTMASTER);
                IBaseDAL<YP_OutOrder> orderDao = BindEntity<YP_OutOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTORDER);
                //审核表头信息
                outStore.Audit_Flag = 1;
                outStore.AuditTime = _currentTime;
                outStore.AuditPeopleID = Convert.ToInt32(auditerID);               
                //获取明细对象链表
                List<YP_OutOrder> listStore = orderDao.GetListArray("MasterOutStorageID=" + outStore.MasterOutStorageID + "");
                base.AuditPrice(outStore, listStore, ConfigManager.YF_SYSTEM);
                masterDao.Update(outStore);
                List<BillOrder> listOrder = new List<BillOrder>();
                //审核明细
                foreach (YP_OutOrder orderOutstore in listStore)
                {
                    orderOutstore.Audit_Flag = 1;
                    orderDao.Update(orderOutstore);
                    listOrder.Add(orderOutstore);
                }
                Hashtable storeTable = StoreFactory.GetProcessor(outStore.OpType).ChangeStoreNum(billMaster, listOrder);
                AccountFactory.GetWriter(outStore.OpType).WriteAccount(billMaster, listOrder, storeTable);
                //如果是药房申领单，则对药房入库申领单进行审核
//add  平级药房调拨 张运辉 [20100531]
                object obj = HIS.SYSTEM.Core.BindEntity<object>.CreateInstanceDAL(oleDb, "yp_deptdic").GetFieldValue("DEPTTYPE1", "DEPTID=" + outStore.OutDeptId);
                if (obj != null&&obj.ToString() == "药房")
                //if (outStore.OpType == ConfigManager.OP_YF_APPLYIN)
                {
                    BillMaster inStore;
                    IBaseDAL<YP_InMaster> yfInMaster = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INMASTER);
                    inStore = yfInMaster.GetModel("BillNum=" + outStore.RelationNum.ToString()
                        + " AND OpType='" + ConfigManager.OP_YF_PJDB + "'"
                        + " AND Audit_Flag=0" + " AND DeptID=" + outStore.OutDeptId.ToString());
                    new ApplyInProcessor().AuditBill(inStore, auditerID, auditDeptID);
                }
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                outStore.Audit_Flag = 0;
                if (oleDb.IsInTransaction)
                {
                    oleDb.RollbackTransaction();
                }
                throw error;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="billMaster"></param>
        public override void DelBill(BillMaster billMaster)
        {
            try
            {
                YP_OutMaster outStore = (YP_OutMaster)billMaster;
                oleDb.BeginTransaction();
                IBaseDAL<YP_OutMaster> masterDao = BindEntity<YP_OutMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTMASTER);
                //删除表头信息
                masterDao.Update(BLL.Tables.yf_outmaster.MASTEROUTSTORAGEID + oleDb.EuqalTo() + outStore.MasterOutStorageID,
                    BLL.Tables.yf_outmaster.DEL_FLAG + oleDb.EuqalTo() + "1");
                //如果是药品平级调拨
//add  平级药房调拨 张运辉 [20100531]
                object obj = HIS.SYSTEM.Core.BindEntity<HIS.BLL.Tables.yp_deptdic>.CreateInstanceDAL(oleDb).GetFieldValue("DEPTTYPE1", "DEPTID=" + outStore.OutDeptId);
                if (obj != null && obj.ToString() == "药房")
                {
                    IBaseDAL<YP_InMaster> yfInMaster = BindEntity<YP_InMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INMASTER);
                    yfInMaster.Update("BillNum=" + outStore.RelationNum.ToString()
                        + " AND OpType='" + ConfigManager.OP_YF_APPLYIN + "'"
                        + " AND Audit_Flag=0" + " AND DeptID=" + outStore.OutDeptId.ToString(), "DEL_FLAG=1");
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
        /// 
        /// </summary>
        /// <param name="billMaster"></param>
        /// <param name="listOrder"></param>
        /// <param name="deptId"></param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_OutMaster masterOutstore = (YP_OutMaster)billMaster;
                oleDb.BeginTransaction();
                //声明操作对象
                IBaseDAL<YP_OutMaster> masterDao = BindEntity<YP_OutMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTMASTER);
                IBaseDAL<YP_OutOrder> orderDao = BindEntity<YP_OutOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTORDER);
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                YP_OutOrder outStore = new YP_OutOrder();
                int billNum = (ypDal.YP_Bill_GetBillNum(masterOutstore.OpType, deptId)).BillNum;
                masterOutstore.BillNum = billNum;
                masterDao.Add(masterOutstore);
                foreach (BillOrder order in listOrder)
                {
                    outStore = (YP_OutOrder)order;
                    masterOutstore.RetailFee += outStore.RetailFee;
                    masterOutstore.TradeFee += outStore.TradeFee;
                    masterOutstore.OutFee += outStore.RetailFee;
                    outStore.MasterOutStorageID = masterOutstore.MasterOutStorageID;
                    outStore.BillNum = billNum;
                    //依次添加明细记录
                    orderDao.Add(outStore);
                }
                masterDao.Update(masterOutstore);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        public override BillMaster SaveBills(List<BillMaster> masterList, long deptId, System.Collections.Hashtable dispDt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="billMaster"></param>
        /// <param name="listOrder"></param>
        /// <param name="deptId"></param>
        public override void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_OutMaster masterOutstore = (YP_OutMaster)billMaster;
                oleDb.BeginTransaction();
                IBaseDAL<YP_OutMaster> masterDao;
                IBaseDAL<YP_OutOrder> orderDao;
                YP_OutOrder outStore = new YP_OutOrder();
                //声明操作对象
                masterDao = BindEntity<YP_OutMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTMASTER);
                orderDao = BindEntity<YP_OutOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YF_OUTORDER);
                //删除以前的明细信息
                orderDao.Delete("MasterOutStorageID" + oleDb.EuqalTo() + masterOutstore.MasterOutStorageID);
                masterOutstore.TradeFee = 0;
                masterOutstore.RetailFee = 0;
                foreach (BillOrder order in listOrder)
                {

                    //遍历DataTable取出明细记录并设置记录的值
                    outStore = (YP_OutOrder)order;
                    masterOutstore.TradeFee += outStore.TradeFee;
                    masterOutstore.RetailFee += outStore.RetailFee;
                    outStore.MasterOutStorageID = masterOutstore.MasterOutStorageID;
                    outStore.BillNum = masterOutstore.BillNum;
                    //依次添加明细记录
                    orderDao.Add(outStore);
                }
                masterDao.Update(masterOutstore);
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
