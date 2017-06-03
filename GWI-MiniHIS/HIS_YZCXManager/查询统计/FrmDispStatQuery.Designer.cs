namespace HIS_YZCXManager
{
    partial class FrmDispStatQuery : GWI.HIS.Windows.Controls.BaseMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDispStatQuery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cobBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cobEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cobDrugType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cobStatType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQueryCode = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.radMZStat = new System.Windows.Forms.RadioButton();
            this.radZYStat = new System.Windows.Forms.RadioButton();
            this.btnQuit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgrdDispMaster = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRJID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMaster = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgrdDispOrder = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblOrder = new System.Windows.Forms.Label();
            this.grpQuery = new System.Windows.Forms.GroupBox();
            this.radQYStat = new System.Windows.Forms.RadioButton();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkIsRefund = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblTotalFee = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseStatus.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDispMaster)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDispOrder)).BeginInit();
            this.panel5.SuspendLayout();
            this.grpQuery.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.grpQuery);
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 73);
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
            this.plBaseStatus.Controls.Add(this.label6);
            this.plBaseStatus.Controls.Add(this.lblTotalFee);
            this.plBaseStatus.Location = new System.Drawing.Point(0, 708);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.BackColor = System.Drawing.Color.White;
            this.plBaseWorkArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plBaseWorkArea.Controls.Add(this.splitContainer1);
            this.plBaseWorkArea.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 107);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 601);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "发药时间:";
            // 
            // cobBeginDate
            // 
            this.cobBeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.cobBeginDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cobBeginDate.Location = new System.Drawing.Point(77, 46);
            this.cobBeginDate.Name = "cobBeginDate";
            this.cobBeginDate.Size = new System.Drawing.Size(153, 21);
            this.cobBeginDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(236, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "到";
            // 
            // cobEndDate
            // 
            this.cobEndDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.cobEndDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cobEndDate.Location = new System.Drawing.Point(259, 45);
            this.cobEndDate.Name = "cobEndDate";
            this.cobEndDate.Size = new System.Drawing.Size(150, 21);
            this.cobEndDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(216, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "药品类型";
            // 
            // cobDrugType
            // 
            this.cobDrugType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobDrugType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobDrugType.FormattingEnabled = true;
            this.cobDrugType.Items.AddRange(new object[] {
            "西药",
            "中成药",
            "中草药",
            "物资",
            "全部药品"});
            this.cobDrugType.Location = new System.Drawing.Point(275, 21);
            this.cobDrugType.Name = "cobDrugType";
            this.cobDrugType.Size = new System.Drawing.Size(92, 20);
            this.cobDrugType.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(373, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "统计方式";
            // 
            // cobStatType
            // 
            this.cobStatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobStatType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobStatType.FormattingEnabled = true;
            this.cobStatType.Items.AddRange(new object[] {
            "按单个药品汇总",
            "按药剂科室汇总",
            "按生产厂家汇总",
            "按开方科室汇总"});
            this.cobStatType.Location = new System.Drawing.Point(432, 20);
            this.cobStatType.Name = "cobStatType";
            this.cobStatType.Size = new System.Drawing.Size(146, 20);
            this.cobStatType.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "查询代码:";
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.AllowSelectedNullRow = false;
            this.txtQueryCode.DisplayField = "CHEMNAME";
            this.txtQueryCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQueryCode.Location = new System.Drawing.Point(77, 21);
            this.txtQueryCode.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtQueryCode.MemberField = "MAKERDICID";
            this.txtQueryCode.MemberValue = null;
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.NextControl = this.btnQuery;
            this.txtQueryCode.NextControlByEnter = true;
            this.txtQueryCode.OffsetX = 0;
            this.txtQueryCode.OffsetY = 0;
            this.txtQueryCode.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.txtQueryCode.SelectedValue = null;
            this.txtQueryCode.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtQueryCode.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtQueryCode.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn1.AutoFill = true;
            selectionCardColumn1.DataBindField = "BYNAME";
            selectionCardColumn1.HeaderText = "别名";
            selectionCardColumn1.IsNameField = false;
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 75;
            selectionCardColumn2.AutoFill = true;
            selectionCardColumn2.DataBindField = "SPEC";
            selectionCardColumn2.HeaderText = "规格";
            selectionCardColumn2.IsNameField = false;
            selectionCardColumn2.IsSeachColumn = false;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 75;
            selectionCardColumn3.AutoFill = true;
            selectionCardColumn3.DataBindField = "PRODUCTNAME";
            selectionCardColumn3.HeaderText = "生产厂家";
            selectionCardColumn3.IsNameField = false;
            selectionCardColumn3.IsSeachColumn = false;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            selectionCardColumn3.Visiable = true;
            selectionCardColumn3.Width = 75;
            this.txtQueryCode.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2,
        selectionCardColumn3};
            this.txtQueryCode.SelectionCardFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQueryCode.SelectionCardHeight = 250;
            this.txtQueryCode.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtQueryCode.SelectionCardRowHeaderWidth = 35;
            this.txtQueryCode.SelectionCardRowHeight = 23;
            this.txtQueryCode.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtQueryCode.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.txtQueryCode.SelectionCardWidth = 400;
            this.txtQueryCode.ShowRowNumber = true;
            this.txtQueryCode.ShowSelectionCardAfterEnter = false;
            this.txtQueryCode.Size = new System.Drawing.Size(133, 21);
            this.txtQueryCode.TabIndex = 10;
            this.txtQueryCode.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtQueryCode.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txtQueryCode_AfterSelectedRow);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(730, 42);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(76, 27);
            this.btnQuery.TabIndex = 14;
            this.btnQuery.Text = "查询(&F)";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // radMZStat
            // 
            this.radMZStat.AutoSize = true;
            this.radMZStat.Checked = true;
            this.radMZStat.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radMZStat.Location = new System.Drawing.Point(417, 48);
            this.radMZStat.Name = "radMZStat";
            this.radMZStat.Size = new System.Drawing.Size(95, 16);
            this.radMZStat.TabIndex = 12;
            this.radMZStat.TabStop = true;
            this.radMZStat.Text = "门诊销量统计";
            this.radMZStat.UseVisualStyleBackColor = true;
            this.radMZStat.CheckedChanged += new System.EventHandler(this.radMZStat_CheckedChanged);
            // 
            // radZYStat
            // 
            this.radZYStat.AutoSize = true;
            this.radZYStat.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radZYStat.Location = new System.Drawing.Point(518, 47);
            this.radZYStat.Name = "radZYStat";
            this.radZYStat.Size = new System.Drawing.Size(95, 16);
            this.radZYStat.TabIndex = 13;
            this.radZYStat.Text = "住院销量统计";
            this.radZYStat.UseVisualStyleBackColor = true;
            this.radZYStat.CheckedChanged += new System.EventHandler(this.radZYStat_CheckedChanged);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.Location = new System.Drawing.Point(899, 43);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(76, 27);
            this.btnQuit.TabIndex = 16;
            this.btnQuit.Text = "退出(&C)";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 597);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgrdDispMaster);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(244, 560);
            this.panel4.TabIndex = 1;
            // 
            // dgrdDispMaster
            // 
            this.dgrdDispMaster.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdDispMaster.AllowSortWhenClickColumnHeader = true;
            this.dgrdDispMaster.AllowUserToAddRows = false;
            this.dgrdDispMaster.AllowUserToDeleteRows = false;
            this.dgrdDispMaster.AllowUserToResizeColumns = false;
            this.dgrdDispMaster.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDispMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdDispMaster.ColumnHeadersHeight = 30;
            this.dgrdDispMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column2,
            this.PRJID,
            this.Column10,
            this.Column11});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdDispMaster.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdDispMaster.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgrdDispMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdDispMaster.EnableHeadersVisualStyles = false;
            this.dgrdDispMaster.HideSelectionCardWhenCustomInput = false;
            this.dgrdDispMaster.Location = new System.Drawing.Point(0, 0);
            this.dgrdDispMaster.MultiSelect = false;
            this.dgrdDispMaster.Name = "dgrdDispMaster";
            this.dgrdDispMaster.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDispMaster.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrdDispMaster.RowHeadersVisible = false;
            this.dgrdDispMaster.RowHeadersWidth = 30;
            this.dgrdDispMaster.RowTemplate.Height = 23;
            this.dgrdDispMaster.SelectionCards = null;
            this.dgrdDispMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdDispMaster.Size = new System.Drawing.Size(244, 560);
            this.dgrdDispMaster.TabIndex = 0;
            this.dgrdDispMaster.UseGradientBackgroundColor = false;
            this.dgrdDispMaster.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgrdDispMaster_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "PRJNAME";
            this.Column1.HeaderText = "项目";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "TOTALNUM";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column9.HeaderText = "数量";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 55;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PRJFEE";
            dataGridViewCellStyle3.Format = "N2";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "零售金额";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // PRJID
            // 
            this.PRJID.DataPropertyName = "PRJID";
            this.PRJID.HeaderText = "项目编号";
            this.PRJID.Name = "PRJID";
            this.PRJID.ReadOnly = true;
            this.PRJID.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "productname";
            this.Column10.HeaderText = "生产产家";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "spec";
            this.Column11.HeaderText = "规格";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblMaster);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 37);
            this.panel3.TabIndex = 0;
            // 
            // lblMaster
            // 
            this.lblMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaster.Font = new System.Drawing.Font("楷体_GB2312", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMaster.Location = new System.Drawing.Point(0, 0);
            this.lblMaster.Name = "lblMaster";
            this.lblMaster.Size = new System.Drawing.Size(244, 37);
            this.lblMaster.TabIndex = 0;
            this.lblMaster.Text = "汇总信息";
            this.lblMaster.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 597);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgrdDispOrder);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 37);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(764, 560);
            this.panel6.TabIndex = 1;
            // 
            // dgrdDispOrder
            // 
            this.dgrdDispOrder.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdDispOrder.AllowSortWhenClickColumnHeader = true;
            this.dgrdDispOrder.AllowUserToAddRows = false;
            this.dgrdDispOrder.AllowUserToDeleteRows = false;
            this.dgrdDispOrder.AllowUserToResizeRows = false;
            this.dgrdDispOrder.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDispOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdDispOrder.ColumnHeadersHeight = 30;
            this.dgrdDispOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.dataGridViewTextBoxColumn3});
            this.dgrdDispOrder.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgrdDispOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdDispOrder.EnableHeadersVisualStyles = false;
            this.dgrdDispOrder.HideSelectionCardWhenCustomInput = false;
            this.dgrdDispOrder.Location = new System.Drawing.Point(0, 0);
            this.dgrdDispOrder.MultiSelect = false;
            this.dgrdDispOrder.Name = "dgrdDispOrder";
            this.dgrdDispOrder.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDispOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgrdDispOrder.RowHeadersVisible = false;
            this.dgrdDispOrder.RowTemplate.Height = 23;
            this.dgrdDispOrder.SelectionCards = null;
            this.dgrdDispOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdDispOrder.Size = new System.Drawing.Size(764, 560);
            this.dgrdDispOrder.TabIndex = 0;
            this.dgrdDispOrder.UseGradientBackgroundColor = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CHEMNAME";
            this.dataGridViewTextBoxColumn1.HeaderText = "化学名";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SPEC";
            this.dataGridViewTextBoxColumn2.HeaderText = "规格";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "PRODUCTNAME";
            this.Column3.HeaderText = "生产厂家";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DEBITNUM";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column4.HeaderText = "数量";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 55;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "UNITNAME";
            this.Column5.HeaderText = "单位";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 35;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DEBITFEE";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column6.HeaderText = "零售金额";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "PATIENTNAME";
            this.Column7.HeaderText = "病人姓名";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 60;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "INVOICENUM";
            this.Column8.HeaderText = "发票号";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "REGTIME";
            this.dataGridViewTextBoxColumn3.HeaderText = "发药时间";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblOrder);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(764, 37);
            this.panel5.TabIndex = 0;
            // 
            // lblOrder
            // 
            this.lblOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblOrder.Font = new System.Drawing.Font("楷体_GB2312", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOrder.Location = new System.Drawing.Point(0, 0);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(764, 37);
            this.lblOrder.TabIndex = 0;
            this.lblOrder.Text = "药品销售明细信息";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpQuery
            // 
            this.grpQuery.Controls.Add(this.radQYStat);
            this.grpQuery.Controls.Add(this.btnExport);
            this.grpQuery.Controls.Add(this.chkIsRefund);
            this.grpQuery.Controls.Add(this.cobEndDate);
            this.grpQuery.Controls.Add(this.cobStatType);
            this.grpQuery.Controls.Add(this.label4);
            this.grpQuery.Controls.Add(this.btnQuit);
            this.grpQuery.Controls.Add(this.label1);
            this.grpQuery.Controls.Add(this.btnQuery);
            this.grpQuery.Controls.Add(this.cobBeginDate);
            this.grpQuery.Controls.Add(this.label2);
            this.grpQuery.Controls.Add(this.radZYStat);
            this.grpQuery.Controls.Add(this.cobDrugType);
            this.grpQuery.Controls.Add(this.label3);
            this.grpQuery.Controls.Add(this.label5);
            this.grpQuery.Controls.Add(this.radMZStat);
            this.grpQuery.Controls.Add(this.txtQueryCode);
            this.grpQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpQuery.Location = new System.Drawing.Point(0, 0);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Size = new System.Drawing.Size(1016, 73);
            this.grpQuery.TabIndex = 17;
            this.grpQuery.TabStop = false;
            this.grpQuery.Text = "查询条件";
            // 
            // radQYStat
            // 
            this.radQYStat.AutoSize = true;
            this.radQYStat.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radQYStat.Location = new System.Drawing.Point(615, 46);
            this.radQYStat.Name = "radQYStat";
            this.radQYStat.Size = new System.Drawing.Size(95, 16);
            this.radQYStat.TabIndex = 19;
            this.radQYStat.Text = "全院销量统计";
            this.radQYStat.UseVisualStyleBackColor = true;
            this.radQYStat.CheckedChanged += new System.EventHandler(this.radQYStat_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(812, 42);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(81, 27);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "导出(Excel)";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkIsRefund
            // 
            this.chkIsRefund.AutoSize = true;
            this.chkIsRefund.Location = new System.Drawing.Point(584, 22);
            this.chkIsRefund.Name = "chkIsRefund";
            this.chkIsRefund.Size = new System.Drawing.Size(48, 16);
            this.chkIsRefund.TabIndex = 17;
            this.chkIsRefund.Text = "退药";
            this.chkIsRefund.UseVisualStyleBackColor = true;
            this.chkIsRefund.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1012, 597);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 2;
            // 
            // lblTotalFee
            // 
            this.lblTotalFee.AutoSize = true;
            this.lblTotalFee.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalFee.Location = new System.Drawing.Point(123, 6);
            this.lblTotalFee.Name = "lblTotalFee";
            this.lblTotalFee.Size = new System.Drawing.Size(79, 14);
            this.lblTotalFee.TabIndex = 0;
            this.lblTotalFee.Text = "$$$$$$$$$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "合计零售金额:";
            // 
            // FrmDispStatQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "药品销量统计";
            this.Name = "FrmDispStatQuery";
            this.Text = "药品销量统计";
            this.Load += new System.EventHandler(this.FrmDispStatQuery_Load);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseStatus.ResumeLayout(false);
            this.plBaseStatus.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDispMaster)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDispOrder)).EndInit();
            this.panel5.ResumeLayout(false);
            this.grpQuery.ResumeLayout(false);
            this.grpQuery.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cobDrugType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker cobEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker cobBeginDate;
        private System.Windows.Forms.Label label1;
        private GWI.HIS.Windows.Controls.QueryTextBox txtQueryCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cobStatType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.RadioButton radZYStat;
        private System.Windows.Forms.RadioButton radMZStat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdDispOrder;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdDispMaster;
        private System.Windows.Forms.GroupBox grpQuery;
        private System.Windows.Forms.Label lblMaster;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkIsRefund;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalFee;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRJID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.RadioButton radQYStat;
    }
}