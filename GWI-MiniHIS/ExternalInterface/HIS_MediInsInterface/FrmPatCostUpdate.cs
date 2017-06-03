using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GWMHIS.BussinessLogicLayer.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS_MediInsInterface.Action;


namespace HIS_MediInsInterface
{
    //zenghao [20100510.2.01]
    public partial class FrmPatCostUpdate : ZYBaseFrom, ICostUpdate
    {
        //线程外访问控件,更改控件值
        delegate void SetToolCallback(ToolStrip ts, bool b, ToolStripItem tsb);
        private void SetEnabled(ToolStrip ts, bool b, ToolStripItem tsb)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (ts.InvokeRequired)
            {
                SetToolCallback d = new SetToolCallback(SetEnabled);
                this.Invoke(d, new object[] { ts, b, tsb });
            }
            else
            {
                tsb.Enabled = b;
            }
        }
        delegate void SetMessageCallback(RichTextBox rtb, string value);
        private void SetMessageText(RichTextBox rtb, string value)
        {
            if (rtb.InvokeRequired)
            {
                SetMessageCallback sc = new SetMessageCallback(SetMessageText);
                this.Invoke(sc, new object[] { rtb, value });
            }
            else
            {
                rtb.AppendText(value);
            }
        }

        //上传状态
        private UpdateType UT
        {
            set
            {
                if (value == UpdateType.待上传)
                {
                    //this.toolStripButton1.Enabled = true;
                    //this.toolStripButton2.Enabled = true;
                    //this.toolStripButton3.Enabled = true;
                    //this.toolStripButton4.Enabled = false;

                    SetEnabled(toolStrip2, true, toolStripButton1);
                    SetEnabled(toolStrip2, true, toolStripButton2);
                    SetEnabled(toolStrip2, true, toolStripButton3);
                    SetEnabled(toolStrip2, false, toolStripButton4);

                    SetEnabled(toolStrip2, true, toolStripSplitButton1);
                    SetEnabled(toolStrip2, true, toolStripSplitButton2);
                }
                else if (value == UpdateType.正在单人上传)
                {
                    this.toolStripButton1.Enabled = false;
                    this.toolStripButton2.Enabled = false;
                    this.toolStripButton3.Enabled = true;
                    this.toolStripButton4.Enabled = false;

                    toolStripSplitButton1.Enabled = false;
                    toolStripSplitButton2.Enabled = false;
                }
                else if (value == UpdateType.正在多人上传)
                {
                    this.toolStripButton1.Enabled = false;
                    this.toolStripButton2.Enabled = false;
                    this.toolStripButton3.Enabled = true;
                    this.toolStripButton4.Enabled = true;

                    toolStripSplitButton1.Enabled = false;
                    toolStripSplitButton2.Enabled = false;
                }
                else
                {
                    this.toolStripButton1.Enabled = false;
                    this.toolStripButton2.Enabled = false;
                    this.toolStripButton3.Enabled = false;
                    this.toolStripButton4.Enabled = false;

                    toolStripSplitButton1.Enabled = false;
                    toolStripSplitButton2.Enabled = false;
                }
            }
        }

        private bool IsShow = true;

        private CostUpdateController controller;

        public FrmPatCostUpdate()
        {
            InitializeComponent();

            

            base.HIS_DoubleClick += new lvPatList_DoubleClickEvent(FrmPatCostUpdate_HIS_DoubleClick);
            this.UT = UpdateType.无效;
            //toolStripSplitButton2.Visible = false;
           
        }

        private void Clear()
        {
            this.lb_zyno.Text = "";
            this.lb_name.Text = "";
            this.lb_indate.Text = "";
            this.lb_cardno.Text = "";
            this.lb_bedno.Text = "";
        }

