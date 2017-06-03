using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Printing;

using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;

namespace HIS_ZYNurseManager
{
    public partial class FrmOrderPrint : GWI.HIS.Windows.Controls.BaseMainForm
    {
        
        int _PatlistID;
        int firstpage;
        int lastpage;
        int currpage = 0;
        int num = 0;
        string prt_msg;
        bool testbool = true;        
        public bool initflag = true;//初始化标识，解决通过菜单加载时先提示后显示窗体        
        DataTable dtprt;//医嘱打印
        User _CurrentUser;
        Deptment _CurrentDept;
        OP_OrderExec op_orderexec = new OP_OrderExec();       
        OrderPrt long_order_prt;
        OrderPrt tmp_order_prt;
        FrmOrderRePrt frmRePrt;
        Patient currpat;
        Font TitleFont = new Font("楷体_GB2312", 16);//打印相关变量
        Font lblFont = new Font("宋体", 12, FontStyle.Bold);
        Font NormalFont = new Font("楷体_GB2312", 12);
        Font ContentFont = new Font("宋体", 9);
        float namex;
        float sexx;
        float agex;
        float deptx;
        float bedx;
        float curenox;
        float[] linex;
        float[] contentx;
        float[] lorderwidth = { 45, 45, 60, 60, 180, 50, 15, 50, 40, 45, 45, 60, 60 };
        float[] torderwidth = { 45, 45, 245, 50, 15, 85, 40, 60, 60, 60, 60 };
        int[] validpages;//患者医嘱页数    
             
        #region 构造方法      
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <param name="currentuserid">当前用户ID</param>
        /// <param name="currentdeptid">当前科室ID</param>
        /// <param name="title">窗体名称</param>
        public FrmOrderPrint(int patlistid, long currentuserid, long currentdeptid, string title)
        {
            InitializeComponent();
            _PatlistID = patlistid;
            _CurrentDept = new Deptment(currentdeptid);
            _CurrentUser = new User(currentuserid);
            this.Text = title;
            if (patlistid != -1)
            initflag = false;
            FormLoad();
            initflag = false;
        }        
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        void FormLoad()
        {
            string _cureno = "";
            dgv_Patient.AutoGenerateColumns = false;
            dgv_LongOrder.AutoGenerateColumns = false;
            dgv_TempOrder.AutoGenerateColumns = false;
            tbx_CureNO.Enabled = chbx_SearchCureNO.Checked;
            if (chbx_SearchCureNO.Checked)
            _cureno = tbx_CureNO.Text.Trim();
            dgv_Patient.DataSource = op_orderexec.listPatient(_cureno, Convert.ToInt32(_CurrentDept.DeptID));
            //患者列表选择指定患者
            DataTable dt = (DataTable)dgv_Patient.DataSource;
            if (dt != null && dt.Rows.Count > 0)
            {
                if (_PatlistID != -1)
                {
                    int i = 0;
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["PatlistID"].ToString() == _PatlistID.ToString())
                            break;
                    }
                    if (i < dt.Rows.Count)
                    {
                        //定位到指定患者
                        dgv_Patient.Rows[i].Selected = true;
                        dgv_Patient.CurrentCell = dgv_Patient.Rows[i].Cells[0];
                        dgv_Patient.FirstDisplayedCell = dgv_Patient.CurrentCell;
                    }
                }
                else
                {
                    dgv_Patient.Rows[0].Selected = true;
                    _PatlistID = Convert.ToInt32(dt.Rows[0]["PatlistID"].ToString());
                }
                currpat = new Patient(_PatlistID);

