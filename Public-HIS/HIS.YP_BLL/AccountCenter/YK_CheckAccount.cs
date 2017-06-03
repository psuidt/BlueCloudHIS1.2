using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Model;
using HIS.SYSTEM.Core;
using System.Collections;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 药库盘点台帐处理器
    /// </summary>
    class YK_CheckAccount : CheckAccount
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
                YP_CheckMaster master = (YP_CheckMaster)billMaster;
                IBaseDAL<YP_Account> accountDao = BindEntity<YP_Account>.CreateInstanceDAL(oleDb, HIS.BLL.Tables.YK_ACCOUNT);
                AccountFactory.GetQuery(ConfigManager.YK_SYSTEM).GetAccountTime(master.AuditTime, ref actYear,
                    ref actMonth, master.DeptID);
                foreach (YP_CheckOrder order in orderList)
                {
                    if (order.CheckNum != order.FactNum)
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
        /// 计算余额
        /// </summary>
        /// <param name="account">台帐信息</param>
        protected override void ComputeFee(YP_Account account)
        {
            account.BalanceFee = AccountWriter.YK_ComputeTotalFee(account.RetailPrice, account.OverNum);
        }
    }

}
