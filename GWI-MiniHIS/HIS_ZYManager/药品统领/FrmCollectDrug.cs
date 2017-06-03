using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.ZY_BLL.ObjectModel.BaseData;
using HIS.ZY_BLL.DataModel;

namespace HIS_ZYManager
{
    public partial class FrmCollectDrug : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private bool IsOper;
        private User _currentUser;
        private Deptment _currentDept;
        DataTable RecDt;
        DataTable dtDrugMessage;
        string[] data;

        public FrmCollectDrug()
        {
            InitializeComponent();
        }

        public FrmCollectDrug(long currentUserId, long currentDeptId, string chineseName, bool _IsOper)
        {
            InitializeComponent();

            dtDrugMessage = new DsMessageData().dtDrugMessage.Clone();

            RecDt = new DataTable();
            DataColumn col;
            col = new System.Data.DataColumn("patlistid");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("cureno");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("bedcode");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("Name");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("py_code");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("wb_code");
            RecDt.Columns.Add(col);

            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;

            DataTable tb = BaseDataFactory.GetData(baseDataType.所有科室);
            tb.TableName = "Dept";
            
            this.cbPatDept.DataSource = tb;
            this.cbPatDept.DisplayMember = "name";
            this.cbPatDept.ValueMember = "code";

            this.cbPatDept.SelectedValue = _currentDept.DeptID;

            DataTable tb1 = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetYfDept();
            this.cbYfDept.DataSource = tb1;
            this.cbYfDept.DisplayMember = "name";
            this.cbYfDept.ValueMember = "code";

            this.cbYfDept.Text = "住院药房";

            if (_IsOper == true)
            {
                this.ckdept.Enabled = false;
                this.cbPatDept.Enabled = false;
            }

            this.ckdept.Enabled = false;
            this.cbPatDept.Enabled = false;


            IsOper = _IsOper;
        }

        private void ckdept_CheckedChanged(object sender, EventArgs e)
        {
            if (ckdept.Checked == true)
            {
                this.cbPatDept.Enabled = true;
            }
            else
            {
                this.cbPatDept.Enabled = false;
                //GetPatList(null);
            }
        }

        private void ckpat_CheckedChanged(object sender, EventArgs e)
        {
            if (ckpat.Checked == true)
            {
                this.tbPatname.Enabled = true;
            }
            else
            {
                this.tbPatname.Enabled = false;
            }
        }

        private void GetPatList(string deptcode)
        {
            ZY_PatList zy_Patlist = new ZY_PatList();
            BindPatListVal bplv = new BindPatListVal();
            bplv.IsIn = true;
            bplv.DeptCode = deptcode;
            bplv.IsOperation = IsOper;
            zy_Patlist.bindPatListVal = bplv;
            zy_Patlist.bindPatListType = BindPatListType.费用清单病人列表;
            List<ZY_PatList> zyPatList = zy_Patlist.BindPatList();

            RecDt.Rows.Clear();

            for (int i = 0; i < zyPatList.Count; i++)
            {
                DataRow dr = RecDt.NewRow();
                dr["patlistid"] = zyPatList[i].PatListID.ToString();
                dr["cureno"] = zyPatList[i].CureNo;
                dr["bedcode"] = zyPatList[i].BedCode;
                dr["Name"] = zyPatList[i].patientInfo.PatName;
                dr["py_code"] = zyPatList[i].patientInfo.PYM;
                dr["wb_code"] = zyPatList[i].patientInfo.WBM;
                RecDt.Rows.Add(dr);
            }
            this.tbPatname.SetSelectionCardDataSource(RecDt);
        }

