using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Model;
using System.Collections;
using HIS.SYSTEM.Core;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 调价台帐处理器
    /// </summary>
    class AdjPriceAccount : AccountWriter
    {
        /// <summary>
        /// 写入台帐
        /// </summary>
        /// <param name="billMaster">单据头表信息</param>
        /// <param name="orderList">单据明细信息</param>
        /// <param name="storeTable">库存处理后的最新药品库存信息</param>
        public override void WriteAccount(BillMaster billMaster, List<BillOrder> orderList, Hashtable storeTable)
        {
            try
            {
                int actYear = 0, actMonth = 0;
                decimal storeNum;
                int smallUnit;
                YP_AdjMaster master = (YP_AdjMaster)billMaster;
                if (master.OpType == ConfigManager.OP_YF_ADJPRICE)
                {
                    IBaseDAL<YP_Account> accountDao = BindEntity<YP_Account>.CreateInstanceDAL(oleDb, BLL.Tables.YF_ACCOUNT);
                    AccountFactory.GetQuery(ConfigManager.YF_SYSTEM).GetAccountTime(master.ExeTime, ref actYear,
                        ref actMonth, master.DeptID);
                    foreach (YP_AdjOrder order in orderList)
                    {
                        storeNum = ((YP_StoreNum)(storeTable[order.MakerDicID])).storeNum;
                        smallUnit = ((YP_StoreNum)(storeTable[order.MakerDicID])).smallUnit;
                        YP_Account account = BuildAccount(billMaster, order, storeNum, actYear, actMonth, smallUnit);
                        ComputeFee(account);
                        accountDao.Add(account);
                    }
                }
                else
                {
                    IBaseDAL<YP_Account> accountDao = BindEntity<YP_Account>.CreateInstanceDAL(oleDb, BLL.Tables.YK_ACCOUNT);
                    AccountFactory.GetQuery(ConfigManager.YK_SYSTEM).GetAccountTime(master.ExeTime, ref actYear,
                        ref actMonth, master.DeptID);
                    foreach (YP_AdjOrder order in orderList)
                    {
                        storeNum = ((YP_StoreNum)(storeTable[order.MakerDicID])).storeNum;
                        smallUnit = ((YP_StoreNum)(storeTable[order.MakerDicID])).smallUnit;
                        YP_Account account = BuildAccount(billMaster, order, storeNum, actYear, actMonth, smallUnit);
                        ComputeFee(account);
                        accountDao.Add(account);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

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
            YP_AdjMaster master = (YP_AdjMaster)billMaster;
            YP_AdjOrder order = (YP_AdjOrder)billOrder;
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
            account.RegTime = master.ExeTime;
            account.RetailPrice = order.NewRetailPrice;
            account.StockPrice = order.NewTradePrice;
            account.OrderID = order.OrderAdjPriceID;
            if (order.AdjRetailFee > 0)
            {
                account.LenderFee = Math.Abs(order.AdjRetailFee);
            }
            else
            {
                account.DebitFee = Math.Abs(order.AdjRetailFee);
            }
            account.OverNum = storeNum;
            return account;
        }

        /// <summary>
        /// 计算余额
        /// </summary>
        /// <param name="account">台帐信息</param>
        protected override void ComputeFee(YP_Account account)
        {
            if (account.OpType == ConfigManager.OP_YF_ADJPRICE)
            {
                account.BalanceFee = AccountWriter.YF_ComputeTotalFee(account.RetailPrice, account.OverNum, account.UnitNum);
            }
            else
            {
                account.BalanceFee = AccountWriter.YK_ComputeTotalFee(account.RetailPrice, account.OverNum);
            }
        }
    }
}
