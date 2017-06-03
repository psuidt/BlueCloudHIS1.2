using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using HIS.Model;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YZCX_BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class PrintCondition
    {
        public DateTime beginTime;
        public DateTime endTime;
        public int exeDeptId;
        public string exePeoples;
        public int printer;
        public string billNo;
        public Hashtable reportFees = new Hashtable();
    }

    abstract public class YP_Printer : HIS.SYSTEM.Core.BaseBLL
    {
        static protected DataTable _printOrder;
        static protected grproLib.GridppReport report;
        static protected void report_FetchRecord(ref bool Eof)
        {
            GWI_DesReport.HisReport.FillRecordToReport(report, _printOrder);
        }

        static public void PrintTotalInOutStore(string path, PrintCondition condition, DataTable totalOrder)
        {
            _printOrder = totalOrder;
            if (path != "" && totalOrder != null)
            {
                if (totalOrder.Rows.Count <= 0)
                {
                    return;
                }
                else
                {
                    report = new grproLib.GridppReport();
                    report.LoadFromFile(path);
                    report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);

                    report.ParameterByName("开始时间").AsDateTime = condition.beginTime;
                    report.ParameterByName("结束时间").AsDateTime = condition.endTime;
                    if (condition.exeDeptId != 0)
                        report.ParameterByName("统计科室").AsString = BaseData.GetDeptName(condition.exeDeptId.ToString());
                    else
                        report.ParameterByName("统计科室").AsString = "全部库房（含物资与药库）";
                    report.ParameterByName("打印人员").AsString = BaseData.GetUserName(condition.printer);
                    report.ParameterByName("打印时间").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    if (condition.billNo == "0")
                        report.ParameterByName("标题").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName
                            + "入库统计单";
                    else
                        report.ParameterByName("标题").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName
                            + "出库统计单";
                    report.PrintPreview(false);
                }
            }
        }

        static public void PrintCheckReport(string path, PrintCondition condition, DataTable drugInfo)
        {
            try
            {
                _printOrder = drugInfo;
                if (path != "" && drugInfo.Rows.Count > 0)
                {
                    report = new grproLib.GridppReport();
                    report.LoadFromFile(path);
                    report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);

                    report.ParameterByName("审核单号").AsString = condition.billNo;
                    report.ParameterByName("盘点开始时间").AsDateTime = condition.beginTime;
                    report.ParameterByName("盘存库房").AsString = BaseData.GetDeptName(condition.exeDeptId.ToString());
                    report.ParameterByName("盘盈金额").AsString = condition.reportFees["盘盈金额"].ToString();
                    report.ParameterByName("盘亏金额").AsString = condition.reportFees["盘亏金额"].ToString();
                    report.ParameterByName("盘后金额合计").AsString = condition.reportFees["盘存金额"].ToString();
                    report.ParameterByName("盘点结束时间").AsDateTime = condition.endTime;
                    report.ParameterByName("打印人员").AsString = BaseData.GetUserName(condition.printer);
                    report.ParameterByName("审核人员").AsString = condition.exePeoples;
                    report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    report.ParameterByName("打印时间").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    report.PrintPreview(false);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
