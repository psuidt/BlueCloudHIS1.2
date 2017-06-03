using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.Dao.BaseDataManager;
using HIS.ZY_BLL.Dao;

namespace HIS.ZY_BLL.ObjectModel.BaseData
{
    public class BaseData:BaseBLL
    {
        public DataTable GetDiseaseData()
        {
            try
            {
                //string strWhere = Tables.base_disease;
                string[] str = new string[6];
                str[0] = oleDb.FiledNameBM("0", "rowno");
                str[1] = oleDb.FiledNameBM("''", "d_code");
                str[2] = oleDb.FiledNameBM("CODING", "code");
                str[3] = "NAME";
                str[4] = "PY_CODE";
                str[5] = "WB_CODE";
                return BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_DISEASE").GetList("", str);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message+"\n获取诊断数据错误！");
            }
        }

        public DataTable GetPatientTypeData()
        {
            try
            {
                string strWhere = "ZY_FLAG =1 and DEL_FLAG=0 order by PATTYPECODE";
                return BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_PATIENTTYPE_COST").GetList(strWhere
                    , oleDb.FiledNameBM("PATTYPECODE", "code")
                    , "NAME");
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message+"\n获取病人类型错误！");
            }
        }

        public DataTable GetNationcoData()
        {
            try
            {
                string[] str = new string[6];
                str[0] = oleDb.FiledNameBM("0", "rowno");
                str[1] = "CODE";
                str[2] = "NAME";
                str[3] = "PY_CODE";
                str[4] = oleDb.FiledNameBM("''", "wb_code");
                str[5] = oleDb.FiledNameBM("''", "D_CODE");

                return BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_NATIONCO").GetList("", str);

            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message+"\n获取名族！");
            }
        }

        public DataTable GetAllUserData()
        {
            return HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserData();
        }

        public DataTable GetUserDocData()
        {
            return HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserData(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.EmpType.医生);
        }

        public DataTable GetAllDeptData()
        {
            return BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_DEPT_PROPERTY").GetList(" DELETED=0 ", "dept_id as code", "name");
        }

        public DataTable GetClilinDeptData()
        {
            return HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptData(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType.住院, HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType2.临床);
        }

        public DataTable GetAllClilinDeptData()
        {
            return HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptData(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType.全院, HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType2.临床);
        }

        public DataTable GetInvoiceItemData()
        {
            return BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_STAT_ZYFP").GetList(" VALID_FLAG=1 ", "code", "item_name as name");
        }

        public DataTable GetWorkUnit()
        {
            return BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_NONCASH_TYPE", 0).GetList("type=2");
        }

        public DataTable GetWorkers()
        {
            return BindEntity<object>.CreateInstanceDAL(oleDb, "HIS_WORKERS", 0).GetList("", "workid", "workname");
        }

        /// <summary>
        /// 获得所有药房名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetYfName()
        {
            string strWhere = "DEPTTYPE1='药房'";
            return BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).GetList(strWhere,"deptid","deptname");
        }
    }

    public class BaseName:BaseBLL
    {
        public string GetEmpName(string EmpID)
        {
            return HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(EmpID);
        }

        public string GetDeptName(string DeptID)
        {
            return HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(DeptID);
        }

        public DataTable GetEmpData()
        {
            IbaseDataDao ibd = DaoFactory.GetObject<IbaseDataDao>(typeof(BaseDataDao));
            ibd.oleDb = oleDb;
            return ibd.GetEmpData();
        }

        public DataTable GetDeptData()
        {
            IbaseDataDao ibd = DaoFactory.GetObject<IbaseDataDao>(typeof(BaseDataDao));
            ibd.oleDb = oleDb;
            return ibd.GetDeptData();
        }
    }
}
