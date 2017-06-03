namespace HIS_ZYManager
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
            System.Windows.Forms.GroupBox groupBox11;
            this.tbPatName1 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tbInpatNo1 = new GWMHIS.PublicControls.InpatientNOTextBox(this.components);
            this.label222 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lvPatList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.panel33 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btbrush = new System.Windows.Forms.Button();
            this.rbinout = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.chbDept = new System.Windows.Forms.CheckBox();
            this.cbdate = new System.Windows.Forms.CheckBox();
            this.rbOut = new System.Windows.Forms.RadioButton();
            this.rbin = new System.Windows.Forms.RadioButton();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            groupBox11 = new System.Windows.Forms.GroupBox();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            groupBox11.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel11.SuspendLayout();
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
            // groupBox11
            // 
            groupBox11.Controls.Add(this.tbPatName1);
            groupBox11.Controls.Add(this.label31);
            groupBox11.Controls.Add(this.tbInpatNo1);
            groupBox11.Controls.Add(this.label222);
            groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox11.Location = new System.Drawing.Point(0, 0);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new System.Drawing.Size(217, 67);
            groupBox11.TabIndex = 19;
            groupBox11.TabStop = false;
            groupBox11.Text = "检索病人";
            // 
            // tbPatName1
            // 
            this.tbPatName1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPatName1.Location = new System.Drawing.Point(51, 39);
            this.tbPatName1.Name = "tbPatName1";
            this.tbPatName1.Size = new System.Drawing.Size(147, 21);
            this.tbPatName1.TabIndex = 4;
            this.tbPatName1.TextChanged += new System.EventHandler(this.tbPatName_TextChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(7, 43);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(41, 12);
            this.label31.TabIndex = 3;
            this.label31.Text = "病人名";
            // 
            // tbInpatNo1
            // 
            this.tbInpatNo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInpatNo1.BackColor = System.Drawing.Color.White;
            this.tbInpatNo1.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.tbInpatNo1.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.tbInpatNo1.EnterBackColor = System.Drawing.SystemColors.Window;
            this.tbInpatNo1.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.tbInpatNo1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInpatNo1.ForeColor = System.Drawing.Color.Black;
            this.tbInpatNo1.Location = new System.Drawing.Point(51, 16);
            this.tbInpatNo1.Name = "tbInpatNo1";
            this.tbInpatNo1.NextControl = null;
            this.tbInpatNo1.PreviousControl = null;
            this.tbInpatNo1.Size = new System.Drawing.Size(147, 21);
            this.tbInpatNo1.TabIndex = 2;
            this.tbInpatNo1.Text = "00000000";
            this.tbInpatNo1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInpatNo_KeyDown);
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Location = new System.Drawing.Point(7, 21);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(41, 12);
            this.label222.TabIndex = 0;
            this.label222.Text = "住院号";
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
            this.splitContainer1.Panel1.Controls.Add(this.panel22);
            this.splitContainer1.Panel1.Controls.Add(this.panel11);
            this.splitContainer1.Size = new System.Drawing.Size(1016, 640);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.panel4);
            this.panel22.Controls.Add(this.panel33);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(0, 154);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(217, 482);
            this.panel22.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lvPatList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 67);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(217, 415);
            this.panel4.TabIndex = 3;
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
            this.lvPatList.Location = new System.Drawing.Point(0, 0);
            this.lvPatList.MultiSelect = false;
            this.lvPatList.Name = "lvPatList";
            this.lvPatList.Size = new System.Drawing.Size(217, 415);
            this.lvPatList.TabIndex = 2;
            this.lvPatList.UseCompatibleStateImageBehavior = false;
            this.lvPatList.View = System.Windows.Forms.View.Details;
            this.lvPatList.DoubleClick += new System.EventHandler(this.lvPatList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "住院号";
            this.columnHeader1.Width = 80;
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
            this.columnHeader4.Text = "床位";
            this.columnHeader4.Width = 100;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(groupBox11);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel33.Location = new System.Drawing.Point(0, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(217, 67);
            this.panel33.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btbrush);
            this.panel11.Controls.Add(this.rbinout);
            this.panel11.Controls.Add(this.checkBox1);
            this.panel11.Controls.Add(this.label41);
            this.panel11.Controls.Add(this.label119);
            this.panel11.Controls.Add(this.chbDept);
            this.panel11.Controls.Add(this.cbdate);
            this.panel11.Controls.Add(this.rbOut);
            this.panel11.Controls.Add(this.rbin);
            this.panel11.Controls.Add(this.cbDept);
            this.panel11.Controls.Add(this.dtpEnd);
            this.panel11.Controls.Add(this.dtpBegin);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(217, 154);
            this.panel11.TabIndex = 0;
            // 
            // btbrush
            // 
            this.btbrush.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btbrush.Location = new System.Drawing.Point(0, 131);
            this.btbrush.Name = "btbrush";
            this.btbrush.Size = new System.Drawing.Size(217, 23);
            this.btbrush.TabIndex = 24;
            this.btbrush.Text = "刷新";
            this.btbrush.UseVisualStyleBackColor = true;
            this.btbrush.Click += new System.EventHandler(this.llabrush_LinkClicked);
            // 
            // rbinout
            // 
            this.rbinout.AutoSize = true;
            this.rbinout.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbinout.Location = new System.Drawing.Point(60, 86);
            this.rbinout.Name = "rbinout";
            this.rbinout.Size = new System.Drawing.Size(95, 18);
            this.rbinout.TabIndex = 23;
            this.rbinout.Text = "出院未结算";
            this.rbinout.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox1.Location = new System.Drawing.Point(7, 110);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 16);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "手术室病人";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(95, 112);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(29, 12);
            this.label41.TabIndex = 20;
            this.label41.Text = "人数";
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.ForeColor = System.Drawing.Color.Blue;
            this.label119.Location = new System.Drawing.Point(128, 112);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(29, 12);
            this.label119.TabIndex = 18;
            this.label119.Text = "0 人";
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
            // rbOut
            // 
            this.rbOut.AutoSize = true;
            this.rbOut.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbOut.Location = new System.Drawing.Point(159, 86);
            this.rbOut.Name = "rbOut";
            this.rbOut.Size = new System.Drawing.Size(53, 18);
            this.rbOut.TabIndex = 12;
            this.rbOut.Text = "出院";
            this.rbOut.UseVisualStyleBackColor = true;
            this.rbOut.CheckedChanged += new System.EventHandler(this.rbOut_CheckedChanged);
            // 
            // rbin
            // 
            this.rbin.AutoSize = true;
            this.rbin.Checked = true;
            this.rbin.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbin.Location = new System.Drawing.Point(7, 86);
            this.rbin.Name = "rbin";
            this.rbin.Size = new System.Drawing.Size(53, 18);
            this.rbin.TabIndex = 11;
            this.rbin.TabStop = true;
            this.rbin.Text = "在院";
            this.rbin.UseVisualStyleBackColor = true;
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
            this.cbDept.Size = new System.Drawing.Size(143, 21);
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
            this.dtpEnd.Size = new System.Drawing.Size(143, 23);
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
            this.dtpBegin.Size = new System.Drawing.Size(143, 23);
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
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel11;
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
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox cbdate;
        private System.Windows.Forms.CheckBox chbDept;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.Label label222;
        private GWMHIS.PublicControls.InpatientNOTextBox tbInpatNo1;
        private System.Windows.Forms.TextBox tbPatName1;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton rbinout;
        private System.Windows.Forms.Button btbrush;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel33;
    }
}