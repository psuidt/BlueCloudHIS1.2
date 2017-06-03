using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 划价模板明细项目
    /// </summary>
    public class TemplateDetailItem
    {
        private int _template_id;
        /// <summary>
        /// 模板ID
        /// </summary>
        public int TEMPLATE_ID
        {
            get
            {
                return _template_id;
            }
            set
            {
                _template_id = value;
            }

        }
        private int _item_id;
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ITEM_ID
        {
            get
            {
                return _item_id;
            }
            set
            {
                _item_id = value;
            }

        }
        private int _complex_id;
        /// <summary>
        /// 组合项目ID
        /// </summary>
        public int COMPLEX_ID
        {
            get
            {
                return _complex_id;
            }
            set
            {
                _complex_id = value;
            }

        }
        private string _item_name;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ITEM_NAME
        {
            get
            {
                return _item_name;
            }
            set
            {
                _item_name = value;
            }

        }
        private string _standard;
        /// <summary>
        /// 规格
        /// </summary>
        public string STANDARD
        {
            get
            {
                return _standard;
            }
            set
            {
                _standard = value;
            }

        }
        private string _unit;
        /// <summary>
        /// 单位
        /// </summary>
        public string UNIT
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
            }

        }
        private string _bigitemcode;
        /// <summary>
        /// 基本统计分类
        /// </summary>
        public string BIGITEMCODE
        {
            get
            {
                return _bigitemcode;
            }
            set
            {
                _bigitemcode = value;
            }

        }
        private decimal _dosage;
        /// <summary>
        /// 剂数
        /// </summary>
        public decimal DOSAGE
        {
            get
            {
                return _dosage;
            }
            set
            {
                _dosage = value;
            }

        }
        private int _frequen_id;
        /// <summary>
        /// 频次ID
        /// </summary>
        public int FREQUEN_ID
        {
            get
            {
                return _frequen_id;
            }
            set
            {
                _frequen_id = value;
            }

        }
        private string _frequen_name;
        /// <summary>
        /// 频次名称
        /// </summary>
        public string FREQUEN_NAME
        {
            get
            {
                return _frequen_name;
            }
            set
            {
                _frequen_name = value;
            }

        }
        private decimal _days;
        /// <summary>
        /// 天数
        /// </summary>
        public decimal DAYS
        {
            get
            {
                return _days;
            }
            set
            {
                _days = value;
            }

        }
        private string _usage_name;
        /// <summary>
        /// 用法
        /// </summary>
        public string USAGE_NAME
        {
            get
            {
                return _usage_name;
            }
            set
            {
                _usage_name = value;
            }

        }
        private int _group_flag;
        /// <summary>
        /// 分组标志
        /// </summary>
        public int GROUP_FLAG
        {
            get
            {
                return _group_flag;
            }
            set
            {
                _group_flag = value;
            }

        }
        private int _sort_no;
        /// <summary>
        /// 排序号
        /// </summary>
        public int SORT_NO
        {
            get
            {
                return _sort_no;
            }
            set
            {
                _sort_no = value;
            }

        }

        private int amount;
        /// <summary>
        /// 数量
        /// </summary>
        public int AMOUNT
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
    }
}
