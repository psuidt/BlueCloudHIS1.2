namespace HIS_MZDocManager
{
    partial class FrmEditMould
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditMould));
            this.plType = new System.Windows.Forms.Panel();
            this.rdBMould = new System.Windows.Forms.RadioButton();
            this.rdBType = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.plMain = new System.Windows.Forms.Panel();
            this.btCancel = new GWI.HIS.Windows.Controls.Button();
            this.btSure = new GWI.HIS.Windows.Controls.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.plType.SuspendLayout();
            this.plMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // plType
            // 
            this.plType.BackColor = System.Drawing.Color.Transparent;
            this.plType.Controls.Add(this.rdBMould);
            this.plType.Controls.Add(this.rdBType);
            this.plType.Controls.Add(this.label1);
            this.plType.Dock = System.Windows.Forms.DockStyle.Top;
            this.plType.Location = new System.Drawing.Point(0, 0);
            this.plType.Name = "plType";
            this.plType.Size = new System.Drawing.Size(342, 53);
            this.plType.TabIndex = 1;
            // 
            // rdBMould
            // 
            this.rdBMould.AutoSize = true;
            this.rdBMould.Location = new System.Drawing.Point(216, 21);
            this.rdBMould.Name = "rdBMould";
            this.rdBMould.Size = new System.Drawing.Size(81, 18);
            this.rdBMould.TabIndex = 2;
            this.rdBMould.Text = "处方模板";
            this.rdBMould.UseVisualStyleBackColor = true;
            // 
            // rdBType
            // 
            this.rdBType.AutoSize = true;
            this.rdBType.Checked = true;
            this.rdBType.Location = new System.Drawing.Point(127, 21);
            this.rdBType.Name = "rdBType";
            this.rdBType.Size = new System.Drawing.Size(81, 18);
            this.rdBType.TabIndex = 1;
            this.rdBType.TabStop = true;
            this.rdBType.Text = "模板分类";
            this.rdBType.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "创建类型：";
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.Color.Transparent;
            this.plMain.Controls.Add(this.btCancel);
            this.plMain.Controls.Add(this.btSure);
            this.plMain.Controls.Add(this.txtName);
            this.plMain.Controls.Add(this.label2);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 53);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(342, 113);
            this.plMain.TabIndex = 0;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btCancel.FixedWidth = true;
            this.btCancel.Location = new System.Drawing.Point(192, 54);
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
            this.btSure.Location = new System.Drawing.Point(72, 54);
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
            this.txtName.Location = new System.Drawing.Point(89, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(210, 23);
            this.txtName.TabIndex = 0;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "名称：";
            // 
            // FrmEditMould
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(342, 166);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.plType);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximumSize = new System.Drawing.Size(350, 200);
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "FrmEditMould";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEditMould";
            this.plType.ResumeLayout(false);
            this.plType.PerformLayout();
            this.plMain.ResumeLayout(false);
            this.plMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plType;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdBType;
        private System.Windows.Forms.RadioButton rdBMould;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private GWI.HIS.Windows.Controls.Button btCancel;
        private GWI.HIS.Windows.Controls.Button btSure;
    }
}