                if (tpg_Order.SelectedTab == tab_LongOrder)
                {
                    lbl_LongOrder_Title.Text = BaseData.WorkName + "长期医嘱单";
                    //更新患者信息
                    lbl_LongOrder_Age.Text = XcDate.DateToAge(currpat.patbirthday).AgeNum + XcDate.DateToAge(currpat.patbirthday).Unit.ToString();
                    lbl_LongOrder_Bed.Text = currpat.bedcode + "床";
                    lbl_LongOrder_CureNO.Text = currpat.cureno;
                    lbl_LongOrder_Dept.Text = currpat.deptname;
                    lbl_LongOrder_Name.Text = currpat.patname;
                    lbl_LongOrder_Sex.Text = currpat.patsex;

                    //获取医嘱列表
                    long_order_prt = new OrderPrt(_PatlistID, 0);
                    dgv_LongOrder.DataSource = long_order_prt.OrderList;

                    if (dgv_LongOrder == null || dgv_LongOrder.Rows.Count == 0)
                    {
                        pnl_LongOrder.Visible = false;

                        Label LongLabel = new Label();//显示“该患者无长期医嘱！”
                        LongLabel.Text = "该患者无长期医嘱！";
                        LongLabel.AutoSize = true;
                        LongLabel.Font = new Font("楷体_GB2312", 14, FontStyle.Bold);
                        LongLabel.ForeColor = Color.Red;
                        LongLabel.Location = new Point(tab_LongOrder.DisplayRectangle.Width / 2 - LongLabel.Size.Width / 2, tab_LongOrder.DisplayRectangle.Height / 2 - LongLabel.Size.Height / 2 - 50);
                        tab_LongOrder.Controls.Add(LongLabel);
                    }
                    else
                        pnl_LongOrder.Visible = true;

                    prt_msg = long_order_prt.NeedsPrint(_PatlistID, 0);
                    if (initflag == false)
                    {
                        if (prt_msg != "")
                        {
                            MessageBox.Show(prt_msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_PrtPreview.Enabled = btn_Print.Enabled = true;
                        }
                        else
                            btn_PrtPreview.Enabled = btn_Print.Enabled = false;
                    }
                }
                else if (tpg_Order.SelectedTab == tab_TempOrder)
                {
                    lbl_TmpOrder_Title.Text = BaseData.WorkName + "临时医嘱单";

                    //更新患者信息
                    lbl_TmpOrder_Age.Text = XcDate.DateToAge(currpat.patbirthday).AgeNum + XcDate.DateToAge(currpat.patbirthday).Unit.ToString();
                    lbl_TmpOrder_Bed.Text = currpat.bedcode + "床";
                    lbl_TmpOrder_CureNO.Text = currpat.cureno;
                    lbl_TmpOrder_Dept.Text = currpat.deptname;
                    lbl_TmpOrder_Name.Text = currpat.patname;
                    lbl_TmpOrder_Sex.Text = currpat.patsex;

                    //获取医嘱列表
                    tmp_order_prt = new OrderPrt(_PatlistID, 1);
                    dgv_TempOrder.DataSource = tmp_order_prt.OrderList;
                    if (dgv_TempOrder == null || dgv_TempOrder.Rows.Count == 0)
                    {
                        pnl_TmpOrder.Visible = false;

                        Label TmpLabel = new Label();//显示“该患者无临时医嘱！”
                        TmpLabel.Text = "该患者无临时医嘱！";
                        TmpLabel.AutoSize = true;
                        TmpLabel.Font = new Font("楷体_GB2312", 14, FontStyle.Bold);
                        TmpLabel.ForeColor = Color.Red;
                        TmpLabel.Location = new Point(tab_TempOrder.DisplayRectangle.Width / 2 - TmpLabel.Size.Width / 2, tab_TempOrder.DisplayRectangle.Height / 2 - TmpLabel.Size.Height / 2 - 50);
                        tab_TempOrder.Controls.Add(TmpLabel);
                    }
                    else
                        pnl_TmpOrder.Visible = true;
                    prt_msg = tmp_order_prt.NeedsPrint(_PatlistID, 1);
                    if (prt_msg != "")
                    {
                        MessageBox.Show(prt_msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_PrtPreview.Enabled = btn_Print.Enabled = true;
                    }
                    else
                        btn_PrtPreview.Enabled = btn_Print.Enabled = false;
                }
            }
            plBaseWorkArea.Font = new Font("宋体", 9, GraphicsUnit.Point);
        }
        #endregion

