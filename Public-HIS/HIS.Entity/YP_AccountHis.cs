using System;
namespace HIS .Model
{
    /// <summary>
    /// 药库结账历史记录
    /// </summary>
    public class YP_AccountHis
    {
        public YP_AccountHis()
        {
        }
        #region Model
        private int _accounthistoryid;
        private int _accountyear;
        private int _accountmonth;
        private DateTime _begintime;
        private DateTime _endtime;
        private int _regman;
        private DateTime _regtime;
        private int _deptid;
        /// <summary>
        /// 结账记录标识ID
        /// </summary>
        public int AccountHistoryID
        {
            set
            {
                _accounthistoryid = value;
            }
            get
            {
                return _accounthistoryid;
            }
        }
        /// <summary>
        /// 会计年份
        /// </summary>
        public int AccountYear
        {
            set
            {
                _accountyear = value;
            }
            get
            {
                return _accountyear;
            }
        }
        /// <summary>
        /// 会计月份
        /// </summary>
        public int AccountMonth
        {
            set
            {
                _accountmonth = value;
            }
            get
            {
                return _accountmonth;
            }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime
        {
            set
            {
                _begintime = value;
            }
            get
            {
                return _begintime;
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            set
            {
                _endtime = value;
            }
            get
            {
                return _endtime;
            }
        }
        /// <summary>
        /// 结账人员
        /// </summary>
        public int RegMan
        {
            set
            {
                _regman = value;
            }
            get
            {
                return _regman;
            }
        }
        /// <summary>
        /// 结账时间
        /// </summary>
        public DateTime RegTime
        {
            set
            {
                _regtime = value;
            }
            get
            {
                return _regtime;
            }
        }
        /// <summary>
        /// 登记部门
        /// </summary>
        public int DeptID
        {
            set
            {
                _deptid = value;
            }
            get
            {
                return _deptid;
            }
        }
        #endregion Model

    }
}

