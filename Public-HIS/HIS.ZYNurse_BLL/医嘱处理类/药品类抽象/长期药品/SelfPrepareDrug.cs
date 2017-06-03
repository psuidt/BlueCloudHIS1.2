using System;
using System.Collections.Generic;
using System.Text;

using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;

namespace HIS.ZYNurse_BLL
{
    public class SelfPrepareDrug:LongDrugCommon
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)   
       {
           //List<int> grouplist = grouplist;
           string time;
           if (zy_doc_orderrecord.STATUS_FALG==4)//11月24日修改，增加自备药末次停和执行处理,自备药停操作
           {           
               time = servertime.ToString("yyyy-MM-dd");
               string strWhere = Tables.zy_nurse_orderexec.ORDER_ID + oleDb.EuqalTo() + orderid + oleDb.And() + Tables.zy_nurse_orderexec.PATIENT_ID + oleDb.EuqalTo() + zy_doc_orderrecord.PATID + oleDb.And() + Tables.zy_nurse_orderexec.EXEC_DATE + oleDb.EuqalTo() + "'" + time + "'";
               bool serchRusult = BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Exists(strWhere);
               if (serchRusult == false)
               {
                   string string1 = "op_date=" + "'" + servertime + "'";
                   string string2 = "oprerator=" + Employeeid;
                   BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update("order_id=" + orderid, string1, string2);
                   int group_id =zy_doc_orderrecord.GROUP_ID;
                   grouplist.Add(group_id);
                   int groupnum = grouplist.Count;
                   string order_usage = zy_doc_orderrecord.ORDER_USAGE;
                   base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                   base.insertlongorderexec(zy_doc_orderrecord, base.Employeeid, servertime);
                   if (groupnum == 1 || grouplist[groupnum - 1] != grouplist[groupnum - 2])
                   {
                       base.InsertDrugUsageFee(zy_doc_orderrecord.ORDER_ID, zy_doc_orderrecord.GROUP_ID, zy_doc_orderrecord.ORDER_USAGE, servertime, zy_doc_orderrecord);  
                   }
               }
               else
               {
                   base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
               }
           }
           else//正常自备药流程
           {
               DateTime lastexectime;
               string strWhere1 = Tables.zy_nurse_orderexec.ORDER_ID + oleDb.EuqalTo() + zy_doc_orderrecord.ORDER_ID + oleDb.And() + Tables.zy_nurse_orderexec.PATIENT_ID + oleDb.EuqalTo() + zy_doc_orderrecord.PATID;
               object obj = oleDb.GetDataResult("select max(exec_date) from ZY_NURSE_ORDEREXEC where order_id=" + zy_doc_orderrecord.ORDER_ID);
               if (obj != null && obj != DBNull.Value)
               {
                   int hour = servertime.Hour;
                   int minute = servertime.Minute;
                   int second = servertime.Second;
                   lastexectime = DateTime.Parse(obj.ToString());
                   lastexectime = lastexectime.Date.AddHours(hour).AddMinutes(minute).AddSeconds(second);
               }
               else
               {
                   lastexectime = servertime.AddDays(-1);
               }
               int days = servertime.Date.Subtract(lastexectime.Date).Days;

               int group_id = zy_doc_orderrecord.GROUP_ID;
               grouplist.Add(group_id);
               int groupnum = grouplist.Count;

               for (int j = 0; j < days; j++)
               {
                   DateTime exectime = lastexectime.AddDays(j + 1);
                   //time = servertime.ToString("yyyy-MM-dd");
                   string strWhere = Tables.zy_nurse_orderexec.ORDER_ID + oleDb.EuqalTo() + orderid + oleDb.And() + Tables.zy_nurse_orderexec.PATIENT_ID + oleDb.EuqalTo() + zy_doc_orderrecord.PATID + oleDb.And() + Tables.zy_nurse_orderexec.EXEC_DATE + oleDb.EuqalTo() + "'" + exectime.ToString("yyyy-MM-dd") + "'";
                   bool serchRusult = BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Exists(strWhere);
                   if (serchRusult == false)
                   {
                       string string1 = "op_date=" + "'" + exectime + "'";
                       string string2 = "oprerator=" + Employeeid;
                       BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update("order_id=" + orderid, string1, string2);
                       //int group_id = zy_doc_orderrecord.GROUP_ID;
                       //grouplist.Add(group_id);
                       //int groupnum = grouplist.Count;
                       string order_usage = zy_doc_orderrecord.ORDER_USAGE;
                       base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                       base.insertlongorderexec(zy_doc_orderrecord, base.Employeeid,exectime);
                       if (groupnum == 1 || grouplist[groupnum - 1] != grouplist[groupnum - 2])
                       {
                           base.InsertDrugUsageFee(zy_doc_orderrecord.ORDER_ID, zy_doc_orderrecord.GROUP_ID, zy_doc_orderrecord.ORDER_USAGE,exectime, zy_doc_orderrecord);
                       }
                   }
               }
           }
       }
    }
}
