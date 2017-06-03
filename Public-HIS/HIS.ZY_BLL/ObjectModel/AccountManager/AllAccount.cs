using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.DataModel;
using System.Data;
using HIS.ZY_BLL.ObjectModel.BaseData;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.Dao.CostManager;
using HIS.ZY_BLL.Dao;

namespace HIS.ZY_BLL.ObjectModel.AccountManager
{
    /// <summary>
    /// 住院交款表汇总类
    /// </summary>
    public class AllAccount:ZY_Account
    {
        public AllAccount()
            : base()
        {
        }

        

        /// <summary>
        /// 根据结算ID数组得到交款对象集（交款表汇总-打印结算交款表用）
        /// </summary>
        /// <param name="AccountIDs">结算ID数组</param>
        /// <returns>交款对象集</returns>
        public List<ZY_Account> GetAccounts(int[] AccountIDs,int type)
        {
            List<ZY_Account> zyAccounts = BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).GetListArray(" AccountType="+type+" and  accountid in (" + CommMethod.ToString(AccountIDs) + ")");
            for (int i = 0; i < zyAccounts.Count; i++)
                zyAccounts[i].AccountName = BaseNameFactory.GetName(baseNameType.用户名称, zyAccounts[i].AccountCode);
            return zyAccounts;
        }

        /// <summary>
        /// 根据结算ID数组得到发票汇总数据（交款表汇总-打印结算交款表用）
        /// </summary>
        /// <param name="AccountIDs"></param>
        /// <returns></returns>
        public DataTable GetTicketTotle(int[] AccountIDs)
        {
            try
            {
                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                icD.oleDb = oleDb;
                return icD.GetTicketTotle(AccountIDs);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 根据结算ID数组得到得到废票张数（交款表汇总-打印结算交款表用）
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public int GetBadTicketCount(int[] AccountIDs)
        {
            string strWhere = "ACCOUNTID in ("+CommMethod.ToString(AccountIDs)+")";
            return Convert.ToInt32(BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_BADTICKET").GetFieldValue("count(*)", strWhere));
        }

        /// <summary>
        /// 根据结算ID数组得到结算对象集（交款表汇总-打印结算交款表用）
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public List<ZY_CostMaster> GetCostData(int[] AccountIDs)
        {
            string strWhere = "ACCOUNTID in ("+CommMethod.ToString(AccountIDs)+")"  + oleDb.OrderBy("ACCOUNTID");
            return BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
        }

        /// <summary>
        ///根据结算ID数组得到预交金对象集（交款表汇总-打印结算交款表用）
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public List<ZY_ChargeList> GetChargeListData(int[] AccountIDs)
        {
            string strWhere = " DELETE_FLAG in (select costmasterid from zy_costmaster where accountid in (" + CommMethod.ToString(AccountIDs) + ") ) ";
            return BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
        }

        /// <summary>
        /// 得到应收金额（医疗收入、药品收入、其他收入）
        /// </summary>
        /// <param name="AccountID">交款ID</param>
        /// <returns></returns>
        public decimal[] GetTotleType(int[] AccountIDs)
        {
            try
            {
                //IchargeListDao icLD = DaoFactory.GetObject<IchargeListDao>(typeof(ChargeListDao));
                IcostDao icD = DaoFactory.GetObject<IcostDao>(typeof(CostDao));
                //icLD.oleDb = oleDb;
                icD.oleDb = oleDb;
                return icD.GetTotleType(AccountID);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
