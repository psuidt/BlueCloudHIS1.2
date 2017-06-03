using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// 库存处理器
    /// </summary>
    public abstract class StoreQuery : HIS.SYSTEM.Core.BaseBLL
    {
        /// <summary>
        /// 查询库存数量
        /// </summary>
        /// <param name="makerDicId">药品厂家典ID</param>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>库存数量</returns>
        public abstract decimal QueryNum(int makerDicId, int deptId);
        /// <summary>
        /// 查询药品信息
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <returns>药品信息</returns>
        public abstract DataTable LoadDrugInfo(int deptId);
        /// <summary>
        /// 查询药品信息
        /// </summary>
        /// <param name="ykDeptId">药库科室ID</param>
        /// <param name="yfDeptId">药房科室ID</param>
        /// <returns>药品信息表</returns>
        public abstract DataTable LoadDrugInfo(int ykDeptId, int yfDeptId);

        /// <summary>
        /// 查询药品信息
        /// </summary>
        /// <param name="doseId">剂型ID</param>
        /// <param name="typeId">类型ID</param>
        /// <param name="deptId">部门ID</param>
        /// <returns>药品信息</returns>
        public abstract DataTable LoadDrugInfo(int doseId, int typeId, int deptId);

        /// <summary>
        /// 查询药品库存信息
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>药品库存信息</returns>
        public abstract DataTable LoadStoreInfo(int deptId);
        
        /// <summary>
        /// 查询药品库存上下限信息
        /// </summary>
        /// <param name="drugType">药品类型</param>
        /// <param name="validityDay">药品效期</param>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>药品库存上下限信息</returns>
        public abstract DataTable GetDrugForValidity(string drugType, int validityDay, int deptId);

        /// <summary>
        ///查询药品库存上下限信息
        /// </summary>
        /// <param name="queryCode">药品编码（厂家ID）</param>
        /// <param name="isUpperLimt">查询状态（1.低于下限；2.高于上限）</param>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="typeDicId">药品类型</param>
        /// <returns>药品库存上下限信息</returns>
        public abstract DataTable GetDrugForStoreLimit(string queryCode, bool isUpperLimt, int deptId, int typeDicId);

        /// <summary>
        /// 提取盘点药品信息
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>待盘药品信息</returns>
        public abstract DataTable GetCheckDrug(int deptId);
        /// <summary>
        /// 查询药品库存信息
        /// </summary>
        /// <param name="drugType">查询药品类型</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="queryCode">查询代码</param>
        /// <param name="drugDose">药品剂型</param>
        /// <returns>药品库存信息表</returns>
        public abstract DataTable QueryStoreInfo(int drugType, int drugDose, int deptId, string queryCode);

        /// <summary>
        /// 查询库存零售金额
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <param name="drugType">药品类型</param>
        /// <returns>库存零售金额</returns>
        public abstract decimal QueryStoreFee(int deptId, int drugType);

        /// <summary>
        /// 查询库存批发金额
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="drugType">药品类型</param>
        /// <returns>库存批发金额</returns>
        public abstract decimal QueryTradeFee(int deptId, int drugType);

        /// <summary>
        /// 加载批次信息（）
        /// </summary>
        /// <param name="makerdicId">药品厂家典ID</param>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>批次信息</returns>
        public DataTable LoadBatch(int makerdicId, int deptId)
        {
            try
            {
                return BatchQuery.LoadBatch(makerdicId, deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载指定科室的批次信息
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <returns>批次表</returns>
        public DataTable LoadBatch(int deptId)
        {
            try
            {
                return BatchQuery.LoadBatch(deptId);

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载指定药剂科室所有批次信息（含已删除的）
        /// </summary>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <returns>批次信息列表</returns>
        public DataTable LoadBatchWithDelete(int deptId)
        {
            try
            {

                return BatchQuery.LoadBatchWithDelete(deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        ///  加载指定药品在药剂科室的所有批次信息
        /// </summary>
        /// <param name="makerdicId">药品厂家典ID</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <returns>批次信息列表</returns>
        public DataTable LoadBatchWithDelete(int makerdicId, int deptId)
        {
            try
            {
                return BatchQuery.LoadBatchWithDelete(makerdicId, deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public abstract DataTable GetSupportInfo(DateTime ? bTime,DateTime ? eTime);
       
    }
}
