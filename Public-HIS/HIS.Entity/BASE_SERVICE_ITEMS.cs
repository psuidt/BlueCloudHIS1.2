using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类BASE_SERVICE_ITEMS 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class BASE_SERVICE_ITEMS
	{
		public BASE_SERVICE_ITEMS()
		{}
		#region Model
        private int _item_id;
		private string _std_code;
		private string _item_name;
		private string _item_code;
		private string _py_code;
		private string _wb_code;
		private string _item_unit;
		private decimal _price;
		private int _valid_flag;
		private string _statitem_code;
        private decimal _ncms_comp_rate;
        private string _insur_type;
		/// <summary>
		/// 
		/// </summary>
		public int ITEM_ID
		{
			set{ _item_id=value;}
			get{return _item_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string STD_CODE
		{
			set{ _std_code=value;}
			get{return _std_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_NAME
		{
			set{ _item_name=value;}
			get{return _item_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_CODE
		{
			set{ _item_code=value;}
			get{return _item_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PY_CODE
		{
			set{ _py_code=value;}
			get{return _py_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WB_CODE
		{
			set{ _wb_code=value;}
			get{return _wb_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_UNIT
		{
			set{ _item_unit=value;}
			get{return _item_unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal PRICE
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int VALID_FLAG
		{
			set{ _valid_flag=value;}
			get{return _valid_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string STATITEM_CODE
		{
			set{ _statitem_code=value;}
			get{return _statitem_code;}
		}
        
        public decimal NCMS_COMP_RATE
        {
            get
            {
                return _ncms_comp_rate;
            }
            set
            {
                _ncms_comp_rate = value;
            }
        }
        public string INSUR_TYPE 
        {
            get
            {
                return _insur_type;
            }
            set
            {
                _insur_type = value;
            }
        }
		#endregion Model

	}
}

