using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    /// <summary>
    /// 收费继承类
    /// </summary>
    public class ZY_ChargeList_Son:HIS.Model.ZY_ChargeList
    {
        public ZY_ChargeList_Son()
        {
            
        }

        private string _ChargeType;
        private string _ChargeUserName;
        private string _AccountUserName;
        private DateTime _AccountDate;
        private string _DelType;
        private string _PatName;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName
        {
            get { return _PatName; }
            set { _PatName = value; }
        }
        /// <summary>
        /// 收费类型名称
        /// </summary>
        public string ChargeType
        {
            get { return _ChargeType; }
            set { _ChargeType = value; }
        }
        /// <summary>
        /// 收费人名称
        /// </summary>
        public string ChargeUserName
        {
            get { return _ChargeUserName; }
            set { _ChargeUserName = value; }
        }
        /// <summary>
        /// 交款人名称
        /// </summary>
        public string AccountUserName
        {
            get { return _AccountUserName; }
            set { _AccountUserName = value; }
        }
        /// <summary>
        /// 交款时间
        /// </summary>
        public DateTime AccountDate
        {
            set { _AccountDate = value; }
            get { return _AccountDate; }
        }
        /// <summary>
        /// 记录状态名称
        /// </summary>
        public string DelType
        {
            set { _DelType = value; }
            get { return _DelType; }
        }
    }
}
