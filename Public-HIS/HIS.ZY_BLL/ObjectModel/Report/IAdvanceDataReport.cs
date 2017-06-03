using System;
using System.Collections.Generic;
using System.Text;

namespace HIS.ZY_BLL.Report
{
    public interface IAdvanceDataReport : HIS.ZY_BLL.Report.IDataReport
    {
        AdvanceDataShowType advShow { get; set; }
    }
}
