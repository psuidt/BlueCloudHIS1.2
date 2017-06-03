using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS_ZYManager
{
    public partial class FrmTicketManage : ZYBaseFrom
    {
        private ZY_CostMaster zyCostMaster = null;

        public FrmTicketManage()
        {
            InitializeComponent();
            base.HIS_DoubleClick += new lvPatList_DoubleClickEvent(FrmTicketManage_HIS_DoubleClick);
            //btSearch_Click(null, null);
            this.dgCost.AutoGenerateColumns = false;
            this.dgCost.DataSource = null;

            this.txtFP.Enabled = false;

            zyCostMaster = new ZY_CostMaster();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.dtpBdate.Enabled = true;
                this.dtpEdate.Enabled = true;
            }
            else
            {
                this.dtpBdate.Enabled = false;
                this.dtpEdate.Enabled = false;
            }
        }
        //绑定数据
        private void BindCostData(int PatlistID, DateTime? Bdate, DateTime? Edate, string TicketNo)
        {
            this.dgCost.DataSource = zyCostMaster.GetCostData(PatlistID, Bdate, Edate, TicketNo);
        }
        //双击病人列表
        private void FrmTicketManage_HIS_DoubleClick(object sender, EventArgs e)
        {
           
            this.BindCostData(base.zy_PatList.PatListID, null, null,null);
            this.txtZyh.Text = base.zy_PatList.CureNo;
        }
        //查询
        private void btSearch_Click(object sender, EventArgs e)
        {
            //2009-4-8 zy update 加按住院号查询
            int patListId = 0;
            //if (chkBZyh.Checked && txtZyh.Text.Trim() != "")
            //{
            //    try
            //    {
            //        patListId = HIS.ZY_BLL.OP_PatientObject.GetPatInfo(txtZyh.Text).PatListID;
            //    }
            //    catch
            //    {
            //        patListId = -1;
            //    }
            //}

            if (this.radioButton1.Checked)
            {
                this.BindCostData(patListId, this.dtpBdate.Value, this.dtpEdate.Value,null);
            }
            else if (this.radioButton2.Checked)
            {
                txtZyh_KeyDown(null, null);
            }
            else if (this.radioButton3.Checked)
            {
                txtFP_KeyDown(null, null);
            }
            else
            {
                this.BindCostData(patListId, null, null, null);
            }
        }     
        //取消结算
        private void toolCanel_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.zy_PatList == null) return;
                if (this.dgCost.CurrentCell == null) return;
                DataTable dt = ((DataTable)this.dgCost.DataSource).DefaultView.ToTable();
                int row = this.dgCost.CurrentCell.RowIndex;
                if (dt.Rows.Count > 0 && row >= 0)
                {

                    if (MessageBox.Show("确定要取消该次结算吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        ZY_CostMaster zyCostM = new ZY_CostMaster();
                        zyCostM = (ZY_CostMaster)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, row, zyCostM);
                        if (zyCostM.Record_Flag != 0)
                        {
                            MessageBox.Show("该条结算记录可能被取消，不能对其进行操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (zyCostMaster.CheckCanelCost(zyCostM.PatListID, zyCostM.CostMasterID) == false)
                        {
                            MessageBox.Show("不能取消该条结算记录，请操作下面的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (zyCostMaster.Check_CanelCostPat(zyCostM) == false)
                        {
                            MessageBox.Show("该中途结算已经结帐，不能取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (HIS.ZY_BLL.OP_ZYConfigSetting.GetConfigValue("006") == 0)
                        {
                            if (zyCostM.ChargeCode.Trim() != base.currentUser.EmployeeID.ToString())
                            {
                                MessageBox.Show("您没有权限取消【" + BaseNameFactory.GetName(baseNameType.用户名称,zyCostM.ChargeCode) + "】结算的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        //zyCostMaster.NccmCheck_CanelCostPat(base.zy_PatList, zyCostM.Nccm_NO);
                        zyCostM.ChargeCode = currentUser.EmployeeID.ToString();//update zh 090604
                        zyCostMaster.CanelCostPat(zyCostM);

                        MessageBox.Show("取消结算成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindCostData(base.zy_PatList.PatListID, null, null, null);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        //补打
        private void toolAgain_Click(object sender, EventArgs e)
        {
            //if (base.zy_PatList == null) return;
            if (this.dgCost.DataSource == null) return;
            DataTable dt = ((DataTable)this.dgCost.DataSource).DefaultView.ToTable();
            int row = this.dgCost.CurrentCell.RowIndex;
            if (dt.Rows.Count > 0 && row >= 0)
            {
                if (MessageBox.Show("确定要补打该次票据吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    ZY_CostMaster zyCostM = new ZY_CostMaster();
                    zyCostM = (ZY_CostMaster)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, row, zyCostM);
                    if (zyCostM.Record_Flag != 0)
                    {
                        MessageBox.Show("该条结算记录可能被取消，不能对其进行操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string value = GWMHIS.BussinessLogicLayer.Forms.DlgInputBoxStatic.InputBox("输入补打的发票号", "补打发票", "");
                    if (value != null)
                    {
                        int CostMasterID = zyCostMaster.Again_Ticket(zyCostM.CostMasterID, value);// add zenghao
                        if (CostMasterID != 0)
                        {
                            MessageBox.Show("补打发票成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //this.BindCostData(base.zy_PatList.PatListID, null, null,null);
                            //this.dgCost.CurrentCell. = ((DataTable)dgCost.DataSource).Rows.Count - 1;
                            Print(CostMasterID);
                        }
                        else
                        {
                            MessageBox.Show("补打发票失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
        //打印住院发票,结算ID
        private void Print(int CostMasterID)
        {
            FrmCost.Print(CostMasterID);
        }
        //窗体快捷键
        private void FrmTicketManage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:

                    break;
                case Keys.F1:	//帮助

                    break;
                case Keys.F2:	//取消结算
                    toolCanel_Click(null, null);
                    break;
                case Keys.F3:	//重打发票
                    toolAgain_Click(null, null);
                    break;
                

                default:
                    break;
            }
        }
        //显示住院号查询
        private void chkBZyh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                this.txtZyh.Enabled = true;
            }
            else
            {
                this.txtZyh.Enabled = false;
            }
        }
        //显示发票查询
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton3.Checked)
            {
                this.txtFP.Enabled = true;
            }
            else
            {
                this.txtFP.Enabled = false;
            }
        }
        //住院号查询
        private void txtZyh_KeyDown(object sender, KeyEventArgs e)
        {
            this.dgCost.DataSource = zyCostMaster.GetCostData(this.txtZyh.Text);
        }
        //发票号查询
        private void txtFP_KeyDown(object sender, KeyEventArgs e)
        {
             if (this.txtFP.Text.Trim() != "")
                    this.BindCostData(0, null, null, this.txtFP.Text.Trim());
        }
        //废票补录
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmBadTicketManager frmBadTM = new FrmBadTicketManager(base.currentUser.EmployeeID.ToString());
            frmBadTM.ShowDialog();
        }
        //关闭
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
