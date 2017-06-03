using System;
namespace HIS.Model
{
	public class Mz_Doc_Zy_Inpat_Reg
	{
		private int _regid;
		/// <summary>
		///
		/// </summary>
		public int RegId
		{
			get{return _regid;}
			set{_regid = value ;}

		}
		private int _patid;
		/// <summary>
		///
		/// </summary>
		public int PatId
		{
			get{return _patid;}
			set{_patid = value ;}

		}
        private int _patlistid;
		/// <summary>
		///
		/// </summary>
        public int PatListId
		{
            get { return _patlistid; }
            set { _patlistid = value; }

		}
        private string _reg_content;
		/// <summary>
		///
		/// </summary>
        public string Reg_Content
		{
            get { return _reg_content; }
            set { _reg_content = value; }

		}
		private int _reg_emp;
		/// <summary>
		///
		/// </summary>
		public int Reg_Emp
		{
			get{return _reg_emp;}
			set{_reg_emp = value ;}

		}
		private DateTime _reg_date;
		/// <summary>
		///
		/// </summary>
		public DateTime Reg_Date
		{
			get{return _reg_date;}
			set{_reg_date = value ;}

        }
        private int _reg_status;
        /// <summary>
        ///
        /// </summary>
        public int Reg_Status
        {
            get { return _reg_status; }
            set { _reg_status = value; }

        }
	}
}
