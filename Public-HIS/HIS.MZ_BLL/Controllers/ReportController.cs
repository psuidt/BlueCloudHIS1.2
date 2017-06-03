using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.MZ_BLL.Report;
using HIS.MZ_BLL.Exceptions;

namespace HIS.MZ_BLL
{
    public class ReportProcessingEventArgs : EventArgs
    {
        private string status;
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
    }

    public delegate void OnReportProcessingHandler(ReportProcessingEventArgs e);

    public class ReportController : BaseBLL
    {
        public static event OnReportProcessingHandler OnReportProcessing;
 
        private static DataTable statItemList;

        private static DataTable StatItemList
        {
            get
            {
                if ( statItemList == null )
                {
                    string sql = @"select a1.code,a1.item_name,a1.mzfp_code,a2.item_name as mzfp_name,a1.hs_code,a3.item_name as hs_name,a1.mzkj_code,a4.item_name as mzkj_name
                                     from base_stat_item a1
                                     left join base_stat_mzfp a2 on a1.mzfp_code = a2.code
                                     left join base_stat_hs a3 on a1.hs_code = a3.code
                                     left join base_stat_mzkj a4 on a1.mzkj_code = a4.code";
                    statItemList = oleDb.GetDataTable( sql );
                }
                return statItemList;
            }
        }
        /// <summary>
        /// 获取统计起止时间
        /// </summary>
        /// <param name="DateType">时间类型</param>
        /// <param name="StatDay">统计日</param>
        /// <param name="InBeginDate">开始时间</param>
        /// <param name="InEndDate">结束时间</param>
        /// <param name="OutBeginDate">返回的实际开始时间</param>
        /// <param name="OutEndDate">返回的实际结束时间</param>
        public static void GetReportBeginDateAndEndDate(StatDateType DateType,int StatDay, DateTime InBeginDate,DateTime InEndDate,
            out DateTime OutBeginDate,out DateTime OutEndDate ,out string AccountIdList)
        {
            string dateBegin = InBeginDate.ToString( "yyyy-MM-dd" ) + " 00:00:00";
            string dateEnd = InEndDate.ToString( "yyyy-MM-dd" ) + " 23:59:59";
            AccountIdList = null;
            if ( DateType == StatDateType.交账时间 )
            {
                string sql = @"select accountid 
                                from mz_account where accountdate between '" + InBeginDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + InEndDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and workid=  " + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString( );
                DataTable tb = oleDb.GetDataTable( sql );
                if ( tb.Rows.Count > 0 )
                {
                    string accountid = "";
                    for ( int i = 0 ; i < tb.Rows.Count -1 ; i++ )
                        accountid += tb.Rows[i]["accountid"].ToString() + ",";
                    accountid += tb.Rows[tb.Rows.Count - 1]["accountid"].ToString( );
                    AccountIdList = accountid;
                    sql = @"select min(costdate) as d1,max(costdate) as d2 
                        from mz_costmaster where accountid<>0 and accountid in (" + accountid + ") and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString( );

                    DataRow dr = oleDb.GetDataRow( sql );
                    OutBeginDate = Convert.IsDBNull( dr["d1"] ) ? Convert.ToDateTime( "1900-01-01 00:00:00" ) : Convert.ToDateTime( dr["d1"] );
                    OutEndDate = Convert.IsDBNull( dr["d2"] ) ? Convert.ToDateTime( "1900-01-01 00:00:00" ) : Convert.ToDateTime( dr["d2"] );
                }
                else
                {
                    throw new OperatorException( "指定的时间内没有交款记录" );
                    //OutBeginDate = Convert.ToDateTime( "1900-01-01 00:00:00" );
                    //OutEndDate = Convert.ToDateTime( "1900-01-01 00:00:00" );
                }
                return;
            }

            if ( DateType == StatDateType.统计日 )
            {
                OutBeginDate = Convert.ToDateTime( InBeginDate.Year.ToString( ) + "-" + InBeginDate.Month + "-" + ( StatDay + 1 ).ToString( ) + " 00:00:00" );
                OutEndDate = Convert.ToDateTime( InEndDate.Year.ToString( ) + "-" + InEndDate.Month + "-" + StatDay.ToString( ) + " 23:59:59" );
                return;
            }

            if ( DateType == StatDateType.自然时间 )
            {
                OutBeginDate = Convert.ToDateTime(dateBegin);
                OutEndDate = Convert.ToDateTime(dateEnd);
            }

            OutBeginDate = InBeginDate;
            OutEndDate = InEndDate;
        }
        /// <summary>
        /// 填充报表
        /// </summary>
        /// <param name="Report"></param>
        public static void FillReport( BaseReport Report  )
        {
            try
            {
                if ( OnReportProcessing != null )
                {
                    ReportProcessingEventArgs e = new ReportProcessingEventArgs( );
                    e.Status = "数据查询中。。。";
                    OnReportProcessing( e );
                }

                Report.BaseReportData = oleDb.GetDataTable( Report.DataSQL );

                if ( Report is PatientFeeReport )
                {
                    DataRow drTotal = Report.BaseReportData.NewRow( );
                    drTotal[0] = "合  计";
                    for ( int i = 7 ; i < Report.BaseReportData.Columns.Count ; i++ )
                    {
                        string colName = Report.BaseReportData.Columns[i].ColumnName;
                        object obj = Report.BaseReportData.Compute( "Sum(" + colName + ")" ,"");
                        drTotal[colName] = obj.ToString();
                    }
                    Report.BaseReportData.Rows.Add( drTotal );
                    Report.DataResult = Report.BaseReportData;
                               
                    return;
                }
                
                ConvertCodeToName( Report );

                Report.DataResult = SetReportStyle( Report ,Report.Reportstyle );
            }
            catch ( Exception err )
            {
                throw err;                
            }
        }

