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

namespace HIS_ZYManager
{
    public partial class FrmStatDrugMessage : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;
        private Deptment _currentDept;
        private int MasterID;
        private string DeptCode;
        private string YfCode;
        private bool IsDrug;//发药|退药
        private int StatType;
        private int DrugType;
        private bool IsOper;//手术室统领

        public FrmStatDrugMessage(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;

            DataTable tb = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptData(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType.住院, HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType2.临床);
            tb.TableName = "Dept";

            this.cbDept.DataSource = tb;
            this.cbDept.DisplayMember = "name";
            this.cbDept.ValueMember = "code";
            //[20100525.1.06]
            //禁用修改科室
            this.chbDept.Checked = false;
            this.chbDept.Enabled = false;
            this.cbDept.Enabled = false;
            this.cbDept.SelectedValue = _currentDept.DeptID;
            //this.llabrush_Click(null, null);
            this.tscbType.SelectedIndex = 0;
        }
        //[20100514.1.04]
        public FrmStatDrugMessage(long currentUserId, long currentDeptId, string chineseName, bool _IsOper)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;

            DataTable tb = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptData(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType.住院, HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType2.临床);
            tb.TableName = "Dept";

            this.cbDept.DataSource = tb;
            this.cbDept.DisplayMember = "name";
            this.cbDept.ValueMember = "code";

            this.chbDept.Checked = true;
            this.chbDept.Enabled = false;
            this.cbDept.Enabled = false;
            this.cbDept.SelectedValue = _currentDept.DeptID;
            //this.llabrush_Click(null, null);
            if (_IsOper == true)
                this.tscbType.SelectedIndex = 5;
            else
                this.tscbType.SelectedIndex = 0;

