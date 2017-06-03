using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;
using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.MZDoc_BLL.Public
{
    /// <summary>
    /// 公共方法类
    /// </summary>
    public class Function 
    {
        /// <summary>
        /// 为对象赋值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="property">需要赋值的属性</param>
        /// <param name="objectValue">值</param>
        private static void SetValue(object obj, PropertyInfo property, object objectValue)
        {
            switch (objectValue.GetType().FullName)
            {
                case "System.DBNull":
                    property.SetValue(obj, null, null);
                    break;
                case "System.Int64":
                    property.SetValue(obj, Convert.ToInt32(objectValue), null);
                    break;
                default:
                    property.SetValue(obj, objectValue, null);
                    break;
            }
        }

        /// <summary>
        /// 将数据行转化为对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static object DataRowToObject<T>(DataRow row)
        {
            Type type = typeof(T);
            T obj = (T)System.Activator.CreateInstance(type);
            foreach (PropertyInfo property in type.GetProperties())
            {
                if (row.Table.Columns.IndexOf(property.Name.Trim()) >= 0)
                {
                    SetValue((object)obj, property, row[property.Name.Trim()]);
                }
            }
            return obj;
        }

        /// <summary>
        /// 将数据行集合转化为强类型列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static object DataRowsToList<T>(DataRow[] rows)
        {
            Type type = typeof(T);
            List<T> objects = new List<T>();
            T obj = (T)System.Activator.CreateInstance(type);
            if (rows != null && rows.Length > 0)
            {
                while (objects.Count < rows.Length)
                {
                    objects.Add((T)System.Activator.CreateInstance(type));
                }
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (rows[0].Table.Columns.IndexOf(property.Name.Trim()) >= 0)
                    {
                        for (int index = 0; index < rows.Length; index++)
                        {
                            SetValue((object)objects[index], property, rows[index][property.Name]);
                        }
                    }
                }
            }
            return objects;
        }

        /// <summary>
        /// 将数据表转化为强类型列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static object DataTableToList<T>(DataTable table)
        {
            Type type = typeof(T);
            List<T> objects = new List<T>();
            T obj = (T)System.Activator.CreateInstance(type);
            if (table != null && table.Rows.Count > 0)
            {
                while (objects.Count < table.Rows.Count)
                {
                    objects.Add((T)System.Activator.CreateInstance(type));
                }
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (table.Columns.IndexOf(property.Name.Trim()) >= 0)
                    {
                        for (int index = 0; index < table.Rows.Count; index++)
                        {
                            SetValue((object)objects[index], property, table.Rows[index][property.Name]);
                        }
                    }
                }
            }
            return objects;
        }

        /// <summary>
        /// 转换数据行格式
        /// </summary>
        /// <param name="oldRow"></param>
        /// <param name="rowModel"></param>
        /// <returns></returns>
        public static DataRow TransformRow(DataRow oldRow, DataRow rowModel)
        {
            DataRow newRow = rowModel.Table.NewRow();
            if (oldRow != null)
            {
                foreach (DataColumn column in oldRow.Table.Columns)
                {
                    if (rowModel.Table.Columns.IndexOf(column.ColumnName.Trim()) >= 0)
                    {
                        object objectValue = oldRow[column.ColumnName];
                        string fullName = objectValue.GetType().FullName;
                        if (fullName == "System.DBNull")
                        {
                            newRow[column.ColumnName] = null;
                        }
                        else
                        {
                            newRow[column.ColumnName] = objectValue;
                        }
                    }
                }
            }
            return newRow;
        }

        /// <summary>
        /// 将对象转化为数据行
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DataRow ObjectToDataRow(object obj)
        {
            DataTable result = new DataTable();
            if (obj != null)
            {
                ArrayList tempList = new ArrayList();
                foreach (PropertyInfo property in obj.GetType().GetProperties())
                {
                    result.Columns.Add(property.Name, property.PropertyType);
                    tempList.Add(property.GetValue(obj, null));
                }
                object[] array = tempList.ToArray();
                result.LoadDataRow(array, true);
            }
            return result.Rows[0];
        }

        ///<summary>
        /// 将集合类转换成DataTable
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DataTable ListToDataTable(IList list, object obj)
        {
            DataTable result = new DataTable();
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                result.Columns.Add(property.Name, property.PropertyType);
            }

            for (int i = 0; i < list.Count; i++)
            {
                ArrayList tempList = new ArrayList();
                foreach (PropertyInfo property in propertys)
                {
                    tempList.Add(property.GetValue(list[i], null));
                }
                object[] array = tempList.ToArray();
                result.LoadDataRow(array, true);
            }
            return result;
        }

        /// <summary>
        /// 获得处方字体的颜色
        /// </summary>
        /// <param name="status">处方状态</param>
        /// <returns></returns>
        public static System.Drawing.Color GetPresForeColor(PresStatus status)
        {
            switch (status)
            {
                case HIS.MZDoc_BLL.Public.PresStatus.新建状态:
                    return System.Drawing.Color.Blue;
                case HIS.MZDoc_BLL.Public.PresStatus.收费状态:
                    return System.Drawing.Color.Orange;
                case HIS.MZDoc_BLL.Public.PresStatus.退费状态:
                    return System.Drawing.Color.Fuchsia;
                default:
                    return System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 获得处方背景的颜色
        /// </summary>
        /// <param name="itemId">处方项目ID</param>
        /// <param name="status">处方状态</param>
        /// <returns></returns>
        public static System.Drawing.Color GetPresBackColor(int itemId, PresStatus status)
        {
            return itemId <= 0 ? System.Drawing.Color.Ivory
                : (status == PresStatus.修改状态 ? System.Drawing.Color.Moccasin : System.Drawing.Color.White);
        }

        /// <summary>
        /// 将生日转化成为年龄
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static PeopleAge TransBirthdayToAge(DateTime birthday)
        {
            DateTime currentDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            PeopleAge age = new PeopleAge();
            if (birthday.Year != currentDate.Year && birthday.Date.AddYears(1) <= currentDate.Date)
            {
                age.AgeUnit = "岁";
                age.AgeNum = currentDate.Year - birthday.Year;
            }
            else if (birthday.Month != currentDate.Month && birthday.Date.AddMonths(1) <= currentDate.Date)
            {
                age.AgeUnit = "月";
                age.AgeNum = currentDate.Month - birthday.Month;
                if (age.AgeNum < 0)
                {
                    age.AgeNum += 12;
                }
            }
            else if (birthday.Day != currentDate.Day && birthday.Date.AddDays(1) <= currentDate.Date)
            {
                age.AgeUnit = "天";
                age.AgeNum = (currentDate - birthday).Days;
            }
            else
            {
                age.AgeUnit = "小时";
                age.AgeNum = (currentDate - birthday).Hours;
            }
            return age;
        }
    }    
}
