using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 用户自定义设置类
    /// </summary>
    public class UserCustomSetting
    {
        private static string ROW_HEIGHT = "PRES_GRID_HEIGHT";
        private static string GRID_FONT = "GRID_FONT";
        private static string CARD_TYPE = "SHOW_CARD_TYPE";
        private const string GRID_BACK_COLOR = "GRID_BACK_COLOR";
        private const string GRID_FILTER_TYPE = "GRID_FILTER_TYPE";
        private static string settingFile = System.Windows.Forms.Application.StartupPath +"\\UserCustomSetting.ini";
        /// <summary>
        /// 获取自定的处方网格行高
        /// </summary>
        /// <param name="userCode">当前用户名</param>
        /// <returns></returns>
        public static string GetPrescriptionGridRowHeight(string userCode)
        {
            return HIS.SYSTEM.PubicBaseClasses.ApiFunction.GetIniString( ROW_HEIGHT, "N" + userCode, settingFile );
        }
        /// <summary>
        /// 获取自定仪的处方网格的选项卡类型
        /// </summary>
        /// <param name="userCode">当前用户名</param>
        /// <returns></returns>
        public static string GetPrescriptionShowCardType( string userCode )
        {
            return HIS.SYSTEM.PubicBaseClasses.ApiFunction.GetIniString( CARD_TYPE, "N" + userCode, settingFile );
        }
        /// <summary>
        /// 获取处方网格字体大小
        /// </summary>
        /// <param name="userCode">当前用户名</param>
        /// <returns></returns>
        public static string GetPrescriptionGridFontSize( string userCode )
        {
            return HIS.SYSTEM.PubicBaseClasses.ApiFunction.GetIniString( GRID_FONT, "N" + userCode, settingFile );
        }
        public static string GetFilterType( string userCode )
        {
            return HIS.SYSTEM.PubicBaseClasses.ApiFunction.GetIniString( GRID_FILTER_TYPE , "N" + userCode , settingFile );
        }
        /// <summary>
        /// 获取自定义的处方网格背景色
        /// </summary>
        /// <param name="userCode">当前用户名</param>
        /// <returns></returns>
        public static System.Drawing.Color GetPrescriptionGridBackgroundColor( string userCode )
        {
            string colorArgb = HIS.SYSTEM.PubicBaseClasses.ApiFunction.GetIniString( GRID_BACK_COLOR, "N" + userCode, settingFile );
            if ( colorArgb.Trim() == "" )
                return System.Drawing.Color.White;
            try
            {
                return System.Drawing.Color.FromArgb( Convert.ToInt32( colorArgb ) );
            }
            catch
            {
                return System.Drawing.Color.White;
            }
        }


    }
}
