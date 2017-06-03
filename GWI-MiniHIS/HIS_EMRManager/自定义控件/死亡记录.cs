using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Word;
using System.Xml.Linq;

namespace HIS_EMRManager
{
    internal partial class 死亡记录 : EMRControl, IEMRPrint
    {
        public 死亡记录()
        {
            InitializeComponent();
        }

        public 死亡记录(XmlDocument value)
        {
            InitializeComponent();
            this.SetValue(value);
        }

        /// <summary>
        /// 打印病历
        /// </summary>
        public void Print(HIS.EMR_BLL.EmrRecord emrRecord)
        {
            XmlDocument xmlDoc = HIS.EMR_BLL.OP_EmrRecord.GetPatInfo(emrRecord.PatListId, 3, emrRecord.RecordCreateDate);

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            Word.Application wordApp = new Word.Application();
            base.InitWordApplication(wordApp, xmlDoc, Public.EMRType.死亡记录);

            int columnNo = 1;
            foreach (XmlNode node in xmlDoc.SelectSingleNode("病人信息/基本信息").ChildNodes)
            {
                if (columnNo >3)
                {
                    wordApp.Selection.TypeParagraph();
                    wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordApp.Selection.Font.Size = Public.StaticVariable.BodyTitleFontSize;
                    wordApp.Selection.Font.Bold = Public.StaticVariable.BodyTitleFontBold;
                    wordApp.Selection.Font.Name = Public.StaticVariable.BodyTitleFontName;
                    wordApp.Selection.TypeText("    " + node.Name + "：");
                    wordApp.Selection.ParagraphFormat.SpaceAfter = 3f;
                    wordApp.Selection.Font.Size = Public.StaticVariable.BodyFontSize;
                    wordApp.Selection.Font.Bold = Public.StaticVariable.BodyFontBold;
                    wordApp.Selection.Font.Name = Public.StaticVariable.BodyFontName;
                    wordApp.Selection.TypeText(node.InnerText);
                }
                columnNo++;
            }

            XElement xe = XElement.Parse(this.GetValue().InnerXml);
            var nodes = from e in xe.Descendants()
                        orderby e.Attribute("Code").Value
                        select e;
            foreach (XElement node in nodes)
            {
                if (node.Value.ToString().Trim().Length > 0)
                {
                    wordApp.Selection.TypeParagraph();
                    wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordApp.Selection.Font.Size = Public.StaticVariable.BodyTitleFontSize;
                    wordApp.Selection.Font.Bold = Public.StaticVariable.BodyTitleFontBold;
                    wordApp.Selection.Font.Name = Public.StaticVariable.BodyTitleFontName;
                    wordApp.Selection.TypeText("    " + node.Name.ToString().Trim() + "：");
                    wordApp.Selection.Font.Size = Public.StaticVariable.BodyFontSize;
                    wordApp.Selection.Font.Bold = Public.StaticVariable.BodyFontBold;
                    wordApp.Selection.Font.Name = Public.StaticVariable.BodyFontName;
                    wordApp.Selection.TypeText(node.Value.ToString().Trim());
                }
            }

            //医生签名
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.Font.Size = Public.StaticVariable.BodyFontSize;
            wordApp.Selection.Font.Bold = 0;
            wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            //wordApp.Selection.TypeText("医师签名：" + new GWMHIS.BussinessLogicLayer.Classes.Employee((long)emrRecord.RecordCreateEmp).Name + "    ");
            wordApp.Selection.TypeText("医师签名：____________________");
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.TypeText(emrRecord.RecordCreateDate.ToLongDateString() + emrRecord.RecordCreateDate.Hour + "时    ");
        } 
    }
}
