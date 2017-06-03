using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;
using System.Data;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 医技申请模板类
    /// </summary>
    public class MedicalApplyMould:Model.Mz_Doc_MedicalApply_Mould
    {
        #region 成员变量
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;
        #endregion

        /// <summary>
        /// 医技申请模板类构造函数
        /// </summary>
        public MedicalApplyMould()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 医技申请模板类构造函数
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public MedicalApplyMould(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        public DataSet GetMouldData()
        {
            DataSet dataSet = new DataSet();
            string strwhere = Tables.mz_doc_medicalapply_mould.LEVEL + _oleDb.EuqalTo() + 1
                + _oleDb.And() + HIS.BLL.Tables.mz_doc_medicalapply_mould.ELEMENT_NAME + _oleDb.EuqalTo() + "'" + this.Element_Name + "'"
                + _oleDb.And() + HIS.BLL.Tables.mz_doc_medicalapply_mould.MEDICAL_CLASS + _oleDb.EuqalTo() + this.Medical_Class;
            DataTable table = BindEntity<HIS.Model.Mz_Doc_MedicalApply_Mould>.CreateInstanceDAL(_oleDb).GetList(strwhere);
            table.TableName = "LevelHMould";
            dataSet.Tables.Add(table);

            strwhere = Tables.mz_doc_medicalapply_mould.LEVEL + _oleDb.EuqalTo() + 2
                + _oleDb.And() + HIS.BLL.Tables.mz_doc_medicalapply_mould.ELEMENT_NAME + _oleDb.EuqalTo() + "'" + this.Element_Name + "'"
            + _oleDb.And() + HIS.BLL.Tables.mz_doc_medicalapply_mould.CREATE_DEPT + _oleDb.EuqalTo() + this.Create_Dept
            + _oleDb.And() + HIS.BLL.Tables.mz_doc_medicalapply_mould.MEDICAL_CLASS + _oleDb.EuqalTo() + this.Medical_Class;
            table = BindEntity<HIS.Model.Mz_Doc_MedicalApply_Mould>.CreateInstanceDAL(_oleDb).GetList(strwhere);
            table.TableName = "LevelDMould";
            dataSet.Tables.Add(table);

            strwhere = Tables.mz_doc_medicalapply_mould.LEVEL + _oleDb.EuqalTo() + 3
                + _oleDb.And() + HIS.BLL.Tables.mz_doc_medicalapply_mould.ELEMENT_NAME + _oleDb.EuqalTo() + "'" + this.Element_Name + "'"
            + _oleDb.And() + HIS.BLL.Tables.mz_doc_medicalapply_mould.CREATE_EMP + _oleDb.EuqalTo() + this.Create_Emp
            + _oleDb.And() + HIS.BLL.Tables.mz_doc_medicalapply_mould.MEDICAL_CLASS + _oleDb.EuqalTo() + this.Medical_Class;
            table = BindEntity<HIS.Model.Mz_Doc_MedicalApply_Mould>.CreateInstanceDAL(_oleDb).GetList(strwhere);
            table.TableName = "LevelPMould";
            dataSet.Tables.Add(table);

            return dataSet;
        }

        public void Save()
        {
            BindEntity<Model.Mz_Doc_MedicalApply_Mould>.CreateInstanceDAL(_oleDb).Add(this);
        }
    }
}
