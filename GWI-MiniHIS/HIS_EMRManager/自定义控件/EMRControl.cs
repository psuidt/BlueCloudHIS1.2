using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;
using Word;

namespace HIS_EMRManager
{
    /// <summary>
    /// 病历控件
    /// </summary>
    internal  partial class EMRControl : UserControl
    {
        private HIS.EMR_BLL.EmrRecord _emrRecord;
        public event EventHandler SelectDataList;
        protected int titleFontSize = 12;
        protected int textFontSize = 12;

        public HIS.EMR_BLL.EmrRecord EmrRecord
        {
            get { return _emrRecord; }
            set { _emrRecord = value; }
        }
        /// <summary>
        /// 病历控件
        /// </summary>
        public EMRControl()
        {
            InitializeComponent();
        }

        public EMRControl(HIS.EMR_BLL.EmrRecord record)
        {
            InitializeComponent();
            this._emrRecord = record;
            this.SetValue(record.RecordContentXml);
        }

        /// <summary>
        /// 病历控件
        /// </summary>
        /// <param name="value">病历数据</param>
        public EMRControl(XmlDocument value)
        {
            InitializeComponent();
            this.SetValue(value);
        }

        /// <summary>
        /// 获取病历控件上的病历数据
        /// </summary>
        /// <returns></returns>
        public XmlDocument GetValue()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode node = xmlDoc.CreateElement(this.Name);
            foreach (Control control in this.Controls)
            {
                //if (control.Visible == true)
                //{
                    if (control.Tag != null && control.Tag.ToString().Trim() != "")
                    {
                        XmlNode childNode = xmlDoc.CreateElement(control.Name);
                        XmlAttribute xmlAttribute = xmlDoc.CreateAttribute("Code");
                        xmlAttribute.Value = control.Tag.ToString().Trim();
                        childNode.Attributes.Append(xmlAttribute);
                        childNode.InnerText = control.Text;
                        node.AppendChild(childNode);
                    }
                //}
            }
            xmlDoc.AppendChild(node);
            return xmlDoc;
        }

