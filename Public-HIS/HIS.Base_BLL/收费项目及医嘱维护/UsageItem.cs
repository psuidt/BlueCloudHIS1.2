using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 用法项目
    /// </summary>
    public class UsageItem
    {
        private int id;
        private string name;
        private string py_Code;
        private string wb_Code;
        private string unit;
        private bool printLongOrder;
        private bool printTempOrder;
        private bool deleteBit;
        private List<LinkageItem> associatedItems;

        public UsageItem()
        {
            associatedItems = new List<LinkageItem>( );
        }
        /// <summary>
        /// 用法ID
        /// </summary>
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        /// <summary>
        /// 名称
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
        public string Py_Code
        {
            get
            {
                return py_Code;
            }
            set
            {
                py_Code = value;
            }
        }
        /// <summary>
        /// 五笔
        /// </summary>
        public string Wb_Code
        {
            get
            {
                return wb_Code;
            }
            set
            {
                wb_Code = value;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
            }
        }
        /// <summary>
        /// 是否打印长嘱
        /// </summary>
        public bool PrintLongOrder
        {
            get
            {
                return printLongOrder;
            }
            set
            {
                printLongOrder = value;
            }
        }
        /// <summary>
        /// 是否打印临嘱
        /// </summary>
        public bool PrintTempOrder
        {
            get
            {
                return printTempOrder;
            }
            set
            {
                printTempOrder = value;
            }
        }
        /// <summary>
        /// 删除标志
        /// </summary>
        public bool DeleteBit
        {
            get
            {
                return deleteBit;
            }
            set
            {
                deleteBit = value;
            }
        }
        /// <summary>
        /// 联动项目
        /// </summary>
        public List<LinkageItem> AssociatedItems
        {
            get
            {
                return associatedItems;
            }
            set
            {
                associatedItems = value;
            }
        }
    }
}
