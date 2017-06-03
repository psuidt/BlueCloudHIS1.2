using System;
namespace HIS.ZY_BLL.DataModel
{
	/// <summary>
	/// 交款类
	/// </summary>
    public partial class ZY_Account
	{

		#region Model
		private int _accountid;
        private int _accountType;
		private DateTime _lastdate;
        private decimal _wticketfee;
        private decimal _bticketfee;
		private int _wticketnum;
		private int _bticketnum;
		private decimal _total_fee;
		private decimal _cash_fee;
		private decimal _pos_fee;
		private string _accountcode;
		private DateTime _accountdate;
        private decimal _costFee;
        private decimal _faoverFee;
        private int _printNum;
		/// <summary>
		/// ID
		/// </summary>
		public int AccountID
		{
			set{ _accountid=value;}
			get{return _accountid;}
		}

        /// <summary>
        /// 交款类型
        /// </summary>
        public int AccountType
        {
            set { _accountType = value; }
            get { return _accountType; }
        }

		/// <summary>
		/// 上一次交款时间
		/// </summary>
		public DateTime LastDate
		{
			set{ _lastdate=value;}
			get{return _lastdate;}
		}
        /// <summary>
        /// 有效票据总额
        /// </summary>
        public decimal WTicketFee
        {
            set { _wticketfee = value; }
            get { return _wticketfee; }
        }
		/// <summary>
		/// 有效票据数
		/// </summary>
		public int WTicketNum
		{
			set{ _wticketnum=value;}
			get{return _wticketnum;}
		}
        /// <summary>
        /// 无效票据总额
        /// </summary>
        public decimal BTicketFee
        {
            set { _bticketfee = value; }
            get { return _bticketfee; }
        }
		/// <summary>
		/// 无效票据数
		/// </summary>
		public int BTicketNum
		{
			set{ _bticketnum=value;}
			get{return _bticketnum;}
		}
		/// <summary>
		/// 总费用
		/// </summary>
		public decimal Total_Fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
		/// <summary>
		/// 现金总额
		/// </summary>
		public decimal Cash_Fee
		{
			set{ _cash_fee=value;}
			get{return _cash_fee;}
		}
		/// <summary>
		/// pos总额
		/// </summary>
		public decimal POS_Fee
		{
			set{ _pos_fee=value;}
			get{return _pos_fee;}
		}
		/// <summary>
		/// 交款人代码
		/// </summary>
		public string AccountCode
		{
			set{ _accountcode=value;}
			get{return _accountcode;}
		}
		/// <summary>
		/// 交款时间
		/// </summary>
		public DateTime AccountDate
		{
			set{ _accountdate=value;}
			get{return _accountdate;}
		}
        /// <summary>
        /// 记账费用
        /// </summary>
        public decimal CostFee
        {
            set { _costFee = value; }
            get { return _costFee; }
        }
        /// <summary>
        /// 优惠费用
        /// </summary>
        public decimal FaoverFee
        {
            set { _faoverFee = value; }
            get { return _faoverFee; }
        }
        /// <summary>
        /// 打印次数
        /// </summary>
        public int PrintNum
        {
            set { _printNum = value; }
            get { return _printNum; }
        }
        
		#endregion Model

	}
}

