using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.DataModel;

namespace HIS.ZY_BLL.ObjectModel.PresOrderManager
{
    public interface IpresOrderManager
    {
        HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb { get; set; }
        decimal Amount { get; set; }
        int OldID { get; set; }
        decimal CalculateAllFee(decimal binnum, decimal smallnum, decimal RelationNum, decimal price);
        decimal CalculateAllFee(decimal Allnum, decimal RelationNum, decimal price);
        bool CheckBackPres(out decimal resultfee, out decimal arithmetical_compliment);
        void SavePres(List<ZY_PresOrder> zyPresOrderList);
    }
}
