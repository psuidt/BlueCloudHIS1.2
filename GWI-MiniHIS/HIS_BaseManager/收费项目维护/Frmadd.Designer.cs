namespace HIS_BaseManager
{
    partial class FrmEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn4 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label5 = new System.Windows.Forms.Label( );
            this.txtStdCode = new System.Windows.Forms.TextBox( );
            this.txtItemName = new System.Windows.Forms.TextBox( );
            this.txtPrice = new System.Windows.Forms.TextBox( );
            this.txtUnit = new System.Windows.Forms.TextBox( );
            this.btnSave = new System.Windows.Forms.Button( );
            this.btnCancel = new System.Windows.Forms.Button( );
            this.btnNext = new System.Windows.Forms.Button( );
            this.chkValid = new System.Windows.Forms.CheckBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.btnPrevious = new System.Windows.Forms.Button( );
            this.label6 = new System.Windows.Forms.Label( );
            this.label7 = new System.Windows.Forms.Label( );
            this.cboInsurType = new System.Windows.Forms.ComboBox( );
            this.txtNcmsCompRate = new GWI.HIS.Windows.Controls.QueryTextBox( );
            this.label9 = new System.Windows.Forms.Label( );
            this.cboStatItem = new GWI.HIS.Windows.Controls.QueryTextBox( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label1.Location = new System.Drawing.Point( 25 , 22 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 77 , 14 );
            this.label1.TabIndex = 0;
            this.label1.Text = "医疗编码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label2.Location = new System.Drawing.Point( 25 , 63 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 77 , 14 );
            this.label2.TabIndex = 1;
            this.label2.Text = "项目名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label3.Location = new System.Drawing.Point( 25 , 138 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 49 , 14 );
            this.label3.TabIndex = 2;
            this.label3.Text = "价格：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label4.Location = new System.Drawing.Point( 199 , 138 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 77 , 14 );
            this.label4.TabIndex = 3;
            this.label4.Text = "计价单位：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label5.Location = new System.Drawing.Point( 25 , 101 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 77 , 14 );
            this.label5.TabIndex = 4;
            this.label5.Text = "统计大类：";
            // 
            // txtStdCode
            // 
            this.txtStdCode.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtStdCode.Location = new System.Drawing.Point( 96 , 19 );
            this.txtStdCode.Name = "txtStdCode";
            this.txtStdCode.Size = new System.Drawing.Size( 155 , 23 );
            this.txtStdCode.TabIndex = 0;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtItemName.Location = new System.Drawing.Point( 96 , 57 );
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size( 323 , 23 );
            this.txtItemName.TabIndex = 1;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtPrice.Location = new System.Drawing.Point( 96 , 135 );
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size( 100 , 23 );
            this.txtPrice.TabIndex = 3;
            // 
            // txtUnit
            // 
            this.txtUnit.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtUnit.Location = new System.Drawing.Point( 270 , 135 );
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size( 100 , 23 );
            this.txtUnit.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.btnSave.Location = new System.Drawing.Point( 277 , 251 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 77 , 24 );
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.btnCancel.Location = new System.Drawing.Point( 358 , 251 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 77 , 24 );
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.btnNext.Location = new System.Drawing.Point( 183 , 251 );
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size( 77 , 24 );
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "下一条(&N)";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler( this.btnNext_Click );
            // 
            // chkValid
            // 
            this.chkValid.AutoSize = true;
            this.chkValid.BackColor = System.Drawing.Color.Transparent;
            this.chkValid.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.chkValid.Location = new System.Drawing.Point( 376 , 138 );
            this.chkValid.Name = "chkValid";
            this.chkValid.Size = new System.Drawing.Size( 54 , 18 );
            this.chkValid.TabIndex = 19;
            this.chkValid.Text = "有效";
            this.chkValid.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.groupBox1.Location = new System.Drawing.Point( 18 , 231 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 437 , 8 );
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.btnPrevious.Location = new System.Drawing.Point( 102 , 251 );
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size( 77 , 24 );
            this.btnPrevious.TabIndex = 11;
            this.btnPrevious.Text = "上一条(&P)";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler( this.btnPrevious_Click );
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label6.Location = new System.Drawing.Point( 196 , 176 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 77 , 14 );
            this.label6.TabIndex = 31;
            this.label6.Text = "医保类型：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label7.Location = new System.Drawing.Point( 22 , 176 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 105 , 14 );
            this.label7.TabIndex = 30;
            this.label7.Text = "农合补偿比例：";
            // 
            // cboInsurType
            // 
            this.cboInsurType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInsurType.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.cboInsurType.FormattingEnabled = true;
            this.cboInsurType.Location = new System.Drawing.Point( 267 , 173 );
            this.cboInsurType.Name = "cboInsurType";
            this.cboInsurType.Size = new System.Drawing.Size( 149 , 22 );
            this.cboInsurType.TabIndex = 6;
            this.cboInsurType.SelectedIndexChanged += new System.EventHandler( this.cboInsurType_SelectedIndexChanged );
            // 
            // txtNcmsCompRate
            // 
            this.txtNcmsCompRate.AllowSelectedNullRow = false;
            this.txtNcmsCompRate.DisplayField = "";
            this.txtNcmsCompRate.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtNcmsCompRate.Location = new System.Drawing.Point( 120 , 173 );
            this.txtNcmsCompRate.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtNcmsCompRate.MemberField = "";
            this.txtNcmsCompRate.MemberValue = null;
            this.txtNcmsCompRate.Name = "txtNcmsCompRate";
            this.txtNcmsCompRate.NextControl = null;
            this.txtNcmsCompRate.NextControlByEnter = false;
            this.txtNcmsCompRate.OffsetX = 0;
            this.txtNcmsCompRate.OffsetY = 0;
            this.txtNcmsCompRate.QueryFields = null;
            this.txtNcmsCompRate.SelectedValue = null;
            this.txtNcmsCompRate.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNcmsCompRate.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtNcmsCompRate.SelectionCardColumnHeaderHeight = 30;
            this.txtNcmsCompRate.SelectionCardColumns = null;
            this.txtNcmsCompRate.SelectionCardFont = null;
            this.txtNcmsCompRate.SelectionCardHeight = 250;
            this.txtNcmsCompRate.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtNcmsCompRate.SelectionCardRowHeaderWidth = 35;
            this.txtNcmsCompRate.SelectionCardRowHeight = 23;
            this.txtNcmsCompRate.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtNcmsCompRate.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtNcmsCompRate.SelectionCardWidth = 250;
            this.txtNcmsCompRate.ShowRowNumber = true;
            this.txtNcmsCompRate.ShowSelectionCardAfterEnter = false;
            this.txtNcmsCompRate.Size = new System.Drawing.Size( 54 , 23 );
            this.txtNcmsCompRate.TabIndex = 5;
            this.txtNcmsCompRate.Text = "100";
            this.txtNcmsCompRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNcmsCompRate.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label9.Location = new System.Drawing.Point( 180 , 176 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 14 , 14 );
            this.label9.TabIndex = 35;
            this.label9.Text = "%";
            // 
            // cboStatItem
            // 
            this.cboStatItem.AllowSelectedNullRow = false;
            this.cboStatItem.DisplayField = "ITEM_NAME";
            this.cboStatItem.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.cboStatItem.Location = new System.Drawing.Point( 95 , 98 );
            this.cboStatItem.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.cboStatItem.MemberField = "CODE";
            this.cboStatItem.MemberValue = null;
            this.cboStatItem.Name = "cboStatItem";
            this.cboStatItem.NextControl = this.txtPrice;
            this.cboStatItem.NextControlByEnter = true;
            this.cboStatItem.OffsetX = 0;
            this.cboStatItem.OffsetY = 0;
            this.cboStatItem.QueryFields = new string[] {
        "ITEM_NAME",
        "PY_CODE",
        "WB_CODE"};
            this.cboStatItem.SelectedValue = null;
            this.cboStatItem.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.cboStatItem.SelectionCardBackColor = System.Drawing.Color.White;
            this.cboStatItem.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn1.AutoFill = false;
            selectionCardColumn1.DataBindField = "CODE";
            selectionCardColumn1.HeaderText = "CODE";
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = false;
            selectionCardColumn1.Width = 75;
            selectionCardColumn2.AutoFill = true;
            selectionCardColumn2.DataBindField = "ITEM_NAME";
            selectionCardColumn2.HeaderText = "大项目名称";
            selectionCardColumn2.IsSeachColumn = true;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 75;
            selectionCardColumn3.AutoFill = false;
            selectionCardColumn3.DataBindField = "PY_CODE";
            selectionCardColumn3.HeaderText = "PY_CODE";
            selectionCardColumn3.IsSeachColumn = false;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn3.Visiable = false;
            selectionCardColumn3.Width = 75;
            selectionCardColumn4.AutoFill = false;
            selectionCardColumn4.DataBindField = "WB_CODE";
            selectionCardColumn4.HeaderText = "WB_CODE";
            selectionCardColumn4.IsSeachColumn = false;
            selectionCardColumn4.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn4.Visiable = false;
            selectionCardColumn4.Width = 75;
            this.cboStatItem.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2,
        selectionCardColumn3,
        selectionCardColumn4};
            this.cboStatItem.SelectionCardFont = null;
            this.cboStatItem.SelectionCardHeight = 170;
            this.cboStatItem.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.cboStatItem.SelectionCardRowHeaderWidth = 35;
            this.cboStatItem.SelectionCardRowHeight = 23;
            this.cboStatItem.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.cboStatItem.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.cboStatItem.SelectionCardWidth = 320;
            this.cboStatItem.ShowRowNumber = true;
            this.cboStatItem.ShowSelectionCardAfterEnter = true;
            this.cboStatItem.Size = new System.Drawing.Size( 324 , 23 );
            this.cboStatItem.TabIndex = 2;
            this.cboStatItem.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // FrmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 487 , 305 );
            this.Controls.Add( this.cboStatItem );
            this.Controls.Add( this.label9 );
            this.Controls.Add( this.txtNcmsCompRate );
            this.Controls.Add( this.cboInsurType );
            this.Controls.Add( this.label6 );
            this.Controls.Add( this.label7 );
            this.Controls.Add( this.btnPrevious );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.chkValid );
            this.Controls.Add( this.btnNext );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnSave );
            this.Controls.Add( this.txtUnit );
            this.Controls.Add( this.txtPrice );
            this.Controls.Add( this.txtItemName );
            this.Controls.Add( this.txtStdCode );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler( this.FrmEdit_Load );
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.FrmEdit_KeyPress );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStdCode;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox chkValid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboInsurType;
        private GWI.HIS.Windows.Controls.QueryTextBox txtNcmsCompRate;
        private System.Windows.Forms.Label label9;
        private GWI.HIS.Windows.Controls.QueryTextBox cboStatItem;
    }
}