        /// <summary>
        /// 填充报表
        /// </summary>
        /// <param name="Report"></param>
        public static void FillReport(BaseReport Report,DateTime?Btime,DateTime ?Etime)
        {
            try
            {
                if (OnReportProcessing != null)
                {
                    ReportProcessingEventArgs e = new ReportProcessingEventArgs();
                    e.Status = "数据查询中。。。";
                    OnReportProcessing(e);
                }

                HIS.DAL.MZ_DAL mzdal = new HIS.DAL.MZ_DAL();
                mzdal._OleDB = oleDb;                
                Report.BaseReportData =mzdal.GetChargeReport(Btime, Etime,Report.StatType);              
                ConvertCodeToName(Report);
                Report.DataResult = SetReportStyle(Report, Report.Reportstyle);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        
        /// <summary>
        /// 将列的代码和行的代码转换成中文名称
        /// </summary>
        /// <param name="tbData"></param>
        /// <param name="style"></param>
        private static void ConvertCodeToName( BaseReport report )
        {
            for ( int i = 0 ; i < report.BaseReportData.Rows.Count ; i++ )
            {
                string id = Convert.IsDBNull( report.BaseReportData.Rows[i]["ID"] ) ? "0" : report.BaseReportData.Rows[i]["ID"].ToString( ).Trim( );
                id = id.Trim( ) == "" ? "0" : id;
                string code = Convert.IsDBNull( report.BaseReportData.Rows[i]["CODE"] ) ? "0" : report.BaseReportData.Rows[i]["CODE"].ToString( ).Trim( );

                if ( report is DoctorIncomeReport || report is TollerIncomeReport )
                {
                    //id = PublicDataReader.GetEmployeeNameById( Convert.ToInt32( id ) );
                    id = BaseDataController.GetName( BaseDataCatalog.人员列表, Convert.ToInt32( id ) );
                }
                else if ( report is DepartmentIncomeReport )
                {
                    //id = PublicDataReader.GetDeptNameById( Convert.ToInt32( id ) );
                    id = BaseDataController.GetName( BaseDataCatalog.科室列表, Convert.ToInt32( id ) );
                }
                else if ( report is PatientTypeIncomReport )
                {
                    //id = PublicDataReader.GetPatientTypeNameByCode( id );
                    id = BaseDataController.GetName( BaseDataCatalog.病人类型列表, id );
                }

                id = id.Trim( ) == "" ? "<未指定>" : id;
                if ( report.StatType != StatClassType.收费支付类型)
                    code = GetItemNameByCode( code , report.StatType );

                report.BaseReportData.Rows[i]["ID"] = id;
                report.BaseReportData.Rows[i]["CODE"] = code;

            }
        }
        /// <summary>
        /// 设置数据表样式
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        private static DataTable SetReportStyle( BaseReport report , ReportStyle reportStyle )
        {
            if ( OnReportProcessing != null )
            {
                ReportProcessingEventArgs e = new ReportProcessingEventArgs( );
                e.Status = "数据排列中。。。";
                OnReportProcessing( e );
            }
            DataTable tbResult = new DataTable( );
            if ( reportStyle == ReportStyle.科目为标题列 )
            {
                tbResult = RebuildDataWithItemInColumn( report );
            }
            else
            {
                tbResult = RebuildDataWithItemInRow( report );
            }
            

            if ( OnReportProcessing != null )
            {
                ReportProcessingEventArgs e = new ReportProcessingEventArgs( );
                e.Status = "完成";
                OnReportProcessing( e );
            }        
                return tbResult;
        }
        /// <summary>
        /// 按科目在列重组数据
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        private static DataTable RebuildDataWithItemInColumn( BaseReport report )
        {
            DataTable tbData = report.BaseReportData;
            DataTable tbResult = new DataTable( );
            tbResult.Columns.Add( "名称" , Type.GetType( "System.String" ) );
            tbResult.Columns.Add( "合计" , Type.GetType( "System.Decimal" ) );
            for ( int i = 0 ; i < tbData.Rows.Count ; i++ )
            {
                string id = Convert.IsDBNull( tbData.Rows[i]["ID"] ) ? "0" : tbData.Rows[i]["ID"].ToString( ).Trim( );
                string code = Convert.IsDBNull( tbData.Rows[i]["CODE"] ) ? "0" : tbData.Rows[i]["CODE"].ToString( ).Trim( );
                decimal fee = Convert.IsDBNull( tbData.Rows[i]["TOTAL_FEE"] ) ? 0 : Convert.ToDecimal( tbData.Rows[i]["TOTAL_FEE"] );

                //if ( report is DoctorIncomeReport || report is TollerIncomeReport )
                //    id = PublicDataReader.GetEmployeeNameById( Convert.ToInt32( id ) );
                //else
                //    id = PublicDataReader.GetDeptNameById( Convert.ToInt32( id ) );
                //id = id.Trim( ) == "" ? "<未指定>" : id;
                //code = GetItemNameByCode( code , report.StatType );


                if ( !tbResult.Columns.Contains( code ) )
                    tbResult.Columns.Add( code , Type.GetType( "System.Decimal" ) );
                DataRow[] drs = tbResult.Select( "名称='" + id + "'" );
                if ( drs.Length == 0 )
                {
                    DataRow dr = tbResult.NewRow( );
                    dr["名称"] = id;
                    dr["合计"] = fee;
                    dr[code] = fee;
                    tbResult.Rows.Add( dr );
                }
                else
                {
                    decimal cellValue = Convert.IsDBNull( drs[0][code] ) ? 0 : Convert.ToDecimal( drs[0][code] );
                    decimal rowTotalValue = Convert.IsDBNull( drs[0]["合计"] ) ? 0 : Convert.ToDecimal( drs[0]["合计"] );
                    drs[0][code] = cellValue + fee;
                    drs[0]["合计"] = rowTotalValue + fee;
                }
            }
            DataRow drTotal = tbResult.NewRow( );
            drTotal["名称"] = "合  计";
            for ( int i = 0 ; i < tbResult.Columns.Count ; i++ )
            {
                if ( tbResult.Columns[i].ColumnName == "名称" )
                    continue;
                object objSum = tbResult.Compute( "Sum(" + tbResult.Columns[i].ColumnName + ")" , "" );
                drTotal[tbResult.Columns[i].ColumnName] = objSum;
            }
            tbResult.Rows.Add( drTotal );
            return tbResult;
        }
        /// <summary>
        /// 按科目在行重组数据
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        private static DataTable RebuildDataWithItemInRow( BaseReport report )
        {
            DataTable tbData = report.BaseReportData;
            DataTable tbResult = new DataTable( );
            tbResult.Columns.Add( "名称" , Type.GetType( "System.String" ) );
            tbResult.Columns.Add( "合计" , Type.GetType( "System.Decimal" ) );
            for ( int i = 0 ; i < tbData.Rows.Count ; i++ )
            {
                string id = Convert.IsDBNull( tbData.Rows[i]["ID"] ) ? "0" : tbData.Rows[i]["ID"].ToString( ).Trim( );
                //id = id.Trim( ) == "" ? "0" : id;
                string code = Convert.IsDBNull( tbData.Rows[i]["CODE"] ) ? "0" : tbData.Rows[i]["CODE"].ToString( ).Trim( );
                decimal fee = Convert.IsDBNull( tbData.Rows[i]["TOTAL_FEE"] ) ? 0 : Convert.ToDecimal( tbData.Rows[i]["TOTAL_FEE"] );

                //if ( report is DoctorIncomeReport || report is TollerIncomeReport )
                //    id = PublicDataReader.GetEmployeeNameById( Convert.ToInt32( id ) );
                //else
                //    id = PublicDataReader.GetDeptNameById( Convert.ToInt32( id ) );
                //id = id.Trim( ) == "" ? "<未指定>" : id;
                //code = GetItemNameByCode( code , report.StatType );

                if ( !tbResult.Columns.Contains( id ) )
                    tbResult.Columns.Add( id , Type.GetType( "System.Decimal" ) );
                DataRow[] drs = tbResult.Select( "名称='" + code + "'" );
                if ( drs.Length == 0 )
                {
                    DataRow dr = tbResult.NewRow( );
                    dr["名称"] = code;
                    dr["合计"] = fee;
                    dr[id] = fee;
                    tbResult.Rows.Add( dr );
                }
                else
                {
                    decimal cellValue = Convert.IsDBNull( drs[0][id] ) ? 0 : Convert.ToDecimal( drs[0][id] );
                    decimal rowTotalValue = Convert.IsDBNull( drs[0]["合计"] ) ? 0 : Convert.ToDecimal( drs[0]["合计"] );
                    drs[0][id] = cellValue + fee;
                    drs[0]["合计"] = rowTotalValue + fee;
                }
            }
            DataRow drTotal = tbResult.NewRow( );
            drTotal["名称"] = "合  计";
            for ( int i = 0 ; i < tbResult.Columns.Count ; i++ )
            {
                if ( tbResult.Columns[i].ColumnName == "名称" )
                    continue;
                object objSum = tbResult.Compute( "Sum([" + tbResult.Columns[i].ColumnName + "])" , "" );
                drTotal[tbResult.Columns[i].ColumnName] = objSum;
            }
            tbResult.Rows.Add( drTotal );
            return tbResult;
        }
        /// <summary>
        /// 根据代码获取统计分类的名称
        /// </summary>
        /// <param name="code">分类代码</param>
        /// <param name="statType">分类类型</param>
        /// <returns></returns>
        private static string GetItemNameByCode(string code , StatClassType statType)
        {
            string fieldcode = "";
            string fieldname = "";
            if ( statType == StatClassType.门诊发票分类 )
            {
                fieldcode = "mzfp_code";
                fieldname = "mzfp_name";
            }
            else if ( statType == StatClassType.经管核算分类 )
            {
                fieldcode = "hs_code";
                fieldname = "hs_name";
            }
            else if (statType == StatClassType.门诊会计分类)
            {
                fieldcode = "mzkj_code";
                fieldname = "mzkj_name";
            }
            else
            {
                fieldcode = "code";
                fieldname = "item_name";
            }
            DataRow[] drs = StatItemList.Select( fieldcode + "='" + code + "'" );
            if ( drs.Length == 0 )
                return "";
            else
                return drs[0][fieldname].ToString( ).Trim( );
        }
    }
}
