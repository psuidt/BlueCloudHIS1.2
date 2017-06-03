using System;
namespace HIS.Model
{
    public class BASE_VINDICATE_TABLE
    {
        private string _base_table_db_name;
        /// <summary>
        ///
        /// </summary>
        public string BASE_TABLE_DB_NAME
        {
            get
            {
                return _base_table_db_name;
            }
            set
            {
                _base_table_db_name = value;
            }

        }
        private string _base_table_cn_name;
        /// <summary>
        ///
        /// </summary>
        public string BASE_TABLE_CN_NAME
        {
            get
            {
                return _base_table_cn_name;
            }
            set
            {
                _base_table_cn_name = value;
            }

        }
        private int _allow_user_edit;
        /// <summary>
        /// 
        /// </summary>
        public int ALLOW_USER_EDIT
        {
            get
            {
                return _allow_user_edit;
            }
            set
            {
                _allow_user_edit = value;
            }
        }
        private int _allow_physic_delete;
        public int ALLOW_PHYSIC_DELETE
        {
            get
            {
                return _allow_physic_delete;
            }
            set
            {
                _allow_physic_delete = value;
            }
        }
    }
}
