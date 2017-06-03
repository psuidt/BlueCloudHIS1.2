using System;
namespace HIS.Model
{
	public class MZ_REG_TYPE
	{
		private string _type_code;
		/// <summary>
		///
		/// </summary>
		public string TYPE_CODE
		{
			get{return _type_code;}
			set{_type_code = value ;}

		}
		private string _type_name;
		/// <summary>
		///
		/// </summary>
		public string TYPE_NAME
		{
			get{return _type_name;}
			set{_type_name = value ;}

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
		private int _valid_flag;
		/// <summary>
		///
		/// </summary>
		public int VALID_FLAG
		{
			get{return _valid_flag;}
			set{_valid_flag = value ;}

		}
		private int _workid;
		/// <summary>
		///
		/// </summary>
		public int WORKID
		{
			get{return _workid;}
			set{_workid = value ;}

		}
	}
}
