using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 工作单位
    /// </summary>
    public class WorkUnit
    {
        private string code;
        private string name;
        private string py_code;
        private string wb_code;
        /// <summary>
        /// 代码
        /// </summary>
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }
        /// <summary>
        ///  名称
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        /// <summary>
        /// 拼音
        /// </summary>
        public string PyCode
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
        /// 五笔
        /// </summary>
        public string WbCode
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
    }
}
