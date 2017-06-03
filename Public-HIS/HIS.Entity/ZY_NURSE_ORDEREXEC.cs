using System;
namespace HIS.Model
{
	public class ZY_NURSE_ORDEREXEC
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
		private int _order_id;
		/// <summary>
		///
		/// </summary>
		public int ORDER_ID
		{
			get{return _order_id;}
			set{_order_id = value ;}

		}
		private DateTime _exec_date;
		/// <summary>
		///
		/// </summary>
		public DateTime EXEC_DATE
		{
			get{return _exec_date;}
			set{_exec_date = value ;}

		}
		private int _exec_user;
		/// <summary>
		///
		/// </summary>
		public int EXEC_USER
		{
			get{return _exec_user;}
			set{_exec_user = value ;}

		}
		private int _patient_id;
		/// <summary>
		///
		/// </summary>
		public int PATIENT_ID
		{
			get{return _patient_id;}
			set{_patient_id = value ;}

		}
		private int _baby_id;
		/// <summary>
		///
		/// </summary>
		public int BABY_ID
		{
			get{return _baby_id;}
			set{_baby_id = value ;}

		}
		private int _realexec_user;
		/// <summary>
		///
		/// </summary>
		public int REALEXEC_USER
		{
			get{return _realexec_user;}
			set{_realexec_user = value ;}

		}
		private DateTime _realexec_time;
		/// <summary>
		///
		/// </summary>
		public DateTime REALEXEC_TIME
		{
			get{return _realexec_time;}
			set{_realexec_time = value ;}

		}
	}
}
