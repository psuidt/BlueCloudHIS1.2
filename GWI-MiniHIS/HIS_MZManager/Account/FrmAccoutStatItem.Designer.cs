namespace HIS_MZManager.Account
{
    partial class FrmAccoutStatItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.dgvStatItem = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.button1 = new System.Windows.Forms.Button( );
            this.btnExit = new System.Windows.Forms.Button( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvStatItem ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // dgvStatItem
            // 
            this.dgvStatItem.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvStatItem.AllowSortWhenClickColumnHeader = false;
            this.dgvStatItem.AllowUserToAddRows = false;
            this.dgvStatItem.AllowUserToDeleteRows = false;
            this.dgvStatItem.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.dgvStatItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle5.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStatItem.ColumnHeadersHeight = 30;
            this.dgvStatItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStatItem.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvStatItem.EnableHeadersVisualStyles = false;
            this.dgvStatItem.HideSelectionCardWhenCustomInput = false;
            this.dgvStatItem.Location = new System.Drawing.Point( 2 , 2 );
            this.dgvStatItem.Name = "dgvStatItem";
            this.dgvStatItem.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle6.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStatItem.RowTemplate.Height = 23;
            this.dgvStatItem.SelectionCards = null;
            this.dgvStatItem.Size = new System.Drawing.Size( 757 , 433 );
            this.dgvStatItem.TabIndex = 0;
            this.dgvStatItem.UseGradientBackgroundColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point( 311 , 441 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 75 , 23 );
            this.button1.TabIndex = 1;
            this.button1.Text = "打印";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.Location = new System.Drawing.Point( 392 , 441 );
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size( 75 , 23 );
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler( this.btnExit_Click );
            // 
            // FrmAccoutStatItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 761 , 473 );
            this.Controls.Add( this.btnExit );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.dgvStatItem );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAccoutStatItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "统计分类明细";
            this.Load += new System.EventHandler( this.FrmAccoutStatItem_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvStatItem ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgvStatItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExit;
    }
}