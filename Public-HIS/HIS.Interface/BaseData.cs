using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;

namespace HIS.Interface
{
    public class BaseData : BaseBLL
    {
        private static DataTable employeies;
        private static DataTable depts;

        public static DataTable Depts
        {
            get
            {
                if ( depts == null )
                {
                    depts = BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).GetList("","dept_id","name" );
                }
                return depts;
            }
        }
        public static DataTable Employeies
        {
            get
            {
                if ( employeies == null )
                {
                    employeies = BindEntity<Model.BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL( oleDb ).GetList( "" , "employee_id" , "name" );
                }
                return employeies;
            }
        }

        public static string GetEmployeeNameById( string EmployeeId )
        {
            if ( EmployeeId.Trim( ) == "" )
                return "";
            DataRow[] drs = Employeies.Select( "EMPLOYEE_ID=" + EmployeeId );
            if ( drs.Length == 0 )
                return "";
            else
                return drs[0]["NAME"].ToString( );
        }
        public static string GetDeptNameById( string DeptId )
        {
            if ( DeptId.Trim( ) == "" )
                return "";

            DataRow[] drs = Depts.Select( "DEPT_ID=" + DeptId );
            if ( drs.Length == 0 )
                return "";
            else
                return drs[0]["NAME"].ToString( );
        }
    }
}
