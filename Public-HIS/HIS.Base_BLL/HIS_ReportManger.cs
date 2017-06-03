using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS;
using HIS.SYSTEM.Core;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 报表对象
    /// </summary>
    public class HIS_ReportManger : BaseBLL
    {
        
        /// <summary>
        /// 删除报表
        /// </summary>
        /// <param name="Rptid"></param>
        /// <returns></returns>
        public static bool DeleteReport( int Rptid )
        {
             
            try
            {

                BindEntity<Model.HIS_Report>.CreateInstanceDAL( oleDb ).Delete( Rptid );

                return true;
            }
            catch ( System.Exception e )
            {
                throw new Exception( e.Message );
            }
        }
        /// <summary>
        /// 添加报表
        /// </summary>
        /// <param name="ReportName"></param>
        /// <param name="ReportPath"></param>
        /// <param name="CreatorCode"></param>
        /// <param name="CreatorName"></param>
        /// <returns></returns>
        public static bool AddReport(string ReportName,string ReportPath,string CreatorCode,string CreatorName)
        {
             
            try
            {
                HIS.Model.HIS_Report Erpt = new HIS.Model.HIS_Report( );
                Erpt.ReportName = ReportName;
                Erpt.ReportPath = ReportPath;
                Erpt.BuildEmpCode = CreatorCode;
                Erpt.BuildEmpName = CreatorName;
                Erpt.BuildDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;

                BindEntity<Model.HIS_Report>.CreateInstanceDAL( oleDb ).Add( Erpt );
                return true;
            }
            catch ( System.Exception e )
            {
                throw new Exception( e.Message );
            }
            finally
            {
                 
            }
        }
        /// <summary>
        /// 更新报表
        /// </summary>
        /// <param name="RptID"></param>
        /// <param name="ReportName"></param>
        /// <param name="ReportPath"></param>
        /// <param name="CreatorCode"></param>
        /// <param name="CreatorName"></param>
        /// <returns></returns>
        public static bool UpdateReport(int RptID, string ReportName , string ReportPath , string CreatorCode , string CreatorName )
        {
             
            try
            {
                HIS.Model.HIS_Report Erpt = new HIS.Model.HIS_Report( );
                Erpt.ReportID = RptID;
                Erpt.ReportName = ReportName;
                Erpt.ReportPath = ReportPath;
                Erpt.BuildEmpCode = CreatorCode;
                Erpt.BuildEmpName = CreatorName;
                BindEntity<Model.HIS_Report>.CreateInstanceDAL( oleDb ).Update( Erpt );
                return true;
            }
            catch ( System.Exception e )
            {
                throw new Exception( e.Message );
            }
            finally
            {
            }
        }
    }
}
