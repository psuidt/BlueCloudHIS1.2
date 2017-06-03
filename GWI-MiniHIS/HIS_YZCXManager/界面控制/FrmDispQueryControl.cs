using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using HIS.YZCX_BLL;

namespace HIS_YZCXManager
{
    class FrmDispQueryControl
    {
        private IFrmDispStatQuery _frmdispstatquery;
        private DataTable _dispMaster;
        private DataTable _dispOrder;
        private DataTable _drugInfo;
        private Decimal _totalFee;
        private string _statType;

        public FrmDispQueryControl(IFrmDispStatQuery frmdispstatquery)
        {
            _frmdispstatquery = frmdispstatquery;
            _dispMaster = new DataTable();
            _dispMaster.Columns.Add("PRJID", new Int32().GetType());
            _dispMaster.Columns.Add("PRJNAME");
            _dispMaster.Columns.Add("PRJFEE", new Decimal().GetType());
            _dispMaster.Columns.Add("TOTALNUM", new Decimal().GetType());
            _dispMaster.Columns.Add("productname");
            _dispMaster.Columns.Add("spec");
            _dispMaster.PrimaryKey = new DataColumn[] {_dispMaster.Columns["PRJID"]};
            _drugInfo = YP_Loader.LoadUseDrug();
            _frmdispstatquery.RefreshDrugInfo(_drugInfo);
        }

