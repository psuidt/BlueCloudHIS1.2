using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using System.Xml;

namespace HIS.EMR_BLL
{
    /// <summary>
    /// 病历上传操作类
    /// </summary>
    public class OP_EmrDataUpdate : BaseBLL
    {
        #region HIS中查询
        /// <summary>
        /// 获得病人列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEmrPatList(bool hadUpdate)
        {
            string strSql = @"select distinct b.*
                                from DB2INST2.EMR_RECORD a 
                                left join PATIENTINFO b on a.patid=b.patid 
                                where a.RECORDFLAG=0 and a.DELETE_BIT=0 and a.UpdateFlag=" + (hadUpdate?1:0) + " and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID;
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获得病历列表
        /// </summary>
        /// <param name="patIdList"></param>
        /// <returns></returns>
        public static DataTable GetEmrRecord(string patIdList, bool hadUpdate)
        {
            string strSql = @"select a.*,b.elementname as emrtypename,c.patname,d.name as empname,e.name as deptname
                                from db2inst2.emr_record a
                                left join emr_base_element b on a.recordtype=b.elementcode
                                left join patientinfo c on a.patid=c.patid
                                left join base_employee_property d on a.recordcreateemp=d.employee_id
                                left join base_dept_property e on a.recordcreatedept=e.dept_id
                                where a.recordflag=0 and a.delete_bit=0 and a.updateflag=" + (hadUpdate ? 1 : 0) + " and a.patid in(" + patIdList + ") and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID;
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获得门诊处方信息
        /// </summary>
        /// <param name="patListId">病人就诊Id</param>
        /// <returns></returns>
        public static DataTable GetMzcfRecord(long patListId)
        {
            string strSql = @"select distinct 
                           c.curedate, 
                           d.name as doc_name, 
                           b.*,
                           e.name as frequency_name,
                           f.name as usage_name,
                           a.pres_date,
                           g.address
                           from mz_doc_preshead a
                           left join mz_doc_preslist b on a.presheadid=b.presheadid
                           left join mz_patlist c on a.patlistid=c.patlistid
                           left join base_employee_property d on a.pres_doc=d.employee_id
                           left join base_frequency e on b.frequency_id=e.id
                           left join base_usagediction f on b.usage_id=f.id
                           left join vi_clinical_drug g on b.item_id=g.itemid
                           where c.patlistid=" + patListId + " and a.prestype<>'00' and a.pres_flag=1 and b.delete_bit=0 and a.workid=" + 
                                               HIS.SYSTEM.Core.EntityConfig.WorkID + " order by b.presheadid,b.orderno";
            //h.batchnum  //left join yk_batch h on b.item_id=h.makerdicid
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获得住院处方信息
        /// </summary>
        /// <param name="patListId"></param>
        /// <returns></returns>
        public static DataTable GetZycfRecord(long patListId)
        {
            string strSql = @"select distinct b.order_id,c.curedate,b.order_content,b.order_spec,d.address,a.amount as sl,b.unit,b.order_price,b.order_usage,b.amount,b.unit as usage_uit,b.frequency,e.name,b.order_bdate,a.presorderid
                             from zy_presorder a 
                             inner join zy_doc_orderrecord b on a.order_id=b.order_id 
                             left join zy_patlist c on b.patid=c.patlistid
                             left join vi_clinical_drug d on b.orditem_id=d.itemid
                             left join base_employee_property e on b.order_doc=e.employee_id
                             where a.record_flag=1 and a.PRESTYPE in('1','2','3') and a.patlistid=" + patListId + " and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " order by b.order_bdate";
            return oleDb.GetDataTable(strSql);
        }
        #endregion

        #region 上传数据
        /// <summary>
        /// 上传病历记录
        /// </summary>
        /// <param name="records">病历记录列表</param>
        public static void UploaEmrRecord(string dahId, List<EmrRecord> records)
        {
            foreach (EmrRecord record in records)
            {
                switch (record.RecordType.Trim())
                {
                    case "01":
                        Upload_Clinic_Medical_Records(dahId,record);
                        break;
                    case "02":
                        Upload_To_Hospital_Records(dahId, record);
                        break;
                    case "03":
                        Upload_In_Hospital_Records(dahId, record);
                        break;
                    case "04":
                        Upload_Out_Hospital_Records(dahId, record);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 获得健康档案病人信息
        /// </summary>
        /// <param name="patName">病人姓名</param>
        public static DataTable GetPatFileId(string patName)
        {
            CHIService service = new CHIService();
            XmlDocument result = new XmlDocument();
            result.LoadXml(service.getPatientInfo("name", patName));
            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                DataTable table = new DataTable();
                foreach (XmlNode node in result.SelectSingleNode("chs/table/row").ChildNodes)
                {
                    table.Columns.Add(node.Name, Type.GetType("System.String"));
                }
                foreach (XmlNode node in result.SelectSingleNode("chs/table").ChildNodes)
                {
                    DataRow row = table.NewRow();
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        row[childNode.Name] = childNode.InnerText;
                    }
                    table.Rows.Add(row);
                }
                return table;
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }

        /// <summary>
        /// 获得健康档案病人档案号ID
        /// </summary>
        /// <param name="mediCard"></param>
        /// <param name="patName"></param>
        /// <returns></returns>
        public static string GetPatFileId(string mediCard, string patName)
        {
            CHIService service = new CHIService();
            XmlDocument result = new XmlDocument();
            result.LoadXml(service.getJkdaInfo(mediCard, patName));
            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                return result.SelectSingleNode("chs/table/row/DAHID").InnerText;
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }

        /// <summary>
        /// 上传门诊病历记录
        /// </summary>
        /// <param name="record">病历记录</param>
        public static void Upload_Clinic_Medical_Records(string dahId, EmrRecord record)
        {
            XmlDocument upateData = new XmlDocument();
            XmlDocument result = new XmlDocument();
            upateData.LoadXml(Properties.Resources.ClinicMedicalRecords);
            #region 传入病历数据
            foreach (XmlNode node in upateData.SelectSingleNode("chs/table/row").ChildNodes)
            {
                foreach (XmlNode recordNode in record.RecordContentXml.SelectSingleNode("门急诊病历").ChildNodes)
                {
                    if (node.InnerText.Trim() == recordNode.Name.Trim())
                    {
                        node.InnerText = recordNode.InnerText;
                    }
                }
            }
            Model.PatientInfo patInfo = BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).GetModel(record.PatId);  //病人信息
            Model.MZ_PatList patList = BindEntity<Model.MZ_PatList>.CreateInstanceDAL(oleDb).GetModel(record.PatListId);  //病人就诊信息
            upateData.SelectSingleNode("chs/table/row/dahid").InnerText = dahId;     //健康档案号
            upateData.SelectSingleNode("chs/table/row/cf").InnerText = "";  
            upateData.SelectSingleNode("chs/table/row/jzrq").InnerText = patList.CureDate.Year.ToString("0000") + patList.CureDate.Month.ToString("00") + patList.CureDate.Day.ToString("00");
            upateData.SelectSingleNode("chs/table/row/jzys").InnerText = new GWMHIS.BussinessLogicLayer.Classes.Employee(Convert.ToInt64(patList.CureEmpCode)).Name;
            upateData.SelectSingleNode("chs/table/row/jzjg").InnerText = HIS.SYSTEM.Core.EntityConfig.WorkName;
            upateData.SelectSingleNode("chs/table/row/jgdm").InnerText = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            upateData.SelectSingleNode("chs/table/row/djr").InnerText = new GWMHIS.BussinessLogicLayer.Classes.Employee(Convert.ToInt64(record.RecordCreateEmp)).Name;
            upateData.SelectSingleNode("chs/table/row/djrq").InnerText = record.RecordCreateDate.Year.ToString("0000") + record.RecordCreateDate.Month.ToString("00") + record.RecordCreateDate.Day.ToString("00");
            upateData.SelectSingleNode("chs/table/row/his_blbh").InnerText = (record.RecordId).ToString();
            #endregion

            CHIService service = new CHIService();
            result.LoadXml(service.upload_Clinic_Medical_Records(upateData.InnerXml));

            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                record.UpdateFlag = 1;
                record.Update();
                Upload_Mzcf_Records(record.PatListId, dahId, record.RecordId);
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }

        /// <summary>
        /// 上传门诊处方记录
        /// </summary>
        /// <param name="patListId">病人就诊Id</param>
        /// <param name="dahId">档案号Id</param>
        /// <param name="recordId">门诊病历记录Id</param>
        public static void Upload_Mzcf_Records(int patListId,string dahId,int recordId)
        {
            XmlDocument upateData = new XmlDocument();
            XmlDocument result = new XmlDocument();
            upateData.LoadXml(Properties.Resources.MzcfRecords);
            #region 传入处方数据
            DataTable table = GetMzcfRecord(patListId);
            XmlNode node = upateData.SelectSingleNode("chs/table/row").Clone();
            upateData.SelectSingleNode("chs/table").RemoveAll();
            for (int index = 0; index < table.Rows.Count;index++ )
            {
                XmlNode childNode = node.Clone();
                childNode.SelectSingleNode("cfbh").InnerText = table.Rows[index]["preslistid"].ToString();  //处方编号
                childNode.SelectSingleNode("dahid").InnerText = dahId;  //档案号id
                childNode.SelectSingleNode("jzsj").InnerText = Convert.ToDateTime(table.Rows[index]["curedate"]).Year.ToString("0000") + 
                                                               Convert.ToDateTime(table.Rows[index]["curedate"]).Month.ToString("00") + 
                                                               Convert.ToDateTime(table.Rows[index]["curedate"]).Day.ToString("00");  //就诊时间
                childNode.SelectSingleNode("xmmc").InnerText = table.Rows[index]["item_name"].ToString();  //项目名称
                childNode.SelectSingleNode("gg").InnerText = table.Rows[index]["standard"].ToString();  //规格
                childNode.SelectSingleNode("cs").InnerText = table.Rows[index]["address"].ToString();  //产商
                childNode.SelectSingleNode("ph").InnerText = "";// table.Rows[index]["batchnum"].ToString();  //批号
                childNode.SelectSingleNode("sl").InnerText = table.Rows[index]["item_amount"].ToString();  //数量
                childNode.SelectSingleNode("dw").InnerText = table.Rows[index]["item_unit"].ToString();  //单位
                childNode.SelectSingleNode("dj").InnerText = table.Rows[index]["sell_price"].ToString();  //单价
                childNode.SelectSingleNode("yf").InnerText = table.Rows[index]["usage_name"].ToString();  //用法
                childNode.SelectSingleNode("yl").InnerText = table.Rows[index]["usage_amount"].ToString() + table.Rows[index]["usage_unit"].ToString();  //用量
                childNode.SelectSingleNode("pl").InnerText = table.Rows[index]["frequency_name"].ToString();  //频率
                childNode.SelectSingleNode("djr").InnerText = table.Rows[index]["doc_name"].ToString();  //登记人
                childNode.SelectSingleNode("djrq").InnerText = Convert.ToDateTime(table.Rows[index]["pres_date"]).Year.ToString("0000") +
                                                               Convert.ToDateTime(table.Rows[index]["pres_date"]).Month.ToString("00") +
                                                               Convert.ToDateTime(table.Rows[index]["pres_date"]).Day.ToString("00"); //登记日期
                childNode.SelectSingleNode("jgdm").InnerText = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();  //机构代码
                childNode.SelectSingleNode("his_blbh").InnerText = recordId.ToString();  //病历编号
                upateData.SelectSingleNode("chs/table").AppendChild(childNode);
            }
            #endregion

            CHIService service = new CHIService();
            result.LoadXml(service.upload_Mzcf_Records(upateData.InnerXml));

            if (!Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }

        /// <summary>
        /// 上传入院记录
        /// </summary>
        /// <param name="record">病历记录</param>
        public static void Upload_To_Hospital_Records(string dahId, EmrRecord record)
        {
            XmlDocument upateData = new XmlDocument();
            XmlDocument result = new XmlDocument();
            upateData.LoadXml(Properties.Resources.ToHospitalRecords);
            #region 传入病历数据
            foreach (XmlNode node in upateData.SelectSingleNode("chs/table/row").ChildNodes)
            {
                foreach (XmlNode recordNode in record.RecordContentXml.SelectSingleNode("入院记录").ChildNodes)
                {
                    if (node.InnerText.Trim() == recordNode.Name.Trim())
                    {
                        node.InnerText = recordNode.InnerText;
                    }
                }
            }

            Model.PatientInfo patInfo = BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).GetModel(record.PatId);
            Model.ZY_PatList patList = BindEntity<Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(record.PatListId);
            upateData.SelectSingleNode("chs/table/row/zyid").InnerText = (HIS.SYSTEM.Core.EntityConfig.WorkID*10000000+record.PatListId).ToString();  //住院ID
            upateData.SelectSingleNode("chs/table/row/zyh").InnerText = patInfo.CureNo;  //住院号
            upateData.SelectSingleNode("chs/table/row/dahid").InnerText = dahId; //档案号
            upateData.SelectSingleNode("chs/table/row/zylx").InnerText = "1";  //住院类型
            //付费方式
            switch (patInfo.ACCOUNTTYPE)
            {
                case "自费":
                    upateData.SelectSingleNode("chs/table/row/fffs").InnerText = "8";
                    break;
                case "农合":
                    upateData.SelectSingleNode("chs/table/row/fffs").InnerText = "6";
                    break;
                case "居民医保":
                    upateData.SelectSingleNode("chs/table/row/fffs").InnerText = "4";
                    break;
                case "职工医保":
                    upateData.SelectSingleNode("chs/table/row/fffs").InnerText = "3";
                    break;
                case "公费":
                    upateData.SelectSingleNode("chs/table/row/fffs").InnerText = "1";
                    break;
                default:
                    upateData.SelectSingleNode("chs/table/row/fffs").InnerText = "9";
                    break;
            }
            upateData.SelectSingleNode("chs/table/row/ryrq").InnerText = patList.CureDate.Year.ToString("0000") + patList.CureDate.Month.ToString("00") + patList.CureDate.Day.ToString("00");  //入院时间
            upateData.SelectSingleNode("chs/table/row/ryks").InnerText = new GWMHIS.BussinessLogicLayer.Classes.Employee(Convert.ToInt64(patList.CureDeptCode)).Name;  //科室
            upateData.SelectSingleNode("chs/table/row/ch").InnerText = patList.BedCode;  //床号
            upateData.SelectSingleNode("chs/table/row/zzys").InnerText = new GWMHIS.BussinessLogicLayer.Classes.Employee(Convert.ToInt64(Convert.ToInt64(patList.CureDocCode))).Name;  //主治医生
            upateData.SelectSingleNode("chs/table/row/qt").InnerText = "";  //其他
            upateData.SelectSingleNode("chs/table/row/csd").InnerText = "";  //出生地
            upateData.SelectSingleNode("chs/table/row/gzdw").InnerText = "";  //工作单位
            upateData.SelectSingleNode("chs/table/row/zdqt").InnerText = "";
            upateData.SelectSingleNode("chs/table/row/jzyy").InnerText = HIS.SYSTEM.Core.EntityConfig.WorkName;
            upateData.SelectSingleNode("chs/table/row/jgdm").InnerText = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            upateData.SelectSingleNode("chs/table/row/djr").InnerText = new GWMHIS.BussinessLogicLayer.Classes.Employee(Convert.ToInt64(record.RecordCreateEmp)).Name;
            upateData.SelectSingleNode("chs/table/row/djrq").InnerText = record.RecordCreateDate.Year.ToString("0000") + record.RecordCreateDate.Month.ToString("00") + record.RecordCreateDate.Day.ToString("00");
            upateData.SelectSingleNode("chs/table/row/his_blbh").InnerText = (record.RecordId).ToString();
            #endregion

            CHIService service = new CHIService();
            result.LoadXml(service.upload_To_Hospital_Records(upateData.InnerXml));

            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                record.UpdateFlag = 1;
                record.Update();
                Upload_Zycf_Records(record.PatListId, dahId, record.RecordId);
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }

        /// <summary>
        /// 上传病程记录
        /// </summary>
        /// <param name="record">病历记录</param>
        public static void Upload_In_Hospital_Records(string dahId, EmrRecord record)
        {
            XmlDocument upateData = new XmlDocument();
            XmlDocument result = new XmlDocument();
            upateData.LoadXml(Properties.Resources.InHospitalRecords);
            #region 传入病历数据
            foreach (XmlNode node in upateData.SelectSingleNode("chs/table/row").ChildNodes)
            {
                foreach (XmlNode recordNode in record.RecordContentXml.SelectSingleNode("病程记录").ChildNodes)
                {
                    if (node.InnerText.Trim() == recordNode.Name.Trim())
                    {
                        node.InnerText = recordNode.InnerText;
                    }
                }
            }
            Model.PatientInfo patInfo = BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).GetModel(record.PatId);
            Model.ZY_PatList patList = BindEntity<Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(record.PatListId);
            upateData.SelectSingleNode("chs/table/row/zyid").InnerText = (HIS.SYSTEM.Core.EntityConfig.WorkID * 10000000 + record.PatListId).ToString();  //住院ID
            upateData.SelectSingleNode("chs/table/row/dahid").InnerText = dahId; //档案号
            upateData.SelectSingleNode("chs/table/row/cf").InnerText = "";  //处方
            upateData.SelectSingleNode("chs/table/row/qt").InnerText = "";  //其他
            upateData.SelectSingleNode("chs/table/row/zdqt").InnerText = "";  //其他诊断
            upateData.SelectSingleNode("chs/table/row/jcrq").InnerText = record.RecordCreateDate.Year.ToString("0000") + record.RecordCreateDate.Month.ToString("00") + record.RecordCreateDate.Day.ToString("00");  //检查日期
            upateData.SelectSingleNode("chs/table/row/jcys").InnerText = new GWMHIS.BussinessLogicLayer.Classes.Employee(Convert.ToInt64(record.RecordCreateEmp)).Name;  //检查医生
            upateData.SelectSingleNode("chs/table/row/jgdm").InnerText = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            upateData.SelectSingleNode("chs/table/row/djr").InnerText = new GWMHIS.BussinessLogicLayer.Classes.Employee(Convert.ToInt64(record.RecordCreateEmp)).Name;
            upateData.SelectSingleNode("chs/table/row/djrq").InnerText = record.RecordCreateDate.Year.ToString("0000") + record.RecordCreateDate.Month.ToString("00") + record.RecordCreateDate.Day.ToString("00");
           #endregion

            CHIService service = new CHIService();
            result.LoadXml(service.upload_In_Hospital_Records(upateData.InnerXml));

            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                record.UpdateFlag = 1;
                record.Update();
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }

        /// <summary>
        /// 上传出院记录
        /// </summary>
        /// <param name="record">病历记录</param>
        public static void Upload_Out_Hospital_Records(string dahId, EmrRecord record)
        {
            XmlDocument upateData = new XmlDocument();
            XmlDocument result = new XmlDocument();
            upateData.LoadXml(Properties.Resources.OutHospitalRecords);
            #region 传入病历数据
            foreach (XmlNode node in upateData.SelectSingleNode("chs/table/row").ChildNodes)
            {
                foreach (XmlNode recordNode in record.RecordContentXml.SelectSingleNode("出院记录").ChildNodes)
                {
                    if (node.InnerText.Trim() == recordNode.Name.Trim())
                    {
                        node.InnerText = recordNode.InnerText;
                    }
                }
            }

            Model.PatientInfo patInfo = BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).GetModel(record.PatId);
            Model.ZY_PatList patList = BindEntity<Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(record.PatListId);
            upateData.SelectSingleNode("chs/table/row/zyid").InnerText = (HIS.SYSTEM.Core.EntityConfig.WorkID * 10000000 + record.PatListId).ToString();  //住院ID
            upateData.SelectSingleNode("chs/table/row/dahid").InnerText = dahId; //档案号
            upateData.SelectSingleNode("chs/table/row/cyrq").InnerText = patList.OutDate.Year.ToString("0000") + patList.OutDate.Month.ToString("00") + patList.OutDate.Day.ToString("00");  //入院时间
            upateData.SelectSingleNode("chs/table/row/zzys").InnerText = new GWMHIS.BussinessLogicLayer.Classes.Employee(Convert.ToInt64(Convert.ToInt64(patList.CureDocCode))).Name; //主治医生
             upateData.SelectSingleNode("chs/table/row/jgdm").InnerText = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            upateData.SelectSingleNode("chs/table/row/djr").InnerText = new GWMHIS.BussinessLogicLayer.Classes.Employee(Convert.ToInt64(record.RecordCreateEmp)).Name;
            upateData.SelectSingleNode("chs/table/row/djrq").InnerText = record.RecordCreateDate.Year.ToString("0000") + record.RecordCreateDate.Month.ToString("00") + record.RecordCreateDate.Day.ToString("00");
            #endregion

            CHIService service = new CHIService();
            result.LoadXml(service.upload_Out_Hospital_Records(upateData.InnerXml));

            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                record.UpdateFlag = 1;
                record.Update();
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }

        /// <summary>
        /// 上传住院费用
        /// </summary>
        /// <param name="patListId"></param>
        /// <param name="dahId"></param>
        /// <param name="recordId"></param>
        public static void Upload_Zycf_Records(int patListId, string dahId, int recordId)
        {
            XmlDocument upateData = new XmlDocument();
            XmlDocument result = new XmlDocument();
            upateData.LoadXml(Properties.Resources.ZycfRecords);
            #region 传入处方数据
            DataTable table = GetMzcfRecord(patListId);
            XmlNode node = upateData.SelectSingleNode("chs/table/row").Clone();
            upateData.SelectSingleNode("chs/table").RemoveAll();
            for (int index = 0; index < table.Rows.Count; index++)
            {
                XmlNode childNode = node.Clone();
                childNode.SelectSingleNode("cfbh").InnerText = table.Rows[index]["order_id"].ToString();  //处方编号
                childNode.SelectSingleNode("dahid").InnerText = dahId;  //档案号id
                childNode.SelectSingleNode("jzsj").InnerText = Convert.ToDateTime(table.Rows[index]["curedate"]).Year.ToString("0000") +
                                                               Convert.ToDateTime(table.Rows[index]["curedate"]).Month.ToString("00") +
                                                               Convert.ToDateTime(table.Rows[index]["curedate"]).Day.ToString("00");  //就诊时间
                childNode.SelectSingleNode("xmmc").InnerText = table.Rows[index]["order_content"].ToString();  //项目名称
                childNode.SelectSingleNode("gg").InnerText = table.Rows[index]["order_spec"].ToString();  //规格
                childNode.SelectSingleNode("cs").InnerText = table.Rows[index]["address"].ToString();  //产商
                childNode.SelectSingleNode("ph").InnerText = "";// table.Rows[index]["batchnum"].ToString();  //批号
                childNode.SelectSingleNode("sl").InnerText = table.Rows[index]["sl"].ToString();  //数量
                childNode.SelectSingleNode("dw").InnerText = table.Rows[index]["unit"].ToString();  //单位
                childNode.SelectSingleNode("dj").InnerText = table.Rows[index]["order_price"].ToString();  //单价
                childNode.SelectSingleNode("yf").InnerText = table.Rows[index]["order_usage"].ToString();  //用法
                childNode.SelectSingleNode("yl").InnerText = table.Rows[index]["amount"].ToString() + table.Rows[index]["usage_unit"].ToString();  //用量
                childNode.SelectSingleNode("pl").InnerText = table.Rows[index]["frequency"].ToString();  //频率
                childNode.SelectSingleNode("djr").InnerText = table.Rows[index]["name"].ToString();  //登记人
                childNode.SelectSingleNode("djrq").InnerText = Convert.ToDateTime(table.Rows[index]["order_bdate"]).Year.ToString("0000") +
                                                               Convert.ToDateTime(table.Rows[index]["order_bdate"]).Month.ToString("00") +
                                                               Convert.ToDateTime(table.Rows[index]["order_bdate"]).Day.ToString("00"); //登记日期
                childNode.SelectSingleNode("jgdm").InnerText = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();  //机构代码
                childNode.SelectSingleNode("his_blbh").InnerText = recordId.ToString();  //病历编号
                upateData.SelectSingleNode("chs/table").AppendChild(childNode);
            }
            #endregion

            CHIService service = new CHIService();
            result.LoadXml(service.upload_Mzcf_Records(upateData.InnerXml));

            if (!Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }

        /// <summary>
        /// 判断是否已上传该门诊病历信息
        /// </summary>
        /// <param name="dahid">档案号</param>
        /// <param name="his_blbh">病历编号</param>
        /// <returns></returns>
        public static bool CheckMz(string dahid,string his_blbh)
        {
            CHIService service = new CHIService();
            XmlDocument result = new XmlDocument();
            //result.LoadXml(service.getPatientInfo(dahid, his_blbh));
            //if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            //{
            //    return Convert.ToBoolean(result.SelectSingleNode("chs/message").InnerText);
            //}
            //else
            //{
            //    throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            //}
            return false;
        }

        /// <summary>
        /// 判断是否已上传该住院病历信息
        /// </summary>
        /// <param name="dahid">档案号</param>
        /// <param name="his_blbh">病历编号</param>
        /// <returns></returns>
        public static bool CheckZy(string dahid, string his_blbh)
        {
            CHIService service = new CHIService();
            XmlDocument result = new XmlDocument();
            //result.LoadXml(service.getPatientInfo(dahid, his_blbh));
            //if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            //{
            //    return Convert.ToBoolean(result.SelectSingleNode("chs/message").InnerText);
            //}
            //else
            //{
            //    throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            //}
            return false;
        }
        #endregion

        #region 下载数据
        /// <summary>
        /// 下载病人历史病历信息
        /// </summary>
        /// <param name="dahId"></param>
        /// <param name="recordType"></param>
        /// <returns></returns>
        public static DataTable LoadEmrRecord(string dahId, string recordType)
        {
                switch (recordType)
                {
                    case "01":
                        return GetMzblInfo(dahId);
                    case "02":
                        return GetZyryInfo(dahId);
                    case "03":
                        return GetZyBcInfo(dahId);
                    case "04":
                        return GetZycyInfo(dahId);
                    default:
                        return new DataTable();
                }
        }

        /// <summary>
        /// 查询门诊病历信息
        /// </summary>
        /// <param name="dahid">档案号Id</param>
        /// <returns></returns>
        public static DataTable GetMzblInfo(string dahid)
        {
            CHIService service = new CHIService();
            XmlDocument result = new XmlDocument();
            result.LoadXml(service.getMzblInfo(dahid));
            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                DataTable table = new DataTable();
                table.Columns.Add("接诊医师", Type.GetType("System.String"));
                table.Columns.Add("就诊日期", Type.GetType("System.String"));
                table.Columns.Add("就诊机构", Type.GetType("System.String"));
                table.Columns.Add("登记人", Type.GetType("System.String"));
                table.Columns.Add("登记日期", Type.GetType("System.String"));
                table.Columns.Add("record", Type.GetType("System.String"));
                foreach (XmlNode node in result.SelectSingleNode("chs/table").ChildNodes)
                {
                    DataRow row = table.NewRow();
                    row["接诊医师"] = node.SelectSingleNode("JZYS").InnerText;
                    row["就诊日期"] = node.SelectSingleNode("JZRQ").InnerText;
                    row["就诊机构"] = node.SelectSingleNode("JZJG").InnerText;
                    row["登记人"] = node.SelectSingleNode("DJR").InnerText;
                    row["登记日期"] = node.SelectSingleNode("DJRQ").InnerText;
                    XmlDocument xmlDoc = new XmlDocument();
                    XmlNode rootNode = xmlDoc.CreateElement("门急诊病历");

                    XmlDocument model = new XmlDocument();
                    model.LoadXml(Properties.Resources.ClinicMedicalRecords);
                    foreach (XmlNode node1 in node.ChildNodes)
                    {
                        foreach (XmlNode node2 in model.SelectSingleNode("chs/table/row").ChildNodes)
                        {
                            if (node1.Name.Trim().ToLower() == node2.Name.Trim().ToLower())
                            {
                                XmlNode newNode = xmlDoc.CreateElement(node2.InnerText);
                                newNode.InnerText = node1.InnerText.Replace("null","");
                                rootNode.AppendChild(newNode);
                            }
                        }
                    }
                    xmlDoc.AppendChild(rootNode);
                    row["record"] = xmlDoc.InnerXml;
                    table.Rows.Add(row);
                }
                return table;
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }
        /// <summary>
        /// 查询门诊处方信息
        /// </summary>
        /// <param name="dahid"></param>
        /// <returns></returns>
        public static DataTable GetMzcfInfo(string dahid)
        {
            CHIService service = new CHIService();
            XmlDocument result = new XmlDocument();
            result.LoadXml(service.getMzcfInfo(dahid));
            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                DataTable table = new DataTable();
                return table;
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }
        /// <summary>
        /// 查询住院入院信息
        /// </summary>
        /// <param name="dahid"></param>
        /// <returns></returns>
        public static DataTable GetZyryInfo(string dahid)
        {
            CHIService service = new CHIService();
            XmlDocument result = new XmlDocument();
            result.LoadXml(service.getZyryInfo(dahid));
            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                DataTable table = new DataTable();
                table.Columns.Add("入院时间", Type.GetType("System.String"));
                table.Columns.Add("入院科室", Type.GetType("System.String"));
                table.Columns.Add("床号", Type.GetType("System.String"));
                table.Columns.Add("主治医生", Type.GetType("System.String"));
                table.Columns.Add("就诊医院", Type.GetType("System.String"));
                table.Columns.Add("登记人", Type.GetType("System.String"));
                table.Columns.Add("登记日期", Type.GetType("System.String"));
                table.Columns.Add("record", Type.GetType("System.String"));
                foreach (XmlNode node in result.SelectSingleNode("chs/table").ChildNodes)
                {
                    DataRow row = table.NewRow();
                    row["入院时间"] = node.SelectSingleNode("RYRQ").InnerText.Replace("null", "");
                    row["入院科室"] = node.SelectSingleNode("RYKS").InnerText.Replace("null", "");
                    row["床号"] = node.SelectSingleNode("CH").InnerText.Replace("null", "");
                    row["主治医生"] = node.SelectSingleNode("ZZYS").InnerText.Replace("null", "");
                    row["就诊医院"] = node.SelectSingleNode("JZYY").InnerText.Replace("null", "");
                    row["登记人"] = node.SelectSingleNode("DJR").InnerText.Replace("null", "");
                    row["登记日期"] = node.SelectSingleNode("DJRQ").InnerText.Replace("null", "");
                    XmlDocument xmlDoc = new XmlDocument();
                    XmlNode rootNode = xmlDoc.CreateElement("入院记录");

                    XmlDocument model = new XmlDocument();
                    model.LoadXml(Properties.Resources.ToHospitalRecords);
                    foreach (XmlNode node1 in node.ChildNodes)
                    {
                        foreach (XmlNode node2 in model.SelectSingleNode("chs/table/row").ChildNodes)
                        {
                            if (node1.Name.Trim().ToLower() == node2.Name.Trim().ToLower())
                            {
                                XmlNode newNode = xmlDoc.CreateElement(node2.InnerText);
                                newNode.InnerText = node1.InnerText.Replace("null", "");
                                rootNode.AppendChild(newNode);
                            }
                        }
                    }
                    xmlDoc.AppendChild(rootNode);
                    row["record"] = xmlDoc.InnerXml;
                    table.Rows.Add(row);
                }
                return table;
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }
        /// <summary>
        /// 查询病程记录信息
        /// </summary>
        /// <param name="dahid"></param>
        /// <returns></returns>
        public static DataTable GetZyBcInfo(string dahid)
        {
            CHIService service = new CHIService();
            XmlDocument result = new XmlDocument();
            result.LoadXml(service.getZyBcInfo(dahid));
            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                DataTable table = new DataTable();
                table.Columns.Add("检查医师", Type.GetType("System.String"));
                table.Columns.Add("检查日期", Type.GetType("System.String"));
                table.Columns.Add("登记人", Type.GetType("System.String"));
                table.Columns.Add("登记日期", Type.GetType("System.String"));
                table.Columns.Add("record", Type.GetType("System.String"));
                foreach (XmlNode node in result.SelectSingleNode("chs/table").ChildNodes)
                {
                    DataRow row = table.NewRow();
                    row["检查医师"] = node.SelectSingleNode("JCYS").InnerText.Replace("null", "");
                    row["检查日期"] = node.SelectSingleNode("JCRQ").InnerText.Replace("null", "");
                    row["登记人"] = node.SelectSingleNode("DJR").InnerText.Replace("null", "");
                    row["登记日期"] = node.SelectSingleNode("DJRQ").InnerText.Replace("null", "");
                    XmlDocument xmlDoc = new XmlDocument();
                    XmlNode rootNode = xmlDoc.CreateElement("病程记录");

                    XmlDocument model = new XmlDocument();
                    model.LoadXml(Properties.Resources.InHospitalRecords);
                    foreach (XmlNode node1 in node.ChildNodes)
                    {
                        foreach (XmlNode node2 in model.SelectSingleNode("chs/table/row").ChildNodes)
                        {
                            if (node1.Name.Trim().ToLower() == node2.Name.Trim().ToLower() && node2.InnerText.Trim()!="")
                            {
                                XmlNode newNode = xmlDoc.CreateElement(node2.InnerText.Trim());
                                newNode.InnerText = node1.InnerText.Replace("null", "");
                                rootNode.AppendChild(newNode);
                            }
                        }
                    }
                    xmlDoc.AppendChild(rootNode);
                    row["record"] = xmlDoc.InnerXml;
                    table.Rows.Add(row);
                }
                return table;
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }
        /// <summary>
        /// 查询出院记录信息
        /// </summary>
        /// <param name="dahid"></param>
        /// <returns></returns>
        public static DataTable GetZycyInfo(string dahid)
        {
            CHIService service = new CHIService();
            XmlDocument result = new XmlDocument();
            result.LoadXml(service.getZycyInfo(dahid));
            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                DataTable table = new DataTable();
                table.Columns.Add("主治医生", Type.GetType("System.String"));
                table.Columns.Add("出院日期", Type.GetType("System.String"));
                table.Columns.Add("登记人", Type.GetType("System.String"));
                table.Columns.Add("登记日期", Type.GetType("System.String"));
                table.Columns.Add("record", Type.GetType("System.String"));
                foreach (XmlNode node in result.SelectSingleNode("chs/table").ChildNodes)
                {
                    DataRow row = table.NewRow();
                    row["主治医生"] = node.SelectSingleNode("ZZYS").InnerText.Replace("null", "");
                    row["出院日期"] = node.SelectSingleNode("CYRQ").InnerText.Replace("null", "");
                    row["登记人"] = node.SelectSingleNode("DJR").InnerText.Replace("null", "");
                    row["登记日期"] = node.SelectSingleNode("DJRQ").InnerText.Replace("null", "");
                    XmlDocument xmlDoc = new XmlDocument();
                    XmlNode rootNode = xmlDoc.CreateElement("出院记录");

                    XmlDocument model = new XmlDocument();
                    model.LoadXml(Properties.Resources.OutHospitalRecords);
                    foreach (XmlNode node1 in node.ChildNodes)
                    {
                        foreach (XmlNode node2 in model.SelectSingleNode("chs/table/row").ChildNodes)
                        {
                            if (node1.Name.Trim().ToLower() == node2.Name.Trim().ToLower())
                            {
                                XmlNode newNode = xmlDoc.CreateElement(node2.InnerText);
                                newNode.InnerText = node1.InnerText.Replace("null", "");
                                rootNode.AppendChild(newNode);
                            }
                        }
                    }
                    xmlDoc.AppendChild(rootNode);
                    row["record"] = xmlDoc.InnerXml;
                    table.Rows.Add(row);
                }
                return table;
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }
        /// <summary>
        /// 查询住院处方信息
        /// </summary>
        /// <param name="dahid"></param>
        /// <returns></returns>
        public static DataTable GetZycfInfo(string dahid)
        {
            CHIService service = new CHIService();
            XmlDocument result = new XmlDocument();
            result.LoadXml(service.getZycfInfo(dahid));
            if (Convert.ToBoolean(result.SelectSingleNode("chs/status").InnerText))
            {
                DataTable table = new DataTable();
                return table;
            }
            else
            {
                throw new Exception(result.SelectSingleNode("chs/message").InnerText);
            }
        }

        /// <summary>
        /// 查询体检信息
        /// </summary>
        /// <param name="s_dahid"></param>
        /// <returns></returns>
        public static string GetTjInfo(string dahid)
        {
            CHIService service = new CHIService();
            return service.getTjInfo(dahid);
        }

        /// <summary>
        /// 查询慢病信息
        /// </summary>
        /// <param name="s_dahid"></param>
        /// <returns></returns>
        public static string GetMbInfo(string dahid)
        {
            CHIService service = new CHIService();
            return service.getMbInfo(dahid);
        }

        /// <summary>
        /// 查询预防接种信息
        /// </summary>
        /// <param name="s_dahid"></param>
        /// <returns></returns>
        public static string GetYfjzInfo(string dahid)
        {
            CHIService service = new CHIService();
            return service.getYfjzInfo(dahid);
        }

        /// <summary>
        /// 查询体检日期
        /// </summary>
        /// <param name="s_ylzh"></param>
        /// <param name="s_sfz"></param>
        /// <returns></returns>
        public static string GetTjrq(string ylzh, string sfz)
        {
            CHIService service = new CHIService();
            return service.getTjrq(ylzh, sfz);
        }

        /// <summary>
        /// 查询综合信息
        /// </summary>
        /// <param name="dahid"></param>
        /// <param name="lb">null 为查询全部信息
        ///2 基本信息</param>
        ///3 体检信息</param>
        ///4 健教信息</param>
        ///5 产检分娩访视信息</param>
        ///6 妇女保健信息</param>
        ///7 儿童体检信息</param>
        ///8 康复访视信息</param>
        ///9 传染病登记信息</param>
        ///10 慢病监测信息</param>
        ///11 预防接种信息</param>
        /// <returns></returns>
        public static string GetZhxx(string dahid, string lb)
        {
            CHIService service = new CHIService();
            if (lb.Trim() == "1")
            {
                return service.getZhxx(dahid, null);
            }
            else
            {
                return service.getZhxx(dahid, lb);
            }
        }
        #endregion
    }
}
