using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 医嘱项目对象
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// 医嘱ID
        /// </summary>
        public int ORDER_ID;
        /// <summary>
        /// 医嘱名称
        /// </summary>
        public string ORDER_NAME;
        /// <summary>
        /// 医嘱单位
        /// </summary>
        public string ORDER_UNIT;
        /// <summary>
        /// 医嘱类型
        /// </summary>
        public int ORDER_TYPE;
        /// <summary>
        /// 分类
        /// </summary>
        public int MEDICAL_CLASS;
        /// <summary>
        /// 默认用法
        /// </summary>
        public string DEFAULT_USAGE ;
        /// <summary>
        /// 拼音
        /// </summary>
        public string PY_CODE;
        /// <summary>
        /// 五笔
        /// </summary>
        public string WB_CODE;
        /// <summary>
        /// 数字吗
        /// </summary>
        public string D_CODE;
        /// <summary>
        /// 对应的项目ID
        /// </summary>
        public int ITEM_ID;
        /// <summary>
        /// 套餐标志
        /// </summary>
        public int TC_FLAG;
        /// <summary>
        /// 删除标志
        /// </summary>
        public int DELETE_BIT;
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime BOOK_DATE;
        /// <summary>
        /// 删除日期
        /// </summary>
        public DateTime DEL_DATE;
        /// <summary>
        /// 备注
        /// </summary>
        public string BZ;
    }
}
