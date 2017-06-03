using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 基础数据记录的字段
    /// </summary>
    public class BaseDataRecordField
    {
        public BaseDataRecordField()
        {
            fieldConfig = new FieldConfig();
            dataValue = null;
        }
        private object dataValue;
        private FieldConfig fieldConfig;
        /// <summary>
        /// 字段配置信息
        /// </summary>
        public FieldConfig FieldConfig
        {
            get
            {
                return fieldConfig;
            }
            set
            {
                fieldConfig = value;
            }
        }
        /// <summary>
        /// 值
        /// </summary>
        public object DataValue
        {
            get
            {
                return dataValue;
            }
            set
            {
                dataValue = value;
            }
        }
    }
}
