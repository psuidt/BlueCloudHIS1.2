using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Model;

namespace HIS.Interface
{
    public interface IZY_Data
    {
        /// <summary>
        /// 根据科室ID获取发药消息头列表
        /// </summary>
        /// <param name="deptId">发药科室ID</param>
        /// <returns>发药消息头列表</returns>
        List<ZY_DRUGMESSAGE_MASTER> GetDrugMsgMaster();
        List<ZY_DRUGMESSAGE_MASTER> GetDrugMsgMaster(int deptid);

        /// <summary>
        /// 根据发药消息头获取发药消息明细
        /// </summary>
        /// <param name="queryMaster">发药消息头</param>
        /// <returns>发药消息明细</returns>
        DataTable GetDrugMsgOrder(ZY_DRUGMESSAGE_MASTER queryMaster);

        /// <summary>
        /// 根据发药消息头获取发药消息明细
        /// </summary>
        /// <param name="queryMaster">发药消息头</param>
        /// <returns>发药消息明细</returns>
        DataTable GetDrugMsgOrder(int dispHisId);

        /// <summary>
        /// 根据住院号获取住院病人卡信息
        /// </summary>
        /// <param name="cureNo">住院号</param>
        /// <returns>病人卡数据源</returns>
        DataRow GetPatCardInfo(string cureNo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderrecipeid"></param>
        void UpdateSendFlag(int orderrecipeid, int drFlag, decimal drugnum, decimal retailfee);

        /// <summary>
        /// 药品打缺
        /// </summary>
        /// <param name="orderrecipeid">记账明细ＩＤ</param>
        /// <param name="chargeTime">记账时间</param>
        void UpdateNoDrugFlag(int orderrecipeid, DateTime chargeTime);

        /// <summary>
        /// 获取医嘱内容
        /// </summary>
        /// <param name="docOrderId">医嘱ID</param>
        /// <returns>医嘱内容</returns>
        string GetDocOrderInfo(int docOrderId);

        /// <summary>
        /// 获取发药明细数量金额
        /// </summary>
        /// <param name="durgMsgOrder">发药明细表</param>
        /// <returns></returns>
        bool GetSendNumAndFee(DataTable drugMsgOrder);

        /// <summary>
        /// 获取某条医嘱明细的用法大类
        /// </summary>
        /// <param name="docOrderId">医嘱明细ID</param>
        /// <returns>用法大类</returns>
        DataTable GetUseType(int docOrderId);

        /// <summary>
        /// 获取住院人员年龄
        /// </summary>
        /// <param name="cureNo">住院号</param>
        /// <returns>病人年龄</returns>
        string GetPatAge(string cureNo, DateTime currentTime);
    }
}
