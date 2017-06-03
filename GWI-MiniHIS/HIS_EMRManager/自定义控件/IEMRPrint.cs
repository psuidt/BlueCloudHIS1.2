using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_EMRManager
{
    interface IEMRPrint
    {
        /// <summary>
        /// 打印病历
        /// </summary>
        void Print(HIS.EMR_BLL.EmrRecord emrRecord);
    }
}