        /// <summary>
        /// 加载汇总头表
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isRefund"></param>
        /// <param name="drugType"></param>
        /// <param name="statWay"></param>
        /// <param name="makerDicId"></param>
        /// <param name="isMZZY"></param>
        public void LoadDispMaster(DateTime beginTime, DateTime endTime, bool isRefund,
            int drugType, string statWay, int makerDicId, int isMZZYQY)
        {
            try
            {
                _totalFee = 0;
                _statType = statWay;
                _dispMaster.Rows.Clear();
                if (_dispOrder != null)
                {
                    _dispOrder.Rows.Clear();
                }
                //加载明细
                _dispOrder = YP_Loader.LoadDispInfo(beginTime, endTime, drugType, isRefund,
                    makerDicId, isMZZYQY);
                //生成汇总数据
                GetDispMaster();
                _frmdispstatquery.RefreshDispMaster(_dispMaster);
                _frmdispstatquery.SetTotalFee(_totalFee);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 生成汇总头表汇总数据
        /// </summary>
        /// <param name="statWay"></param>
        private void GetDispMaster()
        {
            if (_dispOrder == null)
            {
                return;
            }
            if (_dispOrder.Rows.Count <= 0)
            {
                return;
            }
            switch (_statType)
            {
                case "按单个药品汇总":
                    for (int index = 0; index < _dispOrder.Rows.Count; index++)
                    {
                        DataRow currentRow = _dispOrder.Rows[index];
                        DataRow findRow = _dispMaster.Rows.Find(Convert.ToInt32(currentRow["MAKERDICID"]));
                        if (findRow == null)
                        {
                            DataRow newRow = _dispMaster.NewRow();
                            newRow["PRJID"] = Convert.ToInt32(currentRow["MAKERDICID"]);
                            newRow["PRJNAME"] = currentRow["CHEMNAME"].ToString();
                            newRow["PRJFEE"] = Convert.ToDecimal(currentRow["DEBITFEE"]);
                            newRow["TOTALNUM"] = Convert.ToDecimal(currentRow["DEBITNUM"]);
                            newRow["productname"] = currentRow["productname"].ToString();
                            newRow["spec"] = currentRow["spec"].ToString();
                            _dispMaster.Rows.Add(newRow);
                        }
                        else
                        {
                            findRow["PRJFEE"] = Convert.ToDecimal(currentRow["DEBITFEE"])
                                + Convert.ToDecimal(findRow["PRJFEE"]);
                            findRow["TOTALNUM"] = Convert.ToDecimal(currentRow["DEBITNUM"])
                                + Convert.ToDecimal(findRow["TOTALNUM"]);
                        }
                    }
                        break;
                case "按药剂科室汇总":
                        for (int index = 0; index < _dispOrder.Rows.Count; index++)
                        {
                            DataRow currentRow = _dispOrder.Rows[index];
                            DataRow findRow = _dispMaster.Rows.Find(Convert.ToInt32(currentRow["DEPTID"]));
                            if (findRow == null)
                            {
                                DataRow newRow = _dispMaster.NewRow();
                                newRow["PRJID"] = Convert.ToInt32(currentRow["DEPTID"]);
                                newRow["PRJNAME"] = currentRow["DEPTNAME"].ToString();
                                newRow["PRJFEE"] = Convert.ToDecimal(currentRow["DEBITFEE"]);
                                newRow["TOTALNUM"] = Convert.ToDecimal(currentRow["DEBITNUM"]);
                               // newRow["productname"] = currentRow["productname"].ToString();
                               // newRow["spec"] = currentRow["spec"].ToString();
                                _dispMaster.Rows.Add(newRow);
                            }
                            else
                            {
                                findRow["PRJFEE"] = Convert.ToDecimal(currentRow["DEBITFEE"])
                                    + Convert.ToDecimal(findRow["PRJFEE"]);
                                findRow["TOTALNUM"] = Convert.ToDecimal(currentRow["DEBITNUM"])
                                + Convert.ToDecimal(findRow["TOTALNUM"]);
                            }
                        }
                        break;
                case "按生产厂家汇总":
                        for (int index = 0; index < _dispOrder.Rows.Count; index++)
                        {
                            DataRow currentRow = _dispOrder.Rows[index];
                            DataRow findRow = _dispMaster.Rows.Find(Convert.ToInt32(currentRow["PRODUCTID"]));
                            if (findRow == null)
                            {
                                DataRow newRow = _dispMaster.NewRow();
                                newRow["PRJID"] = Convert.ToInt32(currentRow["PRODUCTID"]);
                                newRow["PRJNAME"] = currentRow["PRODUCTNAME"].ToString();
                                newRow["PRJFEE"] = Convert.ToDecimal(currentRow["DEBITFEE"]);
                                newRow["TOTALNUM"] = Convert.ToDecimal(currentRow["DEBITNUM"]);
                               // newRow["productname"] = currentRow["productname"].ToString();
                               // newRow["spec"] = currentRow["spec"].ToString();
                                _dispMaster.Rows.Add(newRow);
                            }
                            else
                            {
                                findRow["PRJFEE"] = Convert.ToDecimal(currentRow["DEBITFEE"])
                                    + Convert.ToDecimal(findRow["PRJFEE"]);
                                findRow["TOTALNUM"] = Convert.ToDecimal(currentRow["DEBITNUM"])
                                + Convert.ToDecimal(findRow["TOTALNUM"]);
                            }
                        }
                    break;
                case "按开方科室汇总":
                    for (int index = 0; index < _dispOrder.Rows.Count; index++)
                    {
                        DataRow currentRow = _dispOrder.Rows[index];
                        DataRow findRow = _dispMaster.Rows.Find(Convert.ToInt32(currentRow["CUREDEPTID"]));
                        if (findRow == null)
                        {
                            DataRow newRow = _dispMaster.NewRow();
                            newRow["PRJID"] = Convert.ToInt32(currentRow["CUREDEPTID"]);
                            newRow["PRJNAME"] = currentRow["CUREDEPTNAME"].ToString();
                            newRow["PRJFEE"] = Convert.ToDecimal(currentRow["DEBITFEE"]);
                            newRow["TOTALNUM"] = Convert.ToDecimal(currentRow["DEBITNUM"]);
                          //  newRow["productname"] = currentRow["productname"].ToString();
                          //  newRow["spec"] = currentRow["spec"].ToString();
                            _dispMaster.Rows.Add(newRow);
                        }
                        else
                        {
                            findRow["PRJFEE"] = Convert.ToDecimal(currentRow["DEBITFEE"])
                                + Convert.ToDecimal(findRow["PRJFEE"]);
                            findRow["TOTALNUM"] = Convert.ToDecimal(currentRow["DEBITNUM"])
                            + Convert.ToDecimal(findRow["TOTALNUM"]);
                        }
                    }
                    break;
                default:
                    break;
            }
            DataRow endRow = _dispMaster.NewRow();
            endRow["PRJNAME"] = "合计";
            endRow["PRJID"] = 0;
            endRow["PRJFEE"] = 0;
            endRow["TOTALNUM"] = 0;
            endRow["productname"] = "";
            endRow["spec"] = "";

            for (int index = 0; index < _dispMaster.Rows.Count; index++)
            {
                endRow["PRJFEE"] = Convert.ToDecimal(_dispMaster.Rows[index]["PRJFEE"])
                    + Convert.ToDecimal(endRow["PRJFEE"]);
                endRow["TOTALNUM"] = Convert.ToDecimal(_dispMaster.Rows[index]["TOTALNUM"])
                    + Convert.ToDecimal(endRow["TOTALNUM"]);
            }
            _totalFee = Convert.ToDecimal(endRow["PRJFEE"]);
            _dispMaster.Rows.Add(endRow);
        }

        public void LoadDispOrder(int prjId)
        {
            DataTable selectOrders = _dispOrder.Clone();
            DataRow[] selectRows;
            switch (_statType)
            {
                case "按单个药品汇总":
                    selectRows = _dispOrder.Select("MAKERDICID="+prjId.ToString());
                    foreach (DataRow dr in selectRows)
                    {
                        selectOrders.Rows.Add(dr.ItemArray);
                    }
                    break;
                case "按药剂科室汇总":
                    selectRows = _dispOrder.Select("DEPTID=" + prjId.ToString());
                    foreach (DataRow dr in selectRows)
                    {
                        selectOrders.Rows.Add(dr.ItemArray);
                    }
                    break;
                case "按生产厂家汇总":
                    selectRows = _dispOrder.Select("PRODUCTID=" + prjId.ToString());
                    foreach (DataRow dr in selectRows)
                    {
                        selectOrders.Rows.Add(dr.ItemArray);
                    }
                    break;
                case "按开方科室汇总":
                    selectRows = _dispOrder.Select("CUREDEPTID=" + prjId.ToString());
                    foreach (DataRow dr in selectRows)
                    {
                        selectOrders.Rows.Add(dr.ItemArray);
                    }
                    break;
                default:
                    break;
            }
            _frmdispstatquery.RefreshDispOrder(selectOrders);
        }

        public void Exportdata(int prjId,DateTime ? bdate,DateTime ? edate)
        {
            DataTable selectOrders = _dispOrder.Clone();
            DataRow[] selectRows;
            switch (_statType)
            {
                case "按单个药品汇总":
                    selectRows = _dispOrder.Select("MAKERDICID=" + prjId.ToString());
                    foreach (DataRow dr in selectRows)
                    {
                        selectOrders.Rows.Add(dr.ItemArray);
                    }
                    break;
                case "按药剂科室汇总":
                    selectRows = _dispOrder.Select("DEPTID=" + prjId.ToString());
                    foreach (DataRow dr in selectRows)
                    {
                        selectOrders.Rows.Add(dr.ItemArray);
                    }
                    break;
                case "按生产厂家汇总":
                    selectRows = _dispOrder.Select("PRODUCTID=" + prjId.ToString());
                    foreach (DataRow dr in selectRows)
                    {
                        selectOrders.Rows.Add(dr.ItemArray);
                    }
                    break;
                case "按开方科室汇总":
                    selectRows = _dispOrder.Select("CUREDEPTID=" + prjId.ToString());
                    foreach (DataRow dr in selectRows)
                    {
                        selectOrders.Rows.Add(dr.ItemArray);
                    }
                    break;
                default:
                    break;
            }
            ExportData(getdatatable(_dispOrder),bdate,edate);

        }

        /// <summary>
        /// 导出数据到excel
        /// </summary>
        /// <param name="Report">报表数据</param>
        public  void ExportData(DataTable dtReport,DateTime ? bdate,DateTime ? edate)
        {
            try
            {
                int totalColumn = dtReport.Columns.Count;

                Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();

                excel.Application.Workbooks.Add(true);

                DataTable Report = dtReport.Clone();
                for (int i = 0; i < dtReport.Rows.Count;i++ )
                {
                    Report.Rows.Add(dtReport.Rows[i].ItemArray);
                }
             
                Report.Columns["prjname"].ColumnName = "名称";
                Report.Columns["SPEC"].ColumnName = "药品规格";
                Report.Columns["TOTALNUM"].ColumnName = "销售数量";
                Report.Columns["PRJFEE"].ColumnName = "销售金额"; 
                Report.Columns["PRODUCTNAME"].ColumnName = "生产厂家";              
                //DataRow endRow = Report.NewRow();
                //endRow["prjname"] = "合计";               
                //endRow["销售金额"] = 0;
                //endRow["销售数量"] = 0;
                //for (int index = 0; index < Report.Rows.Count; index++) // 显示销量数量和金额统计，增加报表头 2010.9.9 heyan
                //{
                //    endRow["销售金额"] = Convert.ToDecimal(Report.Rows[index]["销售金额"])
                //        + Convert.ToDecimal(endRow["销售金额"]);
                //    endRow["销售数量"] = Convert.ToDecimal(Report.Rows[index]["销售数量"])
                //        + Convert.ToDecimal(endRow["销售数量"]);
                //}
                //endRow["销售金额"] = Convert.ToDecimal(endRow["销售金额"]).ToString("0.00").ToString();
                //Report.Rows.Add(endRow);

                #region 填充数据
                //int row = 3;
                //Microsoft.Office.Interop.Excel.Range startCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row, 1];
                //Microsoft.Office.Interop.Excel.Range endCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row + Report.Rows.Count, totalColumn];

                //for (int i = 0; i < Report.Columns.Count; i++)
                //    excel.Cells[row, i + 1] = Report.Columns[i].ColumnName.ToString();
                //row = row + 1;
                //for (int i = 0; i < Report.Rows.Count; i++)
                //{

                //    for (int j = 0; j < Report.Columns.Count; j++)
                //    {
                //        object objValue = Report.Rows[i][Report.Columns[j].ColumnName];
                //        if (Convert.IsDBNull(objValue))
                //            continue;
                //        excel.Cells[row + i, j + 1] = objValue.ToString();
                //    }
                //}
                #region 填充数据
                excel.Cells[1, 1] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "药品销量统计汇总报表";
                Microsoft.Office.Interop.Excel.Range titleStartcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1];
                Microsoft.Office.Interop.Excel.Range titleEndcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, totalColumn];
                excel.get_Range(titleStartcell, titleEndcell).Merge(0);
                excel.get_Range(titleStartcell, titleEndcell).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                excel.get_Range(titleStartcell, titleEndcell).Font.Name = "宋体";
                excel.get_Range(titleStartcell, titleEndcell).Font.Size = 15;
                excel.get_Range(titleStartcell, titleEndcell).Font.Bold = true;

                excel.Cells[2, 1] = "统计时间：";
                excel.Cells[2, 2] = bdate.Value.ToString("yyyy-MM-dd HH:mm:ss") + " -- " + edate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                excel.get_Range((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 2], (Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 6]).Merge(0);

                //excel.Cells[2, totalColumn - 2] = "制表人：";
                //excel.Cells[2, totalColumn - 1] = _user.Name;

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

        private DataTable getdatatable(DataTable dt)
        {
            DataTable dtt = dt.Clone();
            DataRow[] datarows;
            datarows = dt.Select("");
            foreach (DataRow drr in datarows)
            {
                dtt.Rows.Add(drr.ItemArray);
            }

            int clon = dt.Columns.Count;
            DataTable dtlast = new DataTable();
            string[] strcname = new string[] { "药品名称", "药品规格", "销售数量", "销售金额", "开方科室", "药品单位", "生产厂家", "MAKERDICID", "发票号","CUREDEPTID" };
            dtt.Columns["CHEMNAME"].ColumnName = "药品名称";
            dtt.Columns["SPEC"].ColumnName = "药品规格";
            dtt.Columns["DEBITNUM"].ColumnName = "销售数量";
            dtt.Columns["DEBITFEE"].ColumnName = "销售金额";
            //dtt.Columns["DEPTNAME"].ColumnName = "发药药房";
            dtt.Columns["UNITNAME"].ColumnName = "药品单位";
            dtt.Columns["PRODUCTNAME"].ColumnName = "生产厂家";
            dtt.Columns["CUREDEPTNAME"].ColumnName = "开方科室";
            //dtt.Columns["INVOICENUM"].ColumnName = "发票号";

            DataColumn dtzh = null;
            dtzh = dtt.Columns.Add("zuhezhujian", Type.GetType("System.String"));
            for (int index = 0; index < dtt.Rows.Count; index++)
            {
                dtt.Rows[index]["zuhezhujian"] = dtt.Rows[index]["MAKERDICID"].ToString() + dtt.Rows[index]["CUREDEPTID"].ToString();
 
            }
                for (int index = 0; index < clon; index++)
                {

                    if (!strcname.Contains(dtt.Columns[index].ColumnName))
                    {
                        dtt.Columns.Remove(dtt.Columns[index].ColumnName);
                        index--;
                        clon--;
                    }
                }
            
            Hashtable linshi = new Hashtable();
            string ypid = "";
            string ypyf = "";
            int k = dtt.Rows.Count;
            for (int i = 0; i < k; i++)
            {
                ypid = dtt.Rows[i]["zuhezhujian"].ToString();
                ypyf = dtt.Rows[i]["开方科室"].ToString();
                if ((linshi.ContainsKey(ypid)) && (linshi.ContainsValue(ypyf)))
                {
                    dtt.Rows.Remove(dtt.Rows[i]);
                    i--;
                    k--;
                }

                else
                {
                    linshi.Add(ypid, ypyf);
                    decimal a = (Decimal)dtt.Compute("sum(销售数量)", "zuhezhujian=" + ypid + " and " + "开方科室='" + ypyf + "'");
                    decimal b = (Decimal)dtt.Compute("sum(销售金额)", "zuhezhujian=" + ypid + "and " + "开方科室='" + ypyf + "'");
                    dtt.Rows[i]["销售数量"] = a;
                    dtt.Rows[i]["销售金额"] = b;

                }
            }
            //foreach (DataRow dr in drs)
            //{
            //    dtlast.Rows.Add(dr.ItemArray);

            //}
            dtt.Columns.Remove("MAKERDICID");
            dtt.Columns.Remove("CUREDEPTID");
            dtt.Columns.Remove("zuhezhujian");
            linshi.Clear();
            return dtt;




        }
    }

    public interface IFrmDispStatQuery
    {
        void SetTotalFee(decimal _totalRetailFee);
        void RefreshDispMaster(DataTable dispMaster);
        void RefreshDispOrder(DataTable dispOrder);
        void RefreshDrugInfo(DataTable drugInfo);
    }
}
