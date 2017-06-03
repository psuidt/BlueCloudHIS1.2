using System;
namespace HIS.Model
{
	public class BASE_COMPLEX_ITEM
	{
		private int _complex_id;
		/// <summary>
		///
		/// </summary>
		public int COMPLEX_ID
		{
			get{return _complex_id;}
			set{_complex_id = value ;}

		}
		private string _code;
		/// <summary>
		///
		/// </summary>
		public string CODE
		{
			get{return _code;}
			set{_code = value ;}

		}
		private string _complex_name;
		/// <summary>
		///
		/// </summary>
		public string COMPLEX_NAME
		{
			get{return _complex_name;}
			set{_complex_name = value ;}

		}
		private string _item_unit;
		/// <summary>
		///
		/// </summary>
		public string ITEM_UNIT
		{
			get{return _item_unit;}
			set{_item_unit = value ;}

		}
		private string _statitem_code;
		/// <summary>
		///
		/// </summary>
		public string STATITEM_CODE
		{
			get{return _statitem_code;}
			set{_statitem_code = value ;}

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
		private int _valid_flag;
		/// <summary>
		///
		/// </summary>
		public int VALID_FLAG
		{
			get{return _valid_flag;}
			set{_valid_flag = value ;}

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
        private decimal price;
        public decimal PRICE
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
	}
}
