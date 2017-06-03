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
   partial  class GetInBed : BaseBLL
    {
        #region 得到分床的病人列表
        /// <summary>
        /// 得到分床的病人列表
        /// </summary>
        /// <param name="sign">0=管辖内病人1=全科室病人</param>
        /// <param name="docid"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public  List<HIS.Model.ZY_PatList> GetInBedPatList(int sign, int docid, int deptid)
        { // 20100628.2.06 诊疗管理病人信息加载查询优化。
            string strWhere = Tables.zy_nurse_bed.PATLIST_ID + oleDb.NotEqualTo() + 0;
            if (sign == 0) //管辖内病人  
            {
                strWhere += oleDb.And() + Tables.zy_nurse_bed.ZY_DOC + oleDb.EuqalTo() + docid +
                    oleDb.And() + Tables.zy_nurse_bed.DEPT_ID + oleDb.EuqalTo() + deptid;
            }
            if (sign == 1) // 全科室病人
            {
                strWhere += oleDb.And() + Tables.zy_nurse_bed.DEPT_ID + oleDb.EuqalTo() + deptid;
            }
            string str = "patlistid in ( select patlist_id from { zy_nurse_bed } where +" + strWhere + ")  order by CAST(replace(BEDCODE,'加','100') as INTEGER)";
            return BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetListArray(str);
        }
        #endregion

        #region 获得病人的主治医生，经治医生，护士
        /// <summary>
        /// 获得病人的主治医生，经治医生，护士
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public  string[] GetDoc(int patlistid)
        {
            string strsql = Tables.zy_nurse_bed.PATLIST_ID + oleDb.EuqalTo() + patlistid;
            DataTable dt = BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).GetList(strsql);
            strsql = Tables.zy_patlist.PATLISTID + oleDb.EuqalTo() + patlistid;
            object obj = BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_patlist.CUREDOCCODE, strsql);
            string[] doc = new string[3];
            if (dt != null && dt.Rows.Count != 0)
            {
                doc[0] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(dt.Rows[0]["zz_doc"].ToString());//主治医生               
                doc[2] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(dt.Rows[0]["charge_nurse"].ToString());//护士
            }
            doc[1] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(obj.ToString());//经治医生
            return doc;
        }
        #endregion

        #region 通过住院号查询在床病人
        /// <summary>
       /// 通过住院号查询在床病人
       /// </summary>
       /// <param name="cureno"></param>
       /// <returns></returns>
        public List<HIS.Model.ZY_PatList> GetPlistByNo(string cureno)
        {
            string strWhere = Tables.zy_nurse_bed.PATLIST_ID + oleDb.NotEqualTo() + 0 + oleDb.OrderBy() + oleDb.DBConvert("replace(" + Tables.zy_nurse_bed.BED_NO + ",'加','100')", "INTEGER"); ;
            string str = " cureno='" + cureno + "' and patlistid in ( select patlist_id from  zy_nurse_bed  where +" + strWhere + ")  ";
            return BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetListArray(str);
        }
        #endregion

    }
}
