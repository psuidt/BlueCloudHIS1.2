using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Dao.Report
{
    public interface Ireport:IbaseDao
    {
        DataTable CLoadOperationData(DateTime Bdate, DateTime Edate);
        DataTable TLoadOperationData(DateTime Bdate, DateTime Edate);
        DataTable GLoadOperationData(DateTime Bdate, DateTime Edate);

        DataTable GetRegisterPatientData(DateTime dateBegin, DateTime dateEnd);
        DataTable GetInPatinetData(string deptcode);
        DataTable GetOutPatinetData(string deptcode, DateTime Bdate, DateTime Edate);
    }
}
