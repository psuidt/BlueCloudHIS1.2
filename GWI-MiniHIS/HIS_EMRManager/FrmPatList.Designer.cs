namespace HIS_EMRManager
{
    partial class FrmPatList
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
            this.dGVEResult = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.ckbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVEResult
            // 
            this.dGVEResult.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dGVEResult.AllowSortWhenClickColumnHeader = false;
            this.dGVEResult.AllowUserToAddRows = false;
            this.dGVEResult.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVEResult.ColumnHeadersHeight = 28;
            this.dGVEResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVEResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ckbh,
            this.name,
            this.sex,
            this.csrq,
            this.sfz});
            this.dGVEResult.DisplayAllItemWhenSelectionCardShowing = false;
            this.dGVEResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVEResult.EnableHeadersVisualStyles = false;
            this.dGVEResult.HideSelectionCardWhenCustomInput = false;
            this.dGVEResult.Location = new System.Drawing.Point(0, 0);
            this.dGVEResult.MultiSelect = false;
            this.dGVEResult.Name = "dGVEResult";
            this.dGVEResult.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVEResult.RowTemplate.Height = 23;
            this.dGVEResult.SelectionCards = null;
            this.dGVEResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVEResult.Size = new System.Drawing.Size(602, 266);
            this.dGVEResult.TabIndex = 5;
            this.dGVEResult.UseGradientBackgroundColor = true;
            this.dGVEResult.DoubleClick += new System.EventHandler(this.dGVEResult_DoubleClick);
            this.dGVEResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dGVEResult_KeyDown);
            // 
            // ckbh
            // 
            this.ckbh.HeaderText = "磁卡编号";
            this.ckbh.Name = "ckbh";
            this.ckbh.ReadOnly = true;
            this.ckbh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ckbh.Width = 120;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "病人姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name.Width = 80;
            // 
            // sex
            // 
            this.sex.DataPropertyName = "sex";
            this.sex.HeaderText = "性别";
            this.sex.Name = "sex";
            this.sex.ReadOnly = true;
            this.sex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sex.Width = 60;
            // 
            // csrq
            // 
            this.csrq.DataPropertyName = "csrq";
            this.csrq.HeaderText = "出生日期";
            this.csrq.Name = "csrq";
            this.csrq.ReadOnly = true;
            this.csrq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.csrq.Width = 120;
            // 
            // sfz
            // 
            this.sfz.DataPropertyName = "sfz";
            this.sfz.HeaderText = "身份证号";
            this.sfz.Name = "sfz";
            this.sfz.ReadOnly = true;
            this.sfz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sfz.Width = 150;
            // 
            // FrmEmrList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 266);
            this.Controls.Add(this.dGVEResult);
            this.Name = "FrmEmrList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人列表";
            ((System.ComponentModel.ISupportInitialize)(this.dGVEResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dGVEResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ckbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn csrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfz;
    }
}