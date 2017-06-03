using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.Dao;
using HIS.ZY_BLL.DataModel;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZY_BLL.Dao.FeeBillManager;

namespace HIS.ZY_BLL.ObjectModel.FeeBillManager
{
    public class FeeBillManager : IbaseDao
    {
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

        #endregion

        public FeeBillManager()
        {
            _oleDb = BaseBLL.oleDb;
        }

        public FeeBillManager(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;
        }


        /// <summary>
        /// 得到病人费用清单（已记账的）
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public  DataTable GetPresDataTable(int patlistid, DateTime? Bdate, DateTime? Edate)
        {
            try
            {

                string strWhere = null;
                strWhere = "PATLISTID" + oleDb.EuqalTo() + patlistid + oleDb.And() + "CHARGE_FLAG" + oleDb.EuqalTo() + "1 ";

                string date_1_3 = null;
                if (OP_ZYConfigSetting.GetConfigValue("003") == 0)
                {
                    date_1_3 = oleDb.Date("PRESDATE");
                }
                else
                {
                    date_1_3 = oleDb.Date("COSTDATE");
                }
                if (Bdate != null && Edate != null)
                {
                    strWhere += oleDb.And() + date_1_3 + oleDb.GreaterThanAndEqualTo() + "'" + Bdate.Value.Date + "'"
                        + oleDb.And() + date_1_3 + oleDb.LessThanAndEqualTo() + "'" + Edate.Value.Date + "' ";
                }

                strWhere += oleDb.OrderBy("COSTDATE");
                List<ZY_PresOrder> zyPres = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                for (int i = 0; i < zyPres.Count; i++)
                {
                    zyPres[i].LoadData();
                }

                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyPres);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人费用清单（已记账的），转科病人分开打
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public  DataTable GetPresDataTable(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate)
        {
            try
            {

                string strWhere = null;
                strWhere = "PATLISTID" + oleDb.EuqalTo() + patlistid
                    + oleDb.And()
                    + "PRESDEPTCODE" + oleDb.EuqalTo() + "'" + presdeptcode + "'"
                    + oleDb.And()
                    + "CHARGE_FLAG" + oleDb.EuqalTo() + "1 ";

                string date_1_3 = null;
                if (OP_ZYConfigSetting.GetConfigValue("003") == 0)
                {
                    date_1_3 = oleDb.Date("PRESDATE");
                }
                else
                {
                    date_1_3 = oleDb.Date("COSTDATE");
                }
                if (Bdate != null && Edate != null)
                {
                    strWhere += oleDb.And() + date_1_3 + oleDb.GreaterThanAndEqualTo() + "'" + Bdate.Value.Date + "'"
                        + oleDb.And() + date_1_3 + oleDb.LessThanAndEqualTo() + "'" + Edate.Value.Date + "' ";
                }

                strWhere += oleDb.OrderBy("COSTDATE");
                List<ZY_PresOrder> zyPres = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                for (int i = 0; i < zyPres.Count; i++)
                {
                    zyPres[i].LoadData();
                }

                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyPres);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 得到病人费用清单(项目汇总)
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public  DataTable GetPresTotalData(int patlistid, DateTime? Bdate, DateTime? Edate)
        {
            try
            {
                IfeeBillManager ifbmD = DaoFactory.GetObject<IfeeBillManager>(typeof(FeeBillManagerDao));
                ifbmD.oleDb = oleDb;
                return ifbmD.GetPresTotalData(patlistid, Bdate, Edate);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人费用清单(项目汇总),转科病人分开打
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public DataTable GetPresTotalData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate)
        {
            try
            {
                IfeeBillManager ifbmD = DaoFactory.GetObject<IfeeBillManager>(typeof(FeeBillManagerDao));
                ifbmD.oleDb = oleDb;
                return ifbmD.GetPresTotalData(patlistid,presdeptcode, Bdate, Edate);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 得到病人费用清单(项目分组汇总)
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public DataTable GetPresTotalGroupData(int patlistid, DateTime? Bdate, DateTime? Edate)
        {
            try
            {
                IfeeBillManager ifbmD = DaoFactory.GetObject<IfeeBillManager>(typeof(FeeBillManagerDao));
                ifbmD.oleDb = oleDb;
                return ifbmD.GetPresTotalGroupData(patlistid, Bdate, Edate);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人费用清单(项目分组汇总),转科病人分开打
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public DataTable GetPresTotalGroupData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate)
        {
            try
            {
                IfeeBillManager ifbmD = DaoFactory.GetObject<IfeeBillManager>(typeof(FeeBillManagerDao));
                ifbmD.oleDb = oleDb;
                return ifbmD.GetPresTotalGroupData(patlistid, presdeptcode, Bdate, Edate);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 得到病人费用清单(核算汇总)
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public DataTable GetCostCalData(int patlistid, DateTime? Bdate, DateTime? Edate)
        {
            try
            {
                IfeeBillManager ifbmD = DaoFactory.GetObject<IfeeBillManager>(typeof(FeeBillManagerDao));
                ifbmD.oleDb = oleDb;
                return ifbmD.GetCostCalData(patlistid, Bdate, Edate);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人费用清单(核算汇总)，转科病人分开打
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public DataTable GetCostCalData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate)
        {
            try
            {
                IfeeBillManager ifbmD = DaoFactory.GetObject<IfeeBillManager>(typeof(FeeBillManagerDao));
                ifbmD.oleDb = oleDb;
                return ifbmD.GetCostCalData(patlistid, presdeptcode, Bdate, Edate);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 得到病人的一日清单
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public DataTable GetCostDayData(int patlistid, DateTime? Bdate, DateTime? Edate)
        {
            try
            {
                IfeeBillManager ifbmD = DaoFactory.GetObject<IfeeBillManager>(typeof(FeeBillManagerDao));
                ifbmD.oleDb = oleDb;
                return ifbmD.GetCostDayData(patlistid, Bdate, Edate);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 得到病人的一日清单,转科病人分开打
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <returns></returns>
        public DataTable GetCostDayData(int patlistid, string presdeptcode, DateTime? Bdate, DateTime? Edate)
        {
            try
            {
                IfeeBillManager ifbmD = DaoFactory.GetObject<IfeeBillManager>(typeof(FeeBillManagerDao));
                ifbmD.oleDb = oleDb;
                return ifbmD.GetCostDayData(patlistid, presdeptcode, Bdate, Edate);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 打印费用项目加入医保类型
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sType">1.项目组合2.项目明细3.项目分组</param>
        /// <returns></returns>
        public DataTable GetFeeType(DataTable dtt, string sType, out decimal alldec, out decimal firstFee, out decimal secondFee,out decimal otherFee)
        {
            try
            {
                //DataView dv = dtt.DefaultView;
                //dv.Sort = "itemtypename Asc";
                //dtt = dv.ToTable();

                alldec = 0;
                firstFee = 0;
                secondFee = 0;
                otherFee = 0;
                IfeeBillManager ifbmD = DaoFactory.GetObject<IfeeBillManager>(typeof(FeeBillManagerDao));
                ifbmD.oleDb = oleDb;
                DataTable drugData = ifbmD.GetBaseData(0);
                DataTable projectData = ifbmD.GetBaseData(1);
                DataTable projectGroupData = ifbmD.GetBaseData(2);
                DataTable projectGroupMXData = ifbmD.GetBaseData(3);

                DataTable dt = dtt.Clone();
                if (dtt.Rows.Count == 0) return dtt;
                dt.Columns["ITEMID"].DataType = typeof(string);
                for (int i = 0; i < dtt.Rows.Count; i++)
                {

                    if (Convert.ToDecimal(dtt.Rows[i]["amount"]) == 0)
                        continue;

                    if (Convert.ToInt32(dtt.Rows[i]["PRESTYPE"]) == 4)//项目（基本项目）
                    {
                        #region 基本项目
                        DataRow dr = dt.NewRow();
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            dr[k] = dtt.Rows[i][k];
                        }
                        string itemid = dr["ITEMID"].ToString();
                        DataRow[] drs = projectData.Select("itemid=" + itemid);
                        if (drs.Length != 0)
                        {
                            if (drs[0] != null)
                            {
                                dr["itemid"] = drs[0]["d_code"];

                                if (HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(drs[0]["insur_type"], "").ToString().Trim() == "甲")
                                {
                                    dr["itemname"] = "★" + dr["itemname"].ToString();
                                    firstFee += Convert.ToDecimal(dr["tolal_fee"]);
                                }
                                else if (HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(drs[0]["insur_type"], "").ToString().Trim() == "乙")
                                {
                                    dr["itemname"] = "☆" + dr["itemname"].ToString();
                                    secondFee += Convert.ToDecimal(dr["tolal_fee"]);
                                }
                            }
                        }
                        dt.Rows.Add(dr);
                        #endregion
                    }
                    else if (Convert.ToInt32(dtt.Rows[i]["PRESTYPE"]) == 5)//项目（组合项目）
                    {

                        if (OP_ZYConfigSetting.GetConfigValue("001") == 0)
                        {
                            #region 组合项目

                            DataRow dr = dt.NewRow();
                            for (int k = 0; k < dt.Columns.Count; k++)
                            {
                                dr[k] = dtt.Rows[i][k];
                            }
                            string itemid = dr["ITEMID"].ToString();
                            DataRow[] drs = projectGroupData.Select("itemid=" + itemid);
                            if (drs.Length != 0)
                            {
                                if (drs[0] != null)
                                {
                                    dr["itemid"] = drs[0]["d_code"];

                                    if (XcConvert.IsNull(drs[0]["insur_type"], "").ToString().Trim() == "甲")
                                    {
                                        dr["itemname"] = "★" + dr["itemname"].ToString();
                                        firstFee += Convert.ToDecimal(dr["tolal_fee"]);
                                    }
                                    else if (XcConvert.IsNull(drs[0]["insur_type"], "").ToString().Trim() == "乙")
                                    {
                                        dr["itemname"] = "☆" + dr["itemname"].ToString();
                                        secondFee += Convert.ToDecimal(dr["tolal_fee"]);
                                    }
                                }
                            }
                            dt.Rows.Add(dr);

                            #endregion
                        }
                        else
                        {
                            #region 组合项目明细
                            if (sType == "1")//项目组合
                            {
                                #region 项目组合
                                string itemid = dtt.Rows[i]["ITEMID"].ToString();
                                DataRow[] drs = projectGroupMXData.Select("complex_id=" + itemid);
                                if (drs.Length != 0)
                                {
                                    for (int j = 0; j < drs.Length; j++)
                                    {
                                        DataRow dr = dt.NewRow();
                                        for (int k = 0; k < dt.Columns.Count; k++)
                                        {
                                            dr[k] = dtt.Rows[i][k];
                                        }
                                        dr["itemid"] = drs[j]["STD_CODE"];
                                        dr["prestype"] = '4';
                                        if (XcConvert.IsNull(drs[j]["insur_type"], "").ToString().Trim() == "甲")
                                        {
                                            dr["itemname"] = "★" + drs[j]["Item_name"];
                                            firstFee += Convert.ToDecimal(dr["tolal_fee"]);
                                        }
                                        else if (XcConvert.IsNull(drs[j]["insur_type"], "").ToString().Trim() == "乙")
                                        {
                                            dr["itemname"] = "☆" + drs[j]["Item_name"];
                                            secondFee += Convert.ToDecimal(dr["tolal_fee"]);
                                        }
                                        else
                                        {
                                            dr["itemname"] = drs[j]["Item_name"];
                                        }
                                        dr["packunit"] = drs[j]["item_unit"];
                                        dr["unit"] = drs[j]["item_unit"];
                                        dr["sell_price"] = drs[j]["price"];
                                        dr["amount"] = Convert.ToDecimal(drs[j]["num"]) * Convert.ToDecimal(dr["amount"]);
                                        dr["tolal_fee"] = Convert.ToString(Convert.ToDecimal(dr["sell_price"]) * Convert.ToDecimal(dr["amount"]));
                                        alldec += Convert.ToDecimal(dr["tolal_fee"]);
                                        dt.Rows.Add(dr);
                                    }
                                    alldec = alldec - Convert.ToDecimal(dtt.Rows[i]["tolal_fee"]);
                                }
                                #endregion
                            }
                            else if (sType == "2")//项目清单
                            {
                                #region 项目清单
                                string itemid = dtt.Rows[i]["ITEMID"].ToString();
                                DataRow[] drs = projectGroupMXData.Select("complex_id=" + itemid);
                                if (drs.Length != 0)
                                {
                                    for (int j = 0; j < drs.Length; j++)
                                    {
                                        DataRow dr = dt.NewRow();
                                        for (int k = 0; k < dt.Columns.Count; k++)
                                        {
                                            dr[k] = dtt.Rows[i][k];
                                        }
                                        //dr["itemid"] = drs[j]["STD_CODE"];
                                        //dr["prestype"] = '4';
                                        if (XcConvert.IsNull(drs[j]["insur_type"], "").ToString().Trim() == "甲")
                                        {
                                            dr["itemname"] = "★" + drs[j]["Item_name"];
                                            firstFee += Convert.ToDecimal(dr["tolal_fee"]);
                                        }
                                        else if (XcConvert.IsNull(drs[j]["insur_type"], "").ToString().Trim() == "乙")
                                        {
                                            dr["itemname"] = "☆" + drs[j]["Item_name"];
                                            secondFee += Convert.ToDecimal(dr["tolal_fee"]);
                                        }
                                        else
                                        {
                                            dr["itemname"] = drs[j]["Item_name"];
                                        }
                                        dr["packunit"] = drs[j]["item_unit"];
                                        dr["unit"] = drs[j]["item_unit"];
                                        dr["sell_price"] = drs[j]["price"];
                                        dr["amount"] = Convert.ToDecimal(drs[j]["num"]) * Convert.ToDecimal(dr["amount"]);
                                        dr["tolal_fee"] = Convert.ToString(Convert.ToDecimal(dr["sell_price"]) * Convert.ToDecimal(dr["amount"]));
                                        alldec += Convert.ToDecimal(dr["tolal_fee"]);
                                        dt.Rows.Add(dr);
                                    }

                                    alldec = alldec - Convert.ToDecimal(dtt.Rows[i]["tolal_fee"]);
                                }
                                #endregion
                            }
                            else if (sType == "3")//项目分组
                            {
                                #region 项目分组
                                string itemid = dtt.Rows[i]["ITEMID"].ToString();
                                DataRow[] drs = projectGroupMXData.Select("complex_id=" + itemid);
                                if (drs.Length != 0)
                                {
                                    for (int j = 0; j < drs.Length; j++)
                                    {
                                        DataRow dr = dt.NewRow();
                                        for (int k = 0; k < dt.Columns.Count; k++)
                                        {
                                            dr[k] = dtt.Rows[i][k];
                                        }
                                        dr["itemid"] = drs[j]["STD_CODE"];
                                        dr["prestype"] = '4';
                                        if (XcConvert.IsNull(drs[j]["insur_type"], "").ToString().Trim() == "甲")
                                        {
                                            dr["itemname"] = "★" + drs[j]["Item_name"];
                                            firstFee += Convert.ToDecimal(dr["tolal_fee"]);
                                        }
                                        else if (XcConvert.IsNull(drs[j]["insur_type"], "").ToString().Trim() == "乙")
                                        {
                                            dr["itemname"] = "☆" + drs[j]["Item_name"];
                                            secondFee += Convert.ToDecimal(dr["tolal_fee"]);
                                        }
                                        else
                                        {
                                            dr["itemname"] = drs[j]["Item_name"];
                                        }
                                        dr["packunit"] = drs[j]["item_unit"];
                                        dr["unit"] = drs[j]["item_unit"];
                                        dr["sell_price"] = drs[j]["price"];
                                        dr["amount"] = Convert.ToDecimal(drs[j]["num"]) * Convert.ToDecimal(dr["amount"]);
                                        dr["tolal_fee"] = Convert.ToString(Convert.ToDecimal(dr["sell_price"]) * Convert.ToDecimal(dr["amount"]));
                                        alldec += Convert.ToDecimal(dr["tolal_fee"]);
                                        dt.Rows.Add(dr);
                                    }

                                    alldec = alldec - Convert.ToDecimal(dtt.Rows[i]["tolal_fee"]);
                                }
                                #endregion
                            }

                            #endregion
                        }

                    }
                    else//药品
                    {
                        #region 药品
                        DataRow dr = dt.NewRow();
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            dr[k] = dtt.Rows[i][k];
                        }

                        string itemid = dr["ITEMID"].ToString();
                        DataRow[] drs = drugData.Select("itemid=" + itemid);
                        if (drs.Length != 0)
                        {
                            if (drs[0] != null)
                            {
                                dr["itemid"] = drs[0]["d_code"];

                                if (HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(drs[0]["insur_type"], "").ToString().Trim() == "甲")
                                {
                                    dr["itemname"] = "★" + dr["itemname"].ToString();
                                    firstFee += Convert.ToDecimal(dr["tolal_fee"]);
                                }
                                else if (HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(drs[0]["insur_type"], "").ToString().Trim() == "乙")
                                {
                                    dr["itemname"] = "☆" + dr["itemname"].ToString();
                                    secondFee += Convert.ToDecimal(dr["tolal_fee"]);
                                }
                            }
                        }
                        dt.Rows.Add(dr);
                        #endregion
                    }
                }
                return dt;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
        /// <summary>
        /// 修改病人床位
        /// </summary>
        /// <param name="patlistid">病人列表ID</param>
        /// <param name="BedNo">床位号</param>
        public void AlterPatBedNo(int patlistid, string BedNo)
        {
            string strWhere = "PATLISTID" + oleDb.EuqalTo() + patlistid;
            string fieldValue = "BEDCODE" + oleDb.EuqalTo() + "'" + BedNo + "'";

            BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).Update(strWhere, fieldValue);
        }

        //得到开方医生代码
        /// <summary>
        /// 得到开方医生代码
        /// </summary>
        /// <param name="patlistid">病人listid</param>
        /// <returns></returns>
        public DataTable GetPresDeptCode(int patlistid)
        {
            return BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList("patlistid=" + patlistid, "distinct presdeptcode");
        }


        public DataTable SpliterDataTable(DataTable dt)
        {
            DataTable newdt = dt.Clone();

            DataColumn dc = null;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dc = new DataColumn();
                dc.ColumnName = dt.Columns[i].ColumnName + "1";
                dc.DataType = dt.Columns[i].DataType;
                newdt.Columns.Add(dc);
            }

            DataRow dr = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = newdt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)//循环给newdt赋值
                {
                    dr[dt.Columns[j].ColumnName] = dt.Rows[i][dt.Columns[j].ColumnName];
                }
                //i循环不到最后一条 且 循环下一条的类型 与当前条类型相同 可以填充第二列 
                if (i < dt.Rows.Count - 1 && dt.Rows[i]["itemtypename"].ToString().Trim() == dt.Rows[i + 1]["itemtypename"].ToString().Trim())
                {
                    i++;//循环到下一条
                    for (int j = 0; j < dt.Columns.Count; j++)//循环给newdt赋值
                    {
                        dr[dt.Columns[j].ColumnName + "1"] = dt.Rows[i][dt.Columns[j].ColumnName];
                    }
                }
                newdt.Rows.Add(dr);
            }

            return newdt;
        }

    }
}
