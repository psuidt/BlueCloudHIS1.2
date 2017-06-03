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
  partial  class GetOutPat : BaseBLL
    {
        #region 根据条件查询出院病人列表
      /// <summary>
        /// 根据条件查询出院病人列表
      /// </summary>
      /// <param name="CureDeptCode"></param>
      /// <param name="Bdate"></param>
      /// <param name="Edate"></param>
      /// <returns></returns>
        public  List<HIS.Model.ZY_PatList> GetOutPatList(string CureDeptCode, DateTime? Bdate, DateTime? Edate)
        {
            try
            {
                string strWhere = " (" + Tables.zy_patlist.PATTYPE + oleDb.NotEqualTo() + "'1'" +
                      oleDb.And() + Tables.zy_patlist.PATTYPE + oleDb.NotEqualTo() + "'2'" + oleDb.And() +
                      Tables.zy_patlist.PATTYPE + oleDb.NotEqualTo() + "'7'" +
                      oleDb.And() + Tables.zy_patlist.PATTYPE + oleDb.NotEqualTo() + "'6')";

                if (Bdate != null && Edate != null)
                {
                    strWhere += oleDb.And() + oleDb.Date(Tables.zy_patlist.MARKDATE) +
                        oleDb.GreaterThanAndEqualTo() + "'" + Bdate.Value.Date + "'" + oleDb.And() +
                        oleDb.Date(Tables.zy_patlist.MARKDATE) +
                        oleDb.LessThanAndEqualTo() + "'" + Edate.Value.Date + "'";
                }
                strWhere += oleDb.OrderBy(Tables.zy_patlist.CURENO);
                return BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 根据病人姓名查询
        /// <summary>
        /// 根据病人姓名查询
        /// </summary>
        /// <param name="patname"></param>
        /// <returns></returns>
        public  List<HIS.Model.ZY_PatList> GetOutPatName(string patname)
        {
            if (patname != "")
            {
                string str = "select  patid from patientinfo where patname like '%" + patname + "%'";
                string strWhere = "patid in( " + str + ")";
                return BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            }
            return null;
        }
        #endregion

        #region 根据病人住院号查询
        /// <summary>
        /// 根据病人住院号查询
        /// </summary>
        /// <param name="cureno"></param>
        /// <returns></returns>
        public  List<HIS.Model.ZY_PatList> GetOutPatCureNo(string cureno)
        {
            if (cureno != "")
            {
                string str = "select  patid from patientinfo where cureno like '%" + cureno + "'";
                string strWhere = "patid in( " + str + ") and pattype in ('3','4','5')";
                return BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            }
            return null;
        }
        #endregion
    }
}
