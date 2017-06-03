using System;
using System.Collections.Generic;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;

namespace HIS.ZYNurse_BLL
{
    public class LongStopItem:AbstractItem
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)
        {          
            DateTime currentTime = servertime;
            DateTime beginTime = zy_doc_orderrecord.ORDER_BDATE;
            DateTime finishTime = zy_doc_orderrecord.EORDER_DATE;
            int patlistid = zy_doc_orderrecord.PATID;
            OP_Order oporder = new OP_Order();
            string strWhere = "date(costdate)='" + Convert.ToDateTime(currentTime.ToString("yyyy-MM-dd")) + "'" + oleDb.And() + Tables.zy_presorder.ORDER_ID + oleDb.EuqalTo() + orderid;
            bool existresult = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere);
            if (existresult == false)//末次未执行，只执行停医嘱操作
            {
                if (zy_doc_orderrecord.TEMINAL_TIMES != 0)
                {                 
                    base.insertorderexec(orderid, base.Employeeid,servertime);
                    base.updateLongOrderFlag(orderid);
                    InsertItemFee(orderid, servertime, zy_doc_orderrecord);
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
                            decimal amount = oporder.getsingleresult(presorderlist);
                            if (execNum < lasttimes)//首次小于末次，补充数量
                            {
                                decimal cancelamount = Math.Ceiling(amount * (execNum - lasttimes) / execNum);
                                oporder.insertamountaccount(patlistid, presorderlist, datelist, cancelamount, currentTime);
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
                        base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                        base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid, servertime);
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
                            decimal amount = oporder.getsingleresult(presorderlist);
                            if (execNum > lasttimes)
                            {
                                decimal cancelamount = Math.Ceiling(amount * (execNum - lasttimes) / execNum);//1月8日增加，修改冲正模式。
                                oporder.autocanamountaccount(patlistid, presorderlist, datelist, cancelamount, currentTime);
                            }
                            else
                            {
                                decimal cancelamount = Math.Ceiling(amount * (execNum - lasttimes) / execNum);
                                oporder.insertamountaccount(patlistid, presorderlist, datelist, cancelamount, currentTime);
                            }
                        }
                        base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                        base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid, servertime);
                    }
                    else//在正常频次和末次相等的情况下,只修改医嘱执行状态，不做先充后执行操作
                    {
                        base.updateLongOrderFlag(zy_doc_orderrecord.ORDER_ID);
                        base.insertorderexec(zy_doc_orderrecord.ORDER_ID, base.Employeeid, servertime);
                    }
                }
            }
        }

        public override void InsertItemFee(int order_id, DateTime server_datetime, ZY_DOC_ORDERRECORD zy_doc_orderrecord)
        {
            int orderid = order_id;
            int itemid;
            DateTime ServerDateTime = server_datetime;
            Model.ZY_PresOrder presorder = new ZY_PresOrder();
            //Model.ZY_PresMaster premaster = new ZY_PresMaster();
            string strwhere1 = "order_id=" + orderid;
            string string1 = "op_date=" + "'" + ServerDateTime + "'";
            string string2 = "oprerator=" + base.Employeeid;
            BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere1, string1, string2);
            presorder.PatListID = zy_doc_orderrecord.PATID;
            presorder.MarkDate = zy_doc_orderrecord.TRANS_DATE;
            presorder.PresDate = zy_doc_orderrecord.ORDER_BDATE;
            presorder.PresDocCode = zy_doc_orderrecord.ORDER_DOC.ToString();
            presorder.PresDeptCode = zy_doc_orderrecord.PRES_DEPTID.ToString();
            presorder.ExecDeptCode = zy_doc_orderrecord.EXEC_DEPT.ToString();
            itemid = zy_doc_orderrecord.ORDITEM_ID == 0 ? zy_doc_orderrecord.MAKEDICID : zy_doc_orderrecord.ORDITEM_ID;
            presorder.ItemName = zy_doc_orderrecord.ORDER_CONTENT;
            presorder.order_id = zy_doc_orderrecord.ORDER_ID;
            presorder.group_id = zy_doc_orderrecord.GROUP_ID;
            presorder.order_type = zy_doc_orderrecord.ORDER_TYPE;
            string ordercontent = zy_doc_orderrecord.ORDER_CONTENT;
            int unit_type = zy_doc_orderrecord.UNITTYPE;
            int item_type = zy_doc_orderrecord.ITEM_TYPE;
            string frequency_time = zy_doc_orderrecord.FREQUENCY;
            int first_time = zy_doc_orderrecord.FIRSET_TIMES;
            int last_time = Convert.ToInt32(XcConvert.IsNull(zy_doc_orderrecord.TEMINAL_TIMES, "0"));
            decimal num = zy_doc_orderrecord.AMOUNT;
            decimal pres_amount = zy_doc_orderrecord.PRES_AMOUNT;
            DateTime order_begindate = zy_doc_orderrecord.ORDER_BDATE;
            DateTime order_enddate = zy_doc_orderrecord.EORDER_DATE;
            DateTime currenttime = ServerDateTime;

            string strWhere4 = "patlistid=" + presorder.PatListID;
            string str4 = "patid";
            presorder.PatID = Convert.ToInt32(BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue(str4, strWhere4));

            string strWhere6 = "name='" + frequency_time + "'";
            string str6 = "execnum";

            int execNum;
            if (currenttime.ToString("yyyy-MM-dd") == order_begindate.ToString("yyyy-MM-dd") && currenttime.ToString("yyyy-MM-dd") == order_enddate.ToString("yyyy-MM-dd"))//11月22日加，解决如果长嘱当天开，当天停，以末次计数
            {
                execNum = last_time;
            }
            else if (currenttime.ToString("yyyy-MM-dd") == order_begindate.ToString("yyyy-MM-dd"))
            {
                execNum = first_time;
            }
            else if (currenttime.ToString("yyyy-MM-dd") == order_enddate.ToString("yyyy-MM-dd"))
            {
                execNum = last_time;
            }
            else
            {
                if (frequency_time == "1" || frequency_time == "" || frequency_time == null)
                {
                    execNum = 1;
                }
                else
                {
                    execNum = Convert.ToInt32(BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetFieldValue(str6, strWhere6));
                }
            }
            presorder.CostDate = ServerDateTime;
            presorder.ChargeCode = Convert.ToString(base.Employeeid);
            presorder.Charge_Flag = 1;


            string strWhere2 = "itemid=" + itemid + " and drug_flag=0";
            string[] str2 = new string[7];
            str2[0] = "packunit";
            str2[1] = "leastunit";
            str2[2] = "packnum";
            str2[3] = "buy_price";
            str2[4] = "sell_price";
            str2[5] = "STATITEM_CODE";
            str2[6] = "server_item_id";
            DataTable dt2 = BindEntity<Views.vi_clinical_all_items>.CreateInstanceDAL(oleDb).GetList(strWhere2, str2);
            if (dt2.Rows.Count == 0)
            {
                throw new Exception("项目【" + ordercontent + "】未找到，该项目已不存在，请检查基础数据是否正确！");
            }
            presorder.ItemID = Convert.ToInt32(dt2.Rows[0]["server_item_id"].ToString());
            presorder.PackUnit = dt2.Rows[0]["packunit"].ToString();
            presorder.Unit = dt2.Rows[0]["leastunit"].ToString();
            presorder.RelationNum = Convert.ToDecimal(dt2.Rows[0]["packnum"].ToString());
            presorder.Buy_Price = Convert.ToDecimal(dt2.Rows[0]["buy_price"].ToString());
            presorder.Sell_Price = Convert.ToDecimal(dt2.Rows[0]["sell_price"].ToString());
            presorder.Drug_Flag = 1;
            presorder.PresType = "4";
            presorder.Amount = num * execNum;
            presorder.Tolal_Fee = Convert.ToDecimal(num * execNum * presorder.Sell_Price);
            presorder.ItemType = dt2.Rows[0]["STATITEM_CODE"].ToString();

            //插入费用表数据和结算表数据
            presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
            BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
            //premaster.PatListID = presorder.PatListID;
            //premaster.PatID = presorder.PatID;
            //premaster.PresType = Convert.ToString(0);
            //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
            //string strWhere7 = "presorderid=" + presorder.PresOrderID;
            //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
            //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere7, updatefile);
            return;
        }
    }
}
