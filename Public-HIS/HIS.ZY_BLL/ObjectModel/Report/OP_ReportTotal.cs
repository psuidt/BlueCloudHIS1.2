using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using System.Data;
using HIS.SYSTEM.Core;

namespace HIS.ZY_BLL
{

    /// <summary>
    /// 病人类型
    /// </summary>
    public enum PatType
    {
        在院病人, 出院病人
    }

    /// <summary>
    /// 统计类型
    /// </summary>
    public enum CostItemType
    {
        /// <summary>
        /// 发票项目
        /// </summary>
        发票项目,
        /// <summary>
        /// 核算项目
        /// </summary>
        核算项目,
        /// <summary>
        /// 会计项目
        /// </summary>
        会计项目
    }
    /// <summary>
    /// 统计方式
    /// </summary>
    public enum CostItemStyle
    {
        记账日期, 结帐日期
    }

    /// <summary>
    /// 报表统计
    /// </summary>
    public abstract class ReportStat:BaseBLL
    {
        private CostItemStyle _costItemStyle;
        private CostItemType _costItemType;
        private DateTime? _Bdate;
        private DateTime? _Edate;

        public CostItemStyle costItemStyle
        {
            set { _costItemStyle = value; }
            get { return _costItemStyle; }
        }

        public CostItemType costItemType
        {
            set { _costItemType = value; }
            get { return _costItemType; }
        }

        public DateTime? Bdate
        {
            set { _Bdate = value; }
            get { return _Bdate; }
        }

        public DateTime? Edate
        {
            set { _Edate = value; }
            get { return _Edate; }
        }
        /// <summary>
        /// 得到发票项目
        /// </summary>
        /// <returns></returns>
        public DataTable GetTicketItemName()
        {
            try
            {
                string strsql = "select ITEM_NAME from {BASE_STAT_ZYFP} ORDER BY CODE";
                return oleDb.GetDataTable(strsql);
            }
            catch (System.Exception e)
            {
#if DEBUG

                throw new Exception(e.Message);
#else

                throw new Exception("获取发票项目失败！");
#endif
            }
        }
        /// <summary>
        /// 得到核算项目
        /// </summary>
        /// <returns></returns>
        public DataTable GetCalcuItemName()
        {
            try
            {
                string strsql = " select ITEM_NAME from {BASE_STAT_HS} ORDER BY CODE ";
                return oleDb.GetDataTable(strsql);

            }
            catch (System.Exception e)
            {
#if DEBUG

                throw new Exception(e.Message);
#else

                throw new Exception("获取核算项目失败！");
#endif
            }
        }

        public DataTable GetAddCol
        {
            get
            {
                if (costItemType == CostItemType.发票项目)
                {
                    return GetTicketItemName();
                }
                else if (costItemType == CostItemType.核算项目)
                {
                    return GetCalcuItemName();
                }
                return null;
            }
        }

