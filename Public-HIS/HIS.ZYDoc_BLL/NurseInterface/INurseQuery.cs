using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZYDoc_BLL.NurseInterface
{
    public interface INurseQuery
    {
        DataTable CashDataTable { get; set; }//缓存中间表 
        /// <summary>
        /// 得到科室内需要转抄的医嘱
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        DataTable GetDeptTransOrders(int deptid);

        /// <summary>
        /// 得到医嘱信息
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="order_type"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        DataTable GetOrders(int patlistid, OrderType ordertype, bool isAll);//得到医嘱信息
    }
}
