namespace HIS_YPManager
{
    partial class FrmDeptSetType
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
            this.chkZY = new System.Windows.Forms.CheckBox();
            this.chkXY = new System.Windows.Forms.CheckBox();
            this.chkZCY = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkWZ = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkZY
            // 
            this.chkZY.AutoSize = true;
            this.chkZY.BackColor = System.Drawing.Color.Transparent;
            this.chkZY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkZY.Location = new System.Drawing.Point(12, 12);
            this.chkZY.Name = "chkZY";
            this.chkZY.Size = new System.Drawing.Size(59, 20);
            this.chkZY.TabIndex = 0;
            this.chkZY.Text = "中药";
            this.chkZY.UseVisualStyleBackColor = false;
            // 
            // chkXY
            // 
            this.chkXY.AutoSize = true;
            this.chkXY.BackColor = System.Drawing.Color.Transparent;
            this.chkXY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkXY.Location = new System.Drawing.Point(12, 38);
            this.chkXY.Name = "chkXY";
            this.chkXY.Size = new System.Drawing.Size(59, 20);
            this.chkXY.TabIndex = 1;
            this.chkXY.Text = "西药";
            this.chkXY.UseVisualStyleBackColor = false;
            // 
            // chkZCY
            // 
            this.chkZCY.AutoSize = true;
            this.chkZCY.BackColor = System.Drawing.Color.Transparent;
            this.chkZCY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkZCY.Location = new System.Drawing.Point(12, 64);
            this.chkZCY.Name = "chkZCY";
            this.chkZCY.Size = new System.Drawing.Size(75, 20);
            this.chkZCY.TabIndex = 2;
            this.chkZCY.Text = "中成药";
            this.chkZCY.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(101, 18);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(100, 63);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkWZ
            // 
            this.chkWZ.AutoSize = true;
            this.chkWZ.BackColor = System.Drawing.Color.Transparent;
            this.chkWZ.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkWZ.Location = new System.Drawing.Point(12, 90);
            this.chkWZ.Name = "chkWZ";
            this.chkWZ.Size = new System.Drawing.Size(59, 20);
            this.chkWZ.TabIndex = 5;
            this.chkWZ.Text = "物资";
            this.chkWZ.UseVisualStyleBackColor = false;
            // 
            // FrmDeptSetType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 114);
            this.Controls.Add(this.chkWZ);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkZCY);
            this.Controls.Add(this.chkXY);
            this.Controls.Add(this.chkZY);
            this.Name = "FrmDeptSetType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择药品类型";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkZY;
        private System.Windows.Forms.CheckBox chkXY;
        private System.Windows.Forms.CheckBox chkZCY;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkWZ;
    }
}