        #region 患者列表行选择事件
        private void dgv_Patient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentrow = dgv_Patient.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgv_Patient.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            _PatlistID = Convert.ToInt32(dt.Rows[currentrow]["PatlistID"].ToString());
            currpat = new Patient(_PatlistID);
            if (tpg_Order.SelectedTab == tab_LongOrder)
            {
                //更新患者信息
                lbl_LongOrder_Age.Text = XcDate.DateToAge(currpat.patbirthday).AgeNum + XcDate.DateToAge(currpat.patbirthday).Unit.ToString();
                lbl_LongOrder_Bed.Text = currpat.bedcode + "床";
                lbl_LongOrder_CureNO.Text = currpat.cureno;
                lbl_LongOrder_Dept.Text = currpat.deptname;
                lbl_LongOrder_Name.Text = currpat.patname;
                lbl_LongOrder_Sex.Text = currpat.patsex;

                //获取医嘱列表
                long_order_prt = new OrderPrt(_PatlistID, 0);
                dgv_LongOrder.DataSource = long_order_prt.OrderList;

                if (dgv_LongOrder == null || dgv_LongOrder.Rows.Count == 0)
                {
                    pnl_LongOrder.Visible = false;

                    Label LongLabel = new Label();//显示“该患者无长期医嘱！”
                    LongLabel.Text = "该患者无长期医嘱！";
                    LongLabel.AutoSize = true;
                    LongLabel.Font = new Font("楷体_GB2312", 14, FontStyle.Bold);
                    LongLabel.ForeColor = Color.Red;
                    LongLabel.Location = new Point(tab_LongOrder.DisplayRectangle.Width / 2 - LongLabel.Size.Width / 2, tab_LongOrder.DisplayRectangle.Height / 2 - LongLabel.Size.Height / 2 - 50);
                    tab_LongOrder.Controls.Add(LongLabel);
                }
                else
                    pnl_LongOrder.Visible = true;

                prt_msg = long_order_prt.NeedsPrint(_PatlistID, 0);
                if (prt_msg != "")
                {
                    MessageBox.Show(prt_msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_PrtPreview.Enabled = btn_Print.Enabled = true;
                }
                else
                    btn_PrtPreview.Enabled = btn_Print.Enabled = false;
            }
            else if (tpg_Order.SelectedTab == tab_TempOrder)
            {
                //更新患者信息
                lbl_TmpOrder_Age.Text = XcDate.DateToAge(currpat.patbirthday).AgeNum + XcDate.DateToAge(currpat.patbirthday).Unit.ToString();
                lbl_TmpOrder_Bed.Text = currpat.bedcode + "床";
                lbl_TmpOrder_CureNO.Text = currpat.cureno;
                lbl_TmpOrder_Dept.Text = currpat.deptname;
                lbl_TmpOrder_Name.Text = currpat.patname;
                lbl_TmpOrder_Sex.Text = currpat.patsex;

                //获取医嘱列表
                tmp_order_prt = new OrderPrt(_PatlistID, 1);
                dgv_TempOrder.DataSource = tmp_order_prt.OrderList;
                if (dgv_TempOrder == null || dgv_TempOrder.Rows.Count == 0)
                {
                    pnl_TmpOrder.Visible = false;

                    Label TmpLabel = new Label();//显示“该患者无临时医嘱！”
                    TmpLabel.Text = "该患者无临时医嘱！";
                    TmpLabel.AutoSize = true;
                    TmpLabel.Font = new Font("楷体_GB2312", 14, FontStyle.Bold);
                    TmpLabel.ForeColor = Color.Red;
                    TmpLabel.Location = new Point(tab_TempOrder.DisplayRectangle.Width / 2 - TmpLabel.Size.Width / 2, tab_TempOrder.DisplayRectangle.Height / 2 - TmpLabel.Size.Height / 2 - 50);
                    tab_TempOrder.Controls.Add(TmpLabel);
                }
                else
                    pnl_TmpOrder.Visible = true;
                prt_msg = tmp_order_prt.NeedsPrint(_PatlistID, 1);
                if (prt_msg != "")
                {
                    MessageBox.Show(prt_msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_PrtPreview.Enabled = btn_Print.Enabled = true;
                }
                else
                    btn_PrtPreview.Enabled = btn_Print.Enabled = false;
            }
        }
        #endregion

        #region 长嘱临嘱切换
        private void tpg_Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tpg_Order.SelectedTab == tab_LongOrder)
            {
                lbl_LongOrder_Title.Text = BaseData.WorkName + "长期医嘱单";
                //更新患者信息
                lbl_LongOrder_Age.Text = XcDate.DateToAge(currpat.patbirthday).AgeNum + XcDate.DateToAge(currpat.patbirthday).Unit.ToString();
                lbl_LongOrder_Bed.Text = currpat.bedcode + "床";
                lbl_LongOrder_CureNO.Text = currpat.cureno;
                lbl_LongOrder_Dept.Text = currpat.deptname;
                lbl_LongOrder_Name.Text = currpat.patname;
                lbl_LongOrder_Sex.Text = currpat.patsex;

                //获取医嘱列表
                long_order_prt = new OrderPrt(_PatlistID, 0);
                dgv_LongOrder.DataSource = long_order_prt.OrderList;

                if (dgv_LongOrder == null || dgv_LongOrder.Rows.Count == 0)
                {
                    pnl_LongOrder.Visible = false;

                    Label LongLabel = new Label();//显示“该患者无长期医嘱！”
                    LongLabel.Text = "该患者无长期医嘱！";
                    LongLabel.AutoSize = true;
                    LongLabel.Font = new Font("楷体_GB2312", 14, FontStyle.Bold);
                    LongLabel.ForeColor = Color.Red;
                    LongLabel.Location = new Point(tab_LongOrder.DisplayRectangle.Width / 2 - LongLabel.Size.Width / 2, tab_LongOrder.DisplayRectangle.Height / 2 - LongLabel.Size.Height / 2 - 50);
                    tab_LongOrder.Controls.Add(LongLabel);
                }
                else
                    pnl_LongOrder.Visible = true;

                prt_msg = long_order_prt.NeedsPrint(_PatlistID, 0);
                if (prt_msg != "")
                {
                    MessageBox.Show(prt_msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_PrtPreview.Enabled = btn_Print.Enabled = true;
                }
                else
                    btn_PrtPreview.Enabled = btn_Print.Enabled = false;
            }
            else if (tpg_Order.SelectedTab == tab_TempOrder)
            {
                lbl_TmpOrder_Title.Text = BaseData.WorkName + "临时医嘱单";

                //更新患者信息
                lbl_TmpOrder_Age.Text = XcDate.DateToAge(currpat.patbirthday).AgeNum + XcDate.DateToAge(currpat.patbirthday).Unit.ToString();
                lbl_TmpOrder_Bed.Text = currpat.bedcode + "床";
                lbl_TmpOrder_CureNO.Text = currpat.cureno;
                lbl_TmpOrder_Dept.Text = currpat.deptname;
                lbl_TmpOrder_Name.Text = currpat.patname;
                lbl_TmpOrder_Sex.Text = currpat.patsex;

                //获取医嘱列表
                tmp_order_prt = new OrderPrt(_PatlistID, 1);
                dgv_TempOrder.DataSource = tmp_order_prt.OrderList;
                if (dgv_TempOrder == null || dgv_TempOrder.Rows.Count == 0)
                {
                    pnl_TmpOrder.Visible = false;

                    Label TmpLabel = new Label();//显示“该患者无临时医嘱！”
                    TmpLabel.Text = "该患者无临时医嘱！";
                    TmpLabel.AutoSize = true;
                    TmpLabel.Font = new Font("楷体_GB2312", 14, FontStyle.Bold);
                    TmpLabel.ForeColor = Color.Red;
                    TmpLabel.Location = new Point(tab_TempOrder.DisplayRectangle.Width / 2 - TmpLabel.Size.Width / 2, tab_TempOrder.DisplayRectangle.Height / 2 - TmpLabel.Size.Height / 2 - 50);
                    tab_TempOrder.Controls.Add(TmpLabel);
                }
                else
                    pnl_TmpOrder.Visible = true;
                prt_msg = tmp_order_prt.NeedsPrint(_PatlistID, 1);
                if (prt_msg != "")
                {
                    MessageBox.Show(prt_msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_PrtPreview.Enabled = btn_Print.Enabled = true;
                }
                else
                    btn_PrtPreview.Enabled = btn_Print.Enabled = false;
            }
        }
        #endregion

        #region 选定查找住院号复选框
        private void chbx_SearchCureNO_CheckedChanged(object sender, EventArgs e)
        {
            tbx_CureNO.Enabled = chbx_SearchCureNO.Checked;
            tbx_CureNO.Text = "";
            if (tbx_CureNO.Enabled == true)
                tbx_CureNO.Focus();
            btn_SearchCureNO.Text = chbx_SearchCureNO.Checked ? "查找" : "刷新";
        }
        #endregion

        #region 刷新/查找
        private void btn_SearchCureNO_Click(object sender, EventArgs e)
        {
            FormLoad();
            chbx_SearchCureNO.Checked = false;
        }
        #endregion

        #region 住院号文本框中回车激活查找按钮单击事件
        private void tbx_CureNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_SearchCureNO.PerformClick();
        }
        #endregion

