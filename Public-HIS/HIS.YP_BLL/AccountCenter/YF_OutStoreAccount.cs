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
    /// 药房出库台帐处理器
    /// </summary>
    class YF_OutStoreAccount : OutStoreAccount
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
        protected override YP_Account BuildAccount(BillMaster billMaster, BillOrder billOrder, decimal storeNum,
           int accountYear, int accountMonth, int smallUnit)
        {
            YP_OutOrder order = (YP_OutOrder)billOrder;
            YP_Account account = base.BuildAccount(billMaster, billOrder, storeNum, accountYear, accountMonth, smallUnit);
            account.DebitNum = order.OutNum * order.UnitNum;
            return account;
        }

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
                YP_OutMaster master = (YP_OutMaster)billMaster;
                IBaseDAL<YP_Account> accountDao = BindEntity<YP_Account>.CreateInstanceDAL(oleDb, HIS.BLL.Tables.YF_ACCOUNT);
                AccountFactory.GetQuery(ConfigManager.YF_SYSTEM).GetAccountTime(master.AuditTime, ref actYear,
                    ref actMonth, master.DeptID);
                foreach (YP_OutOrder order in orderList)
                {
                    decimal storeNum = ((YP_StoreNum)(storeTable[order.MakerDicID])).storeNum;
                    int smallUnit = ((YP_StoreNum)(storeTable[order.MakerDicID])).smallUnit;
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
            account.BalanceFee = AccountWriter.YF_ComputeTotalFee(account.RetailPrice, account.OverNum, account.UnitNum);
        }
    }
}
