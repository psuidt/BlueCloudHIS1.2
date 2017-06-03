using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MZDoc_BLL.InterFace
{
    /// <summary>
    /// 医技报告接口
    /// </summary>
    public class MedicalReportInterFace : IBaseInterFace
    {
        IPACSReportInterFace PACSReport;  //PACS报告
        ILISReportInterFace LISReport;  //LIS报告

        /// <summary>
        /// 医技报告接口构造函数
        /// </summary>
        public MedicalReportInterFace()
        {
            PACSReport = MedicalReportFactory.CreatePACSReportObject(); 
            LISReport = MedicalReportFactory.CreateLISReportObject();
        }

        /// <summary>
        /// 初始化报告接口
        /// </summary>
        /// <param name="info">医技报告信息</param>
        public void InitReportPort(Public.MedicalReportInfo info)
        {
            if (PACSReport != null)
            {
                PACSReport.InitReportPort(info);
            }
            if (LISReport != null)
            {
                LISReport.InitReportPort(info);
            }
        }
        /// <summary>
        /// 获得医技结果报告
        /// </summary>
        /// <param name="medicalApplyType">医技类型</param>
        /// <param name="info">医技报告信息</param>
        /// <returns>报告结果</returns>
        public object GetMedicalResultReport(Public.MedicalApplyType medicalApplyType, Public.MedicalReportInfo info)
        {
            switch (medicalApplyType)
            {
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技检查申请:
                    if (PACSReport != null)
                    {
                        return PACSReport.GetMedicalResultReport(info);
                    }
                    break;
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技化验申请:
                    if (LISReport != null)
                    {
                        return LISReport.GetMedicalResultReport(info);
                    }
                    break;
                default:
                    break;
            }
            return null;
        }
        /// <summary>
        /// 获得医技结果报告的图片
        /// </summary>
        /// <param name="medicalApplyType">医技类型</param>
        /// <param name="info">医技报告信息</param>
        /// <returns>报告结果</returns>
        public object GetMedicalResultImage(Public.MedicalApplyType medicalApplyType, Public.MedicalReportInfo info)
        {
            switch (medicalApplyType)
            {
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技检查申请:
                    if (PACSReport != null)
                    {
                        return PACSReport.GetMedicalResultImage(info);
                    }
                    break;
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技化验申请:
                    if (LISReport != null)
                    {
                        return LISReport.GetMedicalResultImage(info);
                    }
                    break;
                default:
                    break;
            }
            return null;
        }
        /// <summary>
        /// 释放报告接口
        /// </summary>
        public void DisposeReportPort()
        {
            if (PACSReport != null)
            {
                PACSReport.DisposeReportPort();
            }
            if (LISReport != null)
            {
                LISReport.DisposeReportPort();
            }
        }
    }
}
