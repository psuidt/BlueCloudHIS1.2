using System;
namespace HIS.Model
{
	public class NCMS_MATCH_CATALOG_TEMP
	{
		private string _hospital_code;
		/// <summary>
		///
		/// </summary>
		public string HOSPITAL_CODE
		{
			get{return _hospital_code;}
			set{_hospital_code = value ;}

		}
		private string _medorg_code;
		/// <summary>
		///
		/// </summary>
		public string MEDORG_CODE
		{
			get{return _medorg_code;}
			set{_medorg_code = value ;}

		}
		private string _ncms_code;
		/// <summary>
		///
		/// </summary>
		public string NCMS_CODE
		{
			get{return _ncms_code;}
			set{_ncms_code = value ;}

		}
		private string _region_code;
		/// <summary>
		///
		/// </summary>
		public string REGION_CODE
		{
			get{return _region_code;}
			set{_region_code = value ;}

		}
		private string _status;
		/// <summary>
		///
		/// </summary>
		public string STATUS
		{
			get{return _status;}
			set{_status = value ;}

		}
		private string _type;
		/// <summary>
		///
		/// </summary>
		public string TYPE
		{
			get{return _type;}
			set{_type = value ;}

		}
        private decimal _comp_rate;
        /// <summary>
        /// 
        /// </summary>
        public decimal COMP_RATE
        {
            get
            {
                return _comp_rate;
            }
            set
            {
                _comp_rate = value;
            }
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
