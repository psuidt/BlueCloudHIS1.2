using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZYDoc_BLL.OrderInfo
{
   partial class OrderCheck
    {
       static  DateTime timeformat = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());
       static HIS.ZYDoc_BLL.BaseInfo.CheckBase checkbase = new HIS.ZYDoc_BLL.BaseInfo.CheckBase();
       public static WrongDecline OrderChecks(List<HIS.Model.zy_doc_orderrecord_son> records, OrderType ordertype)
       {
           WrongDecline wrong = new WrongDecline();
           if (records == null)
           {
               wrong.SetData(0, 0, "0");
               return wrong;
           }
           int count = records.Count;
           #region 数据合理性判断
           if (count == 0)
           {
               wrong.SetData(0, 0, "0");
               return wrong;
           }
           for (int i = 0; i < count; i++)
           {
               if (records[i].ORDER_CONTENT == null || records[i].ORDER_CONTENT == "")
               {
                   records[i].DELETE_FLAG = 1;
                   continue;
               }
               if (records[i].STATUS_FALG > 1)//已经发送的不再判断，医嘱内容为空的直接删除
               {
                   continue;
               }
               if (records[i].ITEM_TYPE == 10 || records[i].ITEM_TYPE == 7)
               {
                   continue;
               }
               if (records[i].Usage == "皮试" || records[i].Usage == "皮试用")
               {
                   continue;
               }
               records[i].AMOUNT = Convert.ToDecimal(records[i].AMOUNT.ToString("0.000"));
               if (ordertype == OrderType.临时医嘱)
               {
                   if (records[i].ITEM_TYPE < 4)
                   {
                       int unittype = records[i].UNITTYPE;
                       #region 是否非法单位
                       if (!IsRightUnit(records[i].UNIT, out unittype, records[i].MAKEDICID, records[i].ITEM_TYPE))
                       {
                           wrong.SetData(4, i, "C03");
                           return wrong;
                       }
                       records[i].UNITTYPE = unittype;
                       #endregion
                   }
                   if (records[i].AMOUNT == 0 || records[i].PRES_AMOUNT == 0)
                   {
                       wrong.SetData(3, i, "C01", records[i].ORDER_CONTENT);
                       return wrong;
                   }
               }
               if (ordertype == OrderType.长期医嘱)
               {
                   if (records[i].AMOUNT == 0)
                   {
                       wrong.SetData(3, i, "C01", records[i].ORDER_CONTENT);
                       return wrong;
                   }
               }
               if (records[i].AMOUNT <= 0 || records[i].PRES_AMOUNT < 0)
               {
                   wrong.SetData(3, i, "C02", records[i].ORDER_CONTENT);
                   return wrong;
               }
           #endregion
               if (!IsGroupFirstRow(records, i)) //只要每组的第一行作判断
               {
                   continue;
               }
               //项目也要判断用法和频次是否合法　　2010.3.29
               if (records[i].ITEM_TYPE > 3 || records[i].ITEM_TYPE == 0)
               {
                   if (records[i].Usage == "" || records[i].Frency == "" || records[i].Usage == null || records[i].Frency == null)// dt.Rows[i]["Usage"].ToString() == "" || dt.Rows[i]["Frency"].ToString().Trim() == "")
                       continue;
               }
               #region 是否非法用法
               if (!IsRightUsage(records[i].Usage))
               {
                   wrong.SetData(5, i, "C04");
                   return wrong;
               }
               #endregion

               #region 是否非法频率
               if (ordertype == OrderType.长期医嘱 && records[i].Frency == null) //临嘱可以不写频率 (后来修改)
               {
                   wrong.SetData(6, i, "C05");
                   return wrong;
               }
               if (!IsRightFrequcy(records[i].Frency))
               {
                   wrong.SetData(6, i, "C06");
                   return wrong;
               }
               #endregion
           }
           wrong.SetData(0, 0, "0");
           return wrong;
       }

        #region 判断是否是一组的第一行
        /// <summary>
        /// 判断是否是一组的第一行
        /// </summary>
        /// <param name="myTb"></param>
        /// <param name="nrow"></param>
        /// <returns></returns>
        private static  bool IsGroupFirstRow(List<HIS.Model.zy_doc_orderrecord_son> records, int nrow)
        {
            if (nrow == 0) return true;
            if (records[nrow].BeginTime.ToString() != timeformat.ToString() || records[nrow].ORDER_CONTENT.ToString().Trim() == "术后医嘱"
                || records[nrow].ORDER_CONTENT.ToString().Trim() == "产后医嘱" || records[nrow].ITEM_TYPE == 7)
            {
                return true;//上一列无内容
            }
            return false;
        }
        #endregion

        #region  医嘱单位判断
        /// <summary>
        /// 医嘱单位判断
        /// </summary>
        /// <param name="unit">单位名称</param>
        /// <param name="itemid">药品ＩＤ</param>
        /// <param name="itemtype">药品类型</param>
        /// <param name="itemcode">药品代码</param>
        /// <returns></returns>
        private static  bool  IsRightUnit(string unit,out int unittype, int itemid, int itemtype)
        {
            DataTable dw =BaseInfo.BaseLoads.dwlx(itemid, itemtype);
            int ii = 0;
            if (unit == "")
            {
                unittype = 0;
                return false;
            }
            for (ii = 0; ii < dw.Rows.Count; ii++)
            {
                if (unit == dw.Rows[ii]["name"].ToString().Trim())
                {
                    unittype =Convert.ToInt32(dw.Rows[ii]["dwlx"].ToString());
                    return true ;
                }
            }
            unittype = 0;
            return false;
        }
        #endregion

        #region 医嘱用法判断
        /// <summary>
        /// 医嘱用法判断
        /// </summary>
        /// <param name="usage">用法名称</param>
        /// <returns></returns>
        private static  bool  IsRightUsage(string usage)
        {
            if (usage == "")
            {
                return false;
            }

            if (checkbase.IsRightUsage(usage))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 医嘱频率判断
        /// <summary>
        /// 医嘱频率判断
        /// </summary>
        /// <param name="frequcy">频率名称</param>
        /// <returns></returns>
        private static  bool  IsRightFrequcy(string frequcy)
        {
            if (frequcy == "" ||frequcy==null) //20100524.1.05 临时医嘱可以不输频率保存
            {
                return true;
            }
            if (checkbase.IsRightFrequcy(frequcy))
            {
                return true;
            }
            return false ;
        }
        #endregion       

        #region  判断医嘱名称是否合法
        /// <summary>
        /// 判断医嘱名称是否合法
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="itemid"></param>
        /// <param name="itemtype"></param>
        /// <returns></returns>
        public static  string  IsRightName(string itemname, int itemid, int itemtype)
        {
            if (itemname == null || itemname == "")
            {
                return "";
            }
            string itemname1 = itemname.Replace("'", "");
            string name2 = checkbase.IsRightName(itemname, itemid, itemtype);
            if (itemname1.IndexOf(name2, 0) < 0)
            {
                return name2;
            }
            return itemname1;
        }
        #endregion

        #region 模板明细保存前检查有效性
        /// <summary>
        /// 保存时检查医嘱的有效性
        /// </summary>
        /// <param name="colid"></param>
        /// <param name="rowid"></param>
        /// <param name="itemname">错误费用名称</param>
        /// <returns></returns>
        public  static WrongDecline CheckModelOrderData(List<HIS.Model.ZY_DOC_ORDERMODELLIST_E> list)
        {
            WrongDecline wrong = new WrongDecline();
            int count = list.Count;
            #region 数据合理性判断
            if (count == 0)
            {
                wrong.SetData(0, 0, "0");
                return wrong;
            }
            for (int i = 0; i < count; i++)
            {
                //已保存的和说明性医嘱不作判断
                if (list[i].FLAG == 1 || list[i].ITEM_TYPE == 7)
                {
                    continue;
                }
                if (list[i].AMOUNT == 0 || list[i].PRESAMOUNT == 0)
                {                  
                    wrong.SetData(3, i, "C01", list[i].ITEM_NAME);
                    return wrong;
                }
                if (list[i].AMOUNT <= 0 && list[i].PRESAMOUNT < 0)
                {                   
                    wrong.SetData(3, i, "C02", list[i].ITEM_NAME);
                    return wrong;
                }
                if (list[i].ITEM_TYPE < 4 && list[i].ITEM_TYPE>0)
                {
                    int unittype = list[i].UNITTYPE;
                    #region 是否非法单位
                    if (!IsRightUnit(list[i].UNIT,out unittype, list[i].ITEM_ID, list[i].ITEM_TYPE))
                    {
                        wrong.SetData(4, i, "C03");
                        return wrong;
                    }
                    list[i].UNITTYPE = unittype;
                    #endregion

                    #region 是否非法用法

                    if (!IsGroupFirstRow(list, i))
                    {
                        continue;
                    }
                    if (!IsRightUsage(list[i].ORDER_USAGE))
                    {
                        wrong.SetData(5, i, "C04");
                        return wrong;
                    }
                    #endregion

                    #region 是否非法频率
                    if (list[i].ORDER_FRENQUECY == "" || list[i].ORDER_FRENQUECY == null)
                    {
                        wrong.SetData(6, i, "C05");
                        return wrong;
                    }
                    if (!IsRightFrequcy(list[i].ORDER_FRENQUECY))
                    {
                        wrong.SetData(6, i, "C06");
                        return wrong;
                    }
                    #endregion
                }
            }
            wrong.SetData(0, 0, "0");
            return wrong;
            #endregion
        }
        #endregion

        #region 判断是否是一组的第一行
        private static bool IsGroupFirstRow(List<HIS.Model.ZY_DOC_ORDERMODELLIST_E> list, int nrow)
        {
            if (nrow == 0) return true;
            if (list[nrow].GroupID != 0)
            {
                return true;//上一列无内容
            }
            return false;
        }
        #endregion

    }
}
