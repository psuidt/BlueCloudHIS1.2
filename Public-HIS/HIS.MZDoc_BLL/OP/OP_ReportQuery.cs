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
    /// 统计查询操作类
    /// </summary>
    public class OP_ReportQuery : BaseBLL
    {
        /// <summary>
        /// 查询医生工作量
        /// </summary>
        /// <param name="employeeId">员工ID</param>
        /// <param name="beginDate">统计开始时间</param>
        /// <param name="endDate">统计结束时间</param>
        /// <returns></returns>
        public static DataTable QueryDocWorkData(int employeeId, DateTime beginDate, DateTime endDate)
        {
            //DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(oleDb);
            return new HIS.DAL.MZDoc_DAL(oleDb).Query_DocWork(employeeId, beginDate, endDate);
        }

        /// <summary>
        /// 查询病区床位情况
        /// </summary>
        /// <returns>病区床位情况数据表</returns>
        public static DataTable QueryZyDeptBed()
        {
            //DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(oleDb);
            return new HIS.DAL.MZDoc_DAL(oleDb).Query_ZyDeptBed();
        }

        /// <summary>
        /// 获得与病人姓名一致的其他入院信息
        /// </summary>
        /// <param name="patName">病人姓名</param>
        /// <returns>数据表</returns>
        public static DataTable GetFormerlyInpatInfo(string patName)
        {
            return BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).GetList(
                Tables.patientinfo.PATNAME + oleDb.Like() + "'%" + patName + "%'" + oleDb.And() + Tables.patientinfo.CURENUM + oleDb.GreaterThan() + "0");
        }
    }
}
