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
    /// 处方头类
    /// </summary>
    public class PresHead : Model.Mz_Doc_PresHead
    {
        #region 成员变量
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;
        #endregion

        /// <summary>
        /// 处方头类构造函数
        /// </summary>
        public PresHead()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 处方头类构造函数
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public PresHead(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        /// <summary>
        /// 处方头类构造函数
        /// </summary>
        /// <param name="presHeadId">处方头Id</param>
        public PresHead(long presHeadId)
        {
            _oleDb = BaseBLL.oleDb;
            this.PresHeadId = (int)presHeadId;
        }

        /// <summary>
        /// 处方头类构造函数
        /// </summary>
        /// <param name="patListId">病人Id</param>
        /// <param name="type">类型</param>
        public PresHead(long patListId,int type)
        {
            _oleDb = BaseBLL.oleDb;
            this.PatListId = (int)patListId;
        }

        /// <summary>
        /// 获得处方头列表
        /// </summary>
        /// <param name="type">处方类型(1:未收费处方,2:未收费和已收费的正常处方,3:包含已退费的所有处方)</param>
        /// <returns></returns>
        private List<PresHead> GetPresHeadList(int type)
        {
            string strsql = HIS.BLL.Tables.mz_doc_preshead.PATLISTID + _oleDb.EuqalTo() + this.PatListId
                + _oleDb.And() + HIS.BLL.Tables.mz_doc_preshead.PRES_FLAG + _oleDb.LessThan() + type
                + _oleDb.OrderBy(HIS.BLL.Tables.mz_doc_preshead.PRESHEADID);
            return (List<PresHead>)Public.Function.DataTableToList<PresHead>(BindEntity<HIS.Model.Mz_Doc_PresHead>.CreateInstanceDAL(_oleDb).GetList(strsql));
        }

        /// <summary>
        /// 获得未收费的处方头列表
        /// </summary>
        /// <returns></returns>
        public List<PresHead> GetNoChangePresHeadList()
        {
            return GetPresHeadList(1);
        }

        /// <summary>
        /// 获得正常的处方头列表
        /// </summary>
        /// <returns></returns>
        public List<PresHead> GetNormalPresHeadList()
        {
            return GetPresHeadList(2);
        }

        /// <summary>
        /// 获得所以处方头列表
        /// </summary>
        /// <returns></returns>
        public List<PresHead> GetAllPresHeadList()
        {
            return GetPresHeadList(3);
        }

        /// <summary>
        /// 获取处方实时状态
        /// </summary>
        public Public.PresStatus GetPresStatus()
        {
            Model.Mz_Doc_PresHead presHead = BindEntity<Model.Mz_Doc_PresHead>.CreateInstanceDAL(_oleDb).GetModel(this.PresHeadId);
            return (Public.PresStatus)presHead.Pres_Flag;
        }
    }
}
