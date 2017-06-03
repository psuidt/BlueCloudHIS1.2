using System;
namespace HIS.Model
{
	public class BASE_WORK_UNIT
	{
		private string _code;
		/// <summary>
		///
		/// </summary>
		public string CODE
		{
			get{return _code;}
			set{_code = value ;}

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
		private int _work_id;
		/// <summary>
		///
		/// </summary>
		public int WORK_ID
		{
			get{return _work_id;}
			set{_work_id = value ;}

		}
	}
}
