using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;
using System.Xml;

namespace HIS.EMR_BLL
{
    /// <summary>
    /// 病历模板
    /// </summary>
    public class EmrMould : Model.Emr_Mould_Class
    {
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;

        private XmlDocument _mouldContent; //Xml格式的病历模板内容

        /// <summary>
        /// 病历模板
        /// </summary>
        public EmrMould()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 病历模板
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public EmrMould(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        /// <summary>
        /// Xml格式的病历模板内容
        /// </summary>
        public XmlDocument MouldContent
        {
            get 
            {
                if (_mouldContent == null)
                {
                    Model.Emr_Mould_Content content = BindEntity<Model.Emr_Mould_Content>.CreateInstanceDAL(_oleDb).GetModel(
                                            HIS.BLL.Tables.emr_mould_content.MOULDID+_oleDb.EuqalTo()+this.MouldId);
                    _mouldContent = new XmlDocument();
                    try
                    {
                        _mouldContent.LoadXml(content.MouldContent);
                    }
                    catch
                    { 
                    }
                }
                return _mouldContent;
            }
            set
            {
                _mouldContent = value;
            }
        }

        /// <summary>
        /// 添加模板
        /// </summary>
        public void Add()
        {
            DataTable table = BindEntity<Model.Emr_Mould_Class>.CreateInstanceDAL(_oleDb).GetList(
                Tables.emr_mould_class.MOULDNAME+_oleDb.EuqalTo()+"'"+this.MouldName.Trim()+"'"
                +_oleDb.And()+Tables.emr_mould_class.DELETE_BIT+_oleDb.EuqalTo()+0);
            if (table != null && table.Rows.Count > 0)
            {
                throw new Exception("该模板名称已存在，请为模板指定新的名称！");
            }
            BindEntity<Model.Emr_Mould_Class>.CreateInstanceDAL(_oleDb).Add(this);

            Model.Emr_Mould_Content content = new HIS.Model.Emr_Mould_Content();
            content.MouldId = this.MouldId;
            content.MouldContent = _mouldContent.InnerXml;
            BindEntity<Model.Emr_Mould_Content>.CreateInstanceDAL(_oleDb).Add(content);
        }

        /// <summary>
        /// 修改模板
        /// </summary>
        public void Update()
        {
            BindEntity<Model.Emr_Mould_Class>.CreateInstanceDAL(_oleDb).Update(this);

            Model.Emr_Mould_Content content = new HIS.Model.Emr_Mould_Content();
            content.MouldId = this.MouldId;
            content.MouldContent = _mouldContent.InnerXml;
            BindEntity<Model.Emr_Mould_Content>.CreateInstanceDAL(_oleDb).Update(content);
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        public void Delete()
        {
            this.Delete_Bit = 1;
            BindEntity<Model.Emr_Mould_Class>.CreateInstanceDAL(_oleDb).Update(this);
        }

        /// <summary>
        /// 获得病历模板分类信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllMouldClass()
        {
            return BindEntity<Model.Emr_Mould_Class>.CreateInstanceDAL(_oleDb).GetList(HIS.BLL.Tables.emr_mould_class.DELETE_BIT+_oleDb.EuqalTo()+0);
        }

        /// <summary>
        /// 获得病历模板分类信息
        /// </summary>
        /// <param name="level">模板级别</param>
        /// <param name="employeeId">员工Id</param>
        /// <param name="deptId">科室Id</param>
        /// <returns></returns>
        public DataTable GetAllMouldClass(int level,long employeeId,long deptId)
        {
            switch (level)
            { 
                case 1:
                    return BindEntity<Model.Emr_Mould_Class>.CreateInstanceDAL(_oleDb).GetList(
                        HIS.BLL.Tables.emr_mould_class.MOULDLEVEL + _oleDb.EuqalTo() + level
                        + _oleDb.And() + HIS.BLL.Tables.emr_mould_class.DELETE_BIT + _oleDb.EuqalTo() + 0);
                case 2:
                    return BindEntity<Model.Emr_Mould_Class>.CreateInstanceDAL(_oleDb).GetList(
                        HIS.BLL.Tables.emr_mould_class.MOULDLEVEL + _oleDb.EuqalTo() + level
                        +_oleDb.And()+HIS.BLL.Tables.emr_mould_class.MOULDCREATEDEPT+_oleDb.EuqalTo()+deptId
                        + _oleDb.And() + HIS.BLL.Tables.emr_mould_class.DELETE_BIT + _oleDb.EuqalTo() + 0);
                default:
                    return BindEntity<Model.Emr_Mould_Class>.CreateInstanceDAL(_oleDb).GetList(
                        HIS.BLL.Tables.emr_mould_class.MOULDLEVEL + _oleDb.EuqalTo() + level
                        + _oleDb.And() + HIS.BLL.Tables.emr_mould_class.MOULDCREATEEMP + _oleDb.EuqalTo() + employeeId
                        + _oleDb.And() + HIS.BLL.Tables.emr_mould_class.DELETE_BIT + _oleDb.EuqalTo() + 0);
            }
        }
    }
}
