using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HIS.SYSTEM.Core;

namespace HIS.EMR_BLL
{
    /// <summary>
    /// 手术记录
    /// </summary>
    public class OperaEmrRecord : EmrRecord
    {
        /// <summary>
        /// 病历记录
        /// </summary>
        public OperaEmrRecord()
            : base()
        {
        }
        /// <summary>
        /// 获得病人信息
        /// </summary>
        /// <param name="patlistId">病人就诊Id</param>
        /// <param name="recordTime">记录时间</param>
        /// <returns></returns>
        public XmlDocument GetPatInfo(int patlistId, DateTime recordTime)
        {
            XmlDocument xmlPatInfo = new XmlDocument();
            XmlNode node = xmlPatInfo.CreateElement("病人信息");
            xmlPatInfo.AppendChild(node);

            XmlNode basicNode = xmlPatInfo.CreateElement("基本信息");
            node.AppendChild(basicNode);

            XmlNode cureNode = xmlPatInfo.CreateElement("就诊信息");
            node.AppendChild(cureNode);

            HIS.Model.ZY_PatList patList = BindEntity<Model.ZY_PatList>.CreateInstanceDAL(_oleDb).GetModel(patlistId);
            HIS.Model.PatientInfo patInfo = BindEntity<Model.PatientInfo>.CreateInstanceDAL(_oleDb).GetModel(patList.PatID);

            #region 基本信息
            XmlNode childNode = xmlPatInfo.CreateElement("姓名");
            childNode.InnerText = "姓名：" + patInfo.PatName;
            basicNode.AppendChild(childNode);

            childNode = xmlPatInfo.CreateElement("性别");
            childNode.InnerText = "性别：" + patInfo.PatSex;
            basicNode.AppendChild(childNode);

            childNode = xmlPatInfo.CreateElement("年龄");
            childNode.InnerText = "年龄：" + CalculateAge(patInfo.PatBriDate);
            basicNode.AppendChild(childNode);

            childNode = xmlPatInfo.CreateElement("科室");
            childNode.InnerText = "科室：" + new GWMHIS.BussinessLogicLayer.Classes.Deptment(Convert.ToInt64(patList.CureDeptCode)).Name;
            basicNode.AppendChild(childNode);

            childNode = xmlPatInfo.CreateElement("床号");
            childNode.InnerText = "床号：" + patList.BedCode;
            basicNode.AppendChild(childNode);
            #endregion
            return xmlPatInfo;
        }
    }
}
