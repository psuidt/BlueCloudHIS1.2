using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.Interface.Structs;
namespace HIS.MZ_BLL
{
    /// <summary>
    /// 药品接口对象
    /// </summary>
    public class YP_Interface : BaseBLL 
    {
        /// <summary>
        /// 根据发票号获取病人信息
        /// </summary>
        /// <param name="InvoiceSerialNo">发票号</param>
        /// <returns></returns>
        public static HIS.Model.MZ_PatList GetPatInfo( string InvoiceSerialNo )
        {
            OutPatient patient = new OutPatient( InvoiceSerialNo , OPDBillKind.门诊收费发票);

            HIS.Model.MZ_PatList model = new HIS.Model.MZ_PatList( );

            model.PatListID = patient.PatListID;
            model.PatID = patient.PatID;
            model.PatName = patient.PatientName;
            model.PatSex = patient.Sex;
            model.PYM = patient.PYM;
            model.WBM = patient.WBM;
            model.MediCard = patient.MediCard;
            model.MediType = patient.MediType;
            model.HpCode = patient.HpCode;
            model.HpGrade = patient.HpGrade;
            model.CureDeptCode = patient.CureDeptCode;
            model.CureEmpCode = patient.CureEmpCode;
            model.DiseaseCode = patient.DiseaseCode;
            model.DiseaseName = patient.DiseaseName;
            model.CureDate = patient.CureDate;

            return model;
        }
        
        /// <summary>
        /// 根据发票号得到待发药处方信息
        /// </summary>
        /// <param name="InvoiceSerialNo">发票号</param>
        /// <returns>处方信息</returns>
        public static Prescription[] GetPatPresStruck( string InvoiceSerialNo )
        {
            return ( new OutPatient( InvoiceSerialNo , OPDBillKind.门诊收费发票) ).GetPrescriptions( PresStatus.已收费未发药 , false );
        }
        /// <summary>
        /// 根据发票号获取处方头
        /// </summary>
        /// <param name="InvoiceSerialNo">发票号</param>
        /// <param name="model">
        /// 0表发药模式；1表退药模式
        /// </param>
        /// <param name="deptId">部门Id</param>
        /// <returns>处方头对象</returns>
        public static HIS.Model.MZ_PresMaster GetPresMasterbyInvoiceNo( string InvoiceSerialNo, short model,int deptId)
        {
            
            List<HIS.Model.MZ_PresMaster> list;
            //发药查询
            if (model == 0)
            {
                list = BindEntity < Model.MZ_PresMaster>.CreateInstanceDAL(oleDb).GetListArray( "ticketnum='" + InvoiceSerialNo + "' and EXECDEPTCODE='" + deptId + "' and record_flag=0 and charge_flag=1 and drug_flag=0" );
            }
            //退药查询
            else
            {
                list = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetListArray( "ticketnum='" + InvoiceSerialNo + "' and EXECDEPTCODE='" + deptId + "' and record_flag=0 and charge_flag=1 and drug_flag=1" );
            }
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }
        /// <summary>
        /// 获取处方头信息
        /// </summary>
        /// <param name="isSend">是否发药</param>
        /// <param name="deptId">药房ID</param>
        /// <returns>c处方</returns>
        public static List<HIS.Model.MZ_PresMasterInfo> GetPresMasterList( bool isSend , int deptId )
        {
            return GetPresMasterList( "" , isSend , deptId );
        }
        /// <summary>
        /// 获取处方表头列表信息
        /// </summary>
        /// <param name="isSend">是否发药</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>对象列表</returns>
        public static List<HIS.Model.MZ_PresMasterInfo> GetPresMasterList( bool isSend , int deptId , string beginDate , string endDate )
        {
            return GetPresMasterList( "" , isSend , deptId , beginDate , endDate );
        }
        /// <summary>
        /// 获取处方表头列表信息
        /// </summary>
        /// <param name="InvoiceNo">发票号</param>
        /// <param name="isSend">是否发药</param>
        /// <param name="deptId">部门ID</param>
        /// <returns>对象列表</returns>
        public static List<HIS.Model.MZ_PresMasterInfo> GetPresMasterList( string InvoiceNo , bool isSend , int deptId )
        {
            return GetPresMasterList( InvoiceNo , isSend , deptId , "" , "" );
        }
        /// <summary>
        /// 根据发票号获取处方头信息
        /// </summary>
        /// <param name="InvoiceNo">发票号</param>
        /// <param name="isSend">是否发药</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="deptId">科室部门ID</param>
        /// <returns>对象列表</returns>
        public static List<HIS.Model.MZ_PresMasterInfo> GetPresMasterList( string InvoiceNo , bool isSend , int deptId , string beginDate , string endDate )
        {
            
            string presId = "";
            if ( InvoiceNo.Trim( ) != "" )
            {
                Model.MZ_CostMaster costmaster = BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).GetModel( "ticketnum='" + InvoiceNo.Trim( ) + "' and record_flag=0 " );

                if ( costmaster == null )
                {
                    throw new Exception( "该发票号不存在" );
                }
                presId = costmaster.PresMasterID.ToString( );
            }

