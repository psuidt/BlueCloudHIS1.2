using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HIS_DJSFManager.Forms;
using System.IO;
using System.Data;

namespace HIS_DJSFManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );
            try
            {
                //本地数据库不存在
                if (!HIS.LocalDb.DBManager.LocalDbFileExists())
                {
                    //创建
                    HIS.LocalDb.DBManager.CreateLocalDbFile();
                    //下载
                    HIS.DownUpLoadData.DownloadController downloader = new HIS.DownUpLoadData.DownloadController(0);
                    downloader.DownLoadBaseUserData();
                }


                Application.Run(new FrmMain());
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        
    }
}
