using System;
using System.Collections.Generic;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.Model;

namespace HIS.ZYNurse_BLL
{
    public abstract class AbstractStateOrder:AbstractOrderOperation
    {
        protected void updateSendTime(int orderid,DateTime ServerDateTime)
        {
            string string1 = "op_date=" + "'" + ServerDateTime + "'";
            string string2 = "oprerator=" + Employeeid;
            BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update("order_id=" + orderid, string1, string2);
        }
    }
}
