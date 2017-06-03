namespace HIS_MZManager.Report
{
    partial class FrmIncomeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmIncomeReport ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.label1 = new System.Windows.Forms.Label( );
            this.cboStatType = new System.Windows.Forms.ComboBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.cboType = new System.Windows.Forms.ComboBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.cboYear = new System.Windows.Forms.ComboBox( );
            this.txtDay = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label5 = new System.Windows.Forms.Label( );
            this.cboMonth = new System.Windows.Forms.ComboBox( );
            this.label6 = new System.Windows.Forms.Label( );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.dtpEnd = new System.Windows.Forms.DateTimePicker( );
            this.dtpFrom = new System.Windows.Forms.DateTimePicker( );
            this.cboDateType = new System.Windows.Forms.ComboBox( );
            this.btnStat = new System.Windows.Forms.Button( );
            this.btnPrint = new System.Windows.Forms.Button( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.panel3 = new System.Windows.Forms.Panel( );
            this.lblDate = new System.Windows.Forms.Label( );
            this.panel4 = new System.Windows.Forms.Panel( );
            this.dgvReport = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.plBaseToolbar.SuspendLayout( );
            this.plBaseWorkArea.SuspendLayout( );
            this.panel2.SuspendLayout( );
            this.panel1.SuspendLayout( );
            this.panel3.SuspendLayout( );
            this.panel4.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvReport ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add( this.btnClose );
            this.plBaseToolbar.Controls.Add( this.btnPrint );
            this.plBaseToolbar.Controls.Add( this.btnStat );
            this.plBaseToolbar.Controls.Add( this.cboDateType );
            this.plBaseToolbar.Controls.Add( this.panel1 );
            this.plBaseToolbar.Controls.Add( this.panel2 );
            this.plBaseToolbar.Controls.Add( this.label3 );
            this.plBaseToolbar.Controls.Add( this.cboType );
            this.plBaseToolbar.Controls.Add( this.label2 );
            this.plBaseToolbar.Controls.Add( this.cboStatType );
            this.plBaseToolbar.Controls.Add( this.label1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 837 , 64 );
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
            this.plBaseStatus.Location = new System.Drawing.Point( 0 , 424 );
            this.plBaseStatus.Size = new System.Drawing.Size( 837 , 26 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.panel4 );
            this.plBaseWorkArea.Controls.Add( this.panel3 );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0 , 98 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 837 , 326 );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 8 , 39 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 53 , 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "统计分类";
            // 
            // cboStatType
            // 
            this.cboStatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatType.FormattingEnabled = true;
            this.cboStatType.Location = new System.Drawing.Point( 67 , 36 );
            this.cboStatType.Name = "cboStatType";
            this.cboStatType.Size = new System.Drawing.Size( 130 , 20 );
            this.cboStatType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 201 , 39 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 29 , 12 );
            this.label2.TabIndex = 2;
            this.label2.Text = "类别";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange( new object[] {
            "医生",
            "科室",
            "科室医生"} );
            this.cboType.Location = new System.Drawing.Point( 236 , 36 );
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size( 117 , 20 );
            this.cboType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 8 , 10 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 53 , 12 );
            this.label3.TabIndex = 4;
            this.label3.Text = "时段类型";
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.cboYear );
            this.panel2.Controls.Add( this.txtDay );
            this.panel2.Controls.Add( this.label4 );
            this.panel2.Controls.Add( this.label5 );
            this.panel2.Controls.Add( this.cboMonth );
            this.panel2.Controls.Add( this.label6 );
            this.panel2.Location = new System.Drawing.Point( 203 , 4 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 272 , 26 );
            this.panel2.TabIndex = 8;
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
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
            this.cboYear.Size = new System.Drawing.Size( 68 , 20 );
            this.cboYear.TabIndex = 1;
            // 
            // txtDay
            // 
            this.txtDay.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtDay.Location = new System.Drawing.Point( 228 , 3 );
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.ReadOnly = true;
            this.txtDay.Size = new System.Drawing.Size( 34 , 21 );
            this.txtDay.TabIndex = 1;
            this.txtDay.Text = "25";
            this.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 156 , 7 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 17 , 12 );
            this.label4.TabIndex = 3;
            this.label4.Text = "月";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 179 , 7 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 47 , 12 );
            this.label5.TabIndex = 0;
            this.label5.Text = "统计日:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
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
            this.cboMonth.Location = new System.Drawing.Point( 95 , 3 );
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size( 55 , 20 );
            this.cboMonth.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 74 , 7 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 17 , 12 );
            this.label6.TabIndex = 0;
            this.label6.Text = "年";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.dtpEnd );
            this.panel1.Controls.Add( this.dtpFrom );
            this.panel1.Location = new System.Drawing.Point( 481 , 4 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 352 , 26 );
            this.panel1.TabIndex = 9;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point( 179 , 3 );
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size( 170 , 21 );
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point( 3 , 3 );
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size( 170 , 21 );
            this.dtpFrom.TabIndex = 0;
            // 
            // cboDateType
            // 
            this.cboDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateType.FormattingEnabled = true;
            this.cboDateType.Location = new System.Drawing.Point( 67 , 7 );
            this.cboDateType.Name = "cboDateType";
            this.cboDateType.Size = new System.Drawing.Size( 130 , 20 );
            this.cboDateType.TabIndex = 10;
            this.cboDateType.SelectedIndexChanged += new System.EventHandler( this.cboDateType_SelectedIndexChanged );
            // 
            // btnStat
            // 
            this.btnStat.Location = new System.Drawing.Point( 361 , 35 );
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size( 75 , 23 );
            this.btnStat.TabIndex = 11;
            this.btnStat.Text = "统计";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler( this.btnStat_Click );
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point( 442 , 35 );
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size( 75 , 23 );
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler( this.btnPrint_Click );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 523 , 35 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75 , 23 );
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.lblDate );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point( 0 , 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 837 , 21 );
            this.panel3.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Location = new System.Drawing.Point( 0 , 0 );
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size( 837 , 21 );
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "<统计时间段>";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.dgvReport );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point( 0 , 21 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 837 , 305 );
            this.panel4.TabIndex = 1;
            // 
            // dgvReport
            // 
            this.dgvReport.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvReport.AllowSortWhenClickColumnHeader = false;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle4.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReport.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.Location = new System.Drawing.Point( 0 , 0 );
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle6.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReport.RowTemplate.Height = 23;
            this.dgvReport.SelectionCards = null;
            this.dgvReport.Size = new System.Drawing.Size( 837 , 305 );
            this.dgvReport.TabIndex = 0;
            this.dgvReport.UseGradientBackgroundColor = false;
            // 
            // FrmIncomeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 837 , 450 );
            this.Name = "FrmIncomeReport";
            this.Text = "FrmIncomeReport";
            this.Load += new System.EventHandler( this.FrmIncomeReport_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout( );
            this.plBaseWorkArea.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            this.panel2.PerformLayout( );
            this.panel1.ResumeLayout( false );
            this.panel3.ResumeLayout( false );
            this.panel4.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvReport ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ComboBox cboStatType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboDateType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnStat;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel4;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvReport;

    }
}