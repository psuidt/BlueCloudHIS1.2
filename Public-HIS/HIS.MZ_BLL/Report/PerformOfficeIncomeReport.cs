using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;

namespace HIS.MZ_BLL.Report
{
    /// <summary>
    /// 执行科室收入报表
    /// </summary>
    public class PerformOfficeIncomeReport : BaseBLL
    {
        private DateTime beginDate;
        private DateTime endDate;
        private DataTable result;

        public PerformOfficeIncomeReport( DateTime BeginDate , DateTime EndDate )
        {
            beginDate = BeginDate;
            endDate = EndDate;
        }
        /// <summary>
        /// 报表结果
        /// </summary>
        public DataTable Result
        {
            get
            {
                return result;
            }
        }
        /// <summary>
        /// 填充报表
        /// </summary>
        public void Fill()
        {
            string sql = GetStatSQL( );
            result = oleDb.GetDataTable( sql );
        }

        private string GetStatSQL()
        {
            string sql = @"select execdeptcode,dept_name,itemname,statname,fpname,total_fee,count,sub_flag from
                            (
                                select execdeptcode,b.name as dept_name,'' as itemname,'' as statname,'' as fpname ,sum(total_fee) as total_fee  , 0 as count , 1 as sub_flag
                                from mz_presmaster a,
                                (select cast(dept_id as char(10)) as dept_id,name from base_dept_property where workid= %workid ) b
                                where a.execdeptcode = b.dept_id and record_flag <> 9 and charge_flag =1 and prestype = '-1'
                                and a.costmasterid in (select costmasterid from mz_costmaster where costdate between '%d1' and '%d2' and record_flag <> 9)
                                and a.workid= %workid 
                                group by execdeptcode,b.name
                                union all
                                select a.execdeptcode,'' as dept_name,b.itemname,rtrim(c.item_name) as statname,rtrim(d.item_name) as fpname,sum(b.tolal_fee) as total_fee , count(1) as count, 0 as sub_flag
                                from mz_presmaster a,mz_presorder b ,base_stat_item c,base_stat_mzfp d
                                where a.presmasterid = b.presmasterid 
                                and b.bigitemcode = c.code and c.mzfp_code = d.code
                                and a.record_flag<> 9 and a.charge_flag =1 
                                and b.bigitemcode not in ('00','01','02','03') 
                                and a.costmasterid in (select costmasterid from mz_costmaster where costdate between '%d1' and '%d2' and record_flag <> 9)
                                and a.workid = %workid and b.workid = %workid
                                group by a.execdeptcode,b.itemname,c.item_name,d.item_name
                            ) a 
                            order by execdeptcode,dept_name desc";
            sql = sql.Replace( "%workid" , HIS.SYSTEM.Core.EntityConfig.WorkID.ToString( ) );
            sql = sql.Replace( "%d1" , beginDate.ToString( "yyyy-MM-dd HH:mm:ss" ) );
            sql = sql.Replace( "%d2" , endDate.ToString( "yyyy-MM-dd HH:mm:ss" ) );
            return sql;
        }
    }
}
