namespace HIS_BaseManager
{
    partial class FrmCreatePYWB
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
            this.cboTable = new System.Windows.Forms.ComboBox( );
            this.chkPY = new System.Windows.Forms.CheckBox( );
            this.chkWB = new System.Windows.Forms.CheckBox( );
            this.btnCreat = new System.Windows.Forms.Button( );
            this.btnExit = new System.Windows.Forms.Button( );
            this.label2 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.label4 = new System.Windows.Forms.Label( );
            this.cboName = new System.Windows.Forms.ComboBox( );
            this.cboPK = new System.Windows.Forms.ComboBox( );
            this.cboPY = new System.Windows.Forms.ComboBox( );
            this.cboWb = new System.Windows.Forms.ComboBox( );
            this.label5 = new System.Windows.Forms.Label( );
            this.chkIsNumeric = new System.Windows.Forms.CheckBox( );
            this.chkEmpty = new System.Windows.Forms.CheckBox( );
            this.lblCount = new System.Windows.Forms.Label( );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.pgbCount = new System.Windows.Forms.ProgressBar( );
            this.lblInfo = new System.Windows.Forms.Label( );
            this.panel1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 21 , 37 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 17 , 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "表";
            // 
            // cboTable
            // 
            this.cboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Location = new System.Drawing.Point( 78 , 34 );
            this.cboTable.MaxDropDownItems = 20;
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size( 307 , 20 );
            this.cboTable.TabIndex = 1;
            // 
            // chkPY
            // 
            this.chkPY.AutoSize = true;
            this.chkPY.BackColor = System.Drawing.Color.Transparent;
            this.chkPY.Location = new System.Drawing.Point( 78 , 164 );
            this.chkPY.Name = "chkPY";
            this.chkPY.Size = new System.Drawing.Size( 84 , 16 );
            this.chkPY.TabIndex = 2;
            this.chkPY.Text = "生成拼音码";
            this.chkPY.UseVisualStyleBackColor = false;
            // 
            // chkWB
            // 
            this.chkWB.AutoSize = true;
            this.chkWB.BackColor = System.Drawing.Color.Transparent;
            this.chkWB.Location = new System.Drawing.Point( 168 , 164 );
            this.chkWB.Name = "chkWB";
            this.chkWB.Size = new System.Drawing.Size( 84 , 16 );
            this.chkWB.TabIndex = 3;
            this.chkWB.Text = "生成五笔码";
            this.chkWB.UseVisualStyleBackColor = false;
            // 
            // btnCreat
            // 
            this.btnCreat.Location = new System.Drawing.Point( 128 , 186 );
            this.btnCreat.Name = "btnCreat";
            this.btnCreat.Size = new System.Drawing.Size( 75 , 23 );
            this.btnCreat.TabIndex = 4;
            this.btnCreat.Text = "生成";
            this.btnCreat.UseVisualStyleBackColor = true;
            this.btnCreat.Click += new System.EventHandler( this.btnCreat_Click );
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point( 222 , 186 );
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size( 75 , 23 );
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "关闭";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler( this.btnExit_Click );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point( 19 , 63 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53 , 12 );
            this.label2.TabIndex = 7;
            this.label2.Text = "名称字段";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point( 19 , 115 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 53 , 12 );
            this.label3.TabIndex = 8;
            this.label3.Text = "拼音字段";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point( 19 , 90 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 53 , 12 );
            this.label4.TabIndex = 9;
            this.label4.Text = "主键字段";
            // 
            // cboName
            // 
            this.cboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point( 78 , 60 );
            this.cboName.MaxDropDownItems = 20;
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size( 307 , 20 );
            this.cboName.TabIndex = 10;
            // 
            // cboPK
            // 
            this.cboPK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPK.FormattingEnabled = true;
            this.cboPK.Location = new System.Drawing.Point( 78 , 86 );
            this.cboPK.MaxDropDownItems = 20;
            this.cboPK.Name = "cboPK";
            this.cboPK.Size = new System.Drawing.Size( 229 , 20 );
            this.cboPK.TabIndex = 11;
            // 
            // cboPY
            // 
            this.cboPY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPY.FormattingEnabled = true;
            this.cboPY.Location = new System.Drawing.Point( 78 , 112 );
            this.cboPY.MaxDropDownItems = 20;
            this.cboPY.Name = "cboPY";
            this.cboPY.Size = new System.Drawing.Size( 307 , 20 );
            this.cboPY.TabIndex = 12;
            // 
            // cboWb
            // 
            this.cboWb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWb.FormattingEnabled = true;
            this.cboWb.Location = new System.Drawing.Point( 78 , 138 );
            this.cboWb.MaxDropDownItems = 20;
            this.cboWb.Name = "cboWb";
            this.cboWb.Size = new System.Drawing.Size( 307 , 20 );
            this.cboWb.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point( 19 , 141 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 53 , 12 );
            this.label5.TabIndex = 13;
            this.label5.Text = "五笔字段";
            // 
            // chkIsNumeric
            // 
            this.chkIsNumeric.AutoSize = true;
            this.chkIsNumeric.BackColor = System.Drawing.Color.Transparent;
            this.chkIsNumeric.Location = new System.Drawing.Point( 313 , 88 );
            this.chkIsNumeric.Name = "chkIsNumeric";
            this.chkIsNumeric.Size = new System.Drawing.Size( 72 , 16 );
            this.chkIsNumeric.TabIndex = 15;
            this.chkIsNumeric.Text = "数字类型";
            this.chkIsNumeric.UseVisualStyleBackColor = false;
            // 
            // chkEmpty
            // 
            this.chkEmpty.AutoSize = true;
            this.chkEmpty.BackColor = System.Drawing.Color.Transparent;
            this.chkEmpty.Location = new System.Drawing.Point( 258 , 164 );
            this.chkEmpty.Name = "chkEmpty";
            this.chkEmpty.Size = new System.Drawing.Size( 96 , 16 );
            this.chkEmpty.TabIndex = 16;
            this.chkEmpty.Text = "仅生成为空的";
            this.chkEmpty.UseVisualStyleBackColor = false;
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCount.Location = new System.Drawing.Point( 0 , 0 );
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size( 78 , 22 );
            this.lblCount.TabIndex = 17;
            this.lblCount.Text = "0/0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add( this.pgbCount );
            this.panel1.Controls.Add( this.lblCount );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point( 0 , 218 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 420 , 22 );
            this.panel1.TabIndex = 18;
            // 
            // pgbCount
            // 
            this.pgbCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgbCount.Location = new System.Drawing.Point( 78 , 0 );
            this.pgbCount.Name = "pgbCount";
            this.pgbCount.Size = new System.Drawing.Size( 342 , 22 );
            this.pgbCount.TabIndex = 18;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point( 21 , 9 );
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size( 197 , 12 );
            this.lblInfo.TabIndex = 19;
            this.lblInfo.Text = "仅系统管理员组的用户能使用该功能";
            // 
            // FrmCreatePYWB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 420 , 240 );
            this.Controls.Add( this.lblInfo );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.chkEmpty );
            this.Controls.Add( this.chkIsNumeric );
            this.Controls.Add( this.cboWb );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.cboPY );
            this.Controls.Add( this.cboPK );
            this.Controls.Add( this.cboName );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.btnExit );
            this.Controls.Add( this.btnCreat );
            this.Controls.Add( this.chkWB );
            this.Controls.Add( this.chkPY );
            this.Controls.Add( this.cboTable );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreatePYWB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "拼音五笔生成";
            this.Load += new System.EventHandler( this.FrmCreatePYWB_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.FrmCreatePYWB_FormClosing );
            this.panel1.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.CheckBox chkPY;
        private System.Windows.Forms.CheckBox chkWB;
        private System.Windows.Forms.Button btnCreat;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.ComboBox cboPK;
        private System.Windows.Forms.ComboBox cboPY;
        private System.Windows.Forms.ComboBox cboWb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsNumeric;
        private System.Windows.Forms.CheckBox chkEmpty;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar pgbCount;
        private System.Windows.Forms.Label lblInfo;
    }
}