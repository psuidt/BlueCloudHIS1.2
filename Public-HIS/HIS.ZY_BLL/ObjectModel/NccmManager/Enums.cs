using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL.ObjectModel.NccmManager
{
    /// <summary>
    /// 获取农合病人的方式
    /// </summary>
    public enum SearchNccmPatType
    {
        病人姓名,
        身份证号,
        医疗卡号,
        家庭编码,
        住院编号
    }
}
