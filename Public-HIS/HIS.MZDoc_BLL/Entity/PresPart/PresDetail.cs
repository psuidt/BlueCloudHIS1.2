using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 处方明细类
    /// </summary>
    public class PresDetail:Model.Mz_Doc_PresList
    {
        #region 成员变量
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;
        #endregion

        /// <summary>
        /// 处方明细类构造函数
        /// </summary>
        public PresDetail()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 处方明细类构造函数
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public PresDetail(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        /// <summary>
        /// 处方明细类构造函数
        /// </summary>
        /// <param name="presHeadId">处方头Id</param>
        public PresDetail(long presHeadId)
        {
            _oleDb = BaseBLL.oleDb;
            this.PresHeadId = (int)presHeadId;
        }

        /// <summary>
        /// 获得处方明细列表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public List<PresDetail> GetPresDetailList(string condition)
        {
            string strsql = HIS.BLL.Tables.mz_doc_preslist.PRESHEADID + _oleDb.EuqalTo() + this.PresHeadId
                    + _oleDb.And() + HIS.BLL.Tables.mz_doc_preslist.DELETE_BIT + _oleDb.EuqalTo() + 0
                    + (condition == "" ? "" : (_oleDb.And() + condition))
                    + _oleDb.OrderBy(HIS.BLL.Tables.mz_doc_preslist.ORDERNO);
            return (List<PresDetail>)Public.Function.DataTableToList<PresDetail>(BindEntity<HIS.Model.Mz_Doc_PresList>.CreateInstanceDAL(_oleDb).GetList(strsql));
        }

        /// <summary>
        /// 获得皮试处方明细列表
        /// </summary>
        /// <returns></returns>
        public List<PresDetail> GetSkinTestPresDetailList()
        {
            string strsql = HIS.BLL.Tables.mz_doc_preslist.SKINTEST_FLAG + _oleDb.GreaterThan() + 0
                    + _oleDb.And() + HIS.BLL.Tables.mz_doc_preslist.SKINTEST_FLAG + _oleDb.LessThan() + 4;
            return GetPresDetailList(strsql);
        }

        /// <summary>
        /// 获得输液处方明细列表
        /// </summary>
        /// <returns></returns>
        public List<PresDetail> GetTransPresDetailList()
        {
            string strsql = HIS.BLL.Tables.mz_doc_preslist.USAGE_ID + _oleDb.In(OP_ReadBaseData.GetTransUseageIdList());
            return GetPresDetailList(strsql);
        }

        /// <summary>
        /// 获得所有处方明细列表
        /// </summary>
        /// <returns></returns>
        public List<PresDetail> GetAllPresDetailList()
        {
            return GetPresDetailList("");
        }
    }
}
