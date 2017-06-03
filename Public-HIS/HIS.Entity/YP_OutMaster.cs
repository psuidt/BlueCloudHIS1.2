using System;
namespace HIS .Model
{
    /// <summary>
    /// 实体类YF_OutMaster 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class YP_OutMaster:BillMaster
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public YP_OutMaster()
        {
        }
        #region Model
        private int _masteroutstorageid;
        private string _remark;
        private int _del_flag;
        private int _audit_flag;
        private DateTime _audittime;
        private int _auditpeopleid;
        private DateTime _regtime;
        private int _regpeopleid;
        private int _billnum;
        private decimal _outfee;
        private decimal _retailfee;
        private decimal _tradefee;
        private string _invoicenum;
        private string _invoicedate;
        private DateTime _billdate;
        private string _optype;
        private int _relationnum;
        private int _deptid;
        private int _outdeptid;
        /// <summary>
        /// 出库表头标识ID
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
        /// 备注
        /// </summary>
        public string ReMark
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
        /// 审核时间
        /// </summary>
        public DateTime AuditTime
        {
            set
            {
                _audittime = value;
            }
            get
            {
                return _audittime;
            }
        }
        /// <summary>
        /// 审核人员信息
        /// </summary>
        public int AuditPeopleID
        {
            set
            {
                _auditpeopleid = value;
            }
            get
            {
                return _auditpeopleid;
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
        /// 登记人信息
        /// </summary>
        public int RegPeopleID
        {
            set
            {
                _regpeopleid = value;
            }
            get
            {
                return _regpeopleid;
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
        /// 出库金额
        /// </summary>
        public decimal OutFee
        {
            set
            {
                _outfee = value;
            }
            get
            {
                return _outfee;
            }
        }
        /// <summary>
        /// 出库零售金额
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
        /// 出库批发金额
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
        /// 发票号
        /// </summary>
        public string InvoiceNum
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
        /// 发票日期
        /// </summary>
        public string InvoiceDate
        {
            set
            {
                _invoicedate = value;
            }
            get
            {
                return _invoicedate;
            }
        }
        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime BillDate
        {
            set
            {
                _billdate = value;
            }
            get
            {
                return _billdate;
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
        /// 对应药房申请单单据号
        /// </summary>
        public int RelationNum
        {
            set
            {
                _relationnum = value;
            }
            get
            {
                return _relationnum;
            }
        }
        /// <summary>
        /// 领药科室
        /// </summary>
        public int OutDeptId
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
        #endregion Model

    }
}

