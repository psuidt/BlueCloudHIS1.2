using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.Model;

namespace HIS.YZCX_BLL
{
    /// <summary>
    /// 公共数据读取类
    /// </summary>
    public class PublicDataReader : HIS.SYSTEM.Core.BaseBLL
    {
        private static DataTable employeies;
        private static DataTable statItemList;
        private static DataTable mzfpItemList;
        private static DataTable depts;
        private static DataTable tbPatientType;

        public static DataTable Depts
        {
            get
            {
                //if ( depts == null )
                //{
                //    HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
                //    mz_dal._OleDB = oleDb;
                //    depts = mz_dal.GetBaseDepartment( );
                //}
                //return depts;
                return HIS.MZ_BLL.BaseDataController.BaseDataSet[HIS.MZ_BLL.BaseDataCatalog.科室列表];
            }
        }
        public static DataTable Employeies
        {
            get
            {
                if ( employeies == null )
                {
                    HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL();
                    mz_dal._OleDB = oleDb;
                    employeies = mz_dal.GetEmployeeList( );
                }
                return employeies;
            }
        }
        public static DataTable StatItemList
        {
            get
            {
                //if ( statItemList == null )
                //{
                //    HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
                //    mz_dal._OleDB = oleDb;
                //    statItemList = mz_dal.GetOPDInoviceItems( );
                //}
                //return statItemList;
                return HIS.MZ_BLL.BaseDataController.BaseDataSet[HIS.MZ_BLL.BaseDataCatalog.门诊发票科目];
            }
            
        }
        public static DataTable GetBigItemList()
        {
            try
            {
                return BindEntity<BASE_STAT_ITEM>.CreateInstanceDAL(oleDb).GetList("");
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        public static DataTable GetHSItemList()
        {
            try
            {
                return BindEntity<BASE_STAT_HS>.CreateInstanceDAL(oleDb).GetList("");
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        public static DataTable MzfpItemList
        {
            get
            {
                if ( mzfpItemList == null )
                {
                    HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
                    mz_dal._OleDB = oleDb;
                    mzfpItemList = mz_dal.GetMzfpItemList( );
                }
                return mzfpItemList;
            }
        }
        /// <summary>
        /// PATTYPECODE ,NAME,FAVORABLE_SCALE,FAVORABLE_TYPE,MZ_FLAG,ZY_FLAG,MEDSAFECODE,DEL_FLAG
        /// </summary>
        public static DataTable PatientTypeList
        {
            get
            {
                if ( tbPatientType == null )
                {
                    HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
                    mz_dal._OleDB = oleDb;
                    tbPatientType = mz_dal.GetPatientType( );
                }
                return tbPatientType;
            }
        }

        public static string GetEmployeeNameById(int EmployeeId)
        {
            DataRow[] drs = PublicDataReader.Employeies.Select( "EMPLOYEE_ID=" + EmployeeId );
            if ( drs.Length == 0 )
                return "";
            else
                return drs[0]["NAME"].ToString( );
        }
        public static string GetDeptNameById(int DeptId)
        {
            DataRow[] drs = PublicDataReader.Depts.Select( "DEPT_ID=" + DeptId );
            if ( drs.Length == 0 )
                return "";
            else
                return drs[0]["NAME"].ToString( );
        }
        public static string GetPatientTypeNameByCode(string Code)
        {
            DataRow[] drs = PublicDataReader.PatientTypeList.Select( "PATTYPECODE='" + Code + "'" );
            if ( drs.Length == 0 )
                return "";
            else
                return drs[0]["NAME"].ToString( );
        }
        /// <summary>
        /// 获取门诊划价收费的项目选择卡数据源
        /// </summary>
        /// <param name="dataType">数据类型：0-划价 1-收费</param>
        /// <returns></returns>
        public static DataTable GetItemSelectedCardDataSource(int dataType)
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetItemSelectedCardDataSource(dataType);
        }
        /// <summary>
        /// 获取门诊科室选择卡数据源  DEPT_ID,NAME,PY_CODE
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDeptSelectedCardDataSource(bool all)
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetDeptSelectedCardDataSource(all);
        }
        /// <summary>
        /// 得到医生 EMPLOYEE_ID,B.NAME,B.PY_CODE,B.WB_CODE
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDoctorList()
        {
            //HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            //mz_dal._OleDB = oleDb;
            //return mz_dal.GetDoctorList( );
            return HIS.MZ_BLL.BaseDataController.BaseDataSet[HIS.MZ_BLL.BaseDataCatalog.医生列表];
        }
        /// <summary>
        /// 获取医生详细列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDoctorDetailList()
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL();
            mz_dal._OleDB = oleDb;
            return mz_dal.GetDoctorDetailList();
        }
        /// <summary>
        /// 得到疾病 ID,  NAME, PY_CODE
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDiseaseList()
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetDiseaseList( );
        }
        /// <summary>
        /// 获取挂号类型和医生级别对应关系
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRegTypeAndDocTypeRelation()
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL();
            mz_dal._OleDB = oleDb;
            return mz_dal.GetRegisterTypeRelation();
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
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetChargeInvoiceList( dateTimeFrom , dateTimeTo , OperatorId );
        }
        /// <summary>
        /// 发票查询
        /// </summary>
        /// <param name="dateTimeFrom">开始时间</param>
        /// <param name="dateTimeTo">结束时间</param>
        /// <returns></returns>
        public static DataTable GetChargeInvoiceList( DateTime dateTimeFrom , DateTime dateTimeTo )
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetChargeInvoiceList( dateTimeFrom , dateTimeTo );
        }
        /// <summary>
        /// 获取医生级别定义（国标）
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDoctorTypeDefine()
        {
            return HIS.SYSTEM.Core.BindEntity<object>.CreateInstanceDAL( oleDb, BLL.Tables.GB_SUB_ITEM ).GetList( BLL.Tables.gb_sub_item.CODE + oleDb.EuqalTo() + "'006'" + oleDb.And() + BLL.Tables.gb_sub_item.SUB_CODE + oleDb.Between() + "'231'" + oleDb.And() + "'235'",
                    oleDb.FiledNameBM( BLL.Tables.gb_sub_item.SUB_CODE, "type_id" ),
                    oleDb.FiledNameBM( BLL.Tables.gb_sub_item.SUB_ITEM_NAME, "type_name" ) );
        }
        /// <summary>
        /// 获取医生级别和挂号级别对应关系
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDoctorTypeRegTypeRelation()
        {
            return HIS.SYSTEM.Core.BindEntity<Model.MZ_DOCTYPE_REGTYPE>.CreateInstanceDAL( oleDb ).GetList( "" );
        }
        /// <summary>
        /// 获取挂号科室(DEPT_ID,NAME ,APPEND_FEE,PY_CODE,WB_CODE)
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRegisterDepartment()
        {
            //HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            //mz_dal._OleDB = oleDb;
            //return mz_dal.GetRegisterDepartment( ); 
            return HIS.MZ_BLL.BaseDataController.BaseDataSet[HIS.MZ_BLL.BaseDataCatalog.科室列表];
        }
        /// <summary>
        /// 获取挂号类型(TYPE_CODE,TYPE_NAME,PY_CODE,WB_CODE,PRICE)
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRegisterType()
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            //DataTable tb = mz_dal.GetRegisterType( );
            DataTable tb = HIS.MZ_BLL.BaseDataController.BaseDataSet[HIS.MZ_BLL.BaseDataCatalog.挂号类型定义列表];
            DataRow[] drs = tb.Select( "Valid_Flag=1" );
            DataTable tb1 = tb.Clone( );
            for ( int i = 0 ; i < drs.Length ; i++ )
            {
                tb1.Rows.Add( drs[i].ItemArray );
            }
            return tb1;
        }
        /// <summary>
        /// 获取挂号类型定义及其费用关联
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRegisterTypeDefine()
        {
            //HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL();
            //mz_dal._OleDB = oleDb;
            //return mz_dal.GetRegisterTypeDefine();
            return HIS.MZ_BLL.BaseDataController.BaseDataSet[HIS.MZ_BLL.BaseDataCatalog.挂号类型定义列表];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRegisterBaseDefine()
        {
            //HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL();
            //mz_dal._OleDB = oleDb;
            //return mz_dal.GetRegisterBaseDefine();
            return HIS.MZ_BLL.BaseDataController.BaseDataSet[HIS.MZ_BLL.BaseDataCatalog.挂号类型定义列表];
        }
        /// <summary>
        /// 获取挂号医生(EMPLOYEE_ID,NAME,PY_CODE,WB_CODE,TYPE_NAME,TYPE_ID)
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRegisterDoctor()
        {
            //HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            //mz_dal._OleDB = oleDb;
            //return mz_dal.GetRegisterDoctor( );
            return HIS.MZ_BLL.BaseDataController.BaseDataSet[HIS.MZ_BLL.BaseDataCatalog.医生列表];
        }
        /// <summary>
        /// 获取人员列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEmployeeList()
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetEmployeeList( );
        }
        /// <summary>
        /// 获取项目的执行科室
        /// </summary>
        /// <param name="ItemID">项目ID</param>
        /// <returns></returns>
        public static DataTable GetItemExecDepartment( int ItemID )
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;

            return mz_dal.GetItemExecDepartment( ItemID );
        }
        /// <summary>
        /// 获取所有项目的执行科室
        /// </summary>
        /// <returns></returns>
        public static DataTable GetItemExecDepartment()
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetItemExecDepartment();
        }

        /// <summary>
        /// 获取临床科室
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadClincDept()
        {
            try
            {
                string strWhere = BLL.Tables.base_dept_property.TYPE_CODE + oleDb.EuqalTo()
                    + "'001'";
                return BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL(oleDb).GetList(strWhere,
                    BLL.Tables.base_dept_property.DEPT_ID,
                    BLL.Tables.base_dept_property.NAME);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载住院发票项目
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadZYFPCode()
        {
            try
            {
                return BindEntity<HIS.Model.BASE_STAT_ZYFP>.CreateInstanceDAL(oleDb).GetList(BLL.Tables.base_stat_zyfp.VALID_FLAG
                    + oleDb.EuqalTo() + "1");
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取收费项目列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetServiceItemList()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL();
            base_dal.OleDB = oleDb;
            return base_dal.get_Base_Service_Items();
        }
        /// <summary>
        /// 获取民族列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFolkList()
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetFolkList( );
        }
        /// <summary>
        /// 根据诊疗卡号获取已挂号的病人列表
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public static DataTable GetRegistedPatientListByCardNo(string cardNo)
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            return mz_dal.GetRegPatientListByCardNo( cardNo );
        }
        /// <summary>
        /// 获取模板
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_TemplateList()
        {
            return BindEntity<Model.BASE_TEMPLATE_ITEM>.CreateInstanceDAL( oleDb ).GetList( "VALID_FLAG=1" );
        }
        /// <summary>
        /// 获取模板明细
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_TemplateDetailList()
        {
            return BindEntity<Model.BASE_TEMPLATE_DETAIL>.CreateInstanceDAL( oleDb ).GetList( "" );
        }
        /// <summary>
        /// 得到工作单位列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_WorkUnitList()
        {
            return BindEntity<Model.BASE_WORK_UNIT>.CreateInstanceDAL( oleDb ).GetList( "" );
        }

        public static DataTable Get_Invoice_PerfChar()
        {
            string sql = oleDb.Table( Tables.MZ_INVOICE , "" , "" , oleDb.FiledNameBM( oleDb.Distinct( "perfchar" ) , "perfchar" ) );
            return oleDb.GetDataTable( sql );
        }
    }
}
