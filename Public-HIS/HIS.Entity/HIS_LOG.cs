using System;
namespace HIS.Model
{
	public class HIS_LOG
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
		private int _dept_id;
		/// <summary>
		///
		/// </summary>
		public int DEPT_ID
		{
			get{return _dept_id;}
			set{_dept_id = value ;}

		}
		private int _operator_id;
		/// <summary>
		///
		/// </summary>
		public int OPERATOR_ID
		{
			get{return _operator_id;}
			set{_operator_id = value ;}

		}
		private string _operator_type;
		/// <summary>
		///
		/// </summary>
		public string OPERATOR_TYPE
		{
			get{return _operator_type;}
			set{_operator_type = value ;}

		}
		private string _contents;
		/// <summary>
		///
		/// </summary>
		public string CONTENTS
		{
			get{return _contents;}
			set{_contents = value ;}

		}
		private DateTime _starttime;
		/// <summary>
		///
		/// </summary>
		public DateTime STARTTIME
		{
			get{return _starttime;}
			set{_starttime = value ;}

		}
		private int _errlevel;
		/// <summary>
		///
		/// </summary>
		public int ERRLEVEL
		{
			get{return _errlevel;}
			set{_errlevel = value ;}

		}
		private string _workstation;
		/// <summary>
		///
		/// </summary>
		public string WORKSTATION
		{
			get{return _workstation;}
			set{_workstation = value ;}

		}
		private int _module_id;
		/// <summary>
		///
		/// </summary>
		public int MODULE_ID
		{
			get{return _module_id;}
			set{_module_id = value ;}

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
