using System;
namespace HIS.Model
{
	public class BASE_ORDER_TYPE
	{
		private int _id;
		/// <summary>
		///
		/// </summary>
		public int ID
		{
			get{return _id;}
			set{_id = value ;}

		}
		private string _name;
		/// <summary>
		///
		/// </summary>
		public string NAME
		{
			get{return _name;}
			set{_name = value ;}

		}
		private string _code;
		/// <summary>
		///
		/// </summary>
		public string CODE
		{
			get{return _code;}
			set{_code = value ;}

		}
		private string _py_code;
		/// <summary>
		///
		/// </summary>
		public string PY_CODE
		{
			get{return _py_code;}
			set{_py_code = value ;}

		}
		private string _wb_code;
		/// <summary>
		///
		/// </summary>
		public string WB_CODE
		{
			get{return _wb_code;}
			set{_wb_code = value ;}

		}
		private string _comments;
		/// <summary>
		///
		/// </summary>
		public string COMMENTS
		{
			get{return _comments;}
			set{_comments = value ;}

		}
		
	}
}
