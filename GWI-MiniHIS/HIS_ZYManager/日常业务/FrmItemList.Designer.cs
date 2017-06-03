namespace HIS_ZYManager
{
    partial class FrmItemList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemList));
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEdate = new System.Windows.Forms.DateTimePicker();
            this.dtpBdate = new System.Windows.Forms.DateTimePicker();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.btbrush = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbQF = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbInpatNo = new GWMHIS.PublicControls.InpatientNOTextBox(this.components);
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btClose = new System.Windows.Forms.Button();
            this.chbDept = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lvPatList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpE = new System.Windows.Forms.DateTimePicker();
            this.dtpB = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cb_pattype = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 29);
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
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 645);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(210, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 42;
            this.label4.Text = "至";
            // 
            // dtpEdate
            // 
            this.dtpEdate.CustomFormat = "yyyy-MM-dd";
            this.dtpEdate.Enabled = false;
            this.dtpEdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEdate.Location = new System.Drawing.Point(237, 10);
            this.dtpEdate.Name = "dtpEdate";
            this.dtpEdate.Size = new System.Drawing.Size(87, 21);
            this.dtpEdate.TabIndex = 40;
            // 
            // dtpBdate
            // 
            this.dtpBdate.CustomFormat = "yyyy-MM-dd";
            this.dtpBdate.Enabled = false;
            this.dtpBdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBdate.Location = new System.Drawing.Point(119, 10);
            this.dtpBdate.Name = "dtpBdate";
            this.dtpBdate.Size = new System.Drawing.Size(88, 21);
            this.dtpBdate.TabIndex = 39;
            // 
            // cbDept
            // 
            this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept.Enabled = false;
            this.cbDept.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDept.FormattingEnabled = true;
            this.cbDept.Location = new System.Drawing.Point(437, 10);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(182, 21);
            this.cbDept.TabIndex = 44;
            // 
            // btbrush
            // 
            this.btbrush.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btbrush.Location = new System.Drawing.Point(632, 38);
            this.btbrush.Name = "btbrush";
            this.btbrush.Size = new System.Drawing.Size(96, 23);
            this.btbrush.TabIndex = 57;
            this.btbrush.Text = "刷  新(&S)";
            this.btbrush.UseVisualStyleBackColor = true;
            this.btbrush.Click += new System.EventHandler(this.btbrush_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cb_pattype);
            this.panel1.Controls.Add(this.cbQF);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.tbInpatNo);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Controls.Add(this.chbDept);
            this.panel1.Controls.Add(this.dtpBdate);
            this.panel1.Controls.Add(this.btbrush);
            this.panel1.Controls.Add(this.dtpEdate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbDept);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 76);
            this.panel1.TabIndex = 58;
            // 
            // cbQF
            // 
            this.cbQF.AutoSize = true;
            this.cbQF.Location = new System.Drawing.Point(738, 13);
            this.cbQF.Name = "cbQF";
            this.cbQF.Size = new System.Drawing.Size(108, 16);
            this.cbQF.TabIndex = 66;
            this.cbQF.Text = "只显示欠费病人";
            this.cbQF.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(437, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 21);
            this.textBox1.TabIndex = 65;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // tbInpatNo
            // 
            this.tbInpatNo.Enabled = false;
            this.tbInpatNo.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.tbInpatNo.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.tbInpatNo.EnterBackColor = System.Drawing.SystemColors.Window;
            this.tbInpatNo.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.tbInpatNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInpatNo.Location = new System.Drawing.Point(119, 42);
            this.tbInpatNo.Name = "tbInpatNo";
            this.tbInpatNo.NextControl = null;
            this.tbInpatNo.PreviousControl = null;
            this.tbInpatNo.Size = new System.Drawing.Size(88, 21);
            this.tbInpatNo.TabIndex = 64;
            this.tbInpatNo.Text = "00000000";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(348, 44);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(72, 16);
            this.checkBox4.TabIndex = 63;
            this.checkBox4.Text = "病人姓名";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(29, 44);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(60, 16);
            this.checkBox3.TabIndex = 62;
            this.checkBox3.Text = "住院号";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(29, 12);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 16);
            this.checkBox2.TabIndex = 61;
            this.checkBox2.Text = "入出院时间";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btClose.Image = global::HIS_ZYManager.Properties.Resources.退出;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(738, 38);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(93, 23);
            this.btClose.TabIndex = 59;
            this.btClose.Text = "关闭(&C)";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click_1);
            // 
            // chbDept
            // 
            this.chbDept.AutoSize = true;
            this.chbDept.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbDept.Location = new System.Drawing.Point(348, 14);
            this.chbDept.Name = "chbDept";
            this.chbDept.Size = new System.Drawing.Size(72, 16);
            this.chbDept.TabIndex = 58;
            this.chbDept.Text = "住院科室";
            this.chbDept.UseVisualStyleBackColor = true;
            this.chbDept.CheckedChanged += new System.EventHandler(this.chbDept_CheckedChanged_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 569);
            this.panel2.TabIndex = 59;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1016, 569);
            this.panel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lvPatList);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(859, 569);
            this.panel5.TabIndex = 4;
            // 
            // lvPatList
            // 
            this.lvPatList.CheckBoxes = true;
            this.lvPatList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lvPatList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPatList.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvPatList.FullRowSelect = true;
            this.lvPatList.GridLines = true;
            this.lvPatList.HideSelection = false;
            this.lvPatList.Location = new System.Drawing.Point(0, 0);
            this.lvPatList.MultiSelect = false;
            this.lvPatList.Name = "lvPatList";
            this.lvPatList.Size = new System.Drawing.Size(859, 569);
            this.lvPatList.TabIndex = 3;
            this.lvPatList.UseCompatibleStateImageBehavior = false;
            this.lvPatList.View = System.Windows.Forms.View.Details;
            this.lvPatList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvPatList_ItemChecked);
            this.lvPatList.SelectedIndexChanged += new System.EventHandler(this.lvPatList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "住院号";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "床位号";
            this.columnHeader6.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "性别";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "累计交费";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "累计记账";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "余额";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "出生日期";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "科室";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "病人类型";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "入院日期";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "出院时间";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "住院天数";
            this.columnHeader13.Width = 100;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.button6);
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(859, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(157, 569);
            this.panel4.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.dtpE);
            this.groupBox2.Controls.Add(this.dtpB);
            this.groupBox2.Location = new System.Drawing.Point(3, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 67);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "   费用时间";
            // 
            // dtpE
            // 
            this.dtpE.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpE.Location = new System.Drawing.Point(12, 41);
            this.dtpE.Name = "dtpE";
            this.dtpE.Size = new System.Drawing.Size(137, 21);
            this.dtpE.TabIndex = 41;
            this.dtpE.Value = new System.DateTime(2010, 5, 31, 23, 59, 59, 0);
            // 
            // dtpB
            // 
            this.dtpB.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpB.Location = new System.Drawing.Point(12, 15);
            this.dtpB.Name = "dtpB";
            this.dtpB.Size = new System.Drawing.Size(137, 21);
            this.dtpB.TabIndex = 40;
            this.dtpB.Value = new System.DateTime(2010, 5, 31, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(20, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "修改床位号";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(20, 324);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(112, 31);
            this.button6.TabIndex = 5;
            this.button6.Text = "全部打印";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(20, 287);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 31);
            this.button5.TabIndex = 4;
            this.button5.Text = "选择打印";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(20, 250);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 31);
            this.button4.TabIndex = 3;
            this.button4.Text = "单人打印";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(78, 139);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 31);
            this.button3.TabIndex = 2;
            this.button3.Text = "反选";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(20, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "全选";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(20, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印方式";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton5.Location = new System.Drawing.Point(11, 102);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(95, 18);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "按一日清单";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton4.Location = new System.Drawing.Point(11, 82);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(95, 18);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "按项目汇总";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton3.Location = new System.Drawing.Point(11, 62);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(95, 18);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "按明细项目";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.Location = new System.Drawing.Point(11, 41);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 18);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "按发票项目";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(11, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 18);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "按项目组合";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // cb_pattype
            // 
            this.cb_pattype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_pattype.FormattingEnabled = true;
            this.cb_pattype.Items.AddRange(new object[] {
            "在床",
            "未结算",
            "已出院"});
            this.cb_pattype.Location = new System.Drawing.Point(632, 10);
            this.cb_pattype.Name = "cb_pattype";
            this.cb_pattype.Size = new System.Drawing.Size(92, 20);
            this.cb_pattype.TabIndex = 67;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(11, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 42;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FrmItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "费用清单";
            this.Name = "FrmItemList";
            this.Text = "费用清单";
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEdate;
        private System.Windows.Forms.DateTimePicker dtpBdate;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.Button btbrush;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.ListView lvPatList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chbDept;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private GWMHIS.PublicControls.InpatientNOTextBox tbInpatNo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpE;
        private System.Windows.Forms.DateTimePicker dtpB;
        private System.Windows.Forms.CheckBox cbQF;
        private System.Windows.Forms.ComboBox cb_pattype;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}