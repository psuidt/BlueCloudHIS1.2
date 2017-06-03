using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.Core;


namespace HIS.ZYNurse_BLL
{
    public class TempSingleItem:AbstractItem
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)
        {
            base.insertorderexec(orderid, base.Employeeid, servertime);
            base.updateTempOrderFlag(orderid);
            InsertItemFee(orderid, servertime, zy_doc_orderrecord);
            base.InsertTempDrugUsageFee(zy_doc_orderrecord.ORDER_ID, zy_doc_orderrecord.GROUP_ID, zy_doc_orderrecord.ORDER_USAGE, servertime, zy_doc_orderrecord);
        }
        public override void InsertItemFee(int order_id, DateTime server_datetime, ZY_DOC_ORDERRECORD zy_doc_orderrecord)
        {
            DateTime ServerDateTime = server_datetime;
            int employeeid = base.Employeeid;
            int orderid = order_id;
            int itemid;
            Model.ZY_PresOrder presorder = new ZY_PresOrder();
            //Model.ZY_PresMaster premaster = new ZY_PresMaster();
            string strwhere1 = "order_id=" + orderid;           
            string string1 = "op_date=" + "'" + ServerDateTime + "'";
            string string2 = "oprerator=" + employeeid;
            BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere1, string1, string2);
            presorder.PatListID = zy_doc_orderrecord.PATID;
            presorder.MarkDate = zy_doc_orderrecord.TRANS_DATE;
            presorder.PresDate = zy_doc_orderrecord.ORDER_BDATE;
            presorder.PresDocCode = zy_doc_orderrecord.ORDER_DOC.ToString();
            presorder.PresDeptCode = zy_doc_orderrecord.PRES_DEPTID.ToString();
            presorder.ExecDeptCode = zy_doc_orderrecord.EXEC_DEPT.ToString();
            itemid = zy_doc_orderrecord.ORDITEM_ID;
            presorder.ItemName = zy_doc_orderrecord.ORDER_CONTENT;
            presorder.order_id = zy_doc_orderrecord.ORDER_ID;
            presorder.group_id = zy_doc_orderrecord.GROUP_ID;
            string ordercontent = zy_doc_orderrecord.ORDER_CONTENT;          
            presorder.order_type = 1;
            int unit_type = zy_doc_orderrecord.UNITTYPE;
            int item_type = zy_doc_orderrecord.ITEM_TYPE;
            string frequency_time = zy_doc_orderrecord.FREQUENCY != "0" ? zy_doc_orderrecord.FREQUENCY : "1";
            decimal num = zy_doc_orderrecord.AMOUNT;
            decimal pres_amount = zy_doc_orderrecord.PRES_AMOUNT;
            string strWhere4 = "patlistid=" + presorder.PatListID;
            string str4 = "patid";
            presorder.PatID = Convert.ToInt32(BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue(str4, strWhere4));

            string strWhere6 = "name='" + frequency_time + "'";
            string str6 = "execnum";
            int execNum;
            if (frequency_time == "1" || frequency_time == "" || frequency_time == null)
            {
                execNum = 1;
            }
            else
            {
                execNum = Convert.ToInt32(BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetFieldValue(str6, strWhere6));
            }
            presorder.CostDate = ServerDateTime;
            presorder.ChargeCode = Convert.ToString(base.Employeeid);
            presorder.Charge_Flag = 1;            
            string strWhere2 = "itemid=" + itemid + "  and order_type=" + item_type + " and drug_flag=0";
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
                throw new Exception("项目【" + ordercontent + "】未找到，该项目已不存在，请检查基础数据！");
            }
            presorder.ItemID = Convert.ToInt32(dt2.Rows[0]["server_item_id"].ToString());
            presorder.PackUnit = dt2.Rows[0]["packunit"].ToString();
            presorder.Unit = dt2.Rows[0]["leastunit"].ToString();
            presorder.RelationNum = Convert.ToDecimal(dt2.Rows[0]["packnum"].ToString());
            presorder.Buy_Price = Convert.ToDecimal(dt2.Rows[0]["buy_price"].ToString());
            presorder.Sell_Price = Convert.ToDecimal(dt2.Rows[0]["sell_price"].ToString());
            presorder.ItemType = dt2.Rows[0]["STATITEM_CODE"].ToString();
            presorder.Drug_Flag = 1;
            presorder.PresType = "4";
            presorder.Amount = num * execNum;
            presorder.Tolal_Fee = Convert.ToDecimal(presorder.Amount * presorder.Sell_Price);           
            presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
            BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
            //premaster.PatListID = presorder.PatListID;
            //premaster.PatID = presorder.PatID;
            //premaster.PresType = Convert.ToString(1);
            //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
            //string strWhere7 = "presorderid=" + presorder.PresOrderID;
            //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
            //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere7, updatefile);
            return;
        }
    }
}
