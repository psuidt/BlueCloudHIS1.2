using System;
namespace HIS.Model
{
	public class MZ_PATIENT
	{
		private decimal _patid;
		/// <summary>
		///
		/// </summary>
		public decimal PATID
		{
			get{return _patid;}
			set{_patid = value ;}

		}
		private string _cardno;
		/// <summary>
		///
		/// </summary>
		public string CARDNO
		{
			get{return _cardno;}
			set{_cardno = value ;}

		}
		private string _patname;
		/// <summary>
		///
		/// </summary>
		public string PATNAME
		{
			get{return _patname;}
			set{_patname = value ;}

		}
		private string _sex;
		/// <summary>
		///
		/// </summary>
		public string SEX
		{
			get{return _sex;}
			set{_sex = value ;}

		}
		private int _type;
		/// <summary>
		///
		/// </summary>
		public int TYPE
		{
			get{return _type;}
			set{_type = value ;}

		}
		private string _type_name;
		/// <summary>
		///
		/// </summary>
		public string TYPE_NAME
		{
			get{return _type_name;}
			set{_type_name = value ;}

		}
		private string _idcard;
		/// <summary>
		///
		/// </summary>
		public string IDCARD
		{
			get{return _idcard;}
			set{_idcard = value ;}

		}
		private DateTime _bornday;
		/// <summary>
		///
		/// </summary>
		public DateTime BORNDAY
		{
			get{return _bornday;}
			set{_bornday = value ;}

		}
		private string _folk;
		/// <summary>
		///
		/// </summary>
		public string FOLK
		{
			get{return _folk;}
			set{_folk = value ;}

		}
		private string _tel;
		/// <summary>
		///
		/// </summary>
		public string TEL
		{
			get{return _tel;}
			set{_tel = value ;}

		}
		private string _occupation;
		/// <summary>
		///
		/// </summary>
		public string OCCUPATION
		{
			get{return _occupation;}
			set{_occupation = value ;}

		}
		private string _address;
		/// <summary>
		///
		/// </summary>
		public string ADDRESS
		{
			get{return _address;}
			set{_address = value ;}

		}
	}
}
