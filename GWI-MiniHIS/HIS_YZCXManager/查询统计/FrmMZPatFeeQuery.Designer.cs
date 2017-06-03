namespace HIS_YZCXManager
{
    partial class FrmMZPatFeeQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMZPatFeeQuery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStat = new System.Windows.Forms.Button();
            this.dgvReport = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVisitNo = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPatName = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgrdFeeOrder = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIsUseTime = new System.Windows.Forms.CheckBox();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdFeeOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plBaseToolbar.Controls.Add(this.chkIsUseTime);
            this.plBaseToolbar.Controls.Add(this.label5);
            this.plBaseToolbar.Controls.Add(this.txtPatName);
            this.plBaseToolbar.Controls.Add(this.label3);
            this.plBaseToolbar.Controls.Add(this.txtVisitNo);
            this.plBaseToolbar.Controls.Add(this.label1);
            this.plBaseToolbar.Controls.Add(this.btnClose);
            this.plBaseToolbar.Controls.Add(this.btnStat);
            this.plBaseToolbar.Controls.Add(this.label6);
            this.plBaseToolbar.Controls.Add(this.dtpEnd);
            this.plBaseToolbar.Controls.Add(this.dtpFrom);
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 40);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 734);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 0);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel3);
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 74);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 660);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 34;
            this.label6.Text = "统计时间";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "";
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Location = new System.Drawing.Point(261, 7);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(126, 23);
            this.dtpEnd.TabIndex = 30;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "";
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Location = new System.Drawing.Point(102, 7);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(126, 23);
            this.dtpFrom.TabIndex = 29;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(925, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 25);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStat
            // 
            this.btnStat.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStat.Image = ((System.Drawing.Image)(resources.GetObject("btnStat.Image")));
            this.btnStat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStat.Location = new System.Drawing.Point(845, 6);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(79, 25);
            this.btnStat.TabIndex = 38;
            this.btnStat.Text = "查询(&F)";
            this.btnStat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvReport.AllowSortWhenClickColumnHeader = false;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.Location = new System.Drawing.Point(0, 0);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvReport.RowTemplate.Height = 23;
            this.dgvReport.SelectionCards = null;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(1016, 230);
            this.dgvReport.TabIndex = 0;
            this.dgvReport.UseGradientBackgroundColor = true;
            this.dgvReport.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReport_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 28);
            this.panel1.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDate.Location = new System.Drawing.Point(143, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(457, 28);
            this.lblDate.TabIndex = 1;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "本次统计时间范围：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvReport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 230);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 41;
            this.label1.Text = "就诊号码";
            // 
            // txtVisitNo
            // 
            this.txtVisitNo.AllowSelectedNullRow = false;
            this.txtVisitNo.DisplayField = "";
            this.txtVisitNo.Location = new System.Drawing.Point(498, 7);
            this.txtVisitNo.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtVisitNo.MemberField = "";
            this.txtVisitNo.MemberValue = null;
            this.txtVisitNo.Name = "txtVisitNo";
            this.txtVisitNo.NextControl = null;
            this.txtVisitNo.NextControlByEnter = false;
            this.txtVisitNo.OffsetX = 0;
            this.txtVisitNo.OffsetY = 0;
            this.txtVisitNo.QueryFields = null;
            this.txtVisitNo.SelectedValue = null;
            this.txtVisitNo.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtVisitNo.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtVisitNo.SelectionCardColumnHeaderHeight = 30;
            this.txtVisitNo.SelectionCardColumns = null;
            this.txtVisitNo.SelectionCardFont = null;
            this.txtVisitNo.SelectionCardHeight = 250;
            this.txtVisitNo.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtVisitNo.SelectionCardRowHeaderWidth = 35;
            this.txtVisitNo.SelectionCardRowHeight = 23;
            this.txtVisitNo.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtVisitNo.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtVisitNo.SelectionCardWidth = 250;
            this.txtVisitNo.ShowRowNumber = true;
            this.txtVisitNo.ShowSelectionCardAfterEnter = false;
            this.txtVisitNo.Size = new System.Drawing.Size(134, 23);
            this.txtVisitNo.TabIndex = 42;
            this.txtVisitNo.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 43;
            this.label3.Text = "病人姓名";
            // 
            // txtPatName
            // 
            this.txtPatName.AllowSelectedNullRow = false;
            this.txtPatName.DisplayField = "";
            this.txtPatName.Location = new System.Drawing.Point(707, 7);
            this.txtPatName.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtPatName.MemberField = "";
            this.txtPatName.MemberValue = null;
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.NextControl = null;
            this.txtPatName.NextControlByEnter = false;
            this.txtPatName.OffsetX = 0;
            this.txtPatName.OffsetY = 0;
            this.txtPatName.QueryFields = null;
            this.txtPatName.SelectedValue = null;
            this.txtPatName.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPatName.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtPatName.SelectionCardColumnHeaderHeight = 30;
            this.txtPatName.SelectionCardColumns = null;
            this.txtPatName.SelectionCardFont = null;
            this.txtPatName.SelectionCardHeight = 250;
            this.txtPatName.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtPatName.SelectionCardRowHeaderWidth = 35;
            this.txtPatName.SelectionCardRowHeight = 23;
            this.txtPatName.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtPatName.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtPatName.SelectionCardWidth = 250;
            this.txtPatName.ShowRowNumber = true;
            this.txtPatName.ShowSelectionCardAfterEnter = false;
            this.txtPatName.Size = new System.Drawing.Size(130, 23);
            this.txtPatName.TabIndex = 44;
            this.txtPatName.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 258);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1016, 402);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgrdFeeOrder);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(0, 26);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1016, 376);
            this.panel4.TabIndex = 1;
            // 
            // dgrdFeeOrder
            // 
            this.dgrdFeeOrder.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdFeeOrder.AllowSortWhenClickColumnHeader = false;
            this.dgrdFeeOrder.AllowUserToAddRows = false;
            this.dgrdFeeOrder.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdFeeOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgrdFeeOrder.ColumnHeadersHeight = 33;
            this.dgrdFeeOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgrdFeeOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdFeeOrder.EnableHeadersVisualStyles = false;
            this.dgrdFeeOrder.Location = new System.Drawing.Point(0, 0);
            this.dgrdFeeOrder.MultiSelect = false;
            this.dgrdFeeOrder.Name = "dgrdFeeOrder";
            this.dgrdFeeOrder.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdFeeOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgrdFeeOrder.RowTemplate.Height = 23;
            this.dgrdFeeOrder.SelectionCards = null;
            this.dgrdFeeOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdFeeOrder.Size = new System.Drawing.Size(1016, 376);
            this.dgrdFeeOrder.TabIndex = 0;
            this.dgrdFeeOrder.UseGradientBackgroundColor = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "ITEMNAME";
            this.Column1.HeaderText = "项目名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "STANDARD";
            this.Column2.HeaderText = "项目规格";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SELL_PRICE";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N3";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column3.HeaderText = "零售价格";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 75;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "BUY_PRICE";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N3";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column4.HeaderText = "批发价格";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 75;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TOLAL_FEE";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column5.HeaderText = "零售金额";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 75;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NUM";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column6.HeaderText = "数量";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 70;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "UNIT";
            this.Column7.HeaderText = "单位";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 45;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.DataPropertyName = "PRESDATE";
            this.Column8.HeaderText = "开方时间";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1016, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "费用明细";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 45;
            this.label5.Text = "到";
            // 
            // chkIsUseTime
            // 
            this.chkIsUseTime.AutoSize = true;
            this.chkIsUseTime.Location = new System.Drawing.Point(15, 11);
            this.chkIsUseTime.Name = "chkIsUseTime";
            this.chkIsUseTime.Size = new System.Drawing.Size(15, 14);
            this.chkIsUseTime.TabIndex = 46;
            this.chkIsUseTime.UseVisualStyleBackColor = true;
            this.chkIsUseTime.CheckedChanged += new System.EventHandler(this.chkIsUseTime_CheckedChanged);
            // 
            // FrmMZPatFeeQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmMZPatFeeQuery";
            this.Text = "FrmMZPatFeeQuery";
            this.Load += new System.EventHandler(this.FrmPatientFeeReport_Load);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdFeeOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStat;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvReport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private GWI.HIS.Windows.Controls.QueryTextBox txtVisitNo;
        private GWI.HIS.Windows.Controls.QueryTextBox txtPatName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdFeeOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsUseTime;
    }
}