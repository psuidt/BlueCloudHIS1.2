using System;
namespace HIS.ZY_BLL.DataModel
{
	public class ZY_DRUGMESSAGE_ORDER
	{
		private int _drugmessageid;
		/// <summary>
		///
		/// </summary>
		public int DRUGMESSAGEID
		{
			get{return _drugmessageid;}
			set{_drugmessageid = value ;}

		}
		private int _masterid;
		/// <summary>
		///
		/// </summary>
		public int MASTERID
		{
			get{return _masterid;}
			set{_masterid = value ;}

		}
		private int _makerdicid;
		/// <summary>
		///
		/// </summary>
		public int MAKERDICID
		{
			get{return _makerdicid;}
			set{_makerdicid = value ;}

		}
		private string _chemname;
		/// <summary>
		///
		/// </summary>
		public string CHEMNAME
		{
			get{return _chemname;}
			set{_chemname = value ;}

		}
		private string _spec;
		/// <summary>
		///
		/// </summary>
		public string SPEC
		{
			get{return _spec;}
			set{_spec = value ;}

		}
		private string _bedno;
		/// <summary>
		///
		/// </summary>
		public string BEDNO
		{
			get{return _bedno;}
			set{_bedno = value ;}

		}
		private string _cureno;
		/// <summary>
		///
		/// </summary>
		public string CURENO
		{
			get{return _cureno;}
			set{_cureno = value ;}

		}
		private string _patname;
		/// <summary>
		///
		/// </summary>
		public string PATNAME
		{
			get{return _patname;}
			set{_patname = value ;}

		}
		private int _curedept;
		/// <summary>
		///
		/// </summary>
		public int CUREDEPT
		{
			get{return _curedept;}
			set{_curedept = value ;}

		}
		private int _curedoc;
		/// <summary>
		///
		/// </summary>
		public int CUREDOC
		{
			get{return _curedoc;}
			set{_curedoc = value ;}

		}
		private int _patid;
		/// <summary>
		///
		/// </summary>
		public int PATID
		{
			get{return _patid;}
			set{_patid = value ;}

		}
		private int _recipenum;
		/// <summary>
		///
		/// </summary>
		public int RECIPENUM
		{
			get{return _recipenum;}
			set{_recipenum = value ;}

		}
		private decimal _drugnum;
		/// <summary>
		///
		/// </summary>
		public decimal DRUGNUM
		{
			get{return _drugnum;}
			set{_drugnum = value ;}

		}
		private int _unit;
		/// <summary>
		///
		/// </summary>
		public int UNIT
		{
			get{return _unit;}
			set{_unit = value ;}

		}
		private string _unitname;
		/// <summary>
		///
		/// </summary>
		public string UNITNAME
		{
			get{return _unitname;}
			set{_unitname = value ;}

		}
		private int _unitnum;
		/// <summary>
		///
		/// </summary>
		public int UNITNUM
		{
			get{return _unitnum;}
			set{_unitnum = value ;}

		}
		private string _dosename;
		/// <summary>
		///
		/// </summary>
		public string DOSENAME
		{
            get { return _dosename; }
            set { _dosename = value; }

		}
		private decimal _retailprice;
		/// <summary>
		///
		/// </summary>
		public decimal RETAILPRICE
		{
			get{return _retailprice;}
			set{_retailprice = value ;}

		}
		private decimal _tradeprice;
		/// <summary>
		///
		/// </summary>
		public decimal TRADEPRICE
		{
			get{return _tradeprice;}
			set{_tradeprice = value ;}

		}
		private decimal _retailfee;
		/// <summary>
		///
		/// </summary>
		public decimal RETAILFEE
		{
			get{return _retailfee;}
			set{_retailfee = value ;}

		}
		private decimal _tradefee;
		/// <summary>
		///
		/// </summary>
		public decimal TRADEFEE
		{
			get{return _tradefee;}
			set{_tradefee = value ;}

		}
		private int _recipemasterid;
		/// <summary>
		///
		/// </summary>
		public int RECIPEMASTERID
		{
			get{return _recipemasterid;}
			set{_recipemasterid = value ;}

		}
		private int _orderrecipeid;
		/// <summary>
		///
		/// </summary>
		public int ORDERRECIPEID
		{
			get{return _orderrecipeid;}
			set{_orderrecipeid = value ;}

		}
		private int _chargeman;
		/// <summary>
		///
		/// </summary>
		public int CHARGEMAN
		{
			get{return _chargeman;}
			set{_chargeman = value ;}

		}
		private DateTime _chargedate;
		/// <summary>
		///
		/// </summary>
		public DateTime CHARGEDATE
		{
			get{return _chargedate;}
			set{_chargedate = value ;}

		}
		private int _refundflag;
		/// <summary>
		///
		/// </summary>
		public int REFUNDFLAG
		{
			get{return _refundflag;}
			set{_refundflag = value ;}

		}
		private int _uniform_flag;
		/// <summary>
		///
		/// </summary>
		public int UNIFORM_FLAG
		{
			get{return _uniform_flag;}
			set{_uniform_flag = value ;}

		}
		private string _chargecode;
		/// <summary>
		///
		/// </summary>
		public string CHARGECODE
		{
			get{return _chargecode;}
			set{_chargecode = value ;}

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
		private int _ordergroup_id;
		/// <summary>
		///
		/// </summary>
		public int ORDERGROUP_ID
		{
			get{return _ordergroup_id;}
			set{_ordergroup_id = value ;}

		}
		private int _docordertype;
		/// <summary>
		///
		/// </summary>
		public int DOCORDERTYPE
		{
			get{return _docordertype;}
			set{_docordertype = value ;}

		}
		private int _docorderid;
		/// <summary>
		///
		/// </summary>
		public int DOCORDERID
		{
			get{return _docorderid;}
			set{_docorderid = value ;}

		}
        private int _disp_flag;
        public int DISP_FLAG
        {
            get { return _disp_flag; }
            set { _disp_flag = value; }
        }

        private int _specdicid;
        public int SPECDICID
        {
            get { return _specdicid; }
            set { _specdicid = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _productname;
        public string PRODUCTNAME
        {
            get { return _productname; }
            set { _productname = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _nodrug_flag;
        public int NODRUG_FLAG
        {
            get { return _nodrug_flag; }
            set { _nodrug_flag = value; }
        }
	}
}
