using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
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
    /// 药房盘点处理器
    /// </summary>
    class YF_CheckPorcessor : CheckProcessor
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public YF_CheckPorcessor()
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
                        Tables.YF_CHECKMASTER);
                string strWhere = BLL.Tables.yf_checkmaster.AUDIT_FLAG + oleDb.EuqalTo() + "0" + oleDb.And()
                    + BLL.Tables.yf_checkmaster.DEPTID + oleDb.EuqalTo() + deptId.ToString();
                checkMasterDao.Update(strWhere, BLL.Tables.yf_checkmaster.DEL_FLAG + oleDb.EuqalTo() + "1");
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
        /// 创建盘点表头
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>盘点表头</returns>
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
                BindEntity<HIS.Model.YP_CheckMaster>.CreateInstanceDAL(oleDb, Tables.YF_CHECKMASTER).Add(master);
                return master;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 审核盘点单
        /// </summary>
        /// <param name="billMaster">单据头表</param>
        /// <param name="auditerID">审核人员ID</param>
        /// <param name="auditDeptID">审核科室ID</param>
        public override void AuditBill(BillMaster billMaster, long auditerID, long auditDeptID)
        {
            try
            {
                //更改标识位
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                //审核表头对象
                List<BillOrder> totalListOrder = new List<BillOrder>();
                string str = Tables.yf_checkmaster.AUDIT_FLAG + oleDb.EuqalTo() + "0" + oleDb.And() +
                    Tables.yf_checkmaster.DEL_FLAG + oleDb.NotEqualTo() + "1" + oleDb.And() +
                    Tables.yf_checkmaster.DEPTID + oleDb.EuqalTo() + auditDeptID.ToString();
                List<YP_CheckMaster> listMaster = BindEntity<HIS.Model.YP_CheckMaster>.CreateInstanceDAL(oleDb,
                    Tables.YF_CHECKMASTER).GetListArray(str);
                if (listMaster.Count <= 0)
                {
                    ConfigManager.EndCheck((int)auditerID);
                    throw new Exception("没有单据需要审核！");
                }
                DateTime _currentTime = XcDate.ServerDateTime;
                int groupNum = (ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YF_AUDITCHECK,
                    auditDeptID)).BillNum;
                foreach (YP_CheckMaster checkMaster in listMaster)
                {
                    if (checkMaster.BillNum == 0)
                    {
                        throw new Exception("当前还有单据在盘点中,请确认所有盘点单据都保存成功");
                    }
                    checkMaster.AuditNum = groupNum;
                    checkMaster.Audit_Flag = 1;
                    checkMaster.AuditPeopleID = Convert.ToInt32(auditerID);
                    checkMaster.AuditTime = _currentTime;
                    checkMaster.DeptID = Convert.ToInt32(auditDeptID);                   
                    //读取审核表头对象对应的审核明细链表
                    str = Tables.yf_checkorder.MASTERCHECKID + oleDb.EuqalTo() + checkMaster.MasterCheckID;
                    List<YP_CheckOrder> listOrder = BindEntity<HIS.Model.YP_CheckOrder>.CreateInstanceDAL(oleDb,
                        Tables.YF_CHECKORDER).GetListArray(str);
                    //构建盘点汇总明细表
                    AddOrderListByMakerId(totalListOrder, listOrder);
                }
                oleDb.BeginTransaction();
                foreach (YP_CheckMaster checkMaster in listMaster)
                {
                    BindEntity<YP_CheckMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_CHECKMASTER).Update(checkMaster);
                    string nameAndValue = Tables.yf_checkorder.AUDIT_FLAG + oleDb.EuqalTo() + "1";
                    BindEntity<HIS.Model.YP_CheckOrder>.CreateInstanceDAL(oleDb,
                        Tables.YF_CHECKORDER).Update(BLL.Tables.yf_checkorder.MASTERCHECKID + oleDb.EuqalTo() + checkMaster.MasterCheckID,
                        nameAndValue);
                }
                YP_CheckMaster newMaster = new YP_CheckMaster();
                newMaster.AuditTime = _currentTime;
                newMaster.DeptID = Convert.ToInt32(auditDeptID);
                newMaster.BillNum = groupNum;
                newMaster.OpType = ConfigManager.OP_YF_AUDITCHECK;
                Hashtable storeTable = StoreFactory.GetProcessor(ConfigManager.OP_YF_CHECK).ChangeStoreNum(newMaster, totalListOrder);
                AccountFactory.GetWriter(ConfigManager.OP_YF_CHECK).WriteAccount(newMaster, totalListOrder, storeTable);
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
        /// 将多张盘点单的明细添加到盘点汇总单中
        /// </summary>
        /// <param name="totalListOrder">盘点汇总单</param>
        /// <param name="listOrder">盘点单明细表</param>
        private void AddOrderListByMakerId(List<BillOrder> totalListOrder, List<YP_CheckOrder> listOrder)
        {
            foreach (YP_CheckOrder orderCheck in listOrder)
            {
                bool isFind = false;
                orderCheck.Audit_Flag = 1;
                BindEntity<HIS.Model.YP_CheckOrder>.CreateInstanceDAL(oleDb,
                    Tables.YF_CHECKORDER).Update(orderCheck);
                foreach (YP_CheckOrder totalOrder in totalListOrder)
                {
                    if (totalOrder.MakerDicID == orderCheck.MakerDicID)
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
                    totalListOrder.Add(orderCheck);
                }
            }
        }

        /// <summary>
        /// 删除盘点单据
        /// </summary>
        /// <param name="billMaster">盘点单表头</param>
        public override void DelBill(BillMaster billMaster)
        {
            try
            {
                YP_CheckMaster master = (YP_CheckMaster)billMaster;
                oleDb.BeginTransaction();
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                IBaseDAL<YP_CheckMaster> checkMaster = BindEntity<HIS.Model.YP_CheckMaster>.CreateInstanceDAL(oleDb,
                    Tables.YF_CHECKMASTER);
                checkMaster.Update(BLL.Tables.yf_checkmaster.MASTERCHECKID + oleDb.EuqalTo() + master.MasterCheckID,
                    BLL.Tables.yf_checkmaster.DEL_FLAG + oleDb.EuqalTo() + "1");
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 保存盘点单据
        /// </summary>
        /// <param name="billMaster">盘点单表头</param>
        /// <param name="listOrder">盘点单明细列表</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                YP_CheckMaster masterCheck = (YP_CheckMaster)billMaster;
                ComputeMasterFee(masterCheck, listOrder);
                oleDb.BeginTransaction();
                YP_CheckMaster inDBMaster = BindEntity<YP_CheckMaster>.CreateInstanceDAL(oleDb,
                    Tables.YF_CHECKMASTER).GetModel(masterCheck.MasterCheckID);
                if (inDBMaster.Del_Flag == 1)
                {
                    throw new Exception("当前单据已经被其他用户强制清除，无法保证盘存数量的正确性，请重新录入新的盘点单");
                }
                ////声明操作对象
                YP_CheckOrder checkOrder = new YP_CheckOrder();
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                int billNum = (ypDal.YP_Bill_GetBillNum(ConfigManager.OP_YF_CHECK, masterCheck.DeptID)).BillNum;
                masterCheck.BillNum = billNum;
                BindEntity<YP_CheckMaster>.CreateInstanceDAL(oleDb, Tables.YF_CHECKMASTER).Update(masterCheck);
                foreach (BillOrder order in listOrder)
                {
                    //遍历DataTable取出明细记录并设置记录的值
                    checkOrder = (YP_CheckOrder)order;
                    checkOrder.MasterCheckID = masterCheck.MasterCheckID;
                    checkOrder.BillNum = masterCheck.BillNum;
                    checkOrder.BillTime = masterCheck.RegTime;
                    checkOrder.DeptID = masterCheck.DeptID;
                    //依次添加明细记录
                    BindEntity<YP_CheckOrder>.CreateInstanceDAL(oleDb, Tables.YF_CHECKORDER).Add(checkOrder);
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
        /// 修改盘点单据
        /// </summary>
        /// <param name="billMaster">盘点单表头</param>
        /// <param name="listOrder">盘点单明细列表</param>
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
                BindEntity<HIS.Model.YP_CheckMaster>.CreateInstanceDAL(oleDb, Tables.YF_CHECKMASTER).Update(masterCheck);
                foreach (BillOrder order in listOrder)
                {
                    checkOrder = (YP_CheckOrder)order;
                    BindEntity<HIS.Model.YP_CheckOrder>.CreateInstanceDAL(oleDb, Tables.YF_CHECKORDER).Update(checkOrder);
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
