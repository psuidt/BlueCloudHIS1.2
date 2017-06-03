using System;
namespace HIS.Model
{
	public class BASE_ENUME
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
		private string _enumname;
		/// <summary>
		///
		/// </summary>
		public string ENUMNAME
		{
			get{return _enumname;}
			set{_enumname = value ;}

		}
		private string _remark;
		/// <summary>
		///
		/// </summary>
		public string REMARK
		{
			get{return _remark;}
			set{_remark = value ;}

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
