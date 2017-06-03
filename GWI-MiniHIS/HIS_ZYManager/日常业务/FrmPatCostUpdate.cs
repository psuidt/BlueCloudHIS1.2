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
using HIS_ZYManager.Action;


namespace HIS_ZYManager
{
    //zenghao [20100510.2.01]
    public partial class FrmPatCostUpdate : ZYBaseFrom, ICostUpdate
    {
        //线程外访问控件,更改控件值
        delegate void SetToolCallback(ToolStrip ts, bool b, ToolStripButton tsb);
        private void SetEnabled(ToolStrip ts, bool b, ToolStripButton tsb)
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
                }
                else if (value == UpdateType.正在单人上传)
                {
                    this.toolStripButton1.Enabled = false;
                    this.toolStripButton2.Enabled = false;
                    this.toolStripButton3.Enabled = true;
                    this.toolStripButton4.Enabled = false;
                }
                else if (value == UpdateType.正在多人上传)
                {
                    this.toolStripButton1.Enabled = false;
                    this.toolStripButton2.Enabled = false;
                    this.toolStripButton3.Enabled = true;
                    this.toolStripButton4.Enabled = true;
                }
                else
                {
                    this.toolStripButton1.Enabled = false;
                    this.toolStripButton2.Enabled = false;
                    this.toolStripButton3.Enabled = false;
                    this.toolStripButton4.Enabled = false;
                }
            }
        }

        private bool IsShow = true;

        private CostUpdateController controller;

        public FrmPatCostUpdate()
        {
            InitializeComponent();

            controller = new CostUpdateController(this);

            base.HIS_DoubleClick += new lvPatList_DoubleClickEvent(FrmPatCostUpdate_HIS_DoubleClick);
            this.UT = UpdateType.无效;

            controller.BackUpdateType += new HIS_ZYManager.Action.CostUpdateController.BackUpdateTypeEvent(costUpdate_BackUpdateType);
            Clear();

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

        #endregion
    }
}
