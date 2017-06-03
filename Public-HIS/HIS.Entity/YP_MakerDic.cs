using System;
namespace HIS .Model
{
    public struct DrugInfo
    {
        public string chemname;
        public string spec;
        public string productname;
        public string medicarename;
    }
    /// <summary>
    /// 实体类YP_MakerDic 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class YP_MakerDic
    {
        public YP_MakerDic()
        {
        }
        #region Model
        private int _makerdicid;
        private int _specdicid;
        public DrugInfo DrugInfo;
        private string _balenum;
        private string _barcode;
        private int _productid;
        private decimal _tradeprice;
        private decimal _hretailprice;
        private decimal _retailprice;
        private string _approvenum;
        private int _validitydate;
        private int _medicaredicid;
        private decimal _ownpayscale;
        private decimal _defrecscale;
        private decimal _defstockprice;
        private int _del_flag;
        private int _ownpay_flag;
        private int _virulent_flag;
        private int _narcotic_flag;
        private int _skintest_flag;
        private int _recipe_flag;
        private int _lunacy_flag;
        private int _costly_flag;
        private int _bigtransfu_flag;
        private int _gmp_flag;
        private int _medicare_flag;
        private int _useout_flag;
        private string _remark;
        private DateTime _regtime;
        private int _getway;
        private string _unifgettype;
        private int _medi_inverse;
        public int Medi_inverse
        {
            get 
            { 
                return _medi_inverse;
            }
            set 
            {
                _medi_inverse = value; 
            }
        }
        /// <summary>
        /// 厂家典标识ID
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
        /// 
        /// </summary>
        public int SpecDicID
        {
            set
            {
                _specdicid = value;
            }
            get
            {
                return _specdicid;
            }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string BaleNum
        {
            set
            {
                _balenum = value;
            }
            get
            {
                return _balenum;
            }
        }
        /// <summary>
        /// 条形码
        /// </summary>
        public string BarCode
        {
            set
            {
                _barcode = value;
            }
            get
            {
                return _barcode;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProductID
        {
            set
            {
                _productid = value;
            }
            get
            {
                return _productid;
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
        /// 最高零售价
        /// </summary>
        public decimal HRetailPrice
        {
            set
            {
                _hretailprice = value;
            }
            get
            {
                return _hretailprice;
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
        /// 批准文号
        /// </summary>
        public string ApproveNum
        {
            set
            {
                _approvenum = value;
            }
            get
            {
                return _approvenum;
            }
        }
        /// <summary>
        /// 有效期
        /// </summary>
        public int ValidityDate
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
        /// 
        /// </summary>
        public int MedicareDicID
        {
            set
            {
                _medicaredicid = value;
            }
            get
            {
                return _medicaredicid;
            }
        }
        /// <summary>
        /// 自付比例
        /// </summary>
        public decimal OwnpayScale
        {
            set
            {
                _ownpayscale = value;
            }
            get
            {
                return _ownpayscale;
            }
        }
        /// <summary>
        /// 默认扣率
        /// </summary>
        public decimal DefRecScale
        {
            set
            {
                _defrecscale = value;
            }
            get
            {
                return _defrecscale;
            }
        }
        /// <summary>
        /// 默认进价
        /// </summary>
        public decimal DefStockPrice
        {
            set
            {
                _defstockprice = value;
            }
            get
            {
                return _defstockprice;
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
        /// 自费标识
        /// </summary>
        public int OwnPay_Flag
        {
            set
            {
                _ownpay_flag = value;
            }
            get
            {
                return _ownpay_flag;
            }
        }
        /// <summary>
        /// 剧毒标识
        /// </summary>
        public int Virulent_Flag
        {
            set
            {
                _virulent_flag = value;
            }
            get
            {
                return _virulent_flag;
            }
        }
        /// <summary>
        /// 麻醉标识
        /// </summary>
        public int Narcotic_Flag
        {
            set
            {
                _narcotic_flag = value;
            }
            get
            {
                return _narcotic_flag;
            }
        }
        /// <summary>
        /// 皮试标识
        /// </summary>
        public int Skintest_Flag
        {
            set
            {
                _skintest_flag = value;
            }
            get
            {
                return _skintest_flag;
            }
        }
        /// <summary>
        /// 处方用药
        /// </summary>
        public int Recipe_Flag
        {
            set
            {
                _recipe_flag = value;
            }
            get
            {
                return _recipe_flag;
            }
        }
        /// <summary>
        /// 精神药品标识
        /// </summary>
        public int Lunacy_Flag
        {
            set
            {
                _lunacy_flag = value;
            }
            get
            {
                return _lunacy_flag;
            }
        }
        /// <summary>
        /// 贵重药品标识
        /// </summary>
        public int Costly_Flag
        {
            set
            {
                _costly_flag = value;
            }
            get
            {
                return _costly_flag;
            }
        }
        /// <summary>
        /// 大输液标识
        /// </summary>
        public int Bigtransfu_Flag
        {
            set
            {
                _bigtransfu_flag = value;
            }
            get
            {
                return _bigtransfu_flag;
            }
        }
        /// <summary>
        /// GMP标识
        /// </summary>
        public int GMP_Flag
        {
            set
            {
                _gmp_flag = value;
            }
            get
            {
                return _gmp_flag;
            }
        }
        /// <summary>
        /// 医保标识
        /// </summary>
        public int Medicare_Flag
        {
            set
            {
                _medicare_flag = value;
            }
            get
            {
                return _medicare_flag;
            }
        }
        /// <summary>
        /// 外用药品标识
        /// </summary>
        public int UseOut_Flag
        {
            set
            {
                _useout_flag = value;
            }
            get
            {
                return _useout_flag;
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
        /// 停用标识
        /// </summary>
        public int GetWay
        {
            set
            {
                _getway = value;
            }
            get
            {
                return _getway;
            }
        }
        /// <summary>
        /// 统领类型
        /// </summary>
        public string UnifGettype
        {
            set
            {
                _unifgettype = value;
            }
            get
            {
                return _unifgettype;
            }
        }
        #endregion Model

    }
}

