namespace HIS_MZManager.HJSF
{
    partial class FrmChargeInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.txtSelfTally = new System.Windows.Forms.TextBox( );
            this.label6 = new System.Windows.Forms.Label( );
            this.txtReturn = new System.Windows.Forms.Label( );
            this.label15 = new System.Windows.Forms.Label( );
            this.txtActPosPay = new System.Windows.Forms.TextBox( );
            this.lblPref = new System.Windows.Forms.Label( );
            this.txtActPay = new System.Windows.Forms.TextBox( );
            this.txtChargeUp = new System.Windows.Forms.TextBox( );
            this.label13 = new System.Windows.Forms.Label( );
            this.lblNeedCharge = new System.Windows.Forms.Label( );
            this.label14 = new System.Windows.Forms.Label( );
            this.lblTotal = new System.Windows.Forms.Label( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.label16 = new System.Windows.Forms.Label( );
            this.label1 = new System.Windows.Forms.Label( );
            this.lblSelfPay = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.btnOk = new System.Windows.Forms.Button( );
            this.btnCancel = new System.Windows.Forms.Button( );
            this.label5 = new System.Windows.Forms.Label( );
            this.groupBox1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add( this.txtSelfTally );
            this.groupBox1.Controls.Add( this.label6 );
            this.groupBox1.Controls.Add( this.txtReturn );
            this.groupBox1.Controls.Add( this.label15 );
            this.groupBox1.Controls.Add( this.txtActPosPay );
            this.groupBox1.Controls.Add( this.lblPref );
            this.groupBox1.Controls.Add( this.txtActPay );
            this.groupBox1.Controls.Add( this.txtChargeUp );
            this.groupBox1.Controls.Add( this.label13 );
            this.groupBox1.Controls.Add( this.lblNeedCharge );
            this.groupBox1.Controls.Add( this.label14 );
            this.groupBox1.Controls.Add( this.lblTotal );
            this.groupBox1.Controls.Add( this.label4 );
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Controls.Add( this.label16 );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point( 0 , 0 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 499 , 392 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtSelfTally
            // 
            this.txtSelfTally.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtSelfTally.Font = new System.Drawing.Font( "宋体" , 21.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtSelfTally.Location = new System.Drawing.Point( 210 , 203 );
            this.txtSelfTally.MaxLength = 8;
            this.txtSelfTally.Name = "txtSelfTally";
            this.txtSelfTally.Size = new System.Drawing.Size( 241 , 41 );
            this.txtSelfTally.TabIndex = 9;
            this.txtSelfTally.Text = "0.00";
            this.txtSelfTally.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSelfTally.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtMoenyInput_KeyPress );
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font( "宋体" , 18F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label6.Location = new System.Drawing.Point( 32 , 212 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 160 , 24 );
            this.label6.TabIndex = 8;
            this.label6.Text = "单位个人记账";
            // 
            // txtReturn
            // 
            this.txtReturn.BackColor = System.Drawing.Color.White;
            this.txtReturn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtReturn.Font = new System.Drawing.Font( "宋体" , 21.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtReturn.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
            this.txtReturn.Location = new System.Drawing.Point( 210 , 344 );
            this.txtReturn.Name = "txtReturn";
            this.txtReturn.Size = new System.Drawing.Size( 241 , 38 );
            this.txtReturn.TabIndex = 7;
            this.txtReturn.Text = "0.00";
            this.txtReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font( "宋体" , 18F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label15.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
            this.label15.Location = new System.Drawing.Point( 32 , 353 );
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size( 112 , 24 );
            this.label15.TabIndex = 1;
            this.label15.Text = "找    零";
            // 
            // txtActPosPay
            // 
            this.txtActPosPay.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtActPosPay.Font = new System.Drawing.Font( "宋体" , 21.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtActPosPay.Location = new System.Drawing.Point( 210 , 250 );
            this.txtActPosPay.MaxLength = 8;
            this.txtActPosPay.Name = "txtActPosPay";
            this.txtActPosPay.Size = new System.Drawing.Size( 241 , 41 );
            this.txtActPosPay.TabIndex = 6;
            this.txtActPosPay.Text = "0.00";
            this.txtActPosPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtActPosPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtMoenyInput_KeyPress );
            // 
            // lblPref
            // 
            this.lblPref.BackColor = System.Drawing.Color.White;
            this.lblPref.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPref.Font = new System.Drawing.Font( "宋体" , 21.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblPref.Location = new System.Drawing.Point( 210 , 62 );
            this.lblPref.Name = "lblPref";
            this.lblPref.Size = new System.Drawing.Size( 241 , 38 );
            this.lblPref.TabIndex = 6;
            this.lblPref.Text = "0.00";
            this.lblPref.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtActPay
            // 
            this.txtActPay.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtActPay.Font = new System.Drawing.Font( "宋体" , 21.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtActPay.Location = new System.Drawing.Point( 210 , 297 );
            this.txtActPay.MaxLength = 8;
            this.txtActPay.Name = "txtActPay";
            this.txtActPay.Size = new System.Drawing.Size( 241 , 41 );
            this.txtActPay.TabIndex = 5;
            this.txtActPay.Text = "0.00";
            this.txtActPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtActPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtMoenyInput_KeyPress );
            // 
            // txtChargeUp
            // 
            this.txtChargeUp.BackColor = System.Drawing.Color.White;
            this.txtChargeUp.Font = new System.Drawing.Font( "宋体" , 21.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtChargeUp.Location = new System.Drawing.Point( 210 , 106 );
            this.txtChargeUp.MaxLength = 8;
            this.txtChargeUp.Name = "txtChargeUp";
            this.txtChargeUp.Size = new System.Drawing.Size( 241 , 41 );
            this.txtChargeUp.TabIndex = 5;
            this.txtChargeUp.Text = "0.00";
            this.txtChargeUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChargeUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtMoenyInput_KeyPress );
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font( "宋体" , 18F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point( 32 , 306 );
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size( 110 , 24 );
            this.label13.TabIndex = 3;
            this.label13.Text = "实收现金";
            // 
            // lblNeedCharge
            // 
            this.lblNeedCharge.BackColor = System.Drawing.Color.White;
            this.lblNeedCharge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNeedCharge.Font = new System.Drawing.Font( "宋体" , 21.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblNeedCharge.ForeColor = System.Drawing.Color.Black;
            this.lblNeedCharge.Location = new System.Drawing.Point( 210 , 153 );
            this.lblNeedCharge.Name = "lblNeedCharge";
            this.lblNeedCharge.Size = new System.Drawing.Size( 241 , 38 );
            this.lblNeedCharge.TabIndex = 4;
            this.lblNeedCharge.Text = "0.00";
            this.lblNeedCharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font( "宋体" , 18F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label14.Location = new System.Drawing.Point( 32 , 260 );
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size( 112 , 24 );
            this.label14.TabIndex = 2;
            this.label14.Text = "实收 POS";
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Font = new System.Drawing.Font( "宋体" , 21.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblTotal.Location = new System.Drawing.Point( 210 , 18 );
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size( 241 , 38 );
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font( "宋体" , 18F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label4.Location = new System.Drawing.Point( 32 , 115 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 160 , 24 );
            this.label4.TabIndex = 3;
            this.label4.Text = "农合医保记账";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font( "宋体" , 18F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label3.Location = new System.Drawing.Point( 32 , 69 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 110 , 24 );
            this.label3.TabIndex = 2;
            this.label3.Text = "优惠金额";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font( "宋体" , 18F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point( 32 , 162 );
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size( 110 , 24 );
            this.label16.TabIndex = 0;
            this.label16.Text = "自付金额";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "宋体" , 18F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point( 32 , 26 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 111 , 24 );
            this.label1.TabIndex = 0;
            this.label1.Text = "总 金 额";
            // 
            // lblSelfPay
            // 
            this.lblSelfPay.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblSelfPay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSelfPay.Font = new System.Drawing.Font( "宋体" , 20F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblSelfPay.Location = new System.Drawing.Point( 177 , 449 );
            this.lblSelfPay.Name = "lblSelfPay";
            this.lblSelfPay.Size = new System.Drawing.Size( 149 , 35 );
            this.lblSelfPay.TabIndex = 7;
            this.lblSelfPay.Text = "0.00";
            this.lblSelfPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSelfPay.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "宋体" , 20F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label2.Location = new System.Drawing.Point( 27 , 449 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 124 , 27 );
            this.label2.TabIndex = 1;
            this.label2.Text = "自付金额";
            this.label2.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Font = new System.Drawing.Font( "宋体" , 15F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.btnOk.Image = global::HIS_MZManager.Properties.Resources.icon_accept;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point( 117 , 398 );
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size( 108 , 34 );
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确认";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font( "宋体" , 15F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.btnCancel.Image = global::HIS_MZManager.Properties.Resources.action_stop;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point( 271 , 398 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 108 , 34 );
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point( 0 , 435 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 499 , 35 );
            this.label5.TabIndex = 8;
            this.label5.Text = "  总金额   = 优惠金额 + 记帐金额 + 自付金额\r\n  自付金额 = 单位个人记账 +  实收现金 + 实收 POS - 找零金额";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmChargeInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size( 499 , 470 );
            this.ControlBox = false;
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnOk );
            this.Controls.Add( this.lblSelfPay );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.label2 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChargeInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler( this.FrmChargeInfo_Load );
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.FrmChargeInfo_KeyPress );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSelfPay;
        private System.Windows.Forms.Label lblPref;
        private System.Windows.Forms.TextBox txtChargeUp;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label txtReturn;
        private System.Windows.Forms.TextBox txtActPosPay;
        private System.Windows.Forms.TextBox txtActPay;
        private System.Windows.Forms.Label lblNeedCharge;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSelfTally;
        private System.Windows.Forms.Label label6;
    }
}