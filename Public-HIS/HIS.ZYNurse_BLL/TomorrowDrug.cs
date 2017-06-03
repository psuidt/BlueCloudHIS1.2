using System;
using System.Collections.Generic;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.DatabaseAccessLayer;

namespace HIS.ZYNurse_BLL
{
    public class TomorrowDrug : BaseBLL
    {
        public bool Send(List<int> orderidlist, int employee_id, int patlist_id)
        {
            try
            {
                int patlistid = patlist_id;
                List<int> orderid = orderidlist;
                List<int> grouplist = new List<int>();
                DateTime ServerDateTime = XcDate.ServerDateTime.Date.AddDays(1).AddHours(14);
                
                for (int arraynum = 0; arraynum < orderid.Count; arraynum++)
                {
                    try
                    {
                        oleDb.BeginTransaction();
                        ZY_DOC_ORDERRECORD orderrecord = new ZY_DOC_ORDERRECORD();
                        string strwhere1 = "order_id=" + orderid[arraynum];
                        orderrecord = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetModel(orderid[arraynum]);
                        AbstractOrderOperation concreteOrder = OrderOperationFactory.CreateConcreteOrder(orderrecord);
                        concreteOrder.Zy_doc_orderrecord = orderrecord;
                        concreteOrder.Employeeid = employee_id;
                        concreteOrder.ServerTime = ServerDateTime;
                        concreteOrder.Send(orderid[arraynum], ServerDateTime, orderrecord, grouplist);
                        oleDb.CommitTransaction();
                    }
                    catch
                    {
                        oleDb.RollbackTransaction();
                    }
                }
                
                return true;
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
    }
}
