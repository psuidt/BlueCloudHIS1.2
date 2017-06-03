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
    public class ModelOperation : BaseBLL, IModelOP
    {
        ModelMain mainop = new ModelMain();
        ModelList listop = new ModelList();
        #region 保存模板头
        /// <summary>
        /// 保存模板头
        /// </summary>
        /// <param name="model"></param>
        public int  SaveModeltype(HIS.Model.ZY_DOC_ORDERMODEL model)
        {
           return  mainop.SaveModeltype(model);
        }
        #endregion

        #region 获得所有模板类型
        /// <summary>
        /// 获得所有模板类型
        /// </summary>
        /// <param name="level"></param>
        /// <param name="userid"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public DataTable GetModelType(int level, int userid, int deptid)//获得所有模板类型
        {
            return mainop.GetModelType(level, userid, deptid);
        }
        #endregion

        #region 获得所有模板名称
        /// <summary>
        /// 获得所有模板名称
        /// </summary>
        /// <param name="model_id"></param>
        /// <returns></returns>
        public DataTable GetModelName(int model_id)//获得所有模板名称
        {
            return mainop.GetModelName(model_id);
        }
        #endregion

        #region 删除树结点
        /// <summary>
        /// 删除树结点
        /// </summary>
        /// <param name="modelid"></param>
        /// <returns></returns>
        public bool DelNode(int modelid)//删除树结点
        {
            return mainop.DelNode(modelid);
        }
        #endregion

        #region 修改模板节点名
        /// <summary>
        /// 修改模板节点名
        /// </summary>
        /// <param name="modelid"></param>
        /// <param name="NodeName"></param>
        public void UpdateNode(int modelid, string NodeName)//修改模板节点名
        {
            mainop.UpdateNode(modelid, NodeName);
        }
        #endregion

        #region 保存模板明细
        /// <summary>
        /// 保存模板明细
        /// </summary>
        /// <param name="modellist"></param>
        /// <param name="model_id"></param>
        /// <returns></returns>
        public WrongDecline SaveModelList(List<HIS.Model.ZY_DOC_ORDERMODELLIST_E> modellist, int model_id)//保存模板明细
        {
            return listop.SaveModelList(modellist, model_id);
        }
        #endregion

        #region 删除模板明细
        /// <summary>
        /// 删除模板明细
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public bool DelOrder(List<HIS.Model.ZY_DOC_ORDERMODELLIST> models)//删除模板明细
        {
            return listop.DelOrder(models);
        }
        #endregion

        #region 获得模板明细
        /// <summary>
        /// 获得模板明细
        /// </summary>
        /// <param name="model_id"></param>
        /// <returns></returns>
        public DataTable GetModelList(int model_id)  //获得模板明细
        {
            return listop.GetModelList(model_id);
        }
        #endregion

        #region 得到最大模板主表ID
        /// <summary>
        /// 得到最大模板主表ID
        /// </summary>
        /// <returns></returns>
        public int Get_MaxModelid()
        {
            return mainop.Get_MaxModelid();
        }
        #endregion
    }
}
