using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZYDoc_BLL
{    
    partial class MessageShows
    {       
        public static string GetMessages(string code,params string[] content)
        {
            string  returnString = "0";
            switch (code)
            {
                case "0": returnString = "0"; break;               
                case "C01": returnString = "{0}数量不能为空"; break;
                case "C02": returnString = "{0}数量或付数不能小于零！"; break;
                case "C03": returnString = "非法单位，请重新输入"; break;
                case "C04": returnString = "非法用法，请重新输入"; break;
                case "C05": returnString = "频率不能为空"; break;
                case "C06": returnString = "非法频率，请重新输入"; break;

                case "S01": returnString = "医嘱名称为空，保存失败，请重新输入医嘱名称"; break;
                case "S02": returnString = "{0}的开嘱时间为空，保存失败，请重开医嘱"; break;
                case "S03": returnString = "{0}的用法为空，保存失败，请输入用法"; break;
                case "S04": returnString = "{0}的开嘱医生为空，保存失败，请重新开此条医嘱"; break;
                case "S05": returnString = "{0}的开嘱科室为空，保存失败，请重新开此条医嘱"; break;
                case "S06": returnString = "长期医嘱\n{0}保存成功！\n {1}重新保存！"; break;
                case "S07": returnString = "长期医嘱\n{0}保存成功！"; break;
                case "S08": returnString = "长期医嘱\n{0}重新保存！"; break;
                case "S09": returnString = "临时医嘱\n{0}保存成功！\n {1}重新保存！"; break;
                case "S10": returnString = "临时医嘱\n{0}保存成功！"; break;
                case "S11": returnString = "临时医嘱\n{0}重新保存！"; break;

                default: return string.Format(returnString,content);
            }
            return string.Format(returnString, content);
        }
    }
}
