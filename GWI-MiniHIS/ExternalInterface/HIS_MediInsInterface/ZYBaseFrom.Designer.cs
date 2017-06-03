namespace HIS_MediInsInterface
{
    partial class ZYBaseFrom
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZYBaseFrom));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvPatList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPatName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInpatNo = new GWMHIS.PublicControls.InpatientNOTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chbDept = new System.Windows.Forms.CheckBox();
            this.cbdate = new System.Windows.Forms.CheckBox();
            this.llabrush = new System.Windows.Forms.LinkLabel();
            this.rbOut = new System.Windows.Forms.RadioButton();
            this.rbin = new System.Windows.Forms.RadioButton();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.toolStrip1);
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 34);
            this.plBaseToolbar.Visible = false;
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("baseImageList.ImageStream")));
            this.baseImageList.Images.SetKeyName(0, "table_delete.gif");
            this.baseImageList.Images.SetKeyName(1, "search_big.GIF");
            this.baseImageList.Images.SetKeyName(2, "Save.GIF");
            this.baseImageList.Images.SetKeyName(3, "Print.GIF");
            this.baseImageList.Images.SetKeyName(4, "page_user_dark.gif");
            this.baseImageList.Images.SetKeyName(5, "page_refresh.gif");
            this.baseImageList.Images.SetKeyName(6, "page_key.gif");
            this.baseImageList.Images.SetKeyName(7, "page_edit.gif");
            this.baseImageList.Images.SetKeyName(8, "page_cross.gif");
            this.baseImageList.Images.SetKeyName(9, "list_users.gif");
            this.baseImageList.Images.SetKeyName(10, "icon_package_get.gif");
            this.baseImageList.Images.SetKeyName(11, "icon_network.gif");
            this.baseImageList.Images.SetKeyName(12, "icon_history.gif");
            this.baseImageList.Images.SetKeyName(13, "icon_accept.gif");
            this.baseImageList.Images.SetKeyName(14, "folder_page.gif");
            this.baseImageList.Images.SetKeyName(15, "folder_new.gif");
            this.baseImageList.Images.SetKeyName(16, "Exit.GIF");
            this.baseImageList.Images.SetKeyName(17, "Delete.GIF");
            this.baseImageList.Images.SetKeyName(18, "copy.gif");
            this.baseImageList.Images.SetKeyName(19, "action_stop.gif");
            this.baseImageList.Images.SetKeyName(20, "action_refresh.gif");
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point(0, 708);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.splitContainer1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 68);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 640);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvPatList);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1016, 640);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvPatList
            // 
            this.lvPatList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvPatList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPatList.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvPatList.FullRowSelect = true;
            this.lvPatList.GridLines = true;
            this.lvPatList.Location = new System.Drawing.Point(0, 184);
            this.lvPatList.MultiSelect = false;
            this.lvPatList.Name = "lvPatList";
            this.lvPatList.Size = new System.Drawing.Size(205, 452);
            this.lvPatList.TabIndex = 2;
            this.lvPatList.UseCompatibleStateImageBehavior = false;
            this.lvPatList.View = System.Windows.Forms.View.Details;
            this.lvPatList.DoubleClick += new System.EventHandler(this.lvPatList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "住院号";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "性别";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "出生日期";
            this.columnHeader4.Width = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chbDept);
            this.panel1.Controls.Add(this.cbdate);
            this.panel1.Controls.Add(this.llabrush);
            this.panel1.Controls.Add(this.rbOut);
            this.panel1.Controls.Add(this.rbin);
            this.panel1.Controls.Add(this.cbDept);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpBegin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 184);
            this.panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox1.Location = new System.Drawing.Point(69, 105);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 16);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "手术室病人";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "人数";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPatName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbInpatNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 64);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检索病人";
            // 
            // tbPatName
            // 
            this.tbPatName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPatName.Location = new System.Drawing.Point(51, 39);
            this.tbPatName.Name = "tbPatName";
            this.tbPatName.Size = new System.Drawing.Size(154, 21);
            this.tbPatName.TabIndex = 4;
            this.tbPatName.TextChanged += new System.EventHandler(this.tbPatName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "病人名";
            // 
            // tbInpatNo
            // 
            this.tbInpatNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInpatNo.BackColor = System.Drawing.Color.White;
            this.tbInpatNo.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.tbInpatNo.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.tbInpatNo.EnterBackColor = System.Drawing.SystemColors.Window;
            this.tbInpatNo.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.tbInpatNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInpatNo.ForeColor = System.Drawing.Color.Black;
            this.tbInpatNo.Location = new System.Drawing.Point(51, 16);
            this.tbInpatNo.Name = "tbInpatNo";
            this.tbInpatNo.NextControl = null;
            this.tbInpatNo.PreviousControl = null;
            this.tbInpatNo.Size = new System.Drawing.Size(154, 21);
            this.tbInpatNo.TabIndex = 2;
            this.tbInpatNo.Text = "00000000";
            this.tbInpatNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInpatNo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "住院号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(100, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "0 人";
            // 
            // chbDept
            // 
            this.chbDept.AutoSize = true;
            this.chbDept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chbDept.Location = new System.Drawing.Point(3, 53);
            this.chbDept.Name = "chbDept";
            this.chbDept.Size = new System.Drawing.Size(46, 16);
            this.chbDept.TabIndex = 17;
            this.chbDept.Text = "科室";
            this.chbDept.UseVisualStyleBackColor = true;
            this.chbDept.CheckedChanged += new System.EventHandler(this.chbDept_CheckedChanged);
            // 
            // cbdate
            // 
            this.cbdate.AutoSize = true;
            this.cbdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbdate.Location = new System.Drawing.Point(3, 6);
            this.cbdate.Name = "cbdate";
            this.cbdate.Size = new System.Drawing.Size(46, 16);
            this.cbdate.TabIndex = 14;
            this.cbdate.Text = "日期";
            this.cbdate.UseVisualStyleBackColor = true;
            this.cbdate.CheckedChanged += new System.EventHandler(this.cbdate_CheckedChanged);
            // 
            // llabrush
            // 
            this.llabrush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llabrush.AutoSize = true;
            this.llabrush.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llabrush.Location = new System.Drawing.Point(167, 87);
            this.llabrush.Name = "llabrush";
            this.llabrush.Size = new System.Drawing.Size(35, 14);
            this.llabrush.TabIndex = 13;
            this.llabrush.TabStop = true;
            this.llabrush.Text = "刷新";
            this.llabrush.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabrush_LinkClicked);
            // 
            // rbOut
            // 
            this.rbOut.AutoSize = true;
            this.rbOut.Checked = true;
            this.rbOut.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbOut.Location = new System.Drawing.Point(7, 87);
            this.rbOut.Name = "rbOut";
            this.rbOut.Size = new System.Drawing.Size(53, 18);
            this.rbOut.TabIndex = 12;
            this.rbOut.TabStop = true;
            this.rbOut.Text = "出院";
            this.rbOut.UseVisualStyleBackColor = true;
            this.rbOut.CheckedChanged += new System.EventHandler(this.rbOut_CheckedChanged);
            // 
            // rbin
            // 
            this.rbin.AutoSize = true;
            this.rbin.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbin.Location = new System.Drawing.Point(7, 86);
            this.rbin.Name = "rbin";
            this.rbin.Size = new System.Drawing.Size(53, 18);
            this.rbin.TabIndex = 11;
            this.rbin.Text = "在院";
            this.rbin.UseVisualStyleBackColor = true;
            this.rbin.Visible = false;
            this.rbin.CheckedChanged += new System.EventHandler(this.rbin_CheckedChanged);
            // 
            // cbDept
            // 
            this.cbDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept.Enabled = false;
            this.cbDept.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDept.FormattingEnabled = true;
            this.cbDept.Location = new System.Drawing.Point(55, 50);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(150, 21);
            this.cbDept.TabIndex = 10;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(55, 23);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(150, 23);
            this.dtpEnd.TabIndex = 8;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBegin.CustomFormat = "yyyy-MM-dd";
            this.dtpBegin.Enabled = false;
            this.dtpBegin.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(55, 0);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(150, 23);
            this.dtpBegin.TabIndex = 7;
            // 
            // ZYBaseFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "住院收费";
            this.Name = "ZYBaseFrom";
            this.Text = "";
            this.Load += new System.EventHandler(this.ZYBaseFrom_Load);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbOut;
        private System.Windows.Forms.RadioButton rbin;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.ListView lvPatList;
        private System.Windows.Forms.LinkLabel llabrush;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chbDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private GWMHIS.PublicControls.InpatientNOTextBox tbInpatNo;
        private System.Windows.Forms.TextBox tbPatName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        protected System.Windows.Forms.CheckBox cbdate;
    }
}