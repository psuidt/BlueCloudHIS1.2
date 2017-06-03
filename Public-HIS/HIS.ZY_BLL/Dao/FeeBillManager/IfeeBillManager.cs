using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Dao.FeeBillManager
{
    public interface IfeeBillManager:IbaseDao
    {
        DataTable GetPresTotalData(int patlistid, DateTime? Bdate, DateTime? Edate);
        DataTable GetPresTotalData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate);
        DataTable GetPresTotalGroupData(int patlistid, DateTime? Bdate, DateTime? Edate);
        DataTable GetPresTotalGroupData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate);
        DataTable GetCostCalData(int patlistid, DateTime? Bdate, DateTime? Edate);
        DataTable GetCostCalData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate);
        DataTable GetCostDayData(int patlistid, DateTime? Bdate, DateTime? Edate);
        DataTable GetCostDayData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate);
        DataTable GetBaseData(int datatype);
    }
}
