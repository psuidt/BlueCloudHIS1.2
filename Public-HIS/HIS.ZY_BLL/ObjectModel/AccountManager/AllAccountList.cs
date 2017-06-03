using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.BaseData;
using System.Data;

namespace HIS.ZY_BLL.ObjectModel.AccountManager
{
    /// <summary>
    /// 已交款
    /// </summary>
    //zenghao [20100506.1.01]
    public class AllAccountList : AbstractAllAccount
    {
        ZY_Account zyAccount = new ZY_Account();
        List<ZY_Account> zyAccountlist = null;

        List<ZY_Account> zyAccountSonlistCharge = null;
        List<ZY_Account> zyAccountSonlistCost = null;
        List<string> AccountIDCharge = null;
        List<string> AccountIDCost = null;

        ChargeAllText chargeAllText ;
        ChargeAllData chargeAllData ;
        CostAllText costAllText ;
        CostAllData costAllData ;

        public AllAccountList() : base() { }
        public AllAccountList(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb) : base(_OleDb) { }

        private void GetText(List<ZY_Account> zyAccountlist, DateTime BeginDate, DateTime EndDate)
        {
            zyAccountSonlistCharge = new List<ZY_Account>();
            zyAccountSonlistCost = new List<ZY_Account>();
            AccountIDCharge = new List<string>();
            AccountIDCost = new List<string>();

            chargeAllText = new ChargeAllText();
            chargeAllData = new ChargeAllData();
            costAllText = new CostAllText();
            costAllData = new CostAllData();

            if (zyAccountlist != null && zyAccountlist.Count > 0)
            {
                //ChargeAllText chargeAllText = new ChargeAllText();
                decimal _OrderAllFee = 0;
                int _OrderAllNum = 0;
                decimal _BackAllFee = 0;
                int _BackAllNum = 0;
                decimal _AllFee = 0;
                decimal _Menoy = 0;
                decimal _POS = 0;

                //CostAllText costAllText = new CostAllText();
                decimal _receiveFee = 0;
                int _receiveNum = 0;
                decimal _retreatFee = 0;
                int _retreatNum = 0;

                decimal _AllFee1 = 0;
                decimal _Menoy1 = 0;
                decimal _POS1 = 0;

                decimal _costFee = 0;
                decimal _faoverFee = 0;


                for (int i = 0; i < zyAccountlist.Count; i++)
                {
                    ZY_Account zyAS = zyAccountlist[i];
                    zyAS.AccountName = BaseNameFactory.GetName(baseNameType.用户名称, zyAS.AccountCode);
                    if (zyAccountlist[i].AccountType == 0)//预交金
                    {
                        zyAccountSonlistCharge.Add(zyAS);
                        AccountIDCharge.Add(zyAS.AccountID.ToString());
                        _OrderAllFee += zyAS.WTicketFee;
                        _OrderAllNum += zyAS.WTicketNum;
                        _BackAllFee += zyAS.BTicketFee;
                        _BackAllNum += zyAS.BTicketNum;
                        _AllFee += zyAS.Total_Fee;
                        _Menoy += zyAS.Cash_Fee;
                        _POS += zyAS.POS_Fee;
                    }
                    else if (zyAccountlist[i].AccountType == 1)//结算
                    {
                        zyAccountSonlistCost.Add(zyAS);
                        AccountIDCost.Add(zyAS.AccountID.ToString());
                        _receiveFee += zyAS.WTicketFee;
                        _receiveNum += zyAS.WTicketNum;
                        _retreatFee += zyAS.BTicketFee;
                        _retreatNum += zyAS.BTicketNum;
                        _AllFee1 += zyAS.Total_Fee + zyAS.CostFee + zyAS.FaoverFee;
                        _Menoy1 += zyAS.Cash_Fee;
                        _POS1 += zyAS.POS_Fee;
                        _costFee += zyAS.CostFee;
                        _faoverFee += zyAS.FaoverFee;
                    }
                }

                //第二步：获取预交金和结算界面的text控件的值
                chargeAllText.OrderAllFee = _OrderAllFee.ToString();
                chargeAllText.OrderAllNum = _OrderAllNum.ToString();
                chargeAllText.BackAllFee = _BackAllFee.ToString();
                chargeAllText.BackAllNum = _BackAllNum.ToString();
                chargeAllText.AllFee = _AllFee.ToString();
                chargeAllText.Menoy = _Menoy.ToString();
                chargeAllText.POS = _POS.ToString();
                costAllText.receiveFee = _receiveFee.ToString();
                costAllText.receiveNum = _receiveNum.ToString();
                costAllText.retreatFee = _retreatFee.ToString();
                costAllText.retreatNum = _retreatNum.ToString();
                costAllText.AllFee = _AllFee1.ToString();
                costAllText.Menoy = _Menoy1.ToString();
                costAllText.POS = _POS1.ToString();
                costAllText.costFee = _costFee.ToString();
                costAllText.faoverFee = _faoverFee.ToString();
                costAllText.lbAllFee = zyAccount.GetAllChargeFee(BeginDate, EndDate, zyAccountlist).ToString("0.00");//?

                //得到树的结构
                List<string> accountCodes = new List<string>();
                for (int i = 0; i < zyAccountlist.Count; i++)
                {
                    if (accountCodes.Contains(zyAccountlist[i].AccountCode) == false)
                    {
                        accountCodes.Add(zyAccountlist[i].AccountCode);
                    }
                }

                CostEmps = new CostEmp[accountCodes.Count];
                for (int i = 0; i < CostEmps.Length; i++)
                {
                    CostEmps[i].EmpID = accountCodes[i];
                    CostEmps[i].EmpName = BaseNameFactory.GetName(baseNameType.用户名称, accountCodes[i]);
                    //预交金
                    List<ZY_Account> zyas = zyAccountSonlistCharge.FindAll(x => x.AccountCode == accountCodes[i]);
                    CostEmps[i].Chargedates = new DateTime[zyas.Count];
                    CostEmps[i].ChargeAccountIDs = new int[zyas.Count];
                    for (int j = 0; j < zyas.Count; j++)
                    {
                        //CostEmps[i].EmpName = zyas[j].AccountName;
                        CostEmps[i].Chargedates[j] = zyas[j].AccountDate;
                        CostEmps[i].ChargeAccountIDs[j] = zyas[j].AccountID;
                    }
                    //结算
                    List<ZY_Account> zyas1 = zyAccountSonlistCost.FindAll(x => x.AccountCode == accountCodes[i]);
                    CostEmps[i].Costdates = new DateTime[zyas1.Count];
                    CostEmps[i].CostAccountIDs = new int[zyas1.Count];
                    for (int j = 0; j < zyas1.Count; j++)
                    {
                        //CostEmps[i].EmpName = zyas1[j].AccountName;
                        CostEmps[i].Costdates[j] = zyas1[j].AccountDate;
                        CostEmps[i].CostAccountIDs[j] = zyas1[j].AccountID;
                    }

                }
            }
        }

