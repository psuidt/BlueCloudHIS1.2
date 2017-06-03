namespace HIS_MZManager
{
    partial class FrmDownLoad
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
            this.lvwMsg = new System.Windows.Forms.ListView( );
            this.btnDownLoad = new System.Windows.Forms.Button( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader( );
            this.SuspendLayout( );
            // 
            // lvwMsg
            // 
            this.lvwMsg.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1} );
            this.lvwMsg.Location = new System.Drawing.Point( 0 , 0 );
            this.lvwMsg.Name = "lvwMsg";
            this.lvwMsg.Size = new System.Drawing.Size( 509 , 142 );
            this.lvwMsg.TabIndex = 0;
            this.lvwMsg.UseCompatibleStateImageBehavior = false;
            this.lvwMsg.View = System.Windows.Forms.View.Details;
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point( 324 , 148 );
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size( 78 , 27 );
            this.btnDownLoad.TabIndex = 1;
            this.btnDownLoad.Text = "下载";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler( this.btnDownLoad_Click );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 420 , 148 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 78 , 27 );
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "消息";
            this.columnHeader1.Width = 440;
            // 
            // FrmDownLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 510 , 182 );
            this.ControlBox = false;
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.btnDownLoad );
            this.Controls.Add( this.lvwMsg );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDownLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据下载";
            this.Load += new System.EventHandler( this.FrmDownLoad_Load );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ListView lvwMsg;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}