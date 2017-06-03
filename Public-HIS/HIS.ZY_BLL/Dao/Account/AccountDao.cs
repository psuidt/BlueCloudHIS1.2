using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL.Dao.Account
{
    public class AccountDao:IaccountDao
    {
        

        public System.Data.DataTable GetAllCharge(string ChargeCode)
        {
            string strsql = @" select typename, SUM(TOTAL_FEE) tol_fee , Count(distinct BILLNO) count 
                                        from  
                                        (select BILLNO,
                                        (case   WHEN RECORD_FLAG =2 and TOTAL_FEE < 0 then '退费'   ELSE '正常'  end)typename,
                                        total_fee,
                                        accountid 
                                        from {ZY_CHARGELIST} 
                                        where   ACCOUNTID = 0 and CHARGECODE ='" + ChargeCode + @"' ) a group by typename ";

            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetAllCost(string ChargeCode)
        {
            string sqlstr = @" select typename, SUM(a.REALITY_FEE) tol_fee , Count(distinct TICKETNUM) count  
                                    from  
                                    (select REALITY_FEE,TICKETNUM,(case   WHEN REALITY_FEE >= 0 then '结补'    ELSE  '结退'   end)typename 
                                    from {ZY_COSTMASTER} 
                                    where   ACCOUNTID =0 and CHARGECODE = '" + ChargeCode + "' ) a  Group BY a.typename  ";

            return oleDb.GetDataTable(sqlstr);
        }

        public System.Data.DataTable GetBIGItemData(string[] AccountID)
        {
            string strsql = @"select  
                                (select ITEM_NAME from {BASE_STAT_ITEM} where   CODE = bigitemcode ) itemname , 
                                SUM(total_fee) total_fee 
                                from {ZY_COSTORDER}  
                                where costid IN  (select COSTMASTERID from {ZY_COSTMASTER} where   ACCOUNTID " + oleDb.In(AccountID) + " )   group by BIGITEMCODE ";
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetVillage_Fee(int AccountID)
        {
            string strsql = @" select  SUM(VILLAGE_FEE) VILLAGE_FEE ,VILLAGE_TYPE from {ZY_COSTMASTER}  where ACCOUNTID =" + AccountID + " group by VILLAGE_TYPE ";
            return oleDb.GetDataTable(strsql);
        }

        public decimal GetAllChargeFee(DateTime Bdate, DateTime Edate)
        {
            string strsql = @"select sum(c.total_fee) as total_fee from  {zy_account as a}, {zy_costmaster as b}, {zy_costorder as c} where 
                            DATE(a.ACCOUNTDATE) >= '" + Bdate.Date + @"' AND  DATE(a.ACCOUNTDATE) <= '" + Edate.Date + @"' AND 
                            a.accountid = b.accountid AND b.costmasterid = c.costid ";

            object obj = oleDb.GetDataResult(strsql);
            if (obj == null || obj == DBNull.Value)
                return 0;
            return Convert.ToDecimal(obj);
        }

        public decimal GetAllChargeFee(DateTime Bdate, DateTime Edate, List<HIS.ZY_BLL.DataModel.ZY_Account> zylist)
        {
            string where = " and a.accountid in (";
            for (int i = 0; i < zylist.Count; i++)
            {
                if (i == zylist.Count - 1)
                {
                    where += zylist[i].AccountID.ToString();
                }
                else
                    where += zylist[i].AccountID.ToString() + ",";
            }
            where += ")";
            string strsql = @"select sum(c.total_fee) as total_fee from  {zy_account as a}, {zy_costmaster as b}, {zy_costorder as c} where 
                            DATE(a.ACCOUNTDATE) >= '" + Bdate.Date + @"' AND  DATE(a.ACCOUNTDATE) <= '" + Edate.Date + @"' " + where + @" AND 
                            a.accountid = b.accountid AND b.costmasterid = c.costid ";

            object obj = oleDb.GetDataResult(strsql);
            if (obj == null || obj == DBNull.Value)
                return 0;
            return Convert.ToDecimal(obj);
        }

        public System.Data.DataTable GetAccountDeptOrderData(int AccountID)
        {
            string sql_itemdt = @"select  
                                    (select (select name from {BASE_DEPT_PROPERTY} where dept_id=int(aa.curedeptcode) ) from {zy_patlist as aa} where patlistid=a.patlistid ) deptname,
                                    (select item_name from {base_stat_item} where code= b.bigitemcode) itemname,
                                    sum(b.total_fee) total_fee 
                                from {ZY_COSTMASTER as a} 
                                left join {zy_costorder as b} on a.costmasterid=b.costid 
                                where a.accountid=" + AccountID + " group by  a.patlistid,b.bigitemcode";
            return oleDb.GetDataTable(sql_itemdt);
        }


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
    }
}
