using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using grproLib;
using HIS.ZY_BLL.ObjectModel.CostManager;
using HIS.ZY_BLL.ObjectModel.BaseData;
using HIS.ZY_BLL.ObjectModel.AccountManager;
using HIS.ZY_BLL.DataModel;

namespace HIS_ZYManager
{
    public class PrintController
    {
        private static string chargeInvoiceTemplatePath = System.Windows.Forms.Application.StartupPath + "\\report\\住院发票模板_GD.grf";
        private static string chargeInvoiceTemplatePath1 = System.Windows.Forms.Application.StartupPath + "\\report\\住院发票模板_HN.grf";
        private static string accountbookTemplatePath = System.Windows.Forms.Application.StartupPath + "\\report\\住院预交金交款模板.grf";
        private static string accountbookTemplatePath1 = System.Windows.Forms.Application.StartupPath + "\\report\\住院结算交款模板.grf";

        /// <summary>
        /// 创建住院收费发票打印模板
        /// </summary>
        public static void CreateChargeInvoiceTemplate_GD()
        {
            try
            {
                GridppReport reportPrinter = new GridppReport();

                if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\report"))
                {
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\report");
                }

                if (File.Exists(chargeInvoiceTemplatePath))
                {
                    File.Delete(chargeInvoiceTemplatePath);
                }

                if (!File.Exists(chargeInvoiceTemplatePath))
                {
                    reportPrinter.InsertReportHeader();

                    DataTable dt = BaseDataFactory.GetData(baseDataType.住院发票项目);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        reportPrinter.AddParameter(dt.Rows[i]["name"].ToString(), GRParameterDataType.grptString);
                    }

                    System.Reflection.PropertyInfo[] propertyinfos = typeof(Invoice_GD).GetProperties();
                    for (int i = 0; i < propertyinfos.Length; i++)
                    {
                        if (propertyinfos[i].PropertyType == typeof(String))
                            reportPrinter.AddParameter(propertyinfos[i].Name, GRParameterDataType.grptString);
                    }
                    reportPrinter.SaveToFile(chargeInvoiceTemplatePath);
                }
            }
            catch
            {
                MessageBox.Show("创建住院发票模板发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// 创建住院收费发票打印模板
        /// </summary>
        public static void CreateChargeInvoiceTemplate_HN()
        {
            try
            {
                GridppReport reportPrinter = new GridppReport();


                if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\report"))
                {
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\report");
                }

                if (File.Exists(chargeInvoiceTemplatePath1))
                {
                    File.Delete(chargeInvoiceTemplatePath1);
                }

                if (!File.Exists(chargeInvoiceTemplatePath1))
                {
                    reportPrinter.InsertReportHeader();

                    DataTable dt = BaseDataFactory.GetData(baseDataType.住院发票项目);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        reportPrinter.AddParameter(dt.Rows[i]["name"].ToString(), GRParameterDataType.grptString);
                    }

                    System.Reflection.PropertyInfo[] propertyinfos = typeof(Invoice_HN).GetProperties();
                    for (int i = 0; i < propertyinfos.Length; i++)
                    {
                        if (propertyinfos[i].PropertyType == typeof(String))
                            reportPrinter.AddParameter(propertyinfos[i].Name, GRParameterDataType.grptString);
                    }
                    reportPrinter.SaveToFile(chargeInvoiceTemplatePath1);
                }
            }
            catch
            {
                MessageBox.Show("创建住院发票模板发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// 创建住院预交金个人交款表模板
        /// </summary>
        public static void CreateChargeAccountBookTemplate()
        {
            try
            {
                GridppReport reportPrinter = new GridppReport();

                if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\report"))
                {
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\report");
                }

                if (File.Exists(accountbookTemplatePath))
                {
                    File.Delete(accountbookTemplatePath);
                }

                if (!File.Exists(accountbookTemplatePath))
                {
                    reportPrinter.InsertReportHeader();
                    reportPrinter.InsertDetailGrid();
                    reportPrinter.InsertReportFooter();


                    System.Reflection.PropertyInfo[] propertyinfos = typeof(AbstractChargeAccountRpt).GetProperties();
                    for (int i = 0; i < propertyinfos.Length; i++)
                    {
                        if (propertyinfos[i].PropertyType == typeof(String))
                            reportPrinter.AddParameter(propertyinfos[i].Name, GRParameterDataType.grptString);
                    }

                    System.Reflection.PropertyInfo[] propertyinfos1 = typeof(ZY_ChargeList).GetProperties();
                    for (int i = 0; i < propertyinfos1.Length; i++)
                    {
                        reportPrinter.DetailGrid.Recordset.AddField(propertyinfos1[i].Name, GRFieldType.grftString);
                    }

                    reportPrinter.SaveToFile(accountbookTemplatePath);
                }
            }
            catch
            {
                MessageBox.Show("创建住院个人预交金交款表模板发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        /// <summary>
        /// 创建住院结算个人交款表模板
        /// </summary>
        public static void CreateCostAccountBookTemplate()
        {
            try
            {
                GridppReport reportPrinter = new GridppReport();

                if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\report"))
                {
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\report");
                }

                if (File.Exists(accountbookTemplatePath1))
                {
                    File.Delete(accountbookTemplatePath1);
                }

                if (!File.Exists(accountbookTemplatePath1))
                {
                    reportPrinter.InsertReportHeader();

                    DataTable dt = BaseDataFactory.GetData(baseDataType.住院发票项目);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        reportPrinter.AddParameter(dt.Rows[i]["name"].ToString(), GRParameterDataType.grptString);
                    }

                    System.Reflection.PropertyInfo[] propertyinfos = typeof(AbstractCostAccountRpt).GetProperties();
                    for (int i = 0; i < propertyinfos.Length; i++)
                    {
                        if (propertyinfos[i].PropertyType == typeof(String))
                            reportPrinter.AddParameter(propertyinfos[i].Name, GRParameterDataType.grptString);
                    }

                    DataTable dt1 = BaseDataFactory.GetData(baseDataType.病人类型);
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        reportPrinter.AddParameter(dt1.Rows[i]["name"] + "_记账_张数", GRParameterDataType.grptString);
                        reportPrinter.AddParameter(dt1.Rows[i]["name"] + "_记账", GRParameterDataType.grptString);
                    }
                    reportPrinter.AddParameter("单位_记账_张数", GRParameterDataType.grptString);
                    reportPrinter.AddParameter("单位_记账", GRParameterDataType.grptString);
                    reportPrinter.AddParameter("合计_记账_张数", GRParameterDataType.grptString);
                    reportPrinter.AddParameter("合计_记账", GRParameterDataType.grptString);

                    reportPrinter.SaveToFile(accountbookTemplatePath1);
                }
            }
            catch
            {
                MessageBox.Show("创建住院个人结算交款表模板发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
