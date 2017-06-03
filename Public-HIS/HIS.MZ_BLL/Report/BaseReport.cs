using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;

namespace HIS.MZ_BLL.Report
{
    /// <summary>
    /// 基本报表对象
    /// </summary>
    public abstract class BaseReport 
    {
        private string _reportTitle;
        private DateTime _beginDate;
        private DateTime _endDate;
        private StatClassType _statType;
        private StatDateType _statDateType;
        private StatObjctType _statObjectType;
        private string lister;
        private ReportStyle reportstyle;
        private DataTable baseReportData;
        private string accountIdList;
        /// <summary>
        /// 报表标题
        /// </summary>
        public string ReportTitle
        {
            get
            {
                return _reportTitle;
            }
            set
            {
                _reportTitle = value;
            }
        }
        /// <summary>
        /// 报表类型
        /// </summary>
        public ReportStyle Reportstyle
        {
            get
            {
                return reportstyle;
            }
            set
            {
                reportstyle = value;
            }
        }
        /// <summary>
        /// 建表人
        /// </summary>
        public string Lister
        {
            get
            {
                return lister;
            }
            set
            {
                lister = value;
            }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginDate
        {
            get
            {
                return _beginDate;
            }
            set
            {
                _beginDate = value;
            }
        }
        /// <summary>
        /// 结算事件
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
            }
        }
        /// <summary>
        /// 统计类型
        /// </summary>
        public StatClassType StatType
        {
            get
            {
                return _statType; 
            }
            set
            {
                _statType = value;
            }
        }
        /// <summary>
        /// 统计时间类型
        /// </summary>
        public StatDateType StatDateType
        {
            get
            {
                return _statDateType;
            }
            set
            {
                _statDateType = value;
            }
        }
        /// <summary>
        /// 统计对象类型
        /// </summary>
        public StatObjctType StatObjectType
        {
            get
            {
                return _statObjectType;
            }
            set
            {
                _statObjectType = value;
            }
        }
        /// <summary>
        /// 交款ID列表
        /// </summary>
        public string AccountIdList
        {
            get
            {
                return accountIdList;
            }
            set
            {
                accountIdList = value;
            }
        }
        /// <summary>
        /// 分组字段
        /// </summary>
        public string FieldName
        {
            get
            {
                string field = "";
                if ( StatType == StatClassType.门诊发票分类 )
                    field = "mzfp_code";
                else if ( StatType == StatClassType.经管核算分类 )
                    field = "hs_code";
                else if ( StatType == StatClassType.门诊会计分类 )
                    field = "mzkj_code";
                else if ( StatType == StatClassType.统计大项目类 )
                {
                    if ( _statObjectType != StatObjctType.收费员 )
                        field = "bigitemcode";
                    else
                        field = "code";
                }
                else if ( StatType == StatClassType.收费支付类型 )
                    field = "PayName";
                return field;
            }
        }
        /// <summary>
        /// 基本的统计SQL
        /// meditype,ticketnum,ticketcode,doccode,deptcode,total_fee,village_fee,pos_fee,self_tally,money_fee,
        /// bigitemcode,mzfp_code,hs_code,sub_item_fee,hang_flag,record_flag
        /// </summary>
        protected string BaseSQL 
        {
            get
            {
                long workid =  HIS.SYSTEM.Core.EntityConfig.WorkID;
                string begindate = _beginDate.ToString( "yyyy-MM-dd HH:mm:ss" );
                string enddate = _endDate.ToString( "yyyy-MM-dd HH:mm:ss" );
                StringBuilder sbSQL = new StringBuilder( );
                sbSQL.Append( "select meditype,ticketnum,ticketcode,doccode,deptcode,total_fee,village_fee,pos_fee,self_tally,money_fee,favor_fee,bigitemcode,mzfp_code,hs_code,mzkj_code,sub_item_fee,hang_flag,record_flag,accountid" );
                sbSQL.Append( " from " );
                sbSQL.Append( " (  " );
                sbSQL.Append( " select a.patlistid,a.costmasterid,a.ticketnum,a.ticketcode," );
                sbSQL.Append( " a.total_fee,a.village_fee,a.pos_fee ,a.self_tally,(a.total_fee-a.village_fee-a.favor_fee-a.pos_fee-a.self_tally) as money_fee,a.favor_fee," );
                sbSQL.Append( " b.itemtype as bigitemcode,c.mzfp_code,c.mzkj_code,c.hs_code,b.total_fee as sub_item_fee,a.accountid," );
                sbSQL.Append( " a.hang_flag,a.record_flag,a.costdate" );
                sbSQL.Append( " from " );
                sbSQL.Append( " (select * from mz_costmaster where workid=%d1) a," );
                sbSQL.Append( " (select * from mz_costorder where workid=%d1) b," );
                sbSQL.Append( " base_stat_item c" );
                sbSQL.Append( " where a.costmasterid=b.costid and b.itemtype=c.code and record_flag in (0,1,2)" );
                sbSQL.Append( " and a.costdate between '%d2' and '%d3'" );
                if ( _statDateType == StatDateType.交账时间 )
                {
                    sbSQL.Append( " and a.accountid<>0 and a.accountid in ("+accountIdList+") " );
                }
                sbSQL.Append( " ) a1," );
                sbSQL.Append( " (" );
                sbSQL.Append( " select distinct costmasterid," );
                sbSQL.Append( " (select presdoccode from mz_presmaster b where b.workid=%d1 and a.costmasterid = b.costmasterid and b.record_flag in (0,1,2) order by presdoccode fetch first 1 rows only) doccode," );
                sbSQL.Append( " (select presdeptcode from mz_presmaster b where b.workid=%d1 and a.costmasterid = b.costmasterid and b.record_flag in (0,1,2) order by presdeptcode fetch first 1 rows only) deptcode" );
                sbSQL.Append( " from mz_presmaster a " );
                sbSQL.Append( " where workid=%d1 and costmasterid in (select costmasterid from mz_costmaster where workid=%d1 and costdate between '%d2' and '%d3' and record_flag in (0,1,2))" );
                sbSQL.Append( " ) a2 ," );
                sbSQL.Append( " (select patlistid,meditype from mz_patlist where workid=%d1) a3" );
                sbSQL.Append( " where a1.costmasterid = a2.costmasterid and a1.patlistid=a3.patlistid" );

                sbSQL = sbSQL.Replace( "%d1" , workid.ToString( ) ).Replace( "%d2" , begindate ).Replace( "%d3" , enddate );

                return sbSQL.ToString( );
            }
        }
        /// <summary>
        /// 基本的统计SQL
        /// meditype,ticketnum,ticketcode,doccode,deptcode,total_fee,village_fee,pos_fee,self_tally,money_fee,
        /// bigitemcode,mzfp_code,hs_code,sub_item_fee,hang_flag,record_flag
        /// </summary>
        protected string BaseSQL2
        {
            get
            {
                long workid = HIS.SYSTEM.Core.EntityConfig.WorkID;
                string begindate = _beginDate.ToString( "yyyy-MM-dd HH:mm:ss" );
                string enddate = _endDate.ToString( "yyyy-MM-dd HH:mm:ss" );
                StringBuilder sbSQL = new StringBuilder( );
                sbSQL.Append( "select meditype,ticketnum,ticketcode,doccode,deptcode,chargecode,total_fee,village_fee,pos_fee,self_tally,money_fee,favor_fee,hang_flag,record_flag,accountid" );
                sbSQL.Append( " from " );
                sbSQL.Append( " (  " );
                sbSQL.Append( " select a.patlistid,a.costmasterid,a.ticketnum,a.ticketcode,chargecode," );
                sbSQL.Append( " a.total_fee,a.village_fee,a.pos_fee ,a.self_tally,(a.total_fee-a.village_fee-a.favor_fee-a.pos_fee-a.self_tally) as money_fee,a.favor_fee," );
                sbSQL.Append( " a.accountid,a.hang_flag,a.record_flag,a.costdate" );
                sbSQL.Append( " from " );
                sbSQL.Append( " mz_costmaster as a " );
                sbSQL.Append( " where  workid=%d1 and record_flag in (0,1,2)" );
                sbSQL.Append( " and a.costdate between '%d2' and '%d3'" );
                if ( _statDateType == StatDateType.交账时间 )
                {
                    sbSQL.Append( " and a.accountid<>0 and a.accountid in (" + accountIdList + ") " );
                }
                sbSQL.Append( " ) a1," );
                sbSQL.Append( " (" );
                sbSQL.Append( " select distinct costmasterid," );
                sbSQL.Append( " (select presdoccode from mz_presmaster b where b.workid=%d1 and a.costmasterid = b.costmasterid and b.record_flag in (0,1,2) order by presdoccode fetch first 1 rows only) doccode," );
                sbSQL.Append( " (select presdeptcode from mz_presmaster b where b.workid=%d1 and a.costmasterid = b.costmasterid and b.record_flag in (0,1,2) order by presdeptcode fetch first 1 rows only) deptcode" );
                sbSQL.Append( " from mz_presmaster a " );
                sbSQL.Append( " where workid=%d1 and costmasterid in (select costmasterid from mz_costmaster where workid=%d1 and costdate between '%d2' and '%d3' and record_flag in (0,1,2))" );
                sbSQL.Append( " ) a2 ," );
                sbSQL.Append( " (select patlistid,meditype from mz_patlist where workid=%d1) a3" );
                sbSQL.Append( " where a1.costmasterid = a2.costmasterid and a1.patlistid=a3.patlistid" );

                sbSQL = sbSQL.Replace( "%d1" , workid.ToString( ) ).Replace( "%d2" , begindate ).Replace( "%d3" , enddate );

                return sbSQL.ToString( );
            }
        }
        /// <summary>
        /// 基本的报表数据
        /// </summary>
        public DataTable BaseReportData
        {
            get
            {
                return baseReportData;
            }
            set
            {
                baseReportData = value;
            }
        }
        /// <summary>
        /// 数据获取SQL
        /// </summary>
        public abstract string DataSQL
        {
            get;
        }
        /// <summary>
        /// 经过整理排列的表数据
        /// </summary>
        public abstract DataTable DataResult
        {
            get;
            set;
        }

    }
}
