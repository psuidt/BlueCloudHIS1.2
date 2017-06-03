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

namespace HIS_ZYNurseManager
{
    /// <summary>
    /// 患者出区
    /// </summary>
    public partial class FrmPatOut : GWI.HIS.Windows.Controls.BaseMainForm
    {
        #region 变量与构造函数
      
        int patlistid;    //病人每次住院ID
        int orderid;     //医嘱ID
        int transdeptid; //转科表ID
        string errorMsg; //错误消息
        string unsettled;//未处理项目
        string getdept;  //转科的目标科室
        DataTable dt;
        Patient currentpat;//当前选定的患者        
        ApplyIInPatient inpatient;//患者信息栏对应的类
        OP_PatientOut op_patientout = new OP_PatientOut();//患者出院业务类
        
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
        public FrmPatOut()
        {
            InitializeComponent();
            this.frmload();
        }
        /// <summary>
        /// 带参数构造方法
        /// </summary>
        /// <param name="currentUserId">用户ID</param>
        /// <param name="currentDeptId">科室ID</param>
        /// <param name="chineseName">窗体标题</param>
        public FrmPatOut(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;           
            this.frmload();
        }        
        private void tabPageControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmload();
        }       
        /// <summary>
        /// 窗体加载方法
        /// </summary>
        public void frmload()
        {
            patlistid = 0;

            pnl_PatInfo.InPaitent = null;
            btn_Out.Visible = true;
            btn_CancelOut.Visible = true;
            btn_Out.Text = tabPageControl1.SelectedTab.Text;
            btn_CancelOut.Text = "取消" + tabPageControl1.SelectedTab.Text;
            dgv_Leave.AutoGenerateColumns = dgv_Transfer.AutoGenerateColumns = dgv_Left.AutoGenerateColumns = false;

            #region 根据选定的选项卡加载数据
            switch (tabPageControl1.SelectedTab.Name)
            {
                case ("tab_Leave"):
                    {
                        SelectLeaveTab();
                        break;
                    }
                case ("tab_Transfer"):
                    {
                        SelectTransferTab();
                        break;
                    }
                case ("tab_Left"):
                    {
                        SelectLeftTab();
                        break;
                    }
                default:
                    return;
            }
            #endregion
        }
        #endregion

        #region 选项卡切换
        /// <summary>
        /// 选择已出院患者选项卡
        /// </summary>
        private void SelectLeftTab()
        {
            btn_CancelOut.Visible = false;
            btn_Out.Visible = false;
            dgv_Left.DataSource = op_patientout.listPatient_Left(_currentDept.DeptID);
            dt = (DataTable)dgv_Left.DataSource;
            if (dt != null && dt.Rows.Count > 0)
            {
                patlistid = Convert.ToInt32(dt.Rows[0]["patlistid"].ToString());
                inpatient = new ApplyIInPatient(patlistid);
                pnl_PatInfo.InPaitent = inpatient;
            }
        }       
        /// <summary>
        /// 选择转科选项卡
        /// </summary>
        private void SelectTransferTab()
        {
            if (dt != null)
                dt.Clear();
            dgv_Transfer.DataSource = op_patientout.listPatient_Transfer(_currentDept.DeptID);
            dt = (DataTable)dgv_Transfer.DataSource;
            //如果列表中有数据，则按钮可用，并获取第一行的患者信息
            if (dt == null || dt.Rows.Count == 0)
            {
                btn_Out.Enabled = false;
                btn_CancelOut.Enabled = false;
            }
            else
            {
                btn_Out.Enabled = true;
                btn_CancelOut.Enabled = true;
                patlistid = Convert.ToInt32(dt.Rows[0]["TranPatlistID"].ToString());
                getdept = dt.Rows[0]["TranGetDept"].ToString();
                transdeptid = Convert.ToInt32(dt.Rows[0]["TranID"].ToString());
                inpatient = new ApplyIInPatient(patlistid);
                pnl_PatInfo.InPaitent = inpatient;
            }
        }      
        /// <summary>
        /// 选择定义出院选项卡
        /// </summary>
        private void SelectLeaveTab()
        {
            if (dt != null)
                dt.Clear();
            dgv_Leave.DataSource = op_patientout.listPatient_Leave(_currentDept.DeptID);
            dt = (DataTable)dgv_Leave.DataSource;
            //如果列表中有数据，则按钮可用，并获取第一行的患者信息
            if (dt == null || dt.Rows.Count == 0)
            {
                btn_Out.Enabled = false;
                btn_CancelOut.Enabled = false;
            }
            else
            {
                btn_Out.Enabled = true;
                btn_CancelOut.Enabled = true;
                patlistid = Convert.ToInt32(dt.Rows[0]["patlistid"].ToString());
                inpatient = new ApplyIInPatient(patlistid);
                pnl_PatInfo.InPaitent = inpatient;
            }
        }
        #endregion

