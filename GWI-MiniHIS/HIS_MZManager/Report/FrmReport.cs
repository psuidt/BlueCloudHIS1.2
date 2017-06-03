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
using HIS.MZ_BLL.Exceptions;
using System.Collections;

namespace HIS_MZManager.Report
{
    public partial class FrmReport : BaseMainForm
    {
        private int currentEmployeeId;
        /// <summary>
        /// 设置按钮可用状态
        /// </summary>
        /// <param name="enable"></param>
        private void SetButtonEnable( bool enable )
        {
            btnStat.Enabled = enable;
            btnPrint.Enabled = enable;
            btnExcel.Enabled = enable;
            btnClose.Enabled = enable;
        }

        public FrmReport(int CurrentEmployeeId,string FormText)
        {
            InitializeComponent( );

            this.FormTitle = FormText;
            this.Text = FormText;

            currentEmployeeId = CurrentEmployeeId;
        }

        private void FrmReport_Load( object sender , EventArgs e )
        {
            foreach ( object obj in Enum.GetValues( typeof( StatDateType ) ) )
                cboDateType.Items.Add( obj.ToString( ) );
            cboDateType.Text = StatDateType.统计日.ToString( );

            foreach ( object obj in Enum.GetValues( typeof( StatClassType ) ) )
                cboStatType.Items.Add( obj.ToString( ) );
            cboStatType.Text = StatClassType.门诊发票分类.ToString( );

            foreach ( object obj in Enum.GetValues( typeof( ReportStyle ) ) )
                cboStyle.Items.Add( obj.ToString( ) );
            cboStyle.Text = ReportStyle.科目为标题列.ToString( );

            foreach ( object obj in Enum.GetValues( typeof( StatObjctType ) ) )
                cboType.Items.Add( obj.ToString( ) );
            cboType.Text = StatObjctType.医生.ToString( );
            

            dtpFrom.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 00:00:00" );
            dtpEnd.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 23:59:59" );

            ReportController.OnReportProcessing += new OnReportProcessingHandler( ReportController_OnReportProcessing );
        }

        void ReportController_OnReportProcessing( ReportProcessingEventArgs e )
        {
            lblInfo.Text = e.Status;
            lblInfo.Refresh( );
        }

