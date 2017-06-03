using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYDoc_BLL.BaseInfo
{
    public  class MediApplyBase:BaseBLL,IDisposable
    { 
        #region 获得所有医技类型
        /// <summary>
        /// 获得所有医技类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetMediClass()
        {
            return BindEntity<HIS.Model.Base_Medical_Class>.CreateInstanceDAL(oleDb).GetList("");
        }
        #endregion

        #region 获取样本表
        /// <summary>
        /// 获得样本表
        /// </summary>
        /// <returns></returns>
        public DataTable GetSample()
        {
            string strWhere = Tables.base_sample.DELETE_BIT + oleDb.EuqalTo() + 0;
            return BindEntity<HIS.Model.Base_Sample>.CreateInstanceDAL(oleDb).GetList(strWhere);
        }
        #endregion

        #region 获得附加说明
        /// <summary>
        ///  获得附加说明
        /// </summary>
        /// <returns></returns>
        public DataTable GetParam()
        {
            string strWhere = Tables.base_param.DELETE_BIT + oleDb.EuqalTo() + 0;
            return BindEntity<HIS.Model.Base_Param>.CreateInstanceDAL(oleDb).GetList(strWhere);
        }
        #endregion

        #region  获得检查部位
        /// <summary>
        ///  获得检查部位
        /// </summary>
        /// <returns></returns>
        public DataTable getCheckPlace()
        {
            return BindEntity<HIS.Model.Base_ExaminePlace>.CreateInstanceDAL(oleDb).GetList("");
        }
        #endregion

        #region 根据项目ID获得项目名称
        /// <summary>
        /// 根据项目ID获得项目名称
        /// </summary>
        /// <param name="item_id"></param>
        /// <returns></returns>
        public string GetItemClass(int item_id)
        {
            string strsql = "select name from { BASE_MEDICAL_CLASS } where id =(select medical_class from { BASE_ORDER_ITEMS } where order_id=" + item_id + ") ";
            object obj = oleDb.GetDataResult(strsql);
            if (obj != null && obj != DBNull.Value)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 获得医技类型
        /// <summary>
        /// 获取医技类型
        /// </summary>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public  int GetApplyType(int itemid)
        {
            string strWhere = Views.vi_clinical_order.ORDER_ID + oleDb.EuqalTo() + itemid + oleDb.And()
                + Views.vi_clinical_order.ORDER_TYPE + oleDb.EuqalTo() + 5;
            object obj = BindEntity<Views.vi_clinical_order>.CreateInstanceDAL(oleDb, Views.VI_CLINICAL_ORDER).GetFieldValue(Views.vi_clinical_order.CLASS_TYPE, strWhere);
            if (obj != null && obj != DBNull.Value)
            {
                return Convert.ToInt32(obj.ToString());
            }
            return -1;
        }
        #endregion 

        #region 是否与PACS接口连
        public  bool IsPacs()
        {
            if (OP_Config.GetValue("002") == "1")
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 是否与LIS接口连
        public  bool IsLis()
        {
            if (OP_Config.GetValue("003") == "1")
            {
                return true;
            }
            return false;

        }
        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            //throw new NotImplementedException();
            OP_Config.Reload(HIS.Base_BLL.Enums.ParameterCatalog.住院医生站);
        }

        #endregion
    }
}
