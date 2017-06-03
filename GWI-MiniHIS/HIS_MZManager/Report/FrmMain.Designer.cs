namespace HIS_MZManager.Report
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmMain ) );
            this.imgToolbar = new System.Windows.Forms.ImageList( this.components );
            this.cboYear = new System.Windows.Forms.ComboBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.panel4 = new System.Windows.Forms.Panel( );
            this.lblDate = new System.Windows.Forms.Label( );
            this.panel5 = new System.Windows.Forms.Panel( );
            this.panel3 = new System.Windows.Forms.Panel( );
            this.label5 = new System.Windows.Forms.Label( );
            this.dtpTo = new System.Windows.Forms.DateTimePicker( );
            this.dtpFrom = new System.Windows.Forms.DateTimePicker( );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.txtDay = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.cboMonth = new System.Windows.Forms.ComboBox( );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.label4 = new System.Windows.Forms.Label( );
            this.cboStatDateType = new System.Windows.Forms.ComboBox( );
            this.plGrid = new System.Windows.Forms.Panel( );
            this.dgvReport = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.lblInfo = new System.Windows.Forms.Label( );
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip( );
            this.btnCreateReport = new System.Windows.Forms.ToolStripButton( );
            this.btnView = new System.Windows.Forms.ToolStripButton( );
            this.btnPrint = new System.Windows.Forms.ToolStripButton( );
            this.btnSetting = new System.Windows.Forms.ToolStripButton( );
            this.btnClose = new System.Windows.Forms.ToolStripButton( );
            this.plBaseToolbar.SuspendLayout( );
            this.plBaseStatus.SuspendLayout( );
            this.plBaseWorkArea.SuspendLayout( );
            this.panel4.SuspendLayout( );
            this.panel5.SuspendLayout( );
            this.panel3.SuspendLayout( );
            this.panel2.SuspendLayout( );
            this.panel1.SuspendLayout( );
            this.plGrid.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvReport ) ).BeginInit( );
            this.toolStrip1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add( this.toolStrip1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 840 , 31 );
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
            this.plBaseStatus.Controls.Add( this.lblInfo );
            this.plBaseStatus.Location = new System.Drawing.Point( 0 , 474 );
            this.plBaseStatus.Size = new System.Drawing.Size( 840 , 52 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.plGrid );
            this.plBaseWorkArea.Controls.Add( this.panel4 );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0 , 65 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 840 , 409 );
            // 
            // imgToolbar
            // 
            this.imgToolbar.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imgToolbar.ImageStream" ) ) );
            this.imgToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgToolbar.Images.SetKeyName( 0 , "NOTE11.ICO" );
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Items.AddRange( new object[] {
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"} );
            this.cboYear.Location = new System.Drawing.Point( 3 , 3 );
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size( 68 , 24 );
            this.cboYear.TabIndex = 1;
            this.cboYear.SelectedIndexChanged += new System.EventHandler( this.cboYear_SelectedIndexChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 77 , 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 17 , 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "年";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.lblDate );
            this.panel4.Controls.Add( this.panel5 );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point( 0 , 0 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 840 , 40 );
            this.panel4.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblDate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDate.Location = new System.Drawing.Point( 593 , 0 );
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size( 247 , 40 );
            this.lblDate.TabIndex = 0;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add( this.panel3 );
            this.panel5.Controls.Add( this.panel2 );
            this.panel5.Controls.Add( this.panel1 );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point( 0 , 0 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 593 , 40 );
            this.panel5.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.label5 );
            this.panel3.Controls.Add( this.dtpTo );
            this.panel3.Controls.Add( this.dtpFrom );
            this.panel3.Location = new System.Drawing.Point( 180 , 39 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 405 , 31 );
            this.panel3.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 190 , 9 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 11 , 12 );
            this.label5.TabIndex = 2;
            this.label5.Text = "-";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpTo.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point( 207 , 3 );
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size( 179 , 26 );
            this.dtpTo.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFrom.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point( 3 , 3 );
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size( 181 , 26 );
            this.dtpFrom.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.cboYear );
            this.panel2.Controls.Add( this.txtDay );
            this.panel2.Controls.Add( this.label2 );
            this.panel2.Controls.Add( this.label3 );
            this.panel2.Controls.Add( this.cboMonth );
            this.panel2.Controls.Add( this.label1 );
            this.panel2.Location = new System.Drawing.Point( 196 , 1 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 324 , 33 );
            this.panel2.TabIndex = 7;
            // 
            // txtDay
            // 
            this.txtDay.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtDay.Location = new System.Drawing.Point( 228 , 3 );
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.ReadOnly = true;
            this.txtDay.Size = new System.Drawing.Size( 34 , 26 );
            this.txtDay.TabIndex = 1;
            this.txtDay.Text = "25";
            this.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 156 , 9 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 17 , 12 );
            this.label2.TabIndex = 3;
            this.label2.Text = "月";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 179 , 9 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 47 , 12 );
            this.label3.TabIndex = 0;
            this.label3.Text = "统计日:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange( new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"} );
            this.cboMonth.Location = new System.Drawing.Point( 100 , 3 );
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size( 55 , 24 );
            this.cboMonth.TabIndex = 2;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler( this.cboMonth_SelectedIndexChanged );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.label4 );
            this.panel1.Controls.Add( this.cboStatDateType );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 190 , 36 );
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 3 , 10 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 53 , 12 );
            this.label4.TabIndex = 4;
            this.label4.Text = "时段类型";
            // 
            // cboStatDateType
            // 
            this.cboStatDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatDateType.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.cboStatDateType.FormattingEnabled = true;
            this.cboStatDateType.Location = new System.Drawing.Point( 75 , 4 );
            this.cboStatDateType.Name = "cboStatDateType";
            this.cboStatDateType.Size = new System.Drawing.Size( 109 , 24 );
            this.cboStatDateType.TabIndex = 5;
            this.cboStatDateType.SelectedIndexChanged += new System.EventHandler( this.cboStatDateType_SelectedIndexChanged );
            // 
            // plGrid
            // 
            this.plGrid.Controls.Add( this.dgvReport );
            this.plGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plGrid.Location = new System.Drawing.Point( 0 , 40 );
            this.plGrid.Name = "plGrid";
            this.plGrid.Size = new System.Drawing.Size( 840 , 369 );
            this.plGrid.TabIndex = 5;
            // 
            // dgvReport
            // 
            this.dgvReport.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvReport.AllowSortWhenClickColumnHeader = false;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AllowUserToResizeRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReport.ColumnHeadersHeight = 30;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReport.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.Location = new System.Drawing.Point( 0 , 0 );
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReport.RowTemplate.Height = 23;
            this.dgvReport.SelectionCards = null;
            this.dgvReport.Size = new System.Drawing.Size( 840 , 369 );
            this.dgvReport.TabIndex = 0;
            this.dgvReport.UseGradientBackgroundColor = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Font = new System.Drawing.Font( "宋体" , 10F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo.Location = new System.Drawing.Point( 0 , 0 );
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size( 840 , 52 );
            this.lblInfo.TabIndex = 0;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip1.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "toolStrip1.BackgroundImage" ) ) );
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font( "宋体" , 10F );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateReport,
            this.btnView,
            this.btnPrint,
            this.btnSetting,
            this.btnClose} );
            this.toolStrip1.Location = new System.Drawing.Point( 0 , 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size( 840 , 31 );
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCreateReport
            // 
            this.btnCreateReport.Image = global::HIS_MZManager.Properties.Resources.page_refresh;
            this.btnCreateReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateReport.Name = "btnCreateReport";
            this.btnCreateReport.Size = new System.Drawing.Size( 104 , 28 );
            this.btnCreateReport.Text = "生成报表(&O)";
            this.btnCreateReport.Click += new System.EventHandler( this.btnCreateReport_Click );
            // 
            // btnView
            // 
            this.btnView.Image = global::HIS_MZManager.Properties.Resources.搜索;
            this.btnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size( 76 , 28 );
            this.btnView.Text = "预览(&V)";
            this.btnView.Click += new System.EventHandler( this.btnView_Click );
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::HIS_MZManager.Properties.Resources.打印;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size( 76 , 28 );
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler( this.btnPrint_Click );
            // 
            // btnSetting
            // 
            this.btnSetting.Image = global::HIS_MZManager.Properties.Resources.菜单设置;
            this.btnSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size( 76 , 28 );
            this.btnSetting.Text = "设置(&T)";
            this.btnSetting.Click += new System.EventHandler( this.btnSetting_Click );
            // 
            // btnClose
            // 
            this.btnClose.Image = global::HIS_MZManager.Properties.Resources.退出;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 76 , 28 );
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size( 840 , 526 );
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler( this.FrmMain_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout( );
            this.plBaseStatus.ResumeLayout( false );
            this.plBaseWorkArea.ResumeLayout( false );
            this.panel4.ResumeLayout( false );
            this.panel5.ResumeLayout( false );
            this.panel3.ResumeLayout( false );
            this.panel3.PerformLayout( );
            this.panel2.ResumeLayout( false );
            this.panel2.PerformLayout( );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout( );
            this.plGrid.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvReport ) ).EndInit( );
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ImageList imgToolbar;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plGrid;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.ComboBox cboStatDateType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInfo;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCreateReport;
        private System.Windows.Forms.ToolStripButton btnView;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnSetting;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvReport;
    }
}

