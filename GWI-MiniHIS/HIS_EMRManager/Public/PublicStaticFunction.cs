using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_EMRManager.Public
{
    /// <summary>
    /// 公共静态方法
    /// </summary>
    internal class PublicStaticFunction
    {
        /// <summary>
        /// 当前操作员ID
        /// </summary>
        internal static long CurrentEmployeeId = -1;
        /// <summary>
        /// 当前登录科室
        /// </summary>
        internal static long CurrentDeptId = -1;

        /// <summary>
        /// 获得病历
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static string GetEMRTypeCode(EMRType type)
        {
            switch (type)
            {
                case EMRType.门诊病历:
                    return "01";
                case EMRType.入院记录:
                    return "02";
                case EMRType.病程记录:
                    return "03";
                case EMRType.出院记录:
                    return "04";
                case EMRType.死亡记录:
                    return "05";
                case EMRType.手术记录:
                    return "06";
                default:
                    return "";
            }
        }
    }
}
