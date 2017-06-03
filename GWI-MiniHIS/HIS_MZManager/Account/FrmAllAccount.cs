using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.MZ_BLL;
using System.Collections;

namespace HIS_MZManager.Account
{
    public partial class FrmAllAccount : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private GWMHIS.BussinessLogicLayer.Classes.User currentUser;

        private BaseAccountBook _currentAccountBook;

        private List<PrivyAccountBook> accountBook;
        private List<PrivyAccountBook> notAccountBook;

        /// <summary>
        /// 交款汇总
        /// </summary>
        /// <param name="FormText"></param>
        /// <param name="CurrentUser"></param>
        public FrmAllAccount( string FormText, GWMHIS.BussinessLogicLayer.Classes.User CurrentUser )
        {
            InitializeComponent( );

            currentUser = CurrentUser;

            this.Text = FormText;
            this.FormTitle = FormText;

            
        }

        private void FrmAllAccount_Load( object sender , EventArgs e )
        {
            dtpTo.Value = Convert.ToDateTime( HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString( "yyyy-MM-dd" ) + " 23:59:59" );
            dtpFrom.Value = dtpTo.Value.AddDays( -1 ).AddSeconds( 1 );

            cboChargeUser.DisplayMember = "NAME";
            cboChargeUser.ValueMember = "EMPLOYEE_ID";
            //cboChargeUser.DataSource = PublicDataReader.Employeies;
            cboChargeUser.DataSource = BaseDataController.BaseDataSet[BaseDataCatalog.人员列表];

            if ( chkChargeUser.Checked )
            {
                cboChargeUser.Enabled = true;
            }
            else
            {
                cboChargeUser.Enabled = false;
            }

            chkChargeUser.CheckedChanged += new EventHandler( chkChargeUser_CheckedChanged );
        }

