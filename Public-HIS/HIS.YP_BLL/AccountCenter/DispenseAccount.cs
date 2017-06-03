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
    /// 发药台帐处理器
    /// </summary>
    class DispenseAccount : AccountWriter
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
            YP_DRMaster master = (YP_DRMaster)billMaster;
            YP_DROrder order = (YP_DROrder)billOrder;
            YP_Account account = new YP_Account();
            account.AccountYear = accountYear;
            account.AccountMonth = accountMonth; ;
            account.AccountType = 2;
            account.Balance_Flag = 0;
            account.BillNum = (master.InvoiceNum != 0 ? master.InvoiceNum : Convert.ToInt32(master.InpatientID));
            account.OpType = master.OpType;
            account.DeptID = master.DeptID;
            account.LeastUnit = smallUnit;
            account.UnitNum = order.UnitNum;
            account.MakerDicID = order.MakerDicID;
            account.RegTime = master.OPTime;
            account.RetailPrice = order.RetailPrice;
            account.StockPrice = order.TradePrice;
            account.OrderID = order.OrderDrugOCID;
            if (master.InvoiceNum != 0)
            {
                account.DebitFee = order.RetailFee * master.RecipeNum;
                account.DebitNum = order.DrugOCNum * master.RecipeNum;
            }
            else
            {
                account.DebitFee = order.RetailFee;
                account.DebitNum = order.DrugOCNum;
            }
            account.OverNum = storeNum;
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
                int smallUnit = 0;
                decimal storeNum = 0;
                YP_DRMaster master = (YP_DRMaster)billMaster;
                AccountFactory.GetQuery(ConfigManager.YF_SYSTEM).GetAccountTime(master.OPTime, ref actYear,
                    ref actMonth, master.DeptID);
                foreach (YP_DROrder order in orderList)
                {
                    storeNum = ((YP_StoreNum)(storeTable[order.OrderRecipeID])).storeNum;
                    smallUnit = ((YP_StoreNum)(storeTable[order.OrderRecipeID])).smallUnit;
                    YP_Account account = BuildAccount(billMaster, order, storeNum, actYear, actMonth, smallUnit);
                    ComputeFee(account);
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
            IBaseDAL<YP_Account> accountDao = BindEntity<YP_Account>.CreateInstanceDAL(oleDb, HIS.BLL.Tables.YF_ACCOUNT);
            //库存金额
            decimal storeFee = 0;
            decimal adjLenderFee = 0;
            decimal adjDebitFee = 0;
            //判断退药期间是否有调价发生
            YP_MakerDic makerDic = new YP_MakerDic();
            IBaseDAL<YP_MakerDic> makerDao = BindEntity<YP_MakerDic>.CreateInstanceDAL(oleDb);
            makerDic = makerDao.GetModel(account.MakerDicID);
            //计算库存金额
            storeFee = AccountWriter.YF_ComputeTotalFee(makerDic.RetailPrice, account.OverNum, account.UnitNum);
            //如果在发/退药期间调价
            if (makerDic.RetailPrice != account.RetailPrice)
            {
                //调赢
                if (makerDic.RetailPrice > account.RetailPrice)
                {
                    //账务调整
                    adjDebitFee = (account.DebitNum / Convert.ToDecimal(account.UnitNum)) *
                        (makerDic.RetailPrice - account.RetailPrice);
                    account.BalanceFee = storeFee + adjDebitFee;
                    //写发/退药台帐
                    accountDao.Add(account);
                    //写调整台帐
                    account.AccountType = 3;
                    account.DebitFee = adjDebitFee;
                    account.DebitNum = 0;
                    account.LenderNum = 0;
                    account.LenderFee = 0;
                    account.BalanceFee = storeFee;
                    accountDao.Add(account);
                }
                //调亏
                else
                {
                    //账务调整
                    adjLenderFee = (account.DebitNum / Convert.ToDecimal(account.UnitNum)) *
                        (account.RetailPrice - makerDic.RetailPrice);
                    account.BalanceFee = storeFee - adjLenderFee;
                    //写发/退药台帐
                    accountDao.Add(account);
                    //写调整台帐
                    account.AccountType = 3;
                    account.DebitFee = 0;
                    account.DebitNum = 0;
                    account.LenderNum = 0;
                    account.LenderFee = adjLenderFee;
                    account.BalanceFee = storeFee;
                    accountDao.Add(account);
                }

            }
            else
            {
                account.BalanceFee = storeFee;
                accountDao.Add(account);
            }
        }
    }
}
