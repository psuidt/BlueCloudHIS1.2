namespace HIS_MZDocManager
{
    partial class FrmWardBedQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWardBedQuery));
            this.dGVEResult = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Dept_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip();
            this.tSBtnQuery = new System.Windows.Forms.ToolStripButton();
            this.tSBtnQuit = new System.Windows.Forms.ToolStripButton();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEResult)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.toolStrip1);
            this.plBaseToolbar.Size = new System.Drawing.Size(829, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 432);
            this.plBaseStatus.Size = new System.Drawing.Size(829, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.dGVEResult);
            this.plBaseWorkArea.Size = new System.Drawing.Size(829, 369);
            // 
            // dGVEResult
            // 
            this.dGVEResult.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dGVEResult.AllowSortWhenClickColumnHeader = false;
            this.dGVEResult.AllowUserToAddRows = false;
            this.dGVEResult.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVEResult.ColumnHeadersHeight = 28;
            this.dGVEResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVEResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dept_Id,
            this.DeptName,
            this.Num,
            this.IsUse,
            this.NotUse});
            this.dGVEResult.DisplayAllItemWhenSelectionCardShowing = false;
            this.dGVEResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVEResult.EnableHeadersVisualStyles = false;
            this.dGVEResult.HideSelectionCardWhenCustomInput = false;
            this.dGVEResult.Location = new System.Drawing.Point(0, 0);
            this.dGVEResult.MultiSelect = false;
            this.dGVEResult.Name = "dGVEResult";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVEResult.RowTemplate.Height = 23;
            this.dGVEResult.SelectionCards = null;
            this.dGVEResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVEResult.Size = new System.Drawing.Size(829, 369);
            this.dGVEResult.TabIndex = 3;
            this.dGVEResult.UseGradientBackgroundColor = true;
            // 
            // Dept_Id
            // 
            this.Dept_Id.DataPropertyName = "Dept_Id";
            this.Dept_Id.HeaderText = "编号";
            this.Dept_Id.Name = "Dept_Id";
            this.Dept_Id.ReadOnly = true;
            this.Dept_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dept_Id.Width = 50;
            // 
            // DeptName
            // 
            this.DeptName.DataPropertyName = "Name";
            this.DeptName.HeaderText = "科室名称";
            this.DeptName.Name = "DeptName";
            this.DeptName.ReadOnly = true;
            this.DeptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DeptName.Width = 200;
            // 
            // Num
            // 
            this.Num.DataPropertyName = "Num";
            this.Num.HeaderText = "科室总床位数";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IsUse
            // 
            this.IsUse.DataPropertyName = "IsUse";
            this.IsUse.HeaderText = "已使用床位数";
            this.IsUse.Name = "IsUse";
            this.IsUse.ReadOnly = true;
            this.IsUse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IsUse.Width = 120;
            // 
            // NotUse
            // 
            this.NotUse.DataPropertyName = "NotUse";
            this.NotUse.HeaderText = "空床位数";
            this.NotUse.Name = "NotUse";
            this.NotUse.ReadOnly = true;
            this.NotUse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NotUse.Width = 90;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSBtnQuery,
            this.tSBtnQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(829, 29);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSBtnQuery
            // 
            this.tSBtnQuery.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnQuery.Image")));
            this.tSBtnQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnQuery.Name = "tSBtnQuery";
            this.tSBtnQuery.Size = new System.Drawing.Size(55, 26);
            this.tSBtnQuery.Text = "查询";
            this.tSBtnQuery.Click += new System.EventHandler(this.tSBtnQuery_Click);
            // 
            // tSBtnQuit
            // 
            this.tSBtnQuit.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnQuit.Image")));
            this.tSBtnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnQuit.Name = "tSBtnQuit";
            this.tSBtnQuit.Size = new System.Drawing.Size(55, 26);
            this.tSBtnQuit.Text = "退出";
            this.tSBtnQuit.Click += new System.EventHandler(this.tSBtnQuit_Click);
            // 
            // FrmQueryShow1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 458);
            this.FormTitle = "病区床位查询";
            this.Name = "FrmQueryShow1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmWardBedQuery";
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVEResult)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dGVEResult;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSBtnQuery;
        private System.Windows.Forms.ToolStripButton tSBtnQuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotUse;
    }
}