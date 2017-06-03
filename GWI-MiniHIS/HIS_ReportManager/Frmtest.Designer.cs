namespace HIS_ReportManager
{
    partial class Frmtest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmtest));
            this.panel1 = new System.Windows.Forms.Panel();
            this.axGDVshowReport = new AxgrproLib.AxGRDisplayViewer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGDVshowReport)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.axGDVshowReport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 333);
            this.panel1.TabIndex = 0;
            // 
            // axGDVshowReport
            // 
            this.axGDVshowReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axGDVshowReport.Enabled = true;
            this.axGDVshowReport.Location = new System.Drawing.Point(0, 0);
            this.axGDVshowReport.Name = "axGDVshowReport";
            this.axGDVshowReport.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGDVshowReport.OcxState")));
            this.axGDVshowReport.Size = new System.Drawing.Size(699, 333);
            this.axGDVshowReport.TabIndex = 1;
            // 
            // Frmtest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(699, 333);
            this.Controls.Add(this.panel1);
            this.Name = "Frmtest";
            this.Text = "报表预览";
            this.Load += new System.EventHandler(this.Frmtest_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axGDVshowReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private AxgrproLib.AxGRDisplayViewer axGDVshowReport;
    }
}