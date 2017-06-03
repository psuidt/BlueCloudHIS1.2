namespace HIS_EMRManager
{
    partial class FrmEmrMouldSite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmrMouldSite));
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("全院级模板");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("科室级模板");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("个人级模板");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("全院级模板");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("科室级模板");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("个人级模板");
            this.cMnSChief = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMnIAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.plCenter = new System.Windows.Forms.Panel();
            this.tCMain = new System.Windows.Forms.TabControl();
            this.tPWhole = new System.Windows.Forms.TabPage();
            this.plWholeCenter = new System.Windows.Forms.Panel();
            this.plWholeTool = new System.Windows.Forms.Panel();
            this.btSaveMould = new System.Windows.Forms.Button();
            this.plWholeLeft = new System.Windows.Forms.Panel();
            this.tVEmrClass = new System.Windows.Forms.TreeView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tVWholeLevel = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tPElement = new System.Windows.Forms.TabPage();
            this.plElementCenter = new System.Windows.Forms.Panel();
            this.dGVMouldList = new System.Windows.Forms.DataGridView();
            this.RowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MouldContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.plElementTool = new System.Windows.Forms.Panel();
            this.btDelElementMould = new System.Windows.Forms.Button();
            this.btSaveElementMould = new System.Windows.Forms.Button();
            this.btAddElementMould = new System.Windows.Forms.Button();
            this.plElementLeft = new System.Windows.Forms.Panel();
            this.tVEmrElement = new System.Windows.Forms.TreeView();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.tVElementLevel = new System.Windows.Forms.TreeView();
            this.cMnSMould = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMnIDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMnIRename = new System.Windows.Forms.ToolStripMenuItem();
            this.plBaseWorkArea.SuspendLayout();
            this.cMnSChief.SuspendLayout();
            this.plCenter.SuspendLayout();
            this.tCMain.SuspendLayout();
            this.tPWhole.SuspendLayout();
            this.plWholeTool.SuspendLayout();
            this.plWholeLeft.SuspendLayout();
            this.tPElement.SuspendLayout();
            this.plElementCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVMouldList)).BeginInit();
            this.plElementTool.SuspendLayout();
            this.plElementLeft.SuspendLayout();
            this.cMnSMould.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Size = new System.Drawing.Size(629, 29);
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
            this.baseImageList.Images.SetKeyName(21, "新建.gif");
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point(0, 442);
            this.plBaseStatus.Size = new System.Drawing.Size(629, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.plBaseWorkArea.Controls.Add(this.plCenter);
            this.plBaseWorkArea.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plBaseWorkArea.Size = new System.Drawing.Size(629, 379);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(629, 34);
            // 
            // cMnSChief
            // 
            this.cMnSChief.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMnIAdd});
            this.cMnSChief.Name = "cMnSChief";
            this.cMnSChief.Size = new System.Drawing.Size(123, 26);
            // 
            // tSMnIAdd
            // 
            this.tSMnIAdd.Name = "tSMnIAdd";
            this.tSMnIAdd.Size = new System.Drawing.Size(122, 22);
            this.tSMnIAdd.Text = "新增模板";
            this.tSMnIAdd.Click += new System.EventHandler(this.tSMnIAdd_Click);
            // 
            // plCenter
            // 
            this.plCenter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plCenter.BackgroundImage")));
            this.plCenter.Controls.Add(this.tCMain);
            this.plCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plCenter.Location = new System.Drawing.Point(0, 0);
            this.plCenter.Name = "plCenter";
            this.plCenter.Size = new System.Drawing.Size(629, 379);
            this.plCenter.TabIndex = 1;
            // 
            // tCMain
            // 
            this.tCMain.Controls.Add(this.tPWhole);
            this.tCMain.Controls.Add(this.tPElement);
            this.tCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tCMain.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tCMain.Location = new System.Drawing.Point(0, 0);
            this.tCMain.Multiline = true;
            this.tCMain.Name = "tCMain";
            this.tCMain.SelectedIndex = 0;
            this.tCMain.Size = new System.Drawing.Size(629, 379);
            this.tCMain.TabIndex = 2;
            // 
            // tPWhole
            // 
            this.tPWhole.BackColor = System.Drawing.Color.Transparent;
            this.tPWhole.Controls.Add(this.plWholeCenter);
            this.tPWhole.Controls.Add(this.plWholeTool);
            this.tPWhole.Controls.Add(this.plWholeLeft);
            this.tPWhole.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tPWhole.Location = new System.Drawing.Point(4, 23);
            this.tPWhole.Name = "tPWhole";
            this.tPWhole.Padding = new System.Windows.Forms.Padding(3);
            this.tPWhole.Size = new System.Drawing.Size(621, 352);
            this.tPWhole.TabIndex = 0;
            this.tPWhole.Text = "整体模板";
            this.tPWhole.UseVisualStyleBackColor = true;
            // 
            // plWholeCenter
            // 
            this.plWholeCenter.AutoScroll = true;
            this.plWholeCenter.AutoScrollMargin = new System.Drawing.Size(2, 0);
            this.plWholeCenter.AutoScrollMinSize = new System.Drawing.Size(2, 0);
            this.plWholeCenter.BackColor = System.Drawing.Color.White;
            this.plWholeCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plWholeCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plWholeCenter.Location = new System.Drawing.Point(153, 3);
            this.plWholeCenter.Name = "plWholeCenter";
            this.plWholeCenter.Size = new System.Drawing.Size(465, 308);
            this.plWholeCenter.TabIndex = 7;
            // 
            // plWholeTool
            // 
            this.plWholeTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.plWholeTool.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plWholeTool.Controls.Add(this.btSaveMould);
            this.plWholeTool.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plWholeTool.Location = new System.Drawing.Point(153, 311);
            this.plWholeTool.Name = "plWholeTool";
            this.plWholeTool.Size = new System.Drawing.Size(465, 38);
            this.plWholeTool.TabIndex = 3;
            // 
            // btSaveMould
            // 
            this.btSaveMould.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveMould.Location = new System.Drawing.Point(293, 6);
            this.btSaveMould.Name = "btSaveMould";
            this.btSaveMould.Size = new System.Drawing.Size(75, 23);
            this.btSaveMould.TabIndex = 2;
            this.btSaveMould.Text = "保存";
            this.btSaveMould.UseVisualStyleBackColor = true;
            this.btSaveMould.Click += new System.EventHandler(this.btSaveMould_Click);
            // 
            // plWholeLeft
            // 
            this.plWholeLeft.Controls.Add(this.tVEmrClass);
            this.plWholeLeft.Controls.Add(this.splitter2);
            this.plWholeLeft.Controls.Add(this.tVWholeLevel);
            this.plWholeLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plWholeLeft.Location = new System.Drawing.Point(3, 3);
            this.plWholeLeft.Name = "plWholeLeft";
            this.plWholeLeft.Size = new System.Drawing.Size(150, 346);
            this.plWholeLeft.TabIndex = 2;
            // 
            // tVEmrClass
            // 
            this.tVEmrClass.ContextMenuStrip = this.cMnSChief;
            this.tVEmrClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tVEmrClass.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tVEmrClass.ImageIndex = 0;
            this.tVEmrClass.ImageList = this.baseImageList;
            this.tVEmrClass.Location = new System.Drawing.Point(0, 89);
            this.tVEmrClass.Name = "tVEmrClass";
            this.tVEmrClass.SelectedImageIndex = 0;
            this.tVEmrClass.Size = new System.Drawing.Size(150, 257);
            this.tVEmrClass.TabIndex = 4;
            this.tVEmrClass.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tVEmrClass_AfterSelect);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 86);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(150, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // tVWholeLevel
            // 
            this.tVWholeLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tVWholeLevel.ImageIndex = 0;
            this.tVWholeLevel.ImageList = this.imageList;
            this.tVWholeLevel.Location = new System.Drawing.Point(0, 0);
            this.tVWholeLevel.Name = "tVWholeLevel";
            treeNode7.Name = "TNWholeHospital";
            treeNode7.Tag = "1";
            treeNode7.Text = "全院级模板";
            treeNode8.Name = "TNWholeDept";
            treeNode8.Tag = "2";
            treeNode8.Text = "科室级模板";
            treeNode9.Name = "TNWholePerson";
            treeNode9.Tag = "3";
            treeNode9.Text = "个人级模板";
            this.tVWholeLevel.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            this.tVWholeLevel.SelectedImageIndex = 1;
            this.tVWholeLevel.Size = new System.Drawing.Size(150, 86);
            this.tVWholeLevel.TabIndex = 2;
            this.tVWholeLevel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tVWholeLevel_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "vcmiconincludedfolder.jpg");
            this.imageList.Images.SetKeyName(1, "vcmiconresolvedfolder.jpg");
            // 
            // tPElement
            // 
            this.tPElement.BackColor = System.Drawing.Color.Transparent;
            this.tPElement.Controls.Add(this.plElementCenter);
            this.tPElement.Controls.Add(this.plElementTool);
            this.tPElement.Controls.Add(this.plElementLeft);
            this.tPElement.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tPElement.Location = new System.Drawing.Point(4, 23);
            this.tPElement.Name = "tPElement";
            this.tPElement.Padding = new System.Windows.Forms.Padding(3);
            this.tPElement.Size = new System.Drawing.Size(621, 352);
            this.tPElement.TabIndex = 1;
            this.tPElement.Text = "元素模板";
            this.tPElement.UseVisualStyleBackColor = true;
            // 
            // plElementCenter
            // 
            this.plElementCenter.Controls.Add(this.dGVMouldList);
            this.plElementCenter.Controls.Add(this.txtContent);
            this.plElementCenter.Controls.Add(this.splitter1);
            this.plElementCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plElementCenter.Location = new System.Drawing.Point(153, 3);
            this.plElementCenter.Name = "plElementCenter";
            this.plElementCenter.Size = new System.Drawing.Size(465, 308);
            this.plElementCenter.TabIndex = 5;
            // 
            // dGVMouldList
            // 
            this.dGVMouldList.AllowUserToAddRows = false;
            this.dGVMouldList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.dGVMouldList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dGVMouldList.BackgroundColor = System.Drawing.Color.White;
            this.dGVMouldList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(192)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVMouldList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dGVMouldList.ColumnHeadersHeight = 25;
            this.dGVMouldList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNo,
            this.MouldContent});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVMouldList.DefaultCellStyle = dataGridViewCellStyle7;
            this.dGVMouldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVMouldList.EnableHeadersVisualStyles = false;
            this.dGVMouldList.Location = new System.Drawing.Point(0, 3);
            this.dGVMouldList.Name = "dGVMouldList";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(192)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVMouldList.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dGVMouldList.RowHeadersWidth = 25;
            this.dGVMouldList.RowTemplate.Height = 23;
            this.dGVMouldList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVMouldList.Size = new System.Drawing.Size(465, 200);
            this.dGVMouldList.TabIndex = 4;
            this.dGVMouldList.CurrentCellChanged += new System.EventHandler(this.dGVMouldList_CurrentCellChanged);
            // 
            // RowNo
            // 
            this.RowNo.DataPropertyName = "RowNo";
            this.RowNo.HeaderText = "编号";
            this.RowNo.Name = "RowNo";
            this.RowNo.Width = 45;
            // 
            // MouldContent
            // 
            this.MouldContent.DataPropertyName = "MouldContent";
            this.MouldContent.HeaderText = "内容";
            this.MouldContent.Name = "MouldContent";
            this.MouldContent.ReadOnly = true;
            this.MouldContent.Width = 1200;
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtContent.Location = new System.Drawing.Point(0, 203);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(465, 105);
            this.txtContent.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(465, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // plElementTool
            // 
            this.plElementTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.plElementTool.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plElementTool.Controls.Add(this.btDelElementMould);
            this.plElementTool.Controls.Add(this.btSaveElementMould);
            this.plElementTool.Controls.Add(this.btAddElementMould);
            this.plElementTool.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plElementTool.Location = new System.Drawing.Point(153, 311);
            this.plElementTool.Name = "plElementTool";
            this.plElementTool.Size = new System.Drawing.Size(465, 38);
            this.plElementTool.TabIndex = 4;
            // 
            // btDelElementMould
            // 
            this.btDelElementMould.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelElementMould.Location = new System.Drawing.Point(347, 6);
            this.btDelElementMould.Name = "btDelElementMould";
            this.btDelElementMould.Size = new System.Drawing.Size(75, 23);
            this.btDelElementMould.TabIndex = 2;
            this.btDelElementMould.Text = "删除";
            this.btDelElementMould.UseVisualStyleBackColor = true;
            this.btDelElementMould.Click += new System.EventHandler(this.btDelElementMould_Click);
            // 
            // btSaveElementMould
            // 
            this.btSaveElementMould.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveElementMould.Location = new System.Drawing.Point(254, 6);
            this.btSaveElementMould.Name = "btSaveElementMould";
            this.btSaveElementMould.Size = new System.Drawing.Size(75, 23);
            this.btSaveElementMould.TabIndex = 1;
            this.btSaveElementMould.Text = "保存";
            this.btSaveElementMould.UseVisualStyleBackColor = true;
            this.btSaveElementMould.Click += new System.EventHandler(this.btSaveElementMould_Click);
            // 
            // btAddElementMould
            // 
            this.btAddElementMould.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddElementMould.Location = new System.Drawing.Point(162, 6);
            this.btAddElementMould.Name = "btAddElementMould";
            this.btAddElementMould.Size = new System.Drawing.Size(75, 23);
            this.btAddElementMould.TabIndex = 0;
            this.btAddElementMould.Text = "新增";
            this.btAddElementMould.UseVisualStyleBackColor = true;
            this.btAddElementMould.Click += new System.EventHandler(this.btAddElementMould_Click);
            // 
            // plElementLeft
            // 
            this.plElementLeft.Controls.Add(this.tVEmrElement);
            this.plElementLeft.Controls.Add(this.splitter3);
            this.plElementLeft.Controls.Add(this.tVElementLevel);
            this.plElementLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plElementLeft.Location = new System.Drawing.Point(3, 3);
            this.plElementLeft.Name = "plElementLeft";
            this.plElementLeft.Size = new System.Drawing.Size(150, 346);
            this.plElementLeft.TabIndex = 1;
            // 
            // tVEmrElement
            // 
            this.tVEmrElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tVEmrElement.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tVEmrElement.ImageIndex = 0;
            this.tVEmrElement.ImageList = this.baseImageList;
            this.tVEmrElement.Location = new System.Drawing.Point(0, 89);
            this.tVEmrElement.Name = "tVEmrElement";
            this.tVEmrElement.SelectedImageIndex = 0;
            this.tVEmrElement.Size = new System.Drawing.Size(150, 257);
            this.tVEmrElement.TabIndex = 5;
            this.tVEmrElement.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tVEmrElement_AfterSelect);
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 86);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(150, 3);
            this.splitter3.TabIndex = 4;
            this.splitter3.TabStop = false;
            // 
            // tVElementLevel
            // 
            this.tVElementLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tVElementLevel.ImageIndex = 0;
            this.tVElementLevel.ImageList = this.imageList;
            this.tVElementLevel.Location = new System.Drawing.Point(0, 0);
            this.tVElementLevel.Name = "tVElementLevel";
            treeNode1.Name = "TNWholeHospital";
            treeNode1.Tag = "1";
            treeNode1.Text = "全院级模板";
            treeNode2.Name = "TNWholeDept";
            treeNode2.Tag = "2";
            treeNode2.Text = "科室级模板";
            treeNode3.Name = "TNWholePerson";
            treeNode3.Tag = "3";
            treeNode3.Text = "个人级模板";
            this.tVElementLevel.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tVElementLevel.SelectedImageIndex = 1;
            this.tVElementLevel.Size = new System.Drawing.Size(150, 86);
            this.tVElementLevel.TabIndex = 3;
            this.tVElementLevel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tVElementLevel_AfterSelect);
            // 
            // cMnSMould
            // 
            this.cMnSMould.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMnIDel,
            this.tSMnIRename});
            this.cMnSMould.Name = "cMnSChief";
            this.cMnSMould.Size = new System.Drawing.Size(123, 48);
            // 
            // tSMnIDel
            // 
            this.tSMnIDel.Name = "tSMnIDel";
            this.tSMnIDel.Size = new System.Drawing.Size(122, 22);
            this.tSMnIDel.Text = "删除模板";
            this.tSMnIDel.Click += new System.EventHandler(this.tSMnIDel_Click);
            // 
            // tSMnIRename
            // 
            this.tSMnIRename.Name = "tSMnIRename";
            this.tSMnIRename.Size = new System.Drawing.Size(122, 22);
            this.tSMnIRename.Text = "重命名";
            this.tSMnIRename.Click += new System.EventHandler(this.tSMnIRename_Click);
            // 
            // FrmEmrMouldSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 468);
            this.Name = "FrmEmrMouldSite";
            this.Text = "FrmEmrMouldSite";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEmrMouldSite_Load);
            this.Controls.SetChildIndex(this.plTitle, 0);
            this.Controls.SetChildIndex(this.plBaseToolbar, 0);
            this.Controls.SetChildIndex(this.plBaseStatus, 0);
            this.Controls.SetChildIndex(this.plBaseWorkArea, 0);
            this.plBaseWorkArea.ResumeLayout(false);
            this.cMnSChief.ResumeLayout(false);
            this.plCenter.ResumeLayout(false);
            this.tCMain.ResumeLayout(false);
            this.tPWhole.ResumeLayout(false);
            this.plWholeTool.ResumeLayout(false);
            this.plWholeLeft.ResumeLayout(false);
            this.tPElement.ResumeLayout(false);
            this.plElementCenter.ResumeLayout(false);
            this.plElementCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVMouldList)).EndInit();
            this.plElementTool.ResumeLayout(false);
            this.plElementLeft.ResumeLayout(false);
            this.cMnSMould.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plCenter;
        private System.Windows.Forms.TabControl tCMain;
        private System.Windows.Forms.TabPage tPWhole;
        private System.Windows.Forms.TabPage tPElement;
        private System.Windows.Forms.Panel plWholeLeft;
        private System.Windows.Forms.Panel plElementLeft;
        private System.Windows.Forms.Panel plWholeTool;
        private System.Windows.Forms.Panel plElementTool;
        private System.Windows.Forms.Panel plElementCenter;
        private System.Windows.Forms.Panel plWholeCenter;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btDelElementMould;
        private System.Windows.Forms.Button btSaveElementMould;
        private System.Windows.Forms.Button btAddElementMould;
        private System.Windows.Forms.Button btSaveMould;
        private System.Windows.Forms.ContextMenuStrip cMnSChief;
        private System.Windows.Forms.ToolStripMenuItem tSMnIAdd;
        private System.Windows.Forms.ContextMenuStrip cMnSMould;
        private System.Windows.Forms.ToolStripMenuItem tSMnIDel;
        private System.Windows.Forms.ToolStripMenuItem tSMnIRename;
        private System.Windows.Forms.DataGridView dGVMouldList;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MouldContent;
        private System.Windows.Forms.TreeView tVWholeLevel;
        private System.Windows.Forms.TreeView tVEmrClass;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TreeView tVEmrElement;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.TreeView tVElementLevel;
    }
}