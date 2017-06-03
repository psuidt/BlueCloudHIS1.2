using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 采购计划打印类
    /// </summary>
    class StockPlanPrint : YP_Printer
    {
        /// <summary>
        /// 打印采购计划单
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="billOrder">单据明细</param>
        /// <param name="path">报表文件路径</param>
        /// <param name="Printer">打印人员</param>
        public override void PrintBill(HIS.Model.BillMaster billMaster, System.Data.DataTable billOrder, string path, int Printer)
        {
            try
            {
                HIS.Model.YP_PlanMaster printMaster = (HIS.Model.YP_PlanMaster)billMaster;
                _printOrder = BillFactory.GetQuery(ConfigManager.OP_YK_STOCKPLAN).LoadOrder(printMaster);
                if (printMaster != null && _printOrder.Rows.Count > 0)
                {
                    report = new grproLib.GridppReport();
                    report.LoadFromFile(path);
                    report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                    report.ParameterByName("RegTime").AsDateTime = printMaster.RegTime;
                    report.ParameterByName("RegPeopleName").AsString = printMaster.RegPeopleName;
                    report.ParameterByName("TotalRetailFee").AsString = printMaster.RetailFee.ToString();
                    report.ParameterByName("TotalTradeFee").AsString = printMaster.TradeFee.ToString();
                    report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    report.ParameterByName("Printer").AsString = BaseData.GetUserName(Printer);
                    report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    report.ParameterByName("DiffFee").AsString = (printMaster.RetailFee - printMaster.TradeFee).ToString();
                    report.PrintPreview(false);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override void PrintReport(YP_PrintCondition printCondition, System.Data.DataTable orderDt, string path)
        {
            throw new NotImplementedException();
        }
    }
}
