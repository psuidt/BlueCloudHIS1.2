namespace HIS_BaseManager.基本数据维护
{
    partial class FrmSetLocation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkTabIndex = new System.Windows.Forms.CheckBox();
            this.btnSameVInterval = new System.Windows.Forms.Button();
            this.btnSameHInterval = new System.Windows.Forms.Button();
            this.btnSameSize = new System.Windows.Forms.Button();
            this.btnToTop = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.txtLocationX = new System.Windows.Forms.NumericUpDown();
            this.txtLocationY = new System.Windows.Forms.NumericUpDown();
            this.txtHeight = new System.Windows.Forms.NumericUpDown();
            this.txtWidth = new System.Windows.Forms.NumericUpDown();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.plControls = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvColumn = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.txtLocationX ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.txtLocationY ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.txtHeight ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.txtWidth ) ).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvColumn ) ).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add( this.chkTabIndex );
            this.panel1.Controls.Add( this.btnSameVInterval );
            this.panel1.Controls.Add( this.btnSameHInterval );
            this.panel1.Controls.Add( this.btnSameSize );
            this.panel1.Controls.Add( this.btnToTop );
            this.panel1.Controls.Add( this.btnToLeft );
            this.panel1.Controls.Add( this.txtLocationX );
            this.panel1.Controls.Add( this.txtLocationY );
            this.panel1.Controls.Add( this.txtHeight );
            this.panel1.Controls.Add( this.txtWidth );
            this.panel1.Controls.Add( this.lblLocation );
            this.panel1.Controls.Add( this.label1 );
            this.panel1.Controls.Add( this.btnOk );
            this.panel1.Controls.Add( this.btnCancel );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point( 0, 430 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 796, 72 );
            this.panel1.TabIndex = 1;
            // 
            // chkTabIndex
            // 
            this.chkTabIndex.AutoSize = true;
            this.chkTabIndex.Location = new System.Drawing.Point( 418, 10 );
            this.chkTabIndex.Name = "chkTabIndex";
            this.chkTabIndex.Size = new System.Drawing.Size( 96, 16 );
            this.chkTabIndex.TabIndex = 21;
            this.chkTabIndex.Text = "编辑TabIndex";
            this.chkTabIndex.UseVisualStyleBackColor = true;
            this.chkTabIndex.CheckedChanged += new System.EventHandler( this.chkTabIndex_CheckedChanged );
            // 
            // btnSameVInterval
            // 
            this.btnSameVInterval.Location = new System.Drawing.Point( 392, 36 );
            this.btnSameVInterval.Name = "btnSameVInterval";
            this.btnSameVInterval.Size = new System.Drawing.Size( 95, 23 );
            this.btnSameVInterval.TabIndex = 20;
            this.btnSameVInterval.Text = "相同水平间隔";
            this.btnSameVInterval.UseVisualStyleBackColor = true;
            this.btnSameVInterval.Click += new System.EventHandler( this.btnSameVInterval_Click );
            // 
            // btnSameHInterval
            // 
            this.btnSameHInterval.Location = new System.Drawing.Point( 297, 36 );
            this.btnSameHInterval.Name = "btnSameHInterval";
            this.btnSameHInterval.Size = new System.Drawing.Size( 95, 23 );
            this.btnSameHInterval.TabIndex = 19;
            this.btnSameHInterval.Text = "相同垂直间隔";
            this.btnSameHInterval.UseVisualStyleBackColor = true;
            this.btnSameHInterval.Click += new System.EventHandler( this.btnSameHInterval_Click );
            // 
            // btnSameSize
            // 
            this.btnSameSize.Location = new System.Drawing.Point( 202, 36 );
            this.btnSameSize.Name = "btnSameSize";
            this.btnSameSize.Size = new System.Drawing.Size( 95, 23 );
            this.btnSameSize.TabIndex = 18;
            this.btnSameSize.Text = "相同大小";
            this.btnSameSize.UseVisualStyleBackColor = true;
            this.btnSameSize.Click += new System.EventHandler( this.btnSameSize_Click );
            // 
            // btnToTop
            // 
            this.btnToTop.Location = new System.Drawing.Point( 107, 36 );
            this.btnToTop.Name = "btnToTop";
            this.btnToTop.Size = new System.Drawing.Size( 95, 23 );
            this.btnToTop.TabIndex = 17;
            this.btnToTop.Text = "顶对齐";
            this.btnToTop.UseVisualStyleBackColor = true;
            this.btnToTop.Click += new System.EventHandler( this.btnToTop_Click );
            // 
            // btnToLeft
            // 
            this.btnToLeft.Location = new System.Drawing.Point( 12, 36 );
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size( 95, 23 );
            this.btnToLeft.TabIndex = 16;
            this.btnToLeft.Text = "左对齐";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler( this.btnToLeft_Click );
            // 
            // txtLocationX
            // 
            this.txtLocationX.Location = new System.Drawing.Point( 50, 9 );
            this.txtLocationX.Maximum = new decimal( new int[] {
            65535,
            0,
            0,
            0} );
            this.txtLocationX.Name = "txtLocationX";
            this.txtLocationX.Size = new System.Drawing.Size( 62, 21 );
            this.txtLocationX.TabIndex = 15;
            this.txtLocationX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLocationY
            // 
            this.txtLocationY.Location = new System.Drawing.Point( 137, 9 );
            this.txtLocationY.Maximum = new decimal( new int[] {
            65535,
            0,
            0,
            0} );
            this.txtLocationY.Name = "txtLocationY";
            this.txtLocationY.Size = new System.Drawing.Size( 56, 21 );
            this.txtLocationY.TabIndex = 14;
            this.txtLocationY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point( 360, 9 );
            this.txtHeight.Maximum = new decimal( new int[] {
            65535,
            0,
            0,
            0} );
            this.txtHeight.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size( 52, 21 );
            this.txtHeight.TabIndex = 11;
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHeight.Value = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point( 280, 9 );
            this.txtWidth.Maximum = new decimal( new int[] {
            65535,
            0,
            0,
            0} );
            this.txtWidth.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size( 52, 21 );
            this.txtWidth.TabIndex = 10;
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWidth.Value = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point( 12, 13 );
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size( 119, 12 );
            this.lblLocation.TabIndex = 9;
            this.lblLocation.Text = "位置X             Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 213, 13 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 215, 12 );
            this.label1.TabIndex = 5;
            this.label1.Text = "大小: 宽度          高度           ";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnOk.Location = new System.Drawing.Point( 628, 36 );
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size( 75, 23 );
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定(&Y)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnCancel.Location = new System.Drawing.Point( 709, 36 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // plControls
            // 
            this.plControls.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.plControls.BackColor = System.Drawing.Color.White;
            this.plControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plControls.Location = new System.Drawing.Point( 6, 6 );
            this.plControls.Name = "plControls";
            this.plControls.Size = new System.Drawing.Size( 783, 323 );
            this.plControls.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add( this.panel5 );
            this.panel2.Controls.Add( this.panel4 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point( 0, 337 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 796, 93 );
            this.panel2.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add( this.dgvColumn );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point( 0, 17 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 796, 76 );
            this.panel5.TabIndex = 2;
            // 
            // dgvColumn
            // 
            this.dgvColumn.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvColumn.AllowSortWhenClickColumnHeader = false;
            this.dgvColumn.AllowUserToAddRows = false;
            this.dgvColumn.AllowUserToDeleteRows = false;
            this.dgvColumn.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColumn.ColumnHeadersHeight = 40;
            this.dgvColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumn.EnableHeadersVisualStyles = false;
            this.dgvColumn.HideSelectionCardWhenCustomInput = false;
            this.dgvColumn.Location = new System.Drawing.Point( 0, 0 );
            this.dgvColumn.Name = "dgvColumn";
            this.dgvColumn.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumn.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvColumn.RowTemplate.Height = 23;
            this.dgvColumn.SelectionCards = null;
            this.dgvColumn.Size = new System.Drawing.Size( 796, 76 );
            this.dgvColumn.TabIndex = 0;
            this.dgvColumn.UseGradientBackgroundColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add( this.label2 );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point( 0, 0 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 796, 17 );
            this.panel4.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 3, 3 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 89, 12 );
            this.label2.TabIndex = 0;
            this.label2.Text = "网格列宽度调整";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add( this.plControls );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point( 0, 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 796, 337 );
            this.panel3.TabIndex = 4;
            // 
            // FrmSetLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 796, 502 );
            this.Controls.Add( this.panel3 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.panel1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetLocation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "字段位置编辑";
            this.Load += new System.EventHandler( this.FrmSetLocation_Load );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.txtLocationX ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.txtLocationY ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.txtHeight ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.txtWidth ) ).EndInit();
            this.panel2.ResumeLayout( false );
            this.panel5.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvColumn ) ).EndInit();
            this.panel4.ResumeLayout( false );
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plControls;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.NumericUpDown txtHeight;
        private System.Windows.Forms.NumericUpDown txtWidth;
        private System.Windows.Forms.NumericUpDown txtLocationX;
        private System.Windows.Forms.NumericUpDown txtLocationY;
        private System.Windows.Forms.Panel panel2;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvColumn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSameSize;
        private System.Windows.Forms.Button btnToTop;
        private System.Windows.Forms.Button btnToLeft;
        private System.Windows.Forms.Button btnSameVInterval;
        private System.Windows.Forms.Button btnSameHInterval;
        private System.Windows.Forms.CheckBox chkTabIndex;

    }
}