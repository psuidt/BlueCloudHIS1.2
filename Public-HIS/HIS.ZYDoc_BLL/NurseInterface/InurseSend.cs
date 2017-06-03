using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZYDoc_BLL.NurseInterface
{
    public interface InurseSend
    {

        /// <summary>
        /// 护士站发送医嘱，记费用
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        bool SendFee(List<HIS.Model.ZY_DOC_ORDERRECORD> orders);//护士站发送医嘱，记费用

        /// <summary>
        /// 护士站发送医嘱，记费用
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="ordertype"></param>
        /// <returns></returns>
        bool SendFee(int patlistid, OrderType ordertype);//护士站发送医嘱，记费用   
    }
}
