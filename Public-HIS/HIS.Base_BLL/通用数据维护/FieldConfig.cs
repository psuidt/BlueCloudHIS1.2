using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Base_BLL.Enums;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 字段配置信息对象
    /// </summary>
    public class FieldConfig
    {
        private string table_db_name;

        private string table_cn_name;

        private string field_db_name;

        private string field_cn_name;

        private FIELD_DB_TYPE field_db_type;

        private bool is_primary_key;

        private bool auto_increase;

        private bool allow_empty;

        private int maxlength;

        private bool is_foreigner_key;

        private string foreigner_table;

        private string foreigner_field_db_name;

        private string foreigner_field_cn_name;

        private string foreigner_filter_sql;

        private ControlType uic_type;

        private int location_x;

        private int location_y;

        private int width;

        private int height;

        private int grid_col_width;

        private int tabindex;

        private bool allow_edit;

        private HIS.Base_BLL.Enums.FIELD_MARK_TYPE field_mark_type;
        //==
        /// <summary>
        /// 表名称
        /// </summary>
        public string TABLE_DB_NAME
        {
            get
            {
                return table_db_name;
            }
            set
            {
                table_db_name = value;
            }
        }
        /// <summary>
        /// 表中文名
        /// </summary>
        public string TABLE_CN_NAME
        {
            get
            {
                return table_cn_name;
            }
            set
            {
                table_cn_name = value.Trim();
            }
        }
        /// <summary>
        /// 字段名
        /// </summary>
        public string FIELD_DB_NAME
        {
            get
            {
                return field_db_name;
            }
            set
            {
                field_db_name = value.Trim();
            }
        }
        /// <summary>
        /// 字段中文名
        /// </summary>
        public string FIELD_CN_NAME
        {
            get
            {
                return field_cn_name;
            }
            set
            {
                field_cn_name = value.Trim();
            }
        }
        /// <summary>
        /// 字段类型
        /// </summary>
        public FIELD_DB_TYPE FIELD_DB_TYPE
        {
            get
            {
                return field_db_type;
            }
            set
            {
                field_db_type = value;
            }
        }
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IS_PRIMARY_KEY
        {
            get
            {
                return is_primary_key;
            }
            set
            {
                is_primary_key = value;
            }
        }
        /// <summary>
        /// 是否自增长
        /// </summary>
        public bool AUTO_INCREASE
        {
            get
            {
                return auto_increase;
            }
            set
            {
                auto_increase = value;
            }
        }
        /// <summary>
        /// 是否允许空
        /// </summary>
        public bool ALLOW_EMPTY
        {
            get
            {
                return allow_empty;
            }
            set
            {
                allow_empty = value;
            }
        }
        /// <summary>
        /// 最大长度
        /// </summary>
        public int MAXLENGTH
        {
            get
            {
                return maxlength;
            }
            set
            {
                maxlength = value;
            }
        }
        /// <summary>
        /// 是否外键
        /// </summary>
        public bool IS_FOREIGNER_KEY
        {
            get
            {
                return is_foreigner_key;
            }
            set
            {
                is_foreigner_key = value;
            }
        }
        /// <summary>
        /// 外键表名称
        /// </summary>
        public string FOREIGNER_TABLE
        {
            get
            {
                return foreigner_table;
            }
            set
            {
                foreigner_table = value;
            }
        }
        /// <summary>
        /// 对应的外键表的字段名称
        /// </summary>
        public string FOREIGNER_FIELD_DB_NAME
        {
            get
            {
                return foreigner_field_db_name;
            }
            set
            {
                foreigner_field_db_name = value;
            }
        }
        /// <summary>
        /// 对应的外键表的字段中文名
        /// </summary>
        public string FOREIGNER_FIELD_CN_NAME
        {
            get
            {
                return foreigner_field_cn_name;
            }
            set
            {
                foreigner_field_cn_name = value;
            }
        }
        /// <summary>
        /// 外键表查询SQL
        /// </summary>
        public string FOREIGNER_FILTER_SQL
        {
            get
            {
                return foreigner_filter_sql;
            }
            set
            {
                foreigner_filter_sql = value.Trim();
            }
        }
        /// <summary>
        /// 界面显示控件
        /// </summary>
        public ControlType UIC_TYPE
        {
            get
            {
                return uic_type;
            }
            set
            {
                uic_type = value;
            }
        }
        /// <summary>
        /// 控件位置
        /// </summary>
        public int LOCATION_X
        {
            get
            {
                return location_x;
            }
            set
            {
                location_x = value;
            }
        }
        /// <summary>
        /// 控件位置
        /// </summary>
        public int LOCATION_Y
        {
            get
            {
                return location_y;
            }
            set
            {
                location_y = value;
            }
        }
        /// <summary>
        /// 控件宽度
        /// </summary>
        public int WIDTH
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        /// <summary>
        /// 控件高度
        /// </summary>
        public int HEIGHT
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        /// <summary>
        /// 网格列宽度
        /// </summary>
        public int GRID_COL_WIDTH
        {
            get
            {
                return grid_col_width;
            }
            set
            {
                grid_col_width = value;
            }
        }
        /// <summary>
        /// Tab键顺序
        /// </summary>
        public int TABINDEX
        {
            get
            {
                return tabindex;
            }
            set
            {
                tabindex = value;
            }
        }
        /// <summary>
        /// 是否允许在界面编辑
        /// </summary>
        public bool ALLOW_EDIT
        {
            get
            {
                return allow_edit;
            }
            set
            {
                allow_edit = value;
            }
        }
        /// <summary>
        /// 字段标记类型,标记是否代表名称，拼音，五笔字段
        /// </summary>
        public HIS.Base_BLL.Enums.FIELD_MARK_TYPE FIELD_MARK_TYPE
        {
            get
            {
                return field_mark_type;
            }
            set
            {
                field_mark_type = value;
            }
        }
    }
}
