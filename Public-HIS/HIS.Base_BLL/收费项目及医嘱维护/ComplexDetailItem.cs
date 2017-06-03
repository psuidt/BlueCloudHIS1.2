using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 组合项目的明细项目对象
    /// </summary>
    public class ComplexDetailItem : ServiceItem
    {
        public ComplexDetailItem() : base( )
        {
        }

        private int num;
        private int complexId;

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
    }
}
