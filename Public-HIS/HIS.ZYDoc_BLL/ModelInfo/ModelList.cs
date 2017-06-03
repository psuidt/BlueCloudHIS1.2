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
    partial class ModelList:BaseBLL
    {
        #region 模板明细操作

        #region 获得模板明细
        /// <summary>
        /// 根据模板ID得到模板明细
        /// </summary>
        /// <returns></returns>
        public  DataTable GetModelList(int model_id)
        {
            try
            {
                string strWhere = Tables.zy_doc_ordermodellist.MODEL_ID + oleDb.EuqalTo() + model_id + oleDb.And()
                    + Tables.zy_doc_ordermodellist.MODELLIST_A2 + oleDb.NotEqualTo() + 1;
                List<HIS.Model.ZY_DOC_ORDERMODELLIST> zylist = BindEntity<HIS.Model.ZY_DOC_ORDERMODELLIST>.CreateInstanceDAL(oleDb).GetListArray(strWhere);

                List<HIS.Model.ZY_DOC_ORDERMODELLIST_E> zylist_e = new List<HIS.Model.ZY_DOC_ORDERMODELLIST_E>();
                for (int i = 0; i < zylist.Count; i++)
                {
                    HIS.Model.ZY_DOC_ORDERMODELLIST_E zyliste = new HIS.Model.ZY_DOC_ORDERMODELLIST_E();
                    zyliste = (HIS.Model.ZY_DOC_ORDERMODELLIST_E)HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjectToObj(zylist[i], zyliste);
                    zyliste.LoadData();
                    zylist_e.Add(zyliste);
                }
                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zylist_e);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 保存模板明细
        /// <summary>
        /// 保存模板明细
        /// </summary>
        /// <returns></returns>
        public  WrongDecline SaveModelList(List<HIS.Model.ZY_DOC_ORDERMODELLIST_E> modellist, int model_id)
        {
            try
            {
                WrongDecline wrong =OrderInfo.OrderCheck.CheckModelOrderData(modellist);
                if (wrong.err != "0")
                {
                    return wrong;
                }
                List<HIS.Model.ZY_DOC_ORDERMODELLIST> list = SaveList(modellist, model_id);
                oleDb.BeginTransaction();
                for (int i = 0; i < list.Count; i++)
                {
                    if (BindEntity<HIS.Model.ZY_DOC_ORDERMODELLIST>.CreateInstanceDAL(oleDb).Exists(list[i].MODELLIST_ID))
                    {
                        BindEntity<HIS.Model.ZY_DOC_ORDERMODELLIST>.CreateInstanceDAL(oleDb).Update(list[i]);
                    }
                    else
                    {
                        BindEntity<HIS.Model.ZY_DOC_ORDERMODELLIST>.CreateInstanceDAL(oleDb).Add(list[i]);
                    }
                }
                oleDb.CommitTransaction();
                return wrong;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 删除模板明细
        /// <summary>
        /// 删除指定医嘱
        /// </summary>
        /// <returns></returns>
        public  bool DelOrder(List<HIS.Model.ZY_DOC_ORDERMODELLIST> models)
        {
            try
            {
                oleDb.BeginTransaction();
                for (int i = 0; i < models.Count; i++)
                {
                    BindEntity<HIS.Model.ZY_DOC_ORDERMODELLIST>.CreateInstanceDAL(oleDb).Update(models[i]);
                    if (!IsExsitID(models[i].GROUP_ID))
                    {
                        UpdateGroupID(models[i].GROUP_ID);
                    }
                }
                oleDb.CommitTransaction();
                return true;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 修改模板明细
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="list"></param>
        public  void UpdateOrder(HIS.Model.ZY_DOC_ORDERMODELLIST list)
        {
            BindEntity<HIS.Model.ZY_DOC_ORDERMODELLIST>.CreateInstanceDAL(oleDb).Update(list);
        }
        #endregion

        private  List<HIS.Model.ZY_DOC_ORDERMODELLIST> SaveList(List<HIS.Model.ZY_DOC_ORDERMODELLIST_E> list, int model_id)
        {

            List<HIS.Model.ZY_DOC_ORDERMODELLIST> doc_modellist = new List<HIS.Model.ZY_DOC_ORDERMODELLIST>();
            int max_groupid = getGroupId(model_id);
            int id = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ITEM_TYPE != 7)
                {
                    list[i].ITEM_NAME =OrderInfo. OrderCheck.IsRightName(list[i].ITEM_NAME, list[i].ITEM_ID, list[i].ITEM_TYPE);
                }
                if (list[i].FLAG == 0)
                {
                    #region  按右键插入的行
                    if (list[i].MODELLIST_A1 == 1)
                    {
                        if (i >= 1 && list[i - 1].FLAG == 1)
                        {
                            id = list[i - 1].GROUP_ID;
                        }
                        list[i].GROUP_ID = id;
                        list[i].FLAG = 1;
                        list[i].MODEL_ID = model_id;
                        doc_modellist.Add(list[i]);
                    }
                    #endregion
                    else
                    {
                        if (list[i].ITEM_TYPE > 3)
                        {
                            max_groupid += 1;
                            list[i].MODEL_ID = model_id;
                            list[i].FLAG = 1;
                            list[i].GROUP_ID = max_groupid;
                            doc_modellist.Add(list[i]);
                        }
                        else
                        {
                            max_groupid += 1;
                            list[i].MODEL_ID = model_id;
                            list[i].FLAG = 1;
                            list[i].GROUP_ID = max_groupid;
                            doc_modellist.Add(list[i]);
                            for (int j = i + 1; j < list.Count; j++)
                            {
                                if (list[j].GroupID == 0)
                                {
                                    list[j].MODEL_ID = model_id;
                                    list[j].FLAG = 1;
                                    list[j].GROUP_ID = max_groupid;
                                    doc_modellist.Add(list[j]);
                                    if (j == list.Count - 1)
                                    {
                                        i = j;
                                        break;
                                    }
                                }                             
                            }
                        }
                    }
                }
                if (list[i].FLAG == 2)
                {
                    list[i].FLAG = 1;
                    doc_modellist.Add(list[i]);
                }
            }
            return doc_modellist;
        }
        #endregion   

        #region 获得组号
        /// <summary>
        /// 获得最大医嘱组号
        /// </summary>
        /// <param name="modellistid"></param>
        /// <returns></returns>
        private  int getGroupId(int modelid)
        {
            string strWhere = Tables.zy_doc_ordermodellist.MODEL_ID + oleDb.EuqalTo() + modelid + oleDb.And()
                + Tables.zy_doc_ordermodellist.MODELLIST_A2 + oleDb.NotEqualTo() + 1;
            return BindEntity<HIS.Model.ZY_DOC_ORDERMODELLIST>.CreateInstanceDAL(oleDb).GetMaxId(Tables.zy_doc_ordermodellist.GROUP_ID, strWhere);
        }
        #endregion

        #region 修改组号
        /// <summary>
        /// 当删除医嘱时，要改变其他医嘱的组号
        /// </summary>
        /// <param name="id"></param>
        private  void UpdateGroupID(int gid)
        {
            int groupid = Convert.ToInt32(Tables.zy_doc_ordermodellist.GROUP_ID) - 1;
            string strWhere = Tables.zy_doc_ordermodellist.MODELLIST_A2 + oleDb.NotEqualTo() + 1 + oleDb.And()
                + Tables.zy_doc_ordermodellist.GROUP_ID + oleDb.GreaterThan() + gid;
            string strSet = Tables.zy_doc_ordermodellist.GROUP_ID + oleDb.EuqalTo() + groupid;
            BindEntity<HIS.Model.ZY_DOC_ORDERMODELLIST>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
        }
        #endregion

        #region 判断组号是否存在
        /// <summary>
        ///  判断是否还存在相同组号的
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private  bool IsExsitID(int gid)
        {
            string strWhere = Tables.zy_doc_ordermodellist.GROUP_ID + oleDb.EuqalTo() + gid + oleDb.And()
                + Tables.zy_doc_ordermodellist.MODELLIST_A2 + oleDb.NotEqualTo() + 1;
            if (BindEntity<HIS.Model.ZY_DOC_ORDERMODELLIST>.CreateInstanceDAL(oleDb).Exists(strWhere))
            {
                return true;
            }
            return false;
        }
        #endregion    
        
    }
}
