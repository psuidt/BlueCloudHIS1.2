/* 静态模型 */
using System;
using System.Data;
using HIS;
using HIS.SYSTEM.Core;
using HIS.BLL;
namespace HIS.Base_BLL
{
	/// <summary>
	/// 员工类
	/// </summary>
	public class Employee : BaseBLL
	{

		private int _employeeID;
		private string _name;
		private int _sex;
		private string _dgCode;
		private string _pyCode;
		private string _wbCode;
        private int notUse;

        public string UserCode;

        public string DocCode;
        public int CFQ;
        public int DMQ;
        public int MZQ;

        public int[] DeptIds;
        public int[] GroupIds;

        public int Role;
        public string doctor_typeId;

		#region 属性
		/// <summary>
		/// 员工编码
		/// </summary>
		public int EmployeeID
		{
			get
			{
				return _employeeID;
			}
			set
			{
				_employeeID=value;
			}
		}
		/// <summary>
		/// 员工姓名
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public int Sex
		{
			get
			{
				return _sex;
			}
			set
			{
				_sex=value;
			}
		}
		/// <summary>
		/// 数字代码
		/// </summary>
		public string DG_Code
		{
			get
			{
				return _dgCode;
			}
			set 
			{
				_dgCode=value;
			}
		}
		/// <summary>
		/// 拼音代码
		/// </summary>
		public string PY_Code
		{
			get
			{
				return _pyCode;
			}
			set 
			{
				_pyCode=value;
			}
		}
		/// <summary>
		///  五笔代码
		/// </summary>
		public string WB_Code
		{
			get
			{
				return _wbCode;
			}
			set 
			{
				_wbCode=value;
			}
		}
        public int NotUse
        {
            get
            {
                return notUse;
            }
            set
            {
                notUse = value;
            }
        }
		#endregion 

