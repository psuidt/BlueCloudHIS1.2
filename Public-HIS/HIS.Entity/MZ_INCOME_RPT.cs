using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类MZ_INCOME_RPT 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MZ_INCOME_RPT
	{
		public MZ_INCOME_RPT()
		{}
		#region Model
		private int _rptid;
		private int _stat_type;
		private int _stat_year;
		private int _stat_month;
		private DateTime _begin_date;
		private DateTime _end_date;
		private string _operator;
		private DateTime _create_date;
		private DateTime _last_change_date;
        private int _report_type;
        private string _creator;
        private int _stat_date_type;
		/// <summary>
		/// 
		/// </summary>
		public int RPTID
		{
			set{ _rptid=value;}
			get{return _rptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int STAT_TYPE
		{
			set{ _stat_type=value;}
			get{return _stat_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int STAT_YEAR
		{
			set{ _stat_year=value;}
			get{return _stat_year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int STAT_MONTH
		{
			set{ _stat_month=value;}
			get{return _stat_month;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime BEGIN_DATE
		{
			set{ _begin_date=value;}
			get{return _begin_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime END_DATE
		{
			set{ _end_date=value;}
			get{return _end_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OPERATOR
		{
			set{ _operator=value;}
			get{return _operator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CREATE_DATE
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LAST_CHANGE_DATE
		{
			set{ _last_change_date=value;}
			get{return _last_change_date;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int REPORT_TYPE
        {
            set
            {
                _report_type = value;
            }
            get
            {
                return _report_type;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CREATOR
        {
            set
            {
                _creator = value;
            }
            get
            {
                return _creator;
            }
        }
        public int STAT_DATE_TYPE
        {
            get
            {
                return _stat_date_type;
            }
            set
            {
                _stat_date_type = value;
            }
        }
		#endregion Model

	}
}

