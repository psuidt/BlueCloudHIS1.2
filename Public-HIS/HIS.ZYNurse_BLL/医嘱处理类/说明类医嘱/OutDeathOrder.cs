using System;
using System.Collections.Generic;
using System.Text;

using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYNurse_BLL
{
    public class OutDeathOrder:AbstractStateOrder
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)
        {
            base.insertorderexec(orderid, base.Employeeid, servertime);
            base.updateTempOrderFlag(orderid);
            updateSendTime(orderid,servertime);
        }
    }
}
