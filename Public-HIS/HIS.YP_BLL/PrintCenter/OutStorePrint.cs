using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 出库单打印类
    /// </summary>
    class OutStorePrint:YP_Printer
    {
        /// <summary>
        /// 打印出库单据
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="billOrder">单据明细</param>
        /// <param name="path">报表文件路径</param>
        /// <param name="Printer">打印人员</param>
        public override void PrintBill(HIS.Model.BillMaster billMaster, System.Data.DataTable billOrder, string path, int Printer)
        {
            HIS.Model.YP_OutMaster printMaster = (HIS.Model.YP_OutMaster)billMaster;           
            if (printMaster != null && billOrder != null)
            {
                if (billOrder.Rows.Count > 0)
                {
                    DataTable dtt = billOrder.Copy();
                    bool isShowTradePrice = ConfigManager.ManageTradepriceByYF();
                    if (!isShowTradePrice)
                    {
                        _printOrder.Columns.Remove("TRADEPRICE");
                        _printOrder.Columns.Remove("TRADEFEE");
                        _printOrder.Columns.Remove("DIFFFEE");
                    }                     
                   
                    DataColumn dc = null;
                    dc = dtt.Columns.Add("OVERNUM", Type.GetType("System.String"));//增加结余数 zhangyunhui 5.8 
                    for (int i = 0; i < dtt.Rows.Count; i++)
                    {
                        dtt.Rows[i]["OVERNUM"] = Getovernumber(Convert.ToInt32(dtt.Rows[i]["OUTSTORAGEID"].ToString()));
                    }
                    _printOrder = dtt;

                    if (printMaster.OpType == ConfigManager.OP_YK_REPORTLOSS)
                    {
                        
                        report = new grproLib.GridppReport();
                        string startPath = path + "\\report\\药品报损出库单据.grf";
                        report.LoadFromFile(startPath);
                        report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                    }
                    else
                    {
                        report = new grproLib.GridppReport();
                        string startPath = path + "\\report\\科室领药出库单据.grf";
                        report.LoadFromFile(startPath);
                        report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                        report.ParameterByName("OutDept").AsString = BaseData.GetDeptName(printMaster.OutDeptId.ToString());
                    }
                    report.ParameterByName("BillNo").AsString = printMaster.BillNum.ToString();
                    if (printMaster.Audit_Flag == 0)
                    {
                        report.ParameterByName("ExeTime").AsString = printMaster.RegTime.ToString();
                        report.ParameterByName("RegPeople").AsString = BaseData.GetUserName(printMaster.RegPeopleID);
                    }
                    else
                    {
                        report.ParameterByName("ExeTime").AsString = printMaster.AuditTime.ToString();
                        report.ParameterByName("RegPeople").AsString = BaseData.GetUserName(printMaster.AuditPeopleID);
                    }
                    report.ParameterByName("RegDept").AsString = BaseData.GetDeptName(printMaster.DeptID.ToString());
                    report.ParameterByName("Remark").AsString = printMaster.ReMark;
                    report.ParameterByName("TotalRetailFee").AsString = printMaster.RetailFee.ToString();                   
                    string billType = DrugBaseDataBll.FindDrugDept(printMaster.DeptID).DeptType1 == "物资" ? "物资出库单" : "药品出库单";
                    report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + billType;
                    report.ParameterByName("Printer").AsString = BaseData.GetUserName(Printer);
                    if (isShowTradePrice)
                    {
                        report.ParameterByName("TotalTradeFee").AsString = printMaster.TradeFee.ToString();
                        report.ParameterByName("TotalDiffFee").AsString = (printMaster.RetailFee - printMaster.TradeFee).ToString();
                    }
                    else
                    {
                        report.ParameterByName("TotalTradeFee").AsString = "受管制无法显示";
                        report.ParameterByName("TotalDiffFee").AsString = "受管制无法显示";
                    }
                    report.ParameterByName("Auditer").AsString = BaseData.GetUserName(printMaster.AuditPeopleID);
                    report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                   //report.ParameterByName("BillDate").AsDateTime = (printMaster.BillDate);
                    report.PrintPreview(false);
                }
            }
        }

        public override void PrintReport(YP_PrintCondition printCondition, System.Data.DataTable orderDt, string path)
        {
            throw new NotImplementedException();
        }
    }
}
