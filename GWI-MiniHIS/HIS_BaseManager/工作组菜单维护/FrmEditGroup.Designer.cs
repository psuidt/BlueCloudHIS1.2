namespace HIS_BaseManager
{
    partial class FrmEditGroup
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
            this.btnCancel = new System.Windows.Forms.Button( );
            this.btnSave = new System.Windows.Forms.Button( );
            this.label1 = new System.Windows.Forms.Label( );
            this.chkAdmin = new System.Windows.Forms.CheckBox( );
            this.txtGroupName = new System.Windows.Forms.TextBox( );
            this.chkDelete = new System.Windows.Forms.CheckBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.SuspendLayout( );
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point( 285 , 117 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75 , 23 );
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消(&X)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point( 204 , 117 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 75 , 23 );
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 12 , 36 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 71 , 12 );
            this.label1.TabIndex = 2;
            this.label1.Text = "用户组名(&N)";
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.BackColor = System.Drawing.Color.Transparent;
            this.chkAdmin.Location = new System.Drawing.Point( 85 , 70 );
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size( 126 , 16 );
            this.chkAdmin.TabIndex = 4;
            this.chkAdmin.Text = "具有管理员权限(&A)\r\n";
            this.chkAdmin.UseVisualStyleBackColor = false;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point( 85 , 33 );
            this.txtGroupName.MaxLength = 10;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size( 275 , 21 );
            this.txtGroupName.TabIndex = 5;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.BackColor = System.Drawing.Color.Transparent;
            this.chkDelete.Location = new System.Drawing.Point( 294 , 70 );
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size( 66 , 16 );
            this.chkDelete.TabIndex = 6;
            this.chkDelete.Text = "停用(&D)";
            this.chkDelete.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point( 12 , 97 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 361 , 8 );
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // FrmEditGroup
            // 
            this.ClientSize = new System.Drawing.Size( 396 , 155 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.chkDelete );
            this.Controls.Add( this.txtGroupName );
            this.Controls.Add( this.chkAdmin );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.btnSave );
            this.Controls.Add( this.btnCancel );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditGroup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler( this.FrmEditGroup_Load );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
