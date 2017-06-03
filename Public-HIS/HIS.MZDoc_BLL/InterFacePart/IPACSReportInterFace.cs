using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MZDoc_BLL.InterFace
{
    /// <summary>
    /// PACS报告接口基类
    /// </summary>
    interface IPACSReportInterFace
    {
        /// <summary>
        /// 初始化接口
        /// </summary>
        /// <param name="info"></param>
        void InitReportPort(Public.MedicalReportInfo info);
        /// <summary>
        /// 获得医技结果报告
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        object GetMedicalResultReport(Public.MedicalReportInfo info);
        /// <summary>
        /// 获得医技结果报告
        /// </summary>
        /// <param name="info">医技报告信息</param>
        /// <returns>报告结果</returns>
        object GetMedicalResultImage(Public.MedicalReportInfo info);
        /// <summary>
        /// 释放报告接口
        /// </summary>
        void DisposeReportPort();
    }
}
