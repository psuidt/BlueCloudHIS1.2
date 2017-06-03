using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using grproLib;

namespace HIS.Report_BLL
{
    public class ReportProcess : HIS.SYSTEM.Core.BaseBLL
    {

        /// <summary>
        /// 获取第一层子结点
        /// </summary>
        /// <returns></returns>
        public List<HIS.Model.BASE_REPORTMASTER> GetReportMaster()
        {
            //string strWhere = "(" + "(" + HIS.BLL.Tables.base_reportmaster.REPORT_TYPE + oleDb.EuqalTo() + 1 + oleDb.And() + HIS.BLL.Tables.base_reportmaster.P_ID + oleDb.EuqalTo() + -1 + oleDb.And() + HIS.BLL.Tables.base_reportmaster.DEIETE_FLAG + oleDb.EuqalTo() + 0 + ")"
            //        + oleDb.Or() +
            //    "(" + HIS.BLL.Tables.base_reportmaster.REPORT_TYPE + oleDb.EuqalTo() + 0 + ")" + oleDb.And() + HIS.BLL.Tables.base_reportmaster.DEIETE_FLAG + oleDb.EuqalTo() + 0 + ")";
            //return BindEntity<HIS.Model.BASE_REPORTMASTER>.CreateInstanceDAL(oleDb).GetListArray(strWhere );
            string strWhere = HIS.BLL.Tables.base_reportmaster.DEIETE_FLAG + oleDb.EuqalTo() + 0+oleDb.And()+HIS.BLL.Tables.base_reportmaster.P_ID+oleDb.EuqalTo()+-1;
            return BindEntity<HIS.Model.BASE_REPORTMASTER>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
        }      

        /// <summary>
        /// 获取节点
        /// </summary>
        /// <param name="reportmasterid"></param>
        /// <returns></returns>
        public List<HIS.Model.BASE_REPORTMASTER> GetMasterList(int reportmasterid)
        {
            string strWhere = HIS.BLL.Tables.base_reportmaster.P_ID + oleDb.EuqalTo() + reportmasterid + oleDb.And() + HIS.BLL.Tables.base_reportmaster.DEIETE_FLAG +
                oleDb.EuqalTo() + 0;
            return BindEntity<HIS.Model.BASE_REPORTMASTER>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
        }


        public List<HIS.Model.BASE_REPORT> GetReportList(int reportmasterid)
        {
            string strWhere = HIS.BLL.Tables.base_report.REPORTMASTER_ID + oleDb.EuqalTo() + reportmasterid + oleDb.And() +
                HIS.BLL.Tables.base_report.DELETE_FLAG + oleDb.EuqalTo() + 0;
            return BindEntity<HIS.Model.BASE_REPORT>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
 
        }
       /// <summary>
       /// 获取报表列表
       /// </summary>
       /// <returns></returns> 
        public DataTable getReportList()
        {
            object obj = HIS.SYSTEM.Core.BindEntity<HIS.BLL.Tables.base_report>.CreateInstanceDAL(oleDb).GetList("");
            if (obj != null)
                return (DataTable)obj;
            else
                return null;
 
        }
        public DataTable getReportList(DataTable Groupid)
        {
            if(Groupid.Rows.Count<0)
                return null;

            StringBuilder Strwhere=new StringBuilder();
            Strwhere.Append("select a.*,b.ISGLOBAL from BASE_REPORT a,BASE_GROUP_REPORT b  where a.REPORT_ID=b.REPORT_ID and b.GROUP_ID in (") ;
            string SQl = "";
           
            for (int index = 0; index < Groupid.Rows.Count; index++)
            {
                Strwhere.Append(Groupid.Rows[index][0]);
                if (index < Groupid.Rows.Count - 1)
                    Strwhere.Append(",");
            }
            Strwhere.Append(")");
            SQl = Strwhere.ToString();
            
            object obj = oleDb.GetDataTable(SQl);
            if (obj != null)
                return (DataTable)obj;
            else
                return null;
 
        }

        public DataTable getReportList(DataTable Groupid,int reportmasterid)
        {
            if (Groupid.Rows.Count < 0)
                return null;

            StringBuilder Strwhere = new StringBuilder();
            Strwhere.Append("select a.*,b.ISGLOBAL from BASE_REPORT a,BASE_GROUP_REPORT b  where a.REPORT_ID=b.REPORT_ID  and a.reportmaster_id="+reportmasterid+" and b.GROUP_ID in (");
            string SQl = "";

            for (int index = 0; index < Groupid.Rows.Count; index++)
            {
                Strwhere.Append(Groupid.Rows[index][0]);
                if (index < Groupid.Rows.Count - 1)
                    Strwhere.Append(",");
            }
            Strwhere.Append(")");
            SQl = Strwhere.ToString();

            object obj = oleDb.GetDataTable(SQl);
            if (obj != null)
                return (DataTable)obj;
            else
                return null;

        }

