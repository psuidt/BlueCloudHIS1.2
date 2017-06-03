using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GWMHIS.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Forms;
using HIS.SYSTEM.PubicBaseClasses;
using grproLib;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.AccountManager;

namespace HIS_ZYManager
{
    public partial class FrmAccount : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;
        private Deptment _currentDept;
        //private FilterType _filterType;			//选项卡条件过滤类别
        //private SearchType _searchType;
        private int[] AccountID;
        private int Accountid;
        private grproLib.GridppReport Report = null;
        private ZY_Account zyAccount = null;

        public FrmAccount()
        {
            InitializeComponent();
            zyAccount = new ZY_Account();
        }
        public FrmAccount(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();

            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            //_filterType = Constant.CustomFilterType;
            //_searchType = Constant.CustomSearchType;
            this.Text = chineseName;
            zyAccount = new ZY_Account();
            zyAccount.AccountCode = this._currentUser.EmployeeID.ToString();

            this.cbType.SelectedIndex = 0;

            this.tbTime.Text = zyAccount.GetLastTime().ToString();
        }
        //选择结账类型
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbType.SelectedIndex == 1)
            {
                this.panel6.Visible = false;
                this.dgAllFee.DataSource = zyAccount.GetAllCharge(this._currentUser.EmployeeID.ToString());
            }
            else if (this.cbType.SelectedIndex == 2)
            {
                this.panel6.Visible = true;
                this.dgAllFee.DataSource = zyAccount.GetAllCost(this._currentUser.EmployeeID.ToString());
            }
            else
            {
                this.panel6.Visible = true;
                this.dgAllFee.DataSource = zyAccount.GetAllChargeAndCost(this._currentUser.EmployeeID.ToString());
            }

            decimal[] dec_fee = new decimal[4];
            dec_fee = zyAccount.GetMenoyAndPosFee(this._currentUser.EmployeeID.ToString(), this.cbType.SelectedIndex);
            this.tb_Cash.Text = dec_fee[0].ToString();
            this.tb_pos.Text = dec_fee[1].ToString();
            this.tbAllFee.Text = (dec_fee[0] + dec_fee[1]).ToString();
            this.tb_nccmfee.Text = dec_fee[2].ToString();
            this.tb_fovfee.Text = dec_fee[3].ToString();
            this.tb_Deptosit.Text = dec_fee[4].ToString();
            this.tb_allfee.Text = (dec_fee[0] + dec_fee[1] + dec_fee[2] + dec_fee[3] + dec_fee[4]).ToString();
        }
        //根据费用类型显示单据明细
        private void dgAllFee_CurrentCellChanged(object sender, EventArgs e)
        {
            //this.dgFee.DataSource = HIS.ZY_BLL.OP_Account.GetDetailCharge(this.dgAllFee[this.dgAllFee.CurrentCell.RowNumber,0].ToString());
            if (dgAllFee.CurrentCell != null)
            {
                string feetype = dgAllFee[0, dgAllFee.CurrentCell.RowIndex].Value.ToString();//((DataTable)this.dgAllFee.DataSource).DefaultView.ToTable().Rows[this.dgAllFee.CurrentCell.RowIndex]["typename"].ToString();
                dgFee.AutoGenerateColumns = false;
                this.dgFee.DataSource = zyAccount.GetDetailCharge(this._currentUser.EmployeeID.ToString(), feetype);
                
            }
        }
       

        /// 预交金明细数据填充
        private void Report_FetchRecord(ref bool Eof)
        {
            #region OLD
            //string[] AccountIDs = new string[1];
            //AccountIDs[0] = Accountid.ToString();
            //List<ZY_ChargeList> zy_Chargelist = zyAccount.GetChargeData(AccountIDs, -1);
            //for (int i = 0; i < zy_Chargelist.Count; i++)
            //{
            //    zy_Chargelist[i].ChargeType = zy_Chargelist[i].FeeType == 0 ? "现金" : "POS";
            //    zy_Chargelist[i].PatName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetPatName(zy_Chargelist[i].PatID);
            //}
            //DataTable dt = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zy_Chargelist);
            #endregion
            GWI_DesReport.HisReport.FillRecordToReport(Report, chargeRpt.预交金记录);
        }

        AbstractChargeAccountRpt chargeRpt = new AbstractChargeAccountRpt();
        AbstractCostAccountRpt costRpt = new AbstractCostAccountRpt();

        /// 交款表打印
        private void Print()
        {
            zyAccount = zyAccount.GetAccount(Accountid);
            Report = new grproLib.GridppReport();
            if (zyAccount.AccountType == 0)
            {
                chargeRpt.GetAccountRptInfo(chargeRpt, Accountid);

                #region 预交金
                Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院财务结帐预交金汇总.grf");
                GWI_DesReport.HisReport.FillRecordToReport(Report, chargeRpt);
                Report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(Report_FetchRecord);
                
                #endregion
                #region OLD
                //Report.ParameterByName("AccountName").AsString = zyAccount.AccountName;
                //Report.ParameterByName("AccountDate").AsString = zyAccount.AccountDate.ToString();

                //Report.ParameterByName("Total_Fee").AsString = zyAccount.Total_Fee.ToString();
                //Report.ParameterByName("Total_FeeD").AsString = zyAccount.Total_Fee.ToString();

                //Report.ParameterByName("YJ_M_FY").AsString = zyAccount.Cash_Fee.ToString();
                //Report.ParameterByName("YJ_POS_FY").AsString = zyAccount.POS_Fee.ToString();

                //Report.ParameterByName("WTICKETFEE").AsString = zyAccount.WTicketFee.ToString();
                //Report.ParameterByName("WTICKETNUM").AsString = zyAccount.WTicketNum.ToString();
                //Report.ParameterByName("BTICKETFEE").AsString = zyAccount.BTicketFee.ToString();
                //Report.ParameterByName("BTICKETNUM").AsString = zyAccount.BTicketNum.ToString();              
                //Report.ParameterByName("LastDate").AsString = zyAccount.LastDate.ToString();
                //Report.ParameterByName("WorkName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                #endregion
            }
            else
            {
                #region 结算
                Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院财务结帐结算汇总.grf");
                costRpt.GetAccountRptInfo(costRpt, Accountid);
                GWI_DesReport.HisReport.FillRecordToReport(Report, costRpt);
                //Report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "住院每日缴款清单";

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
                #region OLD
                //Report.ParameterByName("交款人").AsString = zyAccount.AccountName;
                //Report.ParameterByName("交款时间").AsString = zyAccount.AccountDate.ToString();


                //DataTable dt = zyAccount.GetTicketTotle(Accountid);
                //decimal AllKMFee = 0;
                ////dt = null;
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    for (int j = 1; j <= Report.Parameters.Count; j++)
                //    {
                //        if (dt.Rows[i]["itemname"].ToString().Trim() == Report.Parameters[j].Name)
                //        {
                //            Report.Parameters[j].Value = dt.Rows[i]["Tolal_Fee"].ToString();
                //        }
                //    }
                //    AllKMFee += Convert.ToDecimal(dt.Rows[i]["Tolal_Fee"]);
                //}


                //#endregion

                //Report.ParameterByName("发票科目合计").AsString = AllKMFee.ToString();



                //List<ZY_CostMaster> zy_CML = zyAccount.GetCostData(Accountid);
                //if (zy_CML != null && zy_CML.Count > 0)
                //{


                //    #region 收费票据

                //    Report.ParameterByName("收费发票开始号").AsString = zy_CML[0].TicketCode;
                //    Report.ParameterByName("收费发票结束号").AsString = zy_CML[zy_CML.Count - 1].TicketCode;
                //    Report.ParameterByName("收费发票张数").AsString = zy_CML.Count.ToString();
                //    List<ZY_CostMaster> zy_CMLx = zy_CML.FindAll(delegate(ZY_CostMaster x) { return x.Record_Flag == 2; });
                //    Report.ParameterByName("收费退费张数").AsString = zy_CMLx.Count.ToString();
                //    Report.ParameterByName("收费退费金额").AsString = zy_CMLx.Sum(x => x.Total_Fee).ToString();
                //    Report.ParameterByName("废票张数").AsString = zyAccount.GetBadTicketCount(Accountid).ToString();
                //    #endregion

                //    #region 记账部分

                //    //自费
                //    List<ZY_CostMaster> zy_CMLy1 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return (y.PatType.Trim() == "01" ); });
                //    //农合
                //    List<ZY_CostMaster> zy_CMLy2 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return (y.PatType.Trim() == "02"); });
                //    //居民医保
                //    List<ZY_CostMaster> zy_CMLy3 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return (y.PatType.Trim() == "03"); });
                //    //职工医保
                //    List<ZY_CostMaster> zy_CMLy4 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return (y.PatType.Trim() == "04" ); });
                //    //其他
                //    List<ZY_CostMaster> zy_CMLy6 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return (y.PatType.Trim() == "06"); });
                //    //单位
                //    List<ZY_CostMaster> zy_CMLy5 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.WorkUnit_Fee != 0; });

                //    Report.ParameterByName("居民医保_记账_张数").AsString = zy_CMLy3.Count.ToString();
                //    Report.ParameterByName("居民医保_记账").AsString = zy_CMLy3.Sum(y => y.NotWorkUnit_Fee).ToString();

                //    Report.ParameterByName("农合_记账_张数").AsString = zy_CMLy2.Count.ToString();
                //    Report.ParameterByName("农合_记账").AsString = zy_CMLy2.Sum(y => y.NotWorkUnit_Fee).ToString();

                //    Report.ParameterByName("职工医保_记账_张数").AsString = zy_CMLy4.Count.ToString();
                //    Report.ParameterByName("职工医保_记账").AsString = zy_CMLy4.Sum(y => y.NotWorkUnit_Fee).ToString();

                //    Report.ParameterByName("其他_记账_张数").AsString = zy_CMLy6.Count.ToString();
                //    Report.ParameterByName("其他_记账").AsString = zy_CMLy6.Sum(y => y.NotWorkUnit_Fee).ToString();

                //    Report.ParameterByName("自费_记账_张数").AsString = zy_CMLy1.Count.ToString();
                //    Report.ParameterByName("自费_记账").AsString = zy_CMLy1.Sum(y => y.NotWorkUnit_Fee).ToString();

                //    Report.ParameterByName("单位记账_张数").AsString = zy_CMLy5.Count.ToString();
                //    Report.ParameterByName("单位记账").AsString = zy_CMLy5.Sum(y => y.WorkUnit_Fee).ToString();

                //    Report.ParameterByName("记账合计张数").AsString = (zy_CMLy3.Count + zy_CMLy2.Count + zy_CMLy4.Count + zy_CMLy6.Count + zy_CMLy1.Count + zy_CMLy5.Count).ToString();//zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.Village_Fee > 0; }).Count.ToString();
                //    Report.ParameterByName("记账合计").AsString = zy_CML.Sum(y => y.Village_Fee).ToString();

                //    #endregion

                //    #region 收现金

                //    Report.ParameterByName("优惠金额").AsString = zy_CML.Sum(z => z.Favor_Fee).ToString();
                //    Report.ParameterByName("应收现金").AsString = zy_CML.Sum(z => z.Self_Fee).ToString();
                //    Report.ParameterByName("预收现金").AsString = zy_CML.Sum(z => z.Deptosit_Fee).ToString();
                //    decimal decR = zy_CML.Sum(z => z.Reality_Fee);
                //    //补收
                //    List<ZY_CostMaster> zy_CML11 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.Reality_Fee > 0; });
                //    //补退
                //    List<ZY_CostMaster> zy_CML22 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.Reality_Fee < 0; });
                //    //欠费
                //    List<ZY_CostMaster> zy_CML33 = zy_CML.FindAll(delegate(ZY_CostMaster y) { return y.Ntype ==3; });

                //    Report.ParameterByName("补收现金").AsString = zy_CML11.Sum(x => x.Reality_Fee).ToString("0.00");
                //    Report.ParameterByName("补退现金").AsString = (0 - zy_CML22.Sum(x => x.Reality_Fee)).ToString("0.00");
                //    Report.ParameterByName("实收现金").AsString = decR.ToString();
                //    Report.ParameterByName("小写合计").AsString = decR.ToString();
                //    Report.ParameterByName("大写合计").AsString = decR.ToString();
                //    try
                //    {
                //        List<ZY_ChargeList> zy_cl = zyAccount.GetChargeListData(Accountid);
                //        //现金
                //        List<ZY_ChargeList> zy_cl0 = zy_cl.FindAll(x => x.FeeType == 0);
                //        //POS
                //        List<ZY_ChargeList> zy_cl1 = zy_cl.FindAll(x => x.FeeType == 1);
                //        Report.ParameterByName("预交金现金").AsString = zy_cl0.Sum(x => x.Total_Fee).ToString();
                //        Report.ParameterByName("预交金POS").AsString = zy_cl1.Sum(x => x.Total_Fee).ToString();
                //        Report.ParameterByName("补收金额现金").AsString = zy_CML11.Sum(x => x.Money_Fee).ToString();
                //        Report.ParameterByName("补收金额POS").AsString = zy_CML11.Sum(x => x.Pos_Fee).ToString();
                //        Report.ParameterByName("欠费金额").AsString = zy_CML33.Sum(x => (x.Self_Fee - x.Deptosit_Fee)).ToString();
                //    }
                //    catch { }
                #endregion

            }
            zyAccount.UpdatePrintNum(Accountid);
            if (this.PrintType.Checked == false)
                Report.PrintPreview(false);
            else
                Report.PrintPreview(false);
        }
      
        //结账
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(this.tbAllFee.Text) == 0)
            {
                if (MessageBox.Show("结账金额为【0】，还需要继续结账吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (MessageBox.Show("确定要结账吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {


                AccountID = zyAccount.SaveAccount(this.cbType.SelectedIndex, this._currentUser.EmployeeID.ToString());
                if (AccountID[0] != -1 || AccountID[1] != -1)
                {
                    MessageBox.Show("交款成功！");
                    this.toolStripButton1.Enabled = false;
                    this.toolStripButton2.Enabled = true;
                    this.cbType.Enabled = false;
                }
                else
                {
                    MessageBox.Show("交款失败！");
                }
            }
        }
        //打印
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            for (int t = 0; t < 2; t++)
            {
                if (AccountID[t] == -1) continue;

                Accountid = AccountID[t];
                Print();
            }
        }
        //关闭
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            this.dgvAccountlist.DataSource = zyAccount.GetAccountList(
                _currentUser.EmployeeID.ToString(),
                this.dtpBdate.Value,
                this.dtpEdate.Value);
            string filter = null;
            if (this.checkBox1.Checked)
            {
                filter += " ACCOUNTTYPE = '预交金' ";
            }

            if (this.checkBox2.Checked)
            {
                filter += filter == null ? " ACCOUNTTYPE='结算' " : " or ACCOUNTTYPE='结算' ";
            }
            if (filter != null)
                ((DataTable)dgvAccountlist.DataSource).DefaultView.RowFilter = filter;
        }
        //打印
        private void button2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1_Click(null, null);
        }
        //重打
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (this.dgvAccountlist.DataSource != null && this.dgvAccountlist.RowCount > 0)
            {
                DataTable dgvdt = ((DataTable)this.dgvAccountlist.DataSource).DefaultView.ToTable();
                if (dgvdt.Rows.Count <= 0)
                {
                    return;
                }
                if (dgvdt.Rows[this.dgvAccountlist.CurrentRow.Index]["ACCOUNTID"] != DBNull.Value && Convert.ToInt32(dgvdt.Rows[this.dgvAccountlist.CurrentRow.Index]["ACCOUNTID"]) > 0)
                {
                    Accountid = Convert.ToInt32(dgvdt.Rows[this.dgvAccountlist.CurrentRow.Index]["ACCOUNTID"]);

                    Print();
                   
                    this.button1_Click(null, null);
                }
            }
        }
        //打印科目分类
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dgvAccountlist.DataSource != null && this.dgvAccountlist.RowCount > 0)
            {
                DataTable dgvdt = ((DataTable)this.dgvAccountlist.DataSource).DefaultView.ToTable();
                if (dgvdt.Rows.Count <= 0)
                {
                    return;
                }
                if (dgvdt.Rows[this.dgvAccountlist.CurrentRow.Index]["ACCOUNTID"] != DBNull.Value && Convert.ToInt32(dgvdt.Rows[this.dgvAccountlist.CurrentRow.Index]["ACCOUNTID"]) > 0)
                {
                    Accountid = Convert.ToInt32(dgvdt.Rows[this.dgvAccountlist.CurrentRow.Index]["ACCOUNTID"]);

                    ZY_Account zy_Account_Son = zyAccount.GetAccount(Accountid);

                    Report = new grproLib.GridppReport();
                    if (zy_Account_Son.AccountType != 0)
                    {
                        Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院财务结帐结算汇总附表.grf");

                        Report.ParameterByName("AccountName").AsString = zy_Account_Son.AccountName;
                        Report.ParameterByName("AccountDate").AsString = zy_Account_Son.AccountDate.ToString();

                        Report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(DeptReport_FetchRecord);
                        Report.ParameterByName("WorkName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    }

                    if (this.PrintType.Checked == false)
                        Report.PrintPreview(false);
                    else
                        Report.PrintPreview(false);
                }
            }
        }

        private void DeptReport_FetchRecord(ref bool Eof)
        {
            DataTable dt = zyAccount.GetAccountDeptOrderData(Accountid);
            GWI_DesReport.HisReport.FillRecordToReport(Report, dt);
        }
     
    }
}
