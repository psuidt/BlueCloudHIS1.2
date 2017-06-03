namespace HIS_YPManager
{
    partial class FrmDrugDept
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDrugDept));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgrdDeptOP = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnStopUse = new System.Windows.Forms.Button();
            this.btnUse = new System.Windows.Forms.Button();
            this.lblBeUse = new System.Windows.Forms.Label();
            this.lblUseState = new System.Windows.Forms.Label();
            this.grpAddDept = new System.Windows.Forms.GroupBox();
            this.chkShowTradePrice = new System.Windows.Forms.CheckBox();
            this.txtQueryCode = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.radWZ = new System.Windows.Forms.RadioButton();
            this.radYK = new System.Windows.Forms.RadioButton();
            this.radYF = new System.Windows.Forms.RadioButton();
            this.lblQueryCode = new System.Windows.Forms.Label();
            this.lblDeptName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgrdDeptInfo = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPTTYPE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plBaseWorkArea.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDeptOP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpAddDept.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDeptInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Size = new System.Drawing.Size(1014, 0);
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
            this.plBaseStatus.Size = new System.Drawing.Size(1014, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 34);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1014, 672);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.grpAddDept);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 672);
            this.panel2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgrdDeptOP);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox4.Location = new System.Drawing.Point(346, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(666, 513);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "系统业务参数";
            // 
            // dgrdDeptOP
            // 
            this.dgrdDeptOP.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdDeptOP.AllowSortWhenClickColumnHeader = false;
            this.dgrdDeptOP.AllowUserToAddRows = false;
            this.dgrdDeptOP.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDeptOP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdDeptOP.ColumnHeadersHeight = 35;
            this.dgrdDeptOP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdDeptOP.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdDeptOP.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgrdDeptOP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdDeptOP.EnableHeadersVisualStyles = false;
            this.dgrdDeptOP.HideSelectionCardWhenCustomInput = false;
            this.dgrdDeptOP.Location = new System.Drawing.Point(3, 17);
            this.dgrdDeptOP.Name = "dgrdDeptOP";
            this.dgrdDeptOP.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDeptOP.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrdDeptOP.RowTemplate.Height = 23;
            this.dgrdDeptOP.SelectionCards = null;
            this.dgrdDeptOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdDeptOP.Size = new System.Drawing.Size(660, 493);
            this.dgrdDeptOP.TabIndex = 7;
            this.dgrdDeptOP.UseGradientBackgroundColor = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "OPTYPE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "业务编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "BILLNUM";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "当前单据号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 150;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "TYPENAME";
            this.Column2.HeaderText = "业务名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQuit);
            this.groupBox1.Controls.Add(this.btnStopUse);
            this.groupBox1.Controls.Add(this.btnUse);
            this.groupBox1.Controls.Add(this.lblBeUse);
            this.groupBox1.Controls.Add(this.lblUseState);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(346, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 64);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "启用科室";
            // 
            // btnQuit
            // 
            this.btnQuit.AutoSize = true;
            this.btnQuit.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.Location = new System.Drawing.Point(428, 16);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(94, 34);
            this.btnQuit.TabIndex = 11;
            this.btnQuit.Text = "关闭(&C)";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnStopUse
            // 
            this.btnStopUse.AutoSize = true;
            this.btnStopUse.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopUse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStopUse.Image = ((System.Drawing.Image)(resources.GetObject("btnStopUse.Image")));
            this.btnStopUse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopUse.Location = new System.Drawing.Point(328, 16);
            this.btnStopUse.Name = "btnStopUse";
            this.btnStopUse.Size = new System.Drawing.Size(94, 34);
            this.btnStopUse.TabIndex = 10;
            this.btnStopUse.Text = "停用科室";
            this.btnStopUse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopUse.UseVisualStyleBackColor = true;
            this.btnStopUse.Click += new System.EventHandler(this.btnStopUse_Click);
            // 
            // btnUse
            // 
            this.btnUse.AutoSize = true;
            this.btnUse.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUse.Image = ((System.Drawing.Image)(resources.GetObject("btnUse.Image")));
            this.btnUse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUse.Location = new System.Drawing.Point(228, 16);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(94, 34);
            this.btnUse.TabIndex = 9;
            this.btnUse.Text = "启用科室";
            this.btnUse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // lblBeUse
            // 
            this.lblBeUse.AutoSize = true;
            this.lblBeUse.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBeUse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBeUse.Location = new System.Drawing.Point(7, 26);
            this.lblBeUse.Name = "lblBeUse";
            this.lblBeUse.Size = new System.Drawing.Size(97, 15);
            this.lblBeUse.TabIndex = 7;
            this.lblBeUse.Text = "当前启用状态";
            // 
            // lblUseState
            // 
            this.lblUseState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUseState.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUseState.Location = new System.Drawing.Point(110, 22);
            this.lblUseState.Name = "lblUseState";
            this.lblUseState.Size = new System.Drawing.Size(100, 23);
            this.lblUseState.TabIndex = 8;
            this.lblUseState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpAddDept
            // 
            this.grpAddDept.Controls.Add(this.chkShowTradePrice);
            this.grpAddDept.Controls.Add(this.txtQueryCode);
            this.grpAddDept.Controls.Add(this.btnDel);
            this.grpAddDept.Controls.Add(this.btnAdd);
            this.grpAddDept.Controls.Add(this.radWZ);
            this.grpAddDept.Controls.Add(this.radYK);
            this.grpAddDept.Controls.Add(this.radYF);
            this.grpAddDept.Controls.Add(this.lblQueryCode);
            this.grpAddDept.Controls.Add(this.lblDeptName);
            this.grpAddDept.Controls.Add(this.label1);
            this.grpAddDept.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAddDept.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpAddDept.Location = new System.Drawing.Point(346, 0);
            this.grpAddDept.Name = "grpAddDept";
            this.grpAddDept.Size = new System.Drawing.Size(666, 93);
            this.grpAddDept.TabIndex = 0;
            this.grpAddDept.TabStop = false;
            this.grpAddDept.Text = "添加科室";
            // 
            // chkShowTradePrice
            // 
            this.chkShowTradePrice.AutoSize = true;
            this.chkShowTradePrice.Location = new System.Drawing.Point(15, 59);
            this.chkShowTradePrice.Name = "chkShowTradePrice";
            this.chkShowTradePrice.Size = new System.Drawing.Size(124, 18);
            this.chkShowTradePrice.TabIndex = 14;
            this.chkShowTradePrice.Text = "药房显示批发价";
            this.chkShowTradePrice.UseVisualStyleBackColor = true;
            this.chkShowTradePrice.CheckedChanged += new System.EventHandler(this.chkShowTradePrice_CheckedChanged);
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.AllowSelectedNullRow = false;
            this.txtQueryCode.DisplayField = "NAME";
            this.txtQueryCode.Location = new System.Drawing.Point(83, 23);
            this.txtQueryCode.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtQueryCode.MemberField = "DEPT_ID";
            this.txtQueryCode.MemberValue = null;
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.NextControl = null;
            this.txtQueryCode.NextControlByEnter = false;
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
            selectionCardColumn1.DataBindField = "NAME";
            selectionCardColumn1.HeaderText = "科室名称";
            selectionCardColumn1.IsNameField = false;
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 75;
            this.txtQueryCode.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1};
            this.txtQueryCode.SelectionCardFont = null;
            this.txtQueryCode.SelectionCardHeight = 250;
            this.txtQueryCode.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtQueryCode.SelectionCardRowHeaderWidth = 35;
            this.txtQueryCode.SelectionCardRowHeight = 23;
            this.txtQueryCode.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtQueryCode.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.txtQueryCode.SelectionCardWidth = 250;
            this.txtQueryCode.ShowRowNumber = true;
            this.txtQueryCode.ShowSelectionCardAfterEnter = false;
            this.txtQueryCode.Size = new System.Drawing.Size(100, 23);
            this.txtQueryCode.TabIndex = 13;
            this.txtQueryCode.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtQueryCode.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txtQueryCode_AfterSelectedRow);
            // 
            // btnDel
            // 
            this.btnDel.AutoSize = true;
            this.btnDel.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(509, 52);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(94, 34);
            this.btnDel.TabIndex = 12;
            this.btnDel.Text = "删除科室";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(409, 52);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 34);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "增加科室";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // radWZ
            // 
            this.radWZ.AutoSize = true;
            this.radWZ.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radWZ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radWZ.Location = new System.Drawing.Point(529, 25);
            this.radWZ.Name = "radWZ";
            this.radWZ.Size = new System.Drawing.Size(70, 19);
            this.radWZ.TabIndex = 6;
            this.radWZ.TabStop = true;
            this.radWZ.Text = "物资库";
            this.radWZ.UseVisualStyleBackColor = true;
            this.radWZ.CheckedChanged += new System.EventHandler(this.radWZ_CheckedChanged);
            // 
            // radYK
            // 
            this.radYK.AutoSize = true;
            this.radYK.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radYK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radYK.Location = new System.Drawing.Point(465, 25);
            this.radYK.Name = "radYK";
            this.radYK.Size = new System.Drawing.Size(55, 19);
            this.radYK.TabIndex = 5;
            this.radYK.TabStop = true;
            this.radYK.Text = "药库";
            this.radYK.UseVisualStyleBackColor = true;
            this.radYK.CheckedChanged += new System.EventHandler(this.radYK_CheckedChanged);
            // 
            // radYF
            // 
            this.radYF.AutoSize = true;
            this.radYF.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radYF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radYF.Location = new System.Drawing.Point(401, 25);
            this.radYF.Name = "radYF";
            this.radYF.Size = new System.Drawing.Size(55, 19);
            this.radYF.TabIndex = 4;
            this.radYF.TabStop = true;
            this.radYF.Text = "药房";
            this.radYF.UseVisualStyleBackColor = true;
            this.radYF.CheckedChanged += new System.EventHandler(this.radYF_CheckedChanged);
            // 
            // lblQueryCode
            // 
            this.lblQueryCode.AutoSize = true;
            this.lblQueryCode.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQueryCode.Location = new System.Drawing.Point(6, 26);
            this.lblQueryCode.Name = "lblQueryCode";
            this.lblQueryCode.Size = new System.Drawing.Size(71, 15);
            this.lblQueryCode.TabIndex = 2;
            this.lblQueryCode.Text = "查找科室";
            // 
            // lblDeptName
            // 
            this.lblDeptName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDeptName.Enabled = false;
            this.lblDeptName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDeptName.Location = new System.Drawing.Point(262, 23);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(121, 23);
            this.lblDeptName.TabIndex = 1;
            this.lblDeptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(189, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室名称";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(346, 670);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgrdDeptInfo);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 668);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "当前药剂科室";
            // 
            // dgrdDeptInfo
            // 
            this.dgrdDeptInfo.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdDeptInfo.AllowSortWhenClickColumnHeader = false;
            this.dgrdDeptInfo.AllowUserToAddRows = false;
            this.dgrdDeptInfo.AllowUserToResizeRows = false;
            this.dgrdDeptInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDeptInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdDeptInfo.ColumnHeadersHeight = 35;
            this.dgrdDeptInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column5,
            this.DEPTTYPE1,
            this.Column7});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdDeptInfo.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdDeptInfo.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgrdDeptInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdDeptInfo.EnableHeadersVisualStyles = false;
            this.dgrdDeptInfo.HideSelectionCardWhenCustomInput = false;
            this.dgrdDeptInfo.Location = new System.Drawing.Point(3, 17);
            this.dgrdDeptInfo.MultiSelect = false;
            this.dgrdDeptInfo.Name = "dgrdDeptInfo";
            this.dgrdDeptInfo.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDeptInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgrdDeptInfo.RowHeadersVisible = false;
            this.dgrdDeptInfo.RowTemplate.Height = 23;
            this.dgrdDeptInfo.SelectionCards = null;
            this.dgrdDeptInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdDeptInfo.Size = new System.Drawing.Size(338, 648);
            this.dgrdDeptInfo.TabIndex = 7;
            this.dgrdDeptInfo.UseGradientBackgroundColor = true;
            this.dgrdDeptInfo.CurrentCellChanged += new System.EventHandler(this.dgrdDeptInfo_CurrentCellChanged_1);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DEPTDICID";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column3.HeaderText = "编号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 50;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "DEPTNAME";
            this.Column5.HeaderText = "名称";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DEPTTYPE1
            // 
            this.DEPTTYPE1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DEPTTYPE1.DataPropertyName = "DEPTTYPE1";
            this.DEPTTYPE1.HeaderText = "业务类型";
            this.DEPTTYPE1.Name = "DEPTTYPE1";
            this.DEPTTYPE1.ReadOnly = true;
            this.DEPTTYPE1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "USE_FLAG";
            this.Column7.HeaderText = "启用标识";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 40;
            // 
            // FrmDrugDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 732);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "药剂科室设置";
            this.Name = "FrmDrugDept";
            this.Text = "药剂科室设置";
            this.Load += new System.EventHandler(this.FrmDrugDept_Load);
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDeptOP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpAddDept.ResumeLayout(false);
            this.grpAddDept.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDeptInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpAddDept;
        private System.Windows.Forms.Label lblDeptName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radWZ;
        private System.Windows.Forms.RadioButton radYK;
        private System.Windows.Forms.RadioButton radYF;
        private System.Windows.Forms.Label lblQueryCode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblUseState;
        private System.Windows.Forms.Label lblBeUse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStopUse;
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnQuit;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdDeptOP;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdDeptInfo;
        private GWI.HIS.Windows.Controls.QueryTextBox txtQueryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPTTYPE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.CheckBox chkShowTradePrice;
    }
}