        private void GetChargeData()
        {
            #region 第三步： 预交金的DataGrid数据
            List<ZY_ChargeList> zyChargelistW = AccountIDCharge.Count > 0 ? zyAccount.GetChargeData(AccountIDCharge.ToArray(), 0) : (new List<ZY_ChargeList>());
            List<ZY_ChargeList> zyChargelistB = AccountIDCharge.Count > 0 ? zyAccount.GetChargeData(AccountIDCharge.ToArray(), 1) : (new List<ZY_ChargeList>());

            List<ZY_ChargeList> zyChargelistSonW = new List<ZY_ChargeList>();
            List<ZY_ChargeList> zyChargelistSonB = new List<ZY_ChargeList>();
            //汇总预交金账单
            ZY_Account zy_AS = new ZY_Account();
            zy_AS.AccountName = "合计";
            zy_AS.WTicketFee = zyAccountSonlistCharge.Sum(x => x.WTicketFee);
            zy_AS.WTicketNum = zyAccountSonlistCharge.Sum(x => x.WTicketNum);
            zy_AS.BTicketFee = zyAccountSonlistCharge.Sum(x => x.BTicketFee);
            zy_AS.BTicketNum = zyAccountSonlistCharge.Sum(x => x.BTicketNum);
            zy_AS.Total_Fee = zyAccountSonlistCharge.Sum(x => x.Total_Fee);
            zy_AS.Cash_Fee = zyAccountSonlistCharge.Sum(x => x.Cash_Fee);
            zy_AS.POS_Fee = zyAccountSonlistCharge.Sum(x => x.POS_Fee);
            zyAccountSonlistCharge.Add(zy_AS);

            chargeAllData.ChargeData = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyAccountSonlistCharge);
            for (int i = 0; i < zyChargelistW.Count; i++)
            {
                ZY_ChargeList zyChargelistson = zyChargelistW[i];
                zyChargelistson.ChargeUserName = BaseNameFactory.GetName(baseNameType.用户名称, zyChargelistson.ChargeCode);
                zyChargelistSonW.Add(zyChargelistson);
            }
            //汇总
            ZY_ChargeList zyChargelist1 = new ZY_ChargeList();
            zyChargelist1.BillNo = "合计";
            zyChargelist1.Total_Fee = zyChargelistSonW.Sum(x => x.Total_Fee);
            zyChargelistSonW.Add(zyChargelist1);

            chargeAllData.GoodChargeList = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyChargelistSonW);

