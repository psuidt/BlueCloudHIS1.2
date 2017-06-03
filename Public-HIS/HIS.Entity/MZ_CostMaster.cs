using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类MZ_CostMaster 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MZ_CostMaster
	{
		public MZ_CostMaster()
		{}
		#region Model
		private int _costmasterid;
		private decimal _patid;
		private int _patlistid;
		private int _presmasterid;
		private string _ticketnum;
		private string _ticketcode;
		private string _chargecode;
		private string _chargename;
		private decimal _total_fee;
		private decimal _self_fee;
		private decimal _village_fee;
		private decimal _favor_fee;
		private decimal _pos_fee;
		private decimal _money_fee;
		private int _ticket_flag;
		private DateTime _costdate;
		private int _record_flag;
		private int _oldid;
		private int _accountid;
		private int _hang_flag;
		private int _hurried_flag;
        private int _ticketvol;
        private decimal _self_tally;
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
		public int PresMasterID
		{
			set{ _presmasterid=value;}
			get{return _presmasterid;}
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
		public string ChargeCode
		{
			set{ _chargecode=value;}
			get{return _chargecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChargeName
		{
			set{ _chargename=value;}
			get{return _chargename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Total_Fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Self_Fee
		{
			set{ _self_fee=value;}
			get{return _self_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Village_Fee
		{
			set{ _village_fee=value;}
			get{return _village_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Favor_Fee
		{
			set{ _favor_fee=value;}
			get{return _favor_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Pos_Fee
		{
			set{ _pos_fee=value;}
            get
            {
                return _pos_fee;
            }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Money_Fee
		{
			set{ _money_fee=value;}
            get
            {
                return _money_fee;
            }
		}
		/// <summary>
		/// 
		/// </summary>
		public int Ticket_Flag
		{
			set{ _ticket_flag=value;}
			get{return _ticket_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CostDate
		{
			set{ _costdate=value;}
			get{return _costdate;}
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
		public int OldID
		{
			set{ _oldid=value;}
			get{return _oldid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AccountID
		{
			set{ _accountid=value;}
			get{return _accountid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Hang_Flag
		{
			set{ _hang_flag=value;}
			get{return _hang_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Hurried_Flag
		{
			set{ _hurried_flag=value;}
			get{return _hurried_flag;}
		}
        public int TICKETVOL
        {
            get
            {
                return _ticketvol;
            }
            set
            {
                _ticketvol = value;
            }
        }
        public decimal Self_Tally
        {
            get
            {
                return _self_tally;
            }
            set
            {
                _self_tally = value;
            }
        }
		#endregion Model

	}
}

