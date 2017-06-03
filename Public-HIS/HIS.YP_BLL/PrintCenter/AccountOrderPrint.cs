using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 药品明细帐打印类
    /// </summary>
    class AccountOrderPrint:YP_Printer
    {
        /// <summary>
        /// 打印单据
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="billOrder">单据明细</param>
        /// <param name="path">报表文件路径</param>
        /// <param name="Printer">打印人员</param>
        public override void PrintBill(HIS.Model.BillMaster billMaster, System.Data.DataTable billOrder, string path, int Printer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 打印明细账报表
        /// </summary>
        /// <param name="printCondition">报表头</param>
        /// <param name="orderDt">报表明细</param>
        /// <param name="path">报表文件路径</param>
        public override void PrintReport(YP_PrintCondition printCondition, System.Data.DataTable orderDt, string path)
        {
            if (printCondition == null || orderDt == null)
            {
                return;
            }
            YP_AccountCondition actCondition = (YP_AccountCondition)printCondition;
            if (orderDt.Rows.Count > 0)
            {
                _printOrder = orderDt;
                report = new grproLib.GridppReport();
                report.LoadFromFile(path);
                report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                report.ParameterByName("AccountYear").AsString = actCondition.actYear;
                report.ParameterByName("AccountMonth").AsString = actCondition.actMonth;
                report.ParameterByName("DrugName").AsString = actCondition.drugName;
                report.ParameterByName("ProductName").AsString = actCondition.productName;
                report.ParameterByName("BeginNum").AsString = actCondition.beginNum;
                report.ParameterByName("BeginFee").AsString = actCondition.begingFee;
                report.ParameterByName("EndNum").AsString = actCondition.endNum;
                report.ParameterByName("EndFee").AsString = actCondition.endFee;
                report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                report.PrintPreview(false);
            }
        }
    }
}
