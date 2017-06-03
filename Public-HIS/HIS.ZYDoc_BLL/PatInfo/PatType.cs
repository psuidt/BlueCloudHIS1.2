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

namespace HIS.ZYDoc_BLL.PatInfo
{
   partial  class PatType : BaseBLL
    {
        #region 出院和死亡医嘱时修改病人状态
        /// <summary>
        /// 出院和死亡医嘱时修改病人状态
        /// </summary>
        /// <param name="patlist"></param>
        public   void OutDeath(HIS.Model.ZY_PatList patlist)
        {
            try  //20100518.0.02  出院医嘱时，病人出院日期没写到数据库里边去
            {
                if (BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue("pattype", Tables.zy_patlist.PATLISTID + oleDb.EuqalTo() + patlist.PatListID).ToString() == "2")
                {
                    patlist.PatType = "7";
                    BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).Update(patlist);
                }
            }
            catch (System.Exception e)
            {               
                throw new Exception(e.Message);
            }         
        }
        #endregion

        #region 取消出院和死亡时修改病人
        /// <summary>
        /// 取消出院和死亡时修改病人
        /// </summary>
        /// <param name="patlistid"></param>
        public  void CancelOutDeath(int patlistid)
        {
            string strWhere = Tables.zy_patlist.PATLISTID + oleDb.EuqalTo() + patlistid + oleDb.And()
                               + Tables.zy_patlist.PATTYPE + oleDb.EuqalTo() + "'7'";
            string[] strSet = new string[5];
            strSet[0] = Tables.zy_patlist.PATTYPE + oleDb.EuqalTo() + "'2'";
            strSet[1] = Tables.zy_patlist.OUT_FLAG + oleDb.EuqalTo() + 0;
            strSet[2] = Tables.zy_patlist.OUTDIAGNCODE + oleDb.EuqalTo() + "''";
            strSet[3] = Tables.zy_patlist.OUTDIAGNNAME + oleDb.EuqalTo() + "''";
            strSet[4] = Tables.zy_patlist.OUTDATE + oleDb.EuqalTo() + "'0001-01-01'";
            BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
        }
        #endregion

        #region  判断病人是否存在转科记录
        /// <summary>
        /// 判断病人是否存在转科记录
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public  bool IsTurnDept(int patlistid)
        {
            string strWhere = Tables.zy_doc_transdept.PATID + oleDb.EuqalTo() + patlistid + oleDb.And()
                + Tables.zy_doc_transdept.CANCEL_FLAG + oleDb.EuqalTo() + 0 + oleDb.And()
                + Tables.zy_doc_transdept.FINISH_FLAG + oleDb.EuqalTo() + 0;
            if (BindEntity<HIS.Model.ZY_DOC_TRANSDEPT>.CreateInstanceDAL(oleDb).Exists(strWhere))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 通过patlistid获得patlist实体对象
        /// <summary>
        ///　通过patlistid获得patlist实体对象
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public  HIS.Model.ZY_PatList GetNewPatModel(int patlistid)
        {
            return BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetModel((patlistid));
        }
        #endregion

        #region 判断是否可以修改医嘱
        /// <summary>
        /// 判断是否可以修改医嘱
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public  bool NotCanUpdate(HIS.Model.ZY_PatList zy_Patlist)
        {
            if (zy_Patlist.PatType.ToString() == "3" || zy_Patlist.PatType.ToString() == "4" || zy_Patlist.PatType.ToString() == "5"
                || zy_Patlist.PatType.ToString() == "7" || HIS.ZYDoc_BLL.PatInfo.PatOperation.IsTurnDept(zy_Patlist.PatListID))
            {
                return true;
            }
            return false;
        }
        #endregion

      // 20100512.1.03  病人出院时判断病人是否存在未完成的手术
        #region  是否存在已申请未完成的手术
        /// <summary>
       /// 是否存在已申请未完成的手术
       /// </summary>
       /// <param name="zy_Patlist"></param>
       /// <returns></returns>
        public bool NotFinishSs(HIS.Model.ZY_PatList zy_Patlist)
        {
            string strWhere = Tables.ss_apply.PATLISTID + oleDb.EuqalTo() + zy_Patlist.PatListID + oleDb.And() + Tables.ss_apply.DELETE_FLAG + oleDb.EuqalTo() + 0
                + oleDb.And() + (" apply_id not in( select apply_id from ss_arrange where finish_flag=1)");
            return BindEntity<HIS.Model.SS_APPLY>.CreateInstanceDAL(oleDb).Exists(strWhere);
        }
        #endregion

        #region 判断是否可以出院
        /// <summary>
        /// 判断是否可以出院
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public  string NotCanOut(int patlistid)
        {
            string err = "";
            string strWhere = Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid + oleDb.And()
               + Tables.zy_doc_orderrecord.BABYID + oleDb.EuqalTo() + 0 + oleDb.And()
               + "(" + "(" + Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.LessThan() + 2 + oleDb.And() + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + 0 + ")" + oleDb.Or()
               + "(" + Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.LessThan() + 1 + oleDb.And()
               + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.In("1", "5", "7") + ")" + ")" + oleDb.And()
               + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 0;
            DataTable dt = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetList(strWhere);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    err = err + dt.Rows[i]["order_content"].ToString() + "\n";
                }
            }
            return err;
        }
        #endregion

    }
}
