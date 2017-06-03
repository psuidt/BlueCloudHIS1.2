using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MediInsInterface_BLL.MediInsBLL.Dao.zyUpload.Daointerface;
using HIS.SYSTEM.Core;

namespace HIS.MediInsInterface_BLL.MediInsBLL.Dao.zyUpload.DaoClass
{
    public class PatDao:IpatDao
    {
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

        public void UpdatePatinfo(string patid, string patlistid, string patname, string grbm, string ywlb, string ywid, string id, string diseaseCode, string diseaseName)
        {
            try
            {
                oleDb.BeginTransaction();
                string strWhere = "patid = " + patid;
                string[] fnavs = new string[2];
                fnavs[0] = "patname='" + patname + "'";
                fnavs[1] = "FAMILYCODE='" + grbm + "-" + ywlb + "'";
                BindEntity<object>.CreateInstanceDAL(oleDb, "PATIENTINFO").Update(strWhere, fnavs);
                strWhere = "patlistid=" + patlistid;
                fnavs = new string[3];
                fnavs[0] = "NCCM_NO='" + ywid + "-" + id + "'";
                fnavs[1] = "DISEASECODE='" + diseaseCode + "'";
                fnavs[2] = "DISEASENAME='" + diseaseName + "'";
                BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATLIST").Update(strWhere, fnavs);
                oleDb.CommitTransaction();
            }
            catch (Exception err)
            {
                oleDb.RollbackTransaction();
                throw err;
            }
        }


       


        public System.Data.DataTable GetPresOrderNoPass(int patlistid)
        {
            string sqlstr = @"select a.itemid,a.itemname,a.prestype,a.standard,a.buy_price,a.unit,a.amount,a.tolal_fee,a.presorderid,a.oldid,a.order_id,a.costdate,b.order_id as order_id2,b.ORDER_DOC,b.EORDER_DATE,b.EORDER_DOC,b.TRANS_DATE,b.EXEC_DEPT
                          from DB2INST2.ZY_PRESORDER a
                          left join ZY_DOC_ORDERRECORD b on a.order_id =b.order_id
                          inner join CXCH_MATCH_CATALOG_TEMP c on a.itemid=bigint(c.HOSP_CODE)
                          where patlistid=" + patlistid + " and passid=0 and a.amount<>0 and a.charge_flag=1 and c.VALID_FLAG='1' ";
            return oleDb.GetDataTable(sqlstr);
        }

      

        public System.Data.DataTable GetPresOrderPass(int patlistid)
        {
            string sqlstr = @"select PRESORDERID,     ITEMID,prestype ,  ITEMNAME, STANDARD,packunit,   SELL_PRICE, AMOUNT,  TOLAL_FEE,   COSTDATE , ORDER_ID  from DB2INST2.ZY_PRESORDER where passid=1 and patlistid=" + patlistid;
            return oleDb.GetDataTable(sqlstr);
        }

        public void UpdatePresOrderPassID(System.Data.DataTable dt)
        {
            try
            {
                oleDb.BeginTransaction();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sqlstr = "update zy_presorder set passid=1 where presorderid=" + dt.Rows[i]["presorderid"].ToString();
                    oleDb.DoCommand(sqlstr);
                }
                oleDb.CommitTransaction();
            }
            catch (Exception err)
            {
                oleDb.RollbackTransaction();
                throw err;
            }
        }

      


        public decimal GetPatAllFee(int patlistid)
        {
            try
            {
                string sqlstr = "select sum(TOLAL_FEE) from zy_presorder where charge_flag=1 and passid=1 and patlistid=" + patlistid;
                return Convert.ToDecimal(oleDb.GetDataResult(sqlstr));
            }
            catch (Exception err)
            {
                throw err;
            }
        }

      

        public void SavePatYlzh(string patid, string ylzh)
        {
            try
            {
                string sqlstr = "update PATIENTINFO set MEDICARD='" + ylzh + "' where patid=" + patid;
                oleDb.DoCommand(sqlstr);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        


        public void DeleteYwid(int patlistid)
        {
            try
            {
                string sqlstr = "update zy_patlist set NCCM_NO='' where patlistid=" + patlistid;
                oleDb.DoCommand(sqlstr);
                sqlstr = "update zy_presorder set passid=0 where patlistid=" + patlistid;
                oleDb.DoCommand(sqlstr);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

       
    }
}
