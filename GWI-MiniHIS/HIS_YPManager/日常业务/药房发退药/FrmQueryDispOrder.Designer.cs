namespace HIS_YPManager
{
    partial class FrmQueryDispOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQueryDispOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectNot = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgrdQueryRecipe = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.IsDispense = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_PatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_BedNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrugName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrugSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOSENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DispDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CureDocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdQueryRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plBaseToolbar.Controls.Add(this.btnCancel);
            this.plBaseToolbar.Controls.Add(this.btnOK);
            this.plBaseToolbar.Controls.Add(this.btnSelectNot);
            this.plBaseToolbar.Controls.Add(this.btnSelectAll);
            this.plBaseToolbar.Size = new System.Drawing.Size(684, 29);
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("baseImageList.ImageStream")));
            this.baseImageList.Images.SetKeyName(0, "table_delete.gif");
            this.baseImageList.Images.SetKeyName(1, "search_big.GIF");
            this.baseImageList.Images.SetKeyName(2, "Save.GIF");
            this.baseImageList.Images.SetKeyName(3, "Print.GIF");
            this.baseImageList.Images.SetKeyName(4, "page_user_dark.gif");
            this.baseImageList.Images.SetKeyName(5, "page_refresh.gif");
            this.baseImageList.Images.SetKeyName(6, "page_key.gif");
            this.baseImageList.Images.SetKeyName(7, "page_edit.gif");
            this.baseImageList.Images.SetKeyName(8, "page_cross.gif");
            this.baseImageList.Images.SetKeyName(9, "list_users.gif");
            this.baseImageList.Images.SetKeyName(10, "icon_package_get.gif");
            this.baseImageList.Images.SetKeyName(11, "icon_network.gif");
            this.baseImageList.Images.SetKeyName(12, "icon_history.gif");
            this.baseImageList.Images.SetKeyName(13, "icon_accept.gif");
            this.baseImageList.Images.SetKeyName(14, "folder_page.gif");
            this.baseImageList.Images.SetKeyName(15, "folder_new.gif");
            this.baseImageList.Images.SetKeyName(16, "Exit.GIF");
            this.baseImageList.Images.SetKeyName(17, "Delete.GIF");
            this.baseImageList.Images.SetKeyName(18, "copy.gif");
            this.baseImageList.Images.SetKeyName(19, "action_stop.gif");
            this.baseImageList.Images.SetKeyName(20, "action_refresh.gif");
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point(0, 376);
            this.plBaseStatus.Size = new System.Drawing.Size(684, 0);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.dgrdQueryRecipe);
            this.plBaseWorkArea.Size = new System.Drawing.Size(684, 313);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(17, 1);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(50, 23);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSelectNot
            // 
            this.btnSelectNot.Location = new System.Drawing.Point(73, 1);
            this.btnSelectNot.Name = "btnSelectNot";
            this.btnSelectNot.Size = new System.Drawing.Size(50, 23);
            this.btnSelectNot.TabIndex = 1;
            this.btnSelectNot.Text = "全不选";
            this.btnSelectNot.UseVisualStyleBackColor = true;
            this.btnSelectNot.Click += new System.EventHandler(this.btnSelectNot_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(517, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(50, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(573, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgrdQueryRecipe
            // 
            this.dgrdQueryRecipe.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdQueryRecipe.AllowSortWhenClickColumnHeader = false;
            this.dgrdQueryRecipe.AllowUserToAddRows = false;
            this.dgrdQueryRecipe.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdQueryRecipe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdQueryRecipe.ColumnHeadersHeight = 35;
            this.dgrdQueryRecipe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsDispense,
            this.col_PatNo,
            this.col_PatName,
            this.col_BedNo,
            this.Column2,
            this.DrugName,
            this.DrugSpec,
            this.ProductName,
            this.DOSENAME,
            this.Num,
            this.Unit,
            this.RetailPrice,
            this.RetailFee,
            this.DispDeptName,
            this.CureDocName,
            this.costdate});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdQueryRecipe.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgrdQueryRecipe.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgrdQueryRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdQueryRecipe.EnableHeadersVisualStyles = false;
            this.dgrdQueryRecipe.HideSelectionCardWhenCustomInput = false;
            this.dgrdQueryRecipe.Location = new System.Drawing.Point(0, 0);
            this.dgrdQueryRecipe.Name = "dgrdQueryRecipe";
            this.dgrdQueryRecipe.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdQueryRecipe.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdQueryRecipe.RowHeadersVisible = false;
            this.dgrdQueryRecipe.RowTemplate.Height = 23;
            this.dgrdQueryRecipe.SelectionCards = null;
            this.dgrdQueryRecipe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgrdQueryRecipe.Size = new System.Drawing.Size(684, 313);
            this.dgrdQueryRecipe.TabIndex = 1;
            this.dgrdQueryRecipe.UseGradientBackgroundColor = true;
            // 
            // IsDispense
            // 
            this.IsDispense.DataPropertyName = "ISDISPENSE";
            this.IsDispense.HeaderText = "选择";
            this.IsDispense.Name = "IsDispense";
            this.IsDispense.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsDispense.Width = 30;
            // 
            // col_PatNo
            // 
            this.col_PatNo.DataPropertyName = "CURENO";
            this.col_PatNo.HeaderText = "住院号";
            this.col_PatNo.Name = "col_PatNo";
            this.col_PatNo.ReadOnly = true;
            this.col_PatNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_PatNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_PatNo.Width = 60;
            // 
            // col_PatName
            // 
            this.col_PatName.DataPropertyName = "PATNAME";
            this.col_PatName.HeaderText = "病人姓名";
            this.col_PatName.Name = "col_PatName";
            this.col_PatName.ReadOnly = true;
            this.col_PatName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_PatName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_PatName.Width = 60;
            // 
            // col_BedNo
            // 
            this.col_BedNo.DataPropertyName = "BEDNO";
            this.col_BedNo.HeaderText = "床号";
            this.col_BedNo.Name = "col_BedNo";
            this.col_BedNo.ReadOnly = true;
            this.col_BedNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_BedNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_BedNo.Width = 35;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MAKERDICID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "编码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 50;
            // 
            // DrugName
            // 
            this.DrugName.DataPropertyName = "CHEMNAME";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DrugName.DefaultCellStyle = dataGridViewCellStyle3;
            this.DrugName.HeaderText = "药品名称";
            this.DrugName.Name = "DrugName";
            this.DrugName.ReadOnly = true;
            this.DrugName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DrugName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DrugName.Width = 150;
            // 
            // DrugSpec
            // 
            this.DrugSpec.DataPropertyName = "SPEC";
            this.DrugSpec.HeaderText = "药品规格";
            this.DrugSpec.Name = "DrugSpec";
            this.DrugSpec.ReadOnly = true;
            this.DrugSpec.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DrugSpec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "PRODUCTNAME";
            this.ProductName.HeaderText = "生产厂家";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductName.Width = 150;
            // 
            // DOSENAME
            // 
            this.DOSENAME.DataPropertyName = "DOSENAME";
            this.DOSENAME.HeaderText = "剂型";
            this.DOSENAME.Name = "DOSENAME";
            this.DOSENAME.ReadOnly = true;
            this.DOSENAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DOSENAME.Width = 45;
            // 
            // Num
            // 
            this.Num.DataPropertyName = "DRUGNUM";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Num.DefaultCellStyle = dataGridViewCellStyle4;
            this.Num.HeaderText = "数量";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Num.Width = 60;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "UNITNAME";
            this.Unit.HeaderText = "单位";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Unit.Width = 35;
            // 
            // RetailPrice
            // 
            this.RetailPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RetailPrice.DataPropertyName = "RETAILPRICE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.RetailPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.RetailPrice.HeaderText = "零售价格";
            this.RetailPrice.Name = "RetailPrice";
            this.RetailPrice.ReadOnly = true;
            this.RetailPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RetailPrice.Width = 42;
            // 
            // RetailFee
            // 
            this.RetailFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RetailFee.DataPropertyName = "RETAILFEE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.RetailFee.DefaultCellStyle = dataGridViewCellStyle6;
            this.RetailFee.HeaderText = "零售金额";
            this.RetailFee.Name = "RetailFee";
            this.RetailFee.ReadOnly = true;
            this.RetailFee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RetailFee.Width = 42;
            // 
            // DispDeptName
            // 
            this.DispDeptName.DataPropertyName = "PRESDEPTNAME";
            this.DispDeptName.HeaderText = "主治科室";
            this.DispDeptName.Name = "DispDeptName";
            this.DispDeptName.ReadOnly = true;
            this.DispDeptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DispDeptName.Width = 60;
            // 
            // CureDocName
            // 
            this.CureDocName.DataPropertyName = "PRESDOCNAME";
            this.CureDocName.HeaderText = "主治医生";
            this.CureDocName.Name = "CureDocName";
            this.CureDocName.ReadOnly = true;
            this.CureDocName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CureDocName.Width = 60;
            // 
            // costdate
            // 
            this.costdate.DataPropertyName = "CHARGEDATE";
            this.costdate.HeaderText = "记账时间";
            this.costdate.Name = "costdate";
            this.costdate.ReadOnly = true;
            this.costdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.costdate.Width = 80;
            // 
            // FrmQueryDispOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 376);
            this.FormTitle = "发药消息查询";
            this.Name = "FrmQueryDispOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发药消息查询";
            this.Load += new System.EventHandler(this.FrmQueryDispOrder_Load);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseWorkArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdQueryRecipe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectNot;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdQueryRecipe;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDispense;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_BedNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrugName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrugSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOSENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn DispDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CureDocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn costdate;
    }
}