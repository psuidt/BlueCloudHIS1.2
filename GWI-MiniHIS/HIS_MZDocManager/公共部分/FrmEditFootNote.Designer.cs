namespace HIS_MZDocManager
{
    partial class FrmEditFootNote
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBFootNote = new System.Windows.Forms.ComboBox();
            this.txtFootNote = new System.Windows.Forms.TextBox();
            this.btSure = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbClose = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(58, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择脚注";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label2.Location = new System.Drawing.Point(58, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "编辑脚注";
            // 
            // cbBFootNote
            // 
            this.cbBFootNote.FormattingEnabled = true;
            this.cbBFootNote.Items.AddRange(new object[] {
            "先煎",
            "后下",
            "包煎",
            "另煎",
            "另包",
            "烊化",
            "冲服",
            "煎汤代水"});
            this.cbBFootNote.Location = new System.Drawing.Point(129, 59);
            this.cbBFootNote.Name = "cbBFootNote";
            this.cbBFootNote.Size = new System.Drawing.Size(184, 20);
            this.cbBFootNote.TabIndex = 2;
            this.cbBFootNote.SelectedIndexChanged += new System.EventHandler(this.cbBFootNote_SelectedIndexChanged);
            // 
            // txtFootNote
            // 
            this.txtFootNote.Location = new System.Drawing.Point(129, 92);
            this.txtFootNote.Name = "txtFootNote";
            this.txtFootNote.Size = new System.Drawing.Size(184, 21);
            this.txtFootNote.TabIndex = 3;
            // 
            // btSure
            // 
            this.btSure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(113)))), ((int)(((byte)(159)))));
            this.btSure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSure.ForeColor = System.Drawing.Color.White;
            this.btSure.Location = new System.Drawing.Point(96, 134);
            this.btSure.Name = "btSure";
            this.btSure.Size = new System.Drawing.Size(75, 23);
            this.btSure.TabIndex = 4;
            this.btSure.Text = "确定";
            this.btSure.UseVisualStyleBackColor = false;
            this.btSure.Click += new System.EventHandler(this.btSure_Click);
            // 
            // btClear
            // 
            this.btClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(113)))), ((int)(((byte)(159)))));
            this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClear.ForeColor = System.Drawing.Color.White;
            this.btClear.Location = new System.Drawing.Point(224, 134);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 5;
            this.btClear.Text = "清空";
            this.btClear.UseVisualStyleBackColor = false;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(192)))), ((int)(((byte)(216)))));
            this.panel2.Controls.Add(this.lbClose);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 26);
            this.panel2.TabIndex = 8;
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lbClose.Location = new System.Drawing.Point(318, 7);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(53, 12);
            this.lbClose.TabIndex = 9;
            this.lbClose.Text = "关闭窗口";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label7.Location = new System.Drawing.Point(12, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "中药脚注";
            // 
            // FrmEditFootNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(376, 190);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btSure);
            this.Controls.Add(this.txtFootNote);
            this.Controls.Add(this.cbBFootNote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(376, 190);
            this.MinimumSize = new System.Drawing.Size(376, 190);
            this.Name = "FrmEditFootNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中药脚注";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBFootNote;
        private System.Windows.Forms.TextBox txtFootNote;
        private System.Windows.Forms.Button btSure;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbClose;
    }
}