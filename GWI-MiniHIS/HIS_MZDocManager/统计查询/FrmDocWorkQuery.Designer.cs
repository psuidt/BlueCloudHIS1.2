namespace HIS_MZDocManager
{
    partial class FrmDocWorkQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocWorkQuery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dTPkBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dTPkEnd = new System.Windows.Forms.DateTimePicker();
            this.btQuery = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dGVResult = new System.Windows.Forms.DataGridView();
            this.Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbCaption = new System.Windows.Forms.Label();
            this.plGraph = new System.Windows.Forms.Panel();
            this.rdBCaky = new System.Windows.Forms.RadioButton();
            this.rdBHistogram = new System.Windows.Forms.RadioButton();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResult)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.rdBHistogram);
            this.plBaseToolbar.Controls.Add(this.rdBCaky);
            this.plBaseToolbar.Controls.Add(this.btClose);
            this.plBaseToolbar.Controls.Add(this.btQuery);
            this.plBaseToolbar.Controls.Add(this.dTPkEnd);
            this.plBaseToolbar.Controls.Add(this.label2);
            this.plBaseToolbar.Controls.Add(this.label1);
            this.plBaseToolbar.Controls.Add(this.dTPkBegin);
            this.plBaseToolbar.Size = new System.Drawing.Size(930, 38);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 446);
            this.plBaseStatus.Size = new System.Drawing.Size(930, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.plBaseWorkArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plBaseWorkArea.Controls.Add(this.plGraph);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plBaseWorkArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 72);
            this.plBaseWorkArea.Size = new System.Drawing.Size(930, 374);
            // 
            // dTPkBegin
            // 
            this.dTPkBegin.Location = new System.Drawing.Point(133, 7);
            this.dTPkBegin.Name = "dTPkBegin";
            this.dTPkBegin.Size = new System.Drawing.Size(118, 21);
            this.dTPkBegin.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "统计时间：从";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "到";
            // 
            // dTPkEnd
            // 
            this.dTPkEnd.Location = new System.Drawing.Point(280, 7);
            this.dTPkEnd.Name = "dTPkEnd";
            this.dTPkEnd.Size = new System.Drawing.Size(118, 21);
            this.dTPkEnd.TabIndex = 3;
            // 
            // btQuery
            // 
            this.btQuery.Image = ((System.Drawing.Image)(resources.GetObject("btQuery.Image")));
            this.btQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btQuery.Location = new System.Drawing.Point(433, 6);
            this.btQuery.Name = "btQuery";
            this.btQuery.Size = new System.Drawing.Size(75, 23);
            this.btQuery.TabIndex = 4;
            this.btQuery.Text = "查询";
            this.btQuery.UseVisualStyleBackColor = true;
            this.btQuery.Click += new System.EventHandler(this.btQuery_Click);
            // 
            // btClose
            // 
            this.btClose.Image = ((System.Drawing.Image)(resources.GetObject("btClose.Image")));
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(528, 6);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "退出";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dGVResult);
            this.panel1.Controls.Add(this.lbCaption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 372);
            this.panel1.TabIndex = 2;
            // 
            // dGVResult
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            this.dGVResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dGVResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(192)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dGVResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item_Name,
            this.Money});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVResult.DefaultCellStyle = dataGridViewCellStyle6;
            this.dGVResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVResult.EnableHeadersVisualStyles = false;
            this.dGVResult.Location = new System.Drawing.Point(0, 35);
            this.dGVResult.Name = "dGVResult";
            this.dGVResult.RowHeadersVisible = false;
            this.dGVResult.RowTemplate.Height = 23;
            this.dGVResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVResult.Size = new System.Drawing.Size(200, 337);
            this.dGVResult.TabIndex = 1;
            this.dGVResult.Visible = false;
            // 
            // Item_Name
            // 
            this.Item_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item_Name.DataPropertyName = "Item_Name";
            this.Item_Name.HeaderText = "项目类型";
            this.Item_Name.Name = "Item_Name";
            this.Item_Name.ReadOnly = true;
            // 
            // Money
            // 
            this.Money.DataPropertyName = "Money";
            this.Money.HeaderText = "金额";
            this.Money.Name = "Money";
            this.Money.ReadOnly = true;
            // 
            // lbCaption
            // 
            this.lbCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(192)))), ((int)(((byte)(216)))));
            this.lbCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCaption.Location = new System.Drawing.Point(0, 0);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(200, 35);
            this.lbCaption.TabIndex = 0;
            this.lbCaption.Text = "看诊人次共计：0人";
            this.lbCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbCaption.Visible = false;
            // 
            // plGraph
            // 
            this.plGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plGraph.Location = new System.Drawing.Point(200, 0);
            this.plGraph.Name = "plGraph";
            this.plGraph.Size = new System.Drawing.Size(728, 372);
            this.plGraph.TabIndex = 3;
            // 
            // rdBCaky
            // 
            this.rdBCaky.AutoSize = true;
            this.rdBCaky.Checked = true;
            this.rdBCaky.Location = new System.Drawing.Point(655, 9);
            this.rdBCaky.Name = "rdBCaky";
            this.rdBCaky.Size = new System.Drawing.Size(59, 16);
            this.rdBCaky.TabIndex = 6;
            this.rdBCaky.TabStop = true;
            this.rdBCaky.Text = "饼状图";
            this.rdBCaky.UseVisualStyleBackColor = true;
            this.rdBCaky.CheckedChanged += new System.EventHandler(this.rdBCaky_CheckedChanged);
            // 
            // rdBHistogram
            // 
            this.rdBHistogram.AutoSize = true;
            this.rdBHistogram.Location = new System.Drawing.Point(721, 9);
            this.rdBHistogram.Name = "rdBHistogram";
            this.rdBHistogram.Size = new System.Drawing.Size(59, 16);
            this.rdBHistogram.TabIndex = 7;
            this.rdBHistogram.Text = "柱状图";
            this.rdBHistogram.UseVisualStyleBackColor = true;
            // 
            // FrmDocWorkQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 472);
            this.FormTitle = "医生工作量统计";
            this.Name = "FrmDocWorkQuery";
            this.Text = "医生工作量统计";
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dTPkBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btQuery;
        private System.Windows.Forms.DateTimePicker dTPkEnd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dGVResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
        private System.Windows.Forms.Label lbCaption;
        private System.Windows.Forms.Panel plGraph;
        private System.Windows.Forms.RadioButton rdBCaky;
        private System.Windows.Forms.RadioButton rdBHistogram;
    }
}