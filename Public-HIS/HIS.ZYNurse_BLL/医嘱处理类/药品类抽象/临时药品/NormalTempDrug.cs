using System;
using System.Collections.Generic;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYNurse_BLL
{
    public class NormalTempDrug:TempDrugCommon
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)
        {
            //List<int> grouplist = grouplist;
            DateTime ServerDateTime = servertime;
            string time =servertime.ToString("yyyy-MM-dd");
            string strWhere = Tables.zy_nurse_orderexec.ORDER_ID + oleDb.EuqalTo() + orderid+ oleDb.And() + Tables.zy_nurse_orderexec.PATIENT_ID + oleDb.EuqalTo() +zy_doc_orderrecord.PATID + oleDb.And() + Tables.zy_nurse_orderexec.EXEC_DATE + oleDb.EuqalTo() + "'" + time + "'";
            bool serchResult = BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Exists(strWhere);
            if (serchResult == false)
            {
                int group_id = zy_doc_orderrecord.GROUP_ID;
                grouplist.Add(group_id);
                int groupnum = grouplist.Count;
                string order_usage =zy_doc_orderrecord.ORDER_USAGE;
                base.updateTempOrderFlag(zy_doc_orderrecord.ORDER_ID);
                base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid, servertime);
                if (groupnum == 1 || grouplist[groupnum - 1] != grouplist[groupnum - 2])
                {
                    base.InsertDrugFee(orderid, ServerDateTime, zy_doc_orderrecord);
                    base.InsertTempDrugUsageFee(orderid,zy_doc_orderrecord.GROUP_ID,zy_doc_orderrecord.ORDER_USAGE, ServerDateTime, zy_doc_orderrecord);                    
                }
                else
                {
                    base.InsertDrugFee(orderid, ServerDateTime, zy_doc_orderrecord);
                }
            }
        }                        
    }
}
