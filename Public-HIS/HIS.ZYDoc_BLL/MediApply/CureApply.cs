using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYDoc_BLL.MediApply
{
   partial class CureApply:MediCenter
    {
       protected grproLib.GridppReport report;    
       ApplyDao apply;
       public CureApply()
       {
           apply = new ApplyDao();          
           apply.meditype = MediType.治疗;
       }
        /// <summary>
        /// 获得科室
        /// </summary>
        /// <param name="meditype"></param>
        /// <returns></returns>
      public  override DataTable GetDept()
       {

           return apply.GetDept();
       }

        /// <summary>
        /// 获得类型
        /// </summary>
        /// <param name="meditype"></param>
        /// <returns></returns>
      public override DataTable GetMediType()
       {
           return apply.GetMediType();
       }

        /// <summary>
        /// 获得相应类型的项目名称
        /// </summary>
        /// <param name="meditype"></param>
        /// <param name="deptId"></param>
        /// <param name="medicalClass"></param>
        /// <returns></returns>
      public override DataTable GetItems(int deptId, int medicalClass)
       {
           return apply.GetItems(deptId,medicalClass);
       }

        /// <summary>
        /// 查询一段时间的申请报告
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="meditype"></param>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        /// <returns></returns>
      public  override DataTable GetOrders(int patlistid,DateTime? Bdate, DateTime? Edate)
       {
           return apply.GetOrders(patlistid,Bdate,Edate);
       }    
       

        /// <summary>
        /// 提交治疗申请
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="patlist"></param>
        /// <returns></returns>
     public override  bool Save(List<HIS.Model.ZY_DOC_ORDERRECORD> orders, HIS.Model.ZY_PatList patlist)
       {
           try
           {
               oleDb.BeginTransaction();
               for (int i = 0; i < orders.Count; i++)
               {
                   orders[i].PATID = patlist.PatListID;
                   orders[i].BABYID = 0;
                   orders[i].PAT_DEPTID = Convert.ToInt32(patlist.CurrDeptCode);                
                   orders[i].GROUP_ID = PubMethd.GetGroupMax(patlist.PatListID, 1);
                   orders[i].ORDER_TYPE = 1;
                   orders[i].ITEM_TYPE = 4;                 
                   orders[i].FIRSET_TIMES = 0;              
                   orders[i].STATUS_FALG = 0;                
                   orders[i].PRES_AMOUNT = 1;
                   orders[i].ORECORD_A2 = 1;
                   BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Add(orders[i]);
               }
               oleDb.CommitTransaction();
               return true;
           }
           catch (System.Exception e)
           {
               oleDb.RollbackTransaction();
               throw new Exception(e.Message);
           }
       }
     public override bool Save(List<HIS.Model.ZY_DOC_ORDERRECORD> records, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_CHECKAPPLY> applys) { return true; }

     public override bool Save(List<HIS.Model.ZY_DOC_ORDERRECORD> records, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_TESTAPPLY> applys) { return true; }
     public override void Print(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string state, string palce, string deptname, string tjjg, string Xjg, string hyjg, string othercheck) { }
     public override void Print(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string sample, string deptname, string diagname) { }
     public override void Print(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string state)
       {
           if (path != "" && applys.Count > 0)
           {
               for (int i = 0; i < applys.Count; i++)
               {
                   report = new grproLib.GridppReport();
                   report.LoadFromFile(path);
                   report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                   report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                   report.ParameterByName("cureno").AsString = patlist.CureNo;
                   report.ParameterByName("patname").AsString = patlist.PatientInfo.PatName;
                   report.ParameterByName("patsex").AsString = patlist.PatientInfo.PatSex;
                   report.ParameterByName("bedcode").AsString = patlist.BedCode;
                   string[] strdiag = patlist.DiseaseName.Split(new char[] { '|' });
                   if (strdiag[0] == "")
                   {
                       report.ParameterByName("diag").AsString = strdiag[1].Replace("\r\n", "");
                   }
                   else
                   {
                       report.ParameterByName("diag").AsString = strdiag[0].Replace("\r\n", "");
                   }
                   report.ParameterByName("applydate").AsString = dtime.ToString();
                   report.ParameterByName("state").AsString = state;
                   report.ParameterByName("items").AsString = applys[i].ORDER_CONTENT;
                   report.ParameterByName("price").AsString = applys[i].ORDER_PRICE.ToString() + " 元";
                   report.ParameterByName("nums").AsString = applys[i].AMOUNT.ToString();
                   report.ParameterByName("totalprice").AsString = (Convert.ToDecimal(applys[i].ORDER_PRICE.ToString()) * Convert.ToDecimal(applys[i].AMOUNT.ToString())).ToString() + "元";
                   report.ParameterByName("presdoc").AsString = name;
                   string age = HIS.SYSTEM.PubicBaseClasses.Age.GetAgeString(patlist.PatientInfo.PatBriDate, XcDate.ServerDateTime, 1);
                   report.ParameterByName("patage").AsString = age;
                   report.PrintPreview(false);
               }
           }
       }
      protected void report_FetchRecord(ref bool Eof)
       {
           GWI_DesReport.HisReport.FillRecordToReport(report, "");
       }
      public override bool DelApply(HIS.Model.ZY_DOC_ORDERRECORD record) { return true; }
    }
}
