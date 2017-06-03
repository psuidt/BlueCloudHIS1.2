using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;

namespace HIS.ZY_BLL.Dao.PatientManager
{
    public class PatListDao:IpatListDao
    {

        /// <summary>
        /// 生成新的住院号
        /// </summary>
        /// <returns></returns>
        public int GetNewCureNo()
        {
            string str1 = oleDb.Count("PATNO", "");
            object obj = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").GetFieldValue(str1, "");
            if (Convert.ToInt32(obj) == 0)
            {
                //string sql= oleDb.InsertInto(Tables.ZY_PATIENTNO,Tables.zy_patientno.PATNO)+oleDb.Values("0");
                string[] filednames = {"PATNO" };
                string[] filedvalue = { "0" };
                bool[] Isquotation = { false };
                BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").Add(filednames, filedvalue, Isquotation);
                //oleDb.DoCommand(sql);
            }
            string str3 = "PATNO =PATNO+1";

            BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").Update("", str3);
            object obj1 = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").GetFieldValue("PATNO", "");
            return Convert.ToInt32(obj1);
        }

        /// <summary>
        /// 生成新的编码
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetNewNccmNo(DateTime date)
        {
            object obj = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").GetFieldValue("TODAYDATE", "");
            if (obj.ToString() == "" || date.Date != (Convert.ToDateTime(obj.ToString())).Date)
            {
                string str1 = "NCCM_NO =0";
                string str3 = "TODAYDATE='" + date.Date + "'";
                BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").Update("", str1, str3);
            }
            string str2 = "NCCM_NO =NCCM_NO+1";
            BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").Update("", str2);
            object obj1 = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_PATIENTNO").GetFieldValue("NCCM_NO", "");
            return obj1.ToString();
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

        public void AlterPatType(int patlistid, int patType)
        {
            string strWhere = "PATLISTID =" + patlistid;
            string str = "PATTYPE = '" + patType + "' ";
            BindEntity<HIS.ZY_BLL.DataModel.ZY_PatList>.CreateInstanceDAL(oleDb).Update(strWhere, str);
        }
    }
}
