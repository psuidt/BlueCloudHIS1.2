using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 盘点单打印
    /// </summary>
    class CheckPrint:YP_Printer
    {
        /// <summary>
        /// 打印盘点汇总单据
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
                HIS.Model.YP_CheckMaster printMaster = (HIS.Model.YP_CheckMaster)billMaster;
                string strWhere = BLL.Tables.yk_checkmaster.AUDITNUM + oleDb.EuqalTo() + printMaster.AuditNum + oleDb.And()
                    + BLL.Tables.yk_checkmaster.DEL_FLAG + oleDb.EuqalTo() + "0" + oleDb.And()
                    + BLL.Tables.yk_checkmaster.DEPTID + oleDb.EuqalTo() + printMaster.DeptID;
                List<YP_CheckMaster> masterList = new List<YP_CheckMaster>();
                DataTable orderDt = null;
                #region 合并药房盘点单
                if (printMaster.OpType == ConfigManager.OP_YF_CHECK)
                {
                    masterList = BindEntity<YP_CheckMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YF_CHECKMASTER).GetListArray(strWhere);
                    if (masterList.Count <= 0)
                    {
                        return;
                    }
                    foreach (YP_CheckMaster master in masterList)
                    {
                        if (orderDt == null)
                        {
                            orderDt = BillFactory.GetQuery(ConfigManager.OP_YF_CHECK).LoadOrder(master);
                            orderDt.PrimaryKey = new DataColumn[] { orderDt.Columns["MAKERDICID"] };
                            continue;
                        }
                        else
                        {
                            DataTable newDt = BillFactory.GetQuery(ConfigManager.OP_YF_CHECK).LoadOrder(master);
                            for (int index = 0; index < newDt.Rows.Count; index++)
                            {
                                DataRow currentRow = newDt.Rows[index];
                                DataRow findRow = orderDt.Rows.Find(Convert.ToInt32(currentRow["MAKERDICID"]));
                                if (findRow == null)
                                {
                                    orderDt.Rows.Add(currentRow.ItemArray);
                                }
                                else
                                {
                                    findRow["CPACKNUM"] = Convert.ToDecimal(findRow["CPACKNUM"])
                                        + Convert.ToDecimal(currentRow["CPACKNUM"]);
                                    findRow["CKRETAILFEE"] = Convert.ToDecimal(findRow["CKRETAILFEE"])
                                        + Convert.ToDecimal(currentRow["CKRETAILFEE"]);
                                    findRow["CKTRADEFEE"] = Convert.ToDecimal(findRow["CKTRADEFEE"])
                                        + Convert.ToDecimal(currentRow["CKTRADEFEE"]);
                                    findRow["CBASENUM"] = Convert.ToDecimal(findRow["CBASENUM"])
                                        + Convert.ToDecimal(currentRow["CBASENUM"]);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region 合并药库盘点单
                if (printMaster.OpType == ConfigManager.OP_YK_CHECK)
                {
                    
                    masterList = BindEntity<YP_CheckMaster>.CreateInstanceDAL(oleDb, BLL.Tables.YK_CHECKMASTER).GetListArray(strWhere);
                    if (masterList.Count <= 0)
                    {
                        return;
                    }
                    foreach (YP_CheckMaster master in masterList)
                    {
                        if (orderDt == null)
                        {
                            orderDt = BillFactory.GetQuery(ConfigManager.OP_YK_CHECK).LoadOrder(master);
                            orderDt.PrimaryKey = new DataColumn[] { orderDt.Columns["MAKERDICID"], orderDt.Columns["BATCHNUM"] };
                            continue;
                        }
                        else
                        {
                            DataTable newDt = BillFactory.GetQuery(ConfigManager.OP_YK_CHECK).LoadOrder(master);
                            for (int index = 0; index < newDt.Rows.Count; index++)
                            {
                                DataRow currentRow = newDt.Rows[index];
                                DataRow findRow = orderDt.Rows.Find(new object[]{Convert.ToInt32(currentRow["MAKERDICID"]),
                                currentRow["BATCHNUM"].ToString()});
                                if (findRow == null)
                                {
                                    orderDt.Rows.Add(currentRow.ItemArray);
                                }
                                else
                                {
                                    findRow["CPACKNUM"] = Convert.ToDecimal(findRow["CPACKNUM"])
                                        + Convert.ToDecimal(currentRow["CPACKNUM"]);
                                    findRow["CKRETAILFEE"] = Convert.ToDecimal(findRow["CKRETAILFEE"])
                                        + Convert.ToDecimal(currentRow["CKRETAILFEE"]);
                                    findRow["CKTRADEFEE"] = Convert.ToDecimal(findRow["CKTRADEFEE"])
                                        + Convert.ToDecimal(currentRow["CKTRADEFEE"]);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region 生成盘点单汇总数据
                billOrder = orderDt.Clone();
                DataRow[] dRows = orderDt.Select("", "typename,chemname asc");
                foreach (DataRow dRow in dRows)
                {
                    billOrder.Rows.Add(dRow.ItemArray);
                }
                billOrder.Columns.Add("DIFFFEE", System.Type.GetType("System.Decimal"));
                billOrder.Columns.Add("DIFFTRADEFEE", System.Type.GetType("System.Decimal"));
                for (int index = 0; index < billOrder.Rows.Count; index++)
                {
                    decimal diffRetailFee = Convert.ToDecimal(billOrder.Rows[index]["CKRETAILFEE"]) -
                        Convert.ToDecimal(billOrder.Rows[index]["FTRETAILFEE"]);
                    decimal diffTradeFee = Convert.ToDecimal(billOrder.Rows[index]["CKTRADEFEE"]) -
                        Convert.ToDecimal(billOrder.Rows[index]["FTTRADEFEE"]);
                    billOrder.Rows[index]["DIFFFEE"] = diffRetailFee;
                    billOrder.Rows[index]["DIFFTRADEFEE"] = diffTradeFee;
                    //盘盈
                    if (diffRetailFee > 0)
                    {
                        printMaster.MoreRetailFee += diffRetailFee;
                        printMaster.MoreTradeFee += diffTradeFee;
                    }
                    //盘亏
                    else
                    {
                        printMaster.LessRetailFee -= diffRetailFee;
                        printMaster.LessTradeFee -= diffTradeFee;
                    }
                }
                printMaster.AuditNum = masterList[0].AuditNum;
                printMaster.AuditPeopleID = masterList[0].AuditPeopleID;
                printMaster.AuditTime = masterList[0].AuditTime;
                printMaster.DeptID = masterList[0].DeptID;
                #endregion
                #region 参数赋值
                if (billOrder.Rows.Count > 0)
                {
                    _printOrder = billOrder;
                    report = new grproLib.GridppReport();
                    report.LoadFromFile(path);
                    report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);                   
                    report.ParameterByName("CheckDate").AsDateTime = printMaster.AuditTime;
                    report.ParameterByName("BillNo").AsString = printMaster.AuditNum.ToString();
                    report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    report.ParameterByName("Printer").AsString = BaseData.GetUserName(Printer);
                    report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    report.ParameterByName("AuditPeople").AsString = BaseData.GetUserName(printMaster.AuditPeopleID);
                    report.ParameterByName("AuditDept").AsString = BaseData.GetDeptName(printMaster.DeptID.ToString())+"盘点单据";
                    report.ParameterByName("FtTradeFee").AsString = billOrder.Compute("sum(CKTRADEFEE)", "").ToString();
                    report.ParameterByName("FtRetailFee").AsString = billOrder.Compute("sum(CKRETAILFEE)", "").ToString();
                    report.ParameterByName("XYFtTradeFee").AsString = billOrder.Compute("sum(CKTRADEFEE)", "typedicid=1").ToString();
                    report.ParameterByName("XYFtRetailFee").AsString = billOrder.Compute("sum(CKRETAILFEE)", "typedicid=1").ToString();
                    report.ParameterByName("ZCYFtTradeFee").AsString = billOrder.Compute("sum(CKTRADEFEE)", "typedicid=2").ToString();
                    report.ParameterByName("ZCYFtRetailFee").AsString = billOrder.Compute("sum(CKRETAILFEE)", "typedicid=2").ToString();
                    report.ParameterByName("ZYFtTradeFee").AsString = billOrder.Compute("sum(CKTRADEFEE)", "typedicid=3").ToString();
                    report.ParameterByName("ZYFtRetailFee").AsString = billOrder.Compute("sum(CKRETAILFEE)", "typedicid=3").ToString();
                    report.ParameterByName("WZFtTradeFee").AsString = billOrder.Compute("sum(CKTRADEFEE)", "typedicid=4").ToString();
                    report.ParameterByName("WZFtRetailFee").AsString = billOrder.Compute("sum(CKRETAILFEE)", "typedicid=4").ToString(); 
                    report.ParameterByName("CkTradeFee").AsString = billOrder.Compute("sum(FTTRADEFEE)", "").ToString();
                    report.ParameterByName("CkRetailFee").AsString = billOrder.Compute("sum(FTRETAILFEE)", "").ToString();
                    report.ParameterByName("XYCkTradeFee").AsString = billOrder.Compute("sum(FTTRADEFEE)", "typedicid=1").ToString();
                    report.ParameterByName("XYCkRetailFee").AsString = billOrder.Compute("sum(FTRETAILFEE)", "typedicid=1").ToString();
                    report.ParameterByName("ZCYCkTradeFee").AsString = billOrder.Compute("sum(FTTRADEFEE)", "typedicid=2").ToString();
                    report.ParameterByName("ZCYCkRetailFee").AsString = billOrder.Compute("sum(FTRETAILFEE)", "typedicid=2").ToString();
                    report.ParameterByName("ZYCkTradeFee").AsString = billOrder.Compute("sum(FTTRADEFEE)", "typedicid=3").ToString();
                    report.ParameterByName("ZYCkRetailFee").AsString = billOrder.Compute("sum(FTRETAILFEE)", "typedicid=3").ToString();
                    report.ParameterByName("WZCkTradeFee").AsString = billOrder.Compute("sum(FTTRADEFEE)", "typedicid=4").ToString();
                    report.ParameterByName("WZCkRetailFee").AsString = billOrder.Compute("sum(FTRETAILFEE)", "typedicid=4").ToString();
                    report.ParameterByName("MoreRetailFee").AsString = printMaster.MoreRetailFee.ToString();
                    report.ParameterByName("MoreTradeFee").AsString = printMaster.MoreTradeFee.ToString();
                    report.ParameterByName("XYMoreRetailFee").AsString = billOrder.Compute("sum(DIFFFEE)", "typedicid=1 and difffee>0").ToString();
                    report.ParameterByName("XYMoreTradeFee").AsString = billOrder.Compute("sum(DIFFTRADEFEE)", "typedicid=1 and difftradefee>0").ToString();
                    report.ParameterByName("ZCYMoreRetailFee").AsString = billOrder.Compute("sum(DIFFFEE)", "typedicid=2 and difffee>0").ToString();
                    report.ParameterByName("ZCYMoreTradeFee").AsString = billOrder.Compute("sum(DIFFTRADEFEE)", "typedicid=2 and difftradefee>0").ToString();
                    report.ParameterByName("ZYMoreRetailFee").AsString = billOrder.Compute("sum(DIFFFEE)", "typedicid=3 and difffee>0").ToString();
                    report.ParameterByName("ZYMoreTradeFee").AsString = billOrder.Compute("sum(DIFFTRADEFEE)", "typedicid=3 and difftradefee>0").ToString();
                    report.ParameterByName("WZMoreRetailFee").AsString = billOrder.Compute("sum(DIFFFEE)", "typedicid=4 and difffee>0").ToString();
                    report.ParameterByName("WZMoreTradeFee").AsString = billOrder.Compute("sum(DIFFTRADEFEE)", "typedicid=4 and difftradefee>0").ToString();
                    report.ParameterByName("LessRetailFee").AsString = (-printMaster.LessRetailFee).ToString();
                    report.ParameterByName("LessTradeFee").AsString = (-printMaster.LessTradeFee).ToString();
                    report.ParameterByName("XYLessRetailFee").AsString = billOrder.Compute("sum(DIFFFEE)", "typedicid=1 and difffee<0").ToString();
                    report.ParameterByName("XYLessTradeFee").AsString = billOrder.Compute("sum(DIFFTRADEFEE)", "typedicid=1 and difftradefee<0").ToString();
                    report.ParameterByName("ZCYLessRetailFee").AsString = billOrder.Compute("sum(DIFFFEE)", "typedicid=2 and difffee<0").ToString();
                    report.ParameterByName("ZCYLessTradeFee").AsString = billOrder.Compute("sum(DIFFTRADEFEE)", "typedicid=2 and difftradefee<0").ToString();
                    report.ParameterByName("ZYLessRetailFee").AsString = billOrder.Compute("sum(DIFFFEE)", "typedicid=3 and difffee<0").ToString();
                    report.ParameterByName("ZYLessTradeFee").AsString = billOrder.Compute("sum(DIFFTRADEFEE)", "typedicid=3 and difftradefee<0").ToString();
                    report.ParameterByName("WZLessRetailFee").AsString = billOrder.Compute("sum(DIFFFEE)", "typedicid=4 and difffee<0").ToString();
                    report.ParameterByName("WZLessTradeFee").AsString = billOrder.Compute("sum(DIFFTRADEFEE)", "typedicid=4 and difftradefee<0").ToString();
                    report.PrintPreview(false);
                }
                #endregion
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
