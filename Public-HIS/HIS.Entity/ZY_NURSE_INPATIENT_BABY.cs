using System;
namespace HIS.Model
{
	public class ZY_NURSE_INPATIENT_BABY
	{
		private int _baby_id;
		/// <summary>
		///
		/// </summary>
		public int BABY_ID
		{
			get{return _baby_id;}
			set{_baby_id = value ;}

		}
		private int _inpatient_id;
		/// <summary>
		///
		/// </summary>
		public int INPATIENT_ID
		{
			get{return _inpatient_id;}
			set{_inpatient_id = value ;}

		}
		private string _inpatient_no;
		/// <summary>
		///
		/// </summary>
		public string INPATIENT_NO
		{
			get{return _inpatient_no;}
			set{_inpatient_no = value ;}

		}
		private int _baby_no;
		/// <summary>
		///
		/// </summary>
		public int BABY_NO
		{
			get{return _baby_no;}
			set{_baby_no = value ;}

		}
		private string _baby_name;
		/// <summary>
		///
		/// </summary>
		public string BABY_NAME
		{
			get{return _baby_name;}
			set{_baby_name = value ;}

		}
		private DateTime _birthday;
		/// <summary>
		///
		/// </summary>
		public DateTime BIRTHDAY
		{
			get{return _birthday;}
			set{_birthday = value ;}

		}
		private int _sex;
		/// <summary>
		///
		/// </summary>
		public int SEX
		{
			get{return _sex;}
			set{_sex = value ;}

		}
	}
}
