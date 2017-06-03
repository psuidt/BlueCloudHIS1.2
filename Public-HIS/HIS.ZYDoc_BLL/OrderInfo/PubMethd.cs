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


namespace HIS.ZYDoc_BLL
{
    partial  class PubMethd:BaseBLL
    {
       static  DateTime timeformat = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());
        #region 表格式化
        /// <summary>
        /// 表格式化
        /// </summary>
        /// <param name="myTbBk"></param>
        /// <param name="sign">0医生站　1护士站</param>
       public static DataTable  OrderFomat(DataTable mytable, int sign)
       {
            DataView tempDataView = new DataView(mytable, "", "order_bdate,group_id,serial_id", DataViewRowState.CurrentRows);
            DataTable  mytb = insertRow(tempDataView, mytable);
            tempDataView.Dispose();
            DataTable myTbBk = mytb.Copy();
            DataColumn column = new DataColumn();
            if (sign == 1)
            {
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "PS";
                myTbBk.Columns.Add(column);
            }
            myTbBk.Rows[0]["begintime"] = myTbBk.Rows[0]["order_bdate"].ToString();
            myTbBk.Rows[0]["Usage"] = myTbBk.Rows[0]["order_usage"].ToString();
            myTbBk.Rows[0]["Frency"] = myTbBk.Rows[0]["frequency"].ToString();
            myTbBk.Rows[0]["First"] = myTbBk.Rows[0]["firset_times"].ToString();
            myTbBk.Rows[0]["Last"] = myTbBk.Rows[0]["teminal_times"].ToString();
            myTbBk.Rows[0]["presnum"] = myTbBk.Rows[0]["pres_amount"].ToString();
            if (myTbBk.Rows[0]["trans_date"].ToString() == timeformat.ToString())
            {
                myTbBk.Rows[0]["trans_date"] = DBNull.Value;
            }
            if (myTbBk.Rows[0]["eorder_date"].ToString() == timeformat.ToString())
            {
                myTbBk.Rows[0]["eorder_date"] = DBNull.Value;
            }
            if (Convert.ToInt32(myTbBk.Rows[0]["status_falg"].ToString().Trim()) <= 2)
            {
                myTbBk.Rows[0]["teminal_times"] = DBNull.Value;
                myTbBk.Rows[0]["Last"] = DBNull.Value;
            }
            if (myTbBk.Rows[0]["ps_orderid"].ToString() != "0.000000" && myTbBk.Rows[0]["item_code"].ToString() == "")
            {
                if (myTbBk.Rows[0]["ps_flag"].ToString() == "1")
                {
                    if (sign == 0)
                    {
                        string content = myTbBk.Rows[0]["order_content"].ToString();
                        if (content.Contains("【-】"))
                        {
                            myTbBk.Rows[0]["order_content"] = content.Substring(0, content.IndexOf("【-")) + "【-】";
                        }
                        else
                        {
                            myTbBk.Rows[0]["order_content"] = content + "【-】";
                        }
                    }
                    if (sign == 1)
                    {
                        myTbBk.Rows[0]["PS"] = "(-)";
                    }
                }
                if (myTbBk.Rows[0]["ps_flag"].ToString() == "2")
                {
                    if (sign == 0)
                    {
                        string content = myTbBk.Rows[0]["order_content"].ToString();
                        if (content.Contains("【+】"))
                        {
                            myTbBk.Rows[0]["order_content"] = content.Substring(0, content.IndexOf("【+")) + "【+】";
                        }
                        else
                        {
                            myTbBk.Rows[0]["order_content"] = content + "【+】";
                        }                      
                    }
                    if (sign == 1)
                    {
                        myTbBk.Rows[0]["PS"] = "(+)";
                    }
                }
            }
            for (int i = 1; i < myTbBk.Rows.Count; i++)
            {
                if (myTbBk.Rows[i]["order_content"].ToString().Trim() == "产后医嘱" || myTbBk.Rows[i]["order_content"].ToString().Trim() == "术后医嘱")
                {
                    myTbBk.Rows[i]["begintime"] = myTbBk.Rows[i]["order_bdate"].ToString();
                    myTbBk.Rows[i]["amount"] = DBNull.Value;
                    myTbBk.Rows[i]["Frency"] = DBNull.Value;
                    myTbBk.Rows[i]["First"] = DBNull.Value;
                    myTbBk.Rows[i]["FIRSET_TIMES"] = DBNull.Value;
                    myTbBk.Rows[i]["teminal_times"] = DBNull.Value;
                    myTbBk.Rows[i]["Last"] = DBNull.Value;
                    myTbBk.Rows[i]["trans_date"] = DBNull.Value;
                    myTbBk.Rows[i]["eorder_date"] = DBNull.Value;
                    continue;
                }
                if (myTbBk.Rows[i]["group_id"].ToString().Trim() != myTbBk.Rows[i - 1]["group_id"].ToString().Trim())
                {
                    myTbBk.Rows[i]["begintime"] = myTbBk.Rows[i]["order_bdate"].ToString();
                    myTbBk.Rows[i]["Usage"] = myTbBk.Rows[i]["order_usage"].ToString();
                    myTbBk.Rows[i]["Frency"] = myTbBk.Rows[i]["frequency"].ToString();
                    myTbBk.Rows[i]["First"] = myTbBk.Rows[i]["firset_times"].ToString();
                    myTbBk.Rows[i]["Last"] = myTbBk.Rows[i]["teminal_times"].ToString();
                    myTbBk.Rows[i]["presnum"] = myTbBk.Rows[i]["pres_amount"].ToString(); 
                }
                else
                {
                    myTbBk.Rows[i]["Usage"] = DBNull.Value;
                    myTbBk.Rows[i]["Frency"] = DBNull.Value;
                    myTbBk.Rows[i]["First"] = DBNull.Value;
                    myTbBk.Rows[i]["Last"] = DBNull.Value;
                    myTbBk.Rows[i]["presnum"] = DBNull.Value;
                }
                if (Convert.ToInt32(myTbBk.Rows[i]["status_falg"].ToString().Trim()) <= 2)
                {
                    myTbBk.Rows[i]["teminal_times"] = DBNull.Value;
                    myTbBk.Rows[i]["Last"] = DBNull.Value;
                }
                if (myTbBk.Rows[i]["trans_date"].ToString() == timeformat.ToString())
                {
                    myTbBk.Rows[i]["trans_date"] = DBNull.Value;
                }
                if (myTbBk.Rows[i]["eorder_date"].ToString() == timeformat.ToString())
                {
                    myTbBk.Rows[i]["eorder_date"] = DBNull.Value;
                }
                if (myTbBk.Rows[i]["ps_orderid"].ToString() != "0.000000" && myTbBk.Rows[i]["item_code"].ToString() == "")
                {
                    if (myTbBk.Rows[i]["ps_flag"].ToString() == "1")
                    {
                        if (sign == 0)
                        {
                            string content = myTbBk.Rows[i]["order_content"].ToString();
                            if (content.Contains("【-】"))
                            {
                                myTbBk.Rows[i]["order_content"] = content.Substring(0, content.IndexOf("【-")) + "【-】";
                            }
                            else
                            {    
                                myTbBk.Rows[i]["order_content"] = content + "【-】";
                            }                          
                        }
                        if (sign == 1)
                        {
                            myTbBk.Rows[i]["PS"] = "(-)";
                        }
                    }
                    if (myTbBk.Rows[i]["ps_flag"].ToString() == "2")
                    {
                        if (sign == 0)
                        {
                            string content = myTbBk.Rows[i]["order_content"].ToString();
                            if (content.Contains("【+】"))
                            {
                                myTbBk.Rows[i]["order_content"] = content.Substring(0, content.IndexOf("【+")) + "【+】";
                            }
                            else
                            {
                                myTbBk.Rows[i]["order_content"] = content + "【+】";
                            }                          
                        }
                        if (sign == 1)
                        {
                            myTbBk.Rows[i]["PS"] = "(+)";
                        }
                    }
                }
            }
            return myTbBk;

        }
        #endregion

