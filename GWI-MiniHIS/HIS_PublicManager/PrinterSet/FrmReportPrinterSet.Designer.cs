namespace HIS_PublicManager
{
    partial class FrmReportPrinterSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmReportPrinterSet ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.label1 = new System.Windows.Forms.Label( );
            this.btnSetAll = new System.Windows.Forms.Button( );
            this.btnCancel = new GWI.HIS.Windows.Controls.Button( );
            this.button1 = new GWI.HIS.Windows.Controls.Button( );
            this.dgvReport = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.ReportFullName = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PrinterName = new System.Windows.Forms.DataGridViewComboBoxColumn( );
            this.panel3 = new System.Windows.Forms.Panel( );
            this.label2 = new System.Windows.Forms.Label( );
            this.panel2.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvReport ) ).BeginInit( );
            this.panel3.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 893 , 40 );
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add( this.label2 );
            this.panel2.Controls.Add( this.label1 );
            this.panel2.Controls.Add( this.btnSetAll );
            this.panel2.Controls.Add( this.btnCancel );
            this.panel2.Controls.Add( this.button1 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point( 0 , 369 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 893 , 110 );
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point( 0 , 0 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 697 , 110 );
            this.label1.TabIndex = 5;
            this.label1.Text = resources.GetString( "label1.Text" );
            // 
            // btnSetAll
            // 
            this.btnSetAll.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnSetAll.Location = new System.Drawing.Point( 704 , 6 );
            this.btnSetAll.Name = "btnSetAll";
            this.btnSetAll.Size = new System.Drawing.Size( 186 , 23 );
            this.btnSetAll.TabIndex = 4;
            this.btnSetAll.Text = "使用当前行设置所有";
            this.btnSetAll.UseVisualStyleBackColor = true;
            this.btnSetAll.Click += new System.EventHandler( this.btnSetAll_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnCancel.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Cancel;
            this.btnCancel.FixedWidth = true;
            this.btnCancel.Image = ( (System.Drawing.Image)( resources.GetObject( "btnCancel.Image" ) ) );
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point( 800 , 53 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 90 , 25 );
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // button1
            // 
            this.button1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.button1.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Save;
            this.button1.FixedWidth = true;
            this.button1.Image = ( (System.Drawing.Image)( resources.GetObject( "button1.Image" ) ) );
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point( 704 , 53 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 90 , 25 );
            this.button1.TabIndex = 2;
            this.button1.Text = "保存(&S)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // dgvReport
            // 
            this.dgvReport.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvReport.AllowSortWhenClickColumnHeader = false;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReport.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.ReportFullName,
            this.PrinterName} );
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.Location = new System.Drawing.Point( 0 , 0 );
            this.dgvReport.Name = "dgvReport";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle4.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReport.RowTemplate.Height = 23;
            this.dgvReport.SelectionCards = null;
            this.dgvReport.Size = new System.Drawing.Size( 893 , 329 );
            this.dgvReport.TabIndex = 0;
            this.dgvReport.UseGradientBackgroundColor = false;
            this.dgvReport.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler( this.dgvReport_DataError );
            // 
            // ReportFullName
            // 
            this.ReportFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReportFullName.HeaderText = "报表名";
            this.ReportFullName.Name = "ReportFullName";
            this.ReportFullName.ReadOnly = true;
            this.ReportFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PrinterName
            // 
            this.PrinterName.HeaderText = "打印机";
            this.PrinterName.Name = "PrinterName";
            this.PrinterName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PrinterName.Width = 300;
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.dgvReport );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point( 0 , 40 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 893 , 329 );
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point( 3 , 89 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 305 , 12 );
            this.label2.TabIndex = 6;
            this.label2.Text = "注意：该配置不适用于所有终端，请不要上传该配置文件";
            // 
            // FrmReportPrinterSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 893 , 479 );
            this.Controls.Add( this.panel3 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.panel1 );
            this.Name = "FrmReportPrinterSet";
            this.Text = "报表打印机设置";
            this.Load += new System.EventHandler( this.FrmReportPrinterSet_Load );
            this.panel2.ResumeLayout( false );
            this.panel2.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvReport ) ).EndInit( );
            this.panel3.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvReport;
        private GWI.HIS.Windows.Controls.Button button1;
        private GWI.HIS.Windows.Controls.Button btnCancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSetAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportFullName;
        private System.Windows.Forms.DataGridViewComboBoxColumn PrinterName;
        private System.Windows.Forms.Label label2;
    }
}