namespace HIS_YPManager
{
    partial class ZYFrmDrugDispenseJG
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZYFrmDrugDispenseJG));
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDeptDraw = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtPatAge = new System.Windows.Forms.TextBox();
            this.txtPatName = new System.Windows.Forms.TextBox();
            this.lblPatName = new System.Windows.Forms.Label();
            this.lblPatSex = new System.Windows.Forms.Label();
            this.lblPatAge = new System.Windows.Forms.Label();
            this.txtPatSex = new System.Windows.Forms.TextBox();
            this.txtQueryNum = new GWMHIS.PublicControls.InpatientNOTextBox(this.components);
            this.btnUnifDept = new System.Windows.Forms.Button();
            this.btnInpatNum = new System.Windows.Forms.Button();
            this.lblQueryNum = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lstPatInfo = new System.Windows.Forms.ListView();
            this.CPatName = new System.Windows.Forms.ColumnHeader();
            this.CPatSex = new System.Windows.Forms.ColumnHeader();
            this.CPatBirthDate = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgrdRecipeInfo = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrugName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrugSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDispense = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DispenseDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CureDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnDispense = new System.Windows.Forms.Button();
            this.txtDespencer = new System.Windows.Forms.TextBox();
            this.lblDispenser = new System.Windows.Forms.Label();
            this.plBaseWorkArea.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdRecipeInfo)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Size = new System.Drawing.Size(1014, 0);
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
            this.plBaseStatus.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plBaseStatus.Location = new System.Drawing.Point(0, 732);
            this.plBaseStatus.Size = new System.Drawing.Size(1014, 0);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.splitContainer1);
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 34);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1014, 698);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtDeptDraw);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.txtQueryNum);
            this.panel2.Controls.Add(this.btnUnifDept);
            this.panel2.Controls.Add(this.btnInpatNum);
            this.panel2.Controls.Add(this.lblQueryNum);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 39);
            this.panel2.TabIndex = 1;
            // 
            // txtDeptDraw
            // 
            this.txtDeptDraw.AllowSelectedNullRow = false;
            this.txtDeptDraw.DisplayField = "NAME";
            this.txtDeptDraw.Location = new System.Drawing.Point(67, 8);
            this.txtDeptDraw.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtDeptDraw.MemberField = "DEPT_ID";
            this.txtDeptDraw.MemberValue = null;
            this.txtDeptDraw.Name = "txtDeptDraw";
            this.txtDeptDraw.NextControl = null;
            this.txtDeptDraw.NextControlByEnter = false;
            this.txtDeptDraw.OffsetX = 0;
            this.txtDeptDraw.OffsetY = 0;
            this.txtDeptDraw.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.txtDeptDraw.SelectedValue = null;
            this.txtDeptDraw.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDeptDraw.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtDeptDraw.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn1.AutoFill = true;
            selectionCardColumn1.DataBindField = "NAME";
            selectionCardColumn1.HeaderText = "科室名称";
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 75;
            this.txtDeptDraw.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1};
            this.txtDeptDraw.SelectionCardFont = null;
            this.txtDeptDraw.SelectionCardHeight = 250;
            this.txtDeptDraw.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtDeptDraw.SelectionCardRowHeaderWidth = 35;
            this.txtDeptDraw.SelectionCardRowHeight = 23;
            this.txtDeptDraw.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtDeptDraw.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.txtDeptDraw.SelectionCardWidth = 250;
            this.txtDeptDraw.ShowRowNumber = true;
            this.txtDeptDraw.ShowSelectionCardAfterEnter = false;
            this.txtDeptDraw.Size = new System.Drawing.Size(110, 23);
            this.txtDeptDraw.TabIndex = 16;
            this.txtDeptDraw.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtDeptDraw.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txtDeptDraw_AfterSelectedRow);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.txtPatAge);
            this.panel8.Controls.Add(this.txtPatName);
            this.panel8.Controls.Add(this.lblPatName);
            this.panel8.Controls.Add(this.lblPatSex);
            this.panel8.Controls.Add(this.lblPatAge);
            this.panel8.Controls.Add(this.txtPatSex);
            this.panel8.Location = new System.Drawing.Point(203, 1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(401, 35);
            this.panel8.TabIndex = 5;
            // 
            // txtPatAge
            // 
            this.txtPatAge.BackColor = System.Drawing.SystemColors.Window;
            this.txtPatAge.Location = new System.Drawing.Point(288, 5);
            this.txtPatAge.Name = "txtPatAge";
            this.txtPatAge.Size = new System.Drawing.Size(67, 23);
            this.txtPatAge.TabIndex = 15;
            this.txtPatAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPatName
            // 
            this.txtPatName.BackColor = System.Drawing.SystemColors.Window;
            this.txtPatName.Location = new System.Drawing.Point(79, 5);
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.Size = new System.Drawing.Size(74, 23);
            this.txtPatName.TabIndex = 14;
            this.txtPatName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPatName
            // 
            this.lblPatName.AutoSize = true;
            this.lblPatName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatName.Location = new System.Drawing.Point(10, 10);
            this.lblPatName.Name = "lblPatName";
            this.lblPatName.Size = new System.Drawing.Size(67, 14);
            this.lblPatName.TabIndex = 5;
            this.lblPatName.Text = "病人姓名";
            // 
            // lblPatSex
            // 
            this.lblPatSex.AutoSize = true;
            this.lblPatSex.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatSex.Location = new System.Drawing.Point(159, 10);
            this.lblPatSex.Name = "lblPatSex";
            this.lblPatSex.Size = new System.Drawing.Size(37, 14);
            this.lblPatSex.TabIndex = 7;
            this.lblPatSex.Text = "性别";
            // 
            // lblPatAge
            // 
            this.lblPatAge.AutoSize = true;
            this.lblPatAge.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatAge.Location = new System.Drawing.Point(245, 10);
            this.lblPatAge.Name = "lblPatAge";
            this.lblPatAge.Size = new System.Drawing.Size(37, 14);
            this.lblPatAge.TabIndex = 9;
            this.lblPatAge.Text = "年龄";
            // 
            // txtPatSex
            // 
            this.txtPatSex.BackColor = System.Drawing.SystemColors.Window;
            this.txtPatSex.Location = new System.Drawing.Point(202, 5);
            this.txtPatSex.Name = "txtPatSex";
            this.txtPatSex.ReadOnly = true;
            this.txtPatSex.Size = new System.Drawing.Size(35, 23);
            this.txtPatSex.TabIndex = 13;
            this.txtPatSex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtQueryNum
            // 
            this.txtQueryNum.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.txtQueryNum.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.txtQueryNum.EnterBackColor = System.Drawing.SystemColors.Window;
            this.txtQueryNum.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.txtQueryNum.Location = new System.Drawing.Point(67, 8);
            this.txtQueryNum.Name = "txtQueryNum";
            this.txtQueryNum.NextControl = null;
            this.txtQueryNum.PreviousControl = null;
            this.txtQueryNum.Size = new System.Drawing.Size(110, 23);
            this.txtQueryNum.TabIndex = 27;
            this.txtQueryNum.Text = "00000000";
            this.txtQueryNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQueryNum_KeyDown);
            // 
            // btnUnifDept
            // 
            this.btnUnifDept.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUnifDept.Image = ((System.Drawing.Image)(resources.GetObject("btnUnifDept.Image")));
            this.btnUnifDept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnifDept.Location = new System.Drawing.Point(612, 2);
            this.btnUnifDept.Name = "btnUnifDept";
            this.btnUnifDept.Size = new System.Drawing.Size(88, 28);
            this.btnUnifDept.TabIndex = 16;
            this.btnUnifDept.Text = "统领科室";
            this.btnUnifDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnifDept.UseVisualStyleBackColor = true;
            this.btnUnifDept.Click += new System.EventHandler(this.btnUnifDept_Click);
            // 
            // btnInpatNum
            // 
            this.btnInpatNum.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInpatNum.Image = ((System.Drawing.Image)(resources.GetObject("btnInpatNum.Image")));
            this.btnInpatNum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInpatNum.Location = new System.Drawing.Point(706, 2);
            this.btnInpatNum.Name = "btnInpatNum";
            this.btnInpatNum.Size = new System.Drawing.Size(88, 28);
            this.btnInpatNum.TabIndex = 3;
            this.btnInpatNum.Text = "住院号码";
            this.btnInpatNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInpatNum.UseVisualStyleBackColor = true;
            this.btnInpatNum.Click += new System.EventHandler(this.btnInpatNum_Click);
            // 
            // lblQueryNum
            // 
            this.lblQueryNum.AutoSize = true;
            this.lblQueryNum.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryNum.Location = new System.Drawing.Point(9, 12);
            this.lblQueryNum.Name = "lblQueryNum";
            this.lblQueryNum.Size = new System.Drawing.Size(52, 14);
            this.lblQueryNum.TabIndex = 0;
            this.lblQueryNum.Text = "住院号";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel9);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1014, 659);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lstPatInfo);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 32);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(276, 627);
            this.panel9.TabIndex = 4;
            // 
            // lstPatInfo
            // 
            this.lstPatInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.lstPatInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CPatName,
            this.CPatSex,
            this.CPatBirthDate});
            this.lstPatInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPatInfo.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstPatInfo.FullRowSelect = true;
            this.lstPatInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstPatInfo.Location = new System.Drawing.Point(0, 0);
            this.lstPatInfo.Name = "lstPatInfo";
            this.lstPatInfo.Size = new System.Drawing.Size(276, 627);
            this.lstPatInfo.TabIndex = 1;
            this.lstPatInfo.UseCompatibleStateImageBehavior = false;
            this.lstPatInfo.View = System.Windows.Forms.View.Details;
            this.lstPatInfo.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstPatInfo_ItemChecked);
            this.lstPatInfo.SelectedIndexChanged += new System.EventHandler(this.lstPatInfo_SelectedIndexChanged);
            this.lstPatInfo.DoubleClick += new System.EventHandler(this.lstPatInfo_DoubleClick);
            // 
            // CPatName
            // 
            this.CPatName.Text = "姓名";
            this.CPatName.Width = 79;
            // 
            // CPatSex
            // 
            this.CPatSex.Text = "性别";
            this.CPatSex.Width = 44;
            // 
            // CPatBirthDate
            // 
            this.CPatBirthDate.Text = "出生日期";
            this.CPatBirthDate.Width = 119;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnRefresh);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(276, 32);
            this.panel4.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(0, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(274, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新病人表";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel5.Location = new System.Drawing.Point(0, 38);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(733, 621);
            this.panel5.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgrdRecipeInfo);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 24);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(733, 597);
            this.panel7.TabIndex = 2;
            // 
            // dgrdRecipeInfo
            // 
            this.dgrdRecipeInfo.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdRecipeInfo.AllowSortWhenClickColumnHeader = false;
            this.dgrdRecipeInfo.AllowUserToAddRows = false;
            this.dgrdRecipeInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdRecipeInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdRecipeInfo.ColumnHeadersHeight = 35;
            this.dgrdRecipeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.DrugName,
            this.DrugSpec,
            this.ProductName,
            this.IsDispense,
            this.Num,
            this.Unit,
            this.RetailPrice,
            this.RetailFee,
            this.DispenseDept,
            this.CureDoc,
            this.Column1});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdRecipeInfo.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgrdRecipeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdRecipeInfo.EnableHeadersVisualStyles = false;
            this.dgrdRecipeInfo.Location = new System.Drawing.Point(0, 0);
            this.dgrdRecipeInfo.Name = "dgrdRecipeInfo";
            this.dgrdRecipeInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdRecipeInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdRecipeInfo.RowHeadersVisible = false;
            this.dgrdRecipeInfo.RowTemplate.Height = 23;
            this.dgrdRecipeInfo.SelectionCards = null;
            this.dgrdRecipeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgrdRecipeInfo.Size = new System.Drawing.Size(733, 597);
            this.dgrdRecipeInfo.TabIndex = 0;
            this.dgrdRecipeInfo.UseGradientBackgroundColor = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ITEMID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "编码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 50;
            // 
            // DrugName
            // 
            this.DrugName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DrugName.DataPropertyName = "ITEMNAME";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DrugName.DefaultCellStyle = dataGridViewCellStyle3;
            this.DrugName.HeaderText = "药品名称";
            this.DrugName.Name = "DrugName";
            this.DrugName.ReadOnly = true;
            this.DrugName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DrugSpec
            // 
            this.DrugSpec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DrugSpec.DataPropertyName = "STANDARD";
            this.DrugSpec.HeaderText = "药品规格";
            this.DrugSpec.Name = "DrugSpec";
            this.DrugSpec.ReadOnly = true;
            this.DrugSpec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.DataPropertyName = "PRODUCTNAME";
            this.ProductName.HeaderText = "生产厂家";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IsDispense
            // 
            this.IsDispense.DataPropertyName = "ISDISPENSE";
            this.IsDispense.HeaderText = "选择";
            this.IsDispense.Name = "IsDispense";
            this.IsDispense.Width = 30;
            // 
            // Num
            // 
            this.Num.DataPropertyName = "AMOUNT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Num.DefaultCellStyle = dataGridViewCellStyle4;
            this.Num.HeaderText = "数量";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Num.Width = 60;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "UNIT";
            this.Unit.HeaderText = "单位";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Unit.Width = 35;
            // 
            // RetailPrice
            // 
            this.RetailPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RetailPrice.DataPropertyName = "SELL_PRICE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.RetailPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.RetailPrice.HeaderText = "零售价格";
            this.RetailPrice.Name = "RetailPrice";
            this.RetailPrice.ReadOnly = true;
            this.RetailPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RetailPrice.Width = 42;
            // 
            // RetailFee
            // 
            this.RetailFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RetailFee.DataPropertyName = "TOLAL_FEE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.RetailFee.DefaultCellStyle = dataGridViewCellStyle6;
            this.RetailFee.HeaderText = "零售金额";
            this.RetailFee.Name = "RetailFee";
            this.RetailFee.ReadOnly = true;
            this.RetailFee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RetailFee.Width = 42;
            // 
            // DispenseDept
            // 
            this.DispenseDept.DataPropertyName = "PRESDEPTNAME";
            this.DispenseDept.HeaderText = "主治科室";
            this.DispenseDept.Name = "DispenseDept";
            this.DispenseDept.ReadOnly = true;
            this.DispenseDept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DispenseDept.Width = 60;
            // 
            // CureDoc
            // 
            this.CureDoc.DataPropertyName = "PRESDOCNAME";
            this.CureDoc.HeaderText = "主治医生";
            this.CureDoc.Name = "CureDoc";
            this.CureDoc.ReadOnly = true;
            this.CureDoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CureDoc.Width = 60;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "COSTDATE";
            this.Column1.HeaderText = "记账时间";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 80;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(733, 24);
            this.panel6.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "发药明细";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnQuit);
            this.panel3.Controls.Add(this.btnDispense);
            this.panel3.Controls.Add(this.txtDespencer);
            this.panel3.Controls.Add(this.lblDispenser);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(733, 38);
            this.panel3.TabIndex = 0;
            // 
            // btnQuit
            // 
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.Location = new System.Drawing.Point(250, 3);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(88, 29);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "关闭(&C)";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnDispense
            // 
            this.btnDispense.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDispense.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDispense.Image = ((System.Drawing.Image)(resources.GetObject("btnDispense.Image")));
            this.btnDispense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDispense.Location = new System.Drawing.Point(156, 3);
            this.btnDispense.Name = "btnDispense";
            this.btnDispense.Size = new System.Drawing.Size(88, 29);
            this.btnDispense.TabIndex = 2;
            this.btnDispense.Text = "发药(F2)";
            this.btnDispense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDispense.UseVisualStyleBackColor = true;
            this.btnDispense.Click += new System.EventHandler(this.btnDispense_Click);
            // 
            // txtDespencer
            // 
            this.txtDespencer.BackColor = System.Drawing.SystemColors.Window;
            this.txtDespencer.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtDespencer.Location = new System.Drawing.Point(61, 6);
            this.txtDespencer.Name = "txtDespencer";
            this.txtDespencer.ReadOnly = true;
            this.txtDespencer.Size = new System.Drawing.Size(89, 23);
            this.txtDespencer.TabIndex = 1;
            this.txtDespencer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDispenser
            // 
            this.lblDispenser.AutoSize = true;
            this.lblDispenser.Location = new System.Drawing.Point(6, 10);
            this.lblDispenser.Name = "lblDispenser";
            this.lblDispenser.Size = new System.Drawing.Size(49, 14);
            this.lblDispenser.TabIndex = 0;
            this.lblDispenser.Text = "发药人";
            // 
            // ZYFrmDrugDispense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 732);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "住院药房发药";
            this.KeyPreview = true;
            this.Name = "ZYFrmDrugDispense";
            this.Text = "住院药房发药";
            this.Load += new System.EventHandler(this.ZYFrmDrugDispense_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZYFrmDrugDispense_KeyDown);
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdRecipeInfo)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblQueryNum;
        private System.Windows.Forms.Label lblPatAge;
        private System.Windows.Forms.Label lblPatSex;
        private System.Windows.Forms.Label lblPatName;
        private System.Windows.Forms.Button btnInpatNum;
        private System.Windows.Forms.Button btnDispense;
        private System.Windows.Forms.TextBox txtDespencer;
        private System.Windows.Forms.Label lblDispenser;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtPatSex;
        private System.Windows.Forms.ListView lstPatInfo;
        private System.Windows.Forms.ColumnHeader CPatName;
        private System.Windows.Forms.ColumnHeader CPatSex;
        private System.Windows.Forms.ColumnHeader CPatBirthDate;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdRecipeInfo;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUnifDept;
        private GWMHIS.PublicControls.InpatientNOTextBox txtQueryNum;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtPatAge;
        private System.Windows.Forms.TextBox txtPatName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel9;
        private GWI.HIS.Windows.Controls.QueryTextBox txtDeptDraw;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrugName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrugSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDispense;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn DispenseDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn CureDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}


