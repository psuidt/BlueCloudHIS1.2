using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Dao.SendDrugMessage
{
    public interface IsendDrugMessage:IbaseDao
    {
        DataTable GetYfData();
        DataTable GetUsageName();
        DataTable GetPatInfoData(List<int> patlistIds);
    }
}
