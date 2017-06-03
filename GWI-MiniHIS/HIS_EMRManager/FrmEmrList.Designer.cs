namespace HIS_EMRManager
{
    partial class FrmEmrList
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
            // FrmEmrList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 266);
            this.Controls.Add(this.dGVEResult);
            this.Name = "FrmEmrList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病历列表";
            ((System.ComponentModel.ISupportInitialize)(this.dGVEResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dGVEResult;
    }
}