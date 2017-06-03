using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MZDoc_BLL.Public
{
    /// <summary>
    /// 静态参数
    /// </summary>
    public class StaticConfig
    {
        /// <summary>
        /// 当前看诊医生代码
        /// </summary>
        public static int CureDocCode = -1;
        /// <summary>
        /// 当前看诊科室
        /// </summary>
        public static int CureDeptCode = -1;
        /// <summary>
        /// 当前医技报告返回格式
        /// </summary>
        public static MedicalReportFormat CurrentReportFormat = MedicalReportFormat.无返回;
    }
}
