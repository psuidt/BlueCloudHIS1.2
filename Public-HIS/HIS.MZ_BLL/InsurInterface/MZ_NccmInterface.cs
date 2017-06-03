using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MZ_BLL.Exceptions;
using HIS.Interface.Structs;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem.Core;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem.Enums;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem;

namespace HIS.MZ_BLL.InsurInterface
{
    /// <summary>
    /// 农合接口
    /// </summary>
    public class MZ_NccmInterface :HIS.SYSTEM.Core.BaseBLL, IInsureCharge
    {

        private HIS.MZ_BLL.OutPatient hisOutPatient;
        /// <summary>
        /// 医院信息，实例化该类的时候调用接口赋值该类
        /// </summary>
        private HospitalInfo hospitalInfo;

        private readonly string JOIN_AREA_CODE = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.JOIN_AREA_CODE; // "430121";
        private readonly string JOIN_AREA_NAME =HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.JOIN_AREA_NAME;//  "长沙县";
        private readonly string MED_ORG_CODE = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.MED_ORG_CODE;// "400866951";
        /// <summary>
        /// 匹配列表，为上传数据时提供农合中心编码
        /// </summary>
        private List<Model.NCMS_MATCH_CATALOG_TEMP> matchList;
        /// <summary>
        /// 门诊农合接口
        /// </summary>
        public MZ_NccmInterface()
        {
            HisData hisData = new HisData();
            hisData.uploadorg = MED_ORG_CODE;
            hisData.uploadTime = DateTime.Now.ToString( "yyyy-MM-dd" );

            DataClass dataClass = new DataClass();
            DataType dataType = new DataType();
            dataType.dataTypeName = "";
            dataType.dataTypeValue = "1";
            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;

            hisData.joinArea = joinArea;
            hisData.dataClass = dataClass;
            hisData.dataType = dataType;

            hospitalInfo = NccmInterfaces.DownLoadHospitalInfo( hisData );
            //初始化匹配列表
            matchList = HIS.SYSTEM.Core.BindEntity<Model.NCMS_MATCH_CATALOG_TEMP>.CreateInstanceDAL( oleDb ).GetListArray( "" );
        }
        /// <summary>
        /// 医院病人信息
        /// </summary>
        public HIS.MZ_BLL.OutPatient HisPatientInfo
        {
            get
            {
                return hisOutPatient;
            }
            set
            {
                hisOutPatient = value;

                
            }
        }
        /// <summary>
        /// 读取病人信息
        /// </summary>
        /// <param name="parameters">查询条件数组,目前只取2长度，分别代表医疗证号和身份证号</param>
        /// <returns></returns>
        public InsurPatientInfo[] GetPatientInfo( string[] parameters )
        {
            string cardNo = parameters[0];
            string idCard = parameters[1];
            
            FindPatientCompInfo hisData = new FindPatientCompInfo();
            
            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;

            DataClass dataClass = new DataClass();
            dataClass.dataClassName = NcmsDataClass.新农合数据.ToString() ;
            dataClass.dataClassValue = ((int)NcmsDataClass.新农合数据).ToString();

            DataType dataType = new DataType();
            dataType.dataTypeName = "参合信息" ;
            dataType.dataTypeValue = "2" ;

            OperType operType = new OperType();
            operType.operTypeName = "查询" ;
            operType.operTypeValue = "4" ;

            Condition AREA = new Condition();		//参合地区
            AREA.condition_displayname = "参合地区" ;
            AREA.condition_name = "JOIN_AREA" ;
            AREA.condition_value = JOIN_AREA_CODE ;

            Condition CARD_ID = new Condition();	//合作医疗证号			
            CARD_ID.condition_displayname = "合作医疗证号" ;
            CARD_ID.condition_name = "MED_CARD_ID" ;
            CARD_ID.condition_value = cardNo;     //"20090408" ; 
            
            Condition ID_CARD = new Condition();
            ID_CARD.condition_displayname = "身份证号";
            ID_CARD.condition_name = "PERSON_IDCARD";
            ID_CARD.condition_value = idCard;

            Condition[] cond = null;

            if ( cardNo.Trim() != "" && idCard.Trim() == "" )
            {
                cond = new Condition[] { AREA, CARD_ID };
            }
            else if ( cardNo.Trim() == "" && idCard.Trim() != "" )
            {
                cond = new Condition[] { AREA,  ID_CARD };
            }
            else if ( cardNo.Trim() != "" && idCard.Trim() != "" )
            {
                cond = new Condition[] { AREA, ID_CARD, CARD_ID };
            }

            hisData.joinArea = joinArea ;
            hisData.dataClass = dataClass ;
            hisData.dataType = dataType ;
            hisData.operType = operType ;
            hisData.conditions = cond ;
            hisData.uploadorg = MED_ORG_CODE;
            
            FindPatientCompInfoResult result = NccmInterfaces.FindPatientCompInfo( hisData );
            if ( result.resultId )
            {
                List<HIS.MZ_BLL.InsurPatientInfo> listPatInfo = new List<InsurPatientInfo>();
                try
                {
                    for ( int i = 0; i < result.compPatBaseData.Length; i++ )
                    {
                        HIS.MZ_BLL.InsurPatientInfo insurPatientInfo = new InsurPatientInfo();

                        insurPatientInfo.Area_Id = result.compPatBaseData[i].area_id;
                        insurPatientInfo.Person_Code = result.compPatBaseData[i].person_code;
                        insurPatientInfo.Name = result.compPatBaseData[i].name;
                        insurPatientInfo.Sex = result.compPatBaseData[i].sex;
                        insurPatientInfo.IdCard = result.compPatBaseData[i].idCard;
                        insurPatientInfo.BirthDate = Convert.ToDateTime( result.compPatBaseData[i].birthdate );
                        //insurPatientInfo.Age = Convert.ToInt32( result.compPatBaseData. );
                        insurPatientInfo.Family_Code = result.compPatBaseData[i].family_code;
                        insurPatientInfo.Medcard_Id = cardNo;
                        insurPatientInfo.Medorg_Code = hospitalInfo.org_id;
                        insurPatientInfo.Medorg_Level = hospitalInfo.hos_level;
                        listPatInfo.Add( insurPatientInfo );
                    }
                    return listPatInfo.ToArray();
                }
                catch(Exception err)
                {
                    ErrorWriter.WriteLog( err.Message );
                    throw new OperatorException( "返回查询结果期间发生错误！" );
                }
            }
            else
                throw new Exception (result.resultString);
        }
        /// <summary>
        /// 上传病人费用，门诊不用实现该接口。数据上传在预算和结算的时候完成
        /// </summary>
        /// <param name="prescriptions">处方信息</param>
        /// <param name="RedeemingMoney">补偿金额</param>
        /// <returns></returns>
        public bool UploadPrescription( Prescription[] prescriptions , out decimal RedeemingMoney )
        {
            RedeemingMoney = 0;
            
            return false;
        }
        /// <summary>
        /// 预算(接口预算完成后，回写入参的补偿金额字段以便后续使用)
        /// </summary>
        /// <returns>返回医保预算信息</returns>
        public InsurChargeInfo PreviewCharge( Prescription[] prescriptions )
        {

            PatientComp patComp = new PatientComp();
            patComp.uploadorg = MED_ORG_CODE;

            DataClass dataClass = new DataClass();
            dataClass.dataClassValue = "1";
            patComp.dataClass = dataClass;

            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;
            patComp.joinArea = joinArea;

            DataType dataType = new DataType();
            dataType.dataTypeName = "门诊数据";
            dataType.dataTypeValue = "2";
            patComp.dataType = dataType;

           
      

            MzPatBaseData mzPat = new MzPatBaseData();
            mzPat.idCard = hisOutPatient.InsurInfo.IdCard;
            mzPat.person_code = hisOutPatient.InsurInfo.Person_Code;
            mzPat.hisID = hisOutPatient.PatListID.ToString() ;//本次门诊的唯一号
            mzPat.area_id = JOIN_AREA_CODE;
            mzPat.family_code = hisOutPatient.InsurInfo.Family_Code;
            mzPat.medorg_code = MED_ORG_CODE;
            mzPat.medorg_level = hisOutPatient.InsurInfo.Medorg_Level;
            mzPat.visit_type = "1"; //1,门诊,2-住院
            mzPat.age = hisOutPatient.Age.ToString();
            mzPat.name = hisOutPatient.PatientName;
            mzPat.medcard_id = hisOutPatient.InsurInfo.Medcard_Id;
            mzPat.birthdate = hisOutPatient.InsurInfo.BirthDate.ToString("yyyy-MM-dd");
            mzPat.age = hisOutPatient.InsurInfo.Age.ToString();
            patComp.mzPat = mzPat;

            List<FeeDetail> fees = new List<FeeDetail>();
            for ( int i = 0; i < prescriptions.Length; i++ )
            {
                for ( int j = 0; j < prescriptions[i].PresDetails.Length; j++ )
                {
                    try
                    {
                        FeeDetail feeDetail = new FeeDetail();
                        feeDetail.his_billno = prescriptions[i].ChargeID.ToString();
                        feeDetail.item_sn = prescriptions[i].PrescriptionID.ToString() + prescriptions[i].PresDetails[j].DetailId.ToString() + prescriptions[i].ChargeID.ToString();
                        feeDetail.item_code = prescriptions[i].PresDetails[j].ItemId.ToString();
                        if ( prescriptions[i].PresDetails[j].ItemType == "01" || prescriptions[i].PresDetails[j].ItemType == "02" || prescriptions[i].PresDetails[j].ItemType == "03" )
                            feeDetail.item_class = "1";
                        else
                            feeDetail.item_class = "2";
                        feeDetail.item_equal = "0";
                        feeDetail.item_name = prescriptions[i].PresDetails[j].Itemname.Trim();
                        feeDetail.item_use_time = DateTime.Now.ToString( "yyyy-MM-dd" );
                        feeDetail.amount = Convert.ToDouble( prescriptions[i].PresDetails[j].Amount );
                        feeDetail.drugform = "";
                        feeDetail.doctorTitle = GetDoctorTitle( prescriptions[i].PresDocCode );
                        feeDetail.doctor = prescriptions[i].PresDocCode;
                        feeDetail.money = Convert.ToDouble( prescriptions[i].PresDetails[j].Tolal_Fee );
                        feeDetail.price = Convert.ToDouble( prescriptions[i].PresDetails[j].Sell_price );
                        feeDetail.center_item_code = GetNcmsCenterCode( feeDetail.item_code, feeDetail.item_class );
                        feeDetail.specs = prescriptions[i].PresDetails[j].Standard;
                        feeDetail.unit = prescriptions[i].PresDetails[j].Unit;
                        feeDetail.nccm_comp_status = "0";
                        feeDetail.feeType = GetClassCode( prescriptions[i].PresDetails[j].BigitemCode );
                        feeDetail.comp_ratio = Convert.ToDouble( GetNcmsCompRate( feeDetail.item_code, feeDetail.item_class ) );

                        fees.Add( feeDetail );
                    }
                    catch ( Exception err )
                    {
                        ErrorWriter.WriteLog( err.Message );
                        throw new OperatorException( "准备上传数据期间发生错误！" );
                    }
                }
            }
            FeeDetail[] detailList = fees.ToArray();
            patComp.mzDetail = detailList;
            
            InsurChargeInfo insurChargeInfo = new InsurChargeInfo();//定义的农合结算信息
            //调用接口预算功能
            try
            {
                CompData[] compDatas = NccmInterfaces.OutPatientBudegt( patComp );
                //判断返回的农合结算结果记录是是否和医院处方数对应
                if ( compDatas.Length != prescriptions.Length )
                {
                    throw new NcmsInterfaceException( "新农合预算结果的记录数(" + compDatas.Length.ToString() + ")不等于医院上传的处方数(" + prescriptions.Length.ToString() + ")" );
                }
                //回写每条明细的补偿金额
                for ( int i = 0; i < prescriptions.Length; i++ )
                {
                    for ( int j = 0; j < compDatas.Length; j++ )
                    {
                        if ( prescriptions[i].ChargeID.ToString() == compDatas[j].bill_no )
                        {
                            prescriptions[i].RedeemCost = Convert.ToDecimal( compDatas[j].comp_money );
                            break;
                        }
                    }
                }
            }
            catch ( NcmsInterfaceException ncmsErr )
            {
                throw new OperatorException( ncmsErr.Message );
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Message );
                ErrorWriter.WriteLog( err.InnerException.Message );
                throw new Exception( "农合预算发生错误！" );
            }
                        
            
            return insurChargeInfo;
        }
        /// <summary>
        /// 正式结算
        /// </summary>
        /// <param name="prescriptions">需要结算的处方</param>
        /// <returns>true:结算成功，false：结算失败</returns>
        /// <param name="Result">返回的相关信息</param>
        public bool Charge( Prescription[] prescriptions ,out object Result)
        {
            Result = null;
            PatientComp patComp = new PatientComp();
            patComp.uploadorg = MED_ORG_CODE;

            DataClass dataClass = new DataClass();
            dataClass.dataClassValue = "1";
            patComp.dataClass = dataClass;

            JoinArea joinArea = new JoinArea();
            joinArea.code = JOIN_AREA_CODE;
            joinArea.name = JOIN_AREA_NAME;
            patComp.joinArea = joinArea;

            DataType dataType = new DataType();
            dataType.dataTypeName = "门诊数据";
            dataType.dataTypeValue = "2";
            patComp.dataType = dataType;


            MzPatBaseData mzPat = new MzPatBaseData();
            mzPat.idCard = hisOutPatient.InsurInfo.IdCard;
            mzPat.person_code = hisOutPatient.InsurInfo.Person_Code;
            mzPat.hisID = hisOutPatient.PatListID.ToString();//本次门诊的唯一号
            mzPat.area_id = JOIN_AREA_CODE;
            mzPat.family_code = hisOutPatient.InsurInfo.Family_Code;
            mzPat.medorg_code = MED_ORG_CODE;
            mzPat.medorg_level = hisOutPatient.InsurInfo.Medorg_Level;
            mzPat.visit_type = "1"; //1,门诊,2-住院
            mzPat.age = hisOutPatient.Age.ToString();
            mzPat.name = hisOutPatient.PatientName;
            mzPat.medcard_id = hisOutPatient.InsurInfo.Medcard_Id;
            
            patComp.mzPat = mzPat;

            List<FeeDetail> fees = new List<FeeDetail>();
            for ( int i = 0; i < prescriptions.Length; i++ )
            {
                for ( int j = 0; j < prescriptions[i].PresDetails.Length; j++ )
                {
                    FeeDetail feeDetail = new FeeDetail();
                    feeDetail.his_billno = prescriptions[i].ChargeID.ToString();
                    feeDetail.item_sn = prescriptions[i].PrescriptionID.ToString() + prescriptions[i].PresDetails[j].DetailId.ToString() + prescriptions[i].ChargeID.ToString();
                    feeDetail.item_code = prescriptions[i].PresDetails[j].ItemId.ToString();
                    if ( prescriptions[i].PresDetails[j].ItemType == "01" || prescriptions[i].PresDetails[j].ItemType == "02" || prescriptions[i].PresDetails[j].ItemType == "03" )
                        feeDetail.item_class = "1";
                    else
                        feeDetail.item_class = "2";
                    feeDetail.item_equal = "0";
                    feeDetail.item_name = prescriptions[i].PresDetails[j].Itemname.Trim();
                    feeDetail.item_use_time = DateTime.Now.ToString( "yyyy-MM-dd" );
                    feeDetail.amount = Convert.ToDouble( prescriptions[i].PresDetails[j].Amount );
                    feeDetail.drugform = "";
                    feeDetail.doctorTitle = GetDoctorTitle( prescriptions[i].PresDocCode );
                    feeDetail.doctor = prescriptions[i].PresDocCode;
                    feeDetail.money = Convert.ToDouble( prescriptions[i].PresDetails[j].Tolal_Fee );
                    feeDetail.price = Convert.ToDouble( prescriptions[i].PresDetails[j].Sell_price );
                    feeDetail.center_item_code = GetNcmsCenterCode( feeDetail.item_code, feeDetail.item_class );
                    feeDetail.specs = prescriptions[i].PresDetails[j].Standard;
                    feeDetail.unit = prescriptions[i].PresDetails[j].Unit;
                    feeDetail.nccm_comp_status = "0";
                    feeDetail.feeType = GetClassCode( prescriptions[i].PresDetails[j].BigitemCode );
                    feeDetail.comp_ratio = Convert.ToDouble( GetNcmsCompRate( feeDetail.item_code, feeDetail.item_class ) );
                    fees.Add( feeDetail );
                }
            }
            FeeDetail[] detailList = fees.ToArray();
            patComp.mzDetail = detailList;
            
            //调用接口预算功能
            try
            {
                CompData[] cpData = NccmInterfaces.OutPatientCharge( patComp );
                Result = cpData;
                return true;
            }
            catch ( OperatorException operr )
            {
                throw operr;
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Source + "\r\n" + err.Message );
                throw new Exception( "新农合接口调用期间发生错误！" );
            }
        }
        /// <summary>
        /// 退费
        /// </summary>
        /// <param name="OrgPrescription">原始处方</param>
        /// <param name="DisChargePrescription">冲正的处方</param>
        /// <returns></returns>
        public bool CancelCharge( Prescription OrgPrescription, Prescription DisChargePrescription )
        {
            CanceDetail hisData = new CanceDetail();
            hisData.hos_class = hospitalInfo.hos_class;
            hisData.hos_level = hospitalInfo.hos_level;
            hisData.medorg_level = hospitalInfo.org_id;
            hisData.uploadorg = MED_ORG_CODE;
            hisData.uploadPerson = hospitalInfo.userCode;
            hisData.uploadTime = DateTime.Now.ToString( "yyyy-MM-dd" );

            hisData.joinArea = new JoinArea();
            hisData.joinArea.code = JOIN_AREA_CODE;
            hisData.joinArea.name = JOIN_AREA_NAME;

            hisData.dataClass = new DataClass();
            hisData.dataClass.dataClassName = "新农合数据";
            hisData.dataClass.dataClassValue = "1";

            hisData.dataType = new DataType();
            hisData.dataType.dataTypeName = "门诊数据";
            hisData.dataType.dataTypeValue = "1";

            hisData.operType = new OperType();
            hisData.operType.operTypeName = "冲正";
            hisData.operType.operTypeValue = "2";
            //病人基本信息
            hisData.baseData = new PatBaseData();
            hisData.baseData.age =  hisOutPatient.InsurInfo.Age.ToString()  ;
            hisData.baseData.area_id = JOIN_AREA_CODE;
            hisData.baseData.birthdate = hisOutPatient.InsurInfo.BirthDate.ToString( "yyyy-MM-dd" );
            hisData.baseData.family_code = hisOutPatient.InsurInfo.Family_Code;
            hisData.baseData.hisID = hisOutPatient.PatListID.ToString();
            hisData.baseData.idCard = hisOutPatient.InsurInfo.IdCard;
            hisData.baseData.medcard_id = hisOutPatient.InsurInfo.Medcard_Id;
            hisData.baseData.name = hisOutPatient.InsurInfo.Name;
            hisData.baseData.person_code = hisOutPatient.InsurInfo.Person_Code;
            hisData.baseData.sex = hisOutPatient.InsurInfo.Sex;
            
            hisData.baseData.visit_type = "1";
            //指定需要退费的明细(负记录)数量和金额是负数
            List<FeeDetail> feeList = new List<FeeDetail>();
            for ( int i = 0; i < DisChargePrescription.PresDetails.Length; i++ )
            {
                try
                {
                    FeeDetail detail = new FeeDetail( );
                    detail.his_billno = DisChargePrescription.ChargeID.ToString( );//*
                    detail.item_sn = DisChargePrescription.PrescriptionID.ToString( ) + DisChargePrescription.PresDetails[i].DetailId.ToString( ) + DisChargePrescription.ChargeID.ToString( );//*
                    detail.item_code = DisChargePrescription.PresDetails[i].ItemId.ToString( );//*
                    if ( DisChargePrescription.PresDetails[i].ItemType == "01" || DisChargePrescription.PresDetails[i].ItemType == "02" || DisChargePrescription.PresDetails[i].ItemType == "03" )
                        detail.item_class = "1";
                    else
                        detail.item_class = "2";

                    detail.item_equal = "0";//
                    detail.item_name = DisChargePrescription.PresDetails[i].Itemname;//*
                    detail.item_use_time = DisChargePrescription.PresDate.ToString( "yyyy-MM-dd" );//*
                    detail.amount = Convert.ToDouble( DisChargePrescription.PresDetails[i].Amount );//*
                    detail.drugform = "";//
                    detail.doctorTitle = "";//
                    detail.doctor = DisChargePrescription.PresDocCode;//
                    detail.money = Convert.ToDouble( DisChargePrescription.PresDetails[i].Tolal_Fee );//*
                    detail.price = Convert.ToDouble( DisChargePrescription.PresDetails[i].Sell_price );//*
                    detail.center_item_code = GetNcmsCenterCode( detail.item_code , detail.item_class );//
                    detail.specs = "";//
                    detail.unit = DisChargePrescription.PresDetails[i].Unit;//
                    detail.reverse_date = DateTime.Now.ToString( "yyyy-MM-dd" );//* 冲正日期
                    detail.reverse_person = hisData.uploadPerson;//* 冲正人
                    detail.reverse_sn = OrgPrescription.PrescriptionID.ToString( ) + OrgPrescription.PresDetails[i].DetailId.ToString( ) + OrgPrescription.ChargeID.ToString( );//* 冲正对应的正记录的ID

                    feeList.Add( detail );
                }
                catch ( OperatorException operr )
                {
                    throw operr;
                }
                catch ( Exception err )
                {
                    ErrorWriter.WriteLog( err.Message );
                    throw new Exception( "数据上传期间发生错误！" );
                }
            }
            hisData.cancelData = feeList.ToArray();
            try
            {
                object obj = NccmInterfaces.OutPatientCancelCharge( hisData );
                return true;
            }
            catch ( OperatorException operr )
            {
                throw operr;
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Source + "\r\n" + err.Message );
                throw new Exception( "农合接口退费发生错误！" );
            }
            
        }
        /// <summary>
        /// 得到农合中心编码
        /// </summary>
        /// <param name="hospitalCode">医院编码</param>
        /// <param name="type">类型 1-药品 2-项目</param>
        /// <returns>中心编码</returns>
        private string GetNcmsCenterCode(string hospitalCode ,string type)
        {
            foreach ( Model.NCMS_MATCH_CATALOG_TEMP match in matchList )
            {
                if ( match.HOSPITAL_CODE.Trim() == hospitalCode && match.TYPE == type )
                {
                    return match.NCMS_CODE;
                }
            }
            return "";
        }
        /// <summary>
        /// 获取医院设置的农合比例
        /// </summary>
        /// <param name="hospitalCode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private decimal GetNcmsCompRate( string hospitalCode, string type )
        {
            foreach ( Model.NCMS_MATCH_CATALOG_TEMP match in matchList )
            {
                if ( match.HOSPITAL_CODE.Trim() == hospitalCode && match.TYPE == type )
                {
                    return match.COMP_RATE / (decimal)100;
                }
            }
            return 1M;
        }

        private string GetDoctorTitle( string employeeCode )
        {
            Model.BASE_ROLE_DOCTOR doctor = HIS.SYSTEM.Core.BindEntity<Model.BASE_ROLE_DOCTOR>.CreateInstanceDAL( oleDb ).GetModel( HIS.BLL.Tables.base_role_doctor.EMPLOYEE_ID + "=" + employeeCode );
            if ( doctor != null )
                return "";
            else
                return doctor.YS_TYPEID;
        }

        private string GetClassCode(string stat_item_code)
        {
            Model.BASE_STAT_ITEM item = HIS.SYSTEM.Core.BindEntity<Model.BASE_STAT_ITEM>.CreateInstanceDAL( oleDb ).GetModel( HIS.BLL.Tables.base_stat_item.CODE + "='" + stat_item_code + "'" );
            if ( item == null )
                return "";
            else
                return item.MZFP_CODE;
        }
    }
}
