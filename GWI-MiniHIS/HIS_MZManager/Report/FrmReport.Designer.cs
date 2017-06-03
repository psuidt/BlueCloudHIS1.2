namespace HIS_MZManager.Report
{
    partial class FrmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnStat = new System.Windows.Forms.Button();
            this.cboDateType = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStatType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvReport = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvTotalInfo = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.cboStyle = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.chkChargeTotalInfo = new System.Windows.Forms.CheckBox();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.chkChargeTotalInfo);
            this.plBaseToolbar.Controls.Add(this.chkPreview);
            this.plBaseToolbar.Controls.Add(this.btnExcel);
            this.plBaseToolbar.Controls.Add(this.cboStyle);
            this.plBaseToolbar.Controls.Add(this.label7);
            this.plBaseToolbar.Controls.Add(this.label6);
            this.plBaseToolbar.Controls.Add(this.dtpEnd);
            this.plBaseToolbar.Controls.Add(this.txtDay);
            this.plBaseToolbar.Controls.Add(this.dtpFrom);
            this.plBaseToolbar.Controls.Add(this.label5);
            this.plBaseToolbar.Controls.Add(this.btnClose);
            this.plBaseToolbar.Controls.Add(this.btnPrint);
            this.plBaseToolbar.Controls.Add(this.btnStat);
            this.plBaseToolbar.Controls.Add(this.cboDateType);
            this.plBaseToolbar.Controls.Add(this.label3);
            this.plBaseToolbar.Controls.Add(this.cboType);
            this.plBaseToolbar.Controls.Add(this.label2);
            this.plBaseToolbar.Controls.Add(this.cboStatType);
            this.plBaseToolbar.Controls.Add(this.label1);
            this.plBaseToolbar.Size = new System.Drawing.Size(923, 60);
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("baseImageList.ImageStream")));
            this.baseImageList.Images.SetKeyName(0, "table_delete.gif");
            this.baseImageList.Images.SetKeyName(1, "search_big.GIF");
            this.baseImageList.Images.SetKeyName(2, "Save.GIF");
            this.baseImageList.Images.SetKeyName(3, "Print.GIF");
            this.baseImageList.Images.SetKeyName(4, "page_user_dark.gif");
            this.baseImageList.Images.SetKeyName(5, "page_refresh.gif");
            this.baseImageList.Images.SetKeyName(6, "page_key.gif");
            this.baseImageList.Images.SetKeyName(7, "page_edit.gif");
            this.baseImageList.Images.SetKeyName(8, "page_cross.gif");
            this.baseImageList.Images.SetKeyName(9, "list_users.gif");
            this.baseImageList.Images.SetKeyName(10, "icon_package_get.gif");
            this.baseImageList.Images.SetKeyName(11, "icon_network.gif");
            this.baseImageList.Images.SetKeyName(12, "icon_history.gif");
            this.baseImageList.Images.SetKeyName(13, "icon_accept.gif");
            this.baseImageList.Images.SetKeyName(14, "folder_page.gif");
            this.baseImageList.Images.SetKeyName(15, "folder_new.gif");
            this.baseImageList.Images.SetKeyName(16, "Exit.GIF");
            this.baseImageList.Images.SetKeyName(17, "Delete.GIF");
            this.baseImageList.Images.SetKeyName(18, "copy.gif");
            this.baseImageList.Images.SetKeyName(19, "action_stop.gif");
            this.baseImageList.Images.SetKeyName(20, "action_refresh.gif");
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point(0, 471);
            this.plBaseStatus.Size = new System.Drawing.Size(923, 0);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 94);
            this.plBaseWorkArea.Size = new System.Drawing.Size(923, 377);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(790, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 23);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(644, 31);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(68, 23);
            this.btnPrint.TabIndex = 23;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnStat
            // 
            this.btnStat.Location = new System.Drawing.Point(571, 31);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(68, 23);
            this.btnStat.TabIndex = 22;
            this.btnStat.Text = "统计";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // cboDateType
            // 
            this.cboDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateType.FormattingEnabled = true;
            this.cboDateType.Location = new System.Drawing.Point(72, 7);
            this.cboDateType.Name = "cboDateType";
            this.cboDateType.Size = new System.Drawing.Size(130, 20);
            this.cboDateType.TabIndex = 21;
            this.cboDateType.SelectedIndexChanged += new System.EventHandler(this.cboDateType_SelectedIndexChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(419, 6);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(146, 21);
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(267, 6);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(146, 21);
            this.dtpFrom.TabIndex = 0;
            // 
            // txtDay
            // 
            this.txtDay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDay.Location = new System.Drawing.Point(645, 6);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.ReadOnly = true;
            this.txtDay.Size = new System.Drawing.Size(34, 21);
            this.txtDay.TabIndex = 1;
            this.txtDay.Text = "25";
            this.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(568, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "当前统计日:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "时段类型";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(267, 31);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(93, 20);
            this.cboType.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "类    别";
            // 
            // cboStatType
            // 
            this.cboStatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatType.FormattingEnabled = true;
            this.cboStatType.Location = new System.Drawing.Point(72, 32);
            this.cboStatType.Name = "cboStatType";
            this.cboStatType.Size = new System.Drawing.Size(130, 20);
            this.cboStatType.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "统计分类";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "统计时间";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 30);
            this.panel1.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Location = new System.Drawing.Point(729, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(194, 30);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDate.ForeColor = System.Drawing.Color.Blue;
            this.lblDate.Location = new System.Drawing.Point(102, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(627, 30);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "<未定>";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "统计时间范围";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(923, 347);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvReport);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(923, 233);
            this.panel4.TabIndex = 2;
            // 
            // dgvReport
            // 
            this.dgvReport.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvReport.AllowSortWhenClickColumnHeader = false;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReport.ColumnHeadersHeight = 30;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReport.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.HideSelectionCardWhenCustomInput = false;
            this.dgvReport.Location = new System.Drawing.Point(0, 0);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReport.RowTemplate.Height = 23;
            this.dgvReport.SelectionCards = null;
            this.dgvReport.Size = new System.Drawing.Size(923, 233);
            this.dgvReport.TabIndex = 0;
            this.dgvReport.UseGradientBackgroundColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvTotalInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 233);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(923, 114);
            this.panel3.TabIndex = 1;
            // 
            // dgvTotalInfo
            // 
            this.dgvTotalInfo.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvTotalInfo.AllowSortWhenClickColumnHeader = false;
            this.dgvTotalInfo.AllowUserToAddRows = false;
            this.dgvTotalInfo.AllowUserToDeleteRows = false;
            this.dgvTotalInfo.AllowUserToResizeRows = false;
            this.dgvTotalInfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTotalInfo.ColumnHeadersHeight = 30;
            this.dgvTotalInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTotalInfo.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotalInfo.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTotalInfo.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvTotalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTotalInfo.EnableHeadersVisualStyles = false;
            this.dgvTotalInfo.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTotalInfo.HideSelectionCardWhenCustomInput = false;
            this.dgvTotalInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvTotalInfo.Name = "dgvTotalInfo";
            this.dgvTotalInfo.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTotalInfo.RowHeadersVisible = false;
            this.dgvTotalInfo.RowTemplate.Height = 57;
            this.dgvTotalInfo.SelectionCards = null;
            this.dgvTotalInfo.Size = new System.Drawing.Size(923, 114);
            this.dgvTotalInfo.TabIndex = 3;
            this.dgvTotalInfo.UseGradientBackgroundColor = false;
            // 
            // cboStyle
            // 
            this.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStyle.FormattingEnabled = true;
            this.cboStyle.Location = new System.Drawing.Point(419, 31);
            this.cboStyle.Name = "cboStyle";
            this.cboStyle.Size = new System.Drawing.Size(146, 20);
            this.cboStyle.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(366, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "列标题";
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(717, 31);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(68, 23);
            this.btnExcel.TabIndex = 31;
            this.btnExcel.Text = "Excel输出";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // chkPreview
            // 
            this.chkPreview.AutoSize = true;
            this.chkPreview.Checked = true;
            this.chkPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreview.Location = new System.Drawing.Point(811, 8);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(84, 16);
            this.chkPreview.TabIndex = 32;
            this.chkPreview.Text = "打印前预览";
            this.chkPreview.UseVisualStyleBackColor = true;
            // 
            // chkChargeTotalInfo
            // 
            this.chkChargeTotalInfo.AutoSize = true;
            this.chkChargeTotalInfo.Location = new System.Drawing.Point(685, 9);
            this.chkChargeTotalInfo.Name = "chkChargeTotalInfo";
            this.chkChargeTotalInfo.Size = new System.Drawing.Size(120, 16);
            this.chkChargeTotalInfo.TabIndex = 33;
            this.chkChargeTotalInfo.Text = "生成支付方式合计";
            this.chkChargeTotalInfo.UseVisualStyleBackColor = true;
            this.chkChargeTotalInfo.CheckedChanged += new System.EventHandler(this.chkChargeTotalInfo_CheckedChanged);
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 471);
            this.Name = "FrmReport";
            this.Text = "FrmReport";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnStat;
        private System.Windows.Forms.ComboBox cboDateType;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStatType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDate;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvReport;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox cboStyle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.CheckBox chkChargeTotalInfo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvTotalInfo;
    }
}