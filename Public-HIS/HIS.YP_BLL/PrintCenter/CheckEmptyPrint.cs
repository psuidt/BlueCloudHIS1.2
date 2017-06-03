using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 空盘点单打印
    /// </summary>
    class CheckEmptyPrint:YP_Printer
    {
        /// <summary>
        /// 打印空盘点单据
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
            HIS.Model.YP_CheckMaster checkMaster = (HIS.Model.YP_CheckMaster)billMaster;
            if (billOrder.Rows.Count > 0)
            {
                _printOrder = billOrder;
                report = new grproLib.GridppReport();
                report.LoadFromFile(path);
                report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                report.ParameterByName("CheckDate").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                report.ParameterByName("RegPeople").AsString = BaseData.GetUserName(checkMaster.RegPeopleID);
                report.ParameterByName("RegDept").AsString = BaseData.GetDeptName(checkMaster.DeptID.ToString());
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