        public abstract DataTable[] GetReportData();
    }
    /// <summary>
    /// 按执行科室执行人统计
    /// </summary>
    public class ExecDeptAndUserReport:ReportStat
    {
        public override DataTable[] GetReportData()
        {
            try
            {
                string strsql = null;
                DataTable[] dt = new DataTable[2];

                #region 费用
                if ((base.costItemType == CostItemType.发票项目) && (base.costItemStyle == CostItemStyle.记账日期))
                {


                    string strWhere_2 = "a.ZYFP_CODE =b.CODE";
                    string childtable_2 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_ZYFP", "b"), "aa", strWhere_2,
                                 "a.CODE",
                                oleDb.FiledNameBM("b.ITEM_NAME", "itemname"));

                    string sum_3 = oleDb.Sum("TOLAL_FEE", "TOLAL_FEE");
                    string date_1_4 = oleDb.Date("COSTDATE");
                    string _gs_1_5 = "aa.code";
                    string _gs_1_6 = "ITEMTYPE";
                    string strWhere_7 = _gs_1_5 + oleDb.EuqalTo() + _gs_1_6;
                    string childtable_3 = oleDb.ChildTable(childtable_2, "itemname", strWhere_7,
                                "itemname");
                    string strWhere_8 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'" + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" + oleDb.And() + "CHARGE_FLAG" + oleDb.EuqalTo() + "1";
                    string childtable_4 = oleDb.ChildTable("ZY_PRESORDER", "D", strWhere_8,
                                "PATLISTID",
                                  oleDb.FiledNameBM("EXECDEPTCODE", "currdeptcode"),
                                  "CHARGECODE",
                                  "ITEMTYPE",
                                 childtable_3,
                                 "TOLAL_FEE");
                    strsql = oleDb.Table(childtable_4, "  group by d.currdeptcode,d.CHARGECODE,d.itemname ", "",
                                "currdeptcode",
                                "CHARGECODE",
                                "itemname",
                                 sum_3);

                }
                else if (base.costItemType == CostItemType.发票项目 && base.costItemStyle == CostItemStyle.结帐日期)
                {
                    string strWhere_1 = "a.zyfp_code" + oleDb.EuqalTo() + "b.code";
                    string childtable_1 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM","a")+","+oleDb.TableNameBM("BASE_STAT_ZYFP","b") , "aa", strWhere_1,
                                "a.code",
                                oleDb.FiledNameBM("b.item_name", "itemname"));
                    string strWhere_2 = "aa.code" + oleDb.EuqalTo() + "zy_presorder.itemtype";
                    string childtable_2 = oleDb.ChildTable(childtable_1, "itemname", strWhere_2,
                                "itemname");
                    string sum_3 = oleDb.Sum("TOTAL_FEE", "tolal_fee");
                    string date_1_4 = oleDb.Date("ACCOUNTDATE");

                    string strWhere_6 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'" 
                        + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" 
                        + oleDb.And() + "zy_account.accountid" + oleDb.EuqalTo() + "zy_costmaster.accountid" 
                        + oleDb.And() + "zy_costmaster.costmasterid" + oleDb.EuqalTo() + "zy_presorder.costmasterid"
                        + oleDb.And() + "zy_presorder.charge_flag" + oleDb.EuqalTo() + "1"; 
                    string childtable_3 = oleDb.ChildTable("ZY_ACCOUNT , ZY_COSTMASTER  , ZY_PRESORDER", "d", strWhere_6,
                                oleDb.FiledNameBM("zy_presorder.execdeptcode", "currdeptcode"),
                                   "zy_presorder.chargecode",
                                     childtable_2,
                                oleDb.FiledNameBM("zy_presorder.tolal_fee", "total_fee"));
                    strsql = oleDb.Table(childtable_3 + "group by d.currdeptcode,d.chargecode,d.itemname", "", "",
                                "currdeptcode",
                                "chargecode",
                                "itemname",
                                 sum_3);

                }
                else if (base.costItemType == CostItemType.核算项目 && base.costItemStyle == CostItemStyle.记账日期)
                {
                    string strWhere_2 = "a." + "HS_CODE" + oleDb.EuqalTo() + "b.CODE";
                    string childtable_2 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_HS", "b"), "aa", strWhere_2,
                                 "a." + "CODE",
                                oleDb.FiledNameBM("b.ITEM_NAME", "itemname"));
                    string sum_3 = oleDb.Sum("TOLAL_FEE", "TOLAL_FEE");
                    string date_1_4 = oleDb.Date("COSTDATE");
                    string _gs_1_5 = "aa.code";
                    string _gs_1_6 = "ITEMTYPE";
                    string strWhere_7 = _gs_1_5 + oleDb.EuqalTo() + _gs_1_6;
                    string childtable_3 = oleDb.ChildTable(childtable_2, "itemname", strWhere_7,
                                "itemname");
                    string strWhere_8 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'" + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" + oleDb.And() + "CHARGE_FLAG" + oleDb.EuqalTo() + "1";
                    string childtable_4 = oleDb.ChildTable("ZY_PRESORDER", "D", strWhere_8,
                                "PATLISTID",
                                  oleDb.FiledNameBM("EXECDEPTCODE", "currdeptcode"),
                                  "CHARGECODE",
                                  "ITEMTYPE",
                                 childtable_3,
                                 "TOLAL_FEE");
                    strsql = oleDb.Table(childtable_4, "  group by d.currdeptcode,d.CHARGECODE,d.itemname ", "",
                                "currdeptcode",
                                "CHARGECODE",
                                "itemname",
                                 sum_3);

                }
                else if (base.costItemType == CostItemType.核算项目 && base.costItemStyle == CostItemStyle.结帐日期)
                {
                    string strWhere_1 = "a.HS_CODE" + oleDb.EuqalTo() + "b.code";
                    string childtable_1 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_HS", "b"), "aa", strWhere_1,
                                "a.code",
                                oleDb.FiledNameBM("b.item_name", "itemname"));


                    string strWhere_2 = "aa.code" + oleDb.EuqalTo() + "zy_presorder.itemtype";
                    string childtable_2 = oleDb.ChildTable(childtable_1, "itemname", strWhere_2,
                                "itemname");

                  
                    string sum_3 = oleDb.Sum("TOTAL_FEE", "tolal_fee");
                    string date_1_4 = oleDb.Date("ACCOUNTDATE");

