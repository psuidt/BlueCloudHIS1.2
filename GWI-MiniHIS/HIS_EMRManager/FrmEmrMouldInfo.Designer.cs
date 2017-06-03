namespace HIS_EMRManager
{
    partial class FrmEmrMouldInfo
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
            this.btCancel = new GWI.HIS.Windows.Controls.Button();
            this.btSure = new GWI.HIS.Windows.Controls.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btCancel.FixedWidth = true;
            this.btCancel.Location = new System.Drawing.Point(172, 81);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(90, 25);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btSure
            // 
            this.btSure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btSure.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btSure.FixedWidth = true;
            this.btSure.Location = new System.Drawing.Point(52, 81);
            this.btSure.Name = "btSure";
            this.btSure.Size = new System.Drawing.Size(90, 25);
            this.btSure.TabIndex = 1;
            this.btSure.Text = "确定";
            this.btSure.UseVisualStyleBackColor = true;
            this.btSure.Click += new System.EventHandler(this.btSure_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(52, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(210, 21);
            this.txtName.TabIndex = 0;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "名称：";
            // 
            // FrmEmrMouldInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(292, 134);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSure);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Name = "FrmEmrMouldInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板名称";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GWI.HIS.Windows.Controls.Button btCancel;
        private GWI.HIS.Windows.Controls.Button btSure;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
    }
}