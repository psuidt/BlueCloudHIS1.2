using System;
using System.Collections.Generic;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYNurse_BLL
{
    public class OutHospitalDrug:TempDrugCommon
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)
        {
            base.updateTempOrderFlag(zy_doc_orderrecord.ORDER_ID);
            base.InsertDrugFee(orderid,servertime, zy_doc_orderrecord);
        }
    }
}
