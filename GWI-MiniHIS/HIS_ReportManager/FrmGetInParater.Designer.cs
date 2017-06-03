namespace HIS_ReportManager
{
    partial class FrmGetInParater
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
            this.plEditControl = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plEditControl
            // 
            this.plEditControl.AutoScroll = true;
            this.plEditControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plEditControl.Location = new System.Drawing.Point(0, 0);
            this.plEditControl.Name = "plEditControl";
            this.plEditControl.Size = new System.Drawing.Size(549, 129);
            this.plEditControl.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.plEditControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 129);
            this.panel1.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(3, 135);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmGetInParater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 165);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(2, 3);
            this.Name = "FrmGetInParater";
            this.Text = "获取入参";
            this.Load += new System.EventHandler(this.FrmGetInParater_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plEditControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;

       
    }
}