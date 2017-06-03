using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 入库单打印类
    /// </summary>
    class InStorePrint:YP_Printer
    {
        /// <summary>
        /// 打印入库单据
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="billOrder">单据明细</param>
        /// <param name="path">报表文件路径</param>
        /// <param name="Printer">打印人员</param>
        public override void PrintBill(HIS.Model.BillMaster billMaster, System.Data.DataTable billOrder, string path, int Printer)
        {
            try
            {
                string billType = "";
                HIS.Model.YP_InMaster printMaster = (HIS.Model.YP_InMaster)billMaster;
                DataTable dtt = billOrder.Clone();
                DataRow[] datarows;
                datarows = billOrder.Select("");
                foreach (DataRow dr in datarows)
                {
                    dtt.Rows.Add(dr.ItemArray);
                }
                DataColumn dc = null;
                dc = dtt.Columns.Add("OVERNUM", Type.GetType("System.String")); //  增加结余数 zhangyunhui 5.8
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    dtt.Rows[i]["OVERNUM"] = Getovernumber(Convert.ToInt32(dtt.Rows[i]["INSTORAGEID"].ToString()));
                }
                _printOrder = dtt;
                           
                if (printMaster != null && billOrder.Rows.Count > 0)
                {
                    report = new grproLib.GridppReport();
                    report.LoadFromFile(path);
                    report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                    report.ParameterByName("Supporter").AsString = printMaster.SupportDic.Name;
                    report.ParameterByName("InvoiceNo").AsString = printMaster.InvoiceNum;
                    report.ParameterByName("BillNo").AsString = printMaster.BillNum.ToString();
                    if (printMaster.Audit_Flag == 0)
                    {
                        report.ParameterByName("ExeTime").AsString = printMaster.RegTime.ToString();
                        report.ParameterByName("AuditPeople").AsString = BaseData.GetUserName(printMaster.RegPeopleID);
                    }
                    else
                    {
                        report.ParameterByName("ExeTime").AsString = printMaster.AuditTime.ToString();
                        report.ParameterByName("AuditPeople").AsString = BaseData.GetUserName(printMaster.AuditPeopleID);
                    }
                    report.ParameterByName("TotalFee").AsString = printMaster.RetailFee.ToString();
                    report.ParameterByName("CurrentUser").AsString = BaseData.GetUserName(printMaster.RegPeopleID);
                    if (printMaster.OpType == ConfigManager.OP_YK_BACKSTORE)
                        billType = DrugBaseDataBll.FindDrugDept(printMaster.DeptID).DeptType1 == "物资" ? "物资退库单" : "药品退库单";
                    else
                        billType = DrugBaseDataBll.FindDrugDept(printMaster.DeptID).DeptType1 == "物资" ? "物资入库单" : "药品入库单";
                    report.ParameterByName("CurrentDept").AsString = BaseData.GetDeptName(printMaster.DeptID.ToString());
                    report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + billType;
                    report.ParameterByName("Printer").AsString = BaseData.GetUserName(Printer);
                    report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;                   
                    report.ParameterByName("InstoreFee").AsString = printMaster.StockFee.ToString();
                    report.ParameterByName("DiffFee").AsString = (printMaster.RetailFee - printMaster.StockFee).ToString();
                    report.ParameterByName("ReMark").AsString = printMaster.ReMark.ToString();
                    report.PrintPreview(false);
                }
            }
            catch (Exception error)
            {
                throw error;
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
