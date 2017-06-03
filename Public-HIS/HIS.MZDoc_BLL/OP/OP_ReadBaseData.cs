using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 基础数据读取操作类
    /// </summary>
    public class OP_ReadBaseData : BaseBLL
    {
        #region 获得名称
        /// <summary>
        /// 获得单位名称
        /// </summary>
        /// <param name="unitId">单位ID</param>
        /// <returns></returns>
        public static string GetUnitName(int unitId)
        {
            HIS.Model.YP_UnitDic unit = BindEntity<HIS.Model.YP_UnitDic>.CreateInstanceDAL(oleDb).GetModel(unitId);
            return unit == null ? "" : unit.UnitName;
        }

        /// <summary>
        /// 获得用法名称
        /// </summary>
        /// <param name="usageId">用法ID</param>
        /// <returns></returns>
        public static string GetUsageName(int usageId)
        {
            HIS.Model.Base_UsageDiction usage = BindEntity<HIS.Model.Base_UsageDiction>.CreateInstanceDAL(oleDb).GetModel(usageId);
            return usage == null ? "" : usage.Name;
        }

        /// <summary>
        /// 获得频次名称
        /// </summary>
        /// <param name="frequencyId">频次ID</param>
        /// <returns></returns>
        public static string GetFrequencyName(int frequencyId)
        {
            HIS.Model.Base_Frequency frequency = BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetModel(frequencyId);
            return frequency == null ? "" : frequency.Name;
        }

        /// <summary>
        /// 获得科室名称
        /// </summary>
        /// <param name="deptId">科室ID</param>
        /// <returns></returns>
        public static string GetDeptName(int deptId)
        {
            HIS.Model.BASE_DEPT_PROPERTY dept = BindEntity<HIS.Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL(oleDb).GetModel(deptId);
            return dept == null ? "" : dept.NAME;
        }

        /// <summary>
        /// 获得医技类型的名称
        /// </summary>
        /// <param name="medicalClassId">医技类型ID</param>
        /// <returns></returns>
        public static string GetMedicalClassName(int medicalClassId)
        {
            HIS.Model.Base_Medical_Class medicalClass = BindEntity<HIS.Model.Base_Medical_Class>.CreateInstanceDAL(oleDb).GetModel(medicalClassId);
            return medicalClass == null ? "" : medicalClass.Name;
        }

        /// <summary>
        /// 获得费用类型名称
        /// </summary>
        /// <param name="feeType">费用类型代码</param>
        /// <returns></returns>
        public static string GetFeeTypeName(string feeType)
        {
            DataTable table = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_PATIENTTYPE").GetList("CODE='" + feeType + "'");
            return ((table == null || table.Rows.Count <= 0) ? "" : table.Rows[0]["NAME"].ToString());
        }

        /// <summary>
        /// 获得工作单位名称
        /// </summary>
        /// <param name="feeType">工作单位代码</param>
        /// <returns></returns>
        public static string GetWorkUnitName(string workUnitCode)
        {
            DataTable table = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_WORK_UNIT").GetList("CODE='" + workUnitCode + "'");
            return ((table == null || table.Rows.Count <= 0) ? "" : table.Rows[0]["NAME"].ToString());
        }
        #endregion

        #region 获得基础数据
        /// <summary>
        /// 获得所有药品单位数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUnitData()
        {
            return BindEntity<HIS.Model.YP_UnitDic>.CreateInstanceDAL(oleDb).GetList("");
        }

        /// <summary>
        /// 获得所有用法数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUsageData()
        {
            return BindEntity<HIS.Model.Base_UsageDiction>.CreateInstanceDAL(oleDb).GetList("delete_bit=0");
        }

        /// <summary>
        /// 获得所有用法费用数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUsageFeeData()
        {
            return BindEntity<HIS.Model.BASE_USEAGE_FEE>.CreateInstanceDAL(oleDb).GetList("");
        }

        /// <summary>
        /// 获得输液卡用法id列表
        /// </summary>
        /// <returns></returns>
        public static string[] GetTransUseageIdList()
        {
            DataTable table = BindEntity<Model.Base_Usage_UseType_Role>.CreateInstanceDAL(oleDb).GetList("type_name='输液卡'");
            string[] strUsageId = new string[table.Rows.Count];
            for (int index = 0; index < table.Rows.Count; index++)
            {
                strUsageId[index] = table.Rows[index]["USAGE_ID"].ToString();
            }
            return strUsageId;
        }

        /// <summary>
        /// 获得所有频次数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFrequencyData()
        {
            return BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetList("delete_bit=0");
        }

        /// <summary>
        /// 获得所有嘱托数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEntrustData()
        {
            return BindEntity<HIS.Model.Base_Entrust>.CreateInstanceDAL(oleDb).GetList("delete_bit=0");
        }

        /// <summary>
        /// 获得所有化验样本数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSampleData()
        {
            return BindEntity<HIS.Model.Base_Sample>.CreateInstanceDAL(oleDb).GetList("delete_bit=0");
        }

        /// <summary>
        /// 获得所有附加说明数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetParamData()
        {
            return BindEntity<HIS.Model.Base_Param>.CreateInstanceDAL(oleDb).GetList("delete_bit=0");
        }

        /// <summary>
        /// 获得所有检查部位数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPlaceData()
        {
            return BindEntity<HIS.Model.Base_ExaminePlace>.CreateInstanceDAL(oleDb).GetList("delete_bit=0");
        }

        /// <summary>
        /// 获得所有项目数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllBaseItemData()
        {
            DataTable table = BindEntity<object>.CreateInstanceDAL(oleDb, HIS.BLL.Views.VI_CLINICAL_ALL_ITEMS).GetList("");
            table.Columns["SERVER_ITEM_ID"].ColumnName = "Service_Item_Id";
            return table;
        }

        /// <summary>
        /// 获得所有有效的项目数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetBaseItemData()
        {
            DataTable table = BindEntity<object>.CreateInstanceDAL(oleDb, HIS.BLL.Views.VI_CLINICAL_ALL_ITEMS).GetList("STORENUM>0");
            table.Columns["SERVER_ITEM_ID"].ColumnName = "Service_Item_Id";
            return table;
        }

        /// <summary>
        /// 获得中医诊断列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEastDiagnosisData()
        {
            string strsql = Tables.base_disease.SORT + oleDb.In("'B','Z'");
            return BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_DISEASE).GetList(strsql);
        }

        /// <summary>
        /// 获得西医诊断列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetWastDiagnosisData()
        {
            string strsql = Tables.base_disease.SORT + oleDb.In("'D','M','Y'");
            return BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_DISEASE).GetList(strsql);
        }

        /// <summary>
        /// 获得住院临床科室列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetZYDeptData()
        {
            string strsql = Tables.base_dept_property.ZY_FLAG + oleDb.EuqalTo() + 1 + oleDb.And() + Tables.base_dept_property.TYPE_CODE + oleDb.EuqalTo() + "'001'";
            return BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_DEPT_PROPERTY).GetList(strsql);
        }

        /// <summary>
        /// 获得门诊临床科室列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMZDeptData()
        {
            string strsql = Tables.base_dept_property.MZ_FLAG + oleDb.EuqalTo() + 1 + oleDb.And() + Tables.base_dept_property.TYPE_CODE + oleDb.EuqalTo() + "'001'";
            return BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_DEPT_PROPERTY).GetList(strsql);
        }

        /// <summary>
        /// 获得医生列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDoctorData()
        {
            DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(oleDb);
            return mzdoc_dal.Load_DoctorData();
        }

        /// <summary>
        /// 获得病人类型列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPatientTypeData()
        {
            return BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_PATIENTTYPE).GetList("");
        }

        /// <summary>
        /// 获得工作单位列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetWorkUnitData()
        {
            return BindEntity<Model.BASE_WORK_UNIT>.CreateInstanceDAL(oleDb).GetList("");
        }

        /// <summary>
        /// 获得科室列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDeptData()
        {
            return BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL(oleDb).GetList(Tables.base_dept_property.DELETED + oleDb.EuqalTo() + 0);
        }

        /// <summary>
        /// 获得收费项目执行科室列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetItemExeDeptData()
        {
            return BindEntity<Model.BASE_ITEM_DEPT>.CreateInstanceDAL(oleDb).GetList("");
        }

        /// <summary>
        /// 获得大项目代码列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetStatItemTable()
        {
            return BindEntity<Model.BASE_STAT_ITEM>.CreateInstanceDAL(oleDb).GetList("");
        }

        /// <summary>
        /// 获得门诊发票代码列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetStatMzfpTable()
        {
            return BindEntity<Model.BASE_STAT_MZFP>.CreateInstanceDAL(oleDb).GetList("");
        }

        /// <summary>
        /// 获得核算项目代码列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetStatHsTable()
        {
            return BindEntity<Model.BASE_STAT_HS>.CreateInstanceDAL(oleDb).GetList("");
        }

        /// <summary>
        /// 获得科室药房对应关系
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDeptStore(long deptId)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", Type.GetType("System.String"));
            table.Columns.Add("Value", Type.GetType("System.String"));
            try
            {
                string drugDeptIds = "";
                string[] drugDepts = GetConfigValue("005").Split(',');
                foreach (string drugDept in drugDepts)
                {
                    string[] values = drugDept.Split('-');
                    drugDeptIds += (Convert.ToInt32(values[0]) == deptId ? (values[1] + ",") : "");
                }
                if (drugDeptIds.Trim() != "")
                {
                    drugDeptIds = drugDeptIds.Substring(0, drugDeptIds.Length - 1);
                    table.Rows.Add("默认药房", drugDeptIds);
                }
            }
            catch
            {
            }

            table.Rows.Add("全部药房", -1);

            DataTable drugDeptTable = BindEntity<Model.YP_DeptDic>.CreateInstanceDAL(oleDb).GetList("DEPTTYPE1='药房'");
            if (drugDeptTable != null)
            {
                foreach (DataRow row in drugDeptTable.Rows)
                {
                    table.Rows.Add(row["DeptName"].ToString().Trim(), row["DeptId"]);
                }
            }
            return table;
        }
        #endregion

        #region 其他
        /// <summary>
        /// 获得科室是否是临床科室
        /// </summary>
        /// <param name="deptId">科室ID</param>
        /// <returns></returns>
        public static bool IsClinicDept(int deptId)
        {
            HIS.Model.BASE_DEPT_PROPERTY dept = BindEntity<HIS.Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL(oleDb).GetModel(deptId);
            return dept == null ? false : dept.TYPE_CODE.Trim() == "001";
        }

        /// <summary>
        /// 获取系统参数的值
        /// </summary>
        /// <param name="configCode">参数编码</param>
        /// <returns></returns>
        public static string GetConfigValue(string configCode)
        {
            //参数表修改，实体有改动
            HIS.Model.MZ_DOC_CONFIG config = BindEntity<HIS.Model.MZ_DOC_CONFIG>.CreateInstanceDAL(oleDb).GetModel("Code='" + configCode + "'");
            return config == null ? "" : config.VALUE;
        }

        /// <summary>
        /// 获取医技申请格式的Xml文本
        /// </summary>
        /// <param name="medicalClassId">医技类型Id</param>
        /// <returns></returns>
        public static string GetMedicalApplyXmlDocument(int medicalClassId)
        {
            Model.Base_Medical_Class medical_class = BindEntity<Model.Base_Medical_Class>.CreateInstanceDAL(oleDb).GetModel(medicalClassId);
            if (medical_class != null)
            {
                return medical_class.PrintType;
            }
            else
            {
                return "";
            }
        }        
        #endregion
    }
}
