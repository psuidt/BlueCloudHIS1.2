namespace HIS_MZDocManager
{
    partial class FrmApplyMould
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GVEApplyMould = new System.Windows.Forms.DataGridView();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this._rdbLevelP = new System.Windows.Forms.RadioButton();
            this._rdbLevelD = new System.Windows.Forms.RadioButton();
            this._rdbLevelH = new System.Windows.Forms.RadioButton();
            this.btSure = new System.Windows.Forms.Button();
            this.btQuit = new System.Windows.Forms.Button();
            this.txtMouldText = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.院级模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.科级模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVEApplyMould)).BeginInit();
            this.panel3.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.panel1.Controls.Add(this.GVEApplyMould);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 310);
            this.panel1.TabIndex = 0;
            // 
            // GVEApplyMould
            // 
            this.GVEApplyMould.AllowUserToAddRows = false;
            this.GVEApplyMould.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.GVEApplyMould.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GVEApplyMould.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(192)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GVEApplyMould.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GVEApplyMould.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GVEApplyMould.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Content});
            this.GVEApplyMould.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVEApplyMould.EnableHeadersVisualStyles = false;
            this.GVEApplyMould.Location = new System.Drawing.Point(0, 28);
            this.GVEApplyMould.MultiSelect = false;
            this.GVEApplyMould.Name = "GVEApplyMould";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(192)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GVEApplyMould.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GVEApplyMould.RowHeadersWidth = 25;
            this.GVEApplyMould.RowTemplate.Height = 23;
            this.GVEApplyMould.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GVEApplyMould.Size = new System.Drawing.Size(390, 282);
            this.GVEApplyMould.TabIndex = 1;
            this.GVEApplyMould.DoubleClick += new System.EventHandler(this.GVEApplyMould_DoubleClick);
            // 
            // Content
            // 
            this.Content.DataPropertyName = "Content";
            this.Content.HeaderText = "内容";
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            this.Content.Width = 320;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._rdbLevelP);
            this.panel3.Controls.Add(this._rdbLevelD);
            this.panel3.Controls.Add(this._rdbLevelH);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 28);
            this.panel3.TabIndex = 0;
            // 
            // _rdbLevelP
            // 
            this._rdbLevelP.AutoSize = true;
            this._rdbLevelP.Location = new System.Drawing.Point(133, 6);
            this._rdbLevelP.Name = "_rdbLevelP";
            this._rdbLevelP.Size = new System.Drawing.Size(47, 16);
            this._rdbLevelP.TabIndex = 6;
            this._rdbLevelP.Tag = "3";
            this._rdbLevelP.Text = "个人";
            this._rdbLevelP.UseVisualStyleBackColor = true;
            this._rdbLevelP.CheckedChanged += new System.EventHandler(this._rdbLevel_CheckedChanged);
            // 
            // _rdbLevelD
            // 
            this._rdbLevelD.AutoSize = true;
            this._rdbLevelD.Location = new System.Drawing.Point(83, 6);
            this._rdbLevelD.Name = "_rdbLevelD";
            this._rdbLevelD.Size = new System.Drawing.Size(47, 16);
            this._rdbLevelD.TabIndex = 5;
            this._rdbLevelD.Tag = "2";
            this._rdbLevelD.Text = "科级";
            this._rdbLevelD.UseVisualStyleBackColor = true;
            this._rdbLevelD.CheckedChanged += new System.EventHandler(this._rdbLevel_CheckedChanged);
            // 
            // _rdbLevelH
            // 
            this._rdbLevelH.AutoSize = true;
            this._rdbLevelH.Checked = true;
            this._rdbLevelH.Location = new System.Drawing.Point(33, 6);
            this._rdbLevelH.Name = "_rdbLevelH";
            this._rdbLevelH.Size = new System.Drawing.Size(47, 16);
            this._rdbLevelH.TabIndex = 4;
            this._rdbLevelH.TabStop = true;
            this._rdbLevelH.Tag = "1";
            this._rdbLevelH.Text = "院级";
            this._rdbLevelH.UseVisualStyleBackColor = true;
            this._rdbLevelH.CheckedChanged += new System.EventHandler(this._rdbLevel_CheckedChanged);
            // 
            // btSure
            // 
            this.btSure.Location = new System.Drawing.Point(99, 455);
            this.btSure.Name = "btSure";
            this.btSure.Size = new System.Drawing.Size(75, 23);
            this.btSure.TabIndex = 2;
            this.btSure.Text = "确定";
            this.btSure.UseVisualStyleBackColor = true;
            this.btSure.Click += new System.EventHandler(this.btSure_Click);
            // 
            // btQuit
            // 
            this.btQuit.Location = new System.Drawing.Point(261, 455);
            this.btQuit.Name = "btQuit";
            this.btQuit.Size = new System.Drawing.Size(75, 23);
            this.btQuit.TabIndex = 3;
            this.btQuit.Text = "退出";
            this.btQuit.UseVisualStyleBackColor = true;
            this.btQuit.Click += new System.EventHandler(this.btQuit_Click);
            // 
            // txtMouldText
            // 
            this.txtMouldText.Location = new System.Drawing.Point(5, 320);
            this.txtMouldText.Multiline = true;
            this.txtMouldText.Name = "txtMouldText";
            this.txtMouldText.Size = new System.Drawing.Size(390, 125);
            this.txtMouldText.TabIndex = 0;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(180, 455);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 4;
            this.btSave.Text = "另存为";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.院级模板ToolStripMenuItem,
            this.科级模板ToolStripMenuItem,
            this.个人模板ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(119, 70);
            // 
            // 院级模板ToolStripMenuItem
            // 
            this.院级模板ToolStripMenuItem.Name = "院级模板ToolStripMenuItem";
            this.院级模板ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.院级模板ToolStripMenuItem.Tag = "1";
            this.院级模板ToolStripMenuItem.Text = "院级模板";
            this.院级模板ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 科级模板ToolStripMenuItem
            // 
            this.科级模板ToolStripMenuItem.Name = "科级模板ToolStripMenuItem";
            this.科级模板ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.科级模板ToolStripMenuItem.Tag = "2";
            this.科级模板ToolStripMenuItem.Text = "科级模板";
            this.科级模板ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 个人模板ToolStripMenuItem
            // 
            this.个人模板ToolStripMenuItem.Name = "个人模板ToolStripMenuItem";
            this.个人模板ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.个人模板ToolStripMenuItem.Tag = "3";
            this.个人模板ToolStripMenuItem.Text = "个人模板";
            this.个人模板ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // FrmApplyMould
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 490);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtMouldText);
            this.Controls.Add(this.btQuit);
            this.Controls.Add(this.btSure);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.Name = "FrmApplyMould";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医技申请模板";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVEApplyMould)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView GVEApplyMould;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton _rdbLevelP;
        private System.Windows.Forms.RadioButton _rdbLevelD;
        private System.Windows.Forms.RadioButton _rdbLevelH;
        private System.Windows.Forms.Button btSure;
        private System.Windows.Forms.Button btQuit;
        private System.Windows.Forms.TextBox txtMouldText;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 院级模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 科级模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人模板ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
    }
}