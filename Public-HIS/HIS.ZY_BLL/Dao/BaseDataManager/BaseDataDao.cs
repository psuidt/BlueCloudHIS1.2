using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Dao.BaseDataManager
{
    public class BaseDataDao:IbaseDataDao
    {

        #region IbaseDataDao 成员

        public DataTable GetEmpData()
        {
            string strsql = @"select EMPLOYEE_ID as CODE,NAME from {BASE_EMPLOYEE_PROPERTY}";
            return oleDb.GetDataTable(strsql);
        }

        public DataTable GetDeptData()
        {
            string strsql = @"select DEPT_ID as CODE ,NAME from {BASE_DEPT_PROPERTY}";
            return oleDb.GetDataTable(strsql);
        }

        private HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _oleDb;
        public HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb
        {
            get
            {
                return _oleDb;
            }
            set
            {
                _oleDb = value;
            }
        }

        #endregion
    }
}
