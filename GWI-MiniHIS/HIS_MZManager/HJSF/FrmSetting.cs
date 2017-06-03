using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZManager.HJSF
{
    public partial class FrmSetting : GWI.HIS.Windows.Controls.BaseForm
    {
        private GWMHIS.BussinessLogicLayer.Classes.User currentUser;

        private string settingFile = System.Windows.Forms.Application.StartupPath + "\\UserCustomSetting.ini";

        private const string ROW_HEIGHT = "PRES_GRID_HEIGHT";
        private const string GRID_FONT = "GRID_FONT";
        private const string CARD_TYPE = "SHOW_CARD_TYPE";
        private const string GRID_BACK_COLOR = "GRID_BACK_COLOR";
        private const string GRID_FILTER_TYPE = "GRID_FILTER_TYPE";
        private string lpKey;

        public FrmSetting( FormType formType, GWMHIS.BussinessLogicLayer.Classes.User CurrentUser )
        {
            InitializeComponent( );
           

            currentUser = CurrentUser;
            
        }

        private void btnInvoiceSetting_Click( object sender , EventArgs e )
        {
            //HIS_MZManager.Print.FrmInvoiceSetting fSet = new HIS_MZManager.Print.FrmInvoiceSetting( HIS.MZ_BLL.Print.InvoiceType.门诊发票 );
            //fSet.ShowDialog( );
        }

        private void btnInputLanguage_Click( object sender , EventArgs e )
        {
            HIS_MZManager.ILControl.ILSelectDialog ilSelectDlg = new HIS_MZManager.ILControl.ILSelectDialog( currentUser.Name,currentUser.LoginCode );
            ilSelectDlg.ShowDialog( );
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void FrmSetting_Load( object sender, EventArgs e )
        {
            lpKey = "N" + currentUser.LoginCode;
            foreach ( object obj in Enum.GetValues( typeof( GWI.HIS.Windows.Controls.SelectionCardTypes ) ) )
                cboCardType.Items.Add( obj.ToString( ) );
            
            string rowHeight = HIS.SYSTEM.PubicBaseClasses.ApiFunction.GetIniString( ROW_HEIGHT, lpKey, settingFile );
            GetCombBoxSelectedIndex( rowHeight, cboRowHeight );
            string gridFont = HIS.SYSTEM.PubicBaseClasses.ApiFunction.GetIniString( GRID_FONT, lpKey, settingFile );
            GetCombBoxSelectedIndex( gridFont, cboFontSize );
            
            string bkColor = HIS.SYSTEM.PubicBaseClasses.ApiFunction.GetIniString( GRID_BACK_COLOR, lpKey, settingFile );
            this.plBackColor.BackColor = HIS.MZ_BLL.UserCustomSetting.GetPrescriptionGridBackgroundColor( currentUser.LoginCode );

            string filterType = HIS.SYSTEM.PubicBaseClasses.ApiFunction.GetIniString( GRID_FILTER_TYPE , lpKey , settingFile );
            if ( filterType == "" )
                filterType = "0";
            cboFilterType.SelectedIndex = Convert.ToInt32( filterType );

            string showcardType = HIS.SYSTEM.PubicBaseClasses.ApiFunction.GetIniString( CARD_TYPE , lpKey , settingFile );
            if ( showcardType == "" )
            {
                cboCardType.SelectedIndex = 0;
            }
            else
            {
                GetCombBoxSelectedIndex( showcardType , cboCardType );
            }

            cboRowHeight.SelectedIndexChanged += new EventHandler( cboRowHeight_SelectedIndexChanged );
            cboFontSize.SelectedIndexChanged += new EventHandler( cboFontSize_SelectedIndexChanged );
            cboFilterType.SelectedIndexChanged += new EventHandler( cboFilterType_SelectedIndexChanged );
            cboCardType.SelectedIndexChanged += new EventHandler( cboCardType_SelectedIndexChanged );
        }

        void cboCardType_SelectedIndexChanged( object sender , EventArgs e )
        {
            HIS.SYSTEM.PubicBaseClasses.ApiFunction.WriteIniString( CARD_TYPE , lpKey , cboCardType.Text , settingFile );
        }

        void cboFilterType_SelectedIndexChanged( object sender , EventArgs e )
        {
            HIS.SYSTEM.PubicBaseClasses.ApiFunction.WriteIniString( GRID_FILTER_TYPE , lpKey , cboFilterType.SelectedIndex.ToString() , settingFile );
        }

        void cboFontSize_SelectedIndexChanged( object sender, EventArgs e )
        {
            HIS.SYSTEM.PubicBaseClasses.ApiFunction.WriteIniString( GRID_FONT, lpKey, cboFontSize.Text, settingFile );
        }

        void cboRowHeight_SelectedIndexChanged( object sender, EventArgs e )
        {
            HIS.SYSTEM.PubicBaseClasses.ApiFunction.WriteIniString( ROW_HEIGHT, lpKey, cboRowHeight.Text, settingFile );
        }

        private void GetCombBoxSelectedIndex(string strValue,ComboBox cbo)
        {
            for ( int i = 0; i < cbo.Items.Count; i++ )
            {
                if ( cbo.Items[i].ToString().Trim().ToUpper() == strValue.Trim().ToUpper() )
                {
                    cbo.SelectedIndex = i;
                    return;
                }
            }
            if ( cbo.Items.Count > 0 )
                cbo.SelectedIndex = 0;
        }

        private void btnSelectColor_Click( object sender, EventArgs e )
        {
            if ( colorDlg.ShowDialog() == DialogResult.OK )
            {
                plBackColor.BackColor = colorDlg.Color;
                
                HIS.SYSTEM.PubicBaseClasses.ApiFunction.WriteIniString( GRID_BACK_COLOR, lpKey, colorDlg.Color.ToArgb().ToString() , settingFile );
            }
        }

        private void btnReportPrintSet_Click( object sender , EventArgs e )
        {
            btnReportPrintSet.Enabled = false;
            HIS_PublicManager.PublicPrintSet.ShowSetDialog( );
            //MessageBox.Show( "该功能还未开放！" );
            btnReportPrintSet.Enabled = true;
        }
    }
}
