using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.ZY_BLL.ObjectModel.BaseData;
using HIS.ZY_BLL.Report;

namespace HIS_ZYManager
{
    public partial class FrmOutPatientRpt : GWI.HIS.Windows.Controls.BaseMainForm
    {
        GWMHIS.BussinessLogicLayer.Classes.User _user;
        DataTable dtAllOutPat;

        public FrmOutPatientRpt(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();

            DateTime dateNow = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            dateTimePicker1.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 00:00:00");
            dateTimePicker2.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 23:59:59");

            DataTable dtdept = BaseDataFactory.GetData(baseDataType.住院临床科室);
            DataRow dr = dtdept.NewRow();
            dr["code"] = "-1";
            dr["name"] = "全部科室";
            dtdept.Rows.Add(dr);
            this.cbDept.DataSource = dtdept;
            this.cbDept.DisplayMember = "name";
            this.cbDept.ValueMember = "code";
            this.cbDept.SelectedValue = "-1";
            dgvData.AutoGenerateColumns = false;
            _user = new GWMHIS.BussinessLogicLayer.Classes.User(currentUserId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dgvData.DataSource = PatientRpt.GetOutPatinetData(this.cbDept.SelectedValue.ToString(),this.dateTimePicker1.Value,this.dateTimePicker2.Value);
            dtAllOutPat = (DataTable)dgvData.DataSource;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (this.dgvData.DataSource != null)
            this.ReportToExcel(((DataTable)this.dgvData.DataSource).DefaultView.ToTable());
        }
        /// <summary>
        /// 输出Excel
        /// </summary>
        /// <param name="Report"></param>
        public void ReportToExcel(DataTable Report)
        {

            try
            {
                int totalColumn = Report.Columns.Count;

                Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();

                excel.Application.Workbooks.Add(true);

                //e.TotalCount = Report.DataResult.Rows.Count;

                #region 填充数据
                excel.Cells[1, 1] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "出院病人台帐";
                Microsoft.Office.Interop.Excel.Range titleStartcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1];
                Microsoft.Office.Interop.Excel.Range titleEndcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, totalColumn];
                excel.get_Range(titleStartcell, titleEndcell).Merge(0);
                excel.get_Range(titleStartcell, titleEndcell).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                excel.get_Range(titleStartcell, titleEndcell).Font.Name = "宋体";
                excel.get_Range(titleStartcell, titleEndcell).Font.Size = 15;
                excel.get_Range(titleStartcell, titleEndcell).Font.Bold = true;

                excel.Cells[2, 1] = "统计时间：";
                excel.Cells[2, 2] = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + " -- " + dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
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
                    //e.CurrentCount = i;
                    //if (OnExporting != null)
                    //    OnExporting(e);
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

                //excel.get_Range(titleStartcell, titleEndcell).Select();
                excel.ActiveWindow.DisplayGridlines = false;
                excel.Visible = true;

            }
            catch (Exception err)
            {
                MessageBox.Show("输出到Excel发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ErrorWriter.WriteLog(err.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkDeath_CheckedChanged(object sender, EventArgs e) //heyan   [20100720.1.12]
        {
            if (chkDeath.Checked)
            {
                if (dtAllOutPat == null)
                {
                  dtAllOutPat= PatientRpt.GetOutPatinetData(this.cbDept.SelectedValue.ToString(), this.dateTimePicker1.Value, this.dateTimePicker2.Value);                   
                }
                if (dtAllOutPat == null || dtAllOutPat.Rows.Count == 0)
                {
                    return;
                }
                DataTable dt = dtAllOutPat.Clone();
                DataRow[] rows = dtAllOutPat.Select("out_flag=3");
                dt.Clear();
                for (int i = 0; i < rows.Length; i++)
                {
                    dt.Rows.Add(rows[i].ItemArray);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["cureno"] = "合计";
                    dr["patname"] = "共" + dt.Rows.Count + "人";
                    dr["total_fee"] = dt.Compute("sum(total_fee)", "");
                    dr["DEPTOSIT_FEE"] = dt.Compute("sum(DEPTOSIT_FEE)", "");
                    dr["REALITY_FEE"] = dt.Compute("sum(REALITY_FEE)", "");
                    dr["VILLAGE_FEE"] = dt.Compute("sum(VILLAGE_FEE)", "");
                    dr["FAVOR_FEE"] = dt.Compute("sum(FAVOR_FEE)", "");
                    dt.Rows.Add(dr);
                }
                dgvData.DataSource = dt;

            }
            else
            {
                dgvData.DataSource = dtAllOutPat;
            }
        }
    }
}
