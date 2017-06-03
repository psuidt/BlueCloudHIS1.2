using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 住院接口
    /// </summary>
    public class ZY_Interface : BaseBLL
    {
        /// <summary>
        /// 根据住院处方明细ID获取可退药数量
        /// </summary>
        /// <param name="recipeOrderID">处方明细ID</param>
        /// <returns>该处方明细ID对应的可退药数量</returns>
        public static decimal UpdateSendDrugFlag(int recipeOrderID)
        {
            try
            {
                string strWhere1 = Tables.yf_drorder.DRUGOC_FLAG + oleDb.EuqalTo() + "0" + oleDb.And() + Tables.yf_drorder.ORDERRECIPEID +
                    oleDb.EuqalTo() + recipeOrderID;
                object obj1 = BindEntity<HIS.Model.YP_DROrder>.CreateInstanceDAL(oleDb, Tables.YF_DRORDER).GetSum(Tables.yf_drorder.DRUGOCNUM, strWhere1);
                string strWhere2 = Tables.yf_drorder.DRUGOC_FLAG + oleDb.EuqalTo() + "1" + oleDb.And() + Tables.yf_drorder.ORDERRECIPEID +
                    oleDb.EuqalTo() + recipeOrderID;
                object obj2 = BindEntity<HIS.Model.YP_DROrder>.CreateInstanceDAL(oleDb, Tables.YF_DRORDER).GetSum(Tables.yf_drorder.DRUGOCNUM, strWhere2);
                if (obj1 != null && obj1 != DBNull.Value)
                {
                    return Convert.ToDecimal(obj2.ToString().Trim()) - Convert.ToDecimal(obj1.ToString().Trim());
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
