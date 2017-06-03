using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.MZ_BLL.Exceptions;
using HIS.BLL;
using HIS.Interface.Structs;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 挂号控制器
    /// </summary>
    public class RegController : BaseBLL
    {
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private HIS.DAL.MZ_DAL reg_dal;
        /// <summary>
        /// 挂号处理对象
        /// </summary>
        private HIS.MZ_BLL.RegisterObject.BaseRegister register;
        private int operatorId;
        private string operatorName;
        /// <summary>
        /// 操作员ID
        /// </summary>
        public int OperatorId
        {
            get
            {
                return operatorId;
            }
            set
            {
                operatorId = value;
            }
        }
        /// <summary>
        /// 操作员
        /// </summary>
        public string OperatorName
        {
            get
            {
                return operatorName;
            }
            set
            {
                operatorName = value;
            }
        }
        /// <summary>
        /// 构造器
        /// </summary>
        public RegController()
        {
            //构造数据访问接口
            reg_dal = new HIS.DAL.MZ_DAL();
            reg_dal._OleDB = oleDb;
        }
        /// <summary>
        /// 保存挂号病人基本信息
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        public bool SaveRegPatient( RegPatient Patient )
        {
            HIS.Model.PatientInfo mz_patient = null;
            try
            {
                mz_patient = BindEntity<Model.PatientInfo>.CreateInstanceDAL( oleDb ).GetModel( "PatID=" + Patient.PatID.ToString( ) );
                if ( mz_patient == null )
                {
                    ( new CardController( ) ).AddNewPatient( Patient );
                }
                else
                {
                    ( new CardController( ) ).UpdatePatient( Patient );
                }
                //mz_patient.ADDRESS = Patient.Address;
                //mz_patient.BORNDAY = Patient.BornDate;
                //mz_patient.CARDNO = Patient.HisCardNo;
                //mz_patient.FOLK = Patient.Folk;
                //mz_patient.IDCARD = Patient.IDCard;
                //mz_patient.OCCUPATION = Patient.Occupation;
                //mz_patient.PATNAME = Patient.PatientName;
                //mz_patient.SEX = Patient.Sex;
                //mz_patient.TEL = Patient.Tel;
                //mz_patient.TYPE = Convert.ToInt32( Patient.PatType.Code );
                //mz_patient.TYPE_NAME = Patient.PatType.Name;
                //if ( !Patient.ValidCardNo )
                //{
                //    BindEntity<Model.MZ_PATIENT>.CreateInstanceDAL( oleDb ).Add( mz_patient );
                //    Patient.PatID = mz_patient.PATID;
                //}
                //else
                //{
                //    BindEntity<Model.MZ_PATIENT>.CreateInstanceDAL( oleDb ).Update( mz_patient );
                //}
                return true;
            }
            catch ( OperatorException operr )
            {
                throw operr;
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Message );
                throw new Exception( "保存病人基本信息失败！" );
            }

        }
        /// <summary>
        /// 判断门诊号是否存在
        /// </summary>
        /// <returns></returns>
        private bool VisitNoExists(string VisitNo)
        {
            Model.MZ_PatList mz_patient = BindEntity<Model.MZ_PatList>.CreateInstanceDAL( oleDb ).GetModel( "VISITNO='" + VisitNo + "'" );
            return mz_patient == null ? false : true;
        }
        /// <summary>
        /// 创建门诊号
        /// </summary>
        /// <returns></returns>
        public string CreateVisitNo()
        {
            Model.MZ_SERIAL_NO mz_serial_no = null;
            mz_serial_no = BindEntity<Model.MZ_SERIAL_NO>.CreateInstanceDAL( oleDb ).GetModel( "" );
            if ( mz_serial_no == null )
            {
                mz_serial_no = new HIS.Model.MZ_SERIAL_NO( );
                mz_serial_no.VISIT_NO = 1;
                BindEntity<Model.MZ_SERIAL_NO>.CreateInstanceDAL( oleDb ).Add( mz_serial_no );
            }
            mz_serial_no.VISIT_NO = mz_serial_no.VISIT_NO + 1;
            BindEntity<Model.MZ_SERIAL_NO>.CreateInstanceDAL( oleDb ).Update( "", BLL.Tables.mz_serial_no.VISIT_NO + oleDb.EuqalTo() + mz_serial_no.VISIT_NO );
            string lastNum = "";
            if (mz_serial_no.VISIT_NO.ToString().Length > 4)
            {
                string no = mz_serial_no.VISIT_NO.ToString();
                lastNum = no.Substring(no.Length - 4, 4);
            }
            else
            {
                lastNum = mz_serial_no.VISIT_NO.ToString("0000");
                
            }
            string tmp = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString( "yyyyMMdd" ) + lastNum;
            return tmp;
        }
        
        private bool CardNoExists( string CardNo )
        {
            Model.PatientInfo mz_patient = BindEntity<Model.PatientInfo>.CreateInstanceDAL( oleDb ).GetModel(  Tables.patientinfo.MEDICARD + "='" + CardNo + "'" );
            return mz_patient == null ? false : true;
        }
        /// <summary>
        /// 挂号预算
        /// </summary>
        /// <returns></returns>
        private bool Budget(RegPatient Patient)
        {
            try
            {
                register = RegisterObject.RegisterFactory.CreateRegisterObject( Patient.PatType.Code );
                register.OperatorId = this.operatorId;
                register.OperatorName = this.operatorName;

                Patient.RegFeeInfo = register.Budget( Patient );
                return true;
            }
            catch ( OperatorException operr )
            {
                throw operr;
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err );
                throw new Exception( "挂号费用计算发生错误！请重试" );
            }
            finally
            {
                register = null;
            }

        }
        /// <summary>
        /// 挂号登记
        /// </summary>
        /// <param name="Patient">病人信息</param>
        /// <returns></returns>
        private bool Register(RegPatient Patient)
        {
            try
            {
                register = RegisterObject.RegisterFactory.CreateRegisterObject( Patient.PatType.Code );
                register.OperatorId = this.operatorId;
                register.OperatorName = this.operatorName;
                return register.Register( Patient , Patient.RegFeeInfo );
            }
            catch ( OperatorException operr )
            {
                throw operr;
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err );
                throw new Exception( "挂号登记发生错误！请重试" );
            }
            finally
            {
                register = null;
            }
        }
        /// <summary>
        /// 退号
        /// </summary>
        /// <param name="RegInvoiceNo"></param>
        /// <returns></returns>
        public bool CancelRegister(string RegInvoiceNo , string PerfChar)
        {
            try
            {
                RegPatient Patient = GetPatientInfoByInvoiceNo( PerfChar,RegInvoiceNo );
                if ( Patient == null )
                {
                    throw new OperatorException( "没有找到挂号病人信息!\r\n1、请确认挂号收据号是否正确。\r\n2、如果发票有前缀字符，请确认是否输入前缀字符。\r\n3、确认该号是否已经退号" );
                }
                OutPatient patient = new OutPatient( Patient.PatListID );
                Prescription[] pres = patient.GetPrescriptions( PresStatus.全部 , true );
                if ( pres.Length > 0 )
                    throw new OperatorException( "该病人已经有就诊记录，不能退号" );

                
                register = RegisterObject.RegisterFactory.CreateRegisterObject( Patient.PatType.Code );
                register.OperatorId = this.operatorId;
                register.OperatorName = this.operatorName;
                try
                {
                    return register.CancelRegister( RegInvoiceNo , PerfChar );
                }
                catch ( OperatorException operr )
                {
                    throw operr;
                }
                catch ( Exception e1 )
                {
                    ErrorWriter.WriteLog( e1.Message );
                    throw new Exception( "退号操作不成功！请重试" );
                }

            }
            catch(Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 预算处理过程
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        public bool BudgetProcess( RegPatient Patient )
        {
            oleDb.BeginTransaction();
            try
            {
                //费用预算
                bool ret = Budget( Patient );
                oleDb.CommitTransaction( );
                return true;
            }
            catch ( OperatorException operr )
            {
                oleDb.RollbackTransaction( );
                throw operr;
            }
            catch ( Exception err )
            {
                oleDb.RollbackTransaction( );
                ErrorWriter.WriteLog( err.Message );
                throw new Exception( "挂号费用计算发生错误！请重试" );
            }
        }
        /// <summary>
        /// 正式挂号过程
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        public bool RegisterPrecess( RegPatient Patient )
        {
            oleDb.BeginTransaction();
            try
            {
                Patient.VisitNo = CreateVisitNo( );   //正式挂号前创建一个门诊号
                bool ret = Register( Patient );
                oleDb.CommitTransaction( );
                return ret;
            }
            catch ( OperatorException operr )
            {
                oleDb.RollbackTransaction( );
                throw operr;
            }
            catch ( Exception err )
            {
                oleDb.RollbackTransaction( );
                ErrorWriter.WriteLog( err.Message );
                throw new Exception( "挂号登记发生错误！" );
            }
        }
        /// <summary>
        /// 获取挂号病人列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetRegPatientList(DateTime? dateBegin,DateTime? dateEnd,int? OperatorId)
        {
            return  reg_dal.GetRegPatientList(dateBegin, dateEnd, OperatorId);
            
        }
        /// <summary>
        /// 根据医院诊疗卡获取病人信息
        /// </summary>
        /// <param name="HisCardNo"></param>
        /// <returns></returns>
        public RegPatient GetPatientBaseInfoByHisCardNo(string HisCardNo)
        {
            RegPatient patient = new RegPatient();
            DataRow dr = reg_dal.GetRegPatientByHisCardNo( HisCardNo );
            if ( dr == null )
                return null;

            patient.Address = dr[BLL.Tables.patientinfo.PATADDRESS].ToString();
            patient.BornDate = Convert.ToDateTime( dr[BLL.Tables.patientinfo.PATBRIDATE] );
            patient.Folk = dr[BLL.Tables.patientinfo.PATGROUP].ToString( );
            patient.HisCardNo = HisCardNo;
            patient.IDCard = dr[BLL.Tables.patientinfo.PATNUMBER].ToString( );
            patient.Occupation = dr[BLL.Tables.patientinfo.PATJOB].ToString( );
            patient.PatID = Convert.ToDecimal( dr[BLL.Tables.patientinfo.PATID] );
            patient.PatientName = dr[BLL.Tables.patientinfo.PATNAME].ToString( );
            patient.Sex = dr[BLL.Tables.patientinfo.PATSEX].ToString( );
            patient.Tel = dr[BLL.Tables.patientinfo.PATTEL].ToString( );
            //patient.PatType.Code = dr[BLL.Tables.mz_patlist.MEDITYPE].ToString( ).Trim( );

            return patient;
        }
        /// <summary>
        /// 根据发票获取病人信息
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <returns></returns>
        public RegPatient GetPatientInfoByInvoiceNo( string PerfChar, string invoiceNo )
        {
            RegPatient patient = new RegPatient();
            DataRow dr = reg_dal.GetRegPatientByInvoiceNo( PerfChar,invoiceNo );
            if ( dr == null )
                return null;

            patient.Address = dr[BLL.Tables.patientinfo.PATADDRESS].ToString( );
            if ( !Convert.IsDBNull( dr[BLL.Tables.patientinfo.PATBRIDATE] ) )
                patient.BornDate = Convert.ToDateTime( dr[BLL.Tables.patientinfo.PATBRIDATE] );
            patient.Folk = dr[BLL.Tables.patientinfo.PATGROUP].ToString( );
            patient.HisCardNo = dr[BLL.Tables.patientinfo.MEDICARD].ToString( );
            patient.IDCard = dr[BLL.Tables.patientinfo.PATNUMBER].ToString( );
            patient.Occupation = dr[BLL.Tables.patientinfo.PATJOB].ToString( );
            patient.PatID = Convert.ToDecimal( dr[BLL.Tables.patientinfo.PATID] );
            patient.PatListID = Convert.ToInt32( dr[BLL.Tables.mz_patlist.PATLISTID] );
            patient.PatientName = dr[BLL.Tables.patientinfo.PATNAME].ToString( );
            patient.Sex = dr[BLL.Tables.patientinfo.PATSEX].ToString( );
            patient.Tel = dr[BLL.Tables.patientinfo.PATTEL].ToString( );
            patient.PatType = new PatientType( );
            patient.PatType.Code = dr[BLL.Tables.mz_patlist.MEDITYPE].ToString( );
            //patient.PatType.Name = PublicDataReader.GetPatientTypeNameByCode( patient.PatType.Code );
            patient.PatType.Name = BaseDataController.GetName( BaseDataCatalog.病人类型列表, patient.PatType.Code );
            return patient;
        }
        /// <summary>
        /// 根据就诊号获取病人信息
        /// </summary>
        /// <param name="VisitNo"></param>
        /// <returns></returns>
        public RegPatient GetPatientInfoByVisitNo(string VisitNo)
        {
            DataRow dr = reg_dal.GetRegisterInfoByVisitNo( VisitNo );
            if ( dr == null )
                throw new OperatorException( "没有找到病人信息！" );
            RegPatient patient = new RegPatient( );
            
            patient.Address = dr[Tables.patientinfo.PATADDRESS].ToString( );
            if ( !Convert.IsDBNull(dr[Tables.patientinfo.PATBRIDATE]))
                patient.BornDate =  Convert.ToDateTime( dr[Tables.patientinfo.PATBRIDATE] );
            patient.Folk = Convert.IsDBNull(dr[Tables.patientinfo.PATGROUP])?"" : dr[Tables.patientinfo.PATGROUP].ToString( );
            patient.HisCardNo = Convert.IsDBNull( dr[Tables.patientinfo.MEDICARD] ) ? "" : dr[Tables.patientinfo.MEDICARD].ToString( );
            patient.IDCard = Convert.IsDBNull( dr[Tables.patientinfo.PATNUMBER] ) ? "" : dr[Tables.patientinfo.PATNUMBER].ToString( );
            patient.Occupation = Convert.IsDBNull( dr[Tables.patientinfo.PATJOB] ) ? "" : dr[Tables.patientinfo.PATJOB].ToString( );
            patient.PatID = Convert.IsDBNull( dr[Tables.mz_patlist.PATID] ) ? 0M : Convert.ToDecimal( dr[Tables.mz_patlist.PATID] );
            patient.PatientName = Convert.IsDBNull( dr[Tables.mz_patlist.PATNAME] ) ? "" : dr[Tables.mz_patlist.PATNAME].ToString( );
            patient.PatListID = Convert.IsDBNull( dr[Tables.mz_patlist.PATLISTID] ) ? 0 : Convert.ToInt32( dr[Tables.mz_patlist.PATLISTID] );
            patient.PatType = new PatientType( );
            patient.PatType.Code = Convert.IsDBNull( dr[Tables.mz_patlist.MEDITYPE] ) ? "" : dr[Tables.mz_patlist.MEDITYPE].ToString( );
            patient.Sex = Convert.IsDBNull( dr[Tables.mz_patlist.PATSEX] ) ? "" : dr[Tables.mz_patlist.PATSEX].ToString( );
            patient.Tel = Convert.IsDBNull( dr[Tables.patientinfo.PATTEL] ) ? "" :dr[Tables.patientinfo.PATTEL].ToString( );
            patient.ValidCardNo = patient.PatID==0 ? false : true ;
            patient.VisitNo = VisitNo;
            patient.PYM = Convert.IsDBNull( dr[Tables.patientinfo.PYM] ) ? "" :dr[Tables.patientinfo.PYM].ToString( );
            patient.WBM = Convert.IsDBNull( dr[Tables.patientinfo.WBM] ) ? "" :dr[Tables.patientinfo.WBM].ToString( );
            patient.RegDeptCode = Convert.IsDBNull( dr[Tables.mz_patlist.REG_DEPT_CODE] ) ? "" : dr[Tables.mz_patlist.REG_DEPT_CODE].ToString( );
            patient.RegDoctorCode = Convert.IsDBNull( dr[Tables.mz_patlist.REG_DOC_CODE] ) ? "" : dr[Tables.mz_patlist.REG_DOC_CODE].ToString( );

            return patient;
        }
    }
}