            IsOper = _IsOper;
        }

        //时间
        private void cbdate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbdate.Checked)
            {
                this.dtpBegin.Enabled = true;
                this.dtpEnd.Enabled = true;
            }
            else
            {
                this.dtpBegin.Enabled = false;
                this.dtpEnd.Enabled = false;
            }
        }
        //科室
        private void chbDept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbDept.Checked)
            {
                this.cbDept.Enabled = true;
            }
            else
            {
                this.cbDept.Enabled = false;
            }
        }
        //已发药
        private void rbin_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.rbin.Checked)
            {
                this.cbdate.Checked = true;
                //this.chbDept.Checked = true;
            }
            else
            {
                this.cbdate.Checked = false;
                //this.chbDept.Checked = false;
            }
        }
        //刷新
        private void llabrush_Click(object sender, EventArgs e)
        {
            string deptcode = null;
            DateTime? Bdate = null;
            DateTime? Edate = null;

            //if (chbDept.Checked)
            //{
            //    deptcode = this.cbDept.SelectedValue.ToString().Trim();
            //}
            deptcode = this.cbDept.SelectedValue.ToString().Trim();

            if (cbdate.Checked)
            {
                Bdate = dtpBegin.Value;
                Edate = dtpEnd.Value;
            }
            //[20100514.1.04]
            DataTable dt = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetMessageMaster(this.rbin.Checked, deptcode, Bdate, Edate, IsOper);
            dsMessageData.dtMessageMaster.Rows.Clear();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dsMessageData.dtMessageMaster.NewRow();
                    dr["DRUGMESSAGEID"] = dt.Rows[i]["DRUGMESSAGEID"];
                    dr["SENDTIME"] = dt.Rows[i]["SENDTIME"];
                    dr["PRESDEPTID"] = dt.Rows[i]["PRESDEPTID"];
                    dr["presdeptname"] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(dt.Rows[i]["PRESDEPTID"].ToString());
                    dr["DISPDEPT"] = dt.Rows[i]["DISPDEPT"];
                    dr["dispDeptName"] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(dt.Rows[i]["DISPDEPT"].ToString());
                    dr["DR_FLAG"] = dt.Rows[i]["DR_FLAG"];
                    dr["dr_name"] = Convert.ToInt32(dt.Rows[i]["DR_FLAG"]) == 1 ? "领药" : "退药";
                    dr["MESSAGETYPE"] = dt.Rows[i]["MESSAGETYPE"];

                    int statType = Convert.ToInt32(dt.Rows[i]["MESSAGETYPE"]);
                    if (statType == 2)
                    {
                        dr["messageName"] = "手术";
                    }
                    else
                    {
                        dr["messageName"] = statType == 0 ? "长期" : "临时";
                    }
                    dr["SENDER"] = dt.Rows[i]["SENDER"];
                    dr["SENDERNAME"] = dt.Rows[i]["SENDERNAME"];
                    dr["drug_flag"] = this.rbin.Checked;
                    dr["stattype"] = dt.Rows[i]["STATTYPE"];//
                    dsMessageData.dtMessageMaster.Rows.Add(dr);
                }

                DataTable ddt = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetMessageOrder(dt, this.rbin.Checked);

                dsMessageData.dtMessageOrder.Rows.Clear();
                if (ddt != null)
                {
                    for (int i = 0; i < ddt.Rows.Count; i++)
                    {
                        DataRow dr = dsMessageData.dtMessageOrder.NewRow();

                        for (int m = 0; m < ddt.Columns.Count; m++)
                        {
                            for (int n = 0; n < dsMessageData.dtMessageOrder.Columns.Count; n++)
                            {
                                if (ddt.Columns[m].ColumnName.ToUpper() == dsMessageData.dtMessageOrder.Columns[n].ColumnName.ToUpper())
                                {
                                    dr[dsMessageData.dtMessageOrder.Columns[n].ColumnName] = ddt.Rows[i][m];
                                    break;
                                }
                            }
                        }

                        dsMessageData.dtMessageOrder.Rows.Add(dr);
                    }
                }
            }

            if (this.cbBed.Checked)
            {
                ShowPat();
            }
            else
            {
                dtMessageMasterBindingSource.Filter = "";
            }
            MessageBox.Show("刷新列表成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        private void ShowPat()
        {
            DataRow[] drs = dsMessageData.dtMessageOrder.Select("bedno='" + this.tbbed.Text.Trim() + "'");
            if (drs.Length > 0)
            {
                string Str = "DRUGMESSAGEID in (";
                for (int i = 0; i < drs.Length; i++)
                {
                    Str += drs[i]["masterid"].ToString() + ",";
                }
                Str = Str.Substring(0, Str.Length - 1);
                dtMessageMasterBindingSource.Filter = Str + ")";
            }
        }
        //显示对应统领单信息
        private void dataGridViewEx1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewEx1.CurrentCell == null) return;
            string Masterid = this.dataGridViewEx1[0, this.dataGridViewEx1.CurrentCell.RowIndex].Value.ToString();//dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["DRUGMESSAGEID"].ToString();
            MasterID = Convert.ToInt32(Masterid);
            DataRow DR = dsMessageData.dtMessageMaster.Select("DRUGMESSAGEID='" + MasterID + "'")[0];
            DeptCode = DR["PRESDEPTID"].ToString().Trim();//dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["PRESDEPTID"].ToString().Trim();
            YfCode = DR["DISPDEPT"].ToString().Trim();//dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["DISPDEPT"].ToString().Trim();
            IsDrug = DR["DR_FLAG"].ToString().Trim() == "1" ? true : false;//dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["DR_FLAG"].ToString().Trim() == "1" ? true : false;
            StatType = Convert.ToInt32(DR["MESSAGETYPE"]);//Convert.ToInt32(dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["MESSAGETYPE"]); //== "1" ? true : false;
            DrugType = Convert.ToInt32(DR["StatType"]);//Convert.ToInt32(dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["StatType"]); //== "1" ? true : false;
            dtMessageOrderBindingSource.Filter = "MASTERID=" + Masterid;

            //显示汇总
            dsMessageData.dtMessageAllOrder.Rows.Clear();

            DataRow[] drs = dsMessageData.dtMessageOrder.Select(" MASTERID=" + Masterid);

            for (int i = 0; i < drs.Length; i++)
            {
                bool b = false;
                if (dsMessageData.dtMessageAllOrder.Rows.Count == 0)
                {
                    b = true;
                }

                for (int j = 0; j < dsMessageData.dtMessageAllOrder.Rows.Count; j++)
                {
                    if (Convert.ToInt32(drs[i]["MakerdicID"]) == Convert.ToInt32(dsMessageData.dtMessageAllOrder.Rows[j]["itemid"]))
                    {
                        dsMessageData.dtMessageAllOrder.Rows[j]["Amount"] = Convert.ToDecimal(dsMessageData.dtMessageAllOrder.Rows[j]["Amount"]) + Convert.ToDecimal(drs[i]["DRUGNUM"]);
                        dsMessageData.dtMessageAllOrder.Rows[j]["presamount"] = Convert.ToInt32(dsMessageData.dtMessageAllOrder.Rows[j]["presamount"]) + Convert.ToInt32(drs[i]["RECIPENUM"]);
                        dsMessageData.dtMessageAllOrder.Rows[j]["Total_Fee"] = Convert.ToDecimal(dsMessageData.dtMessageAllOrder.Rows[j]["Total_Fee"]) + Convert.ToDecimal(drs[i]["RETAILFEE"]);
                        break;
                    }
                    if (j == dsMessageData.dtMessageAllOrder.Rows.Count - 1)
                    {
                        b = true;
                    }
                }

                if (b)
                {
                    DataRow _dr = dsMessageData.dtMessageAllOrder.NewRow();
                    _dr["itemid"] = drs[i]["MakerdicID"];
                    _dr["DrugName"] = drs[i]["CHEMNAME"];
                    _dr["Spec"] = drs[i]["SPEC"];
                    _dr["PRODUCTNAME"] = drs[i]["PRODUCTNAME"];
                    _dr["DOSENAME"] = drs[i]["DOSENAME"];

                    _dr["Price"] = drs[i]["RETAILPRICE"];
                    _dr["Amount"] = drs[i]["DRUGNUM"];
                    _dr["presamount"] = drs[i]["RECIPENUM"];
                    _dr["Unit"] = drs[i]["UNITNAME"];
                    _dr["retailprice"] = drs[i]["retailprice"];
                    _dr["Total_Fee"] = drs[i]["RETAILFEE"];
                    dsMessageData.dtMessageAllOrder.Rows.Add(_dr);
                }
            }
            decimal alldec = 0;
            //显示合计
            for (int i = 0; i < dataGridViewEx2.RowCount; i++)
            {
                alldec += Convert.ToDecimal(dataGridViewEx2["totalFeeDataGridViewTextBoxColumn", i].Value);
            }
            this.tbAllFee.Text = alldec.ToString("0.00");
        }

        //新增
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("现在请使用右边按钮【一键发送】，方便快捷！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //return;
            //[20100514.1.04]
            FrmAddDrugMessage frmCharge = new FrmAddDrugMessage(0, _currentUser, _currentDept, IsOper);
            //frmCharge.currentDept = _currentDept;
            //frmCharge.currentUser = _currentUser;
            frmCharge.WindowState = FormWindowState.Maximized;
            frmCharge.MdiParent = this.MdiParent;
            //frmCharge.BindDataGrid();
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmCharge);
            //frmCharge.ShowDialog();
            //llabrush_Click(null, null);
            //dataGridViewEx1_CurrentCellChanged(null, null);
            //MessageBox.Show("请重新刷新病人列表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }
        //修改
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("现在请使用右边按钮【一键发送】，方便快捷！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //return;
            if (this.dataGridViewEx1.CurrentCell != null)
            {
                //未发药
                if (Convert.ToBoolean(dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["drug_flag"]))
                {
                    //[20100514.1.04]
                    FrmAddDrugMessage frmCharge = new FrmAddDrugMessage(MasterID, _currentUser, _currentDept, DeptCode, YfCode, IsDrug, DrugType, dsMessageData.dtMessageOrder, IsOper);
                    //frmCharge.currentDept = _currentDept;
                    //frmCharge.currentUser = _currentUser;
                    frmCharge.WindowState = FormWindowState.Maximized;
                    frmCharge.MdiParent = this.MdiParent;
                    //frmCharge.BindDataGrid();
                    ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmCharge);
                    //frmCharge.ShowDialog();
                    //llabrush_Click(null, null);
                    //dataGridViewEx1_CurrentCellChanged(null, null);
                    //MessageBox.Show("请重新刷新病人列表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("已发药的统领单不能维护！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //删除
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewEx1.CurrentCell != null)
            {
                //未发药
                if (Convert.ToBoolean(dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["drug_flag"]))
                {
                    if (MessageBox.Show("是否删除该统领单?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (HIS.ZY_BLL.DurgMessage.OP_DurgMessage.DelMessage(MasterID))
                        {
                            MessageBox.Show("该统领单删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //llabrush_Click(null, null);
                            MessageBox.Show("请重新刷新病人列表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            MessageBox.Show("该统领单删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("已发药的统领单不能删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //打印
        grproLib.GridppReport Report = null;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewEx1.CurrentCell != null)
            {
                int RowIndex = this.dataGridViewEx1.CurrentCell.RowIndex;
                Report = new grproLib.GridppReport();
                Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\护士统领汇总单据.grf");
                Report.ParameterByName("UserName").AsString = dsMessageData.dtMessageMaster.Rows[RowIndex]["SENDERNAME"].ToString().Trim();
                Report.ParameterByName("ExeTime").AsString = dsMessageData.dtMessageMaster.Rows[RowIndex]["SENDTIME"].ToString().Trim();
                Report.ParameterByName("DeptName").AsString = dsMessageData.dtMessageMaster.Rows[RowIndex]["presdeptname"].ToString().Trim();
                Report.ParameterByName("DispDept").AsString = dsMessageData.dtMessageMaster.Rows[RowIndex]["dispDeptName"].ToString().Trim();
                Report.ParameterByName("Printer").AsString = _currentUser.Name;
                Report.ParameterByName("PrintTime").AsString = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString();
                Report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                List<string> patNames = new List<string>();
                int masterID = Convert.ToInt32(dsMessageData.dtMessageMaster.Rows[RowIndex]["DRUGMESSAGEID"].ToString().Trim());
                string patname = "";
                DataRow[] drs = dsMessageData.dtMessageOrder.Select("masterid=" + masterID);
                for (int i = 0; i < drs.Length; i++)
                {
                    string patS = patNames.Find(delegate(string y) { return y == drs[i]["patname"].ToString(); });
                    if (patS == null)
                    {
                        patNames.Add(drs[i]["patname"].ToString());
                        patname += drs[i]["patname"].ToString() + ",";
                    }
                }
                if (patname != "") patname = patname.Substring(0, patname.Length - 1);
                Report.ParameterByName("PatientNames").AsString = patname;
                Report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(Report_FetchRecord);
                Report.PrintPreview(false);
            }
        }
        //填充报表数据
        private void Report_FetchRecord(ref bool Eof)
        {
            GWI_DesReport.HisReport.FillRecordToReport(Report, dsMessageData.dtMessageAllOrder);
        }

        //关闭
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //再次发送
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewEx1.CurrentCell != null)
            {
                //未发药
                if (Convert.ToBoolean(dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["drug_flag"]))
                {
                    HIS.ZY_BLL.DurgMessage.OP_DurgMessage.AgainSendMessage(MasterID);
                    MessageBox.Show("再次发送成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessagePromptManager.Messenger senders = new MessagePromptManager.Messenger(_currentUser.UserID, _currentDept.DeptID, "");
                    MessagePromptManager.Messenger receiver = new MessagePromptManager.Messenger();
                    MessagePromptManager.Messages message = new MessagePromptManager.Messages("002", "【" + _currentDept.Name + "】统领消息", "【" + _currentDept.Name + "】已经发来了药品统领消息，请及时查看！");
                    senders.SendMessage(receiver, message);
                }
                else
                {
                    MessageBox.Show("已发药的统领单不能发送！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //床位查询条件
        private void cbBed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbBed.Checked)
            {
                this.tbbed.Enabled = true;
            }
            else
            {
                this.tbbed.Enabled = false;
            }
        }
        //快捷建
        private void FrmStatDrugMessage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:

                    break;
                case Keys.F1:	//

                    break;
                case Keys.F2:	//
                    toolStripButton1_Click(null, null);
                    break;
                case Keys.F3:	//
                    toolStripButton2_Click(null, null);
                    break;
                case Keys.F4:	//
                    toolStripButton3_Click(null, null);
                    break;
                case Keys.F5:	//
                    toolStripButton4_Click(null, null);
                    break;
                case Keys.F6:	//
                    toolStripButton6_Click(null, null);
                    break;
                case Keys.F7:	//

                    break;
                default:
                    break;
            }
        }
        //一键发送
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //[20100514.1.04]
            if (IsOper == false && this.tscbType.SelectedIndex == 5)
            {
                MessageBox.Show("手术药品不能在此发送！");
                return;
            }
            //[20100514.1.04]
            if (IsOper == true && this.tscbType.SelectedIndex != 5)
            {
                MessageBox.Show("除了手术药品，其他类型药品不能在此发送！");
                return;
            }

            if (MessageBox.Show("是否执行一键发送[" + this.tscbType.Text + "]到药房?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HIS.ZY_BLL.DurgMessage.OP_DurgMessage.OneKeySendDrug(this.tscbType.SelectedIndex, _currentDept.DeptID.ToString(), _currentUser.EmployeeID.ToString(), _currentUser.Name, dsMessageData.dtDrugMessage, IsOper);
                MessageBox.Show("发送成功，请重新刷新列表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                MessagePromptManager.Messenger senders = new MessagePromptManager.Messenger(_currentUser.UserID, _currentDept.DeptID, "");
                MessagePromptManager.Messenger receiver = new MessagePromptManager.Messenger();
                MessagePromptManager.Messages message = new MessagePromptManager.Messages("002", "【" + _currentDept.Name + "】统领消息", "【" + _currentDept.Name + "】已经发来了药品统领消息，请及时查看！");
                senders.SendMessage(receiver, message);
            }
        }
        //更改汇总显示对应明细[20100608.1.07]
        private void dataGridViewEx2_CurrentCellChanged(object sender, EventArgs e)
        {

            if (this.dataGridViewEx2.CurrentCell == null) return;
            string itemid = this.dataGridViewEx2[0, this.dataGridViewEx2.CurrentCell.RowIndex].Value.ToString();
            //MasterID = Convert.ToInt32(Masterid);
            //DataRow DR = dsMessageData.dtMessageMaster.Select("DRUGMESSAGEID='" + MasterID + "'")[0];
            //DeptCode = DR["PRESDEPTID"].ToString().Trim();//dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["PRESDEPTID"].ToString().Trim();
            //YfCode = DR["DISPDEPT"].ToString().Trim();//dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["DISPDEPT"].ToString().Trim();
            //IsDrug = DR["DR_FLAG"].ToString().Trim() == "1" ? true : false;//dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["DR_FLAG"].ToString().Trim() == "1" ? true : false;
            //StatType = Convert.ToInt32(DR["MESSAGETYPE"]);//Convert.ToInt32(dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["MESSAGETYPE"]); //== "1" ? true : false;
            //DrugType = Convert.ToInt32(DR["StatType"]);//Convert.ToInt32(dsMessageData.dtMessageMaster.Rows[this.dataGridViewEx1.CurrentCell.RowIndex]["StatType"]); //== "1" ? true : false;
            //dtMessageOrderBindingSource.Filter = "MASTERID=" + Masterid;

            //显示汇总
            dsMessageData.dtMessageAllOrderMX.Rows.Clear();

            DataRow[] drs = dsMessageData.dtMessageOrder.Select(" MASTERID=" + MasterID + " and MakerdicID=" + itemid + " ");

            for (int i = 0; i < drs.Length; i++)
            {
                dsMessageData.dtMessageAllOrderMX.Rows.Add(drs[i].ItemArray);
            }
        }
    }
}
