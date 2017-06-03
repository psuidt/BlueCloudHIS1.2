using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_DJSFManager.类
{
    public abstract class BaseAccountBook
    {
        /// <summary>
        /// 交款人姓名
        /// </summary>
        private string tollCollectorName;
        /// <summary>
        /// 发票项目列表
        /// </summary>
        private InvoiceItem[] invoiceItem;
        /// <summary>
        /// 发票科目合计
        /// </summary>
        private decimal invoiceItemSumTotal;
        /// <summary>
        /// 记账部分
        /// </summary>
        private FundPart tallyPart;
        /// <summary>
        /// 现金部分
        /// </summary>
        private FundPart cashPart;
        /// <summary>
        /// 优惠部分
        /// </summary>
        private FundPart favorPart;


        
        /// <summary>
        /// 交款人姓名
        /// </summary>
        public string TollCollectorName
        {
            get
            {
                return tollCollectorName;
            }
            set
            {
                tollCollectorName = value;
            }
        }
        /// <summary>
        /// 发票项目列表
        /// </summary>
        public InvoiceItem[] InvoiceItem
        {
            get
            {
                return invoiceItem;
            }
            set
            {
                invoiceItem = value;
            }
        }
        /// <summary>
        /// 发票科目合计
        /// </summary>
        public decimal InvoiceItemSumTotal
        {
            get
            {
                return invoiceItemSumTotal;
            }
            set
            {
                invoiceItemSumTotal = value;
            }
        }
        /// <summary>
        /// 记账部分
        /// </summary>
        public FundPart TallyPart
        {
            get
            {
                return tallyPart;
            }
            set
            {
                tallyPart = value;
            }
        }
        /// <summary>
        /// 现金部分
        /// </summary>
        public FundPart CashPart
        {
            get
            {
                return cashPart;
            }
            set
            {
                cashPart = value;
            }
        }
        /// <summary>
        /// 优惠部分
        /// </summary>
        public FundPart FavorPart
        {
            get
            {
                return favorPart;
            }
            set
            {
                favorPart = value;
            }
        }
    }
}
