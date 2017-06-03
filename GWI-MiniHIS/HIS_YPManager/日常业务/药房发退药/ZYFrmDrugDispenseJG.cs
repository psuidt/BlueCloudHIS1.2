using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Model;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;

namespace HIS_YPManager
{
    public partial class ZYFrmDrugDispenseJG : GWI.HIS.Windows.Controls.BaseMainForm
    {
        long _currentUserId;
        long _currentDeptId;
        string _chineseName;
        private int _searchDeptId;
        private string _searchDeptName;
        private ZY_PatList _currentZYPat;
        private DataTable _recipeOrder = null;
        private DataTable _deptDt;
        private BillProcessor _billProcessor;
        private Hashtable _allDispPats = new Hashtable();
        /// <summary>
        /// 1表住院单人发药，2表住院统领发药
        /// </summary>
        private short _dispenseModel;

        public ZYFrmDrugDispenseJG()
        {
            InitializeComponent();
        }

        public ZYFrmDrugDispenseJG(long currentUserId, long currentDeptId, string chineseName)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            InitializeComponent();
            this.Text = _chineseName;
            _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_DISPENSE + "ZY_ECONOMY");
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInpatNum_Click(object sender, EventArgs e)
        {
            this.lblQueryNum.Text = "住院号";
            this.btnRefresh.Visible = true;
            this._dispenseModel = 1;
            txtDeptDraw.Visible = false;
            this.txtQueryNum.Focus();
            lstPatInfo.CheckBoxes = false;
            dgrdRecipeInfo.Columns["ISDISPENSE"].ReadOnly = false;
            Clear();
        }

