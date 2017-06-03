using System;
namespace HIS.Model
{
	public class ZY_DOC_DIAGNOSIS
	{
		private decimal _diagnosis_id;
		/// <summary>
		///
		/// </summary>
		public decimal DIAGNOSIS_ID
		{
			get{return _diagnosis_id;}
			set{_diagnosis_id = value ;}

		}
		private int _patid;
		/// <summary>
		///
		/// </summary>
		public int PATID
		{
			get{return _patid;}
			set{_patid = value ;}

		}
		private string _diag_name;
		/// <summary>
		///
		/// </summary>
		public string DIAG_NAME
		{
			get{return _diag_name;}
			set{_diag_name = value ;}

		}
		private int _diag_doc;
		/// <summary>
		///
		/// </summary>
		public int DIAG_DOC
		{
			get{return _diag_doc;}
			set{_diag_doc = value ;}

		}
		private DateTime _diag_date;
		/// <summary>
		///
		/// </summary>
		public DateTime DIAG_DATE
		{
			get{return _diag_date;}
			set{_diag_date = value ;}

		}
		private int _delete_flag;
		/// <summary>
		///
		/// </summary>
		public int DELETE_FLAG
		{
			get{return _delete_flag;}
			set{_delete_flag = value ;}

		}
		private int _delete_doc;
		/// <summary>
		///
		/// </summary>
		public int DELETE_DOC
		{
			get{return _delete_doc;}
			set{_delete_doc = value ;}

		}
		private DateTime _delete_date;
		/// <summary>
		///
		/// </summary>
		public DateTime DELETE_DATE
		{
			get{return _delete_date;}
			set{_delete_date = value ;}

		}
		private int _diag_a1;
		/// <summary>
		///
		/// </summary>
		public int DIAG_A1
		{
			get{return _diag_a1;}
			set{_diag_a1 = value ;}

		}
		private int _diag_a2;
		/// <summary>
		///
		/// </summary>
		public int DIAG_A2
		{
			get{return _diag_a2;}
			set{_diag_a2 = value ;}

		}
		
	}
}
