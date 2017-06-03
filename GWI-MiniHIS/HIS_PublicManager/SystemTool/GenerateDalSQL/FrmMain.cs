using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.BLL;
using HIS.SYSTEM.Core;
using System.IO;

using System.Reflection;

namespace HIS_PublicManager.SystemTool.GenerateDalSQL
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        List<string> namelist = new List<string>();
        int _index = 0;
        int __index = 0;

        private string GetstrWhere(string strwhere, string name, string tablename)
        {
            strwhere = strwhere.Replace(" order by "," % ").Replace(" group by "," & ").Replace("<>", " @ ").Replace(">=", " # ").Replace("<=", " $ ").Replace("=", " = ").Replace("<", " < ").Replace(">", " > ");
 
            string[] strwheres = strwhere.Trim().Split(new char[] { ' ' });

            for (int i = 0; i < strwheres.Length; i++)
            {
                if (strwheres[i].Trim().Length > 0)
                {
                    if (strwheres[i].Trim() == "=")
                    {
                        strwheres[i] = " +_OleDB.EuqalTo()+ ";
                    }
                    else if (strwheres[i].Trim() == "desc")
                    {
                        strwheres[i] = " +_OleDB.DESC()+ ";
                    }
                    else if (strwheres[i].Trim() == "%")
                    {
                        strwheres[i] = " +_OleDB.OrderBy()+ ";
                    }

                    else if (strwheres[i].Trim() == "&")
                    {
                        strwheres[i] = " +_OleDB.GroupBy()+ ";
                    }
                    else if (strwheres[i].Trim() == ">")
                    {
                        strwheres[i] = " +_OleDB.GreaterThan()+ ";
                    }
                    else if (strwheres[i].Trim() == "<")
                    {
                        strwheres[i] = " +_OleDB.LessThan()+ ";
                    }
                    else if (strwheres[i].Trim() == "#")
                    {
                        strwheres[i] = " +_OleDB.GreaterThanAndEqualTo()+ ";
                    }
                    else if (strwheres[i].Trim() == "$")
                    {
                        strwheres[i] = " +_OleDB.LessThanAndEqualTo()+ ";
                    }
                    else if (strwheres[i].Trim() == "@")
                    {
                        strwheres[i] = " +_OleDB.NotEqualTo()+ ";
                    }
                    else if (strwheres[i].Trim().ToLower() == "and")
                    {
                        strwheres[i] = " +_OleDB.And()+ ";
                    }
                    else
                    {
                        for (int q = 0; q < EntityConfig.dal_m.Count; q++)
                        {
                            if (EntityConfig.dal_m[q].TableName.ToLower() == tablename.ToLower())
                            {
                                for (int w = 0; w < EntityConfig.dal_m[q].FieldName.Count; w++)
                                {
                                    if (EntityConfig.dal_m[q].FieldName[w].ToLower() == strwheres[i].Trim().ToLower())
                                    {
                                        strwheres[i] = "Tables." + tablename.ToLower().Trim() + "." + strwheres[i].Trim().ToUpper();
                                        break;
                                    }
                                    if (w == EntityConfig.dal_m[q].FieldName.Count - 1)
                                    {
                                        for (int h = 0; h < namelist.Count; h++)
                                        {
                                            if (namelist[h].ToLower().Trim() == strwheres[i].ToLower().Trim())
                                            {
                                                strwheres[i] = strwheres[i];
                                                break;
                                            }
                                            if (h == namelist.Count - 1)
                                            {
                                                strwheres[i] = "\"" + strwheres[i] + "\"";
                                            }
                                        }
                                    }

                                }
                                break;
                            }
                        }
                    }

                }
                
            }

            strwhere = "";
            for (int i = 0; i < strwheres.Length; i++)
            {
                strwhere += strwheres[i];
            }
            _index = _index + 1;
            strsql.Append("string strWhere_" + _index + "=" + strwhere + ";\n");
            
            namelist.Add("strWhere_"+_index);
            return "strWhere_" +_index;
        }

        private string GetDalSelect(string sql, string name)
        {

            string tablename = sql.Split(new string[] { "from" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim().Split(new char[] { ' ' })[0].Trim();
            string[] strwheres = sql.Split(new string[] { "where" }, StringSplitOptions.RemoveEmptyEntries);
            string strwhere = null;
            if (strwheres.Length > 1)
            {
                strwhere = GetstrWhere(strwheres[1].Trim().ToLower(),name.ToLower(),tablename);
            }
            else
            {
                strwhere = "\"\"";
            }
            string[] fieldnames = sql.Split(new string[] { "select", "from" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim().Split(new char[] { ',' });

            for (int i = 0; i < EntityConfig.dal_m.Count; i++)
            {
                if (EntityConfig.dal_m[i].TableName.ToLower() == tablename.ToLower())
                {
                    tablename = "Tables." + tablename.ToUpper();
                    for (int n = 0; n < fieldnames.Length; n++)
                    {
                        string[] sfield = fieldnames[n].Trim().Split(new char[] { ' ' });
                        if (sfield.Length > 1)
                        {
                            for (int m = 0; m < EntityConfig.dal_m[i].FieldName.Count; m++)
                            {
                                if (EntityConfig.dal_m[i].FieldName[m].ToLower() == sfield[0].ToLower())
                                {
                                    sfield[0] = "Tables." + EntityConfig.dal_m[i].TableName.ToLower() + "." + sfield[0].ToUpper();
                                    break;
                                }
                                
                            }

                            fieldnames[n] = "_OleDB.FiledNameBM(" + sfield[0] + "," + "\"" + sfield[sfield.Length - 1] + "\"" + ")";
                            
                        }
                        else
                        {
                            for (int m = 0; m < EntityConfig.dal_m[i].FieldName.Count; m++)
                            {
                                if (EntityConfig.dal_m[i].FieldName[m].ToLower() == fieldnames[n].ToLower())
                                {
                                    fieldnames[n] = "Tables." + EntityConfig.dal_m[i].TableName.ToLower() + "." + fieldnames[n].ToUpper();
                                    break;
                                }
                                
                            }
                        }
                    }
                    break;
                }
            }

            string str = "_OleDB.ChildTable(" + tablename + "," + "\"" + name + "\"" + "," + strwhere + ",\n";
            for (int i = 0; i < fieldnames.Length; i++)
            {
                str += "\t\t\t" + fieldnames[i];
                if (i != fieldnames.Length - 1)
                    str += ",\n";

            }
            return str += ")";
        }

        private string GetDalSelectTable(string sql, string name)
        {
            sql = sql.Trim();
            string tablename = sql.Split(new string[] { "from" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim().Split(new char[] { ' ' })[0].Trim();
            string[] strwheres = sql.Split(new string[] { "where" }, StringSplitOptions.RemoveEmptyEntries);
            string strwhere = null;
            if (strwheres.Length > 1)
            {
                strwhere = GetstrWhere(strwheres[1].Trim().ToLower(),tablename.ToLower(),tablename);
            }
            else
            {
                strwhere =  "\"\"";
            } 
            string[] fieldnames = sql.Split(new string[] { "select", "from" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim().Split(new char[] { ',' });
            string[] tables= sql.Split(new string[] { "from", "where" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim().Split(new char[] { ' ' });
            if (tables.Length > 1)
                name = sql.Split(new string[] { "from", "where" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim().ToLower().Replace(" as ","").Replace(tablename.ToLower(),"").Trim();
            for (int i = 0; i < EntityConfig.dal_m.Count; i++)
            {
                if (EntityConfig.dal_m[i].TableName.ToLower() == tablename.ToLower())
                {
                    tablename = "Tables." + tablename.ToUpper();
                    for (int n = 0; n < fieldnames.Length; n++)
                    {
                        string[] sfield = fieldnames[n].Trim().Split(new char[] { ' ' });
                        if (sfield.Length > 1)
                        {
                            for (int m = 0; m < EntityConfig.dal_m[i].FieldName.Count; m++)
                            {
                                if (EntityConfig.dal_m[i].FieldName[m].ToLower() == sfield[0].ToLower())
                                {
                                    sfield[0] = "Tables." + EntityConfig.dal_m[i].TableName.ToLower() + "." + sfield[0].ToUpper();
                                    break;
                                }

                            }

                            fieldnames[n] = "_OleDB.FiledNameBM(" + sfield[0] + "," + "\"" + sfield[sfield.Length - 1] + "\"" + ")";

                        }
                        else
                        {
                            for (int m = 0; m < EntityConfig.dal_m[i].FieldName.Count; m++)
                            {
                                if (EntityConfig.dal_m[i].FieldName[m].ToLower() == fieldnames[n].ToLower())
                                {
                                    fieldnames[n] = "Tables." + EntityConfig.dal_m[i].TableName.ToLower() + "." + fieldnames[n].ToUpper();
                                    break;
                                }

                            }
                        }
                    }
                    break;
                }
            }
            string str = null;
            if (name != "")
            {
                str = "string strsql=_OleDB.Table(" + tablename + "," + "\"" + name + "\"" + ","  + strwhere  + ",\n";
            }
            else
            {
                str = @"string strsql=_OleDB.Table(" + tablename + "," + "\"\"" + ","  + strwhere + ",\n";
            }
            //string str = "_OleDB.ChildTable(" + tablename + "," + name + "," + strwhere + ",\n";

            for (int i = 0; i < fieldnames.Length; i++)
            {
                str += "\t\t\t" + fieldnames[i];
                if (i != fieldnames.Length - 1)
                    str += ",\n";

            }
            str += ");";

            return str;
        }


        private string GetDalCase(string sql, string name)
        {
            
            string[] strWhen = sql.Replace("case","").Replace("end","").Trim().Split(new string[] { "when", "then", "else" }, StringSplitOptions.RemoveEmptyEntries);
            if (strWhen.Length < 2) return sql;
            //string[] strs = new string[(strWhen-strWhen%2)/2+1];
            //int index=0;
            string Dal = null;
            Dal = "_OleDB.CASEWhen("+"\"" + name+"\""+",";
            for (int i = 0; i < strWhen.Length; i++)
            {
                if (i != strWhen.Length - 1)
                {
                    //strs[index] = strWhen[i] + " _OleDB.Then() " + strWhen[i++];



                    Dal +=" _OleDB.When()+ "+ strWhen[i] + "+ _OleDB.Then()+ " + strWhen[i+1];
                    if (i != strWhen.Length - 2)
                    {
                        Dal += ",";
                    }
                    i = i + 1;
                }
                else
                {
                    Dal += "_OleDB.Else()+" + strWhen[i];
                 
                }
                
            }
            Dal += ")";
            return Dal;
                
        }
        StringBuilder strsql = null;

        string basestr = null;
        string basestr1 = null;

        private void ChargeSQL(string Textsql)
        {
            basestr = Textsql;
            string[] strs = Textsql.Replace('\n', ' ').Split(new char[] { '(' });
            if (strs.Length == 1)
            {
                strsql.Append(GetDalSelectTable(strs[0].ToLower(), ""));
                return;
            }
            for (int i = 0; i < strs.Length; i++)
            {
                int start_pos = strs[i].IndexOf(')');
                if (start_pos == -1)
                {
                    if (i != 0)
                        strs[i] = "(" + strs[i];
                    continue;//如果没有）证明不是一句完整的SQL
                }
                string childsql = strs[i].Substring(0, start_pos).Trim().ToLower();
                string childname_w = strs[i].ToLower().Substring(start_pos + 1, strs[i].Length - start_pos - 1).Trim().Replace("as", "").Replace(")"," ");
                string childname = childname_w.Split(new char[] { ' ', ',' })[0].ToLower().Replace("from", "").Replace("bigint", "");


                string sqltype = childsql.Split(new char[] { ' ' })[0].Trim();
                if (sqltype.ToLower() == "select")
                {
                    __index = __index + 1;
                    strsql.Append("string childtable_" + __index + "=" + GetDalSelect(childsql, childname) + ";\n");
                    namelist.Add("childtable_" + __index);
                    strs[i] = " childtable_" + __index + " " + strs[i].ToLower().Substring(start_pos + 1, strs[i].Length - start_pos - 1).Trim().Remove(0, childname.Length);
                }
                else if (sqltype.ToLower() == "case")
                {
                    __index = __index + 1;
                    strsql.Append("string casewhen_" + __index + "=" + GetDalCase(childsql, childname) + ";\n");
                    namelist.Add("casewhen_" + __index);
                    strs[i] = " casewhen_" + __index + " " + strs[i].ToLower().Substring(start_pos + 1, strs[i].Length - start_pos - 1).Trim().Remove(0, childname.Length);
                }
                else
                {
                    strs[i] = "(" + strs[i];
                }

            }
            string str = null;
            for (int i = 0; i < strs.Length; i++)
            {
                str += strs[i];
            }
            if (str == basestr)
            {
                basestr1 = str;
                int cast_id= str.ToLower().IndexOf(" cast ");
                if (cast_id != -1)
                {
                    int cast_left = str.IndexOf("(", cast_id);
                    int cast_right = str.IndexOf(")", cast_id);

                    int cast_lleft = str.IndexOf("(", cast_left+1);

                    if (cast_lleft == -1 || cast_lleft > cast_right)
                    {
                        string str_cast = str.Substring(cast_id, cast_right - cast_id + 1);
                        string fieldtype = str_cast.Split(new string[] { " as " }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("(", "").ToLower().Replace("cast", "").Trim();
                        string strtype = str_cast.Split(new string[] { " as " }, StringSplitOptions.RemoveEmptyEntries)[1].Replace(")", "").Trim();
                        _index = _index + 1;
                        strsql.Append("string cast_" + _index + "=" + "_OleDB.DBConvert(" + fieldtype + "," + "\"" + strtype + "\");\n");
                        namelist.Add("cast_" + _index);
                        str = str.Replace(str_cast, " cast_" + _index+" ");
                        //ChargeSQL(str);
                    }
                }

                int sum_id = str.ToLower().IndexOf(" sum ");
                if (sum_id != -1)
                {
                    int sum_left = str.IndexOf("(", sum_id);
                    int sum_right = str.IndexOf(")", sum_id);
                    int sum_lleft = str.IndexOf("(", sum_left + 1);

                    if (sum_lleft == -1 || sum_lleft > sum_right)
                    {
                        string str_sum = str.Substring(sum_id, sum_right - sum_id + 1);
                        string strfield = str.Substring(sum_left + 1, sum_right - sum_left - 1).Trim();
                        _index = _index + 1;
                        strsql.Append("string sum_" + _index + "=" + "_OleDB.Sum(" + strfield + "," + "\"" + "\"" + ");\n");
                        namelist.Add("sum_" + _index);
                        str = str.Replace(str_sum, " sum_" + _index+" ");
                        //ChargeSQL(str);
                    }
                }


                int count_id = str.ToLower().IndexOf(" count ");
                if (count_id != -1)
                {
                    int count_left = str.IndexOf("(", count_id);
                    int count_right = str.IndexOf(")", count_id);
                    int count_lleft = str.IndexOf("(", count_left + 1);

                    if (count_lleft == -1 || count_lleft > count_right)
                    {
                        string str_count = str.Substring(count_id, count_right - count_id + 1);
                        string strfield = str.Substring(count_left + 1, count_right - count_left - 1).Trim();
                        _index = _index + 1;
                        strsql.Append("string count_" + _index + "=" + "_OleDB.Count(" + strfield + "," + "\"" + "\"" + ");\n");
                        namelist.Add("count_" + _index);
                        str = str.Replace(str_count, " count_" + _index+" ");
                        //ChargeSQL(str);
                    }
                }

                int in_id = str.ToLower().IndexOf(" in ");
                if (in_id != -1)
                {
                    int in_left = str.IndexOf("(", in_id);
                    int in_right = str.IndexOf(")", in_id);
                    int in_lleft = str.IndexOf("(", in_left + 1);

                    if (in_lleft == -1 || in_lleft > in_right)
                    {
                        string str_in = str.Substring(in_id, in_right - in_id + 1);
                        string strfield = str.Substring(in_left + 1, in_right - in_left - 1).Trim();
                        _index = _index + 1;
                        strsql.Append("string in_1_"+_index  + "=" + "_OleDB.In(" + strfield + ");\n");
                        namelist.Add("in_1_"+_index);
                        str = str.Replace(str_in, " in_1_"+_index+" ");
                        //ChargeSQL(str);
                    }
                }

                int date_id = str.ToLower().IndexOf(" date ");
                if (date_id != -1)
                {
                    int date_left = str.IndexOf("(", date_id);
                    int date_right = str.IndexOf(")", date_id);
                    int date_lleft = str.IndexOf("(", date_left + 1);

                    if (date_lleft == -1 || date_lleft > date_right)
                    {
                        string str_date = str.Substring(date_id, date_right - date_id + 1);
                        string strfield = str.Substring(date_left + 1, date_right - date_left - 1).Trim();
                        _index = _index + 1;
                        strsql.Append("string date_1_"+_index + "=" + "_OleDB.Date(" + strfield + ");\n");
                        namelist.Add("date_1_"+_index);
                        str = str.Replace(str_date, " date_1_"+_index+" ");
                        //ChargeSQL(str);
                    }
                }

                int mod_id = str.ToLower().IndexOf(" mod ");
                if (mod_id != -1)
                {
                    int mod_left = str.IndexOf("(", mod_id);
                    int mod_right = str.IndexOf(")", mod_id);
                    int mod_lleft = str.IndexOf("(", mod_left + 1);

                    if (mod_lleft == -1 || mod_lleft > mod_right)
                    {
                        string str_mod = str.Substring(mod_id, mod_right - mod_id + 1);
                        string strfield = str.Substring(mod_left + 1, mod_right - mod_left - 1).Trim();
                        _index = _index + 1;
                        strsql.Append("string _mod_1_"+_index + "=" + "_OleDB.Mod(" + strfield + ");\n");
                        namelist.Add("mod_1_"+_index);
                        str = str.Replace(str_mod, " _mod_1_"+_index+" ");
                        //ChargeSQL(str);
                    }
                }

                int max_id = str.ToLower().IndexOf(" max ");
                if (max_id != -1)
                {
                    int max_left = str.IndexOf("(", max_id);
                    int max_right = str.IndexOf(")", max_id);
                    int max_lleft = str.IndexOf("(", max_left + 1);

                    if (max_lleft == -1 || max_lleft > max_right)
                    {
                        string str_max = str.Substring(max_id, max_right - max_id + 1);
                        string strfield = str.Substring(max_left + 1, max_right - max_left - 1).Trim();
                        _index = _index + 1;
                        strsql.Append("string _max_1_" + _index + "=" + "_OleDB.max(" + strfield + ");\n");
                        namelist.Add("max_1_" + _index);
                        str = str.Replace(str_max, " _max_1_" + _index + " ");
                        //ChargeSQL(str);
                    }
                }

                int min_id = str.ToLower().IndexOf(" min ");
                if (min_id != -1)
                {
                    int min_left = str.IndexOf("(", min_id);
                    int min_right = str.IndexOf(")", min_id);
                    int min_lleft = str.IndexOf("(", min_left + 1);

                    if (min_lleft == -1 || min_lleft > min_right)
                    {
                        string str_min = str.Substring(min_id, min_right - min_id + 1);
                        string strfield = str.Substring(min_left + 1, min_right - min_left - 1).Trim();
                        _index = _index + 1;
                        strsql.Append("string _min_1_" + _index + "=" + "_OleDB.min(" + strfield + ");\n");
                        namelist.Add("min_1_" + _index);
                        str = str.Replace(str_min, " _min_1_" + _index + " ");
                        //ChargeSQL(str);
                    }
                }


                int value_id = str.ToLower().IndexOf(" value ");
                if (value_id != -1)
                {
                    int value_left = str.IndexOf("(", value_id);
                    int value_right = str.IndexOf(")", value_id);

                    int value_lleft = str.IndexOf("(", value_left + 1);

                    if (value_lleft == -1 || value_lleft > value_right)
                    {
                        string str_value = str.Substring(value_id, value_right - value_id + 1);
                        string fieldtype = str_value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("(", "").ToLower().Replace("value", "").Trim();
                        string strtype = str_value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1].Replace(")", "").Trim();
                        _index = _index + 1;
                        strsql.Append("string value_" + _index + "=" + "_OleDB.Value(" + fieldtype + "," + "\"" + strtype + "\");\n");
                        namelist.Add("value_" + _index);
                        str = str.Replace(str_value, " value_" + _index + " ");
                        //ChargeSQL(str);
                    }
                }

                if (str == basestr1)
                {

                    int gs_left = str.IndexOf("(");
                    str= getGS(str, gs_left);

                    File.AppendAllText("log.txt", strsql.ToString(), Encoding.Default);
                    File.AppendAllText("log.txt", "\n\n", Encoding.Default);
                    File.AppendAllText("log.txt", str, Encoding.Default);
                    File.AppendAllText("log.txt", "\n\n--------------------------------------------\n\n", Encoding.Default);
                    ChargeSQL(str);
                }
                else
                {
                    File.AppendAllText("log.txt", strsql.ToString(), Encoding.Default);
                    File.AppendAllText("log.txt", "\n\n", Encoding.Default);
                    File.AppendAllText("log.txt", str, Encoding.Default);
                    File.AppendAllText("log.txt", "\n\n--------------------------------------------\n\n", Encoding.Default);
                    ChargeSQL(str);
                }

            }
            else
            {
                File.AppendAllText("log.txt", strsql.ToString(), Encoding.Default);
                File.AppendAllText("log.txt", "\n\n", Encoding.Default);
                File.AppendAllText("log.txt", str, Encoding.Default);
                File.AppendAllText("log.txt", "\n\n--------------------------------------------\n\n", Encoding.Default);
                ChargeSQL(str);
            }
        }

        private string getTableName(string str,int id)
        {
            return null;
        }

        private string getGS(string str,int gs_left)
        {
           
            int gs_right = str.IndexOf(")");
            int gs_lleft = str.IndexOf("(", gs_left + 1);

            if (gs_lleft != -1)
            {
                if (gs_lleft > gs_right)
                {
                    string str_in = str.Substring(gs_left, gs_right - gs_left + 1);
                    _index = _index + 1;
                    strsql.Append("string _gs_1_"+_index + "=" + str_in + ";\n");

                    namelist.Add("_gs_1_"+_index);
                    str = str.Replace(str_in, " _gs_1_"+_index+" ");
                    //ChargeSQL(str);
                    //return str;
                }
                else
                {
                    str = getGS(str, gs_lleft);
                }
            }
            else
            {
                string str_in = str.Substring(gs_left, gs_right - gs_left + 1);
                _index = _index + 1;
                strsql.Append("string _gs_1_"+_index + "=" + str_in + ";\n");

                namelist.Add("_gs_1_"+_index);
                str = str.Replace(str_in, " _gs_1_"+_index+" ");
            }

            return str;
             
        }


        private void bt_charge_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbin1.Checked)
                {
                   string[] strs= this.rtb_sql.Text.ToLower().Split(new string[] { "from " },StringSplitOptions.RemoveEmptyEntries);
                   if (strs.Length >= 2)
                   {
                       _index = 0;
                       __index = 0;
                       EntityConfig.BindConfig();
                       EntityConfig.ReadXML();
                       strsql = new StringBuilder();
                       namelist.Clear();
                       this.ChargeSQL(this.rtb_sql.Text);
                       this.rtb_dal.Text = strsql.ToString();
                   }
                   else
                   {
                       MessageBox.Show("请输入完整的SQL语句");
                   }
                }
                else if (rbout1.Checked)
                {
                    //ClassDal cd = new ClassDal();
                    //this.rtb_dal.Text = cd.GetDebugSQL();
                    //if (File.Exists("DalSQL.dll"))
                    //{
                    //    File.Delete("DalSQL.dll");
                    //}
                    Compiler.CompilerCode(this.rtb_sql.Text);

                    AppDomainSetup ads = new AppDomainSetup();
                    AppDomain ad = AppDomain.CreateDomain("dalsql", null, ads);

                    IDalSQL ids = (HIS.SYSTEM.Core.IDalSQL)ad.Load(Compiler.CpDll).CreateInstance("ClassDal");
                    this.rtb_dal.Text = ids.GetReleaseSQL();

                    AppDomain.Unload(ad);

                }
                else if (rbout2.Checked)
                {
                    //if (File.Exists("DalSQL.dll"))
                    //{
                    //    File.Delete("DalSQL.dll");
                    //}

                    Compiler.CompilerCode(this.rtb_sql.Text);

                    AppDomainSetup ads = new AppDomainSetup();
                    AppDomain ad = AppDomain.CreateDomain("dalsql", null, ads);


                    IDalSQL ids = (HIS.SYSTEM.Core.IDalSQL)ad.Load(Compiler.CpDll).CreateInstance("ClassDal");
                    this.rtb_dal.Text = ids.GetDebugSQL();

                    AppDomain.Unload(ad);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void rbin2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbin2.Checked)
            {
                this.groupBox2.Visible = true;
            }
            else
            {
                this.groupBox2.Visible = false;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("DelDalSQL.bat");
            }
            catch
            {
            }
        }

        private void 执行XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HIS.SYSTEM.DatabaseAccessLayer.OleDB oledb = new HIS.SYSTEM.DatabaseAccessLayer.OleDB();
            DataTable dt= oledb.GetDataTable(this.rtb_dal.Text);
            if (dt != null)
            {
                FrmData fd = new FrmData(dt);
                fd.ShowDialog();
            }
        }
    }
}