            for (int i = 0; i < zyChargelistB.Count; i++)
            {
                ZY_ChargeList zyChargelistson = zyChargelistB[i];
                zyChargelistson.ChargeUserName = BaseNameFactory.GetName(baseNameType.用户名称, zyChargelistson.ChargeCode);
                zyChargelistSonB.Add(zyChargelistson);
            }
            //汇总
            ZY_ChargeList zyChargelist2 = new ZY_ChargeList();
            zyChargelist2.BillNo = "合计";
            zyChargelist2.Total_Fee = zyChargelistSonB.Sum(x => x.Total_Fee);
            zyChargelistSonB.Add(zyChargelist2);

            chargeAllData.BadChargeList = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyChargelistSonB);
            //汇总结算
            ZY_Account zy_ASC = new ZY_Account();
            zy_ASC.AccountName = "合计";
            zy_ASC.WTicketFee = zyAccountSonlistCost.Sum(x => x.WTicketFee);
            zy_ASC.WTicketNum = zyAccountSonlistCost.Sum(x => x.WTicketNum);
            zy_ASC.BTicketFee = zyAccountSonlistCost.Sum(x => x.BTicketFee);
            zy_ASC.BTicketNum = zyAccountSonlistCost.Sum(x => x.BTicketNum);
            zy_ASC.Total_Fee = zyAccountSonlistCost.Sum(x => x.Total_Fee);
            zy_ASC.Cash_Fee = zyAccountSonlistCost.Sum(x => x.Cash_Fee);
            zy_ASC.POS_Fee = zyAccountSonlistCost.Sum(x => x.POS_Fee);
            zy_ASC.CostFee = zyAccountSonlistCost.Sum(x => x.CostFee);
            zy_ASC.FaoverFee = zyAccountSonlistCost.Sum(x => x.FaoverFee);
            zyAccountSonlistCost.Add(zy_ASC);

            costAllData.CostData = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyAccountSonlistCost);
            #endregion
        }

        private void GetCostData()
        {
            #region 第四步：结算的DataGrid数据
            costAllData.CostData = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyAccountSonlistCost);

            List<ZY_CostMaster> zyCostlistW = AccountIDCost.Count > 0 ? zyAccount.GetCostData(AccountIDCost.ToArray(), 0) : (new List<ZY_CostMaster>());
            List<ZY_CostMaster> zyCostlistB = AccountIDCost.Count > 0 ? zyAccount.GetCostData(AccountIDCost.ToArray(), 1) : (new List<ZY_CostMaster>());
            List<ZY_ChargeList> zyChargelistCost = AccountIDCost.Count > 0 ? zyAccount.GetChargeData(AccountIDCost.ToArray(), 2) : (new List<ZY_ChargeList>());
            if (AccountIDCost.Count > 0)
            {
                DataTable TypeCostData = zyAccount.GetBIGItemData(AccountIDCost.ToArray());
                DataRow dr = TypeCostData.NewRow();
                dr["itemname"] = "合计";
                decimal dec = 0;
                for (int i = 0; i < TypeCostData.Rows.Count; i++)
                {
                    dec += Convert.ToDecimal(TypeCostData.Rows[i]["total_fee"]);
                }
                dr["total_fee"] = dec;
                TypeCostData.Rows.Add(dr);//汇总
                costAllData.TypeCostData = TypeCostData;
            }
            else
            {
                costAllData.TypeCostData = null;
            }
            List<ZY_CostMaster> zyCostlistSonW = new List<ZY_CostMaster>();
            List<ZY_CostMaster> zyCostlistSonB = new List<ZY_CostMaster>();
            List<ZY_ChargeList> zyChargeSonCost = new List<ZY_ChargeList>();
            for (int i = 0; i < zyCostlistW.Count; i++)
            {
                ZY_CostMaster zyCostlistson = zyCostlistW[i];
                zyCostlistson.UserName = BaseNameFactory.GetName(baseNameType.用户名称, zyCostlistson.ChargeCode);
                zyCostlistSonW.Add(zyCostlistson);
            }
            //汇总
            ZY_CostMaster zyCostlistSonW1 = new ZY_CostMaster();
            zyCostlistSonW1.TicketNum = "合计";
            zyCostlistSonW1.Total_Fee = zyCostlistSonW.Sum(x => x.Total_Fee);
            zyCostlistSonW1.Reality_Fee = zyCostlistSonW.Sum(x => x.Reality_Fee);
            zyCostlistSonW1.Village_Fee = zyCostlistSonW.Sum(x => x.Village_Fee);
            zyCostlistSonW1.Favor_Fee = zyCostlistSonW.Sum(x => x.Favor_Fee);
            zyCostlistSonW.Add(zyCostlistSonW1);

            costAllData.GoodCostList = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyCostlistSonW);

            for (int i = 0; i < zyCostlistB.Count; i++)
            {
                ZY_CostMaster zyCostlistson = zyCostlistB[i];
                zyCostlistson.UserName = BaseNameFactory.GetName(baseNameType.用户名称, zyCostlistson.ChargeCode);
                zyCostlistSonB.Add(zyCostlistson);
            }
            //汇总
            ZY_CostMaster zyCostlistSonB1 = new ZY_CostMaster();
            zyCostlistSonB1.TicketNum = "合计";
            zyCostlistSonB1.Total_Fee = zyCostlistSonB.Sum(x => x.Total_Fee);
            zyCostlistSonB1.Reality_Fee = zyCostlistSonB.Sum(x => x.Reality_Fee);
            zyCostlistSonB1.Village_Fee = zyCostlistSonB.Sum(x => x.Village_Fee);
            zyCostlistSonB1.Favor_Fee = zyCostlistSonB.Sum(x => x.Favor_Fee);
            zyCostlistSonB.Add(zyCostlistSonB1);

            costAllData.BadCostList = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyCostlistSonB);

            for (int i = 0; i < zyChargelistCost.Count; i++)
            {
                ZY_ChargeList zyChargelistson = zyChargelistCost[i];
                zyChargelistson.ChargeUserName = BaseNameFactory.GetName(baseNameType.用户名称, zyChargelistson.ChargeCode);
                zyChargeSonCost.Add(zyChargelistson);
            }
            //汇总
            ZY_ChargeList zyChargeSonCost1 = new ZY_ChargeList();
            zyChargeSonCost1.BillNo = "合计";
            zyChargeSonCost1.Total_Fee = zyChargeSonCost.Sum(x => x.Total_Fee);
            zyChargeSonCost.Add(zyChargeSonCost1);

            costAllData.ChargeList = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyChargeSonCost);

            costAllText.deptosit_fee = Convert.ToString(zyCostlistW.Sum(x => x.Deptosit_Fee) + zyCostlistB.Sum(x => x.Deptosit_Fee));
            costAllText.lbRoundFee = Convert.ToString(Convert.ToDecimal(CostAllText.lbAllFee) - Convert.ToDecimal(CostAllText.deptosit_fee) - Convert.ToDecimal(CostAllText.AllFee));



            #endregion
        }

        public override void SearchData(DateTime BeginDate, DateTime EndDate)
        {
            //第一步：得到交款表的数据
            zyAccountlist = zyAccount.GetAllData(BeginDate, EndDate);

            if (zyAccountlist.Count > 0)
            {
                GetText(zyAccountlist, BeginDate, EndDate);
                GetChargeData();
                GetCostData();

                ChargeAllText = chargeAllText;
                ChargeAllData = chargeAllData;
                CostAllText = costAllText;
                CostAllData = costAllData;
            }
            else
            {
                ChargeAllData = new ChargeAllData();
                ChargeAllText = new ChargeAllText();
                CostAllText = new CostAllText();
                CostAllData = new CostAllData();
                CostEmps = new CostEmp[0];
            }
        }

        public override void SearchData(DateTime BeginDate, DateTime EndDate, string[] EmpIDs)
        {
            List<ZY_Account> zyAccountlist1 = zyAccountlist.FindAll(x => EmpIDs.Contains(x.AccountCode));
            if (zyAccountlist1.Count > 0)
            {
                GetText(zyAccountlist1, BeginDate, EndDate);
                GetChargeData();
                GetCostData();

                ChargeAllText = chargeAllText;
                ChargeAllData = chargeAllData;
                CostAllText = costAllText;
                CostAllData = costAllData;
            }
            else
            {
                ChargeAllData = new ChargeAllData();
                ChargeAllText = new ChargeAllText();
                CostAllText = new CostAllText();
                CostAllData = new CostAllData();
                CostEmps = new CostEmp[0];
            }
        }

        public override void SearchData(DateTime BeginDate, DateTime EndDate, int[] AccountIDs)
        {
            if (zyAccountlist != null)
            {
                List<ZY_Account> zyAccountlist1 = zyAccountlist.FindAll(x => AccountIDs.Contains(x.AccountID));
                if (zyAccountlist1.Count > 0)
                {
                    GetText(zyAccountlist1, BeginDate, EndDate);
                    GetChargeData();
                    GetCostData();

                    ChargeAllText = chargeAllText;
                    ChargeAllData = chargeAllData;
                    CostAllText = costAllText;
                    CostAllData = costAllData;
                }
                else
                {
                    ChargeAllData = new ChargeAllData();
                    ChargeAllText = new ChargeAllText();
                    CostAllText = new CostAllText();
                    CostAllData = new CostAllData();
                    CostEmps = new CostEmp[0];
                }
            }
        }
    }
}
