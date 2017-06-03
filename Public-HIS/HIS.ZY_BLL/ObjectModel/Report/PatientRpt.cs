using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.ZY_BLL.Dao.Report;
using HIS.ZY_BLL.Dao;

namespace HIS.ZY_BLL.Report
{
    public class PatientRpt : BaseBLL
    {
        public static DataTable GetInPatinetData(string deptcode)
        {
            Ireport repD = DaoFactory.GetObject<Ireport>(typeof(ReportDao));
            repD.oleDb = oleDb;
            return repD.GetInPatinetData(deptcode);
        }

        public static DataTable GetOutPatinetData(string deptcode, DateTime Bdate, DateTime Edate)
        {
            Ireport repD = DaoFactory.GetObject<Ireport>(typeof(ReportDao));
            repD.oleDb = oleDb;
            return repD.GetOutPatinetData(deptcode, Bdate, Edate);
        }
    }
}
