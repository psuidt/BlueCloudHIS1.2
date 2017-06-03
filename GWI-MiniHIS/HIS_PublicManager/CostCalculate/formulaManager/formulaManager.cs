using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace HIS_PublicManager.formulaManager
{
    public class formulaManager
    {
        private string _tablename;
        DataSet ds = null;

        List<formulaValue> fvlist = null;
        formulaResult fResult = null;
        public List<formulaSysVar> fsvlist = null;

        public void LoadData()
        {
            ds = new DataSet();
            fvlist = new List<formulaValue>();
            fResult = new formulaResult();
            fsvlist = new List<formulaSysVar>();

            string filename = "formulaConfig.xml";
            if (File.Exists(filename))
            {
                ds.Tables.Clear();
                ds.ReadXml(filename);
            }
            else
                throw new Exception("公式配置文件不存在！");
        }

        public DataTable ChangedData(string value)
        {
            fvlist.Clear();
            fsvlist.Clear();

            _tablename = "formulaConfig" + value;

            if (ds.Tables.Contains(_tablename))
            {
                return ds.Tables[_tablename];
            }
            else
            {
                return null;
            }           
        }

        public DataTable Preview()
        {

            DataTable dtvalue = ArrangCalculate();

            Calculate(dtvalue);

            return dtvalue;

        }

        public DataTable ArrangCalculate()
        {
            DataTable dtvalue = ds.Tables[_tablename].Copy();

            for (int row = 0; row < dtvalue.Rows.Count; row++)
            {
                for (int col = 0; col < dtvalue.Columns.Count; col++)
                {
                    string value = dtvalue.Rows[row][col].ToString().Trim();
                    string[] strvars = value.Split(new char[] { '{', '}' });
                    if (strvars.Length > 1)
                    {
                        formulaSysVar fsv = new formulaSysVar();
                        fsv.Col = col;
                        fsv.Row = row;
                        string[] strs = strvars[1].Split(new char[] { '=' });
                        fsv.name = strs[0];
                        //dtvalue.Rows[row][col] = [1];
                        fsv.value = strs[1];
                        fsvlist.Add(fsv);
                    }
                    strvars = value.Split(new char[] { '[', ']' });
                    if (strvars.Length > 1)
                    {

                        if (strvars[0].Trim() == "结果=")
                        {
                            strvars[0] = "";
                            fResult.Col = col;
                            fResult.Row = row;
                        }

                        formulaValue fv = new formulaValue();
                        fv.Col = col;
                        fv.Row = row;
                        List<formulaField> fflist = new List<formulaField>();
                        if (strvars.Length < 4)
                        {
                            formulaField ff = new formulaField();
                            ff.formu = "+";
                            string[] ffstr = strvars[1].Split(new char[] { '|' });
                            ff.Col = Convert.ToInt32(ffstr[0].Substring(1, ffstr[0].Length - 1).Trim());
                            ff.Row = Convert.ToInt32(ffstr[1].Trim()) - 1;
                            fflist.Add(ff);
                        }
                        else
                        {
                            formulaField ff = new formulaField();
                            ff.formu = "+";
                            string[] ffstr = strvars[1].Split(new char[] { '|' });
                            ff.Col = Convert.ToInt32(ffstr[0].Substring(1, ffstr[0].Length - 1).Trim());
                            ff.Row = Convert.ToInt32(ffstr[1].Trim()) - 1;
                            fflist.Add(ff);

                            for (int i = 0; i < (strvars.Length - 3) / 4; i++)
                            {
                                ff = new formulaField();
                                ff.formu = strvars[3 + (i * 4)].Trim();
                                ffstr = strvars[5 + (i * 4)].Split(new char[] { '|' });
                                ff.Col = Convert.ToInt32(ffstr[0].Substring(1, ffstr[0].Length - 1).Trim());
                                ff.Row = Convert.ToInt32(ffstr[1].Trim()) - 1;
                                fflist.Add(ff);
                            }
                        }
                        fv.filed = fflist;
                        fvlist.Add(fv);
                    }

                }
            }

            return dtvalue;

        }

        public void Calculate(DataTable dt,bool b)
        {
            DataTable dtvalue = dt;

            if (b)
            {
                for (int i = 0; i < fsvlist.Count; i++)
                {
                    dtvalue.Rows[fsvlist[i].Row][fsvlist[i].Col] = fsvlist[i].value;
                }
            }
            for (int i = 0; i < fvlist.Count; i++)
            {
                decimal dec = 0;
                for (int j = 0; j < fvlist[i].filed.Count; j++)
                {
                    switch (fvlist[i].filed[j].formu)
                    {
                        case "+":
                            dec += Convert.ToDecimal(dtvalue.Rows[fvlist[i].filed[j].Row][fvlist[i].filed[j].Col]);
                            break;
                        case "-":
                            dec -= Convert.ToDecimal(dtvalue.Rows[fvlist[i].filed[j].Row][fvlist[i].filed[j].Col]);
                            break;
                        case "*":
                            dec *= Convert.ToDecimal(dtvalue.Rows[fvlist[i].filed[j].Row][fvlist[i].filed[j].Col]);
                            break;
                        case "/":
                            dec /= Convert.ToDecimal(dtvalue.Rows[fvlist[i].filed[j].Row][fvlist[i].filed[j].Col]);
                            break;

                    }
                }
                dtvalue.Rows[fvlist[i].Row][fvlist[i].Col] = dec.ToString("0.00");
            }
        }

        public void Calculate(DataTable dt)
        {
            Calculate(dt, true);
        }

        public void SetSysVar(int col, int row, string name, string text)
        {
            ds.Tables[_tablename].Rows[row][col] = "{" + name + "=" + text + "}";
        }

        public void AddRow()
        {
            DataRow row = ds.Tables[_tablename].NewRow();
            ds.Tables[_tablename].Rows.Add(row);
        }

        public void AddCol()
        {
           

            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "C" + ds.Tables[_tablename].Columns.Count.ToString();
            ds.Tables[_tablename].Columns.Add(column);
        }

        public void DelCol()
        {
            if (ds.Tables[_tablename].Columns.Count != 0)
                ds.Tables[_tablename].Columns.RemoveAt(ds.Tables[_tablename].Columns.Count - 1);
        }

        public void DelRow()
        {
            if (ds.Tables[_tablename].Rows.Count != 0)
                ds.Tables[_tablename].Rows.RemoveAt(ds.Tables[_tablename].Rows.Count - 1);
        }

        public void SaveConfig()
        {
            string filename = "formulaConfig.xml";
            this.ds.DataSetName = "formulaConfig";

            ds.WriteXml(filename, XmlWriteMode.WriteSchema);

        }

        public string GetResult(DataTable dt)
        {
            return dt.Rows[fResult.Row][fResult.Col].ToString();
        }
    }
}
