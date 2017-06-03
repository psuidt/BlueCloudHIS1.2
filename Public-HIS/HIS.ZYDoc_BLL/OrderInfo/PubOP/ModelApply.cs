using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZYDoc_BLL.OrderInfo
{
    partial class ModelApply
    {
        public static void ModelDataApply(HIS.Model.zy_doc_orderrecord_son record, HIS.Model.ZY_DOC_ORDERMODELLIST model, int ordertype,int deptid,int order_doc)
        {
            HIS.ZYDoc_BLL.BaseInfo.DrugBase drugbase = new HIS.ZYDoc_BLL.BaseInfo.DrugBase();  
            record.ITEM_TYPE = model.ITEM_TYPE;
            if (model.ITEM_TYPE != 7)
            {
                DataRow dr = drugbase.GetItemDrugInfo(model.ITEM_ID, model.ITEM_TYPE);
                if (dr == null)
                {
                    throw new Exception("找不到'" + model.ITEM_NAME + "' 的内容");
                }

                record.ORDER_CONTENT = dr["itemname"].ToString().Trim();
                record.ORDER_SPEC = HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dr["standard"], ""); ;
                record.ITEM_CODE = HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dr["statitem_code"], "");
                if (Convert.ToInt32(dr["tc_flag"]) == 1)
                {
                    record.TC_ID = Convert.ToInt32(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dr["server_item_id"], "0"));
                }
                else
                {
                    record.TC_ID = 0;
                }
                if (model.ITEM_TYPE > 3)
                {
                    record.EXEC_DEPT = Convert.ToInt32(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dr["EXECDEPTCODE"], "0"));
                }
                else //药品的执行科室取模板的执行科室，因为有多个药房的时候，从视图中去找的也不准
                {
                    record.EXEC_DEPT = model.EXEC_DEPT;
                }
            }
            else
            {
                record.ORDER_CONTENT = model.ITEM_NAME;
                record.TC_ID = 0;
                record.EXEC_DEPT = 0;
            }

            //record.ORDER_CONTENT = model.ITEM_NAME;
            record.ORDER_DOC = order_doc;
            record.AMOUNT = model.AMOUNT;
            record.PRES_AMOUNT =Convert.ToDecimal( Convert.ToInt32( model.PRESAMOUNT));
            if (ordertype == 0)
            {
                record.UNIT = model.doseunit.ToString().Trim();
                record.UNITTYPE = 0;
                if (model.ITEM_TYPE < 3 && model.UNITTYPE != 0) //如果开的不是含量单位，则数量要转换
                {
                    decimal dosenum = drugbase.GetDosePackNum(model.ITEM_ID, model.ITEM_TYPE, 0);
                    decimal packnum = drugbase.GetDosePackNum(model.ITEM_ID, model.ITEM_TYPE, 1);
                    if (model.UNITTYPE == 1) //如果开的是最小单位，则要把数量乘以含量系数
                    {
                        record.AMOUNT = model.AMOUNT * dosenum;
                    }
                    if (model.UNITTYPE == 2) //如果开的是包装单位，则要把数量乘以包装系数和含量系数
                    {
                        record.AMOUNT = model.AMOUNT * packnum * dosenum;
                    }
                }
            }
            else
            {
                record.UNIT = model.UNIT;
                record.UNITTYPE = model.UNITTYPE;
            }
            record.ORDER_STRUC = model.ORDER_STRUC;
            record.FREQUENCY = model.ORDER_FRENQUECY;
            record.ORDER_USAGE = model.ORDER_USAGE;
           // record.EXEC_DEPT = model.EXEC_DEPT;
            record.DROPSPEC = model.DROPSPER;
            record.ORDER_TYPE = ordertype;
            record.STATUS_FALG = -1;
            record.PRES_DEPTID = deptid;
            record.GROUP_ID = -1;
          //  record.TC_ID = model.TC_ID;
          //  record.ITEM_CODE = model.ITEM_CODE;
            record.ORDER_PRICE = drugbase.GetPrice(model.ITEM_ID, model.ITEM_TYPE);
            record.Usage = model.ORDER_USAGE;
            record.Frency = model.ORDER_FRENQUECY;
            record.PresNum = Convert.ToInt32(model.PRESAMOUNT);

            if (model.ORDER_FRENQUECY == "")
            {
                record.FIRSET_TIMES = 1;
                record.First = 1;
            }
            else
            {
                if (ordertype == 0)
                {
                    if (model.ORDER_FRENQUECY == "持续")
                    {
                        string dtime =HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToShortTimeString();
                        decimal hourStr = Convert.ToDecimal(dtime.Replace(":", "."));
                        record.FIRSET_TIMES = Convert.ToInt32(24 - hourStr);
                        record.First = record.FIRSET_TIMES;
                    }
                    else
                    {                      
                        record.FIRSET_TIMES = drugbase.getExecTimes(model.ORDER_FRENQUECY, HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime, 0);
                        record.First = record.FIRSET_TIMES;
                    }
                }
                else
                {
                    record.FIRSET_TIMES = 1;
                    record.First = 1;
                }
            }
        }
      
    }
}
