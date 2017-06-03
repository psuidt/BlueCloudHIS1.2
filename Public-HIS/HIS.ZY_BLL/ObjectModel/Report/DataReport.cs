// File:    DataReport.cs
// Author:  Administrator
// Created: 2009年9月3日星期四 11:32:45
// Purpose: Definition of Class DataReport

using System;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.Core;

namespace HIS.ZY_BLL.Report
{
    public class DataReport
    {
        protected OperationDataList operationList;
        protected DataSet baseDataSet;

        protected RelationalDatabase oleDb;

        public DataReport()
        {
            oleDb = BaseBLL.oleDb;
            operationList = new OperationDataList();
        }

        public DataReport(RelationalDatabase _oleDb)
        {
            oleDb = _oleDb;
        }
        

        /// <summary>
        /// 取名称
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        protected string GetName(string TableName, string Code)
        {
            DataRow[] drs = null;
            if (Code == "")
                return "<未指定>";
            if (TableName == "BASE_EMPLOYEE_PROPERTY" || TableName == "BASE_DEPT_PROPERTY")
                drs = baseDataSet.Tables[TableName].Select("code=" + Code + "");
            else
                drs = baseDataSet.Tables[TableName].Select("code='" + Code + "'");
            if (drs.Length == 0)
            {
                return "";
            }
            else
            {
                return drs[0]["NAME"].ToString();
            }
        }

        /// <summary>
        /// 与大项目关联的项目名
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="BigCode"></param>
        /// <returns></returns>
        protected string GetItemName(string TableName, string BigCode)
        {
            try
            {
                
                DataRow[] drs = null;
                drs = baseDataSet.Tables["BASE_STAT_ITEM"].Select("code='" + BigCode+"'");//Convert(code, 'System.Int32')
                if (drs.Length == 0)
                {
                    return "";
                }
                else
                {
                    string strWhere = null;
                    if ("BASE_STAT_ZYFP" == TableName)
                        strWhere = "code='" + drs[0]["ZYFP_CODE"].ToString()+"'";

                    else if ("BASE_STAT_ZYKJ" == TableName)
                        strWhere = "code='" + drs[0]["ZYKJ_CODE"].ToString()+"'";

                    else if ("BASE_STAT_ZYYB" == TableName)
                        strWhere = "code='" + drs[0]["ZYYB_CODE"].ToString()+"'";

                    else if ("BASE_STAT_HS" == TableName)
                        strWhere = "code='" + drs[0]["HS_CODE"].ToString()+"'";
                    else if ("BASE_STAT_ITEM" == TableName)
                    {
                        strWhere = "code='" + BigCode + "'";
                    }
                    drs = baseDataSet.Tables[TableName].Select(strWhere);
                    if (drs.Length == 0)
                    {
                        return "";
                    }
                    else
                    {
                        return drs[0]["NAME"].ToString();
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 加载基础数据
        /// </summary>
        public void LoadBaseData()
        {
            baseDataSet = new DataSet();
            DataTable dt = null;
            //BASE_EMPLOYEE_PROPERTY
            dt = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_EMPLOYEE_PROPERTY").GetList("", "EMPLOYEE_ID as CODE", "NAME");
            dt.TableName = "BASE_EMPLOYEE_PROPERTY";
            baseDataSet.Tables.Add(dt);
            //BASE_DEPT_PROPERTY
            dt = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_DEPT_PROPERTY").GetList("", "DEPT_ID  as CODE", "NAME");
            dt.TableName = "BASE_DEPT_PROPERTY";
            baseDataSet.Tables.Add(dt);
            //
            dt = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_PATIENTTYPE").GetList("", "CODE", "NAME");
            dt.TableName = "BASE_PATIENTTYPE";
            baseDataSet.Tables.Add(dt);
            //
            dt = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_STAT_ITEM").GetList("", "CODE", "ITEM_NAME  as NAME", "ZYFP_CODE", "ZYKJ_CODE", "ZYYB_CODE", "HS_CODE");
            dt.TableName = "BASE_STAT_ITEM";
            baseDataSet.Tables.Add(dt);
            //
            dt = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_STAT_HS").GetList("", "CODE", "ITEM_NAME  as NAME");
            dt.TableName = "BASE_STAT_HS";
            baseDataSet.Tables.Add(dt);
            //
            dt = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_STAT_ZYFP").GetList("", "CODE","ITEM_NAME as NAME");
            dt.TableName = "BASE_STAT_ZYFP";
            baseDataSet.Tables.Add(dt);
            //
            dt = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_STAT_ZYKJ").GetList("", "CODE", "ITEM_NAME  as NAME");
            dt.TableName = "BASE_STAT_ZYKJ";
            baseDataSet.Tables.Add(dt);
            //
            dt = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_STAT_ZYYB").GetList("", "CODE","ITEM_NAME  as NAME");
            dt.TableName = "BASE_STAT_ZYYB";
            baseDataSet.Tables.Add(dt);
            //
            dt = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_WORK_UNIT").GetList("", "CODE","NAME");
            dt.TableName = "BASE_WORK_UNIT";
            baseDataSet.Tables.Add(dt);
        }

        protected decimal Dbnull(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(obj);
        }

        protected string RetureName(Object obj, Object name)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return name.ToString();
            }
            if (obj.ToString().IndexOf(name.ToString()) != -1)
            {
                return obj.ToString();
            }
            else
            {
                return obj.ToString() + "|" + name;
            }
        }
    }
}
