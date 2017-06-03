using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Model;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.Core;

namespace HIS.YP_BLL.PrintCenter
{
    /// <summary>
    /// 药品单据打印查询条件
    /// </summary>
    public class YP_PrintCondition
    {
        /// <summary>
        /// 会计年
        /// </summary>
        public string actYear;
        /// <summary>
        /// 会计月
        /// </summary>
        public string actMonth;
        /// <summary>
        /// 药品类型
        /// </summary>
        public string drugType;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int userId;
        /// <summary>
        /// 药剂科室ID
        /// </summary>
        public int deptId;

        /// <summary>
        /// 查询类型
        /// </summary>
        public int queyType;
    }

    /// <summary>
    /// 药品明细账目信息打印查询条件
    /// </summary>
    public class YP_AccountCondition : YP_PrintCondition
    {
        /// <summary>
        /// 药品名称
        /// </summary>
        public string drugName;
        /// <summary>
        /// 生产厂家名称
        /// </summary>
        public string productName;
        /// <summary>
        /// 期初数量
        /// </summary>
        public string beginNum;
        /// <summary>
        /// 期末数量
        /// </summary>
        public string endNum;
        /// <summary>
        /// 期初金额
        /// </summary>
        public string begingFee;
        /// <summary>
        /// 期末金额
        /// </summary>
        public string endFee;
    }
    /// <summary>
    /// 药品报表打印类
    /// </summary>
    abstract public class YP_Printer:HIS.SYSTEM.Core.BaseBLL
    {
        /// <summary>
        /// 打印报表明细信息
        /// </summary>
        static protected DataTable _printOrder;


       // public abstract void PrintBill( DataTable billOrder, string path, int Printer);
        /// <summary>
        /// 打印单据
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="billOrder">单据明细</param>
        /// <param name="path">报表文件路径</param>
        /// <param name="Printer">打印人员</param>
        public abstract void PrintBill(BillMaster billMaster, DataTable billOrder, string path, int Printer);
       /// <summary>
       /// 打印其他报表（除单据外）
       /// </summary>
       /// <param name="printCondition">报表头</param>
       /// <param name="orderDt">报表明细</param>
       /// <param name="path">报表文件路径</param>
        public abstract void PrintReport(YP_PrintCondition printCondition, System.Data.DataTable orderDt, string path);
        /// <summary>
        /// 报表操作对象
        /// </summary>
        static protected grproLib.GridppReport report;
        /// <summary>
        /// 填充报表
        /// </summary>
        /// <param name="Eof">填充方式</param>
        static protected void report_FetchRecord(ref bool Eof)
        {
                GWI_DesReport.HisReport.FillRecordToReport(report, _printOrder);
        }


        ///<summary>
        ///获取结存数
        /// </summary>
         static  protected decimal Getovernumber(int orderid)//获取药品结余数 zhangyunhui 5.8
        {
            decimal rest;
            string strWhere = HIS.BLL.Tables.yk_account.ORDERID+oleDb.EuqalTo()+orderid;
            object obj = HIS.SYSTEM.Core.BindEntity<HIS.BLL.Tables.yk_account>.CreateInstanceDAL(oleDb).GetFieldValue(HIS.BLL.Tables.yk_account.OVERNUM, strWhere);
            if (obj != null)
                rest = (decimal)obj;
            else
                rest = 0;
            return rest;            
            
        }