        #region 医嘱转抄界面格式化
       /// <summary>
        /// 医嘱转抄界面格式化
        /// </summary>
        /// <param name="dt"></param>
        public static void TransOrderFormat(DataTable dt)
        {           
            int count = dt.Rows.Count;
            for (int i = 1; i < count; i++)
            {
                if (dt.Rows[i]["bed_no"].ToString() == dt.Rows[i - 1]["bed_no"].ToString() && dt.Rows[i - 1]["bed_no"] != DBNull.Value)
                {
                    dt.Rows[i]["patname"] = DBNull.Value;
                    dt.Rows[i]["cureno"] = DBNull.Value;
                    dt.Rows[i]["bed_no"] = DBNull.Value;
                }
                if (dt.Rows[i]["order_type"].ToString() == dt.Rows[i - 1]["order_type"].ToString() && dt.Rows[i - 1]["order_type"] != DBNull.Value)
                {
                    if (dt.Rows[i]["group_id"].ToString() == dt.Rows[i - 1]["group_id"].ToString())
                    {
                        dt.Rows[i]["order_bdate"] = DBNull.Value;
                        dt.Rows[i]["order_doc"] = DBNull.Value;
                        dt.Rows[i]["order_type"] = DBNull.Value;
                    }
                }
            }
        }
       #endregion

