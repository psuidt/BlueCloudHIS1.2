using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Report
{
    public interface IDataReport
    {
        void LoadBaseData();
        void LoadOperationData(DateTime Bdate, DateTime Edate);
        DataTable GetData();
        Total_Type totalType { get; set; }
        Item_Type itemType { get; set; }
        Date_Type dateType { get; set; }
    }

    public interface ITicketDataReport : IDataReport
    {
        bool IsChargerShow { get; set; }
        bool IsDeptShow { get; set; }
        bool IsDocShow { get; set; }
        bool IsPatTypeShow { get; set; }
        bool IsTicketItem { get; set; }
        bool IsVillageItem { get; set; }
        bool IsSelfItem { get; set; }
    }

    public interface IPatFeeDataReport : IDataReport
    {        
        bool IsDeptShow { get; set; }
        bool IsDocShow { get; set; }
        bool IsPatTypeShow { get; set; }
    }
}
