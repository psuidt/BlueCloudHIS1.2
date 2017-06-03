using System;
namespace HIS.Model
{
    public class Base_Usage_UseType_Role
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
		private string _type_name;
		/// <summary>
		///
		/// </summary>
		public string Type_Name
		{
			get{return _type_name;}
			set{_type_name = value ;}

		}
		private int _usage_id;
		/// <summary>
		///
		/// </summary>
		public int Usage_Id
		{
			get{return _usage_id;}
			set{_usage_id = value ;}

		}
	}
}
