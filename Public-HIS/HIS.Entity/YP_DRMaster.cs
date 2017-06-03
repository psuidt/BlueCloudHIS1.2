using System;
namespace HIS .Model
{
    /// <summary>
    /// 发/退药表头
    /// </summary>
    public class YP_DRMaster:BillMaster
    {
        public YP_DRMaster()
        {
        }
        #region Model
        private int _masterdrugocid;
        private decimal _retailfee;
        private int _invoicenum;
        private string _inpatientid;
        private int _recipeid;
        private int _recipenum;
        private string _patientno;
        private int _patientid;
        private string _patientname;
        private int _docid;
        private int _oppeopleid;
        private DateTime _optime;
        private int _charge_flag;
        private int _drugoc_flag;
        private string _optype;
        private decimal _receiptcode;
        private int _dosageman;
        private DateTime _chargedate;
        private int _chargeman;
        private int _deptid;
        private int _uniformid;
        /// <summary>
        /// 发退药表头标识ID
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
        /// 处方信息
        /// </summary>
        public int RecipeID
        {
            set
            {
                _recipeid = value;
            }
            get
            {
                return _recipeid;
            }
        }
        /// <summary>
        /// 处方号码
        /// </summary>
        public int RecipeNum
        {
            set
            {
                _recipenum = value;
            }
            get
            {
                return _recipenum;
            }
        }
        /// <summary>
        /// 病历号
        /// </summary>
        public string PatientNo
        {
            set
            {
                _patientno = value;
            }
            get
            {
                return _patientno;
            }
        }
        /// <summary>
        /// 病人编号
        /// </summary>
        public int PatientID
        {
            set
            {
                _patientid = value;
            }
            get
            {
                return _patientid;
            }
        }
        /// <summary>
        /// 病人名称
        /// </summary>
        public string PatientName
        {
            set
            {
                _patientname = value;
            }
            get
            {
                return _patientname;
            }
        }
        /// <summary>
        /// 医生编号
        /// </summary>
        public int DocID
        {
            set
            {
                _docid = value;
            }
            get
            {
                return _docid;
            }
        }
        /// <summary>
        /// 发/退药人员信息
        /// </summary>
        public int OPPeopleID
        {
            set
            {
                _oppeopleid = value;
            }
            get
            {
                return _oppeopleid;
            }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OPTime
        {
            set
            {
                _optime = value;
            }
            get
            {
                return _optime;
            }
        }
        /// <summary>
        /// 记账单标识号
        /// </summary>
        public int Charge_Flag
        {
            set
            {
                _charge_flag = value;
            }
            get
            {
                return _charge_flag;
            }
        }
        /// <summary>
        /// 发/退药标识
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
        /// 业务类型
        /// </summary>
        public string OpType
        {
            set
            {
                _optype = value;
            }
            get
            {
                return _optype;
            }
        }
        /// <summary>
        /// 结算收据号
        /// </summary>
        public decimal ReceiptCode
        {
            set
            {
                _receiptcode = value;
            }
            get
            {
                return _receiptcode;
            }
        }
        /// <summary>
        /// 配药人
        /// </summary>
        public int DosageMan
        {
            set
            {
                _dosageman = value;
            }
            get
            {
                return _dosageman;
            }
        }
        /// <summary>
        /// 收费日期
        /// </summary>
        public DateTime ChargeDate
        {
            set
            {
                _chargedate = value;
            }
            get
            {
                return _chargedate;
            }
        }
        /// <summary>
        /// 收费人员信息
        /// </summary>
        public int ChargeMan
        {
            set
            {
                _chargeman = value;
            }
            get
            {
                return _chargeman;
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
        public int UniFormId
        {
            set
            {
                _uniformid = value;
            }
            get
            {
                return _uniformid;
            }
        }
        #endregion Model

    }
}

