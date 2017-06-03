using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtilityLibrary.WinControls;
using UtilityLibrary.General;
using System.Reflection;
using System.Resources;
using System.Net;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using HIS.SYSTEM.PubicBaseClasses;
using System.IO;
using GWMHIS.BussinessLogicLayer.Classes;



namespace HIS_ZYDocManager.日常业务
{
    public partial class FrmDocMain : GWI.HIS.Windows.Controls.BaseMainForm
    {
        ImageList outlookLargeIcons = null;
        ResourceManager rmListImages = null;
        private User _currentUser;
        private Deptment _currentDept;
        private HIS.Model.ZY_PatList patlist;
        private bool FirstBrushBR = true;
        private bool FirstBrushDept = true;
        List<HIS.Model.ZY_PatList> zypatlist;
        List<HIS.Model.ZY_PatList> zypatlistall;
        string patbeds = "";        

        public User currentUser
        {
            get
            {
                return _currentUser;
            }
        }
        public Deptment currentDept
        {
            get
            {
                return _currentDept;
            }
        }     
        public FrmDocMain(long currentUserId, long currentDeptId, string chineseName)
        {
            Assembly thisAssemble = Assembly.GetAssembly(System.Type.GetType("HIS_ZYDocManager.日常业务.FrmDocMain"));
            rmListImages = new ResourceManager("HIS_ZYDocManager.Resources.IconImages", thisAssemble);
            outlookLargeIcons = new ImageList();
            outlookLargeIcons.ImageSize = new Size(32, 32);
            Bitmap icons = (Bitmap)rmListImages.GetObject("OutlookLargeIcons");
            icons.MakeTransparent(Color.FromArgb(255, 0, 255));
            outlookLargeIcons.Images.AddStrip(icons);
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;

            //创建功能菜单
            InitializeOutlookBar();
            this.tabPageControl1.SelectedIndex = 0;
            zypatlist = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetInBedPatList(0, Convert.ToInt32(_currentUser.EmployeeID), Convert.ToInt32(_currentDept.DeptID));
            if (zypatlist == null || zypatlist.Count == 0)
            {
                return;
            }
            this.listView1.Items.Clear();
            this.DisPlay(zypatlist, 0);
            this.FirstBrushBR = false;
            lbts.Visible = false;
            lbbeds.Visible = false;        

        }

