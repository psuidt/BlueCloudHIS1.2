using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_YPManager
{
    public partial class FrmOrderAccount : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private DataTable _drugInfoDt;
        private int _makerDicId;
        private int _deptId;
        private string _belongSystem;
        private AccountQuery _accountQuery;
        private DataTable orderDt;
        public FrmOrderAccount()
        {
            InitializeComponent();
        }

        public FrmOrderAccount(long deptId, string chineseName, string belongSystem)
        {
            InitializeComponent();
            _deptId = (int)deptId;
            _belongSystem = belongSystem;
            _accountQuery = AccountFactory.GetQuery(belongSystem);
            this.Text = chineseName;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                
                int accountYear = Convert.ToInt32(this.cobAccountYear.Text);
                int accountMonth = Convert.ToInt32(this.cobAccountMonth.Text);
                decimal balanceFee = 0;
                orderDt = _accountQuery.QueryOrderAccount(accountYear, accountMonth, _makerDicId, _deptId);
                if (orderDt.Rows.Count < 1)
                {
                    MessageBox.Show("该药品在查询时间段内没有明细单据");
                    return;
                }
                dgrdOrderAccount.DataSource = orderDt;
                int lastIndex = orderDt.Rows.Count - 1;
                lblBeginNum.Text = orderDt.Rows[0]["OVERNUM"].ToString();
                balanceFee = Convert.ToDecimal(orderDt.Rows[0]["BALANCEFEE"]);
                lblBeginFee.Text = "￥"+balanceFee.ToString("0.00");
                int overNum = 0;
                if (orderDt.Rows[lastIndex]["AccountType"].ToString() == "月结")
                {
                    overNum = Convert.ToInt32(orderDt.Rows[lastIndex]["Overnum"]);
                    balanceFee = Convert.ToInt32(orderDt.Rows[lastIndex]["BalanceFee"]);
                }
                else
                {
                    overNum = Convert.ToInt32(orderDt.Rows[0]["OVERNUM"]);
                    balanceFee = Convert.ToDecimal(orderDt.Rows[0]["BALANCEFEE"]);
                    for (int index = 1; index <= lastIndex; index++)
                    {
                        overNum += Convert.ToInt32(orderDt.Rows[index]["Lendernum"]);
                        balanceFee += Convert.ToDecimal(orderDt.Rows[index]["LenderFee"]);
                        overNum -= Convert.ToInt32(orderDt.Rows[index]["DebitNum"]);
                        balanceFee -= Convert.ToDecimal(orderDt.Rows[index]["DebitFee"]);
                    }
                }
                lblEndNum.Text = overNum.ToString();
                lblEndFee.Text = "￥"+balanceFee.ToString("0.00") ;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void FrmOrderAccount_Load(object sender, EventArgs e)
        {
            try
            {
                dgrdOrderAccount.AutoGenerateColumns = false;
                DateTime currentTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                int currentActYear = 0;
                int currentActMonth = 0;
                _accountQuery.GetAccountTime(currentTime, ref currentActYear, ref currentActMonth, _deptId);
                cobAccountMonth.Text = currentActMonth.ToString();
                cobAccountYear.Text = currentActYear.ToString();
                _drugInfoDt = StoreFactory.GetQuery(_belongSystem).LoadDrugInfo(_deptId);
                txtDgCode.SetSelectionCardDataSource(_drugInfoDt);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }


        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cobAccountMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtDgCode.Focus();
            }
        }

        private void cobAccountYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                cobAccountMonth.Focus();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgrdOrderAccount.DataSource;
                YP_AccountCondition condition = new YP_AccountCondition();
                condition.actMonth = cobAccountMonth.Text;
                condition.actYear = cobAccountYear.Text;
                condition.drugName = txtDgName.Text;
                condition.drugType = "";
                condition.productName = txtProduct.Text;
                condition.beginNum = lblBeginNum.Text;
                condition.begingFee = lblBeginFee.Text;
                condition.endNum = lblEndNum.Text;
                condition.endFee = lblEndFee.Text;
                string startPath = Application.StartupPath + "\\report\\药品明细帐报表.grf";
                PrintFactory.GetPrinter("Account_Report").PrintReport(condition, dt, startPath);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtDgCode_AfterSelectedRow(object sender, object SelectedValue)
        {
            DataRow dr = (DataRow)SelectedValue;
            if (dr != null)
            {
                txtDgCode.Text = "";
                _makerDicId = Convert.ToInt32(dr["MAKERDICID"]);
                this.txtDgName.Text = dr["CHEMNAME"].ToString();
                this.txtProduct.Text = dr["PRODUCTNAME"].ToString();
                this.txtPackUnit.Text = dr["UNITNAME"].ToString();
                this.txtSpec.Text = dr["SPEC"].ToString();
                this.txtPackNum.Text = Convert.ToDecimal(dr["PACKNUM"]).ToString("0");
                int doseDicId = Convert.ToInt32(dr["DOSEDICID"]);
                int typeDicId = Convert.ToInt32(dr["TYPEDICID"]);
                this.txtDose.Text = DrugBaseDataBll.GetDoseName(doseDicId);
                this.txtType.Text = DrugBaseDataBll.GetTypeName(typeDicId);
                this.btnQuery.Focus();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                int index = CheckAccount();
                if (index > 0)
                {
                    dgrdOrderAccount.CurrentCell = dgrdOrderAccount[0, index];
                    DataRow wrongRow = orderDt.Rows[index - 1];
                    MessageBox.Show("第" + (index + 1).ToString() + "行数据有误 时间:" +
                        Convert.ToDateTime(wrongRow["RegTime"]).ToString("yyyy-MM-dd hh:mm:ss")
                        + " 业务:" + wrongRow["OpType"].ToString());
                    return;
                }
                else
                {
                    MessageBox.Show("账目正确~~~~~~~", "正确提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private int CheckAccount()
        {
            if (orderDt == null)
            {
                return -1;
            }
            if (orderDt.Rows.Count > 1)
            {
                decimal prevFee = Convert.ToDecimal(orderDt.Rows[0]["BalanceFee"]);
                decimal prevNum = Convert.ToDecimal(orderDt.Rows[0]["OverNum"]);
                decimal currentFee = 0;
                decimal currentNum = 0;
                for (int index = 1; index < orderDt.Rows.Count; index++)
                {
                    DataRow currentRow = orderDt.Rows[index];
                    currentFee = prevFee + Convert.ToDecimal(currentRow["LenderFee"]) -
                        Convert.ToDecimal(currentRow["DebitFee"]);
                    currentNum = prevNum + Convert.ToDecimal(currentRow["LenderNum"]) -
                        Convert.ToDecimal(currentRow["DebitNum"]);
                    if (System.Math.Abs(currentFee - Convert.ToDecimal(currentRow["BalanceFee"])) > Convert.ToDecimal(0.001)
                        || currentNum != Convert.ToDecimal(currentRow["OverNum"]))
                    {
                        return index + 1;
                    }
                    else
                    {
                        prevFee = currentFee;
                        prevNum = currentNum;
                    }
                }
                return -1;
            }
            else
            {
                return -1;
            }
        }
    }
}
