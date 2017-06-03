namespace HIS_YPManager
{
    partial class FrmCheckType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckType));
            this.chkDrugType = new System.Windows.Forms.CheckBox();
            this.cobDrugType = new System.Windows.Forms.ComboBox();
            this.chkDrugDose = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cobDrugDose = new System.Windows.Forms.ComboBox();
            this.chkIsHaveStore = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkDrugType
            // 
            this.chkDrugType.AutoSize = true;
            this.chkDrugType.BackColor = System.Drawing.Color.Transparent;
            this.chkDrugType.Location = new System.Drawing.Point(12, 12);
            this.chkDrugType.Name = "chkDrugType";
            this.chkDrugType.Size = new System.Drawing.Size(82, 18);
            this.chkDrugType.TabIndex = 0;
            this.chkDrugType.Text = "商品类型";
            this.chkDrugType.UseVisualStyleBackColor = false;
            this.chkDrugType.CheckedChanged += new System.EventHandler(this.chkDrugType_CheckedChanged);
            // 
            // cobDrugType
            // 
            this.cobDrugType.Enabled = false;
            this.cobDrugType.FormattingEnabled = true;
            this.cobDrugType.Location = new System.Drawing.Point(98, 10);
            this.cobDrugType.Name = "cobDrugType";
            this.cobDrugType.Size = new System.Drawing.Size(140, 21);
            this.cobDrugType.TabIndex = 1;
            this.cobDrugType.SelectedIndexChanged += new System.EventHandler(this.cobDrugType_SelectedIndexChanged);
            // 
            // chkDrugDose
            // 
            this.chkDrugDose.AutoSize = true;
            this.chkDrugDose.BackColor = System.Drawing.Color.Transparent;
            this.chkDrugDose.Location = new System.Drawing.Point(12, 43);
            this.chkDrugDose.Name = "chkDrugDose";
            this.chkDrugDose.Size = new System.Drawing.Size(54, 18);
            this.chkDrugDose.TabIndex = 2;
            this.chkDrugDose.Text = "剂型";
            this.chkDrugDose.UseVisualStyleBackColor = false;
            this.chkDrugDose.CheckedChanged += new System.EventHandler(this.chkDrugDose_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(93, 93);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(173, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cobDrugDose
            // 
            this.cobDrugDose.Enabled = false;
            this.cobDrugDose.FormattingEnabled = true;
            this.cobDrugDose.Location = new System.Drawing.Point(98, 41);
            this.cobDrugDose.Name = "cobDrugDose";
            this.cobDrugDose.Size = new System.Drawing.Size(140, 21);
            this.cobDrugDose.TabIndex = 5;
            this.cobDrugDose.SelectedIndexChanged += new System.EventHandler(this.cobDrugDose_SelectedIndexChanged);
            // 
            // chkIsHaveStore
            // 
            this.chkIsHaveStore.AutoSize = true;
            this.chkIsHaveStore.BackColor = System.Drawing.Color.Transparent;
            this.chkIsHaveStore.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkIsHaveStore.Location = new System.Drawing.Point(12, 69);
            this.chkIsHaveStore.Name = "chkIsHaveStore";
            this.chkIsHaveStore.Size = new System.Drawing.Size(169, 18);
            this.chkIsHaveStore.TabIndex = 6;
            this.chkIsHaveStore.Text = "仅盘库存不为0的药品";
            this.chkIsHaveStore.UseVisualStyleBackColor = false;
            this.chkIsHaveStore.CheckedChanged += new System.EventHandler(this.chkIsHaveStore_CheckedChanged);
            // 
            // FrmCheckType
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(247, 130);
            this.Controls.Add(this.chkIsHaveStore);
            this.Controls.Add(this.cobDrugDose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkDrugDose);
            this.Controls.Add(this.cobDrugType);
            this.Controls.Add(this.chkDrugType);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCheckType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据选择";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmCheckType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.CheckBox chkDrugType;
        public System.Windows.Forms.ComboBox cobDrugType;
        public System.Windows.Forms.CheckBox chkDrugDose;
        public System.Windows.Forms.ComboBox cobDrugDose;
        private System.Windows.Forms.CheckBox chkIsHaveStore;
    }
}