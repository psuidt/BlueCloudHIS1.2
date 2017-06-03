using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.ZY_BLL.Report;
using System.Collections;

namespace HIS_ZYManager
{
    public partial class FrmTicketRpt : GWI.HIS.Windows.Controls.BaseMainForm
    {
        HIS.ZY_BLL.Report.ITicketDataReport dataReport;
        GWMHIS.BussinessLogicLayer.Classes.User _user;
        int comboBox1index = -1;
        DateTime bdate = new DateTime();
        DateTime edate = new DateTime();

        public FrmTicketRpt(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            this.Text = chineseName;

            DateTime dateNow = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            dtpBdate.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 00:00:00");
            dtpEdate.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 23:59:59");

            dataReport = new HIS.ZY_BLL.Report.TicketRpt();
            dataReport.LoadBaseData();
            _user = new GWMHIS.BussinessLogicLayer.Classes.User(currentUserId);
        }

        private void btRpt_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "")
            {
                MessageBox.Show("请先选择好统计类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            //if (this.cboxCharger.Text == "")
            //{
            //    MessageBox.Show("请先选择好显示数据类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //    return;
            //}

            this.label5.Text = "请等待...";
            this.label5.Refresh();

            dataReport.dateType = (HIS.ZY_BLL.Report.Date_Type)(this.comboBox1.SelectedIndex+1);
            
            if (this.comboBox1.SelectedIndex != comboBox1index || this.dtpBdate.Value != bdate || this.dtpEdate.Value != edate)
            {
                dataReport.LoadOperationData(this.dtpBdate.Value, this.dtpEdate.Value);
                comboBox1index = this.comboBox1.SelectedIndex;
                bdate = this.dtpBdate.Value;
                edate = this.dtpEdate.Value;
            }
            this.label5.Text = "统计完成...";
            //dataReport.IsShow = (TicketDataShowType)this.cboxCharger.SelectedIndex;
            this.groupBox2.Enabled = true;

            this.ckCharger.Checked = true;
            this.cboxCharger.Enabled = true;
            this.ckDept.Checked = true;
            this.cboxDept.Enabled = true;
            this.ckDoc.Checked = true;
            this.cbDoc.Enabled = true;
            this.ckPatType.Checked = true;
            this.cbPatType.Enabled = true;

            this.ckIvoice.Checked = false;
            this.cbbegin.Enabled = false;
            this.cbend.Enabled = false;

            DataTable dt = this.GetData();
            BindCB(dt);
            this.dgvData.DataSource = null;
            this.dgvData.DataSource = dt;
            this.ShowDataGridView();
        }

        private void BindCB(DataTable dt)
        {
            //ArrayList al=new ArrayList();
            cboxCharger.Items.Clear();
            cboxDept.Items.Clear();
            cbDoc.Items.Clear();
            cbPatType.Items.Clear();
            cbbegin.Items.Clear();
            cbend.Items.Clear();

            cboxCharger.Items.Add("全部");
            cboxDept.Items.Add("全部");
            cbDoc.Items.Add("全部");
            cbPatType.Items.Add("全部");

            cboxCharger.SelectedIndex = 0;
            cboxDept.SelectedIndex = 0;
            cbDoc.SelectedIndex = 0;
            cbPatType.SelectedIndex = 0;



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cboxCharger.Items.Contains(dt.Rows[i]["结算人"].ToString()) == false && dt.Rows[i]["结算人"].ToString()!="合计")
                {
                    cboxCharger.Items.Add(dt.Rows[i]["结算人"].ToString());
                }

                if (cboxDept.Items.Contains(dt.Rows[i]["科室名称"].ToString()) == false && dt.Rows[i]["科室名称"].ToString().Trim() != "")
                {
                    cboxDept.Items.Add(dt.Rows[i]["科室名称"].ToString());
                }

                if (cbDoc.Items.Contains(dt.Rows[i]["医生姓名"].ToString()) == false && dt.Rows[i]["医生姓名"].ToString().Trim() != "")
                {
                    cbDoc.Items.Add(dt.Rows[i]["医生姓名"].ToString());
                }

                if (cbPatType.Items.Contains(dt.Rows[i]["类型"].ToString()) == false && dt.Rows[i]["类型"].ToString().Trim() != "")
                {
                    cbPatType.Items.Add(dt.Rows[i]["类型"].ToString());
                }
                if (cbbegin.Items.Contains(dt.Rows[i]["发票号"].ToString()) == false && dt.Rows[i]["发票号"].ToString().Trim() != "")
                {
                    cbbegin.Items.Add(dt.Rows[i]["发票号"].ToString());
                }

                if (cbend.Items.Contains(dt.Rows[i]["发票号"].ToString()) == false && dt.Rows[i]["发票号"].ToString().Trim() != "")
                {
                    cbend.Items.Add(dt.Rows[i]["发票号"].ToString());
                }
            }
        }

        private DataTable GetData()
        {
            dataReport.IsChargerShow = this.ckCharger.Checked;
            dataReport.IsDeptShow = this.ckDept.Checked;
            dataReport.IsDocShow = this.ckDoc.Checked;
            dataReport.IsPatTypeShow = this.ckPatType.Checked;

            dataReport.IsSelfItem = this.cbSelf.Checked;
            dataReport.IsTicketItem = this.cbTicketItem.Checked;
            dataReport.IsVillageItem = this.cbVillage.Checked;
            return dataReport.GetData();                
        }
        private void BindDataGridView()
        {
            DataTable dt = GetData();

            string filterStr = null;

            if (this.cboxCharger.Enabled == true && this.cboxCharger.SelectedIndex != 0)
            {
                filterStr = " 结算人='" + this.cboxCharger.Text + "' ";
            }

            if (this.cboxDept.Enabled == true && this.cboxDept.SelectedIndex != 0)
            {
                if (filterStr == null)
                {
                    filterStr = " 科室名称='" + this.cboxDept.Text + "' ";
                }
                else
                {
                    filterStr = filterStr + " and  科室名称='" + this.cboxDept.Text + "' ";
                }
            }

            if (this.cbDoc.Enabled == true && this.cbDoc.SelectedIndex != 0)
            {
                if (filterStr == null)
                {
                    filterStr = " 医生姓名='" + this.cbDoc.Text + "' ";
                }
                else
                {
                    filterStr = filterStr + " and  医生姓名='" + this.cbDoc.Text + "' ";
                }
            }

            if (this.cbPatType.Enabled == true && this.cbPatType.SelectedIndex != 0)
            {
                if (filterStr == null)
                {
                    filterStr = " 类型='" + this.cbPatType.Text + "' ";
                }
                else
                {
                    filterStr = filterStr + " and  类型='" + this.cbPatType.Text + "' ";
                }
            }

            if (this.ckIvoice.Checked == true && this.cbbegin.Text != "" && this.cbend.Text != "")
            {
                try
                {
                    if (filterStr == null)
                    {
                        filterStr = " Convert(SUBSTRING(发票号,3,Len(发票号)-2),'System.Int32')>=" + Convert.ToInt32(this.cbbegin.Text.Trim().Substring(2)) + " and Convert(SUBSTRING(发票号,3,Len(发票号)-2),'System.Int32')<=" + Convert.ToInt32(this.cbend.Text.Trim().Substring(2)) + "";
                    }
                    else
                    {
                        filterStr = filterStr + " and Convert(SUBSTRING(发票号,3,Len(发票号)-2),'System.Int32')>=" + Convert.ToInt32(this.cbbegin.Text.Trim().Substring(2)) + " and Convert(SUBSTRING(发票号,3,Len(发票号)-2),'System.Int32')<=" + Convert.ToInt32(this.cbend.Text.Trim().Substring(2)) + "";
                    }
                }
                catch
                {
                    throw new Exception("输入的发票号有误！");
                }
            }



            if (filterStr != null)
            {
                DataRow[] drs = null;
                try
                {
                    drs = dt.Select(filterStr);
                }
                catch
                {
                    throw new Exception("输入的发票号有误！");
                }
                dt = dt.Clone();
                for (int i = 0; i < drs.Length; i++)
                {
                    dt.Rows.Add(drs[i].ItemArray);
                }
                CreateDataTableRowAll(dt);
            }

            

            this.dgvData.DataSource = null;
            this.dgvData.DataSource = dt;
            ShowDataGridView();
        }

        private void ShowDataGridView()
        {
            int startNum = 1;

            if (dataReport.IsPatTypeShow)
            {
                startNum = 6;
            }
            else if (dataReport.IsPatTypeShow == false && dataReport.IsDocShow == true)
            {
                startNum = 3;
            }
            else if (dataReport.IsPatTypeShow == false && dataReport.IsDocShow == false && dataReport.IsDeptShow == true)
            {
                startNum = 2;
            }
            else if (dataReport.IsPatTypeShow == false && dataReport.IsDocShow == false && dataReport.IsDeptShow == false)
            {
                startNum = 1;
            }

            for (int i = startNum; i < dgvData.Columns.Count; i++)
            {
                dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void CreateDataTableRowAll(DataTable dt)
        {
            DataRow row = dt.NewRow();

            row[0] = "合计";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //row["合计"] = Convert.ToDecimal(row["合计"]) + Convert.ToDecimal(dt.Rows[i]["合计"]);
                int startNum = 1;

                if (dataReport.IsPatTypeShow)
                {
                    startNum = 6;
                }
                else if (dataReport.IsPatTypeShow == false && dataReport.IsDocShow == true)
                {
                    startNum = 3;
                }
                else if (dataReport.IsPatTypeShow == false && dataReport.IsDocShow == false && dataReport.IsDeptShow == true)
                {
                    startNum = 2;
                }
                else if (dataReport.IsPatTypeShow == false && dataReport.IsDocShow == false && dataReport.IsDeptShow == false)
                {
                    startNum = 1;
                }


                for (int j = startNum; j < dt.Columns.Count; j++)
                {
                    row[j] = Dbnull(row[j]) + Dbnull(dt.Rows[i][j]);
                }
            }
            dt.Rows.Add(row);
        }
        private decimal Dbnull(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(obj);
        }
         
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
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
                excel.Cells[1, 1] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "住院发票报表";
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

        private void btClear_Click(object sender, EventArgs e)
        {
            BindDataGridView();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            string name = ((CheckBox)sender).Name;
            switch (name)
            {
                case "ckCharger":
                    this.cboxCharger.Enabled = ((CheckBox)sender).Checked;
                    break;
                case "ckDept":
                    this.cboxDept.Enabled = ((CheckBox)sender).Checked;
                    break;
                case "ckDoc":
                    this.cbDoc.Enabled = ((CheckBox)sender).Checked;
                    break;
                case "ckPatType":
                    this.cbPatType.Enabled = ((CheckBox)sender).Checked;
                    break;
                case "ckIvoice":
                    this.cbbegin.Enabled = ((CheckBox)sender).Checked;
                    this.cbend.Enabled = ((CheckBox)sender).Checked;
                    break;
            }

        }
 
 
    }
}
