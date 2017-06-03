namespace HIS_MZManager.HJSF
{
    partial class FrmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmSetting ) );
            this.btnInputLanguage = new GWI.HIS.Windows.Controls.Button( );
            this.label2 = new System.Windows.Forms.Label( );
            this.btnClose = new GWI.HIS.Windows.Controls.Button( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.cboFilterType = new System.Windows.Forms.ComboBox( );
            this.label8 = new System.Windows.Forms.Label( );
            this.label7 = new System.Windows.Forms.Label( );
            this.label6 = new System.Windows.Forms.Label( );
            this.btnSelectColor = new GWI.HIS.Windows.Controls.Button( );
            this.plBackColor = new System.Windows.Forms.Panel( );
            this.cboFontSize = new System.Windows.Forms.ComboBox( );
            this.cboRowHeight = new System.Windows.Forms.ComboBox( );
            this.label5 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.colorDlg = new System.Windows.Forms.ColorDialog( );
            this.btnReportPrintSet = new GWI.HIS.Windows.Controls.Button( );
            this.label1 = new System.Windows.Forms.Label( );
            this.cboCardType = new System.Windows.Forms.ComboBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.groupBox1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // btnInputLanguage
            // 
            this.btnInputLanguage.BackColor = System.Drawing.Color.Transparent;
            this.btnInputLanguage.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnInputLanguage.FixedWidth = false;
            this.btnInputLanguage.Location = new System.Drawing.Point( 13 , 15 );
            this.btnInputLanguage.Name = "btnInputLanguage";
            this.btnInputLanguage.Size = new System.Drawing.Size( 159 , 25 );
            this.btnInputLanguage.TabIndex = 2;
            this.btnInputLanguage.Text = "输入法转换设置";
            this.btnInputLanguage.UseVisualStyleBackColor = false;
            this.btnInputLanguage.Click += new System.EventHandler( this.btnInputLanguage_Click );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point( 178 , 20 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 221 , 12 );
            this.label2.TabIndex = 4;
            this.label2.Text = "设置中英文输入法以便在录入时自动切换";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.CloseWindow;
            this.btnClose.FixedWidth = true;
            this.btnClose.Image = ( (System.Drawing.Image)( resources.GetObject( "btnClose.Image" ) ) );
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point( 300 , 257 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 90 , 25 );
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭窗口(&X)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add( this.label4 );
            this.groupBox1.Controls.Add( this.cboCardType );
            this.groupBox1.Controls.Add( this.cboFilterType );
            this.groupBox1.Controls.Add( this.label8 );
            this.groupBox1.Controls.Add( this.label7 );
            this.groupBox1.Controls.Add( this.label6 );
            this.groupBox1.Controls.Add( this.btnSelectColor );
            this.groupBox1.Controls.Add( this.plBackColor );
            this.groupBox1.Controls.Add( this.cboFontSize );
            this.groupBox1.Controls.Add( this.cboRowHeight );
            this.groupBox1.Controls.Add( this.label5 );
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Location = new System.Drawing.Point( 12 , 93 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 384 , 158 );
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "处方网格";
            // 
            // cboFilterType
            // 
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.FormattingEnabled = true;
            this.cboFilterType.Items.AddRange( new object[] {
            "模糊查询",
            "前导相似"} );
            this.cboFilterType.Location = new System.Drawing.Point( 116 , 100 );
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size( 121 , 20 );
            this.cboFilterType.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point( 21 , 103 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 89 , 12 );
            this.label8.TabIndex = 15;
            this.label8.Text = "选显卡过滤方式";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point( 258 , 20 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 120 , 48 );
            this.label7.TabIndex = 14;
            this.label7.Text = "设置处方网格的显示效果，参数设置后需要重新打开窗口";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 21 , 72 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 41 , 12 );
            this.label6.TabIndex = 13;
            this.label6.Text = "背景色";
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnSelectColor.FixedWidth = false;
            this.btnSelectColor.Location = new System.Drawing.Point( 192 , 66 );
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size( 41 , 25 );
            this.btnSelectColor.TabIndex = 12;
            this.btnSelectColor.Text = "...";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler( this.btnSelectColor_Click );
            // 
            // plBackColor
            // 
            this.plBackColor.BackColor = System.Drawing.SystemColors.Control;
            this.plBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plBackColor.Location = new System.Drawing.Point( 116 , 67 );
            this.plBackColor.Name = "plBackColor";
            this.plBackColor.Size = new System.Drawing.Size( 70 , 27 );
            this.plBackColor.TabIndex = 11;
            // 
            // cboFontSize
            // 
            this.cboFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontSize.FormattingEnabled = true;
            this.cboFontSize.Items.AddRange( new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14"} );
            this.cboFontSize.Location = new System.Drawing.Point( 116 , 41 );
            this.cboFontSize.Name = "cboFontSize";
            this.cboFontSize.Size = new System.Drawing.Size( 117 , 20 );
            this.cboFontSize.TabIndex = 9;
            // 
            // cboRowHeight
            // 
            this.cboRowHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRowHeight.FormattingEnabled = true;
            this.cboRowHeight.Items.AddRange( new object[] {
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"} );
            this.cboRowHeight.Location = new System.Drawing.Point( 116 , 15 );
            this.cboRowHeight.Name = "cboRowHeight";
            this.cboRowHeight.Size = new System.Drawing.Size( 117 , 20 );
            this.cboRowHeight.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 21 , 44 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 53 , 12 );
            this.label5.TabIndex = 1;
            this.label5.Text = "字体大小";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 21 , 20 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 29 , 12 );
            this.label3.TabIndex = 0;
            this.label3.Text = "行高";
            // 
            // btnReportPrintSet
            // 
            this.btnReportPrintSet.BackColor = System.Drawing.Color.Transparent;
            this.btnReportPrintSet.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnReportPrintSet.FixedWidth = false;
            this.btnReportPrintSet.Location = new System.Drawing.Point( 13 , 55 );
            this.btnReportPrintSet.Name = "btnReportPrintSet";
            this.btnReportPrintSet.Size = new System.Drawing.Size( 159 , 25 );
            this.btnReportPrintSet.TabIndex = 9;
            this.btnReportPrintSet.Text = "报表打印机设置";
            this.btnReportPrintSet.UseVisualStyleBackColor = false;
            this.btnReportPrintSet.Click += new System.EventHandler( this.btnReportPrintSet_Click );
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 178 , 53 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 221 , 37 );
            this.label1.TabIndex = 10;
            this.label1.Text = "设置各个报表所用的打印机,点击按钮后系统搜索安装的打印机会花费一定的时间，请等待";
            // 
            // cboCardType
            // 
            this.cboCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCardType.FormattingEnabled = true;
            this.cboCardType.Location = new System.Drawing.Point( 116 , 126 );
            this.cboCardType.Name = "cboCardType";
            this.cboCardType.Size = new System.Drawing.Size( 121 , 20 );
            this.cboCardType.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 21 , 129 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 89 , 12 );
            this.label4.TabIndex = 18;
            this.label4.Text = "选显卡显示类型";
            // 
            // FrmSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size( 411 , 294 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.btnReportPrintSet );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.btnInputLanguage );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选项";
            this.Load += new System.EventHandler( this.FrmSetting_Load );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private GWI.HIS.Windows.Controls.Button btnInputLanguage;
        private System.Windows.Forms.Label label2;
        private GWI.HIS.Windows.Controls.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFontSize;
        private System.Windows.Forms.ComboBox cboRowHeight;
        private System.Windows.Forms.ColorDialog colorDlg;
        private GWI.HIS.Windows.Controls.Button btnSelectColor;
        private System.Windows.Forms.Panel plBackColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboFilterType;
        private GWI.HIS.Windows.Controls.Button btnReportPrintSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCardType;
        private System.Windows.Forms.Label label4;
    }
}