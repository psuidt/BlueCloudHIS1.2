namespace HIS_EMRManager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("全院级模板");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("科室级模板");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("个人级模板");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("全院级模板");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("科室级模板");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("个人级模板");
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
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cMnSMould = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMnIDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMnIRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnSChief = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMnIAdd = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cMnSChief.SuspendLayout();
            this.SuspendLayout();
            // 
            // plCenter
            // 
            this.plCenter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plCenter.BackgroundImage")));
            this.plCenter.Controls.Add(this.tCMain);
            this.plCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plCenter.Location = new System.Drawing.Point(0, 0);
            this.plCenter.Name = "plCenter";
            this.plCenter.Size = new System.Drawing.Size(721, 477);
            this.plCenter.TabIndex = 2;
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
            this.tCMain.Size = new System.Drawing.Size(721, 477);
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
            this.tPWhole.Size = new System.Drawing.Size(713, 450);
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
            this.plWholeCenter.Size = new System.Drawing.Size(557, 406);
            this.plWholeCenter.TabIndex = 7;
            // 
            // plWholeTool
            // 
            this.plWholeTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.plWholeTool.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plWholeTool.Controls.Add(this.btSaveMould);
            this.plWholeTool.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plWholeTool.Location = new System.Drawing.Point(153, 409);
            this.plWholeTool.Name = "plWholeTool";
            this.plWholeTool.Size = new System.Drawing.Size(557, 38);
            this.plWholeTool.TabIndex = 3;
            // 
            // btSaveMould
            // 
            this.btSaveMould.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveMould.Location = new System.Drawing.Point(385, 6);
            this.btSaveMould.Name = "btSaveMould";
            this.btSaveMould.Size = new System.Drawing.Size(75, 23);
            this.btSaveMould.TabIndex = 2;
            this.btSaveMould.Text = "保存";
            this.btSaveMould.UseVisualStyleBackColor = true;
            // 
            // plWholeLeft
            // 
            this.plWholeLeft.Controls.Add(this.tVEmrClass);
            this.plWholeLeft.Controls.Add(this.splitter2);
            this.plWholeLeft.Controls.Add(this.tVWholeLevel);
            this.plWholeLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plWholeLeft.Location = new System.Drawing.Point(3, 3);
            this.plWholeLeft.Name = "plWholeLeft";
            this.plWholeLeft.Size = new System.Drawing.Size(150, 444);
            this.plWholeLeft.TabIndex = 2;
            // 
            // tVEmrClass
            // 
            this.tVEmrClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tVEmrClass.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tVEmrClass.Location = new System.Drawing.Point(0, 89);
            this.tVEmrClass.Name = "tVEmrClass";
            this.tVEmrClass.Size = new System.Drawing.Size(150, 355);
            this.tVEmrClass.TabIndex = 4;
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
            this.tVWholeLevel.Location = new System.Drawing.Point(0, 0);
            this.tVWholeLevel.Name = "tVWholeLevel";
            treeNode1.Name = "TNWholeHospital";
            treeNode1.Tag = "1";
            treeNode1.Text = "全院级模板";
            treeNode2.Name = "TNWholeDept";
            treeNode2.Tag = "2";
            treeNode2.Text = "科室级模板";
            treeNode3.Name = "TNWholePerson";
            treeNode3.Tag = "3";
            treeNode3.Text = "个人级模板";
            this.tVWholeLevel.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tVWholeLevel.Size = new System.Drawing.Size(150, 86);
            this.tVWholeLevel.TabIndex = 2;
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.dGVMouldList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVMouldList.BackgroundColor = System.Drawing.Color.White;
            this.dGVMouldList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(192)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVMouldList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVMouldList.ColumnHeadersHeight = 25;
            this.dGVMouldList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNo,
            this.MouldContent});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVMouldList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGVMouldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVMouldList.EnableHeadersVisualStyles = false;
            this.dGVMouldList.Location = new System.Drawing.Point(0, 3);
            this.dGVMouldList.Name = "dGVMouldList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(192)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVMouldList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVMouldList.RowHeadersWidth = 25;
            this.dGVMouldList.RowTemplate.Height = 23;
            this.dGVMouldList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVMouldList.Size = new System.Drawing.Size(465, 200);
            this.dGVMouldList.TabIndex = 4;
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
            this.tVEmrElement.Location = new System.Drawing.Point(0, 89);
            this.tVEmrElement.Name = "tVEmrElement";
            this.tVEmrElement.Size = new System.Drawing.Size(150, 257);
            this.tVEmrElement.TabIndex = 5;
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
            this.tVElementLevel.Location = new System.Drawing.Point(0, 0);
            this.tVElementLevel.Name = "tVElementLevel";
            treeNode4.Name = "TNWholeHospital";
            treeNode4.Tag = "1";
            treeNode4.Text = "全院级模板";
            treeNode5.Name = "TNWholeDept";
            treeNode5.Tag = "2";
            treeNode5.Text = "科室级模板";
            treeNode6.Name = "TNWholePerson";
            treeNode6.Tag = "3";
            treeNode6.Text = "个人级模板";
            this.tVElementLevel.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.tVElementLevel.Size = new System.Drawing.Size(150, 86);
            this.tVElementLevel.TabIndex = 3;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "vcmiconincludedfolder.jpg");
            this.imageList.Images.SetKeyName(1, "vcmiconresolvedfolder.jpg");
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
            // 
            // tSMnIRename
            // 
            this.tSMnIRename.Name = "tSMnIRename";
            this.tSMnIRename.Size = new System.Drawing.Size(122, 22);
            this.tSMnIRename.Text = "重命名";
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.plCenter);
            this.Name = "Form1";
            this.Text = "Form1";
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
            this.cMnSChief.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plCenter;
        private System.Windows.Forms.TabControl tCMain;
        private System.Windows.Forms.TabPage tPWhole;
        private System.Windows.Forms.Panel plWholeCenter;
        private System.Windows.Forms.Panel plWholeTool;
        private System.Windows.Forms.Button btSaveMould;
        private System.Windows.Forms.Panel plWholeLeft;
        private System.Windows.Forms.TreeView tVEmrClass;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TreeView tVWholeLevel;
        private System.Windows.Forms.TabPage tPElement;
        private System.Windows.Forms.Panel plElementCenter;
        private System.Windows.Forms.DataGridView dGVMouldList;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MouldContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel plElementTool;
        private System.Windows.Forms.Button btDelElementMould;
        private System.Windows.Forms.Button btSaveElementMould;
        private System.Windows.Forms.Button btAddElementMould;
        private System.Windows.Forms.Panel plElementLeft;
        private System.Windows.Forms.TreeView tVEmrElement;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.TreeView tVElementLevel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip cMnSMould;
        private System.Windows.Forms.ToolStripMenuItem tSMnIDel;
        private System.Windows.Forms.ToolStripMenuItem tSMnIRename;
        private System.Windows.Forms.ContextMenuStrip cMnSChief;
        private System.Windows.Forms.ToolStripMenuItem tSMnIAdd;
    }
}