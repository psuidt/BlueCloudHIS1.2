using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Dao.BaseDataManager
{
    public interface IbaseDataDao:IbaseDao
    {
        DataTable GetEmpData();
        DataTable GetDeptData();
    }
}
