using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZYDoc_BLL.OrderInfo
{
    partial class DeleteDeal
    {
        static DateTime timeformat = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());
        
        #region 删除一条医嘱
        /// <summary>
        /// 删除一条医嘱
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowindex"></param>
        private  static  List<HIS.Model.ZY_DOC_ORDERRECORD> DeleteOneOrder(List<HIS.Model.zy_doc_orderrecord_son> records, HIS.Model.ZY_PatList zy_Patlist, int rowindex)
        {
            List<HIS.Model.ZY_DOC_ORDERRECORD> Drecoreds = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            TempOperation tempop = new TempOperation();
            #region 皮试医嘱的处理
            if (records[rowindex].ORDER_USAGE == "皮试" && records[rowindex].PS_ORDERID > 0)
            {
                TempOperation temp = new TempOperation();
                if (temp.DelPs(zy_Patlist.PatListID, records[rowindex].PS_ORDERID))
                    records[rowindex].DELETE_FLAG = 1;
                    return null;
            }
            #endregion
            records[rowindex].DELETE_FLAG = 1;
            //如果删除的是一组医嘱中的第一条，要将第一条的开始时间付值给第二条
            if (rowindex < records.Count - 1 && IsGroupFirstRow(records, rowindex))
            {
                if ((rowindex + 1) < records.Count)
                {
                    if ((rowindex + 1) < records.Count)
                    {
                        if (records[rowindex + 1].GROUP_ID == records[rowindex].GROUP_ID)
                        {
                            records[rowindex + 1].BeginTime = records[rowindex].BeginTime;
                            records[rowindex + 1].Usage = records[rowindex].Usage;
                            records[rowindex + 1].Frency = records[rowindex].Frency;
                            records[rowindex + 1].First = records[rowindex].First;
                            records[rowindex + 1].PresNum = records[rowindex].PresNum;
                        }
                    }
                }

            }
            Drecoreds.Add(records[rowindex]);           
            //医技申请的要取消申请表中的内容
            #region
            if (records[rowindex].ITEM_TYPE == 5)
            {
                HIS.ZYDoc_BLL.BaseInfo.MediApplyBase applybase = new HIS.ZYDoc_BLL.BaseInfo.MediApplyBase();
                int type = applybase.GetApplyType(records[rowindex].ORDITEM_ID);
                HIS.ZYDoc_BLL.MediApply.IMediApply applyop = new HIS.ZYDoc_BLL.MediApply.ApplyOP();
                if (type == 0) //检查申请
                {
                    applyop.DelApply(HIS.ZYDoc_BLL.MediApply.MediType.检查, records[rowindex]);                   
                }
                if (type == 1)//检验申请
                {
                    applyop.DelApply(HIS.ZYDoc_BLL.MediApply.MediType.检验, records[rowindex]);                   
                }             
            }
            #endregion
            return Drecoreds;
        }
        #endregion

        #region 删除一组医嘱
        /// <summary>
        /// 删除一组医嘱
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowindex"></param>
        private static List<HIS.Model.ZY_DOC_ORDERRECORD> DeleteGroupOrder(List<HIS.Model.zy_doc_orderrecord_son> records, int rowindex)
        {
            List<HIS.Model.ZY_DOC_ORDERRECORD> DRecords = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            for (int i = 0; i < records.Count; i++)
            {
                if (records[i].GROUP_ID == records[rowindex].GROUP_ID)
                {
                    records[i].DELETE_FLAG = 1;
                    DRecords.Add(records[i]);                  
                }
            }
            return DRecords;
        }
        #endregion

        #region 判断是否是一组的第一行
        /// <summary>
        /// 判断是否是一组的第一行
        /// </summary>
        /// <param name="myTb"></param>
        /// <param name="nrow"></param>
        /// <returns></returns>
        private static bool IsGroupFirstRow(List<HIS.Model.zy_doc_orderrecord_son> records, int nrow)
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

        #region 出院，死亡医嘱，转科医嘱删除
        /// <summary>
        /// 出院，死亡医嘱，转科医嘱删除
        /// </summary>
        /// <param name="records"></param>
        /// <param name="rowindex"></param>
        /// <param name="zy_Patlist"></param>
        /// <param name="deptid"></param>
        /// <param name="flag"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        private static List<HIS.Model.ZY_DOC_ORDERRECORD> OutDelete(List<HIS.Model.zy_doc_orderrecord_son> records, int rowindex, HIS.Model.ZY_PatList zy_Patlist, int deptid, int emploeeid,int flag, int sign)
        {
            if (sign == 0 || records[rowindex].ITEM_TYPE == 10)
            {
                records[rowindex].DELETE_FLAG = 1;
                if (flag == 2)
                {
                    LeaveDeath leave = new LeaveDeath();
                    if (leave.updatePatType(zy_Patlist.PatListID, 0, deptid, records[rowindex]))
                    {
                        return null;
                    }
                }
                if (flag == 1)
                {
                    TurnDept turndept = new TurnDept();
                    if (turndept.DelTurn(zy_Patlist.PatListID, Convert.ToInt32(zy_Patlist.CurrDeptCode), emploeeid, records[rowindex]))
                    {
                        return null;
                    }
                }
                if (flag == 0)
                {
                    return DeleteOneOrder(records, zy_Patlist, rowindex);
                }               
            }
            if (sign == 1 && records[rowindex].ITEM_TYPE != 10)
            {
                records[rowindex].DELETE_FLAG = 1;
                return DeleteDeal.DeleteGroupOrder(records, rowindex);
            }
            return null;
        }
        #endregion

        #region 未保存的医嘱删除
        /// <summary>
        /// 未保存的医嘱删除
        /// </summary>
        /// <param name="records"></param>
        /// <param name="zy_Patlist"></param>
        /// <param name="rowindex"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        private static List<HIS.Model.ZY_DOC_ORDERRECORD> NotSaveDelete(List<HIS.Model.zy_doc_orderrecord_son> records, HIS.Model.ZY_PatList zy_Patlist, int rowindex, int sign)
        {
            int count = records.Count;
            records[rowindex].DELETE_FLAG = 1;
            #region 未保存的医嘱
            if (records[rowindex].ORDER_CONTENT != null && records[rowindex].ORDER_CONTENT != "" && records[rowindex].STATUS_FALG == -1) //未保存的医嘱
            {
                if (sign == 1)
                {
                    int begin = rowindex;
                    int end = rowindex;
                    for (int i = rowindex - 1; i >= 0; i--)
                    {
                        if ((records[i].ORDER_BDATE.ToString() == timeformat.ToString()) && records[i].BeginTime.ToString() != timeformat.ToString())
                        {
                            begin = i;
                            break;
                        }
                    }
                    for (int i = rowindex + 1; i < records.Count; i++)
                    {
                        if ((records[i].ORDER_BDATE.ToString() != timeformat.ToString()) && records[i].BeginTime.ToString() == timeformat.ToString())
                        {
                            end = i;
                            break;
                        }
                    }
                    for (int i = begin; i <= end; i++)
                    {
                        records[i].DELETE_FLAG = 1;
                    }
                    if (records[rowindex].ORDER_USAGE != null) //20100618.0.08
                    {
                        if (records[rowindex].ORDER_USAGE.Trim() == "皮试" && records[rowindex].PS_ORDERID > 0)
                        {
                            TempOperation tempop = new TempOperation();
                            tempop.DelPs(zy_Patlist.PatListID, records[rowindex].PS_ORDERID);
                            records[rowindex].DELETE_FLAG = 1;
                            return null;
                        }
                    }
                }
                if (sign == 0)
                {
                    if (rowindex < count - 1)
                    {
                        if ((rowindex + 1) < records.Count)
                        {
                            if(records[rowindex+1].BeginTime.ToString()==timeformat.ToString())                          
                            {
                                records[rowindex + 1].BeginTime = records[rowindex].BeginTime;
                                records[rowindex + 1].Usage = records[rowindex].Usage;
                                records[rowindex + 1].Frency = records[rowindex].Frency;
                                records[rowindex + 1].First = records[rowindex].First;
                                records[rowindex + 1].PresNum = records[rowindex].PresNum;
                            }
                        }                        
                    }
                    records[rowindex].DELETE_FLAG = 1;
                    
                }
                     
            }
            return null;
            #endregion
        }
        #endregion

        #region 医嘱删除处理
        public static List<HIS.Model.ZY_DOC_ORDERRECORD> DeleteOrder(List<HIS.Model.zy_doc_orderrecord_son> records,HIS.Model.ZY_PatList zy_Patlist,int rowindex, int sign,int deptid,int employid,out bool  IsOut)
        {
            IsOut = false;
            int status = -1;            
            if (records[rowindex].STATUS_FALG != -1)
            {
                status =PubMethd.GetStatus(records[rowindex].ORDER_ID);
            }
            #region 已发送的作废医嘱的处理
            if (status > 1) //已发送的作废医嘱的处理
            {
                if (status == 5 && records[rowindex].ORDER_CONTENT.IndexOf("【取消】") == 0)
                {
                    TempOperation tempop = new TempOperation();
                    return tempop.NotAbolish(records[rowindex]);                    
                }
               
            }
            #endregion

            #region 已保存的医嘱
            if (status == 0) //已保存的医嘱
            {
                #region 删除一行时
                if (sign == 0)
                {
                    return DeleteOneOrder(records, zy_Patlist, rowindex);
                }
                #endregion

                #region 删除一组时
                if (sign == 1)
                {
                    return DeleteGroupOrder(records, rowindex);
                }
                #endregion
               
            }
            #endregion

            #region 已发送的医嘱
            if (records[rowindex].ORDER_CONTENT != null && records[rowindex].ORDER_CONTENT != "" && status == 1) //已发送的医嘱
            {
                int flag = 0;
                if (records[rowindex].ITEM_TYPE == 10 && records[rowindex].ORDER_CONTENT.IndexOf("转", 0) >= 0 || (records[rowindex].ITEM_TYPE == 10
                    && records[rowindex].ORDER_CONTENT.Trim() == "入重症监护室") || (records[rowindex].ITEM_TYPE == 10 && records[rowindex].ORDER_CONTENT.Trim() == "出重症监护室"))
                {
                    flag = 1;
                }
                else if (records[rowindex].ITEM_TYPE == 10 && records[rowindex].ORDER_CONTENT.Trim().IndexOf("出院", 0) >= 0)
                {
                    flag = 2;
                    IsOut = true;
                }
                else if (records[rowindex].ITEM_TYPE == 10 && records[rowindex].ORDER_CONTENT.Trim().IndexOf("病人死亡", 0) >= 0)
                {
                    flag = 2;
                    IsOut = true;
                }
             return    OutDelete(records, rowindex, zy_Patlist, deptid, employid, flag, sign);
                
            }
            #endregion

            #region 未保存
            return NotSaveDelete(records, zy_Patlist, rowindex, sign);
            #endregion
        }
        #endregion
    }
}
