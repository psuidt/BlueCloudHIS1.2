using System;
using System.Drawing;
using System.Drawing.Printing;

namespace HIS.MZ_BLL.Print
{
    /// <summary>
    /// 挂号发票类
    /// </summary>
    public class RegisterInvoice : OPDInvoice
    {
        /// <summary>
        /// 挂号级别
        /// </summary>
        private string register_type;
        /// <summary>
        /// 挂号费
        /// </summary>
        private string register_fee;
        /// <summary>
        /// 检查费
        /// </summary>
        private string jerque_fee;
        /// <summary>
        /// 诊查费
        /// </summary>
        private string examine_fee;
        /// <summary>
        /// 材料费
        /// </summary>
        private string material_fee;
        /// <summary>
        /// 挂号费
        /// </summary>
        public string RegisterFee
        {
            get
            {
                return register_fee;
            }
            set
            {
                register_fee = value;
            }
        }
        /// <summary>
        /// 检查费
        /// </summary>
        public string JerqueFee
        {
            get
            {
                return jerque_fee;
            }
            set
            {
                jerque_fee = value;
            }
        }
        /// <summary>
        /// 诊查费
        /// </summary>
        public string ExamineFee
        {
            get
            {
                return examine_fee;
            }
            set
            {
                examine_fee = value;
            }
        }
        /// <summary>
        /// 材料费
        /// </summary>
        public string  MaterialFee
        {
            get
            {
                return material_fee;
            }
            set
            {
                material_fee = value; 
            }
        }
        /// <summary>
        /// 挂号类型
        /// </summary>
        public string RegisterType
        {
            get
            {
                return register_type;
            }
            set
            {
                register_type = value;
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        public override void Print()
        {
            PrintDocument doc = new PrintDocument( );

            PrintController pc = new StandardPrintController( );
            doc.PrintController = pc;
            doc.DefaultPageSettings.PrinterSettings.PrinterName = doc.PrinterSettings.PrinterName;
            doc.DefaultPageSettings.PaperSize = doc.PrinterSettings.DefaultPageSettings.PaperSize;
            doc.PrintPage += new PrintPageEventHandler( doc_PrintPage );

            doc.Print( );
        }
        /// <summary>
        /// 预览
        /// </summary>
        public override void Preview()
        {
            PrintDocument doc = new PrintDocument( );
            //PageSettings ps = new PageSettings( );
            //ps.PaperSize = paperSize;
            //ps.Margins = new Margins( paperInfo.Left , paperInfo.Right , paperInfo.Top , paperInfo.Bottom );

            //doc.DefaultPageSettings = ps;

            System.Windows.Forms.PrintPreviewDialog dlg = new System.Windows.Forms.PrintPreviewDialog( );
            doc.PrintPage += new PrintPageEventHandler( doc_PrintPage );
            dlg.Document = doc;

            dlg.ShowDialog( );
            doc.Dispose( );
        }

        private void doc_PrintPage( object sender , PrintPageEventArgs e )
        {
            try
            {
                Font font = null;
                Brush brush = Brushes.Black;
                ItemPrintSetting setting;
                #region 打印内容
                //打印医院名称
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票, "收款单位" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.HisName , font , brush , setting.X , setting.Y );
                //打印科室
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "诊病科别" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.DepartmentName , font , brush , setting.X , setting.Y );
                //打印医生
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "医生" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.DoctorName , font , brush , setting.X , setting.Y );
                //打印电脑发票号
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "发票号" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.InvoiceNo , font , brush , setting.X , setting.Y );
                //打印年月日
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "年" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.Year.ToString( ) , font , brush , setting.X , setting.Y );
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "月" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.Month.ToString( ) , font , brush , setting.X , setting.Y );
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "日" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.Day.ToString( ) , font , brush , setting.X , setting.Y );
                //打印病人姓名
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "姓名" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.PatientName , font , brush , setting.X , setting.Y );
                //打印门诊号
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "门诊号" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.OutPatientNo , font , brush , setting.X , setting.Y );
                //打印挂号级别
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "医师职级" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( register_type , font , brush , setting.X , setting.Y );
                //打印发票项目
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "挂号费" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( register_fee , font , brush , setting.X , setting.Y );
                //打印诊查费
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "诊查费" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( examine_fee , font , brush , setting.X , setting.Y );
                //打印检查费
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "检查费" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( jerque_fee , font , brush , setting.X , setting.Y );
                //打印材料费
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "材料费" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( material_fee , font , brush , setting.X , setting.Y );

                //打印小写金额
                //setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "小写金额" );
                //font = new Font( setting.FontName , setting.FontSize );
                //e.Graphics.DrawString( base.TotalMoneyNum.ToString( "0.0" ) + "元" , font , brush , setting.X , setting.Y );
                //打印大写金额
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "大写金额" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.TotalMoneyCN , font , brush , setting.X , setting.Y );
                //打印收款人
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "收款人" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.Payee , font , brush , setting.X , setting.Y );

                //其他信息
                setting = PrintClass.GetItemPrintSetting( InvoiceType.挂号发票 , "其他信息" );
                font = new Font( setting.FontName , setting.FontSize );
                e.Graphics.DrawString( base.OtherInfo , font , brush , setting.X , setting.Y );
                #endregion

            }
            catch ( Exception ex )
            {
                ErrorWriter.WriteLog( ex.Message );
                throw new Exception("打印发生错误！");
            }
        }


    }
}
