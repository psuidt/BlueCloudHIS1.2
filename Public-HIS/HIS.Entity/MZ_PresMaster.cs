using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类MZ_PresMaster 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MZ_PresMaster
	{
		public MZ_PresMaster()
		{}
		#region Model
		private int _presmasterid;
		private decimal _patid;
		private int _patlistid;
		private string _prestype;
		private string _presdoccode;
		private string _presdeptcode;
		private string _execdoccode;
		private string _execdeptcode;
		private string _prescostcode;
		private string _chargecode;
        private int _presamount;
		private decimal _total_fee;
		private int _costmasterid;
		private int _oldid;
		private string _ticketnum;
		private string _ticketcode;
		private int _record_flag;
		private int _charge_flag;
		private int _drug_flag;
        private DateTime _presdate;
        private int _hand_flag;
        private int _docPresId;
		/// <summary>
		/// 
		/// </summary>
		public int PresMasterID
		{
			set{ _presmasterid=value;}
			get{return _presmasterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal PatID
		{
			set{ _patid=value;}
			get{return _patid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PatListID
		{
			set{ _patlistid=value;}
			get{return _patlistid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PresType
		{
			set{ _prestype=value;}
			get{return _prestype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PresDocCode
		{
			set{ _presdoccode=value;}
			get{return _presdoccode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PresDeptCode
		{
			set{ _presdeptcode=value;}
			get{return _presdeptcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExecDocCode
		{
			set{ _execdoccode=value;}
			get{return _execdoccode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExecDeptCode
		{
			set{ _execdeptcode=value;}
			get{return _execdeptcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PresCostCode
		{
			set{ _prescostcode=value;}
			get{return _prescostcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChargeCode
		{
			set{ _chargecode=value;}
			get{return _chargecode;}
		}
        public int PresAmount
        {
            get
            {
                return _presamount;
            }
            set
            {
                _presamount = value;
            }
        }
		/// <summary>
		/// 
		/// </summary>
		public decimal Total_Fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
        private decimal _redeemcost;
        /// <summary>
        /// 
        /// </summary>
        public decimal RedeemCost
        {
            get
            {
                return _redeemcost;
            }
            set
            {
                _redeemcost = value;
            }
        }
		/// <summary>
		/// 
		/// </summary>
		public int CostMasterID
		{
			set{ _costmasterid=value;}
			get{return _costmasterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OldID
		{
			set{ _oldid=value;}
			get{return _oldid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TicketNum
		{
			set{ _ticketnum=value;}
			get{return _ticketnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TicketCode
		{
			set{ _ticketcode=value;}
			get{return _ticketcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Record_Flag
		{
			set{ _record_flag=value;}
			get{return _record_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Charge_Flag
		{
			set{ _charge_flag=value;}
			get{return _charge_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Drug_Flag
		{
			set{ _drug_flag=value;}
			get{return _drug_flag;}
		}
        public DateTime PresDate
        {
            get
            {
                return _presdate;
            }
            set
            {
                _presdate = value;
            }
        }
        public int Hand_Flag
        {
            get
            {
                return _hand_flag;
            }
            set
            {
                _hand_flag = value;
            }
        }
        private decimal _roungingmoney;
        public decimal RoungingMoney
        {
            get
            {
                return _roungingmoney;
            }
            set
            {
                _roungingmoney = value;
            }
        }
        public int DocPresId
        {
            get
            {
                return _docPresId;
            }
            set
            {
                _docPresId = value;
            }
        }
		#endregion Model

	}
}

