namespace HIS_EMRManager
{
    public partial class EMRControlPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.plBottom = new System.Windows.Forms.Panel();
            this.btCHI = new System.Windows.Forms.Button();
            this.btHistory = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btSaveMould = new System.Windows.Forms.Button();
            this.btUseMould = new System.Windows.Forms.Button();
            this.btSaveEMRRecord = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.ctMnSSaveLevel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.全院级模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.科室级模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人级模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plBottom.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.ctMnSSaveLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBottom
            // 
            this.plBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plBottom.Controls.Add(this.btCHI);
            this.plBottom.Controls.Add(this.btHistory);
            this.plBottom.Controls.Add(this.btPrint);
            this.plBottom.Controls.Add(this.btSaveMould);
            this.plBottom.Controls.Add(this.btUseMould);
            this.plBottom.Controls.Add(this.btSaveEMRRecord);
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(0, 587);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(612, 37);
            this.plBottom.TabIndex = 0;
            // 
            // btCHI
            // 
            this.btCHI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCHI.Location = new System.Drawing.Point(39, 3);
            this.btCHI.Name = "btCHI";
            this.btCHI.Size = new System.Drawing.Size(85, 23);
            this.btCHI.TabIndex = 5;
            this.btCHI.Text = "健康档案信息";
            this.btCHI.UseVisualStyleBackColor = true;
            this.btCHI.Click += new System.EventHandler(this.btCHI_Click);
            // 
            // btHistory
            // 
            this.btHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btHistory.Location = new System.Drawing.Point(141, 3);
            this.btHistory.Name = "btHistory";
            this.btHistory.Size = new System.Drawing.Size(75, 23);
            this.btHistory.TabIndex = 4;
            this.btHistory.Text = "历史病历";
            this.btHistory.UseVisualStyleBackColor = true;
            this.btHistory.Click += new System.EventHandler(this.btHistory_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Location = new System.Drawing.Point(509, 3);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(75, 23);
            this.btPrint.TabIndex = 3;
            this.btPrint.Text = "打印";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btSaveMould
            // 
            this.btSaveMould.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveMould.Location = new System.Drawing.Point(325, 3);
            this.btSaveMould.Name = "btSaveMould";
            this.btSaveMould.Size = new System.Drawing.Size(75, 23);
            this.btSaveMould.TabIndex = 2;
            this.btSaveMould.Text = "存为模板";
            this.btSaveMould.UseVisualStyleBackColor = true;
            this.btSaveMould.Click += new System.EventHandler(this.btSaveMould_Click);
            // 
            // btUseMould
            // 
            this.btUseMould.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUseMould.Location = new System.Drawing.Point(233, 3);
            this.btUseMould.Name = "btUseMould";
            this.btUseMould.Size = new System.Drawing.Size(75, 23);
            this.btUseMould.TabIndex = 1;
            this.btUseMould.Text = "应用模板";
            this.btUseMould.UseVisualStyleBackColor = true;
            this.btUseMould.Click += new System.EventHandler(this.btUseMould_Click);
            // 
            // btSaveEMRRecord
            // 
            this.btSaveEMRRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveEMRRecord.Location = new System.Drawing.Point(417, 3);
            this.btSaveEMRRecord.Name = "btSaveEMRRecord";
            this.btSaveEMRRecord.Size = new System.Drawing.Size(75, 23);
            this.btSaveEMRRecord.TabIndex = 0;
            this.btSaveEMRRecord.Text = "保存";
            this.btSaveEMRRecord.UseVisualStyleBackColor = true;
            this.btSaveEMRRecord.Click += new System.EventHandler(this.btSaveEMRRecord_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(167, 246);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem1.Tag = "1";
            this.toolStripMenuItem1.Text = "全部信息";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem2.Tag = "2";
            this.toolStripMenuItem2.Text = "基本信息";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem3.Tag = "3";
            this.toolStripMenuItem3.Text = "体检信息";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem4.Tag = "4";
            this.toolStripMenuItem4.Text = "健教信息";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem5.Tag = "5";
            this.toolStripMenuItem5.Text = "产检分娩访视信息";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem6.Tag = "6";
            this.toolStripMenuItem6.Text = "妇女保健信息";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem7.Tag = "7";
            this.toolStripMenuItem7.Text = "儿童体检信息";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem8.Tag = "8";
            this.toolStripMenuItem8.Text = "康复访视信息";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem9.Tag = "9";
            this.toolStripMenuItem9.Text = "传染病登记信息";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem10.Tag = "10";
            this.toolStripMenuItem10.Text = "慢病监测信息";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem11.Tag = "11";
            this.toolStripMenuItem11.Text = "预防接种信息";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // ctMnSSaveLevel
            // 
            this.ctMnSSaveLevel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全院级模板ToolStripMenuItem,
            this.科室级模板ToolStripMenuItem,
            this.个人级模板ToolStripMenuItem});
            this.ctMnSSaveLevel.Name = "ctMnSSaveLevel";
            this.ctMnSSaveLevel.Size = new System.Drawing.Size(153, 92);
            // 
            // 全院级模板ToolStripMenuItem
            // 
            this.全院级模板ToolStripMenuItem.Name = "全院级模板ToolStripMenuItem";
            this.全院级模板ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.全院级模板ToolStripMenuItem.Tag = "1";
            this.全院级模板ToolStripMenuItem.Text = "全院级模板";
            this.全院级模板ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemLevel_Click);
            // 
            // 科室级模板ToolStripMenuItem
            // 
            this.科室级模板ToolStripMenuItem.Name = "科室级模板ToolStripMenuItem";
            this.科室级模板ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.科室级模板ToolStripMenuItem.Tag = "2";
            this.科室级模板ToolStripMenuItem.Text = "科室级模板";
            this.科室级模板ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemLevel_Click);
            // 
            // 个人级模板ToolStripMenuItem
            // 
            this.个人级模板ToolStripMenuItem.Name = "个人级模板ToolStripMenuItem";
            this.个人级模板ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.个人级模板ToolStripMenuItem.Tag = "3";
            this.个人级模板ToolStripMenuItem.Text = "个人级模板";
            this.个人级模板ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemLevel_Click);
            // 
            // EMRControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plBottom);
            this.Name = "EMRControlPanel";
            this.Size = new System.Drawing.Size(612, 624);
            this.plBottom.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ctMnSSaveLevel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plBottom;
        private System.Windows.Forms.Button btSaveEMRRecord;
        private System.Windows.Forms.Button btSaveMould;
        private System.Windows.Forms.Button btUseMould;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btHistory;
        private System.Windows.Forms.Button btCHI;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ContextMenuStrip ctMnSSaveLevel;
        private System.Windows.Forms.ToolStripMenuItem 全院级模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 科室级模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人级模板ToolStripMenuItem;
    }
}
