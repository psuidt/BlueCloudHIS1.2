using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.Base_BLL.Enums;
using System.Collections;
using System.Data;

namespace HIS.Base_BLL
{
    public class ParameterSet : BaseBLL
    {

        private Hashtable htParameters;

        public ParameterSet()
        {
            //初始化加载所有参数,每个模块的所有参数对应一个Parameters并放到htParameters中
            //htParameters.Key:ParameterCatalog
            HIS.DAL.BASE_DAL dal = new HIS.DAL.BASE_DAL();
            dal.OleDB = oleDb;
            htParameters = new Hashtable();
            //门诊经管
            DataTable dtMzConfig = dal.Get_MZJG_Parameters();
            htParameters.Add(ParameterCatalog.门诊经管, ToParameters( dtMzConfig ) );

            //住院经管
            DataTable dtZyCofig = dal.Get_ZYJG_parameters();
            htParameters.Add( ParameterCatalog.住院经管, ToParameters( dtZyCofig ) );

            //门诊医生
            DataTable dtMZYSConfig = dal.Get_MZYS_Parameters();
            htParameters.Add( ParameterCatalog.门诊医生站, ToParameters( dtMZYSConfig ) );

            //住院医生
            DataTable dtZYYSConfig = dal.Get_ZYYS_Parameters();
            htParameters.Add( ParameterCatalog.住院医生站, ToParameters( dtZYYSConfig ) );

            //住院护士
            DataTable dtZYHSConfig = dal.Get_ZYHS_Parameters();
            htParameters.Add( ParameterCatalog.住院护士站, ToParameters( dtZYHSConfig ) );

            //药品管理
            DataTable dtYPGLConfig = dal.Get_YPGL_Parameters();
            htParameters.Add( ParameterCatalog.药品管理, ToParameters( dtYPGLConfig ) );
        }

        public Parameters this[ParameterCatalog catalog]
        {
            get
            {
                return (Parameters)htParameters[catalog];
            }
        }

        private Parameters ToParameters(DataTable dtConfig)
        {
            List<Parameter> lstParameter = new List<Parameter>();
            foreach(DataRow dr in dtConfig.Rows )
            {
                Parameter p = new Parameter();
                p.Code = dr["CODE"].ToString().Trim();
                p.Name = dr["NAME"].ToString().Trim();
                p.Notes = dr["BZ"].ToString().Trim();
                p.Value = dr["VALUE"];
                if ( dtConfig.Columns.Contains( "DEPTID" ) )
                    p.DeptId = Convert.ToInt32( Convert.IsDBNull( dr["DEPTID"] ) ? 0 : dr["DEPTID"] );
                lstParameter.Add( p );
            }
            return new Parameters( lstParameter );
        }
    }
}
