using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.Interface
{
    /// <summary>
    /// 门诊数据接口
    /// </summary>
    public interface IMZ_Data
    {
        /// <summary>
        /// 按发票号检索门诊待发药病人
        /// </summary>
        /// <param name="inVoiceNum">发票号</param>
        /// <returns>门诊发药病人</returns>
        Structs.FY_MZ_Patient GetPatient( string PerfChar, string inVoiceNum,int deptId, int drFlag);

        /// <summary>
        /// 按执行科室ID检索待发药病人
        /// </summary>
        /// <param name="deptId">执行科室ID</param>
        /// <returns>门诊待发药病人</returns>
        List<Structs.FY_MZ_Patient> GetPatient(int deptId, DateTime? beginTime, DateTime endDateTime, int drFlag);

        /// <summary>
        /// 检索一个病人的所有处方头信息
        /// </summary>
        /// <param name="queryPat">门诊发药病人</param>
        /// <returns>处方头列表</returns>
        DataTable GetPrescriptions(Structs.FY_MZ_Patient queryPat, int drFlag);

        /// <summary>
        /// 按处方头检索处方明细信息
        /// </summary>
        /// <param name="queryPrescription">处方头</param>
        /// <returns>处方明细列表</returns>
        /// 处方明细表字段数据
        /// 药品化学名 string  ---
        /// 厂家典ID int ---
        /// 规格典ID int ---
        /// 药品单位ID int ---
        /// 单位数量（划价系数） int ---
        /// 发药数量 int ---
        /// 发药剂量 int ---
        /// 药品零售价 decimal ---
        /// 药品批发价 decimal ---
        /// 药品零售金额 decimal ---
        /// 药品单位名 string ---
        /// 药品生产厂家名称 string ---
        /// 药品规格 string ---
        DataTable GetPrescriptionDetails(Structs.Prescription queryPrescription);

        /// <summary>
        /// 打印输液卡
        /// </summary>
        /// <param name="invoiceNo">对应发票号</param>
        /// <param name="printer">打印人姓名</param>
        void PrintTransfuCard(string invoiceNo, string printer);

        /// <summary>
        /// 打印处方
        /// </summary>
        /// <param name="presHeadId">处方头ID</param>
        void PrintDocPres(long presHeadId);
    }  
}
