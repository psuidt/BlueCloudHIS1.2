using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS;
using HIS.BLL;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 医技申请项目类
    /// </summary>
    public class Medical_Order_Item : Model.Base_Order_Items
    {
        private string _statitem_code;       // 大项目代码
        private int _dept_id;                // 执行科室ID
        private string _dept_name;           // 执行科室名称
        private decimal _price;              // 项目价格

        /// <summary>
        /// 大项目代码
        /// </summary>
        public string StatItem_Code
        {
            get { return _statitem_code; }
            set { _statitem_code = value; }
        }
        /// <summary>
        /// 执行科室ID
        /// </summary>
        public int Dept_Id
        {
            get { return _dept_id; }
            set { _dept_id = value; }
        }
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string Dept_Name
        {
            get { return _dept_name; }
            set { _dept_name = value; }
        }
        /// <summary>
        /// 项目价格
        /// </summary>
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        } 
        /// <summary>
        /// 文本
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Order_Name + ((this.Bz == null ? "" : this.Bz).Trim() == "" ? "" : "【" + this.Bz.Trim() + "】");
        }
    }
}
