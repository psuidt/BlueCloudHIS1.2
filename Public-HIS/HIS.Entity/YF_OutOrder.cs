using System;
namespace HIS .Model
{
    /// <summary>
    /// 出库明细
    /// </summary>
    public class YP_OutOrder:BillOrder
    {
        public YP_OutOrder()
        {
        }
        #region Model
        private int _outstorageid;
        private int _makerdicid;
        private YP_MakerDic _makerdic;
        private int _audit_flag;
        private string _remark;
        private int _billnum;
        private decimal _tradefee;
        private decimal _retailfee;
        private decimal _tradeprice;
        private decimal _retailprice;
        private int _unitnum;
        private int _leastunitid;
        private YP_UnitDic _leastunit;
        private decimal _outnum;
        private decimal _recscale;
        private DateTime _validitydate;
        private string _productnum;
        private string _outreason;
        private int _outdeptid;
        private int _masteroutstorageid;
        private YP_OutMaster _masteroutstorage;
        private int _deptid;
        private string _outdeptname;
        /// <summary>
        /// 出库明细标识ＩＤ
        /// </summary>
        public int OutStorageID
        {
            set
            {
                _outstorageid = value;
            }
            get
            {
                return _outstorageid;
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
        /// 厂家典标识ＩＤ
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
        /// 批发价格
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
        /// 零售价格
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
        /// 最小单位标识ID
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
        /// 出库数量
        /// </summary>
        public decimal OutNum
        {
            set
            {
                _outnum = value;
            }
            get
            {
                return _outnum;
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
        /// 生产批号
        /// </summary>
        public string ProductNum
        {
            set
            {
                _productnum = value;
            }
            get
            {
                return _productnum;
            }
        }

        /// <summary>
        /// 报损出库原因
        /// </summary>
        public string OutReason
        {
            set
            {
                _outreason = value;
            }
            get
            {
                return _outreason;
            }
        }
        /// <summary>
        /// 输出部门标识ＩＤ
        /// </summary>
        public int OutDeptID
        {
            set
            {
                _outdeptid = value;
            }
            get
            {
                return _outdeptid;
            }
        }
        /// <summary>
        /// 出库表头标识
        /// </summary>
        public int MasterOutStorageID
        {
            set
            {
                _masteroutstorageid = value;
            }
            get
            {
                return _masteroutstorageid;
            }
        }
        /// <summary>
        /// 出库表头信息
        /// </summary>
        public YP_OutMaster MasterOutStorage
        {
            set
            {
                _masteroutstorage = value;
            }
            get
            {
                return _masteroutstorage;
            }
        }
        /// <summary>
        /// 科室标识
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

        public string OutDeptName
        {
            set
            {
                _outdeptname = value;
            }
            get
            {
                return _outdeptname;
            }
        }
        #endregion Model

    }
}

