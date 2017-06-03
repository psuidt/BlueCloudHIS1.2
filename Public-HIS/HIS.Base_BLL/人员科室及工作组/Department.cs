using System;
using System.Data;
using HIS.SYSTEM.Core;
using HIS;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 科室
    /// </summary>
    public class Department : BaseBLL
    {

        private int _deptID;
        private int _pDeptID;
        private string _name;
        private string _dgCode;
        private string _pyCode;
        private string _wbCode;
        private string _deptAddr;
        private int _mzFlag;
        private int _zyFlag;
        private int _jzFlag;
        private string _wardID;
        private string _wardName="";
        private int _wardDeptID;
        private int notUse;
        private string type_code="";
        private string code="";
        private int defaultFlag;
        private int _smFlag;

        #region ....
        /// <summary>
        /// 手术科室标志
        /// </summary>
        public int SmFlag
        {
            get
            {
                return _smFlag;
            }
            set
            {
                _smFlag = value;
            }
        }
        public int DefaultFlag
        {
            get
            {
                return defaultFlag;
            }
            set
            {
                defaultFlag = value;
            }
        }
        /// <summary>
        /// 国标代码
        /// </summary>
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }
        /// <summary>
        /// 科室ID
        /// </summary>
        public int DeptID
        {
            get
            {
                return _deptID;
            }
            set
            {
                _deptID = value;
            }
        }
        /// <summary>
        /// 上级科室ID
        /// </summary>
        public int P_DeptID
        {
            get
            {
                return _pDeptID;
            }
            set
            {
                _pDeptID = value;
            }
        }
        /// <summary>
        ///名称
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        /// <summary>
        /// 数字吗
        /// </summary>
        public string DG_Code
        {
            get
            {
                return _dgCode;
            }
            set
            {
                _dgCode = value;
            }
        }
        /// <summary>
        /// �拼音ƴ����
        /// </summary>
        public string PY_Code
        {
            get
            {
                return _pyCode;
            }
            set
            {
                _pyCode = value;
            }
        }
        /// <summary>
        /// 五笔
        /// </summary>
        public string WB_Code
        {
            get
            {
                return _wbCode;
            }
            set
            {
                _wbCode = value;
            }
        }
        /// <summary>
        ///科室位置
        /// </summary>
        public string DeptAddr
        {
            get
            {
                return _deptAddr;
            }
            set
            {
                _deptAddr = value;
            }
        }
        /// <summary>
        /// 门诊标志
        /// </summary>
        public int MZ_Flag
        {
            get
            {
                return _mzFlag;
            }
            set
            {
                _mzFlag = value;
            }
        }
        /// <summary>
        /// 住院标志
        /// </summary>
        public int ZY_Flag
        {
            get
            {
                return _zyFlag;
            }
            set
            {
                _zyFlag = value;
            }
        }
        /// <summary>
        /// 急诊标志
        /// </summary>
        public int JZ_Flag
        {
            get
            {
                return _jzFlag;
            }
            set
            {
                _jzFlag = value;
            }
        }
        /// <summary>
        /// 所属病区ID
        /// </summary>
        public string Ward_ID
        {
            get
            {
                return _wardID;
            }
        }
        /// <summary>
        ///病区名称
        /// </summary>
        public string Ward_Name
        {
            get
            {
                return _wardName;
            }
        }
        /// <summary>
        /// 病区科室ID
        /// </summary>
        public int WardDeptID
        {
            get
            {
                return _wardDeptID;
            }
        }
        /// <summary>
        /// 是否再用
        /// </summary>
        public int NoUse
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
        /// <summary>
        /// 类型代码
        /// </summary>
        public string Type_Code
        {
            get
            {
                return type_code;
            }
            set
            {
                type_code = value;
            }
        }
        #endregion

        public Department()
        {
        }

        /// <summary>
        ///  构造一个科室
        /// </summary>
        /// <param name="deptID">科室ID</param>
        public Department( int deptID )
        {
            GetDeptInfo( deptID );
        }
        public Department( Model.BASE_DEPT_PROPERTY model )
        {
            GetDeptInfo( model );
        }
        /// <summary>
        ///  得到科室信息
        /// </summary>
        /// <param name="deptID">科室ID</param>
        private void GetDeptInfo( int deptID )
        {

            Model.BASE_DEPT_PROPERTY model = BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_dept_property.DEPT_ID + oleDb.EuqalTo( ) + deptID );
            try
            {
                if ( model != null )
                {
                    _name = model.NAME;
                    _deptID = model.DEPT_ID;
                    _pDeptID = model.P_DEPT_ID;
                    _deptAddr = model.DEPTADDR;
                    _dgCode = model.D_CODE;
                    _pyCode = model.PY_CODE;
                    _wbCode = model.WB_CODE;
                    _mzFlag = model.MZ_FLAG;
                    _zyFlag = model.ZY_FLAG;
                    _jzFlag = model.JZ_FLAG;
                    _smFlag = model.SM_FLAG;
                    code = model.CODE;
                    notUse = model.DELETED;
                    type_code = model.TYPE_CODE;
                    InitWardInfo( );
                }
            }
            catch ( System.Exception err )
            {
                throw new Exception( "Deptment\\" + err.Message );
            }
        }
        /// <summary>
        ///  得到科室信息
        /// </summary>
        /// <param name="deptID">表实体对象</param>
        private void GetDeptInfo( Model.BASE_DEPT_PROPERTY model )
        {
            try
            {
                if ( model != null )
                {
                    _name = model.NAME;
                    _deptID = model.DEPT_ID;
                    _pDeptID = model.P_DEPT_ID;
                    _deptAddr = model.DEPTADDR;
                    _dgCode = model.D_CODE;
                    _pyCode = model.PY_CODE;
                    _wbCode = model.WB_CODE;
                    _mzFlag = model.MZ_FLAG;
                    _zyFlag = model.ZY_FLAG;
                    _smFlag = model.SM_FLAG;
                    _jzFlag = model.JZ_FLAG;
                    notUse = model.DELETED;
                    type_code = model.TYPE_CODE;
                    model.CODE = code;
                    InitWardInfo( );
                }
            }
            catch ( System.Exception err )
            {
                throw new Exception( "Deptment\\" + err.Message );
            }
        }
        /// <summary>
        /// 初始化病区信息
        /// </summary>
        private void InitWardInfo()
        {
            _wardID = "";
            _wardName = "";
            _wardDeptID = 0;
            
        }

        /// <summary>
        /// 保存�
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {

            HIS.Model.BASE_DEPT_PROPERTY model = new HIS.Model.BASE_DEPT_PROPERTY( );
            try
            {
                model.P_DEPT_ID = _pDeptID;
                model.NAME = _name;
                model.D_CODE = _dgCode;
                model.PY_CODE = _pyCode;
                model.WB_CODE = _wbCode;
                model.DEPTADDR = _deptAddr;
                model.MZ_FLAG = _mzFlag;
                model.ZY_FLAG = _zyFlag;
                model.JZ_FLAG = _jzFlag;
                model.SM_FLAG = _smFlag;
                model.DELETED = notUse;
                model.TYPE_CODE = type_code;
                model.CODE = code;
                model.ISFACT = 1;
                BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL(oleDb) .Add( model );

                _deptID = model.DEPT_ID;

                return true;
            }
            catch
            {
                return false;
            }
        
        }

        /// <summary>
        /// �更新��
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            HIS.Model.BASE_DEPT_PROPERTY model = BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).GetModel( _deptID );
            try
            {
                model.P_DEPT_ID = _pDeptID;
                model.NAME = _name;
                model.D_CODE = _dgCode;
                model.PY_CODE = _pyCode;
                model.WB_CODE = _wbCode;
                model.DEPTADDR = _deptAddr;
                model.MZ_FLAG = _mzFlag;
                model.ZY_FLAG = _zyFlag;
                model.JZ_FLAG = _jzFlag;
                model.SM_FLAG = _smFlag;
                model.DELETED = notUse;
                model.TYPE_CODE = type_code;
                model.ISFACT = 1;
                model.CODE = code;
                BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).Update( model );

                return true;
            }
            catch
            {
                return false;
            }
             
        }
        /// <summary>
        /// 获取本科室下的人员列表
        /// </summary>
        /// <returns></returns>
        public Employee[] GetEmployeies()
        {
            System.Collections.Generic.List<Model.BASE_EMP_DEPT_ROLE> list = BindEntity<Model.BASE_EMP_DEPT_ROLE>.CreateInstanceDAL( oleDb ).GetListArray( BLL.Tables.base_emp_dept_role.DEPT_ID + oleDb.EuqalTo( ) + _deptID);

            Employee[] employeies = new Employee[list.Count];
            for ( int i = 0 ; i < list.Count ; i++ )
                employeies[i] = new Employee( list[i].EMPLOYEE_ID );
            
            return employeies;
        }
        /// <summary>
        /// 科室名称是否有效
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public static bool NameExists( Department department )
        {
            object obj = null;
            if ( department.DeptID <=0 )
                obj = BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_dept_property.NAME + oleDb.EuqalTo( ) + "'" + department.Name + "'" );
            else
                obj = BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_dept_property.NAME + oleDb.EuqalTo( ) + "'" + department.Name + "'" + oleDb.And() + BLL.Tables.base_dept_property.DEPT_ID + oleDb.NotEqualTo() + department.DeptID );

            bool ret = false;
            if ( obj == null )
                ret = false;
            else
                ret = true;
           
            return ret;
        }
        /// <summary>
        /// 得到所有科室对象
        /// </summary>
        /// <param name="strWhere">过滤条件，SQL语法</param>
        /// <returns></returns>
        public static Department[] GetDepartment( string strWhere )
        {
            if (strWhere != "")
                strWhere = " and " + strWhere;
            System.Collections.Generic.List<Model.BASE_DEPT_PROPERTY> list = BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).GetListArray( BLL.Tables.base_dept_property.DELETED + oleDb.EuqalTo( ) + "0" + "  " + strWhere );

            Department[] depts = new Department[list.Count];
            for ( int i = 0 ; i < list.Count ; i++ )
                depts[i] = new Department( list[i] );

            return depts;

        }

    }
}
