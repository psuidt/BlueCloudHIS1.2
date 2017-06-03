using System;
namespace HIS.Model
{
	/// <summary>
	/// 结算明细
	/// </summary>
	public class ZY_CostOrder
	{
		public ZY_CostOrder()
		{}
		#region Model
		private int _costorderid;
		private int _patid;
		private int _patlistid;
		private int _costid;
		private string _ticketnum;
		private string _ticketcode;
		private string _bigitemcode;
		private decimal _total_fee;
		/// <summary>
		/// ID
		/// </summary>
		public int CostOrderID
		{
			set{ _costorderid=value;}
			get{return _costorderid;}
		}
		/// <summary>
		/// 病人iD
		/// </summary>
		public int PatID
		{
			set{ _patid=value;}
			get{return _patid;}
		}
		/// <summary>
		/// 住院病人ID
		/// </summary>
		public int PatListID
		{
			set{ _patlistid=value;}
			get{return _patlistid;}
		}
		/// <summary>
		/// 结算主表id
		/// </summary>
		public int CostID
		{
			set{ _costid=value;}
			get{return _costid;}
		}
		/// <summary>
		/// 主表发票流水号
		/// </summary>
		public string TicketNum
		{
			set{ _ticketnum=value;}
			get{return _ticketnum;}
		}
		/// <summary>
		/// 主表发票号
		/// </summary>
		public string TicketCode
		{
			set{ _ticketcode=value;}
			get{return _ticketcode;}
		}
		/// <summary>
		/// 大项目代码
		/// </summary>
		public string BigItemCode
		{
			set{ _bigitemcode=value;}
			get{return _bigitemcode;}
		}
		/// <summary>
		/// 总费用
		/// </summary>
		public decimal Total_Fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
		#endregion Model

	}
}

