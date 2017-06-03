using System;
namespace HIS.Model
{
	public class BASE_TEMPLATE_DETAIL
	{
		private int _template_id;
		/// <summary>
		///
		/// </summary>
		public int TEMPLATE_ID
		{
			get{return _template_id;}
			set{_template_id = value ;}

		}
		private int _item_id;
		/// <summary>
		///
		/// </summary>
		public int ITEM_ID
		{
			get{return _item_id;}
			set{_item_id = value ;}

		}
		private int _complex_id;
		/// <summary>
		///
		/// </summary>
		public int COMPLEX_ID
		{
			get{return _complex_id;}
			set{_complex_id = value ;}

		}
		private string _item_name;
		/// <summary>
		///
		/// </summary>
		public string ITEM_NAME
		{
			get{return _item_name;}
			set{_item_name = value ;}

		}
		private string _standard;
		/// <summary>
		///
		/// </summary>
		public string STANDARD
		{
			get{return _standard;}
			set{_standard = value ;}

		}
		private string _unit;
		/// <summary>
		///
		/// </summary>
		public string UNIT
		{
			get{return _unit;}
			set{_unit = value ;}

		}
		private string _bigitemcode;
		/// <summary>
		///
		/// </summary>
		public string BIGITEMCODE
		{
			get{return _bigitemcode;}
			set{_bigitemcode = value ;}

		}
		private decimal _dosage;
		/// <summary>
		///
		/// </summary>
		public decimal DOSAGE
		{
			get{return _dosage;}
			set{_dosage = value ;}

		}
		private int _frequen_id;
		/// <summary>
		///
		/// </summary>
		public int FREQUEN_ID
		{
			get{return _frequen_id;}
			set{_frequen_id = value ;}

		}
		private string _frequen_name;
		/// <summary>
		///
		/// </summary>
		public string FREQUEN_NAME
		{
			get{return _frequen_name;}
			set{_frequen_name = value ;}

		}
		private decimal _days;
		/// <summary>
		///
		/// </summary>
		public decimal DAYS
		{
			get{return _days;}
			set{_days = value ;}

		}
		private string _usage_name;
		/// <summary>
		///
		/// </summary>
		public string USAGE_NAME
		{
			get{return _usage_name;}
			set{_usage_name = value ;}

		}
		private int _group_flag;
		/// <summary>
		///
		/// </summary>
		public int GROUP_FLAG
		{
			get{return _group_flag;}
			set{_group_flag = value ;}

		}
		private int _sort_no;
		/// <summary>
		///
		/// </summary>
		public int SORT_NO
		{
			get{return _sort_no;}
			set{_sort_no = value ;}

		}

        private int amount;
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
	}
}