		/// <summary>
		/// 员工构造函数
		/// </summary>
		public Employee()
		{
            _employeeID = 0;
			_name="";
			_sex=-1;
			_dgCode="";
			_pyCode="";
			_wbCode="";
		}
		/// <summary>
		/// 根据职工ID实例化员工类
		/// </summary>
		/// <param name="employeeID">员工ID</param>
		public Employee(int employeeID)  
		{
			InitEmployee(employeeID);
		}
		/// <summary>
		/// 根据员工ID初始化员工对象
		/// </summary>
		/// <param name="employeeID">员工ID</param>
		protected void InitEmployee(int employeeID)
		{
            try
            {
                Model.BASE_EMPLOYEE_PROPERTY mdl_employee;
                Model.BASE_USER mdl_user;
                Model.BASE_ROLE_DOCTOR mdl_doctor;
                Model.BASE_ROLE_NURSE mdl_nurse;

                mdl_employee = BindEntity<Model.BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL( oleDb ).GetModel( employeeID );
                mdl_user = BindEntity<Model.BASE_USER>.CreateInstanceDAL( oleDb ).GetModel( Tables.base_user.EMPLOYEE_ID + oleDb.EuqalTo() + employeeID.ToString() );
                mdl_doctor = BindEntity<Model.BASE_ROLE_DOCTOR>.CreateInstanceDAL( oleDb ).GetModel( Tables.base_role_doctor.EMPLOYEE_ID + oleDb.EuqalTo() + employeeID.ToString( ) );
                mdl_nurse = BindEntity<Model.BASE_ROLE_NURSE>.CreateInstanceDAL( oleDb ).GetModel( Tables.base_role_nurse.EMPLOYEE_ID + oleDb.EuqalTo() + employeeID.ToString( ) );

                if ( mdl_employee != null )
                {
                    _name = mdl_employee.NAME;
                    _employeeID = mdl_employee.EMPLOYEE_ID;
                    _sex = 0;
                    _dgCode = mdl_employee.D_CODE;
                    _pyCode = mdl_employee.PY_CODE;
                    _wbCode = mdl_employee.WB_CODE;
                    notUse = mdl_employee.DELETE_BIT;
                    if ( mdl_user !=null )
                        UserCode = mdl_user.CODE;
                    if ( mdl_doctor != null )
                    {
                        DocCode = mdl_doctor.YS_CODE;
                        CFQ = mdl_doctor.CF_RIGHT;
                        MZQ = mdl_doctor.MZ_RIGHT;
                        DMQ = mdl_doctor.DM_RIGHT;
                        doctor_typeId = mdl_doctor.YS_TYPEID;
                    }

                    if ( mdl_doctor==null && mdl_nurse==null )
                        Role = 0;
                    else if ( mdl_doctor!=null && mdl_nurse==null )
                        Role = 1;
                    else
                        Role = 2;
                }
            }
            catch ( Exception err )
            {
                throw new Exception( "Employee\\" + err.Message );
            }
            
		}
        /// <summary>
        /// 新增人员
        /// </summary>   
        /// <returns></returns>
        public bool Add()
        {            
            
            HIS.Model.BASE_EMPLOYEE_PROPERTY mdl_emp = new HIS.Model.BASE_EMPLOYEE_PROPERTY( );
            HIS.Model.BASE_ROLE_DOCTOR mdl_doc = new HIS.Model.BASE_ROLE_DOCTOR( );
            HIS.Model.BASE_ROLE_NURSE mdl_nurse = new HIS.Model.BASE_ROLE_NURSE( );
            HIS.Model.BASE_USER mdl_user = new HIS.Model.BASE_USER( );
            HIS.Model.BASE_GROUP_USER mdl_group_user = new HIS.Model.BASE_GROUP_USER( );
            HIS.Model.BASE_EMP_DEPT_ROLE mdl_emp_dept = new HIS.Model.BASE_EMP_DEPT_ROLE( );

            mdl_emp.D_CODE = _dgCode;
            mdl_emp.NAME = _name;
            mdl_emp.PY_CODE = _pyCode;
            mdl_emp.SEX = _sex;
            mdl_emp.WB_CODE = _wbCode;
            mdl_emp.DELETE_BIT = notUse;

            oleDb.BeginTransaction( );
            try
            {
                BindEntity<Model.BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL(oleDb).Add( mdl_emp );
                _employeeID = Convert.ToInt32(mdl_emp.EMPLOYEE_ID);
                if ( _employeeID == 0 )
                    throw new Exception( "保存人员基本信息异常！" );
                if ( Role == 1 )
                {
                    string strWhere = BLL.Tables.base_role_doctor.YS_CODE + oleDb.EuqalTo() + "'"+DocCode+"'" ;
                    if ( BindEntity<Model.BASE_ROLE_DOCTOR>.CreateInstanceDAL(oleDb).GetModel(strWhere ) == null )
                    {
                        mdl_doc.CF_RIGHT = CFQ;
                        mdl_doc.DM_RIGHT = DMQ;
                        mdl_doc.EMPLOYEE_ID = _employeeID;
                        mdl_doc.MZ_RIGHT = MZQ;
                        mdl_doc.YS_CODE = DocCode;
                        mdl_doc.YS_TYPEID = doctor_typeId;
                        BindEntity<Model.BASE_ROLE_DOCTOR>.CreateInstanceDAL( oleDb ).Add( mdl_doc );
                    }
                    else
                        throw new Exception( "医生代码已经在使用中" );
                }
                if ( Role == 2 )
                {
                    mdl_nurse.EMPLOYEE_ID = _employeeID;
                    BindEntity<Model.BASE_ROLE_NURSE>.CreateInstanceDAL( oleDb ).Add( mdl_nurse );
                }
                //科室
                for ( int i = 0 ; i < DeptIds.Length ; i++ )
                {
                    mdl_emp_dept = new HIS.Model.BASE_EMP_DEPT_ROLE( );
                    mdl_emp_dept.DEPT_ID = DeptIds[i];
                    mdl_emp_dept.EMPLOYEE_ID = _employeeID;
                    BindEntity<Model.BASE_EMP_DEPT_ROLE>.CreateInstanceDAL( oleDb ).Add( mdl_emp_dept );
                }
                //用户和组
                if ( UserCode.Trim( ) != "" )
                {
                    mdl_user.EMPLOYEE_ID = _employeeID;
                    mdl_user.CODE = UserCode;
                    mdl_user.PASSWORD = "1";

                    mdl_user = null;
                    mdl_user = BindEntity<Model.BASE_USER>.CreateInstanceDAL( oleDb ).GetModel( oleDb.UCASE( Tables.base_user.CODE) + oleDb.EuqalTo( ) + "'" + UserCode.ToUpper() + "'" );
                    if ( mdl_user != null )
                        throw new Exception( "用户名" + UserCode + "已经在使用中！" );
                    else
                        mdl_user = new HIS.Model.BASE_USER( );

                    mdl_user.PASSWORD = "1";
                    mdl_user.EMPLOYEE_ID = _employeeID;
                    mdl_user.CODE = UserCode;
                    BindEntity<Model.BASE_USER>.CreateInstanceDAL( oleDb ).Add( mdl_user );

                    for ( int i = 0 ; i < GroupIds.Length ; i++ )
                    {
                        mdl_group_user = new HIS.Model.BASE_GROUP_USER( );
                        mdl_group_user.GROUP_ID = GroupIds[i];
                        mdl_group_user.USER_ID = mdl_user.USER_ID;

                        BindEntity<Model.BASE_GROUP_USER>.CreateInstanceDAL( oleDb ).Add( mdl_group_user );
                    }
                }
                oleDb.CommitTransaction( );
                return true;
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction( );
                throw err;
                 
            }
            

        }
        /// <summary>
        /// 更新基本信息
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            HIS.Model.BASE_EMPLOYEE_PROPERTY mdl_emp = BindEntity<Model.BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL(oleDb).GetModel( _employeeID );
            if ( mdl_emp == null )
                throw new Exception("获取人员基本信息对象失败");
            HIS.Model.BASE_ROLE_DOCTOR mdl_doc = new HIS.Model.BASE_ROLE_DOCTOR( );
            HIS.Model.BASE_ROLE_NURSE mdl_nurse = new HIS.Model.BASE_ROLE_NURSE( );
            HIS.Model.BASE_USER mdl_user = new HIS.Model.BASE_USER( );
            HIS.Model.BASE_GROUP_USER mdl_group_user = new HIS.Model.BASE_GROUP_USER( );
            HIS.Model.BASE_EMP_DEPT_ROLE mdl_emp_dept = new HIS.Model.BASE_EMP_DEPT_ROLE( );

