using System;
using System.Collections.Generic;
using System.Text;

using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYNurse_BLL
{
    public class AbstractDrug:AbstractOrderOperation
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)
        {
        }
        public virtual void InsertDrugFee(int order_id, DateTime server_datetime, ZY_DOC_ORDERRECORD zy_doc_orderrecord)
        {
        }
    }
}
