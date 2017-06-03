using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 组合项目对象
    /// </summary>
    public class ComplexItem : ServiceItem
    {
        public ComplexItem() : base( )
        {
        }

        private List<ComplexDetailItem> details;
        /// <summary>
        /// 组合项目明细
        /// </summary>
        public List<ComplexDetailItem> Details
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
