using System;
namespace HIS.Model
{
	public class BASE_REPORTMASTER
	{
		private int _reportmaster_id;
		/// <summary>
		///
		/// </summary>
		public int REPORTMASTER_ID
		{
			get{return _reportmaster_id;}
			set{_reportmaster_id = value ;}

		}
		private int _p_id;
		/// <summary>
		///
		/// </summary>
		public int P_ID
		{
			get{return _p_id;}
			set{_p_id = value ;}

		}
		private string _name;
		/// <summary>
		///
		/// </summary>
		public string NAME
		{
			get{return _name;}
			set{_name = value ;}

		}
		private int _deiete_flag;
		/// <summary>
		///
		/// </summary>
		public int DEIETE_FLAG
		{
			get{return _deiete_flag;}
			set{_deiete_flag = value ;}

		}
		private int _report_type;
		/// <summary>
		///
		/// </summary>
		public int REPORT_TYPE
		{
			get{return _report_type;}
			set{_report_type = value ;}

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