        public DataTable getOutParamter(Reportdat re,List<Paramater> list)
        {
            HIS.SYSTEM.DatabaseAccessLayer.ParameterEx[] parameters = new HIS.SYSTEM.DatabaseAccessLayer.ParameterEx[list.Count];
            for (int index = 0; index < list.Count; index++)
            {
           
                parameters[index].Text = list[index].PARAMETER;
                if (list[index].PARAMETER_TYPE == "OUT")
                {
                    parameters[index].ParaSize = Convert.ToInt32(list[index].DATALENGTH.ToString());
                    parameters[index].ParaDirection = ParameterDirection.Output;
                }
                else
                {
                    if (list[index].PARAMDATATYPE == 1)                    
                        parameters[index].Value = Convert.ToInt32(list[index].objvalue);
                    else
                        parameters[index].Value = list[index].objvalue.ToString();
                    parameters[index].ParaDirection = ParameterDirection.Input;

                }

 
            }

            DataTable result;
            result = oleDb.GetDataTable(re.PROCEDURES, parameters);

                return result;  


 
        }


 
         

    }


    public class Reportdat : HIS.Model.BASE_REPORT
    {
        private int _isglobal;
        public int Isglobal
        {
            get { return _isglobal; }
            set { _isglobal = value; }
        }


    

        /// <summary>
        /// 新增报表
        /// </summary>
        /// <returns></returns>
        public int addReport()
        {
            //string Strwhere = HIS.BLL.Tables.base_report.NAME + "='" + this.NAME + "'and " +
            //    HIS.BLL.Tables.base_report.PROCEDURES + "='" + this.PROCEDURES + "'";                
            //if (HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Exists(Strwhere))
            //    return 0;
            return HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Add(this);
        }
        public bool IsExsistReport()
        {
            string Strwhere = HIS.BLL.Tables.base_report.NAME + "='" + this.NAME + "'" +
                           " and " + HIS.BLL.Tables.base_report.DELETE_FLAG + " = 0";
            return HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Exists(Strwhere);             
        }
        public HIS.Model.BASE_REPORT GetReport(int reportmasterid)
        {
            string Strwhere = HIS.BLL.Tables.base_report.REPORTMASTER_ID + HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() + reportmasterid;
            return HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_REPORT>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).GetModel(Strwhere);      
        }

        public void update()
        {
            BindEntity<HIS.Model.BASE_REPORT>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Update(this);
        }
        public void Delete()
        {
            this.DELETE_FLAG = 1;
            BindEntity<HIS.Model.BASE_REPORT>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Update(this);
            string strWhere = HIS.BLL.Tables.base_report_parameter.REPORT_ID + " =" + this.REPORT_ID + "";
            BindEntity<HIS.Model.BASE_REPORT_PARAMETER>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Delete(strWhere);
        } 

    }

    public class OpReportMaster:HIS.Model.BASE_REPORTMASTER
    {
        public int Add()
        {
            try
            {
                return BindEntity<HIS.Model.BASE_REPORTMASTER>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Add(this);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update()
        {
            BindEntity<HIS.Model.BASE_REPORTMASTER>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Update(this);
        }

        public bool IsHasChildReport(  )//判断指定类型下是否有报表
        {
            string strWhere = HIS.BLL.Tables.base_reportmaster.P_ID + " = " + this.REPORTMASTER_ID + " " + " and DEIETE_FLAG =0";
            string strWhere1 = HIS.BLL.Tables.base_report.REPORTMASTER_ID +
                                      HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo()+this.REPORTMASTER_ID + " and delete_flag=0";
             return (BindEntity<HIS.Model.BASE_REPORTMASTER>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Exists(strWhere)
                     || BindEntity<HIS.Model.BASE_REPORT>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Exists(strWhere1));

        }
        public void Delete( )
        {
            try
            {
                this.DEIETE_FLAG = 1;
                BindEntity<HIS.Model.BASE_REPORTMASTER>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Update(this);
            
            }
            catch(System.Exception e)
            {
              
                throw new Exception(e.Message); 
            }
        }

        public bool IsExsistReportMaster()
        {
            string strWhere = HIS.BLL.Tables.base_reportmaster.NAME + HIS.SYSTEM.Core.BaseBLL.oleDb.EuqalTo() +" '"+this.NAME+"'"+
                " and DEIETE_FLAG  =0";
            return BindEntity<HIS.Model.BASE_REPORTMASTER>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).Exists(strWhere);
        }
    }

    public struct MatchFieldPairType
    {
        public IGRField grField;
        public int MatchColumnIndex;
    }

}
