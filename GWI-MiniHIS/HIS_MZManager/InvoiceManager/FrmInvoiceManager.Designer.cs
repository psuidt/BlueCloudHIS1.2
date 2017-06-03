namespace HIS_MZManager.InvoiceManager
{
    partial class FrmInvoiceManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn4 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmInvoiceManager ) );
            this.dgvInvoiceList = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PERFCHAR = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.票据类型 = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.领用人 = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.START_NO = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.END_NO = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.STATUS_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.chkAllotDate = new System.Windows.Forms.CheckBox( );
            this.chkAllotUser = new System.Windows.Forms.CheckBox( );
            this.dtpFrom = new System.Windows.Forms.DateTimePicker( );
            this.dtpTo = new System.Windows.Forms.DateTimePicker( );
            this.label1 = new System.Windows.Forms.Label( );
            this.btnFind = new GWI.HIS.Windows.Controls.Button( );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.chkUnUsed = new System.Windows.Forms.CheckBox( );
            this.chkUseEnd = new System.Windows.Forms.CheckBox( );
            this.chkReadyUse = new System.Windows.Forms.CheckBox( );
            this.chkInuse = new System.Windows.Forms.CheckBox( );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.cboAllotUser = new GWI.HIS.Windows.Controls.QueryTextBox( );
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip( );
            this.btnNewAllot = new System.Windows.Forms.ToolStripButton( );
            this.btnCallOf = new System.Windows.Forms.ToolStripButton( );
            this.btnDelete = new System.Windows.Forms.ToolStripButton( );
            this.btnDetail = new System.Windows.Forms.ToolStripButton( );
            this.btnRefresh = new System.Windows.Forms.ToolStripButton( );
            this.btnClose = new System.Windows.Forms.ToolStripButton( );
            this.txtRefundMoney = new System.Windows.Forms.TextBox( );
            this.label7 = new System.Windows.Forms.Label( );
            this.txtRefundCount = new System.Windows.Forms.TextBox( );
            this.label6 = new System.Windows.Forms.Label( );
            this.label5 = new System.Windows.Forms.Label( );
            this.txtCount = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.txtTotalMoney = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.txtEnd = new System.Windows.Forms.TextBox( );
            this.txtStart = new System.Windows.Forms.TextBox( );
            this.label8 = new System.Windows.Forms.Label( );
            this.label9 = new System.Windows.Forms.Label( );
            this.txtAllCount = new System.Windows.Forms.TextBox( );
            this.label10 = new System.Windows.Forms.Label( );
            this.plBaseToolbar.SuspendLayout( );
            this.plBaseStatus.SuspendLayout( );
            this.plBaseWorkArea.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInvoiceList ) ).BeginInit( );
            this.panel1.SuspendLayout( );
            this.panel2.SuspendLayout( );
            this.toolStrip1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add( this.toolStrip1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 1028 , 32 );
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "baseImageList.ImageStream" ) ) );
            this.baseImageList.Images.SetKeyName( 0 , "table_delete.gif" );
            this.baseImageList.Images.SetKeyName( 1 , "search_big.GIF" );
            this.baseImageList.Images.SetKeyName( 2 , "Save.GIF" );
            this.baseImageList.Images.SetKeyName( 3 , "Print.GIF" );
            this.baseImageList.Images.SetKeyName( 4 , "page_user_dark.gif" );
            this.baseImageList.Images.SetKeyName( 5 , "page_refresh.gif" );
            this.baseImageList.Images.SetKeyName( 6 , "page_key.gif" );
            this.baseImageList.Images.SetKeyName( 7 , "page_edit.gif" );
            this.baseImageList.Images.SetKeyName( 8 , "page_cross.gif" );
            this.baseImageList.Images.SetKeyName( 9 , "list_users.gif" );
            this.baseImageList.Images.SetKeyName( 10 , "icon_package_get.gif" );
            this.baseImageList.Images.SetKeyName( 11 , "icon_network.gif" );
            this.baseImageList.Images.SetKeyName( 12 , "icon_history.gif" );
            this.baseImageList.Images.SetKeyName( 13 , "icon_accept.gif" );
            this.baseImageList.Images.SetKeyName( 14 , "folder_page.gif" );
            this.baseImageList.Images.SetKeyName( 15 , "folder_new.gif" );
            this.baseImageList.Images.SetKeyName( 16 , "Exit.GIF" );
            this.baseImageList.Images.SetKeyName( 17 , "Delete.GIF" );
            this.baseImageList.Images.SetKeyName( 18 , "copy.gif" );
            this.baseImageList.Images.SetKeyName( 19 , "action_stop.gif" );
            this.baseImageList.Images.SetKeyName( 20 , "action_refresh.gif" );
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Controls.Add( this.label9 );
            this.plBaseStatus.Controls.Add( this.txtAllCount );
            this.plBaseStatus.Controls.Add( this.label10 );
            this.plBaseStatus.Controls.Add( this.txtRefundMoney );
            this.plBaseStatus.Controls.Add( this.label7 );
            this.plBaseStatus.Controls.Add( this.txtRefundCount );
            this.plBaseStatus.Controls.Add( this.label6 );
            this.plBaseStatus.Controls.Add( this.label5 );
            this.plBaseStatus.Controls.Add( this.txtCount );
            this.plBaseStatus.Controls.Add( this.label4 );
            this.plBaseStatus.Controls.Add( this.label3 );
            this.plBaseStatus.Controls.Add( this.txtTotalMoney );
            this.plBaseStatus.Controls.Add( this.label2 );
            this.plBaseStatus.Controls.Add( this.txtEnd );
            this.plBaseStatus.Controls.Add( this.txtStart );
            this.plBaseStatus.Controls.Add( this.label8 );
            this.plBaseStatus.Location = new System.Drawing.Point( 0 , 418 );
            this.plBaseStatus.Size = new System.Drawing.Size( 1028 , 39 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.dgvInvoiceList );
            this.plBaseWorkArea.Controls.Add( this.panel1 );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0 , 66 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 1028 , 352 );
            // 
            // dgvInvoiceList
            // 
            this.dgvInvoiceList.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvInvoiceList.AllowSortWhenClickColumnHeader = false;
            this.dgvInvoiceList.AllowUserToAddRows = false;
            this.dgvInvoiceList.AllowUserToDeleteRows = false;
            this.dgvInvoiceList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoiceList.ColumnHeadersHeight = 35;
            this.dgvInvoiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvoiceList.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PERFCHAR,
            this.票据类型,
            this.领用人,
            this.START_NO,
            this.END_NO,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.STATUS_FLAG} );
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoiceList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceList.EnableHeadersVisualStyles = false;
            this.dgvInvoiceList.Location = new System.Drawing.Point( 0 , 41 );
            this.dgvInvoiceList.MultiSelect = false;
            this.dgvInvoiceList.Name = "dgvInvoiceList";
            this.dgvInvoiceList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInvoiceList.RowTemplate.Height = 23;
            this.dgvInvoiceList.SelectionCards = null;
            this.dgvInvoiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceList.Size = new System.Drawing.Size( 1028 , 311 );
            this.dgvInvoiceList.TabIndex = 1;
            this.dgvInvoiceList.UseGradientBackgroundColor = false;
            this.dgvInvoiceList.CurrentCellChanged += new System.EventHandler( this.dgvInvoiceList_CurrentCellChanged );
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "发票卷号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Width = 60;
            // 
            // PERFCHAR
            // 
            this.PERFCHAR.DataPropertyName = "PERFCHAR";
            this.PERFCHAR.HeaderText = "前缀字符";
            this.PERFCHAR.Name = "PERFCHAR";
            this.PERFCHAR.ReadOnly = true;
            this.PERFCHAR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PERFCHAR.Width = 50;
            // 
            // 票据类型
            // 
            this.票据类型.DataPropertyName = "INVOICE_TYPE";
            this.票据类型.HeaderText = "票据类型";
            this.票据类型.Name = "票据类型";
            this.票据类型.ReadOnly = true;
            this.票据类型.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 领用人
            // 
            this.领用人.DataPropertyName = "USERNAME";
            this.领用人.HeaderText = "领用人";
            this.领用人.Name = "领用人";
            this.领用人.ReadOnly = true;
            this.领用人.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // START_NO
            // 
            this.START_NO.DataPropertyName = "START_NO";
            this.START_NO.HeaderText = "开始票号";
            this.START_NO.Name = "START_NO";
            this.START_NO.ReadOnly = true;
            this.START_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // END_NO
            // 
            this.END_NO.DataPropertyName = "END_NO";
            this.END_NO.HeaderText = "结束票号";
            this.END_NO.Name = "END_NO";
            this.END_NO.ReadOnly = true;
            this.END_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "CURRENT_NO";
            this.Column7.HeaderText = "当前票号";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "STATUS";
            this.Column8.HeaderText = "状态";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.DataPropertyName = "ALLOT_DATE";
            this.Column9.HeaderText = "分配日期";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "ALLOT_USER";
            this.Column10.HeaderText = "操作员";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // STATUS_FLAG
            // 
            this.STATUS_FLAG.DataPropertyName = "STATUS_FLAG";
            this.STATUS_FLAG.HeaderText = "STATUS_FLAG";
            this.STATUS_FLAG.Name = "STATUS_FLAG";
            this.STATUS_FLAG.ReadOnly = true;
            this.STATUS_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STATUS_FLAG.Visible = false;
            // 
            // chkAllotDate
            // 
            this.chkAllotDate.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.chkAllotDate.AutoSize = true;
            this.chkAllotDate.Location = new System.Drawing.Point( 16 , 12 );
            this.chkAllotDate.Name = "chkAllotDate";
            this.chkAllotDate.Size = new System.Drawing.Size( 72 , 16 );
            this.chkAllotDate.TabIndex = 0;
            this.chkAllotDate.Text = "领用时间";
            this.chkAllotDate.UseVisualStyleBackColor = true;
            this.chkAllotDate.CheckedChanged += new System.EventHandler( this.chkAllotDate_CheckedChanged );
            // 
            // chkAllotUser
            // 
            this.chkAllotUser.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.chkAllotUser.AutoSize = true;
            this.chkAllotUser.Location = new System.Drawing.Point( 375 , 11 );
            this.chkAllotUser.Name = "chkAllotUser";
            this.chkAllotUser.Size = new System.Drawing.Size( 60 , 16 );
            this.chkAllotUser.TabIndex = 1;
            this.chkAllotUser.Text = "领用人";
            this.chkAllotUser.UseVisualStyleBackColor = true;
            this.chkAllotUser.CheckedChanged += new System.EventHandler( this.chkAllotUser_CheckedChanged );
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.dtpFrom.Location = new System.Drawing.Point( 94 , 9 );
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size( 111 , 21 );
            this.dtpFrom.TabIndex = 2;
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.dtpTo.Location = new System.Drawing.Point( 225 , 9 );
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size( 132 , 21 );
            this.dtpTo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 210 , 14 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 11 , 12 );
            this.label1.TabIndex = 4;
            this.label1.Text = "-";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnFind.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Search;
            this.btnFind.FixedWidth = false;
            this.btnFind.Image = ( (System.Drawing.Image)( resources.GetObject( "btnFind.Image" ) ) );
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point( 570 , 7 );
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size( 78 , 25 );
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "查找(&F)";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler( this.btnFind_Click );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.chkUnUsed );
            this.panel1.Controls.Add( this.chkUseEnd );
            this.panel1.Controls.Add( this.chkReadyUse );
            this.panel1.Controls.Add( this.chkInuse );
            this.panel1.Controls.Add( this.panel2 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 1028 , 41 );
            this.panel1.TabIndex = 7;
            // 
            // chkUnUsed
            // 
            this.chkUnUsed.AutoSize = true;
            this.chkUnUsed.ForeColor = System.Drawing.Color.DarkRed;
            this.chkUnUsed.Location = new System.Drawing.Point( 185 , 12 );
            this.chkUnUsed.Name = "chkUnUsed";
            this.chkUnUsed.Size = new System.Drawing.Size( 48 , 16 );
            this.chkUnUsed.TabIndex = 11;
            this.chkUnUsed.Text = "停用";
            this.chkUnUsed.UseVisualStyleBackColor = true;
            // 
            // chkUseEnd
            // 
            this.chkUseEnd.AutoSize = true;
            this.chkUseEnd.ForeColor = System.Drawing.Color.Gray;
            this.chkUseEnd.Location = new System.Drawing.Point( 131 , 12 );
            this.chkUseEnd.Name = "chkUseEnd";
            this.chkUseEnd.Size = new System.Drawing.Size( 48 , 16 );
            this.chkUseEnd.TabIndex = 10;
            this.chkUseEnd.Text = "用完";
            this.chkUseEnd.UseVisualStyleBackColor = true;
            // 
            // chkReadyUse
            // 
            this.chkReadyUse.AutoSize = true;
            this.chkReadyUse.Checked = true;
            this.chkReadyUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadyUse.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkReadyUse.Location = new System.Drawing.Point( 77 , 12 );
            this.chkReadyUse.Name = "chkReadyUse";
            this.chkReadyUse.Size = new System.Drawing.Size( 48 , 16 );
            this.chkReadyUse.TabIndex = 9;
            this.chkReadyUse.Text = "备用";
            this.chkReadyUse.UseVisualStyleBackColor = true;
            // 
            // chkInuse
            // 
            this.chkInuse.AutoSize = true;
            this.chkInuse.Checked = true;
            this.chkInuse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInuse.ForeColor = System.Drawing.Color.Blue;
            this.chkInuse.Location = new System.Drawing.Point( 11 , 12 );
            this.chkInuse.Name = "chkInuse";
            this.chkInuse.Size = new System.Drawing.Size( 60 , 16 );
            this.chkInuse.TabIndex = 8;
            this.chkInuse.Text = "使用中";
            this.chkInuse.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.cboAllotUser );
            this.panel2.Controls.Add( this.chkAllotDate );
            this.panel2.Controls.Add( this.dtpTo );
            this.panel2.Controls.Add( this.btnFind );
            this.panel2.Controls.Add( this.label1 );
            this.panel2.Controls.Add( this.chkAllotUser );
            this.panel2.Controls.Add( this.dtpFrom );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point( 339 , 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 689 , 41 );
            this.panel2.TabIndex = 7;
            // 
            // cboAllotUser
            // 
            this.cboAllotUser.AllowSelectedNullRow = false;
            this.cboAllotUser.BackColor = System.Drawing.Color.White;
            this.cboAllotUser.DisplayField = "NAME";
            this.cboAllotUser.Location = new System.Drawing.Point( 452 , 9 );
            this.cboAllotUser.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.cboAllotUser.MemberField = "EMPLOYEE_ID";
            this.cboAllotUser.MemberValue = null;
            this.cboAllotUser.Name = "cboAllotUser";
            this.cboAllotUser.NextControl = null;
            this.cboAllotUser.NextControlByEnter = false;
            this.cboAllotUser.OffsetX = 0;
            this.cboAllotUser.OffsetY = 0;
            this.cboAllotUser.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE",
        "NAME"};
            this.cboAllotUser.SelectedValue = null;
            this.cboAllotUser.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.cboAllotUser.SelectionCardBackColor = System.Drawing.Color.White;
            this.cboAllotUser.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn1.AutoFill = false;
            selectionCardColumn1.DataBindField = "EMPLOYEE_ID";
            selectionCardColumn1.HeaderText = "EMPLOYEE_ID";
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = false;
            selectionCardColumn1.Width = 75;
            selectionCardColumn2.AutoFill = true;
            selectionCardColumn2.DataBindField = "NAME";
            selectionCardColumn2.HeaderText = "姓名";
            selectionCardColumn2.IsSeachColumn = false;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 75;
            selectionCardColumn3.AutoFill = false;
            selectionCardColumn3.DataBindField = "PY_CODE";
            selectionCardColumn3.HeaderText = "拼音码";
            selectionCardColumn3.IsSeachColumn = false;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn3.Visiable = true;
            selectionCardColumn3.Width = 75;
            selectionCardColumn4.AutoFill = false;
            selectionCardColumn4.DataBindField = "WB_CODE";
            selectionCardColumn4.HeaderText = "五笔码";
            selectionCardColumn4.IsSeachColumn = false;
            selectionCardColumn4.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn4.Visiable = true;
            selectionCardColumn4.Width = 75;
            this.cboAllotUser.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2,
        selectionCardColumn3,
        selectionCardColumn4};
            this.cboAllotUser.SelectionCardFont = null;
            this.cboAllotUser.SelectionCardHeight = 250;
            this.cboAllotUser.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.cboAllotUser.SelectionCardRowHeaderWidth = 35;
            this.cboAllotUser.SelectionCardRowHeight = 23;
            this.cboAllotUser.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.cboAllotUser.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.cboAllotUser.SelectionCardWidth = 350;
            this.cboAllotUser.ShowRowNumber = true;
            this.cboAllotUser.ShowSelectionCardAfterEnter = false;
            this.cboAllotUser.Size = new System.Drawing.Size( 112 , 21 );
            this.cboAllotUser.TabIndex = 7;
            this.cboAllotUser.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip1.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "toolStrip1.BackgroundImage" ) ) );
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font( "Tahoma" , 10F );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.btnNewAllot,
            this.btnCallOf,
            this.btnDelete,
            this.btnDetail,
            this.btnRefresh,
            this.btnClose} );
            this.toolStrip1.Location = new System.Drawing.Point( 0 , 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size( 1028 , 32 );
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewAllot
            // 
            this.btnNewAllot.Image = global::HIS_MZManager.Properties.Resources.新建;
            this.btnNewAllot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewAllot.Name = "btnNewAllot";
            this.btnNewAllot.Size = new System.Drawing.Size( 89 , 29 );
            this.btnNewAllot.Text = "新分配(&N)";
            this.btnNewAllot.Click += new System.EventHandler( this.btnNewAllot_Click );
            // 
            // btnCallOf
            // 
            this.btnCallOf.Image = global::HIS_MZManager.Properties.Resources.table_delete;
            this.btnCallOf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCallOf.Name = "btnCallOf";
            this.btnCallOf.Size = new System.Drawing.Size( 74 , 29 );
            this.btnCallOf.Text = "停用(&T)";
            this.btnCallOf.Click += new System.EventHandler( this.btnCallOf_Click );
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::HIS_MZManager.Properties.Resources.page_cross;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size( 76 , 29 );
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler( this.btnDelete_Click );
            // 
            // btnDetail
            // 
            this.btnDetail.Image = ( (System.Drawing.Image)( resources.GetObject( "btnDetail.Image" ) ) );
            this.btnDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size( 84 , 29 );
            this.btnDetail.Text = "详细信息";
            this.btnDetail.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::HIS_MZManager.Properties.Resources.刷新;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size( 75 , 29 );
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.Click += new System.EventHandler( this.btnRefresh_Click );
            // 
            // btnClose
            // 
            this.btnClose.Image = global::HIS_MZManager.Properties.Resources.退出;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75 , 29 );
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // txtRefundMoney
            // 
            this.txtRefundMoney.BackColor = System.Drawing.Color.White;
            this.txtRefundMoney.Location = new System.Drawing.Point( 927 , 6 );
            this.txtRefundMoney.Name = "txtRefundMoney";
            this.txtRefundMoney.ReadOnly = true;
            this.txtRefundMoney.Size = new System.Drawing.Size( 92 , 21 );
            this.txtRefundMoney.TabIndex = 25;
            this.txtRefundMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point( 868 , 9 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 53 , 12 );
            this.label7.TabIndex = 24;
            this.label7.Text = "票面金额";
            // 
            // txtRefundCount
            // 
            this.txtRefundCount.BackColor = System.Drawing.Color.White;
            this.txtRefundCount.Location = new System.Drawing.Point( 806 , 6 );
            this.txtRefundCount.Name = "txtRefundCount";
            this.txtRefundCount.ReadOnly = true;
            this.txtRefundCount.Size = new System.Drawing.Size( 56 , 21 );
            this.txtRefundCount.TabIndex = 23;
            this.txtRefundCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 186 , 9 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 11 , 12 );
            this.label6.TabIndex = 22;
            this.label6.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 536 , 9 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 17 , 12 );
            this.label5.TabIndex = 21;
            this.label5.Text = "张";
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.Color.White;
            this.txtCount.Location = new System.Drawing.Point( 474 , 6 );
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size( 56 , 21 );
            this.txtCount.TabIndex = 20;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 415 , 9 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 53 , 12 );
            this.label4.TabIndex = 19;
            this.label4.Text = "实际使用";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 723 , 9 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 77 , 12 );
            this.label3.TabIndex = 18;
            this.label3.Text = "其中包含退票";
            // 
            // txtTotalMoney
            // 
            this.txtTotalMoney.BackColor = System.Drawing.Color.White;
            this.txtTotalMoney.Location = new System.Drawing.Point( 618 , 6 );
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.ReadOnly = true;
            this.txtTotalMoney.Size = new System.Drawing.Size( 100 , 21 );
            this.txtTotalMoney.TabIndex = 17;
            this.txtTotalMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 559 , 9 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53 , 12 );
            this.label2.TabIndex = 16;
            this.label2.Text = "票面金额";
            // 
            // txtEnd
            // 
            this.txtEnd.BackColor = System.Drawing.Color.White;
            this.txtEnd.Location = new System.Drawing.Point( 205 , 6 );
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.ReadOnly = true;
            this.txtEnd.Size = new System.Drawing.Size( 100 , 21 );
            this.txtEnd.TabIndex = 15;
            this.txtEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStart
            // 
            this.txtStart.BackColor = System.Drawing.Color.White;
            this.txtStart.Location = new System.Drawing.Point( 79 , 6 );
            this.txtStart.Name = "txtStart";
            this.txtStart.ReadOnly = true;
            this.txtStart.Size = new System.Drawing.Size( 100 , 21 );
            this.txtStart.TabIndex = 14;
            this.txtStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point( 8 , 9 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 65 , 12 );
            this.label8.TabIndex = 13;
            this.label8.Text = "发票起止号";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point( 392 , 9 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 17 , 12 );
            this.label9.TabIndex = 28;
            this.label9.Text = "张";
            // 
            // txtAllCount
            // 
            this.txtAllCount.BackColor = System.Drawing.Color.White;
            this.txtAllCount.Location = new System.Drawing.Point( 334 , 6 );
            this.txtAllCount.Name = "txtAllCount";
            this.txtAllCount.ReadOnly = true;
            this.txtAllCount.Size = new System.Drawing.Size( 52 , 21 );
            this.txtAllCount.TabIndex = 27;
            this.txtAllCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point( 311 , 9 );
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size( 17 , 12 );
            this.label10.TabIndex = 26;
            this.label10.Text = "共";
            // 
            // FrmInvoiceManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size( 1028 , 457 );
            this.Name = "FrmInvoiceManager";
            this.Text = "FrmInvoiceManager";
            this.Load += new System.EventHandler( this.FrmInvoiceManager_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout( );
            this.plBaseStatus.ResumeLayout( false );
            this.plBaseStatus.PerformLayout( );
            this.plBaseWorkArea.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInvoiceList ) ).EndInit( );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout( );
            this.panel2.ResumeLayout( false );
            this.panel2.PerformLayout( );
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgvInvoiceList;
        private System.Windows.Forms.CheckBox chkAllotUser;
        private System.Windows.Forms.CheckBox chkAllotDate;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private GWI.HIS.Windows.Controls.Button btnFind;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkUnUsed;
        private System.Windows.Forms.CheckBox chkUseEnd;
        private System.Windows.Forms.CheckBox chkReadyUse;
        private System.Windows.Forms.CheckBox chkInuse;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNewAllot;
        private System.Windows.Forms.ToolStripButton btnCallOf;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnClose;
        private GWI.HIS.Windows.Controls.QueryTextBox cboAllotUser;
        private System.Windows.Forms.ToolStripButton btnDetail;
        private System.Windows.Forms.TextBox txtRefundMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRefundCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERFCHAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn 票据类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 领用人;
        private System.Windows.Forms.DataGridViewTextBoxColumn START_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS_FLAG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAllCount;
        private System.Windows.Forms.Label label10;
    }
}