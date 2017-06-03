using System;
using System.Collections.Generic;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYNurse_BLL
{
    public class OP_SendDrugMessage:BaseBLL
    {
        /// <summary>
        /// 发药消息主表
        /// </summary>
        /// <param name="sendtime"></param>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int InsertDrugMaster(DateTime sendtime,long userid,string name,string presdept,string execdept)
        {
            Model.ZY_DRUGMESSAGE_MASTER zy_drugMessageMaster = new HIS.Model.ZY_DRUGMESSAGE_MASTER();
            zy_drugMessageMaster.SENDTIME =sendtime;
            zy_drugMessageMaster.SENDER = Convert.ToInt32(userid);
            zy_drugMessageMaster.DR_FLAG =1;
            zy_drugMessageMaster.SENDERNAME = name;
            zy_drugMessageMaster.MESSAGETYPE = 0;
            zy_drugMessageMaster.PRESDEPTID = Convert.ToInt32(presdept);
            zy_drugMessageMaster.DISPDEPT = Convert.ToInt32(execdept);
            BindEntity<ZY_DRUGMESSAGE_MASTER>.CreateInstanceDAL(oleDb).Add(zy_drugMessageMaster);
            object obj=BindEntity<ZY_DRUGMESSAGE_MASTER>.CreateInstanceDAL(oleDb).GetFieldValue("max(drugmessageid)", "1=1");
            return int.Parse(obj.ToString());
       }
        /// <summary>
        /// 发药消息明细
        /// </summary>
        /// <param name="presorderid"></param>
        /// <param name="masterid"></param>
        public void InsertDrugMessageRecord(int presorderid,int masterid)
        {
            Model.ZY_DRUGMESSAGE_MASTER zyDurgMessageMaster = new ZY_DRUGMESSAGE_MASTER();
            Model.ZY_PresOrder zyPresOrder = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetModel(presorderid);
            Model.ZY_PatList zyPatlist = BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(zyPresOrder.PatListID);
            Model.YP_MakerDic makerdic = BindEntity<YP_MakerDic>.CreateInstanceDAL(oleDb).GetModel(zyPresOrder.ItemID);

            Model.YP_ProductDic productdic = BindEntity<YP_ProductDic>.CreateInstanceDAL(oleDb).GetModel(makerdic.ProductID);
            Model.ZY_DRUGMESSAGE_ORDER zy_drugMessageOrder = new ZY_DRUGMESSAGE_ORDER();
            zy_drugMessageOrder.MASTERID = masterid;            
            zy_drugMessageOrder.MAKERDICID = zyPresOrder.ItemID;
            zy_drugMessageOrder.CHEMNAME = zyPresOrder.ItemName;
            zy_drugMessageOrder.SPEC = zyPresOrder.Standard;
            zy_drugMessageOrder.DRUGNUM = zyPresOrder.Amount;
            zy_drugMessageOrder.CUREDEPT = Convert.ToInt32(zyPresOrder.PresDeptCode);
            zy_drugMessageOrder.CUREDOC = Convert.ToInt32(zyPresOrder.PresDocCode);
            zy_drugMessageOrder.CURENO = zyPatlist.CureNo;
            zy_drugMessageOrder.PATNAME = zyPatlist.PatientInfo.PatName;
            zy_drugMessageOrder.BEDNO = zyPatlist.BedCode;
            zy_drugMessageOrder.PATID = zyPresOrder.PatListID;
            zy_drugMessageOrder.UNITNAME = zyPresOrder.Unit;
            zy_drugMessageOrder.TRADEPRICE = zyPresOrder.Buy_Price;
            zy_drugMessageOrder.RETAILPRICE = zyPresOrder.Sell_Price;
            zy_drugMessageOrder.UNITNUM = Convert.ToInt32(zyPresOrder.RelationNum);
            zy_drugMessageOrder.ORDERRECIPEID = presorderid;
            zy_drugMessageOrder.CHARGEMAN =Convert.ToInt32(zyPresOrder.ChargeCode);
            zy_drugMessageOrder.CHARGEDATE = zyPresOrder.CostDate;
            zy_drugMessageOrder.ORDERGROUP_ID = zyPresOrder.group_id;
            zy_drugMessageOrder.DOCORDERTYPE = zyPresOrder.order_type;
            zy_drugMessageOrder.DOCORDERID = zyPresOrder.order_id;
            zy_drugMessageOrder.SPECDICID = makerdic.SpecDicID;// add 2010-09-19 zenghao
            zy_drugMessageOrder.PRODUCTNAME = productdic.ProductName;// add 2010-09-19 zenghao
            BindEntity<ZY_DRUGMESSAGE_ORDER>.CreateInstanceDAL(oleDb).Add(zy_drugMessageOrder);

            //object obj = BindEntity<ZY_DRUGMESSAGE_ORDER>.CreateInstanceDAL(oleDb).GetFieldValue("max(drugmessageid)", "1=1");           
            

            //string strwhere2 = "drugmessageid=" + int.Parse(obj.ToString());
            //string updatefield = Tables.zy_drugmessage_order.SPECDICID+oleDb.EuqalTo()+ makerdic.SpecDicID;
            //BindEntity<HIS.Model.ZY_DRUGMESSAGE_ORDER>.CreateInstanceDAL(oleDb).Update(strwhere2, updatefield);

            
            //string strWhere = "drugmessageid=" + masterid;
            //string updatefiled1 = Tables.zy_drugmessage_master.PRESDEPTID + oleDb.EuqalTo() +Convert.ToInt32(zyPresOrder.PresDeptCode);
            //string updatefiled2 = Tables.zy_drugmessage_master.DISPDEPT + oleDb.EuqalTo() + Convert.ToInt32(zyPresOrder.ExecDeptCode);
            //BindEntity<HIS.Model.ZY_DRUGMESSAGE_MASTER>.CreateInstanceDAL(oleDb).Update(strWhere, updatefiled1,updatefiled2);
            
            return;
        }
        /// <summary>
        /// 退药消息主表
        /// </summary>
        /// <param name="sendtime"></param>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int InsertDBDrugMaster(DateTime sendtime, long userid, string name, string presdept, string execdept)
        {
            Model.ZY_DRUGMESSAGE_MASTER zy_drugMessageMaster = new HIS.Model.ZY_DRUGMESSAGE_MASTER();
            zy_drugMessageMaster.SENDTIME = sendtime;
            zy_drugMessageMaster.SENDER = Convert.ToInt32(userid);
            zy_drugMessageMaster.DR_FLAG =0;
            zy_drugMessageMaster.SENDERNAME = name;
            zy_drugMessageMaster.MESSAGETYPE = 0;
            zy_drugMessageMaster.PRESDEPTID = Convert.ToInt32(presdept);
            zy_drugMessageMaster.DISPDEPT = Convert.ToInt32(execdept);
            BindEntity<ZY_DRUGMESSAGE_MASTER>.CreateInstanceDAL(oleDb).Add(zy_drugMessageMaster);
            object obj = BindEntity<ZY_DRUGMESSAGE_MASTER>.CreateInstanceDAL(oleDb).GetFieldValue("max(drugmessageid)", "1=1");
            return int.Parse(obj.ToString());
        }
        /// <summary>
        /// 退药消息明细
        /// </summary>
        /// <param name="presorderid"></param>
        /// <param name="masterid"></param>
        public void InsertDBDrugMessageRecord(int presorderid, int masterid)
        {
            Model.ZY_DRUGMESSAGE_MASTER zyDurgMessageMaster = new ZY_DRUGMESSAGE_MASTER();
            Model.ZY_PresOrder zyPresOrder = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetModel(presorderid);
            Model.ZY_PatList zyPatlist = BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(zyPresOrder.PatListID);

            Model.YP_MakerDic makerdic = BindEntity<YP_MakerDic>.CreateInstanceDAL(oleDb).GetModel(zyPresOrder.ItemID);
            Model.YP_ProductDic productdic = BindEntity<YP_ProductDic>.CreateInstanceDAL(oleDb).GetModel(makerdic.ProductID);


            Model.ZY_DRUGMESSAGE_ORDER zy_drugMessageOrder = new ZY_DRUGMESSAGE_ORDER();
            zy_drugMessageOrder.MASTERID = masterid;
            zy_drugMessageOrder.MAKERDICID = zyPresOrder.ItemID;
            zy_drugMessageOrder.CHEMNAME = zyPresOrder.ItemName;
            zy_drugMessageOrder.SPEC = zyPresOrder.Standard;
            zy_drugMessageOrder.DRUGNUM = zyPresOrder.Amount;
            zy_drugMessageOrder.CUREDEPT = Convert.ToInt32(zyPresOrder.PresDeptCode);
            zy_drugMessageOrder.CUREDOC = Convert.ToInt32(zyPresOrder.PresDocCode);
            zy_drugMessageOrder.CURENO = zyPatlist.CureNo;
            zy_drugMessageOrder.BEDNO = zyPatlist.BedCode;
            zy_drugMessageOrder.PATID = zyPresOrder.PatListID;
            zy_drugMessageOrder.UNITNAME = zyPresOrder.Unit;
            zy_drugMessageOrder.TRADEPRICE = zyPresOrder.Buy_Price;
            zy_drugMessageOrder.RETAILPRICE = zyPresOrder.Sell_Price;
            zy_drugMessageOrder.PATNAME = zyPatlist.PatientInfo.PatName;
            zy_drugMessageOrder.UNITNUM = Convert.ToInt32(zyPresOrder.RelationNum);
            zy_drugMessageOrder.ORDERRECIPEID = presorderid;
            zy_drugMessageOrder.CHARGEMAN = Convert.ToInt32(zyPresOrder.ChargeCode);
            zy_drugMessageOrder.CHARGEDATE = zyPresOrder.CostDate;
            zy_drugMessageOrder.ORDERGROUP_ID = zyPresOrder.group_id;
            zy_drugMessageOrder.DOCORDERTYPE = zyPresOrder.order_type;
            zy_drugMessageOrder.DOCORDERID = zyPresOrder.order_id;

            zy_drugMessageOrder.SPECDICID = makerdic.SpecDicID;// add 2010-09-19 zenghao
            zy_drugMessageOrder.PRODUCTNAME = productdic.ProductName;// add 2010-09-19 zenghao

            BindEntity<ZY_DRUGMESSAGE_ORDER>.CreateInstanceDAL(oleDb).Add(zy_drugMessageOrder);

            //object obj = BindEntity<ZY_DRUGMESSAGE_ORDER>.CreateInstanceDAL(oleDb).GetFieldValue("max(drugmessageid)", "1=1");            
            //Model.YP_MakerDic makerdic = BindEntity<YP_MakerDic>.CreateInstanceDAL(oleDb).GetModel(zyPresOrder.ItemID);
            //string strwhere2 = "drugmessageid=" + int.Parse(obj.ToString());
            //string updatefield = Tables.zy_drugmessage_order.SPECDICID + oleDb.EuqalTo()+makerdic.SpecDicID;
            //BindEntity<HIS.Model.ZY_DRUGMESSAGE_ORDER>.CreateInstanceDAL(oleDb).Update(strwhere2, updatefield);           
            
            //string strWhere = "drugmessageid=" + masterid;
            //string updatefiled1 = Tables.zy_drugmessage_master.PRESDEPTID + oleDb.EuqalTo() + Convert.ToInt32(zyPresOrder.PresDeptCode);
            //string updatefiled2 = Tables.zy_drugmessage_master.DISPDEPT + oleDb.EuqalTo() + Convert.ToInt32(zyPresOrder.ExecDeptCode);
            //BindEntity<HIS.Model.ZY_DRUGMESSAGE_MASTER>.CreateInstanceDAL(oleDb).Update(strWhere, updatefiled1, updatefiled2);
            return;
        }
    }
}