            mdl_emp.D_CODE = _dgCode;
            mdl_emp.NAME = _name;
            mdl_emp.PY_CODE = _pyCode;
            mdl_emp.SEX = _sex;
            mdl_emp.WB_CODE = _wbCode;
            mdl_emp.DELETE_BIT = notUse;

            oleDb.BeginTransaction( );
            try
            {
                BindEntity<Model.BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL( oleDb ).Update( mdl_emp );

                BindEntity<Model.BASE_ROLE_DOCTOR>.CreateInstanceDAL( oleDb ).Delete( Tables.base_role_doctor.EMPLOYEE_ID + oleDb.EuqalTo() + _employeeID );
                if ( Role == 1 )
                {
                    if ( DocCode.Trim() != "" )
                    {
                        if ( BindEntity<Model.BASE_ROLE_DOCTOR>.CreateInstanceDAL( oleDb ).GetModel( Tables.base_role_doctor.YS_CODE + oleDb.EuqalTo() + "'" + DocCode + "'" + oleDb.And() + Tables.base_role_doctor.EMPLOYEE_ID + oleDb.NotEqualTo() + _employeeID ) != null )
                            throw new Exception( "医生代码已经在使用中" );
                    }
                        
                    mdl_doc.CF_RIGHT = CFQ;
                    mdl_doc.DM_RIGHT = DMQ;
                    mdl_doc.EMPLOYEE_ID = _employeeID;
                    mdl_doc.MZ_RIGHT = MZQ;
                    mdl_doc.YS_CODE = DocCode;
                    mdl_doc.YS_TYPEID = doctor_typeId;
                    BindEntity<Model.BASE_ROLE_DOCTOR>.CreateInstanceDAL( oleDb ).Add( mdl_doc );
                }
                BindEntity<Model.BASE_ROLE_NURSE>.CreateInstanceDAL( oleDb ).Delete( Tables.base_role_nurse.EMPLOYEE_ID+ oleDb.EuqalTo() + _employeeID );
                if ( Role == 2 )
                {
                    mdl_nurse.EMPLOYEE_ID = _employeeID;
                    BindEntity<Model.BASE_ROLE_NURSE>.CreateInstanceDAL( oleDb ).Add( mdl_nurse );
                }
                //科室
                BindEntity<Model.BASE_EMP_DEPT_ROLE>.CreateInstanceDAL( oleDb ).Delete( Tables.base_emp_dept_role.EMPLOYEE_ID + oleDb.EuqalTo() + _employeeID );
                for ( int i = 0 ; i < DeptIds.Length ; i++ )
                {
                    mdl_emp_dept = new HIS.Model.BASE_EMP_DEPT_ROLE( );
                    mdl_emp_dept.DEPT_ID = DeptIds[i];
                    mdl_emp_dept.EMPLOYEE_ID = _employeeID;
                    BindEntity<Model.BASE_EMP_DEPT_ROLE>.CreateInstanceDAL( oleDb ).Add( mdl_emp_dept );
                }
                //用户和组
                if ( UserCode.Trim( ) != "" )
                {
                    if ( BindEntity<Model.BASE_USER>.CreateInstanceDAL( oleDb ).GetModel( Tables.base_user.CODE + oleDb.EuqalTo()+ "'" + UserCode + "'" + oleDb.And() + Tables.base_user.EMPLOYEE_ID + oleDb.NotEqualTo() + _employeeID ) == null )
                    {
                        mdl_user = BindEntity<Model.BASE_USER>.CreateInstanceDAL( oleDb ).GetModel( Tables.base_user.EMPLOYEE_ID + oleDb.EuqalTo() + _employeeID );
                        if ( mdl_user == null )
                        {
                            mdl_user = new HIS.Model.BASE_USER( );
                            mdl_user.PASSWORD = "1";
                            mdl_user.EMPLOYEE_ID = _employeeID;
                            mdl_user.CODE = UserCode;
                            mdl_user.USER_ID = BindEntity<Model.BASE_USER>.CreateInstanceDAL( oleDb ).Add( mdl_user );
                        }
                        else
                        {
                            mdl_user.CODE = UserCode;
                            BindEntity<Model.BASE_USER>.CreateInstanceDAL( oleDb ).Update( mdl_user );
                        }

                        BindEntity<Model.BASE_GROUP_USER>.CreateInstanceDAL( oleDb ).Delete( Tables.base_group_user.USER_ID + oleDb.EuqalTo() + mdl_user.USER_ID );
                        for ( int i = 0 ; i < GroupIds.Length ; i++ )
                        {
                            mdl_group_user = new HIS.Model.BASE_GROUP_USER( );
                            mdl_group_user.GROUP_ID = GroupIds[i];
                            mdl_group_user.USER_ID = mdl_user.USER_ID;

                            BindEntity<Model.BASE_GROUP_USER>.CreateInstanceDAL( oleDb ).Add( mdl_group_user );
                        }
                    }
                    else
                        throw new Exception( "用户名存在" );
                }
                else
                {
                    //mdl_user = BindEntity<Model.BASE_USER>.CreateInstanceDAL( oleDb ).GetModel( Tables.base_user.EMPLOYEE_ID + oleDb.EuqalTo() + _employeeID );
                    //if ( mdl_user != null )
                    //{
                    //    BindEntity<Model.BASE_USER>.CreateInstanceDAL( oleDb ).Delete( Tables.base_user.USER_ID + oleDb.EuqalTo( ) + mdl_user.USER_ID );
                    //    BindEntity<Model.BASE_GROUP_USER>.CreateInstanceDAL( oleDb ).Delete( Tables.base_group_user.USER_ID + oleDb.EuqalTo( ) + mdl_user.USER_ID );
                    //}
                }
                oleDb.CommitTransaction( );
                return true;
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction( );
                throw err;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        public static bool NameExists( Employee Employee )
        {
            Model.BASE_EMPLOYEE_PROPERTY model = null;
            if ( Employee.EmployeeID > 0 )
            {
                model = BindEntity<Model.BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL( oleDb ).GetModel( Tables.base_employee_property.NAME + oleDb.EuqalTo( ) + "'" + Employee.Name + "'" + oleDb.And() + Tables.base_employee_property.EMPLOYEE_ID + oleDb.NotEqualTo() + Employee.EmployeeID);
            }
            else
            {
                model = BindEntity<Model.BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL( oleDb ).GetModel( Tables.base_employee_property.NAME + oleDb.EuqalTo( ) + "'" + Employee.Name + "'" );
            }

            return model == null ? false : true;
        }
        /// <summary>
        /// 获得所遇人员
        /// </summary>
        /// <returns></returns>
        public static Employee[] GetEmployeies( string strWhere )
        {


            System.Collections.Generic.List<Model.BASE_EMPLOYEE_PROPERTY> list = BindEntity<Model.BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL( oleDb ).GetListArray(  strWhere);

            Employee[] employeies = new Employee[list.Count];
            for ( int i = 0 ; i < list.Count ; i++ )
                employeies[i] = new Employee( list[i].EMPLOYEE_ID );


            return employeies;
        }
        /// <summary>
        /// 得到该人员的科室
        /// </summary>
        /// <returns></returns>
        public Department[] GetDepartment()
        {
            System.Collections.Generic.List<Model.BASE_EMP_DEPT_ROLE> list = BindEntity<Model.BASE_EMP_DEPT_ROLE>.CreateInstanceDAL( oleDb ).GetListArray( Tables.base_emp_dept_role.EMPLOYEE_ID + oleDb.EuqalTo() + _employeeID );
            Department[] depts = new Department[list.Count];
            for ( int i = 0 ; i < list.Count ; i++ )
                depts[i] = new Department( list[i].DEPT_ID );
            return depts;
        }
        /// <summary>
        /// 获得该人员的所属用户组
        /// </summary>
        /// <returns></returns>
        public DataTable GetGroups()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL( );
            base_dal.OleDB = oleDb;
            return base_dal.get_Employee_GetGroups( _employeeID );
        }
    } 
}
