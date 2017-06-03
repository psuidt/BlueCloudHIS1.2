using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_MZManager.HJSF
{
    public partial class FrmBudgetBalance : BaseMainForm , IFrmBudgeBalance
    {
        private User _currentUser;
        private Deptment _currentDept;
        private FrmBudgetBalanceController controller;
        private FrmPreviousInfo frmPreviousInfo;
        private string decimalFormat = "#0.#0";
        private int formAction;//窗体行为：0 - 门诊收费 1 - 门诊划价 2 - 药房划价

        public FrmBudgetBalance(string FormText,FormType actionType,User CurrentUser,Deptment CurrentDept)
        {
            InitializeComponent( );

            this.Text = FormText;
            this.FormTitle = FormText;

            _currentUser = CurrentUser;
            _currentDept = CurrentDept;

            switch ( actionType )
            {
                case FormType.门诊收费:
                    formAction = 0;
                    break;
                case FormType.门诊划价 :
                    formAction = 1;
                    break;
                default:
                    formAction = 2;
                    break;
            }

            Font font9 = new Font( "宋体" , 9F );
            Font font10 = new Font( "宋体" , 10F );
            this.Font = font9;
            this.dgvPrescription.RowTemplate.Height = 22;
            this.dgvPrescription.Font = font10;
            txtPresDoctor.SelectionCardFont = font10;
            txtDocDept.SelectionCardFont = font10;

            this.Load += new EventHandler( FrmBudgetBalance_Load );
            
            
        }

        void FrmBudgetBalance_KeyDown( object sender , KeyEventArgs e )
        {
            //响应快捷键
            if ( e.KeyCode == Keys.F2 )
            {
                btnSavePrescription_Click( this , null );
            }
            if ( e.KeyCode == Keys.F3 )
            {
                btnNewPrescription_Click( null , null );
            }
            if ( e.KeyCode == Keys.F5 )
            {
                btnRefreshPrescription_Click( null , null );
            }

            if ( e.KeyCode == Keys.F8 )
            {
                btnBalance_Click( null , null );
            }
        }

        void FrmBudgetBalance_Load( object sender , EventArgs e )
        {
            lblDocLabel.Image = tlbFunBar.BackgroundImage;
            this.KeyDown += new KeyEventHandler( FrmBudgetBalance_KeyDown );
            plPatient.SearchingPatient += new OnSearchingPatient( plPatient_SearchingPatient );
            dgvPrescription.CurrentCellChanged += new EventHandler( dgvPrescription_CurrentCellChanged );
            dgvPrescription.Paint += new PaintEventHandler( dgvPrescription_Paint );

            controller = new FrmBudgetBalanceController( this );
            controller.ControllerInitalizeEnd += new OnControllerInitalizeEndEnvenHandle( controller_ControllerInitalizeEnd );
            controller.BeforeDeleteEvent += new OnBeforeDeleteEventHandle( controller_BeforeDeleteEvent );
            controller.BeforeInsertRow += new OnBeforeInsertRowEventHandle( controller_BeforeInsertRow );
            controller.BeforeSavePrescriptionEvent += new OnBeforeSaveEventHandle( controller_BeforeSavePrescriptionEvent );
            controller.AfterSavedEvent += new OnAfterSavedEventHandle( controller_AfterSavedEvent );
            controller.AfterDeleteEvent += new OnAfterDeleteEventHandle( controller_AfterDeleteEvent );
            controller.AfterBudgetEndEvent += new OnAfterBudgetEndEventHandle( controller_AfterBudgetEndEvent );
            controller.AfterBalanceEndEvent += new OnAfterBalanceEndEventHandle( controller_AfterBalanceEndEvent );
            controller.AfterReadPatientPrescription += new OnAfterReadPatientPrescriptionHandler( controller_AfterReadPatientPrescription );
            controller.Initailze( );

            this.dgvPrescription.SetSelectionCardDataSource( controller.ShowCardData , COL_KEYWORD.Name );
            this.dgvPrescription.SelectCardRowSelected += new OnSelectCardRowSelectedHandle( dgvPrescription_SelectCardRowSelected );
            this.dgvPrescription.DataGridViewCellPressEnterKey += new OnDataGridViewCellPressEnterKeyHandle( dgvPrescription_DataGridViewCellPressEnterKey );
            this.dgvPrescription.DataError += new DataGridViewDataErrorEventHandler( dgvPrescription_DataError );
            this.dgvPrescription.DataGridViewCellKeyPress += new OnDataGridViewCellKeyPressHandle( dgvPrescription_DataGridViewCellKeyPress );
            this.dgvPrescription.CellEndEdit += new DataGridViewCellEventHandler( dgvPrescription_CellEndEdit );
            this.dgvPrescription.CellContentClick += new DataGridViewCellEventHandler( dgvPrescription_CellContentClick );

            txtPresDoctor.SetSelectionCardDataSource( controller.Doctors );
            txtDocDept.SetSelectionCardDataSource( controller.Departments );

            txtDocDept.AfterSelectedRow += new AfterSelectedRowHandler( txtDocDept_AfterSelectedRow );
            txtDocDept.KeyPress += new KeyPressEventHandler( txtDocDept_KeyPress );
            if ( formAction == 0 )
                frmPreviousInfo = new FrmPreviousInfo( );
        }

        
        void controller_BeforeSavePrescriptionEvent( object sender , BeforeSaveEventArgs e )
        {
            string message = "";
            //保存处方前检查数据
            if ( controller.CheckDataValidity( out message ) == false )
            {
                MessageBox.Show( message , "数据检查" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                e.Cancel = true;
            }

        }

        void controller_AfterReadPatientPrescription( object sender , AfterReadPatientPrescriptionArgs e )
        {
            if ( e.PrescCount == 0 )
            {
                if ( !e.AfterBalance )
                {
                    txtPresDoctor.Focus( );
                }
                else
                {
                    txtPresDoctor.MemberValue = null;
                    txtPresDoctor.Text = "";
                    txtDocDept.MemberValue = null;
                    txtDocDept.Text = "";
                    plPatient.Clear( );
                    plPatient.Focus( );
                }
            }
            else
            {
                if ( txtPresDoctor.MemberValue != null )
                {
                    tlbFunBar.Focus( );
                    btnNewPrescription.Select( );
                }
                else
                {
                    txtPresDoctor.Focus( );
                }
            }
        }

        void controller_ControllerInitalizeEnd( object sender , ControllerInitalizeEndArgs e )
        {
            if ( e.Cancel )
            {
                this.tlbFunBar.Enabled = false;
                this.KeyDown -= FrmBudgetBalance_KeyDown;
                MessageBox.Show( e.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
            }
            else
            {
                string message = _currentUser.Name + " 你好！";
                message = message + "\r\n\r\n您的当前可用发票号为：" + lblPerfChar.Text +"."+ lblCurrentInvoiceNo.Text;
                message = message + "\r\n\r\n请您在收费前确认该号码是否与打印机上安装的发票号一致！";
                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
            }

        }

        void controller_AfterBudgetEndEvent( object sender , AfterBudgetEndArgs e )
        {
            if ( e.Success )
            {
                //向用户展示结算信息
                FrmChargeInfo frmChargeInfo = new FrmChargeInfo( e.TotalBugetInfo );
                if ( frmChargeInfo.ShowDialog( ) == DialogResult.Cancel )
                {
                    e.ChargeController.CancelCharge( );
                    return;
                }

                //防止在允许收手工录入医保支付或农合补偿金额情况下结算多张处方,
                if ( frmChargeInfo.ReturnChargeInfo.VillageFee > 0 &&
                    e.BudgetInfos.Length > 1 && Convert.ToInt16( HIS.MZ_BLL.OPDParamter.Parameters["002"] ) == 0 )
                {
                    MessageBox.Show( "如果是手工录入的农合补偿金额，每次只能结算一张处方！" , "" , MessageBoxButtons.OK ,
                        MessageBoxIcon.Exclamation );
                    return;
                }
                HIS.MZ_BLL.ChargeInfo[] chargeInfos = e.BudgetInfos;
                e.ChargeController.SetChargeInfoPay( ref chargeInfos , frmChargeInfo.ReturnChargeInfo.VillageFee ,
                                                                       frmChargeInfo.ReturnChargeInfo.PosFee ,
                                                                       frmChargeInfo.ReturnChargeInfo.CashFee ,
                                                                       frmChargeInfo.ReturnChargeInfo.SelfTally );
                e.BudgetInfos = chargeInfos;
                frmPreviousInfo.ActiveGetMoney = frmChargeInfo.ActPay.ToString( decimalFormat );
                frmPreviousInfo.ReturnMoney = frmChargeInfo.ReturnMoney.ToString( decimalFormat );
                controller.Balance( e );
            }
            else
            {
                MessageBox.Show( e.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        void controller_AfterBalanceEndEvent( object sender , AfterBalanceEndArgs e )
        {
            if ( e.Success )
            {
                try
                {
                    PrintController.PrintChargeInvoice( e.Invoices );
                    frmPreviousInfo.PatientName = plPatient.OutPatient.PatientName;
                    frmPreviousInfo.InvoicePics = e.Invoices.Length.ToString( );
                    frmPreviousInfo.TotalMoney = e.BalanceInfo.TotalFee.ToString( decimalFormat );
                    frmPreviousInfo.FavorMoney = e.BalanceInfo.FavorFee.ToString( decimalFormat );
                    frmPreviousInfo.InsurMoney = e.BalanceInfo.VillageFee.ToString( decimalFormat );
                    frmPreviousInfo.SelfPayMoney = e.BalanceInfo.SelfFee.ToString( decimalFormat );
                    frmPreviousInfo.SelfTollyMoney = e.BalanceInfo.SelfTally.ToString( decimalFormat );
                    frmPreviousInfo.PosMoney = e.BalanceInfo.PosFee.ToString( decimalFormat );


                    frmPreviousInfo.Show( );
                    controller.ReadPatientNotBalancePrescription( true );
                }
                catch ( Exception err )
                {
                    MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                }
            }
        }

        void controller_BeforeInsertRow( object sender , BeforeInsertRowArgs e )
        {
            if ( e.Cancel )
            {
                MessageBox.Show( e.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
            }
        }

        void controller_BeforeDeleteEvent( object sender , BeforeDeleteEventArgs e )
        {
            if ( MessageBox.Show( e.Message , "删除" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
            {
                e.Cancel = true;
            }
        }

        void controller_AfterDeleteEvent( object sender , AfterDeleteEventArgs e )
        {
            if ( e.Cancel )
                MessageBox.Show( e.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
        }

        void controller_AfterSavedEvent( object sender , AfterSavedEventArgs e )
        {
            if ( e.Cancel )
                MessageBox.Show( e.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            else
                controller.ReadPatientNotBalancePrescription( false );
        }

        void txtDocDept_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                if ( txtDocDept.MemberValue != null )
                {
                    tlbFunBar.Focus( );
                    btnNewPrescription.Select( );
                }
            }
        }

        void txtDocDept_AfterSelectedRow( object sender , object SelectedValue )
        {
            if ( SelectedValue != null )
            {
                tlbFunBar.Focus( );
                btnNewPrescription.Select( );
            }
        }

        #region 网格操作控制

        void dgvPrescription_CellContentClick( object sender , DataGridViewCellEventArgs e )
        {
            if ( e.ColumnIndex == dgvPrescription.Columns[COL_SELECTED_FLAG.Name].Index )
            {
                controller.SetPrescriptionSelectedStatus( e.RowIndex );
                controller.CalculateAllPrescriptionFee( );
            }
        }

        void dgvPrescription_CellEndEdit( object sender , DataGridViewCellEventArgs e )
        {
            controller.CalculateRowTotalFee( e.RowIndex );
            controller.SetPrescriptionModifyStatus( e.RowIndex );
            controller.SetPrescriptionDosage( e.RowIndex );
            dgvPrescription.Refresh( );
        }

        void dgvPrescription_DataGridViewCellKeyPress( object sender , KeyPressEventArgs e , ref bool handle )
        {
            if ( dgvPrescription.CurrentCell == null )
                return;
            //F1~F12略过
            if ( (int)e.KeyChar >= 112 && (int)e.KeyChar <= 123 )
                return;
            //如果是数量列，控制输入
            if ( dgvPrescription.Columns[dgvPrescription.CurrentCell.ColumnIndex].Name == COL_PACK_NUM.Name ||
                dgvPrescription.Columns[dgvPrescription.CurrentCell.ColumnIndex].Name == COL_BASE_NUM.Name ||
                dgvPrescription.Columns[dgvPrescription.CurrentCell.ColumnIndex].Name == COL_PRES_DOSAGE.Name )
            {
                int key = (int)e.KeyChar;
                if ( key >= 37 && key <= 40 )
                {
                    return;
                }
                if ( key == 40 || key == 13 || key == 27 || key == 8 )
                {
                    return;
                }
                if ((key >= 48 && key <= 57) || ( key >= 96 && key <= 105))
                {
                    return;
                }
                handle = true;
            }
            //如果是序号列直接跳到检索列
            if ( dgvPrescription.Columns[dgvPrescription.CurrentCell.ColumnIndex].Name == COL_PRESNO.Name )
            {
                dgvPrescription.CurrentCell = dgvPrescription[COL_KEYWORD.Name , dgvPrescription.CurrentCell.RowIndex];
                handle = true;
            }
        }

        void dgvPrescription_DataError( object sender , DataGridViewDataErrorEventArgs e )
        {

            e.Cancel = true;
            MessageBox.Show( "包装数、基本数、付数只能输入大于0的整数!" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            dgvPrescription.CancelEdit( );
            dgvPrescription.CurrentCell = dgvPrescription[e.ColumnIndex , e.RowIndex];
            dgvPrescription.Focus( );
        }

        void dgvPrescription_DataGridViewCellPressEnterKey( object sender , int colIndex , int rowIndex , ref bool jumpStop )
        {
            if ( Convert.ToInt32( dgvPrescription[COL_SUB_TOTAL_FLAG.Name , rowIndex].Value ) == 1 )
                return;

            if ( rowIndex == dgvPrescription.Rows.Count - 1 )
            {
                //如果是最后一行
                if ( colIndex == dgvPrescription.Columns[COL_BASE_NUM.Name].Index )
                {
                    bool isHerbalMedical;
                    bool isDrugRow = controller.IsDurgDetail( rowIndex , out isHerbalMedical );
                    if ( isHerbalMedical )
                    {
                        //如果是基本数列,并且是中草药第一行，跳转到付数
                        jumpStop = true;
                        dgvPrescription.CurrentCell = dgvPrescription[COL_PRES_DOSAGE.Name , rowIndex];
                    }
                    else
                    {
                        //增加一行
                        if ( controller.AllowAddEmptyPrescriptionDetail( rowIndex ) )
                        {
                            controller.AddEmptyPrescriptionDetail( dgvPrescription.Rows.Count );
                            //设置录入焦点
                            jumpStop = true;
                            dgvPrescription.CurrentCell = dgvPrescription[COL_KEYWORD.Name , rowIndex + 1];
                        }
                    }
                    return;
                }

                if ( colIndex == dgvPrescription.Columns[COL_PRES_DOSAGE.Name].Index )
                {
                    //增加一行
                    if ( controller.AllowAddEmptyPrescriptionDetail( rowIndex ) )
                    {
                        controller.AddEmptyPrescriptionDetail( dgvPrescription.Rows.Count );
                        //设置录入焦点
                        jumpStop = true;
                        dgvPrescription.CurrentCell = dgvPrescription[COL_KEYWORD.Name , rowIndex + 1];
                    }
                }
                else if ( colIndex == dgvPrescription.Columns[COL_KEYWORD.Name].Index )
                {
                    //如果是检索列
                    if ( Convert.ToInt32( dgvPrescription[COL_ITEM_ID.Name , rowIndex].Value ) == 0 )
                    {
                        jumpStop = true;
                    }
                }
            }
        }

        void dgvPrescription_SelectCardRowSelected( object SelectedValue , ref bool stop , ref int customNextColumnIndex )
        {
            DataRow dr = (DataRow)SelectedValue;
            //判断当前数据能否添加到处方中
            string message = "";
            if ( controller.ValidateRestrictBeforeFillSelectedRowData( dr , dgvPrescription.CurrentCell.RowIndex , out message ) )
            {
                //填充选择的数据到网格
                dgvPrescription.EndEdit( );
                controller.FillSelectedRowData( dr , dgvPrescription.CurrentCell.RowIndex );
                SetColumnEditStatusAfterSelectionCardSelected( dgvPrescription.CurrentCell.RowIndex );
            }
            else
            {
                stop = true;
                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }

            dgvPrescription.Refresh( );
        }

        void dgvPrescription_Paint( object sender , PaintEventArgs e )
        {
            using ( Graphics g = e.Graphics )
            {
                for ( int i = 0 ; i < dgvPrescription.Rows.Count ; i++ )
                {
                    int subtotal_flag = Convert.ToInt32( dgvPrescription[COL_SUB_TOTAL_FLAG.Name , i].Value );
                    int modify_flag = Convert.IsDBNull(dgvPrescription[COL_MODIFY_FLAG.Name , i].Value) ? 0 : Convert.ToInt32( dgvPrescription[COL_MODIFY_FLAG.Name , i].Value );

                    if ( subtotal_flag == 0 )
                    {
                        int doc_pres_flag = Convert.ToInt32( dgvPrescription[COL_DOC_PRESMASTER_ID.Name , i].Value );
                        if ( doc_pres_flag != 0 )
                        {
                            dgvPrescription.SetRowColor( i , Color.Gray , Color.White );
                        }
                        else
                        {
                            if ( modify_flag == 1 )
                            {
                                dgvPrescription.SetRowColor( i , Color.DarkRed , true );
                            }
                        }
                    }
                    else
                    {
                        dgvPrescription.SetRowColor( i , Color.Blue , Color.LightYellow );
                        dgvPrescription[COL_TOTAL_FEE.Name , i].Style.Font = new Font( "宋体" , 10F , FontStyle.Bold );
                        dgvPrescription[COL_EXEC_DEPT_NAME.Name , i].Style.Font = new Font( "宋体" , 10F , FontStyle.Bold );
                    }
                }
            }
        }

        void dgvPrescription_CurrentCellChanged( object sender , EventArgs e )
        {
            //控制网格读写状态
            if ( dgvPrescription.CurrentCell == null )
                return;

            int currentRowIndex = dgvPrescription.CurrentCell.RowIndex;
            int currentColumnIndex = dgvPrescription.CurrentCell.ColumnIndex;

            bool allowEdit = controller.AllowCurrentCellEdit( currentRowIndex , currentColumnIndex );
            dgvPrescription.Columns[currentColumnIndex].ReadOnly = ( allowEdit ? false : true );

            controller.SetPrescriptionDoctorInfo( currentRowIndex );
        }

        #endregion

        void plPatient_SearchingPatient( object sender , SearchingPatientEvent e )
        {
            frmPreviousInfo.Hide( );
            try
            {
                controller.SearchPatient( e.SearchPatientMode , e.InputKeyNo );
                controller.ReadPatientNotBalancePrescription( false );
                
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        void SetColumnEditStatusAfterSelectionCardSelected( int rowIndex )
        {
            bool edit = false;
            edit = controller.AllowCurrentCellEdit( rowIndex , dgvPrescription.Columns[COL_PACK_NUM.Name].Index );
            dgvPrescription.Columns[COL_PACK_NUM.Name].ReadOnly = edit ? false : true;

            edit = controller.AllowCurrentCellEdit( rowIndex , dgvPrescription.Columns[COL_BASE_NUM.Name].Index );
            dgvPrescription.Columns[COL_BASE_NUM.Name].ReadOnly = edit ? false : true;

            edit = controller.AllowCurrentCellEdit( rowIndex , dgvPrescription.Columns[COL_PRES_DOSAGE.Name].Index );
            dgvPrescription.Columns[COL_PRES_DOSAGE.Name].ReadOnly = edit ? false : true;
        }

        #region IFrmBudgeBalance 成员

        public IOutPatient Patient
        {
            get
            {
                return plPatient.OutPatient;
            }
            set
            {
                plPatient.OutPatient = value;
            }
        }

        public DataTable Prescriptions
        {
            get
            {
                return (DataTable)dgvPrescription.DataSource;
            }
            set
            {
                dgvPrescription.DataSource = value;
            }
        }

        public DataTable GetPrescDataStruct()
        {
            DataTable tbStruct = new DataTable( );
            for ( int i = 0 ; i < dgvPrescription.Columns.Count ; i++ )
            {
                DataColumn col = new DataColumn( );
                col.ColumnName = dgvPrescription.Columns[i].Name;
                if ( dgvPrescription.Columns[i].Name == COL_RELATION_NUM.Name || dgvPrescription.Columns[i].Name == COL_BUY_PRICE.Name
                    || dgvPrescription.Columns[i].Name == COL_SELL_PRICE.Name || dgvPrescription.Columns[i].Name == COL_TOTAL_FEE.Name )
                {
                    col.DataType = Type.GetType( "System.Decimal" );
                }
                else if ( dgvPrescription.Columns[i].Name == COL_BASE_NUM.Name || dgvPrescription.Columns[i].Name == COL_COMPLEX_ID.Name
                    || dgvPrescription.Columns[i].Name == COL_DOC_PRESMASTER_ID.Name || dgvPrescription.Columns[i].Name == COL_ITEM_ID.Name
                    || dgvPrescription.Columns[i].Name == COL_MODIFY_FLAG.Name || dgvPrescription.Columns[i].Name == COL_PACK_NUM.Name
                    || dgvPrescription.Columns[i].Name == COL_PRES_DOSAGE.Name || dgvPrescription.Columns[i].Name == COL_PRESC_AMBIT.Name
                    || dgvPrescription.Columns[i].Name == COL_PRESDETAIL_ID.Name || dgvPrescription.Columns[i].Name == COL_PRESMASTER_ID.Name
                    || dgvPrescription.Columns[i].Name == COL_SUB_TOTAL_FLAG.Name || dgvPrescription.Columns[i].Name == COL_DOC_PRESDETAIL_ID.Name )
                {
                    col.DataType = Type.GetType( "System.Int32" );
                }
                else if ( dgvPrescription.Columns[i].Name == COL_SELECTED_FLAG.Name )
                {
                    col.DataType = Type.GetType( "System.Boolean" );
                }
                else
                {
                    col.DataType = Type.GetType( "System.String" );
                }
                
                tbStruct.Columns.Add( col );
            }
            return tbStruct;
        }
        
        public int FormAction
        {
            get
            {
                return formAction;
            }

        }
        
        public int CurrentEmployeeId
        {
            get
            {
                return Convert.ToInt32(_currentUser.EmployeeID);
            }
        }

        public int CurrentLoginDeptId
        {
            get
            {
                return Convert.ToInt32( _currentDept.DeptID );
            }
        }
  
        public int PrescDoctorId
        {
            get
            {
                if ( txtPresDoctor.MemberValue == null )
                    return 0;
                else
                    return Convert.ToInt32( txtPresDoctor.MemberValue );
            }
            set
            {
                txtPresDoctor.MemberValue = value;
            }
        }

        public int DoctorDeptId
        {
            get
            {
                if ( txtDocDept.MemberValue == null )
                    return 0;
                else
                    return Convert.ToInt32( txtDocDept.MemberValue );
            }
            set
            {
                txtDocDept.MemberValue = value;
            }
        }

        public string InvoicePerfChar
        {
            get
            {
                return lblPerfChar.Text;
            }
            set
            {
                lblPerfChar.Text = value;
            }
        }

        public string CurrentInvoiceNo
        {
            get
            {
                return lblCurrentInvoiceNo.Text;
            }
            set
            {
                lblCurrentInvoiceNo.Text = value;
            }
        }

        public decimal AllPrescriptionTotalFee
        {
            get
            {
                if ( lblTotalFee.Text.Trim( ) == "" )
                    return 0;
                else
                    return Convert.ToDecimal( lblTotalFee.Text );
            }
            set
            {
                lblTotalFee.Text = value.ToString("#0.#0");
            }
        }
        #endregion

        private void btnSavePrescription_Click( object sender , EventArgs e )
        {
            string message;
            if ( !controller.AllowBeginPrescriptionHandle( out message ) )
            {
                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                return;
            }
            //结束界面编辑模式
            bool bOk = dgvPrescription.EndEdit( );
            if ( bOk )
            {
                //结束未结束的处方
                controller.EndPrescription( );
                //保存处方
                if ( controller.SavePrescription( ) )
                {
                    if ( dgvPrescription.Rows.Count > 0 )
                        dgvPrescription.CurrentCell = dgvPrescription[COL_KEYWORD.Name , dgvPrescription.Rows.Count - 1];
                }
            }
        }

        private void btnNewPrescription_Click( object sender , EventArgs e )
        {
            string message;
            if ( !controller.AllowBeginPrescriptionHandle( out message ) )
            {
                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                return;
            }
            //结束界面编辑模式
            bool bOk = dgvPrescription.EndEdit( );
            if ( bOk )
            {
                dgvPrescription.CurrentCellChanged -= dgvPrescription_CurrentCellChanged;
                //新开处方前结束原来未结束的处方
                controller.EndPrescription( );
                //增加空的处方明细行供录入
                controller.AddEmptyPrescriptionDetail( dgvPrescription.Rows.Count );
                //重新绑定事件
                dgvPrescription.CurrentCellChanged += new EventHandler(dgvPrescription_CurrentCellChanged);
                //定位焦点
                dgvPrescription.CurrentCell = dgvPrescription[COL_KEYWORD.Name , dgvPrescription.Rows.Count - 1];

                

            }
            dgvPrescription.Focus( );
        }

        private void btnInsertRow_Click( object sender , EventArgs e )
        {
            string message;
            if ( !controller.AllowBeginPrescriptionHandle( out message ) )
            {
                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                return;
            }
            if ( controller.AllowAddEmptyPrescriptionDetail( dgvPrescription.CurrentCell.RowIndex ) )
            {
                controller.AddEmptyPrescriptionDetail( dgvPrescription.CurrentCell.RowIndex + 1 );
                dgvPrescription.CurrentCell = dgvPrescription[COL_KEYWORD.Name , dgvPrescription.CurrentCell.RowIndex + 1];
            }
        }

        private void btnDeleteRow_Click( object sender , EventArgs e )
        {
            string message;
            if ( !controller.AllowBeginPrescriptionHandle( out message ) )
            {
                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                return;
            }
            //删除处方明细前判断
            if ( controller.AllowDeletePrescriptionDetail( dgvPrescription.CurrentCell.RowIndex , out message ) )
            {
                //删除处方明细
                dgvPrescription.CurrentCellChanged -= dgvPrescription_CurrentCellChanged;
                controller.DeletePrescriptionDetail( dgvPrescription.CurrentCell.RowIndex );
                controller.CalculateAllPrescriptionFee( );
                dgvPrescription.CurrentCellChanged += new EventHandler( dgvPrescription_CurrentCellChanged );
            }
            else
            {
                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }
        }

        private void btnDeletePrescription_Click( object sender , EventArgs e )
        {
            string message;
            if ( !controller.AllowBeginPrescriptionHandle( out message ) )
            {
                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                return;
            }
            //删除处方明细前判断
            if ( controller.AllowDeletePrescriptionDetail( dgvPrescription.CurrentCell.RowIndex , out message ) )
            {
                //删除处方
                dgvPrescription.CurrentCellChanged -= dgvPrescription_CurrentCellChanged;
                controller.DeletePrescription( dgvPrescription.CurrentCell.RowIndex );
                controller.CalculateAllPrescriptionFee( );
                dgvPrescription.CurrentCellChanged+=new EventHandler(dgvPrescription_CurrentCellChanged);
            }
            else
            {
                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }
        }

        private void btnBalance_Click( object sender , EventArgs e )
        {
            string message;
            if ( dgvPrescription.EndEdit( ) )
            {
                if ( !controller.AllowBeginPrescriptionHandle( out message ) )
                {
                    MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                    return;
                }
                try
                {
                    controller.EndPrescription( );
                    controller.AfterSavedEvent -= controller_AfterSavedEvent;
                    if ( controller.SavePrescription( ) )
                    {
                        controller.Budget( );
                    }
                }
                catch ( Exception err )
                {
                    MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                }
                finally
                {
                    controller.AfterSavedEvent += new OnAfterSavedEventHandle( controller_AfterSavedEvent );
                }
            }
        }

        private void btnRefreshPrescription_Click( object sender , EventArgs e )
        {
            string message;
            if ( !controller.AllowBeginPrescriptionHandle( out message ) )
            {
                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                return;
            }
            //重新读取病人处方
            try
            {
                controller.ReadPatientNotBalancePrescription( false );
                tlbFunBar.Focus( );
                btnNewPrescription.Select( );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnNewPatient_Click( object sender , EventArgs e )
        {
            frmPreviousInfo.Hide( );
            FrmOutPatient fPatient = new FrmOutPatient( true );
            if ( fPatient.ShowDialog( ) == DialogResult.OK )
            {
                plPatient.OutPatient = fPatient.Result;
                if ( plPatient.OutPatient.CureDoctor != null &&
                    plPatient.OutPatient.CureDoctor.Value.Code != null )
                {
                    txtPresDoctor.MemberValue = Convert.ToInt32( plPatient.OutPatient.CureDoctor.Value.Code );
                    if ( plPatient.OutPatient.CureDepartment != null &&
                        plPatient.OutPatient.CureDepartment.Value.Code != null )
                    {
                        txtDocDept.MemberValue = Convert.ToInt32( plPatient.OutPatient.CureDepartment.Value.Code );
                        tlbFunBar.Focus( );
                        btnNewPrescription.Select( );
                    }
                    else
                    {
                        txtDocDept.Focus( );
                    }
                }
                else
                {
                    txtPresDoctor.Focus( );
                }
            }
        }

        private void btnRefreshBaseData_Click( object sender , EventArgs e )
        {
            try
            {
                Cursor = PublicStaticFun.WaitCursor( );
                controller.ReloadData( );
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnSearchPatient_Click( object sender , EventArgs e )
        {
            FrmOutPatient fPatient = new FrmOutPatient( false );
            frmPreviousInfo.Hide( );
            if ( fPatient.ShowDialog( ) == DialogResult.OK )
            {
                plPatient.OutPatient = fPatient.Result;
                if ( plPatient.OutPatient.CureDoctor != null &&
                    plPatient.OutPatient.CureDoctor.Value.Code != null )
                {
                    txtPresDoctor.MemberValue = Convert.ToInt32( plPatient.OutPatient.CureDoctor.Value.Code );
                    if ( plPatient.OutPatient.CureDepartment != null &&
                        plPatient.OutPatient.CureDepartment.Value.Code != null )
                    {
                        txtDocDept.MemberValue = Convert.ToInt32( plPatient.OutPatient.CureDepartment.Value.Code );
                        tlbFunBar.Focus( );
                        btnNewPrescription.Select( );
                    }
                    else
                    {
                        txtDocDept.Focus( );
                    }
                }
                else
                {
                    txtPresDoctor.Focus( );
                }
                controller.ClearPrescriptions( );
                controller.ReadPatientNotBalancePrescription( false );
            }
        }

        private void btnAdjutInvoiceNo_Click( object sender , EventArgs e )
        {
            FrmAdjustInvoiceNo fAdjust = new FrmAdjustInvoiceNo( Convert.ToInt32(_currentUser.EmployeeID) , HIS.MZ_BLL.OPDBillKind.门诊收费发票 );
            fAdjust.ShowDialog( );
            controller.LoadInvoiceInfo( );
        }

        private void btnReturnInvoice_Click( object sender , EventArgs e )
        {
            FrmUnCharge frmUncharge = new FrmUnCharge( Convert.ToInt32( _currentUser.EmployeeID ) );
            if ( frmUncharge.ShowDialog( ) == DialogResult.OK )
            {
                controller.LoadInvoiceInfo( );
            }
        }

        protected override void OnClosing( CancelEventArgs e )
        {
            frmPreviousInfo.Close( );
            base.OnClosing( e );
        }
    }
}
