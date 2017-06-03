using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_MZDocManager
{
    public partial class FrmRegister : Form
    {
        private User _currentUser;  //当前用户
        private Deptment _currentDept;  //当前科室
        private bool _isSure = false;
        private HIS.MZDoc_BLL.Patient _currentPatient = new HIS.MZDoc_BLL.Patient(new HIS.Model.MZ_PatList());

        /// <summary>
        /// 当前病人
        /// </summary>
        public HIS.MZDoc_BLL.Patient CurrentPatient
        {
            get { return _currentPatient; }
            set { _currentPatient = value; }
        }
        public FrmRegister(long currentUserId, long currentDeptId)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
        }

        /// <summary>
        /// 显示病人信息
        /// </summary>
        private void ShowPatInfo()
        {
            this.txtName.Text = _currentPatient.PatList.PatName;
            this.cboSex.Text = _currentPatient.PatList.PatSex;
            this.txtTel.Text = _currentPatient.PatientInfo.PatTEL;
            this.cboFeeType.SelectedValue = _currentPatient.PatList.MediType;
            this.txtAddress.Text = _currentPatient.PatientInfo.PatAddress;
            this.txtIdentityCard.Text = _currentPatient.PatientInfo.PatNumber;
            this.cboJob.Text = _currentPatient.PatientInfo.PATJOB;
            this.qTxtWorkUnit.SelectedValue = _currentPatient.PatList.HpCode;

            CalculatePatAge();
            this.txtAge.Text = _currentPatient.PatList.Age.ToString();
            this.cbBAgeType.Text = _currentPatient.PatList.HpGrade;
        }

        /// <summary>
        /// 计算病人年龄
        /// </summary>
        private void CalculatePatAge()
        {
            if (_currentPatient.PatList.PatID > 0 && _currentPatient.PatientInfo.PatBriDate != null && _currentPatient.PatientInfo.PatID > 0)
            {
                HIS.MZDoc_BLL.Public.PeopleAge age = HIS.MZDoc_BLL.Public.Function.TransBirthdayToAge(_currentPatient.PatientInfo.PatBriDate);
                _currentPatient.PatList.HpGrade = age.AgeUnit;
                _currentPatient.PatList.Age = age.AgeNum;
            }
        }

        /// <summary>
        /// 检查病人信息完整性
        /// </summary>
        /// <returns></returns>
        private bool CheckPatInfo()
        {
            if (this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("病人姓名不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtName.Focus();
                return false;
            }
            if (this.cboSex.Text.Trim() == "")
            {
                MessageBox.Show("病人性别不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cboSex.Focus();
                return false;

            }
            try
            {
                int age = Convert.ToInt32(this.txtAge.Text);
                if (age <= 0)
                {
                    throw new Exception("");
                }
            }
            catch
            {
                MessageBox.Show("病人年龄输入有误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cboSex.Focus();
                return false;
            }
            if (this.cboFeeType.Text == "")
            {
                MessageBox.Show("病人类型不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cboFeeType.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获得病人就诊信息
        /// </summary>
        private void GetPatListInfo()
        {
            _currentPatient.PatList = new HIS.Model.MZ_PatList();
            _currentPatient.PatList.REG_DEPT_CODE = _currentDept.DeptID.ToString();
            _currentPatient.PatList.REG_DEPT_NAME = _currentDept.Name;
            _currentPatient.PatList.REG_DOC_CODE = _currentUser.EmployeeID.ToString();
            _currentPatient.PatList.REG_DOC_NAME = _currentUser.Name;
            _currentPatient.PatList.MediType = this.cboFeeType.SelectedValue.ToString();
            _currentPatient.PatList.HpCode = this.qTxtWorkUnit.MemberValue == null ? "" : this.qTxtWorkUnit.MemberValue.ToString();
            _currentPatient.PatList.CureDeptCode = _currentDept.DeptID.ToString();
            _currentPatient.PatList.CureEmpCode = _currentUser.EmployeeID.ToString();
            _currentPatient.PatList.CureDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            _currentPatient.PatList.CureStatus = (int)HIS.MZDoc_BLL.Public.PatCureStatus.就诊状态;
            _currentPatient.PatList.Age = Convert.ToInt32(this.txtAge.Text);
            _currentPatient.PatList.HpGrade = this.cbBAgeType.Text.Trim();
        }

        /// <summary>
        /// 获得病人基本信息
        /// </summary>
        private void GetPatInfo()
        {
            _currentPatient = new HIS.MZDoc_BLL.Patient();
            _currentPatient.FeeTypeName = this.cboFeeType.Text.Trim();

            _currentPatient.PatientInfo = new HIS.Model.PatientInfo();
            _currentPatient.PatientInfo.PatName = this.txtName.Text.Trim();
            _currentPatient.PatientInfo.PatSex = this.cboSex.Text.Trim();
            _currentPatient.PatientInfo.PatNumber = this.txtIdentityCard.Text.Trim();
            _currentPatient.PatientInfo.PatTEL = this.txtTel.Text.Trim();
            _currentPatient.PatientInfo.PatAddress = this.txtAddress.Text.Trim();
            _currentPatient.PatientInfo.PATJOB = this.cboJob.Text.Trim();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            this.cboFeeType.DataSource = HIS.MZDoc_BLL.OP_ReadBaseData.GetPatientTypeData();
            this.cboFeeType.DisplayMember = "NAME";
            this.cboFeeType.ValueMember = "CODE";
            this.cboFeeType.SelectedValue = "01";

            this.cboSex.Text = "男性";
            this.cboJob.Text = "农民";
            this.cbBAgeType.Text = "岁";

            this.qTxtWorkUnit.SetSelectionCardDataSource(HIS.MZDoc_BLL.OP_ReadBaseData.GetWorkUnitData());
            this.dTPkBegin.Value = this.dTPkEnd.Value.AddDays(-2);
        }

        //选择工作单位
        private void qTxtWorkUnit_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (SelectedValue != null)
            {
                this.qTxtWorkUnit.MemberValue = ((DataRow)SelectedValue)["Code"].ToString();
                this.qTxtWorkUnit.Text = ((DataRow)SelectedValue)["Name"].ToString();
            }
        }
        //查询病人
        private void btQuery_Click(object sender, EventArgs e)
        {
            List<HIS.Model.MZ_PatList> patList = HIS.MZDoc_BLL.OP_Patient.SearchPatList(this.txtCardNo.Text.Trim(), this.qTxtName.Text.Trim(), dTPkBegin.Value, dTPkEnd.Value);
            this.lVPatList.Items.Clear();
            for (int index = 0; index < patList.Count; index++)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Tag = patList[index];
                listViewItem.Text = patList[index].PatName;
                listViewItem.SubItems.Add(patList[index].PatSex);
                listViewItem.SubItems.Add(patList[index].Age + patList[index].HpGrade);
                listViewItem.SubItems.Add(patList[index].DiseaseName);
                listViewItem.SubItems.Add(patList[index].CureDate.ToString());
                this.lVPatList.Items.Add(listViewItem);
            }
        }
        //选择已有病人
        private void lVPatList_DoubleClick(object sender, EventArgs e)
        {
            if (lVPatList.SelectedItems != null && lVPatList.SelectedItems.Count > 0)
            {
                _currentPatient = new HIS.MZDoc_BLL.Patient((HIS.Model.MZ_PatList)lVPatList.SelectedItems[0].Tag);
                ShowPatInfo();
            }
        }
        //产生新号
        private void btSure_Click(object sender, EventArgs e)
        {
            if (_currentPatient.PatList.PatID <= 0 || _currentPatient.PatientInfo==null || _currentPatient.PatientInfo.PatID<=0)
            {
                if (!CheckPatInfo())
                {
                    return;
                }
                GetPatInfo();
            }
            GetPatListInfo();
            if (_currentPatient.SavePatientInfo())
            {
                _isSure = true;
                this.Close();
            }
        }

        //退出
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPatInfor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{Tab}");
        }

        private void qTxtWorkUnit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.btSure.Focus();
        }

        private void FrmRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
            {
                this.btSure_Click(null,null);
            }
        }

        private void FrmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isSure)
            {
                _currentPatient = new HIS.MZDoc_BLL.Patient(new HIS.Model.MZ_PatList());
            }
        }
    }
}
