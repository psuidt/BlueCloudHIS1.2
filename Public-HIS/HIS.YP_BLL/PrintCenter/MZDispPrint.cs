using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 门诊发药单打印
    /// </summary>
    class MZDispPrint:YP_Printer
    {
        /// <summary>
        /// 打印门诊发药单据
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="billOrder">单据明细</param>
        /// <param name="path">报表文件路径</param>
        /// <param name="Printer">打印人员</param>
        public override void PrintBill(HIS.Model.BillMaster billMaster, System.Data.DataTable billOrder, string path, int Printer)
        {
            try
            {
                if (billMaster == null)
                {
                    return;
                }
                HIS.Model.YP_DRMaster printMaster = (HIS.Model.YP_DRMaster)billMaster;
                billOrder = HIS.YP_BLL.BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE).LoadOrder(billMaster);
                if (billOrder.Rows.Count > 0)
                {
                    _printOrder = billOrder;
                    report = new grproLib.GridppReport();
                    report.LoadFromFile(path);
                    report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                    report.ParameterByName("InvoiceNum").AsString = printMaster.InvoiceNum.ToString();
                    report.ParameterByName("UserName").AsString = BaseData.GetUserName(printMaster.OPPeopleID);
                    report.ParameterByName("ExeTime").AsDateTime = printMaster.OPTime;
                    report.ParameterByName("PatientName").AsString = printMaster.PatientName;
                    report.ParameterByName("HospitalName").AsString = BaseData.WorkName;
                    report.ParameterByName("DocName").AsString = BaseData.GetUserName(printMaster.DocID.ToString());
                    report.ParameterByName("DeptName").AsString = BaseData.GetDeptName(printMaster.DeptID.ToString());
                    report.ParameterByName("RecipeNum").AsString = printMaster.RecipeNum.ToString();
                    report.ParameterByName("RecipeNo").AsString = printMaster.RecipeID.ToString();
                    report.ParameterByName("Printer").AsString = BaseData.GetUserName(Printer);
                    report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
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