                    string strWhere_6 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'" 
                        + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" 
                        + oleDb.And() + "zy_account.accountid" + oleDb.EuqalTo() + "zy_costmaster.accountid" 
                        + oleDb.And() + "zy_costmaster.costmasterid" + oleDb.EuqalTo() + "zy_presorder.costmasterid"
                        + oleDb.And() + "zy_presorder.charge_flag" + oleDb.EuqalTo() + "1";
                    string childtable_3 = oleDb.ChildTable("ZY_ACCOUNT,ZY_COSTMASTER ,ZY_PRESORDER", "d", strWhere_6,
                                oleDb.FiledNameBM("zy_presorder.execdeptcode", "currdeptcode"),
                                   "zy_presorder.chargecode",
                                     childtable_2,
                                oleDb.FiledNameBM("zy_presorder.tolal_fee", "total_fee"));
                    strsql = oleDb.Table(childtable_3 + "group by d.currdeptcode,d.chargecode,d.itemname", "", "",
                                "currdeptcode",
                                "chargecode",
                                "itemname",
                                 sum_3);
                }
                dt[0] = oleDb.GetDataTable(strsql);//得到所有费用
                #endregion

                #region 医生科室
                strsql = "";
                if(base.costItemStyle == CostItemStyle.记账日期)
                {
                    string date_1_1 = oleDb.Date("costdate");
                    string strWhere_2 = date_1_1 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'"
                        + oleDb.And() + date_1_1 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'"
                        + oleDb.And() + "CHARGE_FLAG" + oleDb.EuqalTo() + "1"
                        + oleDb.GroupBy() + "execdeptcode,chargecode";
                    strsql = oleDb.Table("ZY_PRESORDER", "", strWhere_2,
                                "EXECDEPTCODE",
                                "CHARGECODE");
                }
                else if (base.costItemStyle == CostItemStyle.结帐日期)
                {
                    string date_1_1 = oleDb.Date("ACCOUNTDATE");
                    string strWhere_2 = date_1_1 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'"
                        + oleDb.And() + date_1_1 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'"
                        + oleDb.And() + "ZY_ACCOUNT.ACCOUNTID" + oleDb.EuqalTo() + " zy_costmaster.accountid "
                        + oleDb.And() + "ZY_COSTMASTER.COSTMASTERID" + oleDb.EuqalTo() + " ZY_PRESORDER.COSTMASTERID "
                        + oleDb.GroupBy() + "ZY_PRESORDER.execdeptcode,ZY_PRESORDER.chargecode";
                    strsql = oleDb.Table("ZY_ACCOUNT,ZY_COSTMASTER ,ZY_PRESORDER", "", strWhere_2,
                                "ZY_PRESORDER.EXECDEPTCODE",
                                "ZY_PRESORDER.CHARGECODE");
                }
              
                dt[1] = oleDb.GetDataTable(strsql);//得到统计的科室
                #endregion

                return dt;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
    /// <summary>
    /// 按病人和病人所在科室统计
    /// </summary>
    public class PatDeptAndPatientReport : ReportStat
    {
        private bool _IsInHis;
        private string _cureDept;
        /// <summary>
        /// 病人是否在院
        /// </summary>
        public bool IsInHis
        {
            set { _IsInHis = value; }
            get { return _IsInHis; }
        }
        /// <summary>
        /// 需要统计的科室代码
        /// </summary>
        public string CureDeptCode
        {
            set { _cureDept = value; }
            get { return _cureDept; }
        }

        public override DataTable[] GetReportData()
        {
           string strWhere = null;

           try
           {
               string strsql = null;
               DataTable[] dt = new DataTable[2];
               #region 费用
               if ((base.costItemType == CostItemType.发票项目) && (base.costItemStyle == CostItemStyle.记账日期))
               {
                   strWhere = "";
                   if (Bdate != null && Edate != null)
                   {
                       string date_str = oleDb.Date("COSTDATE");
                       strWhere += date_str + oleDb.GreaterThanAndEqualTo() + "'" + Bdate.Value.Date + "'" + oleDb.And() + date_str + oleDb.LessThanAndEqualTo() + "'" + Edate.Value.Date + "'" + oleDb.And() + " ";
                   }
                   if (CureDeptCode != null)
                   {
                       strWhere += "PRESDEPTCODE" + oleDb.EuqalTo() + "'" + CureDeptCode + "'" + oleDb.And()+" ";
                   }
                   string strWhere_2 = "a.zyfp_code" + oleDb.EuqalTo() + "b.code";
                   string childtable_2 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_ZYFP", "b"), "aa", strWhere_2,
                               "a.code",
                               oleDb.FiledNameBM("b.item_name", "itemname"));

                   string sum_3 = oleDb.Sum("TOLAL_FEE", "TOLAL_FEE");
                   string _gs_1_4 = "aa.code";
                   string _gs_1_5 = "ITEMTYPE";
                   string strWhere_6 = _gs_1_4 + oleDb.EuqalTo() + _gs_1_5;
                   string childtable_3 = oleDb.ChildTable(childtable_2, "itemname", strWhere_6,
                               "itemname");
                   string strWhere_7 = strWhere + "CHARGE_FLAG" + oleDb.EuqalTo() + "1";
                   string childtable_4 = oleDb.ChildTable("ZY_PRESORDER", "d", strWhere_7,
                               "PATID",
                               "PRESDEPTCODE",
                                "ITEMTYPE",
                                childtable_3,
                                "TOLAL_FEE");
                   strsql = oleDb.Table(childtable_4 + " group by d.PRESDEPTCODE,d.PATID,d.itemname", "", "",                              
                              "PRESDEPTCODE",
                              "PATID",
                              "itemname",
                                sum_3);
               }
               else if (base.costItemType == CostItemType.发票项目 && base.costItemStyle == CostItemStyle.结帐日期)
               {
                   strWhere = "";
                   if (Bdate != null && Edate != null)
                   {
                       string date_str = oleDb.Date("ACCOUNTDATE");
                       strWhere += date_str + oleDb.GreaterThanAndEqualTo() + "'" + Bdate.Value.Date + "'" + oleDb.And() + date_str + oleDb.LessThanAndEqualTo() + "'" + Edate.Value.Date + "'" + oleDb.And() + " ";
                   }
                   if (CureDeptCode != null)
                   {
                       strWhere += "zy_presorder.PRESDEPTCODE" + oleDb.EuqalTo() + "'" + CureDeptCode + "'" + oleDb.And() + " ";
                   }
                   string strWhere_1 = "a.zyfp_code" + oleDb.EuqalTo() + "b.code";
                   string childtable_1 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_ZYFP", "b"), "aa", strWhere_1,
                               "a.code",
                               oleDb.FiledNameBM("b.item_name", "itemname"));
                   string strWhere_2 = "aa.code" + oleDb.EuqalTo() + "zy_presorder.itemtype";
                   string childtable_2 = oleDb.ChildTable(childtable_1, "itemname", strWhere_2,
                               "itemname");
                   string sum_3 = oleDb.Sum("TOTAL_FEE", "tolal_fee");
                   string date_1_4 = oleDb.Date("ACCOUNTDATE");

                   string strWhere_6 = strWhere + "zy_account.accountid" + oleDb.EuqalTo() + "zy_costmaster.accountid" 
                       + oleDb.And() + "zy_costmaster.costmasterid" + oleDb.EuqalTo() + "zy_presorder.costmasterid"
                       + oleDb.And() + "zy_presorder.charge_flag" + oleDb.EuqalTo() + "1"; 
                   string childtable_3 = oleDb.ChildTable("ZY_ACCOUNT ,ZY_COSTMASTER ,ZY_PRESORDER", "d", strWhere_6,
                               "zy_presorder.PATID",
                                 "zy_presorder.PRESDEPTCODE",
                                    childtable_2,
                               oleDb.FiledNameBM("zy_presorder.tolal_fee", "total_fee"));
                   strsql = oleDb.Table(childtable_3 + "group by d.PRESDEPTCODE,d.PATID,d.itemname", "", "",
                               "PRESDEPTCODE",
                               "PATID",
                               "itemname",
                                sum_3);
               }
               else if (base.costItemType == CostItemType.核算项目 && base.costItemStyle == CostItemStyle.记账日期)
               {
                   strWhere = "";
                   if (Bdate != null && Edate != null)
                   {
                       string date_str = oleDb.Date("COSTDATE");
                       strWhere += date_str + oleDb.GreaterThanAndEqualTo() + "'" + Bdate.Value.Date + "'" + oleDb.And() + date_str + oleDb.LessThanAndEqualTo() + "'" + Edate.Value.Date + "'" + oleDb.And() + " ";
                   }
                   if (CureDeptCode != null)
                   {
                       strWhere += "PRESDEPTCODE "+ oleDb.EuqalTo() + "'" + CureDeptCode + "'" + oleDb.And() + " ";
                   }
                   string strWhere_2 = "a." + "HS_CODE" + oleDb.EuqalTo() + "b.CODE";
                   string childtable_2 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_HS", "b"), "aa", strWhere_2,
                                "a.CODE",
                               oleDb.FiledNameBM("b." + "ITEM_NAME", "itemname"));
                   string sum_3 = oleDb.Sum("TOLAL_FEE", "TOLAL_FEE");
                   string date_1_4 = oleDb.Date("COSTDATE");
                   string _gs_1_5 = "aa.code";
                   string _gs_1_6 = "ITEMTYPE";
                   string strWhere_7 = _gs_1_5 + oleDb.EuqalTo() + _gs_1_6;
                   string childtable_3 = oleDb.ChildTable(childtable_2, "itemname", strWhere_7,
                               "itemname");
                   string strWhere_8 = strWhere + "CHARGE_FLAG" + oleDb.EuqalTo() + "1";
                   string childtable_4 = oleDb.ChildTable("ZY_PRESORDER", "D", strWhere_8,
                                 "PATID",
                                 "PRESDEPTCODE",
                                 //"ITEMTYPE,
                                childtable_3,
                                "TOLAL_FEE");
                   strsql = oleDb.Table(childtable_4, "  group by d.PRESDEPTCODE,d.PATID,d.itemname ", "",
                               "PRESDEPTCODE",
                               "PATID",
                               "itemname",
                                sum_3);
               }
               else if (base.costItemType == CostItemType.核算项目 && base.costItemStyle == CostItemStyle.结帐日期)
               {
                   strWhere = "";
                   if (Bdate != null && Edate != null)
                   {
                       string date_str = oleDb.Date("ACCOUNTDATE");
                       strWhere += date_str + oleDb.GreaterThanAndEqualTo() + "'" + Bdate.Value.Date + "'" + oleDb.And() + date_str + oleDb.LessThanAndEqualTo() + "'" + Edate.Value.Date + "'" + oleDb.And() + " ";
                   }
                   if (CureDeptCode != null)
                   {
                       strWhere += "zy_presorder.PRESDEPTCODE" + oleDb.EuqalTo() + "'" + CureDeptCode + "'" + oleDb.And() + " ";
                   }
                   string strWhere_1 = "a.HS_CODE" + oleDb.EuqalTo() + "b.code";
                   string childtable_1 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_HS", "b"), "aa", strWhere_1,
                               "a.code",
                               oleDb.FiledNameBM("b.item_name", "itemname"));


                   string strWhere_2 = "aa.code" + oleDb.EuqalTo() + "zy_presorder.itemtype";
                   string childtable_2 = oleDb.ChildTable(childtable_1, "itemname", strWhere_2,
                               "itemname");


                   string sum_3 = oleDb.Sum("TOTAL_FEE", "tolal_fee");
                   string date_1_4 = oleDb.Date("ACCOUNTDATE");

                   string strWhere_6 = strWhere + "zy_account.accountid" + oleDb.EuqalTo() + "zy_costmaster.accountid" 
                       + oleDb.And() + "zy_costmaster.costmasterid" + oleDb.EuqalTo() + "zy_presorder.costmasterid"
                       + oleDb.And() + "zy_presorder.charge_flag" + oleDb.EuqalTo() + "1";
                   string childtable_3 = oleDb.ChildTable("ZY_ACCOUNT,ZY_COSTMASTER,ZY_PRESORDER", "d", strWhere_6,
                               "zy_presorder.PRESDEPTCODE",
                               "zy_presorder.PATID",
                               childtable_2,
                               oleDb.FiledNameBM("zy_presorder.tolal_fee", "total_fee"));
                   strsql = oleDb.Table(childtable_3 + "group by d.PRESDEPTCODE,d.PATID,d.itemname", "", "",
                               "PRESDEPTCODE",
                               "PATID",
                               "itemname",
                                sum_3);
               }
               #endregion
               dt[0] = oleDb.GetDataTable(strsql);//得到所有费用
               #region 科室医生
               strsql = "";
               if (base.costItemStyle == CostItemStyle.记账日期)
               {

                   string strWhere_2 = "";
                   if (Bdate != null && Edate != null)
                   {
                       string date_1_1 = oleDb.Date("costdate");
                       strWhere_2 = date_1_1 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'"
                       + oleDb.And() + date_1_1 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" + oleDb.And();
                   }

                   if (IsInHis)
                   {
                       strWhere_2 += "b.pattype " + oleDb.In("'1'", "'2'") + oleDb.And() + " ";
                   }
                   else
                   {
                       strWhere_2 += "b.pattype " + oleDb.In("'3'", "'4'", "'5'") + oleDb.And() + " ";
                   }
                   if (CureDeptCode != null)
                   {
                       strWhere_2 += "a.PRESDEPTCODE " + oleDb.EuqalTo() + "'" + CureDeptCode + "'" + oleDb.And() + " ";
                   }
                   strWhere_2 += "CHARGE_FLAG" + oleDb.EuqalTo() + "1"
                       + oleDb.And() + "a.patlistid " + oleDb.EuqalTo() + "b.patlistid "

                       + oleDb.GroupBy() + "a.PRESDEPTCODE,a.PATID";
                   strsql = oleDb.Table(oleDb.TableNameBM("ZY_PRESORDER", "a") +","+ oleDb.TableNameBM("ZY_PATLIST", "b"), "", strWhere_2,
                               "a.PRESDEPTCODE",
                               "a.PATID");
               }
               else if (base.costItemStyle == CostItemStyle.结帐日期)
               {
                   string strWhere_2 = "";

                   if (Bdate != null && Edate != null)
                   {
                       string date_1_1 = oleDb.Date("ACCOUNTDATE");
                       strWhere_2 = date_1_1 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'"
                          + oleDb.And() + date_1_1 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'"
                          + oleDb.And();
                   }
                   if (IsInHis)
                   {
                       strWhere_2 += "b.pattype " + oleDb.In("'1'", "'2'") + oleDb.And() + " ";
                   }
                   else
                   {
                       strWhere_2 += "b.pattype " + oleDb.In("'3'", "'4'", "'5'") + oleDb.And() + " ";
                   }
                   if (CureDeptCode != null)
                   {
                       strWhere_2 += "a.PRESDEPTCODE " + oleDb.EuqalTo() + "'" + CureDeptCode + "'" + oleDb.And() + " ";
                   }

                   strWhere_2 += "ZY_ACCOUNT.ACCOUNTID" + oleDb.EuqalTo() + " zy_costmaster.accountid "
                   + oleDb.And() + "ZY_COSTMASTER.COSTMASTERID" + oleDb.EuqalTo() + " a.COSTMASTERID "
                   + oleDb.GroupBy() + "a.PRESDEPTCODE,a.PATID";
                   strsql = oleDb.Table("ZY_ACCOUNT,ZY_COSTMASTER ," + oleDb.TableNameBM("ZY_PRESORDER","a")+","+oleDb.TableNameBM("ZY_PATLIST","b"), "", strWhere_2,
                               "a.PRESDEPTCODE",
                               "a.PATID");
               }
               #endregion            
               dt[1] = oleDb.GetDataTable(strsql);//得到统计的科室
               return dt;

           }
           catch (System.Exception e)
           {
               throw new Exception(e.Message);
           }
        }
    }
    /// <summary>
    /// 按开方科室和开方医生统计
    /// </summary>
    public class PresDeptAndDocReport : ReportStat
    {

        public override DataTable[] GetReportData()
        {
            try
            {
                string strsql = null;
                DataTable[] dt = new DataTable[2];

                #region 费用
                if ((base.costItemType == CostItemType.发票项目) && (base.costItemStyle == CostItemStyle.记账日期))
                {


                    string strWhere_2 = "a." + "ZYFP_CODE" + oleDb.EuqalTo() + "b.CODE";
                    string childtable_2 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_ZYFP", "b"), "aa", strWhere_2,
                                 "a." + "CODE",
                                oleDb.FiledNameBM("b.ITEM_NAME", "itemname"));

                    string sum_3 = oleDb.Sum("TOLAL_FEE", "TOLAL_FEE");
                    string date_1_4 = oleDb.Date("COSTDATE");
                    string _gs_1_5 = "aa.code";
                    string _gs_1_6 = "ITEMTYPE";
                    string strWhere_7 = _gs_1_5 + oleDb.EuqalTo() + _gs_1_6;
                    string childtable_3 = oleDb.ChildTable(childtable_2, "itemname", strWhere_7,
                                "itemname");
                    string strWhere_8 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'" + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" + oleDb.And() + "CHARGE_FLAG "+ oleDb.EuqalTo() + "1";
                    string childtable_4 = oleDb.ChildTable("ZY_PRESORDER", "D", strWhere_8,
                                "PATLISTID",
                                  oleDb.FiledNameBM("PRESDEPTCODE", "currdeptcode"),
                                  oleDb.FiledNameBM("PRESDOCCODE","CHARGECODE"),
                                  "ITEMTYPE",
                                 childtable_3,
                                 "TOLAL_FEE");
                    strsql = oleDb.Table(childtable_4, "  group by d.currdeptcode,d.CHARGECODE,d.itemname ", "",
                                "currdeptcode",
                                "CHARGECODE",
                                "itemname",
                                 sum_3);

                }
                else if (base.costItemType == CostItemType.发票项目 && base.costItemStyle == CostItemStyle.结帐日期)
                {
                    string strWhere_1 = "a.zyfp_code" + oleDb.EuqalTo() + "b.code";
                    string childtable_1 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_ZYFP", "b"), "aa", strWhere_1,
                                "a.code",
                                oleDb.FiledNameBM("b.item_name", "itemname"));
                    string strWhere_2 = "aa.code" + oleDb.EuqalTo() + "zy_presorder.itemtype";
                    string childtable_2 = oleDb.ChildTable(childtable_1, "itemname", strWhere_2,
                                "itemname");
                    string sum_3 = oleDb.Sum("TOTAL_FEE", "tolal_fee");
                    string date_1_4 = oleDb.Date("ACCOUNTDATE");

                    string strWhere_6 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'" 
                        + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" 
                        + oleDb.And() + "zy_account.accountid" + oleDb.EuqalTo() + "zy_costmaster.accountid" 
                        + oleDb.And() + "zy_costmaster.costmasterid" + oleDb.EuqalTo() + "zy_presorder.costmasterid"
                        + oleDb.And() + "zy_presorder.charge_flag" + oleDb.EuqalTo() + "1";
                    string childtable_3 = oleDb.ChildTable("ZY_ACCOUNT,ZY_COSTMASTER ,ZY_PRESORDER", "d", strWhere_6,
                                oleDb.FiledNameBM("zy_presorder.PRESDEPTCODE", "currdeptcode"),
                                   oleDb.FiledNameBM("zy_presorder.PRESDOCCODE", "chargecode"),
                                     childtable_2,
                                oleDb.FiledNameBM("zy_presorder.tolal_fee", "total_fee"));
                    strsql = oleDb.Table(childtable_3 + "group by d.currdeptcode,d.chargecode,d.itemname", "", "",
                                "currdeptcode",
                                "chargecode",
                                "itemname",
                                 sum_3);

                }
                else if (base.costItemType == CostItemType.核算项目 && base.costItemStyle == CostItemStyle.记账日期)
                {
                    string strWhere_2 = "a." + "HS_CODE" + oleDb.EuqalTo() + "b.CODE";
                    string childtable_2 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_HS", "b"), "aa", strWhere_2,
                                 "a.CODE",
                                oleDb.FiledNameBM("b.ITEM_NAME", "itemname"));
                    string sum_3 = oleDb.Sum("TOLAL_FEE", "TOLAL_FEE");
                    string date_1_4 = oleDb.Date("COSTDATE");
                    string _gs_1_5 = "aa.code";
                    string _gs_1_6 = "ITEMTYPE";
                    string strWhere_7 = _gs_1_5 + oleDb.EuqalTo() + _gs_1_6;
                    string childtable_3 = oleDb.ChildTable(childtable_2, "itemname", strWhere_7,
                                "itemname");
                    string strWhere_8 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'" + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" + oleDb.And() + "CHARGE_FLAG" + oleDb.EuqalTo() + "1";
                    string childtable_4 = oleDb.ChildTable("ZY_PRESORDER", "D", strWhere_8,
                                "PATLISTID",
                                  oleDb.FiledNameBM("PRESDEPTCODE", "currdeptcode"),
                                  oleDb.FiledNameBM("PRESDOCCODE", "CHARGECODE"),
                                  "ITEMTYPE",
                                 childtable_3,
                                 "TOLAL_FEE");
                    strsql = oleDb.Table(childtable_4, "  group by d.currdeptcode,d.CHARGECODE,d.itemname ", "",
                                "currdeptcode",
                                "CHARGECODE",
                                "itemname",
                                 sum_3);

                }
                else if (base.costItemType == CostItemType.核算项目 && base.costItemStyle == CostItemStyle.结帐日期)
                {
                    string strWhere_1 = "a.HS_CODE" + oleDb.EuqalTo() + "b.code";
                    string childtable_1 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_HS", "b"), "aa", strWhere_1,
                                "a.code",
                                oleDb.FiledNameBM("b.item_name", "itemname"));


                    string strWhere_2 = "aa.code" + oleDb.EuqalTo() + "zy_presorder.itemtype";
                    string childtable_2 = oleDb.ChildTable(childtable_1, "itemname", strWhere_2,
                                "itemname");


                    string sum_3 = oleDb.Sum("TOTAL_FEE", "tolal_fee");
                    string date_1_4 = oleDb.Date("ACCOUNTDATE");

                    string strWhere_6 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'" 
                        + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" 
                        + oleDb.And() + "zy_account.accountid" + oleDb.EuqalTo() + "zy_costmaster.accountid" 
                        + oleDb.And() + "zy_costmaster.costmasterid" + oleDb.EuqalTo() + "zy_presorder.costmasterid"
                        + oleDb.And() + "zy_presorder.charge_flag" + oleDb.EuqalTo() + "1";
                    string childtable_3 = oleDb.ChildTable("ZY_ACCOUNT,ZY_COSTMASTER ,ZY_PRESORDER", "d", strWhere_6,
                                oleDb.FiledNameBM("zy_presorder.PRESDEPTCODE", "currdeptcode"),
                                   oleDb.FiledNameBM("zy_presorder.PRESDOCCODE", "chargecode"),
                                     childtable_2,
                                oleDb.FiledNameBM("zy_presorder.tolal_fee", "total_fee"));
                    strsql = oleDb.Table(childtable_3 + "group by d.currdeptcode,d.chargecode,d.itemname", "", "",
                                "currdeptcode",
                                "chargecode",
                                "itemname",
                                 sum_3);
                }
                dt[0] = oleDb.GetDataTable(strsql);//得到所有费用
                #endregion

                #region 医生科室
                strsql = "";
                if (base.costItemStyle == CostItemStyle.记账日期)
                {
                    string date_1_1 = oleDb.Date("costdate");
                    string strWhere_2 = date_1_1 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'"
                        + oleDb.And() + date_1_1 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'"
                        + oleDb.And() + "CHARGE_FLAG" + oleDb.EuqalTo() + "1"
                        + oleDb.GroupBy() + "PRESDEPTCODE,PRESDOCCODE";
                    strsql = oleDb.Table("ZY_PRESORDER", "", strWhere_2,
                                oleDb.FiledNameBM("PRESDEPTCODE","EXECDEPTCODE"),
                                oleDb.FiledNameBM("PRESDOCCODE","CHARGECODE"));
                }
                else if (base.costItemStyle == CostItemStyle.结帐日期)
                {
                    string date_1_1 = oleDb.Date("ACCOUNTDATE");
                    string strWhere_2 = date_1_1 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'"
                        + oleDb.And() + date_1_1 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'"
                        + oleDb.And() + "ZY_ACCOUNT.ACCOUNTID" + oleDb.EuqalTo() + " zy_costmaster.accountid "
                        + oleDb.And() + "ZY_COSTMASTER.COSTMASTERID" + oleDb.EuqalTo() + " ZY_PRESORDER.COSTMASTERID "
                        + oleDb.GroupBy() + "ZY_PRESORDER.PRESDEPTCODE,ZY_PRESORDER.PRESDOCCODE";
                    strsql = oleDb.Table("ZY_ACCOUNT,ZY_COSTMASTER,ZY_PRESORDER", "", strWhere_2,
                               oleDb.FiledNameBM("PRESDEPTCODE", "EXECDEPTCODE"),
                                oleDb.FiledNameBM("PRESDOCCODE", "CHARGECODE"));
                }

                dt[1] = oleDb.GetDataTable(strsql);//得到统计的科室
                #endregion

                return dt;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    /// <summary>
    /// 按开方医生统计
    /// </summary>
    public class PresDocReport : ReportStat
    {

        public override DataTable[] GetReportData()
        {
            try
            {
                string strsql = null;
                DataTable[] dt = new DataTable[2];

                #region 费用
                if ((base.costItemType == CostItemType.发票项目) && (base.costItemStyle == CostItemStyle.记账日期))
                {


                    string strWhere_2 = "a." + "ZYFP_CODE" + oleDb.EuqalTo() + "b.CODE";
                    string childtable_2 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_ZYFP", "b"), "aa", strWhere_2,
                                 "a.CODE",
                                oleDb.FiledNameBM("b.TEM_NAME", "itemname"));

                    string sum_3 = oleDb.Sum("TOLAL_FEE", "TOLAL_FEE");
                    string date_1_4 = oleDb.Date("COSTDATE");
                    string _gs_1_5 = "aa.code";
                    string _gs_1_6 = "ITEMTYPE";
                    string strWhere_7 = _gs_1_5 + oleDb.EuqalTo() + _gs_1_6;
                    string childtable_3 = oleDb.ChildTable(childtable_2, "itemname", strWhere_7,
                                "itemname");
                    string strWhere_8 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'" 
                        + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" 
                        + oleDb.And() + "CHARGE_FLAG" + oleDb.EuqalTo() + "1";
                    string childtable_4 = oleDb.ChildTable("ZY_PRESORDER", "D", strWhere_8,
                                "PATLISTID",
                                  oleDb.FiledNameBM("PRESDEPTCODE", "currdeptcode"),
                                  oleDb.FiledNameBM("PRESDOCCODE", "CHARGECODE"),
                                  "ITEMTYPE",
                                 childtable_3,
                                 "TOLAL_FEE");
                    strsql = oleDb.Table(childtable_4, "  group by d.CHARGECODE,d.itemname ", "",
                                "CHARGECODE",
                                "itemname",
                                 sum_3);

                }
                else if (base.costItemType == CostItemType.发票项目 && base.costItemStyle == CostItemStyle.结帐日期)
                {
                    string strWhere_1 = "a.zyfp_code" + oleDb.EuqalTo() + "b.code";
                    string childtable_1 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_ZYFP", "b"), "aa", strWhere_1,
                                "a.code",
                                oleDb.FiledNameBM("b.item_name", "itemname"));
                    string strWhere_2 = "aa.code" + oleDb.EuqalTo() + "zy_presorder.itemtype";
                    string childtable_2 = oleDb.ChildTable(childtable_1, "itemname", strWhere_2,
                                "itemname");
                    string sum_3 = oleDb.Sum("TOTAL_FEE", "tolal_fee");
                    string date_1_4 = oleDb.Date("ACCOUNTDATE");

                    string strWhere_6 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'"
                        + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'"
                        + oleDb.And() + "zy_account.accountid" + oleDb.EuqalTo() + "zy_costmaster.accountid"
                        + oleDb.And() + "zy_costmaster.costmasterid" + oleDb.EuqalTo() + "zy_presorder.costmasterid"
                        + oleDb.And() + "zy_presorder.charge_flag" + oleDb.EuqalTo() + "1";
                    string childtable_3 = oleDb.ChildTable("ZY_ACCOUNT,ZY_COSTMASTER ,ZY_PRESORDER", "d", strWhere_6,
                                oleDb.FiledNameBM("zy_presorder.PRESDEPTCODE", "currdeptcode"),
                                   oleDb.FiledNameBM("zy_presorder.PRESDOCCODE", "chargecode"),
                                     childtable_2,
                                oleDb.FiledNameBM("zy_presorder.tolal_fee", "total_fee"));
                    strsql = oleDb.Table(childtable_3 + "group by d.chargecode,d.itemname", "", "",
                                "chargecode",
                                "itemname",
                                 sum_3);

                }
                else if (base.costItemType == CostItemType.核算项目 && base.costItemStyle == CostItemStyle.记账日期)
                {
                    string strWhere_2 = "a." + "HS_CODE" + oleDb.EuqalTo() + "b.CODE";
                    string childtable_2 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_HS", "b"), "aa", strWhere_2,
                                 "a." + "CODE",
                                oleDb.FiledNameBM("b." + "ITEM_NAME", "itemname"));
                    string sum_3 = oleDb.Sum("TOLAL_FEE", "TOLAL_FEE");
                    string date_1_4 = oleDb.Date("COSTDATE");
                    string _gs_1_5 = "aa.code";
                    string _gs_1_6 = "ITEMTYPE";
                    string strWhere_7 = _gs_1_5 + oleDb.EuqalTo() + _gs_1_6;
                    string childtable_3 = oleDb.ChildTable(childtable_2, "itemname", strWhere_7,
                                "itemname");
                    string strWhere_8 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'" 
                        + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" 
                        + oleDb.And() + "CHARGE_FLAG" + oleDb.EuqalTo() + "1";
                    string childtable_4 = oleDb.ChildTable("ZY_PRESORDER", "D", strWhere_8,
                                "PATLISTID",
                                  oleDb.FiledNameBM("PRESDEPTCODE", "currdeptcode"),
                                  oleDb.FiledNameBM("PRESDOCCODE", "CHARGECODE"),
                                  "ITEMTYPE",
                                 childtable_3,
                                 "TOLAL_FEE");
                    strsql = oleDb.Table(childtable_4, "  group by d.CHARGECODE,d.itemname ", "",
                               
                                "CHARGECODE",
                                "itemname",
                                 sum_3);

                }
                else if (base.costItemType == CostItemType.核算项目 && base.costItemStyle == CostItemStyle.结帐日期)
                {
                    string strWhere_1 = "a.HS_CODE" + oleDb.EuqalTo() + "b.code";
                    string childtable_1 = oleDb.ChildTable(oleDb.TableNameBM("BASE_STAT_ITEM", "a") + "," + oleDb.TableNameBM("BASE_STAT_HS", "b"), "aa", strWhere_1,
                                "a.code",
                                oleDb.FiledNameBM("b.item_name", "itemname"));


                    string strWhere_2 = "aa.code" + oleDb.EuqalTo() + "zy_presorder.itemtype";
                    string childtable_2 = oleDb.ChildTable(childtable_1, "itemname", strWhere_2,
                                "itemname");


                    string sum_3 = oleDb.Sum("TOTAL_FEE", "tolal_fee");
                    string date_1_4 = oleDb.Date("ACCOUNTDATE");

                    string strWhere_6 = date_1_4 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'" 
                        + oleDb.And() + date_1_4 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'" 
                        + oleDb.And() + "zy_account.accountid" + oleDb.EuqalTo() + "zy_costmaster.accountid" 
                        + oleDb.And() + "zy_costmaster.costmasterid" + oleDb.EuqalTo() + "zy_presorder.costmasterid"
                        + oleDb.And() + "zy_presorder.charge_flag" + oleDb.EuqalTo() + "1";
                    string childtable_3 = oleDb.ChildTable("ZY_ACCOUNT ,ZY_COSTMASTER ,ZY_PRESORDER", "d", strWhere_6,
                                oleDb.FiledNameBM("zy_presorder.PRESDEPTCODE", "currdeptcode"),
                                   oleDb.FiledNameBM("zy_presorder.PRESDOCCODE", "chargecode"),
                                     childtable_2,
                                oleDb.FiledNameBM("zy_presorder.tolal_fee", "total_fee"));
                    strsql = oleDb.Table(childtable_3 + "group by d.chargecode,d.itemname", "", "",
                              
                                "chargecode",
                                "itemname",
                                 sum_3);
                }
                dt[0] = oleDb.GetDataTable(strsql);//得到所有费用
                #endregion

                #region 医生
                strsql = "";
                if (base.costItemStyle == CostItemStyle.记账日期)
                {
                    string date_1_1 = oleDb.Date("costdate");
                    string strWhere_2 = date_1_1 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'"
                        + oleDb.And() + date_1_1 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'"
                        + oleDb.And() + "CHARGE_FLAG" + oleDb.EuqalTo() + "1"
                        + oleDb.GroupBy() + "PRESDOCCODE";
                    strsql = oleDb.Table("ZY_PRESORDER", "", strWhere_2,
                                oleDb.FiledNameBM("PRESDOCCODE", "CHARGECODE"));
                }
                else if (base.costItemStyle == CostItemStyle.结帐日期)
                {
                    string date_1_1 = oleDb.Date("ACCOUNTDATE");
                    string strWhere_2 = date_1_1 + oleDb.GreaterThanAndEqualTo() + "'" + base.Bdate.Value.Date + "'"
                        + oleDb.And() + date_1_1 + oleDb.LessThanAndEqualTo() + "'" + base.Edate.Value.Date + "'"
                        + oleDb.And() + "ZY_ACCOUNT.ACCOUNTID" + oleDb.EuqalTo() + " zy_costmaster.accountid "
                        + oleDb.And() + "ZY_COSTMASTER.COSTMASTERID" + oleDb.EuqalTo() + " ZY_PRESORDER.COSTMASTERID "
                        + oleDb.GroupBy() + "ZY_PRESORDER.PRESDOCCODE";
                    strsql = oleDb.Table("ZY_ACCOUNT,ZY_COSTMASTER,ZY_PRESORDER", "", strWhere_2,
                                oleDb.FiledNameBM("PRESDOCCODE", "CHARGECODE"));
                }

                dt[1] = oleDb.GetDataTable(strsql);//得到统计的科室
                #endregion

                return dt;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}
