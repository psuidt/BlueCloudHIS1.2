using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 调价单打印类
    /// </summary>
    class AdjPricePrint:YP_Printer
    {
        /// <summary>
        /// 打印调价单
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="billOrder">单据明细</param>
        /// <param name="path">报表文件路径</param>
        /// <param name="Printer">打印人员</param>
        public override void PrintBill(HIS.Model.BillMaster billMaster, System.Data.DataTable billOrder, string path, int Printer)
        {
            if (billMaster == null || billOrder == null)
            {
                return;
            }
            HIS.Model.YP_AdjMaster printMaster = (HIS.Model.YP_AdjMaster)billMaster;          
            if (billOrder.Rows.Count > 0)
            {
                _printOrder = billOrder;
                report = new grproLib.GridppReport();
                report.LoadFromFile(path);
                report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                report.ParameterByName("BillNo").AsString = printMaster.BillNum.ToString();
                report.ParameterByName("AdjCode").AsString = printMaster.AdjCode;
                report.ParameterByName("BillDate").AsDateTime = printMaster.RegTime;
                report.ParameterByName("Remark").AsString = printMaster.Remark;
                report.ParameterByName("RegPeople").AsString =  BaseData.GetUserName(printMaster.RegPeople);
                report.ParameterByName("RegDept").AsString = BaseData.GetDeptName(printMaster.DeptID.ToString());
                report.ParameterByName("HospitalName").AsString = BaseData.WorkName;
                report.ParameterByName("Printer").AsString = BaseData.GetUserName(Printer);
                report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                report.PrintPreview(false);
            }
        }

        /// <summary>
        /// 打印其他报表（除单据外）
        /// </summary>
        /// <param name="printCondition">报表头</param>
        /// <param name="orderDt">报表明细</param>
        /// <param name="path">报表文件路径</param>
        public override void PrintReport(YP_PrintCondition printCondition, System.Data.DataTable orderDt, string path)
        {
            throw new NotImplementedException();
        }
    }
}
