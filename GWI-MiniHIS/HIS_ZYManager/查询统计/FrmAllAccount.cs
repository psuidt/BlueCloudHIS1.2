using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GWMHIS.BussinessLogicLayer.Classes;
using HIS.ZY_BLL.ObjectModel.AccountManager;
using HIS.ZY_BLL.DataModel;
using HIS.SYSTEM.PubicBaseClasses;


namespace HIS_ZYManager
{
    //zenghao [20100506.1.01]
    public partial class FrmAllAccount : GWI.HIS.Windows.Controls.BaseMainForm,Action.IFrmAllAccountView
    {
        private User _currentUser;
        Action.FrmAllAccountController Controller;
        long workid;

        public FrmAllAccount(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            this.Text = chineseName;
            this.FormTitle = chineseName;

            //this.dtpBegin.Value = DateTime.Now.Date;
            //this.dtpEnd.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);

            Controller = new HIS_ZYManager.Action.FrmAllAccountController(this);
            workid = HIS.SYSTEM.Core.EntityConfig.WorkID;

            this.cbWorkers.SelectedValue = workid;
        }

        private void btnExit_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            Controller.SearchData();
        }

        private void FrmAllAccount_Load( object sender , EventArgs e )
        {
            DateTime dateNow = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            dtpBegin.Value = Convert.ToDateTime( dateNow.ToString( "yyyy-MM-dd" ) + " 00:00:00" );
            dtpEnd.Value = Convert.ToDateTime( dateNow.ToString( "yyyy-MM-dd" ) + " 23:59:59" );
        }

        #region IFrmAllAccountView 成员

        public User currentUser
        {
            get { return currentUser; }
        }

        public Deptment currentDept
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime BeginDate
        {
            get { return this.dtpBegin.Value; }
        }

        public DateTime EndDate
        {
            get { return this.dtpEnd.Value; }
        }

        public AbstractAllAccount Data
        {
            set
            {
                OrderAllFee.Text = value.ChargeAllText.OrderAllFee;
                OrderAllNum.Text = value.ChargeAllText.OrderAllNum;
                BackAllFee.Text = value.ChargeAllText.BackAllFee;
                BackAllNum.Text = value.ChargeAllText.BackAllNum;
                AllFee.Text = value.ChargeAllText.AllFee;
                Menoy.Text = value.ChargeAllText.Menoy;
                POS.Text = value.ChargeAllText.POS;

                this.GoodChargeList.AutoGenerateColumns = false;
                this.GoodChargeList.DataSource = value.ChargeAllData.GoodChargeList;
                this.BadChargeList.AutoGenerateColumns = false;
                this.BadChargeList.DataSource = value.ChargeAllData.BadChargeList;
                this.ChargeData.AutoGenerateColumns = false;
                this.ChargeData.DataSource = value.ChargeAllData.ChargeData;

                receiveFee.Text = value.CostAllText.receiveFee;
                receiveNum.Text = value.CostAllText.receiveNum;
                retreatFee.Text = value.CostAllText.retreatFee;
                retreatNum.Text = value.CostAllText.retreatNum;
                AllFee1.Text = value.CostAllText.AllFee;
                Menoy1.Text = value.CostAllText.Menoy;
                POS1.Text = value.CostAllText.POS;
                costFee.Text = value.CostAllText.costFee;
                faoverFee.Text = value.CostAllText.faoverFee;
                deptosit_fee.Text = value.CostAllText.deptosit_fee;
                lbAllFee.Text = value.CostAllText.lbAllFee;
                lbRoundFee.Text = value.CostAllText.lbRoundFee;

                this.TypeCostData.AutoGenerateColumns = false;
                this.TypeCostData.DataSource = value.CostAllData.TypeCostData;
                this.GoodCostList.AutoGenerateColumns = false;
                this.GoodCostList.DataSource = value.CostAllData.GoodCostList;
                this.BadCostList.AutoGenerateColumns = false;
                this.BadCostList.DataSource = value.CostAllData.BadCostList;
                this.ChargeList.AutoGenerateColumns = false;
                this.ChargeList.DataSource = value.CostAllData.ChargeList;
                this.CostData.AutoGenerateColumns = false;
                this.CostData.DataSource = value.CostAllData.CostData;
            }
        }

        public TreeNode treenode
        {
            set
            {
                if (value.Nodes.Count > 0)
                {
                    this.tvEmpName.Nodes.Clear();
                    this.tvEmpName.Nodes.Add(value);
                    tvEmpName.ExpandAll();
                }
            }
        }

        public DataTable Workers
        {
            set
            {
                this.cbWorkers.DataSource = value;
                this.cbWorkers.DisplayMember = "workname";
                this.cbWorkers.ValueMember = "workid";
            }
        }

        public long Worker
        {
            get
            {
                return Convert.ToInt64(this.cbWorkers.SelectedValue);
            }
        }

        #endregion

