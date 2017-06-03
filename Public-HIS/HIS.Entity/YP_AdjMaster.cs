using System;
namespace HIS .Model
{
    /// <summary>
    /// 调价单表头
    /// </summary>
    public class YP_AdjMaster:BillMaster
    {
        public YP_AdjMaster()
        {
        }
        #region Model
        private int _masteradjpriceid;
        private int _billnum;
        private int _regpeople;
        private DateTime _regtime;
        private string _remark;
        private string _adjcode;
        private DateTime _exetime;
        private int _audit_flag;
        private int _del_flag;
        private string _optype;
        private int _over_flag;
        private int _deptid;
        /// <summary>
        /// 调价表头标识ID
        /// </summary>
        public int MasterAdjPriceID
        {
            set
            {
                _masteradjpriceid = value;
            }
            get
            {
                return _masteradjpriceid;
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
        public int RegPeople
        {
            set
            {
                _regpeople = value;
            }
            get
            {
                return _regpeople;
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
        /// 调价文号
        /// </summary>
        public string AdjCode
        {
            set
            {
                _adjcode = value;
            }
            get
            {
                return _adjcode;
            }
        }
        /// <summary>
        /// 执行日期
        /// </summary>
        public DateTime ExeTime
        {
            set
            {
                _exetime = value;
            }
            get
            {
                return _exetime;
            }
        }
        /// <summary>
        /// 调价执行标识
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
        /// 完成标识
        /// </summary>
        public int Over_Flag
        {
            set
            {
                _over_flag = value;
            }
            get
            {
                return _over_flag;
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

