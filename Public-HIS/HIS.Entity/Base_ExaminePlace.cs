using System;
namespace HIS.Model
{
	public class Base_ExaminePlace
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
		private int _medical_class;
		/// <summary>
		///
		/// </summary>
		public int Medical_Class
		{
			get{return _medical_class;}
			set{_medical_class = value ;}

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
	}
}
