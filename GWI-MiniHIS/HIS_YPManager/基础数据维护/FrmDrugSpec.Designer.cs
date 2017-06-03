namespace HIS_YPManager
{
    partial class FrmDrugSpec
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private string _chineseName;
        private long _currentUserId;
        private long _currentDeptId;

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
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn7 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn4 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn5 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDrugSpec));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSetDrugspec = new System.Windows.Forms.Panel();
            this.txtLatinName = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtDgType = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtPackUnit = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtPackNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDrugSpec = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtPharmacology = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtGBCode = new System.Windows.Forms.TextBox();
            this.lblSepc = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkIsUse = new System.Windows.Forms.CheckBox();
            this.radWZ = new System.Windows.Forms.RadioButton();
            this.txtQueryCode = new System.Windows.Forms.TextBox();
            this.radShowAll = new System.Windows.Forms.RadioButton();
            this.lblQuery = new System.Windows.Forms.Label();
            this.radZCY = new System.Windows.Forms.RadioButton();
            this.radZY = new System.Windows.Forms.RadioButton();
            this.radXY = new System.Windows.Forms.RadioButton();
            this.txtDrugName = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtChemName = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtDrugDose = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtDoseUnit = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtLeastUnit = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtDoseNum = new System.Windows.Forms.TextBox();
            this.lblPharmacology = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGBCode = new System.Windows.Forms.Label();
            this.lblPackUnit = new System.Windows.Forms.Label();
            this.lblDoseNum = new System.Windows.Forms.Label();
            this.lblChemName = new System.Windows.Forms.Label();
            this.lblPackNum = new System.Windows.Forms.Label();
            this.lblDoseUnit = new System.Windows.Forms.Label();
            this.lblDoseDrug = new System.Windows.Forms.Label();
            this.lblDrugName = new System.Windows.Forms.Label();
            this.lblLeastUnit = new System.Windows.Forms.Label();
            this.tsrDrugSpec = new GWI.HIS.Windows.Controls.ToolStrip();
            this.tsrbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnDel = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnByName = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnMakerDic = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnExport = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnCancelDel = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnQuit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel6 = new System.Windows.Forms.Panel();
            this.treePharmacology = new System.Windows.Forms.TreeView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblPharmacologyTitle = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgrdDrugSpec = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.GBCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LatinName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackunitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoseUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoseNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Del_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.pnlSetDrugspec.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsrDrugSpec.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDrugSpec)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add(this.tsrDrugSpec);
            this.plBaseToolbar.Size = new System.Drawing.Size(1014, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 706);
            this.plBaseStatus.Size = new System.Drawing.Size(1014, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1014, 643);
            // 
            // pnlSetDrugspec
            // 
            this.pnlSetDrugspec.BackColor = System.Drawing.Color.Transparent;
            this.pnlSetDrugspec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSetDrugspec.Controls.Add(this.txtLatinName);
            this.pnlSetDrugspec.Controls.Add(this.label2);
            this.pnlSetDrugspec.Controls.Add(this.txtDrugSpec);
            this.pnlSetDrugspec.Controls.Add(this.lblSepc);
            this.pnlSetDrugspec.Controls.Add(this.panel2);
            this.pnlSetDrugspec.Controls.Add(this.txtDrugName);
            this.pnlSetDrugspec.Controls.Add(this.txtChemName);
            this.pnlSetDrugspec.Controls.Add(this.txtDrugDose);
            this.pnlSetDrugspec.Controls.Add(this.txtPharmacology);
            this.pnlSetDrugspec.Controls.Add(this.txtDoseUnit);
            this.pnlSetDrugspec.Controls.Add(this.txtLeastUnit);
            this.pnlSetDrugspec.Controls.Add(this.txtPackUnit);
            this.pnlSetDrugspec.Controls.Add(this.txtDgType);
            this.pnlSetDrugspec.Controls.Add(this.lblPharmacology);
            this.pnlSetDrugspec.Controls.Add(this.label1);
            this.pnlSetDrugspec.Controls.Add(this.txtGBCode);
            this.pnlSetDrugspec.Controls.Add(this.lblGBCode);
            this.pnlSetDrugspec.Controls.Add(this.lblPackUnit);
            this.pnlSetDrugspec.Controls.Add(this.txtDoseNum);
            this.pnlSetDrugspec.Controls.Add(this.lblDoseNum);
            this.pnlSetDrugspec.Controls.Add(this.txtPackNum);
            this.pnlSetDrugspec.Controls.Add(this.lblChemName);
            this.pnlSetDrugspec.Controls.Add(this.lblPackNum);
            this.pnlSetDrugspec.Controls.Add(this.lblDoseUnit);
            this.pnlSetDrugspec.Controls.Add(this.lblDoseDrug);
            this.pnlSetDrugspec.Controls.Add(this.lblDrugName);
            this.pnlSetDrugspec.Controls.Add(this.lblLeastUnit);
            this.pnlSetDrugspec.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetDrugspec.Location = new System.Drawing.Point(0, 0);
            this.pnlSetDrugspec.Name = "pnlSetDrugspec";
            this.pnlSetDrugspec.Size = new System.Drawing.Size(789, 180);
            this.pnlSetDrugspec.TabIndex = 0;
            // 
            // txtLatinName
            // 
            this.txtLatinName.AllowSelectedNullRow = false;
            this.txtLatinName.BackColor = System.Drawing.Color.White;
            this.txtLatinName.DisplayField = "";
            this.txtLatinName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLatinName.Location = new System.Drawing.Point(565, 6);
            this.txtLatinName.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtLatinName.MemberField = "";
            this.txtLatinName.MemberValue = null;
            this.txtLatinName.Name = "txtLatinName";
            this.txtLatinName.NextControl = this.txtDgType;
            this.txtLatinName.NextControlByEnter = true;
            this.txtLatinName.OffsetX = 0;
            this.txtLatinName.OffsetY = 0;
            this.txtLatinName.QueryFields = null;
            this.txtLatinName.SelectedValue = null;
            this.txtLatinName.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLatinName.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtLatinName.SelectionCardColumnHeaderHeight = 30;
            this.txtLatinName.SelectionCardColumns = null;
            this.txtLatinName.SelectionCardFont = null;
            this.txtLatinName.SelectionCardHeight = 250;
            this.txtLatinName.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtLatinName.SelectionCardRowHeaderWidth = 35;
            this.txtLatinName.SelectionCardRowHeight = 23;
            this.txtLatinName.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtLatinName.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtLatinName.SelectionCardWidth = 250;
            this.txtLatinName.ShowRowNumber = true;
            this.txtLatinName.ShowSelectionCardAfterEnter = false;
            this.txtLatinName.Size = new System.Drawing.Size(176, 23);
            this.txtLatinName.TabIndex = 28;
            this.txtLatinName.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtLatinName.TextChanged += new System.EventHandler(this.txtLatinName_TextChanged);
            this.txtLatinName.Leave += new System.EventHandler(this.txtLatinName_Leave);
            this.txtLatinName.Enter += new System.EventHandler(this.txtLatinName_Enter);
            // 
            // txtDgType
            // 
            this.txtDgType.AllowSelectedNullRow = false;
            this.txtDgType.BackColor = System.Drawing.Color.White;
            this.txtDgType.DisplayField = "TYPENAME";
            this.txtDgType.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDgType.Location = new System.Drawing.Point(72, 34);
            this.txtDgType.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtDgType.MemberField = "TYPEDICID";
            this.txtDgType.MemberValue = null;
            this.txtDgType.Name = "txtDgType";
            this.txtDgType.NextControl = this.txtPackUnit;
            this.txtDgType.NextControlByEnter = true;
            this.txtDgType.OffsetX = 0;
            this.txtDgType.OffsetY = 0;
            this.txtDgType.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.txtDgType.SelectedValue = null;
            this.txtDgType.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDgType.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtDgType.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn1.AutoFill = true;
            selectionCardColumn1.DataBindField = "TYPENAME";
            selectionCardColumn1.HeaderText = "药品类型";
            selectionCardColumn1.IsNameField = false;
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 75;
            this.txtDgType.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1};
            this.txtDgType.SelectionCardFont = null;
            this.txtDgType.SelectionCardHeight = 250;
            this.txtDgType.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtDgType.SelectionCardRowHeaderWidth = 35;
            this.txtDgType.SelectionCardRowHeight = 23;
            this.txtDgType.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtDgType.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.txtDgType.SelectionCardWidth = 250;
            this.txtDgType.ShowRowNumber = true;
            this.txtDgType.ShowSelectionCardAfterEnter = false;
            this.txtDgType.Size = new System.Drawing.Size(59, 23);
            this.txtDgType.TabIndex = 2;
            this.txtDgType.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtDgType.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txtDgType_AfterSelectedRow);
            // 
            // txtPackUnit
            // 
            this.txtPackUnit.AllowSelectedNullRow = false;
            this.txtPackUnit.BackColor = System.Drawing.Color.White;
            this.txtPackUnit.DisplayField = "UNITNAME";
            this.txtPackUnit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPackUnit.Location = new System.Drawing.Point(198, 34);
            this.txtPackUnit.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtPackUnit.MemberField = "UNITDICID";
            this.txtPackUnit.MemberValue = null;
            this.txtPackUnit.Name = "txtPackUnit";
            this.txtPackUnit.NextControl = this.txtPackNum;
            this.txtPackUnit.NextControlByEnter = true;
            this.txtPackUnit.OffsetX = 0;
            this.txtPackUnit.OffsetY = 0;
            this.txtPackUnit.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.txtPackUnit.SelectedValue = null;
            this.txtPackUnit.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPackUnit.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtPackUnit.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn7.AutoFill = true;
            selectionCardColumn7.DataBindField = "UNITNAME";
            selectionCardColumn7.HeaderText = "单位";
            selectionCardColumn7.IsNameField = false;
            selectionCardColumn7.IsSeachColumn = false;
            selectionCardColumn7.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn7.Visiable = true;
            selectionCardColumn7.Width = 75;
            this.txtPackUnit.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn7};
            this.txtPackUnit.SelectionCardFont = null;
            this.txtPackUnit.SelectionCardHeight = 250;
            this.txtPackUnit.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtPackUnit.SelectionCardRowHeaderWidth = 35;
            this.txtPackUnit.SelectionCardRowHeight = 23;
            this.txtPackUnit.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtPackUnit.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.txtPackUnit.SelectionCardWidth = 250;
            this.txtPackUnit.ShowRowNumber = true;
            this.txtPackUnit.ShowSelectionCardAfterEnter = false;
            this.txtPackUnit.Size = new System.Drawing.Size(47, 23);
            this.txtPackUnit.TabIndex = 3;
            this.txtPackUnit.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtPackUnit.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txtPackUnit_AfterSelectedRow);
            // 
            // txtPackNum
            // 
            this.txtPackNum.BackColor = System.Drawing.Color.White;
            this.txtPackNum.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPackNum.Location = new System.Drawing.Point(320, 34);
            this.txtPackNum.MaxLength = 10;
            this.txtPackNum.Name = "txtPackNum";
            this.txtPackNum.Size = new System.Drawing.Size(51, 23);
            this.txtPackNum.TabIndex = 4;
            this.txtPackNum.TextChanged += new System.EventHandler(this.txtPackNum_TextChanged);
            this.txtPackNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPackNum_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(499, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "拉丁名称";
            // 
            // txtDrugSpec
            // 
            this.txtDrugSpec.AllowSelectedNullRow = false;
            this.txtDrugSpec.BackColor = System.Drawing.Color.White;
            this.txtDrugSpec.DisplayField = "";
            this.txtDrugSpec.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDrugSpec.Location = new System.Drawing.Point(72, 63);
            this.txtDrugSpec.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtDrugSpec.MemberField = "";
            this.txtDrugSpec.MemberValue = null;
            this.txtDrugSpec.Name = "txtDrugSpec";
            this.txtDrugSpec.NextControl = this.txtPharmacology;
            this.txtDrugSpec.NextControlByEnter = true;
            this.txtDrugSpec.OffsetX = 0;
            this.txtDrugSpec.OffsetY = 0;
            this.txtDrugSpec.QueryFields = null;
            this.txtDrugSpec.SelectedValue = null;
            this.txtDrugSpec.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDrugSpec.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtDrugSpec.SelectionCardColumnHeaderHeight = 30;
            this.txtDrugSpec.SelectionCardColumns = null;
            this.txtDrugSpec.SelectionCardFont = null;
            this.txtDrugSpec.SelectionCardHeight = 250;
            this.txtDrugSpec.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtDrugSpec.SelectionCardRowHeaderWidth = 35;
            this.txtDrugSpec.SelectionCardRowHeight = 23;
            this.txtDrugSpec.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtDrugSpec.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtDrugSpec.SelectionCardWidth = 250;
            this.txtDrugSpec.ShowRowNumber = true;
            this.txtDrugSpec.ShowSelectionCardAfterEnter = false;
            this.txtDrugSpec.Size = new System.Drawing.Size(173, 23);
            this.txtDrugSpec.TabIndex = 25;
            this.txtDrugSpec.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtDrugSpec.TextChanged += new System.EventHandler(this.txtDrugSpec_TextChanged);
            // 
            // txtPharmacology
            // 
            this.txtPharmacology.AllowSelectedNullRow = false;
            this.txtPharmacology.BackColor = System.Drawing.Color.White;
            this.txtPharmacology.DisplayField = "NAME";
            this.txtPharmacology.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPharmacology.Location = new System.Drawing.Point(320, 63);
            this.txtPharmacology.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtPharmacology.MemberField = "ID";
            this.txtPharmacology.MemberValue = null;
            this.txtPharmacology.Name = "txtPharmacology";
            this.txtPharmacology.NextControl = this.txtGBCode;
            this.txtPharmacology.NextControlByEnter = true;
            this.txtPharmacology.OffsetX = 0;
            this.txtPharmacology.OffsetY = 0;
            this.txtPharmacology.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.txtPharmacology.SelectedValue = null;
            this.txtPharmacology.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPharmacology.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtPharmacology.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn2.AutoFill = true;
            selectionCardColumn2.DataBindField = "NAME";
            selectionCardColumn2.HeaderText = "药理分类";
            selectionCardColumn2.IsNameField = false;
            selectionCardColumn2.IsSeachColumn = false;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 75;
            this.txtPharmacology.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn2};
            this.txtPharmacology.SelectionCardFont = null;
            this.txtPharmacology.SelectionCardHeight = 250;
            this.txtPharmacology.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtPharmacology.SelectionCardRowHeaderWidth = 35;
            this.txtPharmacology.SelectionCardRowHeight = 23;
            this.txtPharmacology.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtPharmacology.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.txtPharmacology.SelectionCardWidth = 250;
            this.txtPharmacology.ShowRowNumber = true;
            this.txtPharmacology.ShowSelectionCardAfterEnter = false;
            this.txtPharmacology.Size = new System.Drawing.Size(173, 23);
            this.txtPharmacology.TabIndex = 8;
            this.txtPharmacology.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtPharmacology.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txtPharmacology_AfterSelectedRow);
            // 
            // txtGBCode
            // 
            this.txtGBCode.BackColor = System.Drawing.Color.White;
            this.txtGBCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGBCode.Location = new System.Drawing.Point(565, 63);
            this.txtGBCode.MaxLength = 30;
            this.txtGBCode.Name = "txtGBCode";
            this.txtGBCode.Size = new System.Drawing.Size(54, 23);
            this.txtGBCode.TabIndex = 9;
            this.txtGBCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGBCode_KeyDown);
            // 
            // lblSepc
            // 
            this.lblSepc.AutoSize = true;
            this.lblSepc.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSepc.Location = new System.Drawing.Point(3, 68);
            this.lblSepc.Name = "lblSepc";
            this.lblSepc.Size = new System.Drawing.Size(63, 14);
            this.lblSepc.TabIndex = 24;
            this.lblSepc.Text = "商品规格";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.chkIsUse);
            this.panel2.Controls.Add(this.radWZ);
            this.panel2.Controls.Add(this.txtQueryCode);
            this.panel2.Controls.Add(this.radShowAll);
            this.panel2.Controls.Add(this.lblQuery);
            this.panel2.Controls.Add(this.radZCY);
            this.panel2.Controls.Add(this.radZY);
            this.panel2.Controls.Add(this.radXY);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 87);
            this.panel2.TabIndex = 22;
            // 
            // chkIsUse
            // 
            this.chkIsUse.AutoSize = true;
            this.chkIsUse.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkIsUse.Location = new System.Drawing.Point(650, 10);
            this.chkIsUse.Name = "chkIsUse";
            this.chkIsUse.Size = new System.Drawing.Size(86, 18);
            this.chkIsUse.TabIndex = 7;
            this.chkIsUse.Text = "应用药品";
            this.chkIsUse.UseVisualStyleBackColor = true;
            // 
            // radWZ
            // 
            this.radWZ.AutoSize = true;
            this.radWZ.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radWZ.Location = new System.Drawing.Point(589, 10);
            this.radWZ.Name = "radWZ";
            this.radWZ.Size = new System.Drawing.Size(55, 18);
            this.radWZ.TabIndex = 6;
            this.radWZ.TabStop = true;
            this.radWZ.Text = "物资";
            this.radWZ.UseVisualStyleBackColor = true;
            this.radWZ.CheckedChanged += new System.EventHandler(this.radWZ_CheckedChanged);
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtQueryCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQueryCode.Location = new System.Drawing.Point(70, 8);
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.Size = new System.Drawing.Size(241, 23);
            this.txtQueryCode.TabIndex = 0;
            this.txtQueryCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQueryCode_KeyUp);
            // 
            // radShowAll
            // 
            this.radShowAll.AutoSize = true;
            this.radShowAll.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radShowAll.Location = new System.Drawing.Point(330, 10);
            this.radShowAll.Name = "radShowAll";
            this.radShowAll.Size = new System.Drawing.Size(55, 18);
            this.radShowAll.TabIndex = 2;
            this.radShowAll.TabStop = true;
            this.radShowAll.Text = "所有";
            this.radShowAll.UseVisualStyleBackColor = true;
            this.radShowAll.CheckedChanged += new System.EventHandler(this.radShowAll_CheckedChanged);
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQuery.Location = new System.Drawing.Point(3, 13);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(63, 14);
            this.lblQuery.TabIndex = 1;
            this.lblQuery.Text = "定位查询";
            // 
            // radZCY
            // 
            this.radZCY.AutoSize = true;
            this.radZCY.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radZCY.Location = new System.Drawing.Point(452, 10);
            this.radZCY.Name = "radZCY";
            this.radZCY.Size = new System.Drawing.Size(70, 18);
            this.radZCY.TabIndex = 4;
            this.radZCY.TabStop = true;
            this.radZCY.Text = "中成药";
            this.radZCY.UseVisualStyleBackColor = true;
            this.radZCY.CheckedChanged += new System.EventHandler(this.radZCY_CheckedChanged);
            // 
            // radZY
            // 
            this.radZY.AutoSize = true;
            this.radZY.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radZY.Location = new System.Drawing.Point(391, 10);
            this.radZY.Name = "radZY";
            this.radZY.Size = new System.Drawing.Size(55, 18);
            this.radZY.TabIndex = 3;
            this.radZY.TabStop = true;
            this.radZY.Text = "中药";
            this.radZY.UseVisualStyleBackColor = true;
            this.radZY.CheckedChanged += new System.EventHandler(this.radZY_CheckedChanged);
            // 
            // radXY
            // 
            this.radXY.AutoSize = true;
            this.radXY.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radXY.Location = new System.Drawing.Point(528, 10);
            this.radXY.Name = "radXY";
            this.radXY.Size = new System.Drawing.Size(55, 18);
            this.radXY.TabIndex = 5;
            this.radXY.TabStop = true;
            this.radXY.Text = "西药";
            this.radXY.UseVisualStyleBackColor = true;
            this.radXY.CheckedChanged += new System.EventHandler(this.radXY_CheckedChanged);
            // 
            // txtDrugName
            // 
            this.txtDrugName.AllowSelectedNullRow = false;
            this.txtDrugName.BackColor = System.Drawing.Color.White;
            this.txtDrugName.DisplayField = "";
            this.txtDrugName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDrugName.Location = new System.Drawing.Point(72, 6);
            this.txtDrugName.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtDrugName.MemberField = "";
            this.txtDrugName.MemberValue = null;
            this.txtDrugName.Name = "txtDrugName";
            this.txtDrugName.NextControl = this.txtChemName;
            this.txtDrugName.NextControlByEnter = true;
            this.txtDrugName.OffsetX = 0;
            this.txtDrugName.OffsetY = 0;
            this.txtDrugName.QueryFields = null;
            this.txtDrugName.SelectedValue = null;
            this.txtDrugName.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDrugName.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtDrugName.SelectionCardColumnHeaderHeight = 30;
            this.txtDrugName.SelectionCardColumns = null;
            this.txtDrugName.SelectionCardFont = null;
            this.txtDrugName.SelectionCardHeight = 250;
            this.txtDrugName.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtDrugName.SelectionCardRowHeaderWidth = 35;
            this.txtDrugName.SelectionCardRowHeight = 23;
            this.txtDrugName.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtDrugName.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtDrugName.SelectionCardWidth = 250;
            this.txtDrugName.ShowRowNumber = true;
            this.txtDrugName.ShowSelectionCardAfterEnter = false;
            this.txtDrugName.Size = new System.Drawing.Size(173, 23);
            this.txtDrugName.TabIndex = 1;
            this.txtDrugName.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtDrugName.TextChanged += new System.EventHandler(this.txtDrugName_TextChanged);
            this.txtDrugName.Leave += new System.EventHandler(this.txtDrugName_Leave);
            this.txtDrugName.Enter += new System.EventHandler(this.txtDrugName_Enter);
            // 
            // txtChemName
            // 
            this.txtChemName.AllowSelectedNullRow = false;
            this.txtChemName.BackColor = System.Drawing.Color.White;
            this.txtChemName.DisplayField = "";
            this.txtChemName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtChemName.Location = new System.Drawing.Point(320, 6);
            this.txtChemName.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtChemName.MemberField = "";
            this.txtChemName.MemberValue = null;
            this.txtChemName.Name = "txtChemName";
            this.txtChemName.NextControl = this.txtLatinName;
            this.txtChemName.NextControlByEnter = true;
            this.txtChemName.OffsetX = 0;
            this.txtChemName.OffsetY = 0;
            this.txtChemName.QueryFields = null;
            this.txtChemName.SelectedValue = null;
            this.txtChemName.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtChemName.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtChemName.SelectionCardColumnHeaderHeight = 30;
            this.txtChemName.SelectionCardColumns = null;
            this.txtChemName.SelectionCardFont = null;
            this.txtChemName.SelectionCardHeight = 250;
            this.txtChemName.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtChemName.SelectionCardRowHeaderWidth = 35;
            this.txtChemName.SelectionCardRowHeight = 23;
            this.txtChemName.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtChemName.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtChemName.SelectionCardWidth = 250;
            this.txtChemName.ShowRowNumber = true;
            this.txtChemName.ShowSelectionCardAfterEnter = false;
            this.txtChemName.Size = new System.Drawing.Size(173, 23);
            this.txtChemName.TabIndex = 23;
            this.txtChemName.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtChemName.TextChanged += new System.EventHandler(this.txtChemName_TextChanged);
            this.txtChemName.Leave += new System.EventHandler(this.txtChemName_Leave);
            this.txtChemName.Enter += new System.EventHandler(this.txtChemName_Enter);
            // 
            // txtDrugDose
            // 
            this.txtDrugDose.AllowSelectedNullRow = false;
            this.txtDrugDose.BackColor = System.Drawing.Color.White;
            this.txtDrugDose.DisplayField = "DOSENAME";
            this.txtDrugDose.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDrugDose.Location = new System.Drawing.Point(686, 63);
            this.txtDrugDose.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtDrugDose.MemberField = "DoseDicID";
            this.txtDrugDose.MemberValue = null;
            this.txtDrugDose.Name = "txtDrugDose";
            this.txtDrugDose.NextControl = null;
            this.txtDrugDose.NextControlByEnter = false;
            this.txtDrugDose.OffsetX = 0;
            this.txtDrugDose.OffsetY = 0;
            this.txtDrugDose.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.txtDrugDose.SelectedValue = null;
            this.txtDrugDose.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDrugDose.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtDrugDose.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn3.AutoFill = true;
            selectionCardColumn3.DataBindField = "DoseName";
            selectionCardColumn3.HeaderText = "药品剂型";
            selectionCardColumn3.IsNameField = false;
            selectionCardColumn3.IsSeachColumn = false;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn3.Visiable = true;
            selectionCardColumn3.Width = 75;
            this.txtDrugDose.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn3};
            this.txtDrugDose.SelectionCardFont = null;
            this.txtDrugDose.SelectionCardHeight = 250;
            this.txtDrugDose.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtDrugDose.SelectionCardRowHeaderWidth = 35;
            this.txtDrugDose.SelectionCardRowHeight = 23;
            this.txtDrugDose.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtDrugDose.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.txtDrugDose.SelectionCardWidth = 250;
            this.txtDrugDose.ShowRowNumber = true;
            this.txtDrugDose.ShowSelectionCardAfterEnter = false;
            this.txtDrugDose.Size = new System.Drawing.Size(55, 23);
            this.txtDrugDose.TabIndex = 10;
            this.txtDrugDose.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtDrugDose.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txtDrugDose_AfterSelectedRow);
            this.txtDrugDose.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrugDose_KeyPress);
            // 
            // txtDoseUnit
            // 
            this.txtDoseUnit.AllowSelectedNullRow = false;
            this.txtDoseUnit.BackColor = System.Drawing.Color.White;
            this.txtDoseUnit.DisplayField = "UNITNAME";
            this.txtDoseUnit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDoseUnit.Location = new System.Drawing.Point(686, 34);
            this.txtDoseUnit.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtDoseUnit.MemberField = "UNITDICID";
            this.txtDoseUnit.MemberValue = null;
            this.txtDoseUnit.Name = "txtDoseUnit";
            this.txtDoseUnit.NextControl = this.txtDrugSpec;
            this.txtDoseUnit.NextControlByEnter = true;
            this.txtDoseUnit.OffsetX = 0;
            this.txtDoseUnit.OffsetY = 0;
            this.txtDoseUnit.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.txtDoseUnit.SelectedValue = null;
            this.txtDoseUnit.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDoseUnit.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtDoseUnit.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn4.AutoFill = true;
            selectionCardColumn4.DataBindField = "UNITNAME";
            selectionCardColumn4.HeaderText = "单位";
            selectionCardColumn4.IsNameField = false;
            selectionCardColumn4.IsSeachColumn = false;
            selectionCardColumn4.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn4.Visiable = true;
            selectionCardColumn4.Width = 75;
            this.txtDoseUnit.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn4};
            this.txtDoseUnit.SelectionCardFont = null;
            this.txtDoseUnit.SelectionCardHeight = 250;
            this.txtDoseUnit.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtDoseUnit.SelectionCardRowHeaderWidth = 35;
            this.txtDoseUnit.SelectionCardRowHeight = 23;
            this.txtDoseUnit.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtDoseUnit.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.txtDoseUnit.SelectionCardWidth = 250;
            this.txtDoseUnit.ShowRowNumber = true;
            this.txtDoseUnit.ShowSelectionCardAfterEnter = false;
            this.txtDoseUnit.Size = new System.Drawing.Size(55, 23);
            this.txtDoseUnit.TabIndex = 7;
            this.txtDoseUnit.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtDoseUnit.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txtDoseUnit_AfterSelectedRow);
            // 
            // txtLeastUnit
            // 
            this.txtLeastUnit.AllowSelectedNullRow = false;
            this.txtLeastUnit.BackColor = System.Drawing.Color.White;
            this.txtLeastUnit.DisplayField = "UNITNAME";
            this.txtLeastUnit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLeastUnit.Location = new System.Drawing.Point(446, 34);
            this.txtLeastUnit.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtLeastUnit.MemberField = "UNITDICID";
            this.txtLeastUnit.MemberValue = null;
            this.txtLeastUnit.Name = "txtLeastUnit";
            this.txtLeastUnit.NextControl = this.txtDoseNum;
            this.txtLeastUnit.NextControlByEnter = true;
            this.txtLeastUnit.OffsetX = 0;
            this.txtLeastUnit.OffsetY = 0;
            this.txtLeastUnit.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.txtLeastUnit.SelectedValue = null;
            this.txtLeastUnit.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLeastUnit.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtLeastUnit.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn5.AutoFill = true;
            selectionCardColumn5.DataBindField = "UNITNAME";
            selectionCardColumn5.HeaderText = "单位";
            selectionCardColumn5.IsNameField = false;
            selectionCardColumn5.IsSeachColumn = false;
            selectionCardColumn5.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn5.Visiable = true;
            selectionCardColumn5.Width = 75;
            this.txtLeastUnit.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn5};
            this.txtLeastUnit.SelectionCardFont = null;
            this.txtLeastUnit.SelectionCardHeight = 250;
            this.txtLeastUnit.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtLeastUnit.SelectionCardRowHeaderWidth = 35;
            this.txtLeastUnit.SelectionCardRowHeight = 23;
            this.txtLeastUnit.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtLeastUnit.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.txtLeastUnit.SelectionCardWidth = 250;
            this.txtLeastUnit.ShowRowNumber = true;
            this.txtLeastUnit.ShowSelectionCardAfterEnter = false;
            this.txtLeastUnit.Size = new System.Drawing.Size(47, 23);
            this.txtLeastUnit.TabIndex = 5;
            this.txtLeastUnit.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtLeastUnit.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txtLeastUnit_AfterSelectedRow);
            // 
            // txtDoseNum
            // 
            this.txtDoseNum.BackColor = System.Drawing.Color.White;
            this.txtDoseNum.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDoseNum.Location = new System.Drawing.Point(565, 34);
            this.txtDoseNum.MaxLength = 10;
            this.txtDoseNum.Name = "txtDoseNum";
            this.txtDoseNum.Size = new System.Drawing.Size(54, 23);
            this.txtDoseNum.TabIndex = 6;
            this.txtDoseNum.TextChanged += new System.EventHandler(this.txtDoseNum_TextChanged);
            this.txtDoseNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDoseNum_KeyDown);
            // 
            // lblPharmacology
            // 
            this.lblPharmacology.AutoSize = true;
            this.lblPharmacology.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPharmacology.Location = new System.Drawing.Point(250, 68);
            this.lblPharmacology.Name = "lblPharmacology";
            this.lblPharmacology.Size = new System.Drawing.Size(63, 14);
            this.lblPharmacology.TabIndex = 19;
            this.lblPharmacology.Text = "药理分类";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "商品类型";
            // 
            // lblGBCode
            // 
            this.lblGBCode.AutoSize = true;
            this.lblGBCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGBCode.Location = new System.Drawing.Point(499, 68);
            this.lblGBCode.Name = "lblGBCode";
            this.lblGBCode.Size = new System.Drawing.Size(63, 14);
            this.lblGBCode.TabIndex = 20;
            this.lblGBCode.Text = "国家编码";
            // 
            // lblPackUnit
            // 
            this.lblPackUnit.AutoSize = true;
            this.lblPackUnit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPackUnit.Location = new System.Drawing.Point(132, 38);
            this.lblPackUnit.Name = "lblPackUnit";
            this.lblPackUnit.Size = new System.Drawing.Size(63, 14);
            this.lblPackUnit.TabIndex = 14;
            this.lblPackUnit.Text = "包装单位";
            // 
            // lblDoseNum
            // 
            this.lblDoseNum.AutoSize = true;
            this.lblDoseNum.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoseNum.Location = new System.Drawing.Point(499, 38);
            this.lblDoseNum.Name = "lblDoseNum";
            this.lblDoseNum.Size = new System.Drawing.Size(63, 14);
            this.lblDoseNum.TabIndex = 17;
            this.lblDoseNum.Text = "含量系数";
            // 
            // lblChemName
            // 
            this.lblChemName.AutoSize = true;
            this.lblChemName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChemName.Location = new System.Drawing.Point(251, 10);
            this.lblChemName.Name = "lblChemName";
            this.lblChemName.Size = new System.Drawing.Size(63, 14);
            this.lblChemName.TabIndex = 12;
            this.lblChemName.Text = "化学名称";
            // 
            // lblPackNum
            // 
            this.lblPackNum.AutoSize = true;
            this.lblPackNum.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPackNum.Location = new System.Drawing.Point(253, 38);
            this.lblPackNum.Name = "lblPackNum";
            this.lblPackNum.Size = new System.Drawing.Size(63, 14);
            this.lblPackNum.TabIndex = 15;
            this.lblPackNum.Text = "包装数量";
            // 
            // lblDoseUnit
            // 
            this.lblDoseUnit.AutoSize = true;
            this.lblDoseUnit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoseUnit.Location = new System.Drawing.Point(621, 39);
            this.lblDoseUnit.Name = "lblDoseUnit";
            this.lblDoseUnit.Size = new System.Drawing.Size(63, 14);
            this.lblDoseUnit.TabIndex = 18;
            this.lblDoseUnit.Text = "含量单位";
            // 
            // lblDoseDrug
            // 
            this.lblDoseDrug.AutoSize = true;
            this.lblDoseDrug.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoseDrug.Location = new System.Drawing.Point(621, 66);
            this.lblDoseDrug.Name = "lblDoseDrug";
            this.lblDoseDrug.Size = new System.Drawing.Size(63, 14);
            this.lblDoseDrug.TabIndex = 21;
            this.lblDoseDrug.Text = "商品剂型";
            // 
            // lblDrugName
            // 
            this.lblDrugName.AutoSize = true;
            this.lblDrugName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDrugName.Location = new System.Drawing.Point(3, 10);
            this.lblDrugName.Name = "lblDrugName";
            this.lblDrugName.Size = new System.Drawing.Size(63, 14);
            this.lblDrugName.TabIndex = 11;
            this.lblDrugName.Text = "商品名称";
            // 
            // lblLeastUnit
            // 
            this.lblLeastUnit.AutoSize = true;
            this.lblLeastUnit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLeastUnit.Location = new System.Drawing.Point(377, 38);
            this.lblLeastUnit.Name = "lblLeastUnit";
            this.lblLeastUnit.Size = new System.Drawing.Size(63, 14);
            this.lblLeastUnit.TabIndex = 16;
            this.lblLeastUnit.Text = "最小单位";
            // 
            // tsrDrugSpec
            // 
            this.tsrDrugSpec.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsrDrugSpec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsrDrugSpec.BackgroundImage")));
            this.tsrDrugSpec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsrDrugSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsrDrugSpec.Font = new System.Drawing.Font("宋体", 10F);
            this.tsrDrugSpec.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsrbtnAdd,
            this.tsrbtnDel,
            this.tsrbtnUpdate,
            this.tsrbtnSave,
            this.tsrbtnByName,
            this.tsrbtnMakerDic,
            this.tsrbtnPrint,
            this.tsrbtnCancel,
            this.tsrbtnExport,
            this.tsrbtnCancelDel,
            this.tsrbtnQuit});
            this.tsrDrugSpec.Location = new System.Drawing.Point(0, 0);
            this.tsrDrugSpec.Name = "tsrDrugSpec";
            this.tsrDrugSpec.Size = new System.Drawing.Size(1014, 29);
            this.tsrDrugSpec.TabIndex = 0;
            this.tsrDrugSpec.Text = "tsrDrugSpec";
            // 
            // tsrbtnAdd
            // 
            this.tsrbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnAdd.Image")));
            this.tsrbtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnAdd.Name = "tsrbtnAdd";
            this.tsrbtnAdd.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnAdd.Text = "新增(F2)";
            this.tsrbtnAdd.Click += new System.EventHandler(this.tsrbtnAdd_Click);
            // 
            // tsrbtnDel
            // 
            this.tsrbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnDel.Image")));
            this.tsrbtnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnDel.Name = "tsrbtnDel";
            this.tsrbtnDel.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnDel.Text = "删除(F3)";
            this.tsrbtnDel.Click += new System.EventHandler(this.tsrbtnDel_Click);
            // 
            // tsrbtnUpdate
            // 
            this.tsrbtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnUpdate.Image")));
            this.tsrbtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnUpdate.Name = "tsrbtnUpdate";
            this.tsrbtnUpdate.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnUpdate.Text = "修改(F4)";
            this.tsrbtnUpdate.Click += new System.EventHandler(this.tsrbtnUpdate_Click);
            // 
            // tsrbtnSave
            // 
            this.tsrbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnSave.Image")));
            this.tsrbtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnSave.Name = "tsrbtnSave";
            this.tsrbtnSave.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnSave.Text = "保存(F5)";
            this.tsrbtnSave.Click += new System.EventHandler(this.tsrbtnSave_Click);
            // 
            // tsrbtnByName
            // 
            this.tsrbtnByName.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnByName.Image")));
            this.tsrbtnByName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnByName.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnByName.Name = "tsrbtnByName";
            this.tsrbtnByName.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnByName.Text = "别名(F7)";
            this.tsrbtnByName.Click += new System.EventHandler(this.tsrbtnByName_Click);
            // 
            // tsrbtnMakerDic
            // 
            this.tsrbtnMakerDic.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnMakerDic.Image")));
            this.tsrbtnMakerDic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnMakerDic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnMakerDic.Name = "tsrbtnMakerDic";
            this.tsrbtnMakerDic.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnMakerDic.Text = "应用(F6)";
            this.tsrbtnMakerDic.Click += new System.EventHandler(this.tsrbtnMakerDic_Click);
            // 
            // tsrbtnPrint
            // 
            this.tsrbtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnPrint.Image")));
            this.tsrbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnPrint.Name = "tsrbtnPrint";
            this.tsrbtnPrint.Size = new System.Drawing.Size(132, 26);
            this.tsrbtnPrint.Text = "打印启用药品(&P)";
            this.tsrbtnPrint.Click += new System.EventHandler(this.tsrbtnPrint_Click);
            // 
            // tsrbtnCancel
            // 
            this.tsrbtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnCancel.Image")));
            this.tsrbtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnCancel.Name = "tsrbtnCancel";
            this.tsrbtnCancel.Size = new System.Drawing.Size(76, 26);
            this.tsrbtnCancel.Text = "取消(&Q)";
            this.tsrbtnCancel.Click += new System.EventHandler(this.tsrbtnCancel_Click);
            // 
            // tsrbtnExport
            // 
            this.tsrbtnExport.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnExport.Image")));
            this.tsrbtnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnExport.Name = "tsrbtnExport";
            this.tsrbtnExport.Size = new System.Drawing.Size(76, 26);
            this.tsrbtnExport.Text = "导出(&E)";
            this.tsrbtnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsrbtnExport.Click += new System.EventHandler(this.tsrbtnExport_Click);
            // 
            // tsrbtnCancelDel
            // 
            this.tsrbtnCancelDel.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnCancelDel.Image")));
            this.tsrbtnCancelDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnCancelDel.Name = "tsrbtnCancelDel";
            this.tsrbtnCancelDel.Size = new System.Drawing.Size(104, 26);
            this.tsrbtnCancelDel.Text = "取消删除(&V)";
            this.tsrbtnCancelDel.Click += new System.EventHandler(this.tsrbtnCancelDel_Click);
            // 
            // tsrbtnQuit
            // 
            this.tsrbtnQuit.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnQuit.Image")));
            this.tsrbtnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnQuit.Name = "tsrbtnQuit";
            this.tsrbtnQuit.Size = new System.Drawing.Size(76, 26);
            this.tsrbtnQuit.Text = "关闭(&C)";
            this.tsrbtnQuit.Click += new System.EventHandler(this.tsrbtnQuit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 643);
            this.panel1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel6);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1010, 639);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.treePharmacology);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(217, 613);
            this.panel6.TabIndex = 2;
            // 
            // treePharmacology
            // 
            this.treePharmacology.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePharmacology.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treePharmacology.Location = new System.Drawing.Point(0, 0);
            this.treePharmacology.Name = "treePharmacology";
            this.treePharmacology.Size = new System.Drawing.Size(217, 613);
            this.treePharmacology.TabIndex = 0;
            this.treePharmacology.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treePharmacology_NodeMouseDoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblPharmacologyTitle);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(217, 26);
            this.panel5.TabIndex = 1;
            // 
            // lblPharmacologyTitle
            // 
            this.lblPharmacologyTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPharmacologyTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPharmacologyTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPharmacologyTitle.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPharmacologyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPharmacologyTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPharmacologyTitle.Name = "lblPharmacologyTitle";
            this.lblPharmacologyTitle.Size = new System.Drawing.Size(217, 26);
            this.lblPharmacologyTitle.TabIndex = 0;
            this.lblPharmacologyTitle.Text = "药理分类";
            this.lblPharmacologyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgrdDrugSpec);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(0, 132);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(789, 507);
            this.panel4.TabIndex = 1;
            // 
            // dgrdDrugSpec
            // 
            this.dgrdDrugSpec.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdDrugSpec.AllowSortWhenClickColumnHeader = false;
            this.dgrdDrugSpec.AllowUserToAddRows = false;
            this.dgrdDrugSpec.AllowUserToResizeRows = false;
            this.dgrdDrugSpec.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDrugSpec.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdDrugSpec.ColumnHeadersHeight = 35;
            this.dgrdDrugSpec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GBCode,
            this.NAME,
            this.ChemName,
            this.LatinName,
            this.SPEC,
            this.TYPENAME,
            this.PackunitName,
            this.PackNum,
            this.DoseUnitName,
            this.UnitName,
            this.DoseNum,
            this.DoseName,
            this.Del_Flag});
            this.dgrdDrugSpec.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgrdDrugSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdDrugSpec.EnableHeadersVisualStyles = false;
            this.dgrdDrugSpec.GridColor = System.Drawing.SystemColors.Control;
            this.dgrdDrugSpec.HideSelectionCardWhenCustomInput = false;
            this.dgrdDrugSpec.Location = new System.Drawing.Point(0, 0);
            this.dgrdDrugSpec.MultiSelect = false;
            this.dgrdDrugSpec.Name = "dgrdDrugSpec";
            this.dgrdDrugSpec.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDrugSpec.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgrdDrugSpec.RowHeadersWidth = 35;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgrdDrugSpec.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgrdDrugSpec.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgrdDrugSpec.RowTemplate.Height = 23;
            this.dgrdDrugSpec.SelectionCards = null;
            this.dgrdDrugSpec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdDrugSpec.Size = new System.Drawing.Size(789, 507);
            this.dgrdDrugSpec.TabIndex = 0;
            this.dgrdDrugSpec.UseGradientBackgroundColor = true;
            this.dgrdDrugSpec.CurrentCellChanged += new System.EventHandler(this.dgrdDrugSpec_CurrentCellChanged);
            // 
            // GBCode
            // 
            this.GBCode.DataPropertyName = "GBCode";
            this.GBCode.HeaderText = "编码";
            this.GBCode.Name = "GBCode";
            this.GBCode.ReadOnly = true;
            this.GBCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GBCode.Width = 65;
            // 
            // NAME
            // 
            this.NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "商品名称";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ChemName
            // 
            this.ChemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChemName.DataPropertyName = "ChemName";
            this.ChemName.HeaderText = "化学名称";
            this.ChemName.Name = "ChemName";
            this.ChemName.ReadOnly = true;
            this.ChemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LatinName
            // 
            this.LatinName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LatinName.DataPropertyName = "LatinName";
            this.LatinName.HeaderText = "拉丁名称";
            this.LatinName.Name = "LatinName";
            this.LatinName.ReadOnly = true;
            this.LatinName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SPEC
            // 
            this.SPEC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SPEC.DataPropertyName = "SPEC";
            this.SPEC.HeaderText = "药品规格";
            this.SPEC.Name = "SPEC";
            this.SPEC.ReadOnly = true;
            this.SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TYPENAME
            // 
            this.TYPENAME.DataPropertyName = "TYPENAME";
            this.TYPENAME.HeaderText = "类型";
            this.TYPENAME.Name = "TYPENAME";
            this.TYPENAME.ReadOnly = true;
            this.TYPENAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TYPENAME.Width = 50;
            // 
            // PackunitName
            // 
            this.PackunitName.DataPropertyName = "PackunitName";
            this.PackunitName.HeaderText = "包装单位";
            this.PackunitName.Name = "PackunitName";
            this.PackunitName.ReadOnly = true;
            this.PackunitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PackunitName.Width = 35;
            // 
            // PackNum
            // 
            this.PackNum.DataPropertyName = "PackNum";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PackNum.DefaultCellStyle = dataGridViewCellStyle7;
            this.PackNum.HeaderText = "包装数量";
            this.PackNum.Name = "PackNum";
            this.PackNum.ReadOnly = true;
            this.PackNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PackNum.Width = 60;
            // 
            // DoseUnitName
            // 
            this.DoseUnitName.DataPropertyName = "DoseUnitName";
            this.DoseUnitName.HeaderText = "含量单位";
            this.DoseUnitName.Name = "DoseUnitName";
            this.DoseUnitName.ReadOnly = true;
            this.DoseUnitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DoseUnitName.Width = 35;
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UnitName";
            this.UnitName.HeaderText = "基本单位";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            this.UnitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitName.Width = 35;
            // 
            // DoseNum
            // 
            this.DoseNum.DataPropertyName = "DoseNum";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DoseNum.DefaultCellStyle = dataGridViewCellStyle8;
            this.DoseNum.HeaderText = "含量系数";
            this.DoseNum.Name = "DoseNum";
            this.DoseNum.ReadOnly = true;
            this.DoseNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DoseNum.Width = 60;
            // 
            // DoseName
            // 
            this.DoseName.DataPropertyName = "DoseName";
            this.DoseName.HeaderText = "剂型";
            this.DoseName.Name = "DoseName";
            this.DoseName.ReadOnly = true;
            this.DoseName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DoseName.Width = 50;
            // 
            // Del_Flag
            // 
            this.Del_Flag.DataPropertyName = "DEL_FLAG";
            this.Del_Flag.HeaderText = "删除";
            this.Del_Flag.Name = "Del_Flag";
            this.Del_Flag.ReadOnly = true;
            this.Del_Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Del_Flag.Width = 35;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnlSetDrugspec);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(789, 132);
            this.panel3.TabIndex = 0;
            // 
            // FrmDrugSpec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 732);
            this.FormTitle = "药品/物资字典维护";
            this.KeyPreview = true;
            this.Name = "FrmDrugSpec";
            this.Text = "药品/物资字典维护";
            this.Load += new System.EventHandler(this.FrmDrugSpec_Load);
            this.LocationChanged += new System.EventHandler(this.FrmDrugSpec_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDrugSpec_KeyDown);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.pnlSetDrugspec.ResumeLayout(false);
            this.pnlSetDrugspec.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsrDrugSpec.ResumeLayout(false);
            this.tsrDrugSpec.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDrugSpec)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSetDrugspec;
        private System.Windows.Forms.RadioButton radZCY;
        private System.Windows.Forms.RadioButton radZY;
        private System.Windows.Forms.RadioButton radXY;
        private System.Windows.Forms.Label lblDrugName;
        private System.Windows.Forms.Label lblLeastUnit;
        private System.Windows.Forms.Label lblDoseUnit;
        private System.Windows.Forms.Label lblDoseDrug;
        private System.Windows.Forms.TextBox txtPackNum;
        private System.Windows.Forms.Label lblChemName;
        private System.Windows.Forms.Label lblPackNum;
        private System.Windows.Forms.TextBox txtDoseNum;
        private System.Windows.Forms.Label lblDoseNum;
        private System.Windows.Forms.Label lblPackUnit;
        private System.Windows.Forms.TextBox txtGBCode;
        private System.Windows.Forms.Label lblGBCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radShowAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblQuery;
        private GWI.HIS.Windows.Controls.ToolStrip tsrDrugSpec;
        private System.Windows.Forms.ToolStripButton tsrbtnAdd;
        private System.Windows.Forms.ToolStripButton tsrbtnSave;
        private System.Windows.Forms.ToolStripButton tsrbtnUpdate;
        private System.Windows.Forms.ToolStripButton tsrbtnMakerDic;
        private System.Windows.Forms.ToolStripButton tsrbtnDel;
        private System.Windows.Forms.ToolStripButton tsrbtnByName;
        private System.Windows.Forms.ToolStripButton tsrbtnQuit;
        private System.Windows.Forms.TextBox txtQueryCode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblPharmacologyTitle;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TreeView treePharmacology;
        private System.Windows.Forms.Label lblPharmacology;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdDrugSpec;
        private GWI.HIS.Windows.Controls.QueryTextBox txtDgType;
        private GWI.HIS.Windows.Controls.QueryTextBox txtPackUnit;
        private GWI.HIS.Windows.Controls.QueryTextBox txtLeastUnit;
        private GWI.HIS.Windows.Controls.QueryTextBox txtDoseUnit;
        private GWI.HIS.Windows.Controls.QueryTextBox txtPharmacology;
        private GWI.HIS.Windows.Controls.QueryTextBox txtDrugDose;
        private System.Windows.Forms.RadioButton radWZ;
        private GWI.HIS.Windows.Controls.QueryTextBox txtChemName;
        private GWI.HIS.Windows.Controls.QueryTextBox txtDrugName;
        private System.Windows.Forms.CheckBox chkIsUse;
        private System.Windows.Forms.ToolStripButton tsrbtnPrint;
        private GWI.HIS.Windows.Controls.QueryTextBox txtDrugSpec;
        private System.Windows.Forms.Label lblSepc;
        private System.Windows.Forms.ToolStripButton tsrbtnCancel;
        private System.Windows.Forms.ToolStripButton tsrbtnCancelDel;
        private System.Windows.Forms.ToolStripButton tsrbtnExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn GBCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LatinName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackunitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoseUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoseNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoseName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Del_Flag;
        private GWI.HIS.Windows.Controls.QueryTextBox txtLatinName;
    }
}

