using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    public class RegTypeItem
    {
        private string typeCode;
        private string typeName;
        private string pyCode;
        private string wbCode;
        private int validFlag;
        private List<int> items;
        /// <summary>
        /// 类型代码
        /// </summary>
        public string TypeCode
        {
            get
            {
                return typeCode;
            }
            set
            {
                typeCode = value;
            }
        }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName
        {
            get
            {
                return typeName;
            }
            set
            {
                typeName = value;
            }
        }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string PyCode
        {
            get
            {
                return pyCode;
            }
            set
            {
                pyCode = value;
            }
        }
        /// <summary>
        /// 五笔码
        /// </summary>
        public string WbCode
        {
            get
            {
                return wbCode;
            }
            set
            {
                wbCode = value;
            }
        }
        /// <summary>
        /// 有效标志
        /// </summary>
        public int ValidFlag
        {
            get
            {
                return validFlag;
            }
            set
            {
                validFlag = value;
            }
        }
        /// <summary>
        /// 项目ID列表
        /// </summary>
        public List<int> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }

    }
}
