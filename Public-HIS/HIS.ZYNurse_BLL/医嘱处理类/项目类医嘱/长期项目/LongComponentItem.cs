using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;

namespace HIS.ZYNurse_BLL
{
    public class LongComponentItem:AbstractItem
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)
        {
            int itemid;
            DataTable dt =TcgetOrderItem(zy_doc_orderrecord.TC_ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {   
                itemid = Convert.ToInt32(dt.Rows[i]["item_id"].ToString());
                InsertComponentItemFee(orderid, itemid, servertime, zy_doc_orderrecord);
            }
            base.insertorderexec(orderid, base.Employeeid, servertime);
            base.updateLongOrderFlag(orderid);            
        }
        
        public override void InsertComponentItemFee(int order_id,int item_id,DateTime server_datetime, ZY_DOC_ORDERRECORD zy_doc_orderrecord)
        {
            int orderid = order_id;
            int itemid = item_id;
            DateTime ServerDateTime = server_datetime;
            Model.ZY_PresOrder presorder = new ZY_PresOrder();
            //Model.ZY_PresMaster premaster = new ZY_PresMaster();
            string strwhere1 = "order_id=" + orderid;           
            string string1 = "op_date=" + "'" + ServerDateTime + "'";
            string string2 = "oprerator=" +base.Employeeid;
            BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere1, string1, string2);
            presorder.PatListID =zy_doc_orderrecord.PATID;
            presorder.MarkDate =zy_doc_orderrecord.TRANS_DATE;
            presorder.PresDate = zy_doc_orderrecord.ORDER_BDATE;
            presorder.PresDocCode = zy_doc_orderrecord.ORDER_DOC.ToString();
            presorder.PresDeptCode = zy_doc_orderrecord.PRES_DEPTID.ToString();
            presorder.ExecDeptCode = zy_doc_orderrecord.EXEC_DEPT.ToString();
            presorder.ItemID = itemid;
            presorder.order_id = zy_doc_orderrecord.ORDER_ID;
            presorder.group_id = zy_doc_orderrecord.GROUP_ID;
            presorder.order_type = zy_doc_orderrecord.ORDER_TYPE;
            string ordercontent = zy_doc_orderrecord.ORDER_CONTENT;
            int unit_type = zy_doc_orderrecord.UNITTYPE;
            int item_type = zy_doc_orderrecord.ITEM_TYPE;
            string frequency_time = zy_doc_orderrecord.FREQUENCY;
            int first_time = zy_doc_orderrecord.FIRSET_TIMES;
            int last_time = zy_doc_orderrecord.TEMINAL_TIMES;
            decimal num = zy_doc_orderrecord.AMOUNT;
            decimal pres_amount = zy_doc_orderrecord.PRES_AMOUNT;
            DateTime order_enddate = zy_doc_orderrecord.EORDER_DATE;

            string strWhere4 = "patlistid=" + presorder.PatListID;
            string str4 = "patid";
            presorder.PatID = Convert.ToInt32(BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue(str4, strWhere4));

            string strWhere6 = "name='" + frequency_time + "'";
            string str6 = "execnum";
            int execNum = Convert.ToInt32(BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetFieldValue(str6, strWhere6));

            presorder.CostDate = ServerDateTime;
            presorder.ChargeCode = Convert.ToString(base.Employeeid);
            presorder.Charge_Flag = 1;
           
            string strWhere2 = "server_item_id=" + itemid + " and drug_flag=0";
            string[] str2 = new string[7];
            str2[0] = "packunit";
            str2[1] = "leastunit";
            str2[2] = "packnum";
            str2[3] = "buy_price";
            str2[4] = "sell_price";
            str2[5] = "STATITEM_CODE";
            str2[6] = "itemname";
            DataTable dt2 = BindEntity<Views.vi_clinical_all_items>.CreateInstanceDAL(oleDb).GetList(strWhere2, str2);
            if (dt2.Rows.Count == 0)
            {
                throw new Exception("套餐项目【" + ordercontent + "】未找到，请检查基础数据中该套餐是否已正确维护！");
            }
            presorder.PackUnit = dt2.Rows[0]["packunit"].ToString();
            presorder.Unit = dt2.Rows[0]["leastunit"].ToString();
            presorder.RelationNum = Convert.ToDecimal(dt2.Rows[0]["packnum"].ToString());
            presorder.Buy_Price = Convert.ToDecimal(dt2.Rows[0]["buy_price"].ToString());
            presorder.Sell_Price = Convert.ToDecimal(dt2.Rows[0]["sell_price"].ToString());
            presorder.ItemName = dt2.Rows[0]["itemname"].ToString();
            presorder.Drug_Flag = 1;
            presorder.PresType = "4";
            presorder.Amount = num;
            presorder.Tolal_Fee = Convert.ToDecimal(num * presorder.Sell_Price);
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
