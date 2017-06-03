using System;
namespace HIS .Model
{
    /// <summary>
    /// 盘点表头
    /// </summary>
    public class YP_CheckMaster:BillMaster
    {
        public YP_CheckMaster()
        {
        }
        #region Model
        private int _mastercheckid;
        private int _billnum;
        private int _regpeopleid;
        private DateTime _regtime;
        private int _auditpeopleid;
        private DateTime _audittime;
        private string _remark;
        private int _del_flag;
        private int _audit_flag;
        private string _optype;
        private int _deptid;
        private int _auditnum;
        private decimal _moreretailfee;
        private decimal _moretradefee;
        private decimal _lessretailfee;
        private decimal _lesstradefee;

        /// <summary>
        /// 盘点表头标识ID
        /// </summary>
        public int MasterCheckID
        {
            set
            {
                _mastercheckid = value;
            }
            get
            {
                return _mastercheckid;
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
        /// 登记人员
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
        /// 审核人员
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

        /// <summary>
        /// 审核单号
        /// </summary>
        public int AuditNum
        {
            set
            {
                _auditnum = value;
            }
            get
            {
                return _auditnum;
            }
        }

        /// <summary>
        /// 盘赢零售金额
        /// </summary>
        public decimal MoreRetailFee
        {
            set
            {
                _moreretailfee = value;
            }
            get
            {
                return _moreretailfee;
            }
        }

        /// <summary>
        /// 盘盈批发金额
        /// </summary>
        public decimal MoreTradeFee
        {
            set
            {
                _moretradefee = value;
            }
            get
            {
                return _moretradefee;
            }
        }

        /// <summary>
        /// 盘亏零售金额
        /// </summary>
        public decimal LessRetailFee
        {
            set
            {
                _lessretailfee = value;
            }
            get
            {
                return _lessretailfee;
            }
        }

        /// <summary>
        /// 盘亏批发金额
        /// </summary>
        public decimal LessTradeFee
        {
            set
            {
                _lesstradefee = value;
            }
            get
            {
                return _lesstradefee;
            }
        }

        #endregion Model

    }
}

