using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;

namespace HIS.MZ_BLL.Report
{
    /// <summary>
    /// 挂号人次统计
    /// </summary>
    public class RegisterPersonTimeReport : BaseBLL
    {
        int _ViewType;
        DateTime _beginDate;
        DateTime _endDate;
        int statType;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ViewType">查看方式 0-按医生 1-按科室</param>
        /// <param name="beginDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="StatType">统计方式：0-所有 1-仅按挂号费</param>
        public RegisterPersonTimeReport( int ViewType, DateTime beginDate, DateTime endDate ,int StatType)
        {
            _ViewType = ViewType;
            _beginDate = beginDate;
            _endDate = endDate;
            statType = StatType;
        }
        /// <summary>
        /// 获取挂号统计报表(NAME,DATE,NUM)
        /// </summary>
        /// <param name="ViewType">0-按医生 1-按科室</param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private DataSet GetRegisterReport( int ViewType, DateTime beginDate, DateTime endDate )
        {
            DataTable tbReg = GetRegisterData( beginDate, endDate );

            DataTable tbResultByName = new DataTable();
            tbResultByName.TableName = "TB_A";
            tbResultByName.Columns.Add( "CODE", Type.GetType( "System.String" ) );
            tbResultByName.Columns.Add( "NAME", Type.GetType( "System.String" ) );
            tbResultByName.Columns.Add( "NUM", Type.GetType( "System.Int32" ) );
            tbResultByName.Columns.Add( "MONEY", Type.GetType( "System.Decimal" ) );

            DataTable tbResultByDate = new DataTable();
            tbResultByDate.TableName = "TB_B";
            tbResultByDate.Columns.Add( "DATE", Type.GetType( "System.String" ) );
            tbResultByDate.Columns.Add( "NUM", Type.GetType( "System.Int32" ) );

            string fileName = "";
            if ( ViewType == 0 )
                fileName = "PRESDOCCODE";
            else
                fileName = "PRESDEPTCODE";

            for ( int i = 0; i < tbReg.Rows.Count; i++ )
            {
                string code = tbReg.Rows[i][fileName].ToString().Trim();
                DataRow[] drs = tbResultByName.Select( "CODE='" + code + "'" );
                if ( drs.Length == 0 )
                {
                    DataRow dr = tbResultByName.NewRow();
                    dr["CODE"] = code;
                    if ( ViewType == 0 )
                        dr["NAME"] = code == "" ? "未指定" : BaseDataController.GetName( BaseDataCatalog.人员列表, Convert.ToInt32( code ) ); //PublicDataReader.GetEmployeeNameById( Convert.ToInt32( code ) );
                    else
                        dr["NAME"] = code == "" ? "未指定" : BaseDataController.GetName( BaseDataCatalog.科室列表, Convert.ToInt32( code ) ); //PublicDataReader.GetDeptNameById( Convert.ToInt32( code ) );

                    dr["NUM"] = tbReg.Rows[i]["REGNUM"];
                    //dr["MONEY"] = tbReg.Rows[i]["MONEY"];
                    tbResultByName.Rows.Add( dr );
                }
                else
                {
                    drs[0]["NUM"] = Convert.ToInt32( tbReg.Rows[i]["REGNUM"] ) + ( Convert.IsDBNull( drs[0]["NUM"] ) ? 0 : Convert.ToInt32( drs[0]["NUM"] ) );
                    //drs[0]["MONEY"] = Convert.ToInt32( tbReg.Rows[i]["REGNUM"] ) + ( Convert.IsDBNull( drs[0]["MONEY"] ) ? 0 : Convert.ToDecimal( drs[0]["MONEY"] ) );
                }
                //日期
                drs = tbResultByDate.Select( "DATE='" + Convert.ToDateTime( tbReg.Rows[i]["PRESDATE"] ).ToString( "yyyy-MM-dd" ) + "'" );
                if ( drs.Length == 0 )
                {
                    DataRow dr = tbResultByDate.NewRow();
                    dr["DATE"] = Convert.ToDateTime( tbReg.Rows[i]["PRESDATE"] ).ToString( "yyyy-MM-dd" );
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

            DataSet dsResult = new DataSet();
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
        private DataTable GetRegisterData( DateTime dateBegin, DateTime dateEnd )
        {
            int workid = Convert.ToInt32( HIS.SYSTEM.Core.EntityConfig.WorkID );
            string dateFormat = "yyyy-MM-dd HH:mm:ss";
            string sql = @"select count(patlistid) as regnum,presdate,presdoccode,presdeptcode 
                            from
                            ( 	
	                            select patlistid,presdate,presdoccode,presdeptcode 
	                            from
	                            (
 	 	                            select patlistid,date(presdate) as presdate,presdoccode,presdeptcode 
		                            from (select patlistid,presdate,presdoccode,presdeptcode,charge_flag,record_flag,hand_flag from mz_presmaster where workid=" + workid + @") a
		                            where charge_flag=1 and record_flag in (0,1,2) and hand_flag=1 
		                            and not exists( select 1 from (select patlistid  from (select patlistid,charge_flag,record_flag,hand_flag from mz_presmaster where workid=" + workid + @") a where charge_flag=1 and record_flag=0 and hand_flag=0 group by patlistid) a1 where a.patlistid=a1.patlistid )
		                            and presdate between '" + dateBegin.ToString( dateFormat ) + @"' and '" + dateEnd.ToString( dateFormat ) + @"'
		                            union all
		                            select patlistid,date(presdate) as presdate , presdoccode,presdeptcode 
		                            from (select patlistid,presdate,presdoccode,presdeptcode,charge_flag,record_flag,hand_flag from mz_presmaster where workid=" + workid + @") a 
		                            where charge_flag=1 and record_flag=0 and hand_flag=0 
		                            and presdate between '" + dateBegin.ToString( dateFormat ) + @"' and '" + dateEnd.ToString( dateFormat ) + @"'
		                            group by patlistid,date(presdate),presdoccode,presdeptcode 
	                            ) a group by patlistid,presdate,presdoccode,presdeptcode 
                            ) aa group by presdate,presdoccode,presdeptcode ";

            if ( statType == 1 )
            {
                sql = @"select count(patlistid) as regnum, presdate,presdoccode,presdeptcode 
                    from
                    (
                        select b.patlistid,date(presdate) as presdate,presdoccode,presdeptcode 
                        from mz_presorder a , mz_presmaster b where a.presmasterid = b.presmasterid and a.bigitemcode = '05' 
                        and b.presdate between '" + dateBegin.ToString( dateFormat ) + @"' and '" + dateEnd.ToString( dateFormat ) + @"'
                        and b.charge_flag = 1 and record_flag in (0,1) and a.workid  = " + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString() + " and b.workid = " + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString() + @"
                    ) aa group by presdate,presdoccode,presdeptcode";
            }
            return oleDb.GetDataTable( sql );
        }

        private DataSet _dsData;

        public void Fill()
        {
            _dsData = GetRegisterReport(_ViewType, _beginDate, _endDate);
        }

        public DataTable PersonOfDocOrDept
        {
            get
            {
                return _dsData.Tables["TB_A"];
            }
        }
        public DataTable PersonOfDate
        {
            get
            {
                return _dsData.Tables["TB_B"];
            }
        }
    }
}
