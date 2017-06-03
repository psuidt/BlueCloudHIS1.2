using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using HIS.Model;
using HIS.SYSTEM;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.DAL;



namespace HIS.YP_BLL
{
    /// <summary>
    /// 药库盘点单处理器
    /// </summary>
    class YK_CheckPorcessor : CheckProcessor
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public YK_CheckPorcessor()
        {
        }

        public override BillMaster SaveBills(List<BillMaster> masterList, long deptId, System.Collections.Hashtable dispDt)
        {
            throw new NotImplementedException();
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
        /// 清除库房盘点状态
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        public override void ClearCheckStatus(long deptId)
        {
            try
            {
                oleDb.BeginTransaction();
                IBaseDAL<YP_CheckMaster> checkMasterDao = BindEntity<HIS.Model.YP_CheckMaster>.CreateInstanceDAL(oleDb,
                        Tables.YK_CHECKMASTER);
                string strWhere = BLL.Tables.yk_checkmaster.AUDIT_FLAG + oleDb.EuqalTo() + "0" + oleDb.And()
                    + BLL.Tables.yk_checkmaster.DEPTID + oleDb.EuqalTo() + deptId.ToString();
                checkMasterDao.Update(strWhere, BLL.Tables.yk_checkmaster.DEL_FLAG + oleDb.EuqalTo() + "1");
                ConfigManager.EndCheck(deptId);
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 创建药库盘点单表头
        /// </summary>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <param name="userId">操作人员ＩＤ</param>
        /// <returns>药库盘点单表头</returns>
        public override HIS.Model.BillMaster BuildNewMaster(long deptId, long userId)
        {
            try
            {
                YP_CheckMaster master = new YP_CheckMaster();
                master.Audit_Flag = 0;
                master.AuditPeopleID = 0;
                master.Del_Flag = 0;
                master.DeptID = Convert.ToInt32(deptId);
                master.RegPeopleID = Convert.ToInt32(userId);
                master.RegTime = XcDate.ServerDateTime;
                master.BillNum = 0;
                BindEntity<HIS.Model.YP_CheckMaster>.CreateInstanceDAL(oleDb, Tables.YK_CHECKMASTER).Add(master);
                return master;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 审核药库盘点单据
        /// </summary>
        /// <param name="billMaster">药库盘点单表头</param>
        /// <param name="auditerID">审核人员ID</param>
        /// <param name="auditDeptID">审核科室ID</param>
        public override void AuditBill(BillMaster billMaster, long auditerID, long auditDeptID)
        {
            try
            {
                //AccountWriter actWriter = AccountFactory.GetWriter(ConfigManager.OP_YF_CHECK);
                //更改标识位              
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                //审核表头对象
                List<BillOrder> totalListOrder = new List<BillOrder>();
                List<YP_CheckOrder> totalBatchOrder = new List<YP_CheckOrder>();
                //获取所有未审核的表头对象
                string str = Tables.yk_checkmaster.AUDIT_FLAG + oleDb.EuqalTo() + "0" + oleDb.And() +
                    Tables.yk_checkmaster.DEL_FLAG + oleDb.NotEqualTo() + "1" + oleDb.And() +
                    Tables.yk_checkmaster.DEPTID + oleDb.EuqalTo() + auditDeptID.ToString();
                List<YP_CheckMaster> listMaster = BindEntity<HIS.Model.YP_CheckMaster>.CreateInstanceDAL(oleDb,
                    Tables.YK_CHECKMASTER).GetListArray(str);
                if (listMaster.Count <= 0)
                {
                    ConfigManager.EndCheck((int)auditDeptID);
                    throw new Exception("没有单据需要审核！");
                }
                DateTime _currentTime = XcDate.ServerDateTime;
                int groupNum = (ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YK_AUDITCHECK,
                           auditDeptID)).BillNum;             
                foreach (YP_CheckMaster checkMaster in listMaster)
                {
                    //如果存在正在盘点的单据号
                    if (checkMaster.BillNum == 0)
                    {
                        throw new Exception("当前还有单据正在盘点，请确认所有盘点单据都保存完成");
                    }
                    checkMaster.Audit_Flag = 1;
                    checkMaster.AuditPeopleID = Convert.ToInt32(auditerID);
                    checkMaster.AuditTime = _currentTime;
                    checkMaster.AuditNum = groupNum;                   
                    //读取审核表头对象对应的审核明细链表
                    str = Tables.yk_checkorder.MASTERCHECKID + oleDb.EuqalTo() + checkMaster.MasterCheckID;                                        
                    List<YP_CheckOrder> listOrder = BindEntity<YP_CheckOrder>.CreateInstanceDAL(oleDb,
                        Tables.YK_CHECKORDER).GetListArray(str);
                    //按厂家批次合并盘点单明细
                    AddOrderListByBatchNum(totalBatchOrder, listOrder);
                }
                AddOrderListByMakerId(totalListOrder, totalBatchOrder);
                oleDb.BeginTransaction();
                foreach (YP_CheckMaster checkMaster in listMaster)
                {
                    BindEntity<YP_CheckMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_CHECKMASTER).Update(checkMaster);
                    string nameAndValue = Tables.yk_checkorder.AUDIT_FLAG + oleDb.EuqalTo() + "1";
                    BindEntity<HIS.Model.YP_CheckOrder>.CreateInstanceDAL(oleDb,
                        Tables.YK_CHECKORDER).Update(BLL.Tables.yk_checkorder.MASTERCHECKID + oleDb.EuqalTo() + checkMaster.MasterCheckID,
                        nameAndValue);
                }
                //更新批次
                StoreFactory.GetProcessor(ConfigManager.OP_YK_CHECK).UpdateBatch(totalBatchOrder);
                YP_CheckMaster newMaster = new YP_CheckMaster();
                newMaster.AuditTime = _currentTime;
                newMaster.AuditPeopleID = Convert.ToInt32(auditerID);
                newMaster.DeptID = Convert.ToInt32(auditDeptID);
                newMaster.OpType = ConfigManager.OP_YK_AUDITCHECK;
                newMaster.BillNum = groupNum;
                Hashtable storeTable = StoreFactory.GetProcessor(ConfigManager.OP_YK_CHECK).ChangeStoreNum(newMaster, totalListOrder);
                AccountFactory.GetWriter(ConfigManager.OP_YK_CHECK).WriteAccount(newMaster, totalListOrder, storeTable);
                ConfigManager.EndCheck((int)auditDeptID);
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
        /// 将多张药库盘点单明细汇总到一张盘点明细表中
        /// </summary>
        /// <param name="totalListOrder">汇总明细表</param>
        /// <param name="listOrder">药库盘点单明细列表</param>
        private void AddOrderListByMakerId(List<BillOrder> totalListOrder, List<YP_CheckOrder> listOrder)
        {
            StoreQuery _storeQuery = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM);
            foreach (YP_CheckOrder orderCheck in listOrder)
            {
                bool isFind = false;
                foreach (YP_CheckOrder totalOrder in totalListOrder)
                {
                    if (totalOrder.MakerDicID == orderCheck.MakerDicID)
                    {
                        totalOrder.CheckNum += orderCheck.CheckNum;
                        totalOrder.FactNum += orderCheck.FactNum;
                        isFind = true;
                        break;
                    }
                }
                if (isFind == false)
                {
                    totalListOrder.Add((YP_CheckOrder)(orderCheck.Clone()));
                }
            }
            foreach (YP_CheckOrder totalOrder in totalListOrder)
            {
                decimal differentNum = totalOrder.CheckNum - totalOrder.FactNum;
                totalOrder.FactNum = _storeQuery.QueryNum(totalOrder.MakerDicID, totalOrder.DeptID);
                totalOrder.CheckNum = totalOrder.FactNum + differentNum;
                totalOrder.CKRetailFee = totalOrder.CheckNum * totalOrder.RetailPrice;
                totalOrder.CKTradeFee = totalOrder.CheckNum * totalOrder.TradePrice;
                totalOrder.FTRetailFee = totalOrder.FactNum * totalOrder.RetailPrice;
                totalOrder.FTTradeFee = totalOrder.FactNum * totalOrder.TradePrice;
            }
        }

        /// <summary>
        /// 按批次汇总多张盘点单明细到汇总明细单中
        /// </summary>
        /// <param name="totalListOrder">汇总明细单</param>
        /// <param name="listOrder">药库盘点单明细列表</param>
        private void AddOrderListByBatchNum(List<YP_CheckOrder> totalListOrder, List<YP_CheckOrder> listOrder)
        {
            foreach (YP_CheckOrder orderCheck in listOrder)
            {
                bool isFind = false;
                foreach (YP_CheckOrder totalOrder in totalListOrder)
                {
                    if (totalOrder.MakerDicID == orderCheck.MakerDicID
                        && totalOrder.BatchNum == orderCheck.BatchNum)
                    {
                        totalOrder.CheckNum += orderCheck.CheckNum;
                        totalOrder.CKRetailFee += orderCheck.CKRetailFee;
                        totalOrder.CKTradeFee += orderCheck.CKTradeFee;
                        isFind = true;
                        break;
                    }
                }
                if (isFind == false)
                {
                    totalListOrder.Add((YP_CheckOrder)(orderCheck.Clone()));
                }
            }
        }

        /// <summary>
        /// 删除药库盘点单
        /// </summary>
        /// <param name="billMaster">药库盘点单表头</param>
        public override void DelBill(BillMaster billMaster)
        {
            try
            {
                YP_CheckMaster master = (YP_CheckMaster)billMaster;
                oleDb.BeginTransaction();
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                IBaseDAL<YP_CheckMaster> checkMaster = BindEntity<HIS.Model.YP_CheckMaster>.CreateInstanceDAL(oleDb,
                    Tables.YK_CHECKMASTER);
                checkMaster.Update(BLL.Tables.yk_checkmaster.MASTERCHECKID + oleDb.EuqalTo() + master.MasterCheckID,
                    BLL.Tables.yk_checkmaster.DEL_FLAG + oleDb.EuqalTo() + "1");
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        
        /// <summary>
        /// 保存药库盘点单
        /// </summary>
        /// <param name="billMaster">药库盘点单表头</param>
        /// <param name="listOrder">药库盘点单明细列表</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_CheckMaster masterCheck = (YP_CheckMaster)billMaster;
                ComputeMasterFee(masterCheck, listOrder);
                oleDb.BeginTransaction();
                YP_CheckMaster inDBMaster = BindEntity<YP_CheckMaster>.CreateInstanceDAL(oleDb,
                    Tables.YK_CHECKMASTER).GetModel(masterCheck.MasterCheckID);
                if (inDBMaster.Del_Flag == 1)
                {
                    throw new Exception("当前单据已经被强制清除，无法保证盘存数量的正确性，请重新录入新的盘点单");
                }
                //声明操作对象
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                YP_CheckOrder checkOrder = new YP_CheckOrder();
                //获取盘点单据号                
                int billNum = (ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YK_CHECK, masterCheck.DeptID)).BillNum;
                masterCheck.BillNum = billNum;
                masterCheck.Del_Flag = 0;
                BindEntity<HIS.Model.YP_CheckMaster>.CreateInstanceDAL(oleDb, Tables.YK_CHECKMASTER).Update(masterCheck);
                foreach (YP_CheckOrder order in listOrder)
                {
                    //遍历DataTable取出明细记录并设置记录的值
                    checkOrder = (YP_CheckOrder)order;
                    checkOrder.MasterCheckID = masterCheck.MasterCheckID;
                    checkOrder.DeptID = masterCheck.DeptID;
                    checkOrder.BillNum = masterCheck.BillNum;
                    checkOrder.BillTime = masterCheck.RegTime;
                    //依次添加明细记录
                    BindEntity<HIS.Model.YP_CheckOrder>.CreateInstanceDAL(oleDb, Tables.YK_CHECKORDER).Add(checkOrder);
                }
                //更新盘点标识位
                ConfigManager.BeginCheck((long)(masterCheck.DeptID));
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 修改药库盘点单据
        /// </summary>
        /// <param name="billMaster">药库盘点单表头</param>
        /// <param name="listOrder">药库盘点单明细列表</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_CheckMaster masterCheck = (YP_CheckMaster)billMaster;
                ComputeMasterFee(masterCheck, listOrder);
                oleDb.BeginTransaction();
                //声明操作对象
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                YP_CheckOrder checkOrder = new YP_CheckOrder();
                BindEntity<HIS.Model.YP_CheckMaster>.CreateInstanceDAL(oleDb, Tables.YK_CHECKMASTER).Update(masterCheck);
                foreach (YP_CheckOrder order in listOrder)
                {
                    checkOrder = (YP_CheckOrder)order;
                    BindEntity<HIS.Model.YP_CheckOrder>.CreateInstanceDAL(oleDb, Tables.YK_CHECKORDER).Update(checkOrder);
                }
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
