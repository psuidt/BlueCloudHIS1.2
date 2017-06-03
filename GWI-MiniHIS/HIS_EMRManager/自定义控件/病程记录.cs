using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;
using Word;

namespace HIS_EMRManager
{
    /// <summary>
    /// 病程记录控件
    /// </summary>
    internal partial class 病程记录 : EMRControl,IEMRPrint
    {
        public 病程记录()
        {
            InitializeComponent();
        }

        public 病程记录(XmlDocument value)
        {
            InitializeComponent();
            this.SetValue(value);
        }

        /// <summary>
        /// 打印病历
        /// </summary>
        public void Print(HIS.EMR_BLL.EmrRecord emrRecord)
        {
            XmlDocument xmlDoc = HIS.EMR_BLL.OP_EmrRecord.GetPatInfo(emrRecord.PatListId, 1, emrRecord.RecordCreateDate);

            Word.Application wordApp = new Word.Application();
            base.InitWordApplication(wordApp, xmlDoc, Public.EMRType.病程记录);

            DataTable tmpTable = HIS.EMR_BLL.OP_EmrRecord.GetDiseaseCourseRecord(emrRecord.PatId, emrRecord.PatListId, Public.PublicStaticFunction.GetEMRTypeCode(Public.EMRType.病程记录));
            for (int index = 0; index < tmpTable.Rows.Count; index++)
            {
                HIS.EMR_BLL.EmrRecord record = new HIS.EMR_BLL.EmrRecord();
                record = (HIS.EMR_BLL.EmrRecord)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(tmpTable, index, record);

                //病程记录时间
                wordApp.Selection.TypeParagraph();
                wordApp.Selection.Font.Size = Public.StaticVariable.BodyFontSize;
                wordApp.Selection.Font.Bold = 1;
                wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                if (index == 0)
                {
                    wordApp.Selection.TypeText(record.RecordCreateDate.ToLongDateString() + " " + record.RecordCreateDate.ToLongTimeString()+"：首次病程记录");
                }
                else
                {
                    wordApp.Selection.TypeText(record.RecordCreateDate.ToLongDateString() + " " + record.RecordCreateDate.ToLongTimeString());
                }

                XElement xe = XElement.Parse(record.RecordContentXml.InnerXml.ToString());
                var nodes = from e in xe.Descendants()
                            orderby e.Attribute("Code").Value
                            select e;
            
                int num=-1;
                foreach (XElement node in nodes)
                {
                    num++;
                    if (node.Value.ToString().Trim().Length <= 0)
                    {
                        continue;
                    }
                    switch (num)
                    {
                        case 0:
                            WriteBodyTitle(wordApp, "一、" + node.Name.ToString().Trim() + "：",2);
                            WriteBody(wordApp, "" + node.Value.ToString().Trim(),4);
                            WriteBodyTitle(wordApp, "" + "二、拟诊讨论" + "：",2);
                            break;
                        case 1:
                            WriteBodyTitle(wordApp, "1、" + node.Name.ToString().Trim() + "：",4);
                            WriteBody(wordApp, "" + node.Value.ToString().Trim(),6);
                            break;
                        case 2:
                            WriteBodyTitle(wordApp, "2、" + node.Name.ToString().Trim() + "：", 4);
                            WriteBody(wordApp, "" + node.Value.ToString().Trim(), 6);
                            break;
                        case 3:
                            WriteBodyTitle(wordApp, "3、" + node.Name.ToString().Trim() + "：", 4);
                            WriteBody(wordApp, "" + node.Value.ToString().Trim(), 6);
                            break;
                        case 4:
                            WriteBodyTitle(wordApp, "三、" + node.Name.ToString().Trim() + "：",2);
                            WriteBody(wordApp, "" + node.Value.ToString().Trim(), 4);
                            break;
                        case 5:
                            WriteBodyTitle(wordApp, "四、" + node.Name.ToString().Trim() + "：",2);
                            WriteBody(wordApp, "" + node.Value.ToString().Trim(), 4);
                            break;
                    }
                }
                wordApp.Selection.TypeParagraph();

                //医生签名
                wordApp.Selection.Font.Size = textFontSize;
                wordApp.Selection.Font.Bold = 0;
                wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                //wordApp.Selection.TypeText("医师签名：" + new GWMHIS.BussinessLogicLayer.Classes.Employee((long)record.RecordCreateEmp).Name);
                wordApp.Selection.TypeText("住院医师：____________________");
                //wordApp.Selection.TypeParagraph();
                //wordApp.Selection.TypeText(emrRecord.RecordCreateDate.ToLongDateString() + "    ");
                wordApp.Selection.TypeParagraph();
            }               
        }
        
    }
}
