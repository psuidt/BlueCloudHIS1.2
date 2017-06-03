using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.Dao;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.ZY_BLL.DataModel;

namespace HIS.ZY_BLL.ObjectModel.AccountManager
{
    /// <summary>
    /// 预交金交款表
    /// </summary>
    public class AbstractChargeAccountRpt : IbaseDao
    {
        #region 自定义属性
        private string _交款人;

        public string 交款人
        {
            get { return _交款人; }
            set { _交款人 = value; }
        }
        private string _交款时间;

        public string 交款时间
        {
            get { return _交款时间; }
            set { _交款时间 = value; }
        }
        private string _总金额;

        public string 总金额
        {
            get { return _总金额; }
            set { _总金额 = value; }
        }
        private string _总金额大写;

        public string 总金额大写
        {
            get { return _总金额大写; }
            set { _总金额大写 = value; }
        }
        private string _现金金额;

        public string 现金金额
        {
            get { return _现金金额; }
            set { _现金金额 = value; }
        }
        private string _POS金额;

        public string POS金额
        {
            get { return _POS金额; }
            set { _POS金额 = value; }
        }

        private string _收费金额;

        public string 收费金额
        {
            get { return _收费金额; }
            set { _收费金额 = value; }
        }
        private string _收费张数;

        public string 收费张数
        {
            get { return _收费张数; }
            set { _收费张数 = value; }
        }
        private string _退费金额;

        public string 退费金额
        {
            get { return _退费金额; }
            set { _退费金额 = value; }
        }
        private string _退费张数;

        public string 退费张数
        {
            get { return _退费张数; }
            set { _退费张数 = value; }
        }

        private string _上次交款时间;

        public string 上次交款时间
        {
            get { return _上次交款时间; }
            set { _上次交款时间 = value; }
        }
        private string _医院名称;

        public string 医院名称
        {
            get { return _医院名称; }
            set { _医院名称 = value; }
        }

        private DataTable _预交金记录;

        public DataTable 预交金记录
        {
            get { return _预交金记录; }
            set { _预交金记录 = value; }
        }

        #endregion

        #region IbaseDao 成员
        private HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _oleDb;
        public HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb
        {
            get
            {
                return _oleDb;
            }
            set
            {
                _oleDb = value;
            }
        }

        public AbstractChargeAccountRpt()
        {
            _oleDb = BaseBLL.oleDb;
        }

        public AbstractChargeAccountRpt(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;
        }
        #endregion

        /// <summary>
        /// 根据交款ID得到预交金交款表对象
        /// </summary>
        /// <param name="rpt">预交金交款表对象</param>
        /// <param name="Accountid">交款ID</param>
        public void GetAccountRptInfo(AbstractChargeAccountRpt rpt, int Accountid)
        {
            ZY_Account zyAccount = new ZY_Account();
            zyAccount = zyAccount.GetAccount(Accountid);

            rpt.交款人 = zyAccount.AccountName;
            rpt.交款时间 = zyAccount.AccountDate.ToString();

            rpt.总金额 = zyAccount.Total_Fee.ToString();
            rpt.总金额大写 = zyAccount.Total_Fee.ToString();

            rpt.现金金额 = zyAccount.Cash_Fee.ToString();
            rpt.POS金额 = zyAccount.POS_Fee.ToString();

            rpt.收费金额 = zyAccount.WTicketFee.ToString();
            rpt.收费张数 = zyAccount.WTicketNum.ToString();
            rpt.退费金额 = zyAccount.BTicketFee.ToString();
            rpt.退费张数 = zyAccount.BTicketNum.ToString();


            
            rpt.上次交款时间 = zyAccount.LastDate.ToString();
            rpt.医院名称 = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;

            string[] AccountIDs = new string[1];
            AccountIDs[0] = Accountid.ToString();
            List<ZY_ChargeList> zy_Chargelist = zyAccount.GetChargeData(AccountIDs, -1);
            for (int i = 0; i < zy_Chargelist.Count; i++)
            {
                zy_Chargelist[i].ChargeType = zy_Chargelist[i].FeeType == 0 ? "现金" : "POS";
                zy_Chargelist[i].PatName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetPatName(zy_Chargelist[i].PatID);
            }
            rpt.预交金记录 = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zy_Chargelist);

        }

        /// <summary>
        /// 根据交款ID得到预交金交款表对象
        /// </summary>
        /// <param name="rpt">预交金交款表对象</param>
        /// <param name="Accountid">交款ID</param>
        public void GetAccountRptInfo(AbstractChargeAccountRpt rpt, int[] Accountids,int type)
        {
            AllAccount Account = new AllAccount();
            decimal total_fee = 0;
            decimal cash_fee = 0;
            decimal pos_fee = 0;
            decimal wticketfee = 0;
            decimal wticketnum = 0;
            decimal bticketfee = 0;
            decimal bticketnum = 0;

            CommMethod.list_AddString.Clear();
            List<ZY_Account> zyAccounts = Account.GetAccounts(Accountids, type);
            ZY_Account zyAccount = null;
            for (int i = 0; i < zyAccounts.Count; i++)
            {
                zyAccount = zyAccounts[i];

                rpt.交款人 = CommMethod.AddString(zyAccount.AccountName);
                total_fee += zyAccount.Total_Fee;
                cash_fee += zyAccount.Cash_Fee;
                pos_fee += zyAccount.POS_Fee;
                wticketfee += zyAccount.WTicketFee;
                wticketnum += zyAccount.WTicketNum;
                bticketfee += zyAccount.BTicketFee;
                bticketnum += zyAccount.BTicketNum;
            }

            rpt.交款时间 = zyAccount.AccountDate.ToString();
            rpt.总金额 = total_fee.ToString();
            rpt.总金额大写 = total_fee.ToString();

            rpt.现金金额 = cash_fee.ToString();
            rpt.POS金额 = pos_fee.ToString();

            rpt.收费金额 = wticketfee.ToString();
            rpt.收费张数 = wticketnum.ToString();
            rpt.退费金额 = bticketfee.ToString();
            rpt.退费张数 = bticketnum.ToString();

            rpt.上次交款时间 = zyAccount.LastDate.ToString();
            rpt.医院名称 = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;

            string[] AccountIDs = new string[Accountids.Length];
            for (int i = 0; i < AccountIDs.Length; i++)
            {
                AccountIDs[i] = Accountids[i].ToString();
            }
            List<ZY_ChargeList> zy_Chargelist = zyAccount.GetChargeData(AccountIDs, -1);
            for (int i = 0; i < zy_Chargelist.Count; i++)
            {
                zy_Chargelist[i].ChargeType = zy_Chargelist[i].FeeType == 0 ? "现金" : "POS";
                zy_Chargelist[i].PatName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetPatName(zy_Chargelist[i].PatID);
            }
            rpt.预交金记录 = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zy_Chargelist);

        }
    }
}
