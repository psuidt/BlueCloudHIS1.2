using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.MZDoc_BLL.InterFace
{
    /// <summary>
    /// 华奕PACS报告接口类
    /// </summary>
    internal class PACSReport_Great:IPACSReportInterFace
    {
        [DllImport("PlugInVisit.dll")]
        extern static bool hyInitHinstance(IntPtr Handle);
        [DllImport("PlugInVisit.dll")]
        extern static bool hyOpenPACSImageView(StringBuilder cPaitentID, StringBuilder cReqNum);
        [DllImport("PlugInVisit.dll")]
        extern static bool hyGetPACSReportView(StringBuilder cPaitentID, StringBuilder cReqNum, string cFilePath);
        [DllImport("PlugInVisit.dll")]
        extern static bool hyFreeHinstance();

        /// <summary>
        /// 初始化报告接口
        /// </summary>
        /// <param name="info">医技报告信息</param>
        public void InitReportPort(Public.MedicalReportInfo info)
        {
            try
            {
                hyInitHinstance(info.FormHandle);
            }
            catch
            { }
        }
        /// <summary>
        /// 获得医技结果报告
        /// </summary>
        /// <param name="info">医技报告信息</param>
        /// <returns>报告结果</returns>
        public object GetMedicalResultReport(Public.MedicalReportInfo info)
        {
            Public.StaticConfig.CurrentReportFormat = HIS.MZDoc_BLL.Public.MedicalReportFormat.图片;
            Bitmap image = null;
            StringBuilder cPaitentID = new StringBuilder(info.Patid.ToString());
            StringBuilder cReqNum = new StringBuilder(info.PresListId.ToString());
            string filePath = "temp.bmp";
            if (hyGetPACSReportView(cPaitentID, cReqNum, filePath))
            {
                image = new Bitmap(Constant.ApplicationDirectory + "//Buffer//" + filePath);
            }
            return image;
        }
        /// <summary>
        /// 获得医技结果报告
        /// </summary>
        /// <param name="info">医技报告信息</param>
        /// <returns>报告结果</returns>
        public object GetMedicalResultImage(Public.MedicalReportInfo info)
        {
            Public.StaticConfig.CurrentReportFormat = HIS.MZDoc_BLL.Public.MedicalReportFormat.无返回;
            StringBuilder cPaitentID = new StringBuilder(info.Patid.ToString());
            StringBuilder cReqNum = new StringBuilder(Convert.ToString(info.PresListId));
            hyOpenPACSImageView(cPaitentID, cReqNum);
            return null;
        }
        /// <summary>
        /// 释放报告接口
        /// </summary>
        public void DisposeReportPort()
        {
            try
            {
                hyFreeHinstance();
            }
            catch
            { }
        }
    }
}
