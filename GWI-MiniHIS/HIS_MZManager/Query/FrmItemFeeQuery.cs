using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.MZ_BLL;

namespace HIS_MZManager.Query
{
    public partial class FrmItemFeeQuery : GWI.HIS.Windows.Controls.BaseMainForm
    {
        int queryType = 0;

        GWMHIS.BussinessLogicLayer.Classes.User _user;
        public FrmItemFeeQuery(long currentUserId)
        {
            InitializeComponent();
            _user = new GWMHIS.BussinessLogicLayer.Classes.User(currentUserId);
            DataTable dt = HIS.MZ_BLL.PublicDataReader.GetBaseServiceItems();

            txtItems.SetSelectionCardDataSource(HIS.MZ_BLL.PublicDataReader.GetBaseServiceItems());
            txtDoctor.SetSelectionCardDataSource(HIS.MZ_BLL.BaseDataController.BaseDataSet[BaseDataCatalog.医生列表]);
            txtDepartment.SetSelectionCardDataSource(HIS.MZ_BLL.BaseDataController.BaseDataSet[BaseDataCatalog.科室列表]);
            txtExecDept.SetSelectionCardDataSource(HIS.MZ_BLL.BaseDataController.BaseDataSet[BaseDataCatalog.科室列表]); 

            queryType = 0;

            this.txtDepartment.Enabled = false;
            this.txtDoctor.Enabled = false;
            this.txtItems.Enabled = false;
            this.txtExecDept.Enabled = false;

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            HIS.MZ_BLL.Query.PrescriptionQuery presquery = new HIS.MZ_BLL.Query.PrescriptionQuery();

            if (this.checkBox1.Checked==true && txtDepartment.Text.Trim() == "")
            {
                MessageBox.Show("请选择开方科室");
                txtDepartment.Focus();
                return;
            }

            if (this.checkBox2.Checked==true && txtDoctor.Text.Trim() == "")
            {
                MessageBox.Show("请选择开方医生");
                txtDoctor.Focus();
                return;
            }

            if (this.checkBox3.Checked==true && txtItems.Text.Trim() == "")
            {
                MessageBox.Show("请选择收费项目");
                txtItems.Focus();
                return;
            }

            if (this.checkBox4.Checked==true && txtExecDept.Text.Trim() == "")
            {
                MessageBox.Show("请选择执行科室");
                txtExecDept.Focus();
                return;
            }

            string strWhere = " a.presdate between  '" + this.dtpFrom.Value.ToString() + @"' and '" + this.dtpTo.Value.ToString() + @"'";
            if (checkBox1.Checked == true)
            {
                strWhere += " and a.presdeptcode  = '" + this.txtDepartment.MemberValue.ToString() + "'";
            }
            if (checkBox2.Checked == true)
            {
                strWhere += " and a.presdoccode = '" +this.txtDoctor.MemberValue.ToString() + "'";
            }
            if (checkBox3.Checked == true)
            {
                if (queryType == 0)
                    strWhere += " and b.itemid = " + this.txtItems.MemberValue.ToString() + " ";
                else
                    strWhere += " and a.itemid = " + this.txtItems.MemberValue.ToString() + " ";
            }
            if (checkBox4.Checked == true)
            {
                strWhere += " and a.execdeptcode = '" + this.txtExecDept.MemberValue.ToString() + "'";
            }


            dgvItemFee.DataSource = presquery.GetItemFee(queryType,strWhere);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtItems_AfterSelectedRow(object sender, object SelectedValue)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ReportToExcel((DataTable)dgvItemFee.DataSource);
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

                #region 填充数据
                excel.Cells[1, 1] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "门诊收费项目收入报表";
                Microsoft.Office.Interop.Excel.Range titleStartcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1];
                Microsoft.Office.Interop.Excel.Range titleEndcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, totalColumn];
                excel.get_Range(titleStartcell, titleEndcell).Merge(0);
                excel.get_Range(titleStartcell, titleEndcell).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                excel.get_Range(titleStartcell, titleEndcell).Font.Name = "宋体";
                excel.get_Range(titleStartcell, titleEndcell).Font.Size = 15;
                excel.get_Range(titleStartcell, titleEndcell).Font.Bold = true;

                excel.Cells[2, 1] = "统计时间：";
                excel.Cells[2, 2] = dtpFrom.Value .ToString("yyyy-MM-dd HH:mm:ss") + " -- " + dtpTo.Value.ToString("yyyy-MM-dd HH:mm:ss");
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

        private void rbmz_CheckedChanged(object sender, EventArgs e)
        {
            if (rbmz.Checked == true)
                queryType = 0;//门诊
            else
                queryType = 1;//住院
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ck= ((CheckBox)sender);
            if (ck.Checked == true)
            {
                switch (ck.Name)
                {
                    case "checkBox1":
                        this.txtDepartment.Enabled = true;
                        break;
                    case "checkBox2":
                        this.txtDoctor.Enabled = true;
                        break;
                    case "checkBox3":
                        this.txtItems.Enabled = true;
                        break;
                    case "checkBox4":
                        this.txtExecDept.Enabled = true;
                        break;
                }
            }
            else
            {
                switch (ck.Name)
                {
                    case "checkBox1":
                        this.txtDepartment.Enabled = false;
                        break;
                    case "checkBox2":
                        this.txtDoctor.Enabled = false;
                        break;
                    case "checkBox3":
                        this.txtItems.Enabled = false;
                        break;
                    case "checkBox4":
                        this.txtExecDept.Enabled = false;
                        break;
                }
            }
        }
   
    }
}
