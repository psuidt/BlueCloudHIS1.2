namespace HIS_MZManager.Query
{
    partial class FrmPatientSelect
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmPatientSelect ) );
            this.dgvPatient = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.btnSelect = new GWI.HIS.Windows.Controls.Button();
            this.btnClose = new GWI.HIS.Windows.Controls.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PATLISTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISITNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATSEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUREDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PYM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvPatient ) ).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPatient
            // 
            this.dgvPatient.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvPatient.AllowSortWhenClickColumnHeader = false;
            this.dgvPatient.AllowUserToAddRows = false;
            this.dgvPatient.AllowUserToDeleteRows = false;
            this.dgvPatient.AllowUserToResizeRows = false;
            this.dgvPatient.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPatient.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.PATLISTID,
            this.VISITNO,
            this.PATID,
            this.PATNAME,
            this.PATSEX,
            this.CUREDATE,
            this.PYM,
            this.WBM} );
            this.dgvPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPatient.EnableHeadersVisualStyles = false;
            this.dgvPatient.Location = new System.Drawing.Point( 0, 0 );
            this.dgvPatient.MultiSelect = false;
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatient.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatient.RowTemplate.Height = 23;
            this.dgvPatient.SelectionCards = null;
            this.dgvPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatient.Size = new System.Drawing.Size( 557, 218 );
            this.dgvPatient.TabIndex = 0;
            this.dgvPatient.UseGradientBackgroundColor = true;
            this.dgvPatient.DoubleClick += new System.EventHandler( this.dgvPatient_DoubleClick );
            this.dgvPatient.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler( this.dgvPatient_PreviewKeyDown );
            // 
            // btnSelect
            // 
            this.btnSelect.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Ok;
            this.btnSelect.FixedWidth = true;
            this.btnSelect.Image = ( (System.Drawing.Image)( resources.GetObject( "btnSelect.Image" ) ) );
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point( 355, 224 );
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size( 90, 30 );
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "确定(&O)";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler( this.btnSelect_Click );
            // 
            // btnClose
            // 
            this.btnClose.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Cancel;
            this.btnClose.FixedWidth = true;
            this.btnClose.Image = ( (System.Drawing.Image)( resources.GetObject( "btnClose.Image" ) ) );
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point( 455, 224 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 90, 30 );
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "取消(&C)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 6, 229 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 65, 12 );
            this.label1.TabIndex = 3;
            this.label1.Text = "查询关键字";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point( 77, 224 );
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size( 103, 21 );
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler( this.textBox1_TextChanged );
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.textBox1_KeyPress );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point( 186, 229 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 125, 12 );
            this.label2.TabIndex = 5;
            this.label2.Text = "支持姓名拼音码五笔码";
            // 
            // PATLISTID
            // 
            this.PATLISTID.DataPropertyName = "PATLISTID";
            this.PATLISTID.HeaderText = "就诊登记号";
            this.PATLISTID.Name = "PATLISTID";
            this.PATLISTID.ReadOnly = true;
            this.PATLISTID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PATLISTID.Visible = false;
            this.PATLISTID.Width = 75;
            // 
            // VISITNO
            // 
            this.VISITNO.DataPropertyName = "VISITNO";
            this.VISITNO.HeaderText = "就诊号";
            this.VISITNO.Name = "VISITNO";
            this.VISITNO.ReadOnly = true;
            this.VISITNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PATID
            // 
            this.PATID.DataPropertyName = "PATID";
            this.PATID.HeaderText = "PATID";
            this.PATID.Name = "PATID";
            this.PATID.ReadOnly = true;
            this.PATID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PATID.Visible = false;
            // 
            // PATNAME
            // 
            this.PATNAME.DataPropertyName = "PATNAME";
            this.PATNAME.HeaderText = "姓名";
            this.PATNAME.Name = "PATNAME";
            this.PATNAME.ReadOnly = true;
            this.PATNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PATNAME.Width = 150;
            // 
            // PATSEX
            // 
            this.PATSEX.DataPropertyName = "PATSEX";
            this.PATSEX.HeaderText = "性别";
            this.PATSEX.Name = "PATSEX";
            this.PATSEX.ReadOnly = true;
            this.PATSEX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // PYM
            // 
            this.PYM.DataPropertyName = "PYM";
            this.PYM.HeaderText = "py";
            this.PYM.Name = "PYM";
            this.PYM.ReadOnly = true;
            this.PYM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PYM.Visible = false;
            // 
            // WBM
            // 
            this.WBM.DataPropertyName = "WBM";
            this.WBM.HeaderText = "wb";
            this.WBM.Name = "WBM";
            this.WBM.ReadOnly = true;
            this.WBM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WBM.Visible = false;
            // 
            // FrmPatientSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 557, 262 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.textBox1 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.btnSelect );
            this.Controls.Add( this.dgvPatient );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPatientSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择";
            this.Load += new System.EventHandler( this.FrmPatientSelect_Load );
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.FrmPatientSelect_KeyPress );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvPatient ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgvPatient;
        private GWI.HIS.Windows.Controls.Button btnSelect;
        private GWI.HIS.Windows.Controls.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATLISTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISITNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATSEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUREDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PYM;
        private System.Windows.Forms.DataGridViewTextBoxColumn WBM;
    }
}