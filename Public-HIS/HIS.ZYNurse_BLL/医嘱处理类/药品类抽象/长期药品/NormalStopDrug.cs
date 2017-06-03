using System;
using System.Collections.Generic;
using System.Text;

using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;

namespace HIS.ZYNurse_BLL
{
    public class NormalStopDrug:LongDrugCommon 
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)
        {
           
            string strWhere2 = " order_id=" + orderid;
            string strSet = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 5;
            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere2, strSet);
            DateTime currentTime = servertime;           
            DateTime beginTime = zy_doc_orderrecord.ORDER_BDATE;
            DateTime finishTime = zy_doc_orderrecord.EORDER_DATE;
            int patlistid = zy_doc_orderrecord.PATID;
            OP_Order oporder = new OP_Order();           
            string strWhere = "date(costdate)='" + Convert.ToDateTime(currentTime.ToString("yyyy-MM-dd")) + "'" + oleDb.And() + Tables.zy_presorder.ORDER_ID + oleDb.EuqalTo() +orderid;
            bool existresult = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere);            
            if (existresult == false)//末次未执行，只执行停医嘱操作
            {
                if (zy_doc_orderrecord.TEMINAL_TIMES!= 0)
                {
                    int group_id = zy_doc_orderrecord.GROUP_ID;
                    grouplist.Add(group_id);
                    int groupnum = grouplist.Count;
                    string order_usage =zy_doc_orderrecord.ORDER_USAGE;
                    base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                    base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid, servertime);
                    if (groupnum == 1 || grouplist[groupnum - 1] != grouplist[groupnum - 2])
                    {
                        base.InsertDrugFee(zy_doc_orderrecord.ORDER_ID, currentTime, zy_doc_orderrecord);
                        base.InsertDrugUsageFee(zy_doc_orderrecord.ORDER_ID, zy_doc_orderrecord.GROUP_ID, zy_doc_orderrecord.ORDER_USAGE, currentTime,zy_doc_orderrecord);                                        
                    }
                    else
                    {
                        base.InsertDrugFee(zy_doc_orderrecord.ORDER_ID, currentTime, zy_doc_orderrecord);                          
                    }
                    base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                    base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid, servertime);
                }
                else
                {
                    base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                    base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid, servertime);              
                }
            }         
            else//先执行正常频次，后执行停医嘱操作
            {
                int firsttime = zy_doc_orderrecord.FIRSET_TIMES;
                int lasttimes = zy_doc_orderrecord.TEMINAL_TIMES;
                string frequency_time = XcConvert.IsNull(zy_doc_orderrecord.FREQUENCY, "Qd");
                string strWhere6 = "name='" + frequency_time + "'";
                string str6 = "execnum";
                int execNum = Convert.ToInt32(BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetFieldValue(str6, strWhere6));

                if (beginTime.ToString("yyyy-MM-dd") == currentTime.ToString("yyyy-MM-dd") && finishTime.ToString("yyyy-MM-dd") == currentTime.ToString("yyyy-MM-dd"))//当天开当天停的特殊情况，正常频次不能执行
                {
                    if (firsttime == 0)
                    {
                        base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                        base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid, servertime); 
                    }
                    else
                    {
                        execNum = firsttime;
                        string str = " date(costdate)='" + Convert.ToDateTime(currentTime.ToString("yyyy-MM-dd")) + "'" + oleDb.And() + Tables.zy_presorder.ORDER_ID + oleDb.EuqalTo() + orderid + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 0 + oleDb.And() + Tables.zy_presorder.PATLISTID + oleDb.EuqalTo() + zy_doc_orderrecord.PATID;
                        List<DateTime> datelist = new List<DateTime>();
                        List<ZY_PresOrder> zy_presorder = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(str);
                        for (int i = 0; i < zy_presorder.Count; i++)
                        {
                            List<int> presorderlist = new List<int>();
                            presorderlist.Add(zy_presorder[i].PresOrderID);
                            datelist.Add(zy_presorder[i].CostDate);
                            decimal amount =oporder.getsingleresult(presorderlist);
                            if (execNum < lasttimes)//首次小于末次，补充数量
                            {
                                decimal cancelamount = Math.Ceiling(amount * (execNum - lasttimes) / execNum);
                                oporder.insertamountaccount(patlistid, presorderlist, datelist, cancelamount,currentTime);
                            }
                            else if (execNum > lasttimes)//首次大于末次，冲正数量
                            {
                                decimal cancelamount = Math.Ceiling(amount * (execNum - lasttimes) / execNum);
                                if (cancelamount > 0)//数量已冲完，过滤掉0数量自动冲，3月25日修改
                                {
                                    oporder.autocanamountaccount(patlistid, presorderlist, datelist, cancelamount, currentTime);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                                base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid, servertime);
                            }
                        }
                    }
                }
                else//非当天开当天停的情况
                {
                    if (execNum != lasttimes)//在正常频次和末次不相等的情况下，先充掉已执行的正常频率，再执行末次频率
                    {
                        string str = " date(costdate)='" + Convert.ToDateTime(currentTime.ToString("yyyy-MM-dd")) + "'" + oleDb.And() + Tables.zy_presorder.ORDER_ID + oleDb.EuqalTo() + orderid + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 0 + oleDb.And() + Tables.zy_presorder.PATLISTID + oleDb.EuqalTo() + patlistid;
                        List<DateTime> datelist = new List<DateTime>();
                        List<ZY_PresOrder> zy_presorder = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(str);
                        for (int i = 0; i < zy_presorder.Count; i++)
                        {
                            List<int> presorderlist = new List<int>();
                            presorderlist.Add(zy_presorder[i].PresOrderID);
                            datelist.Add(zy_presorder[i].CostDate);
                            decimal amount =oporder.getsingleresult(presorderlist);
                            if (execNum > lasttimes)
                            {
                                decimal cancelamount = Math.Ceiling(amount * (execNum - lasttimes) / execNum);//1月8日增加，修改冲正模式。
                                oporder.autocanamountaccount(patlistid, presorderlist, datelist, cancelamount, currentTime);
                            }
                            else
                            {
                                decimal cancelamount = Math.Ceiling(amount * (execNum - lasttimes) / execNum);
                                oporder.insertamountaccount(patlistid, presorderlist, datelist, cancelamount,currentTime);
                            }
                        }
                    }
                    else//在正常频次和末次相等的情况下,只修改医嘱执行状态，不做先充后执行操作
                    {
                        base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                        base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid, servertime);
                    }
                }
            }        
        }        
    }
}
