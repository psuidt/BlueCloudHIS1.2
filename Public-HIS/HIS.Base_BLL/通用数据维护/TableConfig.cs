using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 表配置信息对象
    /// </summary>
    public class TableConfig
    {
        private string base_table_db_name;
        private string base_table_cn_name;
        private bool allow_user_edit;
        private bool allow_physic_delete;

        public string BASE_TABLE_DB_NAME
        {
            get
            {
                return base_table_db_name;
            }
            set
            {
                base_table_db_name = value;
            }
        }
        public string BASE_TABLE_CN_NAME
        {
            get
            {
                return base_table_cn_name;
            }
            set
            {
                base_table_cn_name = value;
            }
        }
        public bool ALLOW_USER_EDIT
        {
            get
            {
                return allow_user_edit;
            }
            set
            {
                allow_user_edit = value;
            }
        }
        public bool ALLOW_PHYSIC_DELETE
        {
            get
            {
                return allow_physic_delete;
            }
            set
            {
                allow_physic_delete = value;
            }
        }
    }
}
