namespace HIS_MZManager.Account
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvList = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MediType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cash_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POS_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Insur_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Self_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Favor_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Record_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvList ) ).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvList.AllowSortWhenClickColumnHeader = true;
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.dgvList.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.HideSelectionCardWhenCustomInput = false;
            this.dgvList.Location = new System.Drawing.Point( 0, 0 );
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle8.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionCards = null;
            this.dgvList.Size = new System.Drawing.Size( 847, 331 );
            this.dgvList.TabIndex = 0;
            this.dgvList.UseGradientBackgroundColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 760, 337 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 23 );
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
            this.label1.Location = new System.Drawing.Point( 12, 342 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 245, 12 );
            this.label1.TabIndex = 2;
            this.label1.Text = "注：红色标记的为退费发票，不算在合计中。";
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Total_Fee.DefaultCellStyle = dataGridViewCellStyle2;
            this.Total_Fee.HeaderText = "发票金额";
            this.Total_Fee.Name = "Total_Fee";
            this.Total_Fee.ReadOnly = true;
            this.Total_Fee.Width = 80;
            // 
            // Cash_Fee
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cash_Fee.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cash_Fee.HeaderText = "现金支付";
            this.Cash_Fee.Name = "Cash_Fee";
            this.Cash_Fee.ReadOnly = true;
            this.Cash_Fee.Width = 80;
            // 
            // POS_Fee
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.POS_Fee.DefaultCellStyle = dataGridViewCellStyle4;
            this.POS_Fee.HeaderText = "POS支付";
            this.POS_Fee.Name = "POS_Fee";
            this.POS_Fee.ReadOnly = true;
            this.POS_Fee.Width = 75;
            // 
            // Insur_Fee
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Insur_Fee.DefaultCellStyle = dataGridViewCellStyle5;
            this.Insur_Fee.HeaderText = "医保记账";
            this.Insur_Fee.Name = "Insur_Fee";
            this.Insur_Fee.ReadOnly = true;
            this.Insur_Fee.Width = 105;
            // 
            // Self_Fee
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Self_Fee.DefaultCellStyle = dataGridViewCellStyle6;
            this.Self_Fee.HeaderText = "单位记账";
            this.Self_Fee.Name = "Self_Fee";
            this.Self_Fee.ReadOnly = true;
            this.Self_Fee.Width = 80;
            // 
            // Favor_Fee
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Favor_Fee.DefaultCellStyle = dataGridViewCellStyle7;
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
            // FrmViewInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 847, 368 );
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
            ( (System.ComponentModel.ISupportInitialize)( this.dgvList ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgvList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
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
    }
}