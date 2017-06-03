using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.Model;
using HIS.BLL;

namespace HIS.Base_BLL
{
    public class WorkUnitController : BaseBLL
    {
        /// <summary>
        /// 获取所有工作单位列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetWorkunitList()
        {
            return BindEntity<BASE_WORK_UNIT>.CreateInstanceDAL( oleDb ).GetList( "" );
        }
        /// <summary>
        /// 增加单位
        /// </summary>
        /// <param name="Workunit"></param>
        public static void AddWorkUnit( WorkUnit Workunit )
        {
            string strWhere = Tables.base_work_unit.CODE + oleDb.EuqalTo() + "'"+ Workunit.Code +"'";
            if ( BindEntity<BASE_WORK_UNIT>.CreateInstanceDAL( oleDb ).Exists( strWhere ) )
            {
                throw new Exception( "代码已经存在！" );
            }
            try
            {
                BASE_WORK_UNIT base_work_unit = new BASE_WORK_UNIT( );
                base_work_unit.CODE = Workunit.Code;
                base_work_unit.NAME = Workunit.Name;
                base_work_unit.PY_CODE = Workunit.PyCode;
                base_work_unit.WB_CODE = Workunit.WbCode;
                BindEntity<BASE_WORK_UNIT>.CreateInstanceDAL( oleDb ).Add( new string[] { Tables.base_work_unit.CODE , Tables.base_work_unit.NAME , Tables.base_work_unit.PY_CODE , Tables.base_work_unit.WB_CODE } ,
                                                                        new string[] { "'"+Workunit.Code+"'" ,"'"+ Workunit.Name+"'" ,"'"+ Workunit.PyCode+"'" ,"'"+ Workunit.WbCode+"'" } ,
                                                                        new bool[] { false , false , false , false } );
            }
            catch(Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 增加单位
        /// </summary>
        /// <param name="workunitName"></param>
        /// <param name="py"></param>
        /// <param name="wb"></param>
        /// <returns>返回Code</returns>
        public static string AddWorkUnit( string workunitName, string py, string wb )
        {
            string fd = oleDb.DBConvert( Tables.base_work_unit.CODE, "integer" );
            string gs = oleDb.Max( fd );

            string sql = oleDb.Table( Tables.BASE_WORK_UNIT, "", "", gs );

            object obj = oleDb.GetDataResult( sql );
            string code = "";
            if ( Convert.IsDBNull( obj ) )
            {
                code = "0001";
            }
            else
            {
                code = ( Convert.ToInt32( obj ) + 1 ).ToString( "0000" );
            }
            WorkUnit workUnit = new WorkUnit();
            workUnit.Code = code;
            workUnit.Name = workunitName;
            workUnit.PyCode = py;
            workUnit.WbCode = wb;
            AddWorkUnit( workUnit );
            return workUnit.Code;
        }
        /// <summary>
        /// 更新单位
        /// </summary>
        /// <param name="Workunit"></param>
        public static void UpdateWorkUnit( WorkUnit Workunit )
        {
            string strWhere = Tables.base_work_unit.CODE + oleDb.EuqalTo( ) + "'" + Workunit.Code + "'";
            if ( BindEntity<BASE_WORK_UNIT>.CreateInstanceDAL( oleDb ).Exists( strWhere ) )
            {
                try
                {
                    BASE_WORK_UNIT base_work_unit = new BASE_WORK_UNIT( );
                    base_work_unit.CODE = Workunit.Code;
                    base_work_unit.NAME = Workunit.Name;
                    base_work_unit.PY_CODE = Workunit.PyCode;
                    base_work_unit.WB_CODE = Workunit.WbCode;
                    BindEntity<BASE_WORK_UNIT>.CreateInstanceDAL( oleDb ).Update( strWhere ,
                        Tables.base_work_unit.NAME + oleDb.EuqalTo( ) + "'" + Workunit.Name + "'" ,
                        Tables.base_work_unit.PY_CODE + oleDb.EuqalTo( ) + "'" + Workunit.PyCode + "'" ,
                        Tables.base_work_unit.WB_CODE + oleDb.EuqalTo( ) + "'" + Workunit.WbCode + "'" );
                }
                catch ( Exception err )
                {
                    throw err;
                }

            }
            else
                throw new Exception( "记录不存在！" );
        }

    }
}
