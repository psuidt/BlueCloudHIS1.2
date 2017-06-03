using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL.ObjectModel
{
    public class CommMethod
    {
        /// <summary>
        /// 数组对象转字符串，用逗号分隔
        /// </summary>
        /// <param name="objs">数组对象</param>
        /// <returns></returns>
        public static string ToString(object[] objs)
        {
            if (objs.Length == 0 ||objs==null) 
                return "";

            string str = "";
            for (int i = 0; i < objs.Length; i++)
            {
                if (i == objs.Length - 1)
                    str += objs[i].ToString();
                else
                    str += objs[i].ToString() + ",";
            }

            return str;
        }
        /// <summary>
        /// 数组转字符串，用逗号分隔
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static string ToString(int[] ints)
        {
            if (ints.Length == 0 || ints == null)
                return "";

            string str = "";
            for (int i = 0; i < ints.Length; i++)
            {
                if (i == ints.Length - 1)
                    str += ints[i].ToString();
                else
                    str += ints[i].ToString() + ",";
            }

            return str;
        }

        public static List<string> list_AddString = new List<string>();
        /// <summary>
        /// 返回累加后的字符串，过滤掉相同的值
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string AddString(string Str)
        {
            List<string> list = list_AddString;
            if (list.Exists(x => x == Str) == false)
                list.Add(Str);
            string s = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                    s += list[i];
                else
                    s += list[i] + ",";
            }

            return s;
        }
    }
}
