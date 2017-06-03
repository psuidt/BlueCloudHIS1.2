namespace HIS_MZManager.Report
{
    partial class FrmPatientFeeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmPatientFeeReport ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDateType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPatType = new System.Windows.Forms.ComboBox();
            this.chkPatType = new System.Windows.Forms.CheckBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnStat = new System.Windows.Forms.Button();
            this.dgvReport = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.cboInvoiceType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pgb = new System.Windows.Forms.ProgressBar();
            this.lblDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.chkCureDoc = new System.Windows.Forms.CheckBox();
            this.cboDoc = new System.Windows.Forms.ComboBox();
            this.chkDept = new System.Windows.Forms.CheckBox();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.chkSfy = new System.Windows.Forms.CheckBox();
            this.cboCharge = new System.Windows.Forms.ComboBox();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvReport ) ).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add( this.chkSfy );
            this.plBaseToolbar.Controls.Add( this.cboCharge );
            this.plBaseToolbar.Controls.Add( this.chkDept );
            this.plBaseToolbar.Controls.Add( this.cboDept );
            this.plBaseToolbar.Controls.Add( this.chkCureDoc );
            this.plBaseToolbar.Controls.Add( this.cboDoc );
            this.plBaseToolbar.Controls.Add( this.chkPreview );
            this.plBaseToolbar.Controls.Add( this.label1 );
            this.plBaseToolbar.Controls.Add( this.cboInvoiceType );
            this.plBaseToolbar.Controls.Add( this.btnExcel );
            this.plBaseToolbar.Controls.Add( this.btnClose );
            this.plBaseToolbar.Controls.Add( this.btnPrint );
            this.plBaseToolbar.Controls.Add( this.btnStat );
            this.plBaseToolbar.Controls.Add( this.chkPatType );
            this.plBaseToolbar.Controls.Add( this.cboPatType );
            this.plBaseToolbar.Controls.Add( this.label6 );
            this.plBaseToolbar.Controls.Add( this.dtpEnd );
            this.plBaseToolbar.Controls.Add( this.txtDay );
            this.plBaseToolbar.Controls.Add( this.dtpFrom );
            this.plBaseToolbar.Controls.Add( this.label5 );
            this.plBaseToolbar.Controls.Add( this.cboDateType );
            this.plBaseToolbar.Controls.Add( this.label3 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 1024, 83 );
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
            this.plBaseStatus.Location = new System.Drawing.Point( 0, 463 );
            this.plBaseStatus.Size = new System.Drawing.Size( 1024, 0 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.panel2 );
            this.plBaseWorkArea.Controls.Add( this.panel1 );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0, 117 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 1024, 346 );
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size( 1024, 34 );
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 226, 9 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 53, 12 );
            this.label6.TabIndex = 34;
            this.label6.Text = "统计时间";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point( 437, 5 );
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size( 146, 21 );
            this.dtpEnd.TabIndex = 30;
            // 
            // txtDay
            // 
            this.txtDay.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            this.txtDay.Location = new System.Drawing.Point( 663, 5 );
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.ReadOnly = true;
            this.txtDay.Size = new System.Drawing.Size( 34, 21 );
            this.txtDay.TabIndex = 31;
            this.txtDay.Text = "25";
            this.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point( 280, 5 );
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size( 146, 21 );
            this.dtpFrom.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 586, 9 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 71, 12 );
            this.label5.TabIndex = 28;
            this.label5.Text = "当前统计日:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboDateType
            // 
            this.cboDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateType.FormattingEnabled = true;
            this.cboDateType.Location = new System.Drawing.Point( 90, 6 );
            this.cboDateType.Name = "cboDateType";
            this.cboDateType.Size = new System.Drawing.Size( 130, 20 );
            this.cboDateType.TabIndex = 33;
            this.cboDateType.SelectedIndexChanged += new System.EventHandler( this.cboDateType_SelectedIndexChanged );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 31, 9 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 53, 12 );
            this.label3.TabIndex = 32;
            this.label3.Text = "时段类型";
            // 
            // cboPatType
            // 
            this.cboPatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatType.Enabled = false;
            this.cboPatType.FormattingEnabled = true;
            this.cboPatType.Location = new System.Drawing.Point( 90, 30 );
            this.cboPatType.Name = "cboPatType";
            this.cboPatType.Size = new System.Drawing.Size( 130, 20 );
            this.cboPatType.TabIndex = 36;
            // 
            // chkPatType
            // 
            this.chkPatType.AutoSize = true;
            this.chkPatType.Location = new System.Drawing.Point( 12, 31 );
            this.chkPatType.Name = "chkPatType";
            this.chkPatType.Size = new System.Drawing.Size( 72, 16 );
            this.chkPatType.TabIndex = 37;
            this.chkPatType.Text = "病人类型";
            this.chkPatType.UseVisualStyleBackColor = true;
            this.chkPatType.CheckedChanged += new System.EventHandler( this.chkPatType_CheckedChanged );
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point( 763, 53 );
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size( 68, 23 );
            this.btnExcel.TabIndex = 41;
            this.btnExcel.Text = "Excel输出";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler( this.btnExcel_Click );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 839, 53 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 68, 23 );
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point( 687, 53 );
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size( 68, 23 );
            this.btnPrint.TabIndex = 39;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler( this.btnPrint_Click );
            // 
            // btnStat
            // 
            this.btnStat.Location = new System.Drawing.Point( 611, 53 );
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size( 68, 23 );
            this.btnStat.TabIndex = 38;
            this.btnStat.Text = "统计";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler( this.btnStat_Click );
            // 
            // dgvReport
            // 
            this.dgvReport.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvReport.AllowSortWhenClickColumnHeader = false;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle9.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.HideSelectionCardWhenCustomInput = false;
            this.dgvReport.Location = new System.Drawing.Point( 0, 0 );
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle10.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvReport.RowTemplate.Height = 23;
            this.dgvReport.SelectionCards = null;
            this.dgvReport.Size = new System.Drawing.Size( 1024, 320 );
            this.dgvReport.TabIndex = 0;
            this.dgvReport.UseGradientBackgroundColor = false;
            // 
            // cboInvoiceType
            // 
            this.cboInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInvoiceType.FormattingEnabled = true;
            this.cboInvoiceType.Location = new System.Drawing.Point( 762, 3 );
            this.cboInvoiceType.Name = "cboInvoiceType";
            this.cboInvoiceType.Size = new System.Drawing.Size( 146, 20 );
            this.cboInvoiceType.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 703, 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 53, 12 );
            this.label1.TabIndex = 44;
            this.label1.Text = "发票类型";
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.pgb );
            this.panel1.Controls.Add( this.lblDate );
            this.panel1.Controls.Add( this.label2 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 1024, 26 );
            this.panel1.TabIndex = 1;
            // 
            // pgb
            // 
            this.pgb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgb.Location = new System.Drawing.Point( 515, 0 );
            this.pgb.Name = "pgb";
            this.pgb.Size = new System.Drawing.Size( 509, 26 );
            this.pgb.TabIndex = 2;
            this.pgb.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDate.Location = new System.Drawing.Point( 123, 0 );
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size( 392, 26 );
            this.lblDate.TabIndex = 1;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point( 0, 0 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 123, 26 );
            this.label2.TabIndex = 0;
            this.label2.Text = "本次统计时间范围：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.dgvReport );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0, 26 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 1024, 320 );
            this.panel2.TabIndex = 2;
            // 
            // chkPreview
            // 
            this.chkPreview.AutoSize = true;
            this.chkPreview.Checked = true;
            this.chkPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreview.Location = new System.Drawing.Point( 521, 57 );
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size( 84, 16 );
            this.chkPreview.TabIndex = 45;
            this.chkPreview.Text = "打印前预览";
            this.chkPreview.UseVisualStyleBackColor = true;
            // 
            // chkCureDoc
            // 
            this.chkCureDoc.AutoSize = true;
            this.chkCureDoc.Location = new System.Drawing.Point( 226, 31 );
            this.chkCureDoc.Name = "chkCureDoc";
            this.chkCureDoc.Size = new System.Drawing.Size( 48, 16 );
            this.chkCureDoc.TabIndex = 47;
            this.chkCureDoc.Text = "医生";
            this.chkCureDoc.UseVisualStyleBackColor = true;
            this.chkCureDoc.CheckedChanged += new System.EventHandler( this.chkCureDoc_CheckedChanged );
            // 
            // cboDoc
            // 
            this.cboDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoc.Enabled = false;
            this.cboDoc.FormattingEnabled = true;
            this.cboDoc.Location = new System.Drawing.Point( 280, 30 );
            this.cboDoc.Name = "cboDoc";
            this.cboDoc.Size = new System.Drawing.Size( 146, 20 );
            this.cboDoc.TabIndex = 46;
            // 
            // chkDept
            // 
            this.chkDept.AutoSize = true;
            this.chkDept.Location = new System.Drawing.Point( 437, 31 );
            this.chkDept.Name = "chkDept";
            this.chkDept.Size = new System.Drawing.Size( 48, 16 );
            this.chkDept.TabIndex = 49;
            this.chkDept.Text = "科室";
            this.chkDept.UseVisualStyleBackColor = true;
            this.chkDept.CheckedChanged += new System.EventHandler( this.chkDept_CheckedChanged );
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.Enabled = false;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point( 491, 30 );
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size( 166, 20 );
            this.cboDept.TabIndex = 48;
            // 
            // chkSfy
            // 
            this.chkSfy.AutoSize = true;
            this.chkSfy.Location = new System.Drawing.Point( 682, 31 );
            this.chkSfy.Name = "chkSfy";
            this.chkSfy.Size = new System.Drawing.Size( 60, 16 );
            this.chkSfy.TabIndex = 51;
            this.chkSfy.Text = "收费员";
            this.chkSfy.UseVisualStyleBackColor = true;
            this.chkSfy.CheckedChanged += new System.EventHandler( this.chkSfy_CheckedChanged );
            // 
            // cboCharge
            // 
            this.cboCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCharge.Enabled = false;
            this.cboCharge.FormattingEnabled = true;
            this.cboCharge.Location = new System.Drawing.Point( 759, 30 );
            this.cboCharge.Name = "cboCharge";
            this.cboCharge.Size = new System.Drawing.Size( 149, 20 );
            this.cboCharge.TabIndex = 50;
            // 
            // FrmPatientFeeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 1024, 463 );
            this.Name = "FrmPatientFeeReport";
            this.Text = "FrmPatientFeeReport";
            this.Load += new System.EventHandler( this.FrmPatientFeeReport_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvReport ) ).EndInit();
            this.panel1.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDateType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkPatType;
        private System.Windows.Forms.ComboBox cboPatType;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnStat;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvReport;
        private System.Windows.Forms.ComboBox cboInvoiceType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pgb;
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.CheckBox chkSfy;
        private System.Windows.Forms.ComboBox cboCharge;
        private System.Windows.Forms.CheckBox chkDept;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.CheckBox chkCureDoc;
        private System.Windows.Forms.ComboBox cboDoc;
    }
}