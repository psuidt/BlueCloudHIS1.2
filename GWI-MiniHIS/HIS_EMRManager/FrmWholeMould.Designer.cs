namespace HIS_EMRManager
{
    partial class FrmWholeMould
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
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("全院级模板");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("科室级模板");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("个人级模板");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWholeMould));
            this.plTop = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btSure = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.plLeft = new System.Windows.Forms.Panel();
            this.tWMould = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tVWholeLevel = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.plCenter = new System.Windows.Forms.Panel();
            this.plTop.SuspendLayout();
            this.plLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plTop
            // 
            this.plTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plTop.Controls.Add(this.txtName);
            this.plTop.Controls.Add(this.btSure);
            this.plTop.Controls.Add(this.btSave);
            this.plTop.Controls.Add(this.lbName);
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(610, 38);
            this.plTop.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(87, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(205, 21);
            this.txtName.TabIndex = 0;
            // 
            // btSure
            // 
            this.btSure.Location = new System.Drawing.Point(404, 8);
            this.btSure.Name = "btSure";
            this.btSure.Size = new System.Drawing.Size(75, 23);
            this.btSure.TabIndex = 3;
            this.btSure.Text = "选定模板";
            this.btSure.UseVisualStyleBackColor = true;
            this.btSure.Click += new System.EventHandler(this.btSure_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(312, 8);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "保存模板";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(25, 13);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(65, 12);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "模板名称：";
            // 
            // plLeft
            // 
            this.plLeft.Controls.Add(this.tWMould);
            this.plLeft.Controls.Add(this.splitter1);
            this.plLeft.Controls.Add(this.tVWholeLevel);
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLeft.Location = new System.Drawing.Point(0, 0);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(148, 632);
            this.plLeft.TabIndex = 4;
            // 
            // tWMould
            // 
            this.tWMould.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tWMould.Location = new System.Drawing.Point(0, 89);
            this.tWMould.Name = "tWMould";
            this.tWMould.Size = new System.Drawing.Size(148, 543);
            this.tWMould.TabIndex = 5;
            this.tWMould.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tWMould_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 86);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(148, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // tVWholeLevel
            // 
            this.tVWholeLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tVWholeLevel.ImageIndex = 0;
            this.tVWholeLevel.ImageList = this.imageList;
            this.tVWholeLevel.Location = new System.Drawing.Point(0, 0);
            this.tVWholeLevel.Name = "tVWholeLevel";
            treeNode4.Name = "TNWholeHospital";
            treeNode4.Tag = "1";
            treeNode4.Text = "全院级模板";
            treeNode5.Name = "TNWholeDept";
            treeNode5.Tag = "2";
            treeNode5.Text = "科室级模板";
            treeNode6.Name = "TNWholePerson";
            treeNode6.Tag = "3";
            treeNode6.Text = "个人级模板";
            this.tVWholeLevel.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.tVWholeLevel.SelectedImageIndex = 1;
            this.tVWholeLevel.Size = new System.Drawing.Size(148, 86);
            this.tVWholeLevel.TabIndex = 3;
            this.tVWholeLevel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tVWholeLevel_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "vcmiconincludedfolder.jpg");
            this.imageList.Images.SetKeyName(1, "vcmiconresolvedfolder.jpg");
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(148, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 632);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.plCenter);
            this.panel2.Controls.Add(this.plTop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(151, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 632);
            this.panel2.TabIndex = 6;
            // 
            // plCenter
            // 
            this.plCenter.BackColor = System.Drawing.Color.White;
            this.plCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plCenter.Location = new System.Drawing.Point(0, 38);
            this.plCenter.Name = "plCenter";
            this.plCenter.Size = new System.Drawing.Size(610, 594);
            this.plCenter.TabIndex = 4;
            // 
            // FrmWholeMould
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 632);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.plLeft);
            this.Name = "FrmWholeMould";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病历模板";
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.plLeft.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btSure;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Panel plLeft;
        private System.Windows.Forms.TreeView tVWholeLevel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TreeView tWMould;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel plCenter;
    }
}