        #region 获得医嘱的组号
        /// <summary>
        /// 获得医嘱的组号
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="order_type"></param>
        /// <returns></returns>
        public static int GetGroupMax(int patlistid,int ordertype)
        {
            int type = ordertype;
            string strsql = "select patlistid from zy_doc_groupid where patlistid=" + patlistid + " and order_type=" + type + " and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + "";
            DataTable dt = oleDb.GetDataTable(strsql);
            if (dt == null || dt.Rows.Count == 0)
            {
                strsql = "insert into zy_doc_groupid(patlistid,order_type,group_id,workid) values(" + patlistid + "," + type + ",1, " + HIS.SYSTEM.Core.EntityConfig.WorkID + ")";
                oleDb.DoCommand(strsql);
                return 1;
            }
            else
            {
                strsql = "select group_id from zy_doc_groupid where patlistid=" + patlistid + " and order_type=" + type + " and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + "";
                object obj = oleDb.GetDataResult(strsql);
                strsql = "update zy_doc_groupid set group_id=group_id+1 where patlistid=" + patlistid + " and order_type=" + type + " and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + "";
                oleDb.DoCommand(strsql);
                if (obj != null && obj != DBNull.Value)
                {
                    return Convert.ToInt32(obj.ToString()) + 1;
                }
                else
                {
                    return -1;
                }
            }
        }
        #endregion

        #region 医嘱管理界面中获得一组医嘱的起始点和终点
        /// <summary>
        /// 医嘱管理界面中获得一组医嘱的起始点和终点  
        /// </summary>
        /// <param name="nrow"></param>
        /// <param name="myTb"></param>
        /// <param name="beginNum"></param>
        /// <param name="endNum"></param>
        private  static  void FindBeginEnd(int nrow,List<HIS.Model.zy_doc_orderrecord_son> records, ref int beginNum, ref int endNum)
        {
            DateTime timeformat = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());
            int i = 0;
            beginNum = nrow;
            endNum = nrow;
            for (i = nrow; i <= records.Count - 1; i++)
            {
                if (i + 1 == records.Count)
                {
                    endNum = i;
                    break;
                }
                if ( records[i+1].BeginTime.ToString()  == timeformat.ToString())
                {
                    endNum = i + 1;
                }
                else break;
            }
            for (i = nrow; i >= 0; i--)
            {
                if (i == 0)
                {
                    break;
                }
                if (records[i].BeginTime.ToString() == timeformat.ToString())
                {
                    beginNum = i - 1;
                }
                else break;
            }
        }
        #endregion

        #region 数据视图→表
        private static DataTable insertRow(DataView myView, DataTable dt)
        {
            DataTable myTb = dt.Copy(); ;
            myTb.Rows.Clear();
            foreach (DataRowView myDRV in myView)
            {
                DataRow newDR = myTb.NewRow();
                for (int i = 0; i < myView.Table.Columns.Count; i++)
                {
                    newDR[i] = myDRV[i];
                }
                myTb.Rows.Add(newDR);
            }
            return myTb;
        }
        #endregion

        #region 根据医嘱ID获得医嘱状态
        /// <summary>
        ///  根据医嘱ID获得医嘱状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public static int GetStatus(int orderid)
        {
            string strWhere = Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + orderid;
            object obj = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.STATUS_FALG, strWhere);
            if (obj != null && obj != DBNull.Value)
            {
                return Convert.ToInt32(obj.ToString());
            }
            else
            {
                return -1;
            }
        }
        #endregion  

        #region 判断医嘱是否转抄。
        public static bool IsTransOrder(int orderid)
        {
            string strsql = Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + orderid;
            object obj = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.STATUS_FALG, strsql);
            if (obj.ToString() == "2")
            {
                return true;
            }
            return false;
        }
        #endregion  

        #region 根据病人ID获得病人的已转抄还未执行的医嘱
        /// <summary>
        /// 根据病人ID获得病人的已转抄还未执行的医嘱
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public static DataTable GetNotExesOrders(int patlistid)
        {
            string strWhere = Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid
                + oleDb.And() + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 0
                + oleDb.And() + Tables.zy_doc_orderrecord.ITEM_TYPE + oleDb.LessThan() + 4
                + oleDb.And() + Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 2
                + oleDb.And() + Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + 0;
            return BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetList(strWhere);
        }
        #endregion         
     
    }
}
