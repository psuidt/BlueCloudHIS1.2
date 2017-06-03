using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 关联对象
    /// </summary>
    public class LinkageItem
    {
        private int item_id;
        private string item_name;
        private string item_unit;
        private int num;
        private decimal price;
        /// <summary>
        /// ID
        /// </summary>
        public int ITEM_ID
        {
            get
            {
                return item_id;
            }
            set
            {
                item_id = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string ITEM_NAME
        {
            get
            {
                return item_name;
            }
            set
            {
                item_name = value;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string ITEM_UNIT
        {
            get
            {
                return item_unit;
            }
            set
            {
                item_unit = value;
            }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal PRICE
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
    }
}
