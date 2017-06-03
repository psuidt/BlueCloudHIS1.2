using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using HIS.Model;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.Interface;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;

namespace HIS_YPManager
{
    public partial class ZYFrmPresDispense : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private long _currentUserId;
        private long _currentDeptId;
        private int _searchDeptId;
        private int _selectDeptId;
        private DataTable _recipeOrder = null;
        private DataTable _totalOrder = new DataTable();
        private DataTable _deptDt;
        private BillProcessor _billProcessor;
        private IZY_Data _zyInterFace = new ZY_Data();
        private List<ZY_PatList> selectPat = new List<ZY_PatList>();
        private Hashtable _allDispPats = new Hashtable();
        private DataTable _dispMasterDt;
        private DataTable _dispOrderDt;
        private YP_DRMaster _currentMaster = new YP_DRMaster();

        public ZYFrmPresDispense(long currentUserId, long currentDeptId)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            InitializeComponent();
            _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_DISPENSE + "ZY_ECONOMY");
        }

        private void ZYFrmPresDispense_Load(object sender, EventArgs e)
        {
            this.dgrdRecipeInfo.AutoGenerateColumns = false;
            User currentUser = new User((long)(long)_currentUserId);
            this.txtDespencer.Text = currentUser.Name;           
            LoadData();
            btnRefresh_Click(null, null);
        }

        private void LoadData()
        {
            try
            {
                _deptDt = IN_InterFace.LoadClinicDept();
                if (_deptDt != null)
                {
                    DataRow allDeptRow = _deptDt.NewRow();
                    allDeptRow["DEPT_ID"] = 0;
                    allDeptRow["NAME"] = "全院科室";
                    allDeptRow["WB_CODE"] = "qyks";
                    allDeptRow["PY_CODE"] = "qyks";
                    _deptDt.PrimaryKey = new DataColumn[] { _deptDt.Columns["DEPT_ID"] };
                    _deptDt.Rows.Add(allDeptRow);
                }
                txtDeptDraw.SetSelectionCardDataSource(_deptDt);

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                dgrdRecipeInfo.DataSource = null;
                LoadMsgMaster();
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

        /// <summary>
        /// 加载待发药信息列表
        /// </summary>
        private void LoadMsgMaster()
        {

            selectPat.Clear();
            _allDispPats.Clear();
            try
            {
                if (_recipeOrder != null)
                {
                    _recipeOrder.Rows.Clear();
                    _recipeOrder = null;
                }
                treeDrugMsg.Nodes.Clear();
                TreeNode allDeptNode = new TreeNode("全院科室");
                allDeptNode.Tag = 0;
                allDeptNode.ImageIndex = 0;
                treeDrugMsg.Nodes.Add(allDeptNode);
                //如果加载全院科室
                if (_searchDeptId == 0)
                {
                    for (int index = 0; index < _deptDt.Rows.Count; index++)
                    {
                        TreeNode deptNode = new TreeNode(_deptDt.Rows[index]["NAME"].ToString());
                        deptNode.ImageIndex = 0;
                        deptNode.Tag = Convert.ToInt32(_deptDt.Rows[index]["DEPT_ID"]);
                        if (Convert.ToInt32(deptNode.Tag) > 0)
                        {
                            allDeptNode.Nodes.Add(deptNode);
                            deptNode.Expand();
                            AddMsgToDeptNode(Convert.ToInt32(_deptDt.Rows[index]["DEPT_ID"]), deptNode);
                        }
                    }
                }
                //如果加载单个科室
                else
                {
                    DataRow selectRow = _deptDt.Rows.Find(_searchDeptId);
                    TreeNode deptNode = new TreeNode(selectRow["NAME"].ToString());
                    deptNode.ImageIndex = 0;
                    deptNode.Tag = Convert.ToInt32(selectRow["DEPT_ID"]);
                    allDeptNode.Nodes.Add(deptNode);
                    deptNode.Expand();
                    AddMsgToDeptNode(Convert.ToInt32(selectRow["DEPT_ID"]), deptNode);
                }
                allDeptNode.Expand();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        /// <summary>
        /// 加载发药消息头到科室节点
        /// </summary>
        /// <param name="msgMasters">待发药消息头列表</param>
        /// <param name="deptNode">科室节点</param>
        private void AddMsgToDeptNode(int _searchDeptId, TreeNode deptNode)
        {

            List<HIS.Model.ZY_PatList> patlist = IN_InterFace.QueryAllZYPat(Convert.ToInt32(_currentDeptId), _searchDeptId);
            if (patlist != null)
            {
                foreach (ZY_PatList pat in patlist)
                {
                    {
                        TreeNode msgNode = new TreeNode(pat.PatientInfo.PatName + "__" + pat.CureNo + "__" + pat.PatientInfo.PatSex);
                        msgNode.Tag = pat;
                        deptNode.Nodes.Add(msgNode);
                    }
                }
            }
        }

        private void treeDrugMsg_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgrdRecipeInfo.DataSource;
                if (e.Node != null)
                {
                    this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                    if (e.Node.Level == 2 && e.Node.Checked)
                    {
                        ZY_PatList currentMsg = (ZY_PatList)(e.Node.Tag);
                        _selectDeptId = Convert.ToInt32(currentMsg.CurrDeptCode);
                        selectPat.Remove(currentMsg);
                        selectPat.Add(currentMsg);
                        TreeNode rootNode = treeDrugMsg.Nodes[0];
                        foreach (TreeNode node in rootNode.Nodes)
                        {
                            foreach (TreeNode msgNode in node.Nodes)
                            {
                                if (((ZY_PatList)msgNode.Tag).CurrDeptCode != currentMsg.CurrDeptCode
                                    && msgNode.Checked == true)
                                {
                                    msgNode.Parent.Checked = false;
                                    break;
                                }
                            }
                        }
                        _allDispPats.Remove(currentMsg.CureNo);
                        if (dt != null)
                        {
                            DataTable recipeDt = IN_InterFace.QueryRecipeOrder(currentMsg, (int)_currentDeptId);
                            _allDispPats.Add(currentMsg.CureNo, recipeDt);
                            DataTable recipeCopy = recipeDt.Clone();
                            recipeCopy.Clear();                         
                            
                            for (int index = 0; index < recipeDt.Rows.Count; index++)
                            {
                               // _recipeOrder.Rows.Add(recipeDt.Rows[index].ItemArray);
                                recipeCopy.Rows.Add(recipeDt.Rows[index].ItemArray);
                                decimal presamount = (recipeCopy.Rows[index]["presamount"] == null || recipeCopy.Rows[index]["presamount"].ToString() == "0" ? 1 : Convert.ToDecimal(recipeCopy.Rows[index]["presamount"].ToString()));
                                recipeCopy.Rows[index]["amount"] = Convert.ToDecimal(recipeCopy.Rows[index]["amount"].ToString()) / presamount;
                                dt.Rows.Add(recipeCopy.Rows[index].ItemArray);
                            }
                            dgrdRecipeInfo.DataSource = dt;
                        }
                        else
                        {
                            _recipeOrder = IN_InterFace.QueryRecipeOrder(currentMsg, (int)_currentDeptId);
                            _allDispPats.Add(currentMsg.CureNo, _recipeOrder);
                            DataTable dtCopy = _recipeOrder.Clone();
                            dtCopy.Clear();
                            for (int i = 0; i < _recipeOrder.Rows.Count; i++)
                            {
                                dtCopy.Rows.Add(_recipeOrder.Rows[i].ItemArray);
                                decimal presamount = (dtCopy.Rows[i]["presamount"] == null || dtCopy.Rows[i]["presamount"].ToString() == "0" ? 1 : Convert.ToDecimal(dtCopy.Rows[i]["presamount"].ToString()));
                                dtCopy.Rows[i]["amount"] = Convert.ToDecimal(dtCopy.Rows[i]["amount"].ToString()) / presamount;                                
                            }
                            dgrdRecipeInfo.DataSource = dtCopy;
                        }
                    }
                    if (e.Node.Level == 2 && !e.Node.Checked)
                    {
                        ZY_PatList currentMsg = (ZY_PatList)(e.Node.Tag);
                        selectPat.Remove(currentMsg);
                        _allDispPats.Remove(currentMsg.CureNo);
                        if (_recipeOrder != null)
                        {
                            DataRow[] removeRows = dt.Select("cureno=" + "'" + currentMsg.CureNo.ToString() + "'");
                            foreach (DataRow removeRow in removeRows)
                            {
                                dt.Rows.Remove(removeRow);
                            }
                        }
                        dgrdRecipeInfo.DataSource = dt;
                    }
                    if ((e.Node.Level == 2 && e.Node.Checked) ||
                        (e.Node.Level == 1 && e.Node.Checked))
                    {
                        e.Node.Parent.Checked = true;
                    }
                    if ((e.Node.Level == 1 && !e.Node.Checked) ||
                        (e.Node.Level == 0 && !e.Node.Checked))
                    {
                        foreach (TreeNode node in e.Node.Nodes)
                        {
                            node.Checked = false;
                        }
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

        // 显示病人卡信息
        private void ShowCurrentPat(string cureNo)
        {
            string outMsg = "";
            DataRow patInfo = _zyInterFace.GetPatCardInfo(cureNo);
            this.inPatientPanel.BindDataRow(patInfo, out outMsg);
        }

        private void treeDrugMsg_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tabMsgMaster.SelectedIndex == 0 && e.Node != null)
            {
                if (e.Node.Level == 2)
                {
                    ShowCurrentPat(((ZY_PatList)e.Node.Tag).CureNo);
                }
            }
            else if (tabMsgMaster.SelectedIndex == 1 && e.Node != null)
            {
                try
                {
                    if (e.Node.Level == 2)
                    {
                        BillQuery _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE);
                        dgrdDROrder.AutoGenerateColumns = false;
                        dgrdDROrder.ClearLines();
                        DataTable dt = _dispMasterDt.Clone();
                        dt.Clear();
                        dt.Rows.Add(((DataRow)e.Node.Tag).ItemArray);
                        HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, 0, _currentMaster);
                        DataTable dtDrugs = _billQuery.LoadOrder(_currentMaster);
                        for (int i = 0; i < dtDrugs.Rows.Count; i++)
                        {
                            decimal presamount = (dtDrugs.Rows[i]["recipenum"] == null || dtDrugs.Rows[i]["recipenum"].ToString() == "0" ? 1 : Convert.ToDecimal(dtDrugs.Rows[i]["recipenum"].ToString()));
                            dtDrugs.Rows[i]["drugocnum"] = Convert.ToDecimal(dtDrugs.Rows[i]["drugocnum"].ToString()) / presamount;
                        }
                        if (_currentMaster.OpType == "004")
                        {
                            for (int i = 0; i < dtDrugs.Rows.Count; i++)
                            {
                                dtDrugs.Rows[i]["drugocnum"] = -1 * Convert.ToDecimal(dtDrugs.Rows[i]["drugocnum"]);
                                dtDrugs.Rows[i]["recipenum"] = -1 * Convert.ToDecimal(dtDrugs.Rows[i]["recipenum"]);
                            }
                        }
                        dgrdDROrder.DataSource = dtDrugs;
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
        }

        private void btnPutDrug_Click(object sender, EventArgs e)
        {
            if (tabMsgMaster.SelectedIndex == 0)
            {
                PrintBy();
            }
            else if (tabMsgMaster.SelectedIndex == 1)
            {
                string startPath = Application.StartupPath + "\\report\\住院已发药摆药单(经管).grf";

                PrintFactory.GetPrinter(ConfigManager.OP_YF_DISPENSE + "ZY_BY").PrintBill(_currentMaster, null,
                startPath, (int)_currentUserId);

            }
        }

        private void txtDeptDraw_AfterSelectedRow(object sender, object SelectedValue)
        {
            DataRow dr = (DataRow)SelectedValue;
            if (dr != null)
            {
                _searchDeptId = Convert.ToInt32(txtDeptDraw.MemberValue);
                this.btnRefresh.Focus();
            }
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

                for (int index = 0; index < selectPat.Count; index++)
                {
                    newDispFee += IN_InterFace.QueryPatDispFee(selectPat[index], (int)_currentDeptId);
                }
                if (CompareFee(newDispFee) == false)
                {
                    MessageBox.Show("有病人因费用冲账发药信息需要刷新，请重新刷新");
                    return;
                }
                List<BillMaster> dispList = new List<BillMaster>();
                for (int index = 0; index < selectPat.Count; index++)
                {
                   
                    DataTable dt = (DataTable)_allDispPats[selectPat[index].CureNo];
                    YP_DRMaster dispMaster = _billProcessor.BuildNewDispenseMaster(selectPat[index], (int)_currentDeptId, (int)_currentUserId, 
                                                  Convert.ToInt32(dt.Rows[0]["presamount"].ToString()),Convert.ToInt32(dt.Rows[0]["group_id"].ToString()));
                    dispList.Add(dispMaster);
                    for (int j = 1; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[j]["group_id"].ToString().Trim() != dt.Rows[j - 1]["group_id"].ToString().Trim())
                        {
                            dispMaster = _billProcessor.BuildNewDispenseMaster(selectPat[index], (int)_currentDeptId, (int)_currentUserId,
                                 Convert.ToInt32(dt.Rows[j]["presamount"].ToString()), Convert.ToInt32(dt.Rows[j]["group_id"].ToString()));
                            dispList.Add(dispMaster);    
                        }
                    }                    
                }
                YP_DispDeptHis newDispDept = (YP_DispDeptHis)(_billProcessor.SaveBills(dispList, _searchDeptId, _allDispPats));
                MessageBox.Show("发药成功,开始打印摆药单...", "发药成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                PrintBy();
               // PrintDispTL(dispList, newDispDept);
                dgrdRecipeInfo.DataSource = null;
                LoadMsgMaster();
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
            DataTable dt = (DataTable)dgrdRecipeInfo.DataSource;
            if (dt != null)
            {
                decimal currentFee = 0;
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    currentFee += Convert.ToDecimal(dt.Rows[index]["TOLAL_FEE"]);
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
            for (int i = 0; i < selectPat.Count; i++)
            {
                DataRow[] rows = _recipeOrder.Select("cureno=" + "'" + selectPat[i].CureNo.ToString() + "'");
                if (rows == null || rows.Length == 0)
                {
                    continue;
                }
                DataTable dt = _recipeOrder.Clone();
                dt.Clear();
                for (int j = 0; j < rows.Length; j++)
                {
                    dt.Rows.Add(rows[j].ItemArray);
                }
                PrintFactory.GetPrinter(ConfigManager.OP_YF_DISPENSE + "ZY_TL").PrintBill(uniformMaster, dt,
                 startPath, (int)_currentUserId);
            }
        }

        private void btnQueryDispHis_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                LoadDispHisMaster();
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

        /// <summary>
        /// 加载已发药消息列表
        /// </summary>
        private void LoadDispHisMaster()
        {
            try
            {
                if (_recipeOrder != null)
                {
                    _recipeOrder.Rows.Clear();
                    _recipeOrder = null;
                }

                BillQuery _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE);
                DataTable allMaster = _billQuery.LoadMaster(BuildConditionParams());
                _dispMasterDt = allMaster.Clone();
                foreach (DataRow dr in allMaster.Rows)
                {
                    _dispMasterDt.Rows.Add(dr.ItemArray);
                }
                if (_dispOrderDt != null)
                {
                    _dispOrderDt.Rows.Clear();
                }
                treeDrugMsg.Nodes.Clear();
                TreeNode allDeptNode = new TreeNode("全院科室");
                allDeptNode.Tag = 0;
                allDeptNode.ImageIndex = 0;
                treeDrugMsg.Nodes.Add(allDeptNode);
                for (int index = 0; index < _deptDt.Rows.Count; index++)
                {
                    TreeNode deptNode = new TreeNode(_deptDt.Rows[index]["NAME"].ToString());
                    deptNode.ImageIndex = 0;
                    deptNode.Tag = Convert.ToInt32(_deptDt.Rows[index]["DEPT_ID"]);
                    if (Convert.ToInt32(deptNode.Tag) > 0)
                    {
                        allDeptNode.Nodes.Add(deptNode);
                        DataRow[] rows = _dispMasterDt.Select("currdeptcode='" + deptNode.Tag.ToString().Trim() + "'");
                        if (rows != null && rows.Length > 0)
                        {
                            for (int temp = 0; temp < rows.Length; temp++)
                            {
                                TreeNode msgNode = new TreeNode();
                                string nodetext = rows[temp]["patientname"].ToString() + "-- 发药时间 --" + Convert.ToDateTime(rows[temp]["optime"]).ToString("yyyy-MM-dd HH:mm:ss");
                                msgNode.Text = nodetext;
                                if (rows[temp]["optype"].ToString() == "004")
                                {
                                    msgNode.ForeColor = Color.Red;
                                }
                                msgNode.Tag = rows[temp];
                                deptNode.Nodes.Add(msgNode);
                            }
                        }
                    }
                    deptNode.Expand();
                }
                allDeptNode.Expand();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 构建查询条件列表
        /// </summary>
        private Hashtable BuildConditionParams()
        {
            Hashtable parameters = new Hashtable();
            ConditionParam param = new ConditionParam(QueryConditionType.是否审核, 1, true);
            parameters.Add(param, QueryConditionType.是否审核);
            param = new ConditionParam(QueryConditionType.开始时间, cobBeginDate.Value, true);
            parameters.Add(QueryConditionType.开始时间, param);
            param = new ConditionParam(QueryConditionType.结束时间, cobEndDate.Value, true);
            parameters.Add(QueryConditionType.结束时间, param);
            param = new ConditionParam(QueryConditionType.部门ID, (int)_currentDeptId, true);
            parameters.Add(QueryConditionType.部门ID, param);
            return parameters;
        }

        private void tabMsgMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMsgMaster.SelectedIndex == 1)
            {
                this.treeDrugMsg.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.treeDrugMsg_AfterCheck);
                treeDrugMsg.CheckBoxes = false;
                pnlTotalOrder.Visible = true;
                btnDispense.Enabled = false;
                btnQueryDispHis_Click(null, null);
            }
            else
            {
                this.treeDrugMsg.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeDrugMsg_AfterCheck);
                treeDrugMsg.CheckBoxes = true;
                pnlTotalOrder.Visible = false;
                btnDispense.Enabled = true;
                btnRefresh_Click(null, null);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintBy()
        {
            DataTable dtt = (DataTable)dgrdRecipeInfo.DataSource;
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                string startPath = Application.StartupPath + "\\report\\住院摆药单(经管).grf";
                for (int i = 0; i < selectPat.Count; i++)
                {
                    DataRow[] rows = dtt.Select("cureno=" + "'" + selectPat[i].CureNo.ToString() + "'");
                    if (rows == null || rows.Length == 0)
                    {
                        continue;
                    }
                    DataTable dt = dtt.Clone();
                    dt.Clear();
                    for (int j = 0; j < rows.Length; j++)
                    {
                        dt.Rows.Add(rows[j].ItemArray);
                    }
                    PrintFactory.GetPrinter(ConfigManager.OP_YF_DISPENSE + "ZY_BY").PrintBill(null, dt,
                    startPath, (int)_currentUserId);
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
    }
}
