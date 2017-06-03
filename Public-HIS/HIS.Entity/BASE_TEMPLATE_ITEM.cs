using System;
namespace HIS.Model
{
	public class BASE_TEMPLATE_ITEM
	{
		private int _tmplate_id;
		/// <summary>
		///
		/// </summary>
		public int TMPLATE_ID
		{
			get{return _tmplate_id;}
			set{_tmplate_id = value ;}

		}
		private string _tmplate_name;
		/// <summary>
		///
		/// </summary>
		public string TMPLATE_NAME
		{
			get{return _tmplate_name;}
			set{_tmplate_name = value ;}

		}
		private int _tmplate_type;
		/// <summary>
		///
		/// </summary>
		public int TMPLATE_TYPE
		{
			get{return _tmplate_type;}
			set{_tmplate_type = value ;}

		}
		private string _py_code;
		/// <summary>
		///
		/// </summary>
		public string PY_CODE
		{
			get{return _py_code;}
			set{_py_code = value ;}

		}
		private string _wb_code;
		/// <summary>
		///
		/// </summary>
		public string WB_CODE
		{
			get{return _wb_code;}
			set{_wb_code = value ;}

		}
		private int _creator_id;
		/// <summary>
		///
		/// </summary>
		public int CREATOR_ID
		{
			get{return _creator_id;}
			set{_creator_id = value ;}

		}
		private string _creator_name;
		/// <summary>
		///
		/// </summary>
		public string CREATOR_NAME
		{
			get{return _creator_name;}
			set{_creator_name = value ;}

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
		private string _dept_name;
		/// <summary>
		///
		/// </summary>
		public string DEPT_NAME
		{
			get{return _dept_name;}
			set{_dept_name = value ;}

		}
		private int _share_level;
		/// <summary>
		///
		/// </summary>
		public int SHARE_LEVEL
		{
			get{return _share_level;}
			set{_share_level = value ;}

		}
		private DateTime _create_date;
		/// <summary>
		///
		/// </summary>
		public DateTime CREATE_DATE
		{
			get{return _create_date;}
			set{_create_date = value ;}

		}
		private int _valid_flag;
		/// <summary>
		///
		/// </summary>
		public int VALID_FLAG
		{
			get{return _valid_flag;}
			set{_valid_flag = value ;}

		}
        private int exec_dept_id;
        private string exec_dept_name;
        public int EXEC_DEPT_ID
        {
            get
            {
                return exec_dept_id;
            }
            set
            {
                exec_dept_id = value;
            }
        }
        public string EXEC_DEPT_NAME
        {
            get
            {
                return exec_dept_name;
            }
            set
            {
                exec_dept_name = value;
            }
        }
	}
}
