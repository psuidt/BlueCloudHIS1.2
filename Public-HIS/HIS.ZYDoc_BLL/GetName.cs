using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZYDoc_BLL
{
    public  class GetName  //20100624.2.05
    {
        public static void GiveName(Model.zy_doc_orderrecord_son recordson)
        {
            recordson.DeptName = HIS.Base_BLL.BaseData.Collection[HIS.Base_BLL.DataEnum.医院科室表].GetValue(recordson.PAT_DEPTID, "dept_id", "name").ToString();
            recordson.ExecDept = HIS.Base_BLL.BaseData.Collection[HIS.Base_BLL.DataEnum.医院科室表].GetValue(recordson.EXEC_DEPT, "dept_id", "name").ToString();
            recordson.ExeNurse = HIS.Base_BLL.BaseData.Collection[HIS.Base_BLL.DataEnum.医院人员信息表].GetValue(recordson.TRANS_NURSE, "employee_id", "name").ToString();
            recordson.OrderDocName = HIS.Base_BLL.BaseData.Collection[HIS.Base_BLL.DataEnum.医院人员信息表].GetValue(recordson.ORDER_DOC, "employee_id", "name").ToString();
            recordson.EOrderDocName = HIS.Base_BLL.BaseData.Collection[HIS.Base_BLL.DataEnum.医院人员信息表].GetValue(recordson.EORDER_DOC, "employee_id", "name").ToString();
        }

        public static string GetEmployname(string employeeid)
        {
            return HIS.Base_BLL.BaseData.Collection[HIS.Base_BLL.DataEnum.医院人员信息表].GetValue(employeeid, "employee_id", "name").ToString();
        }

        public static string GetDeptName(string deptid)
        {
           return  HIS.Base_BLL.BaseData.Collection[HIS.Base_BLL.DataEnum.医院科室表].GetValue(deptid, "dept_id", "name").ToString();
        }
    }
}
