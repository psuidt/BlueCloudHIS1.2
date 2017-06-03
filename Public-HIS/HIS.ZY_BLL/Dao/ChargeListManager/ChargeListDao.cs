using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;

namespace HIS.ZY_BLL.Dao.ChargeListManager
{
    public class ChargeListDao:IchargeListDao
    {

        public string GetNewBillNo(DateTime date)
        {
            object obj = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").GetFieldValue("TODAYDATE", "");
            if (obj.ToString() == "" || date.Date != (Convert.ToDateTime(obj.ToString())).Date)
            {
                string str1 = "BILLNO =0";
                string str22 = "TICKETNO =0";
                string str3 = "TODAYDATE ='" + date.Date + "'";
                BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").Update("", str1, str22, str3);
            }
            string str2 = "BILLNO =BILLNO+1";
            BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").Update("", str2);
            object obj1 = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").GetFieldValue("BILLNO", "");
            return obj1.ToString();
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




        public decimal[] GetMenoyAndPosFee(string ChargeCode)
        {
            decimal[] dec = new decimal[5];
            string strWhere = "ACCOUNTID =0 and CHARGECODE ='" + ChargeCode + "' and FEETYPE = 0 ";
            dec[0] = Convert.ToDecimal(BindEntity<HIS.ZY_BLL.DataModel.ZY_ChargeList>.CreateInstanceDAL(oleDb).GetSum(
                "TOTAL_FEE",
                strWhere));

            string strWhere1 = "ACCOUNTID = 0 and CHARGECODE ='" + ChargeCode + "' and FEETYPE = 1 ";
            dec[1] = Convert.ToDecimal(BindEntity<HIS.ZY_BLL.DataModel.ZY_ChargeList>.CreateInstanceDAL(oleDb).GetSum(
                "TOTAL_FEE",
                strWhere1));
            return dec;
        }




        public System.Data.DataTable GetDetailCharge(string ChargeCode, int feeType)
        {
            string strsql = null;
            string strWhere = null;
            if (feeType == 0)
            {
                strWhere = "ACCOUNTID = 0 and CHARGECODE = '" + ChargeCode + "' and RECORD_FLAG In(0, 1)";
            }
            else
            {
                strWhere = "ACCOUNTID = 0 and CHARGECODE ='" + ChargeCode + "' and RECORD_FLAG = 2 ";
            }


            strsql = @" select 
                            CHARGELISTID,
                            PATID,
                            (select PATNAME from  {PATIENTINFO} where   PATID =a.PATID ) PATNAME ,
                            PATLISTID, 
                            (select NAME from {BASE_DEPT_PROPERTY}  where   DEPT_ID = CAST( (select (case   WHEN CUREDEPTCODE ='' then '0'    ELSE CUREDEPTCODE  end) from {ZY_PATLIST}  where   PATLISTID = a.PATLISTID )   as bigint)  ) CUREDEPTCODE ,
                            CURENO,
                            BILLNO,
                            OLDBILLNO,
                            FEETYPE,
                            TOTAL_FEE,
                            CHARGECODE,
                            COSTDATE,
                            DELETE_FLAG,
                            ACCOUNTID,
                            RECORD_FLAG 
                        from {zy_chargelist as a}   
                        where " + strWhere;
            return oleDb.GetDataTable(strsql);
        }

       


        public void UpdateAccount(string ChargeCode, int ID)
        {
            string strwhere = "ACCOUNTID = 0 and CHARGECODE ='" + ChargeCode + "'";
            string str = "ACCOUNTID =" + ID;
            BindEntity<HIS.ZY_BLL.DataModel.ZY_ChargeList>.CreateInstanceDAL(oleDb).Update(strwhere, str);
        }

      


        public decimal GetNoCostAll_Fee(int patlistid)
        {
            //总预交金
            string strWhere = "PATLISTID ="+ patlistid;
            object obj = BindEntity<HIS.ZY_BLL.DataModel.ZY_ChargeList>.CreateInstanceDAL(oleDb).GetSum("TOTAL_FEE", strWhere);
            decimal dec = 0;
            decimal dec1 = 0;
            if (obj != null && obj != DBNull.Value)
            {
                dec = Convert.ToDecimal(obj);
            }
            //中途结算的预交金
            strWhere = "PATLISTID =" + patlistid +"  and NTYPE= 1 ";
            obj = BindEntity<HIS.ZY_BLL.DataModel.ZY_CostMaster>.CreateInstanceDAL(oleDb).GetSum("SELF_FEE", strWhere);
            if (obj != null && obj != DBNull.Value)
            {
                dec1 = Convert.ToDecimal(obj);
            }
            //总的预交金-中途结算前的预交金 =剩余预交金 
            return dec - dec1;
        }

        public decimal GetNoCostAll_Fee(int patlistid,DateTime costdate)
        {
            //总预交金 费用发送时间前
            string strWhere = " date(COSTDATE)<='"+costdate.Date+"' and PATLISTID =" + patlistid;
            object obj = BindEntity<HIS.ZY_BLL.DataModel.ZY_ChargeList>.CreateInstanceDAL(oleDb).GetSum("TOTAL_FEE", strWhere);
            decimal dec = 0;
            decimal dec1 = 0;
            if (obj != null && obj != DBNull.Value)
            {
                dec = Convert.ToDecimal(obj);
            }
            //中途结算的预交金 费用发送时间前
            strWhere = " date(COSTDATE)<='"+costdate.Date+"' and PATLISTID =" + patlistid + "  and NTYPE= 1 ";
            obj = BindEntity<HIS.ZY_BLL.DataModel.ZY_CostMaster>.CreateInstanceDAL(oleDb).GetSum("SELF_FEE", strWhere);
            if (obj != null && obj != DBNull.Value)
            {
                dec1 = Convert.ToDecimal(obj);
            }
            //总的预交金-中途结算前的预交金 =剩余预交金 
            return dec - dec1;
        }

    }
}
