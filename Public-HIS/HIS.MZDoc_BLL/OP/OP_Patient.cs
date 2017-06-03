using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 门诊病人操作类
    /// </summary>
    public class OP_Patient : BaseBLL
    {
        /// <summary>
        /// 根据条件查询病人列表
        /// </summary>
        /// <param name="beginTime">就诊时间段查询的开始时间</param>
        /// <param name="endTime">就诊时间段查询的结束时间</param>
        /// <returns></returns>
        public static List<HIS.Model.MZ_PatList> SearchPatList(DateTime beginTime, DateTime endTime)
        {
            DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(oleDb);
            return mzdoc_dal.Search_PatList(beginTime, endTime);
        }

        /// <summary>
        /// 根据条件查询病人列表
        /// </summary>
        /// <param name="cardNo">诊疗卡号</param>
        /// <param name="patName">病人姓名</param>
        /// <param name="beginTime">就诊时间段查询的开始时间</param>
        /// <param name="endTime">就诊时间段查询的结束时间</param>
        /// <returns></returns>
        public static List<Model.MZ_PatList> SearchPatList(string cardNo, string patName, DateTime beginTime, DateTime endTime)
        {
            string strsql = Tables.mz_patlist.MEDICARD + oleDb.Like() + "'%" + cardNo + "%'"
                + oleDb.And() + Tables.mz_patlist.PATNAME + oleDb.Like() + "'%" + patName + "%'"
                + oleDb.And() + Tables.mz_patlist.CUREDATE + oleDb.Between() + "'" + beginTime.Date + "'"
                + oleDb.And() + "'" + endTime.Date.AddDays(1) + "'"
                + oleDb.And() + HIS.BLL.Tables.mz_patlist.VISITNO + oleDb.NotEqualTo() + "''";
            return BindEntity<Model.MZ_PatList>.CreateInstanceDAL(oleDb).GetListArray(strsql);
        }

        /// <summary>
        /// 获得就诊病人列表
        /// </summary>
        /// <param name="onlyCureDoc">是否是查找单个医生的病人</param>
        /// <param name="status">病人状态</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static List<HIS.Model.MZ_PatList> SearchPatList(bool onlyCureDoc, Public.PatCureStatus status, DateTime beginTime, DateTime endTime)
        {
            string strsql = HIS.BLL.Tables.mz_patlist.CUREDATE + oleDb.Between() + "'" + beginTime.Date + "'" + oleDb.And() + "'" + endTime.Date.AddDays(1) + "'" 
                + oleDb.And() + HIS.BLL.Tables.mz_patlist.VISITNO + oleDb.NotEqualTo() + "''";
            if (onlyCureDoc)
            {
                strsql = strsql + oleDb.And() + '(' + HIS.BLL.Tables.mz_patlist.REG_DOC_CODE + oleDb.EuqalTo() + "'" + Public.StaticConfig.CureDocCode + "'"
                    + oleDb.And() + HIS.BLL.Tables.mz_patlist.CUREEMPCODE + oleDb.EuqalTo() + "''"
                    + oleDb.Or() + HIS.BLL.Tables.mz_patlist.CUREEMPCODE + oleDb.EuqalTo() + "'" + Public.StaticConfig.CureDocCode + "'" + ')';
            }
            if (status == Public.PatCureStatus.结束状态)
            {
                strsql = strsql + oleDb.And() + Tables.mz_patlist.CURESTATUS + oleDb.EuqalTo() + Public.PatCureStatus.结束状态.GetHashCode();
            }
            else
            {
                strsql = strsql + oleDb.And() + Tables.mz_patlist.CURESTATUS + oleDb.NotEqualTo() + Public.PatCureStatus.结束状态.GetHashCode();
            }
            return BindEntity<HIS.Model.MZ_PatList>.CreateInstanceDAL(oleDb).GetListArray(strsql);
        }

        /// <summary>
        /// 根据条件查询病人列表
        /// </summary>
        /// <param name="patientSearchInfo">门诊查询信息</param>
        /// <returns></returns>
        public static DataTable SearchPatList(Public.PatientSearchInfo patientSearchInfo)
        {
            DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(oleDb);
            return mzdoc_dal.Search_PatList(patientSearchInfo);
        }
    }
}
