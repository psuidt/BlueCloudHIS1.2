namespace HIS_BaseManager
{
    partial class FrmEmpDeptSetting
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmEmpDeptSetting ) );
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvwDeptlayer = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.menuEditLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList( this.components );
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lvwEmployee = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.menuEditEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkNotUse = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lvwDept = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.menuEditDept = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList( this.components );
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip();
            this.btnAddLayer = new System.Windows.Forms.ToolStripButton();
            this.btnEditLayer = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteLayer = new System.Windows.Forms.ToolStripButton();
            this.btnAddDept = new System.Windows.Forms.ToolStripButton();
            this.btnEditDept = new System.Windows.Forms.ToolStripButton();
            this.btnAddEmployee = new System.Windows.Forms.ToolStripButton();
            this.btnEditEmployee = new System.Windows.Forms.ToolStripButton();
            this.btnShowAll = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add( this.toolStrip1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 884, 31 );
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
            this.plBaseStatus.Location = new System.Drawing.Point( 0, 461 );
            this.plBaseStatus.Size = new System.Drawing.Size( 884, 5 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.splitContainer1 );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0, 65 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 884, 396 );
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0, 0 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.tvwDeptlayer );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.panel2 );
            this.splitContainer1.Panel2.Controls.Add( this.splitter1 );
            this.splitContainer1.Panel2.Controls.Add( this.panel1 );
            this.splitContainer1.Size = new System.Drawing.Size( 884, 396 );
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvwDeptlayer
            // 
            this.tvwDeptlayer.ContextMenuStrip = this.contextMenuStrip1;
            this.tvwDeptlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwDeptlayer.HideSelection = false;
            this.tvwDeptlayer.ImageIndex = 0;
            this.tvwDeptlayer.ImageList = this.imageList1;
            this.tvwDeptlayer.Location = new System.Drawing.Point( 0, 0 );
            this.tvwDeptlayer.Name = "tvwDeptlayer";
            this.tvwDeptlayer.SelectedImageIndex = 1;
            this.tvwDeptlayer.Size = new System.Drawing.Size( 233, 396 );
            this.tvwDeptlayer.TabIndex = 0;
            this.tvwDeptlayer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.tvwDeptlayer_AfterSelect );
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.menuEditLayer,
            this.menuDeleteLayer} );
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size( 95, 48 );
            // 
            // menuEditLayer
            // 
            this.menuEditLayer.Name = "menuEditLayer";
            this.menuEditLayer.Size = new System.Drawing.Size( 94, 22 );
            this.menuEditLayer.Text = "修改";
            this.menuEditLayer.Click += new System.EventHandler( this.menuEditLayer_Click );
            // 
            // menuDeleteLayer
            // 
            this.menuDeleteLayer.Name = "menuDeleteLayer";
            this.menuDeleteLayer.Size = new System.Drawing.Size( 94, 22 );
            this.menuDeleteLayer.Text = "删除";
            this.menuDeleteLayer.Click += new System.EventHandler( this.menuDeleteLayer_Click );
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList1.ImageStream" ) ) );
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName( 0, "close" );
            this.imageList1.Images.SetKeyName( 1, "open" );
            this.imageList1.Images.SetKeyName( 2, "user" );
            this.imageList1.Images.SetKeyName( 3, "computer" );
            this.imageList1.Images.SetKeyName( 4, "删除.ico" );
            this.imageList1.Images.SetKeyName( 5, "hand.ico" );
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.panel6 );
            this.panel2.Controls.Add( this.panel5 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 217, 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 430, 396 );
            this.panel2.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add( this.lvwEmployee );
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point( 0, 0 );
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size( 430, 367 );
            this.panel6.TabIndex = 3;
            // 
            // lvwEmployee
            // 
            this.lvwEmployee.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4} );
            this.lvwEmployee.ContextMenuStrip = this.contextMenuStrip3;
            this.lvwEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwEmployee.HideSelection = false;
            this.lvwEmployee.Location = new System.Drawing.Point( 0, 0 );
            this.lvwEmployee.Name = "lvwEmployee";
            this.lvwEmployee.Size = new System.Drawing.Size( 430, 367 );
            this.lvwEmployee.SmallImageList = this.imageList1;
            this.lvwEmployee.TabIndex = 1;
            this.lvwEmployee.UseCompatibleStateImageBehavior = false;
            this.lvwEmployee.View = System.Windows.Forms.View.Details;
            this.lvwEmployee.DoubleClick += new System.EventHandler( this.lvwEmployee_DoubleClick );
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 137;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "用户名";
            this.columnHeader3.Width = 128;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "类型";
            this.columnHeader4.Width = 113;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.menuEditEmployee} );
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size( 95, 26 );
            // 
            // menuEditEmployee
            // 
            this.menuEditEmployee.Name = "menuEditEmployee";
            this.menuEditEmployee.Size = new System.Drawing.Size( 94, 22 );
            this.menuEditEmployee.Text = "修改";
            this.menuEditEmployee.Click += new System.EventHandler( this.menuEditEmployee_Click );
            // 
            // panel5
            // 
            this.panel5.Controls.Add( this.chkNotUse );
            this.panel5.Controls.Add( this.textBox2 );
            this.panel5.Controls.Add( this.label2 );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point( 0, 367 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 430, 29 );
            this.panel5.TabIndex = 2;
            // 
            // chkNotUse
            // 
            this.chkNotUse.AutoSize = true;
            this.chkNotUse.Location = new System.Drawing.Point( 343, 7 );
            this.chkNotUse.Name = "chkNotUse";
            this.chkNotUse.Size = new System.Drawing.Size( 84, 16 );
            this.chkNotUse.TabIndex = 4;
            this.chkNotUse.Text = "包括已禁用";
            this.chkNotUse.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.textBox2.Location = new System.Drawing.Point( 65, 3 );
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size( 272, 21 );
            this.textBox2.TabIndex = 3;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.textBox2_KeyPress );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 6, 6 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53, 12 );
            this.label2.TabIndex = 2;
            this.label2.Text = "人员检索";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point( 214, 0 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 3, 396 );
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.panel4 );
            this.panel1.Controls.Add( this.panel3 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 214, 396 );
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.lvwDept );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point( 0, 0 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 214, 367 );
            this.panel4.TabIndex = 2;
            // 
            // lvwDept
            // 
            this.lvwDept.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1} );
            this.lvwDept.ContextMenuStrip = this.contextMenuStrip2;
            this.lvwDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDept.HideSelection = false;
            this.lvwDept.Location = new System.Drawing.Point( 0, 0 );
            this.lvwDept.MultiSelect = false;
            this.lvwDept.Name = "lvwDept";
            this.lvwDept.Size = new System.Drawing.Size( 214, 367 );
            this.lvwDept.SmallImageList = this.imageList1;
            this.lvwDept.TabIndex = 0;
            this.lvwDept.UseCompatibleStateImageBehavior = false;
            this.lvwDept.View = System.Windows.Forms.View.Details;
            this.lvwDept.SelectedIndexChanged += new System.EventHandler( this.lvwDept_SelectedIndexChanged );
            this.lvwDept.DoubleClick += new System.EventHandler( this.lvwDept_DoubleClick );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "科室名称";
            this.columnHeader1.Width = 191;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.menuEditDept} );
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size( 95, 26 );
            // 
            // menuEditDept
            // 
            this.menuEditDept.Name = "menuEditDept";
            this.menuEditDept.Size = new System.Drawing.Size( 94, 22 );
            this.menuEditDept.Text = "修改";
            this.menuEditDept.Click += new System.EventHandler( this.menuEditDept_Click );
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.textBox1 );
            this.panel3.Controls.Add( this.label1 );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point( 0, 367 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 214, 29 );
            this.panel3.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.textBox1.Location = new System.Drawing.Point( 62, 3 );
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size( 146, 21 );
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.textBox1_KeyPress );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 3, 6 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 53, 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "科室检索";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList2.ImageStream" ) ) );
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName( 0, "修改.ico" );
            this.imageList2.Images.SetKeyName( 1, "新增.ico" );
            this.imageList2.Images.SetKeyName( 2, "退出.ico" );
            this.imageList2.Images.SetKeyName( 3, "删除.ico" );
            this.imageList2.Images.SetKeyName( 4, "科室.ico" );
            this.imageList2.Images.SetKeyName( 5, "层次.ico" );
            this.imageList2.Images.SetKeyName( 6, "人员.ico" );
            this.imageList2.Images.SetKeyName( 7, "刷新.ico" );
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "toolStrip1.BackgroundImage" ) ) );
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font( "宋体", 10F );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.btnAddLayer,
            this.btnEditLayer,
            this.btnDeleteLayer,
            this.btnAddDept,
            this.btnEditDept,
            this.btnAddEmployee,
            this.btnEditEmployee,
            this.btnShowAll,
            this.btnClose} );
            this.toolStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 884, 31 );
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddLayer
            // 
            this.btnAddLayer.Image = ( (System.Drawing.Image)( resources.GetObject( "btnAddLayer.Image" ) ) );
            this.btnAddLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddLayer.Name = "btnAddLayer";
            this.btnAddLayer.Size = new System.Drawing.Size( 83, 28 );
            this.btnAddLayer.Text = "新增分层";
            this.btnAddLayer.Click += new System.EventHandler( this.btnAddLayer_Click );
            // 
            // btnEditLayer
            // 
            this.btnEditLayer.Image = ( (System.Drawing.Image)( resources.GetObject( "btnEditLayer.Image" ) ) );
            this.btnEditLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditLayer.Name = "btnEditLayer";
            this.btnEditLayer.Size = new System.Drawing.Size( 83, 28 );
            this.btnEditLayer.Text = "修改分层";
            this.btnEditLayer.Click += new System.EventHandler( this.btnEditLayer_Click );
            // 
            // btnDeleteLayer
            // 
            this.btnDeleteLayer.Image = ( (System.Drawing.Image)( resources.GetObject( "btnDeleteLayer.Image" ) ) );
            this.btnDeleteLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteLayer.Name = "btnDeleteLayer";
            this.btnDeleteLayer.Size = new System.Drawing.Size( 83, 28 );
            this.btnDeleteLayer.Text = "删除分层";
            this.btnDeleteLayer.Click += new System.EventHandler( this.btnDeleteLayer_Click );
            // 
            // btnAddDept
            // 
            this.btnAddDept.Image = ( (System.Drawing.Image)( resources.GetObject( "btnAddDept.Image" ) ) );
            this.btnAddDept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDept.Name = "btnAddDept";
            this.btnAddDept.Size = new System.Drawing.Size( 83, 28 );
            this.btnAddDept.Text = "新增科室";
            this.btnAddDept.Click += new System.EventHandler( this.btnAddDept_Click );
            // 
            // btnEditDept
            // 
            this.btnEditDept.Image = ( (System.Drawing.Image)( resources.GetObject( "btnEditDept.Image" ) ) );
            this.btnEditDept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditDept.Name = "btnEditDept";
            this.btnEditDept.Size = new System.Drawing.Size( 83, 28 );
            this.btnEditDept.Text = "修改科室";
            this.btnEditDept.Click += new System.EventHandler( this.btnEditDept_Click );
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Image = ( (System.Drawing.Image)( resources.GetObject( "btnAddEmployee.Image" ) ) );
            this.btnAddEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size( 83, 28 );
            this.btnAddEmployee.Text = "新增人员";
            this.btnAddEmployee.Click += new System.EventHandler( this.btnAddEmployee_Click );
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Image = ( (System.Drawing.Image)( resources.GetObject( "btnEditEmployee.Image" ) ) );
            this.btnEditEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size( 83, 28 );
            this.btnEditEmployee.Text = "修改人员";
            this.btnEditEmployee.Click += new System.EventHandler( this.btnEditEmployee_Click );
            // 
            // btnShowAll
            // 
            this.btnShowAll.Image = ( (System.Drawing.Image)( resources.GetObject( "btnShowAll.Image" ) ) );
            this.btnShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size( 83, 28 );
            this.btnShowAll.Text = "刷新显示";
            this.btnShowAll.Click += new System.EventHandler( this.btnShowAll_Click );
            // 
            // btnClose
            // 
            this.btnClose.Image = ( (System.Drawing.Image)( resources.GetObject( "btnClose.Image" ) ) );
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 83, 28 );
            this.btnClose.Text = "关闭窗口";
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // FrmEmpDeptSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 884, 466 );
            this.FormTitle = "科室人员设置";
            this.Name = "FrmEmpDeptSetting";
            this.Text = "Form1";
            this.Load += new System.EventHandler( this.FrmMain_Load );
            this.Controls.SetChildIndex( this.plBaseToolbar, 0 );
            this.Controls.SetChildIndex( this.plBaseStatus, 0 );
            this.Controls.SetChildIndex( this.plBaseWorkArea, 0 );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout( false );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.contextMenuStrip1.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            this.panel6.ResumeLayout( false );
            this.contextMenuStrip3.ResumeLayout( false );
            this.panel5.ResumeLayout( false );
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout( false );
            this.panel4.ResumeLayout( false );
            this.contextMenuStrip2.ResumeLayout( false );
            this.panel3.ResumeLayout( false );
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvwDeptlayer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ListView lvwEmployee;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvwDept;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEditLayer;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteLayer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem menuEditDept;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem menuEditEmployee;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddLayer;
        private System.Windows.Forms.ToolStripButton btnEditLayer;
        private System.Windows.Forms.ToolStripButton btnDeleteLayer;
        private System.Windows.Forms.ToolStripButton btnAddDept;
        private System.Windows.Forms.ToolStripButton btnEditDept;
        private System.Windows.Forms.ToolStripButton btnAddEmployee;
        private System.Windows.Forms.ToolStripButton btnEditEmployee;
        private System.Windows.Forms.ToolStripButton btnShowAll;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.CheckBox chkNotUse;
    }
}

