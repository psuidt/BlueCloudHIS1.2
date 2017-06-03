using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL.收费项目及医嘱维护
{
    /// <summary>
    /// 基本项目对象
    /// </summary>
    public class BaseItem
    {
        private int itemId;
        private int complexId;
        private string itemName;
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
            }
        }
        /// <summary>
        /// 组合项目ID
        /// </summary>
        public int ComplexId
        {
            get
            {
                return complexId;
            }
            set
            {
                complexId = value;
            }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName
        {
            get
            {
                return itemName;
            }
            set
            {
                itemName = value;
            }
        }
        
    }
}