        #region OUTLOOK CONTROL的代码
        void InitializeOutlookBar()
        {
            //创建功能菜单
            OutlookBarBand outlookShortcutsBand;
            outlookShortcutsBand = new OutlookBarBand("诊疗管理");
            outlookShortcutsBand.LargeImageList = this.baseImageList;
            outlookShortcutsBand.Items.Add(new OutlookBarItem("医嘱管理", 7));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("手术申请", 10));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("手术查询", 12));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("检查申请", 9));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("检验申请", 11));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("治疗申请", 6));
            outlookShortcutsBand.Background = Color.DarkSlateBlue;
            outlookShortcutsBand.TextColor = Color.White;
            outlookBar1.Bands.Add(outlookShortcutsBand);
            OutlookBarBand outlookShortcutsBand1;
            outlookShortcutsBand1 = new OutlookBarBand("查询功能");
            outlookShortcutsBand1.LargeImageList = this.baseImageList;
            outlookShortcutsBand1.Items.Add(new OutlookBarItem("住院病人信息统计", 9));
           
            outlookShortcutsBand1.Items.Add(new OutlookBarItem("医生工作量统计", 6));
            outlookShortcutsBand1.Background = Color.DarkSlateGray;
            outlookShortcutsBand1.TextColor = Color.White;
            outlookBar1.Bands.Add(outlookShortcutsBand1);
            OutlookBarBand outlookShortcutsBand3 = new OutlookBarBand("常用工具");
            outlookShortcutsBand3.LargeImageList = outlookLargeIcons;
            outlookShortcutsBand3.Items.Add(new OutlookBarItem("计算器", 0));
            outlookShortcutsBand3.Items.Add(new OutlookBarItem("画笔", 1));
            outlookShortcutsBand3.Items.Add(new OutlookBarItem("图象处理", 2));
            outlookShortcutsBand3.Items.Add(new OutlookBarItem("记事本", 3));
            outlookShortcutsBand3.Items.Add(new OutlookBarItem("写字板", 4));
            outlookShortcutsBand3.Items.Add(new OutlookBarItem("通讯簿", 5));
            outlookShortcutsBand3.Background = SystemColors.ControlDarkDark;
            outlookShortcutsBand3.TextColor = Color.White;
            outlookBar1.Bands.Add(outlookShortcutsBand3);
            //添加控件的单击事件和设置字体
            outlookBar1.ItemClicked += new OutlookBarItemClickedHandler(OnOutlookBarItemClicked);
            outlookBar1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            //控制控件的停靠
            outlookBar1.Dock = System.Windows.Forms.DockStyle.Left;
        }
        #endregion

        #region 功能菜单的实现
        void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            if (this.listView1.FocusedItem == null && listView2.FocusedItem == null
                && (item.Text == "医嘱管理" || item.Text == "检查申请" || item.Text == "检验申请" || item.Text == "治疗申请" || item.Text == "护理信息"))
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            switch (item.Text)
            {
                case "医嘱管理":
                    this.Cursor = PublicStaticFun.WaitCursor();
                    HIS_ZYDocManager.日常业务.BaseForm form = new BaseForm(patlist, _currentUser.UserID, _currentDept.DeptID);
                    form.MdiParent = this.MdiParent;
                    form.WindowState = FormWindowState.Maximized;
                    ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(form);
                    form.Show();
                    this.Cursor = Cursors.Default;
                    break;
                case "手术申请":
                    if (HIS.ZYDoc_BLL.PatInfo.PatOperation.NotCanUpdate(patlist))  //20100518.0.03  病人定义出院后，不能再进行手术申请
                    {
                        MessageBox.Show("该病人已定义出院，不能再进行手术申请");
                        return;
                    }
                    FrmSsApply fss = new FrmSsApply(patlist,_currentUser.UserID,_currentDept.DeptID);
                    fss.ShowDialog();
                    break;
                case "手术查询":
                    FrmSsQuery fsq = new FrmSsQuery();
                    fsq.ShowDialog();
                    break;       
                case "检验申请":
                    FrmTestApply fta = new FrmTestApply(patlist, _currentUser.UserID, _currentDept.DeptID);
                    fta.ShowDialog();
                    break;
                case "检查申请":
                    FrmCheckApply fca = new FrmCheckApply(patlist, _currentUser.UserID, _currentDept.DeptID);
                    fca.ShowDialog();
                    break;
                case "治疗申请":
                    FrmCureApply fc = new FrmCureApply(patlist, _currentUser.UserID, _currentDept.DeptID);
                    fc.ShowDialog();
                    break;
                case "住院病人信息统计":                  
                    HIS_ZYDocManager.查询统计.FrmPatientInfo rpt = new HIS_ZYDocManager.查询统计.FrmPatientInfo(_currentUser.UserID, _currentDept.DeptID, this.Text);
                    rpt.ShowDialog();
                    break;
                case "医生工作量统计":
                    HIS_ZYDocManager.查询统计.FrmDocWorkQuery work = new HIS_ZYDocManager.查询统计.FrmDocWorkQuery(_currentUser.UserID, _currentDept.DeptID, "");
                    work.ShowDialog();
                    break;
                case "计算器":
                    System.Diagnostics.Process.Start("calc.exe");
                    break;
                case "画笔":
                    System.Diagnostics.Process.Start("mspaint.exe");
                    break;
                case "通讯簿":
                    System.Diagnostics.Process.Start("wab.exe");
                    break;
                case "记事本":
                    System.Diagnostics.Process.Start("notepad.exe");
                    break;
                case "写字板":
                    System.Diagnostics.Process.Start("wordpad.exe");
                    break;
                case "图象处理":
                    System.Diagnostics.Process.Start("kodakimg.exe");
                    break;
                default:
                    break;
            }
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        #endregion

        #region 事件
        /// <summary>
        /// 选择病人头像事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.FocusedItem == null && listView2.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tabPageControl1.SelectedIndex == 0)
            {
                patlist = (HIS.Model.ZY_PatList)this.listView1.FocusedItem.Tag;
            }
            else
            {
                patlist = (HIS.Model.ZY_PatList)this.listView2.FocusedItem.Tag;
            }
            this.Cursor = PublicStaticFun.WaitCursor();
            HIS_ZYDocManager.日常业务.BaseForm form = new BaseForm(patlist, _currentUser.UserID, _currentDept.DeptID);
            form.MdiParent = this.MdiParent;
            form.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(form);
            form.Show();
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// 选项改变时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPageControl1.SelectedIndex == 0)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    patlist = (HIS.Model.ZY_PatList)listView1.SelectedItems[0].Tag;
                    HIS_ZYDocManager.PatientControl patient = new PatientControl();
                    this.inPatientPanel1.InPatientExtDB = patient.SetData(patlist);
                }

            }
            else
            {
                if (listView2.SelectedItems.Count > 0)
                {
                    patlist = (HIS.Model.ZY_PatList)listView2.SelectedItems[0].Tag;
                    HIS_ZYDocManager.PatientControl patient = new PatientControl();
                    this.inPatientPanel1.InPatientExtDB = patient.SetData(patlist);
                }
            }

        }

        private void tabPageControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPageControl1.SelectedIndex == 0) //管辖内病人
            {
                if (FirstBrushBR)
                {
                    this.lbts.Visible = false;
                    this.lbbeds.Visible = false;
                    zypatlist = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetInBedPatList(0, Convert.ToInt32(_currentUser.EmployeeID), Convert.ToInt32(_currentDept.DeptID));
                    if (zypatlist == null || zypatlist.Count == 0)
                    {
                        return;
                    }
                    this.listView1.Items.Clear();
                    this.DisPlay(zypatlist, 0);
                    lbts.Visible = false;
                    lbbeds.Visible = false;
                   // this.ThreadCreate();
                    FirstBrushBR = false;
                }
                else
                {
                    if (lbbeds.Text != "0")
                    {
                        this.lbts.Visible = true;
                        this.lbbeds.Visible = true;
                    }
                }
            }
            if (tabPageControl1.SelectedIndex == 1) //本科室病人
            {
                if (FirstBrushDept)
                {
                    this.lbts.Visible = false;
                    this.lbbeds.Visible = false;
                    zypatlistall = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetInBedPatList(1, Convert.ToInt32(_currentDept.DeptID), Convert.ToInt32(_currentDept.DeptID));
                    if (zypatlistall == null || zypatlistall.Count == 0)
                    {
                        return;
                    }
                    this.listView2.Items.Clear();
                    this.DisPlay(zypatlistall, 1);
                    lbts.Visible = false;
                    lbbeds.Visible = false;
                 //   this.ThreadCreateAll();
                    FirstBrushDept = false;
                }
                if (lbbeds.Text != "0")
                {
                    this.lbts.Visible = true;
                    this.lbbeds.Visible = true;
                }

            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.panel1.Height = this.inPatientPanel1.Height;
        }
        #endregion

        #region  右键菜单
        private void 医嘱录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.FocusedItem == null && listView2.FocusedItem == null)
            {
                MessageBox.Show("没有选择病人");
                return;
            }
            this.Cursor = PublicStaticFun.WaitCursor();
            HIS_ZYDocManager.日常业务.BaseForm form = new BaseForm(patlist, _currentUser.UserID, _currentDept.DeptID);
            form.MdiParent = this.MdiParent;
            form.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(form);
            form.Show();
            this.Cursor = Cursors.Default;
        }

        private void 检查申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.FocusedItem == null && listView2.FocusedItem == null)
            {
                MessageBox.Show("没有选择病人");
                return;
            }
            FrmCheckApply fca = new FrmCheckApply(patlist, _currentUser.UserID, _currentDept.DeptID);
            fca.ShowDialog();
        }

        private void 检验申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.FocusedItem == null && listView2.FocusedItem == null)
            {
                MessageBox.Show("没有选择病人");
                return;
            }
            FrmTestApply fta = new FrmTestApply(patlist, _currentUser.UserID, _currentDept.DeptID);
            fta.ShowDialog();
        }

        private void 治疗申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.FocusedItem == null && listView2.FocusedItem == null)
            {
                MessageBox.Show("没有选择病人");
                return;
            }
            FrmCureApply fc = new FrmCureApply(patlist, _currentUser.UserID, _currentDept.DeptID);
            fc.ShowDialog();
        }

        private void 手术申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSsApply fss = new FrmSsApply(patlist, _currentUser.UserID, _currentDept.DeptID);
            fss.ShowDialog();
        } 

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabPageControl1.SelectedIndex == 0) //管辖内病人
            {
                this.lbts.Visible = false;
                this.lbbeds.Visible = false;
                this.listView1.Items.Clear();
                zypatlist = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetInBedPatList(0, Convert.ToInt32(_currentUser.EmployeeID), Convert.ToInt32(_currentDept.DeptID));
                if (zypatlist == null || zypatlist.Count == 0)
                {
                    return;
                }                
                this.DisPlay(zypatlist, 0);
                lbts.Visible = false;
                lbbeds.Visible = false;             
            }
            if (tabPageControl1.SelectedIndex == 1) //本科室病人
            {
                this.lbts.Visible = false;
                this.lbbeds.Visible = false;
                this.listView2.Items.Clear();
                zypatlist = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetInBedPatList(1, Convert.ToInt32(_currentDept.DeptID), Convert.ToInt32(_currentDept.DeptID));
                if (zypatlist == null || zypatlist.Count == 0)
                {
                    return;
                }               
                this.DisPlay(zypatlist, 1);
                lbts.Visible = false;
                lbbeds.Visible = false;             
            }
        }
        #endregion       

        #region 病人列表显示
        /// <summary>
        /// 病人列表显示
        /// </summary>
        /// <param name="zypatlist"></param>
        /// <param name="sign">0=管辖内病人显示　1＝本科室病人显示</param>
        private void DisPlay(List<HIS.Model.ZY_PatList> zypatlist, int sign)
        {
            int index;
            for (int i = 0; i < zypatlist.Count; i++)
            {
                if (zypatlist[i].PatientInfo.PatSex.ToString().Trim() == "男")
                {
                    if (zypatlist[i].PatType=="7" || HIS.ZYDoc_BLL.PatInfo.PatOperation.IsTurnDept(zypatlist[i].PatListID))
                    {
                        index = 2;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else
                {
                    if (zypatlist[i].PatType == "7" || HIS.ZYDoc_BLL.PatInfo.PatOperation.IsTurnDept(zypatlist[i].PatListID))
                    {
                        index = 3;
                    }
                    else
                    {
                        index = 1;
                    }
                }
                if (sign == 0)
                {
                    this.listView1.Items.Add("" + zypatlist[i].BedCode + "(" + zypatlist[i].PatientInfo.ACCOUNTTYPE + ")\r\n" + zypatlist[i].PatientInfo.PatName, index).Tag = zypatlist[i];
                }
                if (sign == 1)
                {
                    this.listView2.Items.Add("" + zypatlist[i].BedCode + "(" + zypatlist[i].PatientInfo.ACCOUNTTYPE + ")\r\n" + zypatlist[i].PatientInfo.PatName, index).Tag = zypatlist[i];
                }
            }
        }
        #endregion      
       
        #region 管辖内病人查询
        private void FindStoreNum()
        {
            HIS.ZYDoc_BLL.BaseInfo.DrugBase drugbase = new HIS.ZYDoc_BLL.BaseInfo.DrugBase();
            patbeds = "";             
            patbeds = drugbase.FindStorNums(zypatlist);
            if (patbeds != "")
            {
                lbts.Visible = true;
                this.lbbeds.Text = patbeds;
                lbbeds.Visible = true;
            }
        }
        #endregion   
            
        private void LableFind_Click(object sender, EventArgs e)
        {
            this.FindStoreNum();
        }

             

    }
}
