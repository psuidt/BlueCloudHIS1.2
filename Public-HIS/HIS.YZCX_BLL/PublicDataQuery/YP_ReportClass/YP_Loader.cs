using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.YP_BLL;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.DAL;

namespace HIS.YZCX_BLL
{
    public class YP_Loader:BaseBLL
    {

        public static DataTable LoadUseDrug()
        {
            try
            {
                string strSql = oleDb.Table(BLL.Views.VI_DRUG_DIC, "", "", "BYNAME",
                    "CHEMNAME", "PRODUCTNAME", "MAKERDICID", "SPEC", "PY_CODE", "WB_CODE");
                return oleDb.GetDataTable(strSql);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public static DataTable LoadDrugStore(YP_DeptDic currentDept, string drugType, string queryCode)
        {
            DataTable storeDt = null;
            int drugTypeId = 0;
            if (currentDept != null)
            {
                switch (drugType)
                {
                    case "西药":
                        drugTypeId = 1;
                        break;
                    case "中药":
                        drugTypeId = 3;
                        break;
                    case "中成药":
                        drugTypeId = 2;
                        break;
                    case "医用物资":
                        drugTypeId = 4;
                        break;
                    default:
                        break;
                }
                switch (currentDept.DeptType1)
                {
                    case "药房":
                        storeDt = StoreFactory.GetQuery(ConfigManager.YF_SYSTEM).QueryStoreInfo(
                            drugTypeId,
                            0,
                            currentDept.DeptID,
                            queryCode);
                        break;
                    case "药库":
                        storeDt = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM).QueryStoreInfo(
                            drugTypeId,
                            0,
                            currentDept.DeptID,
                            queryCode);
                        break;
                    case "物资":
                        storeDt = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM).QueryStoreInfo(
                            drugTypeId,
                            0,
                            currentDept.DeptID,
                            queryCode);
                        break;
                    default:
                        break;
                }
            }
            return storeDt;
        }

