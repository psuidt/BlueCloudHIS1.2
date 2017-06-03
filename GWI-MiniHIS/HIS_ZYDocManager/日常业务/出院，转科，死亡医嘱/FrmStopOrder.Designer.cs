namespace HIS_ZYDocManager.日常业务
{
    partial class FrmStopOrder
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
            this.btnYes = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtime_end = new System.Windows.Forms.DateTimePicker();
            this.radDefault = new System.Windows.Forms.RadioButton();
            this.radAlter = new System.Windows.Forms.RadioButton();
            this.lbendtimes = new System.Windows.Forms.Label();
            this.NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.lbNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "停嘱时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(24, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "末日执行次数：";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(37, 75);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(64, 22);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "确 定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(152, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 22);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtime_end
            // 
            this.dtime_end.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtime_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtime_end.Location = new System.Drawing.Point(83, 5);
            this.dtime_end.Name = "dtime_end";
            this.dtime_end.Size = new System.Drawing.Size(150, 21);
            this.dtime_end.TabIndex = 4;
            this.dtime_end.ValueChanged += new System.EventHandler(this.dtime_end_ValueChanged);
            // 
            // radDefault
            // 
            this.radDefault.AutoSize = true;
            this.radDefault.BackColor = System.Drawing.Color.Transparent;
            this.radDefault.Checked = true;
            this.radDefault.Location = new System.Drawing.Point(26, 53);
            this.radDefault.Name = "radDefault";
            this.radDefault.Size = new System.Drawing.Size(59, 16);
            this.radDefault.TabIndex = 5;
            this.radDefault.TabStop = true;
            this.radDefault.Text = "默认值";
            this.radDefault.UseVisualStyleBackColor = false;
            this.radDefault.CheckedChanged += new System.EventHandler(this.radDefault_CheckedChanged);
            // 
            // radAlter
            // 
            this.radAlter.AutoSize = true;
            this.radAlter.BackColor = System.Drawing.Color.Transparent;
            this.radAlter.Location = new System.Drawing.Point(152, 53);
            this.radAlter.Name = "radAlter";
            this.radAlter.Size = new System.Drawing.Size(59, 16);
            this.radAlter.TabIndex = 6;
            this.radAlter.Text = "修改值";
            this.radAlter.UseVisualStyleBackColor = false;
            // 
            // lbendtimes
            // 
            this.lbendtimes.AutoSize = true;
            this.lbendtimes.BackColor = System.Drawing.Color.Transparent;
            this.lbendtimes.Location = new System.Drawing.Point(116, 55);
            this.lbendtimes.Name = "lbendtimes";
            this.lbendtimes.Size = new System.Drawing.Size(17, 12);
            this.lbendtimes.TabIndex = 7;
            this.lbendtimes.Text = "次";
            // 
            // NumUpDown
            // 
            this.NumUpDown.Enabled = false;
            this.NumUpDown.Location = new System.Drawing.Point(214, 53);
            this.NumUpDown.Name = "NumUpDown";
            this.NumUpDown.Size = new System.Drawing.Size(48, 21);
            this.NumUpDown.TabIndex = 10;
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.BackColor = System.Drawing.Color.Transparent;
            this.lbNum.Location = new System.Drawing.Point(90, 55);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(11, 12);
            this.lbNum.TabIndex = 11;
            this.lbNum.Text = "0";
            // 
            // FrmStopOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(291, 114);
            this.Controls.Add(this.lbNum);
            this.Controls.Add(this.NumUpDown);
            this.Controls.Add(this.lbendtimes);
            this.Controls.Add(this.radAlter);
            this.Controls.Add(this.radDefault);
            this.Controls.Add(this.dtime_end);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStopOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "停医嘱";
            this.Load += new System.EventHandler(this.FrmStopOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtime_end;
        private System.Windows.Forms.RadioButton radDefault;
        private System.Windows.Forms.RadioButton radAlter;
        private System.Windows.Forms.Label lbendtimes;
        private System.Windows.Forms.NumericUpDown NumUpDown;
        private System.Windows.Forms.Label lbNum;
    }
}