/*
 * 2010-03-10 修改 曾浩 [110] 门诊诊疗管理中如有挂号病人，在输入门诊号的时候输一个号子就跳一个提示，不方便。 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crownwood.Magic.Controls;
using Crownwood.Magic.Common;
using Crownwood.Magic.Menus;
using Crownwood.Magic.Docking;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_MZDocManager
{
    /// <summary>
    /// 诊疗管理主界面
    /// </summary>
    public partial class FrmMedicalManage : GWI.HIS.Windows.Controls.BaseMainForm, Action.IFrmMedicalManageView, Action.IFrmMedicalApplyView
    {
        #region 成员变量
        private static FrmMedicalManage instance;
        private static readonly object syncRoot = new object();

        private User _currentUser;  //当前用户
        private Deptment _currentDept;  //当前科室
        private Action.FrmMedicalManageController Controller;  //处方录入控制器
        private int _rowIndex = -1; //当前行
        private int _paintRowIndex = -1;  //当前绘制行
        private int _groupStartRowIndex = -1;  //当前分组开始行
        private HIS.MZDoc_BLL.Patient _currentPatient = new HIS.MZDoc_BLL.Patient(new HIS.Model.MZ_PatList()); //当前病人

        private bool _isInitialize = true;  //是否正在初始化
        private Action.FrmMedicalApplyController ApplyController; //医技申请控制器
        private HIS.MZDoc_BLL.BaseMedical _currentMedicalApply;  //当前医技申请

        HIS.MZDoc_BLL.InterFace.MedicalReportInterFace medicalReport = new HIS.MZDoc_BLL.InterFace.MedicalReportInterFace();
        HIS.MZDoc_BLL.Public.MedicalReportInfo medicalReportInfo = new HIS.MZDoc_BLL.Public.MedicalReportInfo();
        public Control EMRControl
        {
            set
            {
                value.Dock = DockStyle.Fill;
                this.tbPEMR.Controls.Clear();
                this.tbPEMR.Controls.Add(value);
            }
        }

        #endregion

        #region 构造函数
        private FrmMedicalManage(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();

            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);

            if (_currentUser == null)
                throw new Exception("_currentUser");
            if (_currentDept == null)
                throw new Exception("_currentDept");

            HIS.MZDoc_BLL.Public.StaticConfig.CureDeptCode = (int)currentDeptId;
            HIS.MZDoc_BLL.Public.StaticConfig.CureDocCode = (int)_currentUser.EmployeeID;
            this.Text = chineseName;
            this.FormTitle = chineseName;
            
            Controller = new HIS_MZDocManager.Action.FrmMedicalManageController(this);
            if (Controller == null)
                throw new Exception("Controller");
            ApplyController = new HIS_MZDocManager.Action.FrmMedicalApplyController(this);
            if (ApplyController == null)
                throw new Exception("ApplyController");

            medicalReportInfo.FormHandle = this.Handle;
            medicalReport.InitReportPort(medicalReportInfo);

            this.tSMnuIFeePrint.Visible = Controller.IsPrintFeeList();
        }

        public static FrmMedicalManage GetInstance(long currentUserId, long currentDeptId, string chineseName)
        {
            if (instance == null || instance.IsDisposed)
            {
                lock (syncRoot)
                {
                    if (instance == null || instance.IsDisposed)
                    {
                        instance = new FrmMedicalManage(currentUserId, currentDeptId, chineseName);
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// 初始化停靠管理器
        /// </summary>
        private void ShowDocAssistant()
        {
            if (_manager == null)
            {
                _manager = new DockingManager(this, Crownwood.Magic.Common.VisualStyle.IDE);
            }
            _manager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            _manager.Contents.Clear();
            //设置外边界控件
            _manager.OuterControl = dGVEMain;
            _manager.InnerControl = plBaseWorkArea;
            _manager.OuterControl = tbPCMain;

            UCPatientList ucPatientList = new UCPatientList(_currentUser.EmployeeID);
            UCOfenDrug ucOfenDrug = new UCOfenDrug(_currentUser.EmployeeID);
            UCOfenItem ucOfenItem = new UCOfenItem(_currentUser.EmployeeID);
            UCOfenDiagnosis ucOfenDiagnosis = new UCOfenDiagnosis(_currentUser.EmployeeID);
            UCPresMould ucPresMould = new UCPresMould(_currentDept.DeptID, _currentUser.EmployeeID);

            ucPatientList.SelectDataList += new EventHandler(ucPatientList_SelectDataList);
            ucOfenDrug.SelectDataList += new EventHandler(ucOfenDrug_SelectDataList);
            ucOfenItem.SelectDataList += new EventHandler(ucOfenItem_SelectDataList);
            ucOfenDiagnosis.SelectDataList += new EventHandler(ucOfenDiagnosis_SelectDataList);
            ucPresMould.SelectDataList += new EventHandler(ucPresMould_SelectDataList);

            //创建Content对象
            Content contentPatientList = _manager.Contents.Add(ucPatientList, "病人列表", baseImageList, 21);
            Content contentOfenDrug = _manager.Contents.Add(ucOfenDrug, "药品(常用)", baseImageList, 22);
            Content contentOfenItem = _manager.Contents.Add(ucOfenItem, "项目(常用)", baseImageList, 23);
            Content contentOfenDiagnosis = _manager.Contents.Add(ucOfenDiagnosis, "诊断(常用)", baseImageList, 24);
            Content contentPresMould = _manager.Contents.Add(ucPresMould, "医生模板", baseImageList, 25);

            //将第一个Content设为默认停靠窗口，并停靠在最底端
            WindowContent wc = _manager.AddContentWithState(contentPatientList, State.DockLeft) as WindowContent;

            _manager.AddContentToWindowContent(contentOfenDrug, wc);
            _manager.AddContentToWindowContent(contentOfenItem, wc);
            _manager.AddContentToWindowContent(contentOfenDiagnosis, wc);
            _manager.AddContentToWindowContent(contentPresMould, wc);
        }
        #endregion

        #region IFrmMedicalManageView 成员
        //当前用户
        public User currentUser
        {
            get
            {
                return _currentUser;
            }
        }
        //当前科室
        public Deptment currentDept
        {
            get
            {
                return _currentDept;
            }
        }
        //当前病人
        public HIS.MZDoc_BLL.Patient CurrentPatient
        {
            get
            {
                return _currentPatient;
            }
            set
            {
                _isInitialize = true;
                _currentPatient = value;
                ShowPatientInfo();
                if (tbPCMain.SelectedIndex == 0)
                {
                    Controller.LoadPresList();
                }
                else
                {
                    ApplyController.LoadMedicalDept();
                    ApplyController.LoadApplyList();
                }
                if (_currentPatient.PatList.PatListID > 0)
                {
                    this.dTPkbDate.Value = _currentPatient.PatList.CureDate;
                    this.dTPkeDate.Value = DateTime.Today;
                    ApplyController.LoadMedicalApplyList(this.dTPkbDate.Value, this.dTPkeDate.Value);
                }
                this.ctMnuSPres.Enabled = this._currentPatient.PatList.PatListID > 0;
                _isInitialize = false;
                Controller.LoadEMRRecord();
            }
        }
        //当前病人就诊的诊断
        public string CurrentPatientDiagnosis
        {
            get
            {
                return this.tBDiagnosis.Text;
            }
            set
            {
                this.tBDiagnosis.Text = value;
            }
        }
        //Grid当前行号
        public int RowIndex
        {
            get
            {
                return _rowIndex;
            }
            set
            {
                _rowIndex = value;
            }
        }
        //Grid数据源
        public DataTable BindPresDataSource
        {
            get
            {
                return (DataTable)this.dGVEMain.DataSource;
            }
            set
            {
                this.dGVEMain.AutoGenerateColumns = false;
                this.dGVEMain.DataSource = value;
            }
        }
        //单元格颜色
        public HIS.MZDoc_BLL.Public.PresColor CellColor
        {
            set
            {
                if (value.colIndex == -1)
                {
                    for (int r = 0; r < this.dGVEMain.Columns.Count; r++)
                    {
                        this.dGVEMain.Rows[value.rowIndex].Cells[r].Style.ForeColor = value.ForeColor;
                        this.dGVEMain.Rows[value.rowIndex].Cells[r].Style.BackColor = value.BackColor;
                    }
                }
                else
                {
                    this.dGVEMain.Rows[value.rowIndex].Cells[value.colIndex].Style.ForeColor = value.ForeColor;
                    this.dGVEMain.Rows[value.rowIndex].Cells[value.colIndex].Style.BackColor = value.BackColor;
                }
            }
        }
        // 处方列序号
        public HIS.MZDoc_BLL.Public.PresColumnIndex ColumnIndex
        {
            get
            {
                HIS.MZDoc_BLL.Public.PresColumnIndex presColumnIndex = new HIS.MZDoc_BLL.Public.PresColumnIndex();
                presColumnIndex.ItemIdIndex = this.Item_Id.Index;
                presColumnIndex.DeptNameIndex = this.Dept_Name.Index;
                presColumnIndex.UsageAmountIndex = this.Usage_Amount.Index;
                presColumnIndex.UsageUnitIndex = this.Usage_Unit.Index;
                presColumnIndex.DosageIndex = this.Dosage.Index;
                presColumnIndex.UsageIndex = this.Usage_Name.Index;
                presColumnIndex.FrequencyIndex = this.Frequency_Name.Index;
                presColumnIndex.DaysIndex = this.Days.Index;
                presColumnIndex.ItemAmountIndex = this.Item_Amount.Index;
                presColumnIndex.ItemUnitIndex = this.Item_Unit.Index;
                presColumnIndex.EntrustIndex = this.Entrust.Index;
                return presColumnIndex;
            }
        }
        //单元格只读状态
        public HIS.MZDoc_BLL.Public.PresCellReadOnly CellReadOnly
        {
            set
            {
                this.Item_Id.ReadOnly = value.ItemIdReadOnly;
                this.Dept_Name.ReadOnly = value.DeptNameReadOnly;
                this.Usage_Amount.ReadOnly = value.UsageAmountReadOnly;
                this.Usage_Unit.ReadOnly = value.UsageUnitReadOnly;
                this.Dosage.ReadOnly = value.DosageReadOnly;
                this.Usage_Name.ReadOnly = value.UsageReadOnly;
                this.Frequency_Name.ReadOnly = value.FrequencyReadOnly;
                this.Days.ReadOnly = value.DaysReadOnly;
                this.Item_Amount.ReadOnly = value.ItemAmountReadOnly;
                this.Item_Unit.ReadOnly = value.ItemUnitReadOnly;
                this.Entrust.ReadOnly = value.EntrustReadOnly;
            }
        }
        // 状态栏金额提示值
        public string ItemMoneyStatus
        {
            set
            {
                lbItemMoney.Text = value;
            }
        }
        //分组开始行的索引
        public int GroupStartRowIndex
        {
            get { return _groupStartRowIndex; }
            set { _groupStartRowIndex = value; }
        }
        //当前绘制行号
        public int PaintRowIndex
        {
            get
            {
                return _paintRowIndex;
            }
            set
            {
                _paintRowIndex = value;
            }
        }
        //单元格矩形
        public System.Drawing.Rectangle GridCellBounds
        {
            get
            {
                Rectangle rectangle = new Rectangle(this.dGVEMain.GetCellDisplayRectangle(this.Item_Id.Index, this._paintRowIndex, false).X,
                    this.dGVEMain.GetCellDisplayRectangle(this.Item_Id.Index, this._paintRowIndex, false).Y,
                    this.dGVEMain.GetCellDisplayRectangle(this.Item_Id.Index, this._paintRowIndex, false).Width + this.dGVEMain.GetCellDisplayRectangle(this.Item_Name.Index, this._paintRowIndex, false).Width,
                    this.dGVEMain.GetCellDisplayRectangle(this.Item_Id.Index, this._paintRowIndex, false).Height);

                return rectangle;
            }
        }
        //右键菜单只读状态
        public bool MenuEnabled
        {
            set
            {
                for (int index = 0; index < this.ctMnuSPres.Items.Count; index++)
                {
                    this.ctMnuSPres.Items[index].Enabled = value;
                }
                this.tSMnuIPresPrint.Enabled = ((HIS.MZDoc_BLL.Public.PresStatus)(this.BindPresDataSource.Rows[this.RowIndex]["Status"]) == HIS.MZDoc_BLL.Public.PresStatus.修改状态
                || (HIS.MZDoc_BLL.Public.PresStatus)(this.BindPresDataSource.Rows[this.RowIndex]["Status"]) == HIS.MZDoc_BLL.Public.PresStatus.保存状态
                || (HIS.MZDoc_BLL.Public.PresStatus)(this.BindPresDataSource.Rows[this.RowIndex]["Status"]) == HIS.MZDoc_BLL.Public.PresStatus.收费状态);
                this.tSMnuIPresCopy.Enabled = true;
                this.tSMnuIPresPaste.Enabled = true;
            }
        }
        //初始化
        public void Initialize(DataSet _dataSet)
        {
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["Item_Dictionary"], this.Item_Id.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["ExeDept_Dictionary"], this.Dept_Name.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["Usage_Unit_Dictionary"], this.Usage_Unit.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["Usage_Dictionary"], this.Usage_Name.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["Frequency_Dictionary"], this.Frequency_Name.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["Item_Unit_Dictionary"], this.Item_Unit.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["Entrust_Dictionary"], this.Entrust.Index);
            this.qTBDiagnosis.SetSelectionCardDataSource(_dataSet.Tables["Item_Diagnosis"]);
        }
        //刷新处方
        public void RefreshPres()
        {
            this._groupStartRowIndex = -1;
            this.tSMnuIGrouping.Text = "开始分组(Ctrl+F9)";
            this.RowIndex = -1;
        }
        //药房科室数据
        public DataTable DrugDeptDic
        {
            set
            {
                this.cbBDrugDept.DisplayMember = "Name";
                this.cbBDrugDept.ValueMember = "Value";
                this.cbBDrugDept.DataSource = value;
                this.cbBDrugDept.SelectedIndex = 0;
            }
        }
        //当前选择的药房科室Id
        public string SelectedDrugDeptId
        {
            get
            {
                return (this.cbBDrugDept.SelectedValue == null ? -1 : this.cbBDrugDept.SelectedValue).ToString().Trim();
            }
        }
        #endregion

        #region IFrmMedicalApplyView 成员
        // 当前医技申请类别
        public HIS.MZDoc_BLL.Public.MedicalApplyType CurrentApplyType
        {
            get
            {
                switch (this.tbPCMedical.SelectedIndex)
                {
                    case 0:
                        return HIS.MZDoc_BLL.Public.MedicalApplyType.医技化验申请;
                    case 1:
                        return HIS.MZDoc_BLL.Public.MedicalApplyType.医技检查申请;
                    default:
                        return HIS.MZDoc_BLL.Public.MedicalApplyType.医技治疗申请;
                }
            }
        }
        //医技申请科室
        public DataTable MecicalDept
        {
            set
            {
                this.cbBMedicalDept.DisplayMember = "dept_name";
                this.cbBMedicalDept.ValueMember = "dept_id";
                this.cbBMedicalDept.DataSource = value;

                if (value == null || value.Rows.Count <= 0)
                {
                    this.cbBMedicalDept.Text = "";
                    this.cbBMedicalClass.DataSource = null;
                    this.chkLBMedicalItem.Items.Clear();
                }

                //if (value != null && value.Rows.Count > 0)
                //{
                //    if (this.cbBMedicalDept.SelectedIndex == 0)
                //    {
                //        cbBMedicalDept_SelectedIndexChanged(null, null);
                //    }
                //    this.cbBMedicalDept.SelectedIndex = 0;
                //}

            }
        }
        //当前医技申请科室
        public int CurrentMecicalDept
        {
            get
            {
                return Convert.ToInt32(XcConvert.IsNull(this.cbBMedicalDept.SelectedValue, "-1"));
            }
        }
        //医技申请类型
        public DataTable MecicalClass
        {
            set
            {
                this.cbBMedicalClass.DisplayMember = "medical_class_name";
                this.cbBMedicalClass.ValueMember = "medical_class";
                this.cbBMedicalClass.DataSource = value;
                //if (value != null && value.Rows.Count > 0)
                //{
                //    if (this.cbBMedicalClass.SelectedIndex == 0)
                //    {
                //        cbBMedicalClass_SelectedIndexChanged(null, null);
                //    }
                //    this.cbBMedicalClass.SelectedIndex = 0;
                //}
            }
        }
        //当前医技申请类型
        public int CurrentMecicalClass
        {
            get
            {
                return Convert.ToInt32(XcConvert.IsNull(this.cbBMedicalClass.SelectedValue,"-1"));
            }
        }
        //医技项目
        public List<HIS.MZDoc_BLL.Medical_Order_Item> MecicalItem
        {
            set
            {
                this.chkLBMedicalItem.Items.Clear();
                for (int i = 0; i < value.Count; i++)
                {
                    this.chkLBMedicalItem.Items.Add(value[i]);
                }
                DataTable tb = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(value);
                this.qTxtMecicalItemQuery.SetSelectionCardDataSource(tb);
                //this.qTxtMecicalItemQuery.SetSelectionCardDataSource(value, Type.GetType("HIS.MZDoc_BLL.Medical_Order_Item"));
            }
        }
        //当前选中医技项目列表
        public List<HIS.MZDoc_BLL.Medical_Order_Item> CurrentMecicalItems
        {
            get
            {
                List<HIS.MZDoc_BLL.Medical_Order_Item> itemList = new List<HIS.MZDoc_BLL.Medical_Order_Item>();
                for (int i = 0; i < chkLBMedicalItem.CheckedItems.Count; i++)
                {
                    itemList.Add((HIS.MZDoc_BLL.Medical_Order_Item)chkLBMedicalItem.CheckedItems[i]);
                }
                return itemList;
            }
        }
        //已选项目列表
        public DataTable SelecedMecicalItems
        {
            get
            {
                return (DataTable)this.dGVEApplyList.DataSource;
            }
            set
            {
                this.dGVEApplyList.AutoGenerateColumns = false;
                this.dGVEApplyList.DataSource = value;
            }
        }
        //当前申请项目
        public HIS.MZDoc_BLL.BaseMedical CurrentMedicalApply
        {
            get
            {
                if (_currentMedicalApply != null)
                {
                    FormSite.FormatPanel panel = (FormSite.FormatPanel)this.groupBApplyInfo.Controls[0];
                    switch (this.tbPCMedical.SelectedIndex)
                    {
                        case 2:
                            HIS.MZDoc_BLL.MedicalTreat treatApply = (HIS.MZDoc_BLL.MedicalTreat)_currentMedicalApply;
                            treatApply.Apply_Content = panel.FormatXmlDocument;
                            treatApply.Num = Convert.ToInt32(XcConvert.IsNull(panel.GetElementValue("Num"),"1"));
                            return treatApply;
                        default:
                            _currentMedicalApply.Apply_Content = panel.FormatXmlDocument;
                            return _currentMedicalApply;
                    }
                }
                return null;
            }
            set
            {
                _currentMedicalApply = value;
                if (value != null)
                {
                    this.groupBApplyInfo.Controls.Clear();
                    FormSite.FormatPanel control = new FormSite.FormatPanel(value.Apply_Content);
                    if (control.Controls.Count == 0)
                    {
                        control = new FormSite.FormatPanel(HIS.MZDoc_BLL.OP_ReadBaseData.GetMedicalApplyXmlDocument(value.Medical_Class));
                    }
                    control.Dock = DockStyle.Fill;
                    control.ElementValueChanged += new EventHandler(MedicalContent_TextChanged);
                    control.MouldButtonClick += new EventHandler(MedicalContent_MouldButtonClick);
                    switch (this.tbPCMedical.SelectedIndex)
                    {
                        case 0:
                            control.SetElementValue("Purpose", value.Item_Name);
                            break;
                        case 2:
                            control.SetElementValue("Num", value.Num.ToString());
                            break;
                        default:
                            break;
                    }
                    this.groupBApplyInfo.Controls.Add(control);
                    ApplyInfoReadOnly = !(value.Status == HIS.MZDoc_BLL.Public.PresStatus.新建状态
                                       || value.Status == HIS.MZDoc_BLL.Public.PresStatus.修改状态
                                       || value.Status == HIS.MZDoc_BLL.Public.PresStatus.保存状态);

                }
            }
        }
        //单元格颜色
        public HIS.MZDoc_BLL.Public.PresColor ApplyCellColor
        {
            set
            {
                if (value.colIndex == -1)
                {
                    for (int r = 0; r < this.dGVEApplyList.Columns.Count; r++)
                    {
                        this.dGVEApplyList.Rows[value.rowIndex].Cells[r].Style.ForeColor = value.ForeColor;
                        this.dGVEApplyList.Rows[value.rowIndex].Cells[r].Style.BackColor = value.BackColor;
                    }
                }
                else
                {
                    this.dGVEApplyList.Rows[value.rowIndex].Cells[value.colIndex].Style.ForeColor = value.ForeColor;
                    this.dGVEApplyList.Rows[value.rowIndex].Cells[value.colIndex].Style.BackColor = value.BackColor;
                }
            }
        }
        //申请信息只读状态
        public bool ApplyInfoReadOnly
        {
            set
            {
                if (this.groupBApplyInfo.Controls.Count > 0)
                {
                    FormSite.FormatPanel panel = (FormSite.FormatPanel)this.groupBApplyInfo.Controls[0];
                    panel.Enabled = !value;
                    panel.ForeColor = Color.Black;
                }
            }
        }
        //医技申请Grid当前行号
        public int ApplyRowIndex
        {
            get
            {
                if (this.dGVEApplyList.CurrentCell == null)
                {
                    return -1;
                }
                else
                {
                    return this.dGVEApplyList.CurrentCell.RowIndex;
                }
            }
            set
            {
                this.dGVEApplyList.CurrentCell = this.dGVEApplyList[0, Math.Min(this.dGVEApplyList.RowCount - 1, value)];
            }
        }
        //当前医技类型名称
        public string CurrentMecicalClassName
        {
            get
            {
                return this.cbBMedicalClass.Text;
            }
        }
        //当前医技打印参数列表
        public List<FormSite.PrintParameter> CurrentApplyPrintParameter
        {
            get
            {
                FormSite.FormatPanel panel = (FormSite.FormatPanel)this.groupBApplyInfo.Controls[0];
                return panel.PrintParameters;
            }
        }
        // 医技申请列表
        public DataTable MedicalApplyList 
        {
            get
            {
                return (DataTable)dGVMedicalResult.DataSource;
            }
            set
            {
                this.dGVMedicalResult.AutoGenerateColumns = false;
                dGVMedicalResult.DataSource = value;
            }
        }
        // 医技申请列表中的选中行
        public int MedicalApplyListRowIndex
        {
            get
            {
                if (dGVMedicalResult.DataSource == null || dGVMedicalResult.CurrentCell == null)
                {
                    return -1;
                }
                return dGVMedicalResult.CurrentCell.RowIndex;
            }
        }
        //初始化
        public void InitializeApply(DataSet _dataSet)
        {
            _isInitialize = false;
        }
        #endregion

        #region 其他事件
        //显示病人信息
        private void ShowPatientInfo()
        {
            this.txtName.Text = _currentPatient.PatList.PatName;
            this.txtSex.Text = _currentPatient.PatList.PatSex;
            this.txtAge.Text = _currentPatient.PatList.Age.ToString() + _currentPatient.PatList.HpGrade;
            this.txtTel.Text = _currentPatient.PatientInfo.PatTEL;
            this.txtFeeType.Text = _currentPatient.FeeTypeName;
            this.txtAddress.Text = _currentPatient.PatientInfo.PatAddress;
            this.tBCardno.Text = _currentPatient.PatList.MediCard;
            this.tBVisitNo.Text = _currentPatient.PatList.VisitNo;
            this.tBDiagnosis.Text = _currentPatient.PatList.DiseaseName;
            this.txtAllergic.Text = _currentPatient.PatientInfo.ALLERGIC;
        }
        //检查病人有效性
        private bool CheckCurrentPatient()
        {
            if (this.CurrentPatient.PatList.PatListID <= 0)
            {
                MessageBox.Show("请先选定病人！", "提示");
                return false;
            }
            return true;
        }
        //加载窗体
        private void FrmMedicalManage_Load(object sender, EventArgs e)
        {
            //初始化停靠管理器
            ShowDocAssistant();
            this.ctMnuSPres.Enabled = false;
            tbPCMain.TabPages.RemoveAt(3);
        }
        //快捷键
        private void FrmMedicalManage_KeyDown(object sender, KeyEventArgs e)
        {
            //if (CheckCurrentPatient()) update 曾浩 2010-03-10
            //{
                switch (e.KeyData)
                {
                    case Keys.F2:	//保存
                        tSBtnSave_Click(null, null);
                        break;
                    case Keys.F3:	//新增
                        tSBtnNew_Click(null, null);
                        break;
                    case Keys.F4:	//修改
                        tSBtnUpdate_Click(null, null);
                        break;
                    case Keys.F5:	//取消
                        tSBtnCancel_Click(null, null);
                        break;
                    case Keys.F6:	//模板
                        tSBtnMould_Click(null, null);
                        break;
                    case Keys.F7:	//助手
                        tSBtnDock_Click(null, null);
                        break;
                    case Keys.F8:	//住院证
                        tSBtnInPatReg_Click(null, null);
                        break;
                    case Keys.Control | Keys.N:  //新号
                        tSBtnNewPat_Click(null, null);
                        break;
                    case Keys.F12:	//结束就诊
                        tSBtnEnd_Click(null, null);
                        break;
                    case Keys.Insert: //插入
                        tSMnuIInsert_Click(null, null);
                        break;
                    case Keys.Delete: //删除
                        tSMnuIDelRow_Click(null, null);
                        break;
                    //case Keys.Up:    //上移一行
                    //    tSMnuIUpRow_Click(null, null);
                    //    break;
                    //case Keys.Down:  //下移一行
                    //    tSMnuIDownRow_Click(null, null);
                    //    break;
                    case Keys.Control | Keys.A:  //整张删除
                        tSMnuIDelPres_Click(null, null);
                        break;
                    case Keys.F9:   //分组
                        tSMnuIGrouping_Click(null, null);
                        break;
                    case Keys.F11:  //取消分组
                        tSMnuICancelGroup_Click(null, null);
                        break;
                    case Keys.Control | Keys.S:  //存为模板
                        tSMnuISaveAsMould_Click(null, null);
                        break;
                    case Keys.Control | Keys.Z:  //中药脚注
                        tSMnuIFootNote_Click(null, null);
                        break;
                    case Keys.Control | Keys.P:  //处方打印
                        tSMnuIPresPrint_Click(null, null);
                        break;
                    case Keys.Control | Keys.F:  //处方费用打印
                        tSMnuIFeePrint_Click(null, null);
                        break;
                    case Keys.Control | Keys.C:  //处方复制
                        tSMnuIPresCopy_Click(null, null);
                        break;
                    case Keys.Control | Keys.V:  //处方粘贴
                        tSMnuIPresPaste_Click(null, null);
                        break;
                    case Keys.Control | Keys.B:  //自备药品
                        tSMnuISelfDrug_Click(null, null);
                        break;
                    default:
                        break;
                }
           // }
        }
        //使用诊疗卡检索病人
        private void tBCardno_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        //使用门诊号检索病人
        private void tBVisitNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                try
                {
                    Controller.SearchPatient(this.tBVisitNo.Text.Trim(), 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示");
                }
            }
        }
        //检索诊断
        private void qTBDiagnosis_AfterSelectedRow(object sender, object SelectedValue)
        {
            Controller.SelectedDiagnosisRow(SelectedValue);
            qTBDiagnosis.Text = "";
        }
        //修改诊断
        private void tBDiagnosis_TextChanged(object sender, EventArgs e)
        {
            if (!_isInitialize)
            {

            }
        }
        //结束诊断编辑
        private void tBDiagnosis_Leave(object sender, EventArgs e)
        {
            if (tBDiagnosis.Text.Trim() != XcConvert.IsNull(this.CurrentPatient.PatList.DiseaseName,"").Trim())
            {
                this.CurrentPatient.PatList.DiseaseName = tBDiagnosis.Text;
                this.CurrentPatient.ChangeDiagnosis();
            }
        }
        //鼠标进入状态栏，显示提示信息
        private void plBaseStatus_MouseEnter(object sender, EventArgs e)
        {
            plToolTip.Top = plToolTip.Parent.Height - plToolTip.Height - 20;
            plToolTip.Left = (plToolTip.Parent.Width - plToolTip.Width) / 2;
            plToolTip.Visible = true;
        }
        //鼠标离开状态栏，隐藏提示信息
        private void plBaseStatus_MouseLeave(object sender, EventArgs e)
        {
            plToolTip.Visible = false;
        }
        //按所选药房过滤药品基础数据
        private void cbBDrugDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isInitialize)
            {
                Controller.FilterDeptDrug();
            }
        }
        //窗口关闭
        private void FrmMedicalManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            medicalReport.DisposeReportPort();
        }
        //修改病人信息
        private void lbChangePatInfo_Click(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                FrmPatInfoEdit form = new FrmPatInfoEdit(this._currentUser.UserID, this._currentDept.DeptID, "病人信息修改", _currentPatient);
                form.ShowDialog();
                ShowPatientInfo();
            }
        }
        #endregion

        #region 助手事件
        //选定病人
        void ucPatientList_SelectDataList(object sender, EventArgs e)
        {
            this.CurrentPatient = new HIS.MZDoc_BLL.Patient((HIS.Model.MZ_PatList)sender);
            //CurrentPatient.ChangeCureInfo(HIS.MZDoc_BLL.Public.PatCureStatus.就诊状态);
        }
        //选定常用药品
        void ucOfenDrug_SelectDataList(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                Controller.WriteCommonItem(Convert.ToInt32(sender), 1);
                this.dGVEMain.CurrentCell = this.dGVEMain[this.Usage_Amount.Index, this.RowIndex];
                this.dGVEMain.Focus();
            }
        }
        //选定常用项目
        void ucOfenItem_SelectDataList(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                Controller.WriteCommonItem(Convert.ToInt32(sender), 0);
                this.dGVEMain.CurrentCell = this.dGVEMain[this.Usage_Amount.Index, this.RowIndex];
                this.dGVEMain.Focus();
            }
        }
        //选定常用诊断
        void ucOfenDiagnosis_SelectDataList(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                Controller.ChangeDiagnosis(sender.ToString());
            }
        }
        //选定处方模板
        void ucPresMould_SelectDataList(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                try
                {
                    Controller.SelectedMould((DataRow[])sender);
                    tSBtnNew_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示");
                }
            }
        }
        #endregion

        #region 工具栏事件
        //保存
        private void tSBtnSave_Click(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                dGVEMain.EndEdit();
                try
                {
                    Controller.SavePrescription();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示");
                }
            }
        }
        //新增
        private void tSBtnNew_Click(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                Controller.AddRow();
                this.dGVEMain.CurrentCell = this.dGVEMain[this.Item_Id.Index, this.RowIndex];
                dGVEMain.Focus();
            }
        }
        //修改
        private void tSBtnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                Controller.UpdateRow();
            }
        }
        //取消
        private void tSBtnCancel_Click(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                Controller.LoadPresList();
            }
        }
        //删除
        private void tSBtnDel_Click(object sender, EventArgs e)
        {

        }
        //模板
        private void tSBtnMould_Click(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                try
                {
                    FrmPreMould frmPreMould = new FrmPreMould(this.currentUser.UserID, this.currentDept.DeptID);
                    frmPreMould.ShowDialog();
                    if (frmPreMould.IsSelected)
                    {
                        Controller.SelectedMould(frmPreMould.SelectedRows);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示");
                }
            }
        }
        //助手
        private void tSBtnDock_Click(object sender, EventArgs e)
        {
            ShowDocAssistant();
        }
        //住院证
        private void tSBtnInPatReg_Click(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                FrmZyInpatReg frmZyInpatReg = new FrmZyInpatReg(this.CurrentPatient, this.currentUser,this.currentDept);
                frmZyInpatReg.ShowDialog();
            }
        }
        //新号
        private void tSBtnNewPat_Click(object sender, EventArgs e)
        {
            FrmRegister frmRegister = new FrmRegister(_currentUser.UserID, _currentDept.DeptID);
            frmRegister.ShowDialog();
            if (frmRegister.CurrentPatient.PatList.PatListID > 0)
            {
                this.CurrentPatient = frmRegister.CurrentPatient;
                this.qTBDiagnosis.Focus();
                Controller.AutoProduceCureFee();
            }
        }
        //结束就诊
        private void tSBtnEnd_Click(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                try
                {
                    Controller.EndCure();
                    MessageBox.Show("结束就诊成功！", "提示");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示");
                }
            }
        }
        //刷新药品及项目
        private void tSBtnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = PublicStaticFun.WaitCursor();
            this.dGVEMain.SetSelectionCardDataSource(Controller.RefreshAllItems().Tables["Item_Dictionary"], this.Item_Id.Index);
            this.ApplyController.RefreshMedicalItemData();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region 右键菜单事件
        //插入一行
        private void tSMnuIInsert_Click(object sender, EventArgs e)
        {
            if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count <= 0||!this.tSMnuIInsert.Enabled)
            {
                return;
            }
            Controller.InsertRow();
            this.dGVEMain.CurrentCell = this.dGVEMain[this.Item_Id.Index, this.RowIndex];
            dGVEMain.Focus();
        }
        //删除一行
        private void tSMnuIDelRow_Click(object sender, EventArgs e)
        {
            if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count <= 0 || !this.tSMnuIDelRow.Enabled)
            {
                return;
            }
            try
            {
                Controller.DeleteRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示");
            }
        }
        //上移一行
        private void tSMnuIUpRow_Click(object sender, EventArgs e)
        {
            if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count <= 0 || !this.tSMnuIUpRow.Enabled)
            {
                return;
            }
            try
            {
                Controller.UpRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        //下移一行
        private void tSMnuIDownRow_Click(object sender, EventArgs e)
        {
            if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count <= 0 || !this.tSMnuIDownRow.Enabled)
            {
                return;
            }            
            try
            {
                Controller.DownRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        //整张删除
        private void tSMnuIDelPres_Click(object sender, EventArgs e)
        {
            if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count <= 0 || !this.tSMnuIDelPres.Enabled)
            {
                return;
            }
            try
            {
                if (MessageBox.Show("确定要删除该张处方吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Controller.DeletePres();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示");
            }
        }
        //分组
        private void tSMnuIGrouping_Click(object sender, EventArgs e)
        {
            if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count <= 0 || !this.tSMnuIGrouping.Enabled)
            {
                return;
            }
            try
            {
                Controller.Grouping();
                Controller.PaintGroup(this.dGVEMain.CreateGraphics());
                if (this._groupStartRowIndex == -1)
                {
                    this.tSMnuIGrouping.Text = "开始分组(Ctrl+F9)";
                }
                else
                {
                    this.tSMnuIGrouping.Text = "结束分组(Ctrl+F9)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        //取消分组
        private void tSMnuICancelGroup_Click(object sender, EventArgs e)
        {
            if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count <= 0 || !this.tSMnuICancelGroup.Enabled)
            {
                return;
            }
            Controller.CancelGroup();
            this.dGVEMain.Refresh();
            //Controller.PaintGroup(this.dGVEMain.CreateGraphics());
            if (this._groupStartRowIndex == -1)
            {
                this.tSMnuIGrouping.Text = "开始分组(Ctrl+F9)";
            }
            else
            {
                this.tSMnuIGrouping.Text = "结束分组(Ctrl+F9)";
            }
        }
        //存为模板
        private void tSMnuISaveAsMould_Click(object sender, EventArgs e)
        {

        }
        //中药脚注
        private void tSMnuIFootNote_Click(object sender, EventArgs e)
        {
            if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count <= 0 || !this.tSMnuIFootNote.Enabled)
            {
                return;
            }
            Controller.AddFootNote();
        }
        //处方打印
        private void tSMnuIPresPrint_Click(object sender, EventArgs e)
        {
            if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count <= 0 || !this.tSMnuIPresPrint.Enabled)
            {
                return;
            }
            try
            {
                Controller.PresPrint();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        //复制处方
        private void tSMnuIPresCopy_Click(object sender, EventArgs e)
        {
            Controller.PresCopy();
        }
        //粘贴处方
        private void tSMnuIPresPaste_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.PresPaste();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        //费用清单打印
        private void tSMnuIFeePrint_Click(object sender, EventArgs e)
        {
            if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count <= 0 || !this.tSMnuIPresPrint.Enabled)
            {
                return;
            }
            try
            {
                Controller.PresFeePrint();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        //自备药品
        private void tSMnuISelfDrug_Click(object sender, EventArgs e)
        {
            Controller.SetSelfDrug();
        }
        #endregion

        #region 网格事件
        private void dGVEMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowid = e.RowIndex;
            int colid = e.ColumnIndex;
            this.RowIndex = e.RowIndex;
            if (rowid > -1)
            {
                Controller.MouldProcess(colid);
            }
        }

        private void dGVEMain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dGVEMain.CurrentCell != null)
            {
                this.RowIndex = this.dGVEMain.CurrentCell.RowIndex;
                Controller.SettingReadOnly(this.dGVEMain.CurrentCell.RowIndex);
                if (!this.dGVEMain.CurrentCell.ReadOnly
                    && this.dGVEMain.CurrentCell.ColumnIndex != this.Item_Id.Index
                     && this.dGVEMain.CurrentCell.ColumnIndex != this.Entrust.Index)
                {
                    this.dGVEMain.BeginEdit(true);
                }
            }
        }
        //回车控制光标
        private void dGVEMain_DataGridViewCellPressEnterKey(object sender, int colIndex, int rowIndex, ref bool jumpStop)
        {
            if ((colIndex == this.Entrust.Index || this.Entrust.ReadOnly && colIndex == this.Usage_Amount.Index))
            {
                this.RowIndex = this.BindPresDataSource.Rows.Count - 1;
                Controller.AddRow();
                this.dGVEMain.CurrentCell = this.dGVEMain[this.Item_Id.Index, this.BindPresDataSource.Rows.Count - 1];
                jumpStop = true;
                //控制水平滑动条
                for (int index = 0; index < this.dGVEMain.Controls.Count; index++)
                {
                    if (this.dGVEMain.Controls[index].GetType().ToString() == "System.Windows.Forms.HScrollBar")
                    {
                        HScrollBar scrollbar = (System.Windows.Forms.HScrollBar)this.dGVEMain.Controls[index];
                        scrollbar.Value = 0;
                    }
                }
            }
        }
        //选中showcard记录后控制光标
        private void dGVEMain_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            try
            {
                DataRow row = (DataRow)SelectedValue;
                int colid = this.dGVEMain.CurrentCell.ColumnIndex;
                int rowid = this.dGVEMain.CurrentCell.RowIndex;
                Controller.SelectCardBindData(colid, row);
                this.dGVEMain.CurrentCell = this.dGVEMain[this.dGVEMain.CurrentCell.ColumnIndex, this.RowIndex];

                if (colid == this.Usage_Unit.Index
                       && rowid > 0 && Convert.ToBoolean(this.BindPresDataSource.Rows[rowid]["IsHerb"])
                       && Convert.ToBoolean(this.BindPresDataSource.Rows[rowid - 1]["IsHerb"]))
                {
                    this.RowIndex = this.BindPresDataSource.Rows.Count - 1;
                    Controller.AddRow();
                    this.dGVEMain.CurrentCell = this.dGVEMain[this.Item_Id.Index, this.BindPresDataSource.Rows.Count - 1];
                    stop = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示");
            }
        }
        //绘制组线
        private void dGVEMain_Paint(object sender, PaintEventArgs e)
        {
            Controller.PaintGroup(e.Graphics);
        }
        //定位到网格的最后一行
        private void dGVEMain_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.BindPresDataSource != null && this.BindPresDataSource.Rows.Count > 0)
            {
                this.dGVEMain.CurrentCell = this.dGVEMain[this.Item_Id.Index, this.BindPresDataSource.Rows.Count - 1];
            }
        }
        #endregion

        #region 医技申请
        /// <summary>
        /// 清空已选项目
        /// </summary>
        private void ClearCheckedItem()
        {
            if (this.chkLBMedicalItem != null)
            {
                for (int index = 0; index < chkLBMedicalItem.Items.Count; index++)
                {
                    chkLBMedicalItem.SetItemChecked(index, false);
                }
            }
        }
        //选择医技申请类别
        private void tbPCMedical_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyController.LoadMedicalDept();
            ClearCheckedItem();
        }
        //选择医技科室
        private void cbBMedicalDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyController.LoadMedicalClass();
        }
        //选择医技申请类型
        private void cbBMedicalClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyController.LoadMedicalItem();
            this.groupBApplyInfo.Controls.Clear();
            FormSite.FormatPanel control = new FormSite.FormatPanel(HIS.MZDoc_BLL.OP_ReadBaseData.GetMedicalApplyXmlDocument(Convert.ToInt32(XcConvert.IsNull(this.cbBMedicalClass.SelectedValue, "-1"))));
            control.Dock = DockStyle.Fill;
            control.ElementValueChanged += new EventHandler(MedicalContent_TextChanged);
            control.MouldButtonClick += new EventHandler(MedicalContent_MouldButtonClick);
            this.groupBApplyInfo.Controls.Add(control);
        }
        //切换处方录入和医技申请界面
        private void tbPCMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentPatient = this.CurrentPatient;
            ClearCheckedItem();
        }
        //修改申请内容
        private void MedicalContent_TextChanged(object sender, EventArgs e)
        {
            if (!_isInitialize)
            {
                ApplyController.ChangeMedicalItem();
            }
        }
        //使用模板
        void MedicalContent_MouldButtonClick(object sender, EventArgs e)
        {
            FormSite.FormatPanel panel = (FormSite.FormatPanel)this.groupBApplyInfo.Controls[0];
            string elementName = XcConvert.IsNull(((Control)sender).Tag, "");
            FrmApplyMould form = new FrmApplyMould(this.CurrentMecicalClass, elementName, this.currentUser.EmployeeID, this.currentDept.DeptID);
            form.MouldContent = panel.GetElementValue(elementName);
            form.ShowDialog();
            if (form.IsSure)
            {
                panel.SetElementValue(elementName, form.MouldContent);
            }
        }
        //保存申请
        private void btApplyOK_Click(object sender, EventArgs e)
        {
            if (CheckCurrentPatient())
            {
                if (ApplyController.SaveMedicalApply())
                {
                    ClearCheckedItem();
                }
            }
        }
        //检索医技项目
        private void qTxtMecicalItemQuery_AfterSelectedRow(object sender, object SelectedValue)
        {
            DataRow row = (DataRow)SelectedValue;
            for (int i = 0; i < this.chkLBMedicalItem.Items.Count; i++)
            {
                HIS.MZDoc_BLL.Medical_Order_Item item = (HIS.MZDoc_BLL.Medical_Order_Item)this.chkLBMedicalItem.Items[i];
                if (item.Order_Id == Convert.ToInt32(row["Order_Id"]))
                {
                    this.chkLBMedicalItem.SelectedIndex = i;
                    ((GWI.HIS.Windows.Controls.QueryTextBox)sender).Text = "";
                    this.chkLBMedicalItem.Focus();
                    break;
                }
            }
        }
        //回车选中项目
        private void chkLBMedicalItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (this.chkLBMedicalItem.GetItemChecked(this.chkLBMedicalItem.SelectedIndex) == false)
                    this.chkLBMedicalItem.SetItemChecked(this.chkLBMedicalItem.SelectedIndex, true);
                else
                    this.chkLBMedicalItem.SetItemChecked(this.chkLBMedicalItem.SelectedIndex, false);
                chkLBMedicalItem_SelectedIndexChanged(sender, e);
            }
        }
        //选中申请项目
        private void chkLBMedicalItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyController.SelectMedicalItem();
        }
        //显示申请内容
        private void dGVEApplyList_CurrentCellChanged(object sender, EventArgs e)
        {
            _isInitialize = true;
            ApplyController.ViewMedicalItem();
            _isInitialize = false;
        }
        //申请打印
        private void btApplyPrint_Click(object sender, EventArgs e)
        {
            ApplyController.ApplyPrint();
        }
        //移动在医技申请列表中的光标单元格
        private void dGVEApplyList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ApplyController.ChangeSelected();
        }
        //查询
        private void btSearch_Click(object sender, EventArgs e)
        {
            ApplyController.LoadMedicalApplyList(this.dTPkbDate.Value, this.dTPkeDate.Value);
        }
        //打印报告
        private void btReport_Click(object sender, EventArgs e)
        {
            if (MedicalApplyList == null || MedicalApplyListRowIndex < 0 || MedicalApplyListRowIndex >= MedicalApplyList.Rows.Count)
            {
                return;
            }
            medicalReportInfo.Patid = Convert.ToInt64(CurrentPatient.PatList.PatID);
            medicalReportInfo.PatListid = CurrentPatient.PatList.PatListID;
            medicalReportInfo.PresListId = Convert.ToInt64(MedicalApplyList.Rows[MedicalApplyListRowIndex]["PresListId"]);
            medicalReportInfo.TicketNum = MedicalApplyList.Rows[MedicalApplyListRowIndex]["TicketNum"].ToString();
            medicalReportInfo.VisitNo = CurrentPatient.PatList.VisitNo;
            object obj = medicalReport.GetMedicalResultReport((HIS.MZDoc_BLL.Public.MedicalApplyType)Convert.ToInt32(MedicalApplyList.Rows[MedicalApplyListRowIndex]["Apply_Type"]), medicalReportInfo);
            switch (HIS.MZDoc_BLL.Public.StaticConfig.CurrentReportFormat)
            {
                case HIS.MZDoc_BLL.Public.MedicalReportFormat.图片:
                    if (obj != null)
                    {
                        FrmMedicalReport form = new FrmMedicalReport();
                        Bitmap image = (Bitmap)obj;
                        form.ShowImage = image;
                        form.ShowDialog();
                        image.Dispose();
                    }
                    break;
                case HIS.MZDoc_BLL.Public.MedicalReportFormat.无返回:
                    break;
                default:
                    break;
            }
        }
        //打印影像报告
        private void btImage_Click(object sender, EventArgs e)
        {
            if (MedicalApplyList == null || MedicalApplyListRowIndex < 0 || MedicalApplyListRowIndex >= MedicalApplyList.Rows.Count)
            {
                return;
            }
            medicalReportInfo.Patid = Convert.ToInt64(CurrentPatient.PatList.PatID);
            medicalReportInfo.PatListid = CurrentPatient.PatList.PatListID;
            medicalReportInfo.PresListId = Convert.ToInt64(MedicalApplyList.Rows[MedicalApplyListRowIndex]["PresListId"]);
            medicalReportInfo.TicketNum = MedicalApplyList.Rows[MedicalApplyListRowIndex]["TicketNum"].ToString();
            medicalReportInfo.VisitNo =  CurrentPatient.PatList.VisitNo;
            object obj = medicalReport.GetMedicalResultImage((HIS.MZDoc_BLL.Public.MedicalApplyType)Convert.ToInt32(MedicalApplyList.Rows[MedicalApplyListRowIndex]["Apply_Type"]), medicalReportInfo);
            switch (HIS.MZDoc_BLL.Public.StaticConfig.CurrentReportFormat)
            {
                case HIS.MZDoc_BLL.Public.MedicalReportFormat.图片:
                    if (obj != null)
                    {
                        FrmMedicalReport form = new FrmMedicalReport();
                        Bitmap image = (Bitmap)obj;
                        form.ShowImage = image;
                        form.ShowDialog();
                        image.Dispose();
                    }
                    break;
                case HIS.MZDoc_BLL.Public.MedicalReportFormat.无返回:
                    break;
                default:
                    break;
            }
        }
        //双击医技申请查看报告
        private void dGVMedicalResult_DoubleClick(object sender, EventArgs e)
        {
            btReport_Click(null,null);
        }
        #endregion
    }
}
