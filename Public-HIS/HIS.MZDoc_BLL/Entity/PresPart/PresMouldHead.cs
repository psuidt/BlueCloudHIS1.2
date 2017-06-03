using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 处方模板头类
    /// </summary>
    public class PresMouldHead : Model.Mz_Doc_PresMouldHead
    {
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;

        /// <summary>
        /// 处方模板头类
        /// </summary>
        public PresMouldHead()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 处方模板头类
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public PresMouldHead(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        /// <summary>
        /// 获得模板列表
        /// </summary>
        /// <param name="level">模板级别</param>
        /// <param name="deptId">所属科室</param>
        /// <param name="employeeId">所属医生</param>
        /// <returns></returns>
        public DataTable GetMouldHeadList(int level, long deptId, long employeeId)
        {
            string strwhere = Tables.mz_doc_presmouldhead.MOULD_LEVEL + _oleDb.EuqalTo() + level
                + _oleDb.And() + Tables.mz_doc_presmouldhead.DELETE_BIT + _oleDb.EuqalTo() + 0;
            switch (level)
            {
                case 2:
                    strwhere = strwhere + _oleDb.And() + HIS.BLL.Tables.mz_doc_presmouldhead.CREATE_DEPT + _oleDb.EuqalTo() + deptId;
                    break;
                case 3:
                    strwhere = strwhere + _oleDb.And() + HIS.BLL.Tables.mz_doc_presmouldhead.CREATE_DOC + _oleDb.EuqalTo() + employeeId;
                    break;
                default:
                    break;
            }
            return BindEntity<HIS.Model.Mz_Doc_PresMouldHead>.CreateInstanceDAL(_oleDb).GetList(strwhere);
        }

        /// <summary>
        /// 添加模板
        /// </summary>
        public int Add()
        {
            return BindEntity<Model.Mz_Doc_PresMouldHead>.CreateInstanceDAL(_oleDb).Add(this);
        }

        /// <summary>
        /// 修改模板
        /// </summary>
        public void Update()
        {
            BindEntity<Model.Mz_Doc_PresMouldHead>.CreateInstanceDAL(_oleDb).Update(this);
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        public void Delete()
        {
            this.Delete_Bit = 1;
            BindEntity<Model.Mz_Doc_PresMouldHead>.CreateInstanceDAL(_oleDb).Update(this);
        }

        /// <summary>
        ///  获得模板内容
        /// </summary>
        /// <returns></returns>
        public DataTable GetMouldContents()
        {
            int presNo = 0;
            int orderNo = 0;
            string strwhere = Tables.mz_doc_presmouldlist.PRESMOULDHEADID + _oleDb.EuqalTo() + this.PresMouldHeadId + _oleDb.And() + Tables.mz_doc_presmouldlist.DELETE_BIT + _oleDb.EuqalTo() + 0
                + _oleDb.OrderBy(Tables.mz_doc_presmouldlist.PRESNO, Tables.mz_doc_presmouldlist.ORDERNO);
            DataTable mouldListTable = BindEntity<Model.Mz_Doc_PresMouldList>.CreateInstanceDAL(_oleDb).GetList(strwhere);
            List<PresMouldList> mouldLists = new List<PresMouldList>();
            foreach (DataRow row in mouldListTable.Rows)
            {
                PresMouldList mouldList = new PresMouldList();
                mouldList = (PresMouldList)Public.Function.DataRowToObject<PresMouldList>(row);
                mouldList.LoadData();
                if (mouldList.PresNo != presNo)
                {
                    if (presNo != 0)
                    {
                        PresMouldList mouldList0 = new PresMouldList();
                        mouldList0.Item_Name = "小计：";
                        mouldList0.PresNo = presNo;
                        mouldList0.OrderNo = orderNo + 1;
                        mouldList0.Status = HIS.MZDoc_BLL.Public.PresStatus.保存状态;
                        mouldLists.Add(mouldList0);
                    }
                    //mouldList.TmpNo = Convert.ToString(++presNo);
                    presNo++;
                }
                mouldList.Status = HIS.MZDoc_BLL.Public.PresStatus.保存状态;
                mouldLists.Add(mouldList);
                orderNo = mouldList.OrderNo;
            }
            if (presNo != 0)
            {
                PresMouldList mouldList0 = new PresMouldList();
                mouldList0.Item_Name = "小计：";
                mouldList0.PresNo = presNo;
                mouldList0.OrderNo = orderNo + 1;
                mouldList0.Status = HIS.MZDoc_BLL.Public.PresStatus.保存状态;
                mouldLists.Add(mouldList0);
            }
            return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(mouldLists);
        }

        /// <summary>
        ///  获得模板明细
        /// </summary>
        /// <returns></returns>
        public DataTable GetMouldList()
        {
            string strwhere = Tables.mz_doc_presmouldlist.PRESMOULDHEADID + _oleDb.EuqalTo() + this.PresMouldHeadId + _oleDb.And() + Tables.mz_doc_presmouldlist.DELETE_BIT + _oleDb.EuqalTo() + 0
                + _oleDb.OrderBy(Tables.mz_doc_presmouldlist.PRESNO, Tables.mz_doc_presmouldlist.ORDERNO);
            DataTable mouldListTable = BindEntity<Model.Mz_Doc_PresMouldList>.CreateInstanceDAL(_oleDb).GetList(strwhere);
            List<PresMouldList> mouldLists = new List<PresMouldList>();
            foreach (DataRow row in mouldListTable.Rows)
            {
                PresMouldList mouldList = new PresMouldList();
                mouldList = (PresMouldList)Public.Function.DataRowToObject<PresMouldList>(row);
                mouldList.Group_Id = 0;
                mouldList.LoadData();
                mouldLists.Add(mouldList);
            }
            return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(mouldLists);
        }
    }
}
