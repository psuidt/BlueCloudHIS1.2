using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.Model;
using HIS.BLL;

namespace HIS.Interface
{
    public class ZY_Data:BaseBLL, IZY_Data
    {
        public List<ZY_DRUGMESSAGE_MASTER> GetDrugMsgMaster()
        {
            try
            {
                string workid = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                string strWhere = "drugmessageid in (select masterid from zy_drugmessage_order where disp_flag=0 and workid="
                    + workid + " and nodrug_flag=0)";
                return BindEntity<ZY_DRUGMESSAGE_MASTER>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        //根据发药科室选择药品
        public List<ZY_DRUGMESSAGE_MASTER> GetDrugMsgMaster(int deptid)
        {
            try
            {
                string workid = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                string strWhere = "drugmessageid in (select masterid from zy_drugmessage_order where disp_flag=0 and workid="
                    + workid + " and nodrug_flag=0) and dispdept="+deptid+"";
                return BindEntity<ZY_DRUGMESSAGE_MASTER>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        //[20100622.0.01]
        public DataTable GetDrugMsgOrder(int dispHisId)
        {
            try
            {
                //string strWhere = "h." + Tables.yf_drorder.UNIFORMID + oleDb.EuqalTo() + dispHisId.ToString()
                //   + oleDb.And() + "h." + Tables.yf_drorder.UNIFORM_FLAG + oleDb.EuqalTo() + "2";
                //string tableName = oleDb.TableNameBM(Tables.YF_DRORDER, "h") +
                //    oleDb.LeftOuterJoin() + oleDb.TableNameBM(Tables.ZY_DRUGMESSAGE_ORDER, "a") +
                //    oleDb.ON("h." + Tables.yf_drorder.ORDERRECIPEID, "a." + Tables.zy_drugmessage_order.ORDERRECIPEID) +
                //    oleDb.LeftOuterJoin() + oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "b") +
                //    oleDb.ON("a." + Tables.zy_drugmessage_order.CUREDOC, "b." + Tables.base_employee_property.EMPLOYEE_ID) +
                //    oleDb.LeftOuterJoin() + oleDb.TableNameBM(Tables.BASE_DEPT_PROPERTY, "c") +
                //    oleDb.ON("a." + Tables.zy_drugmessage_order.CUREDEPT, "c." + Tables.base_dept_property.DEPT_ID);
                //string strSql = oleDb.Table(tableName, "", strWhere,
                //    "a.*",
                //    "b.name as presdocname",
                //    "c.name as presdeptname",
                //    "1 as isdispense");
                //strSql += oleDb.OrderBy("a.dosename", "a.chemname");
                string strSql = @"select a.*,b.name as presdocname,c.name as presdeptname,1 as isdispense 
                                     from   yf_drorder  as h
                                      Left outer Join 
                                       zy_drugmessage_order  as a on h.ORDERRECIPEID = a.ORDERRECIPEID 
                                        Left outer Join   base_employee_property as b on a.CUREDOC = b.EMPLOYEE_ID
	                                      Left outer Join  base_dept_property  as c on a.CUREDEPT = c.DEPT_ID  
	                                      left outer join YP_SPECDIC as d on a.SPECDICID= d.SPECDICID
	                                       where h.UNIFORMID = "+dispHisId+@" AND h.UNIFORM_FLAG = 2 
	                                       order by d.PHARMACOLOGY, a.dosename,a.chemname";
                return oleDb.GetDataTable(strSql);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public DataTable GetDrugMsgOrder(ZY_DRUGMESSAGE_MASTER queryMaster)
        {
            try
            {
                if (queryMaster != null)
                {
                    int masterId = queryMaster.DRUGMESSAGEID;
                    string strWhere = "a." + Tables.zy_drugmessage_order.MASTERID + oleDb.EuqalTo() + masterId.ToString()
                        + oleDb.And() + "a." + Tables.zy_drugmessage_order.DISP_FLAG + oleDb.EuqalTo() + "0"
                        + oleDb.And() + "a." + Tables.zy_drugmessage_order.NODRUG_FLAG + oleDb.EuqalTo() + "0";
                    string tableName = oleDb.TableNameBM(Tables.ZY_DRUGMESSAGE_ORDER, "a") +
                        oleDb.LeftOuterJoin() + oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "b") +
                        oleDb.ON("a." + Tables.zy_drugmessage_order.CUREDOC, "b." + Tables.base_employee_property.EMPLOYEE_ID) +
                        oleDb.LeftOuterJoin() + oleDb.TableNameBM(Tables.BASE_DEPT_PROPERTY, "c") +
                        oleDb.ON("a." + Tables.zy_drugmessage_order.CUREDEPT, "c." + Tables.base_dept_property.DEPT_ID);
                    string strSql = oleDb.Table(tableName, "", strWhere,
                        "a.*",
                        "b.name as presdocname",
                        "c.name as presdeptname",
                        "1 as isdispense");
                    strSql += oleDb.OrderBy("a.dosename", "a.chemname");
                    DataTable rtnDt = oleDb.GetDataTable(strSql);
                    GetSendNumAndFee(rtnDt);
                    return rtnDt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取某条医嘱明细的用法大类
        /// </summary>
        /// <param name="docOrderId">医嘱明细ID</param>
        /// <returns>用法大类</returns>
        public DataTable GetUseType(int docOrderId)
        {
            try
            {
                ZY_DOC_ORDERRECORD orderRecord = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetModel(docOrderId);
                if (orderRecord != null)
                {
                    string strSql = "select TYPE_NAME from BASE_USAGE_USETYPE_ROLE A where A.USAGE_ID=(select ID from BASE_USAGEDICTION where NAME='"
                    + orderRecord.ORDER_USAGE + "')";
                    return oleDb.GetDataTable(strSql);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string GetDocOrderInfo(int docOrderId)
        {
            try
            {
                ZY_DOC_ORDERRECORD orderRecord = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetModel(docOrderId);
                if (orderRecord != null)
                {
                    return orderRecord.ORDER_CONTENT + "  "+orderRecord.AMOUNT.ToString() + "  " + 
                        orderRecord.UNIT.ToString() + "  " + orderRecord.FREQUENCY + "  "
                        + orderRecord.ORDER_USAGE + "  " + orderRecord.ORDER_STRUC + "  ["
                        + orderRecord.ORDER_SPEC + "]";
                }
                else
                {
                    return "未找到对应医嘱内容";
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public DataRow GetPatCardInfo(string cureNo)
        {
            try
            {
                if (cureNo != "")
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("select a.dbfee txtdb,0 as banlancefee,a.bedcode as bedno,b.patbridate as bornday,c.name as curedoc,d.name as currentdept,");
                    strSql.Append("e.name as economydoc,curedate as indate,f.name as indept,diseasename as indisease,b.patname as inpatientname,");
                    strSql.Append("a.cureno as inpatientno,'' as nurse,b.accounttype as patienttype,0 as prepayfee,b.patsex as sex,'' as tendinfo");
                    strSql.Append(" from ZY_PATLIST a ");
                    strSql.Append(" left outer join PATIENTINFO b on a.patid=b.patid and a.workid=b.workid");
                    strSql.Append(" left outer join base_employee_property c on a.curedoccode=cast(c.employee_id as char(20)) and a.workid=c.workid");
                    strSql.Append(" left outer join base_dept_property d on a.curedeptcode=cast(d.dept_id as char(20)) and a.workid=d.workid");
                    strSql.Append(" left outer join base_employee_property e on a.origindoccode=cast(e.employee_id as char(20)) and a.workid=e.workid");
                    strSql.Append(" left outer join base_dept_property f on a.origindeptcode=cast(f.dept_id as char(20)) and a.workid=f.workid");
                    strSql.Append(" where a.cureno='" + cureNo + "' and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString());
                    return oleDb.GetDataRow(strSql.ToString());
                }
                return null;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void UpdateSendFlag(int orderrecipeid, int drFlag, decimal drugnum, decimal retailfee)
        {
            try
            {
                string strWhereMsg = BLL.Tables.zy_drugmessage_order.ORDERRECIPEID + oleDb.EuqalTo()
                    + orderrecipeid.ToString();
                BindEntity<HIS.Model.ZY_DRUGMESSAGE_ORDER>.CreateInstanceDAL(oleDb).Update(strWhereMsg, 
                    BLL.Tables.zy_drugmessage_order.DISP_FLAG + oleDb.EuqalTo() + "1",
                    BLL.Tables.zy_drugmessage_order.DRUGNUM + oleDb.EuqalTo() + drugnum.ToString(),
                    BLL.Tables.zy_drugmessage_order.RETAILFEE + oleDb.EuqalTo() + retailfee.ToString());
                string strWhereOrder = BLL.Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo()
                    + orderrecipeid.ToString();
                if (drFlag == 1)
                {
                    BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhereOrder,
                        BLL.Tables.zy_presorder.DRUG_FLAG + oleDb.EuqalTo() + "1");
                }
                else
                {
                    BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhereOrder,
                        BLL.Tables.zy_presorder.DRUG_FLAG + oleDb.EuqalTo() + "2");
                }

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void UpdateNoDrugFlag(int orderrecipeid, DateTime chargeTime)
        {
            try
            {
                string strWhere = Tables.zy_drugmessage_order.ORDERRECIPEID + oleDb.EuqalTo() + orderrecipeid.ToString()
                    + oleDb.And() + Tables.zy_drugmessage_order.CHARGEDATE + oleDb.EuqalTo() + "'" + chargeTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                BindEntity<ZY_DRUGMESSAGE_ORDER>.CreateInstanceDAL(oleDb).Update(strWhere, "NODRUG_FLAG=1");
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string GetPatAge(string cureNo, DateTime currentTime)
        {
            try
            {
                string strWhere = Tables.patientinfo.CURENO + oleDb.EuqalTo() + "'" + cureNo + "'";
                object obj = BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.patientinfo.PATBRIDATE, strWhere);
                if (obj != null && obj != DBNull.Value)
                {
                    DateTime patbirthDate = Convert.ToDateTime(obj);
                    return HIS.SYSTEM.PubicBaseClasses.Age.GetAgeString(patbirthDate, currentTime, 0);
                }
                else
                {
                    return "无";
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool GetSendNumAndFee(DataTable drugMsgOrder)
        {
            //try
            //{
            //    if (drugMsgOrder == null) return false;
            //    for (int i = 0; i < drugMsgOrder.Rows.Count; i++)
            //    {
            //        int orderid = Convert.ToInt32(drugMsgOrder.Rows[i]["ORDERRECIPEID"]);
            //        decimal num = Convert.ToDecimal(drugMsgOrder.Rows[i]["DRUGNUM"]);
            //        if (num >= 0)
            //        {
            //            List<HIS.Model.ZY_PresOrder> zyPlist = BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray("CHARGE_FLAG=1 and DRUG_FLAG=0 and RECORD_FLAG in(0,1) and (PRESORDERID=" + orderid + " or oldid=" + orderid + ")");

            //            HIS.Model.ZY_PresOrder zyPL1 = zyPlist.Find(delegate(HIS.Model.ZY_PresOrder y) { return (y.OldID == 0 && y.Record_Flag == 0); });
            //            List<HIS.Model.ZY_PresOrder> zyPL2 = zyPlist.FindAll(delegate(HIS.Model.ZY_PresOrder y) { return (y.OldID != 0 && y.Record_Flag == 1); });
            //            if (zyPlist != null && zyPL1 != null && zyPL2 != null)
            //            {
            //                decimal amount = zyPL2.Sum(y => y.Amount);
            //                int presamount = zyPL2.Sum(y => y.PresAmount);
            //                decimal total_fee = zyPL2.Sum(y => y.Tolal_Fee);

            //                zyPL1.Amount += amount;
            //                zyPL1.PresAmount += presamount;
            //                //zyPL1.Tolal_Fee += total_fee;

            //                int SmallNum = Convert.ToInt32(zyPL1.Amount) % Convert.ToInt32(zyPL1.RelationNum);
            //                int BigNum = Convert.ToInt32((zyPL1.Amount - SmallNum) / zyPL1.RelationNum);
            //                decimal fee = BigNum * zyPL1.Sell_Price + SmallNum * zyPL1.Sell_Price / zyPL1.RelationNum;
            //                drugMsgOrder.Rows[i]["DRUGNUM"] = zyPL1.Amount;
            //                drugMsgOrder.Rows[i]["RECIPENUM"] = zyPL1.PresAmount;
            //                drugMsgOrder.Rows[i]["RETAILFEE"] = fee;
            //            }
            //        }
            //        else
            //        {
            //            bool b = BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists("CHARGE_FLAG=1 and DRUG_FLAG=1 and RECORD_FLAG =2 and  oldid=" + orderid + "");
            //            if (b)
            //            {
            //                drugMsgOrder.Rows[i]["DRUGNUM"] = 0;
            //                drugMsgOrder.Rows[i]["RECIPENUM"] = 1;
            //                drugMsgOrder.Rows[i]["RETAILFEE"] = 0;
            //            }
            //            else
            //            {
            //                int RelationNum = Convert.ToInt32(drugMsgOrder.Rows[i]["UNITNUM"]);
            //                decimal Sell_Price = Convert.ToDecimal(drugMsgOrder.Rows[i]["RETAILPRICE"]);
            //                int SmallNum = Convert.ToInt32(num) % Convert.ToInt32(RelationNum);
            //                int BigNum = Convert.ToInt32((num - SmallNum) / RelationNum);
            //                decimal fee = BigNum * Sell_Price + SmallNum * Sell_Price / RelationNum;
            //                drugMsgOrder.Rows[i]["DRUGNUM"] = num;
            //                drugMsgOrder.Rows[i]["RECIPENUM"] = 1;
            //                drugMsgOrder.Rows[i]["RETAILFEE"] = fee;
            //            }
            //        }
            //    }
            //    return true;
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            try
            {
                if (drugMsgOrder == null) return false;
                for (int i = 0; i < drugMsgOrder.Rows.Count; i++)
                {
                    int orderid = Convert.ToInt32(drugMsgOrder.Rows[i]["ORDERRECIPEID"]);
                    decimal num = Convert.ToDecimal(drugMsgOrder.Rows[i]["DRUGNUM"]);
                    if (num >= 0)
                    {
                        List<HIS.Model.ZY_PresOrder> zyPlist = BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray("CHARGE_FLAG=1 and DRUG_FLAG=0 and RECORD_FLAG in(0,1) and (PRESORDERID=" + orderid + " or oldid=" + orderid + ")");

                        HIS.Model.ZY_PresOrder zyPL1 = zyPlist.Find(delegate(HIS.Model.ZY_PresOrder y) { return (y.OldID == 0 && y.Record_Flag == 0); });
                        List<HIS.Model.ZY_PresOrder> zyPL2 = zyPlist.FindAll(delegate(HIS.Model.ZY_PresOrder y) { return (y.OldID != 0 && y.Record_Flag == 1); });

                        //已经发药（控制并发问题）
                        if (zyPlist.Count == 0)
                        {
                            drugMsgOrder.Rows[i]["DRUGNUM"] = 0;
                            drugMsgOrder.Rows[i]["RECIPENUM"] = 0;
                            drugMsgOrder.Rows[i]["RETAILFEE"] = 0;
                        }
                        else if (zyPL1 != null && zyPL2 != null)
                        {
                            decimal amount = zyPL2.Sum(y => y.Amount);
                            int presamount = zyPL2.Sum(y => y.PresAmount);
                            decimal total_fee = zyPL2.Sum(y => y.Tolal_Fee);

                            zyPL1.Amount += amount;
                            zyPL1.PresAmount += presamount;
                            //zyPL1.Tolal_Fee += total_fee;

                            int SmallNum = Convert.ToInt32(zyPL1.Amount) % Convert.ToInt32(zyPL1.RelationNum);
                            int BigNum = Convert.ToInt32((zyPL1.Amount - SmallNum) / zyPL1.RelationNum);
                            decimal fee = BigNum * zyPL1.Sell_Price + SmallNum * zyPL1.Sell_Price / zyPL1.RelationNum;
                            drugMsgOrder.Rows[i]["DRUGNUM"] = zyPL1.Amount;
                            drugMsgOrder.Rows[i]["RECIPENUM"] = zyPL1.PresAmount;
                            drugMsgOrder.Rows[i]["RETAILFEE"] = fee;
                        }
                    }
                    else
                    {
                        bool b = BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists("CHARGE_FLAG=1 and DRUG_FLAG=1 and RECORD_FLAG =1 and  PRESORDERID=" + orderid + "");

                        if (b == false)//已经退药（并发问题）
                        {
                            drugMsgOrder.Rows[i]["DRUGNUM"] = 0;
                            drugMsgOrder.Rows[i]["RECIPENUM"] = 1;
                            drugMsgOrder.Rows[i]["RETAILFEE"] = 0;
                        }
                        else
                        {

                            b = BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists("CHARGE_FLAG=1 and DRUG_FLAG=1 and RECORD_FLAG =2 and  oldid=" + orderid + "");

                            if (b)//已经取消退药
                            {
                                drugMsgOrder.Rows[i]["DRUGNUM"] = 0;
                                drugMsgOrder.Rows[i]["RECIPENUM"] = 1;
                                drugMsgOrder.Rows[i]["RETAILFEE"] = 0;
                            }
                            else
                            {
                                int RelationNum = Convert.ToInt32(drugMsgOrder.Rows[i]["UNITNUM"]);
                                decimal Sell_Price = Convert.ToDecimal(drugMsgOrder.Rows[i]["RETAILPRICE"]);
                                int SmallNum = Convert.ToInt32(num) % Convert.ToInt32(RelationNum);
                                int BigNum = Convert.ToInt32((num - SmallNum) / RelationNum);
                                decimal fee = BigNum * Sell_Price + SmallNum * Sell_Price / RelationNum;
                                drugMsgOrder.Rows[i]["DRUGNUM"] = num;
                                drugMsgOrder.Rows[i]["RECIPENUM"] = 1;
                                drugMsgOrder.Rows[i]["RETAILFEE"] = fee;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
