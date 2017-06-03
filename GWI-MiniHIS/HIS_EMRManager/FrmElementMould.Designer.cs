namespace HIS_EMRManager
{
    partial class FrmElementMould
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.plBottom = new System.Windows.Forms.Panel();
            this.rdBPerson = new System.Windows.Forms.RadioButton();
            this.rdBDept = new System.Windows.Forms.RadioButton();
            this.rdBHospital = new System.Windows.Forms.RadioButton();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSure = new System.Windows.Forms.Button();
            this.dGVMouldList = new System.Windows.Forms.DataGridView();
            this.RowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MouldContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.plBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVMouldList)).BeginInit();
            this.SuspendLayout();
            // 
            // plBottom
            // 
            this.plBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.plBottom.Controls.Add(this.rdBPerson);
            this.plBottom.Controls.Add(this.rdBDept);
            this.plBottom.Controls.Add(this.rdBHospital);
            this.plBottom.Controls.Add(this.btCancel);
            this.plBottom.Controls.Add(this.btSure);
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(0, 146);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(464, 44);
            this.plBottom.TabIndex = 0;
            // 
            // rdBPerson
            // 
            this.rdBPerson.AutoSize = true;
            this.rdBPerson.Location = new System.Drawing.Point(145, 13);
            this.rdBPerson.Name = "rdBPerson";
            this.rdBPerson.Size = new System.Drawing.Size(59, 16);
            this.rdBPerson.TabIndex = 4;
            this.rdBPerson.Text = "个人级";
            this.rdBPerson.UseVisualStyleBackColor = true;
            this.rdBPerson.CheckedChanged += new System.EventHandler(this.rdBLevel_CheckedChanged);
            // 
            // rdBDept
            // 
            this.rdBDept.AutoSize = true;
            this.rdBDept.Location = new System.Drawing.Point(80, 13);
            this.rdBDept.Name = "rdBDept";
            this.rdBDept.Size = new System.Drawing.Size(59, 16);
            this.rdBDept.TabIndex = 3;
            this.rdBDept.Text = "科室级";
            this.rdBDept.UseVisualStyleBackColor = true;
            this.rdBDept.CheckedChanged += new System.EventHandler(this.rdBLevel_CheckedChanged);
            // 
            // rdBHospital
            // 
            this.rdBHospital.AutoSize = true;
            this.rdBHospital.Checked = true;
            this.rdBHospital.Location = new System.Drawing.Point(15, 13);
            this.rdBHospital.Name = "rdBHospital";
            this.rdBHospital.Size = new System.Drawing.Size(59, 16);
            this.rdBHospital.TabIndex = 2;
            this.rdBHospital.TabStop = true;
            this.rdBHospital.Text = "全院级";
            this.rdBHospital.UseVisualStyleBackColor = true;
            this.rdBHospital.CheckedChanged += new System.EventHandler(this.rdBLevel_CheckedChanged);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(347, 9);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btSure
            // 
            this.btSure.Location = new System.Drawing.Point(252, 9);
            this.btSure.Name = "btSure";
            this.btSure.Size = new System.Drawing.Size(75, 23);
            this.btSure.TabIndex = 0;
            this.btSure.Text = "确定";
            this.btSure.UseVisualStyleBackColor = true;
            this.btSure.Click += new System.EventHandler(this.btSure_Click);
            // 
            // dGVMouldList
            // 
            this.dGVMouldList.AllowUserToAddRows = false;
            this.dGVMouldList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.dGVMouldList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVMouldList.BackgroundColor = System.Drawing.Color.White;
            this.dGVMouldList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(192)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVMouldList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVMouldList.ColumnHeadersHeight = 25;
            this.dGVMouldList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNo,
            this.MouldContent,
            this.Selected});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVMouldList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGVMouldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVMouldList.EnableHeadersVisualStyles = false;
            this.dGVMouldList.Location = new System.Drawing.Point(0, 0);
            this.dGVMouldList.Name = "dGVMouldList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(192)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVMouldList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVMouldList.RowHeadersWidth = 25;
            this.dGVMouldList.RowTemplate.Height = 23;
            this.dGVMouldList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVMouldList.Size = new System.Drawing.Size(464, 146);
            this.dGVMouldList.TabIndex = 5;
            // 
            // RowNo
            // 
            this.RowNo.DataPropertyName = "RowNo";
            this.RowNo.HeaderText = "编号";
            this.RowNo.Name = "RowNo";
            this.RowNo.Width = 50;
            // 
            // MouldContent
            // 
            this.MouldContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MouldContent.DataPropertyName = "MouldContent";
            this.MouldContent.HeaderText = "内容";
            this.MouldContent.Name = "MouldContent";
            this.MouldContent.ReadOnly = true;
            // 
            // Selected
            // 
            this.Selected.HeaderText = "选择";
            this.Selected.Name = "Selected";
            this.Selected.Width = 40;
            // 
            // FrmElementMould
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 190);
            this.Controls.Add(this.dGVMouldList);
            this.Controls.Add(this.plBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmElementMould";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "元素模板";
            this.plBottom.ResumeLayout(false);
            this.plBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVMouldList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plBottom;
        private System.Windows.Forms.DataGridView dGVMouldList;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSure;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MouldContent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.RadioButton rdBHospital;
        private System.Windows.Forms.RadioButton rdBPerson;
        private System.Windows.Forms.RadioButton rdBDept;
    }
}