        private void btnDispense_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal newDispFee = 0;
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (ConfigManager.IsChecking(_currentDeptId) == true)
                {
                    MessageBox.Show("药品正在盘点中......");
                    return;
                }
                if (this._recipeOrder == null)
                {
                    MessageBox.Show("没有药品可发");
                    return;
                }
                if (this._recipeOrder.Rows.Count < 1)
                {
                    MessageBox.Show("没有药品可发");
                    return;
                }               
                if (_dispenseModel == 1)
                {
                    if (_currentZYPat == null)
                    {
                        MessageBox.Show("没有病人需要发药");
                        return;
                    }
                    YP_DRMaster dispMaster = _billProcessor.BuildNewDispenseMaster(_currentZYPat, (int)_currentDeptId, (int)_currentUserId);
                    newDispFee = IN_InterFace.QueryPatDispFee(_currentZYPat, (int)_currentDeptId);
                    if (this.CompareFee(newDispFee) == false)
                    {
                        MessageBox.Show("该病人因费用冲账发药信息需要刷新，请重新刷新");
                        return;
                    }
                    if (_recipeOrder != null)
                    {
                        List<BillOrder> dispList = _billProcessor.BuildNewDispOrder(_recipeOrder, dispMaster, _dispenseModel);
                        _billProcessor.SaveBill(dispMaster, dispList, _currentDeptId);
                        MessageBox.Show("发药成功...", "发药成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        _recipeOrder = IN_InterFace.QueryRecipeOrder(_currentZYPat, (int)_currentDeptId);
                        dgrdRecipeInfo.DataSource = _recipeOrder;
                    }
                }
                //如果是住院统领
                else
                {
                    ZY_PatList dispPat;
                    for (int index = 0; index < lstPatInfo.CheckedItems.Count; index++)
                    {
                        dispPat = (ZY_PatList)lstPatInfo.CheckedItems[index].Tag;
                        newDispFee += IN_InterFace.QueryPatDispFee(dispPat, (int)_currentDeptId);
                    }
                    if (CompareFee(newDispFee) == false)
                    {
                        MessageBox.Show("有病人因费用冲账发药信息需要刷新，请重新刷新");
                        return;
                    }                   
                    List<BillMaster> dispList = new List<BillMaster>();
                    for (int index = 0; index < lstPatInfo.CheckedItems.Count; index++)
                    {
                        dispPat = (ZY_PatList)lstPatInfo.CheckedItems[index].Tag;
                        YP_DRMaster dispMaster = _billProcessor.BuildNewDispenseMaster(dispPat, (int)_currentDeptId, (int)_currentUserId);
                        dispList.Add(dispMaster);
                    }
                    YP_DispDeptHis newDispDept = (YP_DispDeptHis)(_billProcessor.SaveBills(dispList, _searchDeptId, _allDispPats));                    
                    MessageBox.Show("发药成功,开始打印统领发药单据...", "发药成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    PrintDispTL(dispList, newDispDept);
                    LoadTLMessage();

                }
                this.txtQueryNum.Focus();
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

        private bool CompareFee(decimal newTotalFee)
        {
            if (_recipeOrder != null)
            {
                decimal currentFee = 0;
                for (int index = 0; index < _recipeOrder.Rows.Count; index++)
                {
                    currentFee += Convert.ToDecimal(_recipeOrder.Rows[index]["TOLAL_FEE"]);
                }
                if (currentFee == newTotalFee)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void PrintDispTL(List<BillMaster> printList, YP_DispDeptHis uniformMaster)
        {
            string startPath = Application.StartupPath + "\\report\\统领发药单据(经管).grf";
            PrintFactory.GetPrinter(ConfigManager.OP_YF_DISPENSE + "ZY_TL").PrintBill(uniformMaster, _recipeOrder,
                startPath, (int)_currentUserId);
            if (MessageBox.Show("发药成功,是否需要打印摆药单？", "发药成功",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                startPath = Application.StartupPath + "\\report\\住院摆药单(经管).grf";
                foreach (YP_DRMaster printMaster in printList)
                {
                    PrintFactory.GetPrinter(ConfigManager.OP_YF_DISPENSE + "ZY_BY").PrintBill(printMaster, null,
                    startPath, (int)_currentUserId);
                }
            }
        }
        private void ShowCurrentPat()
        {
            DateTime currentTime = XcDate.ServerDateTime;
            this.txtPatName.Text = XcConvert.IsNull(_currentZYPat.PatientInfo.PatName, "拒绝");
            this.txtPatAge.Text = Age.GetAgeString(_currentZYPat.PatientInfo.PatBriDate, currentTime, 1);
            this.txtPatSex.Text = XcConvert.IsNull(_currentZYPat.PatientInfo.PatSex, "拒绝");
            this.txtQueryNum.Text = XcConvert.IsNull(_currentZYPat.CureNo, "00000000");
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (_dispenseModel == 1)
                {
                    lstPatInfo.Items.Clear();
                    List<ZY_PatList> patList = IN_InterFace.QueryAllZYPat();
                    LstPatBind(patList);
                }
                else
                {
                    LoadTLMessage();
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

        private void lstPatInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstPatInfo.Items.Count > 0)
            {
                if (lstPatInfo.SelectedItems.Count != 0)
                {
                    ListViewItem selectItem = lstPatInfo.SelectedItems[0];
                    _currentZYPat = (ZY_PatList)selectItem.Tag;
                    ShowCurrentPat();
                }
            }
        }

        private void LstPatBind(List<ZY_PatList> patList)
        {
            try
            {
                if (lstPatInfo != null)
                {
                    lstPatInfo.Items.Clear();
                    if (patList != null)
                    {
                        foreach (ZY_PatList pat in patList)
                        {
                            DateTime currentTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                            ListViewItem lstItem = new ListViewItem(pat.PatientInfo.PatName);
                            lstPatInfo.Items.Add(lstItem);
                            lstItem.SubItems.Add(pat.PatientInfo.PatSex);
                            lstItem.SubItems.Add(Age.GetAgeString(pat.PatientInfo.PatBriDate, currentTime, 1));
                            lstItem.Tag = pat;
                            lstItem.Checked = true;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void ZYFrmDrugDispense_Load(object sender, EventArgs e)
        {
            this.dgrdRecipeInfo.AutoGenerateColumns = false;
            User currentUser = new User((long)(long)_currentUserId);
            this.txtDespencer.Text = currentUser.Name;
            this._dispenseModel = 1;
            LoadData();
            btnInpatNum_Click(null, null);
            btnRefresh_Click(null, null);
        }

        private void LoadData()
        {
            try
            {
                _deptDt = IN_InterFace.LoadClinicDept();
                txtDeptDraw.SetSelectionCardDataSource(_deptDt);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void lstPatInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (_dispenseModel == 1)
                {
                    _recipeOrder = IN_InterFace.QueryRecipeOrder(_currentZYPat, (int)_currentDeptId);
                    dgrdRecipeInfo.DataSource = _recipeOrder;
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

        private void report_FetchRecord(ref bool Eof)
        {
            if (_dispenseModel == 1)
            {
                for (int index = 0; index < _recipeOrder.Rows.Count; index++)
                {
                    if (_recipeOrder.Rows[index]["ISDISPENSE"] == DBNull.Value)
                    {
                        _recipeOrder.Rows.RemoveAt(index);
                    }
                }
            }
        }

        private void Clear()
        {
            _currentZYPat = null;
            if (_recipeOrder != null)
            {
                _recipeOrder.Clear();
            }
            if (lstPatInfo != null)
            {
                lstPatInfo.Items.Clear();
            }
            _allDispPats.Clear();
            this.txtPatName.Clear();
            this.txtPatSex.Clear();
            this.txtPatAge.Clear();
            this.txtQueryNum.Clear();
            this.txtQueryNum.Focus();
        }

        private void btnUnifDept_Click(object sender, EventArgs e)
        {
            lblQueryNum.Text = "科室号";
            //btnRefresh.Visible = false;
            txtQueryNum.Focus();
            _dispenseModel = 2;
            lstPatInfo.ItemChecked -= new ItemCheckedEventHandler(lstPatInfo_ItemChecked);
            lstPatInfo.CheckBoxes = true;
            lstPatInfo.ItemChecked += new ItemCheckedEventHandler(lstPatInfo_ItemChecked);
            txtDeptDraw.Visible = true; 
            Clear();
            dgrdRecipeInfo.Columns["ISDISPENSE"].ReadOnly = true;
            txtDeptDraw.Focus();
        }

        private void ZYFrmDrugDispense_KeyDown(object sender, KeyEventArgs e)
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

        private void LoadTLMessage()
        {
            List<ZY_PatList> patList = IN_InterFace.QueryAllZYPat((int)_currentDeptId, _searchDeptId);
            ZY_PatList nullPat = new ZY_PatList();
            nullPat.PatListID = 0;
            _recipeOrder = IN_InterFace.QueryRecipeOrder(nullPat, (int)_currentDeptId);
            dgrdRecipeInfo.DataSource = _recipeOrder;
            _allDispPats.Clear();
            foreach (ZY_PatList pat in patList)
            {
                DataTable singleOrder = IN_InterFace.QueryRecipeOrder(pat, (int)_currentDeptId);
                _allDispPats.Add(pat.CureNo, singleOrder);
            }
            LstPatBind(patList);
        }

        private void lstPatInfo_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (_dispenseModel == 2 && e.Item.Tag!= null)
                {
                    ListViewItem selectItem = e.Item;
                    if (selectItem.Checked == true)
                    {
                        ZY_PatList pat = (ZY_PatList)selectItem.Tag;
                        DataTable recipeDt = (DataTable)_allDispPats[pat.CureNo];
                        AddRecipeOrder(_recipeOrder, recipeDt);
                    }
                    else
                    {
                        ZY_PatList pat = (ZY_PatList)selectItem.Tag;
                        DataTable recipeDt = (DataTable)_allDispPats[pat.CureNo];
                        RemoveRecipeOrder(_recipeOrder, recipeDt);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtQueryNum_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //发药模式为住院发药
                if (_dispenseModel == 1 && e.KeyValue == 13)
                {
                    if (this.txtQueryNum.Text.Trim() == "")
                    {
                        return;
                    }
                    lstPatInfo.Items.Clear();
                    _currentZYPat = IN_InterFace.QueryPatByInpatNum(this.txtQueryNum.Text.Trim());
                    if (_currentZYPat == null)
                    {
                        MessageBox.Show(this.txtQueryNum, "该病人不存在");
                        this.txtQueryNum.Text = "";
                        return;
                    }
                    ListViewItem lstItem = new ListViewItem(_currentZYPat.PatientInfo.PatName);
                    lstPatInfo.Items.Add(lstItem);
                    lstItem.SubItems.Add(_currentZYPat.PatientInfo.PatSex);
                    lstItem.SubItems.Add(_currentZYPat.PatientInfo.PatBriDate.ToString("yyyy-mm-dd"));
                    lstItem.Tag = _currentZYPat;
                    lstPatInfo.Items[0].Selected = true;
                    lstPatInfo_DoubleClick(null, null);
                    ShowCurrentPat();
                    this.btnDispense.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }


        private void txtDeptDraw_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (_dispenseModel == 2)
            {
                DataRow dr = (DataRow)SelectedValue;
                if (dr != null)
                {
                    _searchDeptId = Convert.ToInt32(txtDeptDraw.MemberValue);
                    _searchDeptName = dr["NAME"].ToString();
                    this.btnRefresh.Focus();
                }
            }
        }

        /// <summary>
        /// 添加处方明细表信息到统领处方明细表中
        /// </summary>
        /// <param name="goalRecipe">
        /// 统领处方明细表
        /// </param>
        /// <param name="srcRecipe">
        /// 欲添加的处方明细表
        /// </param>
        private void AddRecipeOrder(DataTable goalRecipe, DataTable srcRecipe)
        {
            try
            {
                DataRow srcRow;
                DataRow goalRow;
                bool isInGoalRecipe = false;
                if (srcRecipe == null || goalRecipe == null)
                {
                    return;
                }
                for (int index = 0; index < srcRecipe.Rows.Count; index++)
                {
                    srcRow = srcRecipe.Rows[index];
                    isInGoalRecipe = false;
                    for (int temp = 0; temp < goalRecipe.Rows.Count; temp++)
                    {
                        goalRow = goalRecipe.Rows[temp];
                        if (srcRow["ITEMID"].Equals(goalRow["ITEMID"]))
                        {
                            Decimal goalNum = Convert.ToDecimal(goalRow["AMOUNT"]);
                            Decimal srcNum = Convert.ToDecimal(srcRow["AMOUNT"]);
                            Decimal goalFee = Convert.ToDecimal(goalRow["TOLAL_FEE"]);                            
                            Decimal srcFee = Convert.ToDecimal(srcRow["TOLAL_FEE"]);
                            goalNum += srcNum;
                            goalRow["AMOUNT"] = goalNum;
                            goalRow["TOLAL_FEE"] = goalFee + srcFee;
                            isInGoalRecipe = true;
                            break;
                        }
                    }
                    if (isInGoalRecipe == false)
                    {
                        goalRecipe.Rows.Add(srcRow.ItemArray);
                    }
                }
                //按剂型排序
                goalRecipe.DefaultView.Sort = "DOSEDICID ASC";
                goalRecipe = goalRecipe.DefaultView.ToTable();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 从处方明细总表中删除特定的处方明细表
        /// </summary>
        /// <param name="goalRecipe">处方明细总表</param>
        /// <param name="srcRecipe">欲删除的处方明细表</param>
        private void RemoveRecipeOrder(DataTable goalRecipe, DataTable srcRecipe)
        {
            try
            {
                DataRow srcRow;
                DataRow goalRow;
                if (srcRecipe == null || goalRecipe == null)
                {
                    return;
                }
                else
                {
                    for (int index = 0; index < srcRecipe.Rows.Count; index++)
                    {
                        srcRow = srcRecipe.Rows[index];
                        for (int temp = 0; temp < goalRecipe.Rows.Count; temp++)
                        {
                            goalRow = goalRecipe.Rows[temp];
                            if (srcRow["ITEMID"].Equals(goalRow["ITEMID"]))
                            {
                                Decimal goalNum = Convert.ToDecimal(goalRow["AMOUNT"]);
                                Decimal srcNum = Convert.ToDecimal(srcRow["AMOUNT"]);
                                Decimal goalFee = Convert.ToDecimal(goalRow["TOLAL_FEE"]);
                                Decimal srcFee = Convert.ToDecimal(srcRow["TOLAL_FEE"]);
                                if (srcNum < goalNum)
                                {
                                    goalNum -= srcNum;
                                    goalRow["AMOUNT"] = goalNum;
                                    goalRow["TOLAL_FEE"] = goalFee - srcFee;
                                }
                                else if (srcNum == goalNum)
                                {
                                    goalRecipe.Rows.Remove(goalRow);
                                }
                            }
                        }
                    }
                    //按剂型排序
                    goalRecipe.DefaultView.Sort = "DOSEDICID ASC";
                    goalRecipe = goalRecipe.DefaultView.ToTable();
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }


    }
}
