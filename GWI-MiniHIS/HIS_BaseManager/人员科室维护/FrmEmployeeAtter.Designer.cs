namespace HIS_BaseManager
{
    partial class FrmEmployeeAtter
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
            this.tabControl1 = new System.Windows.Forms.TabControl( );
            this.tabPage1 = new System.Windows.Forms.TabPage( );
            this.chkNoUse = new System.Windows.Forms.CheckBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.cboDocType = new System.Windows.Forms.ComboBox( );
            this.chkDm = new System.Windows.Forms.CheckBox( );
            this.chkMz = new System.Windows.Forms.CheckBox( );
            this.chkCf = new System.Windows.Forms.CheckBox( );
            this.txtDocCode = new System.Windows.Forms.TextBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.cboRole = new System.Windows.Forms.ComboBox( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.btnAddDept = new System.Windows.Forms.Button( );
            this.btnRemoveDept = new System.Windows.Forms.Button( );
            this.lvwDept = new System.Windows.Forms.ListView( );
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader( );
            this.txtName = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.tabPage2 = new System.Windows.Forms.TabPage( );
            this.groupBox3 = new System.Windows.Forms.GroupBox( );
            this.btnAddGroup = new System.Windows.Forms.Button( );
            this.chkLock = new System.Windows.Forms.CheckBox( );
            this.btnRemoveGroup = new System.Windows.Forms.Button( );
            this.lvwGroup = new System.Windows.Forms.ListView( );
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader( );
            this.btnResetPassword = new System.Windows.Forms.Button( );
            this.label7 = new System.Windows.Forms.Label( );
            this.txtPassword = new System.Windows.Forms.TextBox( );
            this.txtUserCode = new System.Windows.Forms.TextBox( );
            this.label6 = new System.Windows.Forms.Label( );
            this.btnOk = new System.Windows.Forms.Button( );
            this.btnCancel = new System.Windows.Forms.Button( );
            this.label5 = new System.Windows.Forms.Label( );
            this.tabControl1.SuspendLayout( );
            this.tabPage1.SuspendLayout( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.tabPage2.SuspendLayout( );
            this.groupBox3.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Controls.Add( this.tabPage2 );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point( 0 , 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 374 , 412 );
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.chkNoUse );
            this.tabPage1.Controls.Add( this.groupBox1 );
            this.tabPage1.Controls.Add( this.label2 );
            this.tabPage1.Controls.Add( this.cboRole );
            this.tabPage1.Controls.Add( this.groupBox2 );
            this.tabPage1.Controls.Add( this.txtName );
            this.tabPage1.Controls.Add( this.label1 );
            this.tabPage1.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 366 , 387 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkNoUse
            // 
            this.chkNoUse.AutoSize = true;
            this.chkNoUse.Location = new System.Drawing.Point( 267 , 20 );
            this.chkNoUse.Name = "chkNoUse";
            this.chkNoUse.Size = new System.Drawing.Size( 48 , 16 );
            this.chkNoUse.TabIndex = 13;
            this.chkNoUse.Text = "停用";
            this.chkNoUse.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.label4 );
            this.groupBox1.Controls.Add( this.cboDocType );
            this.groupBox1.Controls.Add( this.chkDm );
            this.groupBox1.Controls.Add( this.chkMz );
            this.groupBox1.Controls.Add( this.chkCf );
            this.groupBox1.Controls.Add( this.txtDocCode );
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Location = new System.Drawing.Point( 53 , 70 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 261 , 127 );
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 6 , 60 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 53 , 12 );
            this.label4.TabIndex = 9;
            this.label4.Text = "医生职级";
            // 
            // cboDocType
            // 
            this.cboDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocType.FormattingEnabled = true;
            this.cboDocType.Location = new System.Drawing.Point( 65 , 57 );
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.Size = new System.Drawing.Size( 189 , 20 );
            this.cboDocType.TabIndex = 8;
            // 
            // chkDm
            // 
            this.chkDm.AutoSize = true;
            this.chkDm.Location = new System.Drawing.Point( 182 , 96 );
            this.chkDm.Name = "chkDm";
            this.chkDm.Size = new System.Drawing.Size( 60 , 16 );
            this.chkDm.TabIndex = 7;
            this.chkDm.Text = "毒麻权";
            this.chkDm.UseVisualStyleBackColor = true;
            // 
            // chkMz
            // 
            this.chkMz.AutoSize = true;
            this.chkMz.Location = new System.Drawing.Point( 98 , 96 );
            this.chkMz.Name = "chkMz";
            this.chkMz.Size = new System.Drawing.Size( 60 , 16 );
            this.chkMz.TabIndex = 6;
            this.chkMz.Text = "麻醉权";
            this.chkMz.UseVisualStyleBackColor = true;
            // 
            // chkCf
            // 
            this.chkCf.AutoSize = true;
            this.chkCf.Location = new System.Drawing.Point( 14 , 96 );
            this.chkCf.Name = "chkCf";
            this.chkCf.Size = new System.Drawing.Size( 60 , 16 );
            this.chkCf.TabIndex = 5;
            this.chkCf.Text = "处方权";
            this.chkCf.UseVisualStyleBackColor = true;
            // 
            // txtDocCode
            // 
            this.txtDocCode.Location = new System.Drawing.Point( 65 , 20 );
            this.txtDocCode.Name = "txtDocCode";
            this.txtDocCode.Size = new System.Drawing.Size( 189 , 21 );
            this.txtDocCode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 6 , 24 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 53 , 12 );
            this.label3.TabIndex = 4;
            this.label3.Text = "医生代码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 15 , 47 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 29 , 12 );
            this.label2.TabIndex = 11;
            this.label2.Text = "角色";
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange( new object[] {
            "<无>",
            "医生",
            "护士"} );
            this.cboRole.Location = new System.Drawing.Point( 53 , 44 );
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size( 261 , 20 );
            this.cboRole.TabIndex = 10;
            this.cboRole.SelectedIndexChanged += new System.EventHandler( this.cboRole_SelectedIndexChanged );
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.btnAddDept );
            this.groupBox2.Controls.Add( this.btnRemoveDept );
            this.groupBox2.Controls.Add( this.lvwDept );
            this.groupBox2.Location = new System.Drawing.Point( 17 , 203 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 341 , 178 );
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "科室";
            // 
            // btnAddDept
            // 
            this.btnAddDept.Location = new System.Drawing.Point( 179 , 149 );
            this.btnAddDept.Name = "btnAddDept";
            this.btnAddDept.Size = new System.Drawing.Size( 75 , 23 );
            this.btnAddDept.TabIndex = 0;
            this.btnAddDept.Text = "选择";
            this.btnAddDept.UseVisualStyleBackColor = true;
            this.btnAddDept.Click += new System.EventHandler( this.btnAddDept_Click );
            // 
            // btnRemoveDept
            // 
            this.btnRemoveDept.Location = new System.Drawing.Point( 260 , 149 );
            this.btnRemoveDept.Name = "btnRemoveDept";
            this.btnRemoveDept.Size = new System.Drawing.Size( 75 , 23 );
            this.btnRemoveDept.TabIndex = 3;
            this.btnRemoveDept.Text = "移除";
            this.btnRemoveDept.UseVisualStyleBackColor = true;
            this.btnRemoveDept.Click += new System.EventHandler( this.btnRemoveDept_Click );
            // 
            // lvwDept
            // 
            this.lvwDept.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2} );
            this.lvwDept.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwDept.FullRowSelect = true;
            this.lvwDept.Location = new System.Drawing.Point( 3 , 17 );
            this.lvwDept.Name = "lvwDept";
            this.lvwDept.Size = new System.Drawing.Size( 335 , 124 );
            this.lvwDept.TabIndex = 0;
            this.lvwDept.UseCompatibleStateImageBehavior = false;
            this.lvwDept.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "科室名称";
            this.columnHeader1.Width = 138;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "备注";
            this.columnHeader2.Width = 135;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point( 53 , 17 );
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size( 208 , 21 );
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 15 , 21 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 29 , 12 );
            this.label1.TabIndex = 2;
            this.label1.Text = "姓名";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.groupBox3 );
            this.tabPage2.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage2.Size = new System.Drawing.Size( 366 , 387 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "用户";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add( this.label5 );
            this.groupBox3.Controls.Add( this.btnAddGroup );
            this.groupBox3.Controls.Add( this.chkLock );
            this.groupBox3.Controls.Add( this.btnRemoveGroup );
            this.groupBox3.Controls.Add( this.lvwGroup );
            this.groupBox3.Controls.Add( this.btnResetPassword );
            this.groupBox3.Controls.Add( this.label7 );
            this.groupBox3.Controls.Add( this.txtPassword );
            this.groupBox3.Controls.Add( this.txtUserCode );
            this.groupBox3.Controls.Add( this.label6 );
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point( 3 , 3 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 360 , 378 );
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "用户信息";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point( 196 , 349 );
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size( 75 , 23 );
            this.btnAddGroup.TabIndex = 1;
            this.btnAddGroup.Text = "选择";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler( this.btnAddGroup_Click );
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.Location = new System.Drawing.Point( 73 , 98 );
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size( 60 , 16 );
            this.chkLock.TabIndex = 15;
            this.chkLock.Text = "禁  用";
            this.chkLock.UseVisualStyleBackColor = true;
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.Location = new System.Drawing.Point( 277 , 349 );
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size( 75 , 23 );
            this.btnRemoveGroup.TabIndex = 3;
            this.btnRemoveGroup.Text = "移除";
            this.btnRemoveGroup.UseVisualStyleBackColor = true;
            this.btnRemoveGroup.Click += new System.EventHandler( this.btnRemoveGroup_Click );
            // 
            // lvwGroup
            // 
            this.lvwGroup.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4} );
            this.lvwGroup.FullRowSelect = true;
            this.lvwGroup.Location = new System.Drawing.Point( 2 , 137 );
            this.lvwGroup.Name = "lvwGroup";
            this.lvwGroup.Size = new System.Drawing.Size( 352 , 206 );
            this.lvwGroup.TabIndex = 0;
            this.lvwGroup.UseCompatibleStateImageBehavior = false;
            this.lvwGroup.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "用户组";
            this.columnHeader3.Width = 159;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "备注";
            this.columnHeader4.Width = 129;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point( 247 , 67 );
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size( 75 , 23 );
            this.btnResetPassword.TabIndex = 14;
            this.btnResetPassword.Text = "重置";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler( this.btnResetPassword_Click );
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point( 15 , 75 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 29 , 12 );
            this.label7.TabIndex = 11;
            this.label7.Text = "密码";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point( 73 , 68 );
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size( 173 , 21 );
            this.txtPassword.TabIndex = 13;
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point( 73 , 31 );
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size( 173 , 21 );
            this.txtUserCode.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 15 , 35 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 41 , 12 );
            this.label6.TabIndex = 10;
            this.label6.Text = "用户名";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point( 214 , 418 );
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size( 75 , 23 );
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point( 295 , 418 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75 , 23 );
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point( 6 , 122 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 125 , 12 );
            this.label5.TabIndex = 16;
            this.label5.Text = "用户名分配后不能删除";
            // 
            // FrmEmployeeAtter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 374 , 453 );
            this.Controls.Add( this.btnOk );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.tabControl1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEmployeeAtter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEmployeeAtter";
            this.Load += new System.EventHandler( this.FrmEmployeeAtter_Load );
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.tabPage1.PerformLayout( );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
            this.groupBox2.ResumeLayout( false );
            this.tabPage2.ResumeLayout( false );
            this.groupBox3.ResumeLayout( false );
            this.groupBox3.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddDept;
        private System.Windows.Forms.Button btnRemoveDept;
        private System.Windows.Forms.ListView lvwDept;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.ListView lvwGroup;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkDm;
        private System.Windows.Forms.CheckBox chkMz;
        private System.Windows.Forms.CheckBox chkCf;
        private System.Windows.Forms.TextBox txtDocCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.CheckBox chkNoUse;
        private System.Windows.Forms.Label label5;
    }
}