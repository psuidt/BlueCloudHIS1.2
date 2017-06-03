using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL.Dao.Report
{
    public class ReportDao : Ireport
    {
        #region Ireport 成员

        public System.Data.DataTable CLoadOperationData(DateTime Bdate, DateTime Edate)
        {
            string strsql = @"select table1.PATLISTID,PatName,table3.CureDocCode, ITEMTYPE, tolal_fee, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE 
                                    from (
                                    select  PATLISTID,PATID, ITEMTYPE, sum(TOLAL_FEE) tolal_fee, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE
                                    from {ZY_PRESORDER}
                                    where COSTDATE>='" + Bdate.ToString() + @"' and COSTDATE<='" + Edate.ToString() + @"' and charge_flag=1 
                                    group by PATLISTID, PATID, ITEMTYPE, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE order by patlistid
                                    ) table1 
                                    left join {PATIENTINFO as table2} on table1.patid=table2.patid
                                    left join {zy_PatList as table3} on table1.patlistid=table3.patlistid";
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable TLoadOperationData(DateTime Bdate, DateTime Edate)
        {
            string strsql = @"select table1.PATLISTID,PatName,table3.CureDocCode, ITEMTYPE, tolal_fee, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE 
                                        from (
                                        select PATLISTID, PATID, ITEMTYPE, sum(TOLAL_FEE) tolal_fee, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE 
                                        from {zy_presorder} 
                                        where charge_flag=1 and  costmasterid in ( select costmasterid from {zy_costmaster} where COSTDATE>='" + Bdate.ToString() + @"' and COSTDATE<='" + Edate.ToString() + @"' )
                                        group by PATLISTID,PATID,  ITEMTYPE, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE 
                                        order by patlistid
                                        ) table1 
                                        left join {PATIENTINFO as table2} on table1.patid=table2.patid
                                        left join {zy_PatList as table3} on table1.patlistid=table3.patlistid";
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GLoadOperationData(DateTime Bdate, DateTime Edate)
        {
            string strsql = @"select table1.PATLISTID,PatName,table3.CureDocCode, ITEMTYPE, tolal_fee, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE from (
                            select * from (
                            select PATLISTID, PATID, ITEMTYPE, sum(TOLAL_FEE) tolal_fee, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE from {zy_presorder} where   charge_flag=1 and  costmasterid in 
                            (select costmasterid from zy_costmaster where AccountID in 
                            (select accountid from {zy_account} where ACCOUNTDATE>='" + Bdate.ToString() + @"' and ACCOUNTDATE<='" + Edate.ToString() + @"'))
                             group by PATLISTID,PATID,  ITEMTYPE, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE order by patlistid
                             ) a
                            UNION ALL
                            (
                            select PATLISTID, PATID, ITEMTYPE, sum(TOLAL_FEE) tolal_fee, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE from {zy_presorder} where  charge_flag=1 and  patlistid in (
                            select patlistid from {zy_costmaster} where AccountID in (select accountid from {zy_account} where ACCOUNTDATE>='" + Bdate.ToString() + @"' and ACCOUNTDATE<='" + Edate.ToString() + @"') and record_flag=1 )
                            group by PATLISTID,PATID,  ITEMTYPE, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE order by patlistid
                            ) 
                            UNION ALL
                            (
                            select PATLISTID, PATID, ITEMTYPE, (0-sum(TOLAL_FEE)) tolal_fee, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE from {zy_presorder} where  charge_flag=1 and  patlistid in (
                            select patlistid from {zy_costmaster} where AccountID in (select accountid from {zy_account} where ACCOUNTDATE>='" + Bdate.ToString() + @"' and ACCOUNTDATE<='" + Edate.ToString() + @"') and record_flag=2 )
                            group by PATLISTID,PATID,  ITEMTYPE, PRESDEPTCODE, PRESDOCCODE, EXECDEPTCODE order by patlistid
                            ) 
                             ) table1 left join {PATIENTINFO as table2} on table1.patid=table2.patid
                                      left join {zy_PatList as table3} on table1.patlistid=table3.patlistid";
            return oleDb.GetDataTable(strsql);
        }

        #endregion

        #region IbaseDao 成员

        private HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _oleDb;
        public HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb
        {
            get
            {
                return _oleDb;
            }
            set
            {
                _oleDb = value;
            }
        }

        #endregion

        #region Ireport 成员


        public System.Data.DataTable GetRegisterPatientData(DateTime dateBegin, DateTime dateEnd)
        {
            string dateFormat = "yyyy-MM-dd HH:mm:ss";
            string sql = @"select count(PatlistID) as regnum,curedate presdate, CUREDOCCODE presdoccode, CUREDEPTCODE presdeptcode 
                            from
                            ( 	
	                         select PatlistID,curedate,CUREDEPTCODE,CUREDOCCODE  from {zy_patlist} where pattype!='6' and curedate between '" + dateBegin.ToString(dateFormat) + @"' and '" + dateEnd.ToString(dateFormat) + @"'
                            ) aa group by curedate,CUREDEPTCODE,CUREDOCCODE ";

            return oleDb.GetDataTable(sql); 
        }

       

        public System.Data.DataTable GetInPatinetData(string deptcode)
        {
            string strsql = null;
            if (deptcode != "-1")
            {
                strsql = @"select cureno,patname,deptname,docname,curedate,sum(presorder_fee) as presorderfee ,sum(chargelist_fee) as chargelistfee,sum(presorder_fee)-sum(chargelist_fee) as ye from 
                                (select a.cureno,b.patname,c.name as deptname,d.name as docname,a.curedate,
                                (select case when sum(e.tolal_fee) is null then 0 else sum(e.tolal_fee) end from {zy_presorder as e} where e.patlistid=a.patlistid and e.charge_flag=1 and e.costmasterid=0) as presorder_fee,
								(select case when sum(f.total_fee) is null then 0 else sum(f.total_fee) end  from {zy_chargelist as f} where a.patlistid=f.patlistid) as chargelist_fee
                                from
                                {zy_patlist as a} 
                                left join {PATIENTINFO as b} on a.patid=b.patid
                                left join {BASE_DEPT_PROPERTY as c} on a.currdeptcode=cast(dept_id as char(20))
                                left join {BASE_EMPLOYEE_PROPERTY as d} on a.CUREDOCCODE=cast(d.EMPLOYEE_ID as char(20))
                                where a.pattype in ('1','2','3','7') and a.currdeptcode='" + deptcode + @"' ) as A group by cureno,patname,deptname,docname,curedate ";
            }
            else
            {
                strsql = @"select cureno,patname,deptname,docname,curedate,sum(presorder_fee) as presorderfee ,sum(chargelist_fee) as chargelistfee,sum(presorder_fee)-sum(chargelist_fee) as ye from 
                                (select a.cureno,b.patname,c.name as deptname,d.name as docname,a.curedate,
                                (select case when sum(e.tolal_fee) is null then 0 else sum(e.tolal_fee) end from {zy_presorder as e} where e.patlistid=a.patlistid and e.charge_flag=1 and e.costmasterid=0) as presorder_fee,
								(select case when sum(f.total_fee) is null then 0 else sum(f.total_fee) end  from {zy_chargelist as f} where a.patlistid=f.patlistid) as chargelist_fee
                                from
                                {zy_patlist as a} 
                                left join {PATIENTINFO as b} on a.patid=b.patid
                                left join {BASE_DEPT_PROPERTY as c} on a.currdeptcode=cast(dept_id as char(20))
                                left join {BASE_EMPLOYEE_PROPERTY as d} on a.CUREDOCCODE=cast(d.EMPLOYEE_ID as char(20))
                                where a.pattype in ('1','2','3','7') ) as A group by cureno,patname,deptname,docname,curedate ";
            }
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetOutPatinetData(string deptcode, DateTime Bdate, DateTime Edate)
        {
            string strsql = null;
            if (deptcode != "-1")
            {
                strsql = @"select a.out_flag as out_flag,a.cureno,b.patname,c.name as deptname,d.name as docname,a.outdate,(a.outdate-a.curedate) as days,sum(e.total_fee) total_fee,sum(e.DEPTOSIT_FEE) DEPTOSIT_FEE, sum(e.REALITY_FEE) as REALITY_FEE,sum(e.VILLAGE_FEE) VILLAGE_FEE, sum (e.FAVOR_FEE) as FAVOR_FEE  from 
                                {zy_patlist as a} 
                                left join {PATIENTINFO as b} on a.patid=b.patid
                                left join {BASE_DEPT_PROPERTY as c} on a.currdeptcode=cast(dept_id as char(20))
                                left join {BASE_EMPLOYEE_PROPERTY as d} on a.CUREDOCCODE=cast(d.EMPLOYEE_ID as char(20))
                                left join {zy_costmaster as e} on a.patlistid=e.patlistid
                                where a.pattype in ('4','5') and e.RECORD_FLAG=0 and a.currdeptcode='" + deptcode + @"' and a.outdate>='" + Bdate + @"' and a.outdate<='" + Edate + @"'
                                group by a.cureno,b.patname,c.name,d.name,a.outdate,a.curedate,a.out_flag";
            }
            else
            {
                strsql = @"select a.out_flag as out_flag,a.cureno,b.patname,c.name as deptname,d.name as docname,a.outdate,(a.outdate-a.curedate) as days,sum(e.total_fee) total_fee,sum(e.DEPTOSIT_FEE) DEPTOSIT_FEE, sum(e.REALITY_FEE) as REALITY_FEE,sum(e.VILLAGE_FEE) VILLAGE_FEE, sum (e.FAVOR_FEE) as FAVOR_FEE  from 
                                {zy_patlist as a} 
                                left join {PATIENTINFO as b} on a.patid=b.patid
                                left join {BASE_DEPT_PROPERTY as c} on a.currdeptcode=cast(dept_id as char(20))
                                left join {BASE_EMPLOYEE_PROPERTY as d} on a.CUREDOCCODE=cast(d.EMPLOYEE_ID as char(20))
                                left join {zy_costmaster as e} on a.patlistid=e.patlistid
                                where a.pattype in ('4','5') and e.RECORD_FLAG=0 and a.outdate>='" + Bdate + @"' and a.outdate<='" + Edate + @"'
                                group by a.cureno,b.patname,c.name,d.name,a.outdate,a.curedate,a.out_flag";
            }
            return oleDb.GetDataTable(strsql);
        }

        #endregion
    }
}
