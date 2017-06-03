using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_EMRManager.Public
{
    /// <summary>
    /// 病历基本信息
    /// </summary>
    public struct EMRRecordInfo
    {
        /// <summary>
        /// 病人ID
        /// </summary>
        public long Patid;    
        /// <summary>
        /// 病人就诊ID
        /// </summary>
        public long PatListid;
        /// <summary>
        /// 病历类型
        /// </summary>
        public EMRType RecordType;
        /// <summary>
        /// 病人医疗证卡号
        /// </summary>
        public string MediCard;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName;   
        /// <summary>
        /// 创建人ID
        /// </summary>
        public long CreateEmpId;
        /// <summary>
        /// 创建科室
        /// </summary>
        public long CreateDeptId;
    }
}
