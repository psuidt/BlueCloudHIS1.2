namespace HIS_YPManager
{
    partial class FrmSupportDic
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSupportDic));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsrSupport = new GWI.HIS.Windows.Controls.ToolStrip();
            this.tsrbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnDel = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnQuit = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtLinkPhone = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtLinkName = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtSupportAddress = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtSupportName = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.lblLinkPhone = new System.Windows.Forms.Label();
            this.lblLinkName = new System.Windows.Forms.Label();
            this.lblSupportAddress = new System.Windows.Forms.Label();
            this.lblSupportName = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgrdSupport = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yPSupportDicBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsrbtnCancel = new System.Windows.Forms.ToolStripButton();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.tsrSupport.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdSupport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPSupportDicBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add(this.tsrSupport);
            this.plBaseToolbar.Size = new System.Drawing.Size(792, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 540);
            this.plBaseStatus.Size = new System.Drawing.Size(792, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel4);
            this.plBaseWorkArea.Controls.Add(this.panel3);
            this.plBaseWorkArea.Size = new System.Drawing.Size(792, 477);
            // 
            // tsrSupport
            // 
            this.tsrSupport.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsrSupport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsrSupport.BackgroundImage")));
            this.tsrSupport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsrSupport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsrSupport.Font = new System.Drawing.Font("宋体", 10F);
            this.tsrSupport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsrbtnAdd,
            this.tsrbtnUpdate,
            this.tsrbtnDel,
            this.tsrbtnSave,
            this.tsrbtnCancel,
            this.tsrbtnQuit});
            this.tsrSupport.Location = new System.Drawing.Point(0, 0);
            this.tsrSupport.Name = "tsrSupport";
            this.tsrSupport.Size = new System.Drawing.Size(792, 29);
            this.tsrSupport.TabIndex = 0;
            this.tsrSupport.Text = "tsrSupport";
            // 
            // tsrbtnAdd
            // 
            this.tsrbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnAdd.Image")));
            this.tsrbtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnAdd.Name = "tsrbtnAdd";
            this.tsrbtnAdd.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnAdd.Text = "添加(F2)";
            this.tsrbtnAdd.Click += new System.EventHandler(this.tsrbtnAdd_Click);
            // 
            // tsrbtnUpdate
            // 
            this.tsrbtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnUpdate.Image")));
            this.tsrbtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnUpdate.Name = "tsrbtnUpdate";
            this.tsrbtnUpdate.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnUpdate.Text = "修改(F3)";
            this.tsrbtnUpdate.Click += new System.EventHandler(this.tsrbtnUpdate_Click);
            // 
            // tsrbtnDel
            // 
            this.tsrbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnDel.Image")));
            this.tsrbtnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnDel.Name = "tsrbtnDel";
            this.tsrbtnDel.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnDel.Text = "删除(F4)";
            this.tsrbtnDel.Click += new System.EventHandler(this.tsrbtnDel_Click);
            // 
            // tsrbtnSave
            // 
            this.tsrbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnSave.Image")));
            this.tsrbtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnSave.Name = "tsrbtnSave";
            this.tsrbtnSave.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnSave.Text = "保存(F5)";
            this.tsrbtnSave.Click += new System.EventHandler(this.tsrbtnSave_Click);
            // 
            // tsrbtnQuit
            // 
            this.tsrbtnQuit.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnQuit.Image")));
            this.tsrbtnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnQuit.Name = "tsrbtnQuit";
            this.tsrbtnQuit.Size = new System.Drawing.Size(76, 26);
            this.tsrbtnQuit.Text = "关闭(&C)";
            this.tsrbtnQuit.Click += new System.EventHandler(this.tsrbtnQuit_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtLinkPhone);
            this.panel3.Controls.Add(this.txtLinkName);
            this.panel3.Controls.Add(this.txtSupportAddress);
            this.panel3.Controls.Add(this.txtSupportName);
            this.panel3.Controls.Add(this.txtQuery);
            this.panel3.Controls.Add(this.lblQuery);
            this.panel3.Controls.Add(this.lblLinkPhone);
            this.panel3.Controls.Add(this.lblLinkName);
            this.panel3.Controls.Add(this.lblSupportAddress);
            this.panel3.Controls.Add(this.lblSupportName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 68);
            this.panel3.TabIndex = 0;
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.AllowSelectedNullRow = false;
            this.txtLinkPhone.BackColor = System.Drawing.Color.White;
            this.txtLinkPhone.DisplayField = "";
            this.txtLinkPhone.Location = new System.Drawing.Point(569, 34);
            this.txtLinkPhone.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtLinkPhone.MaxLength = 20;
            this.txtLinkPhone.MemberField = "";
            this.txtLinkPhone.MemberValue = null;
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.NextControl = null;
            this.txtLinkPhone.NextControlByEnter = false;
            this.txtLinkPhone.OffsetX = 0;
            this.txtLinkPhone.OffsetY = 0;
            this.txtLinkPhone.QueryFields = null;
            this.txtLinkPhone.SelectedValue = null;
            this.txtLinkPhone.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLinkPhone.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtLinkPhone.SelectionCardColumnHeaderHeight = 30;
            this.txtLinkPhone.SelectionCardColumns = null;
            this.txtLinkPhone.SelectionCardFont = null;
            this.txtLinkPhone.SelectionCardHeight = 250;
            this.txtLinkPhone.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtLinkPhone.SelectionCardRowHeaderWidth = 35;
            this.txtLinkPhone.SelectionCardRowHeight = 23;
            this.txtLinkPhone.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtLinkPhone.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtLinkPhone.SelectionCardWidth = 250;
            this.txtLinkPhone.ShowRowNumber = true;
            this.txtLinkPhone.ShowSelectionCardAfterEnter = false;
            this.txtLinkPhone.Size = new System.Drawing.Size(209, 23);
            this.txtLinkPhone.TabIndex = 13;
            this.txtLinkPhone.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtLinkPhone.TextChanged += new System.EventHandler(this.txtLinkPhone_TextChanged);
            this.txtLinkPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLinkPhone_KeyPress);
            // 
            // txtLinkName
            // 
            this.txtLinkName.AllowSelectedNullRow = false;
            this.txtLinkName.BackColor = System.Drawing.Color.White;
            this.txtLinkName.DisplayField = "";
            this.txtLinkName.Location = new System.Drawing.Point(274, 34);
            this.txtLinkName.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtLinkName.MaxLength = 10;
            this.txtLinkName.MemberField = "";
            this.txtLinkName.MemberValue = null;
            this.txtLinkName.Name = "txtLinkName";
            this.txtLinkName.NextControl = this.txtLinkPhone;
            this.txtLinkName.NextControlByEnter = true;
            this.txtLinkName.OffsetX = 0;
            this.txtLinkName.OffsetY = 0;
            this.txtLinkName.QueryFields = null;
            this.txtLinkName.SelectedValue = null;
            this.txtLinkName.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLinkName.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtLinkName.SelectionCardColumnHeaderHeight = 30;
            this.txtLinkName.SelectionCardColumns = null;
            this.txtLinkName.SelectionCardFont = null;
            this.txtLinkName.SelectionCardHeight = 250;
            this.txtLinkName.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtLinkName.SelectionCardRowHeaderWidth = 35;
            this.txtLinkName.SelectionCardRowHeight = 23;
            this.txtLinkName.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtLinkName.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtLinkName.SelectionCardWidth = 250;
            this.txtLinkName.ShowRowNumber = true;
            this.txtLinkName.ShowSelectionCardAfterEnter = false;
            this.txtLinkName.Size = new System.Drawing.Size(218, 23);
            this.txtLinkName.TabIndex = 12;
            this.txtLinkName.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtLinkName.TextChanged += new System.EventHandler(this.txtLinkName_TextChanged);
            // 
            // txtSupportAddress
            // 
            this.txtSupportAddress.AllowSelectedNullRow = false;
            this.txtSupportAddress.BackColor = System.Drawing.Color.White;
            this.txtSupportAddress.DisplayField = "";
            this.txtSupportAddress.Location = new System.Drawing.Point(569, 5);
            this.txtSupportAddress.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtSupportAddress.MaxLength = 30;
            this.txtSupportAddress.MemberField = "";
            this.txtSupportAddress.MemberValue = null;
            this.txtSupportAddress.Name = "txtSupportAddress";
            this.txtSupportAddress.NextControl = this.txtLinkName;
            this.txtSupportAddress.NextControlByEnter = true;
            this.txtSupportAddress.OffsetX = 0;
            this.txtSupportAddress.OffsetY = 0;
            this.txtSupportAddress.QueryFields = null;
            this.txtSupportAddress.SelectedValue = null;
            this.txtSupportAddress.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSupportAddress.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtSupportAddress.SelectionCardColumnHeaderHeight = 30;
            this.txtSupportAddress.SelectionCardColumns = null;
            this.txtSupportAddress.SelectionCardFont = null;
            this.txtSupportAddress.SelectionCardHeight = 250;
            this.txtSupportAddress.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtSupportAddress.SelectionCardRowHeaderWidth = 35;
            this.txtSupportAddress.SelectionCardRowHeight = 23;
            this.txtSupportAddress.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtSupportAddress.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtSupportAddress.SelectionCardWidth = 250;
            this.txtSupportAddress.ShowRowNumber = true;
            this.txtSupportAddress.ShowSelectionCardAfterEnter = false;
            this.txtSupportAddress.Size = new System.Drawing.Size(209, 23);
            this.txtSupportAddress.TabIndex = 11;
            this.txtSupportAddress.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtSupportAddress.TextChanged += new System.EventHandler(this.txtSupportAddress_TextChanged);
            // 
            // txtSupportName
            // 
            this.txtSupportName.AllowSelectedNullRow = false;
            this.txtSupportName.BackColor = System.Drawing.Color.White;
            this.txtSupportName.DisplayField = "";
            this.txtSupportName.Location = new System.Drawing.Point(274, 5);
            this.txtSupportName.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtSupportName.MaxLength = 30;
            this.txtSupportName.MemberField = "";
            this.txtSupportName.MemberValue = null;
            this.txtSupportName.Name = "txtSupportName";
            this.txtSupportName.NextControl = this.txtSupportAddress;
            this.txtSupportName.NextControlByEnter = true;
            this.txtSupportName.OffsetX = 0;
            this.txtSupportName.OffsetY = 0;
            this.txtSupportName.QueryFields = null;
            this.txtSupportName.SelectedValue = null;
            this.txtSupportName.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSupportName.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtSupportName.SelectionCardColumnHeaderHeight = 30;
            this.txtSupportName.SelectionCardColumns = null;
            this.txtSupportName.SelectionCardFont = null;
            this.txtSupportName.SelectionCardHeight = 250;
            this.txtSupportName.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtSupportName.SelectionCardRowHeaderWidth = 35;
            this.txtSupportName.SelectionCardRowHeight = 23;
            this.txtSupportName.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtSupportName.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtSupportName.SelectionCardWidth = 250;
            this.txtSupportName.ShowRowNumber = true;
            this.txtSupportName.ShowSelectionCardAfterEnter = false;
            this.txtSupportName.Size = new System.Drawing.Size(218, 23);
            this.txtSupportName.TabIndex = 10;
            this.txtSupportName.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtSupportName.TextChanged += new System.EventHandler(this.txtSupportName_TextChanged);
            // 
            // txtQuery
            // 
            this.txtQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtQuery.Location = new System.Drawing.Point(76, 20);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(100, 23);
            this.txtQuery.TabIndex = 5;
            this.txtQuery.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuery_KeyUp);
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(7, 24);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(63, 14);
            this.lblQuery.TabIndex = 6;
            this.lblQuery.Text = "定位查询";
            // 
            // lblLinkPhone
            // 
            this.lblLinkPhone.AutoSize = true;
            this.lblLinkPhone.Location = new System.Drawing.Point(498, 38);
            this.lblLinkPhone.Name = "lblLinkPhone";
            this.lblLinkPhone.Size = new System.Drawing.Size(63, 14);
            this.lblLinkPhone.TabIndex = 0;
            this.lblLinkPhone.Text = "联系电话";
            // 
            // lblLinkName
            // 
            this.lblLinkName.AutoSize = true;
            this.lblLinkName.Location = new System.Drawing.Point(191, 38);
            this.lblLinkName.Name = "lblLinkName";
            this.lblLinkName.Size = new System.Drawing.Size(77, 14);
            this.lblLinkName.TabIndex = 9;
            this.lblLinkName.Text = "联系人姓名";
            // 
            // lblSupportAddress
            // 
            this.lblSupportAddress.AutoSize = true;
            this.lblSupportAddress.Location = new System.Drawing.Point(499, 10);
            this.lblSupportAddress.Name = "lblSupportAddress";
            this.lblSupportAddress.Size = new System.Drawing.Size(63, 14);
            this.lblSupportAddress.TabIndex = 8;
            this.lblSupportAddress.Text = "厂家地址";
            // 
            // lblSupportName
            // 
            this.lblSupportName.AutoSize = true;
            this.lblSupportName.Location = new System.Drawing.Point(205, 10);
            this.lblSupportName.Name = "lblSupportName";
            this.lblSupportName.Size = new System.Drawing.Size(63, 14);
            this.lblSupportName.TabIndex = 7;
            this.lblSupportName.Text = "厂家名称";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgrdSupport);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(0, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(792, 409);
            this.panel4.TabIndex = 3;
            // 
            // dgrdSupport
            // 
            this.dgrdSupport.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdSupport.AllowSortWhenClickColumnHeader = false;
            this.dgrdSupport.AllowUserToAddRows = false;
            this.dgrdSupport.AllowUserToResizeRows = false;
            this.dgrdSupport.AutoGenerateColumns = false;
            this.dgrdSupport.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdSupport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdSupport.ColumnHeadersHeight = 30;
            this.dgrdSupport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.linkManDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn});
            this.dgrdSupport.DataSource = this.yPSupportDicBindingSource;
            this.dgrdSupport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdSupport.EnableHeadersVisualStyles = false;
            this.dgrdSupport.Location = new System.Drawing.Point(0, 0);
            this.dgrdSupport.MultiSelect = false;
            this.dgrdSupport.Name = "dgrdSupport";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdSupport.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdSupport.RowTemplate.Height = 23;
            this.dgrdSupport.SelectionCards = null;
            this.dgrdSupport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdSupport.Size = new System.Drawing.Size(792, 409);
            this.dgrdSupport.TabIndex = 0;
            this.dgrdSupport.UseGradientBackgroundColor = true;
            this.dgrdSupport.CurrentCellChanged += new System.EventHandler(this.dgrdSupport_CurrentCellChanged);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "厂家名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "厂家地址";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // linkManDataGridViewTextBoxColumn
            // 
            this.linkManDataGridViewTextBoxColumn.DataPropertyName = "LinkMan";
            this.linkManDataGridViewTextBoxColumn.HeaderText = "联系人";
            this.linkManDataGridViewTextBoxColumn.Name = "linkManDataGridViewTextBoxColumn";
            this.linkManDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "联系电话";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.phoneDataGridViewTextBoxColumn.Width = 150;
            // 
            // yPSupportDicBindingSource
            // 
            this.yPSupportDicBindingSource.DataSource = typeof(HIS.Model.YP_SupportDic);
            // 
            // tsrbtnCancel
            // 
            this.tsrbtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnCancel.Image")));
            this.tsrbtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnCancel.Name = "tsrbtnCancel";
            this.tsrbtnCancel.Size = new System.Drawing.Size(76, 26);
            this.tsrbtnCancel.Text = "取消(&Q)";
            this.tsrbtnCancel.Click += new System.EventHandler(this.tsrbtnCancel_Click);
            // 
            // FrmSupportDic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "供应商维护";
            this.KeyPreview = true;
            this.Name = "FrmSupportDic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "供应商维护";
            this.Load += new System.EventHandler(this.FrmSupportDic_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSupportDic_KeyDown);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.tsrSupport.ResumeLayout(false);
            this.tsrSupport.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdSupport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPSupportDicBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblLinkPhone;
        private System.Windows.Forms.Label lblLinkName;
        private System.Windows.Forms.Label lblSupportAddress;
        private System.Windows.Forms.Label lblSupportName;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.TextBox txtQuery;
        private GWI.HIS.Windows.Controls.ToolStrip tsrSupport;
        private System.Windows.Forms.ToolStripButton tsrbtnAdd;
        private System.Windows.Forms.ToolStripButton tsrbtnUpdate;
        private System.Windows.Forms.ToolStripButton tsrbtnDel;
        private System.Windows.Forms.ToolStripButton tsrbtnSave;
        private System.Windows.Forms.ToolStripButton tsrbtnQuit;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdSupport;
        private System.Windows.Forms.BindingSource yPSupportDicBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkManDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pYMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wBMDataGridViewTextBoxColumn;
        private GWI.HIS.Windows.Controls.QueryTextBox txtSupportName;
        private GWI.HIS.Windows.Controls.QueryTextBox txtSupportAddress;
        private GWI.HIS.Windows.Controls.QueryTextBox txtLinkName;
        private GWI.HIS.Windows.Controls.QueryTextBox txtLinkPhone;
        private System.Windows.Forms.ToolStripButton tsrbtnCancel;
    }
}