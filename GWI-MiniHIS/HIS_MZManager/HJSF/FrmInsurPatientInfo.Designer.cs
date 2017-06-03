namespace HIS_MZManager.HJSF
{
    partial class FrmInsurPatientInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmInsurPatientInfo ) );
            this.btnOk = new GWI.HIS.Windows.Controls.Button( );
            this.btnCancel = new GWI.HIS.Windows.Controls.Button( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.txtCardNo = new System.Windows.Forms.TextBox( );
            this.btnReadCard = new GWI.HIS.Windows.Controls.Button( );
            this.txtIdCard = new System.Windows.Forms.TextBox( );
            this.label10 = new System.Windows.Forms.Label( );
            this.lvwPatInfo = new System.Windows.Forms.ListView( );
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader( );
            this.SuspendLayout( );
            // 
            // btnOk
            // 
            this.btnOk.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Ok;
            this.btnOk.FixedWidth = true;
            this.btnOk.Image = ( (System.Drawing.Image)( resources.GetObject( "btnOk.Image" ) ) );
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point( 202 , 406 );
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size( 90 , 25 );
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Cancel;
            this.btnCancel.FixedWidth = true;
            this.btnCancel.Image = ( (System.Drawing.Image)( resources.GetObject( "btnCancel.Image" ) ) );
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point( 387 , 406 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 90 , 25 );
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point( 10 , 390 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 661 , 8 );
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Location = new System.Drawing.Point( 12 , 65 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 659 , 8 );
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point( 26 , 17 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 53 , 12 );
            this.label4.TabIndex = 24;
            this.label4.Text = "医疗证号";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point( 105 , 12 );
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size( 470 , 21 );
            this.txtCardNo.TabIndex = 25;
            this.txtCardNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtCardNo_KeyPress );
            // 
            // btnReadCard
            // 
            this.btnReadCard.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnReadCard.FixedWidth = true;
            this.btnReadCard.Location = new System.Drawing.Point( 581 , 33 );
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size( 90 , 25 );
            this.btnReadCard.TabIndex = 26;
            this.btnReadCard.Text = "读卡";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler( this.btnReadCard_Click );
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point( 105 , 39 );
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size( 470 , 21 );
            this.txtIdCard.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point( 26 , 44 );
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size( 53 , 12 );
            this.label10.TabIndex = 27;
            this.label10.Text = "身份证号";
            // 
            // lvwPatInfo
            // 
            this.lvwPatInfo.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9} );
            this.lvwPatInfo.FullRowSelect = true;
            this.lvwPatInfo.HideSelection = false;
            this.lvwPatInfo.Location = new System.Drawing.Point( 12 , 85 );
            this.lvwPatInfo.MultiSelect = false;
            this.lvwPatInfo.Name = "lvwPatInfo";
            this.lvwPatInfo.Size = new System.Drawing.Size( 659 , 299 );
            this.lvwPatInfo.TabIndex = 29;
            this.lvwPatInfo.UseCompatibleStateImageBehavior = false;
            this.lvwPatInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "地区编码";
            this.columnHeader1.Width = 104;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 89;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "性别";
            this.columnHeader3.Width = 55;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "年龄";
            this.columnHeader4.Width = 51;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "出生日期";
            this.columnHeader5.Width = 108;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "身份证号";
            this.columnHeader6.Width = 149;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "个人编码";
            this.columnHeader7.Width = 124;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "医疗证号";
            this.columnHeader8.Width = 127;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "家庭编码";
            this.columnHeader9.Width = 124;
            // 
            // FrmInsurPatientInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size( 683 , 447 );
            this.ControlBox = false;
            this.Controls.Add( this.lvwPatInfo );
            this.Controls.Add( this.txtIdCard );
            this.Controls.Add( this.label10 );
            this.Controls.Add( this.btnReadCard );
            this.Controls.Add( this.txtCardNo );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnOk );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInsurPatientInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人参保信息";
            this.Load += new System.EventHandler( this.FrmInsurPatientInfo_Load );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private GWI.HIS.Windows.Controls.Button btnOk;
        private GWI.HIS.Windows.Controls.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCardNo;
        private GWI.HIS.Windows.Controls.Button btnReadCard;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lvwPatInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}