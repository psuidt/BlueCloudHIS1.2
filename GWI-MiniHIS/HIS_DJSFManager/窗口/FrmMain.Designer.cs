namespace HIS_DJSFManager.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmMain ) );
            this.menuStrip1 = new System.Windows.Forms.MenuStrip( );
            this.日常业务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.门诊收费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.门诊退费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator( );
            this.票据分配ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.发票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.发票查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.个人收费统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.数据上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.toolStrip1 = new System.Windows.Forms.ToolStrip( );
            this.btnCharge = new System.Windows.Forms.ToolStripButton( );
            this.btnRefund = new System.Windows.Forms.ToolStripButton( );
            this.statusStrip1 = new System.Windows.Forms.StatusStrip( );
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel( );
            this.lblHospital = new System.Windows.Forms.ToolStripStatusLabel( );
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel( );
            this.tbbarUser = new System.Windows.Forms.ToolStripStatusLabel( );
            this.基础数据下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.menuStrip1.SuspendLayout( );
            this.toolStrip1.SuspendLayout( );
            this.statusStrip1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.日常业务ToolStripMenuItem,
            this.发票ToolStripMenuItem,
            this.系统管理ToolStripMenuItem} );
            this.menuStrip1.Location = new System.Drawing.Point( 0 , 0 );
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size( 710 , 24 );
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 日常业务ToolStripMenuItem
            // 
            this.日常业务ToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.门诊收费ToolStripMenuItem,
            this.门诊退费ToolStripMenuItem,
            this.toolStripSeparator1,
            this.票据分配ToolStripMenuItem} );
            this.日常业务ToolStripMenuItem.Name = "日常业务ToolStripMenuItem";
            this.日常业务ToolStripMenuItem.Size = new System.Drawing.Size( 65 , 20 );
            this.日常业务ToolStripMenuItem.Text = "日常业务";
            // 
            // 门诊收费ToolStripMenuItem
            // 
            this.门诊收费ToolStripMenuItem.Name = "门诊收费ToolStripMenuItem";
            this.门诊收费ToolStripMenuItem.Size = new System.Drawing.Size( 118 , 22 );
            this.门诊收费ToolStripMenuItem.Text = "门诊收费";
            this.门诊收费ToolStripMenuItem.Click += new System.EventHandler( this.ShowChargeForm );
            // 
            // 门诊退费ToolStripMenuItem
            // 
            this.门诊退费ToolStripMenuItem.Name = "门诊退费ToolStripMenuItem";
            this.门诊退费ToolStripMenuItem.Size = new System.Drawing.Size( 118 , 22 );
            this.门诊退费ToolStripMenuItem.Text = "门诊退费";
            this.门诊退费ToolStripMenuItem.Click += new System.EventHandler( this.门诊退费ToolStripMenuItem_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 115 , 6 );
            // 
            // 票据分配ToolStripMenuItem
            // 
            this.票据分配ToolStripMenuItem.Name = "票据分配ToolStripMenuItem";
            this.票据分配ToolStripMenuItem.Size = new System.Drawing.Size( 118 , 22 );
            this.票据分配ToolStripMenuItem.Text = "票据分配";
            this.票据分配ToolStripMenuItem.Click += new System.EventHandler( this.票据分配ToolStripMenuItem_Click );
            // 
            // 发票ToolStripMenuItem
            // 
            this.发票ToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.发票查询ToolStripMenuItem,
            this.个人收费统计ToolStripMenuItem} );
            this.发票ToolStripMenuItem.Name = "发票ToolStripMenuItem";
            this.发票ToolStripMenuItem.Size = new System.Drawing.Size( 65 , 20 );
            this.发票ToolStripMenuItem.Text = "查询统计";
            // 
            // 发票查询ToolStripMenuItem
            // 
            this.发票查询ToolStripMenuItem.Name = "发票查询ToolStripMenuItem";
            this.发票查询ToolStripMenuItem.Size = new System.Drawing.Size( 118 , 22 );
            this.发票查询ToolStripMenuItem.Text = "发票查询";
            this.发票查询ToolStripMenuItem.Click += new System.EventHandler( this.发票查询ToolStripMenuItem_Click );
            // 
            // 个人收费统计ToolStripMenuItem
            // 
            this.个人收费统计ToolStripMenuItem.Name = "个人收费统计ToolStripMenuItem";
            this.个人收费统计ToolStripMenuItem.Size = new System.Drawing.Size( 118 , 22 );
            this.个人收费统计ToolStripMenuItem.Text = "个人结账";
            this.个人收费统计ToolStripMenuItem.Click += new System.EventHandler( this.个人收费统计ToolStripMenuItem_Click );
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.数据上传ToolStripMenuItem,
            this.基础数据下载ToolStripMenuItem} );
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size( 65 , 20 );
            this.系统管理ToolStripMenuItem.Text = "系统管理";
            // 
            // 数据上传ToolStripMenuItem
            // 
            this.数据上传ToolStripMenuItem.Name = "数据上传ToolStripMenuItem";
            this.数据上传ToolStripMenuItem.Size = new System.Drawing.Size( 152 , 22 );
            this.数据上传ToolStripMenuItem.Text = "业务数据上传";
            this.数据上传ToolStripMenuItem.Click += new System.EventHandler( this.数据上传ToolStripMenuItem_Click );
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.btnCharge,
            this.btnRefund} );
            this.toolStrip1.Location = new System.Drawing.Point( 0 , 24 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 710 , 25 );
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCharge
            // 
            this.btnCharge.Image = ( (System.Drawing.Image)( resources.GetObject( "btnCharge.Image" ) ) );
            this.btnCharge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCharge.Name = "btnCharge";
            this.btnCharge.Size = new System.Drawing.Size( 73 , 22 );
            this.btnCharge.Text = "门诊收费";
            this.btnCharge.Click += new System.EventHandler( this.ShowChargeForm );
            // 
            // btnRefund
            // 
            this.btnRefund.Image = ( (System.Drawing.Image)( resources.GetObject( "btnRefund.Image" ) ) );
            this.btnRefund.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size( 73 , 22 );
            this.btnRefund.Text = "门诊退费";
            this.btnRefund.Click += new System.EventHandler( this.btnRefund_Click );
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblHospital,
            this.toolStripStatusLabel2,
            this.tbbarUser} );
            this.statusStrip1.Location = new System.Drawing.Point( 0 , 457 );
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size( 710 , 22 );
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size( 65 , 17 );
            this.toolStripStatusLabel1.Text = "用户单位：";
            // 
            // lblHospital
            // 
            this.lblHospital.AutoSize = false;
            this.lblHospital.Name = "lblHospital";
            this.lblHospital.Size = new System.Drawing.Size( 100 , 17 );
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size( 65 , 17 );
            this.toolStripStatusLabel2.Text = "当前用户：";
            // 
            // tbbarUser
            // 
            this.tbbarUser.AutoSize = false;
            this.tbbarUser.Name = "tbbarUser";
            this.tbbarUser.Size = new System.Drawing.Size( 75 , 17 );
            // 
            // 基础数据下载ToolStripMenuItem
            // 
            this.基础数据下载ToolStripMenuItem.Name = "基础数据下载ToolStripMenuItem";
            this.基础数据下载ToolStripMenuItem.Size = new System.Drawing.Size( 152 , 22 );
            this.基础数据下载ToolStripMenuItem.Text = "基础数据下载";
            this.基础数据下载ToolStripMenuItem.Click += new System.EventHandler( this.基础数据下载ToolStripMenuItem_Click );
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 710 , 479 );
            this.Controls.Add( this.statusStrip1 );
            this.Controls.Add( this.toolStrip1 );
            this.Controls.Add( this.menuStrip1 );
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "门诊收费单机版";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout( false );
            this.menuStrip1.PerformLayout( );
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout( );
            this.statusStrip1.ResumeLayout( false );
            this.statusStrip1.PerformLayout( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 日常业务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 门诊收费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 门诊退费ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem 发票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 票据分配ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发票查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人收费统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnCharge;
        private System.Windows.Forms.ToolStripButton btnRefund;
        private System.Windows.Forms.ToolStripMenuItem 数据上传ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblHospital;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tbbarUser;
        private System.Windows.Forms.ToolStripMenuItem 基础数据下载ToolStripMenuItem;
    }
}

