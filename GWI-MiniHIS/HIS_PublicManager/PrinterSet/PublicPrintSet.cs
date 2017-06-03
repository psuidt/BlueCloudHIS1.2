using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using HIS.SYSTEM.PubicBaseClasses;
using System.Management.Instrumentation;
using System.Management;
namespace HIS_PublicManager
{
    public class PublicPrintSet
    {
        private static string printerConfigFile = System.Windows.Forms.Application.StartupPath + "\\PublicPrinterSet.xml";
        private static string reportPath = System.Windows.Forms.Application.StartupPath + "\\report";
        public static void ShowSetDialog()
        {
            FrmReportPrinterSet frmSet = new FrmReportPrinterSet( );
            frmSet.ShowDialog( );
        }
        /// <summary>
        /// 加载本地配置文件
        /// </summary>
        public static DataTable LoadLocalConfig()
        {
            if (! File.Exists( printerConfigFile ) )
            {
                CreatePrinterSetFile( );
            }
            DataSet dsConfig = new DataSet( );
            dsConfig.ReadXml( printerConfigFile );

            string[] files = Directory.GetFiles( reportPath , "*.grf" );
            for ( int i = 0 ; i < files.Length ; i++ )
            {
                //报表不在配置文件中
                if ( dsConfig.Tables[0].Select( "FileFullName='" + files[i].Trim( ) + "'" ).Length == 0 )
                {
                    DataRow drNew = dsConfig.Tables[0].NewRow( );
                    drNew["FileFullName"] = files[i];
                    drNew["PrinterName"] = "";
                    dsConfig.Tables[0].Rows.Add( drNew );
                }
            }
            dsConfig.WriteXml( printerConfigFile );
            return dsConfig.Tables[0];
        }
        /// <summary>
        /// 创建报表打印配置文件
        /// </summary>
        private static void CreatePrinterSetFile()
        {
            DataSet dsConfig = new DataSet( );
            DataTable tbConfig = new DataTable( );
            tbConfig.Columns.Add( "FileFullName" );
            tbConfig.Columns.Add( "PrinterName" );

            //获取打印机
            List<Item> printers = LoadCurrentIntalledPrinter( );
            string defaultPrinter = "";
            if ( printers.Count > 0 )
                defaultPrinter = printers[0].Text;

            string[] files = Directory.GetFiles( reportPath ,"*.grf");
            for ( int i = 0 ; i < files.Length ; i++ )
            {
                DataRow dr = tbConfig.NewRow( );
                dr["FileFullName"] = files[i];
                dr["PrinterName"] = defaultPrinter;
                tbConfig.Rows.Add( dr );
            }
            dsConfig.Tables.Add( tbConfig );

            dsConfig.WriteXml( printerConfigFile );
        }
        /// <summary>
        /// 加载当前安装的打印机
        /// </summary>
        public static List<Item> LoadCurrentIntalledPrinter()
        {
            List<Item> lstPrinter = new List<Item>( );
            ManagementObjectSearcher query;
            ManagementObjectCollection queryCollection;
            string _classname = "SELECT * FROM Win32_Printer";

            query = new ManagementObjectSearcher( _classname );
            queryCollection = query.Get( );

            int j = 0;
            foreach ( ManagementObject mo in queryCollection )
            {
                Item item = new Item( );
                item.Text = mo["Name"].ToString( );
                item.Value = j;
                j++;
                lstPrinter.Add( item );
            }
            
            //释放对象
            queryCollection.Dispose( );
            query.Dispose( );

            return lstPrinter;
        }

        public static void SaveConfig(DataSet dsConfig)
        {
            dsConfig.WriteXml( printerConfigFile );
        }

        public static string GetPrinterNameByReport( string reportName )
        {
            DataTable tbConfig = LoadLocalConfig( );
            string reportName1 =  reportName;
            if ( reportName.IndexOf( reportPath ) == -1 )
            {
                reportName1 = reportPath + "\\" + reportName;
            }
            

            for ( int i = 0 ; i < tbConfig.Rows.Count ; i++ )
            {
                string reportName2 = tbConfig.Rows[i]["FileFullName"].ToString( ).Trim( );
                if ( reportName2.Trim( ).ToUpper( ) == reportName1.Trim( ).ToUpper( ) )
                {
                    string printerName = "";
                    if ( !Convert.IsDBNull( tbConfig.Rows[i]["PrinterName"] ) )
                    {
                        return tbConfig.Rows[i]["PrinterName"].ToString( ).Trim( );
                    }
                    else
                    {
                        throw new Exception( "该报表还未指定打印机！" );
                    }
                }
            }
            throw new Exception( "该报表还未指定打印机！" );
        }
    }
}
