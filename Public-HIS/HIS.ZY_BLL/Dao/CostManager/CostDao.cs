using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.ObjectModel;

namespace HIS.ZY_BLL.Dao.CostManager
{
    public class CostDao:IcostDao
    {
        

        public decimal[] GetMenoyAndPosFee(string ChargeCode)
        {
            decimal[] dec = new decimal[5];

            string strWhere = "ACCOUNTID = 0 and CHARGECODE = '" + ChargeCode + "' ";
            dec[0] = Convert.ToDecimal(BindEntity<HIS.ZY_BLL.DataModel.ZY_CostMaster>.CreateInstanceDAL(oleDb).GetSum("MONEY_FEE", strWhere));
            dec[1] = Convert.ToDecimal(BindEntity<HIS.ZY_BLL.DataModel.ZY_CostMaster>.CreateInstanceDAL(oleDb).GetSum("POS_FEE", strWhere));
            dec[2] = Convert.ToDecimal(BindEntity<HIS.ZY_BLL.DataModel.ZY_CostMaster>.CreateInstanceDAL(oleDb).GetSum("VILLAGE_FEE", strWhere));
            dec[3] = Convert.ToDecimal(BindEntity<HIS.ZY_BLL.DataModel.ZY_CostMaster>.CreateInstanceDAL(oleDb).GetSum("FAVOR_FEE", strWhere));
            dec[4] = Convert.ToDecimal(BindEntity<HIS.ZY_BLL.DataModel.ZY_CostMaster>.CreateInstanceDAL(oleDb).GetSum("DEPTOSIT_FEE", strWhere));
            return dec;
        }

      
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

        public System.Data.DataTable GetDetailCharge(string ChargeCode, int feeType)
        {
            string strsql = null;
            string strWhere = null;

            if (feeType == 0)
            {
                strWhere = "ACCOUNTID = 0 and CHARGECODE = '" + ChargeCode + "' and REALITY_FEE >= 0 ";

            }
            else if (feeType == 1)
            {
                strWhere = "ACCOUNTID = 0 and CHARGECODE ='" + ChargeCode + "' and REALITY_FEE < 0 ";
            }
            strsql = @" select 
                            TICKETCODE as BILLNO,
                            COSTDATE,
                            REALITY_FEE as TOTAL_FEE,
                            (select CURENO from {PATIENTINFO} where   PATID =a.PATID ) CURENO , 
                            (select PATNAME from {PATIENTINFO} where   PATID =a.PATID ) PATNAME , 
                            (select NAME from {BASE_DEPT_PROPERTY} where   DEPT_ID = CAST( (select (case   WHEN CUREDEPTCODE ='' then '0'    ELSE CUREDEPTCODE  end) from {ZY_PATLIST} where   PATLISTID =a.PATLISTID )   as bigint)  ) CUREDEPTCODE 
                            from {zy_costmaster as a}  
                            where " + strWhere;

            return oleDb.GetDataTable(strsql);
        }

   


        public void UpdateAccount(string ChargeCode, int ID)
        {
            string strwhere = "ACCOUNTID = 0 and CHARGECODE ='" + ChargeCode + "'";
            string str = "ACCOUNTID =" + ID;
            BindEntity<HIS.ZY_BLL.DataModel.ZY_CostMaster>.CreateInstanceDAL(oleDb).Update(strwhere, str);
        }




