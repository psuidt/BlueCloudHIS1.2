using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL.ObjectModel.CostManager
{
    /// <summary>
    /// 发票创建工厂
    /// </summary>
    public class InvoiceFactory
    {
        /// <summary>
        /// 创建发票
        /// </summary>
        /// <param name="CostMasterID">结算ID</param>
        /// <param name="invoiceType">发票类型</param>
        /// <returns></returns>
        public static Object CreateInvoice(int CostMasterID, string invoiceType)
        {
            switch (invoiceType)
            {
                case "湖南":
                    Invoice_HN invoice = new Invoice_HN();
                    return invoice.GetTicketInfo(CostMasterID);
                case "广东":
                    Invoice_GD invoice1 = new Invoice_GD();
                    return invoice1.GetInvoiceInfo(CostMasterID);
            }
            return null;
        }
    }
}
