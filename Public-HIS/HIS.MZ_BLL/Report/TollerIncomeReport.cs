using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.MZ_BLL.Report
{
    public class TollerIncomeReport : BaseReport
    {
        private DataTable _dataResult;
        public override string DataSQL
        {
            get
            {
                StringBuilder sbSQL = new StringBuilder( );
                if ( StatType != StatClassType.收费支付类型 )
                {
                    sbSQL.Append("select a.chargecode as ID,c." + base.FieldName + " as code ,sum(b.total_fee) as total_fee ");
                    sbSQL.Append( " from " );
                    sbSQL.Append(" (select ticketnum,costmasterid,chargecode,costdate,record_flag,accountid from mz_costmaster) a,");
                    sbSQL.Append( " (select costid,itemtype as bigitemcode,total_fee from mz_costorder) b , " );
                    sbSQL.Append( " base_stat_item c  " );
                    sbSQL.Append( " where a.costmasterid=b.costid and b.bigitemcode=c.code " );
                    if ( StatDateType == StatDateType.交账时间 )
                    {
                        sbSQL.Append( " and a.accountid<>0 and a.accountid in (" + AccountIdList + ") " );
                    }
                    sbSQL.Append( " and a.costdate between '" + BeginDate.ToString( "yyyy-MM-dd HH:mm:ss" ) + "' and '" + EndDate.ToString( "yyyy-MM-dd HH:mm:ss" ) + "' and a.record_flag in (0,1,2)  " );
                    sbSQL.Append( " group by a.chargecode,c."+base.FieldName );
                }
                else
                {
                    sbSQL.Append( "select chargecode as ID,'现金' as code, sum(money_fee) as total_fee " );
                    sbSQL.Append( " from (" + base.BaseSQL2 + ") a " );
                    sbSQL.Append( " group by chargecode" );
                    sbSQL.Append( " union all " );
                    sbSQL.Append( "select chargecode as ID,'POS' as code, sum(pos_fee) as total_fee " );
                    sbSQL.Append( " from (" + base.BaseSQL2 + ") a " );
                    sbSQL.Append( " group by chargecode" );
                    sbSQL.Append( " union all " );
                    sbSQL.Append( "select chargecode as ID,'医保记账' as code, sum(village_fee) as total_fee " );
                    sbSQL.Append( " from (" + base.BaseSQL2 + ") a " );
                    sbSQL.Append( " group by chargecode" );
                    sbSQL.Append( " union all " );
                    sbSQL.Append( "select chargecode as ID,'单位记账' as code, sum(self_tally) as total_fee " );
                    sbSQL.Append( " from (" + base.BaseSQL2 + ") a " );
                    sbSQL.Append( " group by chargecode" );
                    sbSQL.Append( " union all " );
                    sbSQL.Append( "select chargecode as ID,'优惠金额' as code, sum(favor_fee) as total_fee " );
                    sbSQL.Append( " from (" + base.BaseSQL2 + ") a " );
                    sbSQL.Append( " group by chargecode" );
                }

                return sbSQL.ToString( );
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
