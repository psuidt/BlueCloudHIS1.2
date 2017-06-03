using System;
using System.IO;
using System.Xml;
using System.Reflection;
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
    /// 治疗申请类
    /// </summary>
    public class MedicalTreat : BaseMedical
    {
        //private string MedicalTreatApplyContent = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><ApplyContent></ApplyContent>";

        /// <summary>
        /// 治疗申请类构造函数
        /// </summary>
        public MedicalTreat()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 治疗申请类构造函数
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public MedicalTreat(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        /// <summary>
        /// 获得医技科室
        /// </summary>
        /// <param name="dataSet">基础数据集</param>
        /// <returns></returns>
        public override DataTable LoadMedicalDept(DataSet dataSet)
        {
            if (dataSet.Tables.IndexOf("MedicalTreatDept") < 0)
            {
                DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(_oleDb);
                DataTable table = mzdoc_dal.Load_MedicalTreatDept();
                table.TableName = "MedicalTreatDept";
                dataSet.Tables.Add(table);
            }
            return dataSet.Tables["MedicalTreatDept"];
        }

        /// <summary>
        /// 获得医技项目类型
        /// </summary>
        /// <returns></returns>
        public override List<Model.Base_Medical_Class> LoadMedicalClass()
        {
            DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(_oleDb);
            return mzdoc_dal.Load_MedicalClass("CLASS_TYPE=2");
        }

        /// <summary>
        /// 获得医技项目类型
        /// </summary>
        /// <param name="dataSet">基础数据集</param>
        /// <param name="deptId">科室ID</param>
        /// <returns></returns>
        public override DataTable LoadMedicalClass(DataSet dataSet, int deptId)
        {
            if (dataSet.Tables.IndexOf("MedicalTreatClass") < 0)
            {
                DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(_oleDb);
                DataTable table = mzdoc_dal.Load_MedicalTreatClass();
                table.TableName = "MedicalTreatClass";
                dataSet.Tables.Add(table);
            }
            DataRow[] rows = dataSet.Tables["MedicalTreatClass"].Select("dept_id=" + deptId + "or " + deptId + "=-1");
            DataTable resultTable = dataSet.Tables["MedicalTreatClass"].Clone();
            if (rows != null && rows.Length > 0)
            {
                for (int index = 0; index < rows.Length; index++)
                {
                    resultTable.Rows.Add(rows[index].ItemArray);
                }
            }
            return resultTable;
        }

        /// <summary>
        /// 获得医技项目明细
        /// </summary>
        /// <param name="dataSet">基础数据集</param>
        /// <param name="deptId">科室ID</param>
        /// <param name="medicalClass">医技分类</param>
        /// <returns></returns>
        public override DataTable LoadMedicalItem(DataSet dataSet, int deptId, int medicalClass)
        {
            if (dataSet.Tables.IndexOf("MedicalItem") < 0)
            {
                LoadMedicalItem(dataSet);
            }
            string strsql = Views.vi_clinical_order.ORDER_TYPE + _oleDb.EuqalTo() + 4 +
                _oleDb.And() + Views.vi_clinical_order.DEPT_ID + _oleDb.EuqalTo() + deptId +
                _oleDb.And() + Views.vi_clinical_order.MEDICAL_CLASS + _oleDb.EuqalTo() + medicalClass;
            DataRow[] rows = dataSet.Tables["MedicalItem"].Select(strsql, Views.vi_clinical_order.ORDER_NAME);
            DataTable resultTable = dataSet.Tables["MedicalItem"].Clone();
            if (rows != null && rows.Length > 0)
            {
                for (int index = 0; index < rows.Length; index++)
                {
                    resultTable.Rows.Add(rows[index].ItemArray);
                }
            }
            return resultTable;
        }

        /// <summary>
        /// 创建申请记录
        /// </summary>
        /// <param name="item">医技申请项目</param>
        public override void CreateApply(Medical_Order_Item item)
        {
            base.CreateBaseApply(item);
            this.Apply_Type = 2;
            this.Num = 1;
        }

        /// <summary>
        /// 合成申请内容
        /// </summary>
        public override void ComposeApplyContent()
        {
            this.Apply_Content = Public.XmlFunction.ComposeXmlText(this, Properties.Resources.MedicalTreatApplyContent, "ApplyContent");
        }

        /// <summary>
        /// 分解申请内容
        /// </summary>
        public override void DeComposeApplyContent()
        {
            if (this.ApplyId <= 0)
            {
                Public.XmlFunction.DeComposeXmlText(this, Properties.Resources.MedicalTreatApplyContent, "ApplyContent");
            }
            else
            {
                Public.XmlFunction.DeComposeXmlText(this, this.Apply_Content, "ApplyContent");
            }
        }
    }
}
