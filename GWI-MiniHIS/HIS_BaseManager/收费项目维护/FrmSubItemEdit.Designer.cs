namespace HIS_BaseManager
{
    partial class FrmSubItemEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboClassName = new System.Windows.Forms.ComboBox();
            this.dgvSubItem = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALID_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvSubItem ) ).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 9, 22 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 29, 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "分类";
            // 
            // cboClassName
            // 
            this.cboClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassName.FormattingEnabled = true;
            this.cboClassName.Location = new System.Drawing.Point( 44, 19 );
            this.cboClassName.Name = "cboClassName";
            this.cboClassName.Size = new System.Drawing.Size( 261, 20 );
            this.cboClassName.TabIndex = 1;
            this.cboClassName.SelectedIndexChanged += new System.EventHandler( this.cboClassName_SelectedIndexChanged );
            // 
            // dgvSubItem
            // 
            this.dgvSubItem.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvSubItem.AllowSortWhenClickColumnHeader = false;
            this.dgvSubItem.AllowUserToAddRows = false;
            this.dgvSubItem.AllowUserToDeleteRows = false;
            this.dgvSubItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubItem.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.CODE,
            this.ITEM_NAME,
            this.VALID_FLAG} );
            this.dgvSubItem.Location = new System.Drawing.Point( 12, 45 );
            this.dgvSubItem.Name = "dgvSubItem";
            this.dgvSubItem.RowHeadersWidth = 20;
            this.dgvSubItem.RowTemplate.Height = 23;
            this.dgvSubItem.SelectionCards = null;
            this.dgvSubItem.Size = new System.Drawing.Size( 293, 296 );
            this.dgvSubItem.TabIndex = 2;
            // 
            // CODE
            // 
            this.CODE.DataPropertyName = "CODE";
            this.CODE.HeaderText = "编码";
            this.CODE.Name = "CODE";
            this.CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CODE.Width = 75;
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NAME.DataPropertyName = "ITEM_NAME";
            this.ITEM_NAME.HeaderText = "名称";
            this.ITEM_NAME.Name = "ITEM_NAME";
            this.ITEM_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // VALID_FLAG
            // 
            this.VALID_FLAG.DataPropertyName = "VALID_FLAG";
            this.VALID_FLAG.HeaderText = "有效";
            this.VALID_FLAG.Name = "VALID_FLAG";
            this.VALID_FLAG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VALID_FLAG.Width = 35;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point( 149, 359 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 75, 23 );
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 230, 359 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 23 );
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point( 68, 359 );
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 75, 23 );
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "增加(&N)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // FrmSubItemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 317, 397 );
            this.Controls.Add( this.btnAdd );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.btnSave );
            this.Controls.Add( this.dgvSubItem );
            this.Controls.Add( this.cboClassName );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSubItemEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "统计分类设置";
            this.Load += new System.EventHandler( this.FrmSubItemEdit_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvSubItem ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboClassName;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvSubItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NAME;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VALID_FLAG;
    }
}