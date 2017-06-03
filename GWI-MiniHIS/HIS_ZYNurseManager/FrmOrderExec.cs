using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;
using grproLib;


namespace HIS_ZYNurseManager
{
    public partial class FrmOrderExec : GWI.HIS.Windows.Controls.BaseMainForm
    {
        #region 变量 属性 构造函数
        int printedcount = 0;//选定的医嘱中是否已经打印过（选定日期是否打印过）
        string strcureno;//住院号
        string printedordercontents = "";//已打印过的医嘱内容
        OP_OrderExec op_orderexec = new OP_OrderExec();
        GridppReport report = null;
        GridppReport reportpq = null;//打印瓶签
        DataTable printTable = null;
        DataTable printTablepq = null;//瓶签打印表
        DataTable dt;
        Color ChkBackColor = Color.PaleTurquoise;//选中行背景色        
        private User _currentUser;
        /// <summary>
        /// 当前用户对象
        /// </summary>
        public User currentUser
        {
            get
            {
                return _currentUser;
            }
        }
        private Deptment _currentDept;
        /// <summary>
        /// 当前科室对象
        /// </summary>
        public Deptment currentDept
        {
            get
            {
                return _currentDept;
            }
        }       
        /// <summary>
        /// 无参数构造方法
        /// </summary>
        public FrmOrderExec()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 带参数构造方法
        /// </summary>
        /// <param name="currentUserId">用户ID</param>
        /// <param name="currentDeptId">科室ID</param>
        /// <param name="chineseName">窗体标题</param>
        public FrmOrderExec(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            dgv_Patient.AutoGenerateColumns = false;
            dgv_Rpt.AutoGenerateColumns = false;
            btn_Print.Enabled = false;
            FrmLoad();
        }            
        /// <summary>
        /// 窗体加载方法，获取本科室所有患者列表
        /// </summary>
        public void FrmLoad()
        {
            try
            {
                if (!chbx_SearchCureNO.Checked)
                    tbx_CureNO.Text = "";
                strcureno = tbx_CureNO.Text.ToString().Trim();
                dgv_Patient.DataSource = op_orderexec.listPatient(strcureno, Convert.ToInt32(_currentDept.DeptID));

                dt = (DataTable)dgv_Patient.DataSource;

                if (dt == null)
                    return;

                if (dt.Rows.Count <= 0)
                    if (chbx_SearchCureNO.Checked)
                        MessageBox.Show(this, "未找到该患者！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(this, "本科室暂无患者！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    btn_Patient_SelectAll.Enabled = btn_Patient_SelectReverse.Enabled = true;
                    Select(1, dgv_Patient, "Selected");
                }
                tbx_CureNO.Enabled = chbx_SearchCureNO.Checked = false;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        private void btn_Patient_SelectAll_Click(object sender, EventArgs e)
        {
            Select(1, dgv_Patient, "Selected");
        }      
        private void btn_Patient_SelectReverse_Click(object sender, EventArgs e)
        {
            Select(-1, dgv_Patient, "Selected");
        }      
        private void btn_Rpt_SelectAll_Click(object sender, EventArgs e)
        {
            Select(1, dgv_Rpt, "Selected", "RptSelected");
        }       
        private void btn_Rpt_SelectReverse_Click(object sender, EventArgs e)
        {
            Select(-1, dgv_Rpt, "Selected", "RptSelected");
        }     
        private void dgv_Patient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currow;
            if (dgv_Patient.CurrentCell.ColumnIndex == 0)
            {
                currow = dgv_Patient.CurrentCell.RowIndex;
                dgv_Patient.Rows[currow].Cells[0].Value = !Convert.ToBoolean(dgv_Patient.Rows[currow].Cells[0].Value);
            }
        }  

        #region 查找住院号复选框选定状态切换事件
        private void chbx_SearchCureNO_CheckedChanged(object sender, EventArgs e)
        {
            dgv_Patient.Visible = !chbx_SearchCureNO.Checked;
            tbx_CureNO.Enabled = chbx_SearchCureNO.Checked;
            tbx_CureNO.Text = "";
            if (tbx_CureNO.Enabled == true)
                tbx_CureNO.Focus();
            btn_SearchCureNO.Text = chbx_SearchCureNO.Checked ? "查找" : "刷新";
        }
        #endregion

        #region 查找按钮单击事件
        private void btn_SearchCureNO_Click(object sender, EventArgs e)
        {
            FrmLoad();
        }
        #endregion        

        #region 住院号输入框按下回车激活查找按钮单击事件
        private void tbx_CureNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_SearchCureNO.PerformClick();
            }
        }
        #endregion

