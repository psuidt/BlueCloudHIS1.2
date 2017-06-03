using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.Dao;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS.ZY_BLL.ObjectModel.AccountManager
{
    /// <summary>
    /// 结算交款表记账内容
    /// </summary>
    public struct AccountPatType
    {
        public string TypeName;
        public string CostNum;
        public string CostFee;
    }
    /// <summary>
    /// 结算交款表
    /// </summary>
    public class AbstractCostAccountRpt : IbaseDao
    {
        #region 自定义属性
        private string _医院名称;

        public string 医院名称
        {
            get { return _医院名称; }
            set { _医院名称 = value; }
        }
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
        private string _上次交款时间;

        public string 上次交款时间
        {
            get { return _上次交款时间; }
            set { _上次交款时间 = value; }
        }

        private DataTable _发票项目;

        public DataTable 发票项目
        {
            get { return _发票项目; }
            set { _发票项目 = value; }
        }

        private string _发票科目合计;

        public string 发票科目合计
        {
            get { return _发票科目合计; }
            set { _发票科目合计 = value; }
        }

        private string _收费发票开始号;

        public string 收费发票开始号
        {
            get { return _收费发票开始号; }
            set { _收费发票开始号 = value; }
        }
        private string _收费发票结束号;

        public string 收费发票结束号
        {
            get { return _收费发票结束号; }
            set { _收费发票结束号 = value; }
        }
        private string _收费发票张数;

        public string 收费发票张数
        {
            get { return _收费发票张数; }
            set { _收费发票张数 = value; }
        }

        private string _收费退费张数;

        public string 收费退费张数
        {
            get { return _收费退费张数; }
            set { _收费退费张数 = value; }
        }
        private string _收费退费金额;

        public string 收费退费金额
        {
            get { return _收费退费金额; }
            set { _收费退费金额 = value; }
        }
        private string _废票张数;

        public string 废票张数
        {
            get { return _废票张数; }
            set { _废票张数 = value; }
        }

        private AccountPatType[] _记账内容;

        public AccountPatType[] 记账内容
        {
            get { return _记账内容; }
            set { _记账内容 = value; }
        }

        private string _优惠金额;

        public string 优惠金额
        {
            get { return _优惠金额; }
            set { _优惠金额 = value; }
        }
        private string _应收金额;

        public string 应收金额
        {
            get { return _应收金额; }
            set { _应收金额 = value; }
        }
        private string _预收金额;

        public string 预收金额
        {
            get { return _预收金额; }
            set { _预收金额 = value; }
        }
        private string _预交金现金;

        public string 预交金现金
        {
            get { return _预交金现金; }
            set { _预交金现金 = value; }
        }
        private string _预交金POS;

        public string 预交金POS
        {
            get { return _预交金POS; }
            set { _预交金POS = value; }
        }

        private string _补收金额;

        public string 补收金额
        {
            get { return _补收金额; }
            set { _补收金额 = value; }
        }
        private string _补收金额现金;

        public string 补收金额现金
        {
            get { return _补收金额现金; }
            set { _补收金额现金 = value; }
        }
        private string _补收金额POS;

        public string 补收金额POS
        {
            get { return _补收金额POS; }
            set { _补收金额POS = value; }
        }
        private string _补退金额;

        public string 补退金额
        {
            get { return _补退金额; }
            set { _补退金额 = value; }
        }
        private string _实收金额;

        public string 实收金额
        {
            get { return _实收金额; }
            set { _实收金额 = value; }
        }
        private string _欠费金额;

        public string 欠费金额
        {
            get { return _欠费金额; }
            set { _欠费金额 = value; }
        }

        private string _小写合计;

        public string 小写合计
        {
            get { return _小写合计; }
            set { _小写合计 = value; }
        }
        private string _大写合计;

        public string 大写合计
        {
            get { return _大写合计; }
            set { _大写合计 = value; }
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

        public AbstractCostAccountRpt()
        {
            _oleDb = BaseBLL.oleDb;
        }

        public AbstractCostAccountRpt(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;
        }
        #endregion
        /// <summary>
        /// 根据交款ID得到结算交款表对象
        /// </summary>
        /// <param name="rpt">结算交款表对象</param>
        /// <param name="Accountid">交款ID</param>
        public void GetAccountRptInfo(AbstractCostAccountRpt rpt, int Accountid)
        {
            ZY_Account zyAccount = new ZY_Account();
            zyAccount = zyAccount.GetAccount(Accountid);
            rpt.医院名称 = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "住院每日缴款清单";
            rpt.交款人 = zyAccount.AccountName;
            rpt.交款时间 = zyAccount.AccountDate.ToString();

            #region 发票项目
            DataTable dt = zyAccount.GetTicketTotle(Accountid);
            decimal AllKMFee = 0;
            //dt = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AllKMFee += Convert.ToDecimal(dt.Rows[i]["Tolal_Fee"]);
            }


            #endregion
            rpt.发票项目 = dt;
            rpt.发票科目合计 = AllKMFee.ToString();
            List<ZY_CostMaster> zy_CML = zyAccount.GetCostData(Accountid);
            if (zy_CML != null && zy_CML.Count > 0)
            {


                #region 收费票据

                rpt.收费发票开始号 = zy_CML[0].TicketCode;
                rpt.收费发票结束号 = zy_CML[zy_CML.Count - 1].TicketCode;
                rpt.收费发票张数 = zy_CML.Count.ToString();
                List<ZY_CostMaster> zy_CMLx = zy_CML.FindAll(delegate(ZY_CostMaster x) { return x.Record_Flag == 2; });
                rpt.收费退费张数 = zy_CMLx.Count.ToString();
                rpt.收费退费金额 = zy_CMLx.Sum(x => x.Total_Fee).ToString();
                rpt.废票张数 = zyAccount.GetBadTicketCount(Accountid).ToString();
                #endregion

                #region 记账部分
                DataTable dt1 = BaseDataFactory.GetData(baseDataType.病人类型);
                List<AccountPatType> apts = new List<AccountPatType>();
                AccountPatType apt;
                int AllNum=0;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    List<ZY_CostMaster> zy_CMLy = zy_CML.FindAll(delegate(ZY_CostMaster y) { return (y.PatType.Trim() == dt1.Rows[i]["code"].ToString()); });
                    apt = new AccountPatType();
                    apt.TypeName = dt1.Rows[i]["name"].ToString();
                    apt.CostNum = zy_CMLy.Count.ToString();
                    apt.CostFee = zy_CMLy.Sum(x => x.NotWorkUnit_Fee).ToString();
                    apts.Add(apt);
                    AllNum += zy_CMLy.Count;
                }

                apt = new AccountPatType();
                //单位
                List<ZY_CostMaster> zy_CMLy5 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.WorkUnit_Fee != 0; });
                apt.TypeName = "单位";
                apt.CostNum = zy_CMLy5.Count.ToString();
                apt.CostFee = zy_CMLy5.Sum(y => y.WorkUnit_Fee).ToString();
                apts.Add(apt);
                //合计
                apt = new AccountPatType();
                apt.TypeName = "合计";
                apt.CostNum = (AllNum + zy_CMLy5.Count).ToString();
                apt.CostFee = zy_CML.Sum(y => y.Village_Fee).ToString();
                apts.Add(apt);

                rpt.记账内容 = apts.ToArray();

                #endregion

                #region 收现金

                rpt.优惠金额 = zy_CML.Sum(z => z.Favor_Fee).ToString();
                rpt.应收金额 = zy_CML.Sum(z => z.Self_Fee).ToString();
                rpt.预收金额 = zy_CML.Sum(z => z.Deptosit_Fee).ToString();
                decimal decR = zy_CML.Sum(z => z.Reality_Fee);
                //补收
                List<ZY_CostMaster> zy_CML11 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.Reality_Fee > 0; });
                //补退
                List<ZY_CostMaster> zy_CML22 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.Reality_Fee < 0; });
                //欠费
                List<ZY_CostMaster> zy_CML33 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.Ntype == 3; });

                rpt.补收金额 = zy_CML11.Sum(x => x.Reality_Fee).ToString("0.00");
                rpt.补退金额 = (0 - zy_CML22.Sum(x => x.Reality_Fee)).ToString("0.00");
                rpt.实收金额 = decR.ToString();
                rpt.小写合计 = decR.ToString();
                rpt.大写合计 = decR.ToString();

                List<ZY_ChargeList> zy_cl = zyAccount.GetChargeListData(Accountid);
                //现金
                List<ZY_ChargeList> zy_cl0 = zy_cl.FindAll(x => x.FeeType == 0);
                //POS
                List<ZY_ChargeList> zy_cl1 = zy_cl.FindAll(x => x.FeeType == 1);
                rpt.预交金现金 = zy_cl0.Sum(x => x.Total_Fee).ToString();
                rpt.预交金POS = zy_cl1.Sum(x => x.Total_Fee).ToString();
                rpt.补收金额现金 = zy_CML11.Sum(x => x.Money_Fee).ToString();
                rpt.补收金额POS = zy_CML11.Sum(x => x.Pos_Fee).ToString();
                rpt.欠费金额 = zy_CML33.Sum(x => (x.Self_Fee - x.Deptosit_Fee)).ToString();
                #endregion

            }
        }

        /// <summary>
        /// 根据交款ID得到结算交款表对象
        /// </summary>
        /// <param name="rpt">结算交款表对象</param>
        /// <param name="Accountid">交款ID</param>
        public void GetAccountRptInfo(AbstractCostAccountRpt rpt, int[] Accountids,int type)
        {
            AllAccount zyAccount = new AllAccount();
            List<ZY_Account> zyAccounts = zyAccount.GetAccounts(Accountids,type);
            CommMethod.list_AddString.Clear();
            for (int i = 0; i < zyAccounts.Count; i++)
            {
                rpt.交款人 = CommMethod.AddString(zyAccounts[i].AccountName);
            }

            rpt.医院名称 = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "住院每日缴款清单";
            rpt.交款时间 = zyAccounts[0].AccountDate.ToString();

            #region 发票项目
            DataTable dt = zyAccount.GetTicketTotle(Accountids);
            decimal AllKMFee = 0;
            //dt = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AllKMFee += Convert.ToDecimal(dt.Rows[i]["Tolal_Fee"]);
            }


            #endregion
            rpt.发票项目 = dt;
            rpt.发票科目合计 = AllKMFee.ToString();
            List<ZY_CostMaster> zy_CML = zyAccount.GetCostData(Accountids);
            if (zy_CML != null && zy_CML.Count > 0)
            {


                #region 收费票据

                rpt.收费发票开始号 = zy_CML[0].TicketCode;
                rpt.收费发票结束号 = zy_CML[zy_CML.Count - 1].TicketCode;
                rpt.收费发票张数 = zy_CML.Count.ToString();
                List<ZY_CostMaster> zy_CMLx = zy_CML.FindAll(delegate(ZY_CostMaster x) { return x.Record_Flag == 2; });
                rpt.收费退费张数 = zy_CMLx.Count.ToString();
                rpt.收费退费金额 = zy_CMLx.Sum(x => x.Total_Fee).ToString();
                rpt.废票张数 = zyAccount.GetBadTicketCount(Accountids).ToString();
                #endregion

                #region 记账部分
                DataTable dt1 = BaseDataFactory.GetData(baseDataType.病人类型);
                List<AccountPatType> apts = new List<AccountPatType>();
                AccountPatType apt;
                int AllNum = 0;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    List<ZY_CostMaster> zy_CMLy = zy_CML.FindAll(delegate(ZY_CostMaster y) { return (y.PatType.Trim() == dt1.Rows[i]["code"].ToString()); });
                    apt = new AccountPatType();
                    apt.TypeName = dt1.Rows[i]["name"].ToString();
                    apt.CostNum = zy_CMLy.Count.ToString();
                    apt.CostFee = zy_CMLy.Sum(x => x.NotWorkUnit_Fee).ToString();
                    apts.Add(apt);
                    AllNum += zy_CMLy.Count;
                }

                apt = new AccountPatType();
                //单位
                List<ZY_CostMaster> zy_CMLy5 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.WorkUnit_Fee != 0; });
                apt.TypeName = "单位";
                apt.CostNum = zy_CMLy5.Count.ToString();
                apt.CostFee = zy_CMLy5.Sum(y => y.WorkUnit_Fee).ToString();
                apts.Add(apt);
                //合计
                apt = new AccountPatType();
                apt.TypeName = "合计";
                apt.CostNum = (AllNum + zy_CMLy5.Count).ToString();
                apt.CostFee = zy_CML.Sum(y => y.Village_Fee).ToString();
                apts.Add(apt);

                rpt.记账内容 = apts.ToArray();

                #endregion

                #region 收现金

                rpt.优惠金额 = zy_CML.Sum(z => z.Favor_Fee).ToString();
                rpt.应收金额 = zy_CML.Sum(z => z.Self_Fee).ToString();
                rpt.预收金额 = zy_CML.Sum(z => z.Deptosit_Fee).ToString();
                decimal decR = zy_CML.Sum(z => z.Reality_Fee);
                //补收
                List<ZY_CostMaster> zy_CML11 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.Reality_Fee > 0; });
                //补退
                List<ZY_CostMaster> zy_CML22 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.Reality_Fee < 0; });
                //欠费
                List<ZY_CostMaster> zy_CML33 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.Ntype == 3; });

                rpt.补收金额 = zy_CML11.Sum(x => x.Reality_Fee).ToString("0.00");
                rpt.补退金额 = (0 - zy_CML22.Sum(x => x.Reality_Fee)).ToString("0.00");
                rpt.实收金额 = decR.ToString();
                rpt.小写合计 = decR.ToString();
                rpt.大写合计 = decR.ToString();

                List<ZY_ChargeList> zy_cl = zyAccount.GetChargeListData(Accountids);
                //现金
                List<ZY_ChargeList> zy_cl0 = zy_cl.FindAll(x => x.FeeType == 0);
                //POS
                List<ZY_ChargeList> zy_cl1 = zy_cl.FindAll(x => x.FeeType == 1);
                rpt.预交金现金 = zy_cl0.Sum(x => x.Total_Fee).ToString();
                rpt.预交金POS = zy_cl1.Sum(x => x.Total_Fee).ToString();
                rpt.补收金额现金 = zy_CML11.Sum(x => x.Money_Fee).ToString();
                rpt.补收金额POS = zy_CML11.Sum(x => x.Pos_Fee).ToString();
                rpt.欠费金额 = zy_CML33.Sum(x => (x.Self_Fee - x.Deptosit_Fee)).ToString();
                #endregion

            }
        }
    }
}
