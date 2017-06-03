using System;
using System.Text ;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data;
namespace HIS.MZ_BLL.Print
{
	/// <summary>
	/// 发票类型
	/// </summary>
	public enum InvoiceType
	{
        /// <summary>
        /// 
        /// </summary>
		门诊发票,
        /// <summary>
        /// 
        /// </summary>
        住院发票,
        /// <summary>
        /// 
        /// </summary>
        挂号发票
	}
	/// <summary>
	/// 发票项目
	/// </summary>
	public struct InvoiceItem
	{
		/// <summary>
		/// 发票项目名称
		/// </summary>
		public string ItemName;
		/// <summary>
		/// 发票金额
		/// </summary>
		public decimal ItemMoney;
		/// <summary>
		/// 打印设置
		/// </summary>
		public ItemPrintSetting ItemSetting;
		/// <summary>
		/// 返回名称
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return ItemName ;
		}

	}
	/// <summary>
	/// 发票打印设置
	/// </summary>
	public struct ItemPrintSetting
	{
		/// <summary>
		/// 打印项目名
		/// </summary>
		public string ItemName;
		/// <summary>
		/// 字体
		/// </summary>
		public string FontName;
		/// <summary>
		/// 字体大小
		/// </summary>
		public int FontSize;
		/// <summary>
		/// X
		/// </summary>
		public float X;
		/// <summary>
		/// Y
		/// </summary>
		public float Y;
		/// <summary>
		/// 返回名称
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return ItemName;
		}
        /// <summary>
        /// 不需要打印
        /// </summary>
        public bool NeedPrint;

	}
	/// <summary>
	/// 发票纸张信息
	/// </summary>
	public struct InvoicePaperInfo
	{
		/// <summary>
		/// 纸张名称
		/// </summary>
		public string PaperName;
		/// <summary>
		/// 纸张宽度
		/// </summary>
		public int PaperWidth;
		/// <summary>
		/// 纸张大小
		/// </summary>
		public int PaperHeight;
		/// <summary>
		/// 顶距
		/// </summary>
		public int Top;
		/// <summary>
		/// 底距
		/// </summary>
		public int Bottom;
		/// <summary>
		/// 左距
		/// </summary>
		public int Left;
		/// <summary>
		/// 右距
		/// </summary>
		public int Right;
	}
    /// <summary>
    /// 常量
    /// </summary>
	public class Const
	{
        /// <summary>
        /// 门诊发票宽
        /// </summary>
		public  const int OPDInvoideDefaultWidth = 120;
        /// <summary>
        /// 门诊发票高
        /// </summary>
		public  const int OPDInvoideDefaultHeight = 95;
	}
	/// <summary>
	/// 打印控制类。
	/// </summary>
	public class PrintClass
	{
        /// <summary>
        /// 配置文件名
        /// </summary>
        public static readonly string ConfigFileName = "InvoiceSetting.xml";
        /// <summary>
        /// 配置文件路径
        /// </summary>
        private static readonly string configFilePath = System.Windows.Forms.Application.StartupPath + "\\" + ConfigFileName;
        /// <summary>
        /// 构造函数
        /// </summary>
		public PrintClass()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
        /// <summary>
        /// 获取指定类型发票打印设置
        /// </summary>
        /// <param name="invoiceType"></param>
        /// <param name="InvoiceItemName"></param>
        /// <returns></returns>
        public static ItemPrintSetting GetItemPrintSetting( InvoiceType invoiceType , string InvoiceItemName )
        {

            DataSet dsConfig = GetInvoiceSettingConfig( );
            string invoiceTypename = "";
            switch ( invoiceType )
            {
                case InvoiceType.门诊发票:
                    invoiceTypename = "门诊收费发票";
                    break;
                case InvoiceType.挂号发票:
                    invoiceTypename = "门诊挂号发票";
                    break;
            }
            DataRow[] drItems = dsConfig.Tables["INVOICE_ITEMS"].Select( "INVOICE_NAME = '" + invoiceTypename + "' and ITEM_NAME = '" + InvoiceItemName + "'" );
            ItemPrintSetting setting = new ItemPrintSetting( );
            if ( drItems.Length == 0 )
                return setting;

            string fontName = drItems[0]["FONT_NAME"].ToString( );
            string fontSize = drItems[0]["FONT_SIZE"].ToString( );
            string x = drItems[0]["X"].ToString( );
            string y = drItems[0]["Y"].ToString( );
            string needPrint = drItems[0]["NEED_PRINT"].ToString( );

            setting.ItemName = InvoiceItemName;
            setting.FontName = fontName;
            try
            {
                if ( fontSize != "" )
                    setting.FontSize = Convert.ToInt32( fontSize );
                if ( setting.FontSize <= 8 )
                    setting.FontSize = 8;
            }
            catch
            {
                setting.FontSize = 9;
            }
            try
            {
                if ( x.Trim( ) != "" )
                    setting.X = (float)Convert.ToDecimal( x );
            }
            catch
            {
                setting.X = 0;
            }
            try
            {
                if ( x.Trim( ) != "" )
                    setting.Y = (float)Convert.ToDecimal( y );
            }
            catch
            {
                setting.Y = 0;
            }
            try
            {
                if ( needPrint == "1" )
                    setting.NeedPrint = true;
            }
            catch
            {
                setting.NeedPrint = false;
            }
            return setting;
        }
        /// <summary>
        /// 
        /// </summary>
        public static void CreatePrintConfigFile()
        {
            if ( System.IO.File.Exists( configFilePath ) )
            {
                return;
            }
            try
            {
                #region 创建发票设置结构
                System.Data.DataTable tbInvoice = new System.Data.DataTable( "INVOICES" );
                tbInvoice.Columns.Add( "INVOICE_NAME" , Type.GetType( "System.String" ) );
                tbInvoice.Columns.Add( "PAPER_WIDTH" , Type.GetType( "System.Int32" ) );
                tbInvoice.Columns.Add( "PAPER_HEIGHT" , Type.GetType( "System.Int32" ) );

                System.Data.DataTable tbInvoiceItem = new System.Data.DataTable( "INVOICE_ITEMS" );

                tbInvoiceItem.Columns.Add( "INVOICE_NAME" , Type.GetType( "System.String" ) );
                tbInvoiceItem.Columns.Add( "ITEM_NAME" , Type.GetType( "System.String" ) );
                tbInvoiceItem.Columns.Add( "FONT_NAME" , Type.GetType( "System.String" ) );
                tbInvoiceItem.Columns.Add( "FONT_SIZE" , Type.GetType( "System.Int32" ) );
                tbInvoiceItem.Columns.Add( "X" , Type.GetType( "System.Int32" ) );
                tbInvoiceItem.Columns.Add( "Y" , Type.GetType( "System.Int32" ) );
                tbInvoiceItem.Columns.Add( "NEED_PRINT" , Type.GetType( "System.Int16" ) );
                #endregion

                #region 创建默认值(收费)
                //发票名
                tbInvoice.Rows.Add( new object[]{"门诊收费发票",12.33,9.33}  );
                //发票明细
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "医院名称" , "黑体" , 10 , 50 , 55 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "姓名" , "宋体" , 9 , 90 , 115 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "门诊号" , "宋体" , 9 , 270 , 115 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "年" , "宋体" , 9 , 245 , 90 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "月" , "宋体" , 9 , 300 , 90 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "日" , "宋体" , 9 , 330 , 90 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "发票号" , "宋体" , 9 , 50 , 85 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "医生" , "宋体" , 9 , 110 , 70 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "科室" , "宋体" , 9 , 50 , 70 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "大写金额" , "宋体" , 9 , 140 , 275 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "小写金额" , "宋体" , 9 , 140 , 250 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "收款人" , "宋体" , 9 , 300 , 305 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "发票项目" , "宋体" , 9 , 90 , 150 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊收费发票" , "其他信息" , "宋体" , 9 , 0 , 0 , 0 } );
                #endregion

                #region 创建默认值(挂号)
                //发票名  
                tbInvoice.Rows.Add( new object[]{ "门诊挂号发票",12.33,9.33} );
                //内容
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "收款单位" , "宋体" , 0 , 0 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "诊病科别" , "宋体" , 0 , 0 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "医生" , "宋体" , 0 , 0 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "发票号" , "宋体" , 0 , 0 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "年" , "宋体" , 9 , 245 , 90 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "月" , "宋体" , 9 , 300 , 90 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "日" , "宋体" , 9 , 330 , 90 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "姓名" , "宋体" , 9 , 90 , 115 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "门诊号" , "宋体" , 9 , 270 , 115 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "医师职级" , "宋体" , 0 , 0 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "挂号费" , "宋体" , 0 , 0 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "诊查费" , "宋体" , 0 , 0 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "检查费" , "宋体" , 0 , 0 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "材料费" , "宋体" , 0 , 0 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "小写金额" , "宋体" , 9 , 140 , 250 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "大写金额" , "宋体" , 9 , 140 , 275 , 1 } );
                tbInvoiceItem.Rows.Add( new object[] { "门诊挂号发票" , "收款人" , "宋体" , 9 , 300 , 305 , 1 } );
                #endregion

                System.Data.DataSet dsInvocies = new System.Data.DataSet( "发票设置" );
                dsInvocies.Tables.Add( tbInvoice );
                dsInvocies.Tables.Add( tbInvoiceItem );

                dsInvocies.WriteXml( configFilePath );
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Message );
                throw new Exception( "创建发票打印配置文件错误！" );
            }
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        private static System.Data.DataSet GetInvoiceSettingConfig()
        {
            System.Data.DataSet ds = new System.Data.DataSet( );
            ds.ReadXml( configFilePath  );
            return ds;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceType"></param>
        /// <returns></returns>
        public static System.Data.DataTable GetInvoiceItemSetting(InvoiceType invoiceType)
        {
            System.Data.DataSet ds = GetInvoiceSettingConfig( );
            string invoiceName = "门诊收费发票";
            if ( invoiceType == InvoiceType.挂号发票 )
                invoiceName = "门诊挂号发票";
            DataRow[] drs = ds.Tables["INVOICE_ITEMS"].Select( "INVOICE_NAME='" + invoiceName + "'" );

            DataTable tb = ds.Tables["INVOICE_ITEMS"].Clone( );
            tb.Columns["NEED_PRINT"].DataType = Type.GetType( "System.Int16" );
            foreach ( DataRow dr in drs )
                tb.Rows.Add( dr.ItemArray );

            return tb;
            
        }
        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="invoiceType">发票类型</param>
        /// <param name="dtSetting">设置数据</param>
        /// <returns></returns>
        public static bool SaveSetting( InvoiceType invoiceType ,DataTable dtSetting)
        {
            try
            {
                System.Data.DataSet ds = GetInvoiceSettingConfig( );
                string invoiceName = "门诊收费发票";
                if ( invoiceType == InvoiceType.挂号发票 )
                    invoiceName = "门诊挂号发票";
                DataRow[] drs = ds.Tables["INVOICE_ITEMS"].Select( "INVOICE_NAME='" + invoiceName + "'" );
                foreach ( DataRow dr in drs )
                    ds.Tables["INVOICE_ITEMS"].Rows.Remove( dr );
                foreach ( DataRow dr in dtSetting.Rows )
                    ds.Tables["INVOICE_ITEMS"].Rows.Add( dr.ItemArray );

                ds.WriteXml( configFilePath );
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取纸张信息
        /// </summary>
        /// <returns></returns>
        public static InvoicePaperInfo GetPaperInfo( InvoiceType invoiceType )
        {
            InvoicePaperInfo paperInfo = new InvoicePaperInfo( );
            switch ( invoiceType )
            {
                case InvoiceType.门诊发票:
                    paperInfo.PaperName = "门诊发票";
                    paperInfo.Bottom = 0;
                    paperInfo.Left = 0;
                    paperInfo.PaperHeight = 333;
                    paperInfo.PaperWidth = 433;
                    paperInfo.Right = 0;
                    paperInfo.Top = 0;
                    break;
            }
            return paperInfo;
        }

	}
}