        /// <summary>
        /// 打印启用药品
        /// </summary>
        /// <param name="path">报表文件路径</param>
        /// <param name="printer">打印人</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="drugInfo">药品信息表</param>
        static public void PrintUseDrug(string path, int printer, int deptId, DataTable drugInfo)
        {
            try
            {
                _printOrder = drugInfo;
                if (path != "" && drugInfo.Rows.Count > 0)
                {
                    report = new grproLib.GridppReport();
                    report.LoadFromFile(path);
                    report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                    report.ParameterByName("Printer").AsString = BaseData.GetUserName(printer);
                    report.ParameterByName("DeptName").AsString = BaseData.GetDeptName(deptId.ToString());
                    report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    report.PrintPreview(false);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
        /// <summary>
        /// 打印库存清单
        /// </summary>
        /// <param name="path">报表位置</param>
        /// <param name="printer">打印人</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="drugInfo">药品库存信息表</param>
        /// <param name="_belongSystem">所属系统（药房、药库）</param>
        static public void PrintStoreBill(string path, int printer, int deptId, DataTable drugInfo, string _belongSystem)
        {
            
            _printOrder = drugInfo.Copy();
            if (path != "" && drugInfo.Rows.Count > 0)
            {
                decimal retailFee = StoreFactory.GetQuery(_belongSystem).QueryStoreFee(deptId, 0);
                decimal tradeFee = StoreFactory.GetQuery(_belongSystem).QueryTradeFee(deptId, 0);
                decimal xy_RetailFee = StoreFactory.GetQuery(_belongSystem).QueryStoreFee(deptId, 1);
                decimal zcy_RetailFee = StoreFactory.GetQuery(_belongSystem).QueryStoreFee(deptId, 2);
                decimal zy_RetailFee = StoreFactory.GetQuery(_belongSystem).QueryStoreFee(deptId, 3);
                decimal xy_TradeFee = StoreFactory.GetQuery(_belongSystem).QueryTradeFee(deptId, 1);
                decimal zcy_TradeFee = StoreFactory.GetQuery(_belongSystem).QueryTradeFee(deptId, 2);
                decimal zy_TradeFee = StoreFactory.GetQuery(_belongSystem).QueryTradeFee(deptId, 3);
                report = new grproLib.GridppReport();
                report.LoadFromFile(path);
                report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                report.ParameterByName("Printer").AsString = BaseData.GetUserName(printer);
                report.ParameterByName("DeptName").AsString = BaseData.GetDeptName(deptId.ToString());
                report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                report.ParameterByName("TotalFee").AsString = retailFee.ToString("0.00");
                
                report.ParameterByName("TotalFee_XY").AsString = xy_RetailFee.ToString("0.00");
                report.ParameterByName("TotalFee_ZCY").AsString = zcy_RetailFee.ToString("0.00");
                report.ParameterByName("TotalFee_ZY").AsString =zy_RetailFee.ToString("0.00");
                if (_belongSystem == ConfigManager.YF_SYSTEM && !ConfigManager.ManageTradepriceByYF())
                {
                    report.ParameterByName("TradeFee").AsString = "受管制无法显示";
                    report.ParameterByName("DiffFee").AsString = "受管制无法显示";
                    report.ParameterByName("TradeFee_XY").AsString = "受管制无法显示";
                    report.ParameterByName("TradeFee_ZCY").AsString = "受管制无法显示";
                    report.ParameterByName("TradeFee_ZY").AsString = "受管制无法显示";
                    report.ParameterByName("DiffFee_XY").AsString = "受管制无法显示";
                    report.ParameterByName("DiffFee_ZCY").AsString = "受管制无法显示";
                    report.ParameterByName("DiffFee_ZY").AsString = "受管制无法显示";
                    _printOrder.Columns.Remove("TRADEPRICE");
                    _printOrder.Columns.Remove("TRADEFEE");
                    _printOrder.Columns.Remove("FEEDIFFERENCE");
                    report.PrintPreview(false);
                    return;
                }
                else
                {
                    report.ParameterByName("TradeFee").AsString = tradeFee.ToString("0.00");
                    report.ParameterByName("DiffFee").AsString = (retailFee - tradeFee).ToString("0.00");
                    report.ParameterByName("TradeFee_XY").AsString = xy_TradeFee.ToString("0.00");
                    report.ParameterByName("TradeFee_ZCY").AsString = zcy_TradeFee.ToString("0.00");
                    report.ParameterByName("TradeFee_ZY").AsString = zy_TradeFee.ToString("0.00");
                    report.ParameterByName("DiffFee_XY").AsString = (xy_RetailFee - xy_TradeFee).ToString("0.00");
                    report.ParameterByName("DiffFee_ZCY").AsString = (zcy_RetailFee - zcy_TradeFee).ToString("0.00");
                    report.ParameterByName("DiffFee_ZY").AsString = (zy_RetailFee - zy_TradeFee).ToString("0.00");
                    report.PrintPreview(false);
                    return;
                }               
            }
        }

        /// <summary>
        /// 打印药库入库单汇总表
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="inMasterDt">入库单头表</param>
        /// <param name="billTime">单据时间</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="printer">打印人员ID</param>
        static public void PringInStoreTotal(string path, DataTable inMasterDt, string billTime, int deptId, int printer)
        {
            try
            {
                decimal xy_RetailFee=0, zcy_RetailFee=0, zy_RetailFee=0, xy_TradeFee=0,
                    zcy_TradeFee=0, zy_TradeFee=0, wz_RetailFee = 0, wz_TradeFee=0;

                decimal xy_RetailFee1 = 0, zcy_RetailFee1 = 0, zy_RetailFee1 = 0, xy_TradeFee1 = 0,
                    zcy_TradeFee1 = 0, zy_TradeFee1 = 0, wz_RetailFee1 = 0, wz_TradeFee1 = 0;

                int supportId = 0;
                string supportName = "";
                report = new grproLib.GridppReport();
                report.LoadFromFile(path);
                report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName
                    + "入库单汇总";
                if (inMasterDt != null)
                {
                    if (inMasterDt.Rows.Count >= 1)
                    {
                        report.ParameterByName("BillTime").AsString = Convert.ToDateTime(inMasterDt.Rows[0]["AUDITTIME"]).ToString()
                            + "到" + Convert.ToDateTime(inMasterDt.Rows[inMasterDt.Rows.Count - 1]["AUDITTIME"]).ToString();
                    }
                    else
                    {
                        report.ParameterByName("BillTime").AsString = billTime;
                    }
                    report.ParameterByName("BillCount").AsString = inMasterDt.Rows.Count.ToString();
                    for (int index = 0; index < inMasterDt.Rows.Count; index++)
                    {
                        DataRow currentRow = inMasterDt.Rows[index];
                        int masterId = Convert.ToInt32(currentRow["MASTERINSTORAGEID"]);
                        if (supportId != Convert.ToInt32(currentRow["SUPPORTDICID"]))
                        {
                            supportId = Convert.ToInt32(currentRow["SUPPORTDICID"]);
                            string currentSupporter = BindEntity<HIS.Model.YP_SupportDic>.CreateInstanceDAL(oleDb,
                                BLL.Tables.YP_SUPPORTDIC).GetModel(supportId).Name;
                            if (supportName.IndexOf(currentSupporter + ",") == -1)
                            {
                                supportName += currentSupporter + ",";
                            }
                        }
                        //加载类型汇金额总表
                        DataTable typeFeeDt = BillQuery.LoadTotalFeeByInOrder(masterId);

                        DataTable outFeeDt = BillQuery.LoadTotalFeeByOutOrder(masterId);
                        //按类型累加各单据批发金额和零售金额(入库)
                        for (int temp = 0; temp < typeFeeDt.Rows.Count; temp++)
                        {
                            DataRow typeFeeRow = typeFeeDt.Rows[temp];
                            if (typeFeeRow["TypeDicID"] != DBNull.Value)
                            {
                                int typeId = Convert.ToInt32(typeFeeRow["TypeDicID"]);
                                switch (typeId)
                                {
                                    case 1:
                                        xy_RetailFee += Convert.ToDecimal(typeFeeRow["RetailFee"]);
                                        xy_TradeFee += Convert.ToDecimal(typeFeeRow["TradeFee"]);
                                        break;
                                    case 2:
                                        zcy_RetailFee += Convert.ToDecimal(typeFeeRow["RetailFee"]);
                                        zcy_TradeFee += Convert.ToDecimal(typeFeeRow["TradeFee"]);
                                        break;
                                    case 3:
                                        zy_RetailFee += Convert.ToDecimal(typeFeeRow["RetailFee"]);
                                        zy_TradeFee += Convert.ToDecimal(typeFeeRow["TradeFee"]);
                                        break;
                                    case 4:
                                        wz_RetailFee += Convert.ToDecimal(typeFeeRow["RetailFee"]);
                                        wz_TradeFee += Convert.ToDecimal(typeFeeRow["TradeFee"]);
                                        break;
                                    default:
                                        break;
                               }
                            }
                        }

                        //按类型累加各单据批发金额和零售金额(退库) //update by heyan 增加退库汇总信息
                        for (int temp = 0; temp < outFeeDt.Rows.Count; temp++)
                        {
                            DataRow typeFeeRow = outFeeDt.Rows[temp];
                            if (typeFeeRow["TypeDicID"] != DBNull.Value)
                            {
                                int typeId = Convert.ToInt32(typeFeeRow["TypeDicID"]);
                                switch (typeId)
                                {
                                    case 1:
                                        xy_RetailFee1 += Convert.ToDecimal(typeFeeRow["RetailFee"]);
                                        xy_TradeFee1 += Convert.ToDecimal(typeFeeRow["TradeFee"]);
                                        break;
                                    case 2:
                                        zcy_RetailFee1 += Convert.ToDecimal(typeFeeRow["RetailFee"]);
                                        zcy_TradeFee1 += Convert.ToDecimal(typeFeeRow["TradeFee"]);
                                        break;
                                    case 3:
                                        zy_RetailFee1 += Convert.ToDecimal(typeFeeRow["RetailFee"]);
                                        zy_TradeFee1 += Convert.ToDecimal(typeFeeRow["TradeFee"]);
                                        break;
                                    case 4:
                                        wz_RetailFee1 += Convert.ToDecimal(typeFeeRow["RetailFee"]);
                                        wz_TradeFee1 += Convert.ToDecimal(typeFeeRow["TradeFee"]);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    //报表参数赋值
                    report.ParameterByName("SupportName").AsString = supportName;
                    report.ParameterByName("TradeFee").AsString = (xy_TradeFee + zcy_TradeFee +
                        zy_TradeFee + wz_TradeFee).ToString("0.00");
                    report.ParameterByName("DiffFee").AsString = (xy_RetailFee + zcy_RetailFee + zy_RetailFee + wz_RetailFee
                        - xy_TradeFee - zcy_TradeFee - zy_TradeFee - wz_TradeFee).ToString("0.00");
                    report.ParameterByName("RetailFee").AsString = (xy_RetailFee + zcy_RetailFee +
                        zy_RetailFee + wz_RetailFee).ToString("0.00");
                    report.ParameterByName("RetailFee_XY").AsString = xy_RetailFee.ToString("0.00");
                    report.ParameterByName("RetailFee_ZCY").AsString = zcy_RetailFee.ToString("0.00");
                    report.ParameterByName("RetailFee_ZY").AsString = zy_RetailFee.ToString("0.00");
                    report.ParameterByName("RetailFee_WZ").AsString = wz_RetailFee.ToString("0.00");
                    report.ParameterByName("TradeFee_XY").AsString = xy_TradeFee.ToString("0.00");
                    report.ParameterByName("TradeFee_ZCY").AsString = zcy_TradeFee.ToString("0.00");
                    report.ParameterByName("TradeFee_ZY").AsString = zy_TradeFee.ToString("0.00");
                    report.ParameterByName("TradeFee_WZ").AsString = wz_TradeFee.ToString("0.00");
                    report.ParameterByName("DiffFee_XY").AsString = (xy_RetailFee - xy_TradeFee).ToString("0.00");
                    report.ParameterByName("DiffFee_ZCY").AsString = (zcy_RetailFee - zcy_TradeFee).ToString("0.00");
                    report.ParameterByName("DiffFee_ZY").AsString = (zy_RetailFee - zy_TradeFee).ToString("0.00");
                    report.ParameterByName("DiffFee_WZ").AsString = (wz_RetailFee - wz_TradeFee).ToString("0.00");
                    report.ParameterByName("DeptName").AsString = BaseData.GetDeptName(deptId.ToString());
                    report.ParameterByName("Printer").AsString = BaseData.GetUserName(printer);
                    report.ParameterByName("PrintTime").AsDateTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;


                    report.ParameterByName("TradeFee1").AsString = (xy_TradeFee1 + zcy_TradeFee1 +
                        zy_TradeFee1 + wz_TradeFee1).ToString("0.00");
                    report.ParameterByName("DiffFee1").AsString = (xy_RetailFee1 + zcy_RetailFee1 + zy_RetailFee1 + wz_RetailFee1
                        - xy_TradeFee1 - zcy_TradeFee1 - zy_TradeFee1 - wz_TradeFee1).ToString("0.00");
                    report.ParameterByName("RetailFee1").AsString = (xy_RetailFee1 + zcy_RetailFee1 +
                        zy_RetailFee1 + wz_RetailFee1).ToString("0.00");
                    report.ParameterByName("RetailFee_XY1").AsString = xy_RetailFee1.ToString("0.00");
                    report.ParameterByName("RetailFee_ZCY1").AsString = zcy_RetailFee1.ToString("0.00");
                    report.ParameterByName("RetailFee_ZY1").AsString = zy_RetailFee1.ToString("0.00");
                    report.ParameterByName("RetailFee_WZ1").AsString = wz_RetailFee1.ToString("0.00");
                    report.ParameterByName("TradeFee_XY1").AsString = xy_TradeFee1.ToString("0.00");
                    report.ParameterByName("TradeFee_ZCY1").AsString = zcy_TradeFee1.ToString("0.00");
                    report.ParameterByName("TradeFee_ZY1").AsString = zy_TradeFee1.ToString("0.00");
                    report.ParameterByName("TradeFee_WZ1").AsString = wz_TradeFee1.ToString("0.00");
                    report.ParameterByName("DiffFee_XY1").AsString = (xy_RetailFee1 - xy_TradeFee1).ToString("0.00");
                    report.ParameterByName("DiffFee_ZCY1").AsString = (zcy_RetailFee1 - zcy_TradeFee1).ToString("0.00");
                    report.ParameterByName("DiffFee_ZY1").AsString = (zy_RetailFee1 - zy_TradeFee1).ToString("0.00");
                    report.ParameterByName("DiffFee_WZ1").AsString = (wz_RetailFee1 - wz_TradeFee1).ToString("0.00");


                    report.PrintPreview(false);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 导出数据到excel
        /// </summary>
        /// <param name="Report">报表数据</param>
        static public void ExportData(DataTable Report)
        {
            try
            {
                int totalColumn = Report.Columns.Count;

                Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();

                excel.Application.Workbooks.Add(true);

                #region 填充数据
                int row = 3;
                Microsoft.Office.Interop.Excel.Range startCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row, 1];
                Microsoft.Office.Interop.Excel.Range endCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row + Report.Rows.Count, totalColumn];

                for (int i = 0; i < Report.Columns.Count; i++)
                    excel.Cells[row, i + 1] = Report.Columns[i].ColumnName.ToString();
                row = row + 1;
                for (int i = 0; i < Report.Rows.Count; i++)
                {

                    for (int j = 0; j < Report.Columns.Count; j++)
                    {
                        object objValue = Report.Rows[i][Report.Columns[j].ColumnName];
                        if (Convert.IsDBNull(objValue))
                            continue;
                        excel.Cells[row + i, j + 1] = objValue.ToString();
                    }
                }
                #endregion

                #region 画网格线
                object obj = excel.get_Range(startCell, endCell).Select();

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;


                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                #endregion

                excel.ActiveWindow.DisplayGridlines = false;
                excel.Visible = true;

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
