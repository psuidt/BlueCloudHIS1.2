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
    /// 病历元素模板
    /// </summary>
    public class EmrElementMould : Model.Emr_Mould_Element
    {
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;

        /// <summary>
        /// 病历元素模板
        /// </summary>
        public EmrElementMould()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 病历元素模板
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public EmrElementMould(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        /// <summary>
        /// 添加模板
        /// </summary>
        public void Add()
        {
            BindEntity<Model.Emr_Mould_Element>.CreateInstanceDAL(_oleDb).Add(this);
        }

        /// <summary>
        /// 修改模板
        /// </summary>
        public void Update()
        {
            BindEntity<Model.Emr_Mould_Element>.CreateInstanceDAL(_oleDb).Update(this);
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        public void Delete()
        {
            this.Delete_Bit = 1;
            BindEntity<Model.Emr_Mould_Element>.CreateInstanceDAL(_oleDb).Update(this);
        }
    }
}
