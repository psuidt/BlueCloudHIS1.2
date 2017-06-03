using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.Public_BLL
{
    public enum DataTypeName
    {
        表,视图,存储过程,索引,函数,触发器
    }

    public class OP_DBClient : BaseBLL
    {
        /// <summary>
        /// 得到数据库类型名
        /// </summary>
        /// <param name="dtn">类型名</param>
        /// <returns></returns>
        public static DataTable GetDbData(DataTypeName dtn)
        {
            DataTable dt = null;
            switch (dtn)
            {
                case DataTypeName.表:
                    dt = oleDb.GetDataTable("select tabschema,tabname from syscat.tables where tabschema in('DB2INST1','DB2INST2','DB2INST3') and type='T' order by tabname ");
                    break;
                case DataTypeName.触发器:
                    dt = oleDb.GetDataTable("select trigname from syscat.triggers");
                    break;
                case DataTypeName.存储过程:
                    dt = oleDb.GetDataTable("select procschema,procname from syscat.procedures where procschema in('DB2INST1','DB2INST2','DB2INST3') order by procname");
                    break;
                case DataTypeName.函数:
                    dt = oleDb.GetDataTable("select funcschema,funcname from syscat.functions where funcschema in('DB2INST1','DB2INST2','DB2INST3') order by funcname");
                    break;
                case DataTypeName.视图:
                    dt = oleDb.GetDataTable("select viewschema,viewname from syscat.views where viewschema in('DB2INST1','DB2INST2','DB2INST3') order by viewname");
                    break;
                case DataTypeName.索引:
                    dt = oleDb.GetDataTable("select indschema,indname from syscat.indexes where indschema in('DB2INST1','DB2INST2','DB2INST3') order by indname");
                    break;
            }
            return dt;
        }

        public static DataTable GetDbColmData(string tablename)
        {
            DataTable dt = null;
            dt = oleDb.GetDataTable("select colname,typename,identity from SYScat.COLUMNS where tabschema='DB2INST2' and tabname = '" + tablename + "' order by colno");
            return dt;
        }
    }

    public class Datashow:BaseBLL
    {
        private static DataSet ds = null;

        public static bool ErrBool = false;
        public static string ErrStr = null;
        public static event RuningEventHandler Runing;
        public delegate void RuningEventHandler(string sql, int allcount, int nowcount);

        public static DataSet OutData(string sqlstr)
        {
            string[] strArray = OutSql(sqlstr);
            int length = strArray.Length;
            try
            {
                ds = new DataSet();

                for (int i = 0; i < length; i++)
                {
                    Runing(strArray[i], length, i);
                    if (!(strArray[i].Trim() != ""))
                    {
                        continue;
                    }
                    if ((strArray[i].Trim().Length > 2) && (strArray[i].Trim().Substring(0, 2) == "--"))
                    {
                        continue;
                    }
                    int index = strArray[i].Trim().IndexOf(" ");
                    string str = strArray[i].Trim().Substring(0, index).Trim().ToUpper();
                    DataTable dataTable = new DataTable(); ;

                    switch (str)
                    {
                        case "CALL":
                            int num4 = strArray[i].Trim().IndexOf("(");
                            string storeProcedureName = strArray[i].Trim().Substring(index, num4 - index).Trim();
                            int num5 = strArray[i].Trim().IndexOf(")");
                            string[] strArray2 = strArray[i].Trim().Substring(num4 + 1, (num5 - num4) - 1).Split(new char[] { ',' });
                            HIS.SYSTEM.DatabaseAccessLayer.ParameterEx[] parameters = new HIS.SYSTEM.DatabaseAccessLayer.ParameterEx[strArray2.Length];
                            for (int j = 0; j < parameters.Length; j++)
                            {
                                if (strArray2[j].Trim() == "?")
                                {
                                    parameters[j].Value = null;
                                    parameters[j].ParaDirection = ParameterDirection.Output;
                                    parameters[j].ParaSize = 100;
                                }
                                else
                                {
                                    parameters[j].Value = strArray2[j].Trim();
                                }
                            }
                            dataTable = oleDb.GetDataTable(storeProcedureName, parameters, 90);
                           
                            dataTable.TableName = "Procedure[" + i.ToString() + "]";
                            for (int j = 0; j < parameters.Length; j++)
                            {
                                if (parameters[j].ParaDirection!=null && parameters[j].ParaDirection.Equals(ParameterDirection.Output))
                                {
                                    ErrStr += "\n" + dataTable.TableName + ":" + parameters[j].Value.ToString();
                                }
                            }
                             
                            break;
                        case "SELECT":
                            dataTable = oleDb.GetDataTable(strArray[i]);
                            dataTable.TableName = "SELECT["+i.ToString()+"]";
                            break;
                        case "UPDATE":
                            oleDb.DoCommand(strArray[i]);
                            dataTable.TableName = "UPDATE[" + i.ToString() + "]";
                            break;
                        case "DELETE":
                            oleDb.DoCommand(strArray[i]);
                            dataTable.TableName = "DELETE[" + i.ToString() + "]";
                            break;
                        case "INSERT":
                            oleDb.DoCommand(strArray[i]);
                            dataTable.TableName = "INSERT[" + i.ToString() + "]";
                            break;
                    }

                    ds.Tables.Add(dataTable);
                }

            }
            catch (Exception exception)
            {
                ErrStr = exception.Message;
                ErrBool = true;
            }
            return ds;
        }

        public static string[] OutSql(string sqlstr)
        {
            return sqlstr.Split(new char[] { ';' });
        }
    }
}