        #region 行选择 
        //dgv_Leave的单元格单击事件，病人每次住院ID
        private void dgv_Leave_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dt = (DataTable)dgv_Leave.DataSource;
            int rownum = dgv_Leave.CurrentCell.RowIndex;
            patlistid = Convert.ToInt32(dt.Rows[rownum]["patlistid"].ToString());
            inpatient = new ApplyIInPatient(patlistid);
            pnl_PatInfo.InPaitent = inpatient;
        }   
        //dgv_Transfer的单元格单击事件，点击后获取转科病人住院ID、目标科室和转科表ID
        private void dgv_Transfer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dt = (DataTable)dgv_Transfer.DataSource;
            int rownum = dgv_Transfer.CurrentCell.RowIndex;
            patlistid = Convert.ToInt32(dt.Rows[rownum]["TranPatlistID"].ToString());
            getdept = dt.Rows[rownum]["TranGetDept"].ToString();
            transdeptid = Convert.ToInt32(dt.Rows[rownum]["TranID"].ToString());
            inpatient = new ApplyIInPatient(patlistid);
            pnl_PatInfo.InPaitent = inpatient;
        }       
        //dgv_Left的单元格单击事件，点击后获取病人住院ID
        private void dgv_Left_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dt = (DataTable)dgv_Left.DataSource;
            int rownum = dgv_Left.CurrentCell.RowIndex;
            patlistid = Convert.ToInt32(dt.Rows[rownum]["patlistid"].ToString());
            inpatient = new ApplyIInPatient(patlistid);
            pnl_PatInfo.InPaitent = inpatient;
        }
        #endregion   

        #region 出区按钮单击事件
        private void btn_Out_Click(object sender, EventArgs e)
        {
            string strconfirm;//确认出区信息
            errorMsg = "";
            unsettled = "";

            if (patlistid == 0)//是否选择患者
            {
                MessageBox.Show(this, "未选择患者", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentpat = new Patient(patlistid);
            if (!op_patientout.MayLeave(patlistid, out errorMsg, out unsettled))//是否有未停医嘱，未记账费用
            {
                string strtmp = tabPageControl1.SelectedTab.Text;
                MessageBox.Show(errorMsg + strtmp + unsettled, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string UnProvideItems = op_patientout.UnProvide(patlistid);  //判断是否有未发药品
            if (UnProvideItems != "")
            {
                MessageBox.Show("该病人“" + currentpat.patname + "”【有未发药品，请及时统领以下药品】：" + UnProvideItems, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (OP_Config.GetValue("001") == 1)    //001表示未发药是否能够定义出院，返回0表示能，返回1表示不能
                    return;
            }

            string UnWithDrawalItems = op_patientout.UnWithDrawal(patlistid);//判断是否有未退药品
            if (UnWithDrawalItems != "")
            {
                MessageBox.Show("该病人“" + currentpat.patname + "”有未退药品！未退药品如下：" + UnWithDrawalItems, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (OP_Config.GetValue("002") == 1)   //001表示未退药是否能够定义出院，返回0表示能，返回1表示不能
                    return;
            }

            //定义出院要判断患者是否在床，以及是否处于出院结算状态
            if (tabPageControl1.SelectedTab == tab_Leave)
            {
                errorMsg = "";
                if (op_patientout.isOnbed(patlistid)) //病人是否在床
                {
                    errorMsg = "对不起，病人“" + currentpat.patname + "”还未开出院医嘱！";
                }
                else if (op_patientout.isOnbalance(patlistid))//结算中，已出院
                {
                    errorMsg = "对不起，病人“" + currentpat.patname + "”已经定义出院！";
                }
                if (errorMsg != "")
                {
                    MessageBox.Show(errorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                strconfirm = "确认“" + currentpat.patname + "”定义出院吗？";
                if (MessageBox.Show(this, strconfirm, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }
                DataTable dtPresorder = op_patientout.getDtPresorder(patlistid);//出院操作
                if (dtPresorder.Rows.Count != 0)//未统领药品进统领单
                {
                    List<string[]> depts = new List<string[]>();
                    for (int n = 0; n < dtPresorder.Rows.Count; n++)
                    {
                        if (depts.Exists(x => x[0] == dtPresorder.Rows[n]["presdeptcode"].ToString().Trim() && x[1] == dtPresorder.Rows[n]["execdeptcode"].ToString().Trim()) == false)
                        {
                            depts.Add(new string[] { dtPresorder.Rows[n]["presdeptcode"].ToString().Trim(), dtPresorder.Rows[n]["execdeptcode"].ToString().Trim() });
                        }
                    }

                    for (int m = 0; m < depts.Count; m++)
                    {
                        OP_SendDrugMessage op_sendDrugMessage = new OP_SendDrugMessage();
                        DateTime sendtime = XcDate.ServerDateTime;
                        int masterid = op_sendDrugMessage.InsertDrugMaster(sendtime, currentUser.UserID, currentUser.Name, depts[m][0], depts[m][1]);
                        for (int i = 0; i < dtPresorder.Rows.Count; i++)
                        {
                            if (dtPresorder.Rows[i]["presdeptcode"].ToString().Trim() == depts[m][0] && dtPresorder.Rows[i]["execdeptcode"].ToString().Trim() == depts[m][1])
                            {
                                op_sendDrugMessage.InsertDrugMessageRecord(Convert.ToInt32(dtPresorder.Rows[i]["presorderid"]), masterid);
                            }
                        }
                    }
                }
                DataTable dtDBPresorder = op_patientout.getDrawBackDtPresorder(patlistid);
                if (dtDBPresorder.Rows.Count != 0)
                {
                    List<string[]> depts = new List<string[]>();
                    for (int n = 0; n < dtDBPresorder.Rows.Count; n++)
                    {
                        if (depts.Exists(x => x[0] == dtDBPresorder.Rows[n]["presdeptcode"].ToString().Trim() && x[1] == dtDBPresorder.Rows[n]["execdeptcode"].ToString().Trim()) == false)
                        {
                            depts.Add(new string[] { dtDBPresorder.Rows[n]["presdeptcode"].ToString().Trim(), dtDBPresorder.Rows[n]["execdeptcode"].ToString().Trim() });
                        }
                    }
                    for (int m = 0; m < depts.Count; m++)
                    {
                        OP_SendDrugMessage op_sendDrugMessage = new OP_SendDrugMessage();//未退药品进统领单
                        DateTime sendtime = XcDate.ServerDateTime;
                        int masterid = op_sendDrugMessage.InsertDBDrugMaster(sendtime, currentUser.UserID, currentUser.Name, depts[m][0], depts[m][1]);
                        for (int i = 0; i < dtDBPresorder.Rows.Count; i++)
                        {
                            if (dtDBPresorder.Rows[i]["presdeptcode"].ToString().Trim() == depts[m][0] && dtDBPresorder.Rows[i]["execdeptcode"].ToString().Trim() == depts[m][1])
                            {
                                op_sendDrugMessage.InsertDBDrugMessageRecord(Convert.ToInt32(dtDBPresorder.Rows[i]["presorderid"]), masterid);
                            }
                        }
                    }
                }
                op_patientout.ApplyLeave(Convert.ToInt32(patlistid), Convert.ToInt32(_currentUser.UserID), out errorMsg);//出区操作
            }
            //病人转科操作
            else if (tabPageControl1.SelectedTab == tab_Transfer)
            {
                strconfirm = "确认“" + currentpat.patname + "”转到“" + BaseData.GetDeptName(getdept) + "”吗？";
                //是否确认转科
                DateTime ServerDate = XcDate.ServerDateTime.AddDays(1);
                bool IsCanTransDept = op_patientout.TorrowDrug(patlistid, ServerDate);
                if (IsCanTransDept == true)
                {
                    if (MessageBox.Show(this, strconfirm, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    //DataTable dtPresorder = op_patientout.getDtPresorder(patlistid);//出院操作
                    //if (dtPresorder.Rows.Count != 0)//未统领药品进统领单
                    //{
                    //    OP_SendDrugMessage op_sendDrugMessage = new OP_SendDrugMessage();
                    //    DateTime sendtime = XcDate.ServerDateTime;
                    //    int masterid = op_sendDrugMessage.InsertDrugMaster(sendtime, currentUser.UserID, currentUser.Name);
                    //    for (int i = 0; i < dtPresorder.Rows.Count; i++)
                    //    {
                    //        op_sendDrugMessage.InsertDrugMessageRecord(Convert.ToInt32(dtPresorder.Rows[i]["presorderid"]), masterid);
                    //    }
                    //}
                    //DataTable dtDBPresorder = op_patientout.getDrawBackDtPresorder(patlistid);
                    //if (dtDBPresorder.Rows.Count != 0)
                    //{
                    //    OP_SendDrugMessage op_sendDrugMessage = new OP_SendDrugMessage();//未退药品进统领单
                    //    DateTime sendtime = XcDate.ServerDateTime;
                    //    int masterid = op_sendDrugMessage.InsertDBDrugMaster(sendtime, currentUser.UserID, currentUser.Name);
                    //    for (int i = 0; i < dtDBPresorder.Rows.Count; i++)
                    //    {
                    //        op_sendDrugMessage.InsertDBDrugMessageRecord(Convert.ToInt32(dtDBPresorder.Rows[i]["presorderid"]), masterid);
                    //    }
                    //}
                }
                op_patientout.ApplyTransfer(patlistid, Convert.ToInt32(_currentUser.UserID), transdeptid, getdept, out errorMsg);

                if (errorMsg != "")
                {
                    MessageBox.Show(errorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(tabPageControl1.SelectedTab.Text + "操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessagePromptManager.Messenger senders = new MessagePromptManager.Messenger(_currentUser.UserID, _currentDept.DeptID, "");
                MessagePromptManager.Messenger receiver = new MessagePromptManager.Messenger(-1, -1, "");
                MessagePromptManager.Messages message = new MessagePromptManager.Messages("005", "病人定义出区", "已经成功办理了出区病人,姓名：" + currentpat.patname + "，住院号为：" + currentpat.cureno + "，请及时处理！");
                senders.SendMessage(receiver, message);
            }
            else
            {
                MessageBox.Show("该病人有明日药品费用，请将该部分费用冲正掉后再进行操作！");
            }

            //刷新界面
            this.frmload();

            #region 可以不停医嘱转科
            /*
            errorMsg = "";

            //判断是否选中患者
            if (patlistid == 0)
            {
                MessageBox.Show("您还未选择病人", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            //是否有未转抄医嘱
            if (op_patientout.hasUntranscribeOrder(patlistid))
            {
                errorMsg = "对不起，该病人有未转抄的医嘱，不允许转科！";
                MessageBox.Show(errorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //是否有未执行临时医嘱
            if(op_patientout.hasUndoTempOrder(patlistid))
            {
                errorMsg = "对不起，该病人有未执行的临时医嘱，不允许转科！";
                MessageBox.Show(errorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #region 是否执行长期医嘱
            //执行长期医嘱
            if (MessageBox.Show("是否运行执行长期医嘱？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (op_patientout.LongOrderStatus(patlistid) == 12 || op_patientout.LongOrderStatus(patlistid) == 112)
                {
                    errorMsg = "对不起，该病人有未执行的长期医嘱，不允许转科！";
                    MessageBox.Show(errorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    //今天无未执行的长嘱，进入下一个流程，无需代码段
                }
            }
            //不执行长期医嘱
            else
            {
                //不执行长期医嘱，直接进入下一个流程，无需代码段
            }

            #endregion

            //是否有未停长期账单
            if (op_patientout.hasUnstopLongTab(patlistid))
            {
                errorMsg = "对不起，该病人有未停止的长期账单，不允许转科！";
                MessageBox.Show(errorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //是否确定转科
            if (MessageBox.Show("确认“" + patname + "”转到“" + getdept + "”吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }

            op_patientout.ApplyTransfer(patlistid, Convert.ToInt32(_currentUser.UserID), transdeptid, getdept, out errorMsg);

            if (errorMsg != "")
            {
                MessageBox.Show(errorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("转科操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.frmload();
            */
            #endregion
        }
        #endregion

        #region 取消出区按钮单击事件
        private void btn_CancelOut_Click(object sender, EventArgs e)
        {
            string strtabtitle = tabPageControl1.SelectedTab.Text;//选定的选项卡标题
            bool outorder;//是否有出区医嘱
            if (patlistid == 0)
            {
                MessageBox.Show("您还未选择病人", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //是否确定取消出区
            if (MessageBox.Show("取消" + strtabtitle + "，不会删除" + strtabtitle + "医嘱，请医生取消" + strtabtitle + "。\n该操作将把已转抄执行的" + strtabtitle + "医嘱恢复到未转抄状态，您确定吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }

            //获取出区（出院/死亡/转科）医嘱
            if (tabPageControl1.SelectedTab == tab_Leave)
            {
                outorder = !op_patientout.GetLeaveOrder(patlistid, out orderid, "出院");
                if (outorder)
                {
                    MessageBox.Show("没有" + strtabtitle + "医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmload();
                    return;
                }
                op_patientout.ApplyCancelLeave(patlistid, orderid, out errorMsg);//取消定义出院
            }
            else if (tabPageControl1.SelectedTab == tab_Transfer)
            {
                outorder = !op_patientout.GetLeaveOrder(patlistid, out orderid, "转科");
                if (outorder)
                {
                    MessageBox.Show("没有" + strtabtitle + "医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmload();
                    return;
                }
                op_patientout.ApplyCancelTran(patlistid, orderid, out errorMsg);
            }
            //出区操作失败提示
            if (errorMsg != "")
            {
                MessageBox.Show(errorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(strtabtitle + "医嘱恢复未转抄状态完成。", "完成提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.frmload();
        }
        #endregion

        #region 刷新
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            frmload();
        }
        #endregion
    }
}