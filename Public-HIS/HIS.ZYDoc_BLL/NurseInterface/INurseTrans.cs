using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZYDoc_BLL.NurseInterface
{
    public interface  INurseTrans
    {
        int transnurse { get; set; }　// 转抄护士
        DateTime transdate { get; set; }//转抄时间       
        /// <summary>
        /// 转抄医嘱 
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        bool TransOrders(List<HIS.Model.ZY_DOC_ORDERRECORD> orders);//转抄医嘱  

        /// <summary>
        /// 转抄医嘱
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="ordertype"></param>
        /// <returns></returns>
        bool TransOrders(int patlistid, OrderType ordertype);//转抄医嘱  

        /// <summary>
        /// 取消转抄医嘱
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        bool CancelTransOrders(List<HIS.Model.ZY_DOC_ORDERRECORD> orders);//取消转抄医嘱

    }
}
