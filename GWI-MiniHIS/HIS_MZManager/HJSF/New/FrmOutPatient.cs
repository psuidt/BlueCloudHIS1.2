using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_MZManager.HJSF
{
    public partial class FrmOutPatient : BaseForm , IFrmOutPatient
    {
        //窗体行为(0-新增病人 1-修改病人信息 2-查找病人)
        private int formAction;
        private UIOutPatient patient;
        private FrmOutPatientController controller;
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Action">窗体行为(0-新增病人 1-修改病人信息 2-查找病人)</param>
        public FrmOutPatient(bool AddNewMode)
        {
            InitializeComponent( );

            if ( AddNewMode )
            {
                formAction = 0;
                this.Text = "新病人";
            }
            else
            {
                formAction = 2;
                this.Text = "查找病人";
            }

            this.Load += new EventHandler( FrmOutPatient_Load );
        }
        /// <summary>
        /// 
        /// </summary>
        ///<param name="Patient">要修改的病人信息</param>
        public FrmOutPatient( IOutPatient Patient )
        {
            InitializeComponent( );

            this.Text = "修改病人信息";

            formAction = 1;
            patient = (UIOutPatient)Patient;
            this.Load += new EventHandler( FrmOutPatient_Load );
            
        }

        public IOutPatient Result
        {
            get
            {
                return patient;
            }
        }

        void FrmOutPatient_Load( object sender , EventArgs e )
        {
            controller = new FrmOutPatientController( this );
            controller.BeforeSaveEvent += new OnBeforeSaveEventHandle( controller_BeforeSaveEvent );

            #region loading data and initialize control datasource
            if ( formAction != 2 )
            {
                //医生
                txtCureDoctor.SetSelectionCardDataSource( controller.Doctors );
                //科室
                txtCureDept.SetSelectionCardDataSource( controller.Departments );
                //年龄单位
                foreach ( object obj in Enum.GetValues( typeof( AgeUnit ) ) )
                    cboAgeUnit.Items.Add( obj.ToString( ) );
                cboAgeUnit.SelectedIndex = 0;

                //病人类型
                cboPatType.DisplayMember = "NAME";
                cboPatType.ValueMember = "PATTYPECODE";
                cboPatType.DataSource = controller.PatientType;
                //工作单位
                txtWorkUnit.SetSelectionCardDataSource( controller.WorkUnits );
                //疾病
                txtDisease.SetSelectionCardDataSource( controller.Diseases );
            }
            #endregion

            if ( patient != null )
                controller.SetPatient( patient );

            if ( formAction == 0 )
                gbSearch.Enabled = false;
            else if ( formAction == 1 )
                gbSearch.Enabled = false;
            else
            {
                gbBaseInfo.Enabled = false;
                gbCureInfo.Enabled = false;
            }

            BindKeyPressEvent( );
            txtAge.Leave += new EventHandler( txtAge_Leave );

            chkKeyName.CheckedChanged += new EventHandler( chkKeyName_CheckedChanged );
            chkPatientNo.CheckedChanged += new EventHandler( chkPatientNo_CheckedChanged );
            dgvSearchResultList.DoubleClick += new EventHandler( dgvSearchResultList_DoubleClick );
        }

        void dgvSearchResultList_DoubleClick( object sender , EventArgs e )
        {
            btnSelected_Click( null , null );
        }

        void chkPatientNo_CheckedChanged( object sender , EventArgs e )
        {
            txtOutPatientNo.Enabled = chkPatientNo.Checked;
        }

        void chkKeyName_CheckedChanged( object sender , EventArgs e )
        {
            txtKeyName.Enabled = chkKeyName.Checked;
        }

        void txtAge_Leave( object sender , EventArgs e )
        {
            if ( txtAge.Text.Trim( ) == "" )
                txtAge.Text = "18";
        }

        void controller_BeforeSaveEvent( object sender , BeforeSaveEventArgs e )
        {
            if ( txtPatientName.Text == "" )
            {
                MessageBox.Show( "病人姓名不能为空！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtPatientName.Focus( );
                e.Cancel = true;
                return;
            }

            if ( txtCureDoctor.Text == "" || txtCureDoctor.MemberValue == null )
            {
                MessageBox.Show( "就诊医生不能为空！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtCureDoctor.Focus( );
                e.Cancel = true;
                return;
            }

            if ( txtCureDept.Text == "" || txtCureDept.MemberValue == null )
            {
                MessageBox.Show( "就诊科室不能为空！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtCureDept.Focus( );
                e.Cancel = true;
                return;
            }
        }

        #region IFrmOutPatient 成员

        public int FormAction
        {
            get
            {
                return formAction;
            }
            set
            {
                formAction = value;
            }
        }

        public IOutPatient Patient
        {
            get
            {
                if ( patient == null )
                    patient = new UIOutPatient( );
                patient.PatientName = txtPatientName.Text.Trim( );
                patient.Sex = cboSex.Text;
                Age age = new Age();
                age.AgeNum = Convert.ToInt32(txtAge.Text);
                age.Unit = AgeUnit.岁;
                foreach(object obj in Enum.GetValues(typeof(AgeUnit)))
                {
                    if ( obj.ToString( ) == cboAgeUnit.Text )
                    {
                        age.Unit = (AgeUnit)obj;
                        break;
                    }
                }
                patient.BordDay = XcDate.AgeToDate( age );
                patient.PatientType = new BindValue( cboPatType.SelectedValue , cboPatType.Text );
                patient.WorkUnit = new BindValue( txtWorkUnit.MemberValue , txtWorkUnit.Text );
                patient.CureDoctor = new BindValue( txtCureDoctor.MemberValue , txtCureDoctor.Text );
                patient.CureDepartment = new BindValue( txtCureDept.MemberValue , txtCureDept.Text );
                if ( txtDisease.MemberValue != null )
                    patient.Disease = new BindValue( txtDisease.MemberValue , txtDisease.Text );
                return patient;
            }
            set
            {
                if ( value == null )
                    patient = null;
                else
                    patient = (UIOutPatient)value;

                if ( patient != null )
                {
                    txtPatientName.Text = patient.PatientName;
                    cboSex.Text = patient.Sex;
                    Age age = XcDate.DateToAge( patient.BordDay );
                    txtAge.Text = age.AgeNum.ToString( );
                    cboAgeUnit.Text = age.Unit.ToString( );
                    txtWorkUnit.Text = ( patient.WorkUnit != null ? patient.WorkUnit.Value.Text : "" );
                    txtWorkUnit.MemberValue = ( patient.WorkUnit != null ? ( patient.WorkUnit.Value.Code ==null ? "" : patient.WorkUnit.Value.Code.ToString( ) ) : "" );
                    cboPatType.SelectedValue = patient.PatientType != null ? ( patient.PatientType.Value.Code==null?"":patient.PatientType.Value.Code.ToString( ) ) : "";

                    txtCureDoctor.MemberValue = ( patient.CureDoctor != null ? ( patient.CureDoctor.Value.Code==null?0:Convert.ToInt32( patient.CureDoctor.Value.Code ) ) : 0 );
                    if ( patient.CureDoctor!=null && patient.CureDoctor.Value.Code != null )
                        txtCureDoctor.Text = ( patient.CureDoctor != null ? patient.CureDoctor.Value.Text : "" );

                    txtCureDept.MemberValue = ( patient.CureDepartment != null ? Convert.ToInt32( patient.CureDepartment.Value.Code == null ? 0 : patient.CureDepartment.Value.Code ) : 0 );
                    if ( patient.CureDepartment != null && patient.CureDepartment.Value.Code!= null )
                        txtCureDept.Text = ( patient.CureDepartment != null ? patient.CureDepartment.Value.Text : "" );

                    if ( patient.Disease != null && patient.Disease.Value.Code != null )
                    {
                        txtDisease.Text = patient.Disease.Value.Text;
                        txtDisease.MemberValue = patient.Disease.Value.Code;
                    }
                }
                else
                {
                    txtPatientName.Text = "";
                    cboSex.Text = "";
                    Age age = new Age( 20 , AgeUnit.岁 );
                    txtAge.Text = age.AgeNum.ToString( );
                    cboAgeUnit.Text = age.Unit.ToString( );
                    txtWorkUnit.Text = "";
                    txtWorkUnit.MemberValue = null;
                    cboPatType.SelectedIndex = -1;

                    txtCureDoctor.MemberValue = null;
                    txtCureDoctor.Text = "";

                    txtCureDept.MemberValue = null;
                    txtCureDept.Text = "";

                    txtDisease.Text = "";
                    txtDisease.MemberValue = null;
                }
            }
        }

        public DataTable SearchResultList
        {
            get
            {
                return (DataTable)dgvSearchResultList.DataSource;
            }
            set
            {
                dgvSearchResultList.DataSource = value;
            }
        }
        public int SelectedPatientId
        {
            get
            {
                if ( dgvSearchResultList.Rows.Count > 0 && dgvSearchResultList.CurrentCell != null )
                {
                    return Convert.ToInt32( dgvSearchResultList[PATLISTID.Name , dgvSearchResultList.CurrentCell.RowIndex].Value );
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            try
            {
                if ( controller.SavePatient( ) )
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close( );
                }
            }
            catch ( Exception err )
            {
                HIS.MZ_BLL.ErrorWriter.WriteLog( err.Message + "\r\n" + err.StackTrace );
                MessageBox.Show( "保存发生错误!" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnSearch_Click( object sender , EventArgs e )
        {
            
            dgvSearchResultList.AutoGenerateColumns = false;
            SearchCondiction condiction = new SearchCondiction( );
            condiction.BeginDate = dtpFrom.Value;
            condiction.EndDate = dtpTo.Value;
            condiction.OutPatientNo = "";
            condiction.PatientNameKeyWord = "";
            if ( chkKeyName.Checked )
                condiction.PatientNameKeyWord = txtKeyName.Text;
            if ( chkPatientNo.Checked )
                condiction.OutPatientNo = txtOutPatientNo.Text;
            controller.Condiction = condiction;
            controller.SearchingPatient( );
        }

        private void btnSelected_Click( object sender , EventArgs e )
        {
            if ( dgvSearchResultList.DataSource == null )
                return;
            if ( dgvSearchResultList.Rows.Count == 0 )
                return;
            if ( controller.SelectedPateint( ) )
            {
                this.DialogResult = DialogResult.OK;
                this.Close( );
            }

        }

        private void PressEnterKeyEvent( object sender , KeyPressEventArgs e )
        {
            Control ctrl = (Control)sender;
            if ( (int)e.KeyChar == 13 )
            {
                if ( ctrl.Name == txtPatientName.Name && txtPatientName.Text.Trim() != "")
                    cboSex.Focus( );
                if ( ctrl.Name == cboSex.Name && cboSex.Text!="" )
                    txtAge.Focus( );
                if ( ctrl.Name == txtAge.Name  )
                    cboAgeUnit.Focus( );
                if ( ctrl.Name == cboAgeUnit.Name )
                    cboPatType.Focus( );
                if ( ctrl.Name == cboPatType.Name )
                    txtWorkUnit.Focus( );
                if ( ctrl.Name == txtWorkUnit.Name )
                    txtCureDoctor.Focus( );
            }
        }

        private void BindKeyPressEvent()
        {
            txtPatientName.KeyPress += new KeyPressEventHandler( PressEnterKeyEvent );
            cboSex.KeyPress += new KeyPressEventHandler( PressEnterKeyEvent );
            txtAge.KeyPress += new KeyPressEventHandler( PressEnterKeyEvent );
            cboAgeUnit.KeyPress += new KeyPressEventHandler( PressEnterKeyEvent );
            cboPatType.KeyPress += new KeyPressEventHandler( PressEnterKeyEvent );
            txtWorkUnit.KeyPress += new KeyPressEventHandler( PressEnterKeyEvent );
        }
    }
}
