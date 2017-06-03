using System;
namespace HIS.Model
{
	/// <summary>
	/// 收费类
	/// </summary>
	public class ZY_ChargeList
	{
		public ZY_ChargeList()
		{}
		#region Model
		private int _chargelistid;
		private int _patid;
        private int _patlistid;
		private string _cureno;
		private string _billno;
		private string _oldbillno;
		private int _feetype;
		private decimal _total_fee;
		private string _chargecode;
		private DateTime _costdate;
		private int _delete_flag;
		private int _accountid;
		private int _record_flag;
		/// <summary>
		/// ID
		/// </summary>
		public int ChargeListID
		{
			set{ _chargelistid=value;}
			get{return _chargelistid;}
		}
		/// <summary>
        /// 病人ID
		/// </summary>
		public int PatID
		{
			set{ _patid=value;}
			get{return _patid;}
		}
		/// <summary>
		/// 住院号
		/// </summary>
		public string CureNo
		{
			set{ _cureno=value;}
			get{return _cureno;}
		}
        /// <summary>
        /// 住院病人ID
        ///
        /// </summary>
        public int PatListID
        {
            set { _patlistid = value; }
            get { return _patlistid; }
        }
		/// <summary>
		/// 单据号
		/// </summary>
		public string BillNo
		{
			set{ _billno=value;}
			get{return _billno;}
		}
		/// <summary>
		/// 老单据号
		/// </summary>
		public string OldBillNo
		{
			set{ _oldbillno=value;}
			get{return _oldbillno;}
		}
		/// <summary>
		/// 费用类别（现金or POS）
		/// </summary>
		public int FeeType
		{
			set{ _feetype=value;}
			get{return _feetype;}
		}
		/// <summary>
		/// 费用
		/// </summary>
		public decimal Total_Fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
		/// <summary>
		/// 收费人代码
		/// </summary>
		public string ChargeCode
		{
			set{ _chargecode=value;}
			get{return _chargecode;}
		}
		/// <summary>
		/// 收费时间
		/// </summary>
		public DateTime CostDate
		{
			set{ _costdate=value;}
			get{return _costdate;}
		}
		/// <summary>
		/// 是否有效(结算ID)
		/// </summary>
		public int Delete_Flag
		{
			set{ _delete_flag=value;}
			get{return _delete_flag;}
		}
		/// <summary>
		/// 交款人代码
		/// </summary>
		public int AccountID
		{
			set{ _accountid=value;}
			get{return _accountid;}
		}
		/// <summary>
		/// 记录状态
		/// </summary>
		public int Record_Flag
		{
			set{ _record_flag=value;}
			get{return _record_flag;}
		}
		#endregion Model

	}
}

