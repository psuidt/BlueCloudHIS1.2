namespace HIS_BaseManager
{
    partial class FrmSelectServiceItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.dgvServiceItem = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.ITEM_ID = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.ITEM_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.WB_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.dgvSelected = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this._ITEM_ID = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this._ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.btnOK = new System.Windows.Forms.Button( );
            this.btnCancel = new System.Windows.Forms.Button( );
            this.btnAdd = new System.Windows.Forms.Button( );
            this.btnRemove = new System.Windows.Forms.Button( );
            this.txtSearch = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.btnRemoveAll = new System.Windows.Forms.Button( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvServiceItem ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvSelected ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // dgvServiceItem
            // 
            this.dgvServiceItem.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvServiceItem.AllowSortWhenClickColumnHeader = false;
            this.dgvServiceItem.AllowUserToAddRows = false;
            this.dgvServiceItem.AllowUserToDeleteRows = false;
            this.dgvServiceItem.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiceItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiceItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvServiceItem.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEM_ID,
            this.ITEM_NAME,
            this.ITEM_UNIT,
            this.PRICE,
            this.PY_CODE,
            this.WB_CODE} );
            this.dgvServiceItem.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvServiceItem.EnableHeadersVisualStyles = false;
            this.dgvServiceItem.HideSelectionCardWhenCustomInput = false;
            this.dgvServiceItem.Location = new System.Drawing.Point( 3 , 3 );
            this.dgvServiceItem.Name = "dgvServiceItem";
            this.dgvServiceItem.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiceItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServiceItem.RowTemplate.Height = 23;
            this.dgvServiceItem.SelectionCards = null;
            this.dgvServiceItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceItem.Size = new System.Drawing.Size( 434 , 416 );
            this.dgvServiceItem.TabIndex = 0;
            this.dgvServiceItem.UseGradientBackgroundColor = false;
            this.dgvServiceItem.DoubleClick += new System.EventHandler( this.dgvServiceItem_DoubleClick );
            // 
            // ITEM_ID
            // 
            this.ITEM_ID.DataPropertyName = "ITEM_ID";
            this.ITEM_ID.HeaderText = "ITEM_ID";
            this.ITEM_ID.Name = "ITEM_ID";
            this.ITEM_ID.ReadOnly = true;
            this.ITEM_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ITEM_ID.Visible = false;
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NAME.DataPropertyName = "ITEM_NAME";
            this.ITEM_NAME.HeaderText = "项目名称";
            this.ITEM_NAME.Name = "ITEM_NAME";
            this.ITEM_NAME.ReadOnly = true;
            this.ITEM_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ITEM_UNIT
            // 
            this.ITEM_UNIT.DataPropertyName = "ITEM_UNIT";
            this.ITEM_UNIT.HeaderText = "单位";
            this.ITEM_UNIT.Name = "ITEM_UNIT";
            this.ITEM_UNIT.ReadOnly = true;
            this.ITEM_UNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRICE
            // 
            this.PRICE.DataPropertyName = "PRICE";
            this.PRICE.HeaderText = "价格";
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            this.PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PY_CODE
            // 
            this.PY_CODE.DataPropertyName = "PY_CODE";
            this.PY_CODE.HeaderText = "PY_CODE";
            this.PY_CODE.Name = "PY_CODE";
            this.PY_CODE.ReadOnly = true;
            this.PY_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY_CODE.Visible = false;
            // 
            // WB_CODE
            // 
            this.WB_CODE.DataPropertyName = "WB_CODE";
            this.WB_CODE.HeaderText = "WB_CODE";
            this.WB_CODE.Name = "WB_CODE";
            this.WB_CODE.ReadOnly = true;
            this.WB_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WB_CODE.Visible = false;
            // 
            // dgvSelected
            // 
            this.dgvSelected.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvSelected.AllowSortWhenClickColumnHeader = false;
            this.dgvSelected.AllowUserToAddRows = false;
            this.dgvSelected.AllowUserToDeleteRows = false;
            this.dgvSelected.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelected.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSelected.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this._ITEM_ID,
            this._ITEM_NAME} );
            this.dgvSelected.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvSelected.EnableHeadersVisualStyles = false;
            this.dgvSelected.HideSelectionCardWhenCustomInput = false;
            this.dgvSelected.Location = new System.Drawing.Point( 487 , 3 );
            this.dgvSelected.MultiSelect = false;
            this.dgvSelected.Name = "dgvSelected";
            this.dgvSelected.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle4.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelected.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSelected.RowTemplate.Height = 23;
            this.dgvSelected.SelectionCards = null;
            this.dgvSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelected.Size = new System.Drawing.Size( 350 , 444 );
            this.dgvSelected.TabIndex = 1;
            this.dgvSelected.UseGradientBackgroundColor = false;
            this.dgvSelected.DoubleClick += new System.EventHandler( this.dgvSelected_DoubleClick );
            // 
            // _ITEM_ID
            // 
            this._ITEM_ID.HeaderText = "ITEM_ID";
            this._ITEM_ID.Name = "_ITEM_ID";
            this._ITEM_ID.ReadOnly = true;
            this._ITEM_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._ITEM_ID.Visible = false;
            // 
            // _ITEM_NAME
            // 
            this._ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._ITEM_NAME.HeaderText = "项目名称";
            this._ITEM_NAME.Name = "_ITEM_NAME";
            this._ITEM_NAME.ReadOnly = true;
            this._ITEM_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point( 3 , 453 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 834 , 8 );
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point( 672 , 470 );
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size( 75 , 23 );
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point( 753 , 470 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75 , 23 );
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point( 443 , 189 );
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 38 , 23 );
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point( 443 , 241 );
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size( 38 , 23 );
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler( this.btnRemove_Click );
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point( 167 , 425 );
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size( 270 , 21 );
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler( this.txtSearch_TextChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 12 , 428 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 149 , 12 );
            this.label1.TabIndex = 8;
            this.label1.Text = "输入拼音五笔或名称关键字";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point( 443 , 295 );
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size( 38 , 23 );
            this.btnRemoveAll.TabIndex = 9;
            this.btnRemoveAll.Text = "重置";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler( this.btnRemoveAll_Click );
            // 
            // FrmSelectServiceItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 840 , 505 );
            this.Controls.Add( this.btnRemoveAll );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.txtSearch );
            this.Controls.Add( this.btnRemove );
            this.Controls.Add( this.btnAdd );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnOK );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.dgvSelected );
            this.Controls.Add( this.dgvServiceItem );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectServiceItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择服务项目";
            this.Load += new System.EventHandler( this.FrmSelectServiceItem_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvServiceItem ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvSelected ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgvServiceItem;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvSelected;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ITEM_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ITEM_NAME;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WB_CODE;
        private System.Windows.Forms.Button btnRemoveAll;
    }
}