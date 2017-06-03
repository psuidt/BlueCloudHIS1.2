using System;
using System.Collections.Generic;
using System.Text;
using HIS.Model;
using HIS.BLL;
using HIS.MSAccess;


namespace HIS_DJSFManager.类
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
        /// 就医机构代码
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
        /// 就医机构级别
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
            //HIS.DAL.MZ_PatList mz_patList = new HIS.DAL.MZ_PatList( );
            //mz_patList._OleDB = new HIS.SYSTEM.DatabaseAccessLayer.OleDB( );
            //mz_patList._OleDB.Initialize( );
            MZ_PatList model = (MZ_PatList)MSAccessDb.GetModel( "MZ_PATLIST" , Tables.mz_patlist.PATLISTID + "=" + RegisterID , typeof( MZ_PatList ) );
            if ( model == null )
            {
                throw new Exception( "无效的就诊号！");
            }
            this.PatListID = model.PatListID ;
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
            _hpGrade = model.HpGrade ;
            _cureDeptCode = model.CureDeptCode;
            _cureEmpCode = model.CureEmpCode;
            _diseaseCode = model.DiseaseCode ;
            string[] disease = model.DiseaseName.Split( "|".ToCharArray() );
            _diseaseName = disease[0];
            if ( disease.Length > 1 )
                _diseaseMemo = disease[1];

            _cureDate = model.CureDate;
             
        }
        /// <summary>
        /// 发票流水号获得病人
        /// </summary>
        /// <param name="InvoiceSerialNo">发票号</param>
        public OutPatient( string VisitNo )
        {

            List<HIS.Model.MZ_CostMaster> models = null;
            HIS.Model.MZ_PatList model = null;

            model = (MZ_PatList)MSAccessDb.GetModel( "MZ_PATLIST" , Tables.mz_patlist.VISITNO + "='" + VisitNo + "'" , typeof( MZ_PatList ) );
            if ( model==null )
            {
                throw new Exception( "输入的门诊就诊号找不到病人登记信息" );
            }
            
            this.PatListID = model.PatListID;
            this.PatID = model.PatID;
            this.PatientName = model.PatName;
            this.VisitNo = model.VisitNo;
            this.Sex = model.PatSex;
            this.Age = model.Age;
            this.PYM = model.PYM;
            this.WBM = model.WBM;
            _mediCard = model.MediCard;
            _mediType = model.MediType;
            _hpCode = model.HpCode;
            _hpGrade = model.HpGrade;
            _cureDeptCode = model.CureDeptCode;
            _cureEmpCode = model.CureEmpCode;
            _diseaseCode = model.DiseaseCode;
            string[] disease = model.DiseaseName.Split( "|".ToCharArray() );
            _diseaseName = disease[0];
            if ( disease.Length > 1 )
                _diseaseMemo = disease[1];
            _cureDate = model.CureDate;
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
                strWhere = "TICKETNUM='" + InviceNo + "'" + " and " + Tables.mz_costmaster.HANG_FLAG +  " = 1";
            else
                strWhere = "TICKETNUM='" + InviceNo + "'" + " and " + Tables.mz_costmaster.HANG_FLAG +  " = 0";
            models = MSAccessDb.GetListArray<MZ_CostMaster>( "MZ_COSTMASTER",strWhere );
            if ( models.Count == 0 )
            {
                throw new Exception( "输入的发票流水号找不到病人登记信息" );
            }
            else
            {
                model = (MZ_PatList)MSAccessDb.GetModel( "MZ_PATLIST" , Tables.mz_patlist.PATLISTID + "=" + models[0].PatListID , typeof( MZ_PatList ) );
            }
            
            this.PatListID = model.PatListID;
            this.PatID = model.PatID;
            this.PatientName = model.PatName;
            this.VisitNo = model.VisitNo;
            this.Sex = model.PatSex;
            this.Age = model.Age;
            this.PYM = model.PYM;
            this.WBM = model.WBM;
            _mediCard = model.MediCard;
            _mediType = model.MediType;
            _hpCode = model.HpCode;
            _hpGrade = model.HpGrade;
            _cureDeptCode = model.CureDeptCode;
            _cureEmpCode = model.CureEmpCode;
            _diseaseCode = model.DiseaseCode;
            string[] disease = model.DiseaseName.Split( "|".ToCharArray( ) );
            _diseaseName = disease[0];
            if ( disease.Length > 1 )
                _diseaseMemo = disease[1];
            _cureDate = model.CureDate;
        }
        /// <summary>
        /// 查找病人信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public static OutPatient[] GetPatient(string strWhere)
        {
            
            List<HIS.Model.MZ_PatList> patList = MSAccessDb.GetListArray<MZ_PatList>( "MZ_PATLIST", strWhere );
            OutPatient[] patients = new OutPatient[patList.Count];

            for ( int i = 0 ; i < patList.Count ; i++ )
            {
                patients[i] = new OutPatient(patList[i].PatListID);
            }
             
            return patients;
        }
        public static OutPatient[] GetPatientByPresDate( string beginDate , string endDate )
        {
            string strWhere = "patlistid in (select distinct patlistid from mz_presmaster where  presdate between '" + beginDate + "' and '" + endDate + "' and record_flag in (0,1,2)) ";
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
            if ( !IsCharge )
                condiction = condiction + " and PRESTYPE in ('1','2','3') ";

            if ( ExecDeptCode != 0 )
                condiction = condiction + " and ExecDeptCode = '" + ExecDeptCode.ToString() + "'";

            if ( InvoiceNo.Trim( ) == "" )
            {
                if ( beginDate.Trim( ) != "" )
                {
                    condiction = condiction + " and PresDate>=#" + beginDate + "#";
                }
                if ( endDate.Trim( ) != "" )
                {
                    condiction = condiction + " and PresDate<=#" + endDate + "#";
                }
            }

            if ( InvoiceNo.Trim( ) != "" )
            {
                condiction = condiction + " and COSTMASTERID in (select COSTMASTERID from MZ_COSTMASTER where TICKETNUM='" + InvoiceNo + "' and RECORD_FLAG IN (0,1))";
            }

            condiction = condiction + " and hand_flag = " + (int)OPDOperationType.门诊收费 +" order by presmasterid";
            
            //得到实体列表
            List<HIS.Model.MZ_PresMaster> presMastList = MSAccessDb.GetListArray<MZ_PresMaster>("MZ_PRESMASTER", condiction );
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
                prescriptions[i].VisitNo = this.VisitNo;
                #endregion
                //HIS.DAL.MZ_PresOrder mz_presorder = new HIS.DAL.MZ_PresOrder( );
                //mz_presorder._oleDB = oleDb;
                List<HIS.Model.MZ_PresOrder> presDetailList = MSAccessDb.GetListArray<MZ_PresOrder>("MZ_PRESORDER", " PresMasterID = " + presMastList[i].PresMasterID + " order by order_flag" );
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
                    details[j].Drug_Flag = prescriptions[i].Drug_Flag;
                    #endregion
                }
                prescriptions[i].PresDetails = details;
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
            List<HIS.Model.MZ_PresMaster> presMastList = MSAccessDb.GetListArray<MZ_PresMaster>("MZ_PRESMASTER", condiction );
            if ( presMastList.Count ==0 )
            {
                throw new Exception( "找不到发票信息！\r\n1、请确认发票号是否正确。\r\n2、请确认该发票是否已退费。" );
            }
            if ( presMastList.Count > 1 )
            {
                //判断发票里是否有药品
                foreach ( MZ_PresMaster mz_presmaster in presMastList )
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
                List<HIS.Model.MZ_PresOrder> presDetailList = MSAccessDb.GetListArray<MZ_PresOrder>("MZ_PRESORDER", " PresMasterID = " + presMastList[i].PresMasterID + " order by order_flag" );
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
            MSAccessDb.BeginTrans();
            try
            {
                HIS.Model.MZ_PatList register = new HIS.Model.MZ_PatList( );
                register.CureDate = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) );//就诊日期
                register.CureDeptCode = _cureDeptCode;//就诊科室
                register.CureEmpCode = _cureEmpCode;//就诊医生
                register.DiseaseCode = _diseaseCode;//疾病代码
                register.DiseaseName = _diseaseName;//疾病名称
                register.HpCode = _hpCode;//就医机构代码
                register.HpGrade = _hpGrade;//就医机构级别
                register.MediCard = _mediCard;//医疗证卡号
                register.MediType = _mediType;//就诊类型
                register.PatCode = " ";//病人代码
                register.PatID = 0;//病人ID，如果是普通病人，则为0；否则参见PatientInfo.PatID;
                register.PatName = PatientName;//病人姓名
                register.PatSex = Sex;//性别
                register.PYM = " "; //拼音码
                register.WBM = " "; //五笔码
                register.Age = Age;
                register.VisitNo = " ";//( new RegController( ) ).CreateVisitNo( );
                register.PatListID = MSAccessDb.GetMaxID( "MZ_PATLIST" , Tables.mz_patlist.PATLISTID );
                int newRegisterno = 0;
                MSAccessDb.InsertRecord( register , Tables.mz_patlist.PATLISTID );
                newRegisterno = register.PatListID;
                if ( newRegisterno > 0 )
                {
                    this.PatListID = newRegisterno;
                    this.VisitNo = register.VisitNo;
                    MSAccessDb.CommitTrans( );
                    return this.PatListID; //返回就诊ID

                }
                else
                    throw new Exception( "创建病人登记信息失败！" );
            }
            catch ( Exception err )
            {
                MSAccessDb.RollbackTrans( );
                throw new Exception("新登记病人信息发生错误！");
            }
            
        }
        /// <summary>
        /// 更新本次就诊登记信息
        /// </summary>
        /// <returns>成功标识;true</returns>
        public bool UpdateRegister()
        {
            //HIS.SYSTEM.DatabaseAccessLayer.OleDB oleDB = new HIS.SYSTEM.DatabaseAccessLayer.OleDB( );
            //oleDB.Initialize( );
            try
            {
                //HIS.DAL.MZ_PatList mz_patList = new HIS.DAL.MZ_PatList( );
                //mz_patList._OleDB = oleDB;
                HIS.Model.MZ_PatList register = (MZ_PatList)MSAccessDb.GetModel( "MZ_PATLIST" , Tables.mz_patlist.PATLISTID + "=" + this.PatListID , typeof( MZ_PatList ) );
                register.CureDeptCode = _cureDeptCode;//就诊科室
                register.CureEmpCode = _cureEmpCode;    //就诊医生
                register.DiseaseCode = _diseaseCode;    //疾病代码
                if ( register.REG_DOC_CODE.Trim( ) == "" )
                {
                    //如果挂号医生为空，则将挂号医生更改为当前就诊医生
                    register.REG_DOC_CODE = _cureEmpCode ;
                    register.REG_DOC_NAME = DataReader.GetEmployeeNameById( Convert.ToInt32(_cureEmpCode) );
                    register.REG_DEPT_CODE = _cureDeptCode;
                    register.REG_DEPT_NAME = DataReader.GetDeptNameById( Convert.ToInt32(_cureDeptCode) );
                }
               
                register.DiseaseName = _diseaseName.Replace( "|" , "" ) + "|" + _diseaseMemo.Replace( "|" , "" );    //疾病名称
                register.HpCode = _hpCode;              //就医机构代码
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
                MSAccessDb.UpdateRecord( register );
                //将处方表中挂号的记录改为处方医生
                string strWhere = Tables.mz_presmaster.PATLISTID + "=" + this.PatListID + " and " +
                                Tables.mz_presmaster.HAND_FLAG +  "= 0";
                MZ_PresMaster mz_presmaster = (MZ_PresMaster)MSAccessDb.GetModel( "MZ_PRESMASTER" , strWhere , typeof( MZ_PresMaster ) );
                if ( mz_presmaster != null )
                {
                    if ( mz_presmaster.PresDocCode == null || mz_presmaster.PresDocCode.Trim( ) == "" )
                    {
                        strWhere += " and " + Tables.mz_presmaster.PRESMASTERID + "=" + mz_presmaster.PresMasterID;
                        
                        MSAccessDb.UpdateRecord( new string[]{Tables.mz_presmaster.PRESDOCCODE + "=" + "'" + _cureEmpCode + "'" ,
                                                            Tables.mz_presmaster.PRESDEPTCODE + "=" + "'" + _cureDeptCode + "'"} ,
                                                strWhere , typeof( MZ_PresMaster ) );
                    }
                }
                return true;

            }
            
            catch ( Exception err )
            {
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
            //return BindEntity<MZ_PatList>.CreateInstanceDAL( oleDb ).GetList( Condiction );
            if ( Condiction.Trim() == "" )
                return MSAccessDb.GetDataTable( "select * from mz_patlist" );
            else
                return MSAccessDb.GetDataTable( "select * from mz_patlist where " + Condiction );
        }
        /// <summary>
        /// 读取具有有效处方的病人列表
        /// </summary>
        /// <param name="ExistsVisitDay">有效就诊期</param>
        /// <param name="ExistsPresDays">处方有效期</param>
        /// <returns></returns>
        public static System.Data.DataTable GetPatientListByExistsPrescrition( int ExistsVisitDay, int ExistsPresDays )
        {
            
            DateTime serverDate = DateTime.Now;
            string pres_endDate = serverDate.ToString( "yyyy-MM-dd" ) + " 23:59:59.999999";
            string pres_beginDate = serverDate.AddDays( ExistsPresDays * -1 ).ToString( "yyyy-MM-dd" ) + " 00:00:00.000000";

            string visit_endDate = serverDate.ToString( "yyyy-MM-dd" ) + " 23:59:59.999999";
            string visit_beginDate = serverDate.AddDays( ExistsVisitDay * -1 ).ToString( "yyyy-MM-dd" ) + " 00:00:00.000000";

            //return dal.GetPatientListByExistsPrescrition( visit_beginDate, visit_endDate, pres_beginDate, pres_endDate );
            string sql = @"select distinct a.patlistid,a.patid,patname,patsex,curedate,pym,wbm,visitno 
                            from mz_patlist a,mz_presmaster b where a.patlistid = b.patlistid 
                            and visitno <>'' 
                            and b.presdate between #" + visit_beginDate + "# and #" + visit_endDate + @"# 
                            and b.record_flag = 0 order by curedate desc";
            return MSAccessDb.GetDataTable( sql );
        }
        
    }
}
