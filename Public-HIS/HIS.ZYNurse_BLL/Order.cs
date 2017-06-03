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
    public class Order : BaseBLL
    {
        public bool Send(List<int> orderidlist, int employee_id, int patlist_id)
        {
            try
            {
                int patlistid = patlist_id;
                List<int> orderid = orderidlist;
                List<int> grouplist = new List<int>();
                DateTime ServerDateTime = XcDate.ServerDateTime;
                string exceptionString = "";
                for (int arraynum = 0; arraynum < orderid.Count; arraynum++)
                {
                    ZY_DOC_ORDERRECORD orderrecord = new ZY_DOC_ORDERRECORD();
                    string strwhere1 = "order_id=" + orderid[arraynum];
                    orderrecord = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetModel(orderid[arraynum]);
                    if (orderrecord.STATUS_FALG == 5) //防止同时打开多个窗口，临嘱点两次发送时产生两次费用的并发问题 2010.10.14 add by heyan
                    {
                        continue;
                    }
                    AbstractOrderOperation concreteOrder = OrderOperationFactory.CreateConcreteOrder(orderrecord);
                    concreteOrder.Zy_doc_orderrecord = orderrecord;
                    concreteOrder.Employeeid = employee_id;
                    concreteOrder.ServerTime = ServerDateTime;
                    try
                    {
                        oleDb.BeginTransaction();
                        concreteOrder.Send(orderid[arraynum], ServerDateTime, orderrecord, grouplist);
                        oleDb.CommitTransaction();
                    }
                    catch(Exception e)
                    {
                        exceptionString += e.Message;
                        oleDb.RollbackTransaction();
                        continue;
                       
                    }
                }
                if (exceptionString != "")
                {
                    throw new Exception(exceptionString);
                }
                return true;
            }
            catch (Exception e)
            {
               // throw e;  
                throw new Exception(e.Message);
            }
        }
    }
}
