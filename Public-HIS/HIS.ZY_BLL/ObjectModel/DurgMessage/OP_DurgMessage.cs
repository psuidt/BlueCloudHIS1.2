using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.Dao.SendDrugMessage;
using HIS.ZY_BLL.Dao;

namespace HIS.ZY_BLL.DurgMessage
{
    public class OP_DurgMessage : BaseBLL
    {
       


        /// <summary>
        /// 得到统领单头信息
        /// </summary>
        /// <param name="IsDrug"></param>
        /// <param name="deptcode">统领科室</param>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        /// <returns></returns>
        public static DataTable GetMessageMaster(bool IsDrug, string deptcode, DateTime? Bdate, DateTime? Edate,bool _IsOper)
        {
            string strWhere = "";
            if (IsDrug)//未发药
            {
                strWhere += "  drugmessageid in (select masterid from zy_drugmessage_order where disp_flag=0)";
            }
            else//已发药
            {
                strWhere += "  drugmessageid in (select masterid from zy_drugmessage_order where disp_flag=1)";
            }

            if (deptcode != null)
            {
                strWhere += " and PRESDEPTID=" + deptcode;
            }
            if (Bdate != null && Edate != null)
            {
                strWhere += " and date(SENDTIME)>='" + Bdate.Value.Date + "' and date(SENDTIME)<='" + Edate.Value.Date + "'";
            }
            //[20100514.1.04]
            if (_IsOper == true)
            {
                strWhere += " and StatType=2 ";
            }
            strWhere += " order by DRUGMESSAGEID desc";
            string[] fields = new string[] { "DRUGMESSAGEID", "SENDTIME", "PRESDEPTID", "DISPDEPT", "DR_FLAG", "MESSAGETYPE", "SENDER", "SENDERNAME", "STATTYPE" };
            return BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_MASTER").GetList(strWhere, fields);
        }

        /// <summary>
        /// 得到统领单明细
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable GetMessageOrder(DataTable dt, bool IsDrug)
        {
            //bool isDurg = true;//发退药

            //isDurg=Convert.ToInt32(dt[])

            DataRow[] drs1 = dt.Select("DR_FLAG=1");//发药
            DataRow[] drs2 = dt.Select("DR_FLAG=0");//退药

            DataTable Data1 = null;
            DataTable Data2 = null;

            #region 领药
            if (drs1.Length > 0)
            {
                string strWhere = null;
                DataTable ddt = null;
                if (IsDrug)//未发药
                {
                    strWhere = " disp_flag=0 ";
                }
                else//已发药
                {
                    strWhere = " disp_flag=1 ";
                }

                strWhere += " and MASTERID in (";
                for (int i = 0; i < drs1.Length; i++)
                {
                    if (i != drs1.Length - 1)
                        strWhere += drs1[i]["DRUGMESSAGEID"].ToString() + ",";
                    else
                        strWhere += drs1[i]["DRUGMESSAGEID"].ToString() + ")";
                }
                strWhere += oleDb.OrderBy("dosename");
                ddt = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").GetList(strWhere);

                if (IsDrug)//未发药的要重新计算?
                {
                    DataTable _dt = ddt.Clone();
                    for (int i = 0; i < ddt.Rows.Count; i++)
                    {
                        try
                        {
                            int orderid = Convert.ToInt32(ddt.Rows[i]["ORDERRECIPEID"]);

                            List<ZY_PresOrder> zyPlist = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray("CHARGE_FLAG=1 and DRUG_FLAG=0 and RECORD_FLAG in(0,1) and (PRESORDERID=" + orderid + " or oldid=" + orderid + ")");
                            ZY_PresOrder zyPL1 = zyPlist.Find(delegate(ZY_PresOrder y) { return (y.OldID == 0 && y.Record_Flag == 0); });
#if DEBUG
                        if (zyPL1 == null)
                        {
                            zyPL1.Amount = zyPL1.Amount;
                        }
#endif
                            List<ZY_PresOrder> zyPL2 = zyPlist.FindAll(delegate(ZY_PresOrder y) { return (y.OldID != 0 && y.Record_Flag == 1); });

                            decimal amount = zyPL2.Sum(y => y.Amount);
                            int presamount = zyPL2.Sum(y => y.PresAmount);
                            decimal total_fee = zyPL2.Sum(y => y.Tolal_Fee);

                            zyPL1.Amount += amount;
                            zyPL1.PresAmount += presamount;
                            //zyPL1.Tolal_Fee += total_fee;

                            int SmallNum = Convert.ToInt32(zyPL1.Amount) % Convert.ToInt32(zyPL1.RelationNum);
                            int BigNum = Convert.ToInt32((zyPL1.Amount - SmallNum) / zyPL1.RelationNum);
                            decimal fee = BigNum * zyPL1.Sell_Price + SmallNum * zyPL1.Sell_Price / zyPL1.RelationNum;
                            ddt.Rows[i]["DRUGNUM"] = zyPL1.Amount;
                            ddt.Rows[i]["RECIPENUM"] = zyPL1.PresAmount;
                            ddt.Rows[i]["RETAILFEE"] = fee;

                            if (zyPL1.Amount > 0)
                            {
                                _dt.Rows.Add(ddt.Rows[i].ItemArray);
                            }
                        }
                        catch (Exception err)
                        {
                            throw new Exception("插入的统领费用明细与费用表记录不一致！");
                        }
                    }
                    Data1 = _dt;

                }
                else//已发药的数量直接返回消息表的数量
                {
                    Data1 = ddt;
                }
            }

            #endregion
            #region 退药
            if (drs2.Length > 0)
            {
                string strWhere = null;
                if (IsDrug)//未发药
                {
                    strWhere = " disp_flag=0 ";
                }
                else//已发药
                {
                    strWhere = " disp_flag=1 ";
                }

                strWhere += " and MASTERID in (";

                for (int i = 0; i < drs2.Length; i++)
                {
                    if (i != drs2.Length - 1)
                        strWhere += drs2[i]["DRUGMESSAGEID"].ToString() + ",";
                    else
                        strWhere += drs2[i]["DRUGMESSAGEID"].ToString() + ")";
                }
                strWhere += oleDb.OrderBy("dosename");
                DataTable ddt = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").GetList(strWhere);
                if (IsDrug)//未发药的要重新计算?
                {
                    DataTable _dt = ddt.Clone();
                    for (int i = 0; i < ddt.Rows.Count; i++)
                    {
                        int orderid = Convert.ToInt32(ddt.Rows[i]["ORDERRECIPEID"]);

                        bool b = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists("CHARGE_FLAG=1 and DRUG_FLAG=1 and RECORD_FLAG =2 and  oldid=" + orderid + "");
                        if (!b)
                        {
                            int num = Convert.ToInt32(ddt.Rows[i]["DRUGNUM"]);
                            int RelationNum = Convert.ToInt32(ddt.Rows[i]["UNITNUM"]);
                            decimal Sell_Price = Convert.ToDecimal(ddt.Rows[i]["RETAILPRICE"]);
                            int SmallNum = Convert.ToInt32(num) % Convert.ToInt32(RelationNum);
                            int BigNum = Convert.ToInt32((num - SmallNum) / RelationNum);
                            decimal fee = BigNum * Sell_Price + SmallNum * Sell_Price / RelationNum;
                            ddt.Rows[i]["RETAILFEE"] = fee;
                            _dt.Rows.Add(ddt.Rows[i].ItemArray);
                        }
                    }
                    Data2 = _dt;
                }
                else
                {
                    Data2 = ddt;
                }
            }
            #endregion
            #region 合并
            if (Data1 != null && Data2 != null)
            {
                DataRow[] drs = Data2.Select();
                for (int i = 0; i < drs.Length; i++)
                {
                    Data1.Rows.Add(drs[i].ItemArray);
                }
                return Data1;
            }
            else if (Data1 == null && Data2 != null)
            {
                return Data2;
            }
            else if (Data1 != null && Data2 == null)
            {
                return Data1;
            }
            else
            {
                return null;
            }
            #endregion
        }

