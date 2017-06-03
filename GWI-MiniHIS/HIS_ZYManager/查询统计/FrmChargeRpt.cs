using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ZYManager
{
    public partial class FrmChargeRpt : GWI.HIS.Windows.Controls.BaseMainForm
    {
        HIS.ZY_BLL.Report.IAdvanceDataReport dataReport;
        int comboBox1index = -1;
        DateTime bdate = new DateTime();
        DateTime edate = new DateTime();

        public FrmChargeRpt()
        {
            InitializeComponent();
        }

        public FrmChargeRpt(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            this.Text = chineseName;

            dataReport = new HIS.ZY_BLL.Report.AdvanceRpt();
            dataReport.LoadBaseData();
            comboBox1.SelectedIndex = 0;

            DateTime dateNow = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            dtpBdate.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 00:00:00");
            dtpEdate.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 23:59:59");
        }

        private void btRpt_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "")
            {
                MessageBox.Show("请先选择好统计时间类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (this.comboBox2.Text == "")
            {
                MessageBox.Show("请先选择好显示数据类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            this.label5.Text = "请等待...";
            this.label5.Refresh();

            dataReport.dateType = (HIS.ZY_BLL.Report.Date_Type)(this.comboBox1.SelectedIndex);
            dataReport.advShow = (HIS.ZY_BLL.Report.AdvanceDataShowType)this.comboBox2.SelectedIndex;

            if (this.comboBox1.SelectedIndex != comboBox1index || this.dtpBdate.Value != bdate || this.dtpEdate.Value != edate)
            {
                dataReport.LoadOperationData(this.dtpBdate.Value, this.dtpEdate.Value);
                comboBox1index = this.comboBox1.SelectedIndex;
                bdate = this.dtpBdate.Value;
                edate = this.dtpEdate.Value;
            }

            this.dgvData.DataSource = null;
            this.dgvData.DataSource = dataReport.GetData();

            this.label5.Text = "统计完成...";

            this.dgvData.Columns[0].Frozen = true;
            this.dgvData.Columns[1].Frozen = true;
            int startNum = 1;
            if (this.comboBox2.SelectedIndex == 1)
            {
                this.dgvData.Columns[2].Frozen = true;
                this.dgvData.Columns[3].Frozen = true;
                this.dgvData.Columns[4].Frozen = true;
                startNum = 4;
            }
            else if (this.comboBox2.SelectedIndex == 2)
            {
                this.dgvData.Columns[2].Frozen = true;
                startNum = 1;
            }
            for (int i = startNum; i < dgvData.Columns.Count; i++)
            {
                dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Report = (DataTable)dgvData.DataSource;
                int totalColumn = Report.Columns.Count;

                Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();

                excel.Application.Workbooks.Add(true);

                #region 填充数据
                excel.Cells[1, 1] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "住院预交金统计报表";
                Microsoft.Office.Interop.Excel.Range titleStartcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1];
                Microsoft.Office.Interop.Excel.Range titleEndcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, totalColumn];
                excel.get_Range(titleStartcell, titleEndcell).Merge(0);
                excel.get_Range(titleStartcell, titleEndcell).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                excel.get_Range(titleStartcell, titleEndcell).Font.Name = "宋体";
                excel.get_Range(titleStartcell, titleEndcell).Font.Size = 15;
                excel.get_Range(titleStartcell, titleEndcell).Font.Bold = true;

                excel.Cells[2, 1] = "统计时间：";
                excel.Cells[2, 2] = dtpBdate.Value.ToString("yyyy-MM-dd HH:mm:ss") + " -- " + dtpEdate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                excel.get_Range((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 2], (Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 6]).Merge(0);

              //  excel.Cells[2, totalColumn - 2] = "制表人：";
               // excel.Cells[2, totalColumn - 1] = .Name;

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

                row = row + Report.Rows.Count + 1;
                excel.Cells[row, 1] = "审核人";
                excel.Cells[row, totalColumn - 2] = "打印日期：";
                excel.Cells[row, totalColumn] = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString("yyyy-MM-dd");

                #endregion

                excel.ActiveWindow.DisplayGridlines = false;
                excel.Visible = true;

            }
            catch
            {
                MessageBox.Show("输出到Excel发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GC.Collect();
            }

        }
    }
}
