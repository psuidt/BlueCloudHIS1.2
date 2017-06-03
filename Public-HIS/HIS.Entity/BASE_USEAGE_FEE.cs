using System;
namespace HIS.Model
{
	public class BASE_USEAGE_FEE
	{
		private decimal _id;
		/// <summary>
		///
		/// </summary>
		public decimal ID
		{
			get{return _id;}
			set{_id = value ;}

		}
		private string _use_name;
		/// <summary>
		///
		/// </summary>
		public string USE_NAME
		{
			get{return _use_name;}
			set{_use_name = value ;}

		}
		private int _num;
		/// <summary>
		///
		/// </summary>
		public int NUM
		{
			get{return _num;}
			set{_num = value ;}

		}
		private decimal _hsitem_id;
		/// <summary>
		///
		/// </summary>
		public decimal HSITEM_ID
		{
			get{return _hsitem_id;}
			set{_hsitem_id = value ;}

		}
	}
}