        public static DataTable GetMessageOrder()
        {
            return BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").GetList("disp_flag=0");
        }

        public static DataTable GetYfDept()
        {
            return BindEntity<object>.CreateInstanceDAL(oleDb, "YP_DeptDic").GetList("depttype1='药房' order by deptid", "trim(deptname) as name", "deptid as code");
        }

        public static DataTable GetYfData()
        {

            IsendDrugMessage isdmD = DaoFactory.GetObject<IsendDrugMessage>(typeof(SendDrugMessageDao));
            isdmD.oleDb = oleDb;
            return isdmD.GetYfData();
        }
        //用法名称
        public static DataTable GetUsageName()
        {
            IsendDrugMessage isdmD = DaoFactory.GetObject<IsendDrugMessage>(typeof(SendDrugMessageDao));
            isdmD.oleDb = oleDb;
            return isdmD.GetUsageName();
        }

        //区分0口服1非口服
        public static string GetDrugType(int order_id, DataTable UsageData)
        {
            string strWhere = " order_id=" + order_id;
            object obj = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DOC_ORDERRECORD").GetFieldValue("order_usage", strWhere);
            if (obj != null)
            {
                DataRow[] drs = UsageData.Select("name='" + obj.ToString() + "'");
                if (drs.Length > 0)
                {
                    return "口服";
                }
            }
            return "非口服";
        }

        public static List<ZY_PresOrder> GetPresOrder(string strWhere, bool IsDrug)
        {
            List<ZY_PresOrder> zyPlist = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            if (IsDrug)
            {
                List<ZY_PresOrder> zyPL1 = zyPlist.FindAll(delegate(ZY_PresOrder y) { return (y.OldID == 0 && y.Record_Flag == 0); });
                List<ZY_PresOrder> zyPL2 = zyPlist.FindAll(delegate(ZY_PresOrder y) { return (y.OldID != 0 && y.Record_Flag == 1); });
                List<ZY_PresOrder> zyPL3 = new List<ZY_PresOrder>();
                for (int i = 0; i < zyPL1.Count; i++)
                {
                    List<ZY_PresOrder> zyPL21 = zyPL2.FindAll(delegate(ZY_PresOrder y) { return (y.OldID == zyPL1[i].PresOrderID); });
                    decimal amount = zyPL21.Sum(y => y.Amount);
                    int presamount = zyPL21.Sum(y => y.PresAmount);
                    decimal total_fee = zyPL21.Sum(y => y.Tolal_Fee);

                    zyPL1[i].Amount += amount;
                    zyPL1[i].PresAmount += presamount;
                    zyPL1[i].Tolal_Fee += total_fee;

                    if (zyPL1[i].Amount > 0)//过滤掉已经全部冲完了的药品（数量为0的不显示）
                    {
                        zyPL3.Add(zyPL1[i]);
                    }
                }

                return zyPL3;
            }
            else
            {
                return zyPlist;
            }
        }