        #region 查询按钮单击事件
        private void btn_Search_Click(object sender, EventArgs e)
        {
            //遍历打印类型单选按钮，以查询指定类型医嘱
            btn_Print.Enabled = true;
            foreach (RadioButton control in groupBox4.Controls)
            {                
                if (control.Checked)
                {
                    if (rb瓶签.Checked == true)
                    {
                        Search("输液卡");
                        break;
                    }
                    else
                    {
                        Search(control.Text);
                        break;
                    }
                }
            }
        }       
        /// <summary>
        /// 查询医嘱列表
        /// </summary>
        /// <param name="usagetype">用法类型</param>
        public void Search(string usagetype)
        {
            int ordertype = 0;
            int isprint = 0;//是否已经打印，0全部，1已打印，-1未打印
            int adddays = 0;//服务器时间累加天数
            DataTable execlist;//执行单列表
            DataTable dt_chkpat;//选中的患者列表
            dt = (DataTable)dgv_Patient.DataSource;
            dt_chkpat = dt.Clone();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dt.Rows[i]["Selected"]))
                {
                    dt_chkpat.Rows.Add(dt.Rows[i].ItemArray);
                }
            }
            if (dt_chkpat == null || dt_chkpat.Rows.Count == 0)
            {
                MessageBox.Show(this, "您还未选择患者！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;            
            if (rb_OrderLong.Checked)
                ordertype = 1;
            else if (rb_OrderTemp.Checked)
                ordertype = 2;

            if (rb_RptAll.Checked)
                isprint = 0;
            else if (rb_RptOnPrint.Checked)
                isprint = -1;
            else if (rb_RptPrinted.Checked)
                isprint = 1;

            if (rb_Today.Checked)
            {
                adddays = 0;
            }
            else if (rb_Tomorrow.Checked)
            {
                adddays = 1;
            }
            execlist = op_orderexec.listOrder(dt_chkpat, "PatlistID", "BedCode", "PatName", HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.AddDays(adddays), ordertype, usagetype, isprint);
            if (execlist == null || execlist.Rows.Count <= 0)
            {                
                btn_Print.Enabled = false;
                return;
            }
            else
            {
                btn_Print.Enabled = true;
                dgv_Rpt.DataSource = execlist;
            }

            Select(1, dgv_Rpt, "Selected");

            Cursor.Current = System.Windows.Forms.Cursors.Default;

            for (int i = 0; i < dgv_Rpt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgv_Rpt.Rows[i].Cells["Isprinted"].Value) == 1)
                {
                    dgv_Rpt.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
                if (Convert.ToBoolean(dgv_Rpt.Rows[i].Cells["RptSelected"].Value) == true)
                {
                    dgv_Rpt.Rows[i].DefaultCellStyle.BackColor = ChkBackColor;
                }
                else
                    dgv_Rpt.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        /// <summary>
        /// 查询医嘱列表
        /// </summary>
        public DataTable Search()
        {
            int ordertype = 0;
            int isprint = 0;//是否已经打印，0全部，1已打印，-1未打印
            int adddays = 0;//服务器时间累加天数
            DataTable execlist;//执行单列表
            DataTable dt_chkpat;//选中的患者列表
            dt = (DataTable)dgv_Patient.DataSource;
            dt_chkpat = dt.Clone();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dt.Rows[i]["Selected"]))
                {
                    dt_chkpat.Rows.Add(dt.Rows[i].ItemArray);
                }
            }

            if (dt_chkpat == null || dt_chkpat.Rows.Count == 0)
            {
                MessageBox.Show(this, "您还未选择患者！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            if (rb_OrderLong.Checked)
                ordertype = 1;
            else if (rb_OrderTemp.Checked)
                ordertype = 2;

            if (rb_RptAll.Checked)
                isprint = 0;
            else if (rb_RptOnPrint.Checked)
                isprint = -1;
            else if (rb_RptPrinted.Checked)
                isprint = 1;

            if (rb_Today.Checked)
            {
                adddays = 0;
            }
            else if (rb_Tomorrow.Checked)
            {
                adddays = 1;
            }
            string usagetype = null;
            foreach (RadioButton control in groupBox4.Controls)
            {
                if (control.Checked)
                {
                    usagetype = control.Text;
                    break;
                }
            }


            return op_orderexec.listOrder_print(dt_chkpat, "PatlistID", "BedCode", "PatName", HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.AddDays(adddays), ordertype, usagetype, isprint);
        }
        #endregion

        #region 单击医嘱列表选框事件
        private void dgv_Rpt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currow;
            if (dgv_Rpt.CurrentCell.ColumnIndex == 0)
            {
                bool sel;
                int groupid;
                int ordertype;
                long patlistid;
                currow = dgv_Rpt.CurrentCell.RowIndex;
                dt = (DataTable)dgv_Rpt.DataSource;
                dt.Rows[currow]["Selected"] = !Convert.ToBoolean(dt.Rows[currow]["Selected"]);
                sel = Convert.ToBoolean(dt.Rows[currow]["Selected"]);
                groupid = Convert.ToInt32(dt.Rows[currow]["GroupID"].ToString());
                patlistid = Convert.ToInt64(dt.Rows[currow]["PatlistID"].ToString());
                ordertype = Convert.ToInt32(dt.Rows[currow]["OrderType"].ToString());

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["GroupID"].ToString() == groupid.ToString() && dt.Rows[i]["PatlistID"].ToString() == patlistid.ToString() && dt.Rows[i]["OrderType"].ToString() == ordertype.ToString())
                    {
                        dt.Rows[i][0] = sel;
                    }
                }

                dgv_Rpt.DataSource = dt;

                for (int i = 0; i < dgv_Rpt.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgv_Rpt.Rows[i].Cells["RptSelected"].Value) == true)
                    {
                        dgv_Rpt.Rows[i].DefaultCellStyle.BackColor = ChkBackColor;
                    }
                    else
                        dgv_Rpt.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
        #endregion       

        #region 打印按钮单击事件
        private void btn_Print_Click(object sender, EventArgs e)
        {            
            int zxdid = 0;  //执行单ID
            DateTime printdatetime;
            DataTable dtselected;
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            DataTable dttmp = (DataTable)dgv_Rpt.DataSource;//添加医嘱到数据表
            DataTable dtprinting = dttmp.Clone();//需要打印的医嘱列表
            
            //判断是否有选中医嘱
            foreach(DataRow dr in dttmp.Rows)
            {
                if (Convert.ToBoolean(dr["Selected"]))
                {
                    dtprinting.Rows.Add(dr.ItemArray);
                }
            }
            if (dtprinting.Rows.Count == 0)
            {
                MessageBox.Show(this, "未选定医嘱", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rb_Tomorrow.Checked)
            {
                printdatetime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.AddDays(1);
            }
            else
            {
                printdatetime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            }            
            dtselected = dtprinting.Copy();
            
            //判断打印何种类型的执行单
            foreach (RadioButton rb in groupBox4.Controls)
            {       
                if (rb.Checked)
                {
                    //选定的医嘱中是否已打印，给出提示
                    printedcount = 0;
                    printedordercontents = "";//重置已打印医嘱数量和内容
                    for (int i = 0; i < dtprinting.Rows.Count; i++)
                    {
                        if (dtprinting.Rows[i]["Isprinted"].ToString() == "1")
                        {
                            printedcount += 1;
                            printedordercontents += "\n\t" + dtprinting.Rows[i]["OrderContents"].ToString();
                            dtprinting.Rows.Remove(dtprinting.Rows[i]);
                            i--;
                        }
                    }
                    if (printedcount > 0)
                    {
                        //如果不需要再次打印，则从打印表中删除
                        if (MessageBox.Show("以下医嘱已经打印过，是否需要再次打印？\n（如果由于医嘱项目过多看不到按钮请按Alt+Y或Enter(是)或Alt+N(否)）" + printedordercontents, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dtprinting = dtselected;
                        }
                    }                    
                    //判断打印列表中是否有医嘱要打印
                    if (dtprinting.Rows.Count == 0)
                    {
                        MessageBox.Show("无医嘱需要打印！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        foreach (DataRow dr in dtprinting.Rows)
                        {
                            //该条医嘱是否有打印记录
                            if (op_orderexec.hasPrintHistory(Convert.ToInt32(dr["OrderID"].ToString()), out zxdid))
                            {
                                op_orderexec.updatePrintZXD(printdatetime, Convert.ToInt32(_currentUser.UserID), zxdid);
                            }
                            else
                            {
                                op_orderexec.insertIntoPrintZXD(Convert.ToInt32(dr["OrderID"].ToString()), printdatetime, printdatetime, Convert.ToInt32(_currentUser.UserID));
                            }
                        }
                        this.Print(dtprinting, printdatetime, rb.Text);
                        break;
                    }
                }
            }
            btn_Search.PerformClick();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }        
        /// <summary>
        /// 生成打印报表
        /// </summary>
        /// <param name="datatable">数据表</param>
        /// <param name="datetime">打印何时的报表</param>
        public void Print(DataTable datatable, DateTime datetime,string reporttype)
        {
            if (rb瓶签.Checked)
            {
                printTablepq = datatable.Copy();
                reportpq = new GridppReport();
                printTablepq.Columns.Add("OrderTypeZhCn", Type.GetType("System.String"));
                reportpq.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院护士执行单瓶签.grf");
                op_orderexec.bqTreat(printTablepq);
                reportpq.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(reportpq_FetchRecord);
                reportpq.Title = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "瓶签";//新加
                reportpq.PrintPreview(false);//新加
                //reportpq.Print(false);               
            }
            else
            {
                printTable = datatable.Copy();
                report = new GridppReport();
                report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院护士执行单" + reporttype + ".grf");
                //op_orderexec.ContentInGroup(printTable, 0);
                report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + reporttype;
                report.ParameterByName("DeptName").AsString = _currentDept.Name;
                report.ParameterByName("Date").AsString = datetime.Date.ToShortDateString();
                report.ParameterByName("Printer").AsString = _currentUser.Name;
                report.ParameterByName("PrintDateTime").AsString = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString();
                report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);
                report.Title = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + reporttype;//报表标题
                report.PrintPreview(false);//显示打印预览
                //report.Print(false);//不显示预览直接打印               
            }
        }      
         void report_FetchRecord(ref bool pEof)
        {
            GWI_DesReport.HisReport.FillRecordToReport(report, printTable);
        }

        void reportpq_FetchRecord(ref bool pEof)
        {

            GWI_DesReport.HisReport.FillRecordToReport(reportpq, printTablepq);
        }

        #endregion        

        #region 画医嘱分组线
        private void dgv_Rpt_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 2);//组线画笔
            int x1,y1,x2,y2,y3,y4;//y1为组头横线位置，y2为组线底位置，y3为组线顶位置，y4为组尾横线位置
            x1 = y1 = x2 = y2 = 0;
            for (int i = 0; i < dgv_Rpt.Rows.Count; i++)
            {
                x1 = dgv_Rpt.GetCellDisplayRectangle(dgv_Rpt.Columns["GroupLines"].Index,i,false).Left + dgv_Rpt.GetCellDisplayRectangle(dgv_Rpt.Columns["GroupLines"].Index,i,false).Width * 2 / 3;
                x2 = dgv_Rpt.GetCellDisplayRectangle(dgv_Rpt.Columns["GroupLines"].Index,i,false).Right;
                y1 = dgv_Rpt.GetCellDisplayRectangle(dgv_Rpt.Columns["GroupLines"].Index,i,false).Top + dgv_Rpt.GetCellDisplayRectangle(dgv_Rpt.Columns["GroupLines"].Index,i,false).Height * 1 / 5;
                y2 = dgv_Rpt.GetCellDisplayRectangle(dgv_Rpt.Columns["GroupLines"].Index,i,false).Bottom;
                y3 = dgv_Rpt.GetCellDisplayRectangle(dgv_Rpt.Columns["GroupLines"].Index,i,false).Top;
                y4 = dgv_Rpt.GetCellDisplayRectangle(dgv_Rpt.Columns["GroupLines"].Index,i,false).Bottom - dgv_Rpt.GetCellDisplayRectangle(dgv_Rpt.Columns["GroupLines"].Index,i,false).Height * 1 / 5;
                if (dgv_Rpt.Rows[i].Cells["GroupFlag"].Value.ToString() == "1")
                {
                    e.Graphics.DrawLine(pen, x1, y1, x2, y1);
                    e.Graphics.DrawLine(pen, x1, y1, x1, y2);
                }
                else if (dgv_Rpt.Rows[i].Cells["GroupFlag"].Value.ToString() == "2")
                    e.Graphics.DrawLine(pen, x1, y3, x1, y2);
                else if (dgv_Rpt.Rows[i].Cells["GroupFlag"].Value.ToString() == "3")
                {
                    e.Graphics.DrawLine(pen, x1, y3, x1, y4);
                    e.Graphics.DrawLine(pen, x1, y4, x2, y4);
                }
            }
        }
        #endregion        

        #region 网格选择
        /// <summary>
        /// 对datagridview中的datagridviewcheckcolumn列进行选定状态修改
        /// </summary>
        /// <param name="kind">选择类型，-1反选，0全部不选，1全选</param>
        /// <param name="dgv">含有datagridviewcheckcolumn的datagridview</param>
        /// <param name="str">datagridviewcheckcolumn列绑定的数据源的名称</param>
        public void Select(int kind, GWI.HIS.Windows.Controls.DataGridViewEx dgv, string str)
        {
            dt = (DataTable)dgv.DataSource;
            if (dt == null)
                return;
            if (dt.Rows.Count <= 0)
                return;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dt.Rows[i][str] = kind < 0 ? !Convert.ToBoolean(dt.Rows[i][str]) : Convert.ToBoolean(kind);
            }
        }        
        /// <summary>
        /// 对医嘱datagridview中的datagridviewcheckcolumn列进行选定状态修改和网格风格修改
        /// </summary>
        /// <param name="kind">选择类型，-1反选，0全部不选，1全选</param>
        /// <param name="dgv">含有datagridviewcheckcolumn的datagridview</param>
        /// <param name="str1">datagridviewcheckcolumn列绑定的数据源的名称</param>
        /// <param name="str2">datagridviewcheckcolumn列的名称</param>
        public void Select(int kind, GWI.HIS.Windows.Controls.DataGridViewEx dgv, string str1,string str2)
        {
            Select(kind, dgv, str1);
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv.Rows[i].Cells[str2].Value) == true)
                {
                    dgv_Rpt.Rows[i].DefaultCellStyle.BackColor = ChkBackColor;
                }
                else
                    dgv_Rpt.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }
        #endregion
       
        #region 退出按钮单击事件
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
