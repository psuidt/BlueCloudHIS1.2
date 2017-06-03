using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.BaseData;
using System.Data;

namespace HIS.ZY_BLL.ObjectModel.AccountManager
{
    //zenghao [20100506.1.01]
    /// <summary>
    /// 未交款
    /// </summary>
    public class NotAllAccountList:AbstractAllAccount
    {
        List<ZY_BLL.DataModel.ZY_ChargeList> zyChargelist = null;
        List<ZY_BLL.DataModel.ZY_CostMaster> zyCostmaster = null;

        ChargeAllText chargeAllText;
        ChargeAllData chargeAllData;
        CostAllText costAllText;
        CostAllData costAllData;

        public NotAllAccountList() : base() { }

        public NotAllAccountList(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb) : base(_OleDb) { }

        private void GetText(List<ZY_ChargeList> zy_chargelist, List<ZY_CostMaster> zy_costmaster)
        {
            chargeAllText = new ChargeAllText();
            chargeAllData = new ChargeAllData();
            costAllText = new CostAllText();
            costAllData = new CostAllData();

            //预交金
            decimal _OrderAllFee = 0;
            int _OrderAllNum = 0;
            decimal _BackAllFee = 0;
            int _BackAllNum = 0;
            decimal _AllFee = 0;
            decimal _Menoy = 0;
            decimal _POS = 0;

            //结算
            decimal _receiveFee = 0;
            int _receiveNum = 0;
            decimal _retreatFee = 0;
            int _retreatNum = 0;

            decimal _AllFee1 = 0;
            decimal _Menoy1 = 0;
            decimal _POS1 = 0;

            decimal _costFee = 0;
            decimal _faoverFee = 0;
            decimal _deptosit_fee = 0;

            if (zy_chargelist != null && zy_chargelist.Count > 0)
            {
                _OrderAllFee = zy_chargelist.FindAll(x => x.Record_Flag != 2).Sum(x => x.Total_Fee);
                _OrderAllNum = zy_chargelist.FindAll(x => x.Record_Flag == 0).Count;
                _BackAllFee = zy_chargelist.FindAll(x => x.Record_Flag == 2).Sum(x => x.Total_Fee);
                _BackAllNum = zy_chargelist.FindAll(x => x.Record_Flag == 2).Count;
                _AllFee = zy_chargelist.Sum(x => x.Total_Fee);
                _Menoy = zy_chargelist.FindAll(x => x.FeeType == 0).Sum(x => x.Total_Fee);
                _POS = zy_chargelist.FindAll(x => x.FeeType == 1).Sum(x => x.Total_Fee);
            }

            if (zy_costmaster != null && zy_costmaster.Count > 0)
            {

                _receiveFee = zy_costmaster.FindAll(x => x.Reality_Fee >= 0).Sum(x => x.Total_Fee);
                _receiveNum = zy_costmaster.FindAll(x => x.Reality_Fee >= 0 && x.Record_Flag == 0).Count;
                _retreatFee = zy_costmaster.FindAll(x => x.Reality_Fee < 0).Sum(x => x.Total_Fee);
                _retreatNum = zy_costmaster.FindAll(x => x.Reality_Fee < 0 && x.Record_Flag == 0).Count;
                _AllFee1 = zy_costmaster.Sum(x => (x.Reality_Fee + x.Village_Fee + x.Favor_Fee));//结算金额=实收金额+记账金额+优惠金额
                _Menoy1 = zy_costmaster.Sum(x => x.Money_Fee);
                _POS1 = zy_costmaster.Sum(x => x.Pos_Fee);
                _costFee = zy_costmaster.Sum(x => x.Village_Fee);
                _faoverFee = zy_costmaster.Sum(x => x.Favor_Fee);

                _deptosit_fee = zy_costmaster.Sum(x => x.Deptosit_Fee);

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
            costAllText.lbAllFee = (_AllFee1 + _deptosit_fee).ToString();
            costAllText.deptosit_fee = _deptosit_fee.ToString();
            costAllText.lbRoundFee = "0";

            //得到树的结构
            List<string> accountCodes = new List<string>();
            for (int i = 0; i < zy_chargelist.Count; i++)
            {
                if (accountCodes.Contains(zy_chargelist[i].ChargeCode) == false)
                {
                    accountCodes.Add(zy_chargelist[i].ChargeCode);
                }
            }

            for (int j = 0; j < zy_costmaster.Count; j++)
            {
                if (accountCodes.Contains(zy_costmaster[j].ChargeCode) == false)
                {
                    accountCodes.Add(zy_costmaster[j].ChargeCode);
                }
            }


            CostEmps = new CostEmp[accountCodes.Count];
            for (int i = 0; i < CostEmps.Length; i++)
            {
                CostEmps[i].EmpID = accountCodes[i];
                CostEmps[i].EmpName = BaseNameFactory.GetName(baseNameType.用户名称, accountCodes[i]);
                //预交金
                CostEmps[i].Chargedates = new DateTime[1];
                CostEmps[i].ChargeAccountIDs = new int[1];

                CostEmps[i].Chargedates[0] = DateTime.Now;
                CostEmps[i].ChargeAccountIDs[0] = 0;

                //结算
                CostEmps[i].Costdates = new DateTime[1];
                CostEmps[i].CostAccountIDs = new int[1];

                CostEmps[i].Costdates[0] = DateTime.Now;
                CostEmps[i].CostAccountIDs[0] = 0;
            }

        }

        private void GetChargeData(List<ZY_ChargeList> zy_chargelist, List<ZY_CostMaster> zy_costmaster)
        {
            #region 第三步： 预交金的DataGrid数据
            List<ZY_ChargeList> zyChargelistW = zy_chargelist.Count > 0 ? zy_chargelist.FindAll(x => x.Record_Flag != 2) : (new List<ZY_ChargeList>());
            List<ZY_ChargeList> zyChargelistB = zy_chargelist.Count > 0 ? zy_chargelist.FindAll(x => x.Record_Flag == 2) : (new List<ZY_ChargeList>());

            List<ZY_ChargeList> zyChargelistSonW = new List<ZY_ChargeList>();
            List<ZY_ChargeList> zyChargelistSonB = new List<ZY_ChargeList>();
            //汇总预交金账单
           
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
            costAllData.CostData = null;
            #endregion
        }

        private void GetCostData(List<ZY_ChargeList> zy_chargelist, List<ZY_CostMaster> zy_costmaster)
        {
            #region 第四步：结算的DataGrid数据
            

            List<ZY_CostMaster> zyCostlistW = zy_costmaster.Count > 0 ? zy_costmaster.FindAll(x => x.Reality_Fee >= 0) : (new List<ZY_CostMaster>());
            List<ZY_CostMaster> zyCostlistB = zy_costmaster.Count > 0 ? zy_costmaster.FindAll(x => x.Reality_Fee < 0) : (new List<ZY_CostMaster>());             
           
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
            costAllData.ChargeList = null;
            costAllData.TypeCostData = null;
            costAllData.CostData = null;
            #endregion
        }

        public override void SearchData(DateTime BeginDate, DateTime EndDate)
        {
            zyChargelist = BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetListArray(" accountid=0 ");
            zyCostmaster = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(" accountid=0 ");

            GetText(zyChargelist, zyCostmaster);
            GetChargeData(zyChargelist, zyCostmaster);
            GetCostData(zyChargelist, zyCostmaster);

            ChargeAllText = chargeAllText;
            ChargeAllData = chargeAllData;
            CostAllText = costAllText;
            CostAllData = costAllData;
        }

        public override void SearchData(DateTime BeginDate, DateTime EndDate, string[] EmpIDs)
        {
            List<ZY_ChargeList> zy_chargelist = new List<ZY_ChargeList>();
            List<ZY_CostMaster> zy_costmaster = new List<ZY_CostMaster>();

            for (int i = 0; i < zyChargelist.Count; i++)
            {
                for (int k = 0; k < EmpIDs.Length; k++)
                {
                    if (zyChargelist[i].ChargeCode == EmpIDs[k])
                    {
                        zy_chargelist.Add(zyChargelist[i]);
                    }
                }
            }

            for (int i = 0; i < zyCostmaster.Count; i++)
            {
                for (int k = 0; k < EmpIDs.Length; k++)
                {
                    if (zyCostmaster[i].ChargeCode == EmpIDs[k])
                    {
                        zy_costmaster.Add(zyCostmaster[i]);
                    }
                }
            }

            GetText(zy_chargelist, zy_costmaster);
            GetChargeData(zy_chargelist, zy_costmaster);
            GetCostData(zy_chargelist, zy_costmaster);

            ChargeAllText = chargeAllText;
            ChargeAllData = chargeAllData;
            CostAllText = costAllText;
            CostAllData = costAllData;
        }

        public override void SearchData(DateTime BeginDate, DateTime EndDate, int[] AccountIDs)
        {
            throw new NotImplementedException();
        }
    }
}
