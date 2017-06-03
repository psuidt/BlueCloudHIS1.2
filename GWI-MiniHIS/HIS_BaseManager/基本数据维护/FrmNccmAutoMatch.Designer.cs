namespace HIS_BaseManager
{
    partial class FrmNccmAutoMatch
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
            this.dgvList = new GWMHIS.PublicControls.DataGridViewEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvList ) ).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowClickColumnHeaderForSort = true;
            this.dgvList.AllowJumpWhenCellEmpty = false;
            this.dgvList.AllowSelectedByNumerKey = false;
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.ColumnHeadersHeight = 25;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditColumnBackColor = System.Drawing.Color.White;
            this.dgvList.JumpColumns = null;
            this.dgvList.Location = new System.Drawing.Point( 0, 0 );
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectCardFilterType = GWMHIS.PublicControls.FilterType.模糊查询;
            this.dgvList.SelectCardInfos = null;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.ShowRowNumber = true;
            this.dgvList.ShowSelectedCardRowNumber = false;
            this.dgvList.Size = new System.Drawing.Size( 946, 428 );
            this.dgvList.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.chkAll );
            this.panel1.Controls.Add( this.btnCancel );
            this.panel1.Controls.Add( this.btnOK );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point( 0, 475 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 946, 40 );
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.panel4 );
            this.panel2.Controls.Add( this.panel3 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0, 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 946, 475 );
            this.panel2.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnOK.Font = new System.Drawing.Font( "宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            this.btnOK.Location = new System.Drawing.Point( 760, 6 );
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size( 83, 26 );
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确认匹配";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnCancel.Font = new System.Drawing.Font( "宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            this.btnCancel.Location = new System.Drawing.Point( 855, 6 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 83, 26 );
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font( "宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            this.chkAll.Location = new System.Drawing.Point( 12, 10 );
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size( 54, 18 );
            this.chkAll.TabIndex = 3;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler( this.chkAll_CheckedChanged );
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.label1 );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point( 0, 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 946, 47 );
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.dgvList );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point( 0, 47 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 946, 428 );
            this.panel4.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point( 3, 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 545, 24 );
            this.label1.TabIndex = 0;
            this.label1.Text = "系统已自动按名称自动完成了匹配对应，但由于是模糊匹配，你需要在对应关系中指定一个对应关系。\r\n注意：医院的同一种药品或项目只能对应到农合的一个目录下";
            // 
            // FrmNccmAutoMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 946, 515 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.panel1 );
            this.Name = "FrmNccmAutoMatch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动匹配结果";
            this.Load += new System.EventHandler( this.FrmNccmAutoMatch_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvList ) ).EndInit();
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout( false );
            this.panel3.ResumeLayout( false );
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private GWMHIS.PublicControls.DataGridViewEx dgvList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
    }
}