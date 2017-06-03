using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Dao.Invoice
{
    public interface Iinvoice:IbaseDao
    {
        DataTable GetInvoiceInfo(int CostMasterID);
        DataTable GetInvoiceRecord();
    }
}
