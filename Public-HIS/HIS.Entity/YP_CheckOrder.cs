using System;
namespace HIS.Model
{
	/// <summary>
	/// 盘存明细
	/// </summary>
	public class YP_CheckOrder:BillOrder,ICloneable
	{
		public YP_CheckOrder()
		{}
		#region Model
		private int _checkorderid;
		private int _storageid;
		private YP_Storage _storage;
		private int _deptid;

		private int _makerdicid;
		private int _billnum;
		private decimal _checknum;
		private decimal _cktradefee;
		private decimal _ckretailfee;
		private decimal _factnum;
		private decimal _fttradefee;
		private decimal _ftretailfee;
		private int _leastunitid;
		private YP_UnitDic _leastunit;
		private int _unitnum;
		private int _audit_flag;
		private DateTime _billtime;
		private decimal _retailprice;
		private decimal _tradeprice;
		private string _groupnum;
		private int _mastercheckid;
		private YP_CheckMaster _mastercheck;
		private string _batchNum;
        private DateTime _validityDate;

        public object Clone()
        {
            YP_CheckOrder newOrder = new YP_CheckOrder();
            newOrder._audit_flag = _audit_flag;
            newOrder._batchNum = _batchNum;
            newOrder._billnum = _billnum;
            newOrder._billtime = _billtime;
            newOrder._checknum = _checknum;
            newOrder._checkorderid = _checkorderid;
            newOrder._ckretailfee = _ckretailfee;
            newOrder._cktradefee = _cktradefee;
            newOrder._deptid = _deptid;
            newOrder._factnum = _factnum;
            newOrder._ftretailfee = _ftretailfee;
            newOrder._fttradefee = _fttradefee;
            newOrder._groupnum = _groupnum;
            newOrder._leastunitid = _leastunitid;
            newOrder._makerdicid = _makerdicid;
            newOrder._mastercheckid = _mastercheckid;
            newOrder._retailprice = _retailprice;
            newOrder._storageid = _storageid;
            newOrder._tradeprice = _tradeprice;
            newOrder._unitnum = _unitnum;
            newOrder.ValidityDate = _validityDate;
            return newOrder;
        }

		/// <summary>
		/// 盘存明细标识ID
		/// </summary>
		public int CheckOrderID
		{
			set{ _checkorderid=value;}
			get{return _checkorderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StorageID
		{
			set{ _storageid=value;}
			get{return _storageid;}
		}
		/// <summary>
		/// 库存信息
		/// </summary>
        public YP_Storage Storage
		{
			set{ _storage=value;}
			get{return _storage;}
		}
		/// <summary>
		/// 科室信息
		/// </summary>
		public int DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 药品厂家信息
		/// </summary>
		public int MakerDicID
		{
			set{ _makerdicid=value;}
			get{return _makerdicid;}
		}
		/// <summary>
		/// 单据号
		/// </summary>
		public int BillNum
		{
			set{ _billnum=value;}
			get{return _billnum;}
		}
		/// <summary>
		/// 盘点数量
		/// </summary>
		public decimal CheckNum
		{
			set{ _checknum=value;}
			get{return _checknum;}
		}
		/// <summary>
		/// 盘存批发金额
		/// </summary>
		public decimal CKTradeFee
		{
			set{ _cktradefee=value;}
			get{return _cktradefee;}
		}
		/// <summary>
		/// 盘存零售金额
		/// </summary>
		public decimal CKRetailFee
		{
			set{ _ckretailfee=value;}
			get{return _ckretailfee;}
		}
		/// <summary>
		/// 实际数量
		/// </summary>
		public decimal FactNum
		{
			set{ _factnum=value;}
			get{return _factnum;}
		}
		/// <summary>
		/// 实际批发金额
		/// </summary>
		public decimal FTTradeFee
		{
			set{ _fttradefee=value;}
			get{return _fttradefee;}
		}
		/// <summary>
		/// 实际零售金额
		/// </summary>
		public decimal FTRetailFee
		{
			set{ _ftretailfee=value;}
			get{return _ftretailfee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LeastUnit
		{
			set{ _leastunitid=value;}
			get{return _leastunitid;}
		}
		/// <summary>
		/// 最小单位
		/// </summary>
        public YP_UnitDic LeastUnitEntity
		{
			set{ _leastunit=value;}
			get{return _leastunit;}
		}
		/// <summary>
		/// 单位数量
		/// </summary>
		public int UnitNum
		{
			set{ _unitnum=value;}
			get{return _unitnum;}
		}
		/// <summary>
		/// 审核标识
		/// </summary>
		public int Audit_Flag
		{
			set{ _audit_flag=value;}
			get{return _audit_flag;}
		}
		/// <summary>
		/// 单据时间
		/// </summary>
		public DateTime BillTime
		{
			set{ _billtime=value;}
			get{return _billtime;}
		}
		/// <summary>
		/// 零售价格
		/// </summary>
		public decimal RetailPrice
		{
			set{ _retailprice=value;}
			get{return _retailprice;}
		}
		/// <summary>
		/// 批发价格
		/// </summary>
		public decimal TradePrice
		{
			set{ _tradeprice=value;}
			get{return _tradeprice;}
		}
		/// <summary>
		/// 药品批次
		/// </summary>
		public string GroupNum
		{
			set{ _groupnum=value;}
			get{return _groupnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MasterCheckID
		{
			set{ _mastercheckid=value;}
			get{return _mastercheckid;}
		}
		/// <summary>
		/// 盘点表头信息
		/// </summary>
        public YP_CheckMaster MasterCheck
		{
			set{ _mastercheck=value;}
			get{return _mastercheck;}
		}
		/// <summary>
		/// 生产批号
		/// </summary>
		public string BatchNum
		{
			set{ _batchNum=value;}
            get { return _batchNum; }
		}

        public DateTime ValidityDate
        {
            set { _validityDate = value; }
            get { return _validityDate; }
        }
		#endregion Model

	}
}

