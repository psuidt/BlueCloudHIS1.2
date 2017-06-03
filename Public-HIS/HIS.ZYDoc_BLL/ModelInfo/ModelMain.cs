using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.Core;
using HIS.BLL;
using Entity = HIS.Model;

namespace HIS.ZYDoc_BLL.ModelInfo
{
    partial class ModelMain : BaseBLL
    {

        #region 模板主表操作

        #region 保存模板主表
        /// <summary>
        /// 保存模板主表
        /// </summary
        /// <returns></returns>
        public  int  SaveModeltype(HIS.Model.ZY_DOC_ORDERMODEL model)
        {
            try
            {
               return  BindEntity<HIS.Model.ZY_DOC_ORDERMODEL>.CreateInstanceDAL(oleDb).Add(model);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 获得模板类型
        /// <summary>
        ///得到模板类型名
        /// </summary>
        /// <returns></returns>
        public  DataTable GetModelType(int level, int userid, int deptid)
        {
            try
            {
                string strWhere = "(" + "(" + Tables.zy_doc_ordermodel.MODEL_TYPE + oleDb.EuqalTo() + 1 + oleDb.And() + Tables.zy_doc_ordermodel.P_ID + oleDb.EuqalTo() + -1 + oleDb.And() + Tables.zy_doc_ordermodel.DELETE_FLAG + oleDb.EuqalTo() + 0 + ")"
                    + oleDb.Or() +
                "(" + Tables.zy_doc_ordermodel.MODEL_TYPE + oleDb.EuqalTo() + 0 + ")" + oleDb.And() + Tables.zy_doc_ordermodel.DELETE_FLAG + oleDb.EuqalTo() + 0 + ")";

                strWhere += oleDb.And() + Tables.zy_doc_ordermodel.MODEL_LEVEL + oleDb.EuqalTo() + level;

                if (level == 1) //科室级
                {
                    strWhere += oleDb.And() + Tables.zy_doc_ordermodel.CREATE_DEPT + oleDb.EuqalTo() + deptid;
                }
                if (level == 2)//个人级
                {
                    strWhere += oleDb.And() + Tables.zy_doc_ordermodel.CREATE_DOC + oleDb.EuqalTo() + userid;
                }
                return BindEntity<HIS.Model.ZY_DOC_ORDERMODEL>.CreateInstanceDAL(oleDb).GetList(strWhere);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 获得模板名称
        /// <summary>
        ///根据模板类型名得到该类型的模板名
        /// </summary>
        /// <returns></returns>
        public  DataTable GetModelName(int model_id)
        {
            try
            {
                string strWhere = Tables.zy_doc_ordermodel.P_ID + oleDb.EuqalTo() + model_id + oleDb.And()
                    + Tables.zy_doc_ordermodel.DELETE_FLAG + oleDb.EuqalTo() + 0;
                return BindEntity<HIS.Model.ZY_DOC_ORDERMODEL>.CreateInstanceDAL(oleDb).GetList(strWhere, Tables.zy_doc_ordermodel.MODEL_ID, Tables.zy_doc_ordermodel.MODEL_NAME);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 判断模板是否存在
        /// <summary>
        /// 删除指定医嘱
        /// </summary>
        /// <returns></returns>
        private  bool ModelExist(int modelid)
        {
            try
            {
                object obj = BindEntity<HIS.Model.ZY_DOC_ORDERMODEL>.CreateInstanceDAL(oleDb).GetFieldValue
                    (Tables.zy_doc_ordermodel.MODEL_TYPE, Tables.zy_doc_ordermodel.MODEL_ID + oleDb.EuqalTo() + modelid);
                DataTable tb = new DataTable();
                if (obj.ToString() == "0")
                {
                    string strWhere = Tables.zy_doc_ordermodel.P_ID + oleDb.EuqalTo() + modelid + oleDb.And()
                        + Tables.zy_doc_ordermodel.DELETE_FLAG + oleDb.EuqalTo() + 0 ;
                    tb = BindEntity<HIS.Model.ZY_DOC_ORDERMODEL>.CreateInstanceDAL(oleDb).GetList(strWhere);
                }
                string strWhere1 = Tables.zy_doc_ordermodellist.MODEL_ID + oleDb.EuqalTo() + modelid + oleDb.And()
                    + Tables.zy_doc_ordermodellist.MODELLIST_A2 + oleDb.EuqalTo() + 0;               
                DataTable tb1 = BindEntity<HIS.Model.ZY_DOC_ORDERMODELLIST>.CreateInstanceDAL(oleDb).GetList(strWhere1);
                if (tb.Rows.Count > 0 || tb1.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 模板结点删除
        /// <summary>
        /// 删除树节点
        /// </summary>
        /// <returns></returns>
        public  bool DelNode(int modelid)
        {
            if (ModelExist(modelid))
            {
                return false;
            }
            try
            {
                string strWhere = Tables.zy_doc_ordermodel.MODEL_ID + oleDb.EuqalTo() + modelid + oleDb.And()
                    + Tables.zy_doc_ordermodel.DELETE_FLAG + oleDb.EuqalTo() + 0;
                string strSet = Tables.zy_doc_ordermodel.DELETE_FLAG + oleDb.EuqalTo() + 1;
                BindEntity<HIS.Model.ZY_DOC_ORDERMODEL>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                return true;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 修改模板名
        /// <summary>
        /// 修改树节点名称
        /// </summary>
        /// <param name="modelid"></param>
        /// <param name="NodeName"></param>
        public  void UpdateNode(int modelid, string NodeName)
        {
            try
            {
                string strWhere = Tables.zy_doc_ordermodel.MODEL_ID + oleDb.EuqalTo() + modelid + oleDb.And()
                    + Tables.zy_doc_ordermodel.DELETE_FLAG + oleDb.EuqalTo() + 0;
                string strSet = Tables.zy_doc_ordermodel.MODEL_NAME + oleDb.EuqalTo() + "'" + NodeName + "'";
                BindEntity<HIS.Model.ZY_DOC_ORDERMODEL>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 得到最大模板主表ID
        //得到最大模板主表ID
        public int Get_MaxModelid()
        {
            return BindEntity<HIS.Model.ZY_DOC_ORDERMODEL>.CreateInstanceDAL(oleDb).GetMaxId();
        }
        #endregion   
        #endregion
    }
}
