using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Xml;
using System.Data;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.EMR_BLL
{
    /// <summary>
    /// 病历操作类
    /// </summary>
    public class OP_EmrRecord:BaseBLL
    {
        /// <summary>
        /// 获得病程记录
        /// </summary>
        /// <param name="patId">病人Id</param>
        /// <param name="patListId">病人就诊Id</param>
        /// <param name="emrTypeCode">病历类型代码</param>
        /// <returns></returns>
        public static DataTable GetDiseaseCourseRecord(long patId, long patListId, string emrTypeCode)
        {
            string strSql = HIS.BLL.Tables.emr_record.PATID + oleDb.EuqalTo() + patId + oleDb.And() +
                HIS.BLL.Tables.emr_record.PATLISTID + oleDb.EuqalTo() + patListId + oleDb.And() +
                HIS.BLL.Tables.emr_record.RECORDTYPE + oleDb.EuqalTo() + "'" + emrTypeCode.Trim() + "'" + oleDb.And() +
                HIS.BLL.Tables.emr_record.RECORDFLAG + oleDb.EuqalTo() + 0;
            return BindEntity<Model.Emr_Record>.CreateInstanceDAL(oleDb).GetList(strSql);
        }
        /// <summary>
        /// 获取病人病历记录
        /// </summary>
        /// <param name="patId">病人Id</param>
        /// <param name="emrTypeCode">病历类型代码</param>
        /// <returns></returns>
        public static DataTable GetPatRecord(long patId, string emrTypeCode)
        {
            string strSql = @"select a.*,b.elementname as emrtypename,c.patname,d.name as empname,e.name as deptname
                                from db2inst2.emr_record a
                                left join emr_base_element b on a.recordtype=b.elementcode
                                left join patientinfo c on a.patid=c.patid
                                left join base_employee_property d on a.recordcreateemp=d.employee_id
                                left join base_dept_property e on a.recordcreatedept=e.dept_id
                                where a.recordflag=0 and recordtype='" + emrTypeCode + "' and a.delete_bit=0  and a.patid =" + patId + " and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID;
            return oleDb.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="patlistId">病人</param>
        /// <param name="mzZyFlag">病人就诊Id</param>
        /// <param name="recordTime">记录时间</param>
        /// <returns></returns>
        public static XmlDocument GetPatInfo(int patlistId,int mzZyFlag,DateTime recordTime)
        {
            XmlDocument xmlPatInfo = new XmlDocument();
            XmlNode node = xmlPatInfo.CreateElement("病人信息");
            xmlPatInfo.AppendChild(node);

            XmlNode basicNode = xmlPatInfo.CreateElement("基本信息");
            node.AppendChild(basicNode);

            XmlNode cureNode = xmlPatInfo.CreateElement("就诊信息");
            node.AppendChild(cureNode);

            if (mzZyFlag == 0)
            {
                HIS.Model.MZ_PatList patList = BindEntity<Model.MZ_PatList>.CreateInstanceDAL(oleDb).GetModel(patlistId);
                HIS.Model.PatientInfo patInfo = BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).GetModel(Convert.ToInt32(patList.PatID));

                #region 基本信息
                XmlNode childNode = xmlPatInfo.CreateElement("姓名");
                childNode.InnerText = "姓名："+patInfo.PatName;
                basicNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("科室");
                childNode.InnerText = "科室：" + patList.REG_DEPT_NAME;
                basicNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("门诊号");
                childNode.InnerText = "门诊号：" +patList.VisitNo;
                basicNode.AppendChild(childNode);
                #endregion

                #region 就诊信息
                childNode = xmlPatInfo.CreateElement("姓名");
                childNode.InnerText = "姓名：" + patInfo.PatName;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("民族");
                childNode.InnerText = "民族：" + patInfo.PatGroup;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("性别");
                childNode.InnerText = "性别：" + patInfo.PatSex;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("职业");
                childNode.InnerText = "职业：" + patInfo.PATJOB;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("年龄");
                childNode.InnerText = "年龄：" + patList.Age.ToString().Trim()+patList.HpGrade.Trim();
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("籍贯");
                childNode.InnerText = "籍贯：";
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("联系电话");
                childNode.InnerText = "联系电话：" + patInfo.PatTEL;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("住址");
                childNode.InnerText = "住址：" + patInfo.PatAddress;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("就诊日期");
                childNode.InnerText = "就诊日期：" + patList.CureDate.ToLongDateString() + " "+patList.CureDate.ToLongTimeString();
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("记录日期");
                childNode.InnerText = "记录日期：" + recordTime.ToLongDateString() + " " + recordTime.ToLongTimeString();
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("病史陈述者");
                childNode.InnerText = "病史陈述者：患者本人";
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("可靠性");
                childNode.InnerText = "可靠性：可靠";
                cureNode.AppendChild(childNode);
                #endregion
            }
            else
            {
                HIS.Model.ZY_PatList patList = BindEntity<Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(patlistId);
                HIS.Model.PatientInfo patInfo = BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).GetModel(patList.PatID);

                #region 基本信息
                XmlNode childNode = xmlPatInfo.CreateElement("姓名");
                childNode.InnerText = "姓名：" + patInfo.PatName;
                basicNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("科室");
                //childNode.InnerText = "科室：" + new GWMHIS.BussinessLogicLayer.Classes.Deptment(Convert.ToInt64(patList.CureDeptCode)).Name;
                if (mzZyFlag == 1)
                    childNode.InnerText = "入院记录";
                else if (mzZyFlag == 2)
                    childNode.InnerText = "出院记录";
                else if (mzZyFlag == 3)
                    childNode.InnerText = "死亡记录";
                basicNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("住院号");
                childNode.InnerText = "住院号：" + patInfo.CureNo;
                basicNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("入院时间");
                childNode.InnerText = patList.CureDate.ToLongDateString();
                basicNode.AppendChild(childNode);

                if (mzZyFlag == 3)
                {
                    childNode = xmlPatInfo.CreateElement("死亡时间");
                    childNode.InnerText = patList.OutDate.ToLongDateString();
                    basicNode.AppendChild(childNode);
                }
                else
                { 
                    childNode = xmlPatInfo.CreateElement("出院时间");
                    childNode.InnerText = patList.OutDate.ToLongDateString();
                    basicNode.AppendChild(childNode);
                }

                childNode = xmlPatInfo.CreateElement("住院天数");
                childNode.InnerText = (XcDate.ServerDateTime - patList.CureDate).Days +"天";//patList.ReaLiveNum.ToString() + "天";
                basicNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("入院诊断");
                childNode.InnerText = patList.DiseaseName;
                basicNode.AppendChild(childNode);
                #endregion

                #region 就诊信息
                #region 计算病人年龄
                string patAge = "";
                DateTime currentDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                if (patInfo.PatBriDate.Year != currentDate.Year && patInfo.PatBriDate.Date.AddYears(1) <= currentDate.Date)
                {
                    patAge = currentDate.Year - patInfo.PatBriDate.Year + "岁";
                }
                else if (patInfo.PatBriDate.Month != currentDate.Month && patInfo.PatBriDate.Date.AddMonths(1) <= currentDate.Date)
                {
                    int age = currentDate.Month - patInfo.PatBriDate.Month;
                    if (age < 0)
                    {
                        age += 12;
                    }
                    patAge = age + "月";
                }
                else if (patInfo.PatBriDate.Day != currentDate.Day && patInfo.PatBriDate.Date.AddDays(1) <= currentDate.Date)
                {
                    patAge = (currentDate - patInfo.PatBriDate).Days + "天";
                }
                else
                {
                    patAge = (currentDate - patInfo.PatBriDate).Hours + "小时";
                }
                #endregion

                childNode = xmlPatInfo.CreateElement("姓名");
                childNode.InnerText = "姓名：" + patInfo.PatName;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("出生地");
                childNode.InnerText = "出生地：" + "";
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("性别");
                childNode.InnerText = "性别：" + patInfo.PatSex;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("民族");
                childNode.InnerText = "民族：" + patInfo.PatGroup;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("年龄");
                childNode.InnerText = "年龄：" + patAge;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("职业");
                childNode.InnerText = "职业：" + patInfo.PATJOB;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("婚姻");
                childNode.InnerText = "婚姻：" + "";
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("住址");
                childNode.InnerText = "住址：" + patInfo.PatAddress;
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("入院日期");
                childNode.InnerText = "入院时间：" + patList.CureDate.ToLongDateString() + " " + patList.CureDate.ToLongTimeString();
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("记录日期");
                childNode.InnerText = "记录时间：" + recordTime.ToLongDateString() + " " + recordTime.ToLongTimeString();
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("病史陈述者");
                childNode.InnerText = "病史陈述者：患者本人";
                cureNode.AppendChild(childNode);

                childNode = xmlPatInfo.CreateElement("可靠性");
                childNode.InnerText = "可靠程度：认为可靠";
                cureNode.AppendChild(childNode);
                #endregion
            }
            return xmlPatInfo;
        }
    }
}
