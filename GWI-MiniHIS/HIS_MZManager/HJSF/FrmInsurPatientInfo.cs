using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_MZManager.HJSF
{
    public partial class FrmInsurPatientInfo : GWI.HIS.Windows.Controls.BaseForm
    {
        public HIS.MZ_BLL.InsurPatientInfo ReturnInsurPatientInfo;

        public FrmInsurPatientInfo()
        {
            InitializeComponent( );

        }

        //public FrmInsurPatientInfo( HIS.MZ_BLL.InsurPatientInfo insurPatientInfo )
        //{
        //    InitializeComponent( );

        //    lblAge.Text= insurPatientInfo.Age.ToString();
        //    lblArea.Text = insurPatientInfo.Area_Id;
        //    lblBornDay.Text = insurPatientInfo.BirthDate.ToString( "yyyy-MM-dd" );
        //    lblFamilyCode.Text = insurPatientInfo.Family_Code;
        //    lblIDCard.Text = insurPatientInfo.IdCard;
        //    lblMedCardID.Text = insurPatientInfo.Medcard_Id;
        //    lblName.Text = insurPatientInfo.Name;
        //    lblPersonCode.Text = insurPatientInfo.Person_Code;
        //    if ( insurPatientInfo.Sex == "1" )
        //        lblSex.Text = "男";
        //    else if ( insurPatientInfo.Sex == "2" )
        //        lblSex.Text = "女";
        //    else
        //        lblSex.Text = "未指定";
        //}

        private void FrmInsurPatientInfo_Load( object sender , EventArgs e )
        {
            btnOk.Enabled = false;
            txtCardNo.Focus();
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close( );
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( lvwPatInfo.SelectedItems.Count == 0 )
                return;

            ReturnInsurPatientInfo = (HIS.MZ_BLL.InsurPatientInfo)lvwPatInfo.SelectedItems[0].Tag;
            //ReturnInsurPatientInfo.Medorg_Code = insurinfos.Medorg_Code;
            //ReturnInsurPatientInfo.Medorg_Level = insurinfos.Medorg_Level;
            //ReturnInsurPatientInfo = insurinfos;

            this.DialogResult = DialogResult.OK;
            this.Close( );
        }
         
        private void btnReadCard_Click( object sender , EventArgs e )
        {

            if ( txtCardNo.Text.Trim( ) == "" && txtIdCard.Text.Trim() == "" )
            {
                MessageBox.Show( "医疗卡号或者身份证号必须填写一项！","",MessageBoxButtons.OK,MessageBoxIcon.Information );
                return;
            }
            HIS.MZ_BLL.InsurPatientInfo[] insurinfos = null;
            Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
            try
            {
                insurinfos = HIS.MZ_BLL.InsurInterface.InsurInterfaceFactory.CreateInsurInstance( HIS.MZ_BLL.InsurType.新农合 ).GetPatientInfo( new string[] { txtCardNo.Text.Trim(),txtIdCard.Text.Trim() } );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            lvwPatInfo.Items.Clear();
            for ( int i = 0; i < insurinfos.Length; i++ )
            {
                ListViewItem item = new ListViewItem();
                item.Text = insurinfos[i].Area_Id;//地区编码
                item.SubItems.Add( insurinfos[i].Name );//姓名
                item.SubItems.Add( insurinfos[i].Sex );//性别
                item.SubItems.Add( insurinfos[i].Age.ToString() );//年龄
                item.SubItems.Add( insurinfos[i].BirthDate.ToString("yyyy-MM-dd") );//出生日期
                item.SubItems.Add( insurinfos[i].IdCard );//身份证号
                item.SubItems.Add( insurinfos[i].Person_Code );//个人编码
                item.SubItems.Add( insurinfos[i].Medcard_Id );//医疗证号
                item.SubItems.Add( insurinfos[i].Family_Code );//家庭编码
                item.Tag = insurinfos[i];

                lvwPatInfo.Items.Add( item );
            }
            
                      

            btnOk.Enabled = true;
        }

        private void txtCardNo_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                btnReadCard_Click( null , null );
            }
        }

       
    }
}
