namespace HIS_MZDocManager
{
    partial class FrmPatInfoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPatInfoEdit));
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn5 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn6 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn7 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn8 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            this.plbottom = new System.Windows.Forms.Panel();
            this.btSure = new GWI.HIS.Windows.Controls.Button();
            this.btCancel = new GWI.HIS.Windows.Controls.Button();
            this.cbBAgeType = new System.Windows.Forms.ComboBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.qTxtWorkUnit = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.cboJob = new System.Windows.Forms.ComboBox();
            this.cboFeeType = new System.Windows.Forms.ComboBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtIdentityCard = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tBCardno = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tBVisitNo = new System.Windows.Forms.TextBox();
            this.txtAllergic = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.plBaseWorkArea.SuspendLayout();
            this.plbottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Size = new System.Drawing.Size(814, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 398);
            this.plBaseStatus.Size = new System.Drawing.Size(814, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.tBVisitNo);
            this.plBaseWorkArea.Controls.Add(this.cboJob);
            this.plBaseWorkArea.Controls.Add(this.cboSex);
            this.plBaseWorkArea.Controls.Add(this.tBCardno);
            this.plBaseWorkArea.Controls.Add(this.cboFeeType);
            this.plBaseWorkArea.Controls.Add(this.txtName);
            this.plBaseWorkArea.Controls.Add(this.txtAllergic);
            this.plBaseWorkArea.Controls.Add(this.label17);
            this.plBaseWorkArea.Controls.Add(this.label10);
            this.plBaseWorkArea.Controls.Add(this.label11);
            this.plBaseWorkArea.Controls.Add(this.cbBAgeType);
            this.plBaseWorkArea.Controls.Add(this.txtAge);
            this.plBaseWorkArea.Controls.Add(this.qTxtWorkUnit);
            this.plBaseWorkArea.Controls.Add(this.txtTel);
            this.plBaseWorkArea.Controls.Add(this.txtAddress);
            this.plBaseWorkArea.Controls.Add(this.txtIdentityCard);
            this.plBaseWorkArea.Controls.Add(this.label9);
            this.plBaseWorkArea.Controls.Add(this.label8);
            this.plBaseWorkArea.Controls.Add(this.label7);
            this.plBaseWorkArea.Controls.Add(this.label6);
            this.plBaseWorkArea.Controls.Add(this.label5);
            this.plBaseWorkArea.Controls.Add(this.label4);
            this.plBaseWorkArea.Controls.Add(this.label3);
            this.plBaseWorkArea.Controls.Add(this.label2);
            this.plBaseWorkArea.Controls.Add(this.label1);
            this.plBaseWorkArea.Controls.Add(this.plbottom);
            this.plBaseWorkArea.Size = new System.Drawing.Size(814, 335);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(814, 34);
            // 
            // plbottom
            // 
            this.plbottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plbottom.Controls.Add(this.btSure);
            this.plbottom.Controls.Add(this.btCancel);
            this.plbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plbottom.Location = new System.Drawing.Point(0, 293);
            this.plbottom.Name = "plbottom";
            this.plbottom.Size = new System.Drawing.Size(814, 42);
            this.plbottom.TabIndex = 0;
            // 
            // btSure
            // 
            this.btSure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSure.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btSure.FixedWidth = true;
            this.btSure.Location = new System.Drawing.Point(574, 7);
            this.btSure.Name = "btSure";
            this.btSure.Size = new System.Drawing.Size(90, 25);
            this.btSure.TabIndex = 5;
            this.btSure.Text = "确定(&S)";
            this.btSure.UseVisualStyleBackColor = true;
            this.btSure.Click += new System.EventHandler(this.btSure_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btCancel.FixedWidth = true;
            this.btCancel.Location = new System.Drawing.Point(684, 7);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(90, 25);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // cbBAgeType
            // 
            this.cbBAgeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBAgeType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBAgeType.FormattingEnabled = true;
            this.cbBAgeType.Items.AddRange(new object[] {
            "岁",
            "月",
            "天",
            "小时"});
            this.cbBAgeType.Location = new System.Drawing.Point(573, 51);
            this.cbBAgeType.Name = "cbBAgeType";
            this.cbBAgeType.Size = new System.Drawing.Size(57, 24);
            this.cbBAgeType.TabIndex = 17;
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAge.Location = new System.Drawing.Point(528, 50);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(45, 26);
            this.txtAge.TabIndex = 15;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // qTxtWorkUnit
            // 
            this.qTxtWorkUnit.AllowSelectedNullRow = true;
            this.qTxtWorkUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.qTxtWorkUnit.BackColor = System.Drawing.Color.White;
            this.qTxtWorkUnit.DisplayField = "NAME";
            this.qTxtWorkUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qTxtWorkUnit.Location = new System.Drawing.Point(116, 218);
            this.qTxtWorkUnit.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.qTxtWorkUnit.MemberField = "CODE";
            this.qTxtWorkUnit.MemberValue = null;
            this.qTxtWorkUnit.Name = "qTxtWorkUnit";
            this.qTxtWorkUnit.NextControl = null;
            this.qTxtWorkUnit.NextControlByEnter = true;
            this.qTxtWorkUnit.OffsetX = 0;
            this.qTxtWorkUnit.OffsetY = 0;
            this.qTxtWorkUnit.QueryFields = new string[] {
        "NAME",
        "PY_CODE",
        "WB_CODE"};
            this.qTxtWorkUnit.SelectedValue = null;
            this.qTxtWorkUnit.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.qTxtWorkUnit.SelectionCardBackColor = System.Drawing.Color.White;
            this.qTxtWorkUnit.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn5.AutoFill = true;
            selectionCardColumn5.DataBindField = "NAME";
            selectionCardColumn5.HeaderText = "单位名称";
            selectionCardColumn5.IsNameField = false;
            selectionCardColumn5.IsSeachColumn = true;
            selectionCardColumn5.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn5.Visiable = true;
            selectionCardColumn5.Width = 75;
            selectionCardColumn6.AutoFill = false;
            selectionCardColumn6.DataBindField = "CODE";
            selectionCardColumn6.HeaderText = "国标码";
            selectionCardColumn6.IsNameField = false;
            selectionCardColumn6.IsSeachColumn = false;
            selectionCardColumn6.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn6.Visiable = false;
            selectionCardColumn6.Width = 75;
            selectionCardColumn7.AutoFill = false;
            selectionCardColumn7.DataBindField = "PY_CODE";
            selectionCardColumn7.HeaderText = null;
            selectionCardColumn7.IsNameField = false;
            selectionCardColumn7.IsSeachColumn = true;
            selectionCardColumn7.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn7.Visiable = false;
            selectionCardColumn7.Width = 75;
            selectionCardColumn8.AutoFill = false;
            selectionCardColumn8.DataBindField = "WB_CODE";
            selectionCardColumn8.HeaderText = null;
            selectionCardColumn8.IsNameField = false;
            selectionCardColumn8.IsSeachColumn = true;
            selectionCardColumn8.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn8.Visiable = false;
            selectionCardColumn8.Width = 75;
            this.qTxtWorkUnit.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn5,
        selectionCardColumn6,
        selectionCardColumn7,
        selectionCardColumn8};
            this.qTxtWorkUnit.SelectionCardFont = null;
            this.qTxtWorkUnit.SelectionCardHeight = 250;
            this.qTxtWorkUnit.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.qTxtWorkUnit.SelectionCardRowHeaderWidth = 35;
            this.qTxtWorkUnit.SelectionCardRowHeight = 23;
            this.qTxtWorkUnit.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.qTxtWorkUnit.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.qTxtWorkUnit.SelectionCardWidth = 500;
            this.qTxtWorkUnit.ShowRowNumber = true;
            this.qTxtWorkUnit.ShowSelectionCardAfterEnter = false;
            this.qTxtWorkUnit.Size = new System.Drawing.Size(621, 26);
            this.qTxtWorkUnit.TabIndex = 28;
            this.qTxtWorkUnit.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.qTxtWorkUnit.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.qTxtWorkUnit_AfterSelectedRow);
            // 
            // cboJob
            // 
            this.cboJob.BackColor = System.Drawing.Color.White;
            this.cboJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJob.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboJob.ForeColor = System.Drawing.Color.Black;
            this.cboJob.FormattingEnabled = true;
            this.cboJob.Items.AddRange(new object[] {
            "干部",
            "工人",
            "农民",
            "科技",
            "教师",
            "学生",
            "离退",
            "家务",
            "待业",
            "儿童",
            "其他"});
            this.cboJob.Location = new System.Drawing.Point(360, 83);
            this.cboJob.Name = "cboJob";
            this.cboJob.Size = new System.Drawing.Size(270, 24);
            this.cboJob.TabIndex = 21;
            // 
            // cboFeeType
            // 
            this.cboFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeeType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboFeeType.FormattingEnabled = true;
            this.cboFeeType.Location = new System.Drawing.Point(116, 83);
            this.cboFeeType.Name = "cboFeeType";
            this.cboFeeType.Size = new System.Drawing.Size(135, 24);
            this.cboFeeType.TabIndex = 19;
            // 
            // cboSex
            // 
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "未知的性别",
            "男性",
            "女性"});
            this.cboSex.Location = new System.Drawing.Point(360, 51);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(62, 24);
            this.cboSex.TabIndex = 12;
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTel.Location = new System.Drawing.Point(116, 183);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(621, 26);
            this.txtTel.TabIndex = 26;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.Location = new System.Drawing.Point(116, 149);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(621, 26);
            this.txtAddress.TabIndex = 24;
            // 
            // txtIdentityCard
            // 
            this.txtIdentityCard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIdentityCard.Location = new System.Drawing.Point(116, 115);
            this.txtIdentityCard.Name = "txtIdentityCard";
            this.txtIdentityCard.Size = new System.Drawing.Size(621, 26);
            this.txtIdentityCard.TabIndex = 23;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(116, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(135, 26);
            this.txtName.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(272, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "职  业  ：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(32, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "工作单位：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(32, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "电    话：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(32, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "地    址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(32, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "身份证号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(32, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "病人类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(449, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "年  龄  ：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(272, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "性  别  ：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "姓  名  ：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(32, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 29;
            this.label10.Text = "诊疗卡号：";
            // 
            // tBCardno
            // 
            this.tBCardno.BackColor = System.Drawing.Color.White;
            this.tBCardno.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBCardno.Location = new System.Drawing.Point(116, 16);
            this.tBCardno.Name = "tBCardno";
            this.tBCardno.ReadOnly = true;
            this.tBCardno.Size = new System.Drawing.Size(135, 26);
            this.tBCardno.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(272, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 31;
            this.label11.Text = "门 诊 号：";
            // 
            // tBVisitNo
            // 
            this.tBVisitNo.BackColor = System.Drawing.SystemColors.Info;
            this.tBVisitNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBVisitNo.Location = new System.Drawing.Point(360, 16);
            this.tBVisitNo.Name = "tBVisitNo";
            this.tBVisitNo.Size = new System.Drawing.Size(270, 26);
            this.tBVisitNo.TabIndex = 32;
            this.tBVisitNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBVisitNo_KeyPress);
            // 
            // txtAllergic
            // 
            this.txtAllergic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAllergic.BackColor = System.Drawing.Color.White;
            this.txtAllergic.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAllergic.Location = new System.Drawing.Point(116, 253);
            this.txtAllergic.Name = "txtAllergic";
            this.txtAllergic.Size = new System.Drawing.Size(621, 26);
            this.txtAllergic.TabIndex = 34;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(32, 259);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 16);
            this.label17.TabIndex = 33;
            this.label17.Text = "过 敏 史：";
            // 
            // FrmPatInfoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 424);
            this.Name = "FrmPatInfoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPatInfoEdit";
            this.Load += new System.EventHandler(this.FrmPatInfoEdit_Load);
            this.plBaseWorkArea.ResumeLayout(false);
            this.plBaseWorkArea.PerformLayout();
            this.plbottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plbottom;
        private GWI.HIS.Windows.Controls.Button btSure;
        private GWI.HIS.Windows.Controls.Button btCancel;
        private System.Windows.Forms.ComboBox cbBAgeType;
        private System.Windows.Forms.TextBox txtAge;
        private GWI.HIS.Windows.Controls.QueryTextBox qTxtWorkUnit;
        private System.Windows.Forms.ComboBox cboJob;
        private System.Windows.Forms.ComboBox cboFeeType;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtIdentityCard;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBCardno;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tBVisitNo;
        private System.Windows.Forms.TextBox txtAllergic;
        private System.Windows.Forms.Label label17;
    }
}