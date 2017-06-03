namespace HIS_MZDocManager
{
    partial class UCPresMould
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPresMould));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this._rdbLevelP = new System.Windows.Forms.RadioButton();
            this._rdbLevelD = new System.Windows.Forms.RadioButton();
            this._rdbLevelH = new System.Windows.Forms.RadioButton();
            this.btRefreshMould = new System.Windows.Forms.Button();
            this.tVwPresMould = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.dGVEPresMould = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TmpNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Standard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usage_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usage_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usage_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entrust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEPresMould)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this._rdbLevelP);
            this.pnlTop.Controls.Add(this._rdbLevelD);
            this.pnlTop.Controls.Add(this._rdbLevelH);
            this.pnlTop.Controls.Add(this.btRefreshMould);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(160, 54);
            this.pnlTop.TabIndex = 1;
            // 
            // _rdbLevelP
            // 
            this._rdbLevelP.AutoSize = true;
            this._rdbLevelP.Checked = true;
            this._rdbLevelP.Location = new System.Drawing.Point(109, 32);
            this._rdbLevelP.Name = "_rdbLevelP";
            this._rdbLevelP.Size = new System.Drawing.Size(47, 16);
            this._rdbLevelP.TabIndex = 3;
            this._rdbLevelP.TabStop = true;
            this._rdbLevelP.Tag = "3";
            this._rdbLevelP.Text = "个人";
            this._rdbLevelP.UseVisualStyleBackColor = true;
            this._rdbLevelP.CheckedChanged += new System.EventHandler(this.btRefreshMould_Click);
            // 
            // _rdbLevelD
            // 
            this._rdbLevelD.AutoSize = true;
            this._rdbLevelD.Location = new System.Drawing.Point(59, 32);
            this._rdbLevelD.Name = "_rdbLevelD";
            this._rdbLevelD.Size = new System.Drawing.Size(47, 16);
            this._rdbLevelD.TabIndex = 2;
            this._rdbLevelD.Tag = "2";
            this._rdbLevelD.Text = "科级";
            this._rdbLevelD.UseVisualStyleBackColor = true;
            this._rdbLevelD.CheckedChanged += new System.EventHandler(this.btRefreshMould_Click);
            // 
            // _rdbLevelH
            // 
            this._rdbLevelH.AutoSize = true;
            this._rdbLevelH.Location = new System.Drawing.Point(9, 32);
            this._rdbLevelH.Name = "_rdbLevelH";
            this._rdbLevelH.Size = new System.Drawing.Size(47, 16);
            this._rdbLevelH.TabIndex = 1;
            this._rdbLevelH.Tag = "1";
            this._rdbLevelH.Text = "院级";
            this._rdbLevelH.UseVisualStyleBackColor = true;
            this._rdbLevelH.CheckedChanged += new System.EventHandler(this.btRefreshMould_Click);
            // 
            // btRefreshMould
            // 
            this.btRefreshMould.Dock = System.Windows.Forms.DockStyle.Top;
            this.btRefreshMould.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRefreshMould.Location = new System.Drawing.Point(0, 0);
            this.btRefreshMould.Name = "btRefreshMould";
            this.btRefreshMould.Size = new System.Drawing.Size(160, 25);
            this.btRefreshMould.TabIndex = 0;
            this.btRefreshMould.Text = "刷新医生模板";
            this.btRefreshMould.UseVisualStyleBackColor = true;
            this.btRefreshMould.Click += new System.EventHandler(this.btRefreshMould_Click);
            // 
            // tVwPresMould
            // 
            this.tVwPresMould.Dock = System.Windows.Forms.DockStyle.Top;
            this.tVwPresMould.ImageIndex = 0;
            this.tVwPresMould.ImageList = this.imageList;
            this.tVwPresMould.Location = new System.Drawing.Point(0, 54);
            this.tVwPresMould.Name = "tVwPresMould";
            this.tVwPresMould.SelectedImageIndex = 0;
            this.tVwPresMould.Size = new System.Drawing.Size(160, 256);
            this.tVwPresMould.TabIndex = 0;
            this.tVwPresMould.DoubleClick += new System.EventHandler(this.tVwPresMould_DoubleClick);
            this.tVwPresMould.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tVwPresMould_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder_new.gif");
            this.imageList.Images.SetKeyName(1, "folder_page.gif");
            this.imageList.Images.SetKeyName(2, "copy.gif");
            this.imageList.Images.SetKeyName(3, "page_edit.gif");
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 397);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(160, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 310);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(160, 3);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // dGVEPresMould
            // 
            this.dGVEPresMould.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dGVEPresMould.AllowSortWhenClickColumnHeader = false;
            this.dGVEPresMould.AllowUserToAddRows = false;
            this.dGVEPresMould.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEPresMould.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVEPresMould.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVEPresMould.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.TmpNo,
            this.OrderNo,
            this.Item_Id,
            this.Item_Name,
            this.Dept_Name,
            this.Standard,
            this.Price,
            this.Usage_Amount,
            this.Usage_Unit,
            this.Dosage,
            this.Usage_Name,
            this.Frequency_Name,
            this.Days,
            this.Item_Amount,
            this.Item_Unit,
            this.Entrust});
            this.dGVEPresMould.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVEPresMould.EnableHeadersVisualStyles = false;
            this.dGVEPresMould.Location = new System.Drawing.Point(0, 313);
            this.dGVEPresMould.MultiSelect = false;
            this.dGVEPresMould.Name = "dGVEPresMould";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEPresMould.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVEPresMould.RowHeadersVisible = false;
            this.dGVEPresMould.RowTemplate.Height = 23;
            this.dGVEPresMould.SelectionCards = new GWI.HIS.Windows.Controls.DataGridViewSelectionCard[0];
            this.dGVEPresMould.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVEPresMould.Size = new System.Drawing.Size(160, 84);
            this.dGVEPresMould.TabIndex = 8;
            this.dGVEPresMould.UseGradientBackgroundColor = true;
            this.dGVEPresMould.DoubleClick += new System.EventHandler(this.dGVEPresMould_DoubleClick);
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.HeaderText = "选";
            this.Selected.Name = "Selected";
            this.Selected.ReadOnly = true;
            this.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Selected.Visible = false;
            this.Selected.Width = 25;
            // 
            // TmpNo
            // 
            this.TmpNo.DataPropertyName = "TmpNo";
            this.TmpNo.HeaderText = "*";
            this.TmpNo.Name = "TmpNo";
            this.TmpNo.ReadOnly = true;
            this.TmpNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TmpNo.Visible = false;
            this.TmpNo.Width = 25;
            // 
            // OrderNo
            // 
            this.OrderNo.DataPropertyName = "OrderNo";
            this.OrderNo.HeaderText = "行号";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            this.OrderNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OrderNo.Visible = false;
            this.OrderNo.Width = 40;
            // 
            // Item_Id
            // 
            this.Item_Id.DataPropertyName = "Item_Id_S";
            this.Item_Id.HeaderText = "项目编码";
            this.Item_Id.Name = "Item_Id";
            this.Item_Id.ReadOnly = true;
            this.Item_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item_Id.Width = 70;
            // 
            // Item_Name
            // 
            this.Item_Name.DataPropertyName = "Item_Name_S";
            this.Item_Name.HeaderText = "项目名称";
            this.Item_Name.Name = "Item_Name";
            this.Item_Name.ReadOnly = true;
            this.Item_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item_Name.Width = 150;
            // 
            // Dept_Name
            // 
            this.Dept_Name.DataPropertyName = "Dept_Name";
            this.Dept_Name.HeaderText = "执行科室";
            this.Dept_Name.Name = "Dept_Name";
            this.Dept_Name.ReadOnly = true;
            this.Dept_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Standard
            // 
            this.Standard.DataPropertyName = "Standard";
            this.Standard.HeaderText = "规格";
            this.Standard.Name = "Standard";
            this.Standard.ReadOnly = true;
            this.Standard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Standard.Width = 110;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "价格";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Price.Width = 60;
            // 
            // Usage_Amount
            // 
            this.Usage_Amount.DataPropertyName = "Usage_Amount_S";
            this.Usage_Amount.HeaderText = "用量/次";
            this.Usage_Amount.Name = "Usage_Amount";
            this.Usage_Amount.ReadOnly = true;
            this.Usage_Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Usage_Amount.Width = 60;
            // 
            // Usage_Unit
            // 
            this.Usage_Unit.DataPropertyName = "Usage_Unit";
            this.Usage_Unit.HeaderText = "单位";
            this.Usage_Unit.Name = "Usage_Unit";
            this.Usage_Unit.ReadOnly = true;
            this.Usage_Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Usage_Unit.Width = 50;
            // 
            // Dosage
            // 
            this.Dosage.DataPropertyName = "Dosage_S";
            this.Dosage.HeaderText = "剂数";
            this.Dosage.Name = "Dosage";
            this.Dosage.ReadOnly = true;
            this.Dosage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dosage.Width = 40;
            // 
            // Usage_Name
            // 
            this.Usage_Name.DataPropertyName = "Usage_Name";
            this.Usage_Name.HeaderText = "用法";
            this.Usage_Name.Name = "Usage_Name";
            this.Usage_Name.ReadOnly = true;
            this.Usage_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Usage_Name.Width = 70;
            // 
            // Frequency_Name
            // 
            this.Frequency_Name.DataPropertyName = "Frequency_Name";
            this.Frequency_Name.HeaderText = "频次";
            this.Frequency_Name.Name = "Frequency_Name";
            this.Frequency_Name.ReadOnly = true;
            this.Frequency_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Frequency_Name.Width = 50;
            // 
            // Days
            // 
            this.Days.DataPropertyName = "Days_S";
            this.Days.HeaderText = "天数";
            this.Days.Name = "Days";
            this.Days.ReadOnly = true;
            this.Days.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Days.Width = 40;
            // 
            // Item_Amount
            // 
            this.Item_Amount.DataPropertyName = "Item_Amount_S";
            this.Item_Amount.HeaderText = "开药数量";
            this.Item_Amount.Name = "Item_Amount";
            this.Item_Amount.ReadOnly = true;
            this.Item_Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item_Amount.Width = 50;
            // 
            // Item_Unit
            // 
            this.Item_Unit.DataPropertyName = "Item_Unit";
            this.Item_Unit.HeaderText = "开药单位";
            this.Item_Unit.Name = "Item_Unit";
            this.Item_Unit.ReadOnly = true;
            this.Item_Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item_Unit.Width = 50;
            // 
            // Entrust
            // 
            this.Entrust.DataPropertyName = "Entrust";
            this.Entrust.HeaderText = "嘱托";
            this.Entrust.Name = "Entrust";
            this.Entrust.ReadOnly = true;
            this.Entrust.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Entrust.Width = 150;
            // 
            // UCPresMould
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.dGVEPresMould);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.tVwPresMould);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlTop);
            this.Name = "UCPresMould";
            this.Size = new System.Drawing.Size(160, 400);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEPresMould)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btRefreshMould;
        private System.Windows.Forms.RadioButton _rdbLevelH;
        private System.Windows.Forms.RadioButton _rdbLevelP;
        private System.Windows.Forms.RadioButton _rdbLevelD;
        private System.Windows.Forms.TreeView tVwPresMould;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private GWI.HIS.Windows.Controls.DataGridViewEx dGVEPresMould;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn TmpNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Standard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usage_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usage_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usage_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrust;
    }
}
