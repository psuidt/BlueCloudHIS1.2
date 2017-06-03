using System;
namespace HIS.Model
{
	public class ZY_INVOICE
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
		private int _invoice_type;
		/// <summary>
		///
		/// </summary>
		public int INVOICE_TYPE
		{
			get{return _invoice_type;}
			set{_invoice_type = value ;}

		}
		private int _employee_id;
		/// <summary>
		///
		/// </summary>
		public int EMPLOYEE_ID
		{
			get{return _employee_id;}
			set{_employee_id = value ;}

		}
		private int _start_no;
		/// <summary>
		///
		/// </summary>
		public int START_NO
		{
			get{return _start_no;}
			set{_start_no = value ;}

		}
		private int _end_no;
		/// <summary>
		///
		/// </summary>
		public int END_NO
		{
			get{return _end_no;}
			set{_end_no = value ;}

		}
		private string _perfchar;
		/// <summary>
		///
		/// </summary>
		public string PERFCHAR
		{
			get{return _perfchar;}
			set{_perfchar = value ;}

		}
		private int _current_no;
		/// <summary>
		///
		/// </summary>
		public int CURRENT_NO
		{
			get{return _current_no;}
			set{_current_no = value ;}

		}
		private int _status;
		/// <summary>
		///
		/// </summary>
		public int STATUS
		{
			get{return _status;}
			set{_status = value ;}

		}
		private DateTime _allot_date;
		/// <summary>
		///
		/// </summary>
		public DateTime ALLOT_DATE
		{
			get{return _allot_date;}
			set{_allot_date = value ;}

		}
		private int _allot_user;
		/// <summary>
		///
		/// </summary>
		public int ALLOT_USER
		{
			get{return _allot_user;}
			set{_allot_user = value ;}

		}
	}
}
