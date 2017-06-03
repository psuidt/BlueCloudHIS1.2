using System;
namespace HIS .Model
{
    /// <summary>
    /// 实体类YF_InOrder 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class YP_InOrder:BillOrder
    {
        public YP_InOrder()
        {
        }
        #region Model
        private int _instorageid;
        private int _makerdicid;
        private YP_MakerDic _makerdic;
        private string _batchnum;
        private DateTime _validitydate;
        private decimal _recscale;
        private decimal _innum;
        private int _leastunitid;
        private YP_UnitDic _leastunit;
        private int _unitnum;
        private decimal _stockprice;
        private decimal _retailprice;
        private decimal _tradeprice;
        private decimal _stockfee;
        private decimal _retailfee;
        private decimal _tradefee;
        private int _billnum;
        private int _deptid;
        private string _remark;
        private int _audit_flag;
        private int _masterinstorageid;
        private YP_InMaster _masterinstorage;
        private string _delivernum;
        private decimal _currentnum;
        /// <summary>
        /// 入库标识ID
        /// </summary>
        public int InStorageID
        {
            set
            {
                _instorageid = value;
            }
            get
            {
                return _instorageid;
            }
        }
        /// <summary>
        /// 厂家标识ID
        /// </summary>
        public int MakerDicID
        {
            set
            {
                _makerdicid = value;
            }
            get
            {
                return _makerdicid;
            }
        }
        /// <summary>
        /// 厂家信息
        /// </summary>
        public YP_MakerDic MakerDic
        {
            set
            {
                _makerdic = value;
            }
            get
            {
                return _makerdic;
            }
        }
        /// <summary>
        /// 生产批号
        /// </summary>
        public string BatchNum
        {
            set
            {
                _batchnum = value;
            }
            get
            {
                return _batchnum;
            }
        }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ValidityDate
        {
            set
            {
                _validitydate = value;
            }
            get
            {
                return _validitydate;
            }
        }
        /// <summary>
        /// 扣率
        /// </summary>
        public decimal RecScale
        {
            set
            {
                _recscale = value;
            }
            get
            {
                return _recscale;
            }
        }
        /// <summary>
        /// 入库数量
        /// </summary>
        public decimal InNum
        {
            set
            {
                _innum = value;
            }
            get
            {
                return _innum;
            }
        }
        /// <summary>
        /// 最小单位标识
        /// </summary>
        public int LeastUnit
        {
            set
            {
                _leastunitid = value;
            }
            get
            {
                return _leastunitid;
            }
        }
        /// <summary>
        /// 最小单位
        /// </summary>
        public YP_UnitDic LeastUnitEntity
        {
            set
            {
                _leastunit = value;
            }
            get
            {
                return _leastunit;
            }
        }
        /// <summary>
        /// 单位数量
        /// </summary>
        public int UnitNum
        {
            set
            {
                _unitnum = value;
            }
            get
            {
                return _unitnum;
            }
        }
        /// <summary>
        /// 进价
        /// </summary>
        public decimal StockPrice
        {
            set
            {
                _stockprice = value;
            }
            get
            {
                return _stockprice;
            }
        }
        /// <summary>
        /// 零售价
        /// </summary>
        public decimal RetailPrice
        {
            set
            {
                _retailprice = value;
            }
            get
            {
                return _retailprice;
            }
        }
        /// <summary>
        /// 批发价
        /// </summary>
        public decimal TradePrice
        {
            set
            {
                _tradeprice = value;
            }
            get
            {
                return _tradeprice;
            }
        }
        /// <summary>
        /// 入库金额
        /// </summary>
        public decimal StockFee
        {
            set
            {
                _stockfee = value;
            }
            get
            {
                return _stockfee;
            }
        }
        /// <summary>
        /// 零售金额
        /// </summary>
        public decimal RetailFee
        {
            set
            {
                _retailfee = value;
            }
            get
            {
                return _retailfee;
            }
        }
        /// <summary>
        /// 批发金额
        /// </summary>
        public decimal TradeFee
        {
            set
            {
                _tradefee = value;
            }
            get
            {
                return _tradefee;
            }
        }
        /// <summary>
        /// 单据号
        /// </summary>
        public int BillNum
        {
            set
            {
                _billnum = value;
            }
            get
            {
                return _billnum;
            }
        }
        /// <summary>
        /// 科室ID
        /// </summary>
        public int DeptID
        {
            set
            {
                _deptid = value;
            }
            get
            {
                return _deptid;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set
            {
                _remark = value;
            }
            get
            {
                return _remark;
            }
        }
        /// <summary>
        /// 审核标识
        /// </summary>
        public int Audit_Flag
        {
            set
            {
                _audit_flag = value;
            }
            get
            {
                return _audit_flag;
            }
        }
        /// <summary>
        /// 入库表头
        /// </summary>
        public int MasterInStorageID
        {
            set
            {
                _masterinstorageid = value;
            }
            get
            {
                return _masterinstorageid;
            }
        }
        /// <summary>
        /// 入库表头
        /// </summary>
        public YP_InMaster MasterInStorage
        {
            set
            {
                _masterinstorage = value;
            }
            get
            {
                return _masterinstorage;
            }
        }
        /// <summary>
        /// 送货人
        /// </summary>
        public string DeliverNum
        {
            set
            {
                _delivernum = value;
            }
            get
            {
                return _delivernum;
            }
        }

        public decimal CurrentNum
        {
            set
            {
                _currentnum = value;
            }
            get
            {
                return _currentnum;
            }
        }
        #endregion Model

    }
}

