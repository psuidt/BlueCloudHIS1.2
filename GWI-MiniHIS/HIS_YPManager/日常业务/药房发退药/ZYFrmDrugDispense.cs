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
using HIS.Interface;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;

namespace HIS_YPManager
{
    public partial class ZYFrmDrugDispense : GWI.HIS.Windows.Controls.BaseMainForm
    {
        long _currentUserId;
        long _currentDeptId;
        string _chineseName;
        private int _searchDeptId;
        private int _selectDeptId;
        private DataTable _recipeOrder = null;
        private DataTable _totalOrder = new DataTable();
        private DataTable _deptDt;
        private BillProcessor _billProcessor;
        private Hashtable _allDispPats = new Hashtable();
        private IZY_Data _zyInterFace = new ZY_Data();

        public ZYFrmDrugDispense()
        {
            InitializeComponent();
        }

        public ZYFrmDrugDispense(long currentUserId, long currentDeptId, string chineseName)
        {
            _currentUserId = currentUserId;
            _currentDeptId = currentDeptId;
            _chineseName = chineseName;
            InitializeComponent();
            this.Text = _chineseName;
            _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YF_DISPENSE + "ZY");

        }

        private void ZYFrmDrugDispense_Load(object sender, EventArgs e)
        {
            this.dgrdRecipeInfo.AutoGenerateColumns = false;
            User currentUser = new User((long)(long)_currentUserId);
            this.txtDespencer.Text = currentUser.Name;
            this.cobSumWay.SelectedIndex = 2;
            this.chkIsOnlyPutPO.Checked = false;
            this.chkPrintNoPO.Checked = false ;
            BuildTotalDt();
            this.txtQueryDrug.SetSelectionCardDataSource(StoreFactory.GetQuery(ConfigManager.YF_SYSTEM).LoadDrugInfo((int)_currentDeptId));
            LoadData();
            btnRefresh_Click(null, null);
        }

        #region 自定义方法

        //设置记账明细表的选择
        private void SetRecipeOrderAllSelect(bool isSelect)
        {
            if (_recipeOrder != null)
            {
                if (_recipeOrder.Rows.Count > 0)
                {
                    int value = 1;
                    if (!isSelect)
                    {
                        value = 0;
                    }
                    for (int index = 0; index < _recipeOrder.Rows.Count; index++)
                    {
                        _recipeOrder.Rows[index]["ISDISPENSE"] = value;
                    }
                }
            }
        }

