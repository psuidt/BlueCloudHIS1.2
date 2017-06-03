using System;
namespace HIS.Model
{
	public class BASE_TABLE_CONFIG
	{
		private string _table_db_name;
		/// <summary>
		///
		/// </summary>
		public string TABLE_DB_NAME
		{
			get{return _table_db_name;}
			set{_table_db_name = value ;}

		}
		private string _table_cn_name;
		/// <summary>
		///
		/// </summary>
		public string TABLE_CN_NAME
		{
			get{return _table_cn_name;}
			set{_table_cn_name = value ;}

		}
		private string _field_db_name;
		/// <summary>
		///
		/// </summary>
		public string FIELD_DB_NAME
		{
			get{return _field_db_name;}
			set{_field_db_name = value ;}

		}
		private string _field_cn_name;
		/// <summary>
		///
		/// </summary>
		public string FIELD_CN_NAME
		{
			get{return _field_cn_name;}
			set{_field_cn_name = value ;}

		}
		private int _field_db_type;
		/// <summary>
		///
		/// </summary>
		public int FIELD_DB_TYPE
		{
			get{return _field_db_type;}
			set{_field_db_type = value ;}

		}
		private int _is_primary_key;
		/// <summary>
		///
		/// </summary>
		public int IS_PRIMARY_KEY
		{
			get{return _is_primary_key;}
			set{_is_primary_key = value ;}

		}
		private int _auto_increase;
		/// <summary>
		///
		/// </summary>
		public int AUTO_INCREASE
		{
			get{return _auto_increase;}
			set{_auto_increase = value ;}

		}
		private int _allow_empty;
		/// <summary>
		///
		/// </summary>
		public int ALLOW_EMPTY
		{
			get{return _allow_empty;}
			set{_allow_empty = value ;}

		}
		private int _is_foreigner_key;
		/// <summary>
		///
		/// </summary>
		public int IS_FOREIGNER_KEY
		{
			get{return _is_foreigner_key;}
			set{_is_foreigner_key = value ;}

		}
        private int _maxlength;
        /// <summary>
        /// 
        /// </summary>
        public int MAXLENGTH
        {
            get
            {
                return _maxlength;
            }
            set
            {
                _maxlength = value;
            }
        }
		private string _foreigner_table;
		/// <summary>
		///
		/// </summary>
		public string FOREIGNER_TABLE
		{
			get{return _foreigner_table;}
			set{_foreigner_table = value ;}

		}
		private string _foreigner_field_db_name;
		/// <summary>
		///
		/// </summary>
		public string FOREIGNER_FIELD_DB_NAME
		{
			get{return _foreigner_field_db_name;}
			set{_foreigner_field_db_name = value ;}

		}
		private string _foreigner_field_cn_name;
		/// <summary>
		///
		/// </summary>
		public string FOREIGNER_FIELD_CN_NAME
		{
			get{return _foreigner_field_cn_name;}
			set{_foreigner_field_cn_name = value ;}

		}
		private string _foreigner_filter_sql;
		/// <summary>
		///
		/// </summary>
		public string FOREIGNER_FILTER_SQL
		{
			get{return _foreigner_filter_sql;}
			set{_foreigner_filter_sql = value ;}

		}
		private int _uic_type;
		/// <summary>
		///
		/// </summary>
		public int UIC_TYPE
		{
			get{return _uic_type;}
			set{_uic_type = value ;}

		}
		private int _location_x;
		/// <summary>
		///
		/// </summary>
		public int LOCATION_X
		{
			get{return _location_x;}
			set{_location_x = value ;}

		}
		private int _location_y;
		/// <summary>
		///
		/// </summary>
		public int LOCATION_Y
		{
			get{return _location_y;}
			set{_location_y = value ;}

		}
		private int _width;
		/// <summary>
		///
		/// </summary>
		public int WIDTH
		{
			get{return _width;}
			set{_width = value ;}

		}
		private int _height;
		/// <summary>
		///
		/// </summary>
		public int HEIGHT
		{
			get{return _height;}
			set{_height = value ;}

		}
        private int _grid_col_width;
        public int GRID_COL_WIDTH
        {
            get
            {
                return _grid_col_width;
            }
            set
            {
                _grid_col_width = value;
            }
        }

        private int _tabindex;
        public int TABINDEX
        {
            get
            {
                return _tabindex;
            }
            set
            {
                _tabindex = value;
            }
        }

        private int _allow_eidt;
        public int ALLOW_EDIT
        {
            get
            {
                return _allow_eidt;
            }
            set
            {
                _allow_eidt = value;
            }
        }

        private int _field_mark_type;
        public int FIELD_MARK_TYPE
        {
            get
            {
                return _field_mark_type;
            }
            set
            {
                _field_mark_type = value;
            }
        }
	}
}
