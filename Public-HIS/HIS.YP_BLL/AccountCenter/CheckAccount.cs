using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Model;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 盘点台帐处理器
    /// </summary>
    abstract class CheckAccount : AccountWriter
    {
        /// <summary>
        /// 根据单据信息构造台帐信息
        /// </summary>
        /// <param name="billMaster">单据头</param>
        /// <param name="billOrder">单据明细信息</param>
        /// <param name="storeNum">库存处理后药品库存信息</param>
        /// <param name="accountYear">会计年份</param>
        /// <param name="accountMonth">会计月份</param>
        /// <param name="smallUnit">基本单位</param>
        /// <returns>台帐信息</returns>
        override protected YP_Account BuildAccount(BillMaster billMaster, BillOrder billOrder, decimal storeNum,
            int accountYear, int accountMonth, int smallUnit)
        {
            YP_Account account = new YP_Account();
            YP_CheckMaster master = (YP_CheckMaster)billMaster;
            YP_CheckOrder order = (YP_CheckOrder)billOrder;
            account.AccountYear = accountYear;
            account.AccountMonth = accountMonth; ;
            account.AccountType = 2;
            account.Balance_Flag = 0;
            account.BillNum = master.BillNum;
            account.OpType = master.OpType;
            account.DeptID = master.DeptID;
            account.LeastUnit = smallUnit;
            account.UnitNum = order.UnitNum;
            account.MakerDicID = order.MakerDicID;
            account.RegTime = master.AuditTime;
            account.RetailPrice = order.RetailPrice;
            account.StockPrice = order.TradePrice;
            account.OrderID = order.CheckOrderID;
            if (order.CheckNum - order.FactNum > 0)
            {
                account.LenderNum = order.CheckNum - order.FactNum;
                account.LenderFee = Math.Abs(order.CKRetailFee - order.FTRetailFee);
            }
            else
            {
                account.DebitNum = order.FactNum - order.CheckNum;
                account.DebitFee = Math.Abs(order.CKRetailFee - order.FTRetailFee);
            }
            account.OverNum = storeNum;
            return account;
        }

    }

}