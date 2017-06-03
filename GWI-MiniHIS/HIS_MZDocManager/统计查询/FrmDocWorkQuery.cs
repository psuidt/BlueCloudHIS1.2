using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_MZDocManager
{
    public partial class FrmDocWorkQuery : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;  //当前用户
        private Deptment _currentDept;  //当前科室

        public FrmDocWorkQuery(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            this.FormTitle = chineseName;
        }

        private void btQuery_Click(object sender, EventArgs e)
        {
            DataTable table = HIS.MZDoc_BLL.OP_ReportQuery.QueryDocWorkData((int)this._currentUser.EmployeeID, dTPkBegin.Value, dTPkEnd.Value);

            #region 界面绘制代码
            if (table == null || table.Rows.Count <= 0)
            {
                MessageBox.Show("没有任何记录！", "提示");
                lbCaption.Text = "看诊人次共计：0人";
            }
            else
            {
                lbCaption.Text = "看诊人次共计：" + table.Rows[0][0].ToString().Trim() + "人";
                DrawGraph(table);

                DataRow newRow = table.NewRow();
                newRow["code"] = "00";
                newRow["item_name"] = "总计";
                newRow["money"] = table.Compute("sum(money)", "");
                table.Rows.Add(newRow);

                dGVResult.Visible = true;
                dGVResult.AutoGenerateColumns = false;
                dGVResult.DataSource = table;
                lbCaption.Visible = true;
            }
            #endregion
        }

        /// <summary>
        /// 绘制统计图表
        /// </summary>
        /// <param name="table"></param>
        private void DrawGraph(DataTable table)
        {
            GraphControl gc;
            if (rdBCaky.Checked)
            {
                gc = CreateCakyGraph(table);
            }
            else
            {
                gc = CreateHistogramGraph(table);
            }
            gc.DrawGraph();
        }

        /// <summary>
        /// 绘制柱状图
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private GraphControl CreateHistogramGraph(DataTable table)
        {
            TableColumn[] columns = new TableColumn[1];
            columns[0].ColumnName = "金额";
            columns[0].ColumnField = "money";

            DataTableStruct datatableStruct = DataTableStruct.Rows;
            Color[] color = new Color[table.Columns.Count];
            int num = Convert.ToInt32(256 / table.Rows.Count);
            for (int index = 0; index < table.Columns.Count; index++)
            {
                color[index] = System.Drawing.Color.FromArgb(((int)(((byte)(200 - index * num / 2)))), ((int)(((byte)(255 - index * num / 2)))), ((int)(((byte)(0 + index * num)))));
            }

            return new HistogramGraphControl(plGraph, datatableStruct, columns, color, table, "item_name", "处方金额分类汇总", "分类名称", "金额");
        }

        /// <summary>
        /// 绘制饼状图
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private GraphControl CreateCakyGraph(DataTable table)
        {
            TableColumn[] columns = new TableColumn[4];
            columns[0].ColumnName = "金额";
            columns[0].ColumnField = "money";

            DataTableStruct datatableStruct = DataTableStruct.Rows;
            Color[] color = new Color[table.Rows.Count];
            int num = Convert.ToInt32(256 / table.Rows.Count);
            for (int index = 0; index < table.Rows.Count; index++)
            {
                color[index] = System.Drawing.Color.FromArgb(((int)(((byte)(200 - index * num / 2)))), ((int)(((byte)(255 - index * num / 2)))), ((int)(((byte)(0 + index * num)))));
            }

            return new CakyGraphControl(plGraph, datatableStruct, columns, color, table, "item_name", 0);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdBCaky_CheckedChanged(object sender, EventArgs e)
        {
            btQuery_Click(null,null);
        }
    }
}
