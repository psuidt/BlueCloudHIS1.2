using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using HIS.SYSTEM.PubicBaseClasses;
namespace HIS.MZ_BLL.ILControl
{
    /// <summary>
    /// 输入法控制器
    /// </summary>
    public class ILControl
    {
        /// <summary>
        /// 设置输入法状态
        /// </summary>
        /// <param name="userCode">用户代码</param>
        /// <param name="OnOff">true打开中文输入法，false关闭中文输入法</param>
        public static void SetILStatus( string userCode, bool OnOff )
        {
            InputLanguageCollection ilc = InputLanguage.InstalledInputLanguages;

            string cnIL = ApiFunction.GetIniString( "INPUTLANGUAGE_CN", "N" + userCode, Constant.ApplicationDirectory + "//UserCustomSetting.ini" );
            string enIL = ApiFunction.GetIniString( "INPUTLANGUAGE_EN", "N" + userCode, Constant.ApplicationDirectory + "//UserCustomSetting.ini" );
            string needSetIL = "";
            if ( OnOff == true )
                needSetIL = cnIL;
            else
                needSetIL = enIL;

            for ( int i = 0 ; i < InputLanguage.InstalledInputLanguages.Count ; i++ )
            {
                InputLanguage il = InputLanguage.InstalledInputLanguages[i];
                if ( il.LayoutName == needSetIL )
                {
                    InputLanguage.CurrentInputLanguage = il;
                    return;
                }
            }
        }
    }
}
