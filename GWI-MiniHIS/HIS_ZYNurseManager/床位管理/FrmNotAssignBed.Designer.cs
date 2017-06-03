namespace HIS_ZYNurseManager
{
    partial class FrmNotAssignBed
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
            this.label6 = new System.Windows.Forms.Label();
            this.cmbnobed = new System.Windows.Forms.ComboBox();
            this.btntransbed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 10F);
            this.label6.Location = new System.Drawing.Point(21, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "科内现有空床列表:";
            // 
            // cmbnobed
            // 
            this.cmbnobed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbnobed.FormattingEnabled = true;
            this.cmbnobed.Location = new System.Drawing.Point(24, 35);
            this.cmbnobed.Name = "cmbnobed";
            this.cmbnobed.Size = new System.Drawing.Size(131, 20);
            this.cmbnobed.TabIndex = 2;
            // 
            // btntransbed
            // 
            this.btntransbed.Location = new System.Drawing.Point(79, 75);
            this.btntransbed.Name = "btntransbed";
            this.btntransbed.Size = new System.Drawing.Size(52, 25);
            this.btntransbed.TabIndex = 6;
            this.btntransbed.Text = "确定";
            this.btntransbed.UseVisualStyleBackColor = true;
            this.btntransbed.Click += new System.EventHandler(this.btntransbed_Click);
            // 
            // FrmNotAssignBed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(219, 110);
            this.Controls.Add(this.btntransbed);
            this.Controls.Add(this.cmbnobed);
            this.Controls.Add(this.label6);
            this.Name = "FrmNotAssignBed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "科内转床";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbnobed;
        private System.Windows.Forms.Button btntransbed;
    }
}