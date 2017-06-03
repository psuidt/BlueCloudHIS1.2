using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace HIS_MZManager.GH
{
    public partial class FrmMzgh : GWI.HIS.Windows.Controls.BaseMainForm ,IFrmMzgh
    {
        private GWMHIS.BussinessLogicLayer.Classes.User currentUser;

        private FrmMzghController controller;

        private HIS.MZ_BLL.RegPatient patient ;

        private bool showDialog;

        private FormType formType;

        public FrmMzgh( string FormText, GWMHIS.BussinessLogicLayer.Classes.User CurrentUser )
        {
            InitializeComponent( );

            this.Text = FormText;
            this.FormTitle = FormText;
            currentUser = CurrentUser;

            controller = new FrmMzghController( this );

            showDialog = false;
        }

        public FrmMzgh( string FormText , GWMHIS.BussinessLogicLayer.Classes.User CurrentUser , bool ShowDialog ,FormType _formType )
        {
            InitializeComponent( );

            this.Text = FormText;
            this.FormTitle = FormText;
            currentUser = CurrentUser;

            controller = new FrmMzghController( this );

            showDialog = true;

            formType = _formType;
        }

        private void FrmMzgh_Load( object sender , EventArgs e )
        {
            
            if ( showDialog )
            {
                this.Size = new Size( Screen.PrimaryScreen.WorkingArea.Width , 500 );
                if ( formType == FormType.门诊划价 )
                {
                    btnRegister.Visible = false;
                    btnCancelRegister.Visible = false;
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                }
                else
                {
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    btnRegister.Visible = true;
                    btnCancelRegister.Visible = true;
                }
                controller.ShowAllPatient = true;
            }
            controller.InitViewData( );
            controller.Refresh();

            cboSex.KeyPress += new KeyPressEventHandler( OnPressEnterKey );
            cboFeeType.KeyPress += new KeyPressEventHandler( OnPressEnterKey );
            cboAgeUnit.KeyPress += new KeyPressEventHandler( OnPressEnterKey );

            cboSex.SelectedIndex = 0;
            cboFeeType.ValueMember = "PATTYPECODE";
            cboFeeType.DisplayMember = "NAME";
            cboFeeType.DataSource = controller.PatientTypeList;
            cboFeeType.SelectedIndex = 0;

            cboAgeUnit.Text = "岁";
            
            cboSex.SelectedIndex = 1;
            try
            {
                if ( formType == FormType.门诊收费 )
                    controller.ShowCurrentRegisterInvoiceNo( );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }

            txtPatName.Focus( );
        }

        

        private void OnPressEnterKey(object sender,KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar != 13 )
                return;

            Control ctrl = (Control)sender;
            if ( ctrl.Name == cboSex.Name )
                txtAge.Focus( );

            if ( ctrl.Name == cboAgeUnit.Name )
                cboFeeType.Focus( );

            if (ctrl.Name == cboFeeType.Name)
                txtTel.Focus();

            if (ctrl.Name == txtTel.Name)
                txtLinkAddress.Focus();

            if (ctrl.Name == txtLinkAddress.Name)
                txtAllergic.Focus();

            if (ctrl.Name == txtAllergic.Name)
                txtRegDept.Focus();
            
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void btnRegister_Click( object sender, EventArgs e )
        {
            try
            {
                
                patient = new HIS.MZ_BLL.RegPatient( );

                if ( controller.ProcessRegister() )
                {
                    if ( showDialog )
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close( );
                    }
                    else
                    {
                        ClearInfo( );
                        controller.Refresh( );
                        //txtHisCard.Focus( );
                        txtPatName.Focus( );
                    }
                }
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btnCancelRegister_Click( object sender, EventArgs e )
        {
            try
            {
                if ( controller.CancelRegister( ) )
                {
                    MessageBox.Show( "退号操作成功！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                    controller.Refresh( );
                }
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            try
            {
                controller.Refresh();
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void txtRegDoc_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                this.toolStrip1.Focus();
                this.btnRegister.Select();
            }
        }

        private void ClearInfo()
        {
            patient = null;
            txtHisCard.Text = "";
            txtPatName.Text = "";
            cboSex.Text = "";
            cboFeeType.SelectedIndex = 0;
            cboAgeUnit.Text = "岁";

            txtRegDept.MemberValue = null;
            txtRegDept.Text = "";
            txtRegDoc.MemberValue = null;
            txtRegDoc.Text = "";
            txtRegType.MemberValue = null;
            txtRegType.Text = "";
        }

        #region IFrmMzgh 成员

        public HIS.MZ_BLL.RegPatient Patient
        {
            get
            {
                //if (patient == null )
                //    patient = new HIS.MZ_BLL.RegPatient();
                patient.HisCardNo = txtHisCard.Text;
                patient.PatientName = txtPatName.Text;
                patient.Sex = cboSex.Text;
                patient.PatType = new HIS.MZ_BLL.PatientType( );
                patient.PatType.Code = cboFeeType.SelectedValue==null ? "" : cboFeeType.SelectedValue.ToString( );
                patient.PatType.Name = cboFeeType.Text;
                patient.Age = Convert.ToInt32( txtAge.Text );
                patient.AgeUnit = cboAgeUnit.Text;
                patient.Address = txtLinkAddress.Text;
                patient.Allergic = txtAllergic.Text;
                patient.Tel = txtTel.Text;
                //patient.PatType.Name = cboFeeType.Text;
                
               
                patient.RegDeptCode = txtRegDept.MemberValue == null ? "" : txtRegDept.MemberValue.ToString();
                patient.RegDeptName = txtRegDept.Text;
                patient.RegTypeCode = txtRegType.MemberValue == null ? "" : txtRegType.MemberValue.ToString();
                patient.RegTypeName = txtRegType.Text;
                patient.RegDoctorCode = txtRegDoc.MemberValue == null ? "" : txtRegDoc.MemberValue.ToString();
                patient.RegDoctorName = txtRegDoc.Text;
                
                return patient;
            }
            set
            {
                if ( value != null )
                {
                    if ( value.PatID != 0 )
                        txtHisCard.Text = value.HisCardNo;
                    txtPatName.Text = value.PatientName;
                    cboSex.Text = value.Sex;
                    cboFeeType.SelectedValue = value.PatType == null ? "01" : value.PatType.Code;
                    txtTel.Text = value.Tel;
                    txtLinkAddress.Text = value.Address;
                    txtAllergic.Text = value.Allergic;
                    if ( showDialog )
                    {
                        txtRegDept.MemberValue = value.RegDeptCode;
                        txtRegDoc.MemberValue = value.RegDoctorCode;
                    }
                    patient = value;
                }
                else
                {
                    ClearInfo();
                }
                patient = value;
            }
        }

        public DataTable RegisterList
        {
            get
            {
                return (DataTable)this.dgvRegList.DataSource;
            }
            set
            {
                dgvRegList.DataSource = value;
                for ( int i = 0; i < dgvRegList.Rows.Count; i++ )
                {
                    if ( Convert.ToInt32( dgvRegList["RECORD_FLAG", i].Value ) == 1 )
                    {
                        dgvRegList.SetRowColor( i, Color.Red, GWI.HIS.Windows.Controls.ForeOrBack.Fore );
                    }
                }
            }
        }

        public DataTable RegDeptList
        {
            
            set
            {
                txtRegDept.SetSelectionCardDataSource( value );
            }
        }

        public DataTable RegTypeList
        {
            
            set
            {
                txtRegType.SetSelectionCardDataSource( value );
            }
        }

        public DataTable RegDoctor
        {
            
            set
            {
                txtRegDoc.SetSelectionCardDataSource( value );
            }
        }

        

        public int OperatorId
        {
            get
            {
                return Convert.ToInt32(this.currentUser.EmployeeID);
            }
           
        }

        public string OperatorName
        {
            get
            {
                return this.currentUser.Name;
            }
        }

        public bool ShowRegInfo()
        {

            HJSF.FrmChargeInfo frmChargeInfo = new HIS_MZManager.HJSF.FrmChargeInfo( patient.RegFeeInfo );
            if ( frmChargeInfo.ShowDialog() == DialogResult.OK )
            {
                patient.RegFeeInfo = frmChargeInfo.ReturnChargeInfo;
               
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ShowForm(out string PerfChar)
        {
            PerfChar = "";
            FrmInputRegInvoiceNo frmInvoice = new FrmInputRegInvoiceNo();
            if ( frmInvoice.ShowDialog( ) == DialogResult.OK )
            {
                PerfChar = frmInvoice.InputPerfChar;
                return frmInvoice.InputInvoiceNo;
            }
            else
                return "";
        }

        public void ShowCurrentRegisterInvoiceNo( string currentInvoiceNo )
        {
            if ( !showDialog )
            {
                MessageBox.Show( "当前挂号发票号：" + currentInvoiceNo + "，请确认！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
            }
        }
        #endregion

        private void txtHisCard_Leave( object sender, EventArgs e )
        {
            //try
            //{
            //    if ( txtHisCard.Text.Trim() != "" && !controller.FindPatient( txtHisCard.Text ) )
            //    {
            //        if ( MessageBox.Show( "没有找到诊疗卡对应的病人信息,是否使用该卡号做为该病人的新的就诊卡号?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
            //        {
            //            ClearInfo();
            //            txtHisCard.Focus();
            //        }
            //    }
                
            //}
            //catch ( Exception err )
            //{
            //    MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            //}
        }

        private void OnTextBoxEnter( object sender, EventArgs e )
        {
            string name = ( (Control)sender ).Name;
            if ( name == txtHisCard.Name || name == txtRegDept.Name || name == txtRegType.Name || name == txtRegDoc.Name)
                HIS.MZ_BLL.ILControl.ILControl.SetILStatus( currentUser.LoginCode, false );

            if ( name == txtPatName.Name  )
                HIS.MZ_BLL.ILControl.ILControl.SetILStatus( currentUser.LoginCode, true );
        }

        private void dgvRegList_DoubleClick( object sender , EventArgs e )
        {
            if ( dgvRegList.Rows.Count == 0 )
                return;
            if ( dgvRegList.CurrentCell == null )
                return;

            string visitNo = dgvRegList["VISITNO" , dgvRegList.CurrentCell.RowIndex].Value.ToString( );
            string recordFlag = dgvRegList["record_flag" , dgvRegList.CurrentCell.RowIndex].Value.ToString( );
            if ( recordFlag == "1" )
            {
                MessageBox.Show( "该病人已退号！","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                return;
            }
            controller.LoadPatintInfoByVisitNo( visitNo );

            if ( showDialog )
            {
                this.DialogResult = DialogResult.OK;
                this.Close( );
            }
        }

        private void txtAge_Leave( object sender , EventArgs e )
        {
            if ( txtAge.Text.Trim( ) == "" )
                txtAge.Text = "20";
        }

        private void txtAge_KeyUp( object sender , KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Up )
            {
                if ( cboAgeUnit.SelectedIndex == 0 )
                    return;
                else
                    cboAgeUnit.SelectedIndex--;
                
            }
            if ( e.KeyCode == Keys.Down )
            {
                if ( cboAgeUnit.SelectedIndex == cboAgeUnit.Items.Count - 1 )
                    return;
                else
                    cboAgeUnit.SelectedIndex++;
            }
        }

        

    }
}
