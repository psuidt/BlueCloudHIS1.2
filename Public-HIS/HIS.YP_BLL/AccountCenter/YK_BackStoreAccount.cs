using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Model;
using HIS.SYSTEM.Core;

namespace HIS.YP_BLL
{
    class YK_BackStoreAccount:AccountWriter
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
        protected override HIS.Model.YP_Account BuildAccount(HIS.Model.BillMaster billMaster, HIS.Model.BillOrder billOrder, decimal storeNum, int accountYear, int accountMonth, int smallUnit)
        {
            YP_InMaster master = (YP_InMaster)billMaster;
            YP_InOrder order = (YP_InOrder)billOrder;
            YP_Account account = new YP_Account();
            account.AccountYear = accountYear;
            account.AccountMonth = accountMonth;
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
            account.OrderID = order.InStorageID;
            account.DebitFee = order.RetailFee;
            account.DebitNum = order.InNum;
            account.OverNum = storeNum;
            return account;
        }

        /// <summary>
        /// 写入台帐
        /// </summary>
        /// <param name="billMaster">单据头表信息</param>
        /// <param name="orderList">单据明细信息</param>
        /// <param name="storeTable">库存处理后的最新药品库存信息</param>
        public override void WriteAccount(BillMaster billMaster, List<BillOrder> orderList, System.Collections.Hashtable storeTable)
        {
            try
            {
                int actYear = 0, actMonth = 0;
                YP_InMaster master = (YP_InMaster)billMaster;
                IBaseDAL<YP_Account> accountDao = BindEntity<YP_Account>.CreateInstanceDAL(oleDb, HIS.BLL.Tables.YK_ACCOUNT);
                AccountFactory.GetQuery(ConfigManager.YK_SYSTEM).GetAccountTime(master.AuditTime, ref actYear,
                    ref actMonth, master.DeptID);
                foreach (YP_InOrder order in orderList)
                {
                    string queryKey = order.MakerDicID.ToString() + order.BatchNum.ToString();
                    decimal storeNum = ((YP_StoreNum)(storeTable[queryKey])).storeNum;
                    int smallUnit = ((YP_StoreNum)(storeTable[queryKey])).smallUnit;
                    YP_Account account = BuildAccount(billMaster, order, storeNum, actYear, actMonth, smallUnit);
                    ComputeFee(account);
                    accountDao.Add(account);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 计算余额
        /// </summary>
        /// <param name="account">台帐信息</param>
        protected override void ComputeFee(YP_Account account)
        {
            account.BalanceFee = AccountWriter.YK_ComputeTotalFee(account.RetailPrice, account.OverNum);
        }
    }
}
