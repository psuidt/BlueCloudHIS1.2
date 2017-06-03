using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;

namespace HIS.MZ_BLL.Query
{
    /// <summary>
    /// 发票查询对象
    /// </summary>
    public class InvoiceQuery : BaseQuery
    {
        public InvoiceQuery()
        {
        }
        /// <summary>
        /// 根据挂号流水号获取发票列表
        /// </summary>
        /// <param name="PatListId"></param>
        /// <returns></returns>
        public List<Invoice> GetInvoiceListByPatListId(int PatListId)
        {
            StringBuilder sbSQL = new StringBuilder( );
            sbSQL.Append( "select ticketnum,ticketcode,hang_flag from mz_costmaster where workid=" + EntityConfig.WorkID );
            sbSQL.Append( " and record_flag in (0) " );
            sbSQL.Append( " and patlistid=" + PatListId );

            DataTable tb = oleDb.GetDataTable( sbSQL.ToString( ) );
            List<Invoice> lstInvoice = new List<Invoice>( );
            for ( int i = 0 ; i < tb.Rows.Count ; i++ )
            {
                string ticketnum = tb.Rows[i]["ticketnum"].ToString( );
                string ticketcode = tb.Rows[i]["ticketcode"].ToString( );
                int hang_flag = Convert.ToInt32( tb.Rows[i]["hang_flag"] );
                OPDBillKind kind = ( hang_flag == 0 ? OPDBillKind.门诊挂号发票: OPDBillKind.门诊收费发票);

                Invoice invoice = new Invoice( ticketcode , ticketnum , kind );
                lstInvoice.Add( invoice );
            }
            return lstInvoice;
        }
    }
}
