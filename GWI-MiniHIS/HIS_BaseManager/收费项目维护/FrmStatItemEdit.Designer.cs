namespace HIS_BaseManager
{
    partial class FrmStatItemEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.chkItemType = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCflx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMzfp = new System.Windows.Forms.ComboBox();
            this.cboMzkj = new System.Windows.Forms.ComboBox();
            this.cboHs = new System.Windows.Forms.ComboBox();
            this.cboMzyb = new System.Windows.Forms.ComboBox();
            this.cboZyfp = new System.Windows.Forms.ComboBox();
            this.cboZykj = new System.Windows.Forms.ComboBox();
            this.cboBa = new System.Windows.Forms.ComboBox();
            this.cboZyyb = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 37, 26 );
            this.label1.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 67, 15 );
            this.label1.TabIndex = 0;
            this.label1.Text = "大类名称";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point( 116, 22 );
            this.txtItemName.Margin = new System.Windows.Forms.Padding( 4 );
            this.txtItemName.MaxLength = 20;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size( 371, 24 );
            this.txtItemName.TabIndex = 1;
            // 
            // chkItemType
            // 
            this.chkItemType.AutoSize = true;
            this.chkItemType.BackColor = System.Drawing.Color.Transparent;
            this.chkItemType.Location = new System.Drawing.Point( 496, 29 );
            this.chkItemType.Margin = new System.Windows.Forms.Padding( 4 );
            this.chkItemType.Name = "chkItemType";
            this.chkItemType.Size = new System.Drawing.Size( 116, 19 );
            this.chkItemType.TabIndex = 2;
            this.chkItemType.Text = "是否药品项目";
            this.chkItemType.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point( 385, 79 );
            this.label2.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 67, 15 );
            this.label2.TabIndex = 3;
            this.label2.Text = "处方类型";
            // 
            // cboCflx
            // 
            this.cboCflx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCflx.FormattingEnabled = true;
            this.cboCflx.Location = new System.Drawing.Point( 477, 75 );
            this.cboCflx.Margin = new System.Windows.Forms.Padding( 4 );
            this.cboCflx.Name = "cboCflx";
            this.cboCflx.Size = new System.Drawing.Size( 145, 23 );
            this.cboCflx.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point( 37, 140 );
            this.label3.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 127, 15 );
            this.label3.TabIndex = 5;
            this.label3.Text = "所属门诊发票分类";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point( 37, 182 );
            this.label4.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 127, 15 );
            this.label4.TabIndex = 6;
            this.label4.Text = "所属门诊会计分类";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point( 37, 225 );
            this.label5.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 127, 15 );
            this.label5.TabIndex = 7;
            this.label5.Text = "所属经管核算分类";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point( 37, 270 );
            this.label6.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 127, 15 );
            this.label6.TabIndex = 8;
            this.label6.Text = "所属门诊医保分类";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point( 335, 140 );
            this.label7.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 127, 15 );
            this.label7.TabIndex = 9;
            this.label7.Text = "所属住院发票分类";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point( 335, 182 );
            this.label8.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 127, 15 );
            this.label8.TabIndex = 10;
            this.label8.Text = "所属住院会计分类";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point( 335, 225 );
            this.label9.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 127, 15 );
            this.label9.TabIndex = 11;
            this.label9.Text = "所属病案统计分类";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point( 335, 270 );
            this.label10.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size( 127, 15 );
            this.label10.TabIndex = 12;
            this.label10.Text = "所属住院医保分类";
            // 
            // cboMzfp
            // 
            this.cboMzfp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMzfp.FormattingEnabled = true;
            this.cboMzfp.Location = new System.Drawing.Point( 180, 136 );
            this.cboMzfp.Margin = new System.Windows.Forms.Padding( 4 );
            this.cboMzfp.MaxDropDownItems = 15;
            this.cboMzfp.Name = "cboMzfp";
            this.cboMzfp.Size = new System.Drawing.Size( 145, 23 );
            this.cboMzfp.TabIndex = 13;
            // 
            // cboMzkj
            // 
            this.cboMzkj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMzkj.FormattingEnabled = true;
            this.cboMzkj.Location = new System.Drawing.Point( 180, 179 );
            this.cboMzkj.Margin = new System.Windows.Forms.Padding( 4 );
            this.cboMzkj.MaxDropDownItems = 15;
            this.cboMzkj.Name = "cboMzkj";
            this.cboMzkj.Size = new System.Drawing.Size( 145, 23 );
            this.cboMzkj.TabIndex = 14;
            // 
            // cboHs
            // 
            this.cboHs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHs.FormattingEnabled = true;
            this.cboHs.Location = new System.Drawing.Point( 180, 221 );
            this.cboHs.Margin = new System.Windows.Forms.Padding( 4 );
            this.cboHs.MaxDropDownItems = 15;
            this.cboHs.Name = "cboHs";
            this.cboHs.Size = new System.Drawing.Size( 145, 23 );
            this.cboHs.TabIndex = 15;
            // 
            // cboMzyb
            // 
            this.cboMzyb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMzyb.FormattingEnabled = true;
            this.cboMzyb.Location = new System.Drawing.Point( 180, 266 );
            this.cboMzyb.Margin = new System.Windows.Forms.Padding( 4 );
            this.cboMzyb.MaxDropDownItems = 15;
            this.cboMzyb.Name = "cboMzyb";
            this.cboMzyb.Size = new System.Drawing.Size( 145, 23 );
            this.cboMzyb.TabIndex = 16;
            // 
            // cboZyfp
            // 
            this.cboZyfp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZyfp.FormattingEnabled = true;
            this.cboZyfp.Location = new System.Drawing.Point( 477, 136 );
            this.cboZyfp.Margin = new System.Windows.Forms.Padding( 4 );
            this.cboZyfp.MaxDropDownItems = 15;
            this.cboZyfp.Name = "cboZyfp";
            this.cboZyfp.Size = new System.Drawing.Size( 145, 23 );
            this.cboZyfp.TabIndex = 17;
            // 
            // cboZykj
            // 
            this.cboZykj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZykj.FormattingEnabled = true;
            this.cboZykj.Location = new System.Drawing.Point( 477, 179 );
            this.cboZykj.Margin = new System.Windows.Forms.Padding( 4 );
            this.cboZykj.MaxDropDownItems = 15;
            this.cboZykj.Name = "cboZykj";
            this.cboZykj.Size = new System.Drawing.Size( 145, 23 );
            this.cboZykj.TabIndex = 18;
            // 
            // cboBa
            // 
            this.cboBa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBa.FormattingEnabled = true;
            this.cboBa.Location = new System.Drawing.Point( 477, 221 );
            this.cboBa.Margin = new System.Windows.Forms.Padding( 4 );
            this.cboBa.MaxDropDownItems = 15;
            this.cboBa.Name = "cboBa";
            this.cboBa.Size = new System.Drawing.Size( 145, 23 );
            this.cboBa.TabIndex = 19;
            // 
            // cboZyyb
            // 
            this.cboZyyb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZyyb.FormattingEnabled = true;
            this.cboZyyb.Location = new System.Drawing.Point( 477, 266 );
            this.cboZyyb.Margin = new System.Windows.Forms.Padding( 4 );
            this.cboZyyb.MaxDropDownItems = 15;
            this.cboZyyb.Name = "cboZyyb";
            this.cboZyyb.Size = new System.Drawing.Size( 145, 23 );
            this.cboZyyb.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point( 40, 312 );
            this.groupBox1.Margin = new System.Windows.Forms.Padding( 4 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding( 4 );
            this.groupBox1.Size = new System.Drawing.Size( 584, 2 );
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point( 416, 331 );
            this.btnSave.Margin = new System.Windows.Forms.Padding( 4 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 100, 29 );
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point( 524, 331 );
            this.btnCancel.Margin = new System.Windows.Forms.Padding( 4 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 100, 29 );
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point( 37, 79 );
            this.label11.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size( 69, 15 );
            this.label11.TabIndex = 24;
            this.label11.Text = "编    码";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point( 116, 74 );
            this.txtCode.Margin = new System.Windows.Forms.Padding( 4 );
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size( 209, 24 );
            this.txtCode.TabIndex = 25;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.Font = new System.Drawing.Font( "宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            this.lblNote.ForeColor = System.Drawing.Color.Red;
            this.lblNote.Location = new System.Drawing.Point( 37, 338 );
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size( 352, 15 );
            this.lblNote.TabIndex = 26;
            this.lblNote.Text = "注意：名称和代码保存后将不可修改,请仔细填写";
            // 
            // FrmStatItemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 671, 375 );
            this.ControlBox = false;
            this.Controls.Add( this.lblNote );
            this.Controls.Add( this.txtCode );
            this.Controls.Add( this.label11 );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnSave );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.cboZyyb );
            this.Controls.Add( this.cboBa );
            this.Controls.Add( this.cboZykj );
            this.Controls.Add( this.cboZyfp );
            this.Controls.Add( this.cboMzyb );
            this.Controls.Add( this.cboHs );
            this.Controls.Add( this.cboMzkj );
            this.Controls.Add( this.cboMzfp );
            this.Controls.Add( this.label10 );
            this.Controls.Add( this.label9 );
            this.Controls.Add( this.label8 );
            this.Controls.Add( this.label7 );
            this.Controls.Add( this.label6 );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.cboCflx );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.chkItemType );
            this.Controls.Add( this.txtItemName );
            this.Controls.Add( this.label1 );
            this.Font = new System.Drawing.Font( "宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.Name = "FrmStatItemEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmStatItemEdit";
            this.Load += new System.EventHandler( this.FrmStatItemEdit_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.CheckBox chkItemType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCflx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMzfp;
        private System.Windows.Forms.ComboBox cboMzkj;
        private System.Windows.Forms.ComboBox cboHs;
        private System.Windows.Forms.ComboBox cboMzyb;
        private System.Windows.Forms.ComboBox cboZyfp;
        private System.Windows.Forms.ComboBox cboZykj;
        private System.Windows.Forms.ComboBox cboBa;
        private System.Windows.Forms.ComboBox cboZyyb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblNote;
    }
}