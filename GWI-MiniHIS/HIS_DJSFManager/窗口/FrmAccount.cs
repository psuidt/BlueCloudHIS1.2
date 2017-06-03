using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using grproLib;
using HIS_DJSFManager.类;

namespace HIS_DJSFManager.窗口
{
    public partial class FrmAccount : GWI.HIS.Windows.Controls.BaseForm
    {
        
        private grproLib.GridppReport reportPrinter ;

        
        private int _currentEmployeeId;
        private string _currentEmployeeName;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CurrentUser"></param>
        public FrmAccount( int CurrentEmployeeId,string CurrentEmployeeName )
        {
            InitializeComponent( );

           
            _currentEmployeeId = CurrentEmployeeId;
            _currentEmployeeName = CurrentEmployeeName;

            
        }

        private void FrmAccount_Load( object sender , EventArgs e )
        {
            DataTable tb = new DataTable( );
            tb.Columns.Add( "NAME" );
            tb.Columns.Add( "EMPLOYEE_ID" );
            tb.Rows.Add( new object[] { _currentEmployeeName , _currentEmployeeId } );

            cboUser.SelectedIndexChanged += new EventHandler( cboUser_SelectedIndexChanged );
            cboAccountDate.SelectedIndexChanged +=new EventHandler(cboAccountDate_SelectedIndexChanged);
            cboUser.DisplayMember = "NAME";
            cboUser.ValueMember = "EMPLOYEE_ID";
            cboUser.DataSource = tb;
            cboUser.SelectedValue = _currentEmployeeId;
            
        }

        void cboUser_SelectedIndexChanged( object sender , EventArgs e )
        {
            DataTable tb = AccountBookController.GetAccountHandInDate( Convert.ToInt32( cboUser.SelectedValue ) );
            DataTable tbDate = new DataTable( );
            tbDate.Columns.Add( "AccountId" , Type.GetType( "System.Int32" ) );
            tbDate.Columns.Add( "AccountDate" , Type.GetType( "System.String" ) );

            DataRow drCurrent = tbDate.NewRow( );
            drCurrent["AccountId"] = 0;
            drCurrent["AccountDate"] = "<当前未交>";
            tbDate.Rows.Add( drCurrent );
            foreach ( DataRow dr in tb.Rows )
            {
                DataRow drOld = tbDate.NewRow( );
                drOld["AccountId"] = dr[0];
                drOld["AccountDate"] = Convert.ToDateTime( dr["AccountDate"] ).ToString( "yyyy-MM-dd HH:mm:ss" );
                tbDate.Rows.Add(drOld);
            }
            cboAccountDate.DisplayMember = "AccountDate";
            cboAccountDate.ValueMember = "AccountId";
            cboAccountDate.DataSource = tbDate;

            cboAccountDate_SelectedIndexChanged( null , null );
        }

        void cboAccountDate_SelectedIndexChanged( object sender , EventArgs e )
        {
            int accountId = Convert.ToInt32( cboAccountDate.SelectedValue );
            if ( accountId == 0 && Convert.ToInt32(_currentEmployeeId) == Convert.ToInt32(cboUser.SelectedValue) )
            {
                btnHandIn.Enabled = true;
                btnPrint.Enabled = false;
            }
            else
            {
                btnHandIn.Enabled = false;
                btnPrint.Enabled = true;
            }

            ClearInfo( );
            PrivyAccountBook book;
           
            book = AccountBookController.GetPrivyAccountBook( Convert.ToInt32( _currentEmployeeId ) , accountId );
            
                
            this.Tag = book;
            if ( book != null )
                ShowAccountBook( book );
            
        }

        private void ClearInfo()
        {
            dgvInvoiceItem.Rows.Clear( );
            dgvTallyPart.Rows.Clear( );
            dgvInvoiceList.Rows.Clear( );
            txtChargeFee.Text = "0.0";
            txtExiamFee.Text = "0.0";
            txtFactCash.Text = "0.0";
            txtFavor.Text = "0.0";
            txtRegFee.Text = "0.0";
            txtTotal.Text = "0.0";
            txtTotalCN.Text = "0.0";
            this.Tag = null;
        }

