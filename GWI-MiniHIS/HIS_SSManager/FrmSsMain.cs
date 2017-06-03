using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;


namespace HIS_SSManager
{
    public partial class FrmSsMain : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;
        private Deptment _currentDept;
        bool firstLoad = true;
        bool firstLoadArrange = true;
        private HIS.Model.SS_APPLY ssapplypat  //* 20100517.0.01  手术麻醉主界面必须先选中病人才能操作
        {
            get
            {
                if (tabSsPlist.SelectedIndex == 0 && listView1.SelectedItems.Count >0) return (HIS.Model.SS_APPLY)listView1.SelectedItems[0].Tag;
                else if (tabSsPlist.SelectedIndex == 1 && listView2.SelectedItems.Count>0l) return (HIS.Model.SS_APPLY)listView2.SelectedItems[0].Tag;
                else return null;
            }
        }
        public FrmSsMain(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            Init(false);
            firstLoad = false;
        } 

        //得到未安排病人
        private void Init(bool isarrange)
        { 
            HIS.SS_BLL.SsInfo ssinfo=new HIS.SS_BLL.SsInfo ();
            List<HIS.Model.SS_APPLY> sspatlist = ssinfo.GetSsPatInfo(isarrange, Convert.ToInt32(_currentDept.DeptID));
            if (sspatlist == null || sspatlist.Count == 0)
            {
                if (isarrange)
                {
                    listView2.Items.Clear();
                }
                else
                {
                    listView1.Items.Clear();
                }
                return;
            }
            DisPlay(sspatlist, isarrange);
        }
        #region 病人列表显示
     /// <summary>
     /// 病人列表显示
     /// </summary>
     /// <param name="sspatlist"></param>
     /// <param name="isarrange"></param>
        private void DisPlay(List<HIS.Model.SS_APPLY> sspatlist, bool isarrange)
        {
            int index;
            if (!isarrange)
            {
                listView1.Items.Clear();
            }
            else
            {
                listView2.Items.Clear();
            }
            for (int i = 0; i < sspatlist.Count; i++)
            {
                if (sspatlist[i].Zy_Patlist.PatientInfo.PatSex.ToString().Trim() == "男")
                {
                    index = 0;
                }
                else
                {
                    index = 1;
                }
                if (!isarrange)
                {                   
                    this.listView1.Items.Add("" + sspatlist[i].Zy_Patlist.PatientInfo.PatName + "(" + sspatlist[i].Zy_Patlist.PatientInfo.ACCOUNTTYPE + ")\r\n" + 
                                          sspatlist[i].TEND_OPERA, index).Tag = sspatlist[i];
                }
                else
                {                    
                    this.listView2.Items.Add("" + sspatlist[i].Zy_Patlist.PatientInfo.PatName + "(" + sspatlist[i].Zy_Patlist.PatientInfo.ACCOUNTTYPE + ")\r\n" +
                                          sspatlist[i].TEND_OPERA, index).Tag = sspatlist[i];
                }
            }
        }
        #endregion     

        private void tabSsPlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSsPlist.SelectedIndex == 0)
            {
                tbAfter.Visible = false;
                tbCancelArrange.Visible = false;
                contextMenuStrip1.Items[1].Visible = false;
                contextMenuStrip1.Items[3].Visible = false;
                contextMenuStrip1.Items[2].Visible = false;
                tbPres.Visible = false;
                if (firstLoad)
                {
                    Init(false);
                    firstLoad = false;
                }
            }
            if (tabSsPlist.SelectedIndex == 1)
            {
                tbAfter.Visible = true;
                tbCancelArrange.Visible = true;
                contextMenuStrip1.Items[1].Visible = true ;
                contextMenuStrip1.Items[3].Visible = true ;
                contextMenuStrip1.Items[2].Visible = true;
                tbPres.Visible = true;
                if (firstLoadArrange)
                {
                    Init(true);
                    firstLoadArrange = false;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSsPlist.SelectedIndex == 0)
            {
                if (listView1.SelectedItems.Count > 0)
                {                  
                    PatientControl patient = new PatientControl();                 
                    this.inPatientPanel1.InPaitent = patient.SetData(ssapplypat.Zy_Patlist);
                }

            }
            else
            {
                if (listView2.SelectedItems.Count > 0)
                {                
                   PatientControl patient = new PatientControl();
                    this.inPatientPanel1.InPaitent = patient.SetData(ssapplypat.Zy_Patlist);
                }
            }

        }

        #region 按钮事件
        private void FrmSsMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:	//手术安排
                    tbArrange_Click(null, null);
                    break;
                case Keys.F3:	//术后补录
                    tbAfter_Click(null, null);
                    break;
                case Keys.F4:	//账单补录
                    tbPres_Click(null, null);
                    break;
                case Keys.F5:	//取消安排
                    tbCancelArrange_Click(null, null);
                    break;
                case Keys.F6:	//刷新
                    tbBrush_Click(null, null);
                    break;
                case Keys.F7:	//退出
                    this.Close();
                    break;               
                default:
                    break;
            }
        }
        //手术安排
        private void tbArrange_Click(object sender, EventArgs e)
        {
            if (ssapplypat == null)
            {
                return;
            }
            FrmSsArrange arange = new FrmSsArrange(ssapplypat, Convert.ToInt32(_currentUser.EmployeeID));
            arange.ShowDialog();
            tbBrush_Click(null, null);
            firstLoadArrange = true;
        }
         //术后补录
        private void tbAfter_Click(object sender, EventArgs e)
        {
            if (ssapplypat == null)
            {
                return;
            }
            FrmAfterSs after = new FrmAfterSs(ssapplypat,Convert.ToInt32( _currentUser.EmployeeID));
            after.ShowDialog();
            tbBrush_Click(null, null);
        }
        //账单补录
        private void tbPres_Click(object sender, EventArgs e)
        {
            if (ssapplypat != null)
            {
                HIS_ZYManager.FrmPresManager frmpres = new HIS_ZYManager.FrmPresManager(_currentUser.UserID, _currentDept.DeptID,
                    "账单补录", 1, this.inPatientPanel1.InPaitent.InpitentNo);
                frmpres.WindowState = FormWindowState.Maximized;
                ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmpres);
                frmpres.Show();
            }

        }
        // 刷新
        private void tbBrush_Click(object sender, EventArgs e)
        {
            if (tabSsPlist.SelectedIndex == 0)
            {
                Init(false);
            }
            if (tabSsPlist.SelectedIndex == 1)
            {
                Init(true);
            }
        }
        //退出
        private void tbQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //取消安排
        private void tbCancelArrange_Click(object sender, EventArgs e)
        {
            if (ssapplypat == null)
            {
                return;
            }
            if (MessageBox.Show("确定要取消安排吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            HIS.SS_BLL.SsArrange arrange=new HIS.SS_BLL.SsArrange ();
            if (arrange.CancelArrange(ssapplypat))
            {
                MessageBox.Show("取消安排成功");
                tbBrush_Click(null, null);
                firstLoad = true;
            }
        }
        #endregion

        #region 右键按钮
        private void 手术安排ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbArrange_Click(null, null);
        }

        private void 术后补录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbAfter_Click(null, null);
        }

        private void 账单补录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbPres_Click(null, null);
        }

        private void 取消安排ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbCancelArrange_Click(null, null);
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbBrush_Click(null, null);
        }
        #endregion
       
    }
}