        private void btnStat_Click( object sender , EventArgs e )
        {
            DateTime beginDate;
            DateTime endDate;
            BaseReport report = null;
            string accountIdList;
            int statDay = Convert.ToInt32( txtDay.Text );
            StatDateType dateType = StatDateType.统计日;
            StatClassType statType = StatClassType.门诊发票分类;
            StatObjctType statObjectType = StatObjctType.医生;
            ReportStyle style = ReportStyle.科目为标题列;
            #region 统计条件            
            foreach ( object obj in Enum.GetValues( typeof( StatDateType ) ) )
            {
                if ( obj.ToString( ) == cboDateType.Text )
                {
                    dateType = (StatDateType)obj;
                    break;
                }
            }
            foreach ( object obj in Enum.GetValues( typeof( StatClassType ) ) )
            {
                if ( obj.ToString( ) == cboStatType.Text )
                {
                    statType = (StatClassType)obj;
                    break;
                }
            }
            foreach ( object obj in Enum.GetValues( typeof( ReportStyle ) ) )
            {
                if ( obj.ToString( ) == cboStyle.Text )
                {
                    style = (ReportStyle)obj;
                    break;
                }
            }
            foreach ( object obj in Enum.GetValues( typeof( StatObjctType ) ) )
            {
                if ( obj.ToString( ) == cboType.Text )
                {
                    statObjectType = (StatObjctType)obj;
                    break;
                }
            }
            #endregion
            try
            {
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor( );
                SetButtonEnable( false );
                ReportController.GetReportBeginDateAndEndDate( dateType , statDay , dtpFrom.Value , dtpEnd.Value , out beginDate , out endDate , out accountIdList );
                lblDate.Text = beginDate.ToString( "yyyy-MM-dd HH:mm:ss" ) + "  ——  " + endDate.ToString( "yyyy-MM-dd HH:mm:ss" );
                switch ( statObjectType )
                {
                    case StatObjctType.医生:
                        report = new DoctorIncomeReport( );
                        break;
                    case StatObjctType.科室:
                        report = new DepartmentIncomeReport( );
                        break;
                    case StatObjctType.收费员:
                        report = new TollerIncomeReport( );
                        break;
                    case StatObjctType.病人类型:
                        report = new PatientTypeIncomReport( );
                        break;
                }
                report.BeginDate = beginDate;
                report.EndDate = endDate;
                report.StatType = statType;
                report.Reportstyle = style;
                report.StatDateType = dateType;
                report.AccountIdList = accountIdList;
                report.StatObjectType = statObjectType;
                report.ReportTitle = "门诊" + cboType.Text + "收入报表";
                //report.Lister = PublicDataReader.GetEmployeeNameById( currentEmployeeId );
                report.Lister = BaseDataController.GetName( BaseDataCatalog.人员列表, currentEmployeeId );

                ReportController.FillReport( report );
                dgvReport.DataSource = report.DataResult;
                dgvReport.Tag = report;

                for ( int i = 1 ; i < dgvReport.Columns.Count ; i++ )
                {
                    dgvReport.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvReport.Columns[i].Width = 80;
                }
                dgvReport.Columns[0].Frozen = true;
                dgvReport.Columns[1].Frozen = true;


                if (chkChargeTotalInfo.Checked)
                {
                    StatTotalInfo();
                }
                else
                {
                    dgvTotalInfo.DataSource = null;
                }
            }
            catch ( OperatorException oe )
            {
                MessageBox.Show( oe.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Message );
                MessageBox.Show( "统计报表中发生错误！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            finally
            {
                SetButtonEnable( true  );
                Cursor = Cursors.Default;
            }
        }

        private void cboDateType_SelectedIndexChanged( object sender , EventArgs e )
        {
            if ( cboDateType.Text == StatDateType.统计日.ToString() )
            {
                dtpFrom.CustomFormat = "yyyy-MM";
                dtpEnd.CustomFormat = "yyyy-MM";
            }
            if ( cboDateType.Text == StatDateType.交账时间.ToString( ) || cboDateType.Text == StatDateType.自定义时间.ToString( ))
            {
                dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            }
            if ( cboDateType.Text == StatDateType.自然时间.ToString( ) )
            {
                dtpFrom.CustomFormat = "yyyy-MM-dd";
                dtpEnd.CustomFormat = "yyyy-MM-dd";
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnPrint_Click( object sender , EventArgs e )
        {
            
            if ( dgvReport.Tag == null )
            {
                MessageBox.Show( "没有数据可打印，请先统计" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }
            if ( chkChargeTotalInfo.Checked && dgvTotalInfo.DataSource == null )
            {
                MessageBox.Show("请选中科目汇总复选框重新统计后在打印", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            PrintReport( (BaseReport)dgvReport.Tag , chkPreview.Checked );
        }

        private void PrintReport(BaseReport Report,bool preview)
        {
            try
            {
                if (chkChargeTotalInfo.Checked)
                {
                    PrintController.PrintIncomeReport(Report, ((FundInfo[])dgvTotalInfo.Tag).ToList());
                }
                else
                {
                    PrintController.PrintIncomeReport(Report, preview);
                }
            }
            catch(Exception err)
            {
                ErrorWriter.WriteLog( err.Message );
                MessageBox.Show( "预览/打印发生错误！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnExcel_Click( object sender , EventArgs e )
        {
            if ( dgvReport.Tag == null )
            {
                MessageBox.Show( "没有数据可打印，请先统计" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }
            try
            {
                SetButtonEnable( false );
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor( );
                if (chkChargeTotalInfo.Checked)
                {
                    PrintController.ReportToExcel((BaseReport)dgvReport.Tag,((FundInfo[])dgvTotalInfo.Tag).ToList() );
                }
                else
                {
                    PrintController.ReportToExcel((BaseReport)dgvReport.Tag);
                }
            }
            catch
            {
                MessageBox.Show( "输出到Excel发生错误！","",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
            finally
            {
                SetButtonEnable( true );
                Cursor = Cursors.Default;
            }
        }

        private void chkChargeTotalInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChargeTotalInfo.Checked)
            {
                cboDateType.Enabled = false;
                cboDateType.Text = StatDateType.交账时间.ToString();
            }
            else
            {
                cboDateType.Enabled = true;
            }
        }

        private void StatTotalInfo()
        {
           // int selectedchargeUserId = 0;

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

    }
}
