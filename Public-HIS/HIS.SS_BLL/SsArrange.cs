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

namespace HIS.SS_BLL
{
    public class SsArrange : BaseBLL
    {
        #region 手术安排保存
        /// <summary>
        /// 手术安排保存
        /// </summary>
        /// <param name="arrange"></param>
        /// <param name="bedid"></param>
        /// <returns></returns>
        public bool SaveArrange(HIS.Model.SS_ARRANGE arrange,string  bedName,int emr,int anth,int opera)
        {
            try
            {
                oleDb.BeginTransaction();
                string strexistWhere = Tables.ss_arrange.APPLY_ID + oleDb.EuqalTo() + arrange.APPLY_ID  +
                    oleDb.And() + Tables.ss_arrange.DELETE_FLAG + oleDb.EuqalTo() + 0
                    + oleDb.And() + Tables.ss_arrange.FINISH_FLAG + oleDb.EuqalTo() + 0;

                string strWhere = Tables.ss_apply.APPLY_ID + oleDb.EuqalTo() + arrange.APPLY_ID+oleDb.And()
                  +Tables.ss_apply.DELETE_FLAG+oleDb.EuqalTo()+0;
                string strSet = Tables.ss_apply.ARRANGE_FLAG + oleDb.EuqalTo() + 1+","+Tables.ss_apply.EMERGENCY_OPERA+oleDb.EuqalTo()+emr+
                    "," + Tables.ss_apply.ANESTH_CONSENT + oleDb.EuqalTo() + anth + "," +
                    Tables.ss_apply.OPERA_CONSENT+oleDb.EuqalTo()+opera;
                string strWherebed=Tables.ss_roombed.NAME+oleDb.EuqalTo()+"'"+bedName+"'"+oleDb.And()+Tables.ss_roombed.USE_FLAG+oleDb.EuqalTo()+0;
                string strSetbed=Tables.ss_roombed.USE_FLAG+oleDb.EuqalTo()+1;

                if (BindEntity<HIS.Model.SS_ARRANGE>.CreateInstanceDAL(oleDb).Exists(strexistWhere))
                {                  
                    string bed = BindEntity<HIS.Model.SS_ARRANGE>.CreateInstanceDAL(oleDb).GetFieldValue("opera_roombed", Tables.ss_arrange.APPLY_ID + oleDb.EuqalTo() + arrange.APPLY_ID).ToString();
                    if (bed != bedName)
                    {
                        string Wherebed = Tables.ss_roombed.NAME + oleDb.EuqalTo() + "'" + bed + "'" + oleDb.And() + Tables.ss_roombed.USE_FLAG + oleDb.EuqalTo() + 1;
                        string Setbed = Tables.ss_roombed.USE_FLAG + oleDb.EuqalTo() + 0;
                        BindEntity<HIS.Model.SS_ROOMBED>.CreateInstanceDAL(oleDb).Update(Wherebed, Setbed);
                    }
                    BindEntity<HIS.Model.SS_ARRANGE>.CreateInstanceDAL(oleDb).Update(arrange);
                }
                else
                {
                    BindEntity<HIS.Model.SS_ARRANGE>.CreateInstanceDAL(oleDb).Add(arrange);
                }
                BindEntity<HIS.Model.SS_APPLY>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                BindEntity<HIS.Model.SS_ROOMBED>.CreateInstanceDAL(oleDb).Update(strWherebed,strSetbed);//修改台次表           
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

        #region 得到手术安排实体
        /// <summary>
        /// 得到手术安排实体
        /// </summary>
        /// <param name="applyid"></param>
        /// <returns></returns>
        public HIS.Model.SS_ARRANGE getArrange(int applyid)
        {
            string strWhere = Tables.ss_arrange.APPLY_ID + oleDb.EuqalTo() + applyid;
            return BindEntity<HIS.Model.SS_ARRANGE>.CreateInstanceDAL(oleDb).GetModel(strWhere);
        }
        #endregion

        #region 术后补录
        /// <summary>
        /// 术后补录
        /// </summary>
        /// <param name="apply"></param>
        /// <param name="arrange"></param>
        /// <returns></returns>
        public bool AfterSsInfo(HIS.Model.SS_APPLY apply,HIS.Model.SS_ARRANGE arrange)
        {
            try
            {
                oleDb.BeginTransaction();
                BindEntity<HIS.Model.SS_APPLY>.CreateInstanceDAL(oleDb).Update(apply);
                BindEntity<HIS.Model.SS_ARRANGE>.CreateInstanceDAL(oleDb).Update(arrange);
                string strWhere = Tables.ss_roombed.NAME + oleDb.EuqalTo() + "'"+arrange.OPERA_ROOMBED+"'" + oleDb.And() +
                    Tables.ss_roombed.USE_FLAG + oleDb.EuqalTo() + 1;
                string strSet = Tables.ss_roombed.USE_FLAG + oleDb.EuqalTo() + 0;
                BindEntity<HIS.Model.SS_ROOMBED>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
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

        #region 取消安排
        /// <summary>
        /// 取消安排
        /// </summary>
        /// <param name="apply"></param>
        /// <returns></returns>
        public bool CancelArrange(HIS.Model.SS_APPLY apply)
        {
            try
            {
                oleDb.BeginTransaction();
                //手术申请表安排标记 
                string strWhere = Tables.ss_apply.APPLY_ID + oleDb.EuqalTo() + apply.APPLY_ID + oleDb.And() + Tables.ss_apply.ARRANGE_FLAG + oleDb.EuqalTo() + 1;
                string strSet = Tables.ss_apply.ARRANGE_FLAG + oleDb.EuqalTo() + 0;
                BindEntity<HIS.Model.SS_APPLY>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                // 台次表占用标记
                HIS.Model.SS_ARRANGE arrange = BindEntity<HIS.Model.SS_ARRANGE>.CreateInstanceDAL(oleDb).GetModel(Tables.ss_apply.APPLY_ID + oleDb.EuqalTo() + apply.APPLY_ID);
                string strWherebed = Tables.ss_roombed.NAME + oleDb.EuqalTo() +"'"+ arrange.OPERA_ROOMBED+"'" + oleDb.And() + Tables.ss_roombed.USE_FLAG + oleDb.EuqalTo() + 1;
                string strSetbed = Tables.ss_roombed.USE_FLAG + oleDb.EuqalTo() + 0;
                BindEntity<HIS.Model.SS_ROOMBED>.CreateInstanceDAL(oleDb).Update(strWherebed, strSetbed);
                //手术安排表置删除标志
                string strWhereArrange = Tables.ss_arrange.APPLY_ID + oleDb.EuqalTo() + apply.APPLY_ID + oleDb.And()+ Tables.ss_arrange.DELETE_FLAG + oleDb.EuqalTo() + 0;
                string strSetArrange = Tables.ss_arrange.DELETE_FLAG + oleDb.EuqalTo() + 1;
                BindEntity<HIS.Model.SS_ARRANGE>.CreateInstanceDAL(oleDb).Update(strWhereArrange, strSetArrange);
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

        public HIS.Model.SS_ARRANGE GetNotFinishApply(int applyid)
        {
            string strWhere = Tables.ss_arrange.APPLY_ID + oleDb.EuqalTo() + applyid + oleDb.And() + Tables.ss_arrange.DELETE_FLAG + oleDb.EuqalTo() + 0
                + oleDb.And() + Tables.ss_arrange.FINISH_FLAG + oleDb.EuqalTo() + 0;
            return BindEntity<HIS.Model.SS_ARRANGE>.CreateInstanceDAL(oleDb).GetModel(strWhere);
        }
    }
}
