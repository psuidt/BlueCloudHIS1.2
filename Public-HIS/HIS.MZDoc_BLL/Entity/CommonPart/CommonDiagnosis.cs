using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS;
using HIS.BLL;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 常用诊断类
    /// </summary>
    public class CommonDiagnosis : Model.Mz_Doc_CommonDiagnosis, IBaseCommon
    {
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;  

        /// <summary>
        /// 常用诊断类构造函数
        /// </summary>
        public CommonDiagnosis()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 常用诊断类构造函数
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public CommonDiagnosis(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        /// <summary>
        /// 加载常用诊断数据
        /// </summary>
        /// <param name="employeeid">所属医生Id</param>
        /// <returns>常用诊断数据表</returns>
        public DataTable LoadCommonData(long employeeid)
        {
            string strsql = Tables.mz_doc_commondiagnosis.RECORD_DOC + _oleDb.EuqalTo() + employeeid
                + _oleDb.And() + Tables.mz_doc_commondiagnosis.DELETE_BIT + _oleDb.EuqalTo() + 0 + _oleDb.OrderBy("Frequency desc");
            return BindEntity<Model.Mz_Doc_CommonDiagnosis>.CreateInstanceDAL(_oleDb).GetList(strsql);
        }

        /// <summary>
        /// 加载诊断数据
        /// </summary>
        /// <returns>诊断基础数据</returns>
        public DataTable LoadShowCardData()
        {            
            DataTable table = BindEntity<object>.CreateInstanceDAL(_oleDb, Tables.BASE_DISEASE).GetList("");
            table.Columns[Tables.base_disease.CODING].ColumnName = Tables.mz_doc_commondiagnosis.DIAGNOSIS_CODE;
            table.Columns[Tables.base_disease.NAME].ColumnName = Tables.mz_doc_commondiagnosis.DIAGNOSIS_NAME;
            return table;
        }

        /// <summary>
        /// 新增常用诊断数据
        /// </summary>
        /// <returns></returns>
        public bool Add()
        {
            BindEntity<Model.Mz_Doc_CommonDiagnosis>.CreateInstanceDAL(_oleDb).Add(this); 
            return true;
        }

        /// <summary>
        /// 修改常用诊断数据
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            BindEntity<Model.Mz_Doc_CommonDiagnosis>.CreateInstanceDAL(_oleDb).Update(this);
            return true;
        }

        /// <summary>
        /// 删除常用诊断数据
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            this.Delete_Bit = 1;
            BindEntity<Model.Mz_Doc_CommonDiagnosis>.CreateInstanceDAL(_oleDb).Update(this);
            return true;
        }

        /// <summary>
        /// 累加常用项
        /// </summary>
        /// <param name="diagnosisText">诊断内容</param>
        /// <param name="employeeId">操作人员ID</param>
        public void Increase(string diagnosisText,long employeeId)
        {
            if (diagnosisText.Trim() == "")
                return;

            Model.Mz_Doc_CommonDiagnosis commonDiagnosis = BindEntity<Model.Mz_Doc_CommonDiagnosis>.CreateInstanceDAL(_oleDb).GetModel(
                BLL.Tables.mz_doc_commondiagnosis.DIAGNOSIS_NAME + _oleDb.EuqalTo() + "'" + diagnosisText+"'"
                +_oleDb.And()+BLL.Tables.mz_doc_commondiagnosis.RECORD_DOC+_oleDb.EuqalTo()+employeeId);

            //如果该诊断在常用诊断表中不存在，则添加新纪录，否则在使用频度上累加一次
            if (commonDiagnosis == null)
            {
                commonDiagnosis = new HIS.Model.Mz_Doc_CommonDiagnosis();
                commonDiagnosis.Diagnosis_Name = diagnosisText;
                commonDiagnosis.Record_Doc = (int)employeeId;
                string[] pyWbCode = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode(diagnosisText);
                commonDiagnosis.Py_Code = pyWbCode[0];
                commonDiagnosis.Wb_Code = pyWbCode[0];
                commonDiagnosis.Frequency = 1;
                BindEntity<Model.Mz_Doc_CommonDiagnosis>.CreateInstanceDAL(_oleDb).Add(commonDiagnosis);
            }
            else
            {
                commonDiagnosis.Frequency = commonDiagnosis.Frequency + 1;
                BindEntity<Model.Mz_Doc_CommonDiagnosis>.CreateInstanceDAL(_oleDb).Update(commonDiagnosis);
            }
        }
    }
}
