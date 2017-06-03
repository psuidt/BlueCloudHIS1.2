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
    partial class PubOperation : BaseBLL
    {
        #region 属性
        private List<HIS.Model.zy_doc_orderrecord_son> _recordsSon;
        private List<HIS.Model.ZY_DOC_ORDERRECORD> _records;
        private int _transnurse;

        public List<HIS.Model.zy_doc_orderrecord_son> recordsSon
        {
            get
            {
                return _recordsSon;
            }
            set
            {
                _recordsSon = value;
            }
        }
        public List<HIS.Model.ZY_DOC_ORDERRECORD> records
        {
            get
            {
                return _records;
            }
            set
            {
                _records = value;
            }
        }
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
       
        #endregion

        #region 医嘱保存
        /// <summary>
        /// 保存医嘱时操作，（包括修改的）
        /// </summary>
        /// <param name="records"></param>
        /// <param name="patlist"></param>
        /// <param name="updatarecords"></param>
        /// <returns></returns>
        public  WrongDecline SaveRecords(int deptid, int ordertype, HIS.Model.ZY_PatList patlist,out string SaveDiscription)
        {
            List<HIS.Model.ZY_DOC_ORDERRECORD> orders;
            List<Model.ZY_DOC_ORDERRECORD> updateorders;
            SaveDiscription = "";
            WrongDecline wrong = SaveOrders.SaveOrder(recordsSon, deptid, ordertype, patlist, out  orders,out updateorders);
            string content = "";
            string updatecontent = "";
            if (wrong.err == "0")
            {
                oleDb.BeginTransaction();
                try
                {
                    for (int i = 0; i < orders.Count; i++)
                    {
                        if (orders[i].ORDER_CONTENT == null || orders[i].ORDER_CONTENT == "")
                        {
                            orders[i].DELETE_FLAG = 1; // * 20100607.0.07  新开一组医嘱，最后一行为空时，保存时报错
                            continue;
                        }
                        if (orders[i].ORDER_BDATE.ToString() == Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString())
                        {                          
                            throw new Exception(MessageShows.GetMessages("S02", orders[i].ORDER_CONTENT));
                        }
                        if ((orders[i].ITEM_TYPE < 4 && orders[i].ITEM_TYPE!=0 )&& orders[i].ORDER_USAGE == "")
                        {                         
                            throw new Exception(MessageShows.GetMessages("S03", orders[i].ORDER_CONTENT));
                        }
                        if (orders[i].ORDER_DOC == 0)
                        {                         
                            throw new Exception(MessageShows.GetMessages("S04", orders[i].ORDER_CONTENT));
                        }
                        if (orders[i].PRES_DEPTID == 0)
                        {                          
                            throw new Exception(MessageShows.GetMessages("S05",orders[i].ORDER_CONTENT));
                        }
                        if (orders[i].STATUS_FALG == -1)
                        {
                            orders[i].STATUS_FALG = 0;
                        }
                        orders[i].PATID = patlist.PatListID;
                        orders[i].BABYID = 0;
                        orders[i].PAT_DEPTID = Convert.ToInt32(XcConvert.IsNull(patlist.CurrDeptCode, "0"));
                        orders[i].ORECORD_A2 = 1;
                            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Add(orders[i]);
                            content = content + orders[i].ORDER_CONTENT + "\n";
                    }
                    for (int i = 0; i < updateorders.Count; i++)
                    {
                            updateorders[i].ORECORD_A2 = 1;
                            string strWhere = Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + updateorders[i].ORDER_ID;
                            string strSet = Tables.zy_doc_orderrecord.ORDER_USAGE + oleDb.EuqalTo() + "'" + updateorders[i].ORDER_USAGE + "'";
                            object obj = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.STATUS_FALG, strWhere);
                            if (obj.ToString() == "0" || obj.ToString() == "1")
                            {
                                BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(updateorders[i]);
                            }
                            if (obj.ToString() == "2")
                            {
                                BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                            }
                            updatecontent = updatecontent + updateorders[i].ORDER_CONTENT + "\n";
                                            
                    }
                    if (ordertype == 0)
                    {
                        if (content != "" && updatecontent != "")
                        {                        
                            SaveDiscription = MessageShows.GetMessages("S06", content, updatecontent);
                        }
                        else if (content != "" && updatecontent == "")
                        {                         
                            SaveDiscription = MessageShows.GetMessages("S07", content);
                        }
                        else if (updatecontent!="")
                        {                          
                            SaveDiscription = MessageShows.GetMessages("S08", updatecontent);
                        }
                    }
                    else
                    {
                        if (content != "" && updatecontent != "")
                        {                          
                            SaveDiscription = MessageShows.GetMessages("S09", content, updatecontent);
                        }
                        else if (content != "" && updatecontent == "")
                        {                           
                            SaveDiscription = MessageShows.GetMessages("S10",content);
                        }
                        else if(updatecontent!="")
                        {                            
                            SaveDiscription = MessageShows.GetMessages("S11", updatecontent);
                        }
                    }

                    oleDb.CommitTransaction();
                    return wrong;
                }
                catch (System.Exception e)
                {
                    oleDb.RollbackTransaction();
                    throw new Exception(e.Message);
                }
            }
            return wrong;
        }
        #endregion  

        #region  医嘱发送
        /// <summary>
        /// 医嘱发送
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public  string SendOrders(out int index)
        {
            try
            {
                string content = "";
                index = -1;
                if (recordsSon.Count == 0)
                {
                    return content;
                }
                oleDb.BeginTransaction();
                for (int i = 0; i < recordsSon.Count; i++)
                {
                    if (recordsSon[i].STATUS_FALG == -1)
                    {
                        index = i;
                        oleDb.CommitTransaction();
                        return "";
                    }
                    if (recordsSon[i].ORDER_CONTENT == null || recordsSon[i].STATUS_FALG > 0)
                    {
                        continue;
                    }
                    if (recordsSon[i].STATUS_FALG == 0)
                    {
                        recordsSon[i].STATUS_FALG = 1;
                    }
                    string strsql = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 1;
                      
                    string strwhere = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 0 + oleDb.And()
                        + Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + recordsSon[i].ORDER_ID + oleDb.And()
                        + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 0;
                    BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere, strsql);
                    content = content + recordsSon[i].ORDER_CONTENT + "\n";
                }
                oleDb.CommitTransaction();
                return content;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 修改医嘱
        /// <summary>
        /// 修改医嘱 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public  bool UpdateOrder()
        {
            try
            {
                oleDb.BeginTransaction();
                for (int i = 0; i < records.Count; i++)
                {
                    BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(records[i]);
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

        #region 取消删除医嘱时的操作和条件控制
        /// <summary>
        /// 取消删除医嘱时的操作和条件控制
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public bool DeleteOrder(HIS.Model.ZY_PatList zy_Patlist, int rowindex, int sign, int deptid, int employid, out bool IsOut)
        {

            List<HIS.Model.ZY_DOC_ORDERRECORD> orders = DeleteDeal.DeleteOrder(recordsSon, zy_Patlist, rowindex, sign, deptid, employid, out IsOut);
            if (orders == null)
            {
                return true;
            }
            try
            {
                oleDb.BeginTransaction();
                string strsql = "";
                string strwhere = "";
                for (int i = 0; i < orders.Count; i++)
                {
                    //if (orders[i].ORDER_DOC != employid) //* 20100603.1.07 医生删除时，限制只能删除本医生开的医嘱
                    //{                     
                    //    string docname = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(orders[i].ORDER_DOC.ToString());
                    //    throw new Exception("" + orders[i].ORDER_CONTENT + "是由" + docname + "开的医嘱，只能由" + docname + "删除！");                        
                    //}
                    strsql = Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 1;
                    strwhere = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.LessThan() + 2 + oleDb.And()
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

        #region 根据病人ＩＤ获得病人医嘱信息
        /// <summary>
        /// 根据病人ＩＤ获得病人医嘱信息
        /// </summary>
        /// <param name="orderkind"></param>
        /// <param name="zy_Patlist"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public  DataTable GetOrder(OrderType ordertype,Status status, HIS.Model.ZY_PatList zy_Patlist, int deptid)
        {
            DateTime timeformat = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());          
            DataTable mytable = GetOrderDataTable(zy_Patlist, ordertype, status , deptid);
            if (mytable == null || mytable.Rows.Count == 0)
            {
                return null;
            }
            if (status  == Status.护士转抄)
            {
                return mytable;
            }
            return PubMethd.OrderFomat(mytable, 0);          
        }
        #endregion
       
        #region 根据医嘱类别和病人ID获得病人的医嘱信息
        /// <summary>
        ///  根据医嘱类别和病人ID获得病人的医嘱信息
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="babyid">婴儿Id</param>
        /// <param name="order_type">医嘱类型0＝长期 1＝临时 6=手术  -1有效长嘱</param>
        /// <returns></returns>
        private DataTable GetOrderDataTable(HIS.Model.ZY_PatList patlist,OrderType ordertype,Status status, int deptid)
        {
            try
            {
                string strWhere = "";
                int patlistid = patlist.PatListID;
                if (ordertype ==OrderType.临时医嘱) //临时医嘱
                {
                    strWhere = Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid + oleDb.And()
                        + Tables.zy_doc_orderrecord.BABYID + oleDb.EuqalTo() + 0 + oleDb.And()
                        + "(" + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + (int)ordertype
                        + oleDb.Or() + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + 5 + oleDb.Or()
                        + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + 7 + ")" + oleDb.And()
                        + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.NotEqualTo() + 1;
                }
                if (ordertype == OrderType.长期医嘱 && status ==Status.所有) //长期医嘱
                {
                    strWhere = Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid + oleDb.And()
                        + Tables.zy_doc_orderrecord.BABYID + oleDb.EuqalTo() + 0 + oleDb.And()
                        + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + (int)ordertype
                        + oleDb.And() + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.NotEqualTo() + 1;
                }
                if (ordertype == OrderType.长期医嘱 && status==Status.护士转抄)//已转抄医嘱
                {
                    strWhere = Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid + oleDb.And()
                    + Tables.zy_doc_orderrecord.BABYID + oleDb.EuqalTo() + 0 + oleDb.And()
                    + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + 0 + oleDb.And()
                    + Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 2 + oleDb.And()
                    + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 0 + oleDb.And()
                    + Tables.zy_doc_orderrecord.ITEM_TYPE + oleDb.NotEqualTo() + 10;                   
                }
                //if (patlist.PatType != "3" && patlist.PatType != "4" && patlist.PatType != "5")
                //{
                //    strWhere += oleDb.And() + Tables.zy_doc_orderrecord.PRES_DEPTID + oleDb.EuqalTo() + deptid;
               // }
                List<HIS.Model.ZY_DOC_ORDERRECORD> records = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                List<HIS.Model.zy_doc_orderrecord_son> recordSon = new List<HIS.Model.zy_doc_orderrecord_son>();
                for (int i = 0; i < records.Count; i++)
                {
                    HIS.Model.zy_doc_orderrecord_son son = new HIS.Model.zy_doc_orderrecord_son();
                    son = (HIS.Model.zy_doc_orderrecord_son)HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjectToObj(records[i], son);
                    //son.LoadData();
                    GetName.GiveName(son);
                    recordSon.Add(son);
                }
                return HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(recordSon);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion     

        #region 使医嘱按格式显示
        /// <summary>
        /// 使医嘱按格式显示
        /// </summary>
        /// <returns></returns>
        public DataTable TableFormat()
        {
            if (recordsSon == null)
                return null;
            DataTable table = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(recordsSon.FindAll(x => x.DELETE_FLAG == 0));
            if (table == null || table.Rows.Count == 0)
            {
                return null;
            }
            return  PubMethd.OrderFomat(table, 0);
        }
        #endregion
     
    }
}
