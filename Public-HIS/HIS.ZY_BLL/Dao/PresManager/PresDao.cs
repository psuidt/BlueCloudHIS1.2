using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;

namespace HIS.ZY_BLL.Dao.PresManager
{
    public class PresDao:IpresDao
    {

        public System.Data.DataTable GetSendGrugPres(int patlistid, string deptcode)
        {
            string strWhere = "where amount<>0 and patlistid=" + patlistid + " and execdeptcode='" + deptcode + "' ";
            string strsql = "select * from {VI_ZY_SENDDRUG} "+ strWhere;
           
            return oleDb.GetDataTable(strsql);
        }

        public System.Data.DataTable GetSendGrugPres(int patlistid)
        {
            string strWhere = "where amount<>0 and patlistid=" + patlistid + "  ";
            string strsql = "select * from {VI_ZY_SENDDRUG} "   + strWhere;
           return oleDb.GetDataTable(strsql);
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

        public decimal GetSendGrugPresTotalFee(int patlistid, string deptcode)
        {
            string strWhere = "where amount<>0 and patlistid=" + patlistid + " and execdeptcode='" + deptcode + "' ";
            string strsql = "select sum(TOLAL_FEE) from {VI_ZY_SENDDRUG} "+ strWhere;
            object obj = oleDb.GetDataResult(strsql);
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(obj);
        }

        public System.Data.DataTable GetSendGrugPres(string cureNO, string deptcode)
        {
            string strWhere = "where amount<>0 and CureNo=" + cureNO + " and execdeptcode='" + deptcode + "' ";
            string strsql = "select * from {VI_ZY_SENDDRUG} "+ strWhere;
            return oleDb.GetDataTable(strsql);
        }

        public decimal GetNoCostAll_Fee(int patlistid)
        {
            string strWhere = "PATLISTID =" + patlistid +" and CHARGE_FLAG= 1 and COSTMASTERID = 0 ";
            object ojb = BindEntity<HIS.ZY_BLL.DataModel.ZY_PresOrder>.CreateInstanceDAL(oleDb).GetSum("TOLAL_FEE", strWhere);
            if (ojb != null && ojb != DBNull.Value)
            {
                return Convert.ToDecimal(ojb);
            }
            return 0;
        }

        public decimal GetNoCostAll_Fee(int patlistid,DateTime costdate)
        {
            string strWhere = " date(COSTDATE)<='"+costdate.Date+"' and PATLISTID =" + patlistid + " and CHARGE_FLAG= 1 and COSTMASTERID = 0 ";
            object ojb = BindEntity<HIS.ZY_BLL.DataModel.ZY_PresOrder>.CreateInstanceDAL(oleDb).GetSum("TOLAL_FEE", strWhere);
            if (ojb != null && ojb != DBNull.Value)
            {
                return Convert.ToDecimal(ojb);
            }
            return 0;
        }

        public void AlterCostID(int patlistID, int CostID, int CostType)
        {
            string strWhere = "PATLISTID =" + patlistID + " and COSTMASTERID= 0";
            string str1 = "COSTMASTERID =" + CostID;
            string str2 = "COST_FLAG ="+ CostType;
            BindEntity<HIS.ZY_BLL.DataModel.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere, str1, str2);
        }

        public void AlterCostID(int oldCostID, int newCostID)
        {
            string strWhere = "COSTMASTERID =" + oldCostID;
            string str = "COSTMASTERID =" + newCostID;
            BindEntity<HIS.ZY_BLL.DataModel.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere, str);
        }

        public System.Data.DataTable GetNotSendDurgPresDataTable(int PatListID)
        {
            string strsql = @" select * from  
                                    (
                                    select 
                                    PRESORDERID,patid,patlistid,presmasterid,itemid,itemtype,prestype,itemname,standard,unit,relationnum,buy_price,sell_price,presamount,presdeptcode,
                                    presdoccode,execdeptcode,chargecode   ,presdate,markdate,costdate,order_flag,charge_flag,drug_flag,delete_flag,oldid,record_flag,costmasterid,cost_flag,passid,workid,packunit,comp_money, 
                                    (AMOUNT +  (select (case   WHEN  SUM(AMOUNT)   IS  null  THEN 0   ELSE  SUM(AMOUNT)    end) from {zy_presorder as a} where   CHARGE_FLAG = 1 and DRUG_FLAG = 0 and RECORD_FLAG = 1 and a.oldid = zy_presorder.presorderid )  )  as amount, 
                                    (TOLAL_FEE +  (select (case   WHEN  SUM(TOLAL_FEE)   IS  null  THEN 0   ELSE  SUM(TOLAL_FEE)    end) from {zy_presorder as a} where   CHARGE_FLAG = 1 and DRUG_FLAG = 0 and RECORD_FLAG = 1 and a.oldid = zy_presorder.presorderid )  )  as tolal_fee 
                                    from {ZY_PRESORDER}
                                    where   CHARGE_FLAG = 1 and DRUG_FLAG = 0 and PRESTYPE  IN('0','1','2','3')  and RECORD_FLAG = 0 and PATLISTID =" + PatListID + @" 
                                    ) aa  
                                    where aa.amount > 0";
            return oleDb.GetDataTable(strsql);
        }

        public decimal GetPresAllFee(DateTime PresDate, int PresType, int PatListID)
        {
            string strsql = " select  SUM(TOLAL_FEE)   from {ZY_PRESORDER}  where date(PRESDATE) = '" + PresDate.Date + "' and PATLISTID =" + PatListID + " and ORDER_TYPE= " + PresType + "";

            return Convert.ToDecimal(oleDb.GetDataResult(strsql));
        }

    }
}
