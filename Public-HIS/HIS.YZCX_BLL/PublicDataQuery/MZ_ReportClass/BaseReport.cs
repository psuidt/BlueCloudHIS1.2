using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;

namespace HIS.YZCX_BLL
{
    public abstract class BaseReport 
    {
        private string _reportTitle;
        private DateTime _beginDate;
        private DateTime _endDate;
        protected StatClassType _statType;
        protected StatDateType _statDateType;
        private StatObjctType _statObjectType;
        private string lister;
        private ReportStyle reportstyle;
        private DataTable baseReportData;
        protected string accountIdList;

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
                long workid = HIS.SYSTEM.Core.EntityConfig.WorkID;
                string begindate = _beginDate.ToString("yyyy-MM-dd HH:mm:ss");
                string enddate = _endDate.ToString("yyyy-MM-dd HH:mm:ss");
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select pattype as meditype,ticketnum,'' as ticketcode,presdoccoe as doccode,presdeptcode as deptcode,");
                strSql.Append("village_fee,pos_fee,self_tally,money_fee,favor_fee,itemcode as bigitemcode,fpcode as mzfp_code,");
                strSql.Append("hscode as hs_code,kjcode as mzkj_code, item_fee as sub_item_fee,hang_flag,record_flag");
                strSql.Append(" from yzcx_mz_cost left outer join (select costmasterid, accountid from mz_costmaster)");
                strSql.Append("as A on yzcx_mz_cost.cost_masterid=A.costmasterid");
                strSql.Append(" where cost_date between '%d2' and '%d3' and workid=%d1");
                if (_statDateType == StatDateType.交账时间)
                {
                    strSql.Append(" and A.accountid<>0 and A.accountid in (" + accountIdList + ") ");
                }
                strSql = strSql.Replace("%d1", workid.ToString()).Replace("%d2", begindate).Replace("%d3", enddate);
                return strSql.ToString();
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
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select distinct B.* from");
                strSql.Append("(select pattype as meditype,ticketnum,'' as ticketcode,presdoccoe as doccode,presdeptcode as deptcode,");
                strSql.Append("charge_code,total_fee,village_fee,pos_fee,self_tally,money_fee,favor_fee,hang_flag,record_flag,A.accountid");
                strSql.Append(" from yzcx_mz_cost left outer join (select costmasterid, accountid from mz_costmaster)");
                strSql.Append("as A on yzcx_mz_cost.cost_masterid=A.costmasterid");
                strSql.Append(" where cost_date between '%d2' and '%d3' and workid=%d1");
                if (_statDateType == StatDateType.交账时间)
                {
                    strSql.Append(" and A.accountid<>0 and A.accountid in (" + accountIdList + "))as B ");
                }
                else
                {
                    strSql.Append(")as B");
                }
                strSql = strSql.Replace("%d1", workid.ToString()).Replace("%d2", begindate).Replace("%d3", enddate);
                return strSql.ToString();
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
