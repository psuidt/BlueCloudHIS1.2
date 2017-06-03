using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYDoc_BLL.BaseInfo
{
    // 20100508.1.01  手术申请
    public class SsBase : BaseBLL
    {

        private DataSet dataSet = new DataSet();
        /// <summary>
        /// 获得诊断名称
        /// </summary>
        /// <returns></returns>
        private  DataTable GetDiages()
        {
            string strsql = "select * from base_disease";
            return oleDb.GetDataTable(strsql);
        }
        /// <summary>
        /// 获得手术名称
        /// </summary>
        /// <returns></returns>
        private DataTable GetOperation()
        {
            string strwhere = Views.vi_clinical_all_items.ORDER_TYPE + oleDb.EuqalTo() + 6;
            return BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_CLINICAL_ALL_ITEMS).GetList(strwhere);
        }
        /// <summary>
        /// 获得麻醉方式
        /// </summary>
        /// <returns></returns>
        private DataTable GetAnesth()
        {         
            return BindEntity<HIS.Model.BASE_SSANESTH>.CreateInstanceDAL(oleDb).GetList("");
        }
        /// <summary>
        /// 获得手术体位
        /// </summary>
        /// <returns></returns>
        private DataTable GetBody()
        {
            return BindEntity<HIS.Model.BASE_SSBODY>.CreateInstanceDAL(oleDb).GetList("");
        }

        /// <summary>
        /// 获得手术室医生姓名
        /// </summary>
        /// <returns></returns>
        private DataTable GetDocName()
        {    // 20100519.2.02 手术申请时医生选择时只显示手术室的医生
           string strWhere = @"SELECT a.EMPLOYEE_ID, NAME, D_CODE,PY_CODE,WB_CODE,FP_FLAG,STATUS FROM BASE_ROLE_DOCTOR a,
                             BASE_EMPLOYEE_PROPERTY b ,BASE_EMP_DEPT_ROLE c where a.employee_id=b.employee_id 
                             and b.employee_id=c.employee_id ";//and c.dept_id in ( select dept_id from BASE_DEPT_PROPERTY where sm_flag=1)";

           return oleDb.GetDataTable(strWhere);
        }
        /// <summary>
        /// 获得特殊器械
        /// </summary>
        /// <returns></returns>
        private DataTable GetApplice()
        {
            return BindEntity<HIS.Model.BASE_SSAPPLICE>.CreateInstanceDAL(oleDb).GetList("");
        }
        /// <summary>
        /// 获得科室
        /// </summary>
        /// <returns></returns>
        private DataTable GetDeptName()
        {        
            string strwhere = Tables.base_dept_property.TYPE_CODE + oleDb.EuqalTo() + "'001'" + oleDb.And() + Tables.base_dept_property.DELETED
                 + oleDb.EuqalTo() + 0 + oleDb.And() + Tables.base_dept_property.SM_FLAG + oleDb.EuqalTo() + 1; ;
            return BindEntity<HIS.Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL(oleDb).GetList(strwhere);
        }

        /// <summary>
        /// 获得手术级别
        /// </summary>
        /// <returns></returns>
        private DataTable GetSsGrade()
        {
            return BindEntity<HIS.Model.BASE_SSGRADE>.CreateInstanceDAL(oleDb).GetList("");
        }

        public DataSet  GetSsDataSet()
        {
            DataTable tb = null;
            tb = GetDiages();
            tb.TableName = "Diages";
            if (dataSet.Tables.Contains("Diages"))
            {
                dataSet.Tables.Remove("Diages");
            }
            dataSet.Tables.Add(tb);


            tb = GetOperation();
            tb.TableName = "Operation";
            if (dataSet.Tables.Contains("Operation"))
            {
                dataSet.Tables.Remove("Operation");
            }
            dataSet.Tables.Add(tb);

            tb = GetAnesth();
            tb.TableName = "Anesth";
            if (dataSet.Tables.Contains("Anesth"))
            {
                dataSet.Tables.Remove("Anesth");
            }
            dataSet.Tables.Add(tb);

            tb = GetBody();
            tb.TableName = "Body";
            if (dataSet.Tables.Contains("Body"))
            {
                dataSet.Tables.Remove("Body");
            }
            dataSet.Tables.Add(tb);

            tb = GetDocName();
            tb.TableName = "DocName";
            if (dataSet.Tables.Contains("DocName"))
            {
                dataSet.Tables.Remove("DocName");
            }
            dataSet.Tables.Add(tb);

            tb = GetApplice();
            tb.TableName = "Applice";
            if (dataSet.Tables.Contains("Applice"))
            {
                dataSet.Tables.Remove("Applice");
            }
            dataSet.Tables.Add(tb);

            tb = GetDeptName();
            tb.TableName = "Dept";
            if (dataSet.Tables.Contains("Dept"))
            {
                dataSet.Tables.Remove("Dept");
            }
            dataSet.Tables.Add(tb);

            tb = GetSsGrade();
            tb.TableName = "SsGrade";
            if (dataSet.Tables.Contains("SsGrade"))
            {
                dataSet.Tables.Remove("SsGrade");
            }
            dataSet.Tables.Add(tb);


            return dataSet;
        }
      
    }
}