        /// <summary>
        /// 设置病历控件上的病历显示信息
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(XmlDocument value)
        {
            if (value != null)
            {
                XmlNode node = value.SelectSingleNode(this.Name);
                if (node != null)
                {
                    foreach (Control control in this.Controls)
                    {
                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            if (control.Name.Trim() == childNode.Name.Trim())
                            {
                                control.Text = childNode.InnerText;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 初始化打印控件
        /// </summary>
        /// <param name="wordApp"></param>
        /// <param name="xmlDoc"></param>
        /// <param name="type"></param>
        protected void InitWordApplication(Word.Application wordApp, XmlDocument xmlDoc, Public.EMRType type)
        {
            object oMissing = Missing.Value;
            wordApp.Visible = true;
            wordApp.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //设置页边距
            wordApp.ActiveDocument.PageSetup.TopMargin = wordApp.CentimetersToPoints(float.Parse("1")); //上页边距
            wordApp.ActiveDocument.PageSetup.BottomMargin = wordApp.CentimetersToPoints(float.Parse("1.5")); //上页边距
            wordApp.ActiveDocument.PageSetup.LeftMargin = wordApp.CentimetersToPoints(float.Parse("2.5")); //上页边距
            wordApp.ActiveDocument.PageSetup.RightMargin = wordApp.CentimetersToPoints(float.Parse("2.5")); //上页边距

            //设置边线
            wordApp.ActiveDocument.Sections[1].Borders.DistanceFrom = WdBorderDistanceFrom.wdBorderDistanceFromText;
            wordApp.ActiveDocument.Sections[1].Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleNone;
            wordApp.ActiveDocument.Sections[1].Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
            wordApp.ActiveDocument.Sections[1].Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
            wordApp.ActiveDocument.Sections[1].Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleNone;

            // 添加页眉 
            wordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
            wordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
            object styleType = "正文";
            object style = wordApp.ActiveDocument.Styles.get_Item(ref styleType);
            wordApp.Selection.set_Style(ref style);

            //医院名称
            wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            wordApp.Selection.Font.Size = 16;//字体加大
            wordApp.Selection.Font.Bold = 1;
            wordApp.Selection.TypeText(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName);
            //标题
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.Font.Size = 22;
            wordApp.Selection.Font.Bold = 1;
            wordApp.Selection.TypeText("病   历   记   录");
            wordApp.Selection.TypeParagraph();
            //wordApp.Selection.TypeText(type == HIS_EMRManager.Public.EMRType.病程记录 ? "病  程  记  录" : "病   历   记   录");

            //病人基本信息
            wordApp.Selection.Font.Size = 12;
            Word.Table table = wordApp.ActiveDocument.Tables.Add(wordApp.Selection.Range, 1, 3, ref oMissing, ref oMissing);
            wordApp.Selection.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleNone;
            wordApp.Selection.Borders.InsideLineStyle = WdLineStyle.wdLineStyleNone;
            int columnNo = 1;
            object step = 1;
            object unit = Word.WdUnits.wdCharacter;
            object extend = Word.WdMovementType.wdExtend;
            foreach (XmlNode node in xmlDoc.SelectSingleNode("病人信息/基本信息").ChildNodes)
            {
                wordApp.Selection.Font.Size = 12;
                wordApp.Selection.Font.Bold = 0;
                wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                wordApp.Selection.TypeText("    "+(columnNo==2?"（第     页）":node.InnerText));
                columnNo++;
                if (columnNo <= 3)
                {
                    wordApp.Selection.Move(ref unit, ref step);
                }
                else
                {
                    unit = Word.WdUnits.wdLine;
                    wordApp.Selection.MoveDown(ref unit, ref step, ref oMissing);
                    break;
                }
            }
            //画分隔线
            //wordApp.ActiveDocument.Shapes.AddLine(70, 125, 530, 125, ref oMissing);

            wordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument; // 跳出页眉设置 
            wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;


            wordApp.Selection.ParagraphFormat.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
            wordApp.Selection.ParagraphFormat.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleNone;
            wordApp.Selection.ParagraphFormat.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;
            wordApp.Selection.ParagraphFormat.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleNone;

            //标题
            //wordApp.Selection.TypeParagraph();
            wordApp.Selection.Font.Size = 14;
            wordApp.Selection.Font.Bold = 1;
            wordApp.Selection.TypeText(type.ToString());
            wordApp.Selection.ParagraphFormat.LineSpacing = 20;
        }
        /// <summary>
        /// 写入内容标题
        /// </summary>
        /// <param name="wordApp"></param>
        /// <param name="content"></param>
        /// <param name="spaceNum"></param>
        protected static void WriteBodyTitle(Word.Application wordApp, string content, int spaceNum)
        {
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.ParagraphFormat.LeftIndent = Public.StaticVariable.BodyTitleFontSize * spaceNum;
            wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            wordApp.Selection.Font.Size = Public.StaticVariable.BodyTitleFontSize;
            wordApp.Selection.Font.Bold = Public.StaticVariable.BodyTitleFontBold;
            wordApp.Selection.Font.Name = Public.StaticVariable.BodyTitleFontName;
            wordApp.Selection.TypeText(content);
        }
        /// <summary>
        /// 写入内容
        /// </summary>
        /// <param name="wordApp"></param>
        /// <param name="content"></param>
        /// <param name="spaceNum"></param>
        protected static void WriteBody(Word.Application wordApp, string content, int spaceNum)
        {
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.ParagraphFormat.LeftIndent = Public.StaticVariable.BodyTitleFontSize * spaceNum;
            wordApp.Selection.Font.Size = Public.StaticVariable.BodyFontSize;
            wordApp.Selection.Font.Bold = Public.StaticVariable.BodyFontBold;
            wordApp.Selection.Font.Name = Public.StaticVariable.BodyFontName;
            wordApp.Selection.TypeText(content);
        }
    }
}
