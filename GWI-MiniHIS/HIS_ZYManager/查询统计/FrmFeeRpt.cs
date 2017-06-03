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
    public partial class FrmFeeRpt : GWI.HIS.Windows.Controls.BaseMainForm
    {
        HIS.ZY_BLL.Report.IDataReport dataReport;
        GWMHIS.BussinessLogicLayer.Classes.User _user;
        int comboBox1index = -1;
        DateTime bdate=new DateTime();
        DateTime edate=new DateTime();
        DataTable Newdt;

        public FrmFeeRpt(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            Newdt = new DataTable();

            DateTime dateNow = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            dtpBdate.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 00:00:00");
            dtpEdate.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 23:59:59");

            this.Text = chineseName;
            dataReport = new HIS.ZY_BLL.Report.CTicketRpt();
            _user = new GWMHIS.BussinessLogicLayer.Classes.User(currentUserId);
            dataReport.LoadBaseData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRpt_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "" || this.comboBox2.Text == "" || this.comboBox3.Text == "")
            {
                MessageBox.Show("请先选择好统计类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            this.label5.Text = "请等待...";
            this.label5.Refresh();

            dataReport.dateType = (HIS.ZY_BLL.Report.Date_Type)this.comboBox1.SelectedIndex;
            dataReport.totalType = (HIS.ZY_BLL.Report.Total_Type)this.comboBox3.SelectedIndex;
            dataReport.itemType = (HIS.ZY_BLL.Report.Item_Type)this.comboBox2.SelectedIndex;
            if (this.comboBox1.SelectedIndex != comboBox1index || this.dtpBdate.Value != bdate || this.dtpEdate.Value != edate)
            {
                dataReport.LoadOperationData(this.dtpBdate.Value, this.dtpEdate.Value);
                comboBox1index = this.comboBox1.SelectedIndex;
                bdate = this.dtpBdate.Value;
                edate = this.dtpEdate.Value;
            }
            this.dgvData.DataSource = null;

            Newdt = dataReport.GetData();
            this.dgvData.DataSource = Newdt;

            this.label5.Text = "统计完成...";
            this.dgvData.Columns[0].Frozen = true;
            //this.dgvData.Columns[1].Frozen = true;
            for (int i = 1; i < dgvData.Columns.Count; i++)
            {
                dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.dgvData.DataSource;
            DataTable Newdt1 = new DataTable();

            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "名称";
            column.ReadOnly = true;
            Newdt1.Columns.Add(column);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // Create second column.
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = dt.Rows[i][0].ToString();
                column.ReadOnly = true;
                // Add the column to the table.
                Newdt1.Columns.Add(column);
            }

            DataRow row = null;

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                row = Newdt1.NewRow();
                row[0] = dt.Columns[i].ColumnName;
                for (int col = 1; col < Newdt1.Columns.Count; col++)
                {
                    row[col] = dt.Rows[col-1][i];
                }
                Newdt1.Rows.Add(row);
            }

            this.dgvData.DataSource = null;
            this.dgvData.DataSource = Newdt1;
            this.dgvData.Columns[0].Frozen = true;

            for (int i = 1; i < dgvData.Columns.Count; i++)
            {
                dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            //checkBox1_CheckedChanged(null, null);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            ReportToExcel(((DataTable)this.dgvData.DataSource).DefaultView.ToTable());
        }
        /// <summary>
        /// 输出Excel
        /// </summary>
        /// <param name="Report"></param>
        public  void ReportToExcel(DataTable Report)
        {
           
            try
            {
                int totalColumn = Report.Columns.Count;

                Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();

                excel.Application.Workbooks.Add(true);

                #region 填充数据
                excel.Cells[1, 1] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "住院收入报表";
                Microsoft.Office.Interop.Excel.Range titleStartcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1];
                Microsoft.Office.Interop.Excel.Range titleEndcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, totalColumn];
                excel.get_Range(titleStartcell, titleEndcell).Merge(0);
                excel.get_Range(titleStartcell, titleEndcell).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                excel.get_Range(titleStartcell, titleEndcell).Font.Name = "宋体";
                excel.get_Range(titleStartcell, titleEndcell).Font.Size = 15;
                excel.get_Range(titleStartcell, titleEndcell).Font.Bold = true;

                excel.Cells[2, 1] = "统计时间：";
                excel.Cells[2, 2] = bdate.ToString("yyyy-MM-dd HH:mm:ss") + " -- " + edate.ToString("yyyy-MM-dd HH:mm:ss");
                excel.get_Range((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 2], (Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 6]).Merge(0);

                excel.Cells[2, totalColumn - 2] = "制表人：";
                excel.Cells[2, totalColumn - 1] = _user.Name;

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)this.dgvData.DataSource).DefaultView.ToTable();
            if (this.checkBox1.Checked==false)
            {
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][i]) == 0)
                    {
                        dt.Columns.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i][dt.Columns.Count - 1]) == 0)
                    {
                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                dt = Newdt;
            }

            this.dgvData.DataSource = null;
            this.dgvData.DataSource = dt;
            //Newdt = dt;
        }
    }
}
