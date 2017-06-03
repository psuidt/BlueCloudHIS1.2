namespace HIS_DJSFManager.窗口
{
    partial class FrmViewInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.dgvList = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.MediType = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Total_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Cash_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.POS_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Insur_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Self_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Favor_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Cost_Date = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Record_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.label1 = new System.Windows.Forms.Label( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvList ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // dgvList
            // 
            this.dgvList.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvList.AllowSortWhenClickColumnHeader = true;
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle17.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvList.ColumnHeadersHeight = 30;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.MediType,
            this.InvoiceNo,
            this.Total_Fee,
            this.Cash_Fee,
            this.POS_Fee,
            this.Insur_Fee,
            this.Self_Fee,
            this.Favor_Fee,
            this.Cost_Date,
            this.Record_Flag} );
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point( 0 , 0 );
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle24.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionCards = null;
            this.dgvList.Size = new System.Drawing.Size( 847 , 331 );
            this.dgvList.TabIndex = 0;
            this.dgvList.UseGradientBackgroundColor = false;
            // 
            // MediType
            // 
            this.MediType.HeaderText = "病人类型";
            this.MediType.Name = "MediType";
            this.MediType.ReadOnly = true;
            this.MediType.Width = 80;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.HeaderText = "发票号";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            this.InvoiceNo.Width = 65;
            // 
            // Total_Fee
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Total_Fee.DefaultCellStyle = dataGridViewCellStyle18;
            this.Total_Fee.HeaderText = "发票金额";
            this.Total_Fee.Name = "Total_Fee";
            this.Total_Fee.ReadOnly = true;
            this.Total_Fee.Width = 80;
            // 
            // Cash_Fee
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cash_Fee.DefaultCellStyle = dataGridViewCellStyle19;
            this.Cash_Fee.HeaderText = "现金支付";
            this.Cash_Fee.Name = "Cash_Fee";
            this.Cash_Fee.ReadOnly = true;
            this.Cash_Fee.Width = 80;
            // 
            // POS_Fee
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.POS_Fee.DefaultCellStyle = dataGridViewCellStyle20;
            this.POS_Fee.HeaderText = "POS支付";
            this.POS_Fee.Name = "POS_Fee";
            this.POS_Fee.ReadOnly = true;
            this.POS_Fee.Width = 75;
            // 
            // Insur_Fee
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Insur_Fee.DefaultCellStyle = dataGridViewCellStyle21;
            this.Insur_Fee.HeaderText = "医保农合记账";
            this.Insur_Fee.Name = "Insur_Fee";
            this.Insur_Fee.ReadOnly = true;
            this.Insur_Fee.Width = 105;
            // 
            // Self_Fee
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Self_Fee.DefaultCellStyle = dataGridViewCellStyle22;
            this.Self_Fee.HeaderText = "单位记账";
            this.Self_Fee.Name = "Self_Fee";
            this.Self_Fee.ReadOnly = true;
            this.Self_Fee.Width = 80;
            // 
            // Favor_Fee
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Favor_Fee.DefaultCellStyle = dataGridViewCellStyle23;
            this.Favor_Fee.HeaderText = "优惠金额";
            this.Favor_Fee.Name = "Favor_Fee";
            this.Favor_Fee.ReadOnly = true;
            this.Favor_Fee.Width = 80;
            // 
            // Cost_Date
            // 
            this.Cost_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cost_Date.HeaderText = "收费日期";
            this.Cost_Date.Name = "Cost_Date";
            this.Cost_Date.ReadOnly = true;
            // 
            // Record_Flag
            // 
            this.Record_Flag.HeaderText = "已退费";
            this.Record_Flag.Name = "Record_Flag";
            this.Record_Flag.ReadOnly = true;
            this.Record_Flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Record_Flag.Width = 35;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 760 , 337 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75 , 23 );
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point( 12 , 342 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 245 , 12 );
            this.label1.TabIndex = 2;
            this.label1.Text = "注：红色标记的为退费发票，不算在合计中。";
            // 
            // FrmViewInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 847 , 368 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.dgvList );
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmViewInvoice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发票查看";
            this.Load += new System.EventHandler( this.FrmViewInvoice_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvList ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgvList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MediType;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cash_Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS_Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Insur_Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Self_Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Favor_Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost_Date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Record_Flag;
        private System.Windows.Forms.Label label1;
    }
}