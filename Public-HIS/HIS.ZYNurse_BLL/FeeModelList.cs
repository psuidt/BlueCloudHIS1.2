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
    public class FeeModelList : HIS.Model.ZY_NURSE_FEEMODELLIST
    {
        public bool  Add(List<HIS.Model.ZY_NURSE_FEEMODELLIST> list)
        {
            try
            {
                HIS.SYSTEM.Core.BaseBLL.oleDb.BeginTransaction();
                for (int i = 0; i < list.Count; i++)
                {

                    if (BindEntity<HIS.Model.ZY_NURSE_FEEMODELLIST>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Exists(list[i].MODELLIST_ID))
                    {
                        BindEntity<HIS.Model.ZY_NURSE_FEEMODELLIST>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Update(list[i]);
                    }
                    else
                    {
                        BindEntity<HIS.Model.ZY_NURSE_FEEMODELLIST>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Add(list[i]);
                    }
                }
                HIS.SYSTEM.Core.BaseBLL.oleDb.CommitTransaction();
                return true;
            }
            catch (System.Exception e)
            {
                HIS.SYSTEM.Core.BaseBLL.oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }

        public void Delete(HIS.Model.ZY_NURSE_FEEMODELLIST list)
        {
            list.DELETE_FLAG = 1;
            BindEntity<HIS.Model.ZY_NURSE_FEEMODELLIST>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Update(list);
        }

        /// <summary>
        /// 得到账单模板明细
        /// </summary>
        /// <param name="modelid"></param>
        /// <returns></returns>
        public DataTable GetFeeList(int modelid)
        {
            string strWhere = Tables.zy_nurse_feemodellist.MODEL_ID + " = " + modelid + "" + " and delete_flag=0";
           return  BindEntity<HIS.Model.ZY_NURSE_FEEMODELLIST>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).GetList(strWhere);
        }
    }
}