        void chkChargeUser_CheckedChanged( object sender , EventArgs e )
        {
            cboChargeUser.Enabled = chkChargeUser.Checked;
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            try
            {
                btnOk.Enabled = false;
                btnPrint.Enabled = false;
                btnClose.Enabled = false;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor( );
                CreateTreeList( );
            }
            catch ( Exception err )
            {
                MessageBox.Show( "统计发生错误！请稍后再试！" );
                ErrorWriter.WriteLog( err.Message );
            }
            finally
            {
                Cursor = Cursors.Default;
                btnOk.Enabled = true;
                btnPrint.Enabled = true;
                btnClose.Enabled = true;
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
        }

        private void tvwAccountList_AfterSelect( object sender , TreeViewEventArgs e )
        {
            //ClearInfo( );
            //if ( e.Node.Tag == null )
            //{
            //    return;
            //}
            
            //if ( e.Node.Tag.GetType( ) == typeof( PrivyAccountBook ) )
            //{
            //    //ShowAccountBook( (PrivyAccountBook)e.Node.Tag );
            //    _currentAccountBook = (PrivyAccountBook)e.Node.Tag;
            //    Showdata();
            //}
            //if ( e.Node.Tag.GetType( ) == typeof( CollectAccountBook ) )
            //{
            //    ShowAccountBook( (CollectAccountBook)e.Node.Tag );
            //    _currentAccountBook = (CollectAccountBook)e.Node.Tag;
            //}
           
        }

        private void dgvInvoiceList_CellContentClick( object sender , DataGridViewCellEventArgs e )
        {
            if (_currentAccountBook is CollectAccountBook || _currentAccountBook==null)
                return;

            Invoice[] invoices = null;
            bool refund = false;
            if ( e.ColumnIndex == dgvInvoiceList.Columns[TotalNum.Name].Index )
            {
                if ( _currentAccountBook != null )
                {
                    if ( dgvInvoiceList["InvoiceType" , e.RowIndex].Value.ToString( ) == "收费发票" )
                    {
                        invoices = ( (PrivyAccountBook)_currentAccountBook ).ChargeInvoiceInfo.InvoiceList;
                    }
                    else
                    {
                        invoices = ( (PrivyAccountBook)_currentAccountBook ).RegisterInvoiceInfo.InvoiceList;
                    }
                }
                refund = false;
            }
            else if ( e.ColumnIndex == dgvInvoiceList.Columns[RefundNum.Name].Index )
            {
                if ( dgvInvoiceList["InvoiceType" , e.RowIndex].Value.ToString( ) == "收费发票" )
                {
                    invoices = ( (PrivyAccountBook)_currentAccountBook ).ChargeInvoiceInfo.RefundInvoice;
                }
                else
                {
                    invoices = ( (PrivyAccountBook)_currentAccountBook ).RegisterInvoiceInfo.RefundInvoice;
                }
                refund = true;
            }
            else
            {
                return;
            }
            FrmViewInvoice fView = new FrmViewInvoice( invoices , refund );
            fView.ShowDialog( );
        }

        private void CreateTreeList()
        {
            int selectedchargeUserId = 0;
            if ( chkChargeUser.Checked )
                selectedchargeUserId = Convert.ToInt32( cboChargeUser.SelectedValue );

            tvwAccountList.Nodes.Clear( );
            DataTable tbHandIn = AccountBookController.GetAccountList( dtpFrom.Value , dtpTo.Value );
            TreeNode tdHandIn = new TreeNode( );
            tdHandIn.Text = "已交款";
            List<PrivyAccountBook> lstAllBooks = new List<PrivyAccountBook>( );
            
            #region 构造交款员树
            for ( int i = 0 ; i < tbHandIn.Rows.Count ; i++ )
            {
                int chargeUserId = Convert.ToInt32( tbHandIn.Rows[i]["AccountCode"] );
                if ( chkChargeUser.Checked && chargeUserId != selectedchargeUserId )
                    continue;

                if ( tdHandIn.Nodes.Count == 0 )
                {
                    TreeNode ndUser = new TreeNode( );                   
                    ndUser.Text = BaseDataController.GetName( BaseDataCatalog.人员列表, chargeUserId );
                    ndUser.Tag = chargeUserId;
                    tdHandIn.Nodes.Add( ndUser );
                }
                else
                {
                    bool hasIntree = false;
                    foreach ( TreeNode nd in tdHandIn.Nodes )
                    {
                        if ( Convert.ToInt32( nd.Tag ) == chargeUserId )
                        {
                            hasIntree = true;
                            break;
                        }
                    }
                    if ( !hasIntree )
                    {
                        TreeNode ndUser = new TreeNode( );                     
                        ndUser.Text = BaseDataController.GetName( BaseDataCatalog.人员列表, chargeUserId );
                        ndUser.Tag = chargeUserId;
                        tdHandIn.Nodes.Add( ndUser );
                    }
                }
            }
            #endregion

            #region 生成账单明细，并合并
            foreach ( TreeNode ndUser in tdHandIn.Nodes )
            {
                int chargeUserId = Convert.ToInt32( ndUser.Tag );
                DataRow[] drsAccount = tbHandIn.Select( "ACCOUNTCODE=" + chargeUserId , "ACCOUNTDATE asc" );
                int[] accountIdList= new int[drsAccount.Length];
                for( int i=0;i< drsAccount.Length;i++)
                    accountIdList[i] = Convert.ToInt32( drsAccount[i]["ACCOUNTID"]  );
                DataTable tbInvoice;
                DataTable tbInvoiceDetail;
                AccountBookController.GetAccountData( chargeUserId , accountIdList , out tbInvoice , out tbInvoiceDetail );
                //个人所有账单
                List<PrivyAccountBook> lstBook = new List<PrivyAccountBook>( );

                for ( int i = 0 ; i < drsAccount.Length ; i++ )
                {
                    TreeNode ndDate = new TreeNode( );
                    ndDate.Text = Convert.ToDateTime( drsAccount[i]["ACCOUNTDATE"] ).ToString( "yyyy-MM-dd HH:mm:ss" );
                    int accountId = Convert.ToInt32( drsAccount[i]["ACCOUNTID"]  );
                    PrivyAccountBook book = AccountBookController.GetPrivyAccountBook( chargeUserId , accountId , tbInvoice , tbInvoiceDetail , tbHandIn );
                    ndDate.Tag = book;
                    ndUser.Nodes.Add( ndDate );
                    lstBook.Add( book );
                }               
                //PrivyAccountBook totalBook = AccountBookController.CollectPrivyAccountBook( lstBook );
                ndUser.Tag = new PrivyAccountBook();
                //lstAllBooks.Add( totalBook );
            }
            #endregion
            tvwAccountList.Nodes.Add( tdHandIn );
            //CollectAccountBook allBook = AccountBookController.CollectAllAccountBook( lstAllBooks );
             tdHandIn.Tag =  new PrivyAccountBook();

            DataTable tbUnHandIn = AccountBookController.GetNotHandInAccountUser( );
            TreeNode ndUnHandIn = new TreeNode( );
            List<PrivyAccountBook> lstAllnothandBook = new List<PrivyAccountBook>( );
            ndUnHandIn.Text = "未交款";
            for ( int i = 0 ; i < tbUnHandIn.Rows.Count ; i++ )
            {
                TreeNode ndUnhandInUser = new TreeNode( );
                ndUnhandInUser.Text = tbUnHandIn.Rows[i]["CHARGENAME"].ToString().Trim();
                int chargeUserId = Convert.ToInt32( tbUnHandIn.Rows[i]["CHARGECODE"] );
                if ( chkChargeUser.Checked && chargeUserId != selectedchargeUserId )
                    continue;

                //PrivyAccountBook book = AccountBookController.GetPrivyAccountBook( chargeUserId , 0 );
                ndUnhandInUser.Tag = new PrivyAccountBook();
                ndUnHandIn.Nodes.Add( ndUnhandInUser );
               // lstAllnothandBook.Add( book );
            }

            tvwAccountList.Nodes.Add( ndUnHandIn );
            //CollectAccountBook notHandBook = AccountBookController.CollectAllAccountBook( lstAllnothandBook );
            ndUnHandIn.Tag = new PrivyAccountBook();

            tvwAccountList.ExpandAll( );
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

        private void ShowAccountBook( BaseAccountBook book )
        {

            int row = 0;
          
            #region 显示收费票据
            if ( book is PrivyAccountBook )
            {             

                ChargeName.Visible = false;        
                PrivyAccountBook privyBook = (PrivyAccountBook)book;
                row = dgvInvoiceList.Rows.Add( );
                dgvInvoiceList[InvoiceType.Name , row].Value = "收费发票";
                dgvInvoiceList[NumberStartAndEnd.Name , row].Value = privyBook.ChargeInvoiceInfo.StartNumber + "  ——  " + privyBook.ChargeInvoiceInfo.EndNumber;
                dgvInvoiceList[TotalNum.Name , row].Value = privyBook.ChargeInvoiceInfo.Count;
                dgvInvoiceList[RefundNum.Name , row].Value = privyBook.ChargeInvoiceInfo.RefundCount;
                dgvInvoiceList[RefundMoney.Name , row].Value = privyBook.ChargeInvoiceInfo.RefundMoney;
      
                row = dgvInvoiceList.Rows.Add( );
                dgvInvoiceList[InvoiceType.Name , row].Value = "挂号发票";
                dgvInvoiceList[NumberStartAndEnd.Name , row].Value = privyBook.RegisterInvoiceInfo.StartNumber + "  ——  " + privyBook.RegisterInvoiceInfo.EndNumber;
                dgvInvoiceList[TotalNum.Name , row].Value = privyBook.RegisterInvoiceInfo.Count;
                dgvInvoiceList[RefundNum.Name , row].Value = privyBook.RegisterInvoiceInfo.RefundCount;
                dgvInvoiceList[RefundMoney.Name , row].Value = privyBook.RegisterInvoiceInfo.RefundMoney;
             
            }
            else
            {
                ChargeName.Visible = true;
          
                CollectAccountBook collectBook = (CollectAccountBook)book;
                for ( int i = 0 ; i < collectBook.ChargeInvoiceInfo.Length ; i++ )
                {
                    if ( (collectBook.ChargeInvoiceInfo[i].StartNumber!=null && collectBook.ChargeInvoiceInfo[i].StartNumber != "") && ( collectBook.ChargeInvoiceInfo[i].EndNumber != null && collectBook.ChargeInvoiceInfo[i].EndNumber != "" ))
                    {
                        row = dgvInvoiceList.Rows.Add( );
                        dgvInvoiceList[InvoiceType.Name , row].Value = "收费发票";
                        dgvInvoiceList[ChargeName.Name , row].Value = collectBook.ChargeInvoiceInfo[i].ChargeName;
                        dgvInvoiceList[NumberStartAndEnd.Name , row].Value = collectBook.ChargeInvoiceInfo[i].StartNumber + "  ——  " + collectBook.ChargeInvoiceInfo[i].EndNumber;
                        dgvInvoiceList[TotalNum.Name , row].Value = collectBook.ChargeInvoiceInfo[i].Count;
                        dgvInvoiceList[RefundNum.Name , row].Value = collectBook.ChargeInvoiceInfo[i].RefundCount;
                        dgvInvoiceList[RefundMoney.Name , row].Value = collectBook.ChargeInvoiceInfo[i].RefundMoney;
                       
                    }
                }
                for ( int i = 0 ; i < collectBook.RegisterInvoiceInfo.Length ; i++ )
                {
                    if ( ( collectBook.RegisterInvoiceInfo[i].StartNumber != null && collectBook.RegisterInvoiceInfo[i].StartNumber != "" ) && ( collectBook.RegisterInvoiceInfo[i].EndNumber != null && collectBook.RegisterInvoiceInfo[i].EndNumber != "" ) )
                    {
                        row = dgvInvoiceList.Rows.Add( );
                        dgvInvoiceList[InvoiceType.Name , row].Value = "挂号发票";
                        dgvInvoiceList[ChargeName.Name , row].Value = collectBook.RegisterInvoiceInfo[i].ChargeName;
                        dgvInvoiceList[NumberStartAndEnd.Name , row].Value = collectBook.RegisterInvoiceInfo[i].StartNumber + "  ——  " + collectBook.RegisterInvoiceInfo[i].EndNumber;
                        dgvInvoiceList[TotalNum.Name , row].Value = collectBook.RegisterInvoiceInfo[i].Count;
                        dgvInvoiceList[RefundNum.Name , row].Value = collectBook.RegisterInvoiceInfo[i].RefundCount;
                        dgvInvoiceList[RefundMoney.Name , row].Value = collectBook.RegisterInvoiceInfo[i].RefundMoney;
                   
                    }
                }
            }
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
            if ( book.TallyPart.Details != null )
            {
                for ( int i = 0 ; i < book.TallyPart.Details.Length ; i++ )
                {
                    row = dgvTallyPart.Rows.Add( );
                    dgvTallyPart[TallyType.Name , row].Value = book.TallyPart.Details[i].PayName.Replace( "_记账" , "" );
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
            }
            #endregion

            #region 现金
            txtFavor.Text = book.FavorPart.TotalMoney.ToString( );
            txtFactCash.Text = book.CashPart.TotalMoney.ToString( );
            if ( book.CashPart.Details != null )
            {
                txtChargeFee.Text = book.CashPart.Details[0].Money.ToString( );
                txtRegFee.Text = book.CashPart.Details[1].Money.ToString( );
                txtExiamFee.Text = book.CashPart.Details[2].Money.ToString( );

                txtTotal.Text = book.InvoiceItemSumTotal.ToString( );
                txtTotalCN.Text = HIS.SYSTEM.PubicBaseClasses.Money.NumToChn( book.InvoiceItemSumTotal.ToString( ) );

                if ( book.CashPart.TotalMoney != ( book.CashPart.Details[1].Money + book.CashPart.Details[2].Money + book.CashPart.Details[0].Money ) )
                {
                    txtFactCash.ForeColor = Color.Red;
                }
                else
                {
                    txtFactCash.ForeColor = Color.Black;
                }
            }
            #endregion
        }
        
        private void btnPrint_Click( object sender , EventArgs e )
        {
            //MessageBox.Show( "抱歉，暂时不能打印，报表格式商讨中。。。" ,"",MessageBoxButtons.OK,MessageBoxIcon.Information);
            if (accountBook != null && accountBook.Count > 0)
            {
                PrintController.PrintAllAccountBook(accountBook, dtpFrom.Value, dtpTo.Value);
            }
            else
            {
                MessageBox.Show("没有选择已交款记录,不能打印");
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
        private void tvwAccountList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ClearInfo();           
            if (e.Node.Tag == null)
            {
                return;
            }
             accountBook = new List<PrivyAccountBook>();
             notAccountBook = new List<PrivyAccountBook>();

             this.tvwAccountList.AfterCheck -= new TreeViewEventHandler(tvwAccountList_AfterCheck);
             this.tvwAccountList.SelectedNode = e.Node;
             _currentAccountBook = (PrivyAccountBook)e.Node.Tag;
             accountBook.Clear();
            //设置子节点是否勾选
             SetNodeChecked(this.tvwAccountList.SelectedNode, this.tvwAccountList.SelectedNode.Checked);
            //勾已交款的节点把未交款节点全改为false，反之
             bool b = GetParent(this.tvwAccountList.SelectedNode);
            //得到勾选的节点的ID
             GetNode(this.tvwAccountList.Nodes, b);
            if (b == true)
            {
                CollectAccountBook totalBook = AccountBookController.CollectAllAccountBook(accountBook);
                ShowAccountBook(totalBook);
            }
            else
            {
                CollectAccountBook totalBook1 = AccountBookController.CollectAllAccountBook(notAccountBook);
                ShowAccountBook(totalBook1);
            }
            this.tvwAccountList.AfterCheck += new TreeViewEventHandler(tvwAccountList_AfterCheck);
        }


        public void SetNodeChecked(TreeNode tn, bool b)
        {
            TreeNodeCollection tc = tn.Nodes;
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
                TreeNodeCollection tc = tnn.Nodes;
                foreach (TreeNode TNode in tc)
                {
                    TNode.Checked = false;
                    SetNodeChecked(TNode, false);
                }
                return true;
            }

            return GetParent(tn.Parent);
        }

        public void GetNode(TreeNodeCollection tc, bool b)
        {
            foreach (TreeNode TNode in tc)
            {
                if (TNode.Checked && TNode.Tag != null && TNode.Text.Trim()!="未交款" && TNode.Text.Trim()!="已交款")
                {
                    if (b == true)
                        
                        accountBook.Add((PrivyAccountBook)TNode.Tag);
                    else
                    {
                        if (notAccountBook.Exists(x => x == TNode.Tag) == false)
                            notAccountBook.Add((PrivyAccountBook)TNode.Tag);
                    }
                }
                GetNode(TNode.Nodes, b);
            }
        }
    }
}
