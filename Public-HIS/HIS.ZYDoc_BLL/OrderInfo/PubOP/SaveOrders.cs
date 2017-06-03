using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZYDoc_BLL.OrderInfo
{
    partial class SaveOrders
    {
        static DateTime timeformat = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());

        #region  医嘱保存处理
        /// <summary>
        /// 医嘱保存处理
        /// </summary>
        /// <param name="records"></param>
        /// <param name="deptid"></param>
        /// <param name="ordertype"></param>
        /// <param name="patlistid"></param>
        /// <param name="order_record"></param>
        /// <param name="updateorders"></param>
        public static WrongDecline SaveOrder(List<HIS.Model.zy_doc_orderrecord_son> records, int deptid, int ordertype, HIS.Model.ZY_PatList patlist,
                          out List<HIS.Model.ZY_DOC_ORDERRECORD> order_record,out List<Model.ZY_DOC_ORDERRECORD> update_records)
        {
         order_record = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
         update_records = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            int group_max = 0;//病人最大医嘱组号           
            DateTime time = timeformat;
            DateTime InsertTime = timeformat;         
            WrongDecline wrong=  OrderCheck.OrderChecks(records, (OrderType)ordertype);
            if (records == null)
            {
                return wrong;
            }
            if (wrong.err=="0")
            {
                #region 分组的处理
                for (int i = 0; i < records.Count; i++)
                {                
                    if (records[i].EXEC_DEPT == 0)
                    {
                        records[i].EXEC_DEPT = deptid;
                    }
                    if (records[i].ITEM_TYPE != 7) //不是说明性医嘱的要判断医嘱名称是否合法
                    {
                        if (records[i].STATUS_FALG < 2)
                        {
                            int itemid = records[i].MAKEDICID == 0 ? records[i].ORDITEM_ID : records[i].MAKEDICID;
                            int type = records[i].ITEM_TYPE;
                            records[i].ORDER_CONTENT = OrderCheck.IsRightName(records[i].ORDER_CONTENT, itemid, type);
                        }
                    }
                    if (records[i].STATUS_FALG == -1 && records[i].ORDER_CONTENT != null && records[i].ORDER_CONTENT != "" && records[i].ORECORD_A2 != 2)
                    {
                        #region  按右键插入的行
                        if (records[i].ORECORD_A1 == 1)
                        {
                            int beginNum = 0;
                            int endNum = 0;
                            int sid = 0;
                            FindBeginEnd(i, records, ref beginNum, ref endNum);
                            int group = records[beginNum].GROUP_ID;
                            InsertTime = records[beginNum].ORDER_BDATE;
                            int _ordertype = records[beginNum].ORDER_TYPE;
                            for (int j = beginNum; j <= endNum; j++)
                            {
                                if (records[j].STATUS_FALG == 0)
                                {
                                    records[j].SERIAL_ID = sid;
                                    update_records.Add(records[j]);
                                }
                                else
                                {
                                    if (_ordertype == 7)
                                    {
                                        records[j].ORDER_CONTENT = records[j].ORDER_CONTENT + " 「出院带药」";
                                    }
                                    if (_ordertype == 5)
                                    {
                                        records[j].ORDER_CONTENT = records[j].ORDER_CONTENT + " 「交病人」";
                                    }
                                    records[j].GROUP_ID = group;
                                    records[j].SERIAL_ID = sid;
                                    records[j].STATUS_FALG = 0;
                                    records[j].ORDER_USAGE = records[beginNum].ORDER_USAGE;
                                    records[j].FREQUENCY = records[beginNum].FREQUENCY;
                                    records[j].FIRSET_TIMES = records[beginNum].FIRSET_TIMES;
                                    records[j].ORDER_TYPE = _ordertype;
                                    records[j].ORDER_BDATE = InsertTime;
                                    records[j].ORECORD_A1 = 1;
                                    records[j].ORECORD_A2 = 1;
                                    order_record.Add(records[j]);
                                }
                                sid += 1;
                            }
                        }
                        #endregion
                        #region
                        else
                        {
                            if (records[i].ITEM_TYPE > 3 || records[i].ITEM_TYPE==0) //不是药品的不分组
                            {
                                #region 不是药品的不分组
                                if (records[i].BeginTime.ToString() != timeformat.ToString())
                                {
                                    group_max = PubMethd.GetGroupMax(patlist.PatListID, ordertype);
                                    records[i].ORDER_BDATE = records[i].BeginTime;
                                    time = records[i].BeginTime;
                                }
                                if (records[i].BeginTime.ToString() == timeformat.ToString())
                                {
                                    group_max =PubMethd.GetGroupMax(patlist.PatListID,ordertype);
                                    records[i].ORDER_BDATE = time;
                                }
                                records[i].GROUP_ID = group_max;
                                records[i].SERIAL_ID = 0;
                                records[i].STATUS_FALG = 0;
                                order_record.Add(records[i]);
                                #endregion
                            }
                            else                   //是药品的要分组
                            {
                                #region 是药品的要分组
                                int Index = i; ;
                                List<HIS.Model.ZY_DOC_ORDERRECORD> list = GroupSave(records, i, ref Index, ordertype, deptid, patlist.PatListID);
                                for (int j = 0; j < list.Count; j++)
                                {
                                    order_record.Add(list[j]);
                                }
                                i = Index;
                                #endregion
                            }
                        }
                        #endregion
                    }
                    if (records[i].STATUS_FALG == -1 && records[i].ORECORD_A2 == 2) //如果是修改的再次重新保存
                    {
                        UpdateSave(records[i], i);
                        update_records.Add(records[i]);
                    }
                }
                #endregion               
            }         
            return wrong;
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
        private static void FindBeginEnd(int nrow, List<HIS.Model.zy_doc_orderrecord_son> orders, ref int beginNum, ref int endNum)
        {

            int i = 0;
            beginNum = nrow;
            endNum = nrow;
            for (i = nrow; i <= orders.Count - 1; i++)
            {
                if (i + 1 == orders.Count)
                {
                    endNum = i;
                    break;
                }
                if (orders[i + 1].BeginTime.ToString() == timeformat.ToString())
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
                if (orders[i].BeginTime.ToString() == timeformat.ToString())
                {
                    beginNum = i - 1;
                }
                else break;
            }
        }
        #endregion

        #region 一组医嘱的保存
        /// <summary>
        /// 一组医嘱的保存
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="i"></param>
        /// <param name="Index"></param>
        /// <param name="ordertype"></param>
        /// <returns></returns>
        private static List<HIS.Model.ZY_DOC_ORDERRECORD> GroupSave(List<HIS.Model.zy_doc_orderrecord_son> records, int i, ref int Index, int ordertype, int deptid, int patlistid)
        {
            int group_max = 0;//病人最大医嘱组号    
            List<HIS.Model.ZY_DOC_ORDERRECORD> order_record = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            group_max = PubMethd.GetGroupMax(patlistid, ordertype);
            records[i].ORDER_BDATE = records[i].BeginTime;
            DateTime date = records[i].ORDER_BDATE;
            records[i].PRES_DEPTID = deptid;
            records[i].GROUP_ID = group_max;
            records[i].SERIAL_ID = 0;
            records[i].STATUS_FALG = 0;
            order_record.Add(records[i]);
            for (int j = i + 1, seriaid = 1; j < records.Count; j++)
            {
                if (records[j].BeginTime.ToString() == timeformat.ToString())
                {
                    records[j].GROUP_ID = group_max;
                    records[j].SERIAL_ID= seriaid;
                    records[j].STATUS_FALG = 0;
                    records[j].ORDER_BDATE = date;
                    seriaid += 1;
                    order_record.Add(records[j]);
                    if (j == records.Count - 1)
                    {
                        Index = j;
                        break;
                    }
                }
                if (records[j].BeginTime.ToString() != timeformat.ToString())
                {
                    Index = j - 1;
                    break;
                }
            }
            return order_record;
        }
        #endregion

        #region 修改医嘱保存
        /// <summary>
        /// 修改医嘱保存
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private static void UpdateSave(HIS.Model.zy_doc_orderrecord_son record, int i)
        {
            string ordercontent = record.ORDER_CONTENT.ToString().Trim();
            if (ordercontent == "术后医嘱" || ordercontent == "产后医嘱" || record.ITEM_TYPE == 10)
            {
                record.STATUS_FALG = 1;
            }
            else if (PubMethd.IsTransOrder(record.ORDER_ID))
            {
                record.STATUS_FALG = 2;
            }
            else
            {
                record.STATUS_FALG = 0;
            }
            if (record.BeginTime.ToString() != timeformat.ToString())
            {
                record.ORDER_BDATE = record.BeginTime;// Convert.ToDateTime(dt.Rows[i]["BeginTime"].ToString());
            }
            record.ORECORD_A2 = 1;
        }
        #endregion
       
    }
}
