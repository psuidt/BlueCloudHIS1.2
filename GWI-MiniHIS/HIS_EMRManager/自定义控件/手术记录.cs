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
using Word;

namespace HIS_EMRManager
{
    internal partial class 手术记录 : EMRControl, IEMRPrint
    {
        public 手术记录()
        {
            InitializeComponent();
        }

        public 手术记录(XmlDocument value)
        {
            InitializeComponent();
            this.SetValue(value);
        }

        /// <summary>
        /// 打印病历
        /// </summary>
        public void Print(HIS.EMR_BLL.EmrRecord emrRecord)
        {
            XmlDocument xmlDoc = new HIS.EMR_BLL.OperaEmrRecord().GetPatInfo(emrRecord.PatListId,emrRecord.RecordCreateDate);

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            Word.Application wordApp = new Word.Application();
            base.InitWordApplication(wordApp, xmlDoc, Public.EMRType.手术记录);

            int columnNum = xmlDoc.SelectSingleNode("病人信息/基本信息").ChildNodes.Count;
            Word.Table table = wordApp.ActiveDocument.Tables.Add(wordApp.Selection.Range, columnNum, 1, ref oMissing, ref oMissing);
            wordApp.Selection.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleNone;
            wordApp.Selection.Borders.InsideLineStyle = WdLineStyle.wdLineStyleNone;
            int columnNo = 1;
            object step = 1;
            object unit = Word.WdUnits.wdCharacter;
            object extend = Word.WdMovementType.wdExtend;
            foreach (XmlNode node in xmlDoc.SelectSingleNode("病人信息/基本信息").ChildNodes)
            {
                wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                wordApp.Selection.Font.Size = Public.StaticVariable.BodyTitleFontSize;
                wordApp.Selection.Font.Bold = Public.StaticVariable.BodyTitleFontBold;
                wordApp.Selection.Font.Name = Public.StaticVariable.BodyTitleFontName;
                wordApp.Selection.TypeText("    " + node.InnerText.Split('：')[0] + "：");
                wordApp.Selection.Font.Size = Public.StaticVariable.BodyFontSize;
                wordApp.Selection.Font.Bold = Public.StaticVariable.BodyFontBold;
                wordApp.Selection.Font.Name = Public.StaticVariable.BodyFontName;
                wordApp.Selection.TypeText(node.InnerText.Split('：')[1]);
                columnNo++;
                //if (columnNo <= columnNum)
                //{
                //    wordApp.Selection.Move(ref unit, ref step);
                //}
                //else
                //{
                unit = Word.WdUnits.wdLine;
                    wordApp.Selection.MoveDown(ref unit, ref step, ref oMissing);
                //    break;
                //}
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
            wordApp.Selection.TypeText("手术医师：____________________");
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.TypeText("主治医师：____________________");
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.TypeText("科主任或副主任医师：__________");
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.TypeText("      记录时间："+emrRecord.RecordCreateDate.Year+"."+emrRecord.RecordCreateDate.Month+"."+emrRecord.RecordCreateDate.Day+ "."+emrRecord.RecordCreateDate.Hour+ ":"+emrRecord.RecordCreateDate.Minute);
        } 
    }
}
