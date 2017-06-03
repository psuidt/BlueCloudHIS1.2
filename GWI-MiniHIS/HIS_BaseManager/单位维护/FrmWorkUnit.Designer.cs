namespace HIS_BaseManager 
{
    partial class FrmWorkUnit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmWorkUnit ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.dgvWorkUnit = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.WB_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.label1 = new System.Windows.Forms.Label( );
            this.txtName = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.txtPym = new System.Windows.Forms.TextBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.txtWbm = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.txtCode = new GWI.HIS.Windows.Controls.QueryTextBox( );
            this.btnSave = new System.Windows.Forms.Button( );
            this.btnAdd = new System.Windows.Forms.Button( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.plBaseToolbar.SuspendLayout( );
            this.plBaseWorkArea.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvWorkUnit ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add( this.btnClose );
            this.plBaseToolbar.Controls.Add( this.btnAdd );
            this.plBaseToolbar.Controls.Add( this.btnSave );
            this.plBaseToolbar.Controls.Add( this.txtCode );
            this.plBaseToolbar.Controls.Add( this.txtWbm );
            this.plBaseToolbar.Controls.Add( this.label4 );
            this.plBaseToolbar.Controls.Add( this.txtPym );
            this.plBaseToolbar.Controls.Add( this.label3 );
            this.plBaseToolbar.Controls.Add( this.txtName );
            this.plBaseToolbar.Controls.Add( this.label2 );
            this.plBaseToolbar.Controls.Add( this.label1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 838 , 44 );
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "baseImageList.ImageStream" ) ) );
            this.baseImageList.Images.SetKeyName( 0 , "table_delete.gif" );
            this.baseImageList.Images.SetKeyName( 1 , "search_big.GIF" );
            this.baseImageList.Images.SetKeyName( 2 , "Save.GIF" );
            this.baseImageList.Images.SetKeyName( 3 , "Print.GIF" );
            this.baseImageList.Images.SetKeyName( 4 , "page_user_dark.gif" );
            this.baseImageList.Images.SetKeyName( 5 , "page_refresh.gif" );
            this.baseImageList.Images.SetKeyName( 6 , "page_key.gif" );
            this.baseImageList.Images.SetKeyName( 7 , "page_edit.gif" );
            this.baseImageList.Images.SetKeyName( 8 , "page_cross.gif" );
            this.baseImageList.Images.SetKeyName( 9 , "list_users.gif" );
            this.baseImageList.Images.SetKeyName( 10 , "icon_package_get.gif" );
            this.baseImageList.Images.SetKeyName( 11 , "icon_network.gif" );
            this.baseImageList.Images.SetKeyName( 12 , "icon_history.gif" );
            this.baseImageList.Images.SetKeyName( 13 , "icon_accept.gif" );
            this.baseImageList.Images.SetKeyName( 14 , "folder_page.gif" );
            this.baseImageList.Images.SetKeyName( 15 , "folder_new.gif" );
            this.baseImageList.Images.SetKeyName( 16 , "Exit.GIF" );
            this.baseImageList.Images.SetKeyName( 17 , "Delete.GIF" );
            this.baseImageList.Images.SetKeyName( 18 , "copy.gif" );
            this.baseImageList.Images.SetKeyName( 19 , "action_stop.gif" );
            this.baseImageList.Images.SetKeyName( 20 , "action_refresh.gif" );
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point( 0 , 409 );
            this.plBaseStatus.Size = new System.Drawing.Size( 838 , 10 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.dgvWorkUnit );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0 , 78 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 838 , 331 );
            // 
            // dgvWorkUnit
            // 
            this.dgvWorkUnit.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvWorkUnit.AllowSortWhenClickColumnHeader = false;
            this.dgvWorkUnit.AllowUserToAddRows = false;
            this.dgvWorkUnit.AllowUserToDeleteRows = false;
            this.dgvWorkUnit.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkUnit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWorkUnit.ColumnHeadersHeight = 30;
            this.dgvWorkUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvWorkUnit.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.CODE,
            this.NAME,
            this.PY_CODE,
            this.WB_CODE} );
            this.dgvWorkUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkUnit.EnableHeadersVisualStyles = false;
            this.dgvWorkUnit.Location = new System.Drawing.Point( 0 , 0 );
            this.dgvWorkUnit.MultiSelect = false;
            this.dgvWorkUnit.Name = "dgvWorkUnit";
            this.dgvWorkUnit.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle4.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkUnit.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvWorkUnit.RowTemplate.Height = 23;
            this.dgvWorkUnit.SelectionCards = null;
            this.dgvWorkUnit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorkUnit.Size = new System.Drawing.Size( 838 , 331 );
            this.dgvWorkUnit.TabIndex = 0;
            this.dgvWorkUnit.UseGradientBackgroundColor = false;
            this.dgvWorkUnit.CurrentCellChanged += new System.EventHandler( this.dgvWorkUnit_CurrentCellChanged );
            // 
            // CODE
            // 
            this.CODE.DataPropertyName = "CODE";
            this.CODE.HeaderText = "单位代码";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            this.CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NAME
            // 
            this.NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "单位名称";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PY_CODE
            // 
            this.PY_CODE.DataPropertyName = "PY_CODE";
            this.PY_CODE.HeaderText = "拼音码";
            this.PY_CODE.Name = "PY_CODE";
            this.PY_CODE.ReadOnly = true;
            this.PY_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY_CODE.Width = 200;
            // 
            // WB_CODE
            // 
            this.WB_CODE.DataPropertyName = "WB_CODE";
            this.WB_CODE.HeaderText = "五笔码";
            this.WB_CODE.Name = "WB_CODE";
            this.WB_CODE.ReadOnly = true;
            this.WB_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WB_CODE.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 11 , 15 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 53 , 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "单位代码";
            // 
            // txtName
            // 
            this.txtName.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtName.Location = new System.Drawing.Point( 183 , 12 );
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size( 60 , 21 );
            this.txtName.TabIndex = 3;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtName_KeyPress );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 124 , 15 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53 , 12 );
            this.label2.TabIndex = 2;
            this.label2.Text = "单位名称";
            // 
            // txtPym
            // 
            this.txtPym.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtPym.Location = new System.Drawing.Point( 296 , 12 );
            this.txtPym.Name = "txtPym";
            this.txtPym.Size = new System.Drawing.Size( 117 , 21 );
            this.txtPym.TabIndex = 5;
            this.txtPym.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtPym_KeyPress );
            // 
            // label3
            // 
            this.label3.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 249 , 15 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 41 , 12 );
            this.label3.TabIndex = 4;
            this.label3.Text = "拼音码";
            // 
            // txtWbm
            // 
            this.txtWbm.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtWbm.Location = new System.Drawing.Point( 466 , 12 );
            this.txtWbm.Name = "txtWbm";
            this.txtWbm.Size = new System.Drawing.Size( 117 , 21 );
            this.txtWbm.TabIndex = 7;
            this.txtWbm.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtWbm_KeyPress );
            // 
            // label4
            // 
            this.label4.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 419 , 15 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 41 , 12 );
            this.label4.TabIndex = 6;
            this.label4.Text = "五笔码";
            // 
            // txtCode
            // 
            this.txtCode.AllowSelectedNullRow = false;
            this.txtCode.DisplayField = "";
            this.txtCode.Location = new System.Drawing.Point( 70 , 12 );
            this.txtCode.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtCode.MaxLength = 4;
            this.txtCode.MemberField = "";
            this.txtCode.MemberValue = null;
            this.txtCode.Name = "txtCode";
            this.txtCode.NextControl = null;
            this.txtCode.NextControlByEnter = false;
            this.txtCode.OffsetX = 0;
            this.txtCode.OffsetY = 0;
            this.txtCode.QueryFields = null;
            this.txtCode.SelectedValue = null;
            this.txtCode.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCode.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtCode.SelectionCardColumnHeaderHeight = 30;
            this.txtCode.SelectionCardColumns = null;
            this.txtCode.SelectionCardFont = null;
            this.txtCode.SelectionCardHeight = 250;
            this.txtCode.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtCode.SelectionCardRowHeaderWidth = 35;
            this.txtCode.SelectionCardRowHeight = 23;
            this.txtCode.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtCode.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtCode.SelectionCardWidth = 250;
            this.txtCode.ShowRowNumber = true;
            this.txtCode.ShowSelectionCardAfterEnter = false;
            this.txtCode.Size = new System.Drawing.Size( 48 , 21 );
            this.txtCode.TabIndex = 8;
            this.txtCode.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtCode_KeyPress );
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnSave.Location = new System.Drawing.Point( 671 , 10 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 75 , 23 );
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnAdd.Location = new System.Drawing.Point( 590 , 10 );
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 75 , 23 );
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnClose.Location = new System.Drawing.Point( 752 , 10 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75 , 23 );
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // FrmWorkUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 838 , 419 );
            this.Name = "FrmWorkUnit";
            this.Text = "FrmWorkUnit";
            this.Load += new System.EventHandler( this.FrmWorkUnit_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout( );
            this.plBaseWorkArea.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvWorkUnit ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.TextBox txtWbm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPym;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvWorkUnit;
        private GWI.HIS.Windows.Controls.QueryTextBox txtCode;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WB_CODE;
    }
}