        /// <summary>
        /// 根据发药明细按单个病人构造数据容器（hashtable：key为病人ID,object 为该病人的发药明细）
        /// </summary>
        /// <param name="allDispPats">构建后的数据容器</param>
        /// <returns></returns>
        private List<BillMaster> PutDrugByOrder(Hashtable allDispPats)
        {
            try
            {
                if (allDispPats == null)
                {
                    throw new Exception("发药信息为空");
                }
                allDispPats.Clear();
                List<BillMaster> dispList = new List<BillMaster>();
                for (int index = 0; index < _recipeOrder.Rows.Count; index++)
                {
                    DataRow currentRow = _recipeOrder.Rows[index];
                    if (currentRow["ISDISPENSE"] == DBNull.Value)
                        continue;
                    if (Convert.ToInt32(currentRow["ISDISPENSE"]) == 1)
                    {
                        BillMaster findMaster = dispList.Find(
                            delegate(HIS.Model.BillMaster searchMaster)
                            {
                                YP_DRMaster drMaster = (YP_DRMaster)searchMaster;
                                if (drMaster.DrugOC_Flag == 1 && Convert.ToInt32(currentRow["drugnum"]) >= 0)
                                {
                                    return currentRow["CURENO"].ToString() == ((YP_DRMaster)searchMaster).InpatientID;
                                }
                                else if (drMaster.DrugOC_Flag == 0 && Convert.ToInt32(currentRow["drugnum"]) < 0)
                                {
                                    return currentRow["CURENO"].ToString() == ((YP_DRMaster)searchMaster).InpatientID;
                                }
                                else
                                {
                                    return false;
                                }
                            });
                        if (findMaster == null)
                        {
                            ZY_DispPresInfo presInfo = new ZY_DispPresInfo();
                            presInfo.CureDocCode = currentRow["CUREDOC"].ToString();
                            presInfo.CureNo = currentRow["CURENO"].ToString();
                            presInfo.drFlag = Convert.ToInt32(currentRow["drugnum"]) >= 0 ? 1 : 0;
                            presInfo.opType = presInfo.drFlag == 1 ? ConfigManager.OP_YF_DISPENSE : ConfigManager.OP_YF_REFUND;
                            presInfo.PatListId = Convert.ToInt32(currentRow["PATID"]);
                            presInfo.PatName = currentRow["PATNAME"].ToString();
                            presInfo.presDeptId = Convert.ToInt32(currentRow["CUREDEPT"]);
                            presInfo.recipeNum = 1;
                            YP_DRMaster dispMaster = _billProcessor.BuildNewDispenseMaster(presInfo,
                                (int)_currentDeptId, (int)_currentUserId);
                            dispList.Add(dispMaster);
                            DataTable orderDt = _recipeOrder.Clone();
                            orderDt.Rows.Add(currentRow.ItemArray);
                            allDispPats.Add(dispMaster.InpatientID + dispMaster.DrugOC_Flag.ToString(), orderDt);
                        }
                        else
                        {
                            YP_DRMaster dispMaster = (YP_DRMaster)findMaster;
                            ((DataTable)allDispPats[dispMaster.InpatientID + dispMaster.DrugOC_Flag.ToString()]).Rows.Add(currentRow.ItemArray);
                        }
                    }
                }
                return dispList;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 打印统领单据
        /// </summary>
        /// <param name="uniformMaster">统领单头表</param>
        private void PrintDispTL(YP_DispDeptHis uniformMaster)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                string startPath = Application.StartupPath + "\\report\\统领发药单据.grf";
                uniformMaster.PatientNames = CombineTotalMsg(cobSumWay.SelectedIndex, this.chkPrintNoPO.Checked);
                switch(cobSumWay.SelectedIndex)
                {
                    case 0:
                        uniformMaster.BillType = "长期医嘱";
                        break;
                    case 1:
                        uniformMaster.BillType = "临时医嘱";
                        break;
                    default:
                        uniformMaster.BillType = "全部医嘱";
                        break;
                }
                uniformMaster.BillType += chkPrintNoPO.Checked ? "针剂药品" : "全部药品";
                PrintFactory.GetPrinter(ConfigManager.OP_YF_DISPENSE + "ZY_TL").PrintBill(uniformMaster, _totalOrder,
                    startPath, (int)_currentUserId);
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
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

        /// <summary>
        /// 加载待发药信息列表
        /// </summary>
        private void LoadMsgMaster()
        {
            try
            {
                if (_recipeOrder != null)
                {
                    _recipeOrder.Rows.Clear();
                    _recipeOrder = null;
                }
                List<ZY_DRUGMESSAGE_MASTER> msgMasters = _zyInterFace.GetDrugMsgMaster(Convert.ToInt32(_currentDeptId));
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
                            AddMsgToDeptNode(msgMasters, deptNode);
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
                    AddMsgToDeptNode(msgMasters, deptNode);
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
        private static void AddMsgToDeptNode(List<ZY_DRUGMESSAGE_MASTER> msgMasters, TreeNode deptNode)
        {
            if (msgMasters != null)
            {
                foreach (ZY_DRUGMESSAGE_MASTER master in msgMasters)
                {
                    if (master.PRESDEPTID == Convert.ToInt32(deptNode.Tag))
                    {
                        string msgStr = "";
                        switch (master.MESSAGETYPE)
                        {
                            case 0:
                                msgStr+="[长]";
                                break;
                            case 1:
                                msgStr += "[临]";
                                break;
                            default:
                                msgStr += "[手术]";
                                break;
                        }
                        TreeNode msgNode = new TreeNode(msgStr + master.SENDTIME.ToString("yyyy-MM-dd HH:mm:ss") +
                            " (" + master.SENDERNAME + ")");
                        if (master.DR_FLAG == 0)
                        {
                            msgNode.ForeColor = Color.Red;
                        }
                        msgNode.Tag = master;
                        deptNode.Nodes.Add(msgNode);
                    }
                }
            }
        }

        /// <summary>
        /// 创建统领信息表
        /// </summary>
        private void BuildTotalDt()
        {
            if (_totalOrder != null)
            {
                _totalOrder.Columns.Add("编码", Type.GetType("System.Int32"));
                _totalOrder.Columns.Add("化学名称", Type.GetType("System.String"));
                _totalOrder.Columns.Add("药品规格", Type.GetType("System.String"));
                _totalOrder.Columns.Add("生产厂家", Type.GetType("System.String"));
                _totalOrder.Columns.Add("剂型", Type.GetType("System.String"));
                _totalOrder.Columns.Add("数量", Type.GetType("System.Decimal"));
                _totalOrder.Columns.Add("单位", Type.GetType("System.String"));
                _totalOrder.Columns.Add("零售价", Type.GetType("System.Decimal"));
                _totalOrder.Columns.Add("零售金额", Type.GetType("System.Decimal"));
                _totalOrder.PrimaryKey = new DataColumn[] { _totalOrder.Columns["编码"] };
            }
        }

        /// <summary>
        /// 汇总明细信息成统领信息
        /// </summary>
        private string CombineTotalMsg(int sumWay, bool isOnlyPrintNoPO)
        {
            string patientNames = "";
            DataRow[] dRows;
            List<string> curenoList = new List<string>();
            _totalOrder.Rows.Clear();
            if (_recipeOrder == null)
                return "";
            DataTable selectOrder;
            FilterRecipeOrder(sumWay, isOnlyPrintNoPO, out dRows, out selectOrder);
            for (int index = 0; index < selectOrder.Rows.Count; index++)
            {
                DataRow currentRow = selectOrder.Rows[index];
                string cureNo = currentRow["cureno"].ToString();
                if (curenoList.Find(
                    delegate(string findNo)
                    {
                        return findNo == cureNo;
                    }) == null)
                {
                    curenoList.Add(cureNo);
                    patientNames += currentRow["patname"].ToString() + ",";
                }
                DataRow findRow = _totalOrder.Rows.Find(currentRow["MAKERDICID"]);
                if (findRow != null)
                {
                    if (currentRow["ISDISPENSE"] != DBNull.Value)
                    {
                        if (Convert.ToInt32(currentRow["ISDISPENSE"]) == 1)// add zenghao 2010.11.15
                        {
                            findRow["数量"] = Convert.ToDecimal(findRow["数量"]) +
                                Convert.ToDecimal(currentRow["DrugNum"]);
                            findRow["零售金额"] = Convert.ToDecimal(findRow["零售金额"]) +
                                Convert.ToDecimal(currentRow["RETAILFEE"]);
                        }
                    }
                }
                else
                {
                    if (currentRow["ISDISPENSE"] == DBNull.Value)
                    {
                        continue;
                    }
                    if (Convert.ToInt32(currentRow["ISDISPENSE"]) == 1 && Convert.ToDecimal(currentRow["DRUGNUM"])!=0)
                    {
                        DataRow newRow = _totalOrder.NewRow();
                        newRow["编码"] = currentRow["MAKERDICID"];
                        newRow["化学名称"] = currentRow["CHEMNAME"];
                        newRow["药品规格"] = currentRow["SPEC"];
                        newRow["生产厂家"] = currentRow["PRODUCTNAME"];
                        newRow["剂型"] = currentRow["DOSENAME"];
                        newRow["数量"] = currentRow["DRUGNUM"];
                        newRow["单位"] = currentRow["UNITNAME"];
                        newRow["零售价"] = currentRow["RETAILPRICE"];
                        newRow["零售金额"] = currentRow["RETAILFEE"];
                        _totalOrder.Rows.Add(newRow);
                    }
                }
            }
            if (_totalOrder.Rows.Count > 0)
            {
                //_totalOrder = _totalOrder.Select("", "剂型,化学名称").CopyToDataTable();
                _totalOrder.PrimaryKey = new DataColumn[] { _totalOrder.Columns["编码"] };
            }
            return patientNames;
        }

        private void FilterRecipeOrder(int sumWay, bool isOnlyPrintNoPO, out DataRow[] dRows, out DataTable selectOrder)
        {
            selectOrder = new DataTable();
            switch (sumWay)
            {
                case 0:
                    dRows = _recipeOrder.Select("DOCORDERTYPE=0");//.OrderBy(x => x.Field<string>("chemname")).OrderBy(x => x.Field<string>("dosename")).ToArray();
                    break;
                case 1:
                    dRows = _recipeOrder.Select("DOCORDERTYPE=1");//.OrderBy(x => x.Field<string>("chemname")).OrderBy(x => x.Field<string>("dosename")).ToArray();
                    break;
                default:
                    dRows = _recipeOrder.Select("");//.OrderBy(x => x.Field<string>("chemname")).OrderBy(x => x.Field<string>("dosename")).ToArray();
                    break;
            }
            if (dRows.Count() > 0)
            {
                selectOrder = _recipeOrder.Copy(); //dRows.CopyToDataTable();
            }
            if (isOnlyPrintNoPO)
            {
                for (int index = 0; index < selectOrder.Rows.Count; index++)
                {
                    DataTable useTypeDt = _zyInterFace.GetUseType(Convert.ToInt32(selectOrder.Rows[index]["docorderid"]));
                    if (useTypeDt != null)
                    {
                        if (useTypeDt.Select("TYPE_NAME='服药单'").Count() != 0)
                        {
                            selectOrder.Rows[index]["ISDISPENSE"] = 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 构建查询条件列表
        /// </summary>
        private Hashtable BuildConditionParams()
        {
            Hashtable parameters = new Hashtable();
            ConditionParam param = new ConditionParam(QueryConditionType.开始时间, cobBeginDate.Value, true);
            parameters.Add(QueryConditionType.开始时间, param);
            param = new ConditionParam(QueryConditionType.结束时间, cobEndDate.Value, true);
            parameters.Add(QueryConditionType.结束时间, param);
            param = new ConditionParam(QueryConditionType.部门ID, (int)_currentDeptId, true);
            parameters.Add(QueryConditionType.部门ID, param);
            return parameters;
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
                BillQuery _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_DISPENSE + "ZY_TL");
                DataTable deptDispDt = _billQuery.LoadMaster(BuildConditionParams());
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
                        if (deptDispDt != null)
                        {
                            for (int temp = 0; temp < deptDispDt.Rows.Count; temp++)
                            {
                                DataRow currentRow = deptDispDt.Rows[temp];
                                if (Convert.ToInt32(currentRow["DISPDEPT"]) == Convert.ToInt32(deptNode.Tag))
                                {
                                    TreeNode msgNode = new TreeNode();
                                    string date = Convert.ToDateTime(currentRow["OPTIME"]).ToString("yyyy-MM-dd HH:mm");
                                    msgNode.Text = date;
                                    msgNode.Tag = currentRow;
                                    deptNode.Nodes.Add(msgNode);
                                }
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
        #endregion

        #region 按钮事件
        //退出事件
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //发药按钮
        private void btnDispense_Click(object sender, EventArgs e)
        {
            try
            {
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
                //重新获取住院发药数量和金额  update by heyan 修改药房多次发药的问题
                _zyInterFace.GetSendNumAndFee(_recipeOrder);              
                bool isDurg = true;
                for (int i = 0; i < _recipeOrder.Rows.Count; i++)
                {
                    if (Convert.ToInt32(_recipeOrder.Rows[i]["DRUGNUM"]) != 0)
                    {
                        isDurg = false;
                        break;
                    }
                }

                if (isDurg == true)
                {
                    MessageBox.Show("该单据已经发药，请刷新列表！", "发药提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                List<BillMaster> dispList = PutDrugByOrder(_allDispPats);
                YP_DispDeptHis newDispDept = (YP_DispDeptHis)(_billProcessor.SaveBills(dispList, _selectDeptId, _allDispPats));
                if (newDispDept != null)
                {
                MessageBox.Show("发药成功,开始打印统领发药单据...", "发药成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                PrintDispTL(newDispDept);
                //btnPutDrug_Click(null, null);
                LoadMsgMaster();
                }
                else
                {
                    if (MessageBox.Show("当前存在药品库存不足，需要系统帮您自动取消这些库存不足的药品么？",
                        "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (YP_StoreNum noStoreInfo in ((ZY_DispProcessor)(_billProcessor)).noStoreList)
                        {
                            for (int index = 0; index < _recipeOrder.Rows.Count; index++)
                            {
                                DataRow currentRow = _recipeOrder.Rows[index];
                                if (currentRow["ORDERRECIPEID"].ToString() == noStoreInfo.queryKey
                                    && Convert.ToInt32(currentRow["MAKERDICID"]) == noStoreInfo.makerDicId)
                                    currentRow["ISDISPENSE"] = 0;
                            }
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
                
                this.txtQueryNum.Focus();
            }
        }
        //刷新按钮
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
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
        //摆药按钮
        private void btnPutDrug_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (_recipeOrder != null)
                {
                    YP_PrintCondition printCondition = new YP_PrintCondition();
                    printCondition.userId = (int)_currentUserId;
                    printCondition.drugType = chkIsOnlyPutPO.Checked ? "口服药" : "全部药品";
                    printCondition.queyType = cobSumWay.SelectedIndex;
                    DataRow[] dRows;
                    switch (cobSumWay.SelectedIndex)
                    {
                        case 0:
                            dRows = _recipeOrder.Select("DOCORDERTYPE=0");
                            break;
                        case 1:
                            dRows = _recipeOrder.Select("DOCORDERTYPE=1");
                            break;
                        default:
                            dRows = _recipeOrder.Select("");
                            break;
                    }
                    if (dRows.Count() > 0)
                    {
                        string startPath = Application.StartupPath + "\\report\\住院摆药单.grf";
                        PrintFactory.GetPrinter(ConfigManager.OP_YF_DISPENSE + "ZY_BY").PrintReport(printCondition,
                            dRows.CopyToDataTable(),
                            startPath);
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
        //打印按钮
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (tabMsgMaster.SelectedTab == tabDispHis)
                {
                    if (_recipeOrder != null && treeDrugMsg.SelectedNode != null)
                    {
                        if (treeDrugMsg.SelectedNode.Level == 2)
                        {
                            DataRow selectDispHis = (DataRow)(treeDrugMsg.SelectedNode.Tag);
                            YP_DispDeptHis dispMaster = new YP_DispDeptHis();
                            dispMaster.DeptId = Convert.ToInt32(selectDispHis["DEPTID"]);
                            dispMaster.DispDept = Convert.ToInt32(selectDispHis["DISPDEPT"]);
                            dispMaster.Id = Convert.ToInt32(selectDispHis["Id"]);
                            dispMaster.OpMan = Convert.ToInt32(selectDispHis["OPMAN"]);
                            dispMaster.OpTime = Convert.ToDateTime(selectDispHis["OPTIME"]);
                            dispMaster.TotalFee = Convert.ToDecimal(selectDispHis["TOTALFEE"]);
                            PrintDispTL(dispMaster);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中统领信息");
                        return;
                    }

                }
                else
                {
                    if (_recipeOrder != null)
                    {
                        YP_DispDeptHis dispMaster = new YP_DispDeptHis();
                        dispMaster.DeptId = Convert.ToInt32(_currentDeptId);
                        dispMaster.DispDept = Convert.ToInt32(_selectDeptId);
                        dispMaster.Id = 0;
                        dispMaster.OpMan = Convert.ToInt32(_currentUserId);
                        dispMaster.OpTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                        dispMaster.TotalFee = 0;
                        for (int index = 0; index < _recipeOrder.Rows.Count; index++)
                        {
                            dispMaster.TotalFee += Convert.ToDecimal(_recipeOrder.Rows[index]["RetailFee"]);
                        }
                        PrintDispTL(dispMaster);
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
        //查询明细按钮
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (_recipeOrder != null)
            {
                string queryWhere = "1=1";
                queryWhere += txtQueryNum.Text == "00000000" ? "" : " and CURENO=" + txtQueryNum.Text;
                queryWhere += txtQueryDrug.MemberValue == null ? "" : " and MAKERDICID=" + Convert.ToInt32(txtQueryDrug.MemberValue);
                queryWhere += txtQueryName.Text == "" ? "" : " and PATNAME='" + txtQueryName.Text.Trim() + "'";
                queryWhere += txtQueryBedNo.Text == "" ? "" : " and BEDNO='" + txtQueryBedNo.Text.Trim() + "'";
                DataRow[] dRows = _recipeOrder.Select(queryWhere);
                DataTable _queryResult = _recipeOrder.Clone();
                foreach (DataRow dRow in dRows)
                {
                    _queryResult.Rows.Add(dRow.ItemArray);
                }
                FrmQueryDispOrder frmdispOrder = new FrmQueryDispOrder();
                frmdispOrder.setDataSource(_queryResult);
                if (frmdispOrder.ShowDialog() == DialogResult.OK)
                {
                    for (int index = 0; index < _queryResult.Rows.Count; index++)
                    {
                        DataRow currentRow = _queryResult.Rows[index];
                        DataRow findRow = _recipeOrder.Rows.Find(currentRow["DRUGMESSAGEID"]);
                        if (findRow != null)
                        {
                            findRow["ISDISPENSE"] = currentRow["ISDISPENSE"];
                        }
                    }
                }
            }
        }
        //查看统领消息按钮
        private void btnQueryTotal_Click(object sender, EventArgs e)
        {
            if (btnQueryTotal.Text == "查看统领")
            {
                CombineTotalMsg(cobSumWay.SelectedIndex, false);
                dgrdTotalOrder.DataSource = _totalOrder;
                pnlTotalOrder.Visible = true;
                btnQueryTotal.Text = "查看明细";
            }
            else
            {
                pnlTotalOrder.Visible = false;
                btnQueryTotal.Text = "查看统领";
            }
        }
        //刷新已发药按钮
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

        //全选按钮
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetRecipeOrderAllSelect(true);
        }

        //全不选按钮
        private void btnSelectNo_Click(object sender, EventArgs e)
        {
            SetRecipeOrderAllSelect(false);
        }
        #endregion

        #region 树形控件

        private void treeDrugMsg_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (tabMsgMaster.SelectedTab == tabDispHis && e.Node.Level == 2)
                {
                    int dispHisId = Convert.ToInt32(((DataRow)e.Node.Tag)["ID"]);
                    _recipeOrder = _zyInterFace.GetDrugMsgOrder(dispHisId);
                    _recipeOrder.PrimaryKey = new DataColumn[] { _recipeOrder.Columns["drugmessageid"] };
                    this.dgrdRecipeInfo.DataSource = _recipeOrder;
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
        //树形控件节点上checkbox被改变触发消息
        private void treeDrugMsg_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                    if (e.Node.Level == 2 && e.Node.Checked)
                    {
                        ZY_DRUGMESSAGE_MASTER currentMsg = (ZY_DRUGMESSAGE_MASTER)(e.Node.Tag);
                        //cobSumWay.SelectedIndex = currentMsg.MESSAGETYPE == 0 ? 0 : 1;
                        _selectDeptId = currentMsg.PRESDEPTID;
                        TreeNode rootNode = treeDrugMsg.Nodes[0];
                        foreach (TreeNode node in rootNode.Nodes)
                        {
                            foreach (TreeNode msgNode in node.Nodes)
                            {
                                if (((ZY_DRUGMESSAGE_MASTER)msgNode.Tag).PRESDEPTID != currentMsg.PRESDEPTID
                                    && msgNode.Checked == true)
                                {
                                    msgNode.Parent.Checked = false;
                                    break;
                                }
                            }
                        }
                        if (_recipeOrder != null)
                        {
                            DataTable recipeDt = _zyInterFace.GetDrugMsgOrder(currentMsg);
                            for (int index = 0; index < recipeDt.Rows.Count; index++)
                            {
                                _recipeOrder.Rows.Add(recipeDt.Rows[index].ItemArray);
                            }
                        }
                        else
                        {
                            _recipeOrder = _zyInterFace.GetDrugMsgOrder(currentMsg);
                            _recipeOrder.PrimaryKey = new DataColumn[] { _recipeOrder.Columns["DRUGMESSAGEID"] };
                            _recipeOrder.DefaultView.RowFilter = "DRUGNUM<>0";
                            dgrdRecipeInfo.DataSource = _recipeOrder;
                        }
                    }
                    if (e.Node.Level == 2 && !e.Node.Checked)
                    {
                        ZY_DRUGMESSAGE_MASTER currentMsg = (ZY_DRUGMESSAGE_MASTER)(e.Node.Tag);
                        if (_recipeOrder != null)
                        {
                            DataRow[] removeRows = _recipeOrder.Select("MASTERID=" + currentMsg.DRUGMESSAGEID.ToString());
                            dgrdRecipeInfo.CurrentCellChanged -= dgrdRecipeInfo_CurrentCellChanged;
                            foreach (DataRow removeRow in removeRows)
                            {
                                _recipeOrder.Rows.Remove(removeRow);
                            }
                            dgrdRecipeInfo.CurrentCellChanged += dgrdRecipeInfo_CurrentCellChanged;
                        }

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
        #endregion

        #region 显示控件
        // 显示病人卡信息
        private void ShowCurrentPat(string cureNo)
        {
            string outMsg = "";
            DataRow patInfo = _zyInterFace.GetPatCardInfo(cureNo);
            this.inPatientPanel.BindDataRow(patInfo, out outMsg);
        }
        //统领科室showcard事件
        private void txtDeptDraw_AfterSelectedRow(object sender, object SelectedValue)
        {
            DataRow dr = (DataRow)SelectedValue;
            if (dr != null)
            {
                _searchDeptId = Convert.ToInt32(txtDeptDraw.MemberValue);
                this.btnRefresh.Focus();
            }
        }
        private void txtQueryNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnQuery.Focus();
            }
        }
        //待发药列表和已发药列表切换事件
        private void tabMsgMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabMsgMaster.SelectedTab == tabPgDisp)
                {
                    this.btnDispense.Visible = true;
                    this.treeDrugMsg.CheckBoxes = true;
                    pnlTotalOrder.Visible = false;
                    btnQueryTotal.Text = "查看统领";
                    LoadMsgMaster();
                }
                else
                {
                    this.btnDispense.Visible = false;
                    this.treeDrugMsg.CheckBoxes = false;
                    pnlTotalOrder.Visible = false;
                    btnQueryTotal.Text = "查看统领";
                    LoadDispHisMaster();
                }
                inPatientPanel.Clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        #endregion

        #region 网格控件
        //发药明细网格单元格改变事件
        private void dgrdRecipeInfo_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgrdRecipeInfo.CurrentCell != null)
                {
                    int rowIndex = dgrdRecipeInfo.CurrentCell.RowIndex;
                    string cureNo = dgrdRecipeInfo["col_PatNo", rowIndex].Value.ToString();
                    ShowCurrentPat(cureNo);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //药品打缺消息
        private void dgrdRecipeInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (e.ColumnIndex == dgrdRecipeInfo.Columns["Col_NoDrug"].Index
                    && tabMsgMaster.SelectedTab == tabPgDisp)
                {
                    if (MessageBox.Show("您确定要将该条明细药品打缺么？",
                        "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        int rowIndex = e.RowIndex;
                        if (rowIndex >= 0)
                        {
                            DataRow currentRow = _recipeOrder.Rows[rowIndex];
                            _zyInterFace.UpdateNoDrugFlag(Convert.ToInt32(currentRow["ORDERRECIPEID"]),
                                Convert.ToDateTime(currentRow["CHARGEDATE"]));
                            _recipeOrder.Rows.Remove(currentRow);
                        }
                    }
                }

                else if (e.ColumnIndex == dgrdRecipeInfo.Columns["IsDispense"].Index && tabMsgMaster.SelectedTab == tabPgDisp)
                {
                    if (_recipeOrder.Rows[e.RowIndex]["ISDISPENSE"] == DBNull.Value)
                    {
                        _recipeOrder.Rows[e.RowIndex]["ISDISPENSE"] = 0;
                    }

                    int isChecked = Convert.ToInt32(_recipeOrder.Rows[e.RowIndex]["ISDISPENSE"]);

                    if (isChecked == 0)
                    {
                        _recipeOrder.Rows[e.RowIndex]["ISDISPENSE"] = 1;
                        dgrdRecipeInfo["IsDispense", e.RowIndex].Value = true;
                    }
                    else
                    {
                        _recipeOrder.Rows[e.RowIndex]["ISDISPENSE"] = 0;
                        dgrdRecipeInfo["IsDispense", e.RowIndex].Value = false;
                    }

                }
            }
        }
        #endregion

        
       
  
    }
}
