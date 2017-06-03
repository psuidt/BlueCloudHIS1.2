namespace HIS_MZManager.Query
{
    partial class FrmPatientFeeQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmPatientFeeQuery ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkInvoiceNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPatName = new System.Windows.Forms.TextBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.txtMediCardNo = new System.Windows.Forms.TextBox();
            this.txtVisitNo = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPatList = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.COL_VISITNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_PATNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_AGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_PATTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_DEPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_CURDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_PATLISTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInvoiceList = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.dgvInvoiceItem = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.COL_MZFP_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_MZFP_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvPresc = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PresID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisitNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Standard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pack_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pack_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Base_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PresAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECORD_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRUG_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip( this.components );
            this.cboInvoiceType = new System.Windows.Forms.ComboBox();
            this.chkInvoiceType = new System.Windows.Forms.CheckBox();
            this.chkPatName = new System.Windows.Forms.CheckBox();
            this.chkMediCard = new System.Windows.Forms.CheckBox();
            this.chkVisitNo = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkPrintSingle = new System.Windows.Forms.CheckBox();
            this.chkPrintSub = new System.Windows.Forms.CheckBox();
            this.COL_INVOICENO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_TOTAL_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_MONEY_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_POS_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_INSUR_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SELF_TALLY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_FAVOR_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_CHARGEDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvPatList ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInvoiceList ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInvoiceItem ) ).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvPresc ) ).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add( this.chkPrintSub );
            this.plBaseToolbar.Controls.Add( this.chkPrintSingle );
            this.plBaseToolbar.Controls.Add( this.btnPrint );
            this.plBaseToolbar.Controls.Add( this.chkVisitNo );
            this.plBaseToolbar.Controls.Add( this.chkMediCard );
            this.plBaseToolbar.Controls.Add( this.chkPatName );
            this.plBaseToolbar.Controls.Add( this.chkInvoiceType );
            this.plBaseToolbar.Controls.Add( this.cboInvoiceType );
            this.plBaseToolbar.Controls.Add( this.btnClose );
            this.plBaseToolbar.Controls.Add( this.btnReset );
            this.plBaseToolbar.Controls.Add( this.btnFind );
            this.plBaseToolbar.Controls.Add( this.txtInvoiceNo );
            this.plBaseToolbar.Controls.Add( this.txtVisitNo );
            this.plBaseToolbar.Controls.Add( this.txtMediCardNo );
            this.plBaseToolbar.Controls.Add( this.dtpTo );
            this.plBaseToolbar.Controls.Add( this.dtpFrom );
            this.plBaseToolbar.Controls.Add( this.txtPatName );
            this.plBaseToolbar.Controls.Add( this.label3 );
            this.plBaseToolbar.Controls.Add( this.chkInvoiceNo );
            this.plBaseToolbar.Size = new System.Drawing.Size( 964, 62 );
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "baseImageList.ImageStream" ) ) );
            this.baseImageList.Images.SetKeyName( 0, "table_delete.gif" );
            this.baseImageList.Images.SetKeyName( 1, "search_big.GIF" );
            this.baseImageList.Images.SetKeyName( 2, "Save.GIF" );
            this.baseImageList.Images.SetKeyName( 3, "Print.GIF" );
            this.baseImageList.Images.SetKeyName( 4, "page_user_dark.gif" );
            this.baseImageList.Images.SetKeyName( 5, "page_refresh.gif" );
            this.baseImageList.Images.SetKeyName( 6, "page_key.gif" );
            this.baseImageList.Images.SetKeyName( 7, "page_edit.gif" );
            this.baseImageList.Images.SetKeyName( 8, "page_cross.gif" );
            this.baseImageList.Images.SetKeyName( 9, "list_users.gif" );
            this.baseImageList.Images.SetKeyName( 10, "icon_package_get.gif" );
            this.baseImageList.Images.SetKeyName( 11, "icon_network.gif" );
            this.baseImageList.Images.SetKeyName( 12, "icon_history.gif" );
            this.baseImageList.Images.SetKeyName( 13, "icon_accept.gif" );
            this.baseImageList.Images.SetKeyName( 14, "folder_page.gif" );
            this.baseImageList.Images.SetKeyName( 15, "folder_new.gif" );
            this.baseImageList.Images.SetKeyName( 16, "Exit.GIF" );
            this.baseImageList.Images.SetKeyName( 17, "Delete.GIF" );
            this.baseImageList.Images.SetKeyName( 18, "copy.gif" );
            this.baseImageList.Images.SetKeyName( 19, "action_stop.gif" );
            this.baseImageList.Images.SetKeyName( 20, "action_refresh.gif" );
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point( 0, 480 );
            this.plBaseStatus.Size = new System.Drawing.Size( 964, 0 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.splitContainer1 );
            this.plBaseWorkArea.Controls.Add( this.groupBox1 );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0, 96 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 964, 384 );
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size( 964, 34 );
            // 
            // chkInvoiceNo
            // 
            this.chkInvoiceNo.AutoSize = true;
            this.chkInvoiceNo.Location = new System.Drawing.Point( 376, 9 );
            this.chkInvoiceNo.Name = "chkInvoiceNo";
            this.chkInvoiceNo.Size = new System.Drawing.Size( 53, 12 );
            this.chkInvoiceNo.TabIndex = 1;
            this.chkInvoiceNo.Text = "票据号码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 541, 9 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 53, 12 );
            this.label3.TabIndex = 2;
            this.label3.Text = "就诊日期";
            // 
            // txtPatName
            // 
            this.txtPatName.Enabled = false;
            this.txtPatName.Location = new System.Drawing.Point( 86, 6 );
            this.txtPatName.MaxLength = 10;
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.Size = new System.Drawing.Size( 100, 21 );
            this.txtPatName.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Checked = false;
            this.dtpFrom.Location = new System.Drawing.Point( 600, 6 );
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size( 127, 21 );
            this.dtpFrom.TabIndex = 6;
            // 
            // dtpTo
            // 
            this.dtpTo.Checked = false;
            this.dtpTo.Location = new System.Drawing.Point( 733, 6 );
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size( 124, 21 );
            this.dtpTo.TabIndex = 7;
            // 
            // txtMediCardNo
            // 
            this.txtMediCardNo.Enabled = false;
            this.txtMediCardNo.Location = new System.Drawing.Point( 86, 31 );
            this.txtMediCardNo.MaxLength = 20;
            this.txtMediCardNo.Name = "txtMediCardNo";
            this.txtMediCardNo.Size = new System.Drawing.Size( 100, 21 );
            this.txtMediCardNo.TabIndex = 9;
            this.txtMediCardNo.Text = "<未开放的功能>";
            // 
            // txtVisitNo
            // 
            this.txtVisitNo.Enabled = false;
            this.txtVisitNo.Location = new System.Drawing.Point( 270, 31 );
            this.txtVisitNo.MaxLength = 20;
            this.txtVisitNo.Name = "txtVisitNo";
            this.txtVisitNo.Size = new System.Drawing.Size( 100, 21 );
            this.txtVisitNo.TabIndex = 11;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point( 435, 5 );
            this.txtInvoiceNo.MaxLength = 15;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size( 100, 21 );
            this.txtInvoiceNo.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.dgvPatList );
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point( 0, 0 );
            this.groupBox1.Margin = new System.Windows.Forms.Padding( 1 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 964, 123 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询结果";
            // 
            // dgvPatList
            // 
            this.dgvPatList.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvPatList.AllowSortWhenClickColumnHeader = false;
            this.dgvPatList.AllowUserToAddRows = false;
            this.dgvPatList.AllowUserToDeleteRows = false;
            this.dgvPatList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle21.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvPatList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPatList.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_VISITNO,
            this.COL_PATNAME,
            this.COL_SEX,
            this.COL_AGE,
            this.COL_PATTYPE,
            this.COL_DOCTOR,
            this.COL_DEPT,
            this.COL_CURDATE,
            this.COL_PATLISTID} );
            this.dgvPatList.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvPatList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatList.EnableHeadersVisualStyles = false;
            this.dgvPatList.HideSelectionCardWhenCustomInput = false;
            this.dgvPatList.Location = new System.Drawing.Point( 3, 17 );
            this.dgvPatList.MultiSelect = false;
            this.dgvPatList.Name = "dgvPatList";
            this.dgvPatList.ReadOnly = true;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle22.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatList.RowHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvPatList.RowTemplate.Height = 23;
            this.dgvPatList.SelectionCards = null;
            this.dgvPatList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatList.Size = new System.Drawing.Size( 958, 103 );
            this.dgvPatList.TabIndex = 0;
            this.dgvPatList.UseGradientBackgroundColor = false;
            this.dgvPatList.CurrentCellChanged += new System.EventHandler( this.dgvPatList_CurrentCellChanged );
            // 
            // COL_VISITNO
            // 
            this.COL_VISITNO.Frozen = true;
            this.COL_VISITNO.HeaderText = "门诊号";
            this.COL_VISITNO.Name = "COL_VISITNO";
            this.COL_VISITNO.ReadOnly = true;
            this.COL_VISITNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_PATNAME
            // 
            this.COL_PATNAME.Frozen = true;
            this.COL_PATNAME.HeaderText = "病人姓名";
            this.COL_PATNAME.Name = "COL_PATNAME";
            this.COL_PATNAME.ReadOnly = true;
            this.COL_PATNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_SEX
            // 
            this.COL_SEX.HeaderText = "性别";
            this.COL_SEX.Name = "COL_SEX";
            this.COL_SEX.ReadOnly = true;
            this.COL_SEX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_AGE
            // 
            this.COL_AGE.HeaderText = "年龄";
            this.COL_AGE.Name = "COL_AGE";
            this.COL_AGE.ReadOnly = true;
            this.COL_AGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_AGE.Width = 60;
            // 
            // COL_PATTYPE
            // 
            this.COL_PATTYPE.HeaderText = "病人类型";
            this.COL_PATTYPE.Name = "COL_PATTYPE";
            this.COL_PATTYPE.ReadOnly = true;
            this.COL_PATTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_DOCTOR
            // 
            this.COL_DOCTOR.HeaderText = "接诊医生";
            this.COL_DOCTOR.Name = "COL_DOCTOR";
            this.COL_DOCTOR.ReadOnly = true;
            this.COL_DOCTOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_DEPT
            // 
            this.COL_DEPT.HeaderText = "接诊科室";
            this.COL_DEPT.Name = "COL_DEPT";
            this.COL_DEPT.ReadOnly = true;
            this.COL_DEPT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_CURDATE
            // 
            this.COL_CURDATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.COL_CURDATE.HeaderText = "就诊时间";
            this.COL_CURDATE.Name = "COL_CURDATE";
            this.COL_CURDATE.ReadOnly = true;
            this.COL_CURDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_PATLISTID
            // 
            this.COL_PATLISTID.HeaderText = "PATLISTID";
            this.COL_PATLISTID.Name = "COL_PATLISTID";
            this.COL_PATLISTID.ReadOnly = true;
            this.COL_PATLISTID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_PATLISTID.Visible = false;
            // 
            // dgvInvoiceList
            // 
            this.dgvInvoiceList.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvInvoiceList.AllowSortWhenClickColumnHeader = false;
            this.dgvInvoiceList.AllowUserToAddRows = false;
            this.dgvInvoiceList.AllowUserToDeleteRows = false;
            this.dgvInvoiceList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle4.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInvoiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvoiceList.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_INVOICENO,
            this.COL_TOTAL_FEE,
            this.COL_MONEY_FEE,
            this.COL_POS_FEE,
            this.COL_INSUR_FEE,
            this.COL_SELF_TALLY,
            this.COL_FAVOR_FEE,
            this.COL_CHARGEDATE} );
            this.dgvInvoiceList.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceList.EnableHeadersVisualStyles = false;
            this.dgvInvoiceList.HideSelectionCardWhenCustomInput = false;
            this.dgvInvoiceList.Location = new System.Drawing.Point( 3, 17 );
            this.dgvInvoiceList.MultiSelect = false;
            this.dgvInvoiceList.Name = "dgvInvoiceList";
            this.dgvInvoiceList.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle11.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvInvoiceList.RowHeadersWidth = 20;
            this.dgvInvoiceList.RowTemplate.Height = 23;
            this.dgvInvoiceList.SelectionCards = null;
            this.dgvInvoiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceList.Size = new System.Drawing.Size( 337, 107 );
            this.dgvInvoiceList.TabIndex = 1;
            this.dgvInvoiceList.UseGradientBackgroundColor = false;
            this.dgvInvoiceList.CurrentCellChanged += new System.EventHandler( this.dgvInvoiceList_CurrentCellChanged );
            // 
            // dgvInvoiceItem
            // 
            this.dgvInvoiceItem.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvInvoiceItem.AllowSortWhenClickColumnHeader = false;
            this.dgvInvoiceItem.AllowUserToAddRows = false;
            this.dgvInvoiceItem.AllowUserToDeleteRows = false;
            this.dgvInvoiceItem.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoiceItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvoiceItem.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_MZFP_NAME,
            this.COL_MZFP_FEE} );
            this.dgvInvoiceItem.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvInvoiceItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceItem.EnableHeadersVisualStyles = false;
            this.dgvInvoiceItem.HideSelectionCardWhenCustomInput = false;
            this.dgvInvoiceItem.Location = new System.Drawing.Point( 3, 17 );
            this.dgvInvoiceItem.Name = "dgvInvoiceItem";
            this.dgvInvoiceItem.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInvoiceItem.RowHeadersWidth = 20;
            this.dgvInvoiceItem.RowTemplate.Height = 23;
            this.dgvInvoiceItem.SelectionCards = null;
            this.dgvInvoiceItem.Size = new System.Drawing.Size( 337, 111 );
            this.dgvInvoiceItem.TabIndex = 1;
            this.dgvInvoiceItem.UseGradientBackgroundColor = false;
            // 
            // COL_MZFP_NAME
            // 
            this.COL_MZFP_NAME.HeaderText = "发票科目";
            this.COL_MZFP_NAME.Name = "COL_MZFP_NAME";
            this.COL_MZFP_NAME.ReadOnly = true;
            this.COL_MZFP_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_MZFP_NAME.Width = 120;
            // 
            // COL_MZFP_FEE
            // 
            this.COL_MZFP_FEE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.COL_MZFP_FEE.DefaultCellStyle = dataGridViewCellStyle2;
            this.COL_MZFP_FEE.HeaderText = "金额";
            this.COL_MZFP_FEE.Name = "COL_MZFP_FEE";
            this.COL_MZFP_FEE.ReadOnly = true;
            this.COL_MZFP_FEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnFind.Location = new System.Drawing.Point( 439, 31 );
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size( 75, 23 );
            this.btnFind.TabIndex = 14;
            this.btnFind.Text = "查找(&F)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler( this.btnFind_Click );
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnReset.Location = new System.Drawing.Point( 520, 31 );
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size( 75, 23 );
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "重置(&R)";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler( this.btnReset_Click );
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnClose.Location = new System.Drawing.Point( 886, 31 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 23 );
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0, 123 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.groupBox3 );
            this.splitContainer1.Panel1.Controls.Add( this.splitter1 );
            this.splitContainer1.Panel1.Controls.Add( this.groupBox2 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.groupBox4 );
            this.splitContainer1.Size = new System.Drawing.Size( 964, 261 );
            this.splitContainer1.SplitterDistance = 343;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add( this.dgvInvoiceItem );
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point( 0, 130 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 343, 131 );
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "科目";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point( 0, 127 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 343, 3 );
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.dgvInvoiceList );
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point( 0, 0 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 343, 127 );
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "收据";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add( this.dgvPresc );
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point( 0, 0 );
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size( 619, 261 );
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "明细";
            // 
            // dgvPresc
            // 
            this.dgvPresc.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvPresc.AllowSortWhenClickColumnHeader = false;
            this.dgvPresc.AllowUserToAddRows = false;
            this.dgvPresc.AllowUserToDeleteRows = false;
            this.dgvPresc.AllowUserToResizeRows = false;
            this.dgvPresc.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle12.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPresc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPresc.ColumnHeadersHeight = 38;
            this.dgvPresc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPresc.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.PresID,
            this.VisitNo,
            this.PatName,
            this.InvoiceNo,
            this.DoctorName,
            this.Item_Name,
            this.Standard,
            this.Price,
            this.Pack_Unit,
            this.Pack_Num,
            this.Base_Num,
            this.PresAmount,
            this.TotalCost,
            this.RECORD_FLAG,
            this.DRUG_FLAG} );
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle19.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPresc.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgvPresc.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvPresc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPresc.EnableHeadersVisualStyles = false;
            this.dgvPresc.HideSelectionCardWhenCustomInput = false;
            this.dgvPresc.Location = new System.Drawing.Point( 3, 17 );
            this.dgvPresc.MultiSelect = false;
            this.dgvPresc.Name = "dgvPresc";
            this.dgvPresc.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle20.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPresc.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvPresc.RowHeadersWidth = 30;
            this.dgvPresc.RowTemplate.Height = 20;
            this.dgvPresc.SelectionCards = null;
            this.dgvPresc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPresc.Size = new System.Drawing.Size( 613, 241 );
            this.dgvPresc.TabIndex = 1;
            this.dgvPresc.UseGradientBackgroundColor = false;
            // 
            // NO
            // 
            this.NO.DataPropertyName = "NO";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NO.DefaultCellStyle = dataGridViewCellStyle13;
            this.NO.HeaderText = "序";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NO.Width = 30;
            // 
            // PresID
            // 
            this.PresID.HeaderText = "处方号";
            this.PresID.Name = "PresID";
            this.PresID.ReadOnly = true;
            this.PresID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PresID.Visible = false;
            this.PresID.Width = 50;
            // 
            // VisitNo
            // 
            this.VisitNo.DataPropertyName = "VisitNo";
            this.VisitNo.HeaderText = "就诊号";
            this.VisitNo.Name = "VisitNo";
            this.VisitNo.ReadOnly = true;
            this.VisitNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VisitNo.Visible = false;
            // 
            // PatName
            // 
            this.PatName.DataPropertyName = "PatName";
            this.PatName.HeaderText = "病人姓名";
            this.PatName.Name = "PatName";
            this.PatName.ReadOnly = true;
            this.PatName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PatName.Visible = false;
            this.PatName.Width = 75;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.DataPropertyName = "InvoiceNo";
            this.InvoiceNo.HeaderText = "发票号";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            this.InvoiceNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvoiceNo.Visible = false;
            this.InvoiceNo.Width = 75;
            // 
            // DoctorName
            // 
            this.DoctorName.HeaderText = "医生";
            this.DoctorName.Name = "DoctorName";
            this.DoctorName.ReadOnly = true;
            this.DoctorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DoctorName.Visible = false;
            this.DoctorName.Width = 60;
            // 
            // Item_Name
            // 
            this.Item_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item_Name.DataPropertyName = "Item_Name";
            this.Item_Name.HeaderText = "药品、项目名称";
            this.Item_Name.Name = "Item_Name";
            this.Item_Name.ReadOnly = true;
            this.Item_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Standard
            // 
            this.Standard.DataPropertyName = "Standard";
            this.Standard.HeaderText = "规格";
            this.Standard.Name = "Standard";
            this.Standard.ReadOnly = true;
            this.Standard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "#0.##0";
            this.Price.DefaultCellStyle = dataGridViewCellStyle14;
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Price.Width = 75;
            // 
            // Pack_Unit
            // 
            this.Pack_Unit.DataPropertyName = "Pack_Unit";
            this.Pack_Unit.HeaderText = "包装单位";
            this.Pack_Unit.Name = "Pack_Unit";
            this.Pack_Unit.ReadOnly = true;
            this.Pack_Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Pack_Unit.Width = 45;
            // 
            // Pack_Num
            // 
            this.Pack_Num.DataPropertyName = "Pack_Num";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "#0";
            this.Pack_Num.DefaultCellStyle = dataGridViewCellStyle15;
            this.Pack_Num.HeaderText = "包装数";
            this.Pack_Num.Name = "Pack_Num";
            this.Pack_Num.ReadOnly = true;
            this.Pack_Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Pack_Num.Width = 42;
            // 
            // Base_Num
            // 
            this.Base_Num.DataPropertyName = "Base_Num";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "#0";
            this.Base_Num.DefaultCellStyle = dataGridViewCellStyle16;
            this.Base_Num.HeaderText = "基本数";
            this.Base_Num.Name = "Base_Num";
            this.Base_Num.ReadOnly = true;
            this.Base_Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Base_Num.Width = 42;
            // 
            // PresAmount
            // 
            this.PresAmount.DataPropertyName = "PresAmount";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Format = "#0";
            this.PresAmount.DefaultCellStyle = dataGridViewCellStyle17;
            this.PresAmount.HeaderText = "付数";
            this.PresAmount.Name = "PresAmount";
            this.PresAmount.ReadOnly = true;
            this.PresAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PresAmount.Width = 30;
            // 
            // TotalCost
            // 
            this.TotalCost.DataPropertyName = "TotalCost";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "#0.#0";
            this.TotalCost.DefaultCellStyle = dataGridViewCellStyle18;
            this.TotalCost.HeaderText = "金额";
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            this.TotalCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalCost.Width = 70;
            // 
            // RECORD_FLAG
            // 
            this.RECORD_FLAG.DataPropertyName = "RECORD_FLAG";
            this.RECORD_FLAG.HeaderText = "收费";
            this.RECORD_FLAG.Name = "RECORD_FLAG";
            this.RECORD_FLAG.ReadOnly = true;
            this.RECORD_FLAG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RECORD_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RECORD_FLAG.Visible = false;
            this.RECORD_FLAG.Width = 30;
            // 
            // DRUG_FLAG
            // 
            this.DRUG_FLAG.DataPropertyName = "DRUG_FLAG";
            this.DRUG_FLAG.HeaderText = "发药";
            this.DRUG_FLAG.Name = "DRUG_FLAG";
            this.DRUG_FLAG.ReadOnly = true;
            this.DRUG_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DRUG_FLAG.Visible = false;
            this.DRUG_FLAG.Width = 30;
            // 
            // cboInvoiceType
            // 
            this.cboInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInvoiceType.FormattingEnabled = true;
            this.cboInvoiceType.Location = new System.Drawing.Point( 270, 6 );
            this.cboInvoiceType.Name = "cboInvoiceType";
            this.cboInvoiceType.Size = new System.Drawing.Size( 100, 20 );
            this.cboInvoiceType.TabIndex = 17;
            // 
            // chkInvoiceType
            // 
            this.chkInvoiceType.AutoSize = true;
            this.chkInvoiceType.Checked = true;
            this.chkInvoiceType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvoiceType.Location = new System.Drawing.Point( 192, 8 );
            this.chkInvoiceType.Name = "chkInvoiceType";
            this.chkInvoiceType.Size = new System.Drawing.Size( 72, 16 );
            this.chkInvoiceType.TabIndex = 18;
            this.chkInvoiceType.Text = "票据类型";
            this.chkInvoiceType.UseVisualStyleBackColor = true;
            this.chkInvoiceType.CheckedChanged += new System.EventHandler( this.chkInvoiceType_CheckedChanged );
            // 
            // chkPatName
            // 
            this.chkPatName.AutoSize = true;
            this.chkPatName.Location = new System.Drawing.Point( 11, 8 );
            this.chkPatName.Name = "chkPatName";
            this.chkPatName.Size = new System.Drawing.Size( 72, 16 );
            this.chkPatName.TabIndex = 19;
            this.chkPatName.Text = "病人姓名";
            this.chkPatName.UseVisualStyleBackColor = true;
            this.chkPatName.CheckedChanged += new System.EventHandler( this.chkPatName_CheckedChanged );
            // 
            // chkMediCard
            // 
            this.chkMediCard.AutoSize = true;
            this.chkMediCard.Enabled = false;
            this.chkMediCard.Location = new System.Drawing.Point( 12, 33 );
            this.chkMediCard.Name = "chkMediCard";
            this.chkMediCard.Size = new System.Drawing.Size( 72, 16 );
            this.chkMediCard.TabIndex = 20;
            this.chkMediCard.Text = "诊疗卡号";
            this.chkMediCard.UseVisualStyleBackColor = true;
            // 
            // chkVisitNo
            // 
            this.chkVisitNo.AutoSize = true;
            this.chkVisitNo.Location = new System.Drawing.Point( 192, 33 );
            this.chkVisitNo.Name = "chkVisitNo";
            this.chkVisitNo.Size = new System.Drawing.Size( 60, 16 );
            this.chkVisitNo.TabIndex = 21;
            this.chkVisitNo.Text = "门诊号";
            this.chkVisitNo.UseVisualStyleBackColor = true;
            this.chkVisitNo.CheckedChanged += new System.EventHandler( this.chkVisitNo_CheckedChanged );
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnPrint.Location = new System.Drawing.Point( 600, 31 );
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size( 168, 23 );
            this.btnPrint.TabIndex = 22;
            this.btnPrint.Text = "打印当前病人费用清单(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler( this.btnPrint_Click );
            // 
            // chkPrintSingle
            // 
            this.chkPrintSingle.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.chkPrintSingle.AutoSize = true;
            this.chkPrintSingle.Location = new System.Drawing.Point( 773, 28 );
            this.chkPrintSingle.Name = "chkPrintSingle";
            this.chkPrintSingle.Size = new System.Drawing.Size( 108, 16 );
            this.chkPrintSingle.TabIndex = 23;
            this.chkPrintSingle.Text = "按发票单独打印";
            this.chkPrintSingle.UseVisualStyleBackColor = true;
            // 
            // chkPrintSub
            // 
            this.chkPrintSub.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.chkPrintSub.AutoSize = true;
            this.chkPrintSub.Location = new System.Drawing.Point( 773, 45 );
            this.chkPrintSub.Name = "chkPrintSub";
            this.chkPrintSub.Size = new System.Drawing.Size( 108, 16 );
            this.chkPrintSub.TabIndex = 24;
            this.chkPrintSub.Text = "按处方张数打印";
            this.chkPrintSub.UseVisualStyleBackColor = true;
            // 
            // COL_INVOICENO
            // 
            this.COL_INVOICENO.Frozen = true;
            this.COL_INVOICENO.HeaderText = "收据号";
            this.COL_INVOICENO.Name = "COL_INVOICENO";
            this.COL_INVOICENO.ReadOnly = true;
            this.COL_INVOICENO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_TOTAL_FEE
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.COL_TOTAL_FEE.DefaultCellStyle = dataGridViewCellStyle5;
            this.COL_TOTAL_FEE.HeaderText = "总金额";
            this.COL_TOTAL_FEE.Name = "COL_TOTAL_FEE";
            this.COL_TOTAL_FEE.ReadOnly = true;
            this.COL_TOTAL_FEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_MONEY_FEE
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.COL_MONEY_FEE.DefaultCellStyle = dataGridViewCellStyle6;
            this.COL_MONEY_FEE.HeaderText = "现金";
            this.COL_MONEY_FEE.Name = "COL_MONEY_FEE";
            this.COL_MONEY_FEE.ReadOnly = true;
            this.COL_MONEY_FEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_POS_FEE
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.COL_POS_FEE.DefaultCellStyle = dataGridViewCellStyle7;
            this.COL_POS_FEE.HeaderText = "POS";
            this.COL_POS_FEE.Name = "COL_POS_FEE";
            this.COL_POS_FEE.ReadOnly = true;
            this.COL_POS_FEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_INSUR_FEE
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.COL_INSUR_FEE.DefaultCellStyle = dataGridViewCellStyle8;
            this.COL_INSUR_FEE.HeaderText = "医保记账";
            this.COL_INSUR_FEE.Name = "COL_INSUR_FEE";
            this.COL_INSUR_FEE.ReadOnly = true;
            this.COL_INSUR_FEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_SELF_TALLY
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.COL_SELF_TALLY.DefaultCellStyle = dataGridViewCellStyle9;
            this.COL_SELF_TALLY.HeaderText = "单位记账";
            this.COL_SELF_TALLY.Name = "COL_SELF_TALLY";
            this.COL_SELF_TALLY.ReadOnly = true;
            this.COL_SELF_TALLY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_FAVOR_FEE
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.COL_FAVOR_FEE.DefaultCellStyle = dataGridViewCellStyle10;
            this.COL_FAVOR_FEE.HeaderText = "优惠金额";
            this.COL_FAVOR_FEE.Name = "COL_FAVOR_FEE";
            this.COL_FAVOR_FEE.ReadOnly = true;
            this.COL_FAVOR_FEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_CHARGEDATE
            // 
            this.COL_CHARGEDATE.HeaderText = "收费时间";
            this.COL_CHARGEDATE.Name = "COL_CHARGEDATE";
            this.COL_CHARGEDATE.ReadOnly = true;
            this.COL_CHARGEDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmPatientFeeQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 964, 480 );
            this.Name = "FrmPatientFeeQuery";
            this.Text = "FrmPatientFeeQuery";
            this.Load += new System.EventHandler( this.FrmPatientFeeQuery_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout( false );
            this.groupBox1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvPatList ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInvoiceList ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInvoiceItem ) ).EndInit();
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.groupBox3.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.groupBox4.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvPresc ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Label chkInvoiceNo;
        private System.Windows.Forms.TextBox txtPatName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMediCardNo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.TextBox txtVisitNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvInvoiceItem;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvInvoiceList;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvPatList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvPresc;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisitNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Standard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pack_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pack_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Base_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECORD_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRUG_FLAG;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_VISITNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_PATNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_AGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_PATTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_DEPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_CURDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_PATLISTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_MZFP_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_MZFP_FEE;
        private System.Windows.Forms.CheckBox chkVisitNo;
        private System.Windows.Forms.CheckBox chkMediCard;
        private System.Windows.Forms.CheckBox chkPatName;
        private System.Windows.Forms.CheckBox chkInvoiceType;
        private System.Windows.Forms.ComboBox cboInvoiceType;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkPrintSingle;
        private System.Windows.Forms.CheckBox chkPrintSub;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_INVOICENO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_TOTAL_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_MONEY_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_POS_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_INSUR_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SELF_TALLY;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_FAVOR_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_CHARGEDATE;
    }
}