namespace HIS_MZDocManager
{
    partial class FrmCommonDrug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCommonDrug));
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
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn8 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn9 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            this.tSMain = new GWI.HIS.Windows.Controls.ToolStrip();
            this.tSBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tSBtnNew = new System.Windows.Forms.ToolStripButton();
            this.tSBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tSBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tSBtnDel = new System.Windows.Forms.ToolStripButton();
            this.dGVEMain = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.ITEMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STANDARD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WB_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.plBaseToolbar.Size = new System.Drawing.Size(610, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 400);
            this.plBaseStatus.Size = new System.Drawing.Size(610, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.dGVEMain);
            this.plBaseWorkArea.Size = new System.Drawing.Size(610, 337);
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
            this.tSMain.Size = new System.Drawing.Size(610, 29);
            this.tSMain.TabIndex = 2;
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
            this.itemname,
            this.STANDARD,
            this.unit,
            this.ADDRESS,
            this.PY_CODE,
            this.WB_CODE,
            this.D_CODE,
            this.Frequency});
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
            selectionCardColumn1.DataBindField = "ITEMID";
            selectionCardColumn1.HeaderText = "项目编码";
            selectionCardColumn1.IsNameField = false;
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 60;
            selectionCardColumn2.AutoFill = false;
            selectionCardColumn2.DataBindField = "itemname";
            selectionCardColumn2.HeaderText = "项目名称";
            selectionCardColumn2.IsNameField = false;
            selectionCardColumn2.IsSeachColumn = true;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 200;
            selectionCardColumn3.AutoFill = false;
            selectionCardColumn3.DataBindField = "STANDARD";
            selectionCardColumn3.HeaderText = "规格";
            selectionCardColumn3.IsNameField = false;
            selectionCardColumn3.IsSeachColumn = false;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn3.Visiable = true;
            selectionCardColumn3.Width = 75;
            selectionCardColumn4.AutoFill = false;
            selectionCardColumn4.DataBindField = "unit";
            selectionCardColumn4.HeaderText = "单位";
            selectionCardColumn4.IsNameField = false;
            selectionCardColumn4.IsSeachColumn = false;
            selectionCardColumn4.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn4.Visiable = true;
            selectionCardColumn4.Width = 40;
            selectionCardColumn5.AutoFill = false;
            selectionCardColumn5.DataBindField = "sell_price";
            selectionCardColumn5.HeaderText = "单价";
            selectionCardColumn5.IsNameField = false;
            selectionCardColumn5.IsSeachColumn = false;
            selectionCardColumn5.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn5.Visiable = true;
            selectionCardColumn5.Width = 50;
            selectionCardColumn6.AutoFill = false;
            selectionCardColumn6.DataBindField = "PY_CODE";
            selectionCardColumn6.HeaderText = "拼音码";
            selectionCardColumn6.IsNameField = false;
            selectionCardColumn6.IsSeachColumn = true;
            selectionCardColumn6.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn6.Visiable = true;
            selectionCardColumn6.Width = 60;
            selectionCardColumn7.AutoFill = false;
            selectionCardColumn7.DataBindField = "WB_CODE";
            selectionCardColumn7.HeaderText = "五笔码";
            selectionCardColumn7.IsNameField = false;
            selectionCardColumn7.IsSeachColumn = true;
            selectionCardColumn7.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn7.Visiable = true;
            selectionCardColumn7.Width = 60;
            selectionCardColumn8.AutoFill = false;
            selectionCardColumn8.DataBindField = "D_CODE";
            selectionCardColumn8.HeaderText = "数字码";
            selectionCardColumn8.IsNameField = false;
            selectionCardColumn8.IsSeachColumn = false;
            selectionCardColumn8.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn8.Visiable = true;
            selectionCardColumn8.Width = 60;
            selectionCardColumn9.AutoFill = true;
            selectionCardColumn9.DataBindField = "ADDRESS";
            selectionCardColumn9.HeaderText = "产地";
            selectionCardColumn9.IsNameField = false;
            selectionCardColumn9.IsSeachColumn = false;
            selectionCardColumn9.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn9.Visiable = true;
            selectionCardColumn9.Width = 150;
            dataGridViewSelectionCard1.Columns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2,
        selectionCardColumn3,
        selectionCardColumn4,
        selectionCardColumn5,
        selectionCardColumn6,
        selectionCardColumn7,
        selectionCardColumn8,
        selectionCardColumn9};
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
            this.dGVEMain.Size = new System.Drawing.Size(610, 337);
            this.dGVEMain.TabIndex = 3;
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
            // itemname
            // 
            this.itemname.DataPropertyName = "itemname";
            this.itemname.HeaderText = "名称";
            this.itemname.Name = "itemname";
            this.itemname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.itemname.Width = 200;
            // 
            // STANDARD
            // 
            this.STANDARD.DataPropertyName = "STANDARD";
            this.STANDARD.HeaderText = "规格";
            this.STANDARD.Name = "STANDARD";
            this.STANDARD.ReadOnly = true;
            this.STANDARD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.unit.Width = 60;
            // 
            // ADDRESS
            // 
            this.ADDRESS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ADDRESS.DataPropertyName = "ADDRESS";
            this.ADDRESS.HeaderText = "产地";
            this.ADDRESS.Name = "ADDRESS";
            this.ADDRESS.ReadOnly = true;
            this.ADDRESS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PY_CODE
            // 
            this.PY_CODE.DataPropertyName = "PY_CODE";
            this.PY_CODE.HeaderText = "拼音码";
            this.PY_CODE.Name = "PY_CODE";
            this.PY_CODE.ReadOnly = true;
            this.PY_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WB_CODE
            // 
            this.WB_CODE.DataPropertyName = "WB_CODE";
            this.WB_CODE.HeaderText = "五笔码";
            this.WB_CODE.Name = "WB_CODE";
            this.WB_CODE.ReadOnly = true;
            this.WB_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // D_CODE
            // 
            this.D_CODE.DataPropertyName = "D_CODE";
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
            // lbStatus
            // 
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStatus.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStatus.ForeColor = System.Drawing.Color.Blue;
            this.lbStatus.Location = new System.Drawing.Point(0, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(610, 26);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "        当前状态：";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmCommonDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 426);
            this.FormTitle = "常用药品设置";
            this.KeyPreview = true;
            this.Name = "FrmCommonDrug";
            this.Text = "常用药品设置";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCommonDrug_KeyDown);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn STANDARD;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WB_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;

    }
}