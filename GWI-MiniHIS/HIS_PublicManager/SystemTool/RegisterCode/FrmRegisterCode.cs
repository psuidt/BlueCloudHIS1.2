using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace HIS_PublicManager.SystemTool.RegisterCode
{
    public partial class FrmRegisterCode : Form
    {
        string filename = "RegisterCode.XML";

        public FrmRegisterCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            dsdata.WriteXml(filename, XmlWriteMode.WriteSchema);
            MessageBox.Show("保存成功！");
        }

        private void FrmRegisterCode_Load(object sender, EventArgs e)
        {      
            if (File.Exists(filename))
            {
                dsdata.ReadXml(filename);           
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            HIS.SYSTEM.PublicBaseClasses.DESEncryptor des = new HIS.SYSTEM.PublicBaseClasses.DESEncryptor();
            DataTable dt = dsdata.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][1]=des.Encrypt(dt.Rows[i][0].ToString());
            }
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
                MessageBox.Show("输出到Excel发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportToExcel(dsdata.Tables[0]);
        }
    }
}
