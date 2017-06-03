namespace HIS_MZDocManager
{
    partial class FrmCommonItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCommonItem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            GWI.HIS.Windows.Controls.DataGridViewSelectionCard dataGridViewSelectionCard1 = new GWI.HIS.Windows.Controls.DataGridViewSelectionCard();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn4 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn5 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn6 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn7 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            this.tSMain = new GWI.HIS.Windows.Controls.ToolStrip();
            this.tSBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tSBtnNew = new System.Windows.Forms.ToolStripButton();
            this.tSBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tSBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tSBtnDel = new System.Windows.Forms.ToolStripButton();
            this.dGVEMain = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.ITEMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WB_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbStatus = new System.Windows.Forms.Label();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseStatus.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.tSMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEMain)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.tSMain);
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
            this.plBaseStatus.Controls.Add(this.lbStatus);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.dGVEMain);
            // 
            // tSMain
            // 
            this.tSMain.BackColor = System.Drawing.SystemColors.Control;
            this.tSMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tSMain.BackgroundImage")));
            this.tSMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tSMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tSMain.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tSMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSBtnSave,
            this.tSBtnNew,
            this.tSBtnUpdate,
            this.tSBtnCancel,
            this.tSBtnDel});
            this.tSMain.Location = new System.Drawing.Point(0, 0);
            this.tSMain.Name = "tSMain";
            this.tSMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tSMain.Size = new System.Drawing.Size(563, 29);
            this.tSMain.TabIndex = 3;
            this.tSMain.Text = "toolStrip1";
            // 
            // tSBtnSave
            // 
            this.tSBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnSave.Image")));
            this.tSBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnSave.Name = "tSBtnSave";
            this.tSBtnSave.Size = new System.Drawing.Size(83, 26);
            this.tSBtnSave.Text = "保存(F2)";
            this.tSBtnSave.Click += new System.EventHandler(this.tSBtnSave_Click);
            // 
            // tSBtnNew
            // 
            this.tSBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnNew.Image")));
            this.tSBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnNew.Name = "tSBtnNew";
            this.tSBtnNew.Size = new System.Drawing.Size(83, 26);
            this.tSBtnNew.Text = "新增(F3)";
            this.tSBtnNew.Click += new System.EventHandler(this.tSBtnNew_Click);
            // 
            // tSBtnUpdate
            // 
            this.tSBtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnUpdate.Image")));
            this.tSBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnUpdate.Name = "tSBtnUpdate";
            this.tSBtnUpdate.Size = new System.Drawing.Size(83, 26);
            this.tSBtnUpdate.Text = "修改(F4)";
            this.tSBtnUpdate.Visible = false;
            this.tSBtnUpdate.Click += new System.EventHandler(this.tSBtnUpdate_Click);
            // 
            // tSBtnCancel
            // 
            this.tSBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnCancel.Image")));
            this.tSBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnCancel.Name = "tSBtnCancel";
            this.tSBtnCancel.Size = new System.Drawing.Size(83, 26);
            this.tSBtnCancel.Text = "取消(F5)";
            this.tSBtnCancel.Click += new System.EventHandler(this.tSBtnCancel_Click);
            // 
            // tSBtnDel
            // 
            this.tSBtnDel.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnDel.Image")));
            this.tSBtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnDel.Name = "tSBtnDel";
            this.tSBtnDel.Size = new System.Drawing.Size(83, 26);
            this.tSBtnDel.Text = "删除(F6)";
            this.tSBtnDel.Click += new System.EventHandler(this.tSBtnDel_Click);
            // 
            // dGVEMain
            // 
            this.dGVEMain.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dGVEMain.AllowSortWhenClickColumnHeader = false;
            this.dGVEMain.AllowUserToAddRows = false;
            this.dGVEMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVEMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVEMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEMID,
            this.Order_Name,
            this.Order_Unit,
            this.PY_CODE,
            this.WB_CODE,
            this.D_CODE,
            this.Frequency,
            this.Bz});
            this.dGVEMain.DisplayAllItemWhenSelectionCardShowing = false;
            this.dGVEMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVEMain.EnableHeadersVisualStyles = false;
            this.dGVEMain.HideSelectionCardWhenCustomInput = false;
            this.dGVEMain.Location = new System.Drawing.Point(0, 0);
            this.dGVEMain.MultiSelect = false;
            this.dGVEMain.Name = "dGVEMain";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVEMain.RowTemplate.Height = 23;
            dataGridViewSelectionCard1.BindColumnIndex = 1;
            dataGridViewSelectionCard1.CardSize = new System.Drawing.Size(900, 450);
            selectionCardColumn1.AutoFill = false;
            selectionCardColumn1.DataBindField = "Order_Id";
            selectionCardColumn1.HeaderText = "项目编码";
            selectionCardColumn1.IsNameField = false;
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 60;
            selectionCardColumn2.AutoFill = true;
            selectionCardColumn2.DataBindField = "Order_Name";
            selectionCardColumn2.HeaderText = "项目名称";
            selectionCardColumn2.IsNameField = false;
            selectionCardColumn2.IsSeachColumn = true;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 200;
            selectionCardColumn3.AutoFill = false;
            selectionCardColumn3.DataBindField = "Order_Unit";
            selectionCardColumn3.HeaderText = "单位";
            selectionCardColumn3.IsNameField = false;
            selectionCardColumn3.IsSeachColumn = false;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn3.Visiable = true;
            selectionCardColumn3.Width = 40;
            selectionCardColumn4.AutoFill = false;
            selectionCardColumn4.DataBindField = "Py_Code";
            selectionCardColumn4.HeaderText = "拼音码";
            selectionCardColumn4.IsNameField = false;
            selectionCardColumn4.IsSeachColumn = true;
            selectionCardColumn4.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn4.Visiable = true;
            selectionCardColumn4.Width = 60;
            selectionCardColumn5.AutoFill = false;
            selectionCardColumn5.DataBindField = "Wb_Code";
            selectionCardColumn5.HeaderText = "五笔码";
            selectionCardColumn5.IsNameField = false;
            selectionCardColumn5.IsSeachColumn = true;
            selectionCardColumn5.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn5.Visiable = true;
            selectionCardColumn5.Width = 60;
            selectionCardColumn6.AutoFill = false;
            selectionCardColumn6.DataBindField = "D_Code";
            selectionCardColumn6.HeaderText = "数字码";
            selectionCardColumn6.IsNameField = false;
            selectionCardColumn6.IsSeachColumn = true;
            selectionCardColumn6.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn6.Visiable = true;
            selectionCardColumn6.Width = 60;
            selectionCardColumn7.AutoFill = false;
            selectionCardColumn7.DataBindField = "Bz";
            selectionCardColumn7.HeaderText = "备注";
            selectionCardColumn7.IsNameField = false;
            selectionCardColumn7.IsSeachColumn = false;
            selectionCardColumn7.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn7.Visiable = true;
            selectionCardColumn7.Width = 100;
            dataGridViewSelectionCard1.Columns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2,
        selectionCardColumn3,
        selectionCardColumn4,
        selectionCardColumn5,
        selectionCardColumn6,
        selectionCardColumn7};
            dataGridViewSelectionCard1.CurrentPage = 0;
            dataGridViewSelectionCard1.DataObjectType = null;
            dataGridViewSelectionCard1.DataSource = null;
            dataGridViewSelectionCard1.DataSourceIsDataTable = false;
            dataGridViewSelectionCard1.FilterResult = null;
            dataGridViewSelectionCard1.OffsetX = 0;
            dataGridViewSelectionCard1.OffsetY = 0;
            dataGridViewSelectionCard1.SelectCardAlternatingRowsBackColor = System.Drawing.Color.Empty;
            dataGridViewSelectionCard1.SelectCardFilterType = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            dataGridViewSelectionCard1.SelectCardRowHeight = 23;
            dataGridViewSelectionCard1.SelectionCardBackGroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewSelectionCard1.SelectionCardFont = new System.Drawing.Font("宋体", 9F);
            dataGridViewSelectionCard1.SelectionCardLabelBackColor = System.Drawing.SystemColors.Control;
            dataGridViewSelectionCard1.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            dataGridViewSelectionCard1.SelectionRowBackColor = System.Drawing.Color.Black;
            dataGridViewSelectionCard1.SpeciFilterString = null;
            dataGridViewSelectionCard1.TotalPage = 0;
            this.dGVEMain.SelectionCards = new GWI.HIS.Windows.Controls.DataGridViewSelectionCard[] {
        dataGridViewSelectionCard1};
            this.dGVEMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dGVEMain.Size = new System.Drawing.Size(563, 330);
            this.dGVEMain.TabIndex = 4;
            this.dGVEMain.UseGradientBackgroundColor = true;
            this.dGVEMain.SelectCardRowSelected += new GWI.HIS.Windows.Controls.OnSelectCardRowSelectedHandle(this.dGVEMain_SelectCardRowSelected);
            this.dGVEMain.CurrentCellChanged += new System.EventHandler(this.dGVEMain_CurrentCellChanged);
            // 
            // ITEMID
            // 
            this.ITEMID.DataPropertyName = "Item_Id";
            this.ITEMID.HeaderText = "编码";
            this.ITEMID.Name = "ITEMID";
            this.ITEMID.ReadOnly = true;
            this.ITEMID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Order_Name
            // 
            this.Order_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Order_Name.DataPropertyName = "Order_Name";
            this.Order_Name.HeaderText = "名称";
            this.Order_Name.Name = "Order_Name";
            this.Order_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Order_Unit
            // 
            this.Order_Unit.DataPropertyName = "Order_Unit";
            this.Order_Unit.HeaderText = "单位";
            this.Order_Unit.Name = "Order_Unit";
            this.Order_Unit.ReadOnly = true;
            this.Order_Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Order_Unit.Width = 60;
            // 
            // PY_CODE
            // 
            this.PY_CODE.DataPropertyName = "Py_Code";
            this.PY_CODE.HeaderText = "拼音码";
            this.PY_CODE.Name = "PY_CODE";
            this.PY_CODE.ReadOnly = true;
            this.PY_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WB_CODE
            // 
            this.WB_CODE.DataPropertyName = "Wb_Code";
            this.WB_CODE.HeaderText = "五笔码";
            this.WB_CODE.Name = "WB_CODE";
            this.WB_CODE.ReadOnly = true;
            this.WB_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // D_CODE
            // 
            this.D_CODE.DataPropertyName = "D_Code";
            this.D_CODE.HeaderText = "数字码";
            this.D_CODE.Name = "D_CODE";
            this.D_CODE.ReadOnly = true;
            this.D_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Frequency
            // 
            this.Frequency.DataPropertyName = "Frequency";
            this.Frequency.HeaderText = "使用频度";
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            this.Frequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Frequency.Width = 50;
            // 
            // Bz
            // 
            this.Bz.DataPropertyName = "Bz";
            this.Bz.HeaderText = "备注";
            this.Bz.Name = "Bz";
            this.Bz.ReadOnly = true;
            this.Bz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bz.Width = 200;
            // 
            // lbStatus
            // 
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStatus.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStatus.ForeColor = System.Drawing.Color.Blue;
            this.lbStatus.Location = new System.Drawing.Point(0, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(563, 26);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "        当前状态：";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmCommonItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 419);
            this.FormTitle = "常用项目设置";
            this.KeyPreview = true;
            this.Name = "FrmCommonItem";
            this.Text = "常用项目设置";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCommonItem_KeyDown);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseStatus.ResumeLayout(false);
            this.plBaseWorkArea.ResumeLayout(false);
            this.tSMain.ResumeLayout(false);
            this.tSMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GWI.HIS.Windows.Controls.ToolStrip tSMain;
        private System.Windows.Forms.ToolStripButton tSBtnSave;
        private System.Windows.Forms.ToolStripButton tSBtnNew;
        private System.Windows.Forms.ToolStripButton tSBtnUpdate;
        private System.Windows.Forms.ToolStripButton tSBtnCancel;
        private System.Windows.Forms.ToolStripButton tSBtnDel;
        private GWI.HIS.Windows.Controls.DataGridViewEx dGVEMain;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WB_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bz;
    }
}