        public static List<ZY_PresOrder> GetPresOrder(string strWhere)
        {
            List<ZY_PresOrder> zyPlist = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            for (int i = 0; i < zyPlist.Count; i++)
            {
                bool b = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").Exists("ORDERRECIPEID=" + zyPlist[i].PresOrderID);
                if (b == true)
                {
                    zyPlist.RemoveAt(i);
                    i--;
                }
            }
            return zyPlist;

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="MasterID"></param>
        public static bool DelMessage(int MasterID)
        {

            string strWhere = "disp_flag=1 and  MASTERID=" + MasterID;
            bool b = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").Exists(strWhere);

            if (b)
            {
                strWhere = "disp_flag=0 and  MASTERID=" + MasterID;
                DataTable ddt = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").GetList(strWhere);

                if (ddt != null && ddt.Rows.Count > 0)
                {
                    for (int i = 0; i < ddt.Rows.Count; i++)
                    {
                        int orderid = Convert.ToInt32(ddt.Rows[i]["ORDERRECIPEID"]);

                        List<ZY_PresOrder> zyPlist = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray("CHARGE_FLAG=1 and DRUG_FLAG=0 and RECORD_FLAG in(0,1) and (PRESORDERID=" + orderid + " or oldid=" + orderid + ")");
                        ZY_PresOrder zyPL1 = zyPlist.Find(delegate(ZY_PresOrder y) { return (y.OldID == 0 && y.Record_Flag == 0); });
                        List<ZY_PresOrder> zyPL2 = zyPlist.FindAll(delegate(ZY_PresOrder y) { return (y.OldID != 0 && y.Record_Flag == 1); });

                        decimal amount = zyPL2.Sum(y => y.Amount);
                        int presamount = zyPL2.Sum(y => y.PresAmount);
                        decimal total_fee = zyPL2.Sum(y => y.Tolal_Fee);

                        zyPL1.Amount += amount;
                        zyPL1.PresAmount += presamount;
                        //zyPL1.Tolal_Fee += total_fee;

                        int SmallNum = Convert.ToInt32(zyPL1.Amount) % Convert.ToInt32(zyPL1.RelationNum);
                        int BigNum = Convert.ToInt32((zyPL1.Amount - SmallNum) / zyPL1.RelationNum);
                        decimal fee = BigNum * zyPL1.Sell_Price + SmallNum * zyPL1.Sell_Price / zyPL1.RelationNum;
                        ddt.Rows[i]["DRUGNUM"] = zyPL1.Amount;
                        ddt.Rows[i]["RECIPENUM"] = zyPL1.PresAmount;
                        ddt.Rows[i]["RETAILFEE"] = fee;

                        if (zyPL1.Amount > 0)
                        {
                            return false;
                        }
                    }
                    try
                    {
                        oleDb.BeginTransaction();
                        BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").Update("masterid=" + MasterID, "disp_flag=1");
                        //BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_MASTER").Delete("DRUGMESSAGEID=" + MasterID);
                        oleDb.CommitTransaction();
                    }
                    catch (Exception e)
                    {
                        oleDb.RollbackTransaction();
                        throw e;
                    }
                }
            }
            else
            {

                try
                {
                    oleDb.BeginTransaction();
                    BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").Delete("masterid=" + MasterID);
                    BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_MASTER").Delete("DRUGMESSAGEID=" + MasterID);
                    oleDb.CommitTransaction();
                }
                catch (Exception e)
                {
                    oleDb.RollbackTransaction();
                    throw e;
                }
            }
            return true;
        }
       


        /// <summary>
        /// 一键发送消息
        /// </summary>
        /// <param name="Stype">统领类型（0：全部  药品 1：非口服长期2：非口服临时3：口服  长期4：口服  临时5：手术  用药6：退药  长期7：退药  临时）</param>
        /// <param name="deptId">护士操作科室</param>
        public static void OneKeySendDrug(int Stype, string deptId, string _EmployeeID, string _currentUserName,DataTable dtDrugMessage,bool _IsOper)
        {
            //[20100514.1.04]
            if (Stype == 0 && _IsOper==true)
            {
                GetStatData(5, deptId, _EmployeeID, _currentUserName, dtDrugMessage); 
            }
            else if (Stype == 0 && _IsOper == false)
            {
                GetStatData(1, deptId, _EmployeeID, _currentUserName, dtDrugMessage);
                GetStatData(2, deptId, _EmployeeID, _currentUserName, dtDrugMessage);
                GetStatData(3, deptId, _EmployeeID, _currentUserName, dtDrugMessage);
                GetStatData(4, deptId, _EmployeeID, _currentUserName, dtDrugMessage);
                //GetStatData(5, deptId, _EmployeeID, _currentUserName, dtDrugMessage); 手术用药进手术科室统领
                GetStatData(6, deptId, _EmployeeID, _currentUserName, dtDrugMessage);
                GetStatData(7, deptId, _EmployeeID, _currentUserName, dtDrugMessage);
            }
            else
            {
                GetStatData(Stype, deptId, _EmployeeID, _currentUserName, dtDrugMessage);
            }
        }

        public static DataTable GetPatInfo(int patlistid)
        {
            DataTable obj = BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetList("patlistid=" + patlistid,"bedcode","Cureno");
            if (obj != null)
            {
               return obj;
            }
            return null;
        }

        public static DataTable GetPatInfoData(List<ZY_PresOrder> zyPOList)
        {
            List<int> patlistIds = new List<int>();
            for (int i = 0; i < zyPOList.Count; i++)
            {
                if (patlistIds.Count == 0)
                {
                    patlistIds.Add(zyPOList[i].PatListID);
                }
                else
                {
                    for (int k = 0; k < patlistIds.Count; k++)
                    {
                        if (zyPOList[i].PatListID == patlistIds[k])
                        {
                            break;
                        }
                        if (k == patlistIds.Count - 1)
                        {
                            patlistIds.Add(zyPOList[i].PatListID);
                        }
                    }
                }
            }

            IsendDrugMessage isdmD = DaoFactory.GetObject<IsendDrugMessage>(typeof(SendDrugMessageDao));
            isdmD.oleDb = oleDb;
            return isdmD.GetPatInfoData(patlistIds);

        }

        public static string GetPatName(int patid)
        {
            object obj = BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetFieldValue("PatName","patid=" + patid);
            if (obj != null)
            {
                return obj.ToString();
            }
            return null;
        }

        /// <summary>
        /// 第一步，得到待统领的所有药品
        /// </summary>
        /// <returns></returns>
        public static void GetStatData(int Stype, string deptId, string _EmployeeID, string _currentUserName, DataTable dtDrugMessage)
        {
            string[] data = new string[8];
            
            DataTable yfData = GetYfDept();
            string YfID = null;
            bool IsDrug = false;
            string StatType = null;
            string PresType = null;
            for (int i = 0; i < yfData.Rows.Count; i++)
            {
                List<ZY_PresOrder> zyPOList = null;
                YfID = yfData.Rows[i]["code"].ToString();

                //加载未发药的信息drug_flag=0,发药后为1
                //冲账的药品未退药的drug_flag=1，退药后改为0
                //未发药的费用冲账drug_flag=0 ,oldid 关联
                string strWhere = "prestype in ('0','1','2','3') and presdeptcode='" + deptId + "' and charge_flag=1 and cost_flag=0 and execdeptcode='" + YfID + "' ";
                switch (Stype)
                {
                    case 1://非口服长期
                        strWhere += " and RECORD_FLAG =0 and DRUG_FLAG=0 and order_type=0 ";
                        strWhere += " and ORDER_ID!=0 and (select count(*) from zy_doc_orderrecord b where b.order_id=zy_presorder.order_id and b.order_usage in (select name from BASE_USAGEDICTION where id not in( select distinct USAGE_ID  from DB2INST2.BASE_USAGE_USETYPE_ROLE where type_name = '服药单')))>0";
                        //zyPOList = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetPresOrder(strWhere, true);
                        IsDrug = true;
                        StatType = "0";
                        PresType = "0";
                        break;
                    case 2://非口服临时
                        strWhere += " and RECORD_FLAG =0  and DRUG_FLAG=0 and order_type=1 ";
                        strWhere += " and ORDER_ID!=0 and (select count(*) from zy_doc_orderrecord b where b.order_id=zy_presorder.order_id and b.order_usage in (select name from BASE_USAGEDICTION where id not in( select distinct USAGE_ID  from DB2INST2.BASE_USAGE_USETYPE_ROLE where type_name = '服药单')))>0";
                        //zyPOList = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetPresOrder(strWhere, true);
                        IsDrug = true;
                        StatType = "0";
                        PresType = "1";
                        break;
                    case 3://口服  长期
                        strWhere += " and RECORD_FLAG =0  and DRUG_FLAG=0 and order_type=0 ";
                        strWhere += " and ORDER_ID!=0 and (select count(*) from zy_doc_orderrecord b where b.order_id=zy_presorder.order_id and b.order_usage in (select name from BASE_USAGEDICTION where id in( select distinct USAGE_ID  from DB2INST2.BASE_USAGE_USETYPE_ROLE where type_name = '服药单')))>0";
                        //zyPOList = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetPresOrder(strWhere, true);
                        IsDrug = true;
                        StatType = "1";
                        PresType = "0";
                        break;
                    case 4://口服  临时
                        strWhere += " and RECORD_FLAG =0  and DRUG_FLAG=0 and order_type=1 ";
                        strWhere += " and ORDER_ID!=0 and (select count(*) from zy_doc_orderrecord b where b.order_id=zy_presorder.order_id and b.order_usage in (select name from BASE_USAGEDICTION where id in( select distinct USAGE_ID  from DB2INST2.BASE_USAGE_USETYPE_ROLE where type_name = '服药单')))>0";
                        //zyPOList = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetPresOrder(strWhere, true);
                        IsDrug = true;
                        StatType = "1";
                        PresType = "1";
                        break;
                    case 5://手术  用药
                        strWhere += " and RECORD_FLAG =0  and DRUG_FLAG=0 ";
                        strWhere += " and ORDER_ID=0 ";
                        //zyPOList = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetPresOrder(strWhere, true);
                        IsDrug = true;
                        StatType = "2";
                        PresType = "0";
                        break;
                    case 6://退药  长期
                        strWhere += " and RECORD_FLAG=1 and DRUG_FLAG=1 and order_type=0 ";
                        //zyPOList = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetPresOrder(strWhere, false);
                        IsDrug = false;
                        StatType = "0";
                        PresType = "0";
                        break;
                    case 7://退药  临时
                        strWhere += " and RECORD_FLAG=1 and DRUG_FLAG=1 and order_type=1 ";
                        //zyPOList = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetPresOrder(strWhere, false);
                        IsDrug = false;
                        StatType = "0";
                        PresType = "1";
                        break;
                }
                data[0] = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString();
                data[1] = deptId;
                data[2] = YfID;
                data[3] = IsDrug ? "1" : "0";
                data[4] = PresType;
                data[5] = _EmployeeID;
                data[6] = _currentUserName;
                data[7] = StatType;
                zyPOList = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetPresOrder(strWhere);
                BindData(zyPOList,data,dtDrugMessage);
            }
        }
        /// <summary>
        /// 第二步，数据转化为插入消息表的数据
        /// </summary>
        /// <param name="dt"></param>
        public static void BindData(List<ZY_PresOrder> zyPOList, string[] Data, DataTable dtDrugMessage)
        {
            DataTable yfData = GetYfData();
            DataTable usageData = GetUsageName();
            dtDrugMessage.Rows.Clear();

            DataTable patinfodata = GetPatInfoData(zyPOList);

            for (int i = 0; i < zyPOList.Count; i++)
            {
                //DataTable patInfo = GetPatInfo(zyPOList[i].PatListID);
                //循环赋值
                DataRow dr = dtDrugMessage.NewRow();
                DataRow[] _cdrs = yfData.Select("MakerDicID=" + zyPOList[i].ItemID);
                if (_cdrs.Length > 0)
                {
                    dr["UNIT"] = _cdrs[0]["Unit"];//
                    dr["DOSENAME"] = _cdrs[0]["DOSENAME"];
                    dr["SPECDICID"] = _cdrs[0]["SPECDICID"];
                    dr["PRODUCTNAME"] = _cdrs[0]["ProductName"];
                }
                else
                {
                    dr["UNIT"] = 0;//
                    dr["DOSENAME"] = "";
                    dr["SPECDICID"] = 0;
                    dr["PRODUCTNAME"] = "";
                }

                dr["XD"] = false;
                dr["DRUGMESSAGEID"] = 0;
                dr["masterid"] = 0;
                dr["MakerdicID"] = zyPOList[i].ItemID;
                dr["CHEMNAME"] = zyPOList[i].ItemName; //drs[i]["itemname"];
                dr["SPEC"] = zyPOList[i].Standard;//drs[i]["standard"];
                dr["BEDNO"] = patinfodata.Select(" patlistid=" + zyPOList[i].PatListID)[0]["bedcode"].ToString(); //patInfo.Rows[0]["Bedcode"].ToString();//drs[i]["BEDNO"];
                dr["CURENO"] = patinfodata.Select(" patlistid=" + zyPOList[i].PatListID)[0]["cureno"].ToString();//patInfo.Rows[0]["cureno"].ToString(); //drs[i]["CureNo"];
                dr["PATNAME"] = patinfodata.Select(" patlistid=" + zyPOList[i].PatListID)[0]["patname"].ToString();//GetPatName(zyPOList[i].PatID);//drs[i]["patName"];
                dr["CUREDEPT"] = zyPOList[i].PresDeptCode;//drs[i]["presdeptcode"];
                dr["CUREDOC"] = zyPOList[i].PresDocCode;//drs[i]["presdoccode"];
                dr["patlistid"] = zyPOList[i].PatListID;// drs[i]["patlistid"];
                dr["RECIPENUM"] = zyPOList[i].PresAmount;// drs[i]["presamount"];
                dr["DRUGNUM"] = zyPOList[i].Amount;// drs[i]["amount"];

                dr["UNITNAME"] = zyPOList[i].Unit;// drs[i]["unit"];

                dr["UNITNUM"] = zyPOList[i].RelationNum;// drs[i]["relationnum"];

                //dr["DOSENUM"] = 0;//

                dr["RETAILPRICE"] = zyPOList[i].Sell_Price;// drs[i]["sell_price"];
                dr["TRADEPRICE"] = zyPOList[i].Buy_Price;// drs[i]["buy_price"];
                dr["RETAILFEE"] = zyPOList[i].Tolal_Fee;// drs[i]["tolal_fee"];
                dr["TRADEFEE"] = 0;//
                dr["RECIPEMASTERID"] = 0;//drs[i]["patlistid"].ToString() + drs[i]["order_type"].ToString() + drs[i]["group_id"].ToString();//
                dr["ORDERRECIPEID"] = zyPOList[i].PresOrderID;// drs[i]["PRESORDERID"];
                dr["CHARGEMAN"] = zyPOList[i].ChargeCode;// drs[i]["CHARGECODE"];
                dr["CHARGEDATE"] = zyPOList[i].CostDate;// drs[i]["costdate"];
                //REFUNDFLAG     SMALLINT,
                //UNIFORM_FLAG   SMALLINT,
                dr["CHARGECODE"] = "非口服";//GetDrugType(zyPOList[i].order_id, usageData);
                //WORKID         BIGINT,
                dr["ORDERGROUP_ID"] = zyPOList[i].group_id;// drs[i]["group_id"];
                dr["DOCORDERTYPE"] = zyPOList[i].order_type;// drs[i]["order_type"];
                dr["DOCORDERID"] = zyPOList[i].order_id;// drs[i]["order_id"];
                //DISP_FLAG      SMALLINT,

                dr["DT_State"] = "Add";

                dtDrugMessage.Rows.Add(dr);

            }
            DataRow[] drs = dtDrugMessage.Select();
            if (drs.Length > 0)
            {
                string message = null;
                SaveMessage(0, drs, Data,out message);
            }
        }

        /// <summary>
        /// 第三步，保存统领单数据
        /// </summary>
        /// <param name="MasterID"></param>
        /// <param name="drs"></param>
        /// <param name="data"></param>
        public static void SaveMessage(int MasterID,DataRow[] drs,string[] data,out string message)
        {
            try
            {
                message = "";
                //if (drs.Length == 0)
                //    throw new Exception("没有勾选请领的药品！");
                oleDb.BeginTransaction();

                //判断库存
                StringBuilder sb = new StringBuilder();
                List<int> makerdicids = new List<int>();
                bool isSb = false;

                sb.Append("下列药品库存不足：");

                for (int i = 0; i < drs.Length; i++)
                {
                    if (makerdicids.Exists(x => x == Convert.ToInt32(drs[i]["MakerdicID"]))) continue;

                    string strsql = @"select Sum(CURRENTNUM) FROM YF_STORAGE A where DEPTID = " + data[2].ToString() + " and MAKERDICID=" + Convert.ToInt32(drs[i]["MakerdicID"]);
                    int storenum = Convert.ToInt32(oleDb.GetDataResult(strsql));
                    int num = 0;
                    for (int j = 0; j < drs.Length; j++)
                    {
                        if (Convert.ToInt32(drs[j]["MakerdicID"]) == Convert.ToInt32(drs[i]["MakerdicID"]))
                            num += Convert.ToInt32(drs[j]["DRUGNUM"]);
                    }
                    if (storenum < num)
                    {
                        //throw new Exception("药品库存不足！\n\t[" + drs[i]["CHEMNAME"].ToString() + "]需要申领" + num + "\t但实际库存只有" + storenum.ToString());
                        isSb = true;
                        sb.Append("\n\t[" + drs[i]["CHEMNAME"].ToString() + "]需要申领[" + num + "]\t但实际库存只有[" + storenum.ToString() + "]");
                        drs[i]["DT_State"] = "";
                    }
                    
                    makerdicids.Add(Convert.ToInt32(drs[i]["MakerdicID"]));
                }
                if (isSb == true)
                {
                    message = sb.ToString();
                }

                if (MasterID == 0)
                {
                    string[] filednames = new string[]{"SENDTIME","PRESDEPTID","DISPDEPT","DR_FLAG","MESSAGETYPE",
                                                       "SENDER","SENDERNAME","StatType"};
                    string[] filedvalues = new string[8];
                    filedvalues[0] =data[0];
                    filedvalues[1] = data[1];
                    filedvalues[2] = data[2];
                    filedvalues[3] = data[3];
                    filedvalues[4] = data[4];
                    filedvalues[5] = data[5];
                    filedvalues[6] = data[6];
                    filedvalues[7] = data[7];
                    bool[] b = new bool[] { true, false, false,false,false,
                         false,true,false};
                    MasterID = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_MASTER").Add(filednames, filedvalues, b);
                }

                for (int i = 0; i < drs.Length; i++)
                {
                    if (drs[i]["DT_State"].ToString() == "Delete")
                    {
                        string strWhere = "DRUGMESSAGEID=" + drs[i]["DRUGMESSAGEID"].ToString();
                        BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").Delete(strWhere);                       
                    }
                    else if (drs[i]["DT_State"].ToString() == "Add")
                    {

                        string strWhere = "ORDERRECIPEID=" + drs[i]["ORDERRECIPEID"].ToString();

                        bool bb = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").Exists(strWhere);

                        if (bb)
                        {
                            throw new Exception(drs[i]["PATNAME"].ToString() + "的[" + drs[i]["CHEMNAME"].ToString() + "]已经被生成了统领单，请重新刷新生成！");
                        }

                        string[] filednames = new string[] {" MAKERDICID", "CHEMNAME",
                            "SPEC", "BEDNO", "CURENO", "PATNAME", 
                            "CUREDEPT", "CUREDOC", "PATID", "RECIPENUM", "DRUGNUM",
                            "UNIT", "UNITNAME", "UNITNUM", "DOSENAME", "RETAILPRICE",
                            "TRADEPRICE", "RETAILFEE", "TRADEFEE", "RECIPEMASTERID",
                            "ORDERRECIPEID", "CHARGEMAN", "CHARGEDATE", 
                            "ORDERGROUP_ID", "DOCORDERTYPE",
                            "DOCORDERID", "SPECDICID","MASTERID" ,"PRODUCTNAME","CHARGECODE"};
                        string[] filedvalues = new string[30];
                        filedvalues[0] = drs[i]["MakerdicID"].ToString();
                        filedvalues[1] = drs[i]["CHEMNAME"].ToString();
                        filedvalues[2] = drs[i]["SPEC"].ToString();
                        filedvalues[3] = drs[i]["BEDNO"].ToString();
                        filedvalues[4] = drs[i]["CURENO"].ToString();
                        filedvalues[5] = drs[i]["PATNAME"].ToString();
                        filedvalues[6] = drs[i]["CUREDEPT"].ToString();
                        filedvalues[7] = drs[i]["CUREDOC"].ToString();
                        filedvalues[8] = drs[i]["patlistid"].ToString();
                        filedvalues[9] = drs[i]["RECIPENUM"].ToString();
                        filedvalues[10] = drs[i]["DRUGNUM"].ToString();
                        filedvalues[11] = drs[i]["UNIT"].ToString();
                        filedvalues[12] = drs[i]["UNITNAME"].ToString();
                        filedvalues[13] = drs[i]["UNITNUM"].ToString();
                        filedvalues[14] = drs[i]["DOSENAME"].ToString();
                        filedvalues[15] = drs[i]["RETAILPRICE"].ToString();
                        filedvalues[16] = drs[i]["TRADEPRICE"].ToString();
                        filedvalues[17] = "0";
                        filedvalues[18] = drs[i]["TRADEFEE"].ToString();
                        filedvalues[19] = drs[i]["RECIPEMASTERID"].ToString();
                        filedvalues[20] = drs[i]["ORDERRECIPEID"].ToString();
                        filedvalues[21] = drs[i]["CHARGEMAN"].ToString();
                        filedvalues[22] = drs[i]["CHARGEDATE"].ToString();
                        filedvalues[23] = drs[i]["ORDERGROUP_ID"].ToString();
                        filedvalues[24] = drs[i]["DOCORDERTYPE"].ToString();
                        filedvalues[25] = drs[i]["DOCORDERID"].ToString();
                        filedvalues[26] = drs[i]["SPECDICID"].ToString();
                        filedvalues[27] = MasterID.ToString();
                        filedvalues[28] = drs[i]["PRODUCTNAME"].ToString();
                        filedvalues[29] = drs[i]["CHARGECODE"].ToString();
                        bool[] b = new bool[] { false, true, 
                            true, true,true,true,
                        false,false,false,false,false,
                        false,true,false,true,false,
                        false,false,false,false,
                        false,false,true,
                        false,false,
                        false,false,false,true,true};
                        BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").Add(filednames, filedvalues, b);
                    }
                }
                oleDb.CommitTransaction();
            }
            catch (Exception err)
            {
                oleDb.RollbackTransaction();
                throw err;
            }
        }

        /// <summary>
        /// 再次发送消息
        /// </summary>
        /// <param name="MasterID"></param>
        /// <returns></returns>
        public static void AgainSendMessage(int MasterID)
        {
            try
            {
                string strWhere = "disp_flag=0 and  MASTERID=" + MasterID;
                string[] filedvalues = new string[1];
                filedvalues[0] = "NODRUG_FLAG=0";
                BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_DRUGMESSAGE_ORDER").Update(strWhere, filedvalues);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 汇总请药
        /// </summary>
        /// <param name="_isDrug">发药、退药</param>
        /// <param name="_Stype">口服、非口服</param>
        /// <param name="deptId"></param>
        /// <param name="_EmployeeID"></param>
        /// <param name="_currentUserName"></param>
        /// <param name="dtDrugMessage"></param>
        /// <param name="_IsOper">手术、非手术</param>
        public static string[] CollectDurgSend(bool _isDrug, bool _Stype, string deptId, string YfID, string patlistid,string _EmployeeID, string _currentUserName, DataTable dtDrugMessage, DataTable dtMessageAllOrder, bool _IsOper)
        {
            string[] data = new string[8];

            //DataTable yfData = GetYfDept();
            //string YfID = null;
            bool IsDrug = _isDrug; //true 发药 false 退药
            string StatType = "0";//0 非口服 1口服 2手术
            string PresType = "1";//0 长期 1临时


            List<ZY_PresOrder> zyPOList = null;
            //YfID = yfData.Rows[i]["code"].ToString();
            
            //加载未发药的信息drug_flag=0,发药后为1
            //冲账的药品未退药的drug_flag=1，退药后改为0
            //未发药的费用冲账drug_flag=0 ,oldid 关联
            string strWhere = "prestype in ('0', '1','2')  and charge_flag=1 and cost_flag=0 and execdeptcode='" + YfID + "' "; //update by heyan 2010.10.21 中草药不进统领单
            string strWhere1 = "prestype in ('0','1','2') and charge_flag=1 and cost_flag=0 and execdeptcode='" + YfID + "' ";

            if (patlistid != null && patlistid != "")
            {
                strWhere += " and patlistid=" + patlistid + " ";
                strWhere1 += " and patlistid=" + patlistid + " ";
            }

                strWhere += " and presdeptcode='" + deptId + "'";
                strWhere1 += " and presdeptcode='" + deptId + "'";

            if (_IsOper == false)
            {
                if (IsDrug)//发药
                {
                    strWhere += " and RECORD_FLAG =0 and DRUG_FLAG=0  ";
                    strWhere1 += " and RECORD_FLAG =1 and DRUG_FLAG=0  ";
                }
                else//退药
                {
                    strWhere += " and RECORD_FLAG=1 and DRUG_FLAG=1 ";
                }
            }
            else//手术药品
            {
                StatType = "2";
                if (IsDrug)//发药
                {
                    strWhere += " and RECORD_FLAG =0  and DRUG_FLAG=0 ";
                    strWhere1 += " and RECORD_FLAG =1  and DRUG_FLAG=0 ";
                }
                else//退药
                {
                    strWhere += " and RECORD_FLAG =1  and DRUG_FLAG=1 ";
                }
                strWhere += " and ORDER_ID=0 ";
            }



            data[0] = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString();
            data[1] = deptId;
            data[2] = YfID;
            data[3] = IsDrug ? "1" : "0";
            data[4] = PresType;
            data[5] = _EmployeeID;
            data[6] = _currentUserName;
            data[7] = StatType;
            zyPOList = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.CollectDurgGetPresOrder(strWhere,strWhere1, IsDrug);

            if (zyPOList == null || zyPOList.Count == 0)

            {
                return null;
            }
            else
            {
                CollectDurgBindData(zyPOList, data, dtDrugMessage, dtMessageAllOrder);
                return data;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strWhere1"></param>
        /// <param name="IsDrug"></param>
        /// <returns></returns>
        public static List<ZY_PresOrder> CollectDurgGetPresOrder(string strWhere, string strWhere1, bool IsDrug)
        {
            List<ZY_PresOrder> zyPlist = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere + " and (select count(*)  from ZY_DRUGMESSAGE_ORDER where ORDERRECIPEID=presorderid)=0 ");
            if (IsDrug == true)
            {
                List<ZY_PresOrder> zyPL1 = zyPlist;
                List<ZY_PresOrder> zyPL2 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere1);
                List<ZY_PresOrder> zyPL3 = new List<ZY_PresOrder>();
                for (int i = 0; i < zyPL1.Count; i++)
                {
                    List<ZY_PresOrder> zyPL21 = zyPL2.FindAll(delegate(ZY_PresOrder y) { return (y.OldID == zyPL1[i].PresOrderID); });
                    decimal amount = zyPL21.Sum(y => y.Amount);
                    int presamount = zyPL21.Sum(y => y.PresAmount);
                    decimal total_fee = zyPL21.Sum(y => y.Tolal_Fee);

                    zyPL1[i].Amount += amount;
                    zyPL1[i].PresAmount += presamount;
                    zyPL1[i].Tolal_Fee += total_fee;

                    if (zyPL1[i].Amount > 0)//过滤掉已经全部冲完了的药品（数量为0的不显示）
                    {
                        zyPL3.Add(zyPL1[i]);
                    }
                }
                zyPlist = zyPL3;
            }
            return zyPlist;
        }

        /// <summary>
        /// 数据转化为插入消息表的数据
        /// </summary>
        /// <param name="dt"></param>
        public static void CollectDurgBindData(List<ZY_PresOrder> zyPOList, string[] Data, DataTable dtDrugMessage, DataTable dtMessageAllOrder)
        {
            DataTable yfData = GetYfData();
            DataTable usageData = GetUsageName();
            dtDrugMessage.Rows.Clear();

            DataTable patinfodata = GetPatInfoData(zyPOList);
            for (int i = 0; i < zyPOList.Count; i++)
            {
                //循环赋值
                DataRow dr = dtDrugMessage.NewRow();
                DataRow[] _cdrs = yfData.Select("MakerDicID=" + zyPOList[i].ItemID);
                if (_cdrs.Length > 0)
                {
                    dr["UNIT"] = _cdrs[0]["Unit"];//
                    dr["DOSENAME"] = _cdrs[0]["DOSENAME"];
                    dr["SPECDICID"] = _cdrs[0]["SPECDICID"];
                    dr["PRODUCTNAME"] = _cdrs[0]["ProductName"];
                }
                else
                {
                    dr["UNIT"] = 0;//
                    dr["DOSENAME"] = "";
                    dr["SPECDICID"] = 0;
                    dr["PRODUCTNAME"] = "";
                }

                dr["XD"] = false;
                dr["DRUGMESSAGEID"] = 0;
                dr["masterid"] = 0;
                dr["MakerdicID"] = zyPOList[i].ItemID;
                dr["CHEMNAME"] = zyPOList[i].ItemName; //drs[i]["itemname"];
                dr["SPEC"] = zyPOList[i].Standard;//drs[i]["standard"];
                dr["BEDNO"] = patinfodata.Select(" patlistid=" + zyPOList[i].PatListID)[0]["bedcode"].ToString(); //patInfo.Rows[0]["Bedcode"].ToString();//drs[i]["BEDNO"];
                dr["CURENO"] = patinfodata.Select(" patlistid=" + zyPOList[i].PatListID)[0]["cureno"].ToString();//patInfo.Rows[0]["cureno"].ToString(); //drs[i]["CureNo"];
                dr["PATNAME"] = patinfodata.Select(" patlistid=" + zyPOList[i].PatListID)[0]["patname"].ToString();//GetPatName(zyPOList[i].PatID);//drs[i]["patName"];
                dr["CUREDEPT"] = zyPOList[i].PresDeptCode;//drs[i]["presdeptcode"];
                dr["CUREDOC"] = zyPOList[i].PresDocCode;//drs[i]["presdoccode"];
                dr["patlistid"] = zyPOList[i].PatListID;// drs[i]["patlistid"];
                dr["RECIPENUM"] = zyPOList[i].PresAmount;// drs[i]["presamount"];
                dr["DRUGNUM"] = zyPOList[i].Amount;// drs[i]["amount"];

                dr["UNITNAME"] = zyPOList[i].Unit;// drs[i]["unit"];

                dr["UNITNUM"] = zyPOList[i].RelationNum;// drs[i]["relationnum"];

                //dr["DOSENUM"] = 0;//

                dr["RETAILPRICE"] = zyPOList[i].Sell_Price;// drs[i]["sell_price"];
                dr["TRADEPRICE"] = zyPOList[i].Buy_Price;// drs[i]["buy_price"];
                dr["RETAILFEE"] = zyPOList[i].Tolal_Fee;// drs[i]["tolal_fee"];
                dr["TRADEFEE"] = 0;//
                dr["RECIPEMASTERID"] = 0;//drs[i]["patlistid"].ToString() + drs[i]["order_type"].ToString() + drs[i]["group_id"].ToString();//
                dr["ORDERRECIPEID"] = zyPOList[i].PresOrderID;// drs[i]["PRESORDERID"];
                dr["CHARGEMAN"] = zyPOList[i].ChargeCode;// drs[i]["CHARGECODE"];
                dr["CHARGEDATE"] = zyPOList[i].CostDate;// drs[i]["costdate"];
                //REFUNDFLAG     SMALLINT,
                //UNIFORM_FLAG   SMALLINT,
                dr["CHARGECODE"] = "非口服";//GetDrugType(zyPOList[i].order_id, usageData);
                //WORKID         BIGINT,
                dr["ORDERGROUP_ID"] = zyPOList[i].group_id;// drs[i]["group_id"];
                dr["DOCORDERTYPE"] = zyPOList[i].order_type;// drs[i]["order_type"];
                dr["DOCORDERID"] = zyPOList[i].order_id;// drs[i]["order_id"];
                //DISP_FLAG      SMALLINT,

                dr["DT_State"] = "Add";

                dtDrugMessage.Rows.Add(dr);

            }


            //显示汇总
            #region
            dtMessageAllOrder.Rows.Clear();

            DataRow[] drs = dtDrugMessage.Select();

            for (int i = 0; i < drs.Length; i++)
            {
                bool b = false;
                if (dtMessageAllOrder.Rows.Count == 0)
                {
                    b = true;
                }
                for (int j = 0; j < dtMessageAllOrder.Rows.Count; j++)
                {
                    if (Convert.ToInt32(drs[i]["MakerdicID"]) == Convert.ToInt32(dtMessageAllOrder.Rows[j]["itemid"]))
                    {
                        dtMessageAllOrder.Rows[j]["Amount"] = Convert.ToDecimal(dtMessageAllOrder.Rows[j]["Amount"]) + Convert.ToDecimal(drs[i]["DRUGNUM"]);
                        dtMessageAllOrder.Rows[j]["presamount"] = Convert.ToInt32(dtMessageAllOrder.Rows[j]["presamount"]) + Convert.ToInt32(drs[i]["RECIPENUM"]);
                        dtMessageAllOrder.Rows[j]["Total_Fee"] = Convert.ToDecimal(dtMessageAllOrder.Rows[j]["Total_Fee"]) + Convert.ToDecimal(drs[i]["RETAILFEE"]);
                        break;
                    }
                    if (j == dtMessageAllOrder.Rows.Count - 1)
                    {
                        b = true;
                    }
                }

                if (b)
                {
                    DataRow _dr = dtMessageAllOrder.NewRow();
                    _dr["itemid"] = drs[i]["MakerdicID"];
                    _dr["DrugName"] = drs[i]["CHEMNAME"];
                    _dr["Spec"] = drs[i]["SPEC"];
                    _dr["PRODUCTNAME"] = drs[i]["PRODUCTNAME"];
                    _dr["DOSENAME"] = drs[i]["DOSENAME"];

                    _dr["Price"] = drs[i]["RETAILPRICE"];
                    _dr["Amount"] = drs[i]["DRUGNUM"];
                    _dr["presamount"] = drs[i]["RECIPENUM"];
                    _dr["Unit"] = drs[i]["UNITNAME"];
                    _dr["retailprice"] = drs[i]["retailprice"];
                    _dr["Total_Fee"] = drs[i]["RETAILFEE"];
                    dtMessageAllOrder.Rows.Add(_dr);
                }
            }
            #endregion

        } 


    }
}