        private void cbPatDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (RecDt != null)
            //    GetPatList(this.cbPatDept.SelectedValue.ToString());
        }

        private void tbPatname_Enter(object sender, EventArgs e)
        {
           
        }

        private void btbrush_Click(object sender, EventArgs e)
        {
            bool IsSend = this.rbSend.Checked;
            string deptID = this.cbPatDept.SelectedValue.ToString().Trim();
            string YfId = this.cbYfDept.SelectedValue.ToString().Trim();
            string patlistid = this.ckpat.Checked == true ? (this.tbPatname.MemberValue == null ? null : this.tbPatname.MemberValue.ToString()) : null;
            dgvDrug.DataSource = null;
            dgvDrugMx.DataSource = null;
            dtDrugMessage.Rows.Clear();
            DataTable dtMessageAllOrder = new DsMessageData().dtMessageAllOrder.Clone();

            data = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.CollectDurgSend(
                IsSend,
                false,
                deptID,
                YfId,
                patlistid,
                _currentUser.EmployeeID.ToString(),
                _currentUser.Name,
                dtDrugMessage,
                 dtMessageAllOrder,
                 IsOper);         
            this.dgvDrug.AutoGenerateColumns = false;
            this.dgvDrug.DataSource = dtMessageAllOrder;
            
        }

        private void dgvDrug_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgvDrug.CurrentCell == null) return;
            string itemid = this.dgvDrug["itemid", this.dgvDrug.CurrentCell.RowIndex].Value.ToString(); //((DataTable)this.dgvDrug.DataSource).Rows[this.dgvDrug.CurrentCell.RowIndex]["itemid"].ToString();

            //显示汇总
            DataTable dtDrugMessage1 = new DsMessageData().dtDrugMessage.Clone();

            DataRow[] drs = dtDrugMessage.Select(" MakerdicID=" + itemid + " ");

            for (int i = 0; i < drs.Length; i++)
            {
                dtDrugMessage1.Rows.Add(drs[i].ItemArray);
            }

            this.dgvDrugMx.AutoGenerateColumns = false;
            this.dgvDrugMx.DataSource = dtDrugMessage1;
        }

        private void btSendDrug_Click(object sender, EventArgs e)
        {
            if (dtDrugMessage.Rows.Count > 0 && dtDrugMessage.Select("XD=True").Length > 0)
            {
                string message1 = null;
                HIS.ZY_BLL.DurgMessage.OP_DurgMessage.SaveMessage(0, dtDrugMessage.Select("XD=True"), data, out message1);

                MessageBox.Show("请药成功！\n" + message1, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //MessageBox.Show("发送成功，请重新刷新列表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                MessagePromptManager.Messenger senders = new MessagePromptManager.Messenger(_currentUser.UserID, _currentDept.DeptID, "");
                MessagePromptManager.Messenger receiver = new MessagePromptManager.Messenger();
                MessagePromptManager.Messages message = new MessagePromptManager.Messages("002", "【" + _currentDept.Name + "】统领消息", "【" + _currentDept.Name + "】已经发来了药品统领消息，请及时查看！");
                senders.SendMessage(receiver, message);

                btbrush_Click(null, null);
            }
            else
            {
                MessageBox.Show("没有可请领的药品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
        }
        //打印
        grproLib.GridppReport Report = null;
        private void btPrint_Click(object sender, EventArgs e)
        {
            if (this.dgvDrug.CurrentCell != null)
            {
                DataTable dt = (DataTable)this.dgvDrug.DataSource;
                int RowIndex = this.dgvDrug.CurrentCell.RowIndex;
                Report = new grproLib.GridppReport();
                Report.LoadFromFile(HIS.SYSTEM.PubicBaseClasses.Constant.ApplicationDirectory + "\\report\\护士统领汇总单据.grf");
                Report.ParameterByName("UserName").AsString = data[6];
                Report.ParameterByName("ExeTime").AsString = data[0];
                Report.ParameterByName("DeptName").AsString = BaseNameFactory.GetName(baseNameType.科室名称, data[1]);
                Report.ParameterByName("DispDept").AsString = BaseNameFactory.GetName(baseNameType.科室名称, data[2]);
                Report.ParameterByName("Printer").AsString = _currentUser.Name;
                Report.ParameterByName("PrintTime").AsString = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString();
                Report.ParameterByName("HospitalName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                //List<string> patNames = new List<string>();
                //int masterID = Convert.ToInt32(dsMessageData.dtMessageMaster.Rows[RowIndex]["DRUGMESSAGEID"].ToString().Trim());
                //string patname = "";
                //DataRow[] drs = dsMessageData.dtMessageOrder.Select("masterid=" + masterID);
                //for (int i = 0; i < drs.Length; i++)
                //{
                //    string patS = patNames.Find(delegate(string y) { return y == drs[i]["patname"].ToString(); });
                //    if (patS == null)
                //    {
                //        patNames.Add(drs[i]["patname"].ToString());
                //        patname += drs[i]["patname"].ToString() + ",";
                //    }
                //}
                //if (patname != "") patname = patname.Substring(0, patname.Length - 1);
                Report.ParameterByName("PatientNames").AsString = "";
                Report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(Report_FetchRecord);
                Report.PrintPreview(false);
            }
        }
        //填充报表数据
        private void Report_FetchRecord(ref bool Eof)
        {
            GWI_DesReport.HisReport.FillRecordToReport(Report, (DataTable)dgvDrug.DataSource);
        }

        private void tbPatname_Click(object sender, EventArgs e)
        {
            if (this.ckdept.Checked == true)
                GetPatList(this.cbPatDept.SelectedValue.ToString());
            else
                GetPatList(null);
        }
        //选定
        private void dgvDrug_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (this.dgvDrug.CurrentCell == null) return;
                string itemid = this.dgvDrug["itemid", this.dgvDrug.CurrentCell.RowIndex].Value.ToString(); //((DataTable)this.dgvDrug.DataSource).Rows[this.dgvDrug.CurrentCell.RowIndex]["itemid"].ToString();
                
                bool b = Convert.ToBoolean(this.dgvDrug[0, this.dgvDrug.CurrentCell.RowIndex].Value);
                if (b == true)
                {
                    this.dgvDrug[0, this.dgvDrug.CurrentCell.RowIndex].Value = false;
                }
                else
                {
                    this.dgvDrug[0, this.dgvDrug.CurrentCell.RowIndex].Value = true;
                }
                b = Convert.ToBoolean(this.dgvDrug[0, this.dgvDrug.CurrentCell.RowIndex].Value);
                for (int i = 0; i < dtDrugMessage.Rows.Count; i++)
                {
                    if (dtDrugMessage.Rows[i]["MakerdicID"].ToString() == itemid)
                    {
                        dtDrugMessage.Rows[i]["XD"] = b;
                    }
                }
                decimal alldec = 0;
                for (int i = 0; i < dgvDrug.RowCount; i++)
                {
                    if (this.dgvDrug[0, i].Value!=null && (bool)this.dgvDrug[0, i].Value == true)
                    {
                        alldec += Convert.ToDecimal(this.dgvDrug["Column13", i].Value);
                    }
                }

                this.tbAllFee.Text = alldec.ToString("0.00");
            }
        }
        //全选
        private void cbqx_CheckedChanged(object sender, EventArgs e)
        {
            if (cbqx.Checked == true)
            {
                for (int i = 0; i < dtDrugMessage.Rows.Count; i++)
                {
                    dtDrugMessage.Rows[i]["XD"] = true;

                }

                for (int i = 0; i < dgvDrug.RowCount; i++)
                {
                    this.dgvDrug[0, i].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dtDrugMessage.Rows.Count; i++)
                {
                    dtDrugMessage.Rows[i]["XD"] = false;

                }

                for (int i = 0; i < dgvDrug.RowCount; i++)
                {
                    this.dgvDrug[0, i].Value = false;
                }
            }

            decimal alldec = 0;
            for (int i = 0; i < dgvDrug.RowCount; i++)
            {
                if (this.dgvDrug[0, i].Value != null &&  (bool)this.dgvDrug[0, i].Value == true)
                {
                    alldec += Convert.ToDecimal(this.dgvDrug["Column13", i].Value);
                }
            }

            this.tbAllFee.Text = alldec.ToString("0.00");
            
        }
        //反选
        private void cbfx_CheckedChanged(object sender, EventArgs e)
        {
            

        }

    }
}
