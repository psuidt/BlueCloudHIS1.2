using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_EMRManager.Public
{
    /// <summary>
    /// 病历类型
    /// </summary>
    public enum EMRType
    {
        /// <summary>
        /// 门诊病历
        /// </summary>
        门诊病历 = 1,
        /// <summary>
        /// 入院记录
        /// </summary>
        入院记录 = 2,
        /// <summary>
        /// 病程记录
        /// </summary>
        病程记录 = 3,
        /// <summary>
        /// 出院记录
        /// </summary>
        出院记录 = 4,
        /// <summary>
        /// 死亡记录
        /// </summary>
        死亡记录 = 5,
        /// <summary>
        /// 手术记录
        /// </summary>
        手术记录 = 6
    };
}
