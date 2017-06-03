using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类MZ_Account 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MZ_Account
	{
		public MZ_Account()
		{}
		#region Model
		private int _accountid;
		private DateTime _lastdate;
		private decimal _total_fee;
		private decimal _cash_fee;
		private decimal _pos_fee;
		private string _accountcode;
		private DateTime _accountdate;
        private string _blankout;
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
		public DateTime LastDate
		{
			set{ _lastdate=value;}
			get{return _lastdate;}
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
		public decimal Cash_Fee
		{
			set{ _cash_fee=value;}
			get{return _cash_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal POS_Fee
		{
			set{ _pos_fee=value;}
			get{return _pos_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountCode
		{
			set{ _accountcode=value;}
			get{return _accountcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AccountDate
		{
			set{ _accountdate=value;}
			get{return _accountdate;}
		}
        public string BlankOut
        {
            get
            {
                return _blankout;
            }
            set
            {
                _blankout = value;
            }
        }
		#endregion Model

	}
}

