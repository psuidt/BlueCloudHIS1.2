using System;
namespace HIS.Model
{
	public class BASE_GROUP_REPORT
	{
        private int isgloabal;
        /// <summary>
        /// 
        /// </summary>
        public int IsGloabal
        {
            get { return isgloabal; }
            set { isgloabal = value; }
        }
        private int _his_workid;
        /// <summary>
        /// 
        /// </summary>
        public int HIS_WORKID
        {
            get { return _his_workid; }
            set { _his_workid = value; }
        }
		private int _id;
		/// <summary>
		///
		/// </summary>
		public int ID
		{
			get{return _id;}
			set{_id = value ;}

		}
		private int _report_id;
		/// <summary>
		///
		/// </summary>
		public int REPORT_ID
		{
			get{return _report_id;}
			set{_report_id = value ;}

		}
		private int _group_id;
		/// <summary>
		///
		/// </summary>
		public int GROUP_ID
		{
			get{return _group_id;}
			set{_group_id = value ;}

		}
	}
}
