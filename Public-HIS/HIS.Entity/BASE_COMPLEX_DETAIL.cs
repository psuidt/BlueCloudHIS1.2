using System;
namespace HIS.Model
{
	public class BASE_COMPLEX_DETAIL
	{
		private int _complex_id;
		/// <summary>
		///
		/// </summary>
		public int COMPLEX_ID
		{
			get{return _complex_id;}
			set{_complex_id = value ;}

		}
		private int _service_item_id;
		/// <summary>
		///
		/// </summary>
		public int SERVICE_ITEM_ID
		{
			get{return _service_item_id;}
			set{_service_item_id = value ;}

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
