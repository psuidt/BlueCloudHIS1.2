namespace HIS_ReportManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TvReport = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuAddType = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPageControl1 = new GWI.HIS.Windows.Controls.Controls.TabPageControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvInParam = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.参数ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.参数名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.参数别名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数据类型名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数据类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.大小 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.控件类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPORT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOREIGNER_FIELD_CN_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOREIGNER_FIELD_DB_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOREIGNER_FILTER_SQL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENUMEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelParam = new System.Windows.Forms.Button();
            this.btnAddParam = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProcess = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnReportDesign = new System.Windows.Forms.Button();
            this.btnQueryOldSource = new System.Windows.Forms.Button();
            this.btnPringtview = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.plBaseWorkArea.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInParam)).BeginInit();
            this.panel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Location = new System.Drawing.Point(0, 0);
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 10);
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
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.splitContainer1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 10);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 698);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1016, 698);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 698);
            this.panel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(194, 698);
            this.panel6.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TvReport);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 18);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(194, 680);
            this.panel5.TabIndex = 2;
            // 
            // TvReport
            // 
            this.TvReport.AllowDrop = true;
            this.TvReport.ContextMenuStrip = this.contextMenuStrip1;
            this.TvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvReport.ImageIndex = 14;
            this.TvReport.ImageList = this.baseImageList;
            this.TvReport.Location = new System.Drawing.Point(0, 0);
            this.TvReport.Name = "TvReport";
            this.TvReport.SelectedImageIndex = 13;
            this.TvReport.Size = new System.Drawing.Size(194, 680);
            this.TvReport.TabIndex = 0;
            this.TvReport.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.TvReport_NodeMouseHover);
            this.TvReport.DragDrop += new System.Windows.Forms.DragEventHandler(this.TvReport_DragDrop);
            this.TvReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvReport_AfterSelect);
            this.TvReport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TvReport_MouseDown);
            this.TvReport.DragEnter += new System.Windows.Forms.DragEventHandler(this.TvReport_DragEnter);
            this.TvReport.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TvReport_ItemDrag);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAddType,
            this.MenuAddReport,
            this.MenuUpdate,
            this.MenuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 92);
            // 
            // MenuAddType
            // 
            this.MenuAddType.Name = "MenuAddType";
            this.MenuAddType.Size = new System.Drawing.Size(122, 22);
            this.MenuAddType.Text = "新增类型";
            this.MenuAddType.Click += new System.EventHandler(this.MenuAddType_Click);
            // 
            // MenuAddReport
            // 
            this.MenuAddReport.Name = "MenuAddReport";
            this.MenuAddReport.Size = new System.Drawing.Size(122, 22);
            this.MenuAddReport.Text = "新增报表";
            this.MenuAddReport.Click += new System.EventHandler(this.MenuAddReport_Click);
            // 
            // MenuUpdate
            // 
            this.MenuUpdate.Name = "MenuUpdate";
            this.MenuUpdate.Size = new System.Drawing.Size(122, 22);
            this.MenuUpdate.Text = "修  改";
            this.MenuUpdate.Click += new System.EventHandler(this.MenuUpdate_Click);
            // 
            // MenuDelete
            // 
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(122, 22);
            this.MenuDelete.Text = "删  除";
            this.MenuDelete.Click += new System.EventHandler(this.MenuDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 18);
            this.panel1.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(29, 4);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 12);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "展开所有报表";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabPageControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(818, 698);
            this.panel2.TabIndex = 0;
            // 
            // tabPageControl1
            // 
            this.tabPageControl1.Controls.Add(this.tabPage1);
            this.tabPageControl1.Controls.Add(this.tabPage2);
            this.tabPageControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.tabPageControl1.Name = "tabPageControl1";
            this.tabPageControl1.SelectedIndex = 0;
            this.tabPageControl1.Size = new System.Drawing.Size(818, 698);
            this.tabPageControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(810, 673);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据源";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInitialize);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.dgvInParam);
            this.groupBox1.Controls.Add(this.btnDelParam);
            this.groupBox1.Controls.Add(this.btnAddParam);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 634);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数信息";
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(749, 32);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(75, 23);
            this.btnInitialize.TabIndex = 6;
            this.btnInitialize.Text = "参数初始化";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(749, 111);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "修改";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvInParam
            // 
            this.dgvInParam.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvInParam.AllowSortWhenClickColumnHeader = false;
            this.dgvInParam.AllowUserToAddRows = false;
            this.dgvInParam.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInParam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.参数ID,
            this.参数名,
            this.参数别名,
            this.数据类型名,
            this.数据类型,
            this.大小,
            this.Direction,
            this.控件类型,
            this.REPORT_ID,
            this.FOREIGNER_FIELD_CN_NAME,
            this.FOREIGNER_FIELD_DB_NAME,
            this.FOREIGNER_FILTER_SQL,
            this.ENUMEID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInParam.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInParam.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvInParam.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvInParam.EnableHeadersVisualStyles = false;
            this.dgvInParam.HideSelectionCardWhenCustomInput = false;
            this.dgvInParam.Location = new System.Drawing.Point(3, 17);
            this.dgvInParam.Name = "dgvInParam";
            this.dgvInParam.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInParam.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInParam.RowTemplate.Height = 23;
            this.dgvInParam.SelectionCards = null;
            this.dgvInParam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInParam.Size = new System.Drawing.Size(740, 614);
            this.dgvInParam.TabIndex = 0;
            this.dgvInParam.UseGradientBackgroundColor = true;
            this.dgvInParam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInParam_CellDoubleClick);
            // 
            // 参数ID
            // 
            this.参数ID.DataPropertyName = "PARAMETERID";
            this.参数ID.HeaderText = "参数ID";
            this.参数ID.Name = "参数ID";
            this.参数ID.ReadOnly = true;
            this.参数ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 参数名
            // 
            this.参数名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.参数名.DataPropertyName = "PARAMETER";
            this.参数名.HeaderText = "参数名";
            this.参数名.Name = "参数名";
            this.参数名.ReadOnly = true;
            this.参数名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 参数别名
            // 
            this.参数别名.DataPropertyName = "PARAMETER_CN";
            this.参数别名.HeaderText = "参数别名";
            this.参数别名.Name = "参数别名";
            this.参数别名.ReadOnly = true;
            this.参数别名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 数据类型名
            // 
            this.数据类型名.DataPropertyName = "datatypename";
            this.数据类型名.HeaderText = "数据类型";
            this.数据类型名.Name = "数据类型名";
            this.数据类型名.ReadOnly = true;
            this.数据类型名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 数据类型
            // 
            this.数据类型.DataPropertyName = "PARAMDATATYPE";
            this.数据类型.HeaderText = "数据类型";
            this.数据类型.Name = "数据类型";
            this.数据类型.ReadOnly = true;
            this.数据类型.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.数据类型.Visible = false;
            // 
            // 大小
            // 
            this.大小.DataPropertyName = "DATALENGTH";
            this.大小.HeaderText = "大小";
            this.大小.Name = "大小";
            this.大小.ReadOnly = true;
            this.大小.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Direction
            // 
            this.Direction.DataPropertyName = "PARAMETER_TYPE";
            this.Direction.HeaderText = "输入输出";
            this.Direction.Name = "Direction";
            this.Direction.ReadOnly = true;
            this.Direction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Direction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 控件类型
            // 
            this.控件类型.DataPropertyName = "UIC_TYPE";
            this.控件类型.HeaderText = "控件类型";
            this.控件类型.Name = "控件类型";
            this.控件类型.ReadOnly = true;
            this.控件类型.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.控件类型.Visible = false;
            // 
            // REPORT_ID
            // 
            this.REPORT_ID.DataPropertyName = "REPORT_ID";
            this.REPORT_ID.HeaderText = "REPORT_ID";
            this.REPORT_ID.Name = "REPORT_ID";
            this.REPORT_ID.ReadOnly = true;
            this.REPORT_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.REPORT_ID.Visible = false;
            // 
            // FOREIGNER_FIELD_CN_NAME
            // 
            this.FOREIGNER_FIELD_CN_NAME.DataPropertyName = "FOREIGNER_FIELD_CN_NAME";
            this.FOREIGNER_FIELD_CN_NAME.HeaderText = "Column1";
            this.FOREIGNER_FIELD_CN_NAME.Name = "FOREIGNER_FIELD_CN_NAME";
            this.FOREIGNER_FIELD_CN_NAME.ReadOnly = true;
            this.FOREIGNER_FIELD_CN_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FOREIGNER_FIELD_CN_NAME.Visible = false;
            // 
            // FOREIGNER_FIELD_DB_NAME
            // 
            this.FOREIGNER_FIELD_DB_NAME.DataPropertyName = "FOREIGNER_FIELD_DB_NAME";
            this.FOREIGNER_FIELD_DB_NAME.HeaderText = "FOREIGNER_FIELD_DB_NAME";
            this.FOREIGNER_FIELD_DB_NAME.Name = "FOREIGNER_FIELD_DB_NAME";
            this.FOREIGNER_FIELD_DB_NAME.ReadOnly = true;
            this.FOREIGNER_FIELD_DB_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FOREIGNER_FIELD_DB_NAME.Visible = false;
            // 
            // FOREIGNER_FILTER_SQL
            // 
            this.FOREIGNER_FILTER_SQL.DataPropertyName = "FOREIGNER_FILTER_SQL";
            this.FOREIGNER_FILTER_SQL.HeaderText = "Column3";
            this.FOREIGNER_FILTER_SQL.Name = "FOREIGNER_FILTER_SQL";
            this.FOREIGNER_FILTER_SQL.ReadOnly = true;
            this.FOREIGNER_FILTER_SQL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FOREIGNER_FILTER_SQL.Visible = false;
            // 
            // ENUMEID
            // 
            this.ENUMEID.DataPropertyName = "ENUMEID";
            this.ENUMEID.HeaderText = "ENUMEID";
            this.ENUMEID.Name = "ENUMEID";
            this.ENUMEID.ReadOnly = true;
            this.ENUMEID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ENUMEID.Visible = false;
            // 
            // btnDelParam
            // 
            this.btnDelParam.Location = new System.Drawing.Point(749, 153);
            this.btnDelParam.Name = "btnDelParam";
            this.btnDelParam.Size = new System.Drawing.Size(75, 23);
            this.btnDelParam.TabIndex = 1;
            this.btnDelParam.Text = "删除";
            this.btnDelParam.UseVisualStyleBackColor = true;
            this.btnDelParam.Click += new System.EventHandler(this.btnDelParam_Click);
            // 
            // btnAddParam
            // 
            this.btnAddParam.Location = new System.Drawing.Point(749, 72);
            this.btnAddParam.Name = "btnAddParam";
            this.btnAddParam.Size = new System.Drawing.Size(75, 23);
            this.btnAddParam.TabIndex = 0;
            this.btnAddParam.Text = "新增";
            this.btnAddParam.UseVisualStyleBackColor = true;
            this.btnAddParam.Click += new System.EventHandler(this.btnAddParam_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.txtReportName);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtProcess);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(804, 33);
            this.panel4.TabIndex = 0;
            // 
            // txtReportName
            // 
            this.txtReportName.Location = new System.Drawing.Point(434, 4);
            this.txtReportName.MaxLength = 50;
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.ReadOnly = true;
            this.txtReportName.Size = new System.Drawing.Size(215, 21);
            this.txtReportName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(363, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "报表文件名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "存储过程名";
            // 
            // txtProcess
            // 
            this.txtProcess.Location = new System.Drawing.Point(92, 5);
            this.txtProcess.MaxLength = 50;
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.ReadOnly = true;
            this.txtProcess.Size = new System.Drawing.Size(229, 21);
            this.txtProcess.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel9);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(810, 673);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "报表预览";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(810, 673);
            this.panel9.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 33);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(810, 640);
            this.panel12.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Controls.Add(this.btnReportDesign);
            this.panel10.Controls.Add(this.btnQueryOldSource);
            this.panel10.Controls.Add(this.btnPringtview);
            this.panel10.Controls.Add(this.btnQuery);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(810, 33);
            this.panel10.TabIndex = 0;
            // 
            // btnReportDesign
            // 
            this.btnReportDesign.Location = new System.Drawing.Point(370, 6);
            this.btnReportDesign.Name = "btnReportDesign";
            this.btnReportDesign.Size = new System.Drawing.Size(75, 23);
            this.btnReportDesign.TabIndex = 3;
            this.btnReportDesign.Text = "报表设计器";
            this.btnReportDesign.UseVisualStyleBackColor = true;
            this.btnReportDesign.Click += new System.EventHandler(this.btnReportDesign_Click);
            // 
            // btnQueryOldSource
            // 
            this.btnQueryOldSource.Location = new System.Drawing.Point(222, 6);
            this.btnQueryOldSource.Name = "btnQueryOldSource";
            this.btnQueryOldSource.Size = new System.Drawing.Size(120, 23);
            this.btnQueryOldSource.TabIndex = 2;
            this.btnQueryOldSource.Text = "查看报表原始数据";
            this.btnQueryOldSource.UseVisualStyleBackColor = true;
            this.btnQueryOldSource.Click += new System.EventHandler(this.btnQueryOldSource_Click);
            // 
            // btnPringtview
            // 
            this.btnPringtview.Location = new System.Drawing.Point(120, 6);
            this.btnPringtview.Name = "btnPringtview";
            this.btnPringtview.Size = new System.Drawing.Size(75, 23);
            this.btnPringtview.TabIndex = 1;
            this.btnPringtview.Text = "打印预览";
            this.btnPringtview.UseVisualStyleBackColor = true;
            this.btnPringtview.Click += new System.EventHandler(this.btnPringtview_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(22, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "公共报表管理";
            this.Name = "FrmReport";
            this.Text = "公共报表管理";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.Controls.SetChildIndex(this.plTitle, 0);
            this.Controls.SetChildIndex(this.plBaseToolbar, 0);
            this.Controls.SetChildIndex(this.plBaseStatus, 0);
            this.Controls.SetChildIndex(this.plBaseWorkArea, 0);
            this.plBaseWorkArea.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabPageControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInParam)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TreeView TvReport;
        private GWI.HIS.Windows.Controls.Controls.TabPageControl tabPageControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvInParam;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProcess;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnPringtview;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuAddType;
        private System.Windows.Forms.ToolStripMenuItem MenuAddReport;
        private System.Windows.Forms.ToolStripMenuItem MenuUpdate;
        private System.Windows.Forms.ToolStripMenuItem MenuDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnDelParam;
        private System.Windows.Forms.Button btnAddParam;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnQueryOldSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 参数ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 参数名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 参数别名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数据类型名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数据类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 大小;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn 控件类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPORT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOREIGNER_FIELD_CN_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOREIGNER_FIELD_DB_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOREIGNER_FILTER_SQL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENUMEID;
        private System.Windows.Forms.Button btnReportDesign;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}