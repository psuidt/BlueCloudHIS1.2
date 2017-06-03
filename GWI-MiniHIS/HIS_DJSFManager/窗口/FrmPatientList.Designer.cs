namespace HIS_DJSFManager.窗口
{
    partial class FrmPatientList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.dgvPatient = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.btnOk = new System.Windows.Forms.Button( );
            this.btnCancel = new System.Windows.Forms.Button( );
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.CUREDATE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PatListId = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvPatient ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // dgvPatient
            // 
            this.dgvPatient.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvPatient.AllowSortWhenClickColumnHeader = false;
            this.dgvPatient.AllowUserToAddRows = false;
            this.dgvPatient.AllowUserToDeleteRows = false;
            this.dgvPatient.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPatient.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientName,
            this.Sex,
            this.CUREDATE,
            this.PatListId} );
            this.dgvPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPatient.EnableHeadersVisualStyles = false;
            this.dgvPatient.Location = new System.Drawing.Point( 0 , 0 );
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle4.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatient.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPatient.RowTemplate.Height = 23;
            this.dgvPatient.SelectionCards = null;
            this.dgvPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatient.Size = new System.Drawing.Size( 477 , 244 );
            this.dgvPatient.TabIndex = 0;
            this.dgvPatient.UseGradientBackgroundColor = false;
            this.dgvPatient.DoubleClick += new System.EventHandler( this.dgvPatient_DoubleClick );
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point( 128 , 250 );
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size( 75 , 23 );
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "选择";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point( 271 , 250 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75 , 23 );
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "PatName";
            this.PatientName.HeaderText = "病人姓名";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            this.PatientName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "PatSex";
            this.Sex.HeaderText = "性别";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            this.Sex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CUREDATE
            // 
            this.CUREDATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CUREDATE.DataPropertyName = "CUREDATE";
            this.CUREDATE.HeaderText = "就诊日期";
            this.CUREDATE.Name = "CUREDATE";
            this.CUREDATE.ReadOnly = true;
            this.CUREDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PatListId
            // 
            this.PatListId.DataPropertyName = "PatListId";
            this.PatListId.HeaderText = "PatListId";
            this.PatListId.Name = "PatListId";
            this.PatListId.ReadOnly = true;
            this.PatListId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PatListId.Visible = false;
            // 
            // FrmPatientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 477 , 282 );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnOk );
            this.Controls.Add( this.dgvPatient );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPatientList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人选择";
            this.Load += new System.EventHandler( this.FrmPatientList_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvPatient ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgvPatient;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUREDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatListId;
    }
}