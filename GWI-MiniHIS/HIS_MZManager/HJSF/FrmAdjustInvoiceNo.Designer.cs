namespace HIS_MZManager.HJSF
{
    partial class FrmAdjustInvoiceNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmAdjustInvoiceNo ) );
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.lblCurrent = new System.Windows.Forms.Label( );
            this.txtNewInvoiceNo = new GWI.HIS.Windows.Controls.QueryTextBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.btnOk = new GWI.HIS.Windows.Controls.Button( );
            this.btnCancel = new GWI.HIS.Windows.Controls.Button( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font( "宋体" , 15F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label1.Location = new System.Drawing.Point( 24 , 22 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 119 , 20 );
            this.label1.TabIndex = 0;
            this.label1.Text = "当前发票号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font( "宋体" , 15F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label2.Location = new System.Drawing.Point( 24 , 68 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 179 , 20 );
            this.label2.TabIndex = 1;
            this.label2.Text = "请输入新的发票号:";
            // 
            // lblCurrent
            // 
            this.lblCurrent.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrent.Font = new System.Drawing.Font( "宋体" , 15F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblCurrent.Location = new System.Drawing.Point( 217 , 17 );
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size( 180 , 30 );
            this.lblCurrent.TabIndex = 2;
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewInvoiceNo
            // 
            this.txtNewInvoiceNo.AllowSelectedNullRow = false;
            this.txtNewInvoiceNo.DisplayField = "";
            this.txtNewInvoiceNo.Font = new System.Drawing.Font( "宋体" , 15F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtNewInvoiceNo.Location = new System.Drawing.Point( 217 , 65 );
            this.txtNewInvoiceNo.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtNewInvoiceNo.MemberField = "";
            this.txtNewInvoiceNo.MemberValue = null;
            this.txtNewInvoiceNo.Name = "txtNewInvoiceNo";
            this.txtNewInvoiceNo.NextControl = null;
            this.txtNewInvoiceNo.NextControlByEnter = false;
            this.txtNewInvoiceNo.OffsetX = 0;
            this.txtNewInvoiceNo.OffsetY = 0;
            this.txtNewInvoiceNo.QueryFields = null;
            this.txtNewInvoiceNo.SelectedValue = null;
            this.txtNewInvoiceNo.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNewInvoiceNo.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtNewInvoiceNo.SelectionCardColumnHeaderHeight = 30;
            this.txtNewInvoiceNo.SelectionCardColumns = null;
            this.txtNewInvoiceNo.SelectionCardFont = null;
            this.txtNewInvoiceNo.SelectionCardHeight = 250;
            this.txtNewInvoiceNo.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtNewInvoiceNo.SelectionCardRowHeaderWidth = 35;
            this.txtNewInvoiceNo.SelectionCardRowHeight = 23;
            this.txtNewInvoiceNo.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtNewInvoiceNo.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtNewInvoiceNo.SelectionCardWidth = 250;
            this.txtNewInvoiceNo.ShowRowNumber = true;
            this.txtNewInvoiceNo.ShowSelectionCardAfterEnter = false;
            this.txtNewInvoiceNo.Size = new System.Drawing.Size( 180 , 30 );
            this.txtNewInvoiceNo.TabIndex = 3;
            this.txtNewInvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewInvoiceNo.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point( 17 , 117 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 420 , 8 );
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Ok;
            this.btnOk.FixedWidth = false;
            this.btnOk.Image = ( (System.Drawing.Image)( resources.GetObject( "btnOk.Image" ) ) );
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point( 103 , 137 );
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size( 98 , 25 );
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确认调整(&O)";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.CloseWindow;
            this.btnCancel.FixedWidth = false;
            this.btnCancel.Image = ( (System.Drawing.Image)( resources.GetObject( "btnCancel.Image" ) ) );
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point( 247 , 137 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 98 , 25 );
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "关闭窗口(&X)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // FrmAdjustInvoiceNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 447 , 179 );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnOk );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.txtNewInvoiceNo );
            this.Controls.Add( this.lblCurrent );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdjustInvoiceNo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "调整发票号";
            this.Load += new System.EventHandler( this.FrmAdjustInvoiceNo_Load );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrent;
        private GWI.HIS.Windows.Controls.QueryTextBox txtNewInvoiceNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private GWI.HIS.Windows.Controls.Button btnOk;
        private GWI.HIS.Windows.Controls.Button btnCancel;
    }
}