        public System.Data.DataTable GetTicketTotle(int AccountID)
        {
            string strsql = @"select itemname,sum(tolal_fee) as tolal_fee 
                            from  
                            (select  (select  itemname  from  (select a.CODE,b.ITEM_NAME as itemname from {base_stat_item as a},{base_stat_zyfp as b} where   a.ZYFP_CODE = b.code ) aa  where    aa.code   =  BIGITEMCODE  ) itemname , 
                            SUM(TOTAL_FEE)   as tolal_fee 
                            from {ZY_COSTORDER}
                            where   COSTID  IN( (select COSTMASTERID from {ZY_COSTMASTER} where   ACCOUNTID ="+AccountID+@" )  ) 
                            Group BY BIGITEMCODE ) a  group by itemname  ";
            //strsql = String.Format(strsql, AccountID);
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetTicketTotle(int[] AccountIDs)
        {
            string strsql = @"select itemname,sum(tolal_fee) as tolal_fee 
                            from  
                            (select  (select  itemname  from  (select a.CODE,b.ITEM_NAME as itemname from {base_stat_item as a},{base_stat_zyfp as b} where   a.ZYFP_CODE = b.code ) aa  where    aa.code   = BIGITEMCODE   ) itemname , 
                            SUM(TOTAL_FEE)   as tolal_fee 
                            from {ZY_COSTORDER}
                            where   COSTID  IN( (select COSTMASTERID from {ZY_COSTMASTER} where   ACCOUNTID in (" + CommMethod.ToString(AccountIDs) + @") )  ) 
                            Group BY BIGITEMCODE ) a  group by itemname  ";
            //strsql = String.Format(strsql, AccountID);
            return oleDb.GetDataTable(strsql);
        }


        public decimal[] GetTotleType(int AccountID)
        {
            decimal[] dec = new decimal[3];
            string strsql = @"select sum(TOTAL_FEE) as tolal_fee 
                              from {ZY_COSTORDER}  where   COSTID  IN( (select COSTMASTERID from {ZY_COSTMASTER} where   ACCOUNTID =" + AccountID + @" )  ) and BIGITEMCODE in ('00','01','02','03')";
            object obj = oleDb.GetDataResult(strsql);
            dec[0] = obj == null ? 0 : Convert.ToDecimal(obj);
            strsql = @"select sum(TOTAL_FEE) as tolal_fee 
                              from {ZY_COSTORDER}  where   COSTID  IN( (select COSTMASTERID from {ZY_COSTMASTER} where   ACCOUNTID =" + AccountID + @" )  ) and BIGITEMCODE not in ('00','01','02','03')";
            obj = oleDb.GetDataResult(strsql);
            dec[1] = obj == null ? 0 : Convert.ToDecimal(obj);
            dec[2] = 0;
            return dec;
        }

        public decimal[] GetTotleType(int[] AccountIDs)
        {
            decimal[] dec = new decimal[3];
            string strsql = @"select sum(TOTAL_FEE) as tolal_fee 
                              from {ZY_COSTORDER}  where   COSTID  IN( (select COSTMASTERID from {ZY_COSTMASTER} where   ACCOUNTID in (" + CommMethod.ToString(AccountIDs) + @") )  ) and BIGITEMCODE in ('00','01','02','03')";
            object obj = oleDb.GetDataResult(strsql);
            dec[0] = obj == null ? 0 : Convert.ToDecimal(obj);
            strsql = @"select sum(TOTAL_FEE) as tolal_fee 
                              from {ZY_COSTORDER}  where   COSTID  IN( (select COSTMASTERID from {ZY_COSTMASTER} where   ACCOUNTID in (" + CommMethod.ToString(AccountIDs) + @") )  ) and BIGITEMCODE not in ('00','01','02','03')";
            obj = oleDb.GetDataResult(strsql);
            dec[1] = obj == null ? 0 : Convert.ToDecimal(obj);
            dec[2] = 0;
            return dec;
        }


        public decimal GetfaoverAll_Fee(int patlistid, string patientcode, decimal costFee)
        {
            return 0;
        }

     

        public decimal GetvillageAll_Fee(int patlistid)
        {
            return 0;
        }

        public decimal GetvillageAll_Fee(int patlistid ,DateTime costdate)
        {
            return 0;
        }

       


        public void UpdateRecord_Flag(int CostMasterID, int Record_Flag)
        {
            string strWhere = "COSTMASTERID =" + CostMasterID;
            string str = "RECORD_FLAG =" + Record_Flag;
            BindEntity<HIS.ZY_BLL.DataModel.ZY_CostMaster>.CreateInstanceDAL(oleDb).Update(strWhere, str);
        }

   

        public string GetNewTicketNo(DateTime date)
        {
            object obj = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").GetFieldValue("TODAYDATE", "");
            if (obj.ToString() == "" || (Convert.ToDateTime(obj)).Date != date.Date)
            {
                string str1 = "TODAYDATE ='" + date.Date + "'";
                string str2 = "TICKETNO =0";
                string str3 = "BILLNO =0";
                BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").Update("", str1, str2, str3);
            }

            string str4 = "TICKETNO =TICKETNO+1";
            BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").Update("", str4);

            object obj1 = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").GetFieldValue("TICKETNO", "");

            return obj1.ToString();
        }



        public void UpdateCostMID(int oldCMID, int NewCMID)
        {
            string strWhere = "COSTID =" + oldCMID;
            string str = "COSTID ="+ NewCMID;
            BindEntity<HIS.ZY_BLL.DataModel.ZY_CostOrder>.CreateInstanceDAL(oleDb).Update(strWhere, str);
        }

       

        public System.Data.DataTable GetPatOrderFee(int PatListID)
        {
            string strsql = @" select itemname, SUM(TOLAL_FEE)   as tolal_fee 
                                    from  
                                    (select  (select  itemname  from  (select a.code,b.item_name as itemname from {base_stat_item as a},{base_stat_zyfp as b} where   a.zyfp_code=b.code ) aa  where   aa.code = itemtype ) itemname ,
                                    tolal_fee 
                                    from {zy_presorder} 
                                    where   patlistid =" + PatListID + @" and costmasterid = 0 and charge_flag = 1 ) a  group by a.itemname ";
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetPatBigItemOrderFee(int PatListID)
        {
            string strsql = " select ITEMTYPE, SUM(TOLAL_FEE) tolal_fee  from {ZY_PRESORDER}  where PATLISTID =" + PatListID + " and COSTMASTERID = 0 and CHARGE_FLAG = 1 group by ITEMTYPE order by itemtype";

            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetProject()
        {
            string strsql = "select itemid,d_code,insur_type from {VI_ITEM_ZY_DRUG}";
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetItem()
        {
            string strsql = "select itemid,d_code,insur_type from {VI_ITEM_PROJECT} ";
            return oleDb.GetDataTable(strsql);
        }

        public string GetDeptName(int patlistid)  //获得病人当前科室
        {
            string str = @" select name from (
                         select b.name from {zy_patlist as a}  left outer join { base_dept_property as b} on 
                       case when CURRDEPTCODE='' then  CUREDEPTCODE  else CURRDEPTCODE  end =char(b.dept_id) where a.patlistid=" + patlistid + ")a";
            return oleDb.GetDataResult(str).ToString();

        }

    }
}
