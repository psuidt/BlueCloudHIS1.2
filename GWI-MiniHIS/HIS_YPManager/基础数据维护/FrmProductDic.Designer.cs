namespace HIS_YPManager
{
    partial class FrmProductDic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductDic));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsrProduct = new GWI.HIS.Windows.Controls.ToolStrip();
            this.tsrbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnDel = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnQuit = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtLinkPhone = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtLinkName = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtProductAddress = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtProductName = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.lblLinkPhone = new System.Windows.Forms.Label();
            this.lblLinkName = new System.Windows.Forms.Label();
            this.lblProductAddress = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgrdProduct = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yPProductDicBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsrbtnCancel = new System.Windows.Forms.ToolStripButton();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.tsrProduct.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPProductDicBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add(this.tsrProduct);
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
            // tsrProduct
            // 
            this.tsrProduct.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsrProduct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsrProduct.BackgroundImage")));
            this.tsrProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsrProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsrProduct.Font = new System.Drawing.Font("宋体", 10F);
            this.tsrProduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsrbtnAdd,
            this.tsrbtnDel,
            this.tsrbtnUpdate,
            this.tsrbtnSave,
            this.tsrbtnCancel,
            this.tsrbtnQuit});
            this.tsrProduct.Location = new System.Drawing.Point(0, 0);
            this.tsrProduct.Name = "tsrProduct";
            this.tsrProduct.Size = new System.Drawing.Size(792, 29);
            this.tsrProduct.TabIndex = 0;
            this.tsrProduct.Text = "toolStrip1";
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
            // tsrbtnDel
            // 
            this.tsrbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnDel.Image")));
            this.tsrbtnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnDel.Name = "tsrbtnDel";
            this.tsrbtnDel.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnDel.Text = "修改(F3)";
            this.tsrbtnDel.Click += new System.EventHandler(this.tsrbtnDel_Click);
            // 
            // tsrbtnUpdate
            // 
            this.tsrbtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnUpdate.Image")));
            this.tsrbtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnUpdate.Name = "tsrbtnUpdate";
            this.tsrbtnUpdate.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnUpdate.Text = "删除(F4)";
            this.tsrbtnUpdate.Click += new System.EventHandler(this.tsrbtnUpdate_Click);
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
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtLinkPhone);
            this.panel3.Controls.Add(this.txtLinkName);
            this.panel3.Controls.Add(this.txtProductAddress);
            this.panel3.Controls.Add(this.txtProductName);
            this.panel3.Controls.Add(this.txtQuery);
            this.panel3.Controls.Add(this.lblQuery);
            this.panel3.Controls.Add(this.lblLinkPhone);
            this.panel3.Controls.Add(this.lblLinkName);
            this.panel3.Controls.Add(this.lblProductAddress);
            this.panel3.Controls.Add(this.lblProductName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 72);
            this.panel3.TabIndex = 0;
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.AllowSelectedNullRow = false;
            this.txtLinkPhone.BackColor = System.Drawing.Color.White;
            this.txtLinkPhone.DisplayField = "";
            this.txtLinkPhone.Location = new System.Drawing.Point(574, 38);
            this.txtLinkPhone.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtLinkPhone.MaxLength = 30;
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
            this.txtLinkPhone.Size = new System.Drawing.Size(204, 23);
            this.txtLinkPhone.TabIndex = 3;
            this.txtLinkPhone.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtLinkPhone.TextChanged += new System.EventHandler(this.txtLinkPhone_TextChanged);
            this.txtLinkPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLinkPhone_KeyPress);
            // 
            // txtLinkName
            // 
            this.txtLinkName.AllowSelectedNullRow = false;
            this.txtLinkName.BackColor = System.Drawing.Color.White;
            this.txtLinkName.DisplayField = "";
            this.txtLinkName.Location = new System.Drawing.Point(272, 37);
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
            this.txtLinkName.Size = new System.Drawing.Size(226, 23);
            this.txtLinkName.TabIndex = 2;
            this.txtLinkName.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtLinkName.TextChanged += new System.EventHandler(this.txtLinkName_TextChanged);
            // 
            // txtProductAddress
            // 
            this.txtProductAddress.AllowSelectedNullRow = false;
            this.txtProductAddress.BackColor = System.Drawing.Color.White;
            this.txtProductAddress.DisplayField = "";
            this.txtProductAddress.Location = new System.Drawing.Point(573, 8);
            this.txtProductAddress.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtProductAddress.MaxLength = 40;
            this.txtProductAddress.MemberField = "";
            this.txtProductAddress.MemberValue = null;
            this.txtProductAddress.Name = "txtProductAddress";
            this.txtProductAddress.NextControl = this.txtLinkName;
            this.txtProductAddress.NextControlByEnter = true;
            this.txtProductAddress.OffsetX = 0;
            this.txtProductAddress.OffsetY = 0;
            this.txtProductAddress.QueryFields = null;
            this.txtProductAddress.SelectedValue = null;
            this.txtProductAddress.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtProductAddress.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtProductAddress.SelectionCardColumnHeaderHeight = 30;
            this.txtProductAddress.SelectionCardColumns = null;
            this.txtProductAddress.SelectionCardFont = null;
            this.txtProductAddress.SelectionCardHeight = 250;
            this.txtProductAddress.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtProductAddress.SelectionCardRowHeaderWidth = 35;
            this.txtProductAddress.SelectionCardRowHeight = 23;
            this.txtProductAddress.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtProductAddress.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtProductAddress.SelectionCardWidth = 250;
            this.txtProductAddress.ShowRowNumber = true;
            this.txtProductAddress.ShowSelectionCardAfterEnter = false;
            this.txtProductAddress.Size = new System.Drawing.Size(205, 23);
            this.txtProductAddress.TabIndex = 1;
            this.txtProductAddress.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtProductAddress.TextChanged += new System.EventHandler(this.txtProductAddress_TextChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.AllowSelectedNullRow = false;
            this.txtProductName.BackColor = System.Drawing.Color.White;
            this.txtProductName.DisplayField = "";
            this.txtProductName.Location = new System.Drawing.Point(272, 8);
            this.txtProductName.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtProductName.MaxLength = 35;
            this.txtProductName.MemberField = "";
            this.txtProductName.MemberValue = null;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.NextControl = this.txtProductAddress;
            this.txtProductName.NextControlByEnter = true;
            this.txtProductName.OffsetX = 0;
            this.txtProductName.OffsetY = 0;
            this.txtProductName.QueryFields = null;
            this.txtProductName.SelectedValue = null;
            this.txtProductName.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtProductName.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtProductName.SelectionCardColumnHeaderHeight = 30;
            this.txtProductName.SelectionCardColumns = null;
            this.txtProductName.SelectionCardFont = null;
            this.txtProductName.SelectionCardHeight = 250;
            this.txtProductName.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtProductName.SelectionCardRowHeaderWidth = 35;
            this.txtProductName.SelectionCardRowHeight = 23;
            this.txtProductName.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtProductName.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtProductName.SelectionCardWidth = 250;
            this.txtProductName.ShowRowNumber = true;
            this.txtProductName.ShowSelectionCardAfterEnter = false;
            this.txtProductName.Size = new System.Drawing.Size(226, 23);
            this.txtProductName.TabIndex = 0;
            this.txtProductName.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // txtQuery
            // 
            this.txtQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtQuery.Location = new System.Drawing.Point(72, 22);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(111, 23);
            this.txtQuery.TabIndex = 4;
            this.txtQuery.Leave += new System.EventHandler(this.txtQuery_Leave);
            this.txtQuery.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuery_KeyUp);
            this.txtQuery.Enter += new System.EventHandler(this.txtQuery_Enter);
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(6, 27);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(63, 14);
            this.lblQuery.TabIndex = 5;
            this.lblQuery.Text = "定位查询";
            // 
            // lblLinkPhone
            // 
            this.lblLinkPhone.AutoSize = true;
            this.lblLinkPhone.Location = new System.Drawing.Point(504, 42);
            this.lblLinkPhone.Name = "lblLinkPhone";
            this.lblLinkPhone.Size = new System.Drawing.Size(63, 14);
            this.lblLinkPhone.TabIndex = 9;
            this.lblLinkPhone.Text = "联系电话";
            // 
            // lblLinkName
            // 
            this.lblLinkName.AutoSize = true;
            this.lblLinkName.Location = new System.Drawing.Point(189, 42);
            this.lblLinkName.Name = "lblLinkName";
            this.lblLinkName.Size = new System.Drawing.Size(77, 14);
            this.lblLinkName.TabIndex = 7;
            this.lblLinkName.Text = "联系人姓名";
            // 
            // lblProductAddress
            // 
            this.lblProductAddress.AutoSize = true;
            this.lblProductAddress.Location = new System.Drawing.Point(504, 12);
            this.lblProductAddress.Name = "lblProductAddress";
            this.lblProductAddress.Size = new System.Drawing.Size(63, 14);
            this.lblProductAddress.TabIndex = 8;
            this.lblProductAddress.Text = "厂家地址";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(203, 12);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(63, 14);
            this.lblProductName.TabIndex = 6;
            this.lblProductName.Text = "厂家名称";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgrdProduct);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(0, 72);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(792, 405);
            this.panel4.TabIndex = 3;
            // 
            // dgrdProduct
            // 
            this.dgrdProduct.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdProduct.AllowSortWhenClickColumnHeader = false;
            this.dgrdProduct.AllowUserToAddRows = false;
            this.dgrdProduct.AllowUserToResizeRows = false;
            this.dgrdProduct.AutoGenerateColumns = false;
            this.dgrdProduct.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdProduct.ColumnHeadersHeight = 30;
            this.dgrdProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNameDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.linkNameDataGridViewTextBoxColumn,
            this.linkPhoneDataGridViewTextBoxColumn});
            this.dgrdProduct.DataSource = this.yPProductDicBindingSource;
            this.dgrdProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdProduct.EnableHeadersVisualStyles = false;
            this.dgrdProduct.Location = new System.Drawing.Point(0, 0);
            this.dgrdProduct.MultiSelect = false;
            this.dgrdProduct.Name = "dgrdProduct";
            this.dgrdProduct.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdProduct.RowTemplate.Height = 23;
            this.dgrdProduct.SelectionCards = null;
            this.dgrdProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdProduct.Size = new System.Drawing.Size(792, 405);
            this.dgrdProduct.TabIndex = 0;
            this.dgrdProduct.UseGradientBackgroundColor = true;
            this.dgrdProduct.CurrentCellChanged += new System.EventHandler(this.dgrdProduct_CurrentCellChanged);
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "厂家名称";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.productNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "厂家地址";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // linkNameDataGridViewTextBoxColumn
            // 
            this.linkNameDataGridViewTextBoxColumn.DataPropertyName = "LinkName";
            this.linkNameDataGridViewTextBoxColumn.HeaderText = "联系人";
            this.linkNameDataGridViewTextBoxColumn.Name = "linkNameDataGridViewTextBoxColumn";
            this.linkNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.linkNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.linkNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // linkPhoneDataGridViewTextBoxColumn
            // 
            this.linkPhoneDataGridViewTextBoxColumn.DataPropertyName = "LinkPhone";
            this.linkPhoneDataGridViewTextBoxColumn.HeaderText = "联系电话";
            this.linkPhoneDataGridViewTextBoxColumn.Name = "linkPhoneDataGridViewTextBoxColumn";
            this.linkPhoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.linkPhoneDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.linkPhoneDataGridViewTextBoxColumn.Width = 130;
            // 
            // yPProductDicBindingSource
            // 
            this.yPProductDicBindingSource.DataSource = typeof(HIS.Model.YP_ProductDic);
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
            // FrmProductDic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "生产厂家维护";
            this.KeyPreview = true;
            this.Name = "FrmProductDic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产厂家维护";
            this.Load += new System.EventHandler(this.FrmProductDic_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProductDic_KeyDown);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.tsrProduct.ResumeLayout(false);
            this.tsrProduct.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPProductDicBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblLinkPhone;
        private System.Windows.Forms.Label lblLinkName;
        private System.Windows.Forms.Label lblProductAddress;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblQuery;
        private GWI.HIS.Windows.Controls.ToolStrip tsrProduct;
        private System.Windows.Forms.ToolStripButton tsrbtnAdd;
        private System.Windows.Forms.ToolStripButton tsrbtnUpdate;
        private System.Windows.Forms.ToolStripButton tsrbtnDel;
        private System.Windows.Forms.ToolStripButton tsrbtnSave;
        private System.Windows.Forms.ToolStripButton tsrbtnQuit;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdProduct;
        private System.Windows.Forms.BindingSource yPProductDicBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtQuery;
        private GWI.HIS.Windows.Controls.QueryTextBox txtProductName;
        private GWI.HIS.Windows.Controls.QueryTextBox txtProductAddress;
        private GWI.HIS.Windows.Controls.QueryTextBox txtLinkName;
        private GWI.HIS.Windows.Controls.QueryTextBox txtLinkPhone;
        private System.Windows.Forms.ToolStripButton tsrbtnCancel;
    }
}