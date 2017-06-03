namespace HIS_ReportManager
{
    partial class FrmQueryControl
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
            this.button1 = new System.Windows.Forms.Button();
            this.propertyPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // propertyPanel
            // 
            this.propertyPanel.BackColor = System.Drawing.Color.Transparent;
            this.propertyPanel.Location = new System.Drawing.Point(12, 12);
            this.propertyPanel.Name = "propertyPanel";
            this.propertyPanel.Size = new System.Drawing.Size(325, 315);
            this.propertyPanel.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(165, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 360);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.propertyPanel);
            this.Controls.Add(this.button1);
            this.Name = "FrmQueryControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询条件";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel propertyPanel;
        private System.Windows.Forms.Button button2;
    }
}