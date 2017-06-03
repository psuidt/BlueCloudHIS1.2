using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.MedicalConfir_BLL
{
    partial class ZyGetFee:BaseBLL
    {
        #region 根据住院病人ID获得病人的费用明细
        /// <summary>
        /// 根据住院病人ID获得病人的费用明细
        /// </summary>
        /// <param name="zyPlist"></param>
        /// <param name="IsConfird">true=已确费 false=未确费</param>
        /// <param name="deptid"></param>
        /// <param name="docid"></param>
        /// <returns></returns>
        public static DataTable GetZyItems(List<HIS.Model.ZY_PatList> zyPlist, bool IsConfird, int deptid, int docid)
        {
            if (zyPlist == null || zyPlist.Count == 0)
            {
                return null;
            }
            DataTable items = new DataTable();
            bool isFirst = true;
            string strSql = "";
            object obj = BindEntity<HIS.Model.ZY_DOC_CONFIG>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_config.VALUE, "code='007'");

            try
            {
                oleDb.BeginTransaction();
                for (int i = 0; i < zyPlist.Count; i++)
                {
                    if (IsConfird)
                    {
                        strSql = @"select  ''as patname,'' as cureno,'' as bedcode,a.patlistid,a.presorderid,a.itemname,a.amount,a.tolal_fee,a.presdoccode as presdoc, 
                                a.execdeptcode as execdept, a.presdate,a.presdeptcode as presdept,
                         b.confirdoc as confirdocid,d.name as confirdocname,b.confirdept as confirdeptid,c.name as confirdeptname
                                from
                              medical_confir b left outer join zy_presorder a on b.presorderid=a.presorderid 
                               left outer join BASE_DEPT_PROPERTY c on b.confirdept=c.dept_id
                               left outer join BASE_EMPLOYEE_PROPERTY d on d.EMPLOYEE_ID=b.confirdoc
                              where a.patlistid=" + zyPlist[i].PatListID + @" 
                             and a.prestype ='4' and a.record_flag=0 and  b. cancel_flag=0 and b.mark_flag=1 
                           and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + "";
                    }
                    else
                    {
                        // strSql =  @"select  ''as patname,'' as cureno,'' as bedcode,a.patlistid,a.presorderid,a.itemname,a.tolal_fee,a.presdoccode as presdoc, "
                        //        + " a.execdeptcode as execdept,a.presdate,a.presdeptcode as presdept from zy_presorder a  left outer join  zy_doc_orderrecord b on a.order_id=b.order_id "// where  b.dept_id =" + deptid + ""
                        //        + " where  a.patlistid=" + zyPlist[i].PatListID + " and b.item_type=5"
                        //    + " and a.CHARGE_FLAG = 1  AND a.RECORD_FLAG = 0 and a.prestype ='4' and a.workid= " + HIS.SYSTEM.Core.EntityConfig.WorkID + " and  a.presorderid not in  "
                        //+ " (select presorderid from medical_confir where cancel_flag=0 and mark_flag=1 )";
                        if (obj == null || obj.ToString().Trim() == "1")
                        {
                            strSql = @" select  ''as patname,'' as cureno,'' as bedcode,a.patlistid,a.presorderid,a.itemname,a.amount,a.tolal_fee,a.presdoccode as presdoc, 
                                a.execdeptcode as execdept,a.presdate,a.presdeptcode as presdept ,
                                 '' as confirdocid,'' as confirdocname,'' as confirdeptid,'' as confirdeptname 
                                from zy_presorder a   left outer join  BASE_ITEM_DEPT b on a.itemid=b.item_id
                              where  a.patlistid=" + zyPlist[i].PatListID + @" and  b.dept_id="+deptid+@"
                          and a.CHARGE_FLAG = 1  AND a.RECORD_FLAG = 0 and  
	                               (a.AMOUNT + 
	                               (select (case   WHEN SUM(zy_a.AMOUNT) IS null  THEN 0 ELSE SUM(zy_a.AMOUNT)end) from zy_presorder zy_a where zy_a.CHARGE_FLAG = 1 AND zy_a.RECORD_FLAG = 1 AND zy_a.oldid = a.presorderid )
	                          ) >0 
					          and a.prestype ='4' and a.workid= " + HIS.SYSTEM.Core.EntityConfig.WorkID + @"
					         and  a.presorderid not in  (select presorderid from medical_confir where cancel_flag=0 and mark_flag=1)";
                        }
                        else
                        {
                            strSql = @" select  ''as patname,'' as cureno,'' as bedcode,a.patlistid,a.presorderid,a.itemname,a.amount,a.tolal_fee,a.presdoccode as presdoc, 
                                a.execdeptcode as execdept,a.presdate,a.presdeptcode as presdept ,
                                 '' as confirdocid,'' as confirdocname,'' as confirdeptid,'' as confirdeptname 
                                from zy_presorder a  
                              where  a.patlistid=" + zyPlist[i].PatListID + @" 
                          and a.CHARGE_FLAG = 1  AND a.RECORD_FLAG = 0 and  
	                     (a.AMOUNT + 
	                   (select (case   WHEN SUM(zy_a.AMOUNT) IS null  THEN 0 ELSE SUM(zy_a.AMOUNT)end) from zy_presorder zy_a where zy_a.CHARGE_FLAG = 1 AND zy_a.RECORD_FLAG = 1 AND zy_a.oldid = a.presorderid )
	                   ) >0 
					   and a.prestype ='4' and a.workid= " + HIS.SYSTEM.Core.EntityConfig.WorkID + @"
					    and  a.presorderid not in  (select presorderid from medical_confir where cancel_flag=0 and mark_flag=1)";
                        }
                    }
                    DataTable dt = oleDb.GetDataTable(strSql);
                    DataColumn column = new DataColumn();
                    column.ColumnName = "XD";
                    column.DataType = System.Type.GetType("System.Boolean");
                    dt.Columns.Add(column);
                    if (isFirst)
                    {
                        items = dt.Clone();
                        items.Clear();
                        isFirst = false;
                    }
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        dt.Rows[j]["patname"] = zyPlist[i].PatientInfo.PatName;
                        dt.Rows[j]["cureno"] = zyPlist[i].CureNo;
                        dt.Rows[j]["bedcode"] = zyPlist[i].BedCode;
                        dt.Rows[j]["presdoc"] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(dt.Rows[j]["presdoc"].ToString());
                        dt.Rows[j]["presdept"] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(dt.Rows[j]["presdept"].ToString());
                        dt.Rows[j]["execdept"] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(dt.Rows[j]["execdept"].ToString());
                        dt.Rows[j]["XD"] = true;
                        items.Rows.Add(dt.Rows[j].ItemArray);
                    }
                }
                oleDb.CommitTransaction();
                return items;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 根据项目名称获得做了这些项目的住院病人
        /// <summary>
        /// 根据项目名称获得做了这些项目的住院病人
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        public static DataTable GetZyFees(string itemname)
        {
            string strsql = @" select '住院' as type, e.patname as patname,e.patsex as patsex,c.cureno as cureno,a.itemname as itemname,a.tolal_fee as tolal_fee, "
                + " b.confirdate as date, (select name from BASE_EMPLOYEE_PROPERTY d where d.employee_id=b.confirdoc) as docname "
            + " from zy_presorder a left outer join  medical_confir  b on a.presorderid=b.presorderid  left outer join zy_patlist c on a.patlistid=c.patlistid "
            + " left outer join patientinfo e on e.patid =c.patid "
            + " where a.itemname= '" + itemname + "' and b.cancel_flag=0 and b.mark_flag=1  and b.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " ";
            return oleDb.GetDataTable(strsql);
        }
        #endregion
    }
}
