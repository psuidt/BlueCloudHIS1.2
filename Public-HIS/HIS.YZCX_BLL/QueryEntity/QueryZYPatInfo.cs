using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Model;

namespace HIS.YZCX_BLL
{
    public class QueryZYPatInfo
    {
        public ZY_PatList _zyPatient = new ZY_PatList();
        private decimal _totalFee;
        private decimal _prePayFee;
        private decimal _balanceFee;
        /// <summary>
        /// 病人总费用
        /// </summary>
        public decimal TotalFee
        {
            set
            {
                _totalFee = value;
            }
            get
            {
                return _totalFee;
            }
        }

        /// <summary>
        /// 病人预交金
        /// </summary>
        public decimal PrePayFee
        {
            set
            {
                _prePayFee = value;
            }
            get
            {
                return _prePayFee;
            }
        }

        /// <summary>
        /// 病人余额
        /// </summary>
        public decimal BalanceFee
        {
            set
            {
                _balanceFee = value;
            }
            get
            {
                return _balanceFee;
            }
        }
    }
}