        #region 调整布局，解决作为子窗体时布局不整齐的问题
        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            if (testbool)
            {
                panel8.Size = new Size(panel8.Size.Width, 46);
                panel9.Location = new Point(0, 100);
                panel5.Size = new Size(panel5.Size.Width, 46);
                panel6.Location = new Point(0, 100);
                testbool = false;
            }
        }
        #endregion

        #region 打印
        private void btn_Print_Click(object sender, EventArgs e)
        {
            PrintDocument OrderPrtDoc = new PrintDocument();

            try
            {
                if (tpg_Order.SelectedTab == tab_LongOrder)
                {
                    //获取需要打印的长嘱列表
                    dtprt = long_order_prt.GetLongOrderListToPrt();
                    firstpage = long_order_prt.FirstPage;
                    lastpage = long_order_prt.LastPage;
                    currpage = firstpage;
                    OrderPrtDoc.PrintPage += new PrintPageEventHandler(LongOrderPrt_PrintPage);
                }
                else
                {
                    //获取需要打印的临时列表
                    dtprt = tmp_order_prt.GetTmpOrderListToPrt();
                    firstpage = tmp_order_prt.FirstPage;
                    lastpage = tmp_order_prt.LastPage;
                    currpage = firstpage;
                    //if (dt.Select("PAGENP=" + currpage).Length > 0)
                    OrderPrtDoc.PrintPage += new PrintPageEventHandler(TmpOrderPrt_PrintPage);
                }

                OrderPrtDoc.Print();

                //更新该患者所有医嘱打印状态
                if (tpg_Order.SelectedTab == tab_LongOrder)
                {
                    //更新失败
                    if (!long_order_prt.UpdatePrtStatus(_PatlistID, 0))
                        MessageBox.Show("医嘱打印状态更新失败，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (tpg_Order.SelectedTab == tab_TempOrder)
                {
                    if (!tmp_order_prt.UpdatePrtStatus(_PatlistID, 1))
                        MessageBox.Show("医嘱打印状态更新失败，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.FormLoad();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 长嘱打印
        void LongOrderPrt_PrintPage(object sender, PrintPageEventArgs e)
        {
            float prty;
            float prtx;
            float LeftMargin = (e.PageBounds.Width - lorderwidth.Sum()) / 2;
            float TopMargin = e.MarginBounds.Top - TitleFont.GetHeight(e.Graphics);

            DataRow[] foundrows;
            foundrows = dtprt.Select("PAGENO=" + currpage + " and PRT_STATUS <>3");
            //如果当前页没有内容，转到下一页
            while (foundrows.Length <= 0 && currpage <= lastpage)
            {
                currpage++;
                foundrows = dtprt.Select("PAGENO=" + currpage + " and PRT_STATUS <>3");
            }
            //当前页有内容
            if (foundrows.Length > 0 && currpage <= lastpage)
            {
                //设置网格及其中内容的位置
                linex = new float[10];
                contentx = new float[13];
                linex[0] = (e.PageBounds.Width - lorderwidth.Sum()) / 2;
                contentx[0] = (e.PageBounds.Width - lorderwidth.Sum()) / 2;
                int lj, cj;
                lj = cj = 1;
                for (int i = 0; i < lorderwidth.Length - 1; i++)
                {
                    contentx[cj] = contentx[cj - 1] + lorderwidth[i];
                    if (cj != 5 && cj != 6 && cj != 7 && cj != 8)
                        linex[lj++] = contentx[cj];
                    cj++;
                }
                linex[lj] = contentx[contentx.Length - 1] + lorderwidth[lorderwidth.Length - 1];

                e.Graphics.DrawString("□", NormalFont, Brushes.Black, 50, 50);

                //判断当前页是否是新页，当前页的第一行需要打印，并且第一行是没有打印状态即为新页
                if (foundrows[0]["ROWNO"].ToString() == "1" && foundrows[0]["PRT_STATUS"].ToString() == "0")
                {
                    //打印标题
                    prtx = (e.PageBounds.Width - TitleFont.GetHeight(e.Graphics) * lbl_LongOrder_Title.Text.Length) / 2;
                    prty = TopMargin;
                    e.Graphics.DrawString(lbl_LongOrder_Title.Text, TitleFont, Brushes.Black, prtx, prty, new StringFormat());
                    prty += TitleFont.GetHeight(e.Graphics) + lblFont.GetHeight(e.Graphics);
                    //打印姓名
                    namex = (e.PageBounds.Width - lorderwidth.Sum()) / 2;
                    sexx = namex + 120;
                    agex = sexx + 120;
                    deptx = agex + 120;
                    bedx = deptx + 120;
                    curenox = bedx + 120;
                    e.Graphics.DrawString("姓名", lblFont, Brushes.Black, namex, prty);
                    e.Graphics.DrawString(lbl_LongOrder_Name.Text, NormalFont, Brushes.Black, namex + lblFont.Size * 3, prty);
                    //打印性别
                    e.Graphics.DrawString("性别", lblFont, Brushes.Black, sexx, prty);
                    e.Graphics.DrawString(lbl_LongOrder_Sex.Text, NormalFont, Brushes.Black, sexx + lblFont.Size * 3, prty);
                    //打印年龄
                    e.Graphics.DrawString("年龄", lblFont, Brushes.Black, agex, prty);
                    e.Graphics.DrawString(lbl_LongOrder_Age.Text, NormalFont, Brushes.Black, agex + lblFont.Size * 3, prty);
                    //打印科室
                    e.Graphics.DrawString("科室", lblFont, Brushes.Black, deptx, prty);
                    e.Graphics.DrawString(lbl_LongOrder_Dept.Text, NormalFont, Brushes.Black, deptx + lblFont.Size * 3, prty);
                    //打印床号
                    e.Graphics.DrawString("床号", lblFont, Brushes.Black, bedx, prty);
                    e.Graphics.DrawString(lbl_LongOrder_Bed.Text, NormalFont, Brushes.Black, bedx + lblFont.Size * 3, prty);
                    //打印住院号
                    e.Graphics.DrawString("住院号", lblFont, Brushes.Black, curenox, prty);
                    e.Graphics.DrawString(lbl_LongOrder_CureNO.Text, NormalFont, Brushes.Black, curenox + lblFont.Size * 5, prty);
                    prty += lblFont.GetHeight(e.Graphics) * 2;
                    //打印网格头部分
                    e.Graphics.DrawLine(new Pen(Color.Black), linex[0], prty, linex[linex.Length - 1], prty);//第一条横线
                    e.Graphics.DrawString("起始", ContentFont, Brushes.Black, contentx[0] + (linex[2] - linex[0] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//起始
                    e.Graphics.DrawString("医生", ContentFont, Brushes.Black, contentx[2] + (linex[3] - linex[2] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//医生
                    e.Graphics.DrawString("护士", ContentFont, Brushes.Black, contentx[3] + (linex[4] - linex[3] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//护士
                    e.Graphics.DrawString("医嘱内容", lblFont, Brushes.Black, contentx[4] + (linex[5] - linex[4] - lblFont.GetHeight(e.Graphics) * 4) / 2, prty + lblFont.GetHeight(e.Graphics) / 2);//医嘱内容
                    e.Graphics.DrawString("停止", ContentFont, Brushes.Black, contentx[9] + (linex[7] - linex[5] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//起始
                    e.Graphics.DrawString("医生", ContentFont, Brushes.Black, contentx[11] + (linex[8] - linex[7] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//医生
                    e.Graphics.DrawString("护士", ContentFont, Brushes.Black, contentx[12] + (linex[9] - linex[8] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//护士
                    prty += lblFont.GetHeight(e.Graphics);
                    //第二条横线
                    e.Graphics.DrawLine(new Pen(Color.Black), linex[0], prty, linex[2], prty);
                    e.Graphics.DrawLine(new Pen(Color.Black), linex[5], prty, linex[7], prty);
                    //起始
                    e.Graphics.DrawString("日期", ContentFont, Brushes.Black, contentx[0] + (linex[1] - linex[0] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//日期
                    e.Graphics.DrawString("时间", ContentFont, Brushes.Black, contentx[1] + (linex[2] - linex[1] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//时间
                    e.Graphics.DrawString("签名", ContentFont, Brushes.Black, contentx[2] + (linex[3] - linex[2] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//签名
                    e.Graphics.DrawString("签名", ContentFont, Brushes.Black, contentx[3] + (linex[4] - linex[3] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//签名
                    //停止
                    e.Graphics.DrawString("日期", ContentFont, Brushes.Black, contentx[9] + (linex[6] - linex[5] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//日期
                    e.Graphics.DrawString("时间", ContentFont, Brushes.Black, contentx[10] + (linex[7] - linex[6] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//时间
                    e.Graphics.DrawString("签名", ContentFont, Brushes.Black, contentx[11] + (linex[8] - linex[7] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//签名
                    e.Graphics.DrawString("签名", ContentFont, Brushes.Black, contentx[12] + (linex[9] - linex[8] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//签名
                    //打印纵线
                    for (int i = 0; i < linex.Length; i++)
                    {
                        if (i != 1 && i != 6)
                        {
                            e.Graphics.DrawLine(new Pen(Color.Black), linex[i], prty - lblFont.GetHeight(e.Graphics), linex[i], prty + lblFont.GetHeight(e.Graphics));
                        }
                        else
                        {
                            e.Graphics.DrawLine(new Pen(Color.Black), linex[i], prty, linex[i], prty + lblFont.GetHeight(e.Graphics));
                        }
                    }

                    //打印网格横线
                    prty += lblFont.GetHeight(e.Graphics);
                    for (int i = 0; i <= long_order_prt.RowsPerPage; i++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black), linex[0], prty + lblFont.GetHeight(e.Graphics) * i, linex[linex.Length - 1], prty + lblFont.GetHeight(e.Graphics) * i);
                    }
                    //打印网格纵线
                    for (int i = 0; i < linex.Length; i++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black), linex[i], prty, linex[i], prty + lblFont.GetHeight(e.Graphics) * long_order_prt.RowsPerPage);
                    }
                    //打印页码
                    e.Graphics.DrawString(currpage.ToString(), NormalFont, Brushes.Black, e.PageBounds.Width / 2, e.PageBounds.Bottom / 2 + e.MarginBounds.Bottom / 2, new StringFormat());

                }
                else
                    MessageBox.Show("请放入第" + currpage + "页医嘱", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                prty = TopMargin + TitleFont.GetHeight(e.Graphics) + lblFont.GetHeight(e.Graphics) * 5;
                for (int i = 0; i < foundrows.Length; i++)
                {
                    int rowno = Convert.ToInt32(foundrows[i]["ROWNO"].ToString()) - 1;
                    if (foundrows[i]["PRT_STATUS"].ToString() == "0")
                    {
                        e.Graphics.DrawString(foundrows[i]["ORDER_BDATE"].ToString(), ContentFont, Brushes.Black, contentx[0] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                        e.Graphics.DrawString(foundrows[i]["ORDER_BTIME"].ToString(), ContentFont, Brushes.Black, contentx[1] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                        e.Graphics.DrawString(foundrows[i]["ORDER_DOCNAME"].ToString(), ContentFont, Brushes.Black, contentx[2] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                        e.Graphics.DrawString(foundrows[i]["TRANS_NURSENAME"].ToString(), ContentFont, Brushes.Black, contentx[3] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                        e.Graphics.DrawString(foundrows[i]["ORDER_CONTENT"].ToString(), ContentFont, Brushes.Black, contentx[4] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                        e.Graphics.DrawString(foundrows[i]["UNIT"].ToString(), ContentFont, Brushes.Black, contentx[5] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                        e.Graphics.DrawString(foundrows[i]["GROUP_LINES"].ToString(), ContentFont, Brushes.Black, contentx[6] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                        e.Graphics.DrawString(foundrows[i]["ORDER_USAGE"].ToString(), ContentFont, Brushes.Black, contentx[7] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                        e.Graphics.DrawString(foundrows[i]["FREQUENCY"].ToString(), ContentFont, Brushes.Black, contentx[8] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    }
                    e.Graphics.DrawString(foundrows[i]["ORDER_EDATE"].ToString(), ContentFont, Brushes.Black, contentx[9] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    e.Graphics.DrawString(foundrows[i]["ORDER_ETIME"].ToString(), ContentFont, Brushes.Black, contentx[10] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    e.Graphics.DrawString(foundrows[i]["ORDER_EDOCNAME"].ToString(), ContentFont, Brushes.Black, contentx[11] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    e.Graphics.DrawString(foundrows[i]["ORDER_ETSNURSENAME"].ToString(), ContentFont, Brushes.Black, contentx[12] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                }
            }

            currpage++;
            if (currpage <= lastpage)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }
        #endregion

        #region 临嘱打印
        void TmpOrderPrt_PrintPage(object sender, PrintPageEventArgs e)
        {
            float prty;
            float prtx;
            float LeftMargin = (e.PageBounds.Width - lorderwidth.Sum()) / 2;
            float TopMargin = e.MarginBounds.Top - TitleFont.GetHeight(e.Graphics);

            DataRow[] foundrows;
            foundrows = dtprt.Select("PAGENO=" + currpage + " and PRT_STATUS <>3");
            //如果当前页没有内容，转到下一页
            while (foundrows.Length <= 0 && currpage <= lastpage)
            {
                currpage++;
                foundrows = dtprt.Select("PAGENO=" + currpage + " and PRT_STATUS <>3");
            }
            //当前页有内容
            if (foundrows.Length > 0 && currpage <= lastpage)
            {
                //设置网格及其中内容的位置
                linex = new float[8];
                contentx = new float[11];
                linex[0] = (e.PageBounds.Width - lorderwidth.Sum()) / 2;
                contentx[0] = (e.PageBounds.Width - lorderwidth.Sum()) / 2;
                int lj, cj;
                lj = cj = 1;
                for (int i = 0; i < torderwidth.Length - 1; i++)
                {
                    contentx[cj] = contentx[cj - 1] + torderwidth[i];
                    if (cj != 3 && cj != 4 && cj != 5 && cj != 6)
                        linex[lj++] = contentx[cj];
                    cj++;
                }
                linex[lj] = contentx[contentx.Length - 1] + lorderwidth[lorderwidth.Length - 1];

                e.Graphics.DrawString("□", NormalFont, Brushes.Black, 50, 50);

                //判断当前页是否是新页，当前页的第一行需要打印，并且第一行是没有打印状态即为新页
                if (foundrows[0]["ROWNO"].ToString() == "1" && foundrows[0]["PRT_STATUS"].ToString() == "0")
                {
                    //打印标题
                    prtx = (e.PageBounds.Width - TitleFont.GetHeight(e.Graphics) * lbl_TmpOrder_Title.Text.Length) / 2;
                    prty = TopMargin;
                    e.Graphics.DrawString(lbl_TmpOrder_Title.Text, TitleFont, Brushes.Black, prtx, prty, new StringFormat());
                    prty += TitleFont.GetHeight(e.Graphics) + lblFont.GetHeight(e.Graphics);
                    //打印姓名
                    namex = (e.PageBounds.Width - lorderwidth.Sum()) / 2;
                    sexx = namex + 120;
                    agex = sexx + 120;
                    deptx = agex + 120;
                    bedx = deptx + 120;
                    curenox = bedx + 120;
                    e.Graphics.DrawString("姓名", lblFont, Brushes.Black, namex, prty);
                    e.Graphics.DrawString(lbl_TmpOrder_Name.Text, NormalFont, Brushes.Black, namex + lblFont.Size * 3, prty);
                    //打印性别
                    e.Graphics.DrawString("性别", lblFont, Brushes.Black, sexx, prty);
                    e.Graphics.DrawString(lbl_TmpOrder_Sex.Text, NormalFont, Brushes.Black, sexx + lblFont.Size * 3, prty);
                    //打印年龄
                    e.Graphics.DrawString("年龄", lblFont, Brushes.Black, agex, prty);
                    e.Graphics.DrawString(lbl_TmpOrder_Age.Text, NormalFont, Brushes.Black, agex + lblFont.Size * 3, prty);
                    //打印科室
                    e.Graphics.DrawString("科室", lblFont, Brushes.Black, deptx, prty);
                    e.Graphics.DrawString(lbl_TmpOrder_Dept.Text, NormalFont, Brushes.Black, deptx + lblFont.Size * 3, prty);
                    //打印床号
                    e.Graphics.DrawString("床号", lblFont, Brushes.Black, bedx, prty);
                    e.Graphics.DrawString(lbl_TmpOrder_Bed.Text, NormalFont, Brushes.Black, bedx + lblFont.Size * 3, prty);
                    //打印住院号
                    e.Graphics.DrawString("住院号", lblFont, Brushes.Black, curenox, prty);
                    e.Graphics.DrawString(lbl_TmpOrder_CureNO.Text, NormalFont, Brushes.Black, curenox + lblFont.Size * 5, prty);
                    prty += lblFont.GetHeight(e.Graphics) * 2;
                    //打印网格头部分
                    e.Graphics.DrawLine(new Pen(Color.Black), linex[0], prty, linex[linex.Length - 1], prty);//横线
                    e.Graphics.DrawString("日期", ContentFont, Brushes.Black, contentx[0] + (linex[1] - linex[0] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) * 2 - ContentFont.GetHeight(e.Graphics)) / 2);//日期
                    e.Graphics.DrawString("时间", ContentFont, Brushes.Black, contentx[1] + (linex[2] - linex[1] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) * 2 - ContentFont.GetHeight(e.Graphics)) / 2);//时间
                    e.Graphics.DrawString("医嘱内容", lblFont, Brushes.Black, contentx[2] + (linex[3] - linex[2] - lblFont.GetHeight(e.Graphics) * 4) / 2, prty + lblFont.GetHeight(e.Graphics) / 2);//医嘱内容
                    e.Graphics.DrawString("医生", ContentFont, Brushes.Black, contentx[7] + (linex[4] - linex[3] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//医生
                    e.Graphics.DrawString("护士", ContentFont, Brushes.Black, contentx[8] + (linex[5] - linex[4] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//护士
                    e.Graphics.DrawString("执行", ContentFont, Brushes.Black, contentx[9] + (linex[6] - linex[5] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//护士
                    e.Graphics.DrawString("执行", ContentFont, Brushes.Black, contentx[10] + (linex[7] - linex[6] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//护士
                    prty += lblFont.GetHeight(e.Graphics);
                    e.Graphics.DrawString("签名", ContentFont, Brushes.Black, contentx[7] + (linex[4] - linex[3] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//签名
                    e.Graphics.DrawString("签名", ContentFont, Brushes.Black, contentx[8] + (linex[5] - linex[4] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//签名
                    e.Graphics.DrawString("时间", ContentFont, Brushes.Black, contentx[9] + (linex[6] - linex[5] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//护士
                    e.Graphics.DrawString("签名", ContentFont, Brushes.Black, contentx[10] + (linex[7] - linex[6] - ContentFont.GetHeight(e.Graphics) * 2) / 2, prty + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);//护士

                    //打印纵线
                    for (int i = 0; i < linex.Length; i++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black), linex[i], prty - lblFont.GetHeight(e.Graphics), linex[i], prty + lblFont.GetHeight(e.Graphics));
                    }

                    //打印网格横线
                    prty += lblFont.GetHeight(e.Graphics);
                    for (int i = 0; i <= tmp_order_prt.RowsPerPage; i++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black), linex[0], prty + lblFont.GetHeight(e.Graphics) * i, linex[linex.Length - 1], prty + lblFont.GetHeight(e.Graphics) * i);
                    }
                    //打印网格纵线
                    for (int i = 0; i < linex.Length; i++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black), linex[i], prty, linex[i], prty + lblFont.GetHeight(e.Graphics) * tmp_order_prt.RowsPerPage);
                    }
                    //打印页码
                    e.Graphics.DrawString(currpage.ToString(), NormalFont, Brushes.Black, e.PageBounds.Width / 2, e.PageBounds.Bottom / 2 + e.MarginBounds.Bottom / 2, new StringFormat());
                }
                else
                    MessageBox.Show("请放入第" + currpage + "页医嘱", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                prty = TopMargin + TitleFont.GetHeight(e.Graphics) + lblFont.GetHeight(e.Graphics) * 5;
                for (int i = 0; i < foundrows.Length; i++)
                {
                    int rowno = Convert.ToInt32(foundrows[i]["ROWNO"].ToString()) - 1;
                    e.Graphics.DrawString(foundrows[i]["ORDER_BDATE"].ToString(), ContentFont, Brushes.Black, contentx[0] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    e.Graphics.DrawString(foundrows[i]["ORDER_BTIME"].ToString(), ContentFont, Brushes.Black, contentx[1] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    e.Graphics.DrawString(foundrows[i]["ORDER_CONTENT"].ToString(), ContentFont, Brushes.Black, contentx[2] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    e.Graphics.DrawString(foundrows[i]["UNIT"].ToString(), ContentFont, Brushes.Black, contentx[3] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    e.Graphics.DrawString(foundrows[i]["GROUP_LINES"].ToString(), ContentFont, Brushes.Black, contentx[4] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    e.Graphics.DrawString(foundrows[i]["ORDER_USAGE"].ToString(), ContentFont, Brushes.Black, contentx[5] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    e.Graphics.DrawString(foundrows[i]["FREQUENCY"].ToString(), ContentFont, Brushes.Black, contentx[6] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    e.Graphics.DrawString(foundrows[i]["ORDER_DOCNAME"].ToString(), ContentFont, Brushes.Black, contentx[7] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                    e.Graphics.DrawString(foundrows[i]["TRANS_NURSENAME"].ToString(), ContentFont, Brushes.Black, contentx[8] + 1, prty + NormalFont.GetHeight(e.Graphics) * rowno + (lblFont.GetHeight(e.Graphics) - ContentFont.GetHeight(e.Graphics)) / 2);
                }
            }

            currpage++;
            if (currpage <= lastpage)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }
        #endregion
        #endregion        

        #region 重打
        private void btn_RePrint_Click(object sender, EventArgs e)
        {
            if (tpg_Order.SelectedTab == tab_LongOrder)
            {
                //dtreprt = (DataTable)dgv_LongOrder.DataSource;
                dtprt = (DataTable)dgv_LongOrder.DataSource;
                //获取患者医嘱页数
                validpages = new int[long_order_prt.GetValidPages()];
            }
            else if (tpg_Order.SelectedTab == tab_TempOrder)
            {
                //dtreprt = (DataTable)dgv_LongOrder.DataSource;
                dtprt = (DataTable)dgv_TempOrder.DataSource;
                validpages = new int[tmp_order_prt.GetValidPages()];
            }
            //打开重打页面设置窗体，接收打印页面参数
            for (int i = 0; i < dtprt.Rows.Count; i++)
            {
                dtprt.Rows[i]["PRT_STATUS"] = 3;
            }
            frmRePrt = new FrmOrderRePrt(validpages);
            frmRePrt.Show();
            frmRePrt.FormClosed += new FormClosedEventHandler(frmRePrt_FormClosed);
        }

        void frmRePrt_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmRePrt.ExitFlag)
                return;
            validpages = frmRePrt.Pages;
            PrintDocument OrderPrtDoc = new PrintDocument();
            firstpage = 1;
            lastpage = -1;
            currpage = firstpage;
            if (tpg_Order.SelectedTab == tab_LongOrder)
            {
                for (int pageno = 0; pageno < validpages.Length; pageno++)
                {
                    if (validpages[pageno] == 1)
                    {
                        if (lastpage < pageno + 1)
                            lastpage = pageno + 1;
                        for (int rowno = 0; rowno < dtprt.Rows.Count; rowno++)
                        {
                            if (dtprt.Rows[rowno]["PAGENO"].ToString() == (pageno + 1).ToString())
                            {
                                dtprt.Rows[rowno]["PRT_STATUS"] = 0;
                            }
                        }
                    }
                }
                OrderPrtDoc.PrintPage += new PrintPageEventHandler(LongOrderPrt_PrintPage);
            }
            else if (tpg_Order.SelectedTab == tab_TempOrder)
            {
                for (int pageno = 0; pageno < validpages.Length; pageno++)
                {
                    if (validpages[pageno] == 1)
                    {
                        if (lastpage < pageno + 1)
                            lastpage = pageno + 1;
                        for (int rowno = 0; rowno < dtprt.Rows.Count; rowno++)
                        {
                            if (dtprt.Rows[rowno]["PAGENO"].ToString() == (pageno + 1).ToString())
                            {
                                dtprt.Rows[rowno]["PRT_STATUS"] = 0;
                            }
                        }
                    }
                }
                OrderPrtDoc.PrintPage += new PrintPageEventHandler(TmpOrderPrt_PrintPage);
            }
            OrderPrtDoc.Print();

            //更新该患者所有医嘱打印状态
            if (tpg_Order.SelectedTab == tab_LongOrder)
            {
                //更新失败
                if (!long_order_prt.UpdatePrtStatus(_PatlistID, 0, validpages))
                    MessageBox.Show("医嘱打印状态更新失败，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tpg_Order.SelectedTab == tab_TempOrder)
            {
                if (!tmp_order_prt.UpdatePrtStatus(_PatlistID, 1, validpages))
                    MessageBox.Show("医嘱打印状态更新失败，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.FormLoad();
        }
        #endregion

        #region 打印预览
        private void btn_PrtPreview_Click(object sender, EventArgs e)
        {

            PrintDocument OrderPrtDoc = new PrintDocument();
            PrintPreviewDialog prtPreDia = new PrintPreviewDialog();

            try
            {
                if (tpg_Order.SelectedTab == tab_LongOrder)
                {
                    //获取需要打印的长嘱列表
                    dtprt = long_order_prt.GetLongOrderListToPrt();
                    firstpage = long_order_prt.FirstPage;
                    lastpage = long_order_prt.LastPage;
                    currpage = firstpage;
                    OrderPrtDoc.PrintPage += new PrintPageEventHandler(LongOrderPrt_PrintPage);
                }
                else
                {
                    //获取需要打印的临时列表
                    dtprt = tmp_order_prt.GetTmpOrderListToPrt();
                    firstpage = tmp_order_prt.FirstPage;
                    lastpage = tmp_order_prt.LastPage;
                    currpage = firstpage;
                    //if (dt.Select("PAGENP=" + currpage).Length > 0)
                    OrderPrtDoc.PrintPage += new PrintPageEventHandler(TmpOrderPrt_PrintPage);
                }

                prtPreDia.Document = OrderPrtDoc;
                prtPreDia.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

        #region 退出
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
