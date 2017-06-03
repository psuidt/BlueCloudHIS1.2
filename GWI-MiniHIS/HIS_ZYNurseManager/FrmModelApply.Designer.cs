namespace HIS_ZYNurseManager
{
    partial class FrmModelApply
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
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("院级模板");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("科室级模板");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("个人级模板");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("所有级别", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31});
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tvlevel = new System.Windows.Forms.TreeView();
            this.tvtype = new System.Windows.Forms.TreeView();
            this.btnApply = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tvlevel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 83);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnApply);
            this.panel2.Controls.Add(this.tvtype);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 260);
            this.panel2.TabIndex = 1;
            // 
            // tvlevel
            // 
            this.tvlevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvlevel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvlevel.Location = new System.Drawing.Point(0, 0);
            this.tvlevel.Name = "tvlevel";
            treeNode29.ImageIndex = 14;
            treeNode29.Name = "节点1";
            treeNode29.Text = "院级模板";
            treeNode30.ImageIndex = 14;
            treeNode30.Name = "节点2";
            treeNode30.Text = "科室级模板";
            treeNode31.ImageIndex = 14;
            treeNode31.Name = "节点3";
            treeNode31.Text = "个人级模板";
            treeNode32.ImageIndex = 15;
            treeNode32.Name = "节点0";
            treeNode32.Text = "所有级别";
            this.tvlevel.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode32});
            this.tvlevel.Size = new System.Drawing.Size(221, 83);
            this.tvlevel.TabIndex = 13;
            this.tvlevel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvlevel_AfterSelect);
            // 
            // tvtype
            // 
            this.tvtype.CheckBoxes = true;
            this.tvtype.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvtype.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvtype.Location = new System.Drawing.Point(0, 0);
            this.tvtype.Name = "tvtype";
            this.tvtype.Size = new System.Drawing.Size(221, 227);
            this.tvtype.TabIndex = 1;
            this.tvtype.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvtype_AfterCheck);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(76, 232);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(52, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // FrmModelApply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 343);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmModelApply";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板应用";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView tvlevel;
        private System.Windows.Forms.TreeView tvtype;
        private System.Windows.Forms.Button btnApply;
    }
}