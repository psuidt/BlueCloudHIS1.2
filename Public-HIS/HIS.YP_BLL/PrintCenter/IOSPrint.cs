using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YP_BLL.PrintCenter
{
    class IOSPrint:YP_Printer
    {
        /// <summary>
        /// 打印单据（未实现该方法）
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
        /// 打印进销存报表
        /// </summary>
        /// <param name="printCondition">进销存报表头</param>
        /// <param name="orderDt">进销存报表明细</param>
        /// <param name="path">报表文件路径</param>
        public override void PrintReport(YP_PrintCondition printCondition, System.Data.DataTable orderDt, string path)
        {
            try
            {
                if (orderDt != null && printCondition != null)
                {
                    if (orderDt.Rows.Count > 0)
                    {
                        _printOrder = orderDt;
                        report = new grproLib.GridppReport();
                        report.LoadFromFile(path);
                        report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                        report.ParameterByName("AccountYear").AsString = printCondition.actYear;
                        report.ParameterByName("AccountMonth").AsString = printCondition.actMonth;
                        report.ParameterByName("DrugType").AsString = printCondition.drugType;
                        report.ParameterByName("RegPeople").AsString = BaseData.GetUserName(printCondition.userId.ToString());
                        report.ParameterByName("RegDept").AsString = BaseData.GetDeptName(printCondition.deptId.ToString());
                        report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                        report.PrintPreview(false);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