        public static List<YP_DeptDic> GetAllDrugDept()
        {
            try
            {
                return BindEntity<YP_DeptDic>.CreateInstanceDAL(oleDb).GetListArray("");
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public static DataTable GetYKDept()
        {
            try
            {
                string strWhere = BLL.Tables.yp_deptdic.DEPTTYPE1 + oleDb.EuqalTo() + "'药库'" + oleDb.Or()
                    + BLL.Tables.yp_deptdic.DEPTTYPE1 + oleDb.EuqalTo() + "'物资'";
                return BindEntity<YP_DeptDic>.CreateInstanceDAL(oleDb).GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public static decimal LoadTradelFee(YP_DeptDic currentDept)
        {
            try
            {
                decimal rtn = 0;
                if (currentDept != null)
                {
                    switch (currentDept.DeptType1)
                    {
                        case "药房":
                            rtn = StoreFactory.GetQuery(ConfigManager.YF_SYSTEM).QueryTradeFee(currentDept.DeptID, 0);
                            break;
                        case "药库":
                            rtn = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM).QueryTradeFee(currentDept.DeptID, 0);
                            break;
                        case "物资":
                            rtn = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM).QueryTradeFee(currentDept.DeptID, 0);
                            break;
                        default:
                            break;
                    }
                }
                return rtn;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public static decimal LoadRetailFee(YP_DeptDic currentDept)
        {
            try
            {
                decimal rtn = 0;
                if (currentDept != null)
                {
                    switch (currentDept.DeptType1)
                    {
                        case "药房":
                            rtn = StoreFactory.GetQuery(ConfigManager.YF_SYSTEM).QueryStoreFee(currentDept.DeptID, 0); 
                            break;
                        case "药库":
                            rtn = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM).QueryStoreFee(currentDept.DeptID, 0);
                            break;
                        case "物资":
                            rtn = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM).QueryStoreFee(currentDept.DeptID, 0);
                            break;
                        default:
                            break;
                    }
                }
                return rtn;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 查询药品盘点审核单金额信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="drugType">药品类型</param>
        /// <param name="makerDicId">厂家编码</param>
        /// <returns></returns>
        public static DataTable LoadCheckBillFee(DateTime beginTime, DateTime endTime, string drugType, int makerDicId)
        {
            try
            {
                int drugTypeId = 0;
                switch (drugType)
                {
                    case "西药":
                        drugTypeId = 1;
                        break;
                    case "中药":
                        drugTypeId = 3;
                        break;
                    case "中成药":
                        drugTypeId = 2;
                        break;
                    case "医用物资":
                        drugTypeId = 4;
                        break;
                    default:
                        drugTypeId = 0;
                        break;
                }
                string strWhere = "";
                YZCX_Dal dal = new YZCX_Dal();
                dal._oleDb = oleDb;
                if (beginTime == endTime)
                {
                    strWhere += "AuditTime" + oleDb.Between() + "'" + ((DateTime)beginTime).ToString("yyyy-MM-dd")
                        + " 00:00:00' " + oleDb.And() + " '" + ((DateTime)endTime).ToString("yyyy-MM-dd") + @" 23:59:59'";
                }
                else
                {
                    strWhere += "AuditTime" + oleDb.Between() + "'" + beginTime.ToString("yyyy-MM-dd") + " 00:00:00" + "'" +
                oleDb.And() + " '" + endTime.ToString("yyyy-MM-dd") + " 23:59:59" + "'";
                }

                return dal.LoadCheckBillFee(strWhere, makerDicId, drugTypeId);

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载盘点明细信息
        /// </summary>
        /// <param name="auditNo">盘审单号</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="opType">业务类型</param>
        /// <param name="drugType">药品类型</param>
        /// <param name="makerDicId">药品编码</param>
        /// <returns></returns>
        public static DataTable LoadCheckInfo(int auditNo, int deptId, string deptType, string drugType, int makerDicId)
        {
            try
            {
                int drugTypeId;
                string str = "";
                switch (drugType)
                {
                    case "西药":
                        drugTypeId = 1;
                        break;
                    case "中药":
                        drugTypeId = 3;
                        break;
                    case "中成药":
                        drugTypeId = 2;
                        break;
                    case "医用物资":
                        drugTypeId = 4;
                        break;
                    default:
                        drugTypeId = 0;
                        break;
                }
                HIS.DAL.YZCX_Dal dal = new YZCX_Dal();
                dal._oleDb = oleDb;
                str += "f.auditnum" + oleDb.EuqalTo() + auditNo;
                str += oleDb.And() + "a.deptid" + oleDb.EuqalTo() + deptId;
                if (drugTypeId != 0)
                {
                    str += oleDb.And() + "c.typedicid" + oleDb.EuqalTo() + drugTypeId;
                }
                if (makerDicId != 0)
                {
                    str += oleDb.And() + "a.makerdicid" + oleDb.EuqalTo() + makerDicId;
                }
                if (deptType == "药房")
                {
                    return dal.YF_LoadCheckInfo(str);
                }
                else
                {
                    return dal.YK_LoadCheckInfo(str);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public static DataTable LoadInStoreInfo(DateTime beginTime, DateTime endTime, int deptId, string opType)
        {
            HIS.DAL.YZCX_Dal dal = new YZCX_Dal();
            dal._oleDb = oleDb;
            string strWhere = "";
            if (beginTime == endTime)
            {
                strWhere += "date(A.RegTime)" + oleDb.Between() + "'" + ((DateTime)beginTime).ToString("yyyy-MM-dd") + " 00:00:00' " +
            oleDb.And() + " '" + ((DateTime)endTime).ToString("yyyy-MM-dd") + @" 23:59:59'";
            }
            else
            {
                strWhere += "date(A.RegTime)" + oleDb.Between() + "'" + beginTime.ToString("yyyy-MM-dd") + " 00:00:00' " +
            oleDb.And() + " '" + endTime.ToString("yyyy-MM-dd") + "23:59:59 ' ";
            }
            if (deptId != 0)
            {
                strWhere += oleDb.And() + "A.DeptId" + oleDb.EuqalTo() + deptId.ToString();
            }
            switch (opType)
            {
                case "期初入库":
                    strWhere += oleDb.And() + "A.OpType" + oleDb.EuqalTo() + "'" + ConfigManager.OP_YK_FIRSTIN + "'";
                    break;
                case "采购入库":
                    strWhere += oleDb.And() + "A.OpType" + oleDb.EuqalTo() + "'" + ConfigManager.OP_YK_INOPTYPE + "'";
                    break;
                default:
                    break;
            }
            return dal.LoadInstoreInfo(strWhere);
        }

        public static DataTable LoadOutStoreInfo(DateTime beginTime, DateTime endTime, int deptId, string opType)
        {
            HIS.DAL.YZCX_Dal dal = new YZCX_Dal();
            dal._oleDb = oleDb;
            string strWhere = "";
            if (beginTime == endTime)
            {
                strWhere += "A.RegTime" + oleDb.Between() + "'" + 
                    ((DateTime)beginTime).ToString("yyyy-MM-dd") + " 00:00:00' " +
            oleDb.And() + " '" + ((DateTime)endTime).ToString("yyyy-MM-dd") + @" 23:59:59'";
            }
            else
            {
                strWhere += "A.RegTime" + oleDb.Between() + "'" + beginTime.ToString() + "'" +
            oleDb.And() + " '" + endTime.ToString() + "'";
            }
            if (deptId != 0)
            {
                strWhere += oleDb.And() + "A.DeptId" + oleDb.EuqalTo() + deptId.ToString();
            }
            switch (opType)
            {
                case "科室出库":
                    strWhere += oleDb.And()+"E.outfee>0"+oleDb.And() + "(A.OpType" + oleDb.EuqalTo() + "'" + ConfigManager.OP_YK_DEPTDRAW + "'"
                        + oleDb.Or()+ "A.OpType" + oleDb.EuqalTo() + "'" + ConfigManager.OP_YK_OUTTOYF + "')";
                    break;
                case "报损出库":
                    strWhere += oleDb.And() + "A.OpType" + oleDb.EuqalTo() + "'" + ConfigManager.OP_YK_REPORTLOSS + "'";
                    break;
                case "药房退库":
                    strWhere += oleDb.And() + "A.OpType" + oleDb.EuqalTo() + "'" + ConfigManager.OP_YK_OUTTOYF + "'"+oleDb.And()+"E.outfee<0";
                    break;
                default:
                    break;
            }
            return dal.LoadOutstoreInfo(strWhere);
        }

        public static DataTable LoadDispInfo(DateTime beginTime, DateTime endTime,
            int drugType, bool isRefund, int makerDicId, int isMZZYQY)
        {
            try
            {
                HIS.DAL.YZCX_Dal dal = new YZCX_Dal();
                dal._oleDb = oleDb;
                string strWhere = "";

                strWhere += "A.RegTime" + oleDb.Between() + "'" + beginTime.ToString() + "'" + oleDb.And() + " '" + endTime.ToString() + "'";

                //if (drugType != 0)
                //{
                //    if (drugType == 4) drugType = 0;//add zenghao
                //    strWhere += oleDb.And() + "A.TYPEDICID" + oleDb.EuqalTo() + drugType;
                //}

                if (makerDicId != 0)
                {
                    strWhere += oleDb.And() + "A.MAKERDICID" + oleDb.EuqalTo() + makerDicId;
                }

                return dal.LoadDispInfo(strWhere, isMZZYQY, isRefund, drugType);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
