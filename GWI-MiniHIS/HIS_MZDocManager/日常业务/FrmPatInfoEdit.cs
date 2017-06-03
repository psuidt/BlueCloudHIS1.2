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
    public partial class FrmPatInfoEdit : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;  //当前用户
        private Deptment _currentDept;  //当前科室
        private HIS.MZDoc_BLL.Patient _currentPatient; //当前病人

        public FrmPatInfoEdit(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            this.FormTitle = chineseName;
        }

        public FrmPatInfoEdit(long currentUserId, long currentDeptId, string chineseName, long patListId)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            this.FormTitle = chineseName;
            this._currentPatient = new HIS.MZDoc_BLL.Patient(patListId);
            this.tBVisitNo.Enabled = false;
        }

        public FrmPatInfoEdit(long currentUserId, long currentDeptId, string chineseName, HIS.MZDoc_BLL.Patient patient)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            this.FormTitle = chineseName;
            this._currentPatient = patient;
            this.tBVisitNo.Enabled = false;
        }

        /// <summary>
        /// 显示病人信息
        /// </summary>
        private void ShowPatInfo()
        {
            if (_currentPatient != null)
            {
                this.tBCardno.Text = _currentPatient.PatList.MediCard;
                this.tBVisitNo.Text = _currentPatient.PatList.VisitNo;
                this.txtName.Text = _currentPatient.PatList.PatName;
                this.cboSex.Text = _currentPatient.PatList.PatSex;
                this.txtTel.Text = _currentPatient.PatientInfo.PatTEL;
                this.cboFeeType.SelectedValue = _currentPatient.PatList.MediType;
                this.txtAddress.Text = _currentPatient.PatientInfo.PatAddress;
                this.txtIdentityCard.Text = _currentPatient.PatientInfo.PatNumber;
                this.cboJob.Text = _currentPatient.PatientInfo.PATJOB;
                this.qTxtWorkUnit.MemberValue = _currentPatient.PatList.HpCode;
                this.txtAllergic.Text = _currentPatient.PatientInfo.ALLERGIC;

                CalculatePatAge();
                this.txtAge.Text = _currentPatient.PatList.Age.ToString();
                this.cbBAgeType.Text = _currentPatient.PatList.HpGrade;
            }
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
            _currentPatient.PatList.MediCard = this.tBCardno.Text.Trim();
            //_currentPatient.PatList.VisitNo = this.tBVisitNo.Text.Trim();
            _currentPatient.PatList.PatName = this.txtName.Text.Trim();
            _currentPatient.PatList.PatSex = this.cboSex.Text.Trim();
            _currentPatient.PatList.MediType = this.cboFeeType.SelectedValue.ToString();
            _currentPatient.PatList.HpCode = this.qTxtWorkUnit.MemberValue == null ? "" : this.qTxtWorkUnit.MemberValue.ToString();
            _currentPatient.PatList.Age = Convert.ToInt32(this.txtAge.Text);
            _currentPatient.PatList.HpGrade = this.cbBAgeType.Text.Trim();
        }

        /// <summary>
        /// 获得病人基本信息
        /// </summary>
        private void GetPatInfo()
        {
            _currentPatient.FeeTypeName = this.cboFeeType.Text.Trim();
            _currentPatient.PatientInfo.PatName = this.txtName.Text.Trim();
            _currentPatient.PatientInfo.PatSex = this.cboSex.Text.Trim();
            _currentPatient.PatientInfo.PatNumber = this.txtIdentityCard.Text.Trim();
            _currentPatient.PatientInfo.PatTEL = this.txtTel.Text.Trim();
            _currentPatient.PatientInfo.PatAddress = this.txtAddress.Text.Trim();
            _currentPatient.PatientInfo.PATJOB = this.cboJob.Text.Trim();
            _currentPatient.PatientInfo.ALLERGIC = this.txtAllergic.Text.Trim();
        }

        private void FrmPatInfoEdit_Load(object sender, EventArgs e)
        {
            this.cboFeeType.DataSource = HIS.MZDoc_BLL.OP_ReadBaseData.GetPatientTypeData();
            this.cboFeeType.DisplayMember = "NAME";
            this.cboFeeType.ValueMember = "CODE";

            this.qTxtWorkUnit.SetSelectionCardDataSource(HIS.MZDoc_BLL.OP_ReadBaseData.GetWorkUnitData());
            ShowPatInfo();
        }

        private void qTxtWorkUnit_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (SelectedValue != null)
            {
                this.qTxtWorkUnit.MemberValue = ((DataRow)SelectedValue)["Code"].ToString();
                this.qTxtWorkUnit.Text = ((DataRow)SelectedValue)["Name"].ToString();
            }
        }

        private void btSure_Click(object sender, EventArgs e)
        {
            if (this._currentPatient == null)
            {
                MessageBox.Show("请先指定病人！");
                return;
            }
            if (CheckPatInfo())
            {
                GetPatInfo();
                GetPatListInfo();
                _currentPatient.UpdatePatientInfo();
                MessageBox.Show("修改成功！");
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tBVisitNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13 && this.tBVisitNo.Text.Trim()!="")
            {
                this._currentPatient = new HIS.MZDoc_BLL.Patient(this.tBVisitNo.Text.Trim());
                if (this._currentPatient.PatList.PatListID == 0)
                {
                    MessageBox.Show("找不到与该门诊号对应的病人信息！");
                    return;
                }
                ShowPatInfo();
            }
        }
    }
}
