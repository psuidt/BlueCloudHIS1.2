namespace HIS_BaseManager.基本数据维护
{
    partial class FrmTableConfig
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
                components.Dispose();
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableCNName = new System.Windows.Forms.TextBox();
            this.chkAllowEdit = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboTableDBName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAllowDelete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 35, 30 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 65, 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "表物理名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point( 35, 63 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 65, 12 );
            this.label2.TabIndex = 1;
            this.label2.Text = "表概念名称";
            // 
            // txtTableCNName
            // 
            this.txtTableCNName.Location = new System.Drawing.Point( 106, 60 );
            this.txtTableCNName.Name = "txtTableCNName";
            this.txtTableCNName.Size = new System.Drawing.Size( 262, 21 );
            this.txtTableCNName.TabIndex = 3;
            // 
            // chkAllowEdit
            // 
            this.chkAllowEdit.AutoSize = true;
            this.chkAllowEdit.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowEdit.Location = new System.Drawing.Point( 106, 89 );
            this.chkAllowEdit.Name = "chkAllowEdit";
            this.chkAllowEdit.Size = new System.Drawing.Size( 144, 16 );
            this.chkAllowEdit.TabIndex = 4;
            this.chkAllowEdit.Text = "允许用户维护表的数据";
            this.chkAllowEdit.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point( 7, 137 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 378, 8 );
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point( 67, 157 );
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size( 75, 23 );
            this.btnAddNew.TabIndex = 6;
            this.btnAddNew.Text = "新增";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler( this.btnAddNew_Click );
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point( 148, 157 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 75, 23 );
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point( 229, 157 );
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size( 75, 23 );
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler( this.btnDelete_Click );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 310, 157 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 23 );
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // cboTableDBName
            // 
            this.cboTableDBName.FormattingEnabled = true;
            this.cboTableDBName.Location = new System.Drawing.Point( 106, 27 );
            this.cboTableDBName.MaxDropDownItems = 40;
            this.cboTableDBName.Name = "cboTableDBName";
            this.cboTableDBName.Size = new System.Drawing.Size( 262, 20 );
            this.cboTableDBName.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point( 5, 198 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 149, 12 );
            this.label3.TabIndex = 11;
            this.label3.Text = "新增维护表前请先点击添加";
            // 
            // chkAllowDelete
            // 
            this.chkAllowDelete.AutoSize = true;
            this.chkAllowDelete.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowDelete.ForeColor = System.Drawing.Color.Red;
            this.chkAllowDelete.Location = new System.Drawing.Point( 106, 115 );
            this.chkAllowDelete.Name = "chkAllowDelete";
            this.chkAllowDelete.Size = new System.Drawing.Size( 180, 16 );
            this.chkAllowDelete.TabIndex = 12;
            this.chkAllowDelete.Text = "允许对表内记录进行物理删除";
            this.chkAllowDelete.UseVisualStyleBackColor = false;
            // 
            // FrmTableConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 402, 230 );
            this.Controls.Add( this.chkAllowDelete );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.cboTableDBName );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.btnDelete );
            this.Controls.Add( this.btnSave );
            this.Controls.Add( this.btnAddNew );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.chkAllowEdit );
            this.Controls.Add( this.txtTableCNName );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTableConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "表维护";
            this.Load += new System.EventHandler( this.FrmTableConfig_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTableCNName;
        private System.Windows.Forms.CheckBox chkAllowEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cboTableDBName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAllowDelete;
    }
}