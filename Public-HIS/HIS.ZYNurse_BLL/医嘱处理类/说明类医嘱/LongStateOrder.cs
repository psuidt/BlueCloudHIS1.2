using System;
using System.Collections.Generic;
using System.Text;

using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYNurse_BLL
{
    public class LongStateOrder:AbstractStateOrder
    {     
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord,List<int> grouplist)
        {
            //DateTime time = servertime;
            if (zy_doc_orderrecord.STATUS_FALG == 4)
            {
                base.updateLongOrderFlag(orderid);
            }
            else
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

                for (int j = 0; j < days; j++)
                {
                    DateTime time = lastexectime.AddDays(j + 1);
                    string strWhere = Tables.zy_nurse_orderexec.ORDER_ID + oleDb.EuqalTo() + zy_doc_orderrecord.ORDER_ID + oleDb.And() + Tables.zy_nurse_orderexec.PATIENT_ID + oleDb.EuqalTo() + zy_doc_orderrecord.PATID + oleDb.And() + Tables.zy_nurse_orderexec.EXEC_DATE + oleDb.EuqalTo() + "'" + time.ToString("yyyy-MM-dd") + "'";
                    bool serchRusult = BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Exists(strWhere);
                    if (serchRusult == false)
                    {
                        //base.insertlongorderexec(zy_doc_orderrecord, base.Employeeid, time);
                        base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid,time);
                        base.updateLongOrderFlag(orderid);
                        updateSendTime(orderid, servertime);
                    }
                }
            }
        }
    }
}
