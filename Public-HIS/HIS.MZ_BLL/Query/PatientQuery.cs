using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;

namespace HIS.MZ_BLL.Query
{
    /// <summary>
    /// 病人查询器
    /// </summary>
    public class PatientQuery : BaseQuery
    {
        /// <summary>
        /// 获取病人对象列表
        /// </summary>
        /// <param name="InvoiceNo">发票号</param>
        /// <param name="InvoiceType">发票类型</param>
        /// <param name="VisitNo">门诊号</param>
        /// <param name="PatientName">病人姓名</param>
        /// <param name="dateFrom">开始时间</param>
        /// <param name="dateTo">结束时间</param>
        /// <returns></returns>
        public List<BasePatient> GetPatient(string InvoiceNo,OPDBillKind InvoiceType,
                                            string VisitNo,
                                            string PatientName,
                                            DateTime? dateFrom,DateTime? dateTo)
        {
            StringBuilder sbSQL = new StringBuilder( );
            sbSQL.Append( "select a.patlistid,visitno,patname,patsex,age,meditype,cureempcode,curedeptcode,curedate from mz_patlist a" );
            sbSQL.Append( " inner join " );
            sbSQL.Append( "(select patlistid,ticketnum,ticketcode,hang_flag,workid from mz_costmaster where record_flag in (0,1)) b on a.patlistid = b.patlistid" );
            sbSQL.Append( " where a.workid=" + EntityConfig.WorkID + " and b.workid=" + EntityConfig.WorkID);
            if ( InvoiceNo.Trim( ) != "" )
            {
                if ( InvoiceType == OPDBillKind.门诊挂号发票 )
                    sbSQL.Append( " and b.hang_flag = " + (int)OPDOperationType.门诊挂号  );
                else
                    sbSQL.Append( " and b.hang_flag = " + (int)OPDOperationType.门诊收费 );
                sbSQL.Append( " and b.ticketnum='" + InvoiceNo + "'" );
            }

            if ( VisitNo.Trim( ) != "" )
                sbSQL.Append( " and visitno = '" + VisitNo.Trim( ) + "' " );
            if ( PatientName.Trim( ) != "" )
                sbSQL.Append( " and patname like '%" + PatientName.Trim() + "%' " );
            if ( dateFrom != null )
                sbSQL.Append( " and curedate >='"+dateFrom.Value.ToString("yyyy-MM-dd HH:mm:ss")+"' " );
            if ( dateTo != null )
                sbSQL.Append( " and curedate <='" + dateTo.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) + "' " );

            DataTable tb = oleDb.GetDataTable( sbSQL.ToString( ) );
            List<BasePatient> list = new List<BasePatient>( );
            for ( int i = 0 ; i < tb.Rows.Count ; i++ )
            {
                OutPatient patient = new OutPatient( );
                patient.PatListID = Convert.ToInt32( tb.Rows[i]["PatListID"] );
                patient.VisitNo = Convert.ToString( tb.Rows[i]["VisitNo"] );
                patient.PatientName = Convert.ToString( tb.Rows[i]["patname"] );
                patient.Sex = Convert.ToString( tb.Rows[i]["patsex"] );
                patient.Age = Convert.ToInt32( tb.Rows[i]["age"]);
                patient.MediType = Convert.ToString( tb.Rows[i]["meditype"] );
                patient.CureEmpCode = Convert.ToString( tb.Rows[i]["cureempcode"] );
                patient.CureDeptCode = Convert.ToString( tb.Rows[i]["curedeptcode"] );
                patient.CureDate = Convert.ToDateTime( tb.Rows[i]["curedate"] );
                if ( list.Find( delegate( BasePatient p )
                {
                    return p.PatListID == patient.PatListID ? true : false;
                } ) == null )
                {
                    list.Add( patient );
                }
            }
            return list;
        }

                
    }
}
