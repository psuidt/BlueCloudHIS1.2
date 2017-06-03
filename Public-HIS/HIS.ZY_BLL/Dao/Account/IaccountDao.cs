using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.ZY_BLL.DataModel;

namespace HIS.ZY_BLL.Dao.Account
{
    public interface IaccountDao : IbaseDao
    {
        DataTable GetAllCharge(string ChargeCode);
        DataTable GetAllCost(string ChargeCode);
        DataTable GetBIGItemData(string[] AccountID);
        DataTable GetVillage_Fee(int AccountID);
        decimal GetAllChargeFee(DateTime Bdate, DateTime Edate);
        decimal GetAllChargeFee(DateTime Bdate, DateTime Edate, List<ZY_Account> zylist);
        DataTable GetAccountDeptOrderData(int AccountID);
    }
}
