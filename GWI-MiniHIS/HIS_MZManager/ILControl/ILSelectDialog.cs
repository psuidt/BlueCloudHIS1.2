using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_MZManager.ILControl
{
    public partial class ILSelectDialog : GWI.HIS.Windows.Controls.BaseForm
    {

        private string loginCode;

        public ILSelectDialog( string UserName,string UserCode )
        {
            InitializeComponent( );

            loginCode = UserCode;

            lblName.Text = UserName;
        }

        private void ILSelectDialog_Load( object sender , EventArgs e )
        {
            LoadInstalledLanguage( );

            ShowCurrentUserIL( );
        }

        /// <summary>
        /// 加载本机安装的输入法
        /// </summary>
        private void LoadInstalledLanguage()
        {
            InputLanguageCollection ilc = InputLanguage.InstalledInputLanguages;
            for ( int i = 0 ; i < InputLanguage.InstalledInputLanguages.Count ; i++ )
            {
                InputLanguage il = InputLanguage.InstalledInputLanguages[i];
                cboChineseIL.Items.Add( il.LayoutName );
                cboEnglishIL.Items.Add( il.LayoutName );
            }
        }
        /// <summary>
        /// 显示当前用户设置的输入法
        /// </summary>
        private void ShowCurrentUserIL()
        {
            //中文
            string customInputLanguage = ApiFunction.GetIniString( "INPUTLANGUAGE_CN" , "N" + loginCode , Constant.ApplicationDirectory + "//UserCustomSetting.ini" );
            if ( customInputLanguage == "" || customInputLanguage == null )
            {
                cboChineseIL.SelectedIndex = -1;
            }
            for ( int i = 0 ; i < cboChineseIL.Items.Count ; i++ )
            {
                if ( cboChineseIL.Items[i].ToString( ) == customInputLanguage )
                {
                    cboChineseIL.SelectedIndex = i;
                    break;
                }
            }
            //英文
            customInputLanguage = HIS.SYSTEM.PubicBaseClasses.ApiFunction.GetIniString( "INPUTLANGUAGE_EN", "N" + loginCode, Constant.ApplicationDirectory + "//UserCustomSetting.ini" );
            if ( customInputLanguage == "" || customInputLanguage == null )
            {
                cboEnglishIL.SelectedIndex = -1;
            }
            for ( int i = 0 ; i < cboEnglishIL.Items.Count ; i++ )
            {
                if ( cboEnglishIL.Items[i].ToString( ) == customInputLanguage )
                {
                    cboEnglishIL.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnSave_Click( object sender , EventArgs e )
        {
            //中文
            ApiFunction.WriteIniString( "INPUTLANGUAGE_CN", "N" + loginCode, cboChineseIL.Text, Constant.ApplicationDirectory + "//UserCustomSetting.ini" );
            //英文
            ApiFunction.WriteIniString( "INPUTLANGUAGE_EN", "N" + loginCode, cboEnglishIL.Text, Constant.ApplicationDirectory + "//UserCustomSetting.ini" );

            this.Close( );
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
    }
}