using System;
using System.Collections.Generic;
using System.Text;
using HIS;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.MZ_BLL.Exceptions;
using System.Data;
using HIS.Interface.Structs;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 门诊病人对象
    /// </summary>
    public class OutPatient : BasePatient
    {
        
        /// <summary>
        /// 医疗证卡号
        /// </summary>
        private string _mediCard = "";
        /// <summary>
        /// 就诊类型
        /// </summary>
        private string _mediType = "";
        /// <summary>
        /// 就医机构代码
        /// </summary>
        private string _hpCode = "";
        /// <summary>
        /// 就医机构级别
        /// </summary>
        private string _hpGrade = "";
        /// <summary>
        /// 就诊科室代码
        /// </summary>
        private string _cureDeptCode = "";
        /// <summary>
        /// 就诊医生代码
        /// </summary>
        private string _cureEmpCode = "";
        /// <summary>
        /// 疾病代码
        /// </summary>
        private string _diseaseCode = "";
        /// <summary>
        /// 疾病名称
        /// </summary>
        private string _diseaseName = "";
        /// <summary>
        /// 疾病其他备注
        /// </summary>
        private string _diseaseMemo = "";
        /// <summary>
        /// 就诊日期
        /// </summary>
        private DateTime _cureDate;
        /// <summary>
        /// 是否急诊
        /// </summary>
        private bool _isEmergency;
        /// <summary>
        /// 
        /// </summary>
        private InsurPatientInfo insurInfo;
        /// <summary>
        /// 是否初始化了医保信息
        /// </summary>
        private bool initInsurInfo;
        /// <summary>
        /// 医疗证卡号
        /// </summary>
        public string MediCard
        {
            get
            {
                return _mediCard;
            }
            set
            {
                _mediCard = value;
            }
        }
        /// <summary>
        /// 就诊类型
        /// </summary>
        public string MediType
        {
            get
            {
                return _mediType;
            }
            set
            {
                _mediType = value;
            }
        }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string HpCode
        {
            get
            {
                return _hpCode;
            }
            set
            {
                _hpCode = value;
            }
        }
        /// <summary>
        /// 年龄单位
        /// </summary>
        public string HpGrade
        {
            get
            {
                return _hpGrade;
            }
            set
            {
                _hpGrade = value;
            }
        }
        /// <summary>
        /// 就诊科室代码
        /// </summary>
        public string CureDeptCode
        {
            get
            {
                return _cureDeptCode;
            }
            set
            {
                _cureDeptCode = value;
            }
        }
        /// <summary>
        /// 就诊医生代码
        /// </summary>
        public string CureEmpCode
        {
            get
            {
                return _cureEmpCode;
            }
            set
            {
                _cureEmpCode = value;
            }
        }
        /// <summary>
        /// 疾病代码
        /// </summary>
        public string DiseaseCode
        {
            get
            {
                return _diseaseCode;
            }
            set
            {
                _diseaseCode = value;
            }
        }
        /// <summary>
        /// 疾病名称
        /// </summary>
        public string DiseaseName
        {
            get
            {
                return _diseaseName;
            }
            set
            {
                _diseaseName = value;
            }
        }
        /// <summary>
        /// 疾病的其他描述
        /// </summary>
        public string DiseaseMemo
        {
            get
            {
                return _diseaseMemo;
            }
            set
            {
                _diseaseMemo = value;
            }
        }
        /// <summary>
        /// 就诊日期
        /// </summary>
        public DateTime CureDate
        {
            get
            {
                return _cureDate;
            }
            set
            {
                _cureDate = value;
            }
        }
        /// <summary>
        /// 是否急诊
        /// </summary>
        public bool IsEmergency
        {
            get
            {
                return _isEmergency;
            }
            set
            {
                _isEmergency = value;
            }
        }
        /// <summary>
        /// 医保信息
        /// </summary>
        public InsurPatientInfo InsurInfo
        {
            get
            {
                return insurInfo;
            }
            set
            {
                insurInfo = value;
            }
        }
        /// <summary>
        /// 是否初始化了医保信息
        /// </summary>
        public bool InitInsurInfo
        {
            get
            {
                return initInsurInfo;
            }
            set
            {
                initInsurInfo = value;
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="model"></param>
        private void BindData( HIS.Model.MZ_PatList model )
        {
            this.PatListID = model.PatListID;
            this.PatID = model.PatID;
            this.VisitNo = model.VisitNo;
            this.PatientName = model.PatName;
            this.Sex = model.PatSex;
            this.Age = model.Age;
            this.PYM = model.PYM;
            this.WBM = model.WBM;
            _mediCard = model.MediCard;
            _mediType = model.MediType;
            _hpCode = model.HpCode;
            _hpGrade = model.HpGrade;
            if ( model.CureDeptCode.Trim( ) != "" )
                _cureDeptCode = model.CureDeptCode;
            else
                _cureDeptCode = model.REG_DEPT_CODE;
            if ( model.CureEmpCode.Trim( ) != "" )
                _cureEmpCode = model.CureEmpCode;
            else
                _cureEmpCode = model.REG_DOC_CODE;

            _diseaseCode = model.DiseaseCode;

            string[] disease = model.DiseaseName.Split( "|".ToCharArray( ) );
            _diseaseName = disease[0];
            if ( disease.Length > 1 )
                _diseaseMemo = disease[1];

            _cureDate = model.CureDate;

            this.Allergic = GetAllergic(Convert.ToInt32(this.PatID));
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public OutPatient()
        {
        }
        /// <summary>
        /// 就诊号
        /// </summary>
        /// <param name="RegisterID"></param>
        public OutPatient( int RegisterID )
        {
            HIS.Model.MZ_PatList model = BindEntity<Model.MZ_PatList>.CreateInstanceDAL(oleDb).GetModel( RegisterID );
            if ( model == null )
            {
                throw new Exception( "无效的就诊号！");
            }
            BindData( model );
            
             
        }
        /// <summary>
        /// 就诊号号获得病人
        /// </summary>
        /// <param name="InvoiceSerialNo">就诊号</param>
        public OutPatient( string VisitNo )
        {
            
            //List<HIS.Model.MZ_CostMaster> models = null;
            HIS.Model.MZ_PatList model = null;

            model = BindEntity<Model.MZ_PatList>.CreateInstanceDAL( oleDb ).GetModel( Tables.mz_patlist.VISITNO + "='" + VisitNo + "'" );
            if ( model==null )
            {
                throw new Exception( "输入的门诊就诊号找不到病人登记信息" );
            }
            BindData( model );

        }
        /// <summary>
        /// 发票号
        /// </summary>
        /// <param name="InviceNo"></param>
        /// <param name="InvoiceType"></param>
        public OutPatient( string InviceNo , OPDBillKind InvoiceType )
        {
            List<HIS.Model.MZ_CostMaster> models = null;
            HIS.Model.MZ_PatList model = null;
            string strWhere="";
            if ( InvoiceType == OPDBillKind.门诊收费发票 )
                strWhere = "TICKETNUM='" + InviceNo + "'" + oleDb.And( ) + Tables.mz_costmaster.HANG_FLAG + oleDb.EuqalTo( ) + "1";
            else
                strWhere = "TICKETNUM='" + InviceNo + "'" + oleDb.And( ) + Tables.mz_costmaster.HANG_FLAG + oleDb.EuqalTo( ) + "0";
            models = BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).GetListArray( strWhere  );
            if ( models.Count == 0 )
            {
                throw new Exception( "输入的发票流水号找不到病人登记信息" );
            }
            else
            {
                model = BindEntity<Model.MZ_PatList>.CreateInstanceDAL( oleDb ).GetModel( models[0].PatListID );
            }
            BindData( model );
            
        }
        /// <summary>
        /// 查找病人信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public static OutPatient[] GetPatient(string strWhere)
        {
            
            List<HIS.Model.MZ_PatList> patList = BindEntity<Model.MZ_PatList>.CreateInstanceDAL( oleDb ).GetListArray( strWhere );

            OutPatient[] patients = new OutPatient[patList.Count];

            for ( int i = 0 ; i < patList.Count ; i++ )
            {
                patients[i] = new OutPatient(patList[i].PatListID);
            }
             
            return patients;
        }
        /// <summary>
        /// 按处方日期获取病人列表
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static OutPatient[] GetPatientByPresDate( string beginDate , string endDate )
        {
            string strWhere = "patlistid in (select distinct patlistid from mz_presmaster where  presdate between '" + beginDate + "' and '" + endDate + "' and record_flag in (0,1,2)) and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID;
            return GetPatient( strWhere );
        }
        /// <summary>
        /// 获取病人处方
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="IsCharge">是否收费处检索</param>
        /// <returns>处方信息</returns>
        public Prescription[] GetPrescriptions(PresStatus status,bool IsCharge)
        {
            return GetPrescriptions( status , IsCharge , "" , "","" ,0);
        }
        /// <summary>
        /// 获取病人处方
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="IsCharge">是否收费处检索</param>
        /// <param name="ExceDeptID">执行科室ID</param>
        /// <returns>处方信息</returns>
        public Prescription[] GetPrescriptions( PresStatus status, bool IsCharge, int ExceDeptID )
        {
            return GetPrescriptions( status, IsCharge, "", "", "", ExceDeptID );
        }
        /// <summary>
        /// 获取病人处方
        /// </summary>
        /// <param name="status"></param>
        /// <param name="IsCharge">是否收费处检索</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="InvoiceNo">发票号</param>
        /// <param name="ExecDeptCode">执行科室ID</param>
        /// <returns>处方信息</returns>
        public Prescription[] GetPrescriptions( PresStatus status , bool IsCharge ,string beginDate,string endDate ,string InvoiceNo , int ExecDeptCode)
        {
            string condiction = "";
            switch ( status )
            {
                case PresStatus.全部:
                    condiction = " PatListID = " + this.PatListID + " AND Record_Flag in (0,1)";
                    break;
                case PresStatus.未收费:
                    condiction = " PatListID = " + this.PatListID + " AND Charge_Flag = 0 AND Record_Flag = 0 AND Drug_Flag = 0";
                    break;
                case PresStatus.已收费未发药:
                case PresStatus.已收费已退药:
                    condiction = " PatListID = " + this.PatListID + " AND Charge_Flag = 1 AND Record_Flag = 0 And Drug_Flag = 0";
                    break;
                case PresStatus.已收费已发药:
                    condiction = " PatListID = " + this.PatListID + " AND Charge_Flag = 1 AND Record_Flag = 0 And Drug_Flag = 1";
                    break;
            }
            condiction += " and docpresid=0 ";
            if ( !IsCharge )
                condiction = condiction + " and PRESTYPE in ('0','1','2','3') ";

            if ( ExecDeptCode != 0 )
                condiction = condiction + " and ExecDeptCode = '" + ExecDeptCode.ToString() + "'";

            if ( InvoiceNo.Trim( ) == "" )
            {
                if ( beginDate.Trim( ) != "" )
                {
                    condiction = condiction + " and PresDate>='" + beginDate + "'";
                }
                if ( endDate.Trim( ) != "" )
                {
                    condiction = condiction + " and PresDate<='" + endDate + "'";
                }
            }

            if ( InvoiceNo.Trim( ) != "" )
            {
                condiction = condiction + " and COSTMASTERID in (select COSTMASTERID from MZ_COSTMASTER where TICKETNUM='" + InvoiceNo + "' and RECORD_FLAG IN (0,1))";
            }

            condiction = condiction + " and hand_flag = " + (int)OPDOperationType.门诊收费 +" order by presmasterid";
            
            //得到实体列表
            List<HIS.Model.MZ_PresMaster> presMastList = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetListArray( condiction );
            //定义返回的处方
            Prescription[] prescriptions = new Prescription[presMastList.Count];
            for ( int i = 0 ; i < presMastList.Count ; i++ )
            {
                #region 读取处方头
                prescriptions[i] = new Prescription();
                prescriptions[i].Charge_Flag = presMastList[i].Charge_Flag;
                prescriptions[i].ChargeCode = presMastList[i].ChargeCode;
                prescriptions[i].ChargeID = presMastList[i].CostMasterID;
                prescriptions[i].Drug_Flag = presMastList[i].Drug_Flag;
                prescriptions[i].ExecDeptCode = presMastList[i].ExecDeptCode;
                prescriptions[i].ExecDocCode = presMastList[i].ExecDocCode;
                prescriptions[i].OldPresID = presMastList[i].OldID;
                prescriptions[i].PresCostCode = presMastList[i].PresCostCode;
                prescriptions[i].PrescriptionID = presMastList[i].PresMasterID;
                prescriptions[i].PrescType = presMastList[i].PresType;
                prescriptions[i].PresDeptCode = presMastList[i].PresDeptCode;
                prescriptions[i].PresDocCode = presMastList[i].PresDocCode;
                prescriptions[i].Record_Flag = presMastList[i].Record_Flag;
                prescriptions[i].TicketCode = presMastList[i].TicketCode;
                prescriptions[i].TicketNum = presMastList[i].TicketNum;
                prescriptions[i].Total_Fee = presMastList[i].Total_Fee;
                prescriptions[i].VisitNo = this.VisitNo;
                #endregion

                List<HIS.Model.MZ_PresOrder> presDetailList = BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetListArray( " PresMasterID = " + presMastList[i].PresMasterID + " order by order_flag" );
                //写明细
                PrescriptionDetail[] details = new PrescriptionDetail[presDetailList.Count];
                for ( int j = 0 ; j < presDetailList.Count ; j++ )
                {
                    #region 明细
                    details[j] = new PrescriptionDetail();
                    details[j].Amount = presDetailList[j].Amount;
                    details[j].BigitemCode = presDetailList[j].BigItemCode;
                    details[j].Buy_price = presDetailList[j].Buy_Price;
                    details[j].ComplexId = presDetailList[j].CaseID;
                    details[j].DetailId = presDetailList[j].PresOrderID;
                    details[j].ItemId = presDetailList[j].ItemID;
                    details[j].Itemname = presDetailList[j].ItemName;
                    details[j].ItemType = presDetailList[j].ItemType;
                    details[j].Order_Flag = presDetailList[j].Order_Flag;
                    details[j].PassId = presDetailList[j].PassID;
                    details[j].PresAmount = presDetailList[j].PresAmount;
                    details[j].PresctionId = presDetailList[j].PresMasterID;
                    details[j].RelationNum = presDetailList[j].RelationNum;
                    details[j].Sell_price = presDetailList[j].Sell_Price;
                    details[j].Standard = presDetailList[j].Standard;
                    details[j].Tolal_Fee = presDetailList[j].Tolal_Fee;
                    details[j].Unit = presDetailList[j].Unit;
                    details[j].Drug_Flag = prescriptions[i].Drug_Flag;
                    #endregion
                }
                prescriptions[i].PresDetails = details;
            }

            bool readDocPres = false;
            if ( Convert.ToInt32( HIS.MZ_BLL.OPDParamter.Parameters["017"] ) == 1 )
                readDocPres = true;

            if (readDocPres)
            {
                MZClinicInterface clinicInterface = new MZClinicInterface();
                if (status == PresStatus.未收费)
                {
                    List<Prescription> lstPrescription = new List<Prescription>();
                    for (int i = 0; i < prescriptions.Length; i++)
                        lstPrescription.Add(prescriptions[i]);
                    try
                    {
                        //Prescription[] docPrescs = HIS.MZDoc_BLL.OP_Prescription.GetPrescriptions(base.PatListID);
                        HIS.Interface.Structs.Prescription[] docPrescs = clinicInterface.GetPrescriptions( base.PatListID );
                        for (int i = 0; i < docPrescs.Length; i++)
                        {
                            docPrescs[i].Modified = true;
                            docPrescs[i].DocPresId = docPrescs[i].PrescriptionID;
                            docPrescs[i].PrescriptionID = 0;
                            for (int j = 0; j < docPrescs[i].PresDetails.Length; j++)
                            {
                                docPrescs[i].PresDetails[j].DocPrescDetailId = docPrescs[i].PresDetails[j].DetailId;
                                docPrescs[i].PresDetails[j].DetailId = 0;
                            }
                            lstPrescription.Add(docPrescs[i]);
                        }
                    }
                    catch (Exception err)
                    {
                        ErrorWriter.WriteLog(err.Message);
                        throw new Exception("读取医生未收费处方发生错误！");
                    }

                    prescriptions = lstPrescription.ToArray();
                }
            }
            return prescriptions;
        }
        /// <summary>
        /// 根据发票号获取处方
        /// </summary>
        /// <returns>处方信息</returns>
        public Prescription[] GetPrescriptionByInvoiceSerialNo( string InvoiceSerialNo  )
        {
            string condiction = "";
            condiction = " PatListID = " + this.PatListID + " AND Charge_Flag = 1 AND Record_Flag = 0 And TicketNum='" + InvoiceSerialNo + "' and hand_flag=" + (int)OPDOperationType.门诊收费;
            condiction = condiction + " order by presmasterid";

            //得到实体列表
            List<HIS.Model.MZ_PresMaster> presMastList = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetListArray( condiction );
            if ( presMastList.Count ==0 )
            {
                throw new Exception( "找不到发票信息！\r\n1、请确认发票号是否正确。\r\n2、请确认该发票是否已退费。" );
            }
            if ( presMastList.Count > 1 )
            {
                //判断发票里是否有药品
                foreach ( Model.MZ_PresMaster mz_presmaster in presMastList )
                {
                    if ( mz_presmaster.Drug_Flag == 1 )
                    {
                        throw new Exception( "该发票内有药品并且还未退药，要退费请先进行退药操作！" );
                    }
                }
            }
            else
            {
                if ( presMastList[0].Drug_Flag == 1 )
                {
                    throw new Exception( "该发票已经发药，要退费请先进行退药操作！" );
                }
            }

            //定义返回的处方
            Prescription[] prescriptions = new Prescription[presMastList.Count];
            for ( int i = 0 ; i < presMastList.Count ; i++ )
            {
                #region 读取处方头
                prescriptions[i].Charge_Flag = presMastList[i].Charge_Flag;
                prescriptions[i].ChargeCode = presMastList[i].ChargeCode;
                prescriptions[i].ChargeID = presMastList[i].CostMasterID;
                prescriptions[i].Drug_Flag = presMastList[i].Drug_Flag;
                prescriptions[i].ExecDeptCode = presMastList[i].ExecDeptCode;
                prescriptions[i].ExecDocCode = presMastList[i].ExecDocCode;
                prescriptions[i].OldPresID = presMastList[i].OldID;
                prescriptions[i].PresCostCode = presMastList[i].PresCostCode;
                prescriptions[i].PrescriptionID = presMastList[i].PresMasterID;
                prescriptions[i].PrescType = presMastList[i].PresType;
                prescriptions[i].PresDeptCode = presMastList[i].PresDocCode;
                prescriptions[i].PresDocCode = presMastList[i].PresDocCode;
                prescriptions[i].Record_Flag = presMastList[i].Record_Flag;
                prescriptions[i].TicketCode = presMastList[i].TicketCode;
                prescriptions[i].TicketNum = presMastList[i].TicketNum;
                prescriptions[i].Total_Fee = presMastList[i].Total_Fee;
                #endregion
                //HIS.DAL.MZ_PresOrder mz_presorder = new HIS.DAL.MZ_PresOrder( );
                //mz_presorder._oleDB = oleDb;
                List<HIS.Model.MZ_PresOrder> presDetailList = BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetListArray( " PresMasterID = " + presMastList[i].PresMasterID + " order by order_flag" );
                //写明细
                PrescriptionDetail[] details = new PrescriptionDetail[presDetailList.Count];
                for ( int j = 0 ; j < presDetailList.Count ; j++ )
                {
                    #region 明细
                    details[j].Amount = presDetailList[j].Amount;
                    details[j].BigitemCode = presDetailList[j].BigItemCode;
                    details[j].Buy_price = presDetailList[j].Buy_Price;
                    details[j].ComplexId = presDetailList[j].CaseID;
                    details[j].DetailId = presDetailList[j].PresOrderID;
                    details[j].ItemId = presDetailList[j].ItemID;
                    details[j].Itemname = presDetailList[j].ItemName;
                    details[j].ItemType = presDetailList[j].ItemType;
                    details[j].Order_Flag = presDetailList[j].Order_Flag;
                    details[j].PassId = presDetailList[j].PassID;
                    details[j].PresAmount = presDetailList[j].PresAmount;
                    details[j].PresctionId = presDetailList[j].PresMasterID;
                    details[j].RelationNum = presDetailList[j].RelationNum;
                    details[j].Sell_price = presDetailList[j].Sell_Price;
                    details[j].Standard = presDetailList[j].Standard;
                    details[j].Tolal_Fee = presDetailList[j].Tolal_Fee;
                    details[j].Unit = presDetailList[j].Unit;
                    #endregion
                }
                prescriptions[i].PresDetails = details;
            }
            
            return prescriptions;
        }
        /// <summary>
        ///  登记本次就诊
        /// </summary>
        /// <returns>本次就诊号</returns>
        public int NewRegister()
        {
            oleDb.BeginTransaction();
            try
            {
                HIS.Model.PatientInfo patinfo = new HIS.Model.PatientInfo();
                BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).Add(patinfo);


                HIS.Model.MZ_PatList register = new HIS.Model.MZ_PatList( );
                register.CureDate = Convert.ToDateTime( HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString( "yyyy-MM-dd" ) );//就诊日期
                register.CureDeptCode = "";//就诊科室
                register.CureEmpCode = "";//就诊医生
                register.DiseaseCode = "";//疾病代码
                register.DiseaseName = "";//疾病名称
                register.HpCode = "";//就医机构代码
                register.HpGrade = "";//就医机构级别
                register.MediCard = "";//医疗证卡号
                register.MediType = "";//就诊类型
                register.PatCode = "";//病人代码
                register.PatID = patinfo.PatID;
                register.PatListID = 0;//本次就诊号
                register.PatName = "";//病人姓名
                register.PatSex = "";//性别
                register.PYM = ""; //拼音码
                register.WBM = ""; //五笔码
                register.Age = 0;
                register.VisitNo = ( new RegController( ) ).CreateVisitNo( );

                int newRegisterno = 0;
                newRegisterno = BindEntity<Model.MZ_PatList>.CreateInstanceDAL( oleDb ).Add( register );
                if ( newRegisterno > 0 )
                {
                    this.PatID = patinfo.PatID;
                    this.PatListID = newRegisterno;
                    this.VisitNo = register.VisitNo;
                    oleDb.CommitTransaction( );
                    return this.PatListID; //返回就诊ID

                }
                else
                    throw new OperatorException( "创建病人登记信息失败！" );
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
                throw new Exception("新登记病人信息发生错误！");
            }
            
        }
        /// <summary>
        /// 更新本次就诊登记信息
        /// </summary>
        /// <returns>成功标识;true</returns>
        public bool UpdateRegister()
        {
            try
            {


                HIS.Model.MZ_PatList register = BindEntity<Model.MZ_PatList>.CreateInstanceDAL( oleDb ).GetModel( this.PatListID );
                register.CureDeptCode = _cureDeptCode;//就诊科室
                register.CureEmpCode = _cureEmpCode;    //就诊医生
                register.DiseaseCode = _diseaseCode;    //疾病代码
                if ( register.REG_DOC_CODE.Trim( ) == "" )
                {
                    //如果挂号医生为空，则将挂号医生更改为当前就诊医生
                    register.REG_DOC_CODE = _cureEmpCode ;
                    register.REG_DOC_NAME = BaseDataController.GetName( BaseDataCatalog.人员列表, Convert.ToInt32( _cureEmpCode ) ); //PublicDataReader.GetEmployeeNameById( Convert.ToInt32(_cureEmpCode) );
                    register.REG_DEPT_CODE = _cureDeptCode;
                    register.REG_DEPT_NAME = BaseDataController.GetName( BaseDataCatalog.科室列表, Convert.ToInt32( _cureDeptCode ) );// PublicDataReader.GetDeptNameById( Convert.ToInt32( _cureDeptCode ) );
                }
               
                register.DiseaseName = _diseaseName.Replace( "|" , "" ) + "|" + _diseaseMemo.Replace( "|" , "" );    //疾病名称
                register.HpCode = _hpCode;              //就医机构代码(病人单位代码)
                register.HpGrade = _hpGrade;            //就医机构级别
                register.MediCard = _mediCard;          //医疗证卡号
                register.MediType = _mediType;          //就诊类型
                register.PatCode = "";                  //病人代码????
                register.PatID = this.PatID;                //病人ID，如果是普通病人，则为0；否则参见PatientInfo.PatID;
                register.PatListID = this.PatListID;        //本次就诊号
                register.PatName = this.PatientName;        //病人姓名
                register.PatSex = this.Sex;                 //性别
                register.PYM = this.PYM;                      //拼音码
                register.WBM = this.WBM;                      //五笔码
                register.Age = this.Age;                        //年龄
                register.VisitNo = this.VisitNo;            //就诊号(门诊号)
                BindEntity<Model.MZ_PatList>.CreateInstanceDAL( oleDb ).Update( register );

                Model.PatientInfo patientinfo = BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).GetModel(Convert.ToInt32( this.PatID) );
                if (patientinfo != null)
                {
                    patientinfo.PatName = register.PatName;
                    patientinfo.PatSex = register.PatSex;
                    patientinfo.ALLERGIC = this.Allergic;
                    BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).Update(patientinfo);
                }

                //将处方表中挂号的记录改为处方医生
                string strWhere = Tables.mz_presmaster.PATLISTID + oleDb.EuqalTo() + this.PatListID + oleDb.And( ) +
                                Tables.mz_presmaster.HAND_FLAG + oleDb.EuqalTo() + "0";
                Model.MZ_PresMaster mz_presmaster = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( strWhere );
                if ( mz_presmaster != null )
                {
                    if ( mz_presmaster.PresDocCode == null || mz_presmaster.PresDocCode.Trim( ) == "" )
                    {
                        strWhere += oleDb.And( ) + Tables.mz_presmaster.PRESMASTERID + oleDb.EuqalTo( ) + mz_presmaster.PresMasterID;
                        BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( strWhere ,
                                Tables.mz_presmaster.PRESDOCCODE + oleDb.EuqalTo( ) + "'" + _cureEmpCode + "'" ,
                                Tables.mz_presmaster.PRESDEPTCODE + oleDb.EuqalTo( ) + "'" + _cureDeptCode + "'" );
                    }
                }
                return true;

            }
            catch ( OperatorException operr )
            {
                throw operr;
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Message );
                throw new Exception("更新病人等级信息发生错误！");
            }
        }
        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="Condiction">检索条件</param>
        /// <returns></returns>
        public static System.Data.DataTable GetPatientList(string Condiction)
        {
            return BindEntity<Model.MZ_PatList>.CreateInstanceDAL( oleDb ).GetList( Condiction );
        }
        /// <summary>
        /// 读取具有有效处方的病人列表
        /// </summary>
        /// <param name="ExistsVisitDay">有效就诊期</param>
        /// <param name="ExistsPresDays">处方有效期</param>
        /// <returns></returns>
        public static System.Data.DataTable GetPatientListByExistsPrescrition( int ExistsVisitDay, int ExistsPresDays )
        {
            HIS.DAL.MZ_DAL dal = new HIS.DAL.MZ_DAL();
            dal._OleDB = oleDb;
            DateTime serverDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            string pres_endDate = serverDate.ToString( "yyyy-MM-dd" ) + " 23:59:59.999999";
            string pres_beginDate = serverDate.AddDays( ExistsPresDays * -1 ).ToString( "yyyy-MM-dd" ) + " 00:00:00.000000";

            string visit_endDate = serverDate.ToString( "yyyy-MM-dd" ) + " 23:59:59.999999";
            string visit_beginDate = serverDate.AddDays( ExistsVisitDay * -1 ).ToString( "yyyy-MM-dd" ) + " 00:00:00.000000";

            //return dal.GetPatientListByExistsPrescrition( visit_beginDate, visit_endDate, pres_beginDate, pres_endDate );
            string sql = @"select distinct a.patlistid,a.patid,patname,patsex,curedate,pym,wbm,visitno 
                            from mz_patlist a,mz_presmaster b where a.patlistid = b.patlistid 
                            and visitno <>'' 
                            and b.presdate between '" + visit_beginDate + "' and '" + visit_endDate + @"' 
                            and b.record_flag = 0 order by curedate desc";
            return oleDb.GetDataTable( sql );
        }
        /// <summary>
        /// 判断挂号病人是否已经退号,如果挂号已经退费，返回true
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        public static bool IsCancelRegister(OutPatient Patient)
        {
            string sql = @"select record_flag from mz_costmaster where hang_flag =0 
                            and workid=" + EntityConfig.WorkID + " and patlistid=" + Patient.PatListID + "";
            DataTable tb = oleDb.GetDataTable( sql );
            if ( tb.Rows.Count == 0 )
                return false;
            else
            {
                int flag = Convert.ToInt32(tb.Rows[0]["record_flag"] );
                if ( flag == 0 )
                    return false;
                else
                    return true;
            }
        }
        /// <summary>
        /// 得到病人过敏史
        /// </summary>
        /// <param name="PatId"></param>
        /// <returns></returns>
        private string GetAllergic(int PatId)
        {
            Model.PatientInfo patinfo = BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).GetModel(PatId);
            if (patinfo == null)
            {
                return "";
            }
            else
            {
                if (patinfo.ALLERGIC != null)
                    return patinfo.ALLERGIC;
                else
                    return "";   
            }
        }
    }
}
