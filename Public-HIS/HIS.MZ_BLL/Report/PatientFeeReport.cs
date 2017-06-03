using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.MZ_BLL.Report
{
    public class PatientFeeReport : BaseReport
    {
        private  System.Data.DataTable _dataResult;
        private string patientTypeCode;
        private OPDBillKind invoiceType;
        private string curDocName;
        private string curDeptName;
        private string chargeName;

        public string ChargeName
        {
            get
            {
                return chargeName;
            }
            set
            {
                chargeName = value;
            }
        }

        public string CurDeptName
        {
            get
            {
                return curDeptName;
            }
            set
            {
                curDeptName = value;
            }
        }

        public string CurDocName
        {
            get
            {
                return curDocName;
            }
            set
            {
                curDocName = value;
            }
        }

        public string PatientTypeCode
        {
            get
            {
                return patientTypeCode;
            }
            set
            {
                patientTypeCode = value;
            }
        }

        public OPDBillKind InvoiceType
        {
            get
            {
                return invoiceType;
            }
            set
            {
                invoiceType = value;
            }
        }

        public override string DataSQL
        {
            get
            {
                string workId = EntityConfig.WorkID.ToString( ); // %d1
                string begindate = BeginDate.ToString( "yyyy-MM-dd HH:mm:ss" ); //%d2
                string enddate = EndDate.ToString( "yyyy-MM-dd HH:mm:ss" ); //%d3

                StringBuilder sbSQL1 = new StringBuilder( );
                sbSQL1.Append( " select a.patlistid,b.patname,b.meditype,a.ticketnum,c.name as empname,d.name as deptname,e.name as chargename,a.ticketcode,a.hang_flag ,a.costdate," );
                sbSQL1.Append( " a.total_fee,a.village_fee,a.pos_fee ,a.self_tally, " );
                sbSQL1.Append( " (a.total_fee-a.village_fee-a.favor_fee-a.pos_fee-a.self_tally) as money_fee,a.favor_fee " );
                sbSQL1.Append( " from mz_costmaster a " );
                sbSQL1.Append( " left join mz_patlist b " );
                sbSQL1.Append( " on a.patlistid = b.patlistid and a.workid=b.workid " );
                sbSQL1.Append(" left join base_employee_property c on b.cureempcode = cast(c.employee_id as char(5)) " );
                sbSQL1.Append(" left join base_dept_property d on b.curedeptcode = cast(d.dept_id as char(5)) " );
                sbSQL1.Append(" left join base_employee_property e on a.chargecode = cast(e.employee_id as char(5)) " );
                sbSQL1.Append( " where a.workid=%d1 and b.workid=%d1" );
                sbSQL1.Append( " and a.record_flag in (0,1,2) " );
                sbSQL1.Append( " and a.costdate between '%d2' and '%d3'" );
                if ( StatDateType == StatDateType.交账时间 )
                    sbSQL1.Append( " and a.accountid<>0 and a.accountid in (" + AccountIdList + ") " );


                StringBuilder sbSQL2 = new StringBuilder( );
                string AA2_Fields = "";
                sbSQL2.Append( " select a.patlistid,a.ticketnum,a.ticketcode," );
                
                for ( int i = 0; i < BaseDataController.BaseDataSet[BaseDataCatalog.门诊发票科目].Rows.Count; i++ )
                {
                    string mzfp_code = BaseDataController.BaseDataSet[BaseDataCatalog.门诊发票科目].Rows[i][Tables.base_stat_mzfp.CODE].ToString().Trim();
                    string mzfp_name = BaseDataController.BaseDataSet[BaseDataCatalog.门诊发票科目].Rows[i][Tables.base_stat_mzfp.ITEM_NAME].ToString().Trim();
                    AA2_Fields = AA2_Fields + mzfp_name.Trim() + ",";
                    sbSQL2.Append( "sum( case when c.mzfp_code='" + mzfp_code + "' then b.total_fee else 0 end) as " + mzfp_name + "," );
                }
                AA2_Fields = AA2_Fields.Remove( AA2_Fields.Length - 1 , 1 );

                sbSQL2.Append( " a.hang_flag " );
                sbSQL2.Append( " from mz_costmaster a, mz_costorder b, base_stat_item c" );
                sbSQL2.Append( " where a.costmasterid = b.costid and b.itemtype=c.code and a.workid=b.workid" );
                sbSQL2.Append( " and a.workid=%d1 and b.workid=%d1" );
                sbSQL2.Append( " and a.record_flag in (0,1,2) " );
                sbSQL2.Append( " and a.costdate between '%d2' and '%d3'" );
                if ( StatDateType == StatDateType.交账时间 )
                    sbSQL2.Append( " and a.accountid<>0 and a.accountid in (" + AccountIdList + ") " );

                sbSQL2.Append( " group by a.patlistid,a.hang_flag,a.ticketnum,a.ticketcode " );

                StringBuilder sbSQL3 = new StringBuilder( );
                sbSQL3.Append( " select " );
                sbSQL3.Append( " AA1.patname as 病人姓名," );
                sbSQL3.Append( " AA3.name as 类型," );
                sbSQL3.Append( " aa1.empname as 医生, aa1.deptname as 科室,aa1.chargename as 收费员, " );
                sbSQL3.Append( " AA1.ticketnum as 发票号," );
                sbSQL3.Append( " AA1.costdate as 收费时间," );
                sbSQL3.Append( " AA1.total_fee as 总金额," );
                sbSQL3.Append( " AA1.village_fee 医保记账," );
                sbSQL3.Append( " AA1.pos_fee POS记账," );
                sbSQL3.Append( " AA1.self_tally as 单位记账," );
                sbSQL3.Append( " AA1.money_fee as 现金支付," );
                sbSQL3.Append( " AA1.favor_fee as 优惠金额," );
                sbSQL3.Append( AA2_Fields );
                
                sbSQL3.Append( " from " );
                sbSQL3.Append( "(" + sbSQL1.ToString( ) + ") AA1 " );
                sbSQL3.Append( " inner join " );
                sbSQL3.Append( "(" + sbSQL2.ToString( ) + ") AA2 " );
                sbSQL3.Append( " on AA1.patlistid=AA2.patlistid" );
                sbSQL3.Append( " and aa1.ticketnum = aa2.ticketnum" );
                sbSQL3.Append( " and aa1.ticketcode = aa2.ticketcode" );
                sbSQL3.Append( " and aa1.hang_flag = aa2.hang_flag" );
                sbSQL3.Append( " left join base_patienttype AA3 on AA1.meditype = AA3.code" );
                sbSQL3.Append( " where 1=1 " );

                if ( patientTypeCode.Trim( ) != "" )
                    sbSQL3.Append( " and AA1.meditype='" + patientTypeCode + "'" );

                if ( invoiceType == OPDBillKind.门诊挂号发票 )
                    sbSQL3.Append( " and AA1.hang_flag = 0 " );
                else if ( invoiceType == OPDBillKind.门诊收费发票 )
                    sbSQL3.Append( " and AA1.hang_flag = 1 " );
                else
                    sbSQL3.Append( "" );

                if ( !System.String.IsNullOrEmpty( curDocName.Trim() ) )
                {
                    sbSQL3.Append( " and aa1.empname ='"+curDocName+"'");
                }
                if ( !System.String.IsNullOrEmpty( curDeptName.Trim() ) )
                {
                    sbSQL3.Append( " and aa1.deptname = '" + curDeptName + "'");
                }
                if ( !System.String.IsNullOrEmpty( chargeName.Trim() ) )
                {
                    sbSQL3.Append( " and aa1.chargename = '" + chargeName + "'" );
                }


                sbSQL3 = sbSQL3.Replace( "%d1" , workId ).Replace( "%d2" , begindate ).Replace( "%d3" , enddate );

                return sbSQL3.ToString( );

            }
        }

        public override System.Data.DataTable DataResult
        {
            get
            {
                return _dataResult;
            }
            set
            {
                _dataResult = value;
            }
        }
    }
}
