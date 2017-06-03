using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZYDoc_BLL.ModelInfo
{
    public interface  IModelOP
    {
        /// <summary>
        /// 保存模板头
        /// </summary>
        /// <param name="model"></param>
        int SaveModeltype(HIS.Model.ZY_DOC_ORDERMODEL model);//保存模板头

        /// <summary>
        /// 获得所有模板类型
        /// </summary>
        /// <param name="level"></param>
        /// <param name="userid"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        DataTable GetModelType(int level, int userid, int deptid);//获得所有模板类型

        /// <summary>
        /// 获得所有模板名称
        /// </summary>
        /// <param name="model_id"></param>
        /// <returns></returns>
        DataTable GetModelName(int model_id);//获得所有模板名称

        /// <summary>
        /// 删除树结点
        /// </summary>
        /// <param name="modelid"></param>
        /// <returns></returns>
        bool DelNode(int modelid);//删除树结点

        /// <summary>
        /// 修改模板节点名
        /// </summary>
        /// <param name="modelid"></param>
        /// <param name="NodeName"></param>
        void UpdateNode(int modelid, string NodeName);//修改模板节点名

        /// <summary>
        /// 保存模板明细
        /// </summary>
        /// <param name="modellist"></param>
        /// <param name="model_id"></param>
        /// <returns></returns>
        WrongDecline SaveModelList(List<HIS.Model.ZY_DOC_ORDERMODELLIST_E> modellist, int model_id);//保存模板明细

        /// <summary>
        /// 删除模板明细
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        bool DelOrder(List<HIS.Model.ZY_DOC_ORDERMODELLIST> models);//删除模板明细  
      
        /// <summary>
        /// 获得模板明细
        /// </summary>
        /// <param name="model_id"></param>
        /// <returns></returns>
        DataTable GetModelList(int model_id);  //获得模板明细
        /// <summary>
        /// 得到最大模板主表ID
        /// </summary>
        /// <returns></returns>
        int Get_MaxModelid();//得到最大模板主表ID
    }
}
