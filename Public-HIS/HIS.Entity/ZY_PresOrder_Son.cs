using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.Core;

namespace HIS.Model
{
    /// <summary>
    /// 处方明细继承类
    /// </summary>
    public class ZY_PresOrder_Son:ZY_PresOrder
    {
        private RelationalDatabase OleDB;

        #region 属性
        private bool _xd;
        /// <summary>
        /// 是否勾选
        /// </summary>
        public bool XD
        {
            get { return _xd; }
            set { _xd = value; }
        }

        private int _rowno;
        /// <summary>
        /// 行号
        /// </summary>
        public int rowno
        {
            get { return _rowno; }
            set { _rowno = value; }
        }

        private long _PRESCNO;
        /// <summary>
        /// 处方号
        /// </summary>
        public long PRESCNO
        {
            get { return _PRESCNO; }
            set { _PRESCNO = value; }
        }

        private long _PRESCDETAILNO;
        /// <summary>
        /// 
        /// </summary>
        public long PRESCDETAILNO
        {
            get { return _PRESCDETAILNO; }
            set { _PRESCDETAILNO = value; }
        }

        private string _DeptName;
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName
        {
            get { return _DeptName; }
            set { _DeptName = value; }
        }

        private string _DocName;
        /// <summary>
        /// 医生名称
        /// </summary>
        public string DocName
        {
            get { return _DocName; }
            set { _DocName = value; }
        }

        private string _ExecDept;
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string ExecDept
        {
            get { return _ExecDept; }
            set { _ExecDept = value; }
        }

        private string _CostName;
        /// <summary>
        /// 记账人
        /// </summary>
        public string CostName
        {
            get { return _CostName; }
            set { _CostName = value; }
        }

        private int _BigNum;
        /// <summary>
        /// 包装数
        /// </summary>
        public int BigNum
        {
            get { return _BigNum; }
            set { _BigNum = value; }
        }

        private decimal _SmallNum;
        /// <summary>
        /// 基本数
        /// </summary>
        public decimal SmallNum
        {
            get { return Convert.ToDecimal(_SmallNum.ToString("0")); }
            set { _SmallNum = value; }
        }
        private int _BackChargeNum;
        /// <summary>
        /// 冲包装数
        /// </summary>
        public int BackChargeNum
        {
            get
            {
                return _BackChargeNum;
            }
            set
            {
                _BackChargeNum = value;
            }
        }
        private int _BackChargeNum1;
        /// <summary>
        /// 冲基本数
        /// </summary>
        public int BackChargeNum1
        {
            get { return _BackChargeNum1; }
            set { _BackChargeNum1 = value; }
        }

        private string _NCMS_CODE;
        /// <summary>
        /// 农和中心编码
        /// </summary>
        public string NCMS_CODE
        {
            get { return _NCMS_CODE; }
            set { _NCMS_CODE = value; }
        }

        #endregion

        #region 操作

        public ZY_PresOrder_Son()
        {
            OleDB = BaseBLL.oleDb;
        }

        public ZY_PresOrder_Son(RelationalDatabase _oledb)
        {
            OleDB = _oledb;
        }
        /// <summary>
        /// 加载属性数据
        /// </summary>
        public void LoadData()//
        {
            this.rowno = 0;
            this.DeptName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(base.PresDeptCode);
            this.DocName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(base.PresDocCode);
            this.ExecDept = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(base.ExecDeptCode);
            this.CostName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(base.ChargeCode);
            if (this.PresType.Trim() != "1" && this.PresType.Trim() != "2")
            {
                this.SmallNum = Amount;
                this.BigNum = 0;
            }
            else
            {
                this.SmallNum = base.Amount % base.RelationNum;
                this.BigNum = Convert.ToInt32((base.Amount - this.SmallNum) / base.RelationNum);
            }
            this.NCMS_CODE = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetNCMS_CODE(this.ItemID, Convert.ToInt32(this.PresType) >= 4 ? "2" : "1");
        }
        #endregion
    }
}
