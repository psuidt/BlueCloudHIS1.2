using System;
namespace HIS.Model
{
	public class Base_Param
	{
		private int _id;
		/// <summary>
		///
		/// </summary>
		public int Id
		{
			get{return _id;}
			set{_id = value ;}

		}
		private string _name;
		/// <summary>
		///
		/// </summary>
		public string Name
		{
			get{return _name;}
			set{_name = value ;}

		}
		private string _py_code;
		/// <summary>
		///
		/// </summary>
		public string Py_Code
		{
			get{return _py_code;}
			set{_py_code = value ;}

		}
		private string _wb_code;
		/// <summary>
		///
		/// </summary>
		public string Wb_Code
		{
			get{return _wb_code;}
			set{_wb_code = value ;}

		}
		private string _d_code;
		/// <summary>
		///
		/// </summary>
		public string D_Code
		{
			get{return _d_code;}
			set{_d_code = value ;}

		}
		private int _delete_bit;
		/// <summary>
		///
		/// </summary>
		public int Delete_Bit
		{
			get{return _delete_bit;}
			set{_delete_bit = value ;}

		}
	}
}
