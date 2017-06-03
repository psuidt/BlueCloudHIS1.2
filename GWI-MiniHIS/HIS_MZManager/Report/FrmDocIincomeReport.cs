using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.MZ_BLL;
using HIS.MZ_BLL.Report;
using System.Collections;

namespace HIS_MZManager.Report
{
    public partial class FrmDocIincomeReport : BaseMainForm
    {
        private int currentEmployeeId;

        public FrmDocIincomeReport(string FormText, int CurrentEmployeeId)
        {
            InitializeComponent();

            this.Text = FormText;
            this.FormTitle = FormText;
            currentEmployeeId = CurrentEmployeeId;
            this.Load += new EventHandler(FrmDocIincomeReport_Load);
        }

        void FrmDocIincomeReport_Load(object sender, EventArgs e)
        {
            DateTime dtBegin = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01 00:00:00");
            DateTime dtEnd = dtBegin.AddMonths(1).AddSeconds(-1);

            dtpFrom.Value = dtBegin;
            dtpEnd.Value = dtEnd;
           
        }

        

        private void btnStat_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                btnStat.Enabled = false;
                btnPrint.Enabled = false;
                btnClose.Enabled = false;
                DateTime beginDate;
                DateTime endDate;
                string accountIdList;

                ReportController.GetReportBeginDateAndEndDate(StatDateType.交账时间, 25, dtpFrom.Value, dtpEnd.Value, out beginDate, out endDate, out accountIdList);

                BaseReport report = new DoctorIncomeReport();
                report.BeginDate = beginDate;
                report.EndDate = endDate;
                report.StatType = StatClassType.门诊会计分类;
                report.Reportstyle = ReportStyle.科目为明细行;
                report.StatDateType = StatDateType.交账时间;
                report.AccountIdList = accountIdList;
                report.StatObjectType = StatObjctType.医生;
                report.ReportTitle = "";
                report.Lister = PublicDataReader.GetEmployeeNameById(currentEmployeeId);

                ReportController.FillReport(report);
                dgvReport.DataSource = report.DataResult;
                dgvReport.Tag = report;

                for (int i = 1; i < dgvReport.Columns.Count; i++)
                {
                    dgvReport.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvReport.Columns[i].Width = 80;
                }
                dgvReport.Columns[0].Frozen = true;
                dgvReport.Columns[1].Frozen = true;
                //第二部分
                ShowTotalInfo();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnStat.Enabled = true;
                btnPrint.Enabled = true;
                btnClose.Enabled = true;
            }
        }


        private void ShowTotalInfo()
        {
            int selectedchargeUserId = 0;
                        
            DataTable tbHandIn = AccountBookController.GetAccountList(dtpFrom.Value, dtpEnd.Value);
            
            List<PrivyAccountBook> lstAllBooks = new List<PrivyAccountBook>();

            #region 得到缴款员
            Hashtable htCharge = new Hashtable();
            for (int i = 0; i < tbHandIn.Rows.Count; i++)
            {
                int chargeUserId = Convert.ToInt32(tbHandIn.Rows[i]["AccountCode"]);
                if (!htCharge.ContainsKey(chargeUserId))
                    htCharge.Add(chargeUserId, chargeUserId);
            }
            #endregion

            #region 生成账单明细，并合并
            foreach (object obj in htCharge)
            {
                int chargeUserId = Convert.ToInt32(((DictionaryEntry)obj).Value);
                DataRow[] drsAccount = tbHandIn.Select("ACCOUNTCODE=" + chargeUserId, "ACCOUNTDATE asc");
                int[] accountIdList = new int[drsAccount.Length];
                for (int i = 0; i < drsAccount.Length; i++)
                    accountIdList[i] = Convert.ToInt32(drsAccount[i]["ACCOUNTID"]);
                DataTable tbInvoice;
                DataTable tbInvoiceDetail;
                AccountBookController.GetAccountData(chargeUserId, accountIdList, out tbInvoice, out tbInvoiceDetail);
                //个人所有账单
                List<PrivyAccountBook> lstBook = new List<PrivyAccountBook>();

                for (int i = 0; i < drsAccount.Length; i++)
                {
                    int accountId = Convert.ToInt32(drsAccount[i]["ACCOUNTID"]);
                    PrivyAccountBook book = AccountBookController.GetPrivyAccountBook(chargeUserId, accountId, tbInvoice, tbInvoiceDetail, tbHandIn);
                    lstBook.Add(book);
                }

                PrivyAccountBook totalBook = AccountBookController.CollectPrivyAccountBook(lstBook);
                
                lstAllBooks.Add(totalBook);
            }
            #endregion
            
            CollectAccountBook allBook = AccountBookController.CollectAllAccountBook(lstAllBooks);
            
            List<FundInfo> lstFundInfo = new List<FundInfo>();
            if (allBook.TallyPart.Details != null)
            {
                for (int i = 0; i < allBook.TallyPart.Details.Length; i++)
                    lstFundInfo.Add(allBook.TallyPart.Details[i]);
            }

            FundInfo fdFavor = new FundInfo();
            fdFavor.Money = allBook.FavorPart.TotalMoney;
            fdFavor.PayName = "优惠金额";
            lstFundInfo.Add(fdFavor);

            FundInfo fdCash = new FundInfo();
            fdCash.Money = allBook.CashPart.TotalMoney;
            fdCash.PayName = "实收现金";
            lstFundInfo.Add(fdCash);

            

            FundInfo[] allInfo = lstFundInfo.ToArray();

            DataTable tbTotalInfo = new DataTable();
            for (int i = 0; i < 10; i++)
            {
                DataColumn col = new DataColumn();
                col.ColumnName = "C_" + i.ToString();
                tbTotalInfo.Columns.Add(col);
            }

            int colIndex = 0;
            tbTotalInfo.Rows.Add(tbTotalInfo.NewRow());
            int rowIndex = tbTotalInfo.Rows.Count - 1;
            //记账
            for (int i = 0; i < allInfo.Length; i++)
            {
                if (colIndex == 10)
                {
                    tbTotalInfo.Rows.Add(tbTotalInfo.NewRow());
                    rowIndex = tbTotalInfo.Rows.Count - 1;
                    colIndex = 0;
                }

                tbTotalInfo.Rows[rowIndex][colIndex] = allInfo[i].PayName;
                tbTotalInfo.Rows[rowIndex][colIndex + 1] = allInfo[i].Money;
                colIndex = colIndex + 2;
            }
            dgvTotalInfo.Tag = allInfo;
            tbTotalInfo.Columns.Add("C_EMPTY");
            tbTotalInfo.Rows[tbTotalInfo.Rows.Count - 1]["C_EMPTY"] = "合计:" + allBook.InvoiceItemSumTotal.ToString();
            dgvTotalInfo.DataSource = tbTotalInfo;
            dgvTotalInfo.Columns[dgvTotalInfo.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dgvTotalInfo.Columns.Count; i++)
            {
                if (i % 2 == 1)
                {
                    dgvTotalInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    dgvTotalInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvReport.Tag == null)
                return;
            if (dgvTotalInfo.Tag == null)
                return;

            try
            {
                //PrintController.PrintDocIncomeReport((BaseReport)dgvReport.Tag, ((FundInfo[])dgvTotalInfo.Tag).ToList());
            }
            catch(Exception err)
            {
                MessageBox.Show("打印发生错误！联系管理员检查模板文件及参数是否正确");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
