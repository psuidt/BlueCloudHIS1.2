using System;
namespace HIS.Model
{
	public class Base_Frequency
	{
		private int _id;
		/// <summary>
		///
		/// </summary>
		public int Id
		{
			get{return _id;}
			set{_id = value ;}

		}
		private string _name;
		/// <summary>
		///
		/// </summary>
		public string Name
		{
			get{return _name;}
			set{_name = value ;}

		}
		private string _py_code;
		/// <summary>
		///
		/// </summary>
		public string Py_Code
		{
			get{return _py_code;}
			set{_py_code = value ;}

		}
		private string _wb_code;
		/// <summary>
		///
		/// </summary>
		public string Wb_Code
		{
			get{return _wb_code;}
			set{_wb_code = value ;}

		}
		private string _d_code;
		/// <summary>
		///
		/// </summary>
		public string D_Code
		{
			get{return _d_code;}
			set{_d_code = value ;}

		}
		private int _execnum;
		/// <summary>
		///
		/// </summary>
		public int ExecNum
		{
			get{return _execnum;}
			set{_execnum = value ;}

		}
		private int _cycleday;
		/// <summary>
		///
		/// </summary>
		public int CycleDay
		{
			get{return _cycleday;}
			set{_cycleday = value ;}

		}
		private string _exectime;
		/// <summary>
		///
		/// </summary>
		public string ExecTime
		{
			get{return _exectime;}
			set{_exectime = value ;}

		}
        private string _caption;
        /// <summary>
        ///
        /// </summary>
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }

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
