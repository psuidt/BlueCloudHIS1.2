namespace HIS_DJSFManager.窗口
{
    partial class FrmInvoiceQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmInvoiceQuery ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.dgvList = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.dtpFrom = new System.Windows.Forms.DateTimePicker( );
            this.dtpTo = new System.Windows.Forms.DateTimePicker( );
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.btnQuery = new GWI.HIS.Windows.Controls.Button( );
            this.button1 = new GWI.HIS.Windows.Controls.Button( );
            this.label3 = new System.Windows.Forms.Label( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label5 = new System.Windows.Forms.Label( );
            this.label6 = new System.Windows.Forms.Label( );
            this.label7 = new System.Windows.Forms.Label( );
            this.lblTotalCost = new System.Windows.Forms.Label( );
            this.lblTotalNum = new System.Windows.Forms.Label( );
            this.lblReturnNum = new System.Windows.Forms.Label( );
            this.lblReturnCost = new System.Windows.Forms.Label( );
            this.lblActCost = new System.Windows.Forms.Label( );
            this.chkall = new System.Windows.Forms.CheckBox( );
            this.splitter1 = new System.Windows.Forms.Splitter( );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.plInvoice = new System.Windows.Forms.Panel( );
            this.lblPrint = new System.Windows.Forms.LinkLabel( );
            this.lblClose = new System.Windows.Forms.LinkLabel( );
            this.dgvInoviceItems = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.ItemCost = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.lblPos = new System.Windows.Forms.Label( );
            this.lblFavor = new System.Windows.Forms.Label( );
            this.lblTally = new System.Windows.Forms.Label( );
            this.lblCash = new System.Windows.Forms.Label( );
            this.lblPayType = new System.Windows.Forms.Label( );
            this.lblTotal = new System.Windows.Forms.Label( );
            this.label15 = new System.Windows.Forms.Label( );
            this.label14 = new System.Windows.Forms.Label( );
            this.label13 = new System.Windows.Forms.Label( );
            this.label12 = new System.Windows.Forms.Label( );
            this.label11 = new System.Windows.Forms.Label( );
            this.label10 = new System.Windows.Forms.Label( );
            this.label8 = new System.Windows.Forms.Label( );
            this.cboInvoiceType = new System.Windows.Forms.ComboBox( );
            this.lblTotalCash = new System.Windows.Forms.Label( );
            this.label16 = new System.Windows.Forms.Label( );
            this.lblTotalPOS = new System.Windows.Forms.Label( );
            this.label18 = new System.Windows.Forms.Label( );
            this.lblTotalTally = new System.Windows.Forms.Label( );
            this.label20 = new System.Windows.Forms.Label( );
            this.lblTotalFavor = new System.Windows.Forms.Label( );
            this.label22 = new System.Windows.Forms.Label( );
            this.cboPatType = new System.Windows.Forms.ComboBox( );
            this.chkPayType = new System.Windows.Forms.CheckBox( );
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.VISITNO = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.CASH = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.POS = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.TALLY = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.SELF_TALLY = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.FAVOR = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.ChargeDate = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.ChargeUser = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.UnChargeDate = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.UnChargeCost = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.UnChargeUser = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.HANG_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.MEDITYPE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.lblSelfTally = new System.Windows.Forms.Label( );
            this.label17 = new System.Windows.Forms.Label( );
            this.lblTotalSelfTally = new System.Windows.Forms.Label( );
            this.label19 = new System.Windows.Forms.Label( );
            this.plBaseToolbar.SuspendLayout( );
            this.plBaseStatus.SuspendLayout( );
            this.plBaseWorkArea.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvList ) ).BeginInit( );
            this.panel2.SuspendLayout( );
            this.plInvoice.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInoviceItems ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add( this.chkPayType );
            this.plBaseToolbar.Controls.Add( this.cboPatType );
            this.plBaseToolbar.Controls.Add( this.cboInvoiceType );
            this.plBaseToolbar.Controls.Add( this.label8 );
            this.plBaseToolbar.Controls.Add( this.chkall );
            this.plBaseToolbar.Controls.Add( this.button1 );
            this.plBaseToolbar.Controls.Add( this.btnQuery );
            this.plBaseToolbar.Controls.Add( this.label2 );
            this.plBaseToolbar.Controls.Add( this.label1 );
            this.plBaseToolbar.Controls.Add( this.dtpTo );
            this.plBaseToolbar.Controls.Add( this.dtpFrom );
            this.plBaseToolbar.Size = new System.Drawing.Size( 1028 , 40 );
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
            this.plBaseStatus.Controls.Add( this.lblTotalSelfTally );
            this.plBaseStatus.Controls.Add( this.label19 );
            this.plBaseStatus.Controls.Add( this.lblTotalFavor );
            this.plBaseStatus.Controls.Add( this.label22 );
            this.plBaseStatus.Controls.Add( this.lblTotalTally );
            this.plBaseStatus.Controls.Add( this.label20 );
            this.plBaseStatus.Controls.Add( this.lblTotalPOS );
            this.plBaseStatus.Controls.Add( this.label18 );
            this.plBaseStatus.Controls.Add( this.lblTotalCash );
            this.plBaseStatus.Controls.Add( this.label16 );
            this.plBaseStatus.Controls.Add( this.lblActCost );
            this.plBaseStatus.Controls.Add( this.lblReturnCost );
            this.plBaseStatus.Controls.Add( this.lblReturnNum );
            this.plBaseStatus.Controls.Add( this.lblTotalNum );
            this.plBaseStatus.Controls.Add( this.lblTotalCost );
            this.plBaseStatus.Controls.Add( this.label7 );
            this.plBaseStatus.Controls.Add( this.label6 );
            this.plBaseStatus.Controls.Add( this.label5 );
            this.plBaseStatus.Controls.Add( this.label4 );
            this.plBaseStatus.Controls.Add( this.label3 );
            this.plBaseStatus.Location = new System.Drawing.Point( 0 , 375 );
            this.plBaseStatus.Size = new System.Drawing.Size( 1028 , 71 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.panel2 );
            this.plBaseWorkArea.Controls.Add( this.splitter1 );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0 , 74 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 1028 , 301 );
            // 
            // dgvList
            // 
            this.dgvList.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvList.AllowSortWhenClickColumnHeader = true;
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle15.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvList.ColumnHeadersHeight = 30;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceNo,
            this.PatientName,
            this.VISITNO,
            this.Cost,
            this.CASH,
            this.POS,
            this.TALLY,
            this.SELF_TALLY,
            this.FAVOR,
            this.ChargeDate,
            this.ChargeUser,
            this.UnChargeDate,
            this.UnChargeCost,
            this.UnChargeUser,
            this.HANG_FLAG,
            this.MEDITYPE} );
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle23.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point( 0 , 0 );
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle24.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionCards = null;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size( 1028 , 298 );
            this.dgvList.TabIndex = 0;
            this.dgvList.UseGradientBackgroundColor = true;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler( this.dgvList_CellDoubleClick );
            this.dgvList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler( this.dgvList_RowPostPaint );
            this.dgvList.CurrentCellChanged += new System.EventHandler( this.dgvList_CurrentCellChanged );
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point( 45 , 9 );
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size( 177 , 21 );
            this.dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point( 251 , 9 );
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size( 177 , 21 );
            this.dtpTo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 228 , 13 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 17 , 12 );
            this.label1.TabIndex = 3;
            this.label1.Text = "到";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10 , 13 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 29 , 12 );
            this.label2.TabIndex = 4;
            this.label2.Text = "时间";
            // 
            // btnQuery
            // 
            this.btnQuery.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnQuery.FixedWidth = false;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point( 861 , 7 );
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size( 78 , 25 );
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler( this.btnQuery_Click );
            // 
            // button1
            // 
            this.button1.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.button1.FixedWidth = false;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point( 945 , 7 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 78 , 25 );
            this.button1.TabIndex = 7;
            this.button1.Text = "关闭(&C)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label3.Location = new System.Drawing.Point( 12 , 15 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 82 , 15 );
            this.label3.TabIndex = 0;
            this.label3.Text = "发票总张数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label4.Location = new System.Drawing.Point( 12 , 47 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 82 , 15 );
            this.label4.TabIndex = 1;
            this.label4.Text = "退费发票数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label5.Location = new System.Drawing.Point( 155 , 47 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 67 , 15 );
            this.label5.TabIndex = 2;
            this.label5.Text = "退费金额";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label6.Location = new System.Drawing.Point( 349 , 15 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 67 , 15 );
            this.label6.TabIndex = 3;
            this.label6.Text = "实际金额";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label7.Location = new System.Drawing.Point( 155 , 15 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 82 , 15 );
            this.label7.TabIndex = 4;
            this.label7.Text = "发票总金额";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblTotalCost.Location = new System.Drawing.Point( 239 , 15 );
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size( 79 , 15 );
            this.lblTotalCost.TabIndex = 6;
            this.lblTotalCost.Text = "888888.88";
            this.lblTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalNum
            // 
            this.lblTotalNum.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblTotalNum.Location = new System.Drawing.Point( 97 , 15 );
            this.lblTotalNum.Name = "lblTotalNum";
            this.lblTotalNum.Size = new System.Drawing.Size( 49 , 15 );
            this.lblTotalNum.TabIndex = 7;
            this.lblTotalNum.Text = "8888";
            this.lblTotalNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReturnNum
            // 
            this.lblReturnNum.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblReturnNum.Location = new System.Drawing.Point( 100 , 47 );
            this.lblReturnNum.Name = "lblReturnNum";
            this.lblReturnNum.Size = new System.Drawing.Size( 41 , 15 );
            this.lblReturnNum.TabIndex = 8;
            this.lblReturnNum.Text = "8888";
            this.lblReturnNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReturnCost
            // 
            this.lblReturnCost.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblReturnCost.Location = new System.Drawing.Point( 239 , 47 );
            this.lblReturnCost.Name = "lblReturnCost";
            this.lblReturnCost.Size = new System.Drawing.Size( 81 , 15 );
            this.lblReturnCost.TabIndex = 9;
            this.lblReturnCost.Text = "888888.88";
            this.lblReturnCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblActCost
            // 
            this.lblActCost.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblActCost.Location = new System.Drawing.Point( 422 , 15 );
            this.lblActCost.Name = "lblActCost";
            this.lblActCost.Size = new System.Drawing.Size( 80 , 15 );
            this.lblActCost.TabIndex = 10;
            this.lblActCost.Text = "888888.88";
            this.lblActCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.Location = new System.Drawing.Point( 434 , 12 );
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size( 60 , 16 );
            this.chkall.TabIndex = 8;
            this.chkall.Text = "所有人";
            this.chkall.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point( 0 , 298 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 1028 , 3 );
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.plInvoice );
            this.panel2.Controls.Add( this.dgvList );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0 , 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 1028 , 298 );
            this.panel2.TabIndex = 3;
            // 
            // plInvoice
            // 
            this.plInvoice.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.plInvoice.BackColor = System.Drawing.Color.White;
            this.plInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plInvoice.Controls.Add( this.lblSelfTally );
            this.plInvoice.Controls.Add( this.label17 );
            this.plInvoice.Controls.Add( this.lblPrint );
            this.plInvoice.Controls.Add( this.lblClose );
            this.plInvoice.Controls.Add( this.dgvInoviceItems );
            this.plInvoice.Controls.Add( this.lblPos );
            this.plInvoice.Controls.Add( this.lblFavor );
            this.plInvoice.Controls.Add( this.lblTally );
            this.plInvoice.Controls.Add( this.lblCash );
            this.plInvoice.Controls.Add( this.lblPayType );
            this.plInvoice.Controls.Add( this.lblTotal );
            this.plInvoice.Controls.Add( this.label15 );
            this.plInvoice.Controls.Add( this.label14 );
            this.plInvoice.Controls.Add( this.label13 );
            this.plInvoice.Controls.Add( this.label12 );
            this.plInvoice.Controls.Add( this.label11 );
            this.plInvoice.Controls.Add( this.label10 );
            this.plInvoice.Location = new System.Drawing.Point( 604 , 23 );
            this.plInvoice.Name = "plInvoice";
            this.plInvoice.Size = new System.Drawing.Size( 399 , 269 );
            this.plInvoice.TabIndex = 1;
            this.plInvoice.Visible = false;
            // 
            // lblPrint
            // 
            this.lblPrint.AutoSize = true;
            this.lblPrint.Location = new System.Drawing.Point( 334 , 16 );
            this.lblPrint.Name = "lblPrint";
            this.lblPrint.Size = new System.Drawing.Size( 29 , 12 );
            this.lblPrint.TabIndex = 15;
            this.lblPrint.TabStop = true;
            this.lblPrint.Text = "重打";
            this.lblPrint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lblPrint_LinkClicked );
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Location = new System.Drawing.Point( 364 , 16 );
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size( 29 , 12 );
            this.lblClose.TabIndex = 14;
            this.lblClose.TabStop = true;
            this.lblClose.Text = "关闭";
            this.lblClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lblClose_LinkClicked );
            // 
            // dgvInoviceItems
            // 
            this.dgvInoviceItems.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvInoviceItems.AllowSortWhenClickColumnHeader = false;
            this.dgvInoviceItems.AllowUserToAddRows = false;
            this.dgvInoviceItems.AllowUserToDeleteRows = false;
            this.dgvInoviceItems.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle25.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInoviceItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvInoviceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInoviceItems.ColumnHeadersVisible = false;
            this.dgvInoviceItems.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.ItemCost} );
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInoviceItems.DefaultCellStyle = dataGridViewCellStyle27;
            this.dgvInoviceItems.EnableHeadersVisualStyles = false;
            this.dgvInoviceItems.GridColor = System.Drawing.Color.White;
            this.dgvInoviceItems.Location = new System.Drawing.Point( 6 , 87 );
            this.dgvInoviceItems.Name = "dgvInoviceItems";
            this.dgvInoviceItems.ReadOnly = true;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle28.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInoviceItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvInoviceItems.RowHeadersVisible = false;
            this.dgvInoviceItems.RowTemplate.Height = 23;
            this.dgvInoviceItems.SelectionCards = null;
            this.dgvInoviceItems.Size = new System.Drawing.Size( 387 , 177 );
            this.dgvInoviceItems.TabIndex = 13;
            this.dgvInoviceItems.UseGradientBackgroundColor = false;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.HeaderText = "Column1";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemCost
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle26.Format = "C2";
            dataGridViewCellStyle26.NullValue = null;
            this.ItemCost.DefaultCellStyle = dataGridViewCellStyle26;
            this.ItemCost.HeaderText = "Column1";
            this.ItemCost.Name = "ItemCost";
            this.ItemCost.ReadOnly = true;
            this.ItemCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemCost.Width = 75;
            // 
            // lblPos
            // 
            this.lblPos.Location = new System.Drawing.Point( 195 , 68 );
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size( 60 , 12 );
            this.lblPos.TabIndex = 12;
            this.lblPos.Text = "0.00";
            this.lblPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFavor
            // 
            this.lblFavor.Location = new System.Drawing.Point( 195 , 43 );
            this.lblFavor.Name = "lblFavor";
            this.lblFavor.Size = new System.Drawing.Size( 60 , 12 );
            this.lblFavor.TabIndex = 11;
            this.lblFavor.Text = "0.00";
            this.lblFavor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTally
            // 
            this.lblTally.Location = new System.Drawing.Point( 342 , 70 );
            this.lblTally.Name = "lblTally";
            this.lblTally.Size = new System.Drawing.Size( 51 , 12 );
            this.lblTally.TabIndex = 10;
            this.lblTally.Text = "0.00";
            this.lblTally.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCash
            // 
            this.lblCash.Location = new System.Drawing.Point( 63 , 68 );
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size( 60 , 12 );
            this.lblCash.TabIndex = 9;
            this.lblCash.Text = "0.00";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPayType
            // 
            this.lblPayType.Location = new System.Drawing.Point( 70 , 16 );
            this.lblPayType.Name = "lblPayType";
            this.lblPayType.Size = new System.Drawing.Size( 240 , 12 );
            this.lblPayType.TabIndex = 8;
            this.lblPayType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point( 63 , 43 );
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size( 60 , 12 );
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point( 141 , 43 );
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size( 53 , 12 );
            this.label15.TabIndex = 6;
            this.label15.Text = "优惠金额";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point( 141 , 68 );
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size( 47 , 12 );
            this.label14.TabIndex = 5;
            this.label14.Text = "POS支付";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point( 265 , 68 );
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size( 77 , 12 );
            this.label13.TabIndex = 4;
            this.label13.Text = "农合医保记账";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point( 4 , 68 );
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size( 53 , 12 );
            this.label12.TabIndex = 3;
            this.label12.Text = "现金支付";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point( 4 , 16 );
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size( 53 , 12 );
            this.label11.TabIndex = 2;
            this.label11.Text = "支付方式";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point( 4 , 43 );
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size( 53 , 12 );
            this.label10.TabIndex = 1;
            this.label10.Text = "发票金额";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point( 500 , 14 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 53 , 12 );
            this.label8.TabIndex = 9;
            this.label8.Text = "发票类别";
            // 
            // cboInvoiceType
            // 
            this.cboInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInvoiceType.FormattingEnabled = true;
            this.cboInvoiceType.Location = new System.Drawing.Point( 555 , 10 );
            this.cboInvoiceType.Name = "cboInvoiceType";
            this.cboInvoiceType.Size = new System.Drawing.Size( 116 , 20 );
            this.cboInvoiceType.TabIndex = 10;
            // 
            // lblTotalCash
            // 
            this.lblTotalCash.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblTotalCash.Location = new System.Drawing.Point( 589 , 15 );
            this.lblTotalCash.Name = "lblTotalCash";
            this.lblTotalCash.Size = new System.Drawing.Size( 80 , 15 );
            this.lblTotalCash.TabIndex = 12;
            this.lblTotalCash.Text = "888888.88";
            this.lblTotalCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label16.Location = new System.Drawing.Point( 523 , 15 );
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size( 67 , 15 );
            this.label16.TabIndex = 11;
            this.label16.Text = "现金金额";
            // 
            // lblTotalPOS
            // 
            this.lblTotalPOS.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblTotalPOS.Location = new System.Drawing.Point( 752 , 15 );
            this.lblTotalPOS.Name = "lblTotalPOS";
            this.lblTotalPOS.Size = new System.Drawing.Size( 80 , 15 );
            this.lblTotalPOS.TabIndex = 14;
            this.lblTotalPOS.Text = "888888.88";
            this.lblTotalPOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label18.Location = new System.Drawing.Point( 686 , 15 );
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size( 61 , 15 );
            this.label18.TabIndex = 13;
            this.label18.Text = "POS金额";
            // 
            // lblTotalTally
            // 
            this.lblTotalTally.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblTotalTally.Location = new System.Drawing.Point( 626 , 47 );
            this.lblTotalTally.Name = "lblTotalTally";
            this.lblTotalTally.Size = new System.Drawing.Size( 80 , 15 );
            this.lblTotalTally.TabIndex = 16;
            this.lblTotalTally.Text = "888888.88";
            this.lblTotalTally.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label20.Location = new System.Drawing.Point( 523 , 47 );
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size( 97 , 15 );
            this.label20.TabIndex = 15;
            this.label20.Text = "农合医保记账";
            // 
            // lblTotalFavor
            // 
            this.lblTotalFavor.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblTotalFavor.Location = new System.Drawing.Point( 906 , 15 );
            this.lblTotalFavor.Name = "lblTotalFavor";
            this.lblTotalFavor.Size = new System.Drawing.Size( 80 , 15 );
            this.lblTotalFavor.TabIndex = 18;
            this.lblTotalFavor.Text = "888888.88";
            this.lblTotalFavor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label22.Location = new System.Drawing.Point( 838 , 15 );
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size( 67 , 15 );
            this.label22.TabIndex = 17;
            this.label22.Text = "优惠金额";
            // 
            // cboPatType
            // 
            this.cboPatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatType.FormattingEnabled = true;
            this.cboPatType.Location = new System.Drawing.Point( 762 , 9 );
            this.cboPatType.Name = "cboPatType";
            this.cboPatType.Size = new System.Drawing.Size( 92 , 20 );
            this.cboPatType.TabIndex = 12;
            // 
            // chkPayType
            // 
            this.chkPayType.AutoSize = true;
            this.chkPayType.Location = new System.Drawing.Point( 677 , 12 );
            this.chkPayType.Name = "chkPayType";
            this.chkPayType.Size = new System.Drawing.Size( 72 , 16 );
            this.chkPayType.TabIndex = 13;
            this.chkPayType.Text = "病人类型";
            this.chkPayType.UseVisualStyleBackColor = true;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.DataPropertyName = "InvoiceNo";
            this.InvoiceNo.HeaderText = "发票号";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.HeaderText = "患者姓名";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            // 
            // VISITNO
            // 
            this.VISITNO.DataPropertyName = "VISITNO";
            this.VISITNO.HeaderText = "就诊号";
            this.VISITNO.Name = "VISITNO";
            this.VISITNO.ReadOnly = true;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.NullValue = null;
            this.Cost.DefaultCellStyle = dataGridViewCellStyle16;
            this.Cost.HeaderText = "发票金额";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // CASH
            // 
            this.CASH.DataPropertyName = "CASH";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CASH.DefaultCellStyle = dataGridViewCellStyle17;
            this.CASH.HeaderText = "现金";
            this.CASH.Name = "CASH";
            this.CASH.ReadOnly = true;
            this.CASH.Width = 75;
            // 
            // POS
            // 
            this.POS.DataPropertyName = "POS";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.POS.DefaultCellStyle = dataGridViewCellStyle18;
            this.POS.HeaderText = "POS";
            this.POS.Name = "POS";
            this.POS.ReadOnly = true;
            this.POS.Width = 75;
            // 
            // TALLY
            // 
            this.TALLY.DataPropertyName = "TALLY";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TALLY.DefaultCellStyle = dataGridViewCellStyle19;
            this.TALLY.HeaderText = "农合或医保记账";
            this.TALLY.Name = "TALLY";
            this.TALLY.ReadOnly = true;
            this.TALLY.Width = 75;
            // 
            // SELF_TALLY
            // 
            this.SELF_TALLY.DataPropertyName = "SELF_TALLY";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SELF_TALLY.DefaultCellStyle = dataGridViewCellStyle20;
            this.SELF_TALLY.HeaderText = "个人(单位记账)";
            this.SELF_TALLY.Name = "SELF_TALLY";
            this.SELF_TALLY.ReadOnly = true;
            // 
            // FAVOR
            // 
            this.FAVOR.DataPropertyName = "FAVOR";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FAVOR.DefaultCellStyle = dataGridViewCellStyle21;
            this.FAVOR.HeaderText = "优惠";
            this.FAVOR.Name = "FAVOR";
            this.FAVOR.ReadOnly = true;
            this.FAVOR.Width = 75;
            // 
            // ChargeDate
            // 
            this.ChargeDate.DataPropertyName = "ChargeDate";
            this.ChargeDate.HeaderText = "收费时间";
            this.ChargeDate.Name = "ChargeDate";
            this.ChargeDate.ReadOnly = true;
            this.ChargeDate.Width = 150;
            // 
            // ChargeUser
            // 
            this.ChargeUser.DataPropertyName = "ChargeUser";
            this.ChargeUser.HeaderText = "收费员";
            this.ChargeUser.Name = "ChargeUser";
            this.ChargeUser.ReadOnly = true;
            // 
            // UnChargeDate
            // 
            this.UnChargeDate.DataPropertyName = "UnChargeDate";
            this.UnChargeDate.HeaderText = "退费时间";
            this.UnChargeDate.Name = "UnChargeDate";
            this.UnChargeDate.ReadOnly = true;
            this.UnChargeDate.Width = 150;
            // 
            // UnChargeCost
            // 
            this.UnChargeCost.DataPropertyName = "UnChargeCost";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.NullValue = null;
            this.UnChargeCost.DefaultCellStyle = dataGridViewCellStyle22;
            this.UnChargeCost.HeaderText = "退费金额";
            this.UnChargeCost.Name = "UnChargeCost";
            this.UnChargeCost.ReadOnly = true;
            // 
            // UnChargeUser
            // 
            this.UnChargeUser.DataPropertyName = "UnChargeUser";
            this.UnChargeUser.HeaderText = "退费操作员";
            this.UnChargeUser.Name = "UnChargeUser";
            this.UnChargeUser.ReadOnly = true;
            // 
            // HANG_FLAG
            // 
            this.HANG_FLAG.DataPropertyName = "HANG_FLAG";
            this.HANG_FLAG.HeaderText = "HANG_FLAG";
            this.HANG_FLAG.Name = "HANG_FLAG";
            this.HANG_FLAG.ReadOnly = true;
            this.HANG_FLAG.Visible = false;
            // 
            // MEDITYPE
            // 
            this.MEDITYPE.DataPropertyName = "MEDITYPE";
            this.MEDITYPE.HeaderText = "MEDITYPE";
            this.MEDITYPE.Name = "MEDITYPE";
            this.MEDITYPE.ReadOnly = true;
            this.MEDITYPE.Visible = false;
            // 
            // lblSelfTally
            // 
            this.lblSelfTally.Location = new System.Drawing.Point( 342 , 43 );
            this.lblSelfTally.Name = "lblSelfTally";
            this.lblSelfTally.Size = new System.Drawing.Size( 51 , 12 );
            this.lblSelfTally.TabIndex = 17;
            this.lblSelfTally.Text = "0.00";
            this.lblSelfTally.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point( 265 , 43 );
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size( 77 , 12 );
            this.label17.TabIndex = 16;
            this.label17.Text = "个人单位记账";
            // 
            // lblTotalSelfTally
            // 
            this.lblTotalSelfTally.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblTotalSelfTally.Location = new System.Drawing.Point( 858 , 47 );
            this.lblTotalSelfTally.Name = "lblTotalSelfTally";
            this.lblTotalSelfTally.Size = new System.Drawing.Size( 80 , 15 );
            this.lblTotalSelfTally.TabIndex = 20;
            this.lblTotalSelfTally.Text = "888888.88";
            this.lblTotalSelfTally.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label19.Location = new System.Drawing.Point( 752 , 47 );
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size( 97 , 15 );
            this.label19.TabIndex = 19;
            this.label19.Text = "个人单位记账";
            // 
            // FrmInvoiceQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size( 1028 , 446 );
            this.FormTitle = "发票查询";
            this.Name = "FrmInvoiceQuery";
            this.Text = "FrmInvoiceQuery";
            this.Load += new System.EventHandler( this.FrmInvoiceQuery_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout( );
            this.plBaseStatus.ResumeLayout( false );
            this.plBaseStatus.PerformLayout( );
            this.plBaseWorkArea.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvList ) ).EndInit( );
            this.panel2.ResumeLayout( false );
            this.plInvoice.ResumeLayout( false );
            this.plInvoice.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInoviceItems ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgvList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private GWI.HIS.Windows.Controls.Button btnQuery;
        private GWI.HIS.Windows.Controls.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblActCost;
        private System.Windows.Forms.Label lblReturnCost;
        private System.Windows.Forms.Label lblReturnNum;
        private System.Windows.Forms.Label lblTotalNum;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.CheckBox chkall;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox cboInvoiceType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel plInvoice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvInoviceItems;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label lblFavor;
        private System.Windows.Forms.Label lblTally;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblPayType;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.LinkLabel lblClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCost;
        private System.Windows.Forms.LinkLabel lblPrint;
        private System.Windows.Forms.Label lblTotalFavor;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblTotalTally;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblTotalPOS;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblTotalCash;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboPatType;
        private System.Windows.Forms.CheckBox chkPayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISITNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn CASH;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TALLY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SELF_TALLY;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAVOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargeUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnChargeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnChargeCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnChargeUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn HANG_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDITYPE;
        private System.Windows.Forms.Label lblSelfTally;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblTotalSelfTally;
        private System.Windows.Forms.Label label19;
    }
}