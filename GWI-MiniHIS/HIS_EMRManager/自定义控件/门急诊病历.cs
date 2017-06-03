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
    /// 门急诊病历控件
    /// </summary>
    internal partial class 门急诊病历 : EMRControl, IEMRPrint
    {
        public 门急诊病历()
        {
            InitializeComponent();
        }

        public 门急诊病历(XmlDocument value)
        {
            InitializeComponent();
            this.SetValue(value);
        }

        /// <summary>
        /// 打印病历
        /// </summary>
        public void Print(HIS.EMR_BLL.EmrRecord emrRecord)
        {
            XmlDocument xmlDoc = HIS.EMR_BLL.OP_EmrRecord.GetPatInfo(emrRecord.PatListId, 0, emrRecord.RecordCreateDate);

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            Word.Application wordApp = new Word.Application();
            base.InitWordApplication(wordApp, xmlDoc, Public.EMRType.入院记录);

            //插入标题 
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.Font.Size = Public.StaticVariable.BodyTitleFontSize;
            wordApp.Selection.Font.Bold = 2;
            wordApp.Selection.TypeText(this.Name);  

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
                wordApp.Selection.Font.Size = Public.StaticVariable.BodyFontSize;
                wordApp.Selection.Font.Bold = 0;
                wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                wordApp.Selection.TypeText("    "+node.InnerText);
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
                    wordApp.Selection.TypeText("    "+node.Name.ToString().Trim() + "：");
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
            //wordApp.Selection.TypeText("医生签名：" + new GWMHIS.BussinessLogicLayer.Classes.Employee((long)emrRecord.RecordCreateEmp).Name + "    ");
            wordApp.Selection.TypeText("医生签名：____________________");
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.TypeText(emrRecord.RecordCreateDate.ToLongDateString() + "    ");
        }

        private void 门急诊病历_Scroll(object sender, ScrollEventArgs e)
        {
            int n = Math.Abs(e.NewValue-e.OldValue);
            if (n >= 1)
            {
                foreach (Control control in this.Controls)
                {
                    if (control.GetType().ToString().Trim() == "System.Windows.Forms.Label")
                    {
                        control.Location = new Point(control.Location.X, control.Location.Y-e.NewValue+e.OldValue);
                    }
                }
            }
        }
    }
}
