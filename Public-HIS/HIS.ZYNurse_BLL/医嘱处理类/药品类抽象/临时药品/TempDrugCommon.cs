using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYNurse_BLL
{
    public class TempDrugCommon:AbstractDrug
    {
        /// <summary>
        /// 临时药品费用
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="server_datetime"></param>
        /// <param name="zy_nurse_orderrecord"></param>
        public override void InsertDrugFee(int order_id, DateTime server_datetime, ZY_DOC_ORDERRECORD zy_nurse_orderrecord)
        {
            int orderid = order_id;
            int itemid;
            DateTime ServerDateTime = server_datetime;
            Model.ZY_PresOrder presorder = new ZY_PresOrder();
            //Model.ZY_PresMaster premaster = new ZY_PresMaster(); 
            string string1 = "op_date=" + "'" + ServerDateTime + "'";
            string string2 = "oprerator=" + base.Employeeid;
            BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update("order_id=" + orderid, string1, string2);
            presorder.PatListID = zy_nurse_orderrecord.PATID;
            presorder.MarkDate = zy_nurse_orderrecord.TRANS_DATE;
            presorder.PresDate = zy_nurse_orderrecord.ORDER_BDATE;
            presorder.PresDocCode = zy_nurse_orderrecord.ORDER_DOC.ToString();
            presorder.PresDeptCode = zy_nurse_orderrecord.PRES_DEPTID.ToString();
            presorder.ExecDeptCode = zy_nurse_orderrecord.EXEC_DEPT.ToString();
            itemid =zy_nurse_orderrecord.ORDITEM_ID == 0 ? zy_nurse_orderrecord.MAKEDICID : zy_nurse_orderrecord.ORDITEM_ID;
            presorder.ItemName = zy_nurse_orderrecord.ORDER_CONTENT;
            presorder.order_id = zy_nurse_orderrecord.ORDER_ID;
            presorder.group_id = zy_nurse_orderrecord.GROUP_ID;
            string ordercontent = zy_nurse_orderrecord.ORDER_CONTENT;
            if (zy_nurse_orderrecord.ORDER_TYPE== 0)
            {
                presorder.order_type = 0;
            }
            else
            {
                presorder.order_type = 1;
            }
            int unit_type =zy_nurse_orderrecord.UNITTYPE;
            int item_type =zy_nurse_orderrecord.ITEM_TYPE;
            string frequency_time =zy_nurse_orderrecord.FREQUENCY!= "0" ? zy_nurse_orderrecord.FREQUENCY : "1";
            decimal num = zy_nurse_orderrecord.AMOUNT;
            decimal pres_amount =zy_nurse_orderrecord.PRES_AMOUNT;
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
            //取消判断库存2011.1.14 heyan
            string strWhere3 = "itemid=" + itemid + " and order_type=" + item_type + " and drug_flag=1";  //and storenum>0 and EXECDEPTCODE="+zy_nurse_orderrecord.EXEC_DEPT+""; update by heyan 2010.12.3 医嘱发送时库存为0的不能发送
            string[] str3 = new string[9];
            str3[0] = "packunit";
            str3[1] = "leastunit";
            str3[2] = "packnum";
            str3[3] = "dosenum";
            str3[4] = "buy_price";
            str3[5] = "sell_price";
            str3[6] = "float_flag";
            str3[7] = "standard";
            str3[8] = "STATITEM_CODE";
            DataTable dt3 = BindEntity<Views.vi_clinical_all_items>.CreateInstanceDAL(oleDb).GetList(strWhere3, str3);
            if (dt3.Rows.Count == 0)
            {
                throw new Exception("药品【" + ordercontent + "】未找到，该药品可能已停用或已删除或库存为0，请检查药品字典！");
            }
            presorder.ItemID = itemid;
            presorder.PackUnit = dt3.Rows[0]["packunit"].ToString();
            presorder.Unit = dt3.Rows[0]["leastunit"].ToString();
            presorder.RelationNum = Convert.ToDecimal(dt3.Rows[0]["packnum"].ToString());
            presorder.Buy_Price = Convert.ToDecimal(dt3.Rows[0]["buy_price"].ToString());
            presorder.ItemType = dt3.Rows[0]["STATITEM_CODE"].ToString();
            presorder.Drug_Flag = 0;
            presorder.Sell_Price = Convert.ToDecimal(dt3.Rows[0]["sell_price"].ToString());
            presorder.PresType = zy_nurse_orderrecord.ITEM_TYPE.ToString();
            presorder.Standard = dt3.Rows[0]["standard"].ToString();
            presorder.PresAmount = Convert.ToInt32(pres_amount);
            decimal dose_num = Convert.ToDecimal(dt3.Rows[0]["dosenum"].ToString());
            int pack_num = Convert.ToInt32(dt3.Rows[0]["packnum"].ToString());
            bool float_flag = Convert.ToInt32(dt3.Rows[0]["float_flag"].ToString()) == 1 ? true : false;

            presorder.Amount =DrugAmoutCalculation.gettempAmout(zy_nurse_orderrecord.ORDER_TYPE, float_flag, unit_type, item_type, execNum, dose_num, pack_num, num, pres_amount, presorder.PresDate);
            int tempnum = Convert.ToInt32((presorder.Amount - (presorder.Amount % pack_num)) / pack_num);
            presorder.Tolal_Fee = tempnum * presorder.Sell_Price + ((presorder.Amount % pack_num) / pack_num) * presorder.Sell_Price;
         
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
        /// <summary>
        /// 临时医嘱用法联动费用
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="group_id"></param>
        /// <param name="order_usage"></param>
        /// <param name="server_time"></param>
        public void InsertTempDrugUsageFee(int order_id, int group_id, string order_usage, DateTime server_time,ZY_DOC_ORDERRECORD zy_nurse_orderrecord)
        {
            int orderid = order_id;
            int groupid = group_id;
            string orderusage = order_usage;
            DateTime servertime = server_time;
            string strWhere = "use_name=" + "'" + orderusage + "'";
            DataTable dt = BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_USEAGE_FEE).GetList(strWhere, "item_id", "num");
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() != "")
                    {
                        int item_id = Convert.ToInt32(dt.Rows[i][0].ToString());
                        int num = Convert.ToInt32(dt.Rows[i][1].ToString());
                        Model.ZY_PresOrder presorder = new ZY_PresOrder();
                        //Model.ZY_PresMaster premaster = new ZY_PresMaster();
                       
                        presorder.PatListID =zy_nurse_orderrecord.PATID;
                        presorder.MarkDate =zy_nurse_orderrecord.TRANS_DATE;
                        presorder.PresDate =zy_nurse_orderrecord.ORDER_BDATE;
                        presorder.PresDocCode =zy_nurse_orderrecord.ORDER_DOC.ToString();
                        presorder.PresDeptCode =zy_nurse_orderrecord.PRES_DEPTID.ToString();
                        presorder.ExecDeptCode = zy_nurse_orderrecord.PRES_DEPTID.ToString();////update by heyan 2010.10.8 联动项目的执行科室为开方科室
                        presorder.order_id =zy_nurse_orderrecord.ORDER_ID;
                        presorder.group_id =zy_nurse_orderrecord.GROUP_ID;
                        presorder.order_type = zy_nurse_orderrecord.ORDER_TYPE;                        
                        string frequency_time =zy_nurse_orderrecord.FREQUENCY;                     

                        string strWhere2 = "patlistid=" + presorder.PatListID;
                        string str2 = "patid";
                        presorder.PatID = Convert.ToInt32(BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue(str2, strWhere2));

                        string strWhere3 = "name='" + frequency_time + "'";
                        string str3 = "execnum";                       
                        int execNum;                      
                        if (frequency_time == "1" || frequency_time == "" || frequency_time == null)
                        {
                            execNum = 1;
                        }
                        else
                        {
                            execNum = Convert.ToInt32(BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetFieldValue(str3, strWhere3));
                        }                      
                        string strWhere4 = "server_item_id=" + item_id + " and drug_flag=0";
                        string[] str4 = new string[9];
                        str4[0] = "packunit";
                        str4[1] = "leastunit";
                        str4[2] = "packnum";
                        str4[3] = "buy_price";
                        str4[4] = "sell_price";
                        str4[5] = "standard";
                        str4[6] = "server_item_id";
                        str4[7] = "statitem_code";
                        str4[8] = "ItemName";
                        DataTable dt4 = BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_CLINICAL_ALL_ITEMS).GetList(strWhere4, str4);
                        presorder.PackUnit = dt4.Rows[0]["packunit"].ToString();
                        presorder.Unit = dt4.Rows[0]["leastunit"].ToString();
                        presorder.RelationNum = Convert.ToDecimal(dt4.Rows[0]["packnum"].ToString());
                        presorder.Buy_Price = Convert.ToDecimal(dt4.Rows[0]["buy_price"].ToString());
                        presorder.Sell_Price = Convert.ToDecimal(dt4.Rows[0]["sell_price"].ToString());
                        presorder.Standard = dt4.Rows[0]["standard"].ToString();
                        presorder.PresType = Convert.ToString(4);
                        presorder.ItemID = Convert.ToInt32(dt4.Rows[0]["server_item_id"].ToString());
                        presorder.ItemType = dt4.Rows[0]["statitem_code"].ToString();                    
                        string strWhere6 = "item_id=" + item_id;
                        object obj = BindEntity<BASE_SERVICE_ITEMS>.CreateInstanceDAL(oleDb).GetFieldValue("item_name", strWhere6);
                        presorder.ItemName = obj.ToString();
                        presorder.Amount = execNum * num;
                        presorder.CostDate = servertime;
                        presorder.ChargeCode = Convert.ToString(base.Employeeid);
                        presorder.Charge_Flag = 1;
                        presorder.Drug_Flag = 1;
                        presorder.Tolal_Fee = presorder.Amount * presorder.Sell_Price;
                        presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
                        BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);

                        //premaster.PatListID = presorder.PatListID;
                        //premaster.PatID = presorder.PatID;
                        //premaster.PresType = Convert.ToString(1);
                        //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);

                        //string strWhere5 = "presorderid=" + presorder.PresOrderID;
                        //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
                        //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere5, updatefile);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
