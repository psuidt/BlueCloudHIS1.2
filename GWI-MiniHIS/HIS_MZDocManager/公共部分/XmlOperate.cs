using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Xml;
using HIS.SYSTEM.PubicBaseClasses;
using grproLib;

namespace HIS_MZDocManager
{
    /// <summary>
    /// XML公共操作类
    /// </summary>
    public class XmlOperate
    {
        /// <summary>
        /// 获取控件值，写入XML节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="control"></param>
        private static void GetRegInfoValue(XmlNode node, Control control)
        {
            for (int index = 0; index < control.Controls.Count; index++)
            {
                if (control.Controls[index].GetType().ToString() == "System.Windows.Forms.GroupBox")
                {
                    XmlElement childnode = node.OwnerDocument.CreateElement(control.Controls[index].Name);
                    node.AppendChild(childnode);
                    GetRegInfoValue(childnode, control.Controls[index]);
                }
                if (control.Controls[index].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    XmlElement childnode = node.OwnerDocument.CreateElement(control.Controls[index].Name);
                    childnode.InnerText = control.Controls[index].Text;
                    node.AppendChild(childnode);
                }
                if (control.Controls[index].GetType().ToString() == "System.Windows.Forms.RadioButton")
                {
                    if (((RadioButton)control.Controls[index]).Checked)
                    {
                        node.InnerText = control.Controls[index].Text;
                    }
                }
                if (control.Controls[index].GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    XmlElement childnode = node.OwnerDocument.CreateElement(control.Controls[index].Name);
                    childnode.InnerText = control.Controls[index].Text;
                    node.AppendChild(childnode);
                }
            }
        }

        /// <summary>
        /// 将XML节点值显示在控件上
        /// </summary>
        /// <param name="node"></param>
        /// <param name="control"></param>
        private static void SetRegInfoValue(XmlNode node, Control control)
        {
            foreach (XmlNode xn in node.ChildNodes)//遍历所有子节点
            {
                XmlElement childnode = (XmlElement)xn;
                if (childnode.NodeType != XmlNodeType.Comment)
                {
                    if (childnode.HasChildNodes && childnode.ChildNodes.Count > 1)
                    {
                        for (int index = 0; index < control.Controls.Count; index++)
                        {
                            if (control.Controls[index].Name.Trim() == childnode.Name.Trim())
                            {
                                SetRegInfoValue(childnode, control.Controls[index]);
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int index = 0; index < control.Controls.Count; index++)
                        {
                            if (control.Controls[index].Name.Trim() == childnode.InnerText.Trim() && control.Controls[index].GetType().ToString() == "System.Windows.Forms.RadioButton")
                            {
                                ((RadioButton)(control.Controls[index])).Checked = true;
                                break;
                            }
                            if (control.Controls[index].Name.Trim() == childnode.Name.Trim())
                            {
                                if (control.Controls[index].GetType().ToString() == "System.Windows.Forms.GroupBox")
                                {
                                    SetRegInfoValue(node, control.Controls[index]);
                                    break;
                                }
                                if (control.Controls[index].GetType().ToString() == "System.Windows.Forms.TextBox")
                                {
                                    control.Controls[index].Text = childnode.InnerText;
                                    break;
                                }
                                if (control.Controls[index].GetType().ToString() == "System.Windows.Forms.RadioButton")
                                {
                                    ((RadioButton)(control.Controls[index])).Checked = true;
                                    break;
                                }
                                if (control.Controls[index].GetType().ToString() == "System.Windows.Forms.ComboBox")
                                {
                                    control.Controls[index].Text = childnode.InnerText;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 合成Xml文本
        /// </summary>
        public static string ComposeXmlText(string rootName, Control control)
        {
            string xmlText = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><" + rootName + "></" + rootName + ">";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                GetRegInfoValue(xmlDoc.SelectSingleNode(rootName), control);
                return xmlDoc.InnerXml;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示");
                return xmlText;
            }
        }

        /// <summary>
        /// 分解Xml文本
        /// </summary>
        /// <param name="xmlText"></param>
        /// <param name="rootName"></param>
        /// <param name="control"></param>
        public static void DeComposeXmlText(string xmlText, string rootName, Control control)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                SetRegInfoValue(xmlDoc.SelectSingleNode(rootName), control);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示");
            }
        }

        private static void DeComposePrintXmlCellValue(XmlNode node, GridppReport report)
        {
            foreach (XmlNode xn in node.ChildNodes)//遍历所有子节点
            {
                XmlElement childnode = (XmlElement)xn;
                if (childnode.NodeType != XmlNodeType.Comment)
                {
                    if (childnode.HasChildNodes && childnode.ChildNodes.Count > 1)
                    {
                        DeComposePrintXmlCellValue(childnode, report);
                    }
                    else
                    {
                        try
                        {
                            report.ParameterByName(childnode.Name.Trim()).AsString = childnode.InnerText;
                        }
                        catch
                        { }
                    }
                }
            }
        }

        public static void PrintXmlText(string xmlText, string rootName, string printFileName)
        {
            GridppReport report = new GridppReport();
            report.LoadFromFile(Constant.ApplicationDirectory + printFileName);

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                DeComposePrintXmlCellValue(xmlDoc.SelectSingleNode(rootName), report);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示");
            }

            report.PrintPreview(false);
        }

        public static void PrintXmlText(string xmlText, string rootName, GridppReport report)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                DeComposePrintXmlCellValue(xmlDoc.SelectSingleNode(rootName), report);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示");
            }
        }
    }    
}
