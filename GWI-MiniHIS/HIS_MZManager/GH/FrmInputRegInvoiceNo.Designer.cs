namespace HIS_MZManager.GH
{
    partial class FrmInputRegInvoiceNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmInputRegInvoiceNo ) );
            this.txtInvoiceNo = new GWI.HIS.Windows.Controls.QueryTextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.btnOK = new GWI.HIS.Windows.Controls.Button( );
            this.btnCancel = new GWI.HIS.Windows.Controls.Button( );
            this.txtPerfChar = new GWI.HIS.Windows.Controls.QueryTextBox( );
            this.SuspendLayout( );
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.AllowSelectedNullRow = false;
            this.txtInvoiceNo.DisplayField = "";
            this.txtInvoiceNo.Font = new System.Drawing.Font( "宋体" , 18F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtInvoiceNo.Location = new System.Drawing.Point( 103 , 64 );
            this.txtInvoiceNo.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtInvoiceNo.MemberField = "";
            this.txtInvoiceNo.MemberValue = null;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.NextControl = null;
            this.txtInvoiceNo.NextControlByEnter = false;
            this.txtInvoiceNo.OffsetX = 0;
            this.txtInvoiceNo.OffsetY = 0;
            this.txtInvoiceNo.QueryFields = null;
            this.txtInvoiceNo.SelectedValue = null;
            this.txtInvoiceNo.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtInvoiceNo.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtInvoiceNo.SelectionCardColumnHeaderHeight = 30;
            this.txtInvoiceNo.SelectionCardColumns = null;
            this.txtInvoiceNo.SelectionCardFont = null;
            this.txtInvoiceNo.SelectionCardHeight = 250;
            this.txtInvoiceNo.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtInvoiceNo.SelectionCardRowHeaderWidth = 35;
            this.txtInvoiceNo.SelectionCardRowHeight = 23;
            this.txtInvoiceNo.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtInvoiceNo.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtInvoiceNo.SelectionCardWidth = 250;
            this.txtInvoiceNo.ShowRowNumber = true;
            this.txtInvoiceNo.ShowSelectionCardAfterEnter = false;
            this.txtInvoiceNo.Size = new System.Drawing.Size( 219 , 35 );
            this.txtInvoiceNo.TabIndex = 0;
            this.txtInvoiceNo.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font( "宋体" , 13F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label1.Location = new System.Drawing.Point( 22 , 26 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 206 , 18 );
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入要退的挂号收据号";
            // 
            // btnOK
            // 
            this.btnOK.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Ok;
            this.btnOK.FixedWidth = true;
            this.btnOK.Image = ( (System.Drawing.Image)( resources.GetObject( "btnOK.Image" ) ) );
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point( 76 , 119 );
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size( 90 , 25 );
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Cancel;
            this.btnCancel.FixedWidth = true;
            this.btnCancel.Image = ( (System.Drawing.Image)( resources.GetObject( "btnCancel.Image" ) ) );
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point( 212 , 119 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 90 , 25 );
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // txtPerfChar
            // 
            this.txtPerfChar.AllowSelectedNullRow = false;
            this.txtPerfChar.DisplayField = "";
            this.txtPerfChar.Font = new System.Drawing.Font( "宋体" , 18F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtPerfChar.Location = new System.Drawing.Point( 50 , 64 );
            this.txtPerfChar.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtPerfChar.MaxLength = 3;
            this.txtPerfChar.MemberField = "";
            this.txtPerfChar.MemberValue = null;
            this.txtPerfChar.Name = "txtPerfChar";
            this.txtPerfChar.NextControl = null;
            this.txtPerfChar.NextControlByEnter = false;
            this.txtPerfChar.OffsetX = 0;
            this.txtPerfChar.OffsetY = 0;
            this.txtPerfChar.QueryFields = null;
            this.txtPerfChar.SelectedValue = null;
            this.txtPerfChar.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPerfChar.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtPerfChar.SelectionCardColumnHeaderHeight = 30;
            this.txtPerfChar.SelectionCardColumns = null;
            this.txtPerfChar.SelectionCardFont = null;
            this.txtPerfChar.SelectionCardHeight = 250;
            this.txtPerfChar.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtPerfChar.SelectionCardRowHeaderWidth = 35;
            this.txtPerfChar.SelectionCardRowHeight = 23;
            this.txtPerfChar.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtPerfChar.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtPerfChar.SelectionCardWidth = 250;
            this.txtPerfChar.ShowRowNumber = true;
            this.txtPerfChar.ShowSelectionCardAfterEnter = false;
            this.txtPerfChar.Size = new System.Drawing.Size( 47 , 35 );
            this.txtPerfChar.TabIndex = 4;
            this.txtPerfChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPerfChar.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // FrmInputRegInvoiceNo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size( 382 , 179 );
            this.Controls.Add( this.txtPerfChar );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnOK );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.txtInvoiceNo );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInputRegInvoiceNo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "挂号退号";
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private GWI.HIS.Windows.Controls.QueryTextBox txtInvoiceNo;
        private System.Windows.Forms.Label label1;
        private GWI.HIS.Windows.Controls.Button btnOK;
        private GWI.HIS.Windows.Controls.Button btnCancel;
        private GWI.HIS.Windows.Controls.QueryTextBox txtPerfChar;
    }
}