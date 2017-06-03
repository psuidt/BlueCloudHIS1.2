using System;
using System.Drawing;
using System.Drawing.Printing;
namespace HIS.MZ_BLL.Print
{
	/// <summary>
	/// 门诊发票类
	/// </summary>
	public class OPDInvoice : IInvoice
	{
        /// <summary>
        /// 构造函数
        /// </summary>
		public OPDInvoice()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            paperInfo = PrintClass.GetPaperInfo( InvoiceType.门诊发票 );
			paperSize = new PaperSize(paperInfo.PaperName,paperInfo.PaperWidth,paperInfo.PaperHeight );
		}
		private PaperSize paperSize ;
		private InvoicePaperInfo paperInfo;

		private string _hisName;
		private string _invoiceNo;
		private string _patientName;
		private string _departmentName;
		private int _year;
		private int _month;
		private int _day;
		private string _payee;
		private decimal _totalMoneynum;
		private string _totalMoneycn;
		private InvoiceItem[] _items;
		private string _doctorName;
		private string _outPatientNo;
        private string otherInfo="";
		#region IInvoice 成员
		/// <summary>
		/// 发票号
		/// </summary>
		public string InvoiceNo
		{
			get
			{
				// TODO:  添加 OPDInvoice.InvoiceNo getter 实现
				return _invoiceNo;
			}
			set
			{
				// TODO:  添加 OPDInvoice.InvoiceNo setter 实现
				_invoiceNo = value;
			}
		}

		/// <summary>
		/// 病人姓名
		/// </summary>
		public string PatientName
		{
			get
			{
				// TODO:  添加 OPDInvoice.PatientName getter 实现
				return _patientName;
			}
			set
			{
				// TODO:  添加 OPDInvoice.PatientName setter 实现
				_patientName = value;
			}
		}

		/// <summary>
		/// 病人就诊科室
		/// </summary>
		public string DepartmentName
		{
			get
			{
				// TODO:  添加 OPDInvoice.DepartmentName getter 实现
				return _departmentName;
			}
			set
			{
				// TODO:  添加 OPDInvoice.DepartmentName setter 实现
				_departmentName = value;
			}
		}
		/// <summary>
		/// 发票日期－年
		/// </summary>
		public int Year
		{
			get
			{
				// TODO:  添加 OPDInvoice.Year getter 实现
				return _year;
			}
			set
			{
				// TODO:  添加 OPDInvoice.Year setter 实现
				_year = value;
			}
		}
		/// <summary>
		/// 发票日期－月
		/// </summary>
		public int Month
		{
			get
			{
				// TODO:  添加 OPDInvoice.Month getter 实现
				return _month;
			}
			set
			{
				// TODO:  添加 OPDInvoice.Month setter 实现
				_month = value;
			}
		}
		/// <summary>
		/// 发票日期－日
		/// </summary>
		public int Day
		{
			get
			{
				// TODO:  添加 OPDInvoice.Day getter 实现
				return _day;
			}
			set
			{
				// TODO:  添加 OPDInvoice.Day setter 实现
				_day = value;
			}
		}

		/// <summary>
		/// 收款人
		/// </summary>
		public string Payee
		{
			get
			{
				// TODO:  添加 OPDInvoice.Payee getter 实现
				return _payee;
			}
			set
			{
				// TODO:  添加 OPDInvoice.Payee setter 实现
				_payee = value;
			}
		}
		/// <summary>
		/// 总金额（小写）
		/// </summary>
		public decimal TotalMoneyNum
		{
			get
			{
				// TODO:  添加 OPDInvoice.TotalMoneyNum getter 实现
				return _totalMoneynum;
			}
			set
			{
				// TODO:  添加 OPDInvoice.TotalMoneyNum setter 实现
				_totalMoneynum = value;
			}
		}
		/// <summary>
		/// 总金额（大写）
		/// </summary>
		public string TotalMoneyCN
		{
			get
			{
				// TODO:  添加 OPDInvoice.TotalMoneyCN getter 实现
				return _totalMoneycn;
			}
			set
			{
				// TODO:  添加 OPDInvoice.TotalMoneyCN setter 实现
				_totalMoneycn = value;
			}
		}
        /// <summary>
        /// 其他信息
        /// </summary>
        public string OtherInfo
        {
            get
            {
                return otherInfo;
            }
            set
            {
                otherInfo = value;
            }
        }
		#endregion
		/// <summary>
		/// 发票项目集合
		/// </summary>
		public InvoiceItem[] Items
		{
			get
			{
				return _items;
			}
			set
			{
				_items = value;
			}
		}
		/// <summary>
		/// 医院名称
		/// </summary>
		public string HisName
		{
			get
			{
				return _hisName;
			}
			set
			{
				_hisName = value;
			}
		}
		/// <summary>
		/// 医生
		/// </summary>
		public string DoctorName
		{
			get
			{
				return _doctorName;
			}
			set
			{
				_doctorName = value;
			}
		}
		/// <summary>
		/// 门诊号
		/// </summary>
		public string OutPatientNo
		{
			get
			{
				return _outPatientNo;
			}
			set
			{
				_outPatientNo = value;
			}
		}
		/// <summary>
		/// 打印发票
		/// </summary>
		public virtual void Print()
		{
			PrintDocument doc = new PrintDocument();

			PrintController pc = new StandardPrintController();
			doc.PrintController = pc;
			doc.DefaultPageSettings.PrinterSettings.PrinterName = doc.PrinterSettings.PrinterName;
			doc.DefaultPageSettings.PaperSize = doc.PrinterSettings.DefaultPageSettings.PaperSize;
			doc.PrintPage+=new PrintPageEventHandler(doc_PrintPage);
			
			doc.Print();
			
		}
		/// <summary>
		/// 预览
		/// </summary>
		public virtual void Preview()
		{
			PrintDocument doc = new PrintDocument();
			PageSettings ps = new PageSettings();
			ps.PaperSize = paperSize;
			ps.Margins = new Margins(paperInfo.Left,paperInfo.Right,paperInfo.Top,paperInfo.Bottom );
			
			doc.DefaultPageSettings = ps;
			
			System.Windows.Forms.PrintPreviewDialog dlg = new System.Windows.Forms.PrintPreviewDialog();
			doc.PrintPage+=new PrintPageEventHandler(doc_PrintPage);
			dlg.Document = doc;
			
			dlg.ShowDialog();
			doc.Dispose();
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void doc_PrintPage(object sender, PrintPageEventArgs e)
		{
			try
			{
				Font font=null;
				Brush brush = Brushes.Black;
				ItemPrintSetting setting;
				#region 打印内容
				//打印医院名称
				setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票, "医院名称" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _hisName , font , brush , setting.X , setting.Y );
                }
				//打印科室
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "科室" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _departmentName , font , brush , setting.X , setting.Y );
                }
				//打印医生
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "医生" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _doctorName , font , brush , setting.X , setting.Y );
                }
				//打印电脑发票号
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "发票号" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _invoiceNo , font , brush , setting.X , setting.Y );
                }
				//打印年月日
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "年" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _year.ToString( ) , font , brush , setting.X , setting.Y );
                }
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "月" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _month.ToString( ) , font , brush , setting.X , setting.Y );
                }
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "日" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _day.ToString( ) , font , brush , setting.X , setting.Y );
                }
				//打印病人姓名
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "姓名" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _patientName , font , brush , setting.X , setting.Y );
                }
				//打印门诊号
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "门诊号" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _outPatientNo , font , brush , setting.X , setting.Y );
                }
				//打印发票项目
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "发票项目" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    float x = setting.X;
                    float y = setting.Y;
                    for ( int i = 0 ; i < _items.Length ; i++ )
                    {
                        e.Graphics.DrawString( _items[i].ItemName + "：" + _items[i].ItemMoney.ToString( "0.0" ) + "元" , font , brush , x , y );
                        y = y + font.Height;
                    }
                }
				//打印小写金额
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "小写金额" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _totalMoneynum.ToString( "0.0" ) + "元" , font , brush , setting.X , setting.Y );
                }
				//打印大写金额
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "大写金额" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _totalMoneycn , font , brush , setting.X , setting.Y );
                }
				//打印收款人
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "收款人" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( _payee , font , brush , setting.X , setting.Y );
                }

                //其他信息
                setting = PrintClass.GetItemPrintSetting( InvoiceType.门诊发票 , "其他信息" );
                if ( setting.NeedPrint )
                {
                    font = new Font( setting.FontName , setting.FontSize );
                    e.Graphics.DrawString( otherInfo , font , brush , setting.X , setting.Y );
                }
				#endregion
				
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
