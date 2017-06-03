using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.ZY_BLL;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.DAL;

namespace HIS.YZCX_BLL
{
    public class ZY_Loader : BaseBLL
    {
        static public void SetManagerDiary(ManagerDiary diray, DateTime beginDate, DateTime endDate)
        {
            try
            {
                YZCX_Dal dal = new YZCX_Dal();
                dal._oleDb = oleDb;
                string strWhereAdimDATE = "curedate" + oleDb.Between() + "'" + beginDate.Date.ToString("yyyy-MM-dd") + "'" + oleDb.And()
                    + "'" + endDate.Date.ToString("yyyy-MM-dd") + "'";
                string strWhereLeaveDATE = "outdate" + oleDb.Between() + "'" + beginDate.Date.ToString("yyyy-MM-dd") + "'" + oleDb.And()
                    + "'" + endDate.Date.ToString("yyyy-MM-dd") + "'";
                string strWhereCostTime = "a.costdate between " + "'" + beginDate.Date.ToString("yyyy-MM-dd") + " 00:00:00'" + oleDb.And()
                    + "'" + endDate.Date.ToString("yyyy-MM-dd") + " 23:59:59'";
                string strWhereType = "a.bigitemtype in ('00','01','02','03')";
                diray.AdminNum_ZY = dal.GetZYPopulation(strWhereAdimDATE);
                diray.LeaveNum_ZY = dal.GetZYPopulation(strWhereLeaveDATE);
                diray.AtNum_ZY = dal.GetZYCurrentNum();
                diray.TotalFee_ZY = dal.GetZYTotalFee(strWhereCostTime);
                diray.TotalFee_ZY_YP = dal.GetZYTotalFee(strWhereCostTime + oleDb.And() + strWhereType);
                diray.TotalFee = diray.TotalFee_MZ + diray.TotalFee_ZY;
                diray.HSFee.PrimaryKey = new DataColumn[] { diray.HSFee.Columns["CODE"] };
                diray.TatalDays_ZY = dal.GetZYTotalLeaveDays(beginDate, endDate);
                DataTable zy_HSFee = dal.GetZYHSFee(strWhereCostTime);
                for (int index = 0; index < zy_HSFee.Rows.Count; index++)
                {
                    if (zy_HSFee.Rows[index]["CODE"] != DBNull.Value)
                    {
                        string code = zy_HSFee.Rows[index]["CODE"].ToString();
                        DataRow findRow = diray.HSFee.Rows.Find(code);
                        if (findRow != null)
                        {
                            findRow["TOTALFEE"] = Convert.ToDecimal(findRow["TOTALFEE"])
                                + Convert.ToDecimal(zy_HSFee.Rows[index]["TOTAL_FEE"]);
                        }
                        else
                        {
                            DataRow newRow = diray.HSFee.NewRow();
                            newRow["CODE"] = zy_HSFee.Rows[index]["CODE"];
                            newRow["TOTALFEE"] = zy_HSFee.Rows[index]["TOTAL_FEE"];
                            newRow["ITEM_NAME"] = zy_HSFee.Rows[index]["ITEM_NAME"];
                            diray.HSFee.Rows.Add(newRow);
                        }
                    }
                    else
                    {
                        string code = "0";
                        DataRow findRow = diray.HSFee.Rows.Find(code);
                        if (findRow != null)
                        {
                            findRow["TOTALFEE"] = Convert.ToDecimal(findRow["TOTALFEE"])
                                + Convert.ToDecimal(zy_HSFee.Rows[index]["TOTAL_FEE"]);
                        }
                        else
                        {
                            DataRow newRow = diray.HSFee.NewRow();
                            newRow["CODE"] = "0";
                            newRow["TOTALFEE"] = zy_HSFee.Rows[index]["TOTAL_FEE"];
                            newRow["ITEM_NAME"] = "未设置核算项目";
                            diray.HSFee.Rows.Add(newRow);
                        }
                    }
                    
                }
                
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        static public DataTable LoadZYDeptFee(DateTime beginDate, DateTime endDate)
        {
            string strWhereCostTime = "a.costdate between " + "'" + beginDate.Date.ToString("yyyy-MM-dd") + " 00:00:00'" + oleDb.And()
                    + "'" + endDate.Date.ToString("yyyy-MM-dd") + " 23:59:59'";
            YZCX_Dal dal = new YZCX_Dal();
            dal._oleDb = oleDb;
            return dal.GetZYDeptFee(strWhereCostTime);
        }

        static public DataTable LoadZYDocFee(DateTime beginDate, DateTime endDate, string deptCode)
        {
            string strWhere = "a.costdate between " + "'" + beginDate.Date.ToString("yyyy-MM-dd") + " 00:00:00'" +
                oleDb.And() + "'" + endDate.Date.ToString("yyyy-MM-dd") + " 23:59:59'";
            if (deptCode != "")
            {
                strWhere += oleDb.And() + "a.presdeptcode" + oleDb.EuqalTo() + "'" + deptCode + "'";
            }
            YZCX_Dal dal = new YZCX_Dal();
            dal._oleDb = oleDb;
            return dal.GetZYDocFee(strWhere);
        }

        static public DataTable LoadZYPatFee(DateTime beginDate, DateTime endDate, string docCode, string deptCode)
        {
            string strWhere = "a.costdate between " + "'" + beginDate.Date.ToString("yyyy-MM-dd") + " 00:00:00'" +
                oleDb.And() + "'" + endDate.Date.ToString("yyyy-MM-dd") + " 23:59:59'";
            if (docCode != "")
            {
                strWhere += oleDb.And() + "a.presdoccode" + oleDb.EuqalTo() + "'" + docCode + "'";
            }
            if (deptCode != "")
            {
                strWhere += oleDb.And() + "a.presdeptcode" + oleDb.EuqalTo() + "'" + deptCode + "'";
            }
            YZCX_Dal dal = new YZCX_Dal();
            dal._oleDb = oleDb;
            return dal.GetZYPatFee(strWhere);
        }

        static public List<ZY_PatList> LoadZYPat(int deptId, bool isInHospital)
        {
            try
            {
                return YP_Interface.GetPatInfo(isInHospital, deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        static public DataTable LoadZYPatFee(ZY_PatList zyPat)
        {
            try
            {
                string strWhere = "a.cureno" + oleDb.EuqalTo() + "'"+zyPat.CureNo+"'";
                YZCX_Dal dal = new YZCX_Dal();
                dal._oleDb = oleDb;
                return dal.GetZYOrderFee(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        static public DataTable LoadZYPrePayFee(ZY_PatList zyPat)
        {
            string strWhere = BLL.Tables.zy_chargelist.CURENO + oleDb.EuqalTo() + "'" + zyPat.CureNo + "'";
            return BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetList(strWhere);
        }

        static public DataTable LoadItemFeeByDoc(DateTime beginDate, DateTime endDate, string itemCode)
        {
            try
            {
                YZCX_Dal dal = new YZCX_Dal();
                dal._oleDb = oleDb;
                string strWhere = "costdate between '" + beginDate.Date.ToString("yyyy-MM-dd") + " 00:00:00'" + oleDb.And()
                    + "'" + endDate.Date.ToString("yyyy-MM-dd") + " 23:59:59'" + oleDb.And() + "itemcode" + oleDb.EuqalTo() + "'"
                    + itemCode + "'";
                return dal.GetZYItemFeeByDoc(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        static public DataTable LoadItemFeeByDept(DateTime beginDate, DateTime endDate, string itemCode)
        {
            try
            {
                YZCX_Dal dal = new YZCX_Dal();
                dal._oleDb = oleDb;
                string strWhere = "costdate between '" + beginDate.Date.ToString("yyyy-MM-dd") + " 00:00:00'" + oleDb.And()
                    + "'" + endDate.Date.ToString("yyyy-MM-dd") + " 23:59:59'" + oleDb.And() + "itemcode" + oleDb.EuqalTo() + "'"
                    + itemCode + "'";
                return dal.GetZYItemFeeByDept(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