        List<int> ids = null;
        List<string> ids1 = null;
        private void tvEmpName_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "根节点")
                return;

            ids = new List<int>();
            ids1 = new List<string>();

            this.tvEmpName.AfterCheck -= new TreeViewEventHandler(tvEmpName_AfterCheck);
            this.tvEmpName.SelectedNode = e.Node;
            ids.Clear();
            //设置子节点是否勾选
            SetNodeChecked(this.tvEmpName.SelectedNode, this.tvEmpName.SelectedNode.Checked);
            //勾已交款的节点把未交款节点全改为false，反之
            bool b = GetParent(this.tvEmpName.SelectedNode);
            //得到勾选的节点的ID
            GetNode(this.tvEmpName.Nodes, b);
            if (b == true)
                Controller.FiterData(ids.ToArray(), b);
            else
                Controller.FiterData(ids1.ToArray(), b);
            this.tvEmpName.AfterCheck += new TreeViewEventHandler(tvEmpName_AfterCheck);
        }

        public void GetNode(TreeNodeCollection tc, bool b)
        {
            foreach (TreeNode TNode in tc)
            {
                if (TNode.Checked && TNode.Tag != null)
                {
                    if (b == true)
                        ids.Add(Convert.ToInt32(TNode.Tag));
                    else
                    {
                        if (ids1.Exists(x => x == TNode.Tag.ToString()) == false)
                            ids1.Add(TNode.Tag.ToString());
                    }
                }
                GetNode(TNode.Nodes, b);
            }
        }

        public void SetNodeChecked(TreeNode tn, bool b)
        {
            TreeNodeCollection tc=tn.Nodes;
            foreach (TreeNode TNode in tc)
            {
                TNode.Checked = b;
                SetNodeChecked(TNode, b);
            }
        }

        public bool GetParent(TreeNode tn)
        {
            
            if (tn.Text == "未交款")
            {
                TreeNode tnn = tn.PrevNode;
                tnn.Checked = false;
                TreeNodeCollection tc = tnn.Nodes;
                foreach (TreeNode TNode in tc)
                {
                    TNode.Checked = false;
                    SetNodeChecked(TNode, false);
                }
                return false;
            }

            if (tn.Text == "已交款")
            {
                TreeNode tnn = tn.NextNode;
                tnn.Checked = false;
                TreeNodeCollection tc= tnn.Nodes;
                foreach (TreeNode TNode in tc)
                {
                    TNode.Checked = false;
                    SetNodeChecked(TNode, false);
                }
                return true;
            }
            
            return GetParent(tn.Parent);
        }

        AbstractChargeAccountRpt chargeRpt = new AbstractChargeAccountRpt();
        AbstractCostAccountRpt costRpt = new AbstractCostAccountRpt();
        private grproLib.GridppReport Report = null;
        private ZY_Account zyAccount = null;
        //交款表打印
        private void Print(int accountType)
        {
            Controller.BeginChargeWorkid();

            zyAccount = new ZY_Account();
            Report = new grproLib.GridppReport();

            if (accountType == 0)
            {
                chargeRpt.GetAccountRptInfo(chargeRpt, ids.ToArray(),accountType);

                #region 预交金
                Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院财务结帐预交金汇总.grf");
                GWI_DesReport.HisReport.FillRecordToReport(Report, chargeRpt);
                Report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(Report_FetchRecord);

                #endregion
            }
            else
            {
                #region 结算
                Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院财务结帐结算汇总.grf");
                costRpt.GetAccountRptInfo(costRpt, ids.ToArray(),accountType);
                GWI_DesReport.HisReport.FillRecordToReport(Report, costRpt);

                for (int i = 0; i < costRpt.发票项目.Rows.Count; i++)
                {
                    try
                    {
                        Report.ParameterByName(costRpt.发票项目.Rows[i]["itemname"].ToString()).AsString = costRpt.发票项目.Rows[i]["Tolal_Fee"].ToString();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("发票打印传入参数:发票项目_" + costRpt.发票项目.Rows[i]["itemname"].ToString() + " 错误\r\n" + err.Message);
                        continue;
                    }
                }

                for (int i = 0; i < costRpt.记账内容.Length; i++)
                {
                    try
                    {
                        Report.ParameterByName(costRpt.记账内容[i].TypeName + "_记账_张数").AsString = costRpt.记账内容[i].CostNum;
                        Report.ParameterByName(costRpt.记账内容[i].TypeName + "_记账").AsString = costRpt.记账内容[i].CostFee;
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("发票打印传入参数:记账类型_" + costRpt.记账内容[i].TypeName + " 错误\r\n" + err.Message);
                        continue;
                    }
                }

                #endregion

            }

            Controller.EndChargeWorkid();

            //zyAccount.UpdatePrintNum(Accountid);
            Report.PrintPreview(false);
        }

        //预交金明细数据填充
        private void Report_FetchRecord(ref bool Eof)
        {
            GWI_DesReport.HisReport.FillRecordToReport(Report, chargeRpt.预交金记录);
        }

        //打印预交金汇总
        private void btPrintCharge_Click(object sender, EventArgs e)
        {
            if (ids!=null && ids.Count > 0)
                Print(0);
        }
        //打印结算汇总
        private void btPrintCost_Click(object sender, EventArgs e)
        {
            if (ids != null && ids.Count > 0)
                Print(1);
        }

        private void cbWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Controller != null)
                Controller.SearchData();
        }
        
    }
}
