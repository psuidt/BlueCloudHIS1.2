namespace HIS_YPManager
{
    partial class FrmSupportHis
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSupportHis));
            this.dgrdSupportHis = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.ColBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSupportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRegTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBatchNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdSupportHis)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrdSupportHis
            // 
            this.dgrdSupportHis.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdSupportHis.AllowSortWhenClickColumnHeader = false;
            this.dgrdSupportHis.AllowUserToAddRows = false;
            this.dgrdSupportHis.AllowUserToDeleteRows = false;
            this.dgrdSupportHis.AllowUserToResizeColumns = false;
            this.dgrdSupportHis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdSupportHis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdSupportHis.ColumnHeadersHeight = 30;
            this.dgrdSupportHis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColBillNo,
            this.ColSupportName,
            this.ColRegTime,
            this.ColInNum,
            this.ColBatchNum});
            this.dgrdSupportHis.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgrdSupportHis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdSupportHis.EnableHeadersVisualStyles = false;
            this.dgrdSupportHis.HideSelectionCardWhenCustomInput = false;
            this.dgrdSupportHis.Location = new System.Drawing.Point(0, 0);
            this.dgrdSupportHis.MultiSelect = false;
            this.dgrdSupportHis.Name = "dgrdSupportHis";
            this.dgrdSupportHis.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdSupportHis.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgrdSupportHis.RowHeadersVisible = false;
            this.dgrdSupportHis.RowTemplate.Height = 23;
            this.dgrdSupportHis.SelectionCards = null;
            this.dgrdSupportHis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdSupportHis.Size = new System.Drawing.Size(466, 324);
            this.dgrdSupportHis.TabIndex = 0;
            this.dgrdSupportHis.UseGradientBackgroundColor = true;
            // 
            // ColBillNo
            // 
            this.ColBillNo.DataPropertyName = "BILLNUM";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColBillNo.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColBillNo.HeaderText = "单据号";
            this.ColBillNo.Name = "ColBillNo";
            this.ColBillNo.ReadOnly = true;
            this.ColBillNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColBillNo.Width = 50;
            // 
            // ColSupportName
            // 
            this.ColSupportName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColSupportName.DataPropertyName = "SUPPORTNAME";
            this.ColSupportName.FillWeight = 37.03703F;
            this.ColSupportName.HeaderText = "供应商";
            this.ColSupportName.Name = "ColSupportName";
            this.ColSupportName.ReadOnly = true;
            this.ColSupportName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColRegTime
            // 
            this.ColRegTime.DataPropertyName = "REGTIME";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColRegTime.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColRegTime.FillWeight = 162.963F;
            this.ColRegTime.HeaderText = "入库时间";
            this.ColRegTime.Name = "ColRegTime";
            this.ColRegTime.ReadOnly = true;
            this.ColRegTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColRegTime.Width = 120;
            // 
            // ColInNum
            // 
            this.ColInNum.DataPropertyName = "INNUM";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N3";
            this.ColInNum.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColInNum.HeaderText = "入库数量";
            this.ColInNum.Name = "ColInNum";
            this.ColInNum.ReadOnly = true;
            this.ColInNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColInNum.Width = 60;
            // 
            // ColBatchNum
            // 
            this.ColBatchNum.DataPropertyName = "BATCHNUM";
            this.ColBatchNum.HeaderText = "批次号";
            this.ColBatchNum.Name = "ColBatchNum";
            this.ColBatchNum.ReadOnly = true;
            this.ColBatchNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColBatchNum.Width = 60;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.dgrdSupportHis);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 324);
            this.panel1.TabIndex = 1;
            // 
            // btnQuit
            // 
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.Location = new System.Drawing.Point(0, 0);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(74, 29);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "关闭(&C)";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnQuit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 29);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(466, 324);
            this.panel3.TabIndex = 4;
            // 
            // FrmSupportHis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(466, 353);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "FrmSupportHis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "供应历史记录查询";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdSupportHis)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdSupportHis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSupportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRegTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBatchNum;
        private System.Windows.Forms.Panel panel3;
    }
}