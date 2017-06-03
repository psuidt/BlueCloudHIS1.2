using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;
using System.Xml;

namespace HIS.EMR_BLL
{
    /// <summary>
    /// 病历记录
    /// </summary>
    public class EmrRecord:Model.Emr_Record
    {
        /// <summary>
        /// 数据库对象
        /// </summary>
        protected RelationalDatabase _oleDb = null;

        /// <summary>
        /// 创建病历记录实例
        /// </summary>
        public EmrRecord()
        {
            _oleDb = BaseBLL.oleDb;
        }
        /// <summary>
        /// 创建病历记录实例
        /// </summary>
        /// <param name="recordId">病历记录Id</param>
        public EmrRecord(int recordId)
        {
            _oleDb = BaseBLL.oleDb;
            Model.Emr_Record tmpRecord = BindEntity<Model.Emr_Record>.CreateInstanceDAL(_oleDb).GetModel(recordId);
            if (tmpRecord == null)
            {
                this.RecordId = -1;
            }
            else
            {
                this.RecordId = tmpRecord.RecordId;
                this.PatId = tmpRecord.PatId;
                this.PatListId = tmpRecord.PatListId;
                this.RecordType = tmpRecord.RecordType;
                this.RecordContent = tmpRecord.RecordContent;
                this.RecordCreateEmp = tmpRecord.RecordCreateEmp;
                this.RecordCreateDept = tmpRecord.RecordCreateDept;
                this.RecordCreateDate = tmpRecord.RecordCreateDate;
                this.HistoryRecordId = tmpRecord.HistoryRecordId;
                this.RecordFlag = tmpRecord.RecordFlag;
                this.Delete_Bit = tmpRecord.Delete_Bit;
            }
        }

        /// <summary>
        /// 病历记录
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public EmrRecord(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        /// <summary>
        /// 病历记录
        /// </summary>
        /// <param name="patId">病人ID</param>
        /// <param name="patListId">病人就诊ID</param>
        /// <param name="emrTypeCode">病历类型编码</param>
        public EmrRecord(long patId,long patListId,string emrTypeCode)
        {
            _oleDb = BaseBLL.oleDb;
            Model.Emr_Record tmpRecord = BindEntity<Model.Emr_Record>.CreateInstanceDAL(_oleDb).GetModel(
                HIS.BLL.Tables.emr_record.PATID+_oleDb.EuqalTo()+patId+_oleDb.And()+
                HIS.BLL.Tables.emr_record.PATLISTID + _oleDb.EuqalTo() + patListId + _oleDb.And() +
                HIS.BLL.Tables.emr_record.RECORDTYPE + _oleDb.EuqalTo() + "'" + emrTypeCode.Trim() + "'" + _oleDb.And() +
                HIS.BLL.Tables.emr_record.RECORDFLAG + _oleDb.EuqalTo() + 0);
            if (tmpRecord == null)
            {
                this.RecordId = -1;
            }
            else
            {
                this.RecordId = tmpRecord.RecordId;
                this.PatId = tmpRecord.PatId;
                this.PatListId = tmpRecord.PatListId;
                this.RecordType = tmpRecord.RecordType;
                this.RecordContent = tmpRecord.RecordContent;
                this.RecordCreateEmp = tmpRecord.RecordCreateEmp;
                this.RecordCreateDept = tmpRecord.RecordCreateDept;
                this.RecordCreateDate = tmpRecord.RecordCreateDate;
                this.HistoryRecordId = tmpRecord.HistoryRecordId;
                this.RecordFlag = tmpRecord.RecordFlag;
                this.UpdateFlag = tmpRecord.UpdateFlag;
                this.Delete_Bit = tmpRecord.Delete_Bit;
            }
        }

        /// <summary>
        /// Xml格式的病历记录内容
        /// </summary>
        public XmlDocument RecordContentXml
        {
            get
            {
                XmlDocument recordContentXml = new XmlDocument();
                if (base.RecordContent != null && base.RecordContent.Trim() != "")
                {
                    recordContentXml.LoadXml(base.RecordContent);
                }
                return recordContentXml;
            }
            set
            {
                base.RecordContent = value.InnerXml;
            }
        }

        /// <summary>
        /// 添加病历记录
        /// </summary>
        public void Add()
        {
            BindEntity<Model.Emr_Record>.CreateInstanceDAL(_oleDb).Add(this);
        }

        /// <summary>
        /// 修改病历记录
        /// </summary>
        public void Update()
        {
            BindEntity<Model.Emr_Record>.CreateInstanceDAL(_oleDb).Update(this);
        }

        /// <summary>
        /// 删除病历记录
        /// </summary>
        public void Delete()
        {
            this.Delete_Bit = 1;
            BindEntity<Model.Emr_Record>.CreateInstanceDAL(_oleDb).Update(this);
        }

        /// <summary>
        /// 作废病历记录
        /// </summary>
        public void Invalid()
        { 
            this.RecordFlag = 1;
            BindEntity<Model.Emr_Record>.CreateInstanceDAL(_oleDb).Update(this);
        }
        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="patBriData">出生日期</param>
        /// <returns>年龄</returns>
        protected string CalculateAge(DateTime patBriData)
        {
            string patAge = "";
            DateTime currentDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            if (patBriData.Year != currentDate.Year && patBriData.Date.AddYears(1) <= currentDate.Date)
            {
                patAge = currentDate.Year - patBriData.Year + "岁";
            }
            else if (patBriData.Month != currentDate.Month && patBriData.Date.AddMonths(1) <= currentDate.Date)
            {
                int age = currentDate.Month - patBriData.Month;
                if (age < 0)
                {
                    age += 12;
                }
                patAge = age + "月";
            }
            else if (patBriData.Day != currentDate.Day && patBriData.Date.AddDays(1) <= currentDate.Date)
            {
                patAge = (currentDate - patBriData).Days + "天";
            }
            else
            {
                patAge = (currentDate - patBriData).Hours + "小时";
            }
            return patAge;
        }
    }
}
