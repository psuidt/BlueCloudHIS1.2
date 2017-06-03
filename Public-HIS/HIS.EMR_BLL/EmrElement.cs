using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;

namespace HIS.EMR_BLL
{
    /// <summary>
    /// 病历元素
    /// </summary>
    public class EmrElement : Model.Emr_Base_Element
    {
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;

        /// <summary>
        /// 病历元素
        /// </summary>
        public EmrElement()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 病历元素
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public EmrElement(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }
        /// <summary>
        /// 获得病历元素
        /// </summary>
        /// <param name="elementCode">元素编码</param>
        /// <returns></returns>
        public EmrElement CreateElement(string elementCode)
        {
            Model.Emr_Base_Element baseElement = BindEntity<Model.Emr_Base_Element>.CreateInstanceDAL(_oleDb).GetModel(
                HIS.BLL.Tables.emr_base_element.ELEMENTCODE + _oleDb.EuqalTo() + "'" + elementCode + "'");
            if (baseElement == null)
            {
                return null;
            }
           EmrElement element = new EmrElement();
           element = (EmrElement)HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjectToObj(baseElement, element);
           return element;
        }
        /// <summary>
        /// 获得主元素
        /// </summary>
        /// <returns></returns>
        public DataTable GetChiefElement()
        {
            return BindEntity<Model.Emr_Base_Element>.CreateInstanceDAL(_oleDb).GetList(
                HIS.BLL.Tables.emr_base_element.ELEMENTLEVEL + _oleDb.EuqalTo() + 1 + 
                _oleDb.OrderBy() + HIS.BLL.Tables.emr_base_element.ELEMENTCODE);
        }
        /// <summary>
        /// 获得所有的病历元素
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllElement()
        {
            return BindEntity<Model.Emr_Base_Element>.CreateInstanceDAL(_oleDb).GetList("1=1"+
                _oleDb.OrderBy() + HIS.BLL.Tables.emr_base_element.ELEMENTCODE);
        }
        /// <summary>
        /// 获得病历元素模板列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetElementMould()
        {
            DataTable table = BindEntity<Model.Emr_Mould_Element>.CreateInstanceDAL(_oleDb).GetList(
                HIS.BLL.Tables.emr_mould_element.MOULDTYPE + _oleDb.EuqalTo() + "'" + this.ElementCode.Trim() + "'" + 
                _oleDb.And()+HIS.BLL.Tables.emr_mould_element.DELETE_BIT+_oleDb.EuqalTo()+0+
                _oleDb.OrderBy() + HIS.BLL.Tables.emr_mould_element.MOULDID);
            if (table != null)
            {
                table.Columns.Add("RowNo", Type.GetType("System.Int32"));
                for (int index = 0; index < table.Rows.Count; index++)
                {
                    table.Rows[index]["RowNo"] = index + 1;
                }
            }
            return table;
        }
        /// <summary>
        /// 获得病历元素模板列表
        /// </summary>
        /// <param name="level">模板级别</param>
        /// <param name="employeeId">员工Id</param>
        /// <param name="deptId">科室Id</param>
        /// <returns></returns>
        public DataTable GetElementMould(int level, long employeeId, long deptId)
        {
            string strSql = "";
            switch (level)
            {
                case 1:
                    strSql = HIS.BLL.Tables.emr_mould_element.MOULDTYPE + _oleDb.EuqalTo() + "'" + this.ElementCode.Trim() + "'" +
                        _oleDb.And() + HIS.BLL.Tables.emr_mould_element.MOULDLEVEL + _oleDb.EuqalTo() + level +
                _oleDb.And() + HIS.BLL.Tables.emr_mould_element.DELETE_BIT + _oleDb.EuqalTo() + 0 +
                _oleDb.OrderBy() + HIS.BLL.Tables.emr_mould_element.MOULDID;
                    break;
                case 2:
                    strSql = HIS.BLL.Tables.emr_mould_element.MOULDTYPE + _oleDb.EuqalTo() + "'" + this.ElementCode.Trim() + "'" +
                        _oleDb.And() + HIS.BLL.Tables.emr_mould_element.MOULDLEVEL + _oleDb.EuqalTo() + level +
                         _oleDb.And() + HIS.BLL.Tables.emr_mould_element.MOULDCREATEDEPT + _oleDb.EuqalTo() + deptId +
                _oleDb.And() + HIS.BLL.Tables.emr_mould_element.DELETE_BIT + _oleDb.EuqalTo() + 0 +
                _oleDb.OrderBy() + HIS.BLL.Tables.emr_mould_element.MOULDID;
                    break;
                case 3:
                    strSql = HIS.BLL.Tables.emr_mould_element.MOULDTYPE + _oleDb.EuqalTo() + "'" + this.ElementCode.Trim() + "'" +
                        _oleDb.And() + HIS.BLL.Tables.emr_mould_element.MOULDLEVEL + _oleDb.EuqalTo() + level +
                         _oleDb.And() + HIS.BLL.Tables.emr_mould_element.MOULDCREATEEMP + _oleDb.EuqalTo() + employeeId +
                _oleDb.And() + HIS.BLL.Tables.emr_mould_element.DELETE_BIT + _oleDb.EuqalTo() + 0 +
                _oleDb.OrderBy() + HIS.BLL.Tables.emr_mould_element.MOULDID;
                    break;
            }

            DataTable table = BindEntity<Model.Emr_Mould_Element>.CreateInstanceDAL(_oleDb).GetList(strSql);
            if (table != null)
            {
                table.Columns.Add("RowNo", Type.GetType("System.Int32"));
                for (int index = 0; index < table.Rows.Count; index++)
                {
                    table.Rows[index]["RowNo"] = index + 1;
                }
            }
            return table;
        }
    }
}
