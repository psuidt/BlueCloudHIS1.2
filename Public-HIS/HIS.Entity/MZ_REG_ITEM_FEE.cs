using System;
namespace HIS.Model
{
	public class MZ_REG_ITEM_FEE
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
		private int _item_id;
		/// <summary>
		///
		/// </summary>
		public int ITEM_ID
		{
			get{return _item_id;}
			set{_item_id = value ;}

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
		private int _append;
		/// <summary>
		///
		/// </summary>
		public int APPEND
		{
			get{return _append;}
			set{_append = value ;}

		}
	}
}