            string dateString = "";
            if ( beginDate.Trim( ) != "" )
                dateString = " and PRESDATE>='" + Convert.ToDateTime( beginDate ).ToString( "yyyy-MM-dd HH:mm:ss" ) + "' ";
            if ( endDate.Trim( ) != "" )
                dateString += " and PRESDATE<='" + Convert.ToDateTime( endDate ).ToString( "yyyy-MM-dd HH:mm:ss" ) + "' ";


            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;

            DataTable tb = mz_dal.GetPresMasterList( InvoiceNo , isSend , deptId , presId, dateString);
            if ( tb.Rows.Count == 0 )
                throw new Exception( "输入的发票号没有知道对应的处方头信息" );

            List<HIS.Model.MZ_PresMasterInfo> presList = new List<HIS.Model.MZ_PresMasterInfo>( );
            foreach ( DataRow dr in tb.Rows )
            {
                HIS.Model.MZ_PresMasterInfo pres = new HIS.Model.MZ_PresMasterInfo( );
                pres.Address = dr["Address"].ToString( ).Trim( );
                pres.Age = Convert.IsDBNull(dr["Age"]) ? 0 : Convert.ToInt32(dr["Age"]);
                pres.InvoiceNo = dr["ticketnum"].ToString( ).Trim( );
                pres.PatientName = dr["patname"].ToString( ).Trim( );
                pres.PresMasterId = dr["presmasterid"].ToString( ).Trim( );
                pres.Sex = dr["patsex"].ToString( ).Trim( );
                pres.PatlistId = Convert.ToInt32( dr["patlistid"] );
                presList.Add( pres );
            }
            return presList;
        }
        /// <summary>
        /// 根据发票号得到待发药处方信息
        /// </summary>
        /// <param name="InvoiceSerialNo">发票号</param>
        /// <param name="deptId">部门ID</param>
        /// <returns>病人处方信息DataTable</returns>
        public static DataTable GetPatPresInfo( string InvoiceSerialNo ,int deptId)
        {
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;

            return mz_dal.GetPatPresInfo( InvoiceSerialNo , deptId );

        }
        /// <summary>
        /// 更新发药标识
        /// </summary>
        /// <param name="PresMasterID">处方头ID</param>
        /// <returns></returns>
        public static bool UpdateSendDrugFlag( int PresMasterID)
        {
            try
            {
                Model.MZ_PresMaster presMaster = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( PresMasterID );
                presMaster.Drug_Flag = 1;
                BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( presMaster );

                return true;
            }
            catch(Exception err)
            {
                ErrorWriter.WriteLog( err.Message );
                return false;
            }
        }

        /// <summary>
        /// 更新退药标识
        /// </summary>
        /// <param name="presMasterID">处方头ID</param>
        /// <returns></returns>
        public static bool UpdateBackDrugFlag(int presMasterID)
        {
            try
            {
                Model.MZ_PresMaster presMaster = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( presMasterID );
                presMaster.Drug_Flag = 0;
                BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( presMaster );
                
                return true;
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Message );
                return false;
            }
        }

       
    }
}