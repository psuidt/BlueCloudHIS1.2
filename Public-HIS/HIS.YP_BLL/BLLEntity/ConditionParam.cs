using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 查询条件参数分类
    /// </summary>
    public enum QueryConditionType
    {
        开始时间,
        结束时间,
        部门ID,
        是否审核,
        发票号,
        供应商ID,
        单据号,
        盘审单号,
        业务类型,
        调价单号
    }

    /// <summary>
    /// 查询条件参数
    /// </summary>
    public class ConditionParam
    {
        public ConditionParam(QueryConditionType type, object value, bool isUse)
        {
            _conditionType = type;
            _value = value;
            _isUse = isUse;
        }
        private QueryConditionType _conditionType;
        private object _value;
        private bool _isUse;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsUse
        {
            get { return _isUse; }
            set { _isUse = value; }
        }

        /// <summary>
        /// 参数所属类型
        /// </summary>
        public QueryConditionType ConditionType
        {
            get { return _conditionType; }
            set { _conditionType = value; }
        }

        /// <summary>
        /// 参数值
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
