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
    public class AbstractItem:AbstractOrderOperation
    {
        public override void Send(int orderid, DateTime servertime, ZY_DOC_ORDERRECORD zy_doc_orderrecord, List<int> grouplist)
        { 
        }
        public virtual void InsertItemFee(int order_id, DateTime server_datetime, ZY_DOC_ORDERRECORD zy_doc_orderrecord)
        {
        }
        public virtual void InsertComponentItemFee(int order_id, int item_id,DateTime server_datetime, ZY_DOC_ORDERRECORD zy_doc_orderrecord)
        {
        }
        /// <summary>
        /// 长期项目用法联动费用
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="group_id"></param>
        /// <param name="order_usage"></param>
        /// <param name="server_time"></param>
        /// <param name="zy_nurse_orderrecord"></param>
        public void InsertDrugUsageFee(int order_id, int group_id, string order_usage, DateTime server_time, ZY_DOC_ORDERRECORD zy_nurse_orderrecord)
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

                        presorder.PatListID = zy_nurse_orderrecord.PATID;
                        presorder.MarkDate = zy_nurse_orderrecord.TRANS_DATE;
                        presorder.PresDate = zy_nurse_orderrecord.ORDER_BDATE;
                        presorder.PresDocCode = zy_nurse_orderrecord.ORDER_DOC.ToString();
                        presorder.PresDeptCode = zy_nurse_orderrecord.PRES_DEPTID.ToString();
                        presorder.ExecDeptCode = zy_nurse_orderrecord.PRES_DEPTID.ToString();//联动的费用执行科室取开方科室 update by heyan
                        presorder.order_id = zy_nurse_orderrecord.ORDER_ID;
                        presorder.group_id = zy_nurse_orderrecord.GROUP_ID;
                        presorder.order_type = zy_nurse_orderrecord.ORDER_TYPE;
                        DateTime order_bdate = zy_nurse_orderrecord.ORDER_BDATE;
                        DateTime order_edate = zy_nurse_orderrecord.EORDER_DATE;
                        string frequency_time = zy_nurse_orderrecord.FREQUENCY;
                        int firset_times = zy_nurse_orderrecord.FIRSET_TIMES;
                        int teminal_times = Convert.ToInt32(XcConvert.IsNull(zy_nurse_orderrecord.TEMINAL_TIMES, "0"));
                        DateTime currenttime = servertime;
                        string strWhere2 = "patlistid=" + presorder.PatListID;
                        string str2 = "patid";
                        presorder.PatID = Convert.ToInt32(BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue(str2, strWhere2));
                        string strWhere3 = "name='" + frequency_time + "'";
                        string str3 = "execnum";
                        int execNum;
                        if (currenttime.ToString("yyyy-MM-dd") == order_bdate.ToString("yyyy-MM-dd") && currenttime.ToString("yyyy-MM-dd") == order_edate.ToString("yyyy-MM-dd"))//11月22日加，解决如果长嘱当天开，当天停，以末次计数
                        {
                            execNum = teminal_times;
                        }
                        else if (currenttime.ToString("yyyy-MM-dd") == order_bdate.ToString("yyyy-MM-dd"))
                        {
                            execNum = firset_times;
                        }
                        else if (currenttime.ToString("yyyy-MM-dd") == order_edate.ToString("yyyy-MM-dd"))
                        {
                            execNum = teminal_times;
                        }
                        else
                        {
                            if (frequency_time == "1" || frequency_time == "" || frequency_time == null)
                            {
                                execNum = 1;
                            }
                            else
                            {
                                execNum = Convert.ToInt32(BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetFieldValue(str3, strWhere3));
                            }
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
        /// <summary>
        /// 临时项目用法联动费用
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="group_id"></param>
        /// <param name="order_usage"></param>
        /// <param name="server_time"></param>
        public void InsertTempDrugUsageFee(int order_id, int group_id, string order_usage, DateTime server_time, ZY_DOC_ORDERRECORD zy_nurse_orderrecord)
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

                        presorder.PatListID = zy_nurse_orderrecord.PATID;
                        presorder.MarkDate = zy_nurse_orderrecord.TRANS_DATE;
                        presorder.PresDate = zy_nurse_orderrecord.ORDER_BDATE;
                        presorder.PresDocCode = zy_nurse_orderrecord.ORDER_DOC.ToString();
                        presorder.PresDeptCode = zy_nurse_orderrecord.PRES_DEPTID.ToString();
                        presorder.ExecDeptCode = zy_nurse_orderrecord.PRES_DEPTID.ToString();//联动的费用执行科室取开方科室 update by heyan
                        presorder.order_id = zy_nurse_orderrecord.ORDER_ID;
                        presorder.group_id = zy_nurse_orderrecord.GROUP_ID;
                        presorder.order_type = zy_nurse_orderrecord.ORDER_TYPE;
                        string frequency_time = zy_nurse_orderrecord.FREQUENCY;

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
        
        public DataTable TcgetOrderItem(int tcid)
        {
            string sql = " select a.*,b.num as num from ( select * from  base_complex_detail b where b.complex_id=" + tcid + " and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + ") b left join vi_clinical_order a on b.service_item_id=a.item_id and b.workid=a.workid";
            return oleDb.GetDataTable(sql);
        }
    }
}
