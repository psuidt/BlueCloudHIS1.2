using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Model;
using HIS.DAL;
using HIS.SYSTEM.Core;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 单据查询处理器类
    /// </summary>
    public abstract class BillQuery : HIS.SYSTEM.Core.BaseBLL
    {

        abstract public string GetSqlWhere(Hashtable condition);

        /// <summary>
        /// 加载单据头表
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public abstract DataTable LoadMaster(Hashtable condition);
        /// <summary>
        /// 加载单据明细
        /// </summary>
        /// <param name="billMaster">单据头表</param>
        /// <returns></returns>
        public abstract DataTable LoadOrder(BillMaster billMaster);

        /// <summary>
        /// 判断某张盘点单是否被审核
        /// </summary>
        /// <param name="exceptID">盘点单ID</param>
        /// <param name="belongSystem">所属系统</param>
        /// <returns></returns>
        public bool CheckBill_ExistsNotAudit(int exceptID, string belongSystem)
        {
            try
            {
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                if (belongSystem == ConfigManager.YF_SYSTEM)
                {
                    return ypDal.YF_Checkmaster_ExistNotAudit(exceptID);
                }
                else if (belongSystem == ConfigManager.YK_SYSTEM)
                {
                    return ypDal.YK_Checkmaster_ExistNotAudit(exceptID);
                }
                else
                {
                    return false;
                }

            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
        /// <summary>
        /// 加载发药头表
        /// </summary>
        /// <param name="invoiceNum">发票号</param>
        /// <param name="deptId">科室ID</param>
        /// <returns>发药头信息</returns>
        public DataTable LoadDispMaster(string invoiceNum, int deptId)
        {
            try
            {
                string strWhere = "";
                strWhere += BLL.Tables.yf_drmaster.INVOICENUM + oleDb.EuqalTo() + invoiceNum+
                    oleDb.And() + BLL.Tables.yf_drmaster.DEPTID + oleDb.EuqalTo() + deptId.ToString();
                return HIS.SYSTEM.Core.BindEntity<YP_DRMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_DRMASTER).GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 按发票号获取发药人姓名 
        /// </summary>
        /// <param name="invoiceNum">发票号</param>
        /// <param name="deptId">部门ID</param>
        /// <returns></returns>
        public string GetDispenserName(string invoiceNum, int deptId)
        {
            try
            {
                string strWhere = BLL.Tables.yf_drmaster.INVOICENUM + oleDb.EuqalTo() + invoiceNum +
                    oleDb.And() + BLL.Tables.yf_drmaster.DEPTID + oleDb.EuqalTo() + deptId.ToString();
                YP_DRMaster master = HIS.SYSTEM.Core.BindEntity<YP_DRMaster>.CreateInstanceDAL(oleDb, 
                    BLL.Tables.YF_DRMASTER).GetModel(strWhere);
                return HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName((int)master.OPPeopleID);

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 按入库单据查询其明细各药品类型汇总金额（入库）
        /// </summary>
        /// <param name="inMasterId">入库单头表ID</param>
        /// <returns></returns>
        static public DataTable LoadTotalFeeByInOrder(int inMasterId)
        {
            try
            {
                string strWhere = "a." + BLL.Tables.yf_inorder.MASTERINSTORAGEID + oleDb.EuqalTo() + inMasterId;                
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YK_Inorder_GetTotalFee(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        /// <summary>
        /// 按入库单据查询其明细各药品类型汇总金额(出库)
        /// </summary>
        /// <param name="inMasterId">入库单头表ID</param>
        /// <returns></returns>
        static public DataTable LoadTotalFeeByOutOrder(int inMasterId)
        {
            try
            {
                string strWhere = "a." + BLL.Tables.yf_inorder.MASTERINSTORAGEID + oleDb.EuqalTo() + inMasterId;
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YK_Outorder_GetTotalFee(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        /// <summary>
        /// 查询指定药库药品的供应商入库历史记录
        /// </summary>
        /// <param name="makerDicId">药品厂家典ID</param>
        /// <returns></returns>
        public DataTable LoadSupportHis(int makerDicId, int deptId)
        {
            try
            {
                string strWhere = "A.MakerDicID" + oleDb.EuqalTo() + makerDicId + oleDb.And()
                + "B.DeptID" + oleDb.EuqalTo() + deptId;
                YP_Dal dal = new YP_Dal();
                dal._oleDb = oleDb;
                    return dal.YK_SupportHis(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 根据需要退库的入库单表头加载其对应的退库单明细
        /// </summary>
        /// <param name="inMasterNeedBack">需退库的入库单表头</param>
        /// <returns></returns>
        public List<HIS.Model.BillOrder> GetBackStoreOrderList(BillMaster inMasterNeedBack)
        {
            try
            {
                HIS.Model.YP_InMaster inMaster = (YP_InMaster)inMasterNeedBack;
                string strWhere = "MASTERINSTORAGEID" + oleDb.EuqalTo() + inMaster.MasterInStorageID.ToString();
                List<YP_InOrder> orderList = new List<YP_InOrder>();
                List<BillOrder> rtnList = new List<BillOrder>();
                if (inMaster.OpType == ConfigManager.OP_YF_APPLYIN)
                {
                    orderList = BindEntity<YP_InOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YF_INORDER).GetListArray(strWhere);
                    foreach (YP_InOrder order in orderList)
                    {
                        if (order.InNum > 0)
                        {
                            order.InNum = -order.InNum;
                            order.RetailFee = -order.RetailFee;
                            order.StockFee = -order.StockFee;
                            order.TradeFee = -order.TradeFee;
                            rtnList.Add(order);
                        }
                        else
                        {
                            string drugName = DrugBaseDataBll.GetDurgName(order.MakerDicID);
                            throw new Exception(drugName + "药品的业务类型为退库，无法再次进行退库操作");
                        }
                    }
                }
                else
                {
                    orderList = BindEntity<YP_InOrder>.CreateInstanceDAL(oleDb, BLL.Tables.YK_INORDER).GetListArray(strWhere);
                    foreach (YP_InOrder order in orderList)
                    {
                        rtnList.Add(order);
                    }
                }
                
                return rtnList;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 调价单查询
    /// </summary>
    class AdjBillQuery : BillQuery
    {

        public override string GetSqlWhere(Hashtable condition)
        {
            try
            {
                ConditionParam queryParam;
                string strWhere = "";
                queryParam = (ConditionParam)condition[QueryConditionType.部门ID];
                strWhere += "A.DeptID=" + queryParam.Value.ToString();
                queryParam = (ConditionParam)condition[QueryConditionType.单据号];
                if (queryParam.IsUse)
                {
                    strWhere += oleDb.And()+"A.BillNum=" + queryParam.Value.ToString();
                }
                queryParam = (ConditionParam)condition[QueryConditionType.调价单号];
                if (queryParam.IsUse)
                {
                    strWhere += oleDb.And() + "A.adjCode='" + queryParam.Value.ToString() + "'";
                }
                queryParam = (ConditionParam)condition[QueryConditionType.开始时间];
                if (queryParam.IsUse)
                {
                    ConditionParam endTime = (ConditionParam)condition[QueryConditionType.结束时间];
                    strWhere += oleDb.And() + "DATE(A.RegTime)>='" + ((DateTime)(queryParam.Value)).Date.ToString()
                        + "' AND DATE(A.RegTime)<='" + ((DateTime)(endTime.Value)).Date.ToString() + "'";
                }
                return strWhere;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载调价单据头表
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public override DataTable LoadMaster(Hashtable condition)
        {
            try
            {
                string strWhere = GetSqlWhere(condition);
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YP_Adjmaster_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override DataTable LoadOrder(BillMaster billMaster)
        {
            try
            {
                //A表指的是调价表头
                YP_AdjMaster master = (YP_AdjMaster)billMaster;
                string strWhere = "";
                if (master != null)
                {
                    strWhere = "A.MasterIAdjPriceD=" + master.MasterAdjPriceID.ToString();
                }
                else
                {
                    strWhere = "0<>0";
                }
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YP_Adjorder_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 盘点单查询
    /// </summary>
    abstract class CheckBillQuery : BillQuery
    {
        public override DataTable LoadMaster(Hashtable condition)
        {
            throw new NotImplementedException();
        }

        public override DataTable LoadOrder(BillMaster billMaster)
        {
            throw new NotImplementedException();
        }

        public override string GetSqlWhere(Hashtable condition)
        {
            try
            {
                ConditionParam queryParam;
                string strWhere = "";
                queryParam = ((ConditionParam)condition[QueryConditionType.是否审核]);
                if (queryParam.IsUse)
                {
                    strWhere += "Audit_Flag=" + queryParam.Value.ToString();
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.开始时间]);
                if (queryParam.IsUse)
                {
                    ConditionParam endTime = ((ConditionParam)condition[QueryConditionType.结束时间]);
                    strWhere += " AND DATE(A.RegTime)>='" + ((DateTime)(queryParam.Value)).Date.ToString() +
                        "' AND DATE(A.RegTime)<='" + ((DateTime)endTime.Value).Date.ToString() + "'";
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.盘审单号]);
                if (queryParam.IsUse)
                {
                    strWhere += oleDb.And() + "A.AUDITNUM" + oleDb.EuqalTo() + queryParam.Value.ToString();
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.部门ID]);
                {
                    strWhere += oleDb.And() + "A.DEPTID" + oleDb.EuqalTo() + queryParam.Value.ToString();
                }
                strWhere += oleDb.And() + "A.DEL_FLAG=0";
                return strWhere;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 药房盘点单查询
    /// </summary>
    class YF_CheckBillQuery : CheckBillQuery
    {
        public override string GetSqlWhere(Hashtable condition)
        {
            return base.GetSqlWhere(condition);
        }
        /// <summary>
        /// 加载药房盘点单表头
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public override DataTable LoadMaster(Hashtable condition)
        {
            try
            {
                string strWhere = GetSqlWhere(condition);
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YF_Checkmaster_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载药房盘点单明细
        /// </summary>
        /// <param name="billMaster">单据头表</param>
        /// <returns></returns>
        public override DataTable LoadOrder(BillMaster billMaster)
        {
            try
            {
                YP_CheckMaster masterCheck = (YP_CheckMaster)billMaster;
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                if (masterCheck != null)
                {
                    return ypDal.YF_Checkorder_GetListByMaster(masterCheck.MasterCheckID);
                }
                else
                {
                    return ypDal.YF_Checkorder_GetListByMaster(0);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 药库盘点单查询
    /// </summary>
    class YK_CheckBillQuery : CheckBillQuery
    {
        public override string GetSqlWhere(Hashtable condition)
        {
            return base.GetSqlWhere(condition);
        }
        /// <summary>
        /// 加载药库盘点单据头表
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public override DataTable LoadMaster(Hashtable condition)
        {
            try
            {
                string strWhere = GetSqlWhere(condition);
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YK_Checkmaster_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载药房盘点单明细
        /// </summary>
        /// <param name="billMaster">单据头表</param>
        /// <returns></returns>
        public override DataTable LoadOrder(BillMaster billMaster)
        {
            try
            {
                YP_CheckMaster masterCheck = (YP_CheckMaster)billMaster;
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                if (masterCheck != null)
                {
                    return ypDal.YK_Checkorder_GetListByMaster(masterCheck.MasterCheckID);
                }
                else
                {
                    return ypDal.YK_Checkorder_GetListByMaster(0);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 入库单查询
    /// </summary>
    abstract class InstoreBillQuery : BillQuery
    {
        public override DataTable LoadMaster(Hashtable condition)
        {
            throw new NotImplementedException();
        }

        public override DataTable LoadOrder(BillMaster billMaster)
        {
            throw new NotImplementedException();
        }

        public override string GetSqlWhere(Hashtable condition)
        {
            try
            {
                ConditionParam queryParam;
                string strWhere = "";
                queryParam = ((ConditionParam)(condition[QueryConditionType.是否审核]));
                string isAudit = queryParam.Value.ToString().Trim();
                if (queryParam.IsUse)
                {
                    strWhere += "A.Audit_Flag=" + queryParam.Value.ToString();
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.开始时间]);
                if (queryParam.IsUse)
                {
                    ConditionParam endTime = ((ConditionParam)condition[QueryConditionType.结束时间]);

                    if (isAudit == "0")  //update by heyan 2010.11.29 已审核的单据按审核时间查
                    {
                        strWhere += " AND DATE(A.RegTime)>='" + ((DateTime)(queryParam.Value)).Date.ToString() +
                            "' AND DATE(A.RegTime)<='" + ((DateTime)endTime.Value).Date.ToString() + "'";
                    }
                    else
                    {
                        strWhere += " AND DATE(A.AuditTime)>='" + ((DateTime)(queryParam.Value)).Date.ToString() +
                            "' AND DATE(A.AuditTime)<='" + ((DateTime)endTime.Value).Date.ToString() + "'";
                    }
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.单据号]);
                if (queryParam.IsUse)
                {
                    strWhere += oleDb.And() + "A.BILLNUM" + oleDb.EuqalTo() + queryParam.Value.ToString();
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.供应商ID]);
                if (queryParam.IsUse)
                {
                    strWhere += oleDb.And() + "A.SupportDicID" + oleDb.EuqalTo() + queryParam.Value.ToString();
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.发票号]);
                if (queryParam.IsUse)
                {
                    strWhere += oleDb.And() + "A.InvoiceNum" + oleDb.EuqalTo() + "'" + queryParam.Value.ToString() + "'";
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.部门ID]);
                strWhere += oleDb.And() + "A.DEPTID" + oleDb.EuqalTo() + queryParam.Value.ToString();
                strWhere += oleDb.And() + "A.DEL_FLAG=0";
                return strWhere;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 药房期初入库单查询
    /// </summary>
    class YF_InstoreQuery : InstoreBillQuery
    {
        public override string GetSqlWhere(Hashtable condition)
        {
            string strWhere = base.GetSqlWhere(condition);
            strWhere += " AND A.OPTYPE=" + "'" + ConfigManager.OP_YF_INSTORE + "'";
            return strWhere;
        }
        /// <summary>
        /// 加载药房期初入库单据头表
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public override DataTable LoadMaster(Hashtable condition)
        {
            try
            {
                string strWhere = GetSqlWhere(condition);
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YF_Inmaster_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载药房期初入库单据明细
        /// </summary>
        /// <param name="billMaster">单据头表</param>
        /// <returns></returns>
        public override DataTable LoadOrder(BillMaster billMaster)
        {
            try
            {
                YP_InMaster inStore = (YP_InMaster)billMaster;
                string strWhere = "";
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                if (inStore != null)
                {
                    strWhere = "A.MasterInStorageID=" + inStore.MasterInStorageID.ToString();
                    strWhere += oleDb.And() + "A.DeptID" + oleDb.EuqalTo() + inStore.DeptID;
                }
                else
                {
                    strWhere = "0<>0";
                }
                return ypDal.YF_Inorder_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 药库入库单查询
    /// </summary>
    class YK_IntstoreQuery : InstoreBillQuery
    {

        public override string GetSqlWhere(Hashtable condition)
        {
            return base.GetSqlWhere(condition);
        }
        /// <summary>
        /// 加载药库入库单据头表
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public override DataTable LoadMaster(Hashtable condition)
        {
            try
            {
                string strWhere = GetSqlWhere(condition);
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YK_Inmaster_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载药库入库单据明细
        /// </summary>
        /// <param name="billMaster">单据头表</param>
        /// <returns></returns>
        public override DataTable LoadOrder(BillMaster billMaster)
        {
            try
            {
                YP_InMaster inStore = (YP_InMaster)billMaster;
                string strWhere = "";
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                if (inStore != null)
                {
                    strWhere = "A.MasterInStorageID=" + inStore.MasterInStorageID.ToString();
                    strWhere += oleDb.And() + "A.DeptID" + oleDb.EuqalTo() + inStore.DeptID;
                }
                else
                {
                    strWhere = "0<>0";
                }
                return ypDal.YK_Inorder_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 药房申请入库单查询
    /// </summary>
    class YF_ApplyQuery : InstoreBillQuery
    {
        public override string GetSqlWhere(Hashtable condition)
        {
            try
            {
                ConditionParam queryParam;
                string strWhere = "";
                queryParam = ((ConditionParam)condition[QueryConditionType.是否审核]);
                if (queryParam.IsUse)
                {
                    strWhere += "A.Audit_Flag=" + queryParam.Value.ToString() + " AND (A.OPTYPE='001'" + "or A.OPTYPE='025') ";
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.开始时间]);
                if (queryParam.IsUse)
                {
                    ConditionParam endTime = ((ConditionParam)condition[QueryConditionType.结束时间]);
                    strWhere += " AND DATE(A.RegTime)>='" + ((DateTime)(queryParam.Value)).Date.ToString() +
                        "' AND DATE(A.RegTime)<='" + ((DateTime)endTime.Value).Date.ToString() + "'";
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.部门ID]);
                strWhere += oleDb.And() + "A.DEPTID" + oleDb.EuqalTo() + queryParam.Value.ToString();
                strWhere += oleDb.And() + "A.DEL_FLAG=0";
                return strWhere;
            }
            catch (Exception error)
            {
                throw error;
            }
        
        }
        /// <summary>
        /// 加载药房入库申请单头表
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public override DataTable LoadMaster(Hashtable condition)
        {
            try
            {
                string strWhere = GetSqlWhere(condition);
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YF_Inmaster_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载药房申请入库单明细
        /// </summary>
        /// <param name="billMaster">单据头表</param>
        /// <returns></returns>
        public override DataTable LoadOrder(BillMaster billMaster)
        {
            try
            {
                if (billMaster != null)
                {
                    YP_InMaster inStore = (YP_InMaster)billMaster;
                    string strWhere = "";
                    YP_Dal ypDal = new YP_Dal();
                    ypDal._oleDb = oleDb;
                    if (inStore != null)
                    {
                        strWhere = "A.MasterInStorageID=" + inStore.MasterInStorageID.ToString();
                        strWhere += oleDb.And() + "A.DeptID" + oleDb.EuqalTo() + inStore.DeptID;
                    }
                    else
                    {
                        strWhere = "0<>0";
                    }
                    return ypDal.YF_Inorder_GetList(strWhere);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 出库单查询
    /// </summary>
    abstract class OutstoreBillQuery : BillQuery
    {
        public override DataTable LoadMaster(Hashtable condition)
        {
            throw new NotImplementedException();
        }

        public override DataTable LoadOrder(BillMaster billMaster)
        {
            throw new NotImplementedException();
        }

        public override string GetSqlWhere(Hashtable condition)
        {
            try
            {
                ConditionParam queryParam;
                string strWhere = "";
                queryParam = ((ConditionParam)condition[QueryConditionType.是否审核]);
                string isAudit = queryParam.Value.ToString().Trim();
                if (queryParam.IsUse)
                {
                    strWhere += "A.Audit_Flag=" + queryParam.Value.ToString();
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.开始时间]);
                if (queryParam.IsUse)
                {

                    ConditionParam endTime = ((ConditionParam)condition[QueryConditionType.结束时间]);
                    if (isAudit == "0")//update by heyan 2010.12.29  已审核的按审核时间查询
                    {
                        strWhere += " AND DATE(A.RegTime)>='" + ((DateTime)(queryParam.Value)).Date.ToString() +
                            "' AND DATE(A.RegTime)<='" + ((DateTime)endTime.Value).Date.ToString() + "'";
                    }
                    else
                    {
                        strWhere += " AND DATE(A.AuditTime)>='" + ((DateTime)(queryParam.Value)).Date.ToString() +
                          "' AND DATE(A.AuditTime)<='" + ((DateTime)endTime.Value).Date.ToString() + "'";
                    }
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.业务类型]);
                if (queryParam.IsUse)
                {
                    strWhere += oleDb.And() + "A.OPTYPE" + oleDb.EuqalTo() + "'" + queryParam.Value.ToString() + "'";
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.单据号]);
                if (queryParam.IsUse)
                {
                    strWhere += oleDb.And() + "A.BillNum" + oleDb.EuqalTo() + queryParam.Value.ToString();
                }
                queryParam = ((ConditionParam)condition[QueryConditionType.部门ID]);
                strWhere += oleDb.And() + "A.DEPTID" + oleDb.EuqalTo() + queryParam.Value.ToString();
                strWhere += oleDb.And() + "A.DEL_FLAG=0";
                return strWhere;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 药房出库单查询
    /// </summary>
    class YF_OutstoreQuery : OutstoreBillQuery
    {
        /// <summary>
        /// 加载药房出库单据头表
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public override DataTable LoadMaster(Hashtable condition)
        {
            try
            {
                string strWhere = GetSqlWhere(condition);
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YF_Outmaster_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载药房出库单明细
        /// </summary>
        /// <param name="billMaster">药房出库单据头表</param>
        /// <returns></returns>
        public override DataTable LoadOrder(BillMaster billMaster)
        {
            try
            {
                YP_OutMaster outStore = (YP_OutMaster)billMaster;
                string strWhere;
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                if (outStore != null)
                {
                    strWhere = "A.MasterOutStorageID=" + outStore.MasterOutStorageID.ToString();
                }
                else
                {
                    strWhere = "0<>0";
                }
                return ypDal.YF_Outorder_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 药库出库单查询
    /// </summary>
    class YK_OutstoreQuery : OutstoreBillQuery
    {
        /// <summary>
        /// 加载药库出库单据头表
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public override DataTable LoadMaster(Hashtable condition)
        {
            try
            {
                string strWhere = GetSqlWhere(condition);
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YK_Outmaster_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载药库出库单据明细
        /// </summary>
        /// <param name="billMaster">药库出库单据头表</param>
        /// <returns></returns>
        public override DataTable LoadOrder(BillMaster billMaster)
        {
            try
            {
                YP_OutMaster outStore = (YP_OutMaster)billMaster;
                string strWhere;
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                if (outStore != null)
                {
                    strWhere = "A.MasterOutStorageID=" + outStore.MasterOutStorageID.ToString();
                }
                else
                {
                    strWhere = "0<>0";
                }
                return ypDal.YK_Outorder_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 发退药单查询
    /// </summary>
    class DispRefQuery : BillQuery
    {
        public override string GetSqlWhere(Hashtable condition)
        {
            try
            {
                ConditionParam queryParam;
                string strWhere = "";
                queryParam = ((ConditionParam)condition[QueryConditionType.开始时间]);
                    ConditionParam endTime = ((ConditionParam)condition[QueryConditionType.结束时间]);
                    strWhere += "A.OPTime" + oleDb.Between() + "'" + ((DateTime)queryParam.Value).ToString("yyyy-MM-dd") + " 00:00:00' " +
                oleDb.And() + " '" + ((DateTime)endTime.Value).ToString("yyyy-MM-dd") + @" 23:59:59'";
                queryParam = ((ConditionParam)condition[QueryConditionType.部门ID]);
                strWhere += oleDb.And() + "A.DEPTID" + oleDb.EuqalTo() + queryParam.Value.ToString();
                return strWhere;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        /// <summary>
        /// 加载发退药单据头表
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public override DataTable LoadMaster(Hashtable condition)
        {
            try
            {
                string strWhere = GetSqlWhere(condition);
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.YF_DispenseMaster_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载发/退药单据明细
        /// </summary>
        /// <param name="billMaster">单据头表</param>
        /// <returns></returns>
        public override DataTable LoadOrder(BillMaster billMaster)
        {
            try
            {
                YP_DRMaster queryMaster = (YP_DRMaster)billMaster;
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                string strWhere = "A.MASTERDRUGOCID" + oleDb.EuqalTo() + queryMaster.MasterDrugOCID;
                return ypDal.YF_DispenseOrder_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 住院统领单查询
    /// </summary>
    class ZY_DeptDispQuery : BillQuery
    {
        public override string GetSqlWhere(Hashtable condition)
        {
            ConditionParam queryParam;
            string strWhere = "";
            queryParam = ((ConditionParam)condition[QueryConditionType.开始时间]);
            ConditionParam endTime = ((ConditionParam)condition[QueryConditionType.结束时间]);
            strWhere += "A.OPTime" + oleDb.Between() + "'" + ((DateTime)queryParam.Value).ToString("yyyy-MM-dd") + " 00:00:00' "
                + oleDb.And() + " '" + ((DateTime)endTime.Value).ToString("yyyy-MM-dd") + @" 23:59:59'";
            queryParam = ((ConditionParam)condition[QueryConditionType.部门ID]);
            strWhere += oleDb.And() + "A.DEPTID" + oleDb.EuqalTo() + queryParam.Value.ToString();
            return strWhere;
        }
        /// <summary>
        /// 加载住院统领单头表
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public override DataTable LoadMaster(Hashtable condition)
        {
            try
            {
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                string strWhere = GetSqlWhere(condition);
                return ypDal.YF_DeptDispHIS_GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载住院统领单据明细
        /// </summary>
        /// <param name="billMaster">单据头表</param>
        /// <returns></returns>
        public override DataTable LoadOrder(BillMaster billMaster)
        {
            try
            {
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                YP_DispDeptHis deptDisp = (YP_DispDeptHis)billMaster;
                DataTable deptDispOrder = new DataTable();
                deptDispOrder.Columns.Add("ITEMNAME");
                deptDispOrder.Columns.Add("STANDARD");
                deptDispOrder.Columns.Add("PRODUCTNAME");
                deptDispOrder.Columns.Add("AMOUNT", Type.GetType("System.Decimal"));
                deptDispOrder.Columns.Add("MAKERDICID");
                deptDispOrder.Columns.Add("SELL_PRICE", Type.GetType("System.Decimal"));
                deptDispOrder.Columns.Add("TOLAL_FEE", Type.GetType("System.Decimal"));
                deptDispOrder.Columns.Add("UNIT");
                deptDispOrder.Columns.Add("DOSEDICID");
                deptDispOrder.PrimaryKey = new DataColumn[] { deptDispOrder.Columns["MAKERDICID"] };
                string strWhere = "A.UNIFORMID" + oleDb.EuqalTo() + deptDisp.Id + oleDb.And()
                    + "A.UNIFORM_FLAG" + oleDb.EuqalTo() + "1";
                DataTable drOrders = ypDal.YF_DispenseOrder_GetList(strWhere);
                //设置摆药人员姓名
                List<YP_DRMaster> drMasters = BindEntity<YP_DRMaster>.CreateInstanceDAL(oleDb,
                    BLL.Tables.YF_DRMASTER).GetListArray("UNIFORMID=" + deptDisp.Id.ToString());
                foreach (YP_DRMaster drmaster in drMasters)
                {
                    deptDisp.PatientNames += drmaster.PatientName + ",";
                }
                for (int index = 0; index < drOrders.Rows.Count; index++)
                {
                    DataRow drOrder = drOrders.Rows[index];
                    DataRow findRow = deptDispOrder.Rows.Find(drOrder["MAKERDICID"]);
                    if (findRow != null)
                    {
                        findRow["AMOUNT"] = Convert.ToDecimal(findRow["AMOUNT"]) + Convert.ToDecimal(drOrder["DRUGOCNUM"]);
                        findRow["TOLAL_FEE"] = Convert.ToDecimal(findRow["TOLAL_FEE"]) + Convert.ToDecimal(drOrder["RETAILFEE"]);
                    }
                    else
                    {
                        DataRow deptDispRow = deptDispOrder.NewRow();
                        deptDispRow["ITEMNAME"] = drOrder["CHEMNAME"];
                        deptDispRow["STANDARD"] = drOrder["SPEC"];
                        deptDispRow["PRODUCTNAME"] = drOrder["PRODUCTNAME"];
                        deptDispRow["AMOUNT"] = drOrder["DRUGOCNUM"];
                        deptDispRow["MAKERDICID"] = drOrder["MAKERDICID"];
                        deptDispRow["SELL_PRICE"] = drOrder["RETAILPRICE"];
                        deptDispRow["TOLAL_FEE"] = drOrder["RETAILFEE"];
                        deptDispRow["UNIT"] = drOrder["UNITNAME"];
                        deptDispRow["DOSEDICID"] = drOrder["DOSEDICID"];
                        deptDispOrder.Rows.Add(deptDispRow);
                    }                    
                }
                deptDispOrder.DefaultView.Sort = "DOSEDICID ASC";
                deptDispOrder = deptDispOrder.DefaultView.ToTable();
                return deptDispOrder;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    /// <summary>
    /// 采购计划单查询
    /// </summary>
    class StockPlanQuery : BillQuery
    {
        public override string GetSqlWhere(Hashtable condition)
        {
            ConditionParam queryParam;
            string strWhere = "";
            queryParam = ((ConditionParam)condition[QueryConditionType.开始时间]);
            ConditionParam endTime = ((ConditionParam)condition[QueryConditionType.结束时间]);
            strWhere += "RegTime" + oleDb.Between() + "'" + ((DateTime)queryParam.Value).ToString("yyyy-MM-dd") + " 00:00:00' "
                + oleDb.And() + " '" + ((DateTime)endTime.Value).ToString("yyyy-MM-dd") + @" 23:59:59'";
            return strWhere;
        }
        /// <summary>
        /// 加载采购计划单头表
        /// </summary>
        /// <param name="condition">查询条件参数信息</param>
        /// <returns>单据头表</returns>
        public override DataTable LoadMaster(Hashtable condition)
        {
            string strWhere = GetSqlWhere(condition);
            return BindEntity<YP_PlanMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_PLANMASTER).GetList(strWhere);
        }

        /// <summary>
        /// 加载采购计划单据明细
        /// </summary>
        /// <param name="billMaster">单据头表</param>
        /// <returns></returns>
        public override DataTable LoadOrder(BillMaster billMaster)
        {
            if (billMaster != null)
            {
                YP_PlanMaster master = (YP_PlanMaster)billMaster;
                if (master.PlanMasterId != -1)
                {
                    string strWhere = HIS.BLL.Tables.yk_planmaster.PLANMASTERID + oleDb.EuqalTo()
                        + master.PlanMasterId;
                    YP_Dal dal = new YP_Dal();
                    dal._oleDb = oleDb;
                    return dal.YK_PlanOrder_GetList(strWhere);
                }
                else
                {
                    string strWhere = HIS.BLL.Tables.yk_planmaster.PLANMASTERID + oleDb.EuqalTo()
                        + master.PlanMasterId;
                    YP_Dal dal = new YP_Dal();
                    dal._oleDb = oleDb;
                    DataTable orderDt = dal.YK_PlanOrder_GetList(strWhere);
                    StoreQuery storeQuery = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM);
                    DataTable lowerStoreDrug = storeQuery.GetDrugForStoreLimit("", false,
                        (int)master.DeptId, 0);
                    for (int index = 0; index < lowerStoreDrug.Rows.Count; index++)
                    {
                        DataRow limitRow = lowerStoreDrug.Rows[index];
                        decimal stockNum = Convert.ToDecimal(limitRow["UPPERLIMIT"]) -
                            Convert.ToDecimal(limitRow["CURRENTNUM"]);
                        if (stockNum > 0)
                        {
                            DataRow newRow = orderDt.NewRow();
                            newRow["MAKERDICID"] = limitRow["MAKERDICID"];
                            newRow["CHEMNAME"] = limitRow["CHEMNAME"];
                            newRow["SPEC"] = limitRow["SPEC"];
                            newRow["PRODUCTNAME"] = limitRow["PRODUCTNAME"];
                            newRow["PLANMASTERID"] = 0;
                            newRow["PLANORDERID"] = 0;
                            newRow["RETAILPRICE"] = limitRow["RETAILPRICE"];
                            newRow["TRADEPRICE"] = limitRow["TRADEPRICE"];
                            newRow["UNIT"] = limitRow["LEASTUNIT"];
                            newRow["UNITNAME"] = limitRow["PACKUNITNAME"];
                            newRow["STOCKNUM"] = stockNum;
                            newRow["RETAILFEE"] = stockNum * Convert.ToDecimal(newRow["RETAILPRICE"]);
                            newRow["TRADEFEE"] = stockNum * Convert.ToDecimal(newRow["TRADEPRICE"]);
                            orderDt.Rows.Add(newRow);
                        }
                    }
                    return orderDt;
                }
            }
            else
            {
                return null;
            }
        }
    }

}
