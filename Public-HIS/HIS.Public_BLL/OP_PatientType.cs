using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.Public_BLL
{
    public class OP_PatientType : BaseBLL
    {
        public static DataTable GetPatientTypeData()
        {
            string sqlstr = @" select CODE, NAME from {BASE_PATIENTTYPE} Order By code";
            return oleDb.GetDataTable(sqlstr);
        }

        public static void SavePatientType(string code, string name)
        {
            string strWhere = Tables.base_patienttype.CODE + oleDb.EuqalTo() + "'" + code + "'";
            if (BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_PATIENTTYPE).Exists(strWhere))
            {
                string[] fieldvalueAndname = new string[2];
                fieldvalueAndname[0] = "CODE='" + code + "'";
                fieldvalueAndname[1] = "NAME='" + name + "'";
                BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_PATIENTTYPE).Update(strWhere, fieldvalueAndname);
            }
            else
            {
                string[] filednames = new string[] { "CODE", "NAME" };
                string[] filedvalues = new string[2];
                filedvalues[0] = code;
                filedvalues[1] = name;
                bool[] b = new bool[] { true, true };
                BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_PATIENTTYPE).Add(filednames, filedvalues, b);
            }
        }

        public static void DelPatientType(string code)
        {
            string strWhere = Tables.base_patienttype.CODE + oleDb.EuqalTo() + "'" + code + "'";
            BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_PATIENTTYPE).Delete(strWhere);
        }
    }
}
