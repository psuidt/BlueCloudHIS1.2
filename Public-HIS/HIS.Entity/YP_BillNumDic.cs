using System;
namespace HIS .Model
{
    /// <summary>
    /// 实体类YP_BillNumDic 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class YP_BillNumDic
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public YP_BillNumDic()
        {
        }
        #region Model
        private int _billnumdicid;
        private string _optype;
        private int _billnum;
        private int _deptid;
        /// <summary>
        /// 单据号标识ID
        /// </summary>
        public int BillNumDicID
        {
            set
            {
                _billnumdicid = value;
            }
            get
            {
                return _billnumdicid;
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

