using System;
namespace HIS.Model
{
    /// <summary>
    /// 
    /// </summary>
	public class Emr_Mould_Element
	{
		private int _mouldid;
		/// <summary>
		///
		/// </summary>
		public int MouldId
		{
			get{return _mouldid;}
			set{_mouldid = value ;}

		}
		private string _mouldcontent;
		/// <summary>
		///
		/// </summary>
		public string MouldContent
		{
			get{return _mouldcontent;}
			set{_mouldcontent = value ;}

		}
		private string _mouldtype;
		/// <summary>
		///
		/// </summary>
		public string MouldType
		{
			get{return _mouldtype;}
			set{_mouldtype = value ;}

		}
		private int _mouldlevel;
		/// <summary>
		///
		/// </summary>
		public int MouldLevel
		{
			get{return _mouldlevel;}
			set{_mouldlevel = value ;}

		}
		private int _mouldcreateemp;
		/// <summary>
		///
		/// </summary>
		public int MouldCreateEmp
		{
			get{return _mouldcreateemp;}
			set{_mouldcreateemp = value ;}

		}
		private int _mouldcreatedept;
		/// <summary>
		///
		/// </summary>
		public int MouldCreateDept
		{
			get{return _mouldcreatedept;}
			set{_mouldcreatedept = value ;}

		}
		private DateTime _mouldcreatedate;
		/// <summary>
		///
		/// </summary>
		public DateTime MouldCreateDate
		{
			get{return _mouldcreatedate;}
			set{_mouldcreatedate = value ;}

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
