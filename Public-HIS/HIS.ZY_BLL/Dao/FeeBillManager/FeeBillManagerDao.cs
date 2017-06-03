using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL.Dao.FeeBillManager
{
    public class FeeBillManagerDao:IfeeBillManager
    {
        #region IfeeBillManager 成员

        private string GetstrWhere(DateTime? Bdate, DateTime? Edate)
        {
            string strWhere = null;
            if (OP_ZYConfigSetting.GetConfigValue("003") == 0)
            {
                if (Bdate != null && Edate != null)
                {
                    strWhere = "  AND CHARGE_FLAG = 1 AND  PRESDATE >= '" + Bdate.Value.ToString() + "' AND  PRESDATE <= '" + Edate.Value.ToString() + "' ";
                }
                else
                {
                    strWhere = "  AND CHARGE_FLAG = 1 ";
                }
            }
            else
            {
                if (Bdate != null && Edate != null)
                {
                    strWhere = "  AND CHARGE_FLAG = 1 AND  COSTDATE >= '" + Bdate.Value.ToString() + "' AND  COSTDATE <= '" + Edate.Value.ToString() + "' ";
                }
                else
                {
                    strWhere = "  AND CHARGE_FLAG = 1 ";
                }
            }
            return strWhere;
        }

        public System.Data.DataTable GetPresTotalData(int patlistid, DateTime? Bdate, DateTime? Edate)
        {
            string strWhere = null;

            strWhere = "PATLISTID = " + patlistid + GetstrWhere(Bdate, Edate);
           
            string strsql = @"  select  distinct ITEMID ,PRESTYPE,ITEMNAME,STANDARD,PACKUNIT,UNIT,SELL_PRICE, SUM(AMOUNT)   as amount, SUM(TOLAL_FEE)   as tolal_fee 
                             from {ZY_PRESORDER}  
                             where " + strWhere + @"  
                             Group BY ITEMID,ITEMNAME,STANDARD,PACKUNIT,UNIT,PRESTYPE,SELL_PRICE";

            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetPresTotalData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate)
        {
            string strWhere = null;

            strWhere = "PATLISTID = " + patlistid + " AND PRESDEPTCODE = '" + presdeptcode + "' " + GetstrWhere(Bdate, Edate);
            
            string strsql = @"  select  distinct ITEMID ,PRESTYPE,ITEMNAME,STANDARD,PACKUNIT,UNIT,SELL_PRICE, SUM(AMOUNT)   as amount, SUM(TOLAL_FEE)   as tolal_fee 
                             from {ZY_PRESORDER}  
                             where " + strWhere + @"  
                             Group BY ITEMID,ITEMNAME,STANDARD,PACKUNIT,UNIT,PRESTYPE,SELL_PRICE";

            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetPresTotalGroupData(int patlistid, DateTime? Bdate, DateTime? Edate)
        {
            string strWhere = null;
            strWhere = "PATLISTID = " + patlistid + GetstrWhere(Bdate, Edate);

            string strsql = @"select ITEMTYPE,PRESTYPE,
                                        (select itemname from  (select a.CODE,b.ITEM_NAME as itemname from {base_stat_item as a},{base_stat_zyfp as b} where   a.ZYFP_CODE =b.CODE ) aa  where   aa.code = ITEMTYPE ) itemtypename ,
                                        ITEMID,ITEMNAME,STANDARD,PACKUNIT,UNIT,SELL_PRICE, SUM(AMOUNT) amount , SUM(TOLAL_FEE)   as tolal_fee
                                        from {ZY_PRESORDER}  
                                        where " + strWhere + @"   
                                        group by ITEMTYPE,PRESTYPE,ITEMID,ITEMNAME,STANDARD,PACKUNIT,UNIT,SELL_PRICE  order by itemtypename";

            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetPresTotalGroupData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate)
        {
            string strWhere = null;
            strWhere = "PATLISTID = " + patlistid + " AND PRESDEPTCODE = '" + presdeptcode + "' " + GetstrWhere(Bdate, Edate);
            string strsql = @"select ITEMTYPE,PRESTYPE,
                                        (select itemname from  (select a.CODE,b.ITEM_NAME as itemname from {base_stat_item as a},{base_stat_zyfp as b} where   a.ZYFP_CODE =b.CODE ) aa  where   aa.code = ITEMTYPE ) itemtypename ,
                                        ITEMID,ITEMNAME,STANDARD,PACKUNIT,UNIT,SELL_PRICE, SUM(AMOUNT) amount , SUM(TOLAL_FEE)   as tolal_fee
                                        from {ZY_PRESORDER}  
                                        where " + strWhere + @"   
                                        group by ITEMTYPE,PRESTYPE,ITEMID,ITEMNAME,STANDARD,PACKUNIT,UNIT,SELL_PRICE  order by itemtypename";

            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetCostCalData(int patlistid, DateTime? Bdate, DateTime? Edate)
        {
            string strWhere = null;
            strWhere = "PATLISTID = " + patlistid + GetstrWhere(Bdate, Edate);

            string strsql = @"select itemname, SUM(tolal_fee) tolal_fee  
                                        from  
                                        (
                                        select  
                                        distinct ITEMTYPE ,
                                        (select itemname from  (select a.CODE,b.ITEM_NAME as itemname from {base_stat_item as a},{base_stat_zyfp as b} where   a.ZYFP_CODE =b.CODE ) aa  where   aa.code = ITEMTYPE ) itemname , 
                                        SUM(TOLAL_FEE)   as tolal_fee
                                        from {ZY_PRESORDER} 
                                        where " + strWhere + @"  
                                        Group BY ITEMTYPE    
                                        ) a  group by itemname  ";
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetCostCalData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate)
        {
            string strWhere = null;
            strWhere = "PATLISTID = " + patlistid + " AND PRESDEPTCODE = '" + presdeptcode + "' " + GetstrWhere(Bdate, Edate);

            string strsql = @"select itemname, SUM(tolal_fee) tolal_fee  
                                        from  
                                        (
                                        select  
                                        distinct ITEMTYPE ,
                                        (select itemname from  (select a.CODE,b.ITEM_NAME as itemname from {base_stat_item as a},{base_stat_zyfp as b} where   a.ZYFP_CODE =b.CODE ) aa  where   aa.code = ITEMTYPE ) itemname , 
                                        SUM(TOLAL_FEE)   as tolal_fee
                                        from {ZY_PRESORDER} 
                                        where " + strWhere + @"  
                                        Group BY ITEMTYPE    
                                        ) a  group by itemname  ";
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetCostDayData(int patlistid, DateTime? Bdate, DateTime? Edate)
        {
            string strWhere = null;
            strWhere = "PATLISTID = " + patlistid + GetstrWhere(Bdate, Edate);

            string strsql = @"select itemname, SUM(tolal_fee) tolal_fee  
                                        from  
                                        (
                                        select  
                                        distinct ITEMTYPE ,
                                        (select itemname from  (select a.CODE,b.ITEM_NAME as itemname from {base_stat_item as a},{base_stat_zykj as b} where   a.ZYFP_CODE =b.CODE ) aa  where   aa.code = ITEMTYPE ) itemname , 
                                        SUM(TOLAL_FEE)   as tolal_fee
                                        from {ZY_PRESORDER} 
                                        where " + strWhere + @"  
                                        Group BY ITEMTYPE    
                                        ) a  group by itemname  ";
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetCostDayData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate)
        {
            string strWhere = null;
            strWhere = "PATLISTID = " + patlistid + " AND PRESDEPTCODE = '" + presdeptcode + "' " + GetstrWhere(Bdate, Edate);
            string strsql = @"select itemname, SUM(tolal_fee) tolal_fee  
                                        from  
                                        (
                                        select  
                                        distinct ITEMTYPE ,
                                        (select itemname from  (select a.CODE,b.ITEM_NAME as itemname from {base_stat_item as a},{base_stat_zykj as b} where   a.ZYFP_CODE =b.CODE ) aa  where   aa.code = ITEMTYPE ) itemname , 
                                        SUM(TOLAL_FEE)   as tolal_fee
                                        from {ZY_PRESORDER} 
                                        where " + strWhere + @"  
                                        Group BY ITEMTYPE    
                                        ) a  group by itemname  ";
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetBaseData(int datatype)
        {
            string strsql = null;
            switch (datatype)
            {
                case 0: //药品
                    strsql = "select itemid,d_code,insur_type from {VI_ITEM_ZY_DRUG} ";// oleDb.Table("VI_ITEM_ZY_DRUG", "", "", "itemid", "d_code", "insur_type");
                    return oleDb.GetDataTable(strsql);
                case 1://基本项目
                    strsql = "select itemid,d_code,insur_type from {VI_ITEM_PROJECT} where prestype ='4' ";// oleDb.Table("VI_ITEM_PROJECT", "", "prestype ='4'", "itemid", "d_code", "insur_type");
                    return oleDb.GetDataTable(strsql);
                case 2://组合项目
                    strsql = "select itemid,d_code,insur_type from {VI_ITEM_PROJECT} where prestype ='5' ";// oleDb.Table("VI_ITEM_PROJECT", "", "prestype ='5'", "itemid", "d_code", "insur_type");
                    return oleDb.GetDataTable(strsql);
                case 3://组合项目对应明细
                    strsql = "select * from {BASE_COMPLEX_DETAIL as b} left join {BASE_SERVICE_ITEMS as c} on b.service_item_id=c.item_id order by b.complex_id";
                    return oleDb.GetDataTable(strsql);
            }
            return null;
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
    }
}
