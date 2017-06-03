using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.BussinessLogicLayer;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.Model;

namespace HIS.Report_BLL
{
    public class reportPermissionBLL:HIS.SYSTEM.Core.BaseBLL
    {
        /// <summary>
        /// 获取用户组信息
        /// </summary>
        /// <param name="whereSql"></param>
        /// <returns></returns>
        public DataTable GetGroupList(string whereSql)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select *from base_group a inner join his_workers b on a.workid=b.workid ");
            return oleDb.GetDataTable(sb.ToString());
        }
        /// <summary>
        /// 获取医院信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetHospitals()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select distinct(workname),a.workid ");
            sb.Append("from base_group a inner join his_workers b on a.workid=b.workid ");
            return oleDb.GetDataTable(sb.ToString());
        }
        /// <summary>
        /// 获取报表模板
        /// </summary>
        /// <returns></returns>
        public DataTable GetReports()
        {
            return BindEntity<BASE_REPORT>.CreateInstanceDAL(oleDb).GetList("");
        }

        public DataTable GetReportGroup()
        {
            return BindEntity<HIS.Model.BASE_GROUP_REPORT>.CreateInstanceDAL(oleDb).GetList("");
        }
        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetReportsRelation()
        {
            try
            {
                StringBuilder sb=new StringBuilder();
                sb.Append(" select a.id,b.workname,a.report_id,a.group_id,a.his_workid ,c.name as cnm ,d.name as dnm,case coalesce(a.isglobal,0) when 0 then '否' when 1 then '是' end as isglobal");
                sb.Append(" from base_group_report a inner join his_workers b on a.his_workid=b.workid  ");
                sb.Append(" inner join base_group c on a.group_id=c.group_id inner join base_report d");
                sb.Append(" on a.report_id=d.report_id ");
                sb.Append(" order by b.workname,c.name,d.name");
                return oleDb.GetDataTable(sb.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="relations"></param>
        public void AllocRight(List<RightRelation> relations,int groupid)
        {
            try
            {                
                oleDb.BeginTransaction();
                BASE_GROUP_REPORT bgr;
                BindEntity<BASE_GROUP_REPORT>.CreateInstanceDAL(oleDb).Delete(" group_id=" + groupid + "");                   
                foreach (RightRelation rr in relations)
                {
                    bgr = new BASE_GROUP_REPORT();
                    bgr.GROUP_ID = int.Parse(rr.groupid);
                    bgr.REPORT_ID = int.Parse(rr.reportid);
                   // bgr.HIS_WORKID = int.Parse(rr.hisworkid);
                   // bgr.IsGloabal = rr.isGlobal;
                    //if (BindEntity<BASE_GROUP_REPORT>.CreateInstanceDAL(oleDb).Exists(" group_id="+bgr.GROUP_ID+" and report_id="+bgr.REPORT_ID+""))
                    //    continue;              
                  // BindEntity<HIS.Model.BASE_GROUP_REPORT>.CreateInstanceDAL(oleDb).Add(bgr);
                    string str = "insert into base_group_report(group_id,report_id,his_workid) values(" + bgr.GROUP_ID + "," + bgr.REPORT_ID + "," +Convert.ToInt32( HIS.SYSTEM.Core.EntityConfig.WorkID) + ")";
                    oleDb.DoCommand(str);
                }
                oleDb.CommitTransaction();
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                throw e;
            }
            finally
            {
                GC.Collect();
            }
        }
        public void DelRight(string id)
        {
            try
            {
                oleDb.BeginTransaction();
                BindEntity<BASE_GROUP_REPORT>.CreateInstanceDAL(oleDb).Delete(int.Parse(id.Trim()));
                oleDb.CommitTransaction();
            }
            catch
            {
                oleDb.RollbackTransaction();
                throw new Exception("权限删除失败！");
            }
        }
    }
    public class RightRelation
    {
        public string groupid;
        public string reportid;
        public string hisworkid;
        public int isGlobal;
    }
}
