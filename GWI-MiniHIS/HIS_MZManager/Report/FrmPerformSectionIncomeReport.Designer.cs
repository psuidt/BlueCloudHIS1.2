namespace HIS_MZManager.Report
{
    partial class FrmPerformSectionIncomeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmPerformSectionIncomeReport ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.label6 = new System.Windows.Forms.Label( );
            this.dtpEnd = new System.Windows.Forms.DateTimePicker( );
            this.dtpFrom = new System.Windows.Forms.DateTimePicker( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.btnPrint = new System.Windows.Forms.Button( );
            this.btnStat = new System.Windows.Forms.Button( );
            this.dgvResult = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.COL_DEPT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.COL_DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.COL_ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.COL_STATNAME = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.COL_FPNAME = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.COL_TOTAL_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.COL_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.COL_SUB_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.chkOffice = new System.Windows.Forms.CheckBox( );
            this.chkStatItem = new System.Windows.Forms.CheckBox( );
            this.cboOffice = new System.Windows.Forms.ComboBox( );
            this.cboStatItem = new System.Windows.Forms.ComboBox( );
            this.plBaseToolbar.SuspendLayout( );
            this.plBaseWorkArea.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvResult ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add( this.cboStatItem );
            this.plBaseToolbar.Controls.Add( this.cboOffice );
            this.plBaseToolbar.Controls.Add( this.chkStatItem );
            this.plBaseToolbar.Controls.Add( this.chkOffice );
            this.plBaseToolbar.Controls.Add( this.label6 );
            this.plBaseToolbar.Controls.Add( this.dtpEnd );
            this.plBaseToolbar.Controls.Add( this.dtpFrom );
            this.plBaseToolbar.Controls.Add( this.btnClose );
            this.plBaseToolbar.Controls.Add( this.btnPrint );
            this.plBaseToolbar.Controls.Add( this.btnStat );
            this.plBaseToolbar.Size = new System.Drawing.Size( 928 , 59 );
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
            this.plBaseStatus.Size = new System.Drawing.Size( 928 , 26 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.dgvResult );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0 , 93 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 928 , 300 );
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 11 , 12 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 53 , 12 );
            this.label6.TabIndex = 37;
            this.label6.Text = "统计时间";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point( 222 , 8 );
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size( 146 , 21 );
            this.dtpEnd.TabIndex = 33;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point( 70 , 8 );
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size( 146 , 21 );
            this.dtpFrom.TabIndex = 32;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 521 , 7 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 68 , 23 );
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point( 447 , 7 );
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size( 68 , 23 );
            this.btnPrint.TabIndex = 35;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler( this.btnPrint_Click );
            // 
            // btnStat
            // 
            this.btnStat.Location = new System.Drawing.Point( 374 , 7 );
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size( 68 , 23 );
            this.btnStat.TabIndex = 34;
            this.btnStat.Text = "统计";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler( this.btnStat_Click );
            // 
            // dgvResult
            // 
            this.dgvResult.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvResult.AllowSortWhenClickColumnHeader = false;
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToOrderColumns = true;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle5.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvResult.ColumnHeadersHeight = 30;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvResult.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_DEPT_ID,
            this.COL_DEPT_NAME,
            this.COL_ITEM_NAME,
            this.COL_STATNAME,
            this.COL_FPNAME,
            this.COL_TOTAL_FEE,
            this.COL_COUNT,
            this.COL_SUB_FLAG} );
            this.dgvResult.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.EnableHeadersVisualStyles = false;
            this.dgvResult.HideSelectionCardWhenCustomInput = false;
            this.dgvResult.Location = new System.Drawing.Point( 0 , 0 );
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle8.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionCards = null;
            this.dgvResult.Size = new System.Drawing.Size( 928 , 300 );
            this.dgvResult.TabIndex = 0;
            this.dgvResult.UseGradientBackgroundColor = false;
            // 
            // COL_DEPT_ID
            // 
            this.COL_DEPT_ID.DataPropertyName = "EXECDEPTCODE";
            this.COL_DEPT_ID.HeaderText = "科室ID";
            this.COL_DEPT_ID.Name = "COL_DEPT_ID";
            this.COL_DEPT_ID.ReadOnly = true;
            this.COL_DEPT_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_DEPT_ID.Visible = false;
            // 
            // COL_DEPT_NAME
            // 
            this.COL_DEPT_NAME.DataPropertyName = "DEPT_NAME";
            this.COL_DEPT_NAME.HeaderText = "执行科室";
            this.COL_DEPT_NAME.Name = "COL_DEPT_NAME";
            this.COL_DEPT_NAME.ReadOnly = true;
            this.COL_DEPT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_DEPT_NAME.Width = 150;
            // 
            // COL_ITEM_NAME
            // 
            this.COL_ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.COL_ITEM_NAME.DataPropertyName = "ITEMNAME";
            this.COL_ITEM_NAME.HeaderText = "项目名称";
            this.COL_ITEM_NAME.Name = "COL_ITEM_NAME";
            this.COL_ITEM_NAME.ReadOnly = true;
            this.COL_ITEM_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_STATNAME
            // 
            this.COL_STATNAME.DataPropertyName = "STATNAME";
            this.COL_STATNAME.HeaderText = "统计分类";
            this.COL_STATNAME.Name = "COL_STATNAME";
            this.COL_STATNAME.ReadOnly = true;
            this.COL_STATNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_STATNAME.Width = 120;
            // 
            // COL_FPNAME
            // 
            this.COL_FPNAME.DataPropertyName = "FPNAME";
            this.COL_FPNAME.HeaderText = "发票科目";
            this.COL_FPNAME.Name = "COL_FPNAME";
            this.COL_FPNAME.ReadOnly = true;
            this.COL_FPNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_FPNAME.Width = 120;
            // 
            // COL_TOTAL_FEE
            // 
            this.COL_TOTAL_FEE.DataPropertyName = "TOTAL_FEE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.COL_TOTAL_FEE.DefaultCellStyle = dataGridViewCellStyle6;
            this.COL_TOTAL_FEE.HeaderText = "金额";
            this.COL_TOTAL_FEE.Name = "COL_TOTAL_FEE";
            this.COL_TOTAL_FEE.ReadOnly = true;
            this.COL_TOTAL_FEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_TOTAL_FEE.Width = 150;
            // 
            // COL_COUNT
            // 
            this.COL_COUNT.DataPropertyName = "COUNT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.COL_COUNT.DefaultCellStyle = dataGridViewCellStyle7;
            this.COL_COUNT.HeaderText = "人次";
            this.COL_COUNT.Name = "COL_COUNT";
            this.COL_COUNT.ReadOnly = true;
            this.COL_COUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_SUB_FLAG
            // 
            this.COL_SUB_FLAG.DataPropertyName = "SUB_FLAG";
            this.COL_SUB_FLAG.HeaderText = "SUB_FLAG";
            this.COL_SUB_FLAG.Name = "COL_SUB_FLAG";
            this.COL_SUB_FLAG.ReadOnly = true;
            this.COL_SUB_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_SUB_FLAG.Visible = false;
            // 
            // chkOffice
            // 
            this.chkOffice.AutoSize = true;
            this.chkOffice.Location = new System.Drawing.Point( 13 , 35 );
            this.chkOffice.Name = "chkOffice";
            this.chkOffice.Size = new System.Drawing.Size( 72 , 16 );
            this.chkOffice.TabIndex = 40;
            this.chkOffice.Text = "执行科室";
            this.chkOffice.UseVisualStyleBackColor = true;
            this.chkOffice.CheckedChanged += new System.EventHandler( this.CheckBox_CheckedChanged );
            // 
            // chkStatItem
            // 
            this.chkStatItem.AutoSize = true;
            this.chkStatItem.Location = new System.Drawing.Point( 222 , 35 );
            this.chkStatItem.Name = "chkStatItem";
            this.chkStatItem.Size = new System.Drawing.Size( 72 , 16 );
            this.chkStatItem.TabIndex = 42;
            this.chkStatItem.Text = "统计分类";
            this.chkStatItem.UseVisualStyleBackColor = true;
            this.chkStatItem.CheckedChanged += new System.EventHandler( this.CheckBox_CheckedChanged );
            // 
            // cboOffice
            // 
            this.cboOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOffice.Enabled = false;
            this.cboOffice.FormattingEnabled = true;
            this.cboOffice.Location = new System.Drawing.Point( 91 , 33 );
            this.cboOffice.MaxDropDownItems = 32;
            this.cboOffice.Name = "cboOffice";
            this.cboOffice.Size = new System.Drawing.Size( 125 , 20 );
            this.cboOffice.TabIndex = 44;
            // 
            // cboStatItem
            // 
            this.cboStatItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatItem.Enabled = false;
            this.cboStatItem.FormattingEnabled = true;
            this.cboStatItem.Location = new System.Drawing.Point( 300 , 33 );
            this.cboStatItem.MaxDropDownItems = 32;
            this.cboStatItem.Name = "cboStatItem";
            this.cboStatItem.Size = new System.Drawing.Size( 121 , 20 );
            this.cboStatItem.TabIndex = 46;
            // 
            // FrmPerformSectionIncomeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 928 , 419 );
            this.Name = "FrmPerformSectionIncomeReport";
            this.Text = "FrmPerformSectionIncomeReport";
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout( );
            this.plBaseWorkArea.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvResult ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnStat;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_DEPT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_STATNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_FPNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_TOTAL_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SUB_FLAG;
        private System.Windows.Forms.CheckBox chkOffice;
        private System.Windows.Forms.CheckBox chkStatItem;
        private System.Windows.Forms.ComboBox cboStatItem;
        private System.Windows.Forms.ComboBox cboOffice;
    }
}