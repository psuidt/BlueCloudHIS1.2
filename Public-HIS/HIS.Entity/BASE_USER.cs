using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类BASE_USER 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class BASE_USER
	{
		public BASE_USER()
		{}
		#region Model
		private int _user_id;
		private int _employee_id;
		private string _code;
		private string _password;
		private int _group_id;
		private int _yb_operator;
		private int _jz_operator;
		private int _jk_operator;
		private int _chg_pwd_nextime;
		private int _deny_chg_pwd;
		private int _pwd_never_expire;
		private DateTime _chg_pwd_lastime;
		private DateTime _pwd_expire_time;
		private int _lock;
		private int _curfpno;
		private int _cursjno;
		private int _curtkdno;
		private int _curyjno;
		private string _memo;
		/// <summary>
		/// 
		/// </summary>
		public int USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int EMPLOYEE_ID
		{
			set{ _employee_id=value;}
			get{return _employee_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CODE
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PASSWORD
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GROUP_ID
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int YB_OPERATOR
		{
			set{ _yb_operator=value;}
			get{return _yb_operator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int JZ_OPERATOR
		{
			set{ _jz_operator=value;}
			get{return _jz_operator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int JK_OPERATOR
		{
			set{ _jk_operator=value;}
			get{return _jk_operator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CHG_PWD_NEXTIME
		{
			set{ _chg_pwd_nextime=value;}
			get{return _chg_pwd_nextime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DENY_CHG_PWD
		{
			set{ _deny_chg_pwd=value;}
			get{return _deny_chg_pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PWD_NEVER_EXPIRE
		{
			set{ _pwd_never_expire=value;}
			get{return _pwd_never_expire;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CHG_PWD_LASTIME
		{
			set{ _chg_pwd_lastime=value;}
			get{return _chg_pwd_lastime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime PWD_EXPIRE_TIME
		{
			set{ _pwd_expire_time=value;}
			get{return _pwd_expire_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LOCK
		{
			set{ _lock=value;}
			get{return _lock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CURFPNO
		{
			set{ _curfpno=value;}
			get{return _curfpno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CURSJNO
		{
			set{ _cursjno=value;}
			get{return _cursjno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CURTKDNO
		{
			set{ _curtkdno=value;}
			get{return _curtkdno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CURYJNO
		{
			set{ _curyjno=value;}
			get{return _curyjno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MEMO
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		#endregion Model

	}
}

