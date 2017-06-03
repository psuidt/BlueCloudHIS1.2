using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 划价模板对象
    /// </summary>
    public class TemplateItem
    {
        private int tmplate_id;
        private string tmplate_name;
        private int tmplate_type;
        private string py_code;
        private string wb_code;
        private int exec_dept_id;
        private string exec_dept_name;
        private int creator_id;
        private string creator_name;
        private int dept_id;
        private string dept_name;
        private int share_level;
        private DateTime create_date;
        private int valid_flag;
        private List<TemplateDetailItem> details;
        /// <summary>
        /// 模板ID
        /// </summary>
        public int Tmplate_Id
        {
            get
            {
                return tmplate_id;
            }
            set
            {
                tmplate_id = value;
            }
        }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string Tmplate_Name
        {
            get
            {
                return tmplate_name;
            }
            set
            {
                tmplate_name = value;
            }
        }
        /// <summary>
        /// 模板类型(0-药品 1-项目)
        /// </summary>
        public int Tmplate_Type
        {
            get
            {
                return tmplate_type;
            }
            set
            {
                tmplate_type = value;
            }
        }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string Py_Code
        {
            get
            {
                return py_code;
            }
            set
            {
                py_code = value;
            }
        }
        /// <summary>
        /// 五笔码
        /// </summary>
        public string Wb_Code
        {
            get
            {
                return wb_code;
            }
            set
            {
                wb_code = value;
            }
        }
        /// <summary>
        /// 执行科室ID
        /// </summary>
        public int Exec_Dept_Id
        {
            get
            {
                return exec_dept_id;
            }
            set
            {
                exec_dept_id = value;
            }
        }
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string Exce_Dept_Name
        {
            get
            {
                return exec_dept_name;
            }
            set
            {
                exec_dept_name = value;
            }
        }
        /// <summary>
        /// 创建人ID
        /// </summary>
        public int Creator_Id
        {
            get
            {
                return creator_id;
            }
            set
            {
                creator_id = value;
            }
        }
        /// <summary>
        /// 创建人名称
        /// </summary>
        public string Creator_Name
        {
            get
            {
                return creator_name;
            }
            set
            {
                creator_name = value;
            }
        }
        /// <summary>
        /// 科室ID
        /// </summary>
        public int Dept_Id
        {
            get
            {
                return dept_id;
            }
            set
            {
                dept_id = value;
            }
        }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string Dept_Name
        {
            get
            {
                return dept_name;
            }
            set
            {
                dept_name = value;
            }
        }
        /// <summary>
        /// 共享级别
        /// </summary>
        public int Share_Level
        {
            get
            {
                return share_level;
            }
            set
            {
                share_level = value;
            }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime Create_Date
        {
            get
            {
                return create_date;
            }
            set
            {
                create_date = value;
            }
        }
        /// <summary>
        /// 有效标志
        /// </summary>
        public int Valid_Flag
        {
            get
            {
                return valid_flag;
            }
            set
            {
                valid_flag = value;
            }
        }
        /// <summary>
        /// 明细集合
        /// </summary>
        public List<TemplateDetailItem> Details
        {
            get
            {
                return details;
            }
            set
            {
                details = value;
            }
        }
    }
}
