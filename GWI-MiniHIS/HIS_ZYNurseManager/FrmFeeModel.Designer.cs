namespace HIS_ZYNurseManager
{
    partial class FrmFeeModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFeeModel));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("院级模板");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("科室级模板");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("个人级模板");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("所有级别", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            GWI.HIS.Windows.Controls.DataGridViewSelectionCard dataGridViewSelectionCard1 = new GWI.HIS.Windows.Controls.DataGridViewSelectionCard();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn4 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn5 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn6 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn7 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn8 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.DataGridViewSelectionCard dataGridViewSelectionCard2 = new GWI.HIS.Windows.Controls.DataGridViewSelectionCard();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn9 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn10 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn11 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tvtype = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsAddType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddModel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tvlevel = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvFeeModel = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new GWI.HIS.Windows.Controls.DataGridViewTextBoxColumnEx();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_usage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequencyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.execdept_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.tbnFresh = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbYf = new System.Windows.Forms.ComboBox();
            this.lbyf = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plBaseWorkArea.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeModel)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 29);
            this.plBaseToolbar.Visible = false;
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 708);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.splitContainer1);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 645);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1016, 645);
            this.splitContainer1.SplitterDistance = 171;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tvtype);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 120);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(171, 525);
            this.panel5.TabIndex = 1;
            // 
            // tvtype
            // 
            this.tvtype.ContextMenuStrip = this.contextMenuStrip1;
            this.tvtype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvtype.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvtype.ImageIndex = 0;
            this.tvtype.ImageList = this.baseImageList;
            this.tvtype.Location = new System.Drawing.Point(0, 0);
            this.tvtype.Name = "tvtype";
            this.tvtype.SelectedImageIndex = 13;
            this.tvtype.Size = new System.Drawing.Size(171, 525);
            this.tvtype.TabIndex = 0;
            this.tvtype.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvtype_AfterSelect);
            this.tvtype.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvtype_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddType,
            this.tsAddModel,
            this.tsUpdate,
            this.tsDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            // 
            // tsAddType
            // 
            this.tsAddType.Name = "tsAddType";
            this.tsAddType.Size = new System.Drawing.Size(152, 22);
            this.tsAddType.Text = "新增类型";
            this.tsAddType.Click += new System.EventHandler(this.tsAddType_Click);
            // 
            // tsAddModel
            // 
            this.tsAddModel.Name = "tsAddModel";
            this.tsAddModel.Size = new System.Drawing.Size(152, 22);
            this.tsAddModel.Text = "新增模板";
            this.tsAddModel.Click += new System.EventHandler(this.tsAddModel_Click);
            // 
            // tsUpdate
            // 
            this.tsUpdate.Name = "tsUpdate";
            this.tsUpdate.Size = new System.Drawing.Size(152, 22);
            this.tsUpdate.Text = "修 改";
            this.tsUpdate.Click += new System.EventHandler(this.tsUpdate_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(152, 22);
            this.tsDelete.Text = "删 除";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tvlevel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(171, 120);
            this.panel4.TabIndex = 0;
            // 
            // tvlevel
            // 
            this.tvlevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvlevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvlevel.ImageIndex = 0;
            this.tvlevel.ImageList = this.baseImageList;
            this.tvlevel.Location = new System.Drawing.Point(0, 0);
            this.tvlevel.Name = "tvlevel";
            treeNode1.ImageIndex = 14;
            treeNode1.Name = "节点1";
            treeNode1.Text = "院级模板";
            treeNode2.ImageIndex = 14;
            treeNode2.Name = "节点2";
            treeNode2.Text = "科室级模板";
            treeNode3.ImageIndex = 14;
            treeNode3.Name = "节点3";
            treeNode3.Text = "个人级模板";
            treeNode4.ImageIndex = 15;
            treeNode4.Name = "节点0";
            treeNode4.Text = "所有级别";
            this.tvlevel.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.tvlevel.SelectedImageIndex = 13;
            this.tvlevel.Size = new System.Drawing.Size(171, 120);
            this.tvlevel.TabIndex = 12;
            this.tvlevel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvlevel_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(841, 607);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvFeeModel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(841, 582);
            this.panel3.TabIndex = 13;
            // 
            // dgvFeeModel
            // 
            this.dgvFeeModel.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvFeeModel.AllowSortWhenClickColumnHeader = false;
            this.dgvFeeModel.AllowUserToAddRows = false;
            this.dgvFeeModel.AllowUserToDeleteRows = false;
            this.dgvFeeModel.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFeeModel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFeeModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeeModel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_name,
            this.amount,
            this.unit,
            this.order_usage,
            this.tc_id,
            this.frequencyname,
            this.Column11,
            this.item_id,
            this.execdept_code,
            this.item_type,
            this.item_code});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFeeModel.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFeeModel.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvFeeModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFeeModel.EnableHeadersVisualStyles = false;
            this.dgvFeeModel.HideSelectionCardWhenCustomInput = false;
            this.dgvFeeModel.Location = new System.Drawing.Point(0, 0);
            this.dgvFeeModel.Name = "dgvFeeModel";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFeeModel.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFeeModel.RowTemplate.Height = 23;
            dataGridViewSelectionCard1.BindColumnIndex = 0;
            dataGridViewSelectionCard1.CardSize = new System.Drawing.Size(800, 400);
            selectionCardColumn1.AutoFill = false;
            selectionCardColumn1.DataBindField = "ORDER_NAME";
            selectionCardColumn1.HeaderText = "项目名称";
            selectionCardColumn1.IsNameField = false;
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 260;
            selectionCardColumn2.AutoFill = false;
            selectionCardColumn2.DataBindField = "PY_CODE";
            selectionCardColumn2.HeaderText = "拼音码";
            selectionCardColumn2.IsNameField = false;
            selectionCardColumn2.IsSeachColumn = true;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 75;
            selectionCardColumn3.AutoFill = false;
            selectionCardColumn3.DataBindField = "WB_CODE";
            selectionCardColumn3.HeaderText = "五笔码";
            selectionCardColumn3.IsNameField = false;
            selectionCardColumn3.IsSeachColumn = true;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn3.Visiable = false;
            selectionCardColumn3.Width = 75;
            selectionCardColumn4.AutoFill = false;
            selectionCardColumn4.DataBindField = "PRICE";
            selectionCardColumn4.HeaderText = "价格";
            selectionCardColumn4.IsNameField = false;
            selectionCardColumn4.IsSeachColumn = false;
            selectionCardColumn4.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn4.Visiable = true;
            selectionCardColumn4.Width = 75;
            selectionCardColumn5.AutoFill = false;
            selectionCardColumn5.DataBindField = "ORDER_UNIT";
            selectionCardColumn5.HeaderText = "单位";
            selectionCardColumn5.IsNameField = false;
            selectionCardColumn5.IsSeachColumn = false;
            selectionCardColumn5.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn5.Visiable = true;
            selectionCardColumn5.Width = 75;
            selectionCardColumn6.AutoFill = false;
            selectionCardColumn6.DataBindField = "DEFAULT_USAGE";
            selectionCardColumn6.HeaderText = "用法";
            selectionCardColumn6.IsNameField = false;
            selectionCardColumn6.IsSeachColumn = false;
            selectionCardColumn6.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn6.Visiable = true;
            selectionCardColumn6.Width = 75;
            selectionCardColumn7.AutoFill = false;
            selectionCardColumn7.DataBindField = "execdeptname";
            selectionCardColumn7.HeaderText = "执行科室";
            selectionCardColumn7.IsNameField = false;
            selectionCardColumn7.IsSeachColumn = false;
            selectionCardColumn7.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn7.Visiable = true;
            selectionCardColumn7.Width = 75;
            selectionCardColumn8.AutoFill = false;
            selectionCardColumn8.DataBindField = "TC_FLAG";
            selectionCardColumn8.HeaderText = "套餐";
            selectionCardColumn8.IsNameField = false;
            selectionCardColumn8.IsSeachColumn = false;
            selectionCardColumn8.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn8.Visiable = true;
            selectionCardColumn8.Width = 75;
            dataGridViewSelectionCard1.Columns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2,
        selectionCardColumn3,
        selectionCardColumn4,
        selectionCardColumn5,
        selectionCardColumn6,
        selectionCardColumn7,
        selectionCardColumn8};
            dataGridViewSelectionCard1.CurrentPage = 0;
            dataGridViewSelectionCard1.DataObjectType = null;
            dataGridViewSelectionCard1.DataSource = null;
            dataGridViewSelectionCard1.DataSourceIsDataTable = false;
            dataGridViewSelectionCard1.FilterResult = null;
            dataGridViewSelectionCard1.OffsetX = 0;
            dataGridViewSelectionCard1.OffsetY = 0;
            dataGridViewSelectionCard1.SelectCardAlternatingRowsBackColor = System.Drawing.Color.Empty;
            dataGridViewSelectionCard1.SelectCardFilterType = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            dataGridViewSelectionCard1.SelectCardRowHeight = 23;
            dataGridViewSelectionCard1.SelectionCardBackGroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewSelectionCard1.SelectionCardFont = new System.Drawing.Font("宋体", 9F);
            dataGridViewSelectionCard1.SelectionCardLabelBackColor = System.Drawing.SystemColors.Control;
            dataGridViewSelectionCard1.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            dataGridViewSelectionCard1.SelectionRowBackColor = System.Drawing.Color.Black;
            dataGridViewSelectionCard1.SpeciFilterString = null;
            dataGridViewSelectionCard1.TotalPage = 0;
            dataGridViewSelectionCard2.BindColumnIndex = 7;
            dataGridViewSelectionCard2.CardSize = new System.Drawing.Size(200, 300);
            selectionCardColumn9.AutoFill = false;
            selectionCardColumn9.DataBindField = "PY_CODE";
            selectionCardColumn9.HeaderText = "拼音码";
            selectionCardColumn9.IsNameField = false;
            selectionCardColumn9.IsSeachColumn = true;
            selectionCardColumn9.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn9.Visiable = true;
            selectionCardColumn9.Width = 75;
            selectionCardColumn10.AutoFill = false;
            selectionCardColumn10.DataBindField = "NAME";
            selectionCardColumn10.HeaderText = "名称";
            selectionCardColumn10.IsNameField = false;
            selectionCardColumn10.IsSeachColumn = false;
            selectionCardColumn10.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn10.Visiable = true;
            selectionCardColumn10.Width = 75;
            selectionCardColumn11.AutoFill = false;
            selectionCardColumn11.DataBindField = "EXECNUM";
            selectionCardColumn11.HeaderText = "频率";
            selectionCardColumn11.IsNameField = false;
            selectionCardColumn11.IsSeachColumn = false;
            selectionCardColumn11.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn11.Visiable = true;
            selectionCardColumn11.Width = 75;
            dataGridViewSelectionCard2.Columns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn9,
        selectionCardColumn10,
        selectionCardColumn11};
            dataGridViewSelectionCard2.CurrentPage = 0;
            dataGridViewSelectionCard2.DataObjectType = null;
            dataGridViewSelectionCard2.DataSource = null;
            dataGridViewSelectionCard2.DataSourceIsDataTable = false;
            dataGridViewSelectionCard2.FilterResult = null;
            dataGridViewSelectionCard2.OffsetX = 0;
            dataGridViewSelectionCard2.OffsetY = 0;
            dataGridViewSelectionCard2.SelectCardAlternatingRowsBackColor = System.Drawing.Color.Empty;
            dataGridViewSelectionCard2.SelectCardFilterType = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            dataGridViewSelectionCard2.SelectCardRowHeight = 23;
            dataGridViewSelectionCard2.SelectionCardBackGroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewSelectionCard2.SelectionCardFont = new System.Drawing.Font("宋体", 9F);
            dataGridViewSelectionCard2.SelectionCardLabelBackColor = System.Drawing.SystemColors.Control;
            dataGridViewSelectionCard2.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            dataGridViewSelectionCard2.SelectionRowBackColor = System.Drawing.Color.Black;
            dataGridViewSelectionCard2.SpeciFilterString = null;
            dataGridViewSelectionCard2.TotalPage = 0;
            this.dgvFeeModel.SelectionCards = new GWI.HIS.Windows.Controls.DataGridViewSelectionCard[] {
        dataGridViewSelectionCard1,
        dataGridViewSelectionCard2};
            this.dgvFeeModel.Size = new System.Drawing.Size(841, 582);
            this.dgvFeeModel.TabIndex = 1;
            this.dgvFeeModel.UseGradientBackgroundColor = true;
            this.dgvFeeModel.SelectCardRowSelected += new GWI.HIS.Windows.Controls.OnSelectCardRowSelectedHandle(this.dgvFeeModel_SelectCardRowSelected);
            this.dgvFeeModel.DataGridViewCellPressEnterKey += new GWI.HIS.Windows.Controls.OnDataGridViewCellPressEnterKeyHandle(this.dgvFeeModel_DataGridViewCellPressEnterKey);
            this.dgvFeeModel.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvFeeModel_DataError);
            // 
            // item_name
            // 
            this.item_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.item_name.DataPropertyName = "item_name";
            this.item_name.HeaderText = "账单内容";
            this.item_name.Name = "item_name";
            this.item_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "数量";
            this.amount.JumpInType = GWI.HIS.Windows.Controls.JumpInType.AwaysJumpIn;
            this.amount.Name = "amount";
            this.amount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.amount.TextFormatStyle = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.amount.Width = 50;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.unit.Width = 80;
            // 
            // order_usage
            // 
            this.order_usage.DataPropertyName = "order_usage";
            this.order_usage.HeaderText = "用法";
            this.order_usage.Name = "order_usage";
            this.order_usage.ReadOnly = true;
            this.order_usage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.order_usage.Visible = false;
            // 
            // tc_id
            // 
            this.tc_id.DataPropertyName = "tc_id";
            this.tc_id.HeaderText = "套餐";
            this.tc_id.Name = "tc_id";
            this.tc_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tc_id.Visible = false;
            // 
            // frequencyname
            // 
            this.frequencyname.DataPropertyName = "frequencyname";
            this.frequencyname.HeaderText = "频率";
            this.frequencyname.Name = "frequencyname";
            this.frequencyname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.frequencyname.Visible = false;
            this.frequencyname.Width = 50;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "execnum";
            this.Column11.HeaderText = "首次";
            this.Column11.Name = "Column11";
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column11.Visible = false;
            this.Column11.Width = 50;
            // 
            // item_id
            // 
            this.item_id.DataPropertyName = "item_id";
            this.item_id.HeaderText = "item_id";
            this.item_id.Name = "item_id";
            this.item_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.item_id.Visible = false;
            // 
            // execdept_code
            // 
            this.execdept_code.DataPropertyName = "execdept_code";
            this.execdept_code.HeaderText = "execdept_code";
            this.execdept_code.Name = "execdept_code";
            this.execdept_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.execdept_code.Visible = false;
            // 
            // item_type
            // 
            this.item_type.DataPropertyName = "item_type";
            this.item_type.HeaderText = "Column1";
            this.item_type.Name = "item_type";
            this.item_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.item_type.Visible = false;
            // 
            // item_code
            // 
            this.item_code.DataPropertyName = "item_code";
            this.item_code.HeaderText = "item_code";
            this.item_code.Name = "item_code";
            this.item_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.item_code.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnSave,
            this.btnDel,
            this.tbnFresh,
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(841, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(83, 22);
            this.btnNew.Text = "新开(F2)";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 22);
            this.btnSave.Text = "保存(F3)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(83, 22);
            this.btnDel.Text = "删除(F4)";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // tbnFresh
            // 
            this.tbnFresh.Image = global::HIS_ZYNurseManager.Properties.Resources.刷新;
            this.tbnFresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnFresh.Name = "tbnFresh";
            this.tbnFresh.Size = new System.Drawing.Size(83, 22);
            this.tbnFresh.Text = "刷新(F5)";
            this.tbnFresh.Click += new System.EventHandler(this.tbnFresh_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 22);
            this.btnExit.Text = "退出(F6)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbYf);
            this.panel1.Controls.Add(this.lbyf);
            this.panel1.Controls.Add(this.txtModelName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 38);
            this.panel1.TabIndex = 0;
            // 
            // cbYf
            // 
            this.cbYf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYf.FormattingEnabled = true;
            this.cbYf.Location = new System.Drawing.Point(494, 8);
            this.cbYf.Name = "cbYf";
            this.cbYf.Size = new System.Drawing.Size(121, 20);
            this.cbYf.TabIndex = 9;
            this.cbYf.SelectedIndexChanged += new System.EventHandler(this.cbYf_SelectedIndexChanged);
            // 
            // lbyf
            // 
            this.lbyf.AutoSize = true;
            this.lbyf.Location = new System.Drawing.Point(435, 13);
            this.lbyf.Name = "lbyf";
            this.lbyf.Size = new System.Drawing.Size(53, 12);
            this.lbyf.TabIndex = 8;
            this.lbyf.Text = "选择药房";
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(67, 8);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.ReadOnly = true;
            this.txtModelName.Size = new System.Drawing.Size(322, 21);
            this.txtModelName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "模板名：";
            // 
            // FrmFeeModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "护士账单模板";
            this.KeyPreview = true;
            this.Name = "FrmFeeModel";
            this.Text = "账单模板";
            this.Load += new System.EventHandler(this.FrmFeeModel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFeeModel_KeyDown);
            this.Controls.SetChildIndex(this.plTitle, 0);
            this.Controls.SetChildIndex(this.plBaseToolbar, 0);
            this.Controls.SetChildIndex(this.plBaseStatus, 0);
            this.Controls.SetChildIndex(this.plBaseWorkArea, 0);
            this.plBaseWorkArea.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeModel)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TreeView tvtype;
        private System.Windows.Forms.TreeView tvlevel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsAddType;
        private System.Windows.Forms.ToolStripMenuItem tsAddModel;
        private System.Windows.Forms.ToolStripMenuItem tsDelete;
        private System.Windows.Forms.ToolStripMenuItem tsUpdate;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvFeeModel;
        private System.Windows.Forms.ToolStripButton tbnFresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_name;
        private GWI.HIS.Windows.Controls.DataGridViewTextBoxColumnEx amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_usage;
        private System.Windows.Forms.DataGridViewTextBoxColumn tc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencyname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn execdept_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.ComboBox cbYf;
        private System.Windows.Forms.Label lbyf;
    }
}