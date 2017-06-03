using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HIS.Model;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;
using HIS.Interface.Structs;
using HIS.Interface;

namespace HIS_YPManager
{
    public partial class MZFrmDrugDispense : GWI.HIS.Windows.Controls.BaseMainForm
    {
        long _currentUserId;
        long _currentDeptId;
        string _chineseName;
        private FY_MZ_Patient _currentPat;
        private DataTable _presList;
        private HIS.Interface.IMZ_Data mz_Interface = new HIS.Interface.MZ_Data();
        private BillProcessor _billProcessor;
        private Hashtable _recipeTb = new Hashtable();
        private int _drFlag = 0;
        

        public MZFrmDrugDispense()
        {
            InitializeComponent();
        }

        public MZFrmDrugDispense(long currentUserId, long currentDeptId, string chineseName)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            InitializeComponent();
            this.Text = _chineseName;
            _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_DISPENSE+"MZ");
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDispense_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConfigManager.IsChecking(_currentDeptId) == true)
                {
                    MessageBox.Show("药品正在盘点中......");
                    return;
                }
                if (_currentPat.InvoiceNum == "" || _presList.Rows.Count <= 0)
                {
                    MessageBox.Show("没有病人需要发药");
                    return;
                }
                List<YP_DRMaster> listMaster = new List<YP_DRMaster>();
                for (int index = 0; index < _presList.Rows.Count; index++)
                {
                    Prescription dispPres = GetPresFromDt(index);
                    YP_DRMaster dispMaster = _billProcessor.BuildNewDispenseMaster(dispPres, (int)_currentDeptId,
                        (int)_currentUserId);
                    listMaster.Add(dispMaster);
                    List<BillOrder> dispList = _billProcessor.BuildNewDispOrder((DataTable)_recipeTb[dispPres.PrescriptionID], dispMaster, 0);
                    if (dispList != null)
                    {
                        _billProcessor.SaveBill(dispMaster, dispList, _currentDeptId);
                    }
                }
                MessageBox.Show("发药成功，请注意库存...", "发药成功提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ////2010.10.20 门诊住院发药打印发药清单 add by heyan
                //YP_Printer printer= PrintFactory.GetPrinter(ConfigManager.OP_YF_DISPENSE + "MZ"); ;
                //string startPath = Application.StartupPath+"\\report\\门诊发药单据.grf";
                //for (int i = 0; i < listMaster.Count; i++)
                //{
                //    printer.PrintBill(listMaster[i], null, startPath, (int)_currentUserId);
                //}

                for (int i = 0; i < listMaster.Count; i++) //update by heyan 2010.10.29 点发药时直接打印处方
                {
                    mz_Interface.PrintDocPres(listMaster[i].RecipeID);
                }
                lstPatInfo_DoubleClick(null, null);
                if (chkRefresh.Checked == true)
                {
                    btnRefresh_Click(null, null);
                }
                this.txtQueryNum.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void ShowCurrentPat()
        {
            this.txtPatName.Text = XcConvert.IsNull(_currentPat.PatName, "拒绝");
            this.txtPatAge.Text = XcConvert.IsNull(_currentPat.PatAge, "拒绝");
            this.txtPatSex.Text = XcConvert.IsNull(_currentPat.PatSex, "拒绝");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                lstPatInfo.Items.Clear();
                string queryTime = (cobQueryDate.Value).ToString("yyyy-MM-dd") + @" 23:59:59";
                List<FY_MZ_Patient> patList = mz_Interface.GetPatient((int)_currentDeptId, null, Convert.ToDateTime(queryTime), _drFlag);
                LstRecipeBind(patList);
                lstPatInfo_SelectedIndexChanged(null, null);
                lstPatInfo_DoubleClick(null, null);

            }
            catch (Exception error)
            {
                if (error.Message != "输入的发票号没有知道对应的处方头信息")
                {
                    MessageBox.Show(error.Message);
                }
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
        }

        private void lstPatInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPatInfo.Items.Count > 0)
            {
                if (lstPatInfo.SelectedItems.Count != 0)
                {
                    ListViewItem selectItem = lstPatInfo.SelectedItems[0];
                    _currentPat = (FY_MZ_Patient)selectItem.Tag;
                    ShowCurrentPat();
                }
                else
                {
                    _currentPat.InvoiceNum = "";
                    _currentPat.PatAge = "";
                    _currentPat.PatName = "";
                    _currentPat.PatSex = "";
                    ShowCurrentPat();
                }
            }
        }

        private void LstRecipeBind(List<FY_MZ_Patient> patList)
        {
            try
            {
                if (lstPatInfo.Items != null)
                {
                    lstPatInfo.Items.Clear();
                    if (patList != null)
                    {
                        foreach (FY_MZ_Patient pat in patList)
                        {
                            ListViewItem lstItem = new ListViewItem(pat.PatName);
                            lstPatInfo.Items.Add(lstItem);
                            lstItem.SubItems.Add(pat.PatSex);
                            lstItem.SubItems.Add(pat.PatAge);
                            lstItem.SubItems.Add(pat.PerfChar + pat.InvoiceNum);
                            lstItem.Tag = pat;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void MZFrmDrugDispense_Load(object sender, EventArgs e)
        {
            this.chkRefresh.Checked = true;
            this.dgrdRecipeInfo.AutoGenerateColumns = false;
            User currentUser = new User((long)_currentUserId);
            this.txtDespencer.Text = currentUser.Name;
            btnRefresh_Click(null, null);
        }

        private void lstPatInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _recipeTb.Clear();
                _presList = mz_Interface.GetPrescriptions(_currentPat, _drFlag);
                if (_presList.Rows.Count <= 0)
                {
                    dgrdRecipeMaster.AutoGenerateColumns = false;
                    dgrdRecipeMaster.DataSource = _presList;
                    if (dgrdRecipeInfo.DataSource != null)
                    {
                        ((DataTable)dgrdRecipeInfo.DataSource).Rows.Clear();
                    }
                    return;
                }
                if (tabPagDrugMessage.SelectedTab == pageDisp)
                {
                    this.txtDespencer.Text = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE).GetDispenserName(_currentPat.InvoiceNum,
                        (int)_currentDeptId);
                }
                dgrdRecipeMaster.AutoGenerateColumns = false;
                dgrdRecipeMaster.DataSource = _presList;
                for (int index = 0; index < _presList.Rows.Count; index++)
                {
                    Prescription pres = GetPresFromDt(index);
                    DataTable recipeDt = mz_Interface.GetPrescriptionDetails(pres);
                    _recipeTb.Add(pres.PrescriptionID, recipeDt);
                }
                dgrdRecipeInfo.DataSource = mz_Interface.GetPrescriptionDetails(GetPresFromDt(0));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void MZFrmDrugDispense_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F2:
                    btnDispense_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void txtQueryNum1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //发药模式为门诊发药
                if (e.KeyValue == 13)
                {
                    if (this.txtQueryNum.Text.Trim() == "")
                    {
                        return;
                    }
                    lstPatInfo.Items.Clear();
                    _currentPat = mz_Interface.GetPatient(txtFirstInvoice.Text, txtQueryNum.Text, (int)_currentDeptId, _drFlag);
                    ListViewItem lstItem = new ListViewItem(_currentPat.PatName);
                    lstPatInfo.Items.Add(lstItem);
                    lstItem.SubItems.Add(_currentPat.PatSex);
                    lstItem.SubItems.Add(_currentPat.PatAge);
                    lstItem.SubItems.Add(_currentPat.PerfChar+Convert.ToInt32(_currentPat.InvoiceNum).ToString());
                    lstItem.Tag = _currentPat;
                    ShowCurrentPat();
                    _recipeTb.Clear();
                    _presList = mz_Interface.GetPrescriptions(_currentPat, _drFlag);
                    dgrdRecipeMaster.DataSource = _presList;
                    if (_presList != null)
                    {
                        for (int index = 0; index < _presList.Rows.Count; index++)
                        {
                            Prescription pres = GetPresFromDt(index);
                            DataTable recipeDt = mz_Interface.GetPrescriptionDetails(pres);
                            _recipeTb.Add(pres.PrescriptionID, recipeDt);
                        }
                        if (_presList.Rows.Count > 0)
                        {
                            dgrdRecipeInfo.DataSource = mz_Interface.GetPrescriptionDetails(GetPresFromDt(0));
                        }
                    }
                    this.btnDispense.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private Prescription GetPresFromDt(int index)
        {
            try
            {
                if (_presList == null)
                {
                    return null;
                }
                if (_presList.Rows.Count <= 0)
                {
                    return null;
                }
                DataRow dRow = _presList.Rows[index];
                Prescription _currentPres = new Prescription();
                _currentPres.Charge_Flag = Convert.ToInt32(dRow["Charge_Flag"]);//收费标志
                _currentPres.ChargeCode = dRow["ChargeCode"].ToString();
                _currentPres.ChargeID = Convert.ToInt32(dRow["ChargeID"]);
                _currentPres.Drug_Flag = Convert.ToInt32(dRow["Drug_Flag"]);
                _currentPres.ExecDeptCode = dRow["ExecDeptCode"].ToString();
                _currentPres.ExecDocCode = dRow["ExecDocCode"].ToString();
                _currentPres.exeDocName = dRow["exeDocName"].ToString();
                _currentPres.PatientID = Convert.ToDecimal(dRow["PatientID"]);
                _currentPres.PatientName = dRow["PatientName"].ToString();
                _currentPres.presAmount = dRow["presAmount"].ToString();
                _currentPres.PrescriptionID = Convert.ToInt32(dRow["PrescriptionID"]);
                _currentPres.PrescType = dRow["PrescType"].ToString();
                _currentPres.PresDate = Convert.ToDateTime(dRow["PresDate"]);
                _currentPres.PresDeptCode = dRow["PresDeptCode"].ToString();
                _currentPres.presDeptName = dRow["presDeptName"].ToString();
                _currentPres.PresDocCode = dRow["PresDocCode"].ToString();
                _currentPres.Record_Flag = Convert.ToInt32(dRow["Record_Flag"]);
                _currentPres.RegisterID = Convert.ToInt32(dRow["RegisterID"]);
                _currentPres.TicketNum = dRow["TicketNum"].ToString();
                _currentPres.TicketCode = dRow["TicketCode"].ToString();
                _currentPres.Total_Fee = Convert.ToDecimal(dRow["Total_Fee"]);
                return _currentPres;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void dgrdRecipeMaster_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgrdRecipeMaster.CurrentCell != null)
                {
                    int index = dgrdRecipeMaster.CurrentCell.RowIndex;
                    if (index >= 0)
                    {
                        int presId = GetPresFromDt(index).PrescriptionID;
                        dgrdRecipeInfo.DataSource = _recipeTb[presId];
                        DataTable dt = (DataTable)_recipeTb[presId];
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnRefreshDisp_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                lstPatInfo.Items.Clear();
                string beginTime = (cobBeginDate.Value).ToString("yyyy-MM-dd") + @" 00:00:00";
                string endTime = (cobEndDate.Value).ToString("yyyy-MM-dd") + @" 23:59:59";
                List<FY_MZ_Patient> patList = mz_Interface.GetPatient((int)_currentDeptId,
                    Convert.ToDateTime(beginTime), Convert.ToDateTime(endTime), _drFlag);
                LstRecipeBind(patList);
                lstPatInfo_SelectedIndexChanged(null, null);
                lstPatInfo_DoubleClick(null, null);

            }
            catch (Exception error)
            {
                if (error.Message != "输入的发票号没有知道对应的处方头信息")
                {
                    MessageBox.Show(error.Message);
                }
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
        }

        private void tabPagDrugMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabPagDrugMessage.SelectedTab == pageDisp)
                {
                    _drFlag = 1;
                    btnDispense.Visible = false;
                    btnRefreshDisp_Click(null, null);
                }
                else
                {
                    _drFlag = 0;
                    btnDispense.Visible = true;
                    btnRefresh_Click(null, null);
                    this.txtDespencer.Text = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName((int)_currentUserId);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnPrintTransfu_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentPat.InvoiceNum != "")
                {
                    mz_Interface.PrintTransfuCard(_currentPat.InvoiceNum, txtDespencer.Text);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dgrdRecipeMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (e.ColumnIndex == dgrdRecipeMaster.Columns["colBtnPrint"].Index)
                {
                    int rowIndex = e.RowIndex;
                    if (rowIndex >= 0)
                    {
                        DataRow currentRow = _presList.Rows[rowIndex];
                        if (currentRow == null)
                            return;
                        if (currentRow["PrescriptionID"] == DBNull.Value)
                            return;
                        int recipeNo = Convert.ToInt32(currentRow["PrescriptionID"]);
                        mz_Interface.PrintDocPres(recipeNo);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
        }

        private void chkIsShowUseWay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsShowUseWay.Checked)
            {
                dgrdRecipeInfo.Columns["ColFreQuency"].Visible = true;
                dgrdRecipeInfo.Columns["ColUseWay"].Visible = true;
                dgrdRecipeInfo.Columns["ColEntrust"].Visible = true;
                dgrdRecipeInfo.Columns["ColUseNum"].Visible = true;
                dgrdRecipeInfo.Columns["ColUseUnit"].Visible = true;
            }
            else
            {
                dgrdRecipeInfo.Columns["ColFreQuency"].Visible = false;
                dgrdRecipeInfo.Columns["ColUseWay"].Visible = false;
                dgrdRecipeInfo.Columns["ColEntrust"].Visible = false;
                dgrdRecipeInfo.Columns["ColUseNum"].Visible = false;
                dgrdRecipeInfo.Columns["ColUseUnit"].Visible = false;
            }
        }

        private void txtQueryNum_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //发药模式为门诊发药
                if (e.KeyValue == 13)
                {
                    if (this.txtQueryNum.Text.Trim() == "")
                    {
                        return;
                    }
                    lstPatInfo.Items.Clear();
                    _currentPat = mz_Interface.GetPatient(txtFirstInvoice.Text, txtQueryNum.Text, (int)_currentDeptId, _drFlag);
                    ListViewItem lstItem = new ListViewItem(_currentPat.PatName);
                    lstPatInfo.Items.Add(lstItem);
                    lstItem.SubItems.Add(_currentPat.PatSex);
                    lstItem.SubItems.Add(_currentPat.PatAge);
                    lstItem.SubItems.Add(_currentPat.PerfChar + Convert.ToInt32(_currentPat.InvoiceNum).ToString());
                    lstItem.Tag = _currentPat;
                    ShowCurrentPat();
                    _recipeTb.Clear();
                    _presList = mz_Interface.GetPrescriptions(_currentPat, _drFlag);
                    dgrdRecipeMaster.DataSource = _presList;
                    if (_presList != null)
                    {
                        for (int index = 0; index < _presList.Rows.Count; index++)
                        {
                            Prescription pres = GetPresFromDt(index);
                            DataTable recipeDt = mz_Interface.GetPrescriptionDetails(pres);
                            _recipeTb.Add(pres.PrescriptionID, recipeDt);
                        }
                        if (_presList.Rows.Count > 0)
                        {
                            dgrdRecipeInfo.DataSource = mz_Interface.GetPrescriptionDetails(GetPresFromDt(0));
                        }
                    }
                    this.btnDispense.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
      
    }
}
