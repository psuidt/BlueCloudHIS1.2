using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Xml;

namespace HIS.MZDoc_BLL.Public
{
    /// <summary>
    /// XML公共方法类
    /// </summary>
    public class XmlFunction
    {
        /// <summary>
        /// 合成Xml文本
        /// </summary>
        /// <param name="obj">值来源对象</param>
        /// <param name="modelText">Xml文档模板</param>
        /// <param name="rootName">根节点名称</param>
        /// <returns></returns>
        public static string ComposeXmlText(object obj, string modelText, string rootName)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(modelText);
                XmlNodeList nodeList = xmlDoc.SelectSingleNode(rootName).ChildNodes;

                PropertyInfo[] properties = obj.GetType().GetProperties();
                foreach (XmlNode xn in nodeList)//遍历所有子节点
                {
                    if (xn.NodeType != XmlNodeType.Comment)
                    {
                        XmlElement xe = (XmlElement)xn;
                        foreach (PropertyInfo property in properties)
                        {
                            if (xe.Name == property.Name)
                            {
                                object value = property.GetValue(obj, null);
                                xe.InnerText = (value == null ? "" : value.ToString().Trim());
                            }
                        }
                    }
                }
                return xmlDoc.InnerXml;
            }
            catch
            {
                return modelText;
            }
        }

        /// <summary>
        /// 分解Xml文本
        /// </summary>
        /// <param name="obj">写入值对象</param>
        /// <param name="modelText">Xml文档</param>
        /// <param name="rootName">根节点名称</param>
        /// <returns></returns>
        public static void DeComposeXmlText(object obj, string modelText, string rootName)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(modelText);

                Type type = obj.GetType();
                PropertyInfo[] properties = obj.GetType().GetProperties();
                foreach (XmlNode xn in xmlDoc.SelectSingleNode(rootName).ChildNodes)//遍历所有子节点
                {
                    PropertyInfo property = type.GetProperty(xn.Name);
                    if (xn.NodeType != XmlNodeType.Comment && property != null)
                    {
                        property.SetValue(obj, xn.InnerText, null);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        /// <summary>
        /// 获取XML节点值
        /// </summary>
        /// <param name="node">结点</param>
        /// <param name="table">数据表</param>
        private static void GetXmlCellValue(XmlNode node, DataTable table)
        {
            foreach (XmlNode xn in node.ChildNodes)//遍历所有子节点
            {
                XmlElement childnode = (XmlElement)xn;
                if (childnode.NodeType != XmlNodeType.Comment)
                {
                    if (childnode.HasChildNodes && childnode.ChildNodes.Count > 1)
                    {
                        GetXmlCellValue(childnode, table);
                    }
                    else
                    {
                        DataRow row = table.NewRow();
                        row[0] = childnode.Name;
                        row[1] = childnode.InnerText;
                        table.Rows.Add(row);
                    }
                }
            }
        }

        /// <summary>
        /// 分解Xml文本
        /// </summary>
        /// <param name="xmlText">XML文本内容</param>
        /// <param name="rootName">根节点名称</param>
        /// <param name="table">数据表</param>
        public static DataTable DeComposeXmlText(string xmlText, string rootName, DataTable table)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                GetXmlCellValue(xmlDoc.SelectSingleNode(rootName), table);
                return table;
            }
            catch
            {
                return table;
            }
        }
    }    
}