        private void costUpdate_BackUpdateType()
        {
            this.UT = UpdateType.待上传;
            this.timer1.Stop();
            IsShow = true;
            //costUpdate.Trigger();
        }
        //双击病人列表
        private void FrmPatCostUpdate_HIS_DoubleClick(object sender, EventArgs e)
        {
            if (IsShow)
                this.UT = UpdateType.待上传;

            lb_zyno.Text = base.zy_PatList.CureNo;
            lb_name.Text = zy_PatList.patientInfo.PatName;
            lb_indate.Text = zy_PatList.CureDate.ToString("yyyy-MM-dd");
            lb_cardno.Text = zy_PatList.patientInfo.MediCard;
            lb_bedno.Text = zy_PatList.BedCode;
            controller.GetSinglePatData();

        }
        //单人上传
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IsShow = false;
            this.timer1.Start();
            this.UT = UpdateType.正在单人上传;

            controller.SinglePatUpdate();

        }
        //多人上传
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            IsShow = false;
            this.rtb_message.Focus();
            this.timer1.Start();

            this.UT = UpdateType.正在多人上传;
            controller.ManyPatUpdate();
        }
        //清除信息
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            controller.ClearMessage();
        }
        //终止上传
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            controller.StopUpdate();
            this.UT = UpdateType.待上传;
            this.timer1.Stop();
        }
        //关闭
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //时间控件事件
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.rtb_message.SelectionStart = this.rtb_message.TextLength;
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.BrushUploadFee();
        }

        private void 本地农合对比ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.CompUploadFee();
        }

        #region ICostUpdate 成员

        public HIS.ZY_BLL.DataModel.ZY_PatList zyPatList
        {
            get { return base.zy_PatList; }
        }

        public HIS.ZY_BLL.DataModel.ZY_PatList[] zyPatLists
        {
            get { return base.zy_PatLists; }
        }

        public DataTable dgvFee
        {
            set
            {
                this.dgv_fee.AutoGenerateColumns = false;
                this.dgv_fee.DataSource = value;
            }
        }

        public DataTable dgvHisFee
        {
            set
            {
                this.dgv_HisFee.AutoGenerateColumns = false;
                this.dgv_HisFee.DataSource = value;
            }
        }

        public DataTable dgvNccmFee
        {
            set
            {
                this.dgv_nccm.AutoGenerateColumns = false;
                this.dgv_nccm.DataSource = value;
            }
        }

        public string rtbMessage
        {
            set { SetMessageText(this.rtb_message, value); }
        }

        public void ClearMessage()
        {
            this.rtb_message.Clear();
        }

        public void brushpatlist()
        {
            this.llabrush_LinkClicked(null, null);
        }

        #endregion
        //入院登记
        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            if (base.zy_PatList.Nccm_NO != null && base.zy_PatList.Nccm_NO != "")
            {
                MessageBox.Show("该病人已进行了登记！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FrmShowPatInfo frmspi = new FrmShowPatInfo(controller);
            frmspi.ShowDialog();
            if (frmspi.isOk)
            {

                controller.PatRegister();
                //MessageBox.Show("入院登记成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }    

        private void 重新登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.RestPatRegister();
        }

        private void 取消登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (base.zy_PatList.Nccm_NO == null || base.zy_PatList.Nccm_NO == "")
            {
                MessageBox.Show("该病人还没有进行入院登记！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            controller.CancelPatRegister();
        }

        //出院结算
        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            controller.PatCost();
        }

        private void 取消结算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.CancelPatCost();
        }

        //显示数据
        private void FrmPatCostUpdate_Load(object sender, EventArgs e)
        {
            this.cbdate.Checked = true;
            this.llabrush_LinkClicked(null, null);
            controller = new CostUpdateController(this, currentUser.EmployeeID.ToString(), currentUser.Name);
            controller.BackUpdateType += new Action.CostUpdateController.BackUpdateTypeEvent(costUpdate_BackUpdateType);
            Clear();
        }

        //关闭释放接口资源
        private void FrmPatCostUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.Dispose();
        }
    }
}
