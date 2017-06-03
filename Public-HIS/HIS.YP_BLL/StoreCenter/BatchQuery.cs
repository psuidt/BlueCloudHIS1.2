using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM;
using HIS.Model;
using HIS.BLL;

namespace HIS.YP_BLL
{
    class BatchQuery:BaseBLL
    {
        /// <summary>
        /// 检索特定药品所有批次
        /// </summary>
        /// <param name="makerdicId">药品厂家典ID</param>
        /// <param name="deptId">科室ID</param>
        /// <returns>药品批次列表</returns>
        public static DataTable LoadBatch(int makerdicId, int deptId)
        {
            try
            {
                string strWhere = BLL.Tables.yk_batch.DEPTID + oleDb.EuqalTo() + deptId.ToString()
                    + oleDb.And() + BLL.Tables.yk_batch.MAKERDICID + oleDb.EuqalTo() + makerdicId.ToString()
                    + oleDb.And() + BLL.Tables.yk_batch.DEL_FLAG + oleDb.EuqalTo() + "0";
                return BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, Tables.YK_BATCH).GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 检索指定药剂科室的未删除所有药品批次
        /// </summary>
        /// <param name="deptId">指定科室ID</param>
        /// <returns>药品批次列表</returns>
        public static DataTable LoadBatch(int deptId)
        {
            try
            {
                string strWhere = BLL.Tables.yk_batch.DEPTID + oleDb.EuqalTo() + deptId.ToString()
                    +oleDb.And()+BLL.Tables.yk_batch.DEL_FLAG + oleDb.EuqalTo()+"0";
                return BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, Tables.YK_BATCH).GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 检索指定药剂科室的所有药品批次（含已删除的）
        /// </summary>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <returns>药品批次列表</returns>
        public static DataTable LoadBatchWithDelete(int deptId)
        {
            try
            {
                DateTime currentTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                string strWhere = BLL.Tables.yk_batch.DEPTID + oleDb.EuqalTo() + deptId.ToString()
                    + oleDb.And() + BLL.Tables.yk_batch.VAILIDITYDATE + 
                    oleDb.GreaterThan() +"'"+currentTime.ToString()+"'";
                return BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, Tables.YK_BATCH).GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 检索指定药品在药剂科室中的批次（含已删除的）
        /// </summary>
        /// <param name="makerdicId">药品厂家典ＩＤ</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <returns>药品批次列表</returns>
        public static DataTable LoadBatchWithDelete(int makerdicId, int deptId)
        {
            try
            {
                string strWhere = BLL.Tables.yk_batch.DEPTID + oleDb.EuqalTo() + deptId.ToString()
                    + oleDb.And() + BLL.Tables.yk_batch.MAKERDICID + oleDb.EuqalTo() + makerdicId.ToString() + oleDb.OrderBy() + BLL.Tables.yk_batch.CURRENTNUM + oleDb.DESC(); //update by heyan 2010.12.15
                return BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, Tables.YK_BATCH).GetList(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
