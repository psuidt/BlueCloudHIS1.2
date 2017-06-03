using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 住院退药单打印
    /// </summary>
    class ZYRefundPint:YP_Printer
    {
        /// <summary>
        /// 打印住院退药单据
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="billOrder">单据明细</param>
        /// <param name="path">报表文件路径</param>
        /// <param name="Printer">打印人员</param>
        public override void PrintBill(HIS.Model.BillMaster billMaster, System.Data.DataTable billOrder, string path, int Printer)
        {
            if (billMaster == null)
            {
                return;
            }
            _printOrder = BillFactory.GetQuery(ConfigManager.OP_YF_REFUND).LoadOrder(billMaster);
            if (_printOrder.Rows.Count > 0)
            {
                HIS.Model.YP_DRMaster printMaster = (HIS.Model.YP_DRMaster)billMaster;
                report = new grproLib.GridppReport();
                report.LoadFromFile(path);
                report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                report.ParameterByName("InpatientNo").AsString = printMaster.InpatientID;
                report.ParameterByName("UserName").AsString = BaseData.GetUserName(printMaster.OPPeopleID);
                report.ParameterByName("ExeTime").AsDateTime = printMaster.OPTime;
                report.ParameterByName("PatientName").AsString = printMaster.PatientName;
                report.ParameterByName("HospitalName").AsString = BaseData.WorkName;
                report.ParameterByName("Printer").AsString = BaseData.GetUserName(Printer);
                report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                report.PrintPreview(false);
            }
        }

        public override void PrintReport(YP_PrintCondition printCondition, System.Data.DataTable orderDt, string path)
        {
            throw new NotImplementedException();
        }
    }
}
