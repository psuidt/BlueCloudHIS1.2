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
    partial class TestApply : MediCenter
    {
        grproLib.GridppReport report;   
        ApplyDao apply;
        public TestApply()
        {
            apply = new ApplyDao();
            apply.class_type = 1;
            apply.meditype = MediType.检验;
        }
        /// <summary>
        /// 获得科室
        /// </summary>
        /// <param name="meditype"></param>
        /// <returns></returns>
      public   override DataTable GetDept()
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
      public   override DataTable GetItems(int deptId, int medicalClass)
        {
            return apply.GetItems(deptId, medicalClass);
        }

        /// <summary>
        /// 查询一段时间的申请报告
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="meditype"></param>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        /// <returns></returns>
       public  override DataTable GetOrders(int patlistid, DateTime? Bdate, DateTime? Edate)
        {           
            return apply.GetOrders(patlistid, Bdate, Edate);
        }
       

        
        /// <summary>
        /// 提交检验申请
        /// </summary>
        /// <param name="records"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <returns></returns>
       public override  bool Save(List<HIS.Model.ZY_DOC_ORDERRECORD> records, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_TESTAPPLY> applys)
        {
            oleDb.BeginTransaction();
            try
            {
                for (int i = 0; i < records.Count; i++)
                {
                    records[i].PATID = patlist.PatListID;
                    records[i].BABYID = 0;
                    records[i].PAT_DEPTID = Convert.ToInt32(patlist.CurrDeptCode);
                    records[i].GROUP_ID = PubMethd.GetGroupMax(patlist.PatListID, 1);
                    records[i].ORDER_TYPE = 1;
                    records[i].ITEM_TYPE = 5;
                    records[i].STATUS_FALG = 0;
                    records[i].AMOUNT = 1;
                    records[i].PRES_AMOUNT = 1;
                    records[i].ORECORD_A2 = 1;
                    BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Add(records[i]);
                }
                for (int i = 0; i < applys.Count; i++)
                {
                    applys[i].ORDER_CONTENT = records[i].ORDER_CONTENT;                 
                    applys[i].AMOUNT = 1;
                    applys[i].MEMO = records[i].MEMO;
                    applys[i].SERVERS_ID = records[i].SEVERS_ID;
                    applys[i].TC_ID = records[i].TC_ID;
                    applys[i].PATID = patlist.PatListID;
                    applys[i].BABY_ID = 0;
                    BindEntity<HIS.Model.ZY_DOC_TESTAPPLY>.CreateInstanceDAL(oleDb).Add(applys[i]);
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
       public override bool Save(List<HIS.Model.ZY_DOC_ORDERRECORD> orders, HIS.Model.ZY_PatList patlist) { return true; }

       public override void Print(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string state, string palce, string deptname, string tjjg, string Xjg, string hyjg, string othercheck) { }
       public override void Print(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string state) { }

       public  override  void Print(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string sample, string deptname, string diagname)
        {
            if (path != "" && applys.Count > 0)
            {
                string itemname = applys[0].ORDER_CONTENT.ToString();
                decimal price = applys[0].ORDER_PRICE;
                for (int i = 1; i < applys.Count; i++)
                {
                    itemname = itemname + ", " + applys[i].ORDER_CONTENT.ToString();
                    price = price + applys[i].ORDER_PRICE;
                }
                report = new grproLib.GridppReport();
                report.LoadFromFile(path);
                report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                report.ParameterByName("打印人").AsString = name;
                report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                report.ParameterByName("住院号").AsString = patlist.CureNo;
                report.ParameterByName("病人姓名").AsString = patlist.PatientInfo.PatName;
                report.ParameterByName("病人性别").AsString = patlist.PatientInfo.PatSex;
                string age = HIS.SYSTEM.PubicBaseClasses.Age.GetAgeString(patlist.PatientInfo.PatBriDate, XcDate.ServerDateTime, 1);
                report.ParameterByName("病人年龄").AsString = age;
                string[] strdiag = patlist.DiseaseName.Split(new char[] { '|' });
                if (strdiag[0] == "")
                {
                    report.ParameterByName("诊断").AsString = strdiag[1].Replace("\r\n", "");
                }
                else
                {
                    report.ParameterByName("诊断").AsString = strdiag[0].Replace("\r\n", "");
                }
                report.ParameterByName("申请时间").AsString = dtime.ToString();
                report.ParameterByName("申请科室").AsString = deptname;
                report.ParameterByName("Purpose").AsString = itemname;
                report.ParameterByName("床号").AsString = patlist.BedCode;
                report.ParameterByName("项目金额").AsString = price.ToString() + " 元";
                report.ParameterByName("标本").AsString = sample;
                report.ParameterByName("申请医生").AsString = name;
                report.PrintPreview(false);
            }
        }
      protected void report_FetchRecord(ref bool Eof)
        {
            GWI_DesReport.HisReport.FillRecordToReport(report, "");
        }

      public override  bool DelApply(HIS.Model.ZY_DOC_ORDERRECORD record)
      {
          oleDb.BeginTransaction();
          try
          {
              record.DELETE_FLAG = 1;
              BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(record);
              string strWhere = Tables.zy_doc_testapply.PATID + oleDb.EuqalTo() + record.PATID + oleDb.And() + Tables.zy_doc_testapply.GROUP_ID + oleDb.EuqalTo() + record.GROUP_ID + oleDb.And() + Tables.zy_doc_testapply.DELETE_FLAG + oleDb.EuqalTo() + 0;
              HIS.Model.ZY_DOC_TESTAPPLY check = BindEntity<HIS.Model.ZY_DOC_TESTAPPLY>.CreateInstanceDAL(oleDb).GetModel(strWhere);
              if (check != null)
              {
                  check.DELETE_FLAG = 1;
                  BindEntity<HIS.Model.ZY_DOC_TESTAPPLY>.CreateInstanceDAL(oleDb).Update(check);
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
    }
}
