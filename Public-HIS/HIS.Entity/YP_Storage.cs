using System;
namespace HIS .Model
{
    /// <summary>
    /// 药品库存
    /// </summary>
    public class YP_Storage
    {
        public YP_Storage()
        {
        }
        #region Model
        private int _storageid;
        private int _makerdicid;
        private YP_MakerDic _makerdic;
        private decimal _currentnum;
        private string _place;
        private decimal _lstockprice;
        private DateTime _regtime;
        private decimal _upperlimit;
        private decimal _lowerlimit;
        private int _leastunitid;
        private YP_UnitDic _leastunit;
        private int _unitnum;
        private int _del_flag;
        private int _deptid;
        /// <summary>
        /// 药品库存标识ID
        /// </summary>
        public int StorageID
        {
            set
            {
                _storageid = value;
            }
            get
            {
                return _storageid;
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
        /// 药品厂家信息
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
        /// 当前库存量
        /// </summary>
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
        /// <summary>
        /// 存放位置
        /// </summary>
        public string Place
        {
            set
            {
                _place = value;
            }
            get
            {
                return _place;
            }
        }
        /// <summary>
        /// 上次进价
        /// </summary>
        public decimal LStockPrice
        {
            set
            {
                _lstockprice = value;
            }
            get
            {
                return _lstockprice;
            }
        }
        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime RegTime
        {
            set
            {
                _regtime = value;
            }
            get
            {
                return _regtime;
            }
        }
        /// <summary>
        /// 库存上限
        /// </summary>
        public decimal UpperLimit
        {
            set
            {
                _upperlimit = value;
            }
            get
            {
                return _upperlimit;
            }
        }
        /// <summary>
        /// 库存下限
        /// </summary>
        public decimal LowerLimit
        {
            set
            {
                _lowerlimit = value;
            }
            get
            {
                return _lowerlimit;
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
        /// 删除标识
        /// </summary>
        public int Del_Flag
        {
            set
            {
                _del_flag = value;
            }
            get
            {
                return _del_flag;
            }
        }
        /// <summary>
        /// 部门信息
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
        #endregion Model

    }
}

