namespace HIS.DownUpLoadData
{
    partial class FrmMessage
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
            this.panel1 = new System.Windows.Forms.Panel( );
            this.lblUser = new System.Windows.Forms.Label( );
            this.lblTitle = new System.Windows.Forms.Label( );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.label2 = new System.Windows.Forms.Label( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.btnUpload = new System.Windows.Forms.Button( );
            this.panel3 = new System.Windows.Forms.Panel( );
            this.txtInfo = new System.Windows.Forms.RichTextBox( );
            this.panel1.SuspendLayout( );
            this.panel2.SuspendLayout( );
            this.panel3.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add( this.lblUser );
            this.panel1.Controls.Add( this.lblTitle );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 713 , 34 );
            this.panel1.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point( 546 , 14 );
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size( 77 , 12 );
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "employeeName";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font( "宋体" , 14.25F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblTitle.Location = new System.Drawing.Point( 0 , 0 );
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size( 713 , 34 );
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "本机数据上传";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add( this.label2 );
            this.panel2.Controls.Add( this.btnClose );
            this.panel2.Controls.Add( this.btnUpload );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point( 0 , 299 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 713 , 37 );
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point( 3 , 11 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 329 , 12 );
            this.label2.TabIndex = 3;
            this.label2.Text = "注意：该功能只上传当前操作员使用本机收费后产生的数据。";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 633 , 6 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75 , 23 );
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point( 548 , 6 );
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size( 75 , 23 );
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "开始上传";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler( this.btnUpload_Click );
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add( this.txtInfo );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point( 0 , 34 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 713 , 265 );
            this.panel3.TabIndex = 2;
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.Color.White;
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Location = new System.Drawing.Point( 0 , 0 );
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size( 713 , 265 );
            this.txtInfo.TabIndex = 0;
            this.txtInfo.Text = "";
            // 
            // FrmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 713 , 336 );
            this.Controls.Add( this.panel3 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.panel1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据上传";
            this.Load += new System.EventHandler( this.FrmUpload_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.FrmUpload_FormClosing );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout( );
            this.panel2.ResumeLayout( false );
            this.panel2.PerformLayout( );
            this.panel3.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label2;
    }
}

