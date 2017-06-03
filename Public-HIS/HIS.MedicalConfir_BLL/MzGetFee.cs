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
    partial class MzGetFee : BaseBLL
    {
        #region 根据门诊病人ID获得病人的费用明细
        /// <summary>
        /// 根据门诊病人ID获得病人的费用明细
        /// </summary>
        /// <param name="mzPlist"></param>
        /// <param name="IsConfird"></param>
        /// <param name="deptid"></param>
        /// <param name="docid"></param>
        /// <returns></returns>
        public static DataTable GetMzItems(List<HIS.Model.MZ_PatList> mzPlist, bool IsConfird, int deptid, int docid)
        {
            if (mzPlist == null || mzPlist.Count == 0)
            {
                return null;
            }
            DataTable items = new DataTable();
            bool isFirst = true;
            string strSql = "";
            object obj = BindEntity<HIS.Model.ZY_DOC_CONFIG>.CreateInstanceDAL(oleDb).GetFieldValue (Tables.zy_doc_config.VALUE, "code='007'");
            try
            {
                oleDb.BeginTransaction();
                for (int i = 0; i < mzPlist.Count; i++)
                {
                    if (IsConfird)
                    {
                        strSql = @"select  ''as patname,'' as visitno,b.presdoccode as docname,b.presdeptcode as deptname,b.presdate, a.patlistid,a.presorderid,a.itemname,a.tolal_fee ,
                                    c.confirdoc as confirdocid,e.name as confirdocname,c.confirdept as confirdeptid,d.name as confirdeptname
                                  from medical_confir c left outer join  mz_presorder a  on c.presorderid=a.presorderid  
                                   left outer join mz_presmaster b on a.presmasterid=b.presmasterid 
                                    left outer join BASE_DEPT_PROPERTY d on c.confirdept=d.dept_id
                               left outer join BASE_EMPLOYEE_PROPERTY e on e.EMPLOYEE_ID=c.confirdoc
                                 where a.patlistid=" + mzPlist[i].PatListID + " and b.patlistid=" + mzPlist[i].PatListID + @" 
                              and b.charge_flag=1 and a.itemtype ='00' and c. cancel_flag=0 and c.mark_flag=0 
                            and  a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " ";
                    }
                    else
                    {
                        if (obj == null || obj.ToString().Trim() == "1")
                        {
                            strSql = @"select  ''as patname,'' as visitno,c.presdoccode as docname,c.presdeptcode as deptname,c.presdate, a.patlistid,a.presorderid,a.itemname,a.tolal_fee ,
                                   '' as confirdocid,'' as confirdocname,'' as confirdeptid,''as confirdeptname
                               from mz_presorder a left outer join  BASE_ITEM_DEPT b on a.itemid=b.item_id left outer join mz_presmaster c on a.presmasterid=c.presmasterid where  b.dept_id =" + deptid + @"
                                and a.patlistid=" + mzPlist[i].PatListID + " and c.patlistid= " + mzPlist[i].PatListID + " and a.workid= " + HIS.SYSTEM.Core.EntityConfig.WorkID + @"
                            and c.charge_flag=1 and a.itemtype ='00' and  a.presorderid not in (select presorderid from medical_confir where cancel_flag=0 and mark_flag=0)";
                        }
                        else
                        {
                            strSql = @"select  ''as patname,'' as visitno,c.presdoccode as docname,c.presdeptcode as deptname,c.presdate, a.patlistid,a.presorderid,a.itemname,a.tolal_fee ,
                                   '' as confirdocid,'' as confirdocname,'' as confirdeptid,''as confirdeptname
                               from mz_presorder a left outer join mz_presmaster c on a.presmasterid=c.presmasterid where  
                                a.patlistid=" + mzPlist[i].PatListID + " and c.patlistid= " + mzPlist[i].PatListID + " and a.workid= " + HIS.SYSTEM.Core.EntityConfig.WorkID + @"
                            and c.charge_flag=1 and a.itemtype ='00' and  a.presorderid not in (select presorderid from medical_confir where cancel_flag=0 and mark_flag=0)";
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
                        dt.Rows[j]["patname"] = mzPlist[i].PatName;
                        dt.Rows[j]["visitno"] = mzPlist[i].VisitNo;
                        dt.Rows[j]["docname"] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(dt.Rows[j]["docname"].ToString());
                        dt.Rows[j]["deptname"] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(dt.Rows[j]["deptname"].ToString());
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

        #region 根据项目名称获得做了这些项目的门诊病人
        /// <summary>
        /// 根据项目名称获得做了这些项目的门诊病人
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        public static DataTable GetMzFees(string itemname)
        {
            string strsql = @" select '门诊' as type, c.patname as patname,c.patsex as patsex,c.visitno as visitno,a.itemname as itemname,a.tolal_fee as tolal_fee, "
                + " b.confirdate as date, (select name from BASE_EMPLOYEE_PROPERTY d where d.employee_id=b.confirdoc) as docname "
            + " from mz_presorder a left outer join  medical_confir  b on a.presorderid=b.presorderid  left outer join mz_patlist c on a.patlistid=c.patlistid "
            + " where a.itemname= '" + itemname + "' and b.cancel_flag=0 and b.mark_flag=0  and b.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + "";
            return oleDb.GetDataTable(strsql);
        }
        #endregion
    }
}
