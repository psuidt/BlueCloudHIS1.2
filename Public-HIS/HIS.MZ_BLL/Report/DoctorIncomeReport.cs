using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.MZ_BLL.Report
{
    /// <summary>
    /// 医生收入报表
    /// </summary>
    public class DoctorIncomeReport : BaseReport
    {
        private DataTable _dataResult;
        public override string DataSQL
        {
            get
            {
                StringBuilder sbSQL = new StringBuilder( );
                if ( StatType != StatClassType.收费支付类型 )
                {
                    sbSQL.Append( "select doccode as ID," + base.FieldName + " as code,sum(sub_item_fee) as total_fee " );
                    sbSQL.Append( " from (" + base.BaseSQL + ") a " );
                    sbSQL.Append( " group by doccode," + base.FieldName );
                }
                else
                {
                    sbSQL.Append( "select doccode as ID,'现金' as code, sum(money_fee) as total_fee " );
                    sbSQL.Append( " from (" + base.BaseSQL2 + ") a " );
                    sbSQL.Append( " group by doccode" );
                    sbSQL.Append( " union all " );
                    sbSQL.Append( "select doccode as ID,'POS' as code, sum(pos_fee) as total_fee " );
                    sbSQL.Append( " from (" + base.BaseSQL2 + ") a " );
                    sbSQL.Append( " group by doccode" );
                    sbSQL.Append( " union all " );
                    sbSQL.Append( "select doccode as ID,'医保记账' as code, sum(village_fee) as total_fee " );
                    sbSQL.Append( " from (" + base.BaseSQL2 + ") a " );
                    sbSQL.Append( " group by doccode" );
                    sbSQL.Append( " union all " );
                    sbSQL.Append( "select doccode as ID,'单位记账' as code, sum(self_tally) as total_fee " );
                    sbSQL.Append( " from (" + base.BaseSQL2 + ") a " );
                    sbSQL.Append( " group by doccode" );
                    sbSQL.Append( " union all " );
                    sbSQL.Append( "select doccode as ID,'优惠金额' as code, sum(favor_fee) as total_fee " );
                    sbSQL.Append( " from (" + base.BaseSQL2 + ") a " );
                    sbSQL.Append( " group by doccode" );
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
