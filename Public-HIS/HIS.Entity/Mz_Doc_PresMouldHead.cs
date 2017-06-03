using System;
namespace HIS.Model
{
	public class Mz_Doc_PresMouldHead
	{
		private int _presmouldheadid;
		/// <summary>
		///
		/// </summary>
		public int PresMouldHeadId
		{
			get{return _presmouldheadid;}
			set{_presmouldheadid = value ;}

		}
		private int _p_id;
		/// <summary>
		///
		/// </summary>
		public int P_Id
		{
			get{return _p_id;}
			set{_p_id = value ;}

		}
		private string _mould_name;
		/// <summary>
		///
		/// </summary>
		public string Mould_Name
		{
			get{return _mould_name;}
			set{_mould_name = value ;}

		}
		private int _mould_type;
		/// <summary>
		///
		/// </summary>
		public int Mould_Type
		{
			get{return _mould_type;}
			set{_mould_type = value ;}

		}
		private int _mould_level;
		/// <summary>
		///
		/// </summary>
		public int Mould_Level
		{
			get{return _mould_level;}
			set{_mould_level = value ;}

		}
		private int _create_doc;
		/// <summary>
		///
		/// </summary>
		public int Create_Doc
		{
			get{return _create_doc;}
			set{_create_doc = value ;}

		}
		private int _create_dept;
		/// <summary>
		///
		/// </summary>
		public int Create_Dept
		{
			get{return _create_dept;}
			set{_create_dept = value ;}

		}
		private DateTime _create_date;
		/// <summary>
		///
		/// </summary>
		public DateTime Create_Date
		{
			get{return _create_date;}
			set{_create_date = value ;}

		}
		private int _delete_bit;
		/// <summary>
		///
		/// </summary>
		public int Delete_Bit
		{
			get{return _delete_bit;}
			set{_delete_bit = value ;}

		}
	}
}
