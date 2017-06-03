using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MZDoc_BLL.Public
{
    /// <summary>
    /// 年龄
    /// </summary>
    public struct PeopleAge
    {
        /// <summary>
        /// 年龄数
        /// </summary>
        public int AgeNum;
        /// <summary>
        /// 单位
        /// </summary>
        public string AgeUnit;
    }

    /// <summary>
    /// 处方颜色
    /// </summary>
    public struct PresColor
    {
        /// <summary>
        /// 行号
        /// </summary>
        public int rowIndex;
        /// <summary>
        /// 列号
        /// </summary>
        public int colIndex;
        /// <summary>
        /// 行字体颜色
        /// </summary>
        public System.Drawing.Color ForeColor;
        /// <summary>
        /// 行背景颜色
        /// </summary>
        public System.Drawing.Color BackColor;
    }

    /// <summary>
    /// 处方列只读状态
    /// </summary>
    public struct PresCellReadOnly
    {
        /// <summary>
        /// 项目编码列只读状态
        /// </summary>
        public bool ItemIdReadOnly;
        /// <summary>
        /// 科室名称列只读状态
        /// </summary>
        public bool DeptNameReadOnly;
        /// <summary>
        /// 每次用量列只读状态
        /// </summary>
        public bool UsageAmountReadOnly;
        /// <summary>
        /// 用量单位列只读状态
        /// </summary>
        public bool UsageUnitReadOnly;
        /// <summary>
        /// 剂数列只读状态
        /// </summary>
        public bool DosageReadOnly;
        /// <summary>
        /// 用法列只读状态
        /// </summary>
        public bool UsageReadOnly;
        /// <summary>
        /// 频次列只读状态
        /// </summary>
        public bool FrequencyReadOnly;
        /// <summary>
        /// 天数列只读状态
        /// </summary>
        public bool DaysReadOnly;
        /// <summary>
        /// 开药数量列只读状态
        /// </summary>
        public bool ItemAmountReadOnly;
        /// <summary>
        /// 开药单位列只读状态
        /// </summary>
        public bool ItemUnitReadOnly;
        /// <summary>
        /// 嘱托列只读状态
        /// </summary>
        public bool EntrustReadOnly;
    }

    /// <summary>
    /// 处方列序号
    /// </summary>
    public struct PresColumnIndex
    {
        /// <summary>
        /// 项目编码列序号
        /// </summary>
        public int ItemIdIndex;
        /// <summary>
        /// 科室名称列序号
        /// </summary>
        public int DeptNameIndex;
        /// <summary>
        /// 每次用量列序号
        /// </summary>
        public int UsageAmountIndex;
        /// <summary>
        /// 用量单位列序号
        /// </summary>
        public int UsageUnitIndex;
        /// <summary>
        /// 剂数列序号
        /// </summary>
        public int DosageIndex;
        /// <summary>
        /// 用法列序号
        /// </summary>
        public int UsageIndex;
        /// <summary>
        /// 频次列序号
        /// </summary>
        public int FrequencyIndex;
        /// <summary>
        /// 天数列序号
        /// </summary>
        public int DaysIndex;
        /// <summary>
        /// 开药数量列序号
        /// </summary>
        public int ItemAmountIndex;
        /// <summary>
        /// 开药单位列序号
        /// </summary>
        public int ItemUnitIndex;
        /// <summary>
        /// 嘱托列序号
        /// </summary>
        public int EntrustIndex;
    }

    /// <summary>
    /// 病人查询信息
    /// </summary>
    public struct PatientSearchInfo
    {
        /// <summary>
        /// 门诊卡号
        /// </summary>
        public string CardNo;
        /// <summary>
        /// 门诊号
        /// </summary>
        public string VisitNo;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName;
        /// <summary>
        /// 就诊科室Id
        /// </summary>
        public long DeptId;
        /// <summary>
        /// 就诊医生Id
        /// </summary>
        public long DocId;
        /// <summary>
        /// 诊断
        /// </summary>
        public string Diagnosis;
        /// <summary>
        /// 就诊日期时间段开始日期
        /// </summary>
        public DateTime BeginTime;
        /// <summary>
        /// 就诊日期时间段结束日期
        /// </summary>
        public DateTime EndTime;
    }

    /// <summary>
    /// 医技报告信息
    /// </summary>
    public struct MedicalReportInfo
    {
        /// <summary>
        /// 窗体句柄
        /// </summary>
        public IntPtr FormHandle;
        /// <summary>
        /// 病人ID
        /// </summary>
        public long Patid;
        /// <summary>
        /// 病人就诊ID
        /// </summary>
        public long PatListid;
        /// <summary>
        /// 发票号
        /// </summary>
        public string TicketNum;
        /// <summary>
        /// 处方明细编号
        /// </summary>
        public long PresListId;
        /// <summary>
        /// 门诊号
        /// </summary>
        public string VisitNo;
    }
}
