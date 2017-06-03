using System;
using System.Collections.Generic;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYNurse_BLL
{
    public class PsStatementOrder:TempDrugCommon
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)
        {
            string time;
            DateTime ServerDateTime = servertime;
            //List<int> grouplist = grouplist;  
            if (zy_doc_orderrecord.PS_ORDERID!= Convert.ToDecimal(0) &&zy_doc_orderrecord.PS_FLAG==0)
            {
               
            }                   
            else if (zy_doc_orderrecord.ITEM_CODE=="")//  zy_doc_orderrecord.AMOUNT== Convert.ToDecimal(0)) update by heyan  皮试说明数量医生可以修改，不能以数量判断
            {
                string string1 = "op_date=" + "'" + servertime + "'";
                string string2 = "oprerator=" + Employeeid;
                BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update("order_id=" + orderid, string1, string2);
                time = XcDate.ServerDateTime.ToString("yyyy-MM-dd");
                string strWhere = Tables.zy_nurse_orderexec.ORDER_ID + oleDb.EuqalTo() + orderid + oleDb.And() + Tables.zy_nurse_orderexec.PATIENT_ID + oleDb.EuqalTo() +zy_doc_orderrecord.PATID + oleDb.And() + Tables.zy_nurse_orderexec.EXEC_DATE + oleDb.EuqalTo() + "'" + time + "'";
                bool serchRusult = BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Exists(strWhere);
                if (serchRusult == false)
                {
                    int group_id = zy_doc_orderrecord.GROUP_ID;
                    grouplist.Add(group_id);
                    int groupnum = grouplist.Count;
                    string order_usage = zy_doc_orderrecord.ORDER_USAGE;
                    base.updateTempOrderFlag(zy_doc_orderrecord.ORDER_ID);
                    base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid, servertime);
                    base.InsertTempDrugUsageFee(orderid, zy_doc_orderrecord.GROUP_ID, zy_doc_orderrecord.ORDER_USAGE, ServerDateTime, zy_doc_orderrecord);                            
                }                
            }                       
        }
    }
}
