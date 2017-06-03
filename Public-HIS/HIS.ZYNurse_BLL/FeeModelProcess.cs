using System;
using System.Collections.Generic;

using System.Text;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using System.Data;


namespace HIS.ZYNurse_BLL
{
    public class FeeModelProcess : HIS.Model.ZY_NURSE_FEEMODEL
    {
     
        public void Add()
        {
            BindEntity<HIS.Model.ZY_NURSE_FEEMODEL>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Add(this);
        }

        public void Delete()
        {
            this.DELETE_FLAG = 1;
            BindEntity<HIS.Model.ZY_NURSE_FEEMODEL>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Update(this);
        }

        public void Update()
        {
            BindEntity<HIS.Model.ZY_NURSE_FEEMODEL>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Update(this);
        }

        //判断模板名称是否存在 
        public bool IsExsistName(string modelname,int modeltype,int modellevel)
        {
            string strWhere = HIS.BLL.Tables.zy_nurse_feemodel.MODEL_NAME + " = '" + modelname + "'" + " and " +HIS.BLL.Tables.zy_nurse_feemodel.MODEL_TYPE
                    + " = "+MODEL_TYPE+" " +" and "+HIS.BLL.Tables.zy_nurse_feemodel.DELETE_FLAG+ " =0";
            return BindEntity<HIS.Model.ZY_NURSE_FEEMODEL>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Exists(strWhere);
        }

        //判断结点是否有子结点
        public bool IsExsistChilds(int modelid)
        {
            string strWhere = HIS.BLL.Tables.zy_nurse_feemodel.P_ID + " = "+modelid+""  + " and " + HIS.BLL.Tables.zy_nurse_feemodel.DELETE_FLAG + " =0";
            return BindEntity<HIS.Model.ZY_NURSE_FEEMODEL>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Exists(strWhere);
        }

        public bool IsExsistFeeList(int modelid)
        {
            string strWhere = HIS.BLL.Tables.zy_nurse_feemodellist.MODEL_ID + " = " + modelid + "" + " and " + HIS.BLL.Tables.zy_nurse_feemodellist.DELETE_FLAG + " =0";
            return BindEntity<HIS.Model.ZY_NURSE_FEEMODELLIST>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Exists(strWhere);
        }

        #region 获得模板类型
        /// <summary>
        ///得到模板类型名
        /// </summary>
        /// <returns></returns>
        public List<HIS.Model.ZY_NURSE_FEEMODEL> GetModelType(int level, int userid, int deptid)
        {
            try
            {
                string strWhere = @"(" + "(" + Tables.zy_nurse_feemodel.MODEL_TYPE + HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() + 1 + HIS.SYSTEM.Core.BaseBLL.oleDb.And() + Tables.zy_nurse_feemodel.P_ID +
                    HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() + -1 + HIS.SYSTEM.Core.BaseBLL.oleDb.And() + Tables.zy_nurse_feemodel.DELETE_FLAG + HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() + 0 + ")"
                    + HIS.SYSTEM.Core.BaseBLL.oleDb.Or() +
                "(" + Tables.zy_nurse_feemodel.MODEL_TYPE + HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() + 0 + ")" + HIS.SYSTEM.Core.BaseBLL.oleDb.And()
                + Tables.zy_nurse_feemodel.DELETE_FLAG + HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() + 0 + " and p_id=-1"+")";

                strWhere += HIS.SYSTEM.Core.BaseBLL.oleDb.And() + Tables.zy_nurse_feemodel.MODEL_LEVEL + HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() + level;

                if (level == 1) //科室级
                {
                    strWhere += HIS.SYSTEM.Core.BaseBLL.oleDb.And() + Tables.zy_nurse_feemodel.CREATE_DEPT + HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() + deptid;
                }
                if (level == 2)//个人级
                {
                    strWhere += HIS.SYSTEM.Core.BaseBLL.oleDb.And() + Tables.zy_nurse_feemodel.CREATE_NURSE + HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() + userid;
                }
                return BindEntity<HIS.Model.ZY_NURSE_FEEMODEL>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).GetListArray(strWhere);
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
        public List<HIS.Model.ZY_NURSE_FEEMODEL> GetModelName(int model_id)
        {
            try
            {
                string strWhere = Tables.zy_nurse_feemodel.P_ID + HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() + model_id + HIS.SYSTEM.Core.BaseBLL.oleDb.And()
                    + Tables.zy_nurse_feemodel.DELETE_FLAG + HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() + 0;
                return BindEntity<HIS.Model.ZY_NURSE_FEEMODEL>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).GetListArray(strWhere);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
