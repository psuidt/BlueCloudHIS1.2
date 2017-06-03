using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类MZ_PresOrder 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MZ_PresOrder
	{
		public MZ_PresOrder()
		{}
		#region Model
		private int _presorderid;
		private decimal _patid;
		private int _patlistid;
		private int _presmasterid;
		private int _itemid;
		private string _itemtype;
		private string _bigitemcode;
		private string _itemname;
		private string _standard;
		private string _unit;
		private decimal _relationnum;
		private decimal _buy_price;
		private decimal _sell_price;
		private decimal _amount;
		private int _presamount;
		private decimal _tolal_fee;
		private int _order_flag;
		private int _passid;
		private int _caseid;
        private decimal _comp_money;
		/// <summary>
		/// 
		/// </summary>
		public int PresOrderID
		{
			set{ _presorderid=value;}
			get{return _presorderid;}
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
		public int ItemID
		{
			set{ _itemid=value;}
			get{return _itemid;}
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
		public string BigItemCode
		{
			set{ _bigitemcode=value;}
			get{return _bigitemcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Standard
		{
			set{ _standard=value;}
			get{return _standard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal RelationNum
		{
			set{ _relationnum=value;}
			get{return _relationnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Buy_Price
		{
			set{ _buy_price=value;}
			get{return _buy_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Sell_Price
		{
			set{ _sell_price=value;}
			get{return _sell_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PresAmount
		{
			set{ _presamount=value;}
			get{return _presamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Tolal_Fee
		{
			set{ _tolal_fee=value;}
			get{return _tolal_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Order_Flag
		{
			set{ _order_flag=value;}
			get{return _order_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PassID
		{
			set{ _passid=value;}
			get{return _passid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CaseID
		{
			set{ _caseid=value;}
			get{return _caseid;}
		}
        public decimal Comp_Money
        {
            get
            {
                return _comp_money;
            }
            set
            {
                _comp_money = value;
            }
        }
		#endregion Model

	}
}

