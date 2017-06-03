using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MZDoc_BLL.InterFace
{
    /// <summary>
    /// 医技报告接口实例创建工厂类
    /// </summary>
    internal class MedicalReportFactory
    {
        /// <summary>
        /// 创建PACS报告接口实例
        /// </summary>
        /// <returns>PACS报告接口实例</returns>
        public static IPACSReportInterFace CreatePACSReportObject()
        {
            string[] medicalReportType = OP_ReadBaseData.GetConfigValue("009").Split(',');
            if (medicalReportType.Length > 0)
            {
                switch (medicalReportType[0])
                {
                    case "华奕":
                        return new HIS.MZDoc_BLL.InterFace.PACSReport_Great();
                    default:
                        return null;
                }
            }
            return null;
        }
        /// <summary>
        /// 创建LIS报告接口实例
        /// </summary>
        /// <returns>LIS报告接口实例</returns>
        public static ILISReportInterFace CreateLISReportObject()
        {
            string[] medicalReportType = OP_ReadBaseData.GetConfigValue("009").Split(',');
            if (medicalReportType.Length > 1)
            {
                switch (medicalReportType[1])
                {
                    case "华奕":
                        return new HIS.MZDoc_BLL.InterFace.LISReport_Great();
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
