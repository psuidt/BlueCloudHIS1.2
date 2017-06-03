using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS;
using HIS.SYSTEM.Core;
using HIS.DAL;

namespace HIS.YZCX_BLL
{
    /// <summary>
    /// 门诊报表对象
    /// </summary>
    public class ReportClass : BaseBLL
    {
              
        /// <summary>
        /// 获取挂号统计报表(NAME,DATE,NUM)
        /// </summary>
        /// <param name="ViewType">0-按医生 1-按科室</param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DataSet GetRegisterReport( int ViewType , DateTime beginDate , DateTime endDate )
        {
            DataTable tbReg = GetRegisterData( beginDate , endDate );

            DataTable tbResultByName = new DataTable( );
            tbResultByName.TableName = "TB_A";
            tbResultByName.Columns.Add( "CODE" , Type.GetType( "System.String" ) );
            tbResultByName.Columns.Add( "NAME" , Type.GetType( "System.String" ) );
            tbResultByName.Columns.Add( "NUM" , Type.GetType( "System.Int32" ) );
            tbResultByName.Columns.Add( "MONEY" , Type.GetType( "System.Decimal" ) );

            DataTable tbResultByDate = new DataTable( );
            tbResultByDate.TableName = "TB_B";
            tbResultByDate.Columns.Add( "DATE" , Type.GetType( "System.String" ) );
            tbResultByDate.Columns.Add( "NUM" , Type.GetType( "System.Int32" ) );

            string fileName = "";
            if ( ViewType == 0 )
                fileName = "PRESDOCCODE";
            else
                fileName = "PRESDEPTCODE";

            for ( int i = 0 ; i < tbReg.Rows.Count ; i++ )
            {
                string code = tbReg.Rows[i][fileName].ToString().Trim();
                DataRow[] drs = tbResultByName.Select( "CODE='" + code + "'" );
                if ( drs.Length == 0 )
                {
                    DataRow dr = tbResultByName.NewRow( );
                    dr["CODE"] = code;
                    if ( ViewType == 0 )
                        dr["NAME"] = code == "" ? "未指定" : PublicDataReader.GetEmployeeNameById( Convert.ToInt32( code ) );
                    else
                        dr["NAME"] = code == "" ? "未指定" : PublicDataReader.GetDeptNameById( Convert.ToInt32( code ) );
                    
                    dr["NUM"] = tbReg.Rows[i]["REGNUM"];
                    tbResultByName.Rows.Add( dr );
                }
                else
                {
                    drs[0]["NUM"] = Convert.ToInt32( tbReg.Rows[i]["REGNUM"] ) + ( Convert.IsDBNull( drs[0]["NUM"] ) ? 0 : Convert.ToInt32( drs[0]["NUM"] ) );
                }
                //日期
                drs = tbResultByDate.Select( "DATE='" + Convert.ToDateTime(tbReg.Rows[i]["PRESDATE"]).ToString( "yyyy-MM-dd" ) + "'" );
                if ( drs.Length == 0 )
                {
                    DataRow dr = tbResultByDate.NewRow( );
                    dr["DATE"] = Convert.ToDateTime(tbReg.Rows[i]["PRESDATE"]).ToString("yyyy-MM-dd");
                    dr["NUM"] = tbReg.Rows[i]["REGNUM"];
                    tbResultByDate.Rows.Add( dr );
                }
                else
                {
                    int num = Convert.IsDBNull( drs[0]["NUM"] ) ? 0 : Convert.ToInt32( drs[0]["NUM"] );
                    int num1 = Convert.IsDBNull( tbReg.Rows[i]["REGNUM"] ) ? 0 : Convert.ToInt32( tbReg.Rows[i]["REGNUM"] );
                    num = num + num1;
                    drs[0]["NUM"] = num;
                }
            }

            DataSet dsResult = new DataSet( );
            dsResult.Tables.Add( tbResultByName );
            dsResult.Tables.Add( tbResultByDate );

            return dsResult;
        }
        /// <summary>
        /// 获取挂号人次统计信息
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns></returns>
        private static DataTable GetRegisterData( DateTime dateBegin , DateTime dateEnd )
        {
            int workid = Convert.ToInt32( HIS.SYSTEM.Core.EntityConfig.WorkID );
            string dateFormat = "yyyy-MM-dd HH:mm:ss";
            string strWhere = "presdate between '" + dateBegin.ToString(dateFormat) + "' and '" +
                dateEnd.ToString(dateFormat) + "'" + oleDb.And() + "workid=" + workid.ToString();
            string sql = "select regnum,presdate,presdoccode,presdeptcode from yzcx_mz_register where " + strWhere;
            return oleDb.GetDataTable( sql );
        } 
    }
}
