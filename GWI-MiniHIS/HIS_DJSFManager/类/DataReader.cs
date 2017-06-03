using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.MSAccess;

namespace HIS_DJSFManager.类
{
    /// <summary>
    /// 数据读取类
    /// </summary>
    public class DataReader 
    {
        private static DataTable patientType;
        private static DataTable tbStatItem;
        private static DataTable tbDept;
        private static DataTable tbEmp;
        private static DataTable tbUser;
        

        public static DataTable PatientType
        {
            get
            {
                if ( patientType == null )
                {
                    patientType = MSAccessDb.GetDataTable( "select * from base_patienttype" );
                }
                return patientType;
            }
        }


        public static DataTable GetTemplateDetail()
        {
            string sql = "select * from base_template_detail";
            return MSAccessDb.GetDataTable( sql );
        }

        public static DataTable StatItemList
        {
            get
            {
                if ( tbStatItem == null )
                    tbStatItem = MSAccessDb.GetDataTable( "Select * from base_stat_item" );
                return tbStatItem;
            }
        }
        
        public static DataTable Department
        {
            get
            {
                if ( tbDept == null )
                {
                    tbDept = MSAccessDb.GetDataTable( "select * from base_dept_property" );
                }
                return tbDept;
            }
        }
 
        public static DataTable Employeies
        {
            get
            {
                if ( tbEmp == null )
                    tbEmp = MSAccessDb.GetDataTable( "select * from base_Employee_property" );
                return tbEmp;
            }
        }

        public static DataTable BaseUsers
        {
            get
            {
                if ( tbUser == null )
                {
                    tbUser = MSAccessDb.GetDataTable( "select * from base_user" );
                }
                return tbUser;
            }
        }



        public static string GetEmployeeNameById( int EmployeeId )
        {
            DataRow[] drs = Employeies.Select( "employee_id=" + EmployeeId );
            if ( drs.Length > 0 )
                return drs[0]["name"].ToString( ).Trim( );
            else
                return "";
        }

        public static string GetDeptNameById( int DeptId )
        {
            DataRow[] drs = Department.Select( "dept_id=" + DeptId );
            if ( drs.Length > 0 )
                return drs[0]["name"].ToString( ).Trim( );
            else
                return "";
        }

        public static string GetPatientTypeNameByCode( string Code )
        {
            DataRow[] drs = DataReader.PatientType.Select( "CODE='" + Code + "'" );
            if ( drs.Length == 0 )
                return "";
            else
                return drs[0]["NAME"].ToString( );
        }

        public static DataTable GetShowCardItems()
        {
            string sql = "select * from vi_mz_showcard";
            return MSAccessDb.GetDataTable( sql );
        }

        public static DataTable GetDoctorList()
        {
            string sql = "select * from base_doctor";
            return MSAccessDb.GetDataTable( sql );
        }

        public static DataTable GetPatientList()
        {
            string date = DateTime.Now.AddDays( -7 ).ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "select patlistid,patname,patsex,curedate from mz_patlist where curedate>#" + date + "# and upload_flag=0 order by curedate desc";
            return MSAccessDb.GetDataTable( sql );
        }

        /// <summary>
        /// 得到工作单位列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_WorkUnitList()
        {
            return MSAccessDb.GetDataTable( "select * from base_work_unit" );
        }

        public static DataTable Get_Invoice_PerfChar()
        {
            string sql = "select distinct perfchar from mz_invoice";

            return MSAccessDb.GetDataTable( sql );
        }

        /// <summary>
        /// 发票查询
        /// </summary>
        /// <param name="dateTimeFrom">开始时间</param>
        /// <param name="dateTimeTo">结束时间</param>
        /// <param name="OperatorId">操作员(EmployeeId)</param>
        /// <returns></returns>
        public static DataTable GetChargeInvoiceList( DateTime dateTimeFrom , DateTime dateTimeTo , int OperatorId )
        {
            string userWhere = "";
            if ( OperatorId != 0 )
                userWhere = " and chargecode='" + OperatorId.ToString( ) + "'";
            string sql = @"select a.TICKETNUM as invoiceno,b.PATNAME as patientname,b.VISITNO as VISITNO,b.MEDITYPE as MEDITYPE,a.TOTAL_FEE as cost,a.TOTAL_FEE-a.POS_FEE-a.VILLAGE_FEE-a.FAVOR_FEE-a.SELF_TALLY as cash,a.POS_FEE as pos,a.VILLAGE_FEE as tally,a.FAVOR_FEE as favor,a.SELF_TALLY as self_tally,a.COSTDATE as chargedate,a.CHARGENAME as chargeuser,a.unchargedate,a.unchargecost,a.unchargeuser,a.hang_flag 
                            from  
                            (select aa.*,b.COSTDATE as unchargedate, ABS(b.TOTAL_FEE)  as unchargecost,b.chargename as unchargeuser 
                             from  (
                                     select TICKETNUM,PATLISTID,TOTAL_FEE,COSTDATE,MONEY_FEE,POS_FEE,VILLAGE_FEE,FAVOR_FEE,SELF_TALLY,CHARGENAME,HANG_FLAG 
                                     from  MZ_COSTMASTER  where   RECORD_FLAG IN(0,1) " + userWhere + @"  AND COSTDATE BETWEEN #" +dateTimeFrom.ToString("yyyy-MM-dd")+ " 00:00:00#  AND  #"+dateTimeTo.ToString("yyyy-MM-dd")+" 23:59:59# " +@"
                                   ) aa  Left Join  (select TICKETNUM,TOTAL_FEE,COSTDATE,CHARGENAME,HANG_FLAG  
                                                    from  MZ_COSTMASTER  where   RECORD_FLAG = 2 ) b  on aa.TICKETNUM = b.TICKETNUM AND aa.HANG_FLAG = b.HANG_FLAG  
                             ) a  
                             Left Join  (select PATLISTID,PATNAME,VISITNO,MEDITYPE from  MZ_PATLIST  ) b  on a.PATLISTID = b.PATLISTID ";
            return MSAccessDb.GetDataTable( sql );
        }
        /// <summary>
        /// 发票查询
        /// </summary>
        /// <param name="dateTimeFrom">开始时间</param>
        /// <param name="dateTimeTo">结束时间</param>
        /// <returns></returns>
        public static DataTable GetChargeInvoiceList( DateTime dateTimeFrom , DateTime dateTimeTo )
        {
            return GetChargeInvoiceList( dateTimeFrom , dateTimeTo , 0 );            
        }
    }
}
