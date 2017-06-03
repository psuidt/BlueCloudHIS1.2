using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 基础数据记录对象，代表了一条基础数据记录，值和字段信息包含在属性列表中
    /// </summary>
    public class BaseDataRecord 
    {
        public BaseDataRecord()
        {
            recordFields = new List<BaseDataRecordField>();
        }
        private List<BaseDataRecordField> recordFields;
        /// <summary>
        /// 记录字段
        /// </summary>
        public List<BaseDataRecordField> RecordFields
        {
            get
            {
                return recordFields;
            }
            set
            {
                recordFields = value;
            }
        }
    }
}
