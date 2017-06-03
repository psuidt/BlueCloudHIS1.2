using System;
namespace HIS .Model
{
    /// <summary>
    /// 实体类YF_DROrder 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class YP_DROrder:BillOrder
    {
        public YP_DROrder()
        {
        }
        #region Model
        private int _orderdrugocid;
        private int _masterdrugocid;
        private YP_DRMaster _masterdrugoc;
        private int _invoicenum;
        private int _orderrecipeid;
        private string _inpatientid;
        private int _makerdicid;
        private YP_MakerDic _makerdic;
        private int _specdicid;
        private YP_SpecDic _specdic;
        private string _chemname;
        private int _leastunitid;
        private YP_UnitDic _leastunit;
        private int _unitnum;
        private decimal _drugocnum;
        private int _dosenum;
        private decimal _retailprice;
        private decimal _tradeprice;
        private decimal _retailfee;
        private decimal _tradefee;
        private int _drugoc_flag;
        private int _refundment_flag;
        private int _uniform_flag;
        private int _deptid;
        private int _uniformId;
        private int _curedeptid;

        /// <summary>
        /// 开方科室
        /// </summary>
        public int Curedeptid
        {
            get { return _curedeptid; }
            set { _curedeptid = value; }
        }
        /// <summary>
        /// 发退药明细标识ＩＤ
        /// </summary>
        public int OrderDrugOCID
        {
            set
            {
                _orderdrugocid = value;
            }
            get
            {
                return _orderdrugocid;
            }
        }
        /// <summary>
        /// 发退药表头信息
        /// </summary>
        public YP_DRMaster MasterDrugOC
        {
            set
            {
                _masterdrugoc = value;
            }
            get
            {
                return _masterdrugoc;
            }
        }
        /// <summary>
        /// 发退药表头标识ＩＤ
        /// </summary>
        public int MasterDrugOCID
        {
            set
            {
                _masterdrugocid = value;
            }
            get
            {
                return _masterdrugocid;
            }
        }
        /// <summary>
        /// 发票号
        /// </summary>
        public int InvoiceNum
        {
            set
            {
                _invoicenum = value;
            }
            get
            {
                return _invoicenum;
            }
        }
        /// <summary>
        /// 处方明细ID
        /// </summary>
        public int OrderRecipeID
        {
            set
            {
                _orderrecipeid = value;
            }
            get
            {
                return _orderrecipeid;
            }
        }
        /// <summary>
        /// 住院号
        /// </summary>
        public string InpatientID
        {
            set
            {
                _inpatientid = value;
            }
            get
            {
                return _inpatientid;
            }
        }
        /// <summary>
        /// 厂家标识ＩＤ
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
        /// 规格信息
        /// </summary>
        public YP_SpecDic SpecDic
        {
            set
            {
                _specdic = value;
            }
            get
            {
                return _specdic;
            }
        }

        /// <summary>
        /// 规格标识ID
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
        /// 化学名称
        /// </summary>
        public string ChemName
        {
            set
            {
                _chemname = value;
            }
            get
            {
                return _chemname;
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
        /// 最小单位标识ＩＤ
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
        /// 发退药数量
        /// </summary>
        public decimal DrugOCNum
        {
            set
            {
                _drugocnum = value;
            }
            get
            {
                return _drugocnum;
            }
        }
        /// <summary>
        /// 剂数
        /// </summary>
        public int DoseNum
        {
            set
            {
                _dosenum = value;
            }
            get
            {
                return _dosenum;
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
        /// 批发金额
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
        /// 发退药标识
        /// </summary>
        public int DrugOC_Flag
        {
            set
            {
                _drugoc_flag = value;
            }
            get
            {
                return _drugoc_flag;
            }
        }

        /// <summary>
        /// 退费标识
        /// </summary>
        public int Refundment_Flag
        {
            set
            {
                _refundment_flag = value;
            }
            get
            {
                return _refundment_flag;
            }
        }
        /// <summary>
        /// 统领标识
        /// </summary>
        public int Uniform_Flag
        {
            set
            {
                _uniform_flag = value;
            }
            get
            {
                return _uniform_flag;
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

        public int UniformID
        {
            set
            {
                _uniformId = value;
            }
            get
            {
                return _uniformId;
            }
        }
        #endregion Model

    }
}

