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

namespace HIS.ZYDoc_BLL.NurseInterface
{
   public  class NurseOperation:BaseBLL,INurseBase,INurseQuery,INurseTrans
    {
        private int _transnurse;
        private DateTime _transdate;
        private DataTable _cashdatatable;
        private int _order_id;

        #region 接口成员
        /// <summary>
        /// 转抄护士
        /// </summary>
        public int transnurse
        {
            get
            {
                return _transnurse;
            }
            set
            {
                _transnurse = value;
            }
        }

        /// <summary>
        /// 转抄日期
        /// </summary>
        public DateTime transdate
        {
            get
            {
                return _transdate;
            }
            set
            {
                _transdate = value;
            }
        }

        /// <summary>
        /// 缓存中间表
        /// </summary>
        public DataTable CashDataTable
        {
            get
            {
                return _cashdatatable;
            }
            set
            {
                _cashdatatable = value;
            }
        }

        /// <summary>
       ///  医嘱表ID
       /// </summary>
        public int order_id
        {
            get
            {
                return _order_id; ;
            }
            set
            {
                _order_id = value;
            }
        }
        #endregion

        DateTime timeformat = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());

        #region INurseBase
        #region 通过医嘱表ＩＤ获得首日执行次数
        /// <summary>
        /// 通过医嘱表ＩＤ获得首日执行次数
        /// </summary>
        /// <returns></returns>
        public int GetFirstTimes()
        {
            DataRow[] dr = CashDataTable.Select("order_id = " + order_id + "");
            if (dr != null && dr.Length > 0) //如果能在缓存表中找到，则直接从表中取得数据
            {
                return Convert.ToInt32(dr[0]["firset_times"]);
            }
            else
            {
                object obj = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.FIRSET_TIMES, Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + order_id);
                return Convert.ToInt32(obj.ToString());
            }
        }
        #endregion

        #region 通过医嘱表ＩＤ获得停嘱末次
        /// <summary>
        /// 通过医嘱表ＩＤ获得停嘱末次
        /// </summary>
        /// <returns></returns>
        public int GetTeminalTimes()
        {
            DataRow[] dr = CashDataTable.Select("order_id = " + order_id + "");
            if (dr != null && dr.Length > 0) //如果能在缓存表中找到，则直接从表中取得数据
            {
                return Convert.ToInt32(dr[0]["teminal_times"]);
            }
            else
            {
                object obj = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.TEMINAL_TIMES, Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + order_id);
                return Convert.ToInt32(obj.ToString());
            }
        }
        #endregion

        #region 通过医嘱表ＩＤ获得医嘱类别
        /// <summary>
        /// 通过医嘱表ＩＤ获得医嘱类别
        /// </summary>
        /// <returns></returns>
        public OrderType GetOrderType()
        {
            DataRow[] dr = CashDataTable.Select("order_id = " + order_id + "");
            if (dr != null && dr.Length > 0) //如果能在缓存表中找到，则直接从表中取得数据
            {
                int index = Convert.ToInt32(dr[0]["order_type"].ToString());
                if (dr[0]["execdept"].ToString() == "-1")
                {
                    index = 4;
                }
                if (dr[0]["item_type"].ToString() == "10" && index == 0 && (dr[0]["order_content"].ToString() == "术后医嘱" || dr[0]["order_content"].ToString() == "产后医嘱"))
                {
                    index = 8;
                }
                return (OrderType)Convert.ToInt32(index);
            }
            else
            {
                DataTable dt = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetList(Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + order_id);
                int index = Convert.ToInt32(dt.Rows[0]["order_type"].ToString());
                if (dt.Rows[0]["execdept"].ToString() == "-1")
                {
                    index = 4;
                }
                if (dt.Rows[0]["item_type"].ToString() == "10" && index == 0 && (dt.Rows[0]["order_content"].ToString() == "术后医嘱" || dt.Rows[0]["order_content"].ToString() == "产后医嘱"))
                {
                    index = 8;
                }
                return (OrderType)Convert.ToInt32(index);
            }
         
        }
        #endregion

        #region 通过医嘱表ＩＤ获得医嘱类型
        /// <summary>
        /// 通过医嘱表ＩＤ获得医嘱类型
        /// </summary>
        /// <returns></returns>
        public ItemType GetItemType()
        {
            DataRow[] dr = CashDataTable.Select("order_id = " + order_id + "");
            if (dr != null && dr.Length > 0) //如果能在缓存表中找到，则直接从表中取得数据
            {
                return (ItemType)Convert.ToInt32(dr[0]["item_type"]);
            }
            else
            {
                object obj = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.ITEM_TYPE, Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + order_id);
                return (ItemType)Convert.ToInt32(obj.ToString());
            }
        }
        #endregion

        #region 通过医嘱表ＩＤ获得医嘱状态
        /// <summary>
        /// 通过医嘱表ＩＤ获得医嘱状态
        /// </summary>
        /// <returns></returns>
        public Status GetStatus()
        {
            DataRow[] dr = CashDataTable.Select("order_id = " + order_id + "");
            if (dr != null && dr.Length > 0) //如果能在缓存表中找到，则直接从表中取得数据
            {
                return (Status)Convert.ToInt32(dr[0]["status_falg"]);
            }
            else
            {
                object obj = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.STATUS_FALG, Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + order_id);
                return (Status)Convert.ToInt32(obj.ToString());
            }
        }
        #endregion

        #region 通过医嘱表ＩＤ获得药品或项目ID
        /// <summary>
        /// 通过医嘱表ＩＤ获得药品或项目ID
        /// </summary>
        /// <returns></returns>
        public int GetItemId()
        {
            DataRow[] dr = CashDataTable.Select("order_id = " + order_id + "");
            if (dr != null && dr.Length > 0) //如果能在缓存表中找到，则直接从表中取得数据
            {
                if (dr[0]["orditem_id"].ToString().Trim() != "0")
                {
                    return Convert.ToInt32(dr[0]["orditem_id"].ToString().Trim());
                }
                else
                {
                    return Convert.ToInt32(dr[0]["makedicid"].ToString().Trim());
                }
            }
            else
            {
                HIS.Model.ZY_DOC_ORDERRECORD record = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetModel(order_id);
                if (record.ORDITEM_ID != 0)
                {
                    return record.ORDITEM_ID;
                }
                return record.MAKEDICID;
            }
        }
        #endregion

        #region 判断是否需要皮试
        /// <summary>
        /// 判断是否需要皮试
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public bool IsNeedPs()
        {         
            HIS.Model.ZY_DOC_ORDERRECORD record = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetModel(order_id);
            if(record.PS_ORDERID.ToString()!="0.000000" && record.ITEM_CODE.ToString()=="")
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 插入皮试结果
        /// <summary>
        /// 插入皮试结果
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="ps_flag"></param>
        /// <returns></returns>
        public bool SetPsResult( int ps_flag)
        {
            HIS.Model.ZY_DOC_ORDERRECORD record = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetModel(order_id);
            record.PS_FLAG = ps_flag;
            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(record);
            return true;
        }
        #endregion
        #endregion

        #region INurseQuery
        #region 根据patlistid获得该病人特定类别的医嘱
        /// <summary>
        /// 根据patlistid获得该病人特定类别的医嘱
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="ordertype"></param>
        /// <param name="isAll">true =全部 false=有效</param>
        /// <returns></returns>
        public DataTable GetOrders(int patlistid, OrderType ordertype, bool isAll)//得到医嘱信息
        {
            string strWhere = "";
            try
            {
                if (ordertype == OrderType.临时医嘱) //临时医嘱
                {
                    strWhere = Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid + oleDb.And()
                       + Tables.zy_doc_orderrecord.BABYID + oleDb.EuqalTo() + 0 + oleDb.And()
                       + "(" + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + 1
                       + oleDb.Or() + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + 5 + oleDb.Or()
                       + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + 7 + ")" + oleDb.And()
                       + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.NotEqualTo() + 1;
                }
                else
                {
                    strWhere = Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid + oleDb.And()
                        + Tables.zy_doc_orderrecord.BABYID + oleDb.EuqalTo() + 0 + oleDb.And()
                        + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + (int)ordertype
                    + oleDb.And() + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.NotEqualTo() + 1;
                }
                if (!isAll)
                {
                    strWhere += oleDb.And() + Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.In("2", "4");// +oleDb.OrderBy(Tables.zy_doc_orderrecord.ORDER_BDATE, Tables.zy_doc_orderrecord.GROUP_ID, Tables.zy_doc_orderrecord.SERIAL_ID);
                }
                else
                {
                    strWhere += oleDb.And() + Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.GreaterThan() + 1;// +oleDb.OrderBy(Tables.zy_doc_orderrecord.ORDER_BDATE, Tables.zy_doc_orderrecord.GROUP_ID, Tables.zy_doc_orderrecord.SERIAL_ID); ;
                }

                List<HIS.Model.ZY_DOC_ORDERRECORD> records = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                List<HIS.Model.zy_doc_orderrecord_son> recordSon = new List<HIS.Model.zy_doc_orderrecord_son>();
                for (int i = 0; i < records.Count; i++)
                {
                    HIS.Model.zy_doc_orderrecord_son son = new HIS.Model.zy_doc_orderrecord_son();
                    son = (HIS.Model.zy_doc_orderrecord_son)HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjectToObj(records[i], son);
                    son.LoadData();
                    recordSon.Add(son);
                }
                CashDataTable = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(recordSon);
                DataTable dt = CashDataTable.Copy();
                PubMethd.OrderFomat(dt, 1);
                return dt;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 得到一个科室所有需要转抄的医嘱
        /// <summary>
        /// 得到一个科室所有需要转抄的医嘱
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public DataTable GetDeptTransOrders(int deptid)
        {
            try
            {
                string strWhere = @"select a.patid,a.order_id,a.order_content,case a.order_type when 0 then '长嘱' when  1 then'临嘱' when  5 then'临嘱' when  7 then'临嘱' end as order_type,a.order_bdate,a.order_doc,a.group_id,a.serial_id,a.order_usage,a.frequency,a.firset_times,a.teminal_times,a.order_struc,a.amount,a.unit,c.name ,d.cureno,d.patid,e.bed_no,f.patname,case a.status_falg when 1 then '' when  3 then'(停)' end as status_flag,0 GroupFlag"
                                + " from zy_doc_orderrecord a"
                                + " left join base_employee_property c on a.order_doc=c.employee_id"
                                + " left join zy_patlist d on a.patid=d.patlistid"
                                + " left join zy_nurse_bed e on a.patid=e.patlist_id"
                                + " left join patientinfo f on d.patid=f.patid"
                                + " where (status_falg=1 or status_falg=3) and (order_type=0 or order_type=1 or order_type=5 or order_type=7) and pat_deptid=" + deptid + " and delete_flag=0 order by cast( replace(bed_no,'加','100') as integer),order_type,order_bdate,group_id,serial_id";
                DataTable orderdt = oleDb.GetDataTable(strWhere);
                CashDataTable = oleDb.GetDataTable(strWhere);
                if (orderdt == null || orderdt.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    PubMethd.TransOrderFormat(orderdt);
                    return orderdt;
                }
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion        
        #endregion

        #region INurseTrans
        #region 护士站转抄医嘱
        /// <summary>
        /// 护士站转抄医嘱(对皮试医嘱已作了过滤)
        /// </summary>
        /// <returns></returns>
        public bool TransOrders(List<HIS.Model.ZY_DOC_ORDERRECORD> records)//转抄医嘱   
        {
            try
            {
                this.getTransResult(records);
                oleDb.BeginTransaction();
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].PS_ORDERID != 0 && (records[i].PS_FLAG == 0 || records[i].PS_FLAG == 2) && 
                        records[i].ITEM_CODE != "")
                    {
                        string strwhere = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 1 + oleDb.And()
                           + Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + records[i].ORDER_ID +
                           oleDb.And() + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 0;

                        string strwhere1 = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 3 + oleDb.And()
                           + Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + records[i].ORDER_ID + oleDb.And()
                           + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 0;
                        if (BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Exists(strwhere))
                        {
                            records[i].TRANS_NURSE = transnurse;
                            records[i].TRANS_DATE = transdate;
                            records[i].STATUS_FALG = 2;
                            string strsql = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + records[i].STATUS_FALG;
                            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere, strsql);

                        }
                        if (BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Exists(strwhere1))
                        {
                            records[i].EORDER_TSNURSE = transnurse;
                            records[i].EORDER_TSDATE = transdate;
                            records[i].STATUS_FALG = 4;
                            string strsql = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + records[i].STATUS_FALG;
                            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere1, strsql);
                        }
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

        #region 护士站转抄医嘱
        /// <summary>
        /// 护士站转抄医嘱(按病人转抄)
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="ordertype"></param>
        /// <returns></returns>
        public bool TransOrders(int patlistid, OrderType ordertype)//转抄医嘱
        {
            try
            {
                oleDb.BeginTransaction();
                string strsql = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 2;
                string strwhere = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 1 + oleDb.And()
                    + Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid + oleDb.And() 
                    + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + (int)ordertype
                    + oleDb.And() + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 0;

                BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere, strsql);
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

        #region 护士站取消转抄医嘱
        /// <summary>
        /// 护士站取消转抄医嘱
        /// </summary>
        /// <returns></returns>
        public bool CancelTransOrders(List<HIS.Model.ZY_DOC_ORDERRECORD> records)
        {
            try
            {
                oleDb.BeginTransaction();
                for (int i = 0; i < records.Count; i++)
                {
                    records[i].TRANS_NURSE = 0;
                    records[i].TRANS_DATE = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());
                    records[i].STATUS_FALG = 1;
                    string strsql = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + records[i].STATUS_FALG;
                    string strwhere = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 2 + oleDb.And()
                        + Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + records[i].ORDER_ID;
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

        #region 对皮试医嘱过滤
        /// <summary>
        /// 对皮试医嘱过滤
        /// </summary>
        private void getTransResult(List<HIS.Model.ZY_DOC_ORDERRECORD> records)
        {
            for (int i = 0; i < records.Count; i++)
            {
                string strwhere = "select b.order_id from zy_doc_orderrecord a"
                                  + " left join zy_doc_orderrecord b on a.group_id=b.group_id and a.patid=b.patid and a.order_type=b.order_type"
                                  + " left join zy_doc_orderrecord c on b.ps_orderid=c.ps_orderid and b.patid=c.patid"
                                  + " where b.ps_orderid!=0 and b.ps_flag in (0,2) and b.item_code <> '' "
                                  + " and a.order_id=" + records[i].ORDER_ID;

                DataTable dt = oleDb.GetDataTable(strwhere);
                if (dt != null && dt.Rows.Count > 0)
                {
                    records.Remove(records[i]);
                    i--;
                }
            }
        }
        #endregion
        #endregion

        #region 护士站发送医嘱，对医嘱表的操作部分
        /// <summary>
        /// 护士站发送医嘱，对医嘱表的操作部分
        /// </summary>
        /// <returns></returns>
        public bool SendFee(List<HIS.Model.ZY_DOC_ORDERRECORD> records)
        {
            if (records == null || records.Count == 0)
            {
                return true;
            }
            string strWhere = "";
            string strSet = "";
            try
            {
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].ORDER_TYPE == 1 || records[i].ORDER_TYPE == 5 || records[i].ORDER_TYPE == 7 
                        || records[i].ITEM_TYPE == 10)
                    {
                        strSet = records[i].STATUS_FALG + oleDb.EuqalTo() + 5;
                        strWhere = Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + records[i].ORDER_ID +
                            oleDb.And() + records[i].STATUS_FALG + oleDb.EuqalTo() + 2;
                    }
                    if (records[i].ORDER_TYPE == 0 && records[i].ITEM_TYPE != 10)
                    {
                        if (records[i].STATUS_FALG == 1 || records[i].STATUS_FALG == 2)
                        {
                            strSet = records[i].STATUS_FALG + oleDb.EuqalTo() + 2;
                            strWhere = Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + records[i].ORDER_ID + 
                                oleDb.And() + "(" + records[i].STATUS_FALG + oleDb.EuqalTo() + 1 + oleDb.Or() + 
                                records[i].STATUS_FALG + oleDb.EuqalTo() + 2 + ")";
                        }
                        if (records[i].STATUS_FALG == 4)
                        {
                            strSet = Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + records[i].ORDER_ID +
                                oleDb.And() + records[i].STATUS_FALG + oleDb.EuqalTo() + 5;
                        }
                    }
                    BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                }
                return true;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 护士站发送医嘱，对医嘱表的操作部分
        /// <summary>
        /// 护士站(按病人)发送医嘱，对医嘱表的操作部分
        /// </summary>
        /// <returns></returns>
        public bool SendFee(int patlistid, OrderType ordertype)
        {
            string strWhere = "";
            string strSet = "";
            try
            {
                if (ordertype == OrderType.临时医嘱 || ordertype == OrderType.交病人临嘱 || ordertype == OrderType.出院带药临嘱)
                {
                    strSet = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 5;
                    strWhere = Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid + oleDb.And() +
                        Tables.zy_doc_orderrecord.ORDER_TYPE +
                        oleDb.EuqalTo() + (int)ordertype + oleDb.And() + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 0
                        + oleDb.And() + Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 2;
                }
                if (ordertype ==OrderType.长期医嘱)
                {

                }
                return true;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
