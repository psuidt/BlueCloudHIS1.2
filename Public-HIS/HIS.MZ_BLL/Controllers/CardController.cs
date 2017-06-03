using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.BLL;
using HIS.DAL;
using HIS.MZ_BLL.Exceptions;

namespace HIS.MZ_BLL
{
    public class CardController : BaseBLL
    {
        /// <summary>
        /// 查找病人
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        public DataTable FindPatient( RegPatient Patient , bool AndOr)
        {
            string condiction = "";
            string andOr = AndOr ? oleDb.And( ) : oleDb.Or( );
            if ( Patient != null )
            {
                if ( Patient.PatientName.Trim( ) != "" )
                {
                    if ( condiction.Trim() == "" )
                        condiction += Tables.patientinfo.PATNAME + oleDb.Like( ) + "'%" + Patient.PatientName + "%'";
                    else
                        condiction += andOr + Tables.patientinfo.PATNAME + oleDb.Like( ) + "'%" + Patient.PatientName + "%'";
                }
                if ( Patient.HisCardNo.Trim( ) != "" )
                {
                    if ( condiction.Trim( ) == "" )
                        condiction += Tables.patientinfo.MEDICARD + oleDb.Like( ) + "'%" + Patient.HisCardNo + "%'";
                    else
                        condiction += andOr + Tables.patientinfo.MEDICARD + oleDb.Like( ) + "'%" + Patient.HisCardNo + "%'";
                }
                if ( Patient.Sex.Trim( ) != "" )
                {
                    if ( condiction.Trim() == "")
                        condiction += Tables.patientinfo.PATSEX + oleDb.EuqalTo( ) + "'" + Patient.Sex + "'";
                    else
                        condiction += andOr + Tables.patientinfo.PATSEX + oleDb.EuqalTo( ) + "'" + Patient.Sex + "'";
                }
                if ( Patient.IDCard.Trim( ) != "" )
                {
                    if ( condiction.Trim() =="" )
                        condiction += Tables.patientinfo.PATNUMBER + oleDb.Like( ) + "'%" + Patient.IDCard + "%'";
                    else
                        condiction += andOr + Tables.patientinfo.PATNUMBER + oleDb.Like( ) + "'%" + Patient.IDCard + "%'";
                }
            }
            
            return BindEntity<Model.PatientInfo>.CreateInstanceDAL( oleDb ).GetList( condiction );
            
        }
        /// <summary>
        /// 增加一个病人
        /// </summary>
        /// <param name="Patient"></param>
        public void AddNewPatient( RegPatient Patient )
        {
            Model.PatientInfo patientInfo = null;
            if ( Patient.HisCardNo.Trim( ) != "" )
            {
                string strWhere = Tables.patientinfo.MEDICARD + oleDb.EuqalTo( ) + "'" + Patient.HisCardNo +"'";
                patientInfo = BindEntity<Model.PatientInfo>.CreateInstanceDAL( oleDb ).GetModel( strWhere );
                if ( patientInfo != null )
                    throw new OperatorException( "就诊卡号重复！" );
            }
            patientInfo = new HIS.Model.PatientInfo( );
            patientInfo.PatName = Patient.PatientName;
            patientInfo.PatSex = Patient.Sex;
            patientInfo.MediCard = Patient.HisCardNo;
            patientInfo.PatBriDate = Patient.BornDate;
            patientInfo.PatGroup = Patient.Folk;
            patientInfo.PatTEL = Patient.Tel;
            patientInfo.PatAddress = Patient.Address;
            patientInfo.PATJOB = Patient.Occupation;
            BindEntity<Model.PatientInfo>.CreateInstanceDAL( oleDb ).Add( patientInfo );
            Patient.PatID = patientInfo.PatID;
        }
        /// <summary>
        /// 更新病人信息
        /// </summary>
        /// <param name="Patient">要更新的病人信息</param>
        public void UpdatePatient( RegPatient Patient )
        {
            Model.PatientInfo patientInfo = null;
            string strWhere = Tables.patientinfo.MEDICARD + oleDb.EuqalTo( ) + "'" + Patient.HisCardNo + "'" + oleDb.And() + Tables.patientinfo.PATID + oleDb.NotEqualTo() + Patient.PatID;
            patientInfo = BindEntity<Model.PatientInfo>.CreateInstanceDAL( oleDb ).GetModel( strWhere );
            if ( patientInfo != null )
                throw new OperatorException( "就诊卡号重复！" );
            BindEntity<Model.PatientInfo>.CreateInstanceDAL( oleDb ).Update( Tables.patientinfo.PATID + oleDb.EuqalTo( ) + Patient.PatID ,
                                        patientInfo.PatName + oleDb.EuqalTo( ) + "'" + Patient.PatientName + "'" ,
                                        patientInfo.PatSex + oleDb.EuqalTo( ) + "'" + Patient.Sex + "'" ,
                                        patientInfo.MediCard + oleDb.EuqalTo( ) + "'" + Patient.HisCardNo + "'" ,
                                        patientInfo.PatBriDate + oleDb.EuqalTo( ) + "'" + Patient.BornDate + "'" ,
                                        patientInfo.PatGroup + oleDb.EuqalTo( ) + "'" + Patient.Folk + "'" ,
                                        patientInfo.PatTEL + oleDb.EuqalTo( ) + "'" + Patient.Tel + "'" ,
                                        patientInfo.PatAddress + oleDb.EuqalTo( ) + "'" + Patient.Address + "'" ,
                                        patientInfo.PATJOB + oleDb.EuqalTo( ) + "'" + Patient.Occupation + "'" );
            
        }
    }
}
