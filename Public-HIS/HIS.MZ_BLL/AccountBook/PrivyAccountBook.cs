using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 个人账单类
    /// </summary>
    public class PrivyAccountBook : BaseAccountBook
    {
        /// <summary>
        /// 交账ID
        /// </summary>
        private int accountId;
        /// <summary>
        /// 交款人姓名
        /// </summary>
        private DateTime? accountBookDate;
        /// <summary>
        /// 收费票据信息
        /// </summary>
        private AccountBillInfo chargeInvoiceInfo;
        /// <summary>
        /// 挂号票据信息
        /// </summary>
        private AccountBillInfo registerInvoiceInfo;
        
        

        /// <summary>
        /// 账单ID
        /// </summary>
        public int AccountId
        {
            get
            {
                return accountId;
            }
            set
            {
                accountId = value;
            }
        }
        /// <summary>
        /// 账单日期
        /// </summary>
        public DateTime? AccountBookDate
        {
            get
            {
                return accountBookDate;
            }
            set
            {
                accountBookDate = value;
            }
        }
        /// <summary>
        /// 收费票据信息
        /// </summary>
        public AccountBillInfo ChargeInvoiceInfo
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
        public AccountBillInfo RegisterInvoiceInfo
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
