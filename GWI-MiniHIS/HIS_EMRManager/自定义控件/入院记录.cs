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
    /// 入院记录控件
    /// </summary>
    internal partial class 入院记录 : EMRControl, IEMRPrint
    {
        public 入院记录()
        {
            InitializeComponent();
        }

        public 入院记录(XmlDocument value)
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

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            Word.Application wordApp = new Word.Application();
            base.InitWordApplication(wordApp, xmlDoc, Public.EMRType.入院记录);

            //插入标题 
            //wordApp.Selection.TypeParagraph();
            //wordApp.Selection.Font.Size = 14;
            //wordApp.Selection.Font.Bold = 2;
            //wordApp.Selection.TypeText("入  院  记  录");

            wordApp.Selection.TypeParagraph();
            wordApp.ActiveDocument.Tables.Add(wordApp.Selection.Range, 6, 2, ref oMissing, ref oMissing);
            wordApp.Selection.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleNone;
            wordApp.Selection.Borders.InsideLineStyle = WdLineStyle.wdLineStyleNone;
            wordApp.Selection.Cells.Height = 22;
            int rowNo = 1;
            int columnNo = 1;
            object step = 1;
            object unit = Word.WdUnits.wdCharacter;
            object extend = Word.WdMovementType.wdExtend;
            foreach (XmlNode node in xmlDoc.SelectSingleNode("病人信息/就诊信息").ChildNodes)
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
                if (columnNo > 2)
                {
                    columnNo = 1;
                    rowNo++;
                }
                if (rowNo > 6)
                {
                    unit = Word.WdUnits.wdLine;
                    wordApp.Selection.MoveDown(ref unit, ref step, ref oMissing);
                    break;
                }
                if (columnNo == 1)
                {
                    unit = Word.WdUnits.wdCell;
                    wordApp.Selection.MoveRight(ref unit, ref step, ref oMissing);
                }
                else
                {
                    wordApp.Selection.Move(ref unit, ref step);
                }
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
                    if (node.Name.ToString().Trim() == "个人史")
                    { 
                        wordApp.Selection.TypeText("    " + "个人史、月经史、婚育史" + "：");
                    }
                    else
                    {
                        wordApp.Selection.TypeText("    " + node.Name.ToString().Trim() + "：");
                    }
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
            wordApp.Selection.TypeText("住院医师：________________________");
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.TypeText("主治医师：________________________");
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.TypeText("科主任或副主任医师：______________");
        }
    }
}