        private void ShowAccountBook(PrivyAccountBook book)
        {
            
            int row = 0;

            #region 显示收费票据
            row = dgvInvoiceList.Rows.Add( );
            //row = dgvInvoiceList.Rows.Count-1;
            dgvInvoiceList[InvoiceType.Name , row].Value = "收费发票";
            dgvInvoiceList[NumberStartAndEnd.Name , row].Value = book.ChargeInvoiceInfo.StartNumber + "  ——  " + book.ChargeInvoiceInfo.EndNumber;
            dgvInvoiceList[TotalNum.Name , row].Value = book.ChargeInvoiceInfo.Count;
            dgvInvoiceList[RefundNum.Name , row].Value = book.ChargeInvoiceInfo.RefundCount;
            dgvInvoiceList[RefundMoney.Name , row].Value = book.ChargeInvoiceInfo.RefundMoney;
            dgvInvoiceList[ViewDetail.Name , row].Value = "查看";
            row = dgvInvoiceList.Rows.Add( );
            //row = dgvInvoiceList.Rows.Count - 1;
            dgvInvoiceList[InvoiceType.Name , row].Value = "挂号发票";
            dgvInvoiceList[NumberStartAndEnd.Name , row].Value = book.RegisterInvoiceInfo.StartNumber + "  ——  " + book.RegisterInvoiceInfo.EndNumber;
            dgvInvoiceList[TotalNum.Name , row].Value = book.RegisterInvoiceInfo.Count;
            dgvInvoiceList[RefundNum.Name , row].Value = book.RegisterInvoiceInfo.RefundCount;
            dgvInvoiceList[RefundMoney.Name , row].Value = book.RegisterInvoiceInfo.RefundMoney;
            dgvInvoiceList[ViewDetail.Name , row].Value = "查看";
            #endregion

            #region 显示发票科目
            for ( int i = 0 ; i < book.InvoiceItem.Length ; i++ )
            {
                row = dgvInvoiceItem.Rows.Add( );
                //row = dgvInvoiceItem.Rows.Count - 1;
                dgvInvoiceItem[ITEM_NAME.Name , row].Value = book.InvoiceItem[i].ItemName.Trim( );
                dgvInvoiceItem[MONEY.Name , row].Value = book.InvoiceItem[i].Cost;
            }
            row = dgvInvoiceItem.Rows.Add( );
            //row = dgvInvoiceItem.Rows.Count - 1;
            dgvInvoiceItem[ITEM_NAME.Name , row].Value = "科目合计";
            dgvInvoiceItem[MONEY.Name , row].Value = book.InvoiceItemSumTotal;
            dgvInvoiceItem[ITEM_NAME.Name , row].Style.Font = new Font( "宋体" , 12F , FontStyle.Bold );
            dgvInvoiceItem[MONEY.Name , row].Style.Font = new Font( "宋体" , 12F , FontStyle.Bold );
            #endregion

            #region 显示记账部分
            int count = 0;
            for ( int i = 0 ; i < book.TallyPart.Details.Length ; i++ )
            {
                row = dgvTallyPart.Rows.Add( );
                dgvTallyPart[TallyType.Name , row].Value = book.TallyPart.Details[i].PayName.Replace("_记账","");
                dgvTallyPart[TallyNumber.Name , row].Value = book.TallyPart.Details[i].BillCount;
                dgvTallyPart[TallyMoney.Name , row].Value = book.TallyPart.Details[i].Money;
                count += book.TallyPart.Details[i].BillCount;
            }
            row = dgvTallyPart.Rows.Add( );
            dgvTallyPart[TallyType.Name , row].Value = "记账合计";
            dgvTallyPart[TallyNumber.Name , row].Value = count;
            dgvTallyPart[TallyMoney.Name , row].Value = book.TallyPart.TotalMoney;

            dgvTallyPart[TallyType.Name , row].Style.Font = new Font( "宋体" , 12F , FontStyle.Bold );
            dgvTallyPart[TallyNumber.Name , row].Style.Font = new Font( "宋体" , 12F , FontStyle.Bold );
            dgvTallyPart[TallyMoney.Name , row].Style.Font = new Font( "宋体" , 12F , FontStyle.Bold );
            #endregion

            #region 现金
            txtFavor.Text = book.FavorPart.TotalMoney.ToString();
            txtFactCash.Text = book.CashPart.TotalMoney.ToString( );

            txtChargeFee.Text = book.CashPart.Details[0].Money.ToString( );
            txtRegFee.Text = book.CashPart.Details[1].Money.ToString( );
            txtExiamFee.Text = book.CashPart.Details[2].Money.ToString( );

            txtTotal.Text = book.InvoiceItemSumTotal.ToString( );
            //txtTotalCN.Text = HIS.SYSTEM.PubicBaseClasses.Money.NumToChn( book.InvoiceItemSumTotal.ToString( ) );

            if ( book.CashPart.TotalMoney != ( book.CashPart.Details[1].Money + book.CashPart.Details[2].Money + book.CashPart.Details[0].Money ) )
            {
                txtFactCash.ForeColor = Color.Red;
            }
            else
            {
                txtFactCash.ForeColor = Color.Black;
            }
            #endregion
        }

        private void btnPrint_Click( object sender , EventArgs e )
        {
            if ( this.Tag != null )
            {
                PrivyAccountBook book = (PrivyAccountBook)this.Tag;
                if ( book.AccountId == 0 )
                {
                    MessageBox.Show( "没交款的账单不能打印！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    return;
                }
                PrintController.PrintAccountBook( book );
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnHandIn_Click( object sender , EventArgs e )
        {
            try
            {
                if ( this.Tag != null )
                {
                    bool ret = AccountBookController.HandInAccount( Convert.ToInt32( _currentEmployeeId ) , (PrivyAccountBook)this.Tag );
                    if ( ret == true )
                    {
                        MessageBox.Show( "交款完成，请及时打印交款单！" );
                        cboUser_SelectedIndexChanged( null , null );
                    }
                    else
                    {
                        MessageBox.Show( "交款不成功！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    }
                }
                else
                {
                    MessageBox.Show( "没有需要交款的数据！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                }
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void dgvInvoiceList_CellContentClick( object sender , DataGridViewCellEventArgs e )
        {
            if ( e.ColumnIndex == dgvInvoiceList.Columns[ViewDetail.Name].Index )
            {
                if ( this.Tag != null )
                {
                    FrmViewInvoice fView = null;
                    PrivyAccountBook book = (PrivyAccountBook)this.Tag;
                    if ( dgvInvoiceList["InvoiceType" , e.RowIndex].Value.ToString( ) == "收费发票" )
                    {
                        fView = new FrmViewInvoice( book , OPDBillKind.门诊收费发票 );
                    }
                    else
                    {
                        fView = new FrmViewInvoice( book , OPDBillKind.门诊挂号发票 );
                    }
                    fView.ShowDialog( );
                }
            }
        }
    }
}
