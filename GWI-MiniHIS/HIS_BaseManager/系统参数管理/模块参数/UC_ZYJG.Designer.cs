namespace HIS_BaseManager
{
    partial class UC_ZYJG
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
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chk001 = new System.Windows.Forms.CheckBox();
            this.chk002 = new System.Windows.Forms.CheckBox();
            this.chk004 = new System.Windows.Forms.CheckBox();
            this.chk005 = new System.Windows.Forms.CheckBox();
            this.chk006 = new System.Windows.Forms.CheckBox();
            this.chk003_0 = new System.Windows.Forms.RadioButton();
            this.chk003_1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk008 = new System.Windows.Forms.CheckBox();
            this.chk009 = new System.Windows.Forms.CheckBox();
            this.chk010 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt007 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chk001
            // 
            this.chk001.AutoSize = true;
            this.chk001.Location = new System.Drawing.Point(28, 11);
            this.chk001.Name = "chk001";
            this.chk001.Size = new System.Drawing.Size(228, 16);
            this.chk001.TabIndex = 1;
            this.chk001.Text = "费用清单打印组合项目时，按明细打印";
            this.chk001.UseVisualStyleBackColor = true;
            // 
            // chk002
            // 
            this.chk002.AutoSize = true;
            this.chk002.Location = new System.Drawing.Point(28, 43);
            this.chk002.Name = "chk002";
            this.chk002.Size = new System.Drawing.Size(156, 16);
            this.chk002.TabIndex = 2;
            this.chk002.Text = "划价时显示零库存的药品";
            this.chk002.UseVisualStyleBackColor = true;
            // 
            // chk004
            // 
            this.chk004.AutoSize = true;
            this.chk004.Location = new System.Drawing.Point(28, 120);
            this.chk004.Name = "chk004";
            this.chk004.Size = new System.Drawing.Size(204, 16);
            this.chk004.TabIndex = 3;
            this.chk004.Text = "预交金作废时可以操作别人的费用";
            this.chk004.UseVisualStyleBackColor = true;
            // 
            // chk005
            // 
            this.chk005.AutoSize = true;
            this.chk005.Location = new System.Drawing.Point(28, 149);
            this.chk005.Name = "chk005";
            this.chk005.Size = new System.Drawing.Size(180, 16);
            this.chk005.TabIndex = 4;
            this.chk005.Text = "住院发票不启用电脑管理票号";
            this.chk005.UseVisualStyleBackColor = true;
            // 
            // chk006
            // 
            this.chk006.AutoSize = true;
            this.chk006.Location = new System.Drawing.Point(28, 178);
            this.chk006.Name = "chk006";
            this.chk006.Size = new System.Drawing.Size(252, 16);
            this.chk006.TabIndex = 5;
            this.chk006.Text = "结算取消时可以取消其他操作员的结算记录";
            this.chk006.UseVisualStyleBackColor = true;
            // 
            // chk003_0
            // 
            this.chk003_0.AutoSize = true;
            this.chk003_0.Location = new System.Drawing.Point(129, 13);
            this.chk003_0.Name = "chk003_0";
            this.chk003_0.Size = new System.Drawing.Size(71, 16);
            this.chk003_0.TabIndex = 6;
            this.chk003_0.TabStop = true;
            this.chk003_0.Text = "开方时间";
            this.chk003_0.UseVisualStyleBackColor = true;
            // 
            // chk003_1
            // 
            this.chk003_1.AutoSize = true;
            this.chk003_1.Checked = true;
            this.chk003_1.Location = new System.Drawing.Point(254, 13);
            this.chk003_1.Name = "chk003_1";
            this.chk003_1.Size = new System.Drawing.Size(71, 16);
            this.chk003_1.TabIndex = 7;
            this.chk003_1.TabStop = true;
            this.chk003_1.Text = "记账时间";
            this.chk003_1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk003_0);
            this.groupBox1.Controls.Add(this.chk003_1);
            this.groupBox1.Location = new System.Drawing.Point(28, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 36);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "费用清单的时间类型";
            // 
            // chk008
            // 
            this.chk008.AutoSize = true;
            this.chk008.Location = new System.Drawing.Point(28, 207);
            this.chk008.Name = "chk008";
            this.chk008.Size = new System.Drawing.Size(96, 16);
            this.chk008.TabIndex = 10;
            this.chk008.Text = "关闭临床接口";
            this.chk008.UseVisualStyleBackColor = true;
            // 
            // chk009
            // 
            this.chk009.AutoSize = true;
            this.chk009.Location = new System.Drawing.Point(28, 236);
            this.chk009.Name = "chk009";
            this.chk009.Size = new System.Drawing.Size(504, 16);
            this.chk009.TabIndex = 11;
            this.chk009.Text = "入院登记时开启必填项的最大项数（不选则入院登记时只需要填必须的项，其余项可不填）";
            this.chk009.UseVisualStyleBackColor = true;
            // 
            // chk010
            // 
            this.chk010.AutoSize = true;
            this.chk010.Location = new System.Drawing.Point(28, 265);
            this.chk010.Name = "chk010";
            this.chk010.Size = new System.Drawing.Size(180, 16);
            this.chk010.TabIndex = 12;
            this.chk010.Text = "转科病人的费用清单分开打印";
            this.chk010.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "发票分类明细配置";
            // 
            // txt007
            // 
            this.txt007.Location = new System.Drawing.Point(136, 292);
            this.txt007.Name = "txt007";
            this.txt007.Size = new System.Drawing.Size(440, 21);
            this.txt007.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "0:CT 1:MRI 2:B超 3:X光  4:心脑电图 5:输血费 6:输养费 (0-6)";
            // 
            // UC_ZYJG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt007);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chk010);
            this.Controls.Add(this.chk009);
            this.Controls.Add(this.chk008);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chk006);
            this.Controls.Add(this.chk005);
            this.Controls.Add(this.chk004);
            this.Controls.Add(this.chk002);
            this.Controls.Add(this.chk001);
            this.Name = "UC_ZYJG";
            this.Size = new System.Drawing.Size(620, 481);
            this.Load += new System.EventHandler(this.UC_ZYJG_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk001;
        private System.Windows.Forms.CheckBox chk002;
        private System.Windows.Forms.CheckBox chk004;
        private System.Windows.Forms.CheckBox chk005;
        private System.Windows.Forms.CheckBox chk006;
        private System.Windows.Forms.RadioButton chk003_0;
        private System.Windows.Forms.RadioButton chk003_1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk008;
        private System.Windows.Forms.CheckBox chk009;
        private System.Windows.Forms.CheckBox chk010;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt007;
        private System.Windows.Forms.Label label1;
    }
}
