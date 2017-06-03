using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类MZ_REPORT_LIST 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MZ_REPORT_LIST
	{
		public MZ_REPORT_LIST()
		{}
		#region Model
		private string _report_name;
		private string _creator;
		private DateTime? _crratordate;
		private string _lastchageuser;
		private DateTime? _lastchagedate;
		/// <summary>
		/// 
		/// </summary>
		public string REPORT_NAME
		{
			set{ _report_name=value;}
			get{return _report_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CREATOR
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CRRATORDATE
		{
			set{ _crratordate=value;}
			get{return _crratordate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LASTCHAGEUSER
		{
			set{ _lastchageuser=value;}
			get{return _lastchageuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LASTCHAGEDATE
		{
			set{ _lastchagedate=value;}
			get{return _lastchagedate;}
		}
		#endregion Model

	}
}

