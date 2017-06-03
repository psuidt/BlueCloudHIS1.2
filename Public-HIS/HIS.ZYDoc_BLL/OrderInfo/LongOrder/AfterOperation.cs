using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYDoc_BLL.OrderInfo 
{
   partial  class AfterOperation:BaseBLL
    {
        #region 术后医嘱，产后医嘱插入一条医嘱
        /// <summary>
        /// 术后医嘱，产后医嘱插入一条医嘱
        /// </summary>
        /// <param name="order_context"></param>
        /// <returns></returns>
       public bool AfterPeration(string order_context, int patdeptid, int presdeptid, int docid, int patlistid)
       {
           int groupid = PubMethd.GetGroupMax(patlistid, 0);
           HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
           record.GROUP_ID = groupid;
           record.PATID = patlistid;
           record.PAT_DEPTID = patdeptid;
           record.PRES_DEPTID = presdeptid;
           record.ORDER_DOC = docid;
           record.ORDER_TYPE = 0;
           record.ITEM_TYPE = 10;
           record.ORDITEM_ID = -1;
           record.ORDER_CONTENT = order_context;
           record.AMOUNT = 0;
           record.PRES_AMOUNT = 0;
           record.UNIT = "";
           record.ORDER_BDATE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
           record.FIRSET_TIMES = 0;
           record.ORDER_USAGE = "";
           record.FREQUENCY = "";
           record.DELETE_FLAG = 0;
           record.STATUS_FALG = 1;
           record.BABYID = 0;
           record.EXEC_DEPT = presdeptid;
           record.SERIAL_ID = 0;
           record.ORECORD_A2 = 1;
           BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Add(record);
           return true;
          
       }
        #endregion
    }
}
