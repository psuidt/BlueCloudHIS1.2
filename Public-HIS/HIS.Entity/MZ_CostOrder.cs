using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类MZ_CostOrder 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MZ_CostOrder
	{
		public MZ_CostOrder()
		{}
		#region Model
		private int _costorderid;
		private int _costid;
        //private int _ticketvol;
		private string _ticketnum;
		private string _ticketcode;
		private string _itemtype;
		private decimal _total_fee;
        private int _presmasterid;
		/// <summary>
		/// 
		/// </summary>
		public int CostOrderID
		{
			set{ _costorderid=value;}
			get{return _costorderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CostID
		{
			set{ _costid=value;}
			get{return _costid;}
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
		public string ItemType
		{
			set{ _itemtype=value;}
			get{return _itemtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Total_Fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
        //public int TICKETVOL
        //{
        //    get
        //    {
        //        return _ticketvol;
        //    }
        //    set
        //    {
        //        _ticketvol = value;
        //    }
        //}
        public int PRESMASTERID
        {
            get
            {
                return _presmasterid;
            }
            set
            {
                _presmasterid = value;
            }
        }
		#endregion Model

	}
}

