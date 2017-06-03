using System;
namespace HIS.Model
{
	public class BASE_MODULE
	{
		private int _module_id;
		/// <summary>
		///
		/// </summary>
		public int MODULE_ID
		{
			get{return _module_id;}
			set{_module_id = value ;}

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
		private string _memo;
		/// <summary>
		///
		/// </summary>
		public string MEMO
		{
			get{return _memo;}
			set{_memo = value ;}

		}
		private int _sort_id;
		/// <summary>
		///
		/// </summary>
		public int SORT_ID
		{
			get{return _sort_id;}
			set{_sort_id = value ;}

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
