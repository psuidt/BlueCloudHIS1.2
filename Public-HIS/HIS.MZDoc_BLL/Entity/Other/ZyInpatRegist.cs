using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;
using System.Reflection;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 住院证类
    /// </summary>
    public class ZyInpatRegist : Model.Mz_Doc_Zy_Inpat_Reg
    { 
        #region 成员变量

        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;

        #endregion

        /// <summary>
        /// 住院证类构造函数
        /// </summary>
        public ZyInpatRegist()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 住院证类构造函数
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public ZyInpatRegist(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        /// <summary>
        /// 住院证类构造函数
        /// </summary>
        /// <param name="patListId">病人门诊就诊ID</param>
        public ZyInpatRegist(int patListId)
        {
            _oleDb = BaseBLL.oleDb;
            this.Copy(
                BindEntity<HIS.Model.Mz_Doc_Zy_Inpat_Reg>.CreateInstanceDAL(_oleDb).GetModel(
                  Tables.mz_doc_zy_inpat_reg.PATLISTID + _oleDb.EuqalTo() + patListId));
            //string strsql = Tables.mz_doc_zy_inpat_reg.PATLISTID + _oleDb.EuqalTo() + patListId;
            //HIS.Model.Mz_Doc_Zy_Inpat_Reg tmpObject = (HIS.Model.Mz_Doc_Zy_Inpat_Reg)BindEntity<HIS.Model.Mz_Doc_Zy_Inpat_Reg>.CreateInstanceDAL(_oleDb).GetModel(strsql);
            //if (tmpObject != null)
            //{
            //    PropertyInfo[] propertys = this.GetType().GetProperties();
            //    foreach (PropertyInfo property in this.GetType().GetProperties())
            //    {
            //        property.SetValue(this, property.GetValue(tmpObject, null), null);
            //    }
            //}
        }

        public ZyInpatRegist(long regId)
        {
            _oleDb = BaseBLL.oleDb;
            this.Copy(
                BindEntity<HIS.Model.Mz_Doc_Zy_Inpat_Reg>.CreateInstanceDAL(_oleDb).GetModel(
                  Tables.mz_doc_zy_inpat_reg.REGID + _oleDb.EuqalTo() + regId));
            //string strsql = Tables.mz_doc_zy_inpat_reg.PATLISTID + _oleDb.EuqalTo() + patListId;
            //HIS.Model.Mz_Doc_Zy_Inpat_Reg tmpObject = (HIS.Model.Mz_Doc_Zy_Inpat_Reg)BindEntity<HIS.Model.Mz_Doc_Zy_Inpat_Reg>.CreateInstanceDAL(_oleDb).GetModel(strsql);
            //if (tmpObject != null)
            //{
            //    PropertyInfo[] propertys = this.GetType().GetProperties();
            //    foreach (PropertyInfo property in this.GetType().GetProperties())
            //    {
            //        property.SetValue(this, property.GetValue(tmpObject, null), null);
            //    }
            //}
        }

        private void Copy(object obj)
        {
            if (obj != null)
            {
                PropertyInfo[] propertys = this.GetType().GetProperties();
                foreach (PropertyInfo property in this.GetType().GetProperties())
                {
                    property.SetValue(this, property.GetValue(obj, null), null);
                }
            }
        }

        /// <summary>
        /// 保存住院证信息
        /// </summary>
        public void Save()
        {
            if (this.RegId > 0)
            {
                BindEntity<HIS.Model.Mz_Doc_Zy_Inpat_Reg>.CreateInstanceDAL(_oleDb).Update(this);
            }
            else
            {
                BindEntity<HIS.Model.Mz_Doc_Zy_Inpat_Reg>.CreateInstanceDAL(_oleDb).Add(this);
            }
        }

        public DataTable GetValueTable()
        {
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("Name", Type.GetType("System.String"));
            resultTable.Columns.Add("Value", Type.GetType("System.String"));
            if(this.RegId>0)
            {
                resultTable = Public.XmlFunction.DeComposeXmlText(this.Reg_Content, "ZyInpatRegContent", resultTable);
            }
            return resultTable;
        }
    }
}
