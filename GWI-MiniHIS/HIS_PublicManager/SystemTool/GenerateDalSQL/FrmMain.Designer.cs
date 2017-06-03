namespace HIS_PublicManager.SystemTool.GenerateDalSQL
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtb_sql = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbout2 = new System.Windows.Forms.RadioButton();
            this.rbout1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbin2 = new System.Windows.Forms.RadioButton();
            this.rbin1 = new System.Windows.Forms.RadioButton();
            this.bt_charge = new System.Windows.Forms.Button();
            this.rtb_dal = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.执行XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtb_dal);
            this.splitContainer1.Size = new System.Drawing.Size(771, 456);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtb_sql);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(771, 153);
            this.panel2.TabIndex = 1;
            // 
            // rtb_sql
            // 
            this.rtb_sql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_sql.Location = new System.Drawing.Point(0, 0);
            this.rtb_sql.Name = "rtb_sql";
            this.rtb_sql.Size = new System.Drawing.Size(771, 153);
            this.rtb_sql.TabIndex = 0;
            this.rtb_sql.Text = resources.GetString("rtb_sql.Text");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.bt_charge);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 39);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbout2);
            this.groupBox2.Controls.Add(this.rbout1);
            this.groupBox2.Location = new System.Drawing.Point(301, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 36);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出";
            this.groupBox2.Visible = false;
            // 
            // rbout2
            // 
            this.rbout2.AutoSize = true;
            this.rbout2.Checked = true;
            this.rbout2.Location = new System.Drawing.Point(89, 14);
            this.rbout2.Name = "rbout2";
            this.rbout2.Size = new System.Drawing.Size(65, 16);
            this.rbout2.TabIndex = 1;
            this.rbout2.TabStop = true;
            this.rbout2.Text = "调试SQL";
            this.rbout2.UseVisualStyleBackColor = true;
            // 
            // rbout1
            // 
            this.rbout1.AutoSize = true;
            this.rbout1.Location = new System.Drawing.Point(6, 14);
            this.rbout1.Name = "rbout1";
            this.rbout1.Size = new System.Drawing.Size(65, 16);
            this.rbout1.TabIndex = 0;
            this.rbout1.Text = "执行SQL";
            this.rbout1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbin2);
            this.groupBox1.Controls.Add(this.rbin1);
            this.groupBox1.Location = new System.Drawing.Point(13, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 36);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入";
            // 
            // rbin2
            // 
            this.rbin2.AutoSize = true;
            this.rbin2.Location = new System.Drawing.Point(89, 14);
            this.rbin2.Name = "rbin2";
            this.rbin2.Size = new System.Drawing.Size(65, 16);
            this.rbin2.TabIndex = 1;
            this.rbin2.Text = "DAL语句";
            this.rbin2.UseVisualStyleBackColor = true;
            this.rbin2.CheckedChanged += new System.EventHandler(this.rbin2_CheckedChanged);
            // 
            // rbin1
            // 
            this.rbin1.AutoSize = true;
            this.rbin1.Checked = true;
            this.rbin1.Location = new System.Drawing.Point(6, 14);
            this.rbin1.Name = "rbin1";
            this.rbin1.Size = new System.Drawing.Size(65, 16);
            this.rbin1.TabIndex = 0;
            this.rbin1.TabStop = true;
            this.rbin1.Text = "SQL语句";
            this.rbin1.UseVisualStyleBackColor = true;
            // 
            // bt_charge
            // 
            this.bt_charge.Location = new System.Drawing.Point(631, 7);
            this.bt_charge.Name = "bt_charge";
            this.bt_charge.Size = new System.Drawing.Size(75, 23);
            this.bt_charge.TabIndex = 0;
            this.bt_charge.Text = "转换";
            this.bt_charge.UseVisualStyleBackColor = true;
            this.bt_charge.Click += new System.EventHandler(this.bt_charge_Click);
            // 
            // rtb_dal
            // 
            this.rtb_dal.ContextMenuStrip = this.contextMenuStrip1;
            this.rtb_dal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_dal.Location = new System.Drawing.Point(0, 0);
            this.rtb_dal.Name = "rtb_dal";
            this.rtb_dal.Size = new System.Drawing.Size(771, 260);
            this.rtb_dal.TabIndex = 0;
            this.rtb_dal.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.执行XToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 26);
            // 
            // 执行XToolStripMenuItem
            // 
            this.执行XToolStripMenuItem.Name = "执行XToolStripMenuItem";
            this.执行XToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.执行XToolStripMenuItem.Text = "执行(&X)";
            this.执行XToolStripMenuItem.Click += new System.EventHandler(this.执行XToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 456);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.Text = "SQL语句转DAL语句";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtb_sql;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_charge;
        private System.Windows.Forms.RichTextBox rtb_dal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbout2;
        private System.Windows.Forms.RadioButton rbout1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbin2;
        private System.Windows.Forms.RadioButton rbin1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 执行XToolStripMenuItem;
    }
}

