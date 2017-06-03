using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_DJSFManager.类
{
    /// <summary>
    /// 总账单类
    /// </summary>
    public class CollectAccountBook : BaseAccountBook
    {
        private DateTime? beginDate;
        private DateTime? endDate;
        private AccountBillInfo[] chargeInvoiceInfo;
        private AccountBillInfo[] registerInvoiceInfo;

        /// <summary>
        /// 账单开始时间
        /// </summary>
        public DateTime? BeginDate
        {
            get
            {
                return beginDate;
            }
            set
            {
                beginDate = value;
            }
        }
        /// <summary>
        /// 账单结束时间
        /// </summary>
        public DateTime? EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }
        /// <summary>
        /// 收费票据信息
        /// </summary>
        public AccountBillInfo[] ChargeInvoiceInfo
        {
            get
            {
                return chargeInvoiceInfo;
            }
            set
            {
                chargeInvoiceInfo = value;
            }
        }
        /// <summary>
        /// 挂号票据信息
        /// </summary>
        public AccountBillInfo[] RegisterInvoiceInfo
        {
            get
            {
                return registerInvoiceInfo;
            }
            set
            {
                registerInvoiceInfo = value;
            }
        }
    }
}
