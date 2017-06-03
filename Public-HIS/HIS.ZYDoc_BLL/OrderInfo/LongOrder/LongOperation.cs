using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYDoc_BLL.OrderInfo
{
    partial class LongOperation:BaseBLL
    {
        #region 属性
        private List<HIS.Model.ZY_DOC_ORDERRECORD> _orders;
        public List<HIS.Model.ZY_DOC_ORDERRECORD> orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
            }
        }
        #endregion

        DateTime timeformat = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());
       
        #region 停嘱执行时状态改变及条件控制
        /// <summary>
        /// 停嘱执行
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public bool StopOrders()
        {
            try
            {
                oleDb.BeginTransaction();
                string strsql = "";
                string strwhere = "";
                for (int i = 0; i < orders.Count; i++)
                {
                    strsql = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 3 + ","
                        + Tables.zy_doc_orderrecord.TEMINAL_TIMES + oleDb.EuqalTo() + orders[i].TEMINAL_TIMES + ","
                        + Tables.zy_doc_orderrecord.EORDER_DATE + oleDb.EuqalTo() + "'" + orders[i].EORDER_DATE + "'" +
                       "," + Tables.zy_doc_orderrecord.EORDER_DOC + oleDb.EuqalTo() + orders[i].EORDER_DOC;
                    strwhere = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 2 + oleDb.And()
                        + Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + orders[i].ORDER_ID;
                    BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere, strsql);
                }
                oleDb.CommitTransaction();
                return true;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 停嘱执行时状态改变及条件控制
        /// <summary>
        /// 停嘱执行
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public  bool StopOrders( int groupid, int teminaltimes, int eorderdoc, DateTime? dtime)
        {
            try
            {
                oleDb.BeginTransaction();
                string strsql = "";
                string strwhere = "";
                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].GROUP_ID == groupid)
                    {
                        strsql = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 3 + ","
                            + Tables.zy_doc_orderrecord.TEMINAL_TIMES + oleDb.EuqalTo() + teminaltimes + ","
                            + Tables.zy_doc_orderrecord.EORDER_DATE + oleDb.EuqalTo() + "'" + dtime + "'" +
                           "," + Tables.zy_doc_orderrecord.EORDER_DOC + oleDb.EuqalTo() + Convert.ToInt32(eorderdoc);
                        strwhere = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 2 + oleDb.And()
                            + Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + orders[i].ORDER_ID;
                        BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere, strsql);
                    }
                }
                oleDb.CommitTransaction();
                return true;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 取消停医嘱状态改变及条件控制
        /// <summary>
        /// 取消停医嘱
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public bool CancelStopOrders(int groupid, int patlistid)
        {
            try
            {
                if (StopForSH(patlistid, 0, groupid))
                {
                    return false;
                }
                oleDb.BeginTransaction();
                string strsql = "";
                string strwhere = "";
                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].GROUP_ID == groupid)
                    {
                        strsql = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 2 + ","
                            + Tables.zy_doc_orderrecord.TEMINAL_TIMES + oleDb.EuqalTo() + 0 + ","
                            + Tables.zy_doc_orderrecord.EORDER_DATE + oleDb.EuqalTo() + "'" + timeformat + "'" +
                             "," + Tables.zy_doc_orderrecord.EORDER_DOC + oleDb.EuqalTo() + 0;
                        strwhere = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 3 + oleDb.And()
                            + Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + orders[i].ORDER_ID;
                        BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere, strsql);
                    }
                }
                oleDb.CommitTransaction();
                return true;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        #endregion     
        #region 判断是否为术后、产后、转科自动停止的医嘱
        /// <summary>
        /// 是否为术后、产后、转科自动停止的医嘱
        ///</summary>
        private  bool StopForSH(int BinID, int BabyID, int GroupNum)
        {
            string sSql = "select * from {zy_doc_orderrecord}  where patid= " + BinID + " and babyid=" + BabyID + " and item_type=10 and delete_flag=0 and order_type=0 and ORDER_content not like '%出院%' " +
                        " and order_bdate>( " +
                        " select order_bdate from {zy_doc_orderrecord} " +
                        " where patid=" + BinID + " and babyid=" + BabyID + " and order_type=0 and group_id=" + GroupNum + " and status_falg=3  and delete_flag=0 fetch first 1 rows only)";
            DataTable dt = oleDb.GetDataTable(sSql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        public AfterOperation Afteroperation()
        {
            return new AfterOperation();
        }
    }
}
