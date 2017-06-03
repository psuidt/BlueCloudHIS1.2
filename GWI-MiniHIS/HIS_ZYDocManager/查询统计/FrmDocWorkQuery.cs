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

namespace HIS_ZYDocManager.查询统计
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
            DataTable table = HIS.ZYDoc_BLL.QueryWork.OP_Rpt.QueryDocWork((int)this._currentUser.EmployeeID, dTPkBegin.Value, dTPkEnd.Value);
            #region 界面绘制代码
            int rownum = table.Rows.Count;
            if (table == null || table.Rows.Count <= 0)
            {
                lbfee.Text = "总金额共计：0元";
                rownum = 1;
            }
            else
            {
                lbfee.Text="总金额共计："+table.Compute("sum(money)","").ToString() + "元";
            }
            dGVResult.Visible = true;
            dGVResult.AutoGenerateColumns = false;
            dGVResult.DataSource = table;
            lbfee.Visible = true;



            TableColumn[] columns = new TableColumn[4];
            columns[0].ColumnName = "金额";
            columns[0].ColumnField = "money";
            DataTableStruct datatableStruct;

            datatableStruct = DataTableStruct.Rows;
            Color[] color = new Color[table.Rows.Count];
            int num = Convert.ToInt32(256 / rownum);
            for (int index = 0; index < table.Rows.Count; index++)
            {
                color[index] = System.Drawing.Color.FromArgb(((int)(((byte)(200 - index * num / 2)))), ((int)(((byte)(255 - index * num / 2)))), ((int)(((byte)(0 + index * num)))));
            }

            GraphControl gc = new CakyGraphControl(plGraph, datatableStruct, columns, color, table, "item_name", 0);
            gc.DrawGraph();
            #endregion
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
