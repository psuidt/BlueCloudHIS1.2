namespace HIS_BaseManager
{
    partial class FrmDeptAttr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.txtParentDept = new System.Windows.Forms.TextBox();
            this.txtDeptAddr = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cboStdDept = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDeptType = new System.Windows.Forms.ComboBox();
            this.chkNoUse = new System.Windows.Forms.CheckBox();
            this.chkJZ = new System.Windows.Forms.CheckBox();
            this.chkZY = new System.Windows.Forms.CheckBox();
            this.chkMZ = new System.Windows.Forms.CheckBox();
            this.btnParent = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkSs = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "上层科室";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "位置";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(111, 12);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(199, 21);
            this.txtDeptName.TabIndex = 5;
            this.txtDeptName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeptName_KeyPress);
            // 
            // txtParentDept
            // 
            this.txtParentDept.Location = new System.Drawing.Point(111, 55);
            this.txtParentDept.Name = "txtParentDept";
            this.txtParentDept.Size = new System.Drawing.Size(172, 21);
            this.txtParentDept.TabIndex = 6;
            this.txtParentDept.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParentDept_KeyPress);
            // 
            // txtDeptAddr
            // 
            this.txtDeptAddr.Location = new System.Drawing.Point(111, 143);
            this.txtDeptAddr.Multiline = true;
            this.txtDeptAddr.Name = "txtDeptAddr";
            this.txtDeptAddr.Size = new System.Drawing.Size(199, 101);
            this.txtDeptAddr.TabIndex = 8;
            this.txtDeptAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeptAddr_KeyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(333, 345);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkSs);
            this.tabPage1.Controls.Add(this.cboStdDept);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cboDeptType);
            this.tabPage1.Controls.Add(this.chkNoUse);
            this.tabPage1.Controls.Add(this.chkJZ);
            this.tabPage1.Controls.Add(this.chkZY);
            this.tabPage1.Controls.Add(this.chkMZ);
            this.tabPage1.Controls.Add(this.btnParent);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtDeptAddr);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtParentDept);
            this.tabPage1.Controls.Add(this.txtDeptName);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(325, 320);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "科室属性";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cboStdDept
            // 
            this.cboStdDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStdDept.FormattingEnabled = true;
            this.cboStdDept.Location = new System.Drawing.Point(111, 291);
            this.cboStdDept.Name = "cboStdDept";
            this.cboStdDept.Size = new System.Drawing.Size(199, 20);
            this.cboStdDept.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "国标科室";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "类型";
            // 
            // cboDeptType
            // 
            this.cboDeptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeptType.FormattingEnabled = true;
            this.cboDeptType.Location = new System.Drawing.Point(111, 113);
            this.cboDeptType.Name = "cboDeptType";
            this.cboDeptType.Size = new System.Drawing.Size(198, 20);
            this.cboDeptType.TabIndex = 14;
            // 
            // chkNoUse
            // 
            this.chkNoUse.AutoSize = true;
            this.chkNoUse.Location = new System.Drawing.Point(111, 259);
            this.chkNoUse.Name = "chkNoUse";
            this.chkNoUse.Size = new System.Drawing.Size(48, 16);
            this.chkNoUse.TabIndex = 13;
            this.chkNoUse.Text = "禁用";
            this.chkNoUse.UseVisualStyleBackColor = true;
            // 
            // chkJZ
            // 
            this.chkJZ.AutoSize = true;
            this.chkJZ.Location = new System.Drawing.Point(215, 91);
            this.chkJZ.Name = "chkJZ";
            this.chkJZ.Size = new System.Drawing.Size(48, 16);
            this.chkJZ.TabIndex = 13;
            this.chkJZ.Text = "急诊";
            this.chkJZ.UseVisualStyleBackColor = true;
            // 
            // chkZY
            // 
            this.chkZY.AutoSize = true;
            this.chkZY.Location = new System.Drawing.Point(161, 91);
            this.chkZY.Name = "chkZY";
            this.chkZY.Size = new System.Drawing.Size(48, 16);
            this.chkZY.TabIndex = 12;
            this.chkZY.Text = "住院";
            this.chkZY.UseVisualStyleBackColor = true;
            // 
            // chkMZ
            // 
            this.chkMZ.AutoSize = true;
            this.chkMZ.Location = new System.Drawing.Point(111, 91);
            this.chkMZ.Name = "chkMZ";
            this.chkMZ.Size = new System.Drawing.Size(48, 16);
            this.chkMZ.TabIndex = 11;
            this.chkMZ.Text = "门诊";
            this.chkMZ.UseVisualStyleBackColor = true;
            // 
            // btnParent
            // 
            this.btnParent.Image = global::HIS_BaseManager.Properties.Resources.搜索_;
            this.btnParent.Location = new System.Drawing.Point(285, 54);
            this.btnParent.Name = "btnParent";
            this.btnParent.Size = new System.Drawing.Size(24, 23);
            this.btnParent.TabIndex = 10;
            this.btnParent.UseVisualStyleBackColor = true;
            this.btnParent.Click += new System.EventHandler(this.btnParent_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(246, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消(&X)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.Location = new System.Drawing.Point(165, 351);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "确定(&S)";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkSs
            // 
            this.chkSs.AutoSize = true;
            this.chkSs.Location = new System.Drawing.Point(269, 91);
            this.chkSs.Name = "chkSs";
            this.chkSs.Size = new System.Drawing.Size(48, 16);
            this.chkSs.TabIndex = 18;
            this.chkSs.Text = "手术";
            this.chkSs.UseVisualStyleBackColor = true;
            // 
            // FrmDeptAttr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 386);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDeptAttr";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDeptAttr";
            this.Load += new System.EventHandler(this.FrmDeptAttr_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.TextBox txtParentDept;
        private System.Windows.Forms.TextBox txtDeptAddr;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnParent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkJZ;
        private System.Windows.Forms.CheckBox chkZY;
        private System.Windows.Forms.CheckBox chkMZ;
        private System.Windows.Forms.CheckBox chkNoUse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDeptType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStdDept;
        private System.Windows.Forms.CheckBox chkSs;
    }
}