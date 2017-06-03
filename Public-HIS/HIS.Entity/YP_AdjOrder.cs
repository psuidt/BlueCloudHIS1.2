using System;
namespace HIS .Model
{
    /// <summary>
    /// 实体类YP_AdjOrder 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class YP_AdjOrder:BillOrder
    {
        public YP_AdjOrder()
        {
        }
        #region Model
        private int _orderadjpriceid;
        private int _masteriadjpriced;
        private int _makerdicid;
        private int _leastunitid;
        private YP_AdjMaster _masteradjprice;
        private YP_MakerDic _makerdic;
        private YP_UnitDic _leastunit;
        private int _unitnum;
        private decimal _oldtradeprice;
        private decimal _newtradeprice;
        private decimal _adjtradefee;
        private decimal _oldretailprice;
        private decimal _newretailprice;
        private decimal _adjretailfee;
        private int _deptid;
        private int _billnum;
        private int _audit_flag;
        private decimal _adjnum;
        /// <summary>
        /// 调价明细标识ID
        /// </summary>
        public int OrderAdjPriceID
        {
            set
            {
                _orderadjpriceid = value;
            }
            get
            {
                return _orderadjpriceid;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MasterIAdjPriceD
        {
            set
            {
                _masteriadjpriced = value;
            }
            get
            {
                return _masteriadjpriced;
            }
        }
        /// <summary>
        /// 调价标识ＩＤ
        /// </summary>
        public YP_AdjMaster MasterAdjPrice
        {
            set
            {
                _masteradjprice = value;
            }
            get
            {
                return _masteradjprice;
            }
        }
        /// <summary>
        /// 
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
        /// 调价药品厂家信息
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
        /// 
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
        /// 原批发价
        /// </summary>
        public decimal OldTradePrice
        {
            set
            {
                _oldtradeprice = value;
            }
            get
            {
                return _oldtradeprice;
            }
        }
        /// <summary>
        /// 新批发价
        /// </summary>
        public decimal NewTradePrice
        {
            set
            {
                _newtradeprice = value;
            }
            get
            {
                return _newtradeprice;
            }
        }
        /// <summary>
        /// 调整批发金额
        /// </summary>
        public decimal AdjTradeFee
        {
            set
            {
                _adjtradefee = value;
            }
            get
            {
                return _adjtradefee;
            }
        }
        /// <summary>
        /// 原零售价格
        /// </summary>
        public decimal OldRetailPrice
        {
            set
            {
                _oldretailprice = value;
            }
            get
            {
                return _oldretailprice;
            }
        }
        /// <summary>
        /// 新零售价格
        /// </summary>
        public decimal NewRetailPrice
        {
            set
            {
                _newretailprice = value;
            }
            get
            {
                return _newretailprice;
            }
        }
        /// <summary>
        /// 调整零售金额
        /// </summary>
        public decimal AdjRetailFee
        {
            set
            {
                _adjretailfee = value;
            }
            get
            {
                return _adjretailfee;
            }
        }
        /// <summary>
        /// 科室信息
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
        /// 调整数量
        /// </summary>
        public decimal AdjNum
        {
            set
            {
                _adjnum = value;
            }
            get
            {
                return _adjnum;
            }
        }
        #endregion Model

    }
}

