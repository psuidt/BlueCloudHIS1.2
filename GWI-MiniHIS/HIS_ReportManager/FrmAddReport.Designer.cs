namespace HIS_ReportManager
{
    partial class FrmAddReport
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
            this.txtRepotName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProcessName1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRmark1 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtRmark = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtProcessName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtRepotName
            // 
            this.txtRepotName.Location = new System.Drawing.Point(83, 6);
            this.txtRepotName.Name = "txtRepotName";
            this.txtRepotName.Size = new System.Drawing.Size(184, 21);
            this.txtRepotName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "报表名称：";
            // 
            // txtProcessName1
            // 
            this.txtProcessName1.Location = new System.Drawing.Point(14, 70);
            this.txtProcessName1.Name = "txtProcessName1";
            this.txtProcessName1.Size = new System.Drawing.Size(53, 21);
            this.txtProcessName1.TabIndex = 2;
            this.txtProcessName1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "存储过程：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "备  注：";
            // 
            // txtRmark1
            // 
            this.txtRmark1.Location = new System.Drawing.Point(24, 97);
            this.txtRmark1.Multiline = true;
            this.txtRmark1.Name = "txtRmark1";
            this.txtRmark1.Size = new System.Drawing.Size(53, 21);
            this.txtRmark1.TabIndex = 5;
            this.txtRmark1.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(49, 95);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtRmark
            // 
            this.txtRmark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRmark.FormattingEnabled = true;
            this.txtRmark.Items.AddRange(new object[] {
            "明细报表",
            "大类统计表",
            "交叉报表"});
            this.txtRmark.Location = new System.Drawing.Point(83, 64);
            this.txtRmark.Name = "txtRmark";
            this.txtRmark.Size = new System.Drawing.Size(184, 20);
            this.txtRmark.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtProcessName
            // 
            this.txtProcessName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtProcessName.FormattingEnabled = true;
            this.txtProcessName.Location = new System.Drawing.Point(83, 35);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(184, 20);
            this.txtProcessName.TabIndex = 9;
            // 
            // FrmAddReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(282, 128);
            this.Controls.Add(this.txtProcessName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRmark);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtRmark1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProcessName1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRepotName);
            this.Name = "FrmAddReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报表信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRepotName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProcessName1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRmark1;
        internal System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox txtRmark;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox txtProcessName;
    }
}