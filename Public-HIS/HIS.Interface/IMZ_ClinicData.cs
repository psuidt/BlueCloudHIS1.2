using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.Interface
{
    /// <summary>
    /// 门诊临床数据接口
    /// </summary>
    public interface IMZ_ClinicData
    {
        /// <summary>
        /// 获取病人未收费处方明细
        /// </summary>
        /// <param name="patListId">门诊病人就诊Id</param>
        /// <returns>门诊收费处方结构体组</returns>
        HIS.Interface.Structs.Prescription[] GetPrescriptions(int patListId);

        /// <summary>
        /// 修改病人处方状态
        /// </summary>
        /// <param name="presHeadId">处方头ID</param>
        /// <param name="status">处方状态 1:收费，2:退费</param>
        /// <returns></returns>
        bool ChangePresStatus(int presHeadId, int status);

        /// <summary>
        /// 检查处方状态
        /// </summary>
        /// <param name="presHeadId">处方头Id</param>
        /// <returns></returns>
        bool CheckPresStatus(int presHeadId);

        /// <summary>
        /// 获取住院证信息
        /// </summary>
        /// <param name="regId">住院证ID</param>
        /// <returns>住院证信息数据表</returns>
        DataTable GetInpatRegInfo(int regId);

        /// <summary>
        /// 获取门诊输液卡打印数据
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <param name="printer"></param>
        /// <returns></returns>
        HIS.Interface.Structs.PrintInfo GetTransfuCardPrintInfo(string invoiceNo, string printer);

        /// <summary>
        /// 获取门诊处方打印数据
        /// </summary>
        /// <param name="presHeadId">门诊收费处方头ID</param>
        /// <returns></returns>
        HIS.Interface.Structs.PrintInfo GetDocPresPrintInfo(long presHeadId);



        /// <summary>
        /// 由门诊处方头id得到处方金额
        /// </summary>
        /// <param name="presheadid"></param>
        /// <returns></returns>
        decimal GetMzDocPresTotalMoney(int presheadid);
        
    }
}
