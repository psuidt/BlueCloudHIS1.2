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
    public class NormalDrug:LongDrugCommon
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)
        {
            DateTime lastexectime;
            string strWhere1 = Tables.zy_nurse_orderexec.ORDER_ID + oleDb.EuqalTo() + zy_doc_orderrecord.ORDER_ID + oleDb.And() + Tables.zy_nurse_orderexec.PATIENT_ID + oleDb.EuqalTo() +zy_doc_orderrecord.PATID;
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
                DateTime time=lastexectime.AddDays(j+1);
                if (zy_doc_orderrecord.ORDER_BDATE.ToString("yyyy-MM-dd") ==time.ToString("yyyy-MM-dd") && (zy_doc_orderrecord.FIRSET_TIMES == 0) && (zy_doc_orderrecord.TEMINAL_TIMES == 0))
                {
                    base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                    base.insertlongorderexec(zy_doc_orderrecord, base.Employeeid, servertime);
                }
                
                string strWhere = Tables.zy_nurse_orderexec.ORDER_ID + oleDb.EuqalTo() + zy_doc_orderrecord.ORDER_ID + oleDb.And() + Tables.zy_nurse_orderexec.PATIENT_ID + oleDb.EuqalTo() + zy_doc_orderrecord.PATID + oleDb.And() + Tables.zy_nurse_orderexec.EXEC_DATE + oleDb.EuqalTo() + "'" + time.ToString("yyyy-MM-dd") + "'";
                bool serchRusult = BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Exists(strWhere);
                if (serchRusult == false)
                {
                    //int group_id = zy_doc_orderrecord.GROUP_ID;
                    //grouplist.Add(group_id);
                    //int groupnum = grouplist.Count;
                    string order_usage = zy_doc_orderrecord.ORDER_USAGE;
                    base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                    base.insertlongorderexec(zy_doc_orderrecord, base.Employeeid,time);
                    if (groupnum == 1 || grouplist[groupnum - 1] != grouplist[groupnum - 2])
                    {
                        base.InsertDrugFee(zy_doc_orderrecord.ORDER_ID, time, zy_doc_orderrecord);
                        base.InsertDrugUsageFee(zy_doc_orderrecord.ORDER_ID, zy_doc_orderrecord.GROUP_ID, zy_doc_orderrecord.ORDER_USAGE, time, zy_doc_orderrecord);
                    }
                    else
                    {
                        base.InsertDrugFee(zy_doc_orderrecord.ORDER_ID, time, zy_doc_orderrecord);
                    }
                }
            }
        }       
    }
}
