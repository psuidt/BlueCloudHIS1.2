using System;
namespace HIS.Model
{
	/// <summary>
	/// 住院病人
	/// </summary>
	public class ZY_PatList
	{
		public ZY_PatList()
		{}
		#region Model
		private int _patlistid;
		private string _cureno;
		private int _patid;
        private string _patientcode;
		private string _curedeptcode;
		private string _curedoccode;
		private string _origindeptcode;
		private string _origindoccode;
		private string _pattype;
		private string _diseasecode;
		private string _diseasename;
		private DateTime _curedate;
		private string _currdeptcode;
		private string _bedcode;
		private string _curestate;
		private int _out_flag;
		private string _outdiagncode;
		private string _outdiagnname;
		private DateTime _outdate;
		private int _realivenum;
		private DateTime _markdate;
		private string _markempcode;
        private string _Nccm_NO;
        private string _DbName;
        private decimal _DbFee;
        private PatientInfo _patientInfo;
		/// <summary>
		/// ID
        /// 
		/// </summary>
		public int PatListID
		{
			set{ _patlistid=value;}
			get{return _patlistid;}
		}
		/// <summary>
        /// 住院号
		/// </summary>
		public string CureNo
		{
			set{ _cureno=value;}
			get{return _cureno;}
		}
		/// <summary>
        /// 病人ID
		/// </summary>
		public int PatID
		{
			set{ _patid=value;}
			get{return _patid;}
		}
        /// <summary>
        /// 病人类型代码（医保、农合、自费等）
        /// </summary>
        public string PatientCode
        {
            set { _patientcode = value; }
            get { return _patientcode; }
        }
		/// <summary>
        /// 入院科室代码
		/// </summary>
		public string CureDeptCode
		{
			set{ _curedeptcode=value;}
			get{return _curedeptcode;}
		}
		/// <summary>
        /// 经治医生代码
		/// </summary>
		public string CureDocCode
		{
			set{ _curedoccode=value;}
			get{return _curedoccode;}
		}
		/// <summary>
        /// 门诊科室代码
		/// </summary>
		public string OriginDeptCode
		{
			set{ _origindeptcode=value;}
			get{return _origindeptcode;}
		}
		/// <summary>
        /// 门诊医生代码
		/// </summary>
		public string OriginDocCode
		{
			set{ _origindoccode=value;}
			get{return _origindoccode;}
		}
		/// <summary>
        /// 病人类型
		/// </summary>
		public string PatType
		{
			set{ _pattype=value;}
			get{return _pattype;}
		}
		/// <summary>
        /// 疾病代码
		/// </summary>
		public string DiseaseCode
		{
			set{ _diseasecode=value;}
			get{return _diseasecode;}
		}
		/// <summary>
        /// 疾病名称
		/// </summary>
		public string DiseaseName
		{
			set{ _diseasename=value;}
			get{return _diseasename;}
		}
		/// <summary>
        /// 入院日期
		/// </summary>
		public DateTime CureDate
		{
			set{ _curedate=value;}
			get{return _curedate;}
		}
		/// <summary>
        /// 当前科室代码(出院科室)
		/// </summary>
		public string CurrDeptCode
		{
			set{ _currdeptcode=value;}
			get{return _currdeptcode;}
		}
		/// <summary>
        /// 床位代码
		/// </summary>
		public string BedCode
		{
			set{ _bedcode=value;}
			get{return _bedcode;}
		}
		/// <summary>
        /// 入院状态（急、危重、一般、其他）
		/// </summary>
		public string CureState
		{
			set{ _curestate=value;}
			get{return _curestate;}
		}
		/// <summary>
        /// 出院状态（好转）
		/// </summary>
		public int Out_Flag
		{
			set{ _out_flag=value;}
			get{return _out_flag;}
		}
		/// <summary>
        /// 出院诊断代码
		/// </summary>
		public string OutDiagnCode
		{
			set{ _outdiagncode=value;}
			get{return _outdiagncode;}
		}
		/// <summary>
        /// 出院诊断名称
		/// </summary>
		public string OutDiagnName
		{
			set{ _outdiagnname=value;}
			get{return _outdiagnname;}
		}
		/// <summary>
        /// 出院时间
		/// </summary>
		public DateTime OutDate
		{
			set{ _outdate=value;}
			get{return _outdate;}
		}
		/// <summary>
        /// 实际住院天数
		/// </summary>
		public int ReaLiveNum
		{
			set{ _realivenum=value;}
			get{return _realivenum;}
		}
		/// <summary>
        /// 登记时间
		/// </summary>
		public DateTime MarkDate
		{
			set{ _markdate=value;}
			get{return _markdate;}
		}
		/// <summary>
        /// 登记人
		/// </summary>
		public string MarkEmpCode
		{
			set{ _markempcode=value;}
			get{return _markempcode;}
		}
        /// <summary>
        /// 病人信息
        /// </summary>
        public PatientInfo PatientInfo
        {
            set { _patientInfo = value; }
            get
            {
                if (_patientInfo == null)
                    _patientInfo = HIS.SYSTEM.Core.BindEntity<PatientInfo>.CreateInstanceDAL(HIS.SYSTEM.Core.BaseBLL.oleDb).GetModel(PatID);
                return _patientInfo;
            }
        }
        /// <summary>
        /// 农合编码
        /// </summary>
        public string Nccm_NO
        {
            get
            {
                return _Nccm_NO;
            }
            set
            {
                _Nccm_NO = value;
            }
        }
        /// <summary>
        /// 担保人
        /// </summary>
        public string DbName
        {
            get
            {
                return _DbName;
            }
            set
            {
                _DbName = value;
            }
        }
        /// <summary>
        /// 担保金额
        /// </summary>
        public decimal DbFee
        {
            get
            {
                return _DbFee;
            }
            set
            {
                _DbFee = value;
            }
        }
		#endregion Model

	}
}

