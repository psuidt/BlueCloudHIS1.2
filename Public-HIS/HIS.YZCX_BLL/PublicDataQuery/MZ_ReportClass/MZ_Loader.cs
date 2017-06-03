using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.YP_BLL;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.YZCX_BLL;
using HIS.DAL;


namespace HIS.YZCX_BLL
{
    public class MZ_Loader:BaseBLL
    {
        static public void SetManagerDiary(ManagerDiary diray,
            DateTime beginDate, DateTime endDate)
        {
            try
            {
                YZCX_Dal dal = new YZCX_Dal();
                dal._oleDb = oleDb;
                string strWhereCostTime = "a.cost_date between '" + beginDate.Date.ToString("yyyy-MM-dd") + " 00:00:00'" + oleDb.And()
                    + "'" + endDate.Date.ToString("yyyy-MM-dd") + " 23:59:59'";
                string strWherePresTime = "a.presdate between '" + beginDate.Date.ToString("yyyy-MM-dd") + " 00:00:00'" + oleDb.And()
                    + "'" + endDate.Date.ToString("yyyy-MM-dd") + " 23:59:59'";
                string strWhereType = "a.itemcode in ('00','01','02','03')";
                diray.Mz_Population = dal.GetMZPopulation(strWhereCostTime);
                diray.TotalFee_MZ = dal.GetMZTotalFee(strWhereCostTime);
                diray.TotalFee_MZ_YP = dal.GetMZTotalFee(strWhereCostTime + oleDb.And() + strWhereType);
                if (diray.Mz_Population != 0)
                {
                    diray.AverageFee_MZ = diray.TotalFee_MZ / diray.Mz_Population;
                }
                int presNum = dal.GetMZPresNum(strWherePresTime);
                if (presNum != 0)
                {
                    diray.AveragePresFee_MZ = diray.TotalFee_MZ / presNum;
                }
                diray.HSFee = dal.GetMZHSFee(strWhereCostTime);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        static public DataTable GetPatPresOrder(string visitno)
        {
            try
            {
                string strWhere = "visitno" + oleDb.EuqalTo() + "'" + visitno + "'";
                YZCX_Dal dal = new YZCX_Dal();
                dal._oleDb = oleDb;
                return dal.GetMZPresOrder(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        static public DataTable LoadItemFeeByDoc(DateTime beginDate, DateTime endDate, string itemCode)
        {
            try
            {
                YZCX_Dal dal = new YZCX_Dal();
                dal._oleDb = oleDb;
                string strWhere = "cost_date between '" + beginDate.Date.ToString("yyyy-MM-dd") + " 00:00:00'" + oleDb.And()
                    + "'" + endDate.Date.ToString("yyyy-MM-dd") + " 23:59:59'" + oleDb.And() + "itemcode" + oleDb.EuqalTo() + "'"
                    + itemCode + "'";
                return dal.GetMZItemFeeByDoc(strWhere);
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
                string strWhere = "cost_date between '" + beginDate.Date.ToString("yyyy-MM-dd") + " 00:00:00'" + oleDb.And()
                    + "'" + endDate.Date.ToString("yyyy-MM-dd") + " 23:59:59'" + oleDb.And() + "itemcode" + oleDb.EuqalTo() + "'"
                    + itemCode + "'";
                return dal.GetMZItemFeeByDept(strWhere);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
