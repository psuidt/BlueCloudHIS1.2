using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 打印住院统领单
    /// </summary>
    class ZYMultiPrint:YP_Printer
    {
        /// <summary>
        /// 打印住院统领单据
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
            HIS.Model.YP_DispDeptHis printMaster = (HIS.Model.YP_DispDeptHis)billMaster;
            if (billOrder.Rows.Count > 0)
            {
                _printOrder = billOrder;
                report = new grproLib.GridppReport();
                report.LoadFromFile(path);
                report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                report.ParameterByName("DeptName").AsString = BaseData.GetDeptName(printMaster.DeptId.ToString());
                report.ParameterByName("UserName").AsString = BaseData.GetUserName(printMaster.OpMan);
                report.ParameterByName("ExeTime").AsDateTime = printMaster.OpTime;
                report.ParameterByName("DispDept").AsString = BaseData.GetDeptName(printMaster.DispDept.ToString());
                report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName
                    + printMaster.BillType +"统领发药单";
                report.ParameterByName("Printer").AsString = BaseData.GetUserName(Printer);
                report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                report.ParameterByName("PatientNames").AsString = printMaster.PatientNames;
                report.PrintPreview(false);
            }
        }

        public override void PrintReport(YP_PrintCondition printCondition, System.Data.DataTable orderDt, string path)
        {
            throw new NotImplementedException();
        }
    }
}
