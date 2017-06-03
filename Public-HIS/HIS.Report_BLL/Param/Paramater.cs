using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.BLL;
using System.Data;

namespace HIS.Report_BLL
{
   public class Paramater:HIS.Model.BASE_REPORT_PARAMETER
    {
        //HIS.SYSTEM.DatabaseAccessLayer.OleDB oledb=new HIS.SYSTEM.DatabaseAccessLayer.OleDB();
     
       private object _objvalue;
       /// <summary>
       /// 入参值
       /// </summary>
       public object objvalue
       {
           get { return _objvalue; }
           set { _objvalue = value; }
       }

       private object _objvalueCN;
       public object objvalueCN
       {
           get { return _objvalueCN; }
           set { _objvalueCN = value; }
       }
       //初始化参数
       public void InitializeParamToReport(string procedurename)
       {
           string strsql = "select * from SYSIBM.SYSROUTINEPARMS where routinename='" + procedurename + "'order by ordinal";
           DataTable dt=HIS.SYSTEM.Core.BaseBLL.oleDb.GetDataTable(strsql);
           strsql=HIS.BLL.Tables.base_report_parameter.REPORT_ID+ " ="+this.REPORT_ID+"";
           HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT_PARAMETER>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Delete(strsql);
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               this.FOREIGNER_FILTER_SQL = "";
               this.PARAMETER = dt.Rows[i]["parmname"].ToString().Trim();
               this.PARAMETER_CN = dt.Rows[i]["parmname"].ToString().Trim();
               this.PARAMETER_TYPE =dt.Rows[i]["rowtype"].ToString().Trim() == "P" ? "IN" : "OUT";
               if (dt.Rows[i]["typename"].ToString().IndexOf("INT", 0) >= 0)
               {
                   this.PARAMDATATYPE = 1;
               }
               else if (dt.Rows[i]["typename"].ToString().IndexOf("DATE", 0) >= 0 || dt.Rows[i]["typename"].ToString().IndexOf("TIME", 0) >= 0)
               {
                   this.PARAMDATATYPE = 2;
                   this.UIC_TYPE = 3;
               }
               else
               {
                   this.PARAMDATATYPE = 0;
               }                     
               this.DATALENGTH =Convert.ToInt32( dt.Rows[i]["length"]==null?0:dt.Rows[i]["length"]);
               if ( this.PARAMETER == "V_BTIME" || this.PARAMETER == "V_ETIME")
               {
                   this.UIC_TYPE = 3;
                   this.PARAMDATATYPE = 2;
                   if (this.PARAMETER == "V_BTIME")
                   {
                       this.PARAMETER_CN = "开始日期";
                   }
                   else
                   {
                       this.PARAMETER_CN = "结束日期";
                   }
               }
              else if (this.PARAMETER == "V_CURRDEPTID" || this.PARAMETER == "V_CURREMPLOYEEID")
               {
                   this.UIC_TYPE = 0;
                   this.PARAMDATATYPE = 1;
                   if (this.PARAMETER == "V_CURRDEPTID")
                   {
                       this.PARAMETER_CN = "科室";
                   }
                   if (this.PARAMETER == "V_CURREMPLOYEEID")
                   {
                       this.PARAMETER_CN = "人员";
                   }

               }
             else  if (this.PARAMETER == "V_ALLDEPTID" || this.PARAMETER == "V_ALLDOCTORID")
               {
                   this.UIC_TYPE = 4;
                   this.PARAMDATATYPE = 1;               
                   if (this.PARAMETER == "V_ALLDEPTID")
                   {
                       this.FOREIGNER_FILTER_SQL = " select dept_id as id,name,py_code from BASE_DEPT_PROPERTY";
                       this.PARAMETER_CN = "选择科室";
                   }
                   else
                   {
                       this.FOREIGNER_FILTER_SQL = " select EMPLOYEE_ID as id ,name,py_code from base_employee_property where EMPLOYEE_ID in (select EMPLOYEE_ID from base_role_doctor) ";
                       this.PARAMETER_CN = "选择医生";
                   }                   
               }
               else if (this.PARAMETER == "V_YFDEPT")
               {
                   this.UIC_TYPE = 4;
                   this.PARAMDATATYPE = 1;
                   this.PARAMETER_CN = "选择药房";
                   this.FOREIGNER_FILTER_SQL = " select b.dept_id as id,b.name,b.py_code from  YP_DEPTDIC a left outer join BASE_DEPT_PROPERTY b on a.deptid=b.dept_id where a.depttype1= ''药房'' ";

               }
               else if (this.PARAMETER == "V_YPDEPT")
               {
                   this.UIC_TYPE = 4;
                   this.PARAMDATATYPE = 1;
                   this.PARAMETER_CN = "选择药房药库";
                   this.FOREIGNER_FILTER_SQL = " select b.dept_id as id,b.name,b.py_code from  YP_DEPTDIC a left outer join BASE_DEPT_PROPERTY b on a.deptid=b.dept_id";

               }
               else if (this.PARAMETER == "V_YKDEPT")
               {
                   this.UIC_TYPE = 4;
                   this.PARAMDATATYPE = 1;
                   this.PARAMETER_CN = "选择药库";
                   this.FOREIGNER_FILTER_SQL = " select b.dept_id as id,b.name,b.py_code from  YP_DEPTDIC a left outer join BASE_DEPT_PROPERTY b on a.deptid=b.dept_id where a.depttype1= ''药库''";

               }
               else if (this.PARAMETER == "V_ALLCHARGER")
               {
                   this.UIC_TYPE = 4;
                   this.PARAMDATATYPE = 1;
                   this.FOREIGNER_FILTER_SQL = " select  EMPLOYEE_ID as id ,name,py_code  from  BASE_EMPLOYEE_PROPERTY  where EMPLOYEE_ID not in (select EMPLOYEE_ID from base_role_doctor) and EMPLOYEE_ID not in (select EMPLOYEE_ID from BASE_ROLE_NURSE)";
                   this.PARAMETER_CN = "选择收费员";
               }
               else if (this.PARAMETER == "V_ITEMDRUG")
               {
                   this.UIC_TYPE = 4;
                   this.PARAMDATATYPE = 1;
                   this.FOREIGNER_FILTER_SQL = " select * from VI_RPT01";
                   this.PARAMETER_CN = "选择药品项目名称";
               }
               else if (this.PARAMETER == "V_DRUG")
               {
                   this.UIC_TYPE = 4;
                   this.PARAMDATATYPE = 1;
                   this.FOREIGNER_FILTER_SQL = " select * from VI_RPT01 where drug_flag=1";
                   this.PARAMETER_CN = "选择药品名称";
               }
               else if (this.PARAMETER == "V_ITEM")
               {
                   this.UIC_TYPE = 4;
                   this.PARAMDATATYPE = 1;
                   this.FOREIGNER_FILTER_SQL = " select * from VI_RPT01 where drug_flag=0";
                   this.PARAMETER_CN = "选择项目名称";
               }
               else if (this.PARAMETER == "V_STATTYPE")
               {
                   this.UIC_TYPE = 1;
                   this.PARAMDATATYPE = 1;
                   this.ENUMEID = 1;
                   this.PARAMETER_CN = "统计大类";
               }
               else if (this.PARAMETER == "V_MZDEPT")
               {
                   this.UIC_TYPE = 4;
                   this.PARAMDATATYPE = 1;
                   this.FOREIGNER_FILTER_SQL = " select name,dept_id as id,py_code from  BASE_DEPT_PROPERTY where mz_flag=1";
                   this.PARAMETER_CN = "门诊科室";
               }
               else if (this.PARAMETER == "V_ZYDEPT")
               {
                   this.UIC_TYPE = 4;
                   this.PARAMDATATYPE = 1;
                   this.FOREIGNER_FILTER_SQL = " select name,dept_id as id,py_code from  BASE_DEPT_PROPERTY where zy_flag=1";
                   this.PARAMETER_CN = "住院科室";
               }
               else if (this.PARAMETER == "V_TYPE")
               {
                   this.UIC_TYPE = 2;
                   this.PARAMDATATYPE = 1;
                   this.PARAMETER_CN = "所有";
               }
               else
               {
                   this.UIC_TYPE = 0;
               }
               HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT_PARAMETER>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Add(this);              
           }
       }


       public DataTable GetDataSource(string strsql)
       {
          
           DataTable dt = HIS.SYSTEM.Core.BaseBLL.oleDb.GetDataTable(strsql);
           DataRow dr = dt.NewRow();
           dr["name"] = "全部";
           dr["id"] = -1;
           dr["PY_CODE"] = "QB";
           DataTable dtcopy = dt.Clone();
           dtcopy.Clear();
           dtcopy.Rows.Add(dr.ItemArray);
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               dtcopy.Rows.Add(dt.Rows[i].ItemArray);
           }
           return dtcopy;

          // dt.Rows.Add(dr.ItemArray);
          // return dt;
           
       }

       /// <summary>
       /// 测试SQL是否正确
       /// </summary>
       /// <returns></returns>
       public bool TestSQL(string strsql)
       {
           try
           {
               GetDataSource(strsql);
               return true;
           }
           catch (Exception err)
           {
               throw err;
           }
       }
        public int addParamter()
        {
            string strwhere = HIS.BLL.Tables.base_report_parameter.PARAMETER + "='" + this.PARAMETER + "' and  " + HIS.BLL.Tables.base_report_parameter.REPORT_ID + "=" + this.REPORT_ID;
            if (HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT_PARAMETER>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Exists(strwhere)) 
                return 0;
          object obj=  HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT_PARAMETER>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Add(this);
          return obj == null ? 0 : (int)obj;
        }

        
        public void UpateParamter()
        {
            try
            {
               this.FOREIGNER_FILTER_SQL= this.FOREIGNER_FILTER_SQL.Replace("'", "''");//update by heyan 2010.12.27 字符串更新报错
                HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT_PARAMETER>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Update(this);
            }
            catch(Exception err) 
            {
                throw new Exception(err.Message);
            }
        }
       
    }

   public class ParamProcess : HIS.SYSTEM.Core.BaseBLL
   {
       public DataTable getParamlist(int Reportid)
       {
           //string strWhere = HIS.BLL.Tables.base_report_parameter.REPORT_ID + oleDb.EuqalTo() + Reportid;
           //return HIS.SYSTEM.Core.BindEntity<HIS.BLL.Tables.base_report_parameter>.CreateInstanceDAL(oleDb).GetList(strWhere);
           string strsql = @" select a.*,(case when a.PARAMDATATYPE=0 then '字符'  when a.PARAMDATATYPE=1 then '数字'  when a.PARAMDATATYPE=2 then '日期'end) as datatypename 
                              from base_report_parameter a  where a.report_id="+Reportid+" order by PARAMETERID";
           return oleDb.GetDataTable(strsql);
       }

       /// <summary>
       /// 获取存储过程参数 
       /// </summary>
       /// <param name="Reportid"></param>
       /// <returns></returns>
       public List<Paramater> getPara(int Reportid)
       {
           List<HIS.Model.BASE_REPORT_PARAMETER> _paramlist;
           List<Paramater> newparalist = new List<Paramater>();
           Paramater onepara =null;

           string strWhere = HIS.BLL.Tables.base_report_parameter.REPORT_ID + oleDb.EuqalTo() + Reportid + oleDb.And() + HIS.BLL.Tables.base_report_parameter.PARAMETER_TYPE + oleDb.In() + "('IN','OUT')" + " order by PARAMETERID";
          _paramlist = HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT_PARAMETER>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
          if (_paramlist.Count > 0)
          {
              foreach (HIS.Model.BASE_REPORT_PARAMETER mode in _paramlist)
              {
                  onepara = new Paramater();
                  onepara.PARAMETER = mode.PARAMETER;
                  onepara.PARAMETER_CN = mode.PARAMETER_CN;
                  onepara.PARAMETER_TYPE = mode.PARAMETER_TYPE;
                  onepara.PARAMDATATYPE = mode.PARAMDATATYPE;
                  onepara.REPORT_ID = mode.REPORT_ID;
                  onepara.ENUMEID = mode.ENUMEID;
                  onepara.PARAMETERID = mode.PARAMETERID;
                  onepara.FOREIGNER_FIELD_CN_NAME = mode.FOREIGNER_FIELD_CN_NAME;
                  onepara.FOREIGNER_FIELD_DB_NAME = mode.FOREIGNER_FIELD_DB_NAME;
                  onepara.FOREIGNER_TABLE = mode.FOREIGNER_TABLE;
                  onepara.DATALENGTH = mode.DATALENGTH;
                  onepara.HEIGHT = mode.HEIGHT;
                  onepara.UIC_TYPE = mode.UIC_TYPE;
                  onepara.UIC_X_LOCA = mode.UIC_X_LOCA;
                  onepara.UIC_Y_LOCA = mode.UIC_Y_LOCA;
                  onepara.WIDTH = mode.WIDTH;
                  onepara.FOREIGNER_FILTER_SQL = mode.FOREIGNER_FILTER_SQL;
                  newparalist.Add(onepara);
              }

          }
         

          return newparalist;



       }


       public DataTable Getparalist_all(DataTable Groupid)
       {
           if (Groupid.Rows.Count < 0)
               return null;

           StringBuilder Strwhere = new StringBuilder();
           Strwhere.Append("select * from BASE_REPORT_PARAMETER  a where PARAMETER_TYPE in ('IN','OUT') and  REPORT_ID in (select REPORT_ID from BASE_GROUP_REPORT where BASE_GROUP_REPORT.GROUP_ID in (");
           string SQl = "";

           for (int index = 0; index < Groupid.Rows.Count; index++)
           {
               Strwhere.Append(Groupid.Rows[index][0]);
               if (index < Groupid.Rows.Count - 1)
                   Strwhere.Append(",");
           }
           Strwhere.Append("))");
           SQl = Strwhere.ToString();

           object obj = oleDb.GetDataTable(SQl);
           if (obj != null)
               return (DataTable)obj;
           else
               return null;
       }

       

       /// <summary>
       /// 获取存储过程参数(IN) 
       /// </summary>
       /// <param name="Reportid"></param>
       /// <returns></returns>
       public List<Paramater> getParaIN(int Reportid)
       {
           List<HIS.Model.BASE_REPORT_PARAMETER> _paramlist;
           List<Paramater> newparalist = new List<Paramater>();
           Paramater onepara = null;

           string strWhere = HIS.BLL.Tables.base_report_parameter.REPORT_ID + oleDb.EuqalTo() + Reportid + oleDb.And() + HIS.BLL.Tables.base_report_parameter.PARAMETER_TYPE + oleDb.EuqalTo() + "'IN'";
           _paramlist = HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT_PARAMETER>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
           if (_paramlist.Count > 0)
           {
               foreach (HIS.Model.BASE_REPORT_PARAMETER mode in _paramlist)
               {
                   onepara = new Paramater();
                   onepara.PARAMETER = mode.PARAMETER;
                   onepara.PARAMETER_CN = mode.PARAMETER_CN;
                   onepara.PARAMETER_TYPE = mode.PARAMETER_TYPE;
                   onepara.PARAMDATATYPE = mode.PARAMDATATYPE;
                   onepara.REPORT_ID = mode.REPORT_ID;
                   onepara.ENUMEID = mode.ENUMEID;
                   onepara.PARAMETERID = mode.PARAMETERID;
                   onepara.FOREIGNER_FIELD_CN_NAME = mode.FOREIGNER_FIELD_CN_NAME;
                   onepara.FOREIGNER_FIELD_DB_NAME = mode.FOREIGNER_FIELD_DB_NAME;
                   onepara.FOREIGNER_TABLE = mode.FOREIGNER_TABLE;
                   onepara.DATALENGTH = mode.DATALENGTH;
                   onepara.HEIGHT = mode.HEIGHT;
                   onepara.UIC_TYPE = mode.UIC_TYPE;
                   onepara.UIC_X_LOCA = mode.UIC_X_LOCA;
                   onepara.UIC_Y_LOCA = mode.UIC_Y_LOCA;
                   onepara.WIDTH = mode.WIDTH;
                   onepara.FOREIGNER_FILTER_SQL = mode.FOREIGNER_FILTER_SQL;
                   newparalist.Add(onepara);
               }

           }


           return newparalist;



       }
       /// <summary>
       /// 获取报表写入参数
       /// </summary>
       /// <param name="Reportid"></param>
       /// <returns></returns>
       public List<Paramater> getParaX(int Reportid)
       {
           List<HIS.Model.BASE_REPORT_PARAMETER> _paramlist;
           List<Paramater> newparalist = new List<Paramater>();
           Paramater onepara = null;

           string strWhere = HIS.BLL.Tables.base_report_parameter.REPORT_ID + oleDb.EuqalTo() + Reportid ;
           _paramlist = HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT_PARAMETER>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
           if (_paramlist.Count > 0)
           {
               foreach (HIS.Model.BASE_REPORT_PARAMETER mode in _paramlist)
               {
                   onepara = new Paramater();
                   onepara.PARAMETER = mode.PARAMETER;
                   onepara.PARAMETER_CN = mode.PARAMETER_CN;
                   onepara.PARAMETER_TYPE = mode.PARAMETER_TYPE;
                   onepara.PARAMDATATYPE = mode.PARAMDATATYPE;
                   onepara.REPORT_ID = mode.REPORT_ID;
                   onepara.ENUMEID = mode.ENUMEID;
                   onepara.PARAMETERID = mode.PARAMETERID;
                   onepara.FOREIGNER_FIELD_CN_NAME = mode.FOREIGNER_FIELD_CN_NAME;
                   onepara.FOREIGNER_FIELD_DB_NAME = mode.FOREIGNER_FIELD_DB_NAME;
                   onepara.FOREIGNER_TABLE = mode.FOREIGNER_TABLE;
                   onepara.DATALENGTH = mode.DATALENGTH;
                   onepara.HEIGHT = mode.HEIGHT;
                   onepara.UIC_TYPE = mode.UIC_TYPE;
                   onepara.UIC_X_LOCA = mode.UIC_X_LOCA;
                   onepara.UIC_Y_LOCA = mode.UIC_Y_LOCA;
                   onepara.WIDTH = mode.WIDTH;
                   onepara.FOREIGNER_FILTER_SQL = mode.FOREIGNER_FILTER_SQL;
                   newparalist.Add(onepara);
               }

           }


           return newparalist;



       }

      
       public DataTable getProcedurePara(List<Paramater> paralit,string procedure)
       {
           if (procedure != "")
           {
               HIS.SYSTEM.DatabaseAccessLayer.ParameterEx[] parameters = new HIS.SYSTEM.DatabaseAccessLayer.ParameterEx[paralit.Count];
               for (int index = 0; index < paralit.Count; index++)
               {
                   parameters[index].Text = paralit[index].PARAMETER;
                   if (paralit[index].PARAMDATATYPE == 0)
                       parameters[index].Value = (int)paralit[index].objvalue;

               }
               return oleDb.GetDataTable(procedure, parameters);

           }
           else
               return null;

 
       }

       public void delParamter(int Paraid)
       {
           string strWhere= HIS.BLL.Tables.base_report_parameter.PARAMETERID+oleDb.EuqalTo()+Paraid;
           HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT_PARAMETER>.CreateInstanceDAL(oleDb).Delete(strWhere);
       }

       public DataTable getEnum()
       {
         return   HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_ENUME>.CreateInstanceDAL(oleDb).GetList("");
       }

       public HIS.Model.BASE_ENUME GetEnumSql(int enumid)
       {
           return HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_ENUME>.CreateInstanceDAL(oleDb).GetModel(enumid);
       }

       public DataTable GetEnumOrders(int enumid)
       {
           string strsql = "select name as name,enumvalue as id from base_enumeorder where ENUMEID=" + enumid + "";
           return oleDb.GetDataTable(strsql);
       }

   }
}
