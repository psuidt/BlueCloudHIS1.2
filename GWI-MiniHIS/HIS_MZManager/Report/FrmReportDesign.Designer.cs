namespace HIS_MZManager.Report
{
    partial class FrmReportDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmReportDesign ) );
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.axGRDesigner1 = new AxgrdesLib.AxGRDesigner();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.axGRDesigner1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add( this.lblInfo );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 703, 30 );
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.axGRDesigner1 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0, 30 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 703, 475 );
            this.panel2.TabIndex = 4;
            // 
            // axGRDesigner1
            // 
            this.axGRDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axGRDesigner1.Enabled = true;
            this.axGRDesigner1.Location = new System.Drawing.Point( 0, 0 );
            this.axGRDesigner1.Name = "axGRDesigner1";
            this.axGRDesigner1.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axGRDesigner1.OcxState" ) ) );
            this.axGRDesigner1.Size = new System.Drawing.Size( 703, 475 );
            this.axGRDesigner1.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font( "宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            this.lblInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo.Location = new System.Drawing.Point( 10, 7 );
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size( 55, 14 );
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "label1";
            // 
            // FrmReportDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 703, 505 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.panel1 );
            this.Name = "FrmReportDesign";
            this.Text = "FrmReportDesign";
            this.Load += new System.EventHandler( this.FrmReportDesign_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.FrmReportDesign_FormClosing );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.axGRDesigner1 ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private AxgrdesLib.AxGRDesigner axGRDesigner1;
        private System.Windows.Forms.Label lblInfo;

    }
}