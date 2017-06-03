namespace HIS_MZManager.Report
{
    partial class FrmDocIincomeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocIincomeReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnStat = new System.Windows.Forms.Button();
            this.dgvReport = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.dgvTotalInfo = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseStatus.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.label6);
            this.plBaseToolbar.Controls.Add(this.dtpEnd);
            this.plBaseToolbar.Controls.Add(this.dtpFrom);
            this.plBaseToolbar.Controls.Add(this.btnClose);
            this.plBaseToolbar.Controls.Add(this.btnPrint);
            this.plBaseToolbar.Controls.Add(this.btnStat);
            this.plBaseToolbar.Size = new System.Drawing.Size(893, 35);
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
            this.plBaseStatus.Controls.Add(this.dgvTotalInfo);
            this.plBaseStatus.Location = new System.Drawing.Point(0, 316);
            this.plBaseStatus.Size = new System.Drawing.Size(893, 103);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.dgvReport);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 69);
            this.plBaseWorkArea.Size = new System.Drawing.Size(893, 247);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 43;
            this.label6.Text = "统计时间";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(216, 6);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(146, 21);
            this.dtpEnd.TabIndex = 39;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(64, 6);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(146, 21);
            this.dtpFrom.TabIndex = 38;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(515, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 23);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(441, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(68, 23);
            this.btnPrint.TabIndex = 41;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnStat
            // 
            this.btnStat.Location = new System.Drawing.Point(368, 5);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(68, 23);
            this.btnStat.TabIndex = 40;
            this.btnStat.Text = "统计";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvReport.AllowSortWhenClickColumnHeader = false;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvReport.ColumnHeadersHeight = 30;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReport.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.HideSelectionCardWhenCustomInput = false;
            this.dgvReport.Location = new System.Drawing.Point(0, 0);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvReport.RowTemplate.Height = 23;
            this.dgvReport.SelectionCards = null;
            this.dgvReport.Size = new System.Drawing.Size(893, 247);
            this.dgvReport.TabIndex = 1;
            this.dgvReport.UseGradientBackgroundColor = false;
            // 
            // dgvTotalInfo
            // 
            this.dgvTotalInfo.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvTotalInfo.AllowSortWhenClickColumnHeader = false;
            this.dgvTotalInfo.AllowUserToAddRows = false;
            this.dgvTotalInfo.AllowUserToDeleteRows = false;
            this.dgvTotalInfo.AllowUserToResizeRows = false;
            this.dgvTotalInfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvTotalInfo.ColumnHeadersHeight = 30;
            this.dgvTotalInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTotalInfo.ColumnHeadersVisible = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotalInfo.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvTotalInfo.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvTotalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTotalInfo.EnableHeadersVisualStyles = false;
            this.dgvTotalInfo.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTotalInfo.HideSelectionCardWhenCustomInput = false;
            this.dgvTotalInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvTotalInfo.Name = "dgvTotalInfo";
            this.dgvTotalInfo.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvTotalInfo.RowHeadersVisible = false;
            this.dgvTotalInfo.RowTemplate.Height = 57;
            this.dgvTotalInfo.SelectionCards = null;
            this.dgvTotalInfo.Size = new System.Drawing.Size(893, 103);
            this.dgvTotalInfo.TabIndex = 2;
            this.dgvTotalInfo.UseGradientBackgroundColor = false;
            // 
            // FrmDocIincomeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 419);
            this.Name = "FrmDocIincomeReport";
            this.Text = "FrmDocIincomeReport";
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseStatus.ResumeLayout(false);
            this.plBaseWorkArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnStat;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvReport;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvTotalInfo;
    }
}