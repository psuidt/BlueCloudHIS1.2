using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类MZ_REPORT_TITLE_FIELD 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MZ_REPORT_TITLE_FIELD
	{
		public MZ_REPORT_TITLE_FIELD()
		{}
		#region Model
		private string _report_name;
		private string _title_name;
		private string _field_name;
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
		public string TITLE_NAME
		{
			set{ _title_name=value;}
			get{return _title_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FIELD_NAME
		{
			set{ _field_name=value;}
			get{return _field_name;}
		}
		#endregion Model

	}
}

