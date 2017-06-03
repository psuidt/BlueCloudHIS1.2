namespace HIS_YZCXManager
{
    partial class FrmDrugCheckQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDrugCheckQuery));
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new GWI.HIS.Windows.Controls.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtQueryCode = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cobType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cobEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cobBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgrdCheckOrder = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeCheckMaster = new System.Windows.Forms.TreeView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiffFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCheckOrder)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 0);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 706);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 28);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 34);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 672);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.txtQueryCode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cobType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cobEndDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cobBeginDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 40);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnClose.FixedWidth = false;
            this.btnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(859, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "退出(&C)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(778, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 25);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询(&F)";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.AllowSelectedNullRow = false;
            this.txtQueryCode.DisplayField = "CHEMNAME";
            this.txtQueryCode.Location = new System.Drawing.Point(616, 7);
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
            selectionCardColumn1.HeaderText = "名称";
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 75;
            selectionCardColumn2.AutoFill = true;
            selectionCardColumn2.DataBindField = "SPEC";
            selectionCardColumn2.HeaderText = "规格";
            selectionCardColumn2.IsSeachColumn = false;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 75;
            selectionCardColumn3.AutoFill = true;
            selectionCardColumn3.DataBindField = "PRODUCTNAME";
            selectionCardColumn3.HeaderText = "生产厂家";
            selectionCardColumn3.IsSeachColumn = false;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
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
            this.txtQueryCode.SelectionCardWidth = 350;
            this.txtQueryCode.ShowRowNumber = true;
            this.txtQueryCode.ShowSelectionCardAfterEnter = false;
            this.txtQueryCode.Size = new System.Drawing.Size(156, 23);
            this.txtQueryCode.TabIndex = 7;
            this.txtQueryCode.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtQueryCode.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txtQueryCode_AfterSelectedRow);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(540, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "查询代码:";
            // 
            // cobType
            // 
            this.cobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobType.FormattingEnabled = true;
            this.cobType.Items.AddRange(new object[] {
            "全部药品",
            "西药",
            "中成药",
            "中药",
            "医用物资"});
            this.cobType.Location = new System.Drawing.Point(432, 8);
            this.cobType.Name = "cobType";
            this.cobType.Size = new System.Drawing.Size(102, 21);
            this.cobType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "类型:";
            // 
            // cobEndDate
            // 
            this.cobEndDate.Location = new System.Drawing.Point(250, 7);
            this.cobEndDate.Name = "cobEndDate";
            this.cobEndDate.Size = new System.Drawing.Size(126, 23);
            this.cobEndDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "到";
            // 
            // cobBeginDate
            // 
            this.cobBeginDate.Location = new System.Drawing.Point(88, 7);
            this.cobBeginDate.Name = "cobBeginDate";
            this.cobBeginDate.Size = new System.Drawing.Size(128, 23);
            this.cobBeginDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询日期:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 632);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(374, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(642, 632);
            this.panel4.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(638, 628);
            this.panel6.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.dgrdCheckOrder);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel8.Location = new System.Drawing.Point(0, 23);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(638, 605);
            this.panel8.TabIndex = 1;
            // 
            // dgrdCheckOrder
            // 
            this.dgrdCheckOrder.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdCheckOrder.AllowSortWhenClickColumnHeader = false;
            this.dgrdCheckOrder.AllowUserToAddRows = false;
            this.dgrdCheckOrder.AllowUserToDeleteRows = false;
            this.dgrdCheckOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdCheckOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdCheckOrder.ColumnHeadersHeight = 30;
            this.dgrdCheckOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column10,
            this.DiffFee,
            this.Column8});
            this.dgrdCheckOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdCheckOrder.EnableHeadersVisualStyles = false;
            this.dgrdCheckOrder.Location = new System.Drawing.Point(0, 0);
            this.dgrdCheckOrder.MultiSelect = false;
            this.dgrdCheckOrder.Name = "dgrdCheckOrder";
            this.dgrdCheckOrder.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdCheckOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgrdCheckOrder.RowHeadersWidth = 30;
            this.dgrdCheckOrder.RowTemplate.Height = 23;
            this.dgrdCheckOrder.SelectionCards = null;
            this.dgrdCheckOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdCheckOrder.Size = new System.Drawing.Size(634, 601);
            this.dgrdCheckOrder.TabIndex = 0;
            this.dgrdCheckOrder.UseGradientBackgroundColor = true;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(638, 23);
            this.panel7.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(636, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "明细信息";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.treeCheckMaster);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 632);
            this.panel3.TabIndex = 0;
            // 
            // treeCheckMaster
            // 
            this.treeCheckMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCheckMaster.Location = new System.Drawing.Point(0, 0);
            this.treeCheckMaster.Name = "treeCheckMaster";
            this.treeCheckMaster.Size = new System.Drawing.Size(370, 628);
            this.treeCheckMaster.TabIndex = 0;
            this.treeCheckMaster.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeCheckMaster_NodeMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CHEMNAME";
            this.dataGridViewTextBoxColumn1.HeaderText = "化学名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SPEC";
            this.dataGridViewTextBoxColumn2.HeaderText = "规格";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PRODUCTNAME";
            this.dataGridViewTextBoxColumn3.HeaderText = "生产厂家";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "FACTNUM";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "帐存数量";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 45;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CHECKNUM";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "盘存数量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 45;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "FTRETAILFEE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column6.HeaderText = "账存金额";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 60;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "CKRETAILFEE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.Column10.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column10.HeaderText = "盘存金额";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 60;
            // 
            // DiffFee
            // 
            this.DiffFee.DataPropertyName = "DIFFFEE";
            dataGridViewCellStyle6.Format = "N2";
            this.DiffFee.DefaultCellStyle = dataGridViewCellStyle6;
            this.DiffFee.HeaderText = "帐盘差额";
            this.DiffFee.Name = "DiffFee";
            this.DiffFee.ReadOnly = true;
            this.DiffFee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiffFee.Width = 60;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "UNITNAME";
            this.Column8.HeaderText = "单位";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 35;
            // 
            // FrmDrugCheckQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "药品盘赢/亏查询";
            this.Name = "FrmDrugCheckQuery";
            this.Text = "药品盘赢/亏查询";
            this.Load += new System.EventHandler(this.FrmDrugCheckQuery_Load);
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCheckOrder)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker cobBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cobType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker cobEndDate;
        private GWI.HIS.Windows.Controls.QueryTextBox txtQueryCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel8;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdCheckOrder;
        private System.Windows.Forms.Panel panel7;
        private GWI.HIS.Windows.Controls.Button btnClose;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView treeCheckMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiffFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}