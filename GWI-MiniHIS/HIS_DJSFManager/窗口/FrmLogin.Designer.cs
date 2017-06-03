namespace HIS_DJSFManager.窗口
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.txtPassword = new System.Windows.Forms.TextBox( );
            this.txtUserCode = new System.Windows.Forms.TextBox( );
            this.btnLogin = new System.Windows.Forms.Button( );
            this.btnCancel = new System.Windows.Forms.Button( );
            this.label3 = new System.Windows.Forms.Label( );
            this.txtEmployeeName = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 42 , 83 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 41 , 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 42 , 137 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 41 , 12 );
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point( 100 , 134 );
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size( 213 , 21 );
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtPassword_KeyPress );
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point( 100 , 80 );
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size( 213 , 21 );
            this.txtUserCode.TabIndex = 0;
            this.txtUserCode.Leave += new System.EventHandler( this.txtUserCode_Leave );
            this.txtUserCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtUserCode_KeyPress );
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point( 100 , 161 );
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size( 75 , 23 );
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler( this.btnLogin_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point( 238 , 161 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75 , 23 );
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 42 , 110 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 41 , 12 );
            this.label3.TabIndex = 6;
            this.label3.Text = "姓  名";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Enabled = false;
            this.txtEmployeeName.Location = new System.Drawing.Point( 100 , 107 );
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size( 213 , 21 );
            this.txtEmployeeName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font( "宋体" , 24F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label4.Location = new System.Drawing.Point( 38 , 18 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 303 , 33 );
            this.label4.TabIndex = 8;
            this.label4.Text = "单机版门诊收费系统";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 371 , 206 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.txtEmployeeName );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnLogin );
            this.Controls.Add( this.txtUserCode );
            this.Controls.Add( this.txtPassword );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserCode;